using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 资产预算
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 13:57:42)
    /// </summary>
    public interface IBudgetAssetService : IBaseService<BudgetAsset>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<BudgetAssetDto> GetList(BudgetAssetQueryDto parm);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="FbaSFID"></param>
        /// <returns></returns>
        BudgetAsset GetInfo(long FbaSFID);

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
        BudgetAsset AddBudgetAsset(BudgetAsset parm);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateBudgetAsset(BudgetAsset parm);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportBudgetAsset(List<BudgetAsset> list);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<BudgetAssetDto> ExportList(BudgetAssetQueryDto parm);
    }
}
