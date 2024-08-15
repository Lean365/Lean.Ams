using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 加班预算
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:25:44
    /// </summary>
    public interface IFicoBudgetOvertimeMaService : IBaseService<FicoBudgetOvertimeMa>
    {
        /// <summary>
        /// 获取加班预算列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetOvertimeMaDto> GetList(FicoBudgetOvertimeMaQueryDto parm);

        /// <summary>
        /// 获取加班预算信息
        /// </summary>
        /// <param name="FboSfId"></param>
        /// <returns></returns>
        FicoBudgetOvertimeMa GetInfo(long FboSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 加班预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoBudgetOvertimeMa AddFicoBudgetOvertimeMa(FicoBudgetOvertimeMa parm);

        /// <summary>
        /// 更新
        /// 加班预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoBudgetOvertimeMa(FicoBudgetOvertimeMa parm);


        /// <summary>
        /// 批量导入
        /// 加班预算
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoBudgetOvertimeMa(List<FicoBudgetOvertimeMa> list);

        /// <summary>
        /// 导出
        /// 加班预算
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoBudgetOvertimeMaDto> ExportList(FicoBudgetOvertimeMaQueryDto parm);
    }
}
