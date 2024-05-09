using System.Threading.Tasks;
using Ams.Infrastructure.Model;
using Ams.Kernel.Model.Routine;

namespace Ams.Tasks
{
    /// <summary>
    /// 任务调度
    /// 业务服务接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public interface ITaskSchedulerServer
    {
        Task<ApiResult> StartTaskScheduleAsync();

        Task<ApiResult> StopTaskScheduleAsync();

        Task<ApiResult> AddTaskScheduleAsync(TasksQz tasksQz);

        Task<ApiResult> PauseTaskScheduleAsync(TasksQz tasksQz);

        Task<ApiResult> ResumeTaskScheduleAsync(TasksQz tasksQz);

        Task<ApiResult> DeleteTaskScheduleAsync(TasksQz tasksQz);

        Task<ApiResult> RunTaskScheduleAsync(TasksQz tasksQz);

        Task<ApiResult> UpdateTaskScheduleAsync(TasksQz tasksQz);
    }
}