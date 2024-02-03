using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 部门消耗
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 14:46:50)
    /// </summary>
    public interface IDeptConsumingService : IBaseService<DeptConsuming>
    {
        /// <summary>
        /// 列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<DeptConsumingDto> GetList(DeptConsumingQueryDto parm);

        /// <summary>
        /// 详情
        /// </summary>
        /// <param name="DcSFID"></param>
        /// <returns></returns>
        DeptConsuming GetInfo(long DcSFID);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckEntryUnique(string enterString);


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        DeptConsuming AddDeptConsuming(DeptConsuming parm);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateDeptConsuming(DeptConsuming parm);

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportDeptConsuming(List<DeptConsuming> list);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<DeptConsumingDto> ExportList(DeptConsumingQueryDto parm);
    }
}
