using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 源物料
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:18:11
    /// </summary>
    public interface IPpSourceMaterialService : IBaseService<PpSourceMaterial>
    {
        /// <summary>
        /// 获取源物料列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpSourceMaterialDto> GetList(PpSourceMaterialQueryDto parm);

        /// <summary>
        /// 获取源物料信息
        /// </summary>
        /// <param name="SfId"></param>
        /// <returns></returns>
        PpSourceMaterial GetInfo(long SfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 源物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpSourceMaterial AddPpSourceMaterial(PpSourceMaterial parm);

        /// <summary>
        /// 更新
        /// 源物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpSourceMaterial(PpSourceMaterial parm);


        /// <summary>
        /// 批量导入
        /// 源物料
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpSourceMaterial(List<PpSourceMaterial> list);

        /// <summary>
        /// 导出
        /// 源物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpSourceMaterialDto> ExportList(PpSourceMaterialQueryDto parm);
    }
}
