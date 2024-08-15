using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 生产班组
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 14:45:07
    /// </summary>
    public interface IPpLineService : IBaseService<PpLine>
    {
        /// <summary>
        /// 获取生产班组列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpLineDto> GetList(PpLineQueryDto parm);

        /// <summary>
        /// 获取生产班组信息
        /// </summary>
        /// <param name="PlSfId"></param>
        /// <returns></returns>
        PpLine GetInfo(long PlSfId);
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
        PpLine AddPpLine(PpLine parm);

        /// <summary>
        /// 更新
        /// 生产班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpLine(PpLine parm);


        /// <summary>
        /// 批量导入
        /// 生产班组
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpLine(List<PpLine> list);

        /// <summary>
        /// 导出
        /// 生产班组
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpLineDto> ExportList(PpLineQueryDto parm);
    }
}
