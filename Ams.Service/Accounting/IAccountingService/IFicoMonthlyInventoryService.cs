using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 月度存货
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:55:10
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
        /// <param name="Id"></param>
        /// <returns></returns>
        FicoMonthlyInventory GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 月度存货
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoMonthlyInventory AddFicoMonthlyInventory(FicoMonthlyInventory parm);

        /// <summary>
        /// 更新
        /// 月度存货
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoMonthlyInventory(FicoMonthlyInventory parm);


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
