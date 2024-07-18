using Ams.Model.Accounting.Dto;
using Ams.Model.Accounting;

namespace Ams.Service.Accounting.IAccountingService
{
    /// <summary>
    /// 部门消耗
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:47:09
    /// </summary>
    public interface IFicoDeptConsumingService : IBaseService<FicoDeptConsuming>
    {
        /// <summary>
        /// 获取部门消耗列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoDeptConsumingDto> GetList(FicoDeptConsumingQueryDto parm);

        /// <summary>
        /// 获取部门消耗信息
        /// </summary>
        /// <param name="DcSFID"></param>
        /// <returns></returns>
        FicoDeptConsuming GetInfo(long DcSFID);


        /// <summary>
        /// 批量导入
        /// 部门消耗
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportFicoDeptConsuming(List<FicoDeptConsuming> list);

        /// <summary>
        /// 导出
        /// 部门消耗
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<FicoDeptConsumingDto> ExportList(FicoDeptConsumingQueryDto parm);
    }
}
