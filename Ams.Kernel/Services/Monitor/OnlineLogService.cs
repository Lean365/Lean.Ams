using Ams.Kernel.Model.Dto.Monitor;
using Ams.Repository;

namespace Ams.Kernel.Services.Monitor
{
    /// <summary>
    /// 在线时长
    /// 业务层处理
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [AppService(ServiceType = typeof(IOnlineLogService), ServiceLifetime = LifeTime.Transient)]
    public class OnlineLogService : BaseService<OnlineLog>, IOnlineLogService
    {
        /// <summary>
        /// 查询在线时长列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<OnlineLogDto> GetList(OnlineLogQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Id desc")
                .Where(predicate.ToExpression())
                .LeftJoin<SysUser>((it, u) => it.UserId == u.UserId)
                .Select((it, u) => new OnlineLogDto()
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
        public OnlineLog AddOnlineLog(OnlineLog model)
        {
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
        public PagedInfo<OnlineLogDto> ExportList(OnlineLogQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new OnlineLogDto()
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
        private static Expressionable<OnlineLog> QueryExp(OnlineLogQueryDto parm)
        {
            var predicate = Expressionable.Create<OnlineLog>();

            predicate = predicate.AndIF(parm.UserId != null, it => it.UserId == parm.UserId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.UserIP), it => it.UserIP == parm.UserIP);
            predicate = predicate.AndIF(parm.BeginTime == null, it => it.Create_time >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginTime != null, it => it.Create_time >= parm.BeginTime);
            return predicate;
        }
    }
}