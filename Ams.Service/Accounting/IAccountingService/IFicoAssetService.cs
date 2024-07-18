using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 固定资产
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/4 15:23:24
    /// </summary>
    public interface IFicoAssetService : IBaseService<FicoAsset>
    {
        /// <summary>
        /// 获取固定资产列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoAssetDto> GetList(FicoAssetQueryDto parm);

        /// <summary>
        /// 获取固定资产信息
        /// </summary>
        /// <param name="FaSFID"></param>
        /// <returns></returns>
        FicoAsset GetInfo(long FaSFID);

        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);

        /// <summary>
        /// 新增
        /// 固定资产
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoAsset AddFicoAsset(FicoAsset parm);

        /// <summary>
        /// 更新
        /// 固定资产
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoAsset(FicoAsset parm);


        /// <summary>
        /// 批量导入
        /// 固定资产
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoAsset(List<FicoAsset> list);

        /// <summary>
        /// 导出
        /// 固定资产
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoAssetDto> ExportList(FicoAssetQueryDto parm);
    }
}
