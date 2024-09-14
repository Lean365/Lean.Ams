using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// PCBA明细
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:35
    /// </summary>
    public interface IPpOutputPcbaSlvService : IBaseService<PpOutputPcbaSlv>
    {
        /// <summary>
        /// 获取PCBA明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputPcbaSlvDto> GetList(PpOutputPcbaSlvQueryDto parm);

        /// <summary>
        /// 获取PCBA明细信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PpOutputPcbaSlv GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// PCBA明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PpOutputPcbaSlv AddPpOutputPcbaSlv(PpOutputPcbaSlv parm);

        /// <summary>
        /// 更新
        /// PCBA明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdatePpOutputPcbaSlv(PpOutputPcbaSlv parm);


        /// <summary>
        /// 批量导入
        /// PCBA明细
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportPpOutputPcbaSlv(List<PpOutputPcbaSlv> list);

        /// <summary>
        /// 导出
        /// PCBA明细
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<PpOutputPcbaSlvDto> ExportList(PpOutputPcbaSlvQueryDto parm);
    }
}
