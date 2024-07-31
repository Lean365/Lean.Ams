using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 奖惩
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:30:08
    /// </summary>
    public interface IRoutineEhrRewardPenaltiesService : IBaseService<RoutineEhrRewardPenalties>
    {
        /// <summary>
        /// 获取奖惩列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrRewardPenaltiesDto> GetList(RoutineEhrRewardPenaltiesQueryDto parm);

        /// <summary>
        /// 获取奖惩信息
        /// </summary>
        /// <param name="EeSfId"></param>
        /// <returns></returns>
        RoutineEhrRewardPenalties GetInfo(long EeSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 奖惩
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        RoutineEhrRewardPenalties AddRoutineEhrRewardPenalties(RoutineEhrRewardPenalties parm);

        /// <summary>
        /// 更新
        /// 奖惩
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateRoutineEhrRewardPenalties(RoutineEhrRewardPenalties parm);


        /// <summary>
        /// 批量导入
        /// 奖惩
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportRoutineEhrRewardPenalties(List<RoutineEhrRewardPenalties> list);

        /// <summary>
        /// 导出
        /// 奖惩
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrRewardPenaltiesDto> ExportList(RoutineEhrRewardPenaltiesQueryDto parm);
    }
}
