using Ams.Model.Logistics.Dto;

namespace Ams.Statistics.Logistics.IService
{
    /// <summary>
    /// 业务层接口
    /// service接口
    /// </summary>
    public interface ISalesStatiService : IBaseService<SdSellingInvoice>
    {
        /// <summary>
        /// 本月销售台数
        /// </summary>
        /// <returns></returns>
        decimal GetCurrentMonthSalesQty(SdSellingInvoiceQueryDto parm);

        /// <summary>
        /// 本月销售金额
        /// </summary>
        /// <returns></returns>
        decimal GetCurrentMonthSalesAmount(SdSellingInvoiceQueryDto parm);

        /// <summary>
        /// 按月统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetMonthlySales(SdSellingInvoiceQueryDto parm);

        /// <summary>
        /// 按月,国家统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetMonthlyAreaSales(SdSellingInvoiceQueryDto parm);

        /// <summary>
        /// 按月,仕向统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetMonthlyRegionSales(SdSellingInvoiceQueryDto parm);

        /// <summary>
        /// 按年统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetYearSales(SdSellingInvoiceQueryDto parm);

        /// <summary>
        /// 按年,国家统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetYearAreaSales(SdSellingInvoiceQueryDto parm);

        /// <summary>
        /// 按年,仕向统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetYearRegionSales(SdSellingInvoiceQueryDto parm);

        /// <summary>
        /// 按月统计销售--柱状图
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthlySalesBar(SdSellingInvoiceQueryDto parm);
    }
}