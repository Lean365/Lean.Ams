using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 资产预算
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:25:02
    /// </summary>
    public interface IFicoBudgetAssetsMaService : IBaseService<FicoBudgetAssetsMa>
    {
        /// <summary>
        /// 获取资产预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetAssetsMaDto> GetList(FicoBudgetAssetsMaQueryDto parm);

        /// <summary>
        /// 获取资产预算信息
        /// </summary>
        /// <param name="FbaSfId"></param>
        /// <returns></returns>
        FicoBudgetAssetsMa GetInfo(long FbaSfId);
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
        FicoBudgetAssetsMa AddFicoBudgetAssetsMa(FicoBudgetAssetsMa parm);

        /// <summary>
        /// 更新
        /// 资产预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetAssetsMa(FicoBudgetAssetsMa parm);


        /// <summary>
        /// 批量导入
        /// 资产预算
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetAssetsMa(List<FicoBudgetAssetsMa> list);

        /// <summary>
        /// 导出
        /// 资产预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetAssetsMaDto> ExportList(FicoBudgetAssetsMaQueryDto parm);
    }
}
