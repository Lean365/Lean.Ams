using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 工资率
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:12
    /// </summary>
    public interface IFicoWageRatesService : IBaseService<FicoWageRates>
    {
        /// <summary>
        /// 获取工资率列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoWageRatesDto> GetList(FicoWageRatesQueryDto parm);

        /// <summary>
        /// 获取工资率信息
        /// </summary>
        /// <param name="FwSfId"></param>
        /// <returns></returns>
        FicoWageRates GetInfo(long FwSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 工资率
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoWageRates AddFicoWageRates(FicoWageRates parm);

        /// <summary>
        /// 更新
        /// 工资率
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoWageRates(FicoWageRates parm);


        /// <summary>
        /// 批量导入
        /// 工资率
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoWageRates(List<FicoWageRates> list);

        /// <summary>
        /// 导出
        /// 工资率
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoWageRatesDto> ExportList(FicoWageRatesQueryDto parm);
    }
}
