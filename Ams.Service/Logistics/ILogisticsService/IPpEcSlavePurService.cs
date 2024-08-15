using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// Pur设变
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 14:43:11
    /// </summary>
    public interface IPpEcSlavePurService : IBaseService<PpEcSlavePur>
    {
        /// <summary>
        /// 获取Pur设变列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlavePurDto> GetList(PpEcSlavePurQueryDto parm);

        /// <summary>
        /// 获取Pur设变信息
        /// </summary>
        /// <param name="PurSfId"></param>
        /// <returns></returns>
        PpEcSlavePur GetInfo(long PurSfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// Pur设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpEcSlavePur AddPpEcSlavePur(PpEcSlavePur parm);

        /// <summary>
        /// 更新
        /// Pur设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpEcSlavePur(PpEcSlavePur parm);


        /// <summary>
        /// 批量导入
        /// Pur设变
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpEcSlavePur(List<PpEcSlavePur> list);

        /// <summary>
        /// 导出
        /// Pur设变
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpEcSlavePurDto> ExportList(PpEcSlavePurQueryDto parm);
    }
}
