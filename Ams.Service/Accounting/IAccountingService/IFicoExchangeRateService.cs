using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 币种汇率
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:52:45
    /// </summary>
    public interface IFicoExchangeRateService : IBaseService<FicoExchangeRate>
    {
        /// <summary>
        /// 获取币种汇率列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoExchangeRateDto> GetList(FicoExchangeRateQueryDto parm);

        /// <summary>
        /// 获取币种汇率信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        FicoExchangeRate GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 币种汇率
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoExchangeRate AddFicoExchangeRate(FicoExchangeRate parm);

        /// <summary>
        /// 更新
        /// 币种汇率
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoExchangeRate(FicoExchangeRate parm);


        /// <summary>
        /// 批量导入
        /// 币种汇率
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoExchangeRate(List<FicoExchangeRate> list);

        /// <summary>
        /// 导出
        /// 币种汇率
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoExchangeRateDto> ExportList(FicoExchangeRateQueryDto parm);
    }
}
