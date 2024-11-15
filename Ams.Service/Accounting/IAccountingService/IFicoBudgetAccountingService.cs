using Ams.Model.Accounting;
using Ams.Model.Accounting.Dto;
using Ams.Model.Vo;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 预算科目
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/15 17:17:38
    /// </summary>
    public interface IFicoBudgetAccountingService : IBaseService<FicoBudgetAccounting>
    {
        /// <summary>
        /// 获取预算科目列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetAccountingDto> GetList(FicoBudgetAccountingQueryDto parm);

        /// <summary>
        /// 获取预算科目信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        FicoBudgetAccounting GetInfo(long Id);

        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);

        /// <summary>
        /// 查询部门管理数据
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        List<FicoBudgetAccounting> GetBudgetAccountings(FicoBudgetAccountingQueryDto parm);

        List<FicoBudgetAccounting> BuildBudgetAccountingTree(List<FicoBudgetAccounting> parms);

        /// <summary>
        /// 构建预算科目树
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        List<TreeSelectVo> BuildBudgetAccountingTreeSelect(List<FicoBudgetAccounting> parms);

        /// <summary>
        /// 获取预算科目树信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        List<FicoBudgetAccounting> GetTreeList(FicoBudgetAccountingQueryDto parm);

        /// <summary>
        /// 新增
        /// 预算科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoBudgetAccounting AddFicoBudgetAccounting(FicoBudgetAccounting parm);

        /// <summary>
        /// 更新
        /// 预算科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetAccounting(FicoBudgetAccounting parm);

        /// <summary>
        /// 批量导入
        /// 预算科目
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetAccounting(List<FicoBudgetAccounting> list);

        /// <summary>
        /// 导出
        /// 预算科目
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetAccountingDto> ExportList(FicoBudgetAccountingQueryDto parm);
    }
}