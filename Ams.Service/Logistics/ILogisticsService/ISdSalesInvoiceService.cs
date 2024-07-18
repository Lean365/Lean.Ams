using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 销售凭证
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 11:28:47
    /// </summary>
    public interface ISdSalesInvoiceService : IBaseService<SdSalesInvoice>
    {
        /// <summary>
        /// 获取销售凭证列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SdSalesInvoiceDto> GetList(SdSalesInvoiceQueryDto parm);

        /// <summary>
        /// 获取销售凭证信息
        /// </summary>
        /// <param name="SsiSfid"></param>
        /// <returns></returns>
        SdSalesInvoice GetInfo(long SsiSfid);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 销售凭证
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        SdSalesInvoice AddSdSalesInvoice(SdSalesInvoice parm);

        /// <summary>
        /// 更新
        /// 销售凭证
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateSdSalesInvoice(SdSalesInvoice parm);


        /// <summary>
        /// 批量导入
        /// 销售凭证
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportSdSalesInvoice(List<SdSalesInvoice> list);

        /// <summary>
        /// 导出
        /// 销售凭证
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SdSalesInvoiceDto> ExportList(SdSalesInvoiceQueryDto parm);
    }
}
