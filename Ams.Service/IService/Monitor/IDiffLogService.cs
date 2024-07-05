namespace Ams.Service.IService.Monitor
{
    /// <summary>
    /// 审计日志service接口
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public interface IDiffLogService : IBaseService<DiffLog>
    {
        PagedInfo<DiffLogDto> GetList(DiffLogQueryDto parm);

        DiffLog GetInfo(long PId);

        DiffLog AddSqlDiffLog(DiffLog parm);

        int UpdateSqlDiffLog(DiffLog parm);
    }
}