using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 资产类别
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/12 16:16:33
    /// </summary>
    public interface IFicoAssetsCategoryService : IBaseService<FicoAssetsCategory>
    {
        /// <summary>
        /// 获取资产类别列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoAssetsCategoryDto> GetList(FicoAssetsCategoryQueryDto parm);

        /// <summary>
        /// 获取资产类别信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        FicoAssetsCategory GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 资产类别
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoAssetsCategory AddFicoAssetsCategory(FicoAssetsCategory parm);

        /// <summary>
        /// 更新
        /// 资产类别
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoAssetsCategory(FicoAssetsCategory parm);


        /// <summary>
        /// 批量导入
        /// 资产类别
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoAssetsCategory(List<FicoAssetsCategory> list);

        /// <summary>
        /// 导出
        /// 资产类别
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoAssetsCategoryDto> ExportList(FicoAssetsCategoryQueryDto parm);
    }
}
