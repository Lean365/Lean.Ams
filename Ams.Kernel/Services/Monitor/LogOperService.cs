using Ams.Infrastructure.Attribute;
using Ams.Model;
using Ams.Repository;
using Ams.Kernel.Model.Monitor;
using Ams.Kernel.Model.Dto.Monitor;
using Ams.Kernel.Services.IService.Monitor;

namespace Ams.Kernel.Services.Monitor
{
    /// <summary>
    /// 操作日志
    /// </summary>
    [AppService(ServiceType = typeof(ILogOperService), ServiceLifetime = LifeTime.Transient)]
    public class LogOperService : BaseService<LogOper>, ILogOperService
    {
        /// <summary>
        /// 新增操作日志操作
        /// </summary>
        /// <param name="operLog">日志对象</param>
        public void InsertOperlog(LogOper operLog)
        {
            if (operLog.OperParam != null && operLog.OperParam.Length >= 1000)
            //if (operLog.OperParam.Length >= 1000)
            {
                operLog.OperParam = operLog.OperParam[..1000];
            }
            //LogOperRepository.AddLogOper(operLog);
            Insert(operLog);
        }

        /// <summary>
        /// 查询系统操作日志集合
        /// </summary>
        /// <param name="sysOper">操作日志对象</param>
        /// <returns>操作日志集合</returns>
        public PagedInfo<LogOper> SelectOperLogList(LogOperQueryDto sysOper)
        {
            var exp = Expressionable.Create<LogOper>();
            exp.AndIF(sysOper.BeginTime == null, it => it.OperTime >= DateTime.Now.ToShortDateString().ParseToDateTime());
            exp.AndIF(sysOper.BeginTime != null, it => it.OperTime >= sysOper.BeginTime && it.OperTime <= sysOper.EndTime);
            exp.AndIF(sysOper.Title.IfNotEmpty(), it => it.Title.Contains(sysOper.Title));
            exp.AndIF(sysOper.OperName.IfNotEmpty(), it => it.OperName.Contains(sysOper.OperName));
            exp.AndIF(sysOper.BusinessType != -1, it => it.BusinessType == sysOper.BusinessType);
            exp.AndIF(sysOper.IsState != -1, it => it.IsState == sysOper.IsState);
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
        public LogOper SelectOperLogById(long operId)
        {
            return GetById(operId);
        }
    }
}