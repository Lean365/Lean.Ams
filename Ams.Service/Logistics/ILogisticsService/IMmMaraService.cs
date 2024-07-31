using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 常规物料
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:37:36
    /// </summary>
    public interface IMmMaraService : IBaseService<MmMara>
    {
        /// <summary>
        /// 获取常规物料列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmMaraDto> GetList(MmMaraQueryDto parm);

        /// <summary>
        /// 获取常规物料信息
        /// </summary>
        /// <param name="SfId"></param>
        /// <returns></returns>
        MmMara GetInfo(long SfId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 常规物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        MmMara AddMmMara(MmMara parm);

        /// <summary>
        /// 更新
        /// 常规物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateMmMara(MmMara parm);


        /// <summary>
        /// 批量导入
        /// 常规物料
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportMmMara(List<MmMara> list);

        /// <summary>
        /// 导出
        /// 常规物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmMaraDto> ExportList(MmMaraQueryDto parm);
    }
}
