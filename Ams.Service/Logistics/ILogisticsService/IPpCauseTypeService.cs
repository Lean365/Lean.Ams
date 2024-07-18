using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 原因类别
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 15:57:22
    /// </summary>
    public interface IPpCauseTypeService : IBaseService<PpCauseType>
    {
        /// <summary>
        /// 获取原因类别列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpCauseTypeDto> GetList(PpCauseTypeQueryDto parm);

        /// <summary>
        /// 获取原因类别信息
        /// </summary>
        /// <param name="CtSFID"></param>
        /// <returns></returns>
        PpCauseType GetInfo(long CtSFID);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 原因类别
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpCauseType AddPpCauseType(PpCauseType parm);

        /// <summary>
        /// 更新
        /// 原因类别
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpCauseType(PpCauseType parm);


        /// <summary>
        /// 批量导入
        /// 原因类别
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpCauseType(List<PpCauseType> list);

        /// <summary>
        /// 导出
        /// 原因类别
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpCauseTypeDto> ExportList(PpCauseTypeQueryDto parm);
    }
}
