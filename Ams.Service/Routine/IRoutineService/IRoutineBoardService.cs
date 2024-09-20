using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 看板
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/20 9:52:38
    /// </summary>
    public interface IRoutineBoardService : IBaseService<RoutineBoard>
    {
        /// <summary>
        /// 获取看板列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineBoardDto> GetList(RoutineBoardQueryDto parm);

        /// <summary>
        /// 获取看板信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        RoutineBoard GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 看板
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        RoutineBoard AddRoutineBoard(RoutineBoard parm);

        /// <summary>
        /// 更新
        /// 看板
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateRoutineBoard(RoutineBoard parm);


        /// <summary>
        /// 批量导入
        /// 看板
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportRoutineBoard(List<RoutineBoard> list);

        /// <summary>
        /// 导出
        /// 看板
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<RoutineBoardDto> ExportList(RoutineBoardQueryDto parm);
    }
}
