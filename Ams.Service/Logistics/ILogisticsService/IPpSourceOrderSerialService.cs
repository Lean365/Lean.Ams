using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 源订单序列号
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:43:48
    /// </summary>
    public interface IPpSourceOrderSerialService : IBaseService<PpSourceOrderSerial>
    {
        /// <summary>
        /// 获取源订单序列号列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpSourceOrderSerialDto> GetList(PpSourceOrderSerialQueryDto parm);

        /// <summary>
        /// 获取源订单序列号信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpSourceOrderSerial GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 源订单序列号
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpSourceOrderSerial AddPpSourceOrderSerial(PpSourceOrderSerial parm);

        /// <summary>
        /// 更新
        /// 源订单序列号
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpSourceOrderSerial(PpSourceOrderSerial parm);


        /// <summary>
        /// 批量导入
        /// 源订单序列号
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpSourceOrderSerial(List<PpSourceOrderSerial> list);

        /// <summary>
        /// 导出
        /// 源订单序列号
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpSourceOrderSerialDto> ExportList(PpSourceOrderSerialQueryDto parm);
    }
}
