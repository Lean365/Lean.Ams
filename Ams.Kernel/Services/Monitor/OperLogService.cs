using Ams.Kernel.Model.Dto.Monitor;
using Ams.Repository;

namespace Ams.Kernel.Services.Monitor
{
    /// <summary>
    /// 操作日志
    /// 业务层处理
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [AppService(ServiceType = typeof(IOperLogService), ServiceLifetime = LifeTime.Transient)]
    public class OperLogService : BaseService<OperLog>, IOperLogService
    {
        /// <summary>
        /// 新增操作日志操作
        /// </summary>
        /// <param name="operLog">日志对象</param>
        public void InsertOperlog(OperLog operLog)
        {
            if (operLog.OperParam != null && operLog.OperParam.Length >= 1000)
            {
                operLog.OperParam = operLog.OperParam[..1000];
            }
            //OperLogRepository.AddOperLog(operLog);
            Insert(operLog);
        }

        /// <summary>
        /// 查询系统操作日志集合
        /// </summary>
        /// <param name="sysOper">操作日志对象</param>
        /// <returns>操作日志集合</returns>
        public PagedInfo<OperLog> SelectOperLogList(OperLogQueryDto sysOper)
        {
            var exp = Expressionable.Create<OperLog>();
            exp.AndIF(sysOper.BeginTime == null, it => it.OperTime >= DateTime.Now.ToShortDateString().ParseToDateTime());
            exp.AndIF(sysOper.BeginTime != null, it => it.OperTime >= sysOper.BeginTime && it.OperTime <= sysOper.EndTime);
            exp.AndIF(sysOper.Title.IfNotEmpty(), it => it.Title.Contains(sysOper.Title));
            exp.AndIF(sysOper.OperName.IfNotEmpty(), it => it.OperName.Contains(sysOper.OperName));
            exp.AndIF(sysOper.BusinessType != null, it => it.BusinessType == sysOper.BusinessType);
            exp.AndIF(sysOper.IsStated != null, it => it.IsStated == sysOper.IsStated);
            exp.AndIF(sysOper.OperParam != null, it => it.OperParam.Contains(sysOper.OperParam));

            return Queryable()
                .Where(exp.ToExpression())
                .OrderBy(x => x.OperId, OrderByType.Desc)
                .ToPage(sysOper);
        }

        /// <summary>
        /// 清空操作日志
        /// </summary>
        public void CleanOperLog()
        {
            Truncate();
        }

        /// <summary>
        /// 批量删除系统操作日志
        /// </summary>
        /// <param name="operIds">需要删除的操作日志ID</param>
        /// <returns>结果</returns>
        public int DeleteOperLogByIds(long[] operIds)
        {
            return Delete(operIds);
        }

        /// <summary>
        /// 查询操作日志详细
        /// </summary>
        /// <param name="operId">操作ID</param>
        /// <returns>操作日志对象</returns>
        public OperLog SelectOperLogById(long operId)
        {
            return GetById(operId);
        }
    }
}