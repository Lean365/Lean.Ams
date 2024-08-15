using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 资产预算
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:23:49
    /// </summary>
    public interface IFicoBudgetAssetsSlvService : IBaseService<FicoBudgetAssetsSlv>
    {
        /// <summary>
        /// 获取资产预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetAssetsSlvDto> GetList(FicoBudgetAssetsSlvQueryDto parm);

        /// <summary>
        /// 获取资产预算信息
        /// </summary>
        /// <param name="FbasSfId"></param>
        /// <returns></returns>
        FicoBudgetAssetsSlv GetInfo(long FbasSfId);
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
        FicoBudgetAssetsSlv AddFicoBudgetAssetsSlv(FicoBudgetAssetsSlv parm);

        /// <summary>
        /// 更新
        /// 资产预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetAssetsSlv(FicoBudgetAssetsSlv parm);


        /// <summary>
        /// 批量导入
        /// 资产预算
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetAssetsSlv(List<FicoBudgetAssetsSlv> list);

        /// <summary>
        /// 导出
        /// 资产预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetAssetsSlvDto> ExportList(FicoBudgetAssetsSlvQueryDto parm);
    }
}
