using Ams.Model;
using Ams.Model.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// oph从表
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/28 15:35:46
    /// </summary>
    public interface IPpOutputSlaveService : IBaseService<PpOutputSlave>
    {
        /// <summary>
        /// 获取oph从表列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputSlaveDto> GetList(PpOutputSlaveQueryDto parm);

        /// <summary>
        /// 获取oph从表信息
        /// </summary>
        /// <param name="PosSfid"></param>
        /// <returns></returns>
        PpOutputSlave GetInfo(long PosSfid);

        /// <summary>
        /// 校验输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);


        /// <summary>
        /// 新增
        /// oph从表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpOutputSlave AddPpOutputSlave(PpOutputSlave parm);
        /// <summary>
        /// 更新
        /// oph从表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpOutputSlave(PpOutputSlave parm);

        /// <summary>
        /// 批量导入
        /// oph从表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpOutputSlave(List<PpOutputSlave> list);

        /// <summary>
        /// 导出
        /// oph从表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputSlaveDto> ExportList(PpOutputSlaveQueryDto parm);
    }
}
