using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 资产预算
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/14 9:17:19
    /// </summary>
    public interface IFicoBudgetAssetsService : IBaseService<FicoBudgetAssets>
    {
        /// <summary>
        /// 获取资产预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetAssetsDto> GetList(FicoBudgetAssetsQueryDto parm);

        /// <summary>
        /// 获取资产预算信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        FicoBudgetAssets GetInfo(long Id);
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
        FicoBudgetAssets AddFicoBudgetAssets(FicoBudgetAssets parm);

        /// <summary>
        /// 更新
        /// 资产预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetAssets(FicoBudgetAssets parm);


        /// <summary>
        /// 批量导入
        /// 资产预算
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetAssets(List<FicoBudgetAssets> list);

        /// <summary>
        /// 导出
        /// 资产预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetAssetsDto> ExportList(FicoBudgetAssetsQueryDto parm);
    }
}
