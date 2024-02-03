using Ams.Infrastructure.Attribute;
using Ams.Infrastructure.Extensions;
using Ams.Kernel;
using Ams.Model.Dto;
using Ams.Model.Logistics;
using Ams.Report.Logistics.pp;
using Org.BouncyCastle.X509;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams.Report.Logistics.sd
{
    /// <summary>
    /// Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(ISalesStatsService), ServiceLifetime = LifeTime.Transient)]
    public class SalesStatsService : BaseService<SalesInvoice>, ISalesStatsService
    {
        /// <summary>
        /// 本月销售台数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public string QueryCurrentMonthlySales(SalesInvoiceQueryDto parm)
        {
            string? MonthlyQty;
            var predicate = QueryExp(parm);
            var queryableLeft = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression());
                var response= queryableLeft
                .GroupBy(x1 => x1.SsiYm)                
                .Select((x1) => new                
                {
                    SsiSalesqty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiSalesqty > 0, x1.SsiSalesqty, 0)),
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiLocalamount > 0, x1.SsiLocalamount, 0)),
                }).ToList();
            if (response.Count == 0)
            {
                MonthlyQty = "0,0";

            }
            else
            {
                MonthlyQty = response[0].SsiSalesqty.ToString()+","+ response[0].SsiLocalamount.ToString();
            }

            return MonthlyQty;


        }

        /// <summary>
        /// 本月销售台数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public string QueryCurrentMonthlySalesBu(SalesInvoiceQueryDto parm)
        {
            string? MonthlyQty;
            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy(x1 =>new { x1.SsiYm, x1.SsiPrctr })
                .Select((x1) => new
                {
                    SsiSalesqty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiSalesqty > 0, x1.SsiSalesqty, 0)),
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiLocalamount > 0, x1.SsiLocalamount, 0)),
                }).ToList();
            if (response.Count == 0)
            {
                MonthlyQty = "0,0";

            }
            else
            {
                MonthlyQty = response[0].SsiSalesqty.ToString() + "," + response[0].SsiLocalamount.ToString();
            }

            return MonthlyQty;


        }

        /// <summary>
        /// 上月销售台数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public string QueryPreviousMonthlySales(SalesInvoiceQueryDto parm)
        {
            string? MonthlyQty;
            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy(x1 => x1.SsiYm)
                .Select((x1) => new
                {
                    SsiSalesqty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiSalesqty > 0, x1.SsiSalesqty, 0)),
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiLocalamount > 0, x1.SsiLocalamount, 0)),
                }).ToList();
            if (response.Count == 0)
            {
                MonthlyQty = "0,0";

            }
            else
            {
                MonthlyQty = response[0].SsiSalesqty.ToString() + "," + response[0].SsiLocalamount.ToString();
            }

            return MonthlyQty;


        }

        /// <summary>
        /// 上月销售台数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public string QueryPreviousMonthlySalesBu(SalesInvoiceQueryDto parm)
        {
            string? MonthlyQty;
            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy(x1 => new { x1.SsiYm, x1.SsiPrctr })
                .Select((x1) => new
                {
                    SsiSalesqty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiSalesqty > 0, x1.SsiSalesqty, 0)),
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiLocalamount > 0, x1.SsiLocalamount, 0)),
                }).ToList();
            if (response.Count == 0)
            {
                MonthlyQty = "0,0";

            }
            else
            {
                MonthlyQty = response[0].SsiSalesqty.ToString() + "," + response[0].SsiLocalamount.ToString();
            }

            return MonthlyQty;


        }


        /// <summary>
        /// 年度销售台数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public string QueryCurrentYearlySales(SalesInvoiceQueryDto parm)
        {
            string? MonthlyQty;
            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy(x1 => x1.SsiYm)
                .Select((x1) => new
                {
                    SsiSalesqty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiSalesqty > 0, x1.SsiSalesqty, 0)),
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiLocalamount > 0, x1.SsiLocalamount, 0)),
                }).ToList();
            if (response.Count == 0)
            {
                MonthlyQty = "0,0";

            }
            else
            {
                MonthlyQty = response[0].SsiSalesqty.ToString() + "," + response[0].SsiLocalamount.ToString();
            }

            return MonthlyQty;


        }

        /// <summary>
        /// 年度销售台数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public string QueryCurrentYearlySalesBu(SalesInvoiceQueryDto parm)
        {
            string? MonthlyQty;
            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy(x1 => new { x1.SsiYm, x1.SsiPrctr })
                .Select((x1) => new
                {
                    SsiSalesqty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiSalesqty > 0, x1.SsiSalesqty, 0)),
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiLocalamount > 0, x1.SsiLocalamount, 0)),
                }).ToList();
            if (response.Count == 0)
            {
                MonthlyQty = "0,0";

            }
            else
            {
                MonthlyQty = response[0].SsiSalesqty.ToString() + "," + response[0].SsiLocalamount.ToString();
            }

            return MonthlyQty;


        }
        /// <summary>
        /// 按月统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountMonthSales(SalesInvoiceQueryDto parm)
        {

            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy(x1 => x1.SsiYm)
                .Select((x1) => new
                {
                    x1.SsiYm,

                    SsiSalesqty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiSalesqty > 0, x1.SsiSalesqty, 0)),
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiLocalamount > 0, x1.SsiLocalamount, 0)),
                }).ToDictionaryList(); 


            return response;


        }

        /// <summary>
        /// Bu别按月统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountMonthBuSales(SalesInvoiceQueryDto parm)
        {

            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy(x1 => new { x1.SsiYm, x1.SsiPrctr })
                .Select((x1) => new
                {
                    x1.SsiYm,
                    x1.SsiPrctr,
                    SsiSalesqty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiSalesqty > 0, x1.SsiSalesqty, 0)),
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiLocalamount > 0, x1.SsiLocalamount, 0)),
                }).ToDictionaryList();


            return response;



        }

        /// <summary>
        /// 年度销售台数
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountYearSales(SalesInvoiceQueryDto parm)
        {

            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy(x1 => x1.SsiYm)
                .Select((x1) => new
                {
                    x1.SsiYm,
                    SsiSalesqty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiSalesqty > 0, x1.SsiSalesqty, 0)),
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiLocalamount > 0, x1.SsiLocalamount, 0)),
                }).ToDictionaryList();


            return response;


        }

        /// <summary>
        /// Bu别按年统计销售
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> QueryCountYearBuSales(SalesInvoiceQueryDto parm)
        {

            var predicate = QueryExp(parm);
            var response = Queryable()
                //.Includes(x => x.OutputSlaveNav) //填充子对象
                .Where(predicate.ToExpression())
                .GroupBy(x1 => new { x1.SsiYm, x1.SsiPrctr })
                .Select((x1) => new
                {
                    x1.SsiYm,
                    x1.SsiPrctr,
                    SsiSalesqty = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiSalesqty > 0, x1.SsiSalesqty, 0)),
                    SsiLocalamount = SqlFunc.AggregateSumNoNull(SqlFunc.IIF(x1.SsiLocalamount > 0, x1.SsiLocalamount, 0)),
                }).ToDictionaryList();


            return response;



        }
        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<SalesInvoice> QueryExp(SalesInvoiceQueryDto parm)
        {
            var predicate = Expressionable.Create<SalesInvoice>();

            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SsiPlnt), it => it.SsiPlnt == parm.SsiPlnt);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SsiYm), it => it.SsiYm == parm.SsiYm);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SsiPrctr), it => it.SsiPrctr == parm.SsiPrctr);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SsiSalesitem), it => it.SsiSalesitem.Contains(parm.SsiSalesitem));
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SsiOriginalccy), it => it.SsiOriginalccy == parm.SsiOriginalccy);
            return predicate;
        }
    }
}
