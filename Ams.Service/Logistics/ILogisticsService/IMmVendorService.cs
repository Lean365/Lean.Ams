using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 厂商信息
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 11:23:27
    /// </summary>
    public interface IMmVendorService : IBaseService<MmVendor>
    {
        /// <summary>
        /// 获取厂商信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmVendorDto> GetList(MmVendorQueryDto parm);

        /// <summary>
        /// 获取厂商信息信息
        /// </summary>
        /// <param name="VeSfId"></param>
        /// <returns></returns>
        MmVendor GetInfo(long VeSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 厂商信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        MmVendor AddMmVendor(MmVendor parm);

        /// <summary>
        /// 更新
        /// 厂商信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateMmVendor(MmVendor parm);


        /// <summary>
        /// 批量导入
        /// 厂商信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportMmVendor(List<MmVendor> list);

        /// <summary>
        /// 导出
        /// 厂商信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmVendorDto> ExportList(MmVendorQueryDto parm);
    }
}
