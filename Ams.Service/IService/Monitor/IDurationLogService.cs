namespace Ams.Service.IService.Monitor
{
    /// <summary>
    /// 用户在线时长service接口
    /// </summary>
    public interface IDurationLogService : IBaseService<DurationLog>
    {
        PagedInfo<DurationLogDto> GetList(UserOnlineLogQueryDto parm);

        DurationLog AddUserOnlineLog(DurationLog parm);

        PagedInfo<DurationLogDto> ExportList(UserOnlineLogQueryDto parm);
    }
}