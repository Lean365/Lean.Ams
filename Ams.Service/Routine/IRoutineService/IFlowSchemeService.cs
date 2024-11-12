using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 流程
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/31 11:32:52
    /// </summary>
    public interface IFlowSchemeService : IBaseService<FlowScheme>
    {
        /// <summary>
        /// 获取流程列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FlowSchemeDto> GetList(FlowSchemeQueryDto parm);

        /// <summary>
        /// 获取流程信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        FlowScheme GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 流程
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FlowScheme AddFlowScheme(FlowScheme parm);

        /// <summary>
        /// 更新
        /// 流程
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFlowScheme(FlowScheme parm);


        /// <summary>
        /// 批量导入
        /// 流程
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFlowScheme(List<FlowScheme> list);

        /// <summary>
        /// 导出
        /// 流程
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FlowSchemeDto> ExportList(FlowSchemeQueryDto parm);
    }
}
