using Ams.Infrastructure.Attribute;
using Ams.Kernel.Services.IService.Monitor;
using Ams.Model;
using Ams.Repository;

namespace Ams.Kernel.Services.Monitor
{
    /// <summary>
    /// 在线时长Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(ILogOnlineTimeService), ServiceLifetime = LifeTime.Transient)]
    public class LogOnlineTimeService : BaseService<LogOnlineTime>, ILogOnlineTimeService
    {
        /// <summary>
        /// 查询在线时长列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<LogOnlineTimeDto> GetList(LogOnlineTimeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Id desc")
                .Where(predicate.ToExpression())
                .LeftJoin<SysUser>((it, u) => it.UserId == u.UserId)
                .Select((it, u) => new LogOnlineTimeDto()
                {
                    NickName = u.NickName
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 添加在线时长
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LogOnlineTime AddLogOnlineTime(LogOnlineTime model)
        {
            var httpContext = App.HttpContext;
            model.Create_by = HttpContextExtension.GetName(httpContext); //获取当前登录用户
            if (model.OnlineTime >= 0.5)
            {
                Insertable(model).ExecuteReturnSnowflakeId();
            }
            return model;
        }

        /// <summary>
        /// 导出在线时长
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<LogOnlineTimeDto> ExportList(LogOnlineTimeQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new LogOnlineTimeDto()
                {
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<LogOnlineTime> QueryExp(LogOnlineTimeQueryDto parm)
        {
            var predicate = Expressionable.Create<LogOnlineTime>();

            predicate = predicate.AndIF(parm.UserId != null, it => it.UserId == parm.UserId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.UserIP), it => it.UserIP == parm.UserIP);
            predicate = predicate.AndIF(parm.BeginTime == null, it => it.Create_time >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginTime != null, it => it.Create_time >= parm.BeginTime);
            return predicate;
        }
    }
}