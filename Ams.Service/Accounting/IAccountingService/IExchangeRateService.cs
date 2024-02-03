using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 汇率表
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 8:07:17)
    /// </summary>
    public interface IExchangeRateService : IBaseService<ExchangeRate>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<ExchangeRateDto> GetList(ExchangeRateQueryDto parm);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="FerSFID"></param>
        /// <returns></returns>
        ExchangeRate GetInfo(long FerSFID);

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
        ExchangeRate AddExchangeRate(ExchangeRate parm);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateExchangeRate(ExchangeRate parm);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportExchangeRate(List<ExchangeRate> list);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<ExchangeRateDto> ExportList(ExchangeRateQueryDto parm);
    }
}
