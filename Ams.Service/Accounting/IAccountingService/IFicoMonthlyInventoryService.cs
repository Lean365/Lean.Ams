using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 月度存货
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:45:33
    /// </summary>
    public interface IFicoMonthlyInventoryService : IBaseService<FicoMonthlyInventory>
    {
        /// <summary>
        /// 获取月度存货列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoMonthlyInventoryDto> GetList(FicoMonthlyInventoryQueryDto parm);

        /// <summary>
        /// 获取月度存货信息
        /// </summary>
        /// <param name="MiSFID"></param>
        /// <returns></returns>
        FicoMonthlyInventory GetInfo(long MiSFID);


        /// <summary>
        /// 批量导入
        /// 月度存货
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoMonthlyInventory(List<FicoMonthlyInventory> list);

        /// <summary>
        /// 导出
        /// 月度存货
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoMonthlyInventoryDto> ExportList(FicoMonthlyInventoryQueryDto parm);
    }
}
