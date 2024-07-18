using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 资产预算
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:07
    /// </summary>
    public interface IFicoBudgetAssetService : IBaseService<FicoBudgetAsset>
    {
        /// <summary>
        /// 获取资产预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetAssetDto> GetList(FicoBudgetAssetQueryDto parm);

        /// <summary>
        /// 获取资产预算信息
        /// </summary>
        /// <param name="FbaSFID"></param>
        /// <returns></returns>
        FicoBudgetAsset GetInfo(long FbaSFID);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 资产预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoBudgetAsset AddFicoBudgetAsset(FicoBudgetAsset parm);

        /// <summary>
        /// 更新
        /// 资产预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetAsset(FicoBudgetAsset parm);


        /// <summary>
        /// 批量导入
        /// 资产预算
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetAsset(List<FicoBudgetAsset> list);

        /// <summary>
        /// 导出
        /// 资产预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetAssetDto> ExportList(FicoBudgetAssetQueryDto parm);
    }
}
