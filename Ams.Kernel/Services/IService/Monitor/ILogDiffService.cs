using Ams.Model;

namespace Ams.Kernel.Services.IService.Monitor
{
    /// <summary>
    /// 审计日志
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    public interface ILogDiffService : IBaseService<LogDiff>
    {
        PagedInfo<LogDiffDto> GetList(LogDiffQueryDto parm);

        LogDiff GetInfo(long PId);

        LogDiff AddLogDiff(LogDiff parm);

        int UpdateLogDiff(LogDiff parm);
    }
}