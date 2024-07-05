namespace Ams.Service.IService.Monitor
{
    /// <summary>
    /// 用户在线时长service接口
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public interface IDurationLogService : IBaseService<DurationLog>
    {
        PagedInfo<DurationLogDto> GetList(DurationLogQueryDto parm);

        DurationLog AddUserOnlineLog(DurationLog parm);

        PagedInfo<DurationLogDto> ExportList(DurationLogQueryDto parm);
    }
}