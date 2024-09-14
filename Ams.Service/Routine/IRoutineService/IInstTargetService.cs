using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 机构目标
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:12:49
    /// </summary>
    public interface IInstTargetService : IBaseService<InstTarget>
    {
        /// <summary>
        /// 获取机构目标列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<InstTargetDto> GetList(InstTargetQueryDto parm);

        /// <summary>
        /// 获取机构目标信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        InstTarget GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 机构目标
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        InstTarget AddInstTarget(InstTarget parm);

        /// <summary>
        /// 更新
        /// 机构目标
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateInstTarget(InstTarget parm);


        /// <summary>
        /// 批量导入
        /// 机构目标
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportInstTarget(List<InstTarget> list);

        /// <summary>
        /// 导出
        /// 机构目标
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<InstTargetDto> ExportList(InstTargetQueryDto parm);
    }
}
