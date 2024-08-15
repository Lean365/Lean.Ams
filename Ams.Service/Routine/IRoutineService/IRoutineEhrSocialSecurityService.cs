using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 社保
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:30:43
    /// </summary>
    public interface IRoutineEhrSocialSecurityService : IBaseService<RoutineEhrSocialSecurity>
    {
        /// <summary>
        /// 获取社保列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrSocialSecurityDto> GetList(RoutineEhrSocialSecurityQueryDto parm);

        /// <summary>
        /// 获取社保信息
        /// </summary>
        /// <param name="EeSfId"></param>
        /// <returns></returns>
        RoutineEhrSocialSecurity GetInfo(long EeSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 社保
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        RoutineEhrSocialSecurity AddRoutineEhrSocialSecurity(RoutineEhrSocialSecurity parm);

        /// <summary>
        /// 更新
        /// 社保
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateRoutineEhrSocialSecurity(RoutineEhrSocialSecurity parm);


        /// <summary>
        /// 批量导入
        /// 社保
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportRoutineEhrSocialSecurity(List<RoutineEhrSocialSecurity> list);

        /// <summary>
        /// 导出
        /// 社保
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrSocialSecurityDto> ExportList(RoutineEhrSocialSecurityQueryDto parm);
    }
}
