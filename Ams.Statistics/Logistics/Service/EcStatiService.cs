using Ams.Model.Logistics.Dto;
using Ams.Statistics.Logistics.IService;
using SqlSugar;

namespace Ams.Statistics.Logistics.Service
{
    /// <summary>
    /// Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IEcStatiService), ServiceLifetime = LifeTime.Transient)]
    public class EcStatiService : BaseService<PpEcSlave>, IEcStatiService
    {
        /// <summary>
        /// ec点数统计
        /// </summary>
        /// <returns></returns>
        public int GetEcCount(PpEcSlaveQueryDto parm)
        {
            int EcCount;

            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy((x) => new { x.Mc003, x.Mc004, x.Mc005, x.Mc007, x.Mc009, x.Mc014 })
                .Select((x) => new
                {
                    x.Mc003
                }).ToList();
            //var queryableRight = db.Queryable<PpEcSlave>();
            ////int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            //var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
            //    (x1, x2) => x1.EmEcNo == x2.EsEcNo)
            //    // .Where((x1, x2) => Convert.ToDateTime(x1.PomMfgDate).ToString("yyyy-MM") == DateTime.Now.ToString("yyyy-MM"))
            //    //.GroupBy((x1, x2) => x1.ColumnName)
            //    .GroupBy((x1, x2) => new
            //    {
            //        x2.EsEcNo,
            //        x2.EsModel,
            //        x2.EsItem,
            //        x2.EsSubItem,
            //        x2.EsOldItem,
            //        x2.EsNewItem,
            //    })
            //    .Select((x1, x2) => new
            //    {
            //        x2.EsEcNo,
            //        x2.EsModel,
            //        x2.EsItem,
            //        x2.EsSubItem,
            //        x2.EsOldItem,
            //        x2.EsNewItem,
            //    }).ToList();
            if (response.Count == 0)
            {
                EcCount = 0;
            }
            else
            {
                EcCount = response.Count;
            }

            return EcCount;
        }

        /// <summary>
        /// 按月统计ec点数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListMonthlyEc(PpEcSlaveQueryDto parm)
        {
            DateTime nowDate = DateTime.Now;
            DateTime BeginDate = DateTime.Now;
            DateTime EndDate = DateTime.Now;
            DateTime Date10 = Convert.ToDateTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10));
            if (nowDate > Date10)
            {
                BeginDate = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天
                EndDate = nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天
            }
            else
            {
                BeginDate = nowDate.AddDays(1 - nowDate.Day).AddMonths(-3);//上月第一天
                EndDate = nowDate.AddDays(1 - nowDate.Day).AddDays(-1); ;//上月最后一天
            }
            //发行日期：Mb002 录入日期：Mb023
            var db = Context;
            var predicate = QueryExpBar(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpEcMaster>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.ParentId == x2.Id)
                .Where((x1, x2) => x2.Mb002 >= BeginDate && x2.Mb002 <= EndDate)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new { Mb002 = Convert.ToDateTime(x2.Mb002).ToString("yyyy-MM"), x1.Mc003, x1.Mc004, x1.Mc005, x1.Mc007, x1.Mc009, x1.Mc014 })
                .Select((x1, x2) => new
                {
                    EcDate = Convert.ToDateTime(x2.Mb002).ToString("yyyy-MM"),
                    EcCount = SqlFunc.AggregateCount(x1.Mc003),
                })
                .ToDictionaryList();

            //db.Queryable<Student>().Select(it => new StudentDTO { id = it.id }).ToList();

            //var q = from a in response
            //        group a by a.MfgDate into g
            //        select new
            //        {
            //            MfgDate = g.Key,
            //            StdOutputQty = g.Sum(p => p.StdOutputQty),
            //            RealOutputQty = g.Sum(p => p.RealOutputQty),
            //        };
            return response;
        }

        /// <summary>
        /// 按月,班组统计OPH
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListMonthlyEcBar(PpEcSlaveQueryDto parm)
        {
            DateTime nowDate = DateTime.Now;
            DateTime BeginDate = DateTime.Now;
            DateTime EndDate = DateTime.Now;
            DateTime Date10 = Convert.ToDateTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10));
            if (nowDate > Date10)
            {
                BeginDate = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天
                EndDate = nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天
            }
            else
            {
                BeginDate = nowDate.AddDays(1 - nowDate.Day).AddMonths(-3);//上月第一天
                EndDate = nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1); //nowDate.AddDays(1 - nowDate.Day).AddDays(-1); ;//上月最后一天
            }
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpOutputAssySlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpEcMaster>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.ParentId == x2.Id)
                .Where((x1, x2) => x2.Mb002 >= BeginDate && x2.Mb002 <= EndDate)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => new
                {
                    Mb002 = Convert.ToDateTime(x2.Mb002).ToString("yyyy-MM"),
                    //x1.Mc003
                }).OrderBy((x1, x2) => Convert.ToDateTime(x2.Mb002).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    EcDate = Convert.ToDateTime(x2.Mb002).ToString("yyyy-MM"),
                    EcCount = SqlFunc.AggregateCount(x1.Mc003)
                })
                .ToDictionaryList();

            //db.Queryable<Student>().Select(it => new StudentDTO { id = it.id }).ToList();

            //var q = from a in response
            //        group a by a.MfgDate into g
            //        select new
            //        {
            //            MfgDate = g.Key,
            //            StdOutputQty = g.Sum(p => p.StdOutputQty),
            //            RealOutputQty = g.Sum(p => p.RealOutputQty),
            //        };
            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpEcSlave> QueryExp(PpEcSlaveQueryDto parm)
        {
            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）
            var predicate = Expressionable.Create<PpEcSlave>();
            //predicate = predicate.AndIF(parm.BeginMoOrderDate == null, it => it.CreateTime >= firstDayOfYear);
            //predicate = predicate.AndIF(parm.EndMoOrderDate == null, it => it.CreateTime <= lastDayOfYear);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatItem), it => it.MmMatItem == parm.MmMatItem);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcNo), it => it.EmEcNo.Substring(0, 2).Contains(parm.EmEcNo));
            return predicate;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<PpEcSlave> QueryExpBar(PpEcSlaveQueryDto parm)
        {
            DateTime nowDate = DateTime.Now;
            DateTime BeginDate = DateTime.Now;
            DateTime EndDate = DateTime.Now;
            DateTime Date10 = Convert.ToDateTime(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 10));
            if (nowDate > Date10)
            {
                BeginDate = new DateTime(nowDate.Year, nowDate.Month, 1);   //本月第一天
                EndDate = nowDate.AddDays(1 - nowDate.Day).AddMonths(1).AddDays(-1);  //本月最后一天
            }
            else
            {
                BeginDate = nowDate.AddDays(1 - nowDate.Day).AddMonths(-3);//上月第一天
                EndDate = nowDate.AddDays(1 - nowDate.Day).AddDays(-1); ;//上月最后一天
            }
            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）
            var predicate = Expressionable.Create<PpEcSlave>();
            //predicate = predicate.AndIF(parm.BeginMoOrderDate == null, it => it.CreateTime >= firstDayOfYear);
            //predicate = predicate.AndIF(parm.EndMoOrderDate == null, it => it.CreateTime <= lastDayOfYear);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatItem), it => it.MmMatItem == parm.MmMatItem);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcNo), it => it.EmEcNo.Substring(0, 2).Contains(parm.EmEcNo));
            return predicate;
        }
    }
}