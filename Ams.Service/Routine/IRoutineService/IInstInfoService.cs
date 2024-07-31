using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 机构信息
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 9:51:09
    /// </summary>
    public interface IInstInfoService : IBaseService<InstInfo>
    {
        /// <summary>
        /// 获取机构信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<InstInfoDto> GetList(InstInfoQueryDto parm);

        /// <summary>
        /// 获取机构信息信息
        /// </summary>
        /// <param name="IiSfId"></param>
        /// <returns></returns>
        InstInfo GetInfo(long IiSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 机构信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        InstInfo AddInstInfo(InstInfo parm);

        /// <summary>
        /// 更新
        /// 机构信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateInstInfo(InstInfo parm);


        /// <summary>
        /// 批量导入
        /// 机构信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportInstInfo(List<InstInfo> list);

        /// <summary>
        /// 导出
        /// 机构信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<InstInfoDto> ExportList(InstInfoQueryDto parm);
    }
}
