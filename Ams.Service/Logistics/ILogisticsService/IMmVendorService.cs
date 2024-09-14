using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 销售商
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:56
    /// </summary>
    public interface IMmVendorService : IBaseService<MmVendor>
    {
        /// <summary>
        /// 获取销售商列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmVendorDto> GetList(MmVendorQueryDto parm);

        /// <summary>
        /// 获取销售商信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        MmVendor GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 销售商
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        MmVendor AddMmVendor(MmVendor parm);

        /// <summary>
        /// 更新
        /// 销售商
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateMmVendor(MmVendor parm);


        /// <summary>
        /// 批量导入
        /// 销售商
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportMmVendor(List<MmVendor> list);

        /// <summary>
        /// 导出
        /// 销售商
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmVendorDto> ExportList(MmVendorQueryDto parm);
    }
}
