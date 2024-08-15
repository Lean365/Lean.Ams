using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 月度资产
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:59:43
    /// </summary>
    public interface IFicoMonthlyAssetsService : IBaseService<FicoMonthlyAssets>
    {
        /// <summary>
        /// 获取月度资产列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoMonthlyAssetsDto> GetList(FicoMonthlyAssetsQueryDto parm);

        /// <summary>
        /// 获取月度资产信息
        /// </summary>
        /// <param name="FaSfId"></param>
        /// <returns></returns>
        FicoMonthlyAssets GetInfo(long FaSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 月度资产
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoMonthlyAssets AddFicoMonthlyAssets(FicoMonthlyAssets parm);

        /// <summary>
        /// 更新
        /// 月度资产
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoMonthlyAssets(FicoMonthlyAssets parm);


        /// <summary>
        /// 批量导入
        /// 月度资产
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoMonthlyAssets(List<FicoMonthlyAssets> list);

        /// <summary>
        /// 导出
        /// 月度资产
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoMonthlyAssetsDto> ExportList(FicoMonthlyAssetsQueryDto parm);
    }
}
