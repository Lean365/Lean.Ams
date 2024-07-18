using Ams.Model.Logistics.Dto;

namespace Ams.Statistics.Logistics.IService
{
    /// <summary>
    /// 业务层接口
    /// service接口
    /// </summary>
    public interface ISalesStatiService : IBaseService<SdSalesInvoice>
    {
        /// <summary>
        /// 本月销售台数
        /// </summary>
        /// <returns></returns>
        decimal GetMonthlySalesQty(SdSalesInvoiceQueryDto parm);

        /// <summary>
        /// 本月销售金额
        /// </summary>
        /// <returns></returns>
        decimal GetMonthlySalesAmount(SdSalesInvoiceQueryDto parm);

        /// <summary>
        /// 按月统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthSales(SdSalesInvoiceQueryDto parm);

        /// <summary>
        /// 按月,国家统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthAreaSales(SdSalesInvoiceQueryDto parm);

        /// <summary>
        /// 按月,仕向统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListMonthRegionSales(SdSalesInvoiceQueryDto parm);

        /// <summary>
        /// 按年统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListYearSales(SdSalesInvoiceQueryDto parm);

        /// <summary>
        /// 按年,国家统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListYearAreaSales(SdSalesInvoiceQueryDto parm);

        /// <summary>
        /// 按年,仕向统计销售
        /// </summary>
        /// <returns></returns>
        List<Dictionary<string, object>> GetListYearRegionSales(SdSalesInvoiceQueryDto parm);
    }
}