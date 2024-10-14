using Ams.Repository;

namespace Ams.Service.Monitor
{
    /// <summary>
    /// 在线时长Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IDurationLogService), ServiceLifetime = LifeTime.Transient)]
    public class DurationLogService : BaseService<DurationLog>, IDurationLogService
    {
        /// <summary>
        /// 查询在线时长列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<DurationLogDto> GetList(DurationLogQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Id desc")
                .Where(predicate.ToExpression())
                .LeftJoin<SysUser>((it, u) => it.UserId == u.UserId)
                .Select((it, u) => new DurationLogDto()
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
        public DurationLog AddUserOnlineLog(DurationLog model)
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
        public PagedInfo<DurationLogDto> ExportList(DurationLogQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new DurationLogDto()
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
        private static Expressionable<DurationLog> QueryExp(DurationLogQueryDto parm)
        {
            var predicate = Expressionable.Create<DurationLog>();

            predicate = predicate.AndIF(parm.UserId != null, it => it.UserId == parm.UserId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.UserIP), it => it.UserIP == parm.UserIP);
            predicate = predicate.AndIF(parm.BeginAddTime == null, it => it.Create_time >= new DateTime(DateTime.Now.Year, 1, 1));// DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginAddTime != null, it => it.Create_time >= parm.BeginAddTime);
            return predicate;
        }
    }
}