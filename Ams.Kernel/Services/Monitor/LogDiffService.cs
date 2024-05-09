using Ams.Infrastructure.Attribute;
using Ams.Kernel.Services.IService.Monitor;
using Ams.Model;
using Ams.Repository;

namespace Ams.Kernel.Services.Monitor
{
    /// <summary>
    /// 审计日志Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(ILogDiffService), ServiceLifetime = LifeTime.Transient)]
    public class LogDiffService : BaseService<LogDiff>, ILogDiffService
    {
        /// <summary>
        /// 查询审计日志列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<LogDiffDto> GetList(LogDiffQueryDto parm)
        {
            var predicate = Expressionable.Create<LogDiff>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.TableName), it => it.TableName == parm.TableName);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DiffType), it => it.DiffType == parm.DiffType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.UserName), it => it.UserName == parm.UserName);
            predicate = predicate.AndIF(parm.BeginTime == null, it => it.Create_time >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginTime != null, it => it.Create_time >= parm.BeginTime);
            predicate = predicate.AndIF(parm.EndTime != null, it => it.Create_time <= parm.EndTime);
            var response = Queryable()
                //.OrderBy("PId desc")
                .Where(predicate.ToExpression())
                .ToPage<LogDiff, LogDiffDto>(parm);

            return response;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PId"></param>
        /// <returns></returns>
        public LogDiff GetInfo(long PId)
        {
            var response = Queryable()
                .Where(x => x.PId == PId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加审计日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LogDiff AddLogDiff(LogDiff model)
        {
            //var httpContext = App.HttpContext;
            model.Create_by = model.UserName;// HttpContextExtension.GetName(httpContext); //获取当前登录用户
            return Context.Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改审计日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateLogDiff(LogDiff model)
        {
            //var response = Update(w => w.PId == model.PId, it => new LogDiff()
            //{
            //    TableName = model.TableName,
            //    BusinessData = model.BusinessData,
            //    DiffType = model.DiffType,
            //    Sql = model.Sql,
            //    BeforeData = model.BeforeData,
            //    AfterData = model.AfterData,
            //    UserName = model.UserName,
            //    createTime = model.createTime,
            //    ConfigId = model.ConfigId,
            //});
            //return response;
            //var httpContext = App.HttpContext;
            model.Update_by = model.UserName;// HttpContextExtension.GetName(httpContext); //获取当前登录用户
            return Update(model, true);
        }
    }
}