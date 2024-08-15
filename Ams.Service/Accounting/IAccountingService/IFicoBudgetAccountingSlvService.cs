using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 明细科目
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 17:37:35
    /// </summary>
    public interface IFicoBudgetAccountingSlvService : IBaseService<FicoBudgetAccountingSlv>
    {
        /// <summary>
        /// 获取明细科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetAccountingSlvDto> GetList(FicoBudgetAccountingSlvQueryDto parm);

        /// <summary>
        /// 获取明细科目信息
        /// </summary>
        /// <param name="FbasSfId"></param>
        /// <returns></returns>
        FicoBudgetAccountingSlv GetInfo(long FbasSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 明细科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoBudgetAccountingSlv AddFicoBudgetAccountingSlv(FicoBudgetAccountingSlv parm);

        /// <summary>
        /// 更新
        /// 明细科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetAccountingSlv(FicoBudgetAccountingSlv parm);


        /// <summary>
        /// 批量导入
        /// 明细科目
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetAccountingSlv(List<FicoBudgetAccountingSlv> list);

        /// <summary>
        /// 导出
        /// 明细科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetAccountingSlvDto> ExportList(FicoBudgetAccountingSlvQueryDto parm);
    }
}
