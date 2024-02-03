using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 月度存货
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 8:20:25)
    /// </summary>
    public interface IMonthlyInventoryService : IBaseService<MonthlyInventory>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MonthlyInventoryDto> GetList(MonthlyInventoryQueryDto parm);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="MiSFID"></param>
        /// <returns></returns>
        MonthlyInventory GetInfo(long MiSFID);

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
        MonthlyInventory AddMonthlyInventory(MonthlyInventory parm);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateMonthlyInventory(MonthlyInventory parm);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportMonthlyInventory(List<MonthlyInventory> list);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MonthlyInventoryDto> ExportList(MonthlyInventoryQueryDto parm);
    }
}
