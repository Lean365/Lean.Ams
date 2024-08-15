using Ams.Model.Monitor.Dto;

namespace Ams.Service.Monitor.IMonitorService
{
    /// <summary>
    /// 用户在线时长service接口
    /// </summary>
    public interface IDurationLogService : IBaseService<DurationLog>
    {
        PagedInfo<DurationLogDto> GetList(DurationLogQueryDto parm);

        DurationLog AddUserOnlineLog(DurationLog parm);

        PagedInfo<DurationLogDto> ExportList(DurationLogQueryDto parm);
    }
}