using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 供应商
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:53
    /// </summary>
    public interface IMmSupplierService : IBaseService<MmSupplier>
    {
        /// <summary>
        /// 获取供应商列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmSupplierDto> GetList(MmSupplierQueryDto parm);

        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        MmSupplier GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 供应商
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        MmSupplier AddMmSupplier(MmSupplier parm);

        /// <summary>
        /// 更新
        /// 供应商
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateMmSupplier(MmSupplier parm);


        /// <summary>
        /// 批量导入
        /// 供应商
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportMmSupplier(List<MmSupplier> list);

        /// <summary>
        /// 导出
        /// 供应商
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmSupplierDto> ExportList(MmSupplierQueryDto parm);
    }
}
