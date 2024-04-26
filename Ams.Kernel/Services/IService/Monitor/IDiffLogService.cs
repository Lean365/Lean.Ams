using Ams.Kernel.Model.Dto.Monitor;

namespace Ams.Kernel.Services.IService.Monitor
{
    /// <summary>
    /// 审计日志
    /// 业务层接口
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public interface IDiffLogService : IBaseService<DiffLog>
    {
        PagedInfo<DiffLogDto> GetList(DiffLogQueryDto parm);

        DiffLog GetInfo(long PId);

        DiffLog AddDiffLog(DiffLog parm);

        int UpdateDiffLog(DiffLog parm);
    }
}