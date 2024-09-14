using Ams.Service;

namespace Ams.Service.Monitor.IMonitorService
{
    /// <summary>
    /// 在线时长service接口
    /// </summary>
    public interface IDurationLogService : IBaseService<DurationLog>
    {
        PagedInfo<DurationLogDto> GetList(DurationLogQueryDto parm);

        DurationLog AddUserOnlineLog(DurationLog parm);

        PagedInfo<DurationLogDto> ExportList(DurationLogQueryDto parm);
    }
}