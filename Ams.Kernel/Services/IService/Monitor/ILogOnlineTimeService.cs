using Ams.Model;
using Ams.Kernel.Model.Monitor;
using Ams.Kernel.Model.Dto.Monitor;

namespace Ams.Kernel.Services.IService.Monitor
{
    /// <summary>
    /// 在线时长service接口
    /// </summary>
    public interface ILogOnlineTimeService : IBaseService<LogOnlineTime>
    {
        PagedInfo<LogOnlineTimeDto> GetList(LogOnlineTimeQueryDto parm);

        LogOnlineTime AddLogOnlineTime(LogOnlineTime parm);

        PagedInfo<LogOnlineTimeDto> ExportList(LogOnlineTimeQueryDto parm);
    }
}
