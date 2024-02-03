using Microsoft.AspNetCore.Mvc;
using Quartz;
using SqlSugar;
using Ams.Kernel.Filters;
using Ams.Infrastructure.CustomException;
using Ams.Tasks;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Model.Routine;
using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Services.IService.Routine;
namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 计划任务
    /// API控制器
    /// @Author: (Lean365:Davis.Cheng)
    /// @Date: (2023-12-15)
    /// </summary>
    [Verify]
    [Route("routine/tasks")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class TasksQzController : BaseController
    {
        private ITasksQzService _tasksQzService;
        private ITaskSchedulerServer _schedulerServer;

        public TasksQzController(
            ITasksQzService TasksQzService,
            ITaskSchedulerServer taskScheduler)
        {
            _tasksQzService = TasksQzService;
            _schedulerServer = taskScheduler;
        }

        /// <summary>
        /// 查询计划任务列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:tasks:list")]
        public IActionResult ListTask([FromQuery] TasksQzQueryDto parm)
        {
            var response = _tasksQzService.SelectTaskList(parm);
            return SUCCESS(response, TIME_FORMAT_YYYMMDD);
        }

        /// <summary>
        /// 查询单个计划任务
        /// </summary>
        /// <param name="id">编码</param>
        /// <returns></returns>
        [HttpGet("get")]
        public IActionResult Get(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return SUCCESS(_tasksQzService.GetId(id));
            }
            return SUCCESS(0);
        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <returns></returns>
        [HttpPost("create")]
        [ActionPermissionFilter(Permission = "routine:tasks:add")]
        [Log(Title = "添加任务", BusinessType = BusinessType.INSERT)]
        public IActionResult Create([FromBody] TasksQzCreateDto parm)
        {
            //判断是否已经存在
            if (_tasksQzService.Any(m => m.Name == parm.Name))
            {
                throw new CustomizeException($"添加 {parm.Name} 失败，该用任务存在，不能重复！");
            }
            if (!string.IsNullOrEmpty(parm.Cron) && !CronExpression.IsValidExpression(parm.Cron))
            {
                throw new CustomizeException($"cron表达式不正确");
            }
            if (string.IsNullOrEmpty(parm.ApiUrl) && parm.TaskType == 2)
            {
                throw new CustomizeException($"地址不能为空");
            }
            if (string.IsNullOrEmpty(parm.SqlText) && parm.TaskType == 3)
            {
                throw new CustomizeException($"sql语句不能为空");
            }
            if (parm.TaskType == 1 && (parm.AssemblyName.IsEmpty() || parm.ClassName.IsEmpty()))
            {
                throw new CustomizeException($"程序集或者类名不能为空");
            }
            //从 Dto 映射到 实体
            var tasksQz = parm.Adapt<TasksQz>().ToCreate(HttpContext);
            tasksQz.Create_by = HttpContext.GetName();
            tasksQz.ID = SnowFlakeSingle.Instance.NextId().ToString();

            return SUCCESS(_tasksQzService.AddTasks(tasksQz));
        }

        /// <summary>
        /// 更新任务
        /// </summary>
        /// <returns></returns>
        [HttpPost("update")]
        [ActionPermissionFilter(Permission = "routine:tasks:edit")]
        [Log(Title = "修改任务", BusinessType = BusinessType.UPDATE)]
        public async Task<IActionResult> Update([FromBody] TasksQzCreateDto parm)
        {
            //判断是否已经存在
            if (_tasksQzService.Any(m => m.Name == parm.Name && m.ID != parm.ID))
            {
                throw new CustomizeException($"更新 {parm.Name} 失败，该用任务存在，不能重复！");
            }
            if (string.IsNullOrEmpty(parm.Cron) && parm.TriggerType == 1)
            {
                throw new CustomizeException($"触发器 Corn 模式下，运行时间表达式必须填写");
            }
            if (!string.IsNullOrEmpty(parm.Cron) && !CronExpression.IsValidExpression(parm.Cron))
            {
                throw new CustomizeException($"cron表达式不正确");
            }
            var tasksQz = _tasksQzService.GetFirst(m => m.ID == parm.ID);
            if (string.IsNullOrEmpty(parm.ApiUrl) && parm.TaskType == 2)
            {
                throw new CustomizeException($"api地址不能为空");
            }

            if (tasksQz.IsStart == 1)
            {
                throw new CustomizeException($"该任务正在运行中，请先停止在更新");
            }
            var model = parm.Adapt<TasksQz>();
            model.Update_by = HttpContext.GetName();
            int response = _tasksQzService.UpdateTasks(model);
            if (response > 0)
            {
                var respon = await _schedulerServer.UpdateTaskScheduleAsync(tasksQz);
            }

            return SUCCESS(response);
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete")]
        [ActionPermissionFilter(Permission = "routine:tasks:delete")]
        [Log(Title = "删除任务", BusinessType = BusinessType.DELETE)]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new CustomizeException("删除任务 Id 不能为空");
            }

            if (!_tasksQzService.Any(m => m.ID == id))
            {
                throw new CustomizeException("任务不存在");
            }

            var tasksQz = _tasksQzService.GetFirst(m => m.ID == id);
            var taskResult = await _schedulerServer.DeleteTaskScheduleAsync(tasksQz);

            if (taskResult.IsSuccess())
            {
                _tasksQzService.Delete(id);
            }
            return ToResponse(taskResult);
        }

        /// <summary>
        /// 启动任务
        /// </summary>
        /// <returns></returns>
        [HttpGet("start")]
        [ActionPermissionFilter(Permission = "routine:tasks:start")]
        [Log(Title = "启动任务", BusinessType = BusinessType.OTHER)]
        public async Task<IActionResult> Start(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new CustomizeException("启动任务 Id 不能为空");
            }

            if (!_tasksQzService.Any(m => m.ID == id))
            {
                throw new CustomizeException("任务不存在");
            }

            var tasksQz = _tasksQzService.GetFirst(m => m.ID == id);
            var taskResult = await _schedulerServer.AddTaskScheduleAsync(tasksQz);

            if (taskResult.IsSuccess())
            {
                tasksQz.IsStart = 1;
                _tasksQzService.Update(tasksQz);
            }

            return ToResponse(taskResult);
        }

        /// <summary>
        /// 停止任务
        /// </summary>
        /// <returns></returns>
        [HttpGet("stop")]
        [ActionPermissionFilter(Permission = "routine:tasks:stop")]
        [Log(Title = "停止任务", BusinessType = BusinessType.OTHER)]
        public async Task<IActionResult> Stop(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new CustomizeException("停止任务 Id 不能为空");
            }

            if (!_tasksQzService.Any(m => m.ID == id))
            {
                throw new CustomizeException("任务不存在");
            }

            var tasksQz = _tasksQzService.GetFirst(m => m.ID == id);
            var taskResult = await _schedulerServer.DeleteTaskScheduleAsync(tasksQz);//await _schedulerServer.PauseTaskScheduleAsync(TasksQz);

            if (taskResult.IsSuccess())
            {
                tasksQz.IsStart = 0;
                _tasksQzService.Update(tasksQz);
            }

            return ToResponse(taskResult);
        }

        /// <summary>
        /// 定时任务立即执行一次
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("run")]
        [ActionPermissionFilter(Permission = "routine:tasks:run")]
        [Log(Title = "执行任务", BusinessType = BusinessType.OTHER)]
        public async Task<IActionResult> Run(string id)
        {
            var result = await _tasksQzService.IsAnyAsync(m => m.ID == id);
            if (!result)
            {
                throw new CustomizeException("任务不存在");
            }
            var tasksQz = await _tasksQzService.GetFirstAsync(m => m.ID == id);
            var taskResult = await _schedulerServer.RunTaskScheduleAsync(tasksQz);

            return ToResponse(taskResult);
        }

        /// <summary>
        /// 定时任务导出
        /// </summary>
        /// <returns></returns>
        [Log(BusinessType = BusinessType.EXPORT, IsSaveResponseData = false, Title = "定时任务导出")]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:tasks:export")]
        public IActionResult Export()
        {
            var list = _tasksQzService.GetAll();

            string sFileName = ExportExcel(list, "tasks", "定时任务", "export/routine");
            return SUCCESS(new { path = "/export/routine/" + sFileName, fileName = sFileName });
        }
    }
}
