namespace Ams.Service.IService
{
    /// <summary>
    /// 审计日志service接口
    /// </summary>
    public interface IDiffLogService : IBaseService<DiffLog>
    {
        PagedInfo<DiffLogDto> GetList(SqlDiffLogQueryDto parm);

        DiffLog GetInfo(long PId);

        DiffLog AddSqlDiffLog(DiffLog parm);

        int UpdateSqlDiffLog(DiffLog parm);
    }
}