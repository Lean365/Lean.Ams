using Ams.Repository;

namespace Ams.Service.Monitor
{
    /// <summary>
    /// 审计日志Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IDiffLogService), ServiceLifetime = LifeTime.Transient)]
    public class DiffLogService : BaseService<DiffLog>, IDiffLogService
    {
        /// <summary>
        /// 查询审计日志列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<DiffLogDto> GetList(DiffLogQueryDto parm)
        {
            var predicate = Expressionable.Create<DiffLog>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.TableName), it => it.TableName == parm.TableName);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DiffType), it => it.DiffType == parm.DiffType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.UserName), it => it.UserName == parm.UserName);
            predicate = predicate.AndIF(parm.BeginAddTime == null, it => it.Create_time >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginAddTime != null, it => it.Create_time >= parm.BeginAddTime);
            predicate = predicate.AndIF(parm.EndAddTime != null, it => it.Create_time <= parm.EndAddTime);
            var response = Queryable()
                //.OrderBy("PId desc")
                .Where(predicate.ToExpression())
                .ToPage<DiffLog, DiffLogDto>(parm);

            return response;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="PId"></param>
        /// <returns></returns>
        public DiffLog GetInfo(long PId)
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
        public DiffLog AddSqlDiffLog(DiffLog model)
        {
            return Context.Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改审计日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSqlDiffLog(DiffLog model)
        {
            //var response = Update(w => w.PId == model.PId, it => new SqlDiffLog()
            //{
            //    TableName = model.TableName,
            //    BusinessData = model.BusinessData,
            //    DiffType = model.DiffType,
            //    Sql = model.Sql,
            //    BeforeData = model.BeforeData,
            //    AfterData = model.AfterData,
            //    UserName = model.UserName,
            //    AddTime = model.AddTime,
            //    ConfigId = model.ConfigId,
            //});
            //return response;
            return Update(model, true);
        }
    }
}