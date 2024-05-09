using Ams.Model;

namespace Ams.Kernel.Services.IService.Monitor
{
    /// <summary>
    /// 在线时长
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    public interface ILogOnlineTimeService : IBaseService<LogOnlineTime>
    {
        PagedInfo<LogOnlineTimeDto> GetList(LogOnlineTimeQueryDto parm);

        LogOnlineTime AddLogOnlineTime(LogOnlineTime parm);

        PagedInfo<LogOnlineTimeDto> ExportList(LogOnlineTimeQueryDto parm);
    }
}