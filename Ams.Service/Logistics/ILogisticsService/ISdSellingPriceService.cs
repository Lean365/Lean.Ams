using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 销售价格
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:46:00
    /// </summary>
    public interface ISdSellingPriceService : IBaseService<SdSellingPrice>
    {
        /// <summary>
        /// 获取销售价格列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SdSellingPriceDto> GetList(SdSellingPriceQueryDto parm);

        /// <summary>
        /// 获取销售价格信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        SdSellingPrice GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 销售价格
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        SdSellingPrice AddSdSellingPrice(SdSellingPrice parm);

        /// <summary>
        /// 更新
        /// 销售价格
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateSdSellingPrice(SdSellingPrice parm);


        /// <summary>
        /// 批量导入
        /// 销售价格
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportSdSellingPrice(List<SdSellingPrice> list);

        /// <summary>
        /// 导出
        /// 销售价格
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SdSellingPriceDto> ExportList(SdSellingPriceQueryDto parm);
    }
}
