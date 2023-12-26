using Ams.Model;
using Ams.Kernel.Model.Dto.Monitor;
using Ams.Kernel.Model.Monitor;

namespace Ams.Kernel.Services.IService.Monitor
{
    /// <summary>
    /// 审计日志service接口
    /// </summary>
    public interface ILogDiffService : IBaseService<LogDiff>
    {
        PagedInfo<LogDiffDto> GetList(LogDiffQueryDto parm);

        LogDiff GetInfo(long PId);

        LogDiff AddLogDiff(LogDiff parm);

        int UpdateLogDiff(LogDiff parm);

    }
}
