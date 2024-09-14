using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 部门消耗
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:51:22
    /// </summary>
    public interface IFicoCostingDeptConsumingService : IBaseService<FicoCostingDeptConsuming>
    {
        /// <summary>
        /// 获取部门消耗列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoCostingDeptConsumingDto> GetList(FicoCostingDeptConsumingQueryDto parm);

        /// <summary>
        /// 获取部门消耗信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        FicoCostingDeptConsuming GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 部门消耗
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        FicoCostingDeptConsuming AddFicoCostingDeptConsuming(FicoCostingDeptConsuming parm);

        /// <summary>
        /// 更新
        /// 部门消耗
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateFicoCostingDeptConsuming(FicoCostingDeptConsuming parm);


        /// <summary>
        /// 批量导入
        /// 部门消耗
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoCostingDeptConsuming(List<FicoCostingDeptConsuming> list);

        /// <summary>
        /// 导出
        /// 部门消耗
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoCostingDeptConsumingDto> ExportList(FicoCostingDeptConsumingQueryDto parm);
    }
}
