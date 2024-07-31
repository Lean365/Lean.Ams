using Ams.Model.Routine.Dto;
using Ams.Model.Routine;

namespace Ams.Service.Routine.IRoutineService
{
    /// <summary>
    /// 计算公式
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 10:24:50
    /// </summary>
    public interface IInstFormulaService : IBaseService<InstFormula>
    {
        /// <summary>
        /// 获取计算公式列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<InstFormulaDto> GetList(InstFormulaQueryDto parm);

        /// <summary>
        /// 获取计算公式信息
        /// </summary>
        /// <param name="IfSfId"></param>
        /// <returns></returns>
        InstFormula GetInfo(long IfSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 计算公式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        InstFormula AddInstFormula(InstFormula parm);

        /// <summary>
        /// 更新
        /// 计算公式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateInstFormula(InstFormula parm);


        /// <summary>
        /// 批量导入
        /// 计算公式
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportInstFormula(List<InstFormula> list);

        /// <summary>
        /// 导出
        /// 计算公式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<InstFormulaDto> ExportList(InstFormulaQueryDto parm);
    }
}
