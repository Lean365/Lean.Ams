using System.Threading.Tasks;
using Ams.Infrastructure.Model;
using Ams.Model.Routine;

namespace Ams.Tasks
{
    /// <summary>
    /// 计划任务
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
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