using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 招聘
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:31:16
    /// </summary>
    public interface IRoutineEhrRecruitmentService : IBaseService<RoutineEhrRecruitment>
    {
        /// <summary>
        /// 获取招聘列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrRecruitmentDto> GetList(RoutineEhrRecruitmentQueryDto parm);

        /// <summary>
        /// 获取招聘信息
        /// </summary>
        /// <param name="EeSfId"></param>
        /// <returns></returns>
        RoutineEhrRecruitment GetInfo(long EeSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 招聘
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        RoutineEhrRecruitment AddRoutineEhrRecruitment(RoutineEhrRecruitment parm);

        /// <summary>
        /// 更新
        /// 招聘
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateRoutineEhrRecruitment(RoutineEhrRecruitment parm);


        /// <summary>
        /// 批量导入
        /// 招聘
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportRoutineEhrRecruitment(List<RoutineEhrRecruitment> list);

        /// <summary>
        /// 导出
        /// 招聘
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineEhrRecruitmentDto> ExportList(RoutineEhrRecruitmentQueryDto parm);
    }
}
