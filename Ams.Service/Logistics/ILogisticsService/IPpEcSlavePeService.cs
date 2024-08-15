using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// Pe设变
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:39:48
    /// </summary>
    public interface IPpEcSlavePeService : IBaseService<PpEcSlavePe>
    {
        /// <summary>
        /// 获取Pe设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlavePeDto> GetList(PpEcSlavePeQueryDto parm);

        /// <summary>
        /// 获取Pe设变信息
        /// </summary>
        /// <param name="PeSfId"></param>
        /// <returns></returns>
        PpEcSlavePe GetInfo(long PeSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// Pe设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcSlavePe AddPpEcSlavePe(PpEcSlavePe parm);

        /// <summary>
        /// 更新
        /// Pe设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcSlavePe(PpEcSlavePe parm);


        /// <summary>
        /// 批量导入
        /// Pe设变
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcSlavePe(List<PpEcSlavePe> list);

        /// <summary>
        /// 导出
        /// Pe设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlavePeDto> ExportList(PpEcSlavePeQueryDto parm);
    }
}
