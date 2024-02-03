using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 工资率
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 7:33:39)
    /// </summary>
    public interface IWageRatesService : IBaseService<WageRates>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<WageRatesDto> GetList(WageRatesQueryDto parm);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="FwSFID"></param>
        /// <returns></returns>
        WageRates GetInfo(long FwSFID);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString);


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        WageRates AddWageRates(WageRates parm);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateWageRates(WageRates parm);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportWageRates(List<WageRates> list);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<WageRatesDto> ExportList(WageRatesQueryDto parm);
    }
}
