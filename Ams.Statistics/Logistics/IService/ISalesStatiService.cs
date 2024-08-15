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
        decimal GetMonthlySalesQty(SdSellingInvoiceQueryDto parm);

        /// <summary>
        /// 本月销售金额
        /// </summary>
        /// <returns></returns>
        decimal GetMonthlySalesAmount(SdSellingInvoiceQueryDto parm);

        /// <summary>
        /// 按月统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthSales(SdSellingInvoiceQueryDto parm);

        /// <summary>
        /// 按月,国家统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthAreaSales(SdSellingInvoiceQueryDto parm);

        /// <summary>
        /// 按月,仕向统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthRegionSales(SdSellingInvoiceQueryDto parm);

        /// <summary>
        /// 按年统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListYearSales(SdSellingInvoiceQueryDto parm);

        /// <summary>
        /// 按年,国家统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListYearAreaSales(SdSellingInvoiceQueryDto parm);

        /// <summary>
        /// 按年,仕向统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListYearRegionSales(SdSellingInvoiceQueryDto parm);
    }
}