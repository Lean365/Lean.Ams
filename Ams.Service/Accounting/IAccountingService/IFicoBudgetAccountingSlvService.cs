using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 预算科目
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 8:38:32
    /// </summary>
    public interface IFicoBudgetAccountingSlvService : IBaseService<FicoBudgetAccountingSlv>
    {
        /// <summary>
        /// 获取预算科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetAccountingSlvDto> GetList(FicoBudgetAccountingSlvQueryDto parm);

        /// <summary>
        /// 获取预算科目信息
        /// </summary>
        /// <param name="FbasSfid"></param>
        /// <returns></returns>
        FicoBudgetAccountingSlv GetInfo(long FbasSfid);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 预算科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoBudgetAccountingSlv AddFicoBudgetAccountingSlv(FicoBudgetAccountingSlv parm);

        /// <summary>
        /// 更新
        /// 预算科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetAccountingSlv(FicoBudgetAccountingSlv parm);


        /// <summary>
        /// 批量导入
        /// 预算科目
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetAccountingSlv(List<FicoBudgetAccountingSlv> list);

        /// <summary>
        /// 导出
        /// 预算科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetAccountingSlvDto> ExportList(FicoBudgetAccountingSlvQueryDto parm);
    }
}
