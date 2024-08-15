using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 福利
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:33:35
    /// </summary>
    public interface IRoutineEhrBenefitsService : IBaseService<RoutineEhrBenefits>
    {
        /// <summary>
        /// 获取福利列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrBenefitsDto> GetList(RoutineEhrBenefitsQueryDto parm);

        /// <summary>
        /// 获取福利信息
        /// </summary>
        /// <param name="EeSfId"></param>
        /// <returns></returns>
        RoutineEhrBenefits GetInfo(long EeSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 福利
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        RoutineEhrBenefits AddRoutineEhrBenefits(RoutineEhrBenefits parm);

        /// <summary>
        /// 更新
        /// 福利
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateRoutineEhrBenefits(RoutineEhrBenefits parm);


        /// <summary>
        /// 批量导入
        /// 福利
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportRoutineEhrBenefits(List<RoutineEhrBenefits> list);

        /// <summary>
        /// 导出
        /// 福利
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrBenefitsDto> ExportList(RoutineEhrBenefitsQueryDto parm);
    }
}
