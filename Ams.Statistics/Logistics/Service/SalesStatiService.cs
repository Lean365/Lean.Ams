using Ams.Model.Logistics.Dto;
using Ams.Statistics.Logistics.IService;
using SqlSugar;

namespace Ams.Statistics.Logistics.Service
{
    /// <summary>
    /// Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(ISalesStatiService), ServiceLifetime = LifeTime.Transient)]
    public class SalesStatiService : BaseService<SdSellingInvoice>, ISalesStatiService
    {
        /// <summary>
        /// 查询当月销售额
        /// </summary>
        /// <returns></returns>
        public decimal GetMonthlySalesQty(SdSellingInvoiceQueryDto parm)
        {
            decimal MonthlyQty;
            var predicate = QueryExpCurrent(parm);
            var response = Queryable()
                //.Includes(x => x.PpOutputPdoneSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy((x) => x.Mc014)
                .Select((x) => new
                {
                    SsiOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.Mc011 > 0, x.Mc011, 0)), //求和,
                    //SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.SsiLocalamount > 0, x.SsiLocalamount, 0)), //求和,
                }).ToList();
            if (response.Count == 0)
            {
                MonthlyQty = 0;
            }
            else
            {
                MonthlyQty = response[0].SsiOutputQty;
            }

            return MonthlyQty;
        }

        /// <summary>
        /// 查询当月销售额
        /// </summary>
        /// <returns></returns>
        public decimal GetMonthlySalesAmount(SdSellingInvoiceQueryDto parm)
        {
            decimal MonthlyQty;
            var predicate = QueryExpCurrent(parm);
            var response = Queryable()
                //.Includes(x => x.PpOutputPdoneSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy((x) => x.Mc004)
                .Select((x) => new
                {
                    //SsiOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.SsiSalesqty > 0, x.SsiSalesqty, 0)), //求和,
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.Mc015 > 0, x.Mc015 / 10000, 0)), //求和,
                }).ToList();
            //var queryableLeft = Queryable()
            //    //.Includes(x => x.PpOutputPdoneSlaveNav) //填充子对象
            //    .Where(predicate.ToExpression());
            //var queryableRight = db.Queryable<PpOutputPdoneSlave>();
            ////int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            //var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
            //    (x1, x2) => x1.Id == x2.ParentId)
            //    // .Where((x1, x2) => Convert.ToDateTime(x1.Mma009).ToString("yyyy-MM") == DateTime.Now.ToString("yyyy-MM"))
            //    //.GroupBy((x1, x2) => x1.ColumnName)
            //    .GroupBy((x1, x2) => Convert.ToDateTime(x1.Mma009).ToString("yyyy-MM"))
            //    .Select((x1, x2) => new
            //    {
            //        RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb003 > 0, x2.Mmb003, 0)),
            //    }).ToList();
            if (response.Count == 0)
            {
                MonthlyQty = 0;
            }
            else
            {
                MonthlyQty = response[0].SsiLocalamount;
            }

            return MonthlyQty;
        }

        /// <summary>
        /// 按月统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListMonthSales(SdSellingInvoiceQueryDto parm)
        {
            var db = Context;
            var predicate = QueryExpCurrent(parm);
            var response = Queryable()
                //.Includes(x => x.PpOutputPdoneSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy((x) => x.Mc004)
                .Select((x) => new
                {
                    SsiOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.Mc011 > 0, x.Mc011, 0)), //求和,
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.Mc015 > 0, x.Mc015, 0)), //求和,
                }).ToDictionaryList();
            //var queryableRight = db.Queryable<PpOutputPdoneSlave>();
            ////int pageIndex = 1; int pageSize = 20; int totalCount = 0; //单表分页
            //var response = db.Queryable(queryableLeft, queryableRight, JoinType.Left,
            //    (x1, x2) => x1.Id == x2.ParentId)
            //    //.GroupBy((x1, x2) => x1.ColumnName)
            //    .GroupBy((x1, x2) => Convert.ToDateTime(x1.Mma009).ToString("yyyy-MM"))
            //    .Select((x1, x2) => new
            //    {
            //        MfgDate = Convert.ToDateTime(x1.Mma009).ToString("yyyy-MM"),
            //        StdOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)), //求和,
            //        RealOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb003 > 0, x2.Mmb003, 0)),
            //        AchievedRate = SqlFunc.Round((decimal)SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x2.Mmb003 > 0, x2.Mmb003, 0)) / SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.Mma014 > 0, x1.Mma014, 0)) * 100, 2),
            //    }).ToDictionaryList();

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
        /// 按月,国家统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListMonthAreaSales(SdSellingInvoiceQueryDto parm)
        {
            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.PpOutputPdoneSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy((x) => new
                {
                    SsiYm = Convert.ToDateTime(x.Mc004).ToString("yyyy-MM"),
                })
                .Select((x) => new
                {
                    SsiOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.Mc011 > 0, x.Mc011, 0)), //求和,
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.Mc015 > 0, x.Mc015, 0)), //求和,
                }).ToDictionaryList();
            return response;
        }

        /// <summary>
        /// 按月,仕向统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListMonthRegionSales(SdSellingInvoiceQueryDto parm)
        {
            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.PpOutputPdoneSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy((x) => Convert.ToDateTime(x.Mc004).ToString("yyyy-MM"))
                .Select((x) => new
                {
                    SsiOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.Mc011 > 0, x.Mc011, 0)), //求和,
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.Mc015 > 0, x.Mc015, 0)), //求和,
                }).ToDictionaryList();
            return response;
        }

        /// <summary>
        /// 按年统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListYearSales(SdSellingInvoiceQueryDto parm)
        {
            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.PpOutputPdoneSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy((x) => Convert.ToDateTime(x.Mc004).ToString("yyyy-MM"))
                .Select((x) => new
                {
                    SsiOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.Mc011 > 0, x.Mc011, 0)), //求和,
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.Mc015 > 0, x.Mc015, 0)), //求和,
                }).ToDictionaryList();
            return response;
            //return response;
        }

        /// <summary>
        /// 按年国家统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListYearAreaSales(SdSellingInvoiceQueryDto parm)
        {
            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.PpOutputPdoneSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy((x) => Convert.ToDateTime(x.Mc004).ToString("yyyy-MM"))
                .Select((x) => new
                {
                    SsiOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.Mc011 > 0, x.Mc011, 0)), //求和,
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.Mc015 > 0, x.Mc015, 0)), //求和,
                }).ToDictionaryList();
            return response;
            // return response;
        }

        /// <summary>
        /// 按年仕向统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetListYearRegionSales(SdSellingInvoiceQueryDto parm)
        {
            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.PpOutputPdoneSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy((x) => Convert.ToDateTime(x.Mc004).ToString("yyyy-MM"))
                .Select((x) => new
                {
                    SsiOutputQty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.Mc011 > 0, x.Mc011, 0)), //求和,
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x.Mc015 > 0, x.Mc015, 0)), //求和,
                }).ToDictionaryList();
            return response;
            //return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<SdSellingInvoice> QueryExp(SdSellingInvoiceQueryDto parm)
        {
            var predicate = Expressionable.Create<SdSellingInvoice>();

            predicate = predicate.AndIF(parm.Mc004 != null, it => it.Mc004 == parm.Mc004);
            //predicate = predicate.AndIF(parm.EndMma009 != null, it => it.Mma009 <= parm.EndMma009);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mma010), it => it.Mma010 == parm.Mma010);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mma007), it => it.Mma007.Contains(parm.Mma007));
            return predicate;
        }

        /// <summary>
        /// 当月查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<SdSellingInvoice> QueryExpCurrent(SdSellingInvoiceQueryDto parm)
        {
            string currentMonth = DateTime.Parse(DateTime.Now.ToString("yyyy-MM")).AddMonths(-1).ToString("yyyyMM");
            var predicate = Expressionable.Create<SdSellingInvoice>();
            if (parm.Mc004 == null)
            {
                predicate = predicate.AndIF(true, it => it.Mc004 == currentMonth);
            }
            else
            {
                predicate = predicate.AndIF(parm.Mc004 != null, it => it.Mc004 == parm.Mc004);
            }
            //predicate = predicate.AndIF(parm.EndMma009 != null, it => it.Mma009 <= parm.EndMma009);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mma010), it => it.Mma010 == parm.Mma010);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Mma007), it => it.Mma007.Contains(parm.Mma007));
            return predicate;
        }
    }
}