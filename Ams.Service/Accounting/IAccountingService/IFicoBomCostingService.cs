using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// bom成本核算
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:12
    /// </summary>
    public interface IFicoBomCostingService : IBaseService<FicoBomCosting>
    {
        /// <summary>
        /// 获取bom成本核算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBomCostingDto> GetList(FicoBomCostingQueryDto parm);

        /// <summary>
        /// 获取bom成本核算信息
        /// </summary>
        /// <param name="BcSFID"></param>
        /// <returns></returns>
        FicoBomCosting GetInfo(long BcSFID);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// bom成本核算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoBomCosting AddFicoBomCosting(FicoBomCosting parm);

        /// <summary>
        /// 更新
        /// bom成本核算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBomCosting(FicoBomCosting parm);


        /// <summary>
        /// 批量导入
        /// bom成本核算
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBomCosting(List<FicoBomCosting> list);

        /// <summary>
        /// 导出
        /// bom成本核算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBomCostingDto> ExportList(FicoBomCostingQueryDto parm);
    }
}
