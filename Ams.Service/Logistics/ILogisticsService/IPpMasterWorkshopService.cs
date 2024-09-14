using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 生产班组
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 12:06:17
    /// </summary>
    public interface IPpMasterWorkshopService : IBaseService<PpMasterWorkshop>
    {
        /// <summary>
        /// 获取生产班组列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpMasterWorkshopDto> GetList(PpMasterWorkshopQueryDto parm);

        /// <summary>
        /// 获取生产班组信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpMasterWorkshop GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 生产班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpMasterWorkshop AddPpMasterWorkshop(PpMasterWorkshop parm);

        /// <summary>
        /// 更新
        /// 生产班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpMasterWorkshop(PpMasterWorkshop parm);


        /// <summary>
        /// 批量导入
        /// 生产班组
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpMasterWorkshop(List<PpMasterWorkshop> list);

        /// <summary>
        /// 导出
        /// 生产班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpMasterWorkshopDto> ExportList(PpMasterWorkshopQueryDto parm);
    }
}
