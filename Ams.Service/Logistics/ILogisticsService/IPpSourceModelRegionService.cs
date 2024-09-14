using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 源机种仕向
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:38:17
    /// </summary>
    public interface IPpSourceModelRegionService : IBaseService<PpSourceModelRegion>
    {
        /// <summary>
        /// 获取源机种仕向列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpSourceModelRegionDto> GetList(PpSourceModelRegionQueryDto parm);

        /// <summary>
        /// 获取源机种仕向信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpSourceModelRegion GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 源机种仕向
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpSourceModelRegion AddPpSourceModelRegion(PpSourceModelRegion parm);

        /// <summary>
        /// 更新
        /// 源机种仕向
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpSourceModelRegion(PpSourceModelRegion parm);


        /// <summary>
        /// 批量导入
        /// 源机种仕向
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpSourceModelRegion(List<PpSourceModelRegion> list);

        /// <summary>
        /// 导出
        /// 源机种仕向
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpSourceModelRegionDto> ExportList(PpSourceModelRegionQueryDto parm);
    }
}
