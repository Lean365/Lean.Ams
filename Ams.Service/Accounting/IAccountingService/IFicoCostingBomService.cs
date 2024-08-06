using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// bom成本核算
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:24
    /// </summary>
    public interface IFicoCostingBomService : IBaseService<FicoCostingBom>
    {
        /// <summary>
        /// 获取bom成本核算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoCostingBomDto> GetList(FicoCostingBomQueryDto parm);

        /// <summary>
        /// 获取bom成本核算信息
        /// </summary>
        /// <param name="BcSfId"></param>
        /// <returns></returns>
        FicoCostingBom GetInfo(long BcSfId);
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
        FicoCostingBom AddFicoCostingBom(FicoCostingBom parm);

        /// <summary>
        /// 更新
        /// bom成本核算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoCostingBom(FicoCostingBom parm);


        /// <summary>
        /// 批量导入
        /// bom成本核算
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoCostingBom(List<FicoCostingBom> list);

        /// <summary>
        /// 导出
        /// bom成本核算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoCostingBomDto> ExportList(FicoCostingBomQueryDto parm);
    }
}
