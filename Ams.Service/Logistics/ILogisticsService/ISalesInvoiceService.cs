using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 销售凭证
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/31 12:01:23)
    /// </summary>
    public interface ISalesInvoiceService : IBaseService<SalesInvoice>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SalesInvoiceDto> GetList(SalesInvoiceQueryDto parm);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="SsiSfid"></param>
        /// <returns></returns>
        SalesInvoice GetInfo(long SsiSfid);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString);


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        SalesInvoice AddSalesInvoice(SalesInvoice parm);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateSalesInvoice(SalesInvoice parm);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportSalesInvoice(List<SalesInvoice> list);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SalesInvoiceDto> ExportList(SalesInvoiceQueryDto parm);
    }
}
