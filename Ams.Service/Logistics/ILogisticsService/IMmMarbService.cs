using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 物料信息
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:22:47
    /// </summary>
    public interface IMmMarbService : IBaseService<MmMarb>
    {
        /// <summary>
        /// 获取物料信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmMarbDto> GetList(MmMarbQueryDto parm);

        /// <summary>
        /// 获取物料信息信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        MmMarb GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 物料信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        MmMarb AddMmMarb(MmMarb parm);

        /// <summary>
        /// 更新
        /// 物料信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateMmMarb(MmMarb parm);


        /// <summary>
        /// 批量导入
        /// 物料信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportMmMarb(List<MmMarb> list);

        /// <summary>
        /// 导出
        /// 物料信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmMarbDto> ExportList(MmMarbQueryDto parm);
    }
}
