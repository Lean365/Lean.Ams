using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 原因类别
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:54:27)
    /// </summary>
    public interface ICauseTypeService : IBaseService<CauseType>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<CauseTypeDto> GetList(CauseTypeQueryDto parm);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="CtSFID"></param>
        /// <returns></returns>
        CauseType GetInfo(long CtSFID);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString);


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        CauseType AddCauseType(CauseType parm);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateCauseType(CauseType parm);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportCauseType(List<CauseType> list);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<CauseTypeDto> ExportList(CauseTypeQueryDto parm);
    }
}
