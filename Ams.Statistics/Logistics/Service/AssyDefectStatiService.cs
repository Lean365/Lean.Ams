using Ams.Model.Logistics.Dto;
using Ams.Statistics.Logistics.IService;
using SqlSugar;

namespace Ams.Statistics.Logistics.Service
{
    /// <summary>
    /// Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IAssyDefectStatiService), ServiceLifetime = LifeTime.Transient)]
    public class AssyDefectStatiService : BaseService<PpDefectAssyMa>, IAssyDefectStatiService
    {
        /// <summary>
        /// 本月组立不良台数
        /// </summary>
        /// <returns></returns>
        public int GetMonthlyPoorQty(PpDefectAssyMaQueryDto parm)
        {
            int MonthlyQty;
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpRepairAssySlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpDefectAssySlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                // .Where((x1, x2) => Convert.ToDateTime(x1.Mma009).ToString("yyyy-MM") == DateTime.Now.ToString("yyyy-MM"))
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.Mea006).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mfa004 > 0, x2.Mfa004, 0)),
                }).ToList();
            if (response.Count == 0)
            {
                MonthlyQty = 0;
            }
            else
            {
                MonthlyQty = response[0].RealOutputQty;
            }

            return MonthlyQty;
        }

        /// <summary>
        /// 按月统计组立不良报表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListMonthPoor(PpDefectAssyMaQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpRepairAssySlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpDefectAssySlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.Mea006).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.Mea006).ToString("yyyy-MM"),
                    //StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mfa004 > 0, x1.Mfa004, 0)), //求和,
                    RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mfa004 > 0, x2.Mfa004, 0)),
                    //AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb003 > 0, x2.Mmb003, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)) * 100, 2),
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
        /// 导出月度组立不良报表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public dynamic ExportListMonthPoor(PpDefectAssyMaQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.PpRepairAssySlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpDefectAssySlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .GroupBy((x1, x2) => Convert.ToDateTime(x1.Mea006).ToString("yyyy-MM"))
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.Mea006).ToString("yyyy-MM"),
                    MfgPoor = SqlFunc.AggregateCount(x2.Mfa004), //求和,
                    //StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
                    //RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb003 > 0, x2.Mmb003, 0)),
                    //AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb003 > 0, x2.Mmb003, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)) * 100, 2),
                }).ToList();

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
        /// 按月统计组立不良--柱状图
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListMonthlyPoorBar(PpDefectAssyMaQueryDto parm)
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
                //.Includes(x => x.PpRepairAssySlvNav) //填充子对象
                .Where(predicate.ToExpression());
            var queryableRight = db.Queryable<PpDefectAssySlv>();
            //int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
                (x1, x2) => x1.Id == x2.ParentId)
                //.GroupBy((x1, x2) => x1.ColumnName)
                .Where((x1, x2) => x1.Mea006 >= BeginDate && x1.Mea006 <= EndDate)
                .GroupBy((x1, x2) => new
                {
                    Mea006 = Convert.ToDateTime(x1.Mea006).ToString("yyyy-MM"),
                    //x1.Mma010,
                })
                .Select((x1, x2) => new
                {
                    MfgDate = Convert.ToDateTime(x1.Mea006).ToString("yyyy-MM"),
                    //MfgLine = x1.Mma010,
                    MfgPoor = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mfa004 > 0, x2.Mfa004, 0)), //求和,
                    //StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
                    //RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb003 > 0, x2.Mmb003, 0)),
                    //RealWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb004 > 0, x2.Mmb004, 0)), //实际工数,
                    //InputsWorkhours = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)), //投入工数,
                    //RealWorktime = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb009 > 0, x2.Mmb009, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb003 > 0, x2.Mmb003, 1)), 2), //实际ST,
                    //RealWorkinghoursDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际ST差异,
                    //RealOutputDiff = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb003 > 0, x2.Mmb003, 0)) - SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //实际台数差异,

                    //AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb003 > 0, x2.Mmb003, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 1)) * 100, 2),
                }).ToDictionaryList();

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
        private static Expressionable<PpDefectAssyMa> QueryExp(PpDefectAssyMaQueryDto parm)
        {
            //DateTime firstDayOfYear = new DateTime(DateTime.Now.Year + 1, 1, 1); // 获取当前年份的第一天
            //DateTime lastDayOfYear = new DateTime(DateTime.Now.Year + 2, 1, 1).AddDays(-1); // 获取当前年份的最后一天（下一年的第一天再减去一天）
            var predicate = Expressionable.Create<PpDefectAssyMa>();
            //predicate = predicate.AndIF(parm.BeginMoOrderDate == null, it => it.CreateTime >= firstDayOfYear);
            //predicate = predicate.AndIF(parm.EndMoOrderDate == null, it => it.CreateTime <= lastDayOfYear);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MmMatItem), it => it.MmMatItem == parm.MmMatItem);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmEcNo), it => it.EmEcNo.Substring(0, 2).Contains(parm.EmEcNo));
            return predicate;
        }
    }
}