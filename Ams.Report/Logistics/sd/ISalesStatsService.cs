using Ams.Kernel;
using Ams.Model.Dto;
using Ams.Model.Logistics;
namespace Ams.Report.Logistics.sd
{
    /// <summary>
    /// 业务层接口
    /// service接口
    /// </summary>
    public interface ISalesStatsService : IBaseService<SalesInvoice>
    {
        /// <summary>
        /// 本月销售台数/金额
        /// </summary>
        /// <returns></returns>
        string QueryCurrentMonthlySales(SalesInvoiceQueryDto parm);

        /// <summary>
        /// Bu别本月销售台数/金额
        /// </summary>
        /// <returns></returns>
        string QueryCurrentMonthlySalesBu(SalesInvoiceQueryDto parm);


        /// <summary>
        /// 前月销售台数/金额
        /// </summary>
        /// <returns></returns>
        string QueryPreviousMonthlySales(SalesInvoiceQueryDto parm);


        /// <summary>
        /// Bu别前月销售台数/金额
        /// </summary>
        /// <returns></returns>
        string QueryPreviousMonthlySalesBu(SalesInvoiceQueryDto parm);


        /// <summary>
        /// 当年销售台数/金额
        /// </summary>
        /// <returns></returns>
        string QueryCurrentYearlySales(SalesInvoiceQueryDto parm);


        /// <summary>
        /// Bu别当年销售台数/金额
        /// </summary>
        /// <returns></returns>
        string QueryCurrentYearlySalesBu(SalesInvoiceQueryDto parm);



        /// <summary>
        /// 按月统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountMonthSales(SalesInvoiceQueryDto parm);
        /// <summary>
        /// Bu别按月统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountMonthBuSales(SalesInvoiceQueryDto parm);
        /// <summary>
        /// 按年统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountYearSales(SalesInvoiceQueryDto parm);


        /// <summary>
        /// Bu别按年统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> QueryCountYearBuSales(SalesInvoiceQueryDto parm);
    }
}
