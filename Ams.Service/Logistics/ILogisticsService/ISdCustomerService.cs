using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 顾客信息
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 13:49:23
    /// </summary>
    public interface ISdCustomerService : IBaseService<SdCustomer>
    {
        /// <summary>
        /// 获取顾客信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SdCustomerDto> GetList(SdCustomerQueryDto parm);

        /// <summary>
        /// 获取顾客信息信息
        /// </summary>
        /// <param name="ScSfId"></param>
        /// <returns></returns>
        SdCustomer GetInfo(long ScSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 顾客信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        SdCustomer AddSdCustomer(SdCustomer parm);

        /// <summary>
        /// 更新
        /// 顾客信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateSdCustomer(SdCustomer parm);


        /// <summary>
        /// 批量导入
        /// 顾客信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportSdCustomer(List<SdCustomer> list);

        /// <summary>
        /// 导出
        /// 顾客信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SdCustomerDto> ExportList(SdCustomerQueryDto parm);
    }
}
