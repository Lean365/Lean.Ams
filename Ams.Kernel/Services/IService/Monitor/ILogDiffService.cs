using Ams.Kernel.Model.Dto.Monitor;
using Ams.Kernel.Model.Monitor;
using Ams.Model;

namespace Ams.Kernel.Services.IService.Monitor
{
    /// <summary>
    /// 审计日志
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// </summary>
    public interface ILogDiffService : IBaseService<LogDiff>
    {
        PagedInfo<LogDiffDto> GetList(LogDiffQueryDto parm);

        LogDiff GetInfo(long PId);

        LogDiff AddLogDiff(LogDiff parm);

        int UpdateLogDiff(LogDiff parm);
    }
}