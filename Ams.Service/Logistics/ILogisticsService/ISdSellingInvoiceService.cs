using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 销售凭证
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/7 16:16:45
    /// </summary>
    public interface ISdSellingInvoiceService : IBaseService<SdSellingInvoice>
    {
        /// <summary>
        /// 获取销售凭证列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SdSellingInvoiceDto> GetList(SdSellingInvoiceQueryDto parm);

        /// <summary>
        /// 获取销售凭证信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        SdSellingInvoice GetInfo(long Id);
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
        SdSellingInvoice AddSdSellingInvoice(SdSellingInvoice parm);

        /// <summary>
        /// 更新
        /// 销售凭证
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateSdSellingInvoice(SdSellingInvoice parm);


        /// <summary>
        /// 批量导入
        /// 销售凭证
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportSdSellingInvoice(List<SdSellingInvoice> list);

        /// <summary>
        /// 导出
        /// 销售凭证
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SdSellingInvoiceDto> ExportList(SdSellingInvoiceQueryDto parm);
    }
}
