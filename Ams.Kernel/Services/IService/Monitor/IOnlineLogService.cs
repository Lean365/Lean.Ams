using Ams.Kernel.Model.Dto.Monitor;

namespace Ams.Kernel.Services.IService.Monitor
{
    /// <summary>
    /// 在线时长
    /// 业务层接口
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public interface IOnlineLogService : IBaseService<OnlineLog>
    {
        PagedInfo<OnlineLogDto> GetList(OnlineLogQueryDto parm);

        OnlineLog AddOnlineLog(OnlineLog parm);

        PagedInfo<OnlineLogDto> ExportList(OnlineLogQueryDto parm);
    }
}