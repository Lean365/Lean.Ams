using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 财务期间
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 13:51:07
    /// </summary>
    public interface IFicoFinancialPeriodService : IBaseService<FicoFinancialPeriod>
    {
        /// <summary>
        /// 获取财务期间列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoFinancialPeriodDto> GetList(FicoFinancialPeriodQueryDto parm);

        /// <summary>
        /// 获取财务期间信息
        /// </summary>
        /// <param name="FpSfId"></param>
        /// <returns></returns>
        FicoFinancialPeriod GetInfo(long FpSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 财务期间
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoFinancialPeriod AddFicoFinancialPeriod(FicoFinancialPeriod parm);

        /// <summary>
        /// 更新
        /// 财务期间
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoFinancialPeriod(FicoFinancialPeriod parm);


        /// <summary>
        /// 批量导入
        /// 财务期间
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoFinancialPeriod(List<FicoFinancialPeriod> list);

        /// <summary>
        /// 导出
        /// 财务期间
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoFinancialPeriodDto> ExportList(FicoFinancialPeriodQueryDto parm);
    }
}
