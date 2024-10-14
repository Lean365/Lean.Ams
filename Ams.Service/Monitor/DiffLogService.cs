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

            //查询字段: <新建日>
            //predicate = predicate.AndIF(parm.BeginTime == null, it => it.Ma002 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //predicate = predicate.AndIF(parm.BeginTime != null, it => it.Ma002 >= parm.BeginTime);
            //predicate = predicate.AndIF(parm.EndTime != null, it => it.Ma002 <= parm.EndTime);
            //当日期条件为空时，默认查询大于今天的所有数据
            //predicate = predicate.AndIF(parm.BeginTime == null, it => it.Ma002 >= DateTime.Now.ToShortDateString().ParseToDateTime());
            //当日期条件为空时，默认查询大于今年的所有数据
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.TableName), it => it.TableName == parm.TableName);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DiffType), it => it.DiffType == parm.DiffType);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.UserName), it => it.UserName == parm.UserName);

            predicate = predicate.AndIF(parm.BeginTime == null, it => it.Create_time >= new DateTime(DateTime.Now.Year, 1, 1));
            predicate = predicate.AndIF(parm.BeginTime != null, it => it.Create_time >= parm.BeginTime);
            predicate = predicate.AndIF(parm.EndTime != null, it => it.Create_time <= parm.EndTime);
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