using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 汇率表
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:18
    /// </summary>
    public interface IFicoExchangeRateService : IBaseService<FicoExchangeRate>
    {
        /// <summary>
        /// 获取汇率表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoExchangeRateDto> GetList(FicoExchangeRateQueryDto parm);

        /// <summary>
        /// 获取汇率表信息
        /// </summary>
        /// <param name="FerSfId"></param>
        /// <returns></returns>
        FicoExchangeRate GetInfo(long FerSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 汇率表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoExchangeRate AddFicoExchangeRate(FicoExchangeRate parm);

        /// <summary>
        /// 更新
        /// 汇率表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoExchangeRate(FicoExchangeRate parm);


        /// <summary>
        /// 批量导入
        /// 汇率表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoExchangeRate(List<FicoExchangeRate> list);

        /// <summary>
        /// 导出
        /// 汇率表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoExchangeRateDto> ExportList(FicoExchangeRateQueryDto parm);
    }
}
