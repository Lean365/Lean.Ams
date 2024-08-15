using System.Threading.Tasks;
using Ams.Infrastructure.Model;
using Ams.Model.Routine;

namespace Ams.Tasks
{
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