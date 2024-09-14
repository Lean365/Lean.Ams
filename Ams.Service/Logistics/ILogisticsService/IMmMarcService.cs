using Ams.Model.Logistics.Dto;
using Ams.Model.Logistics;

namespace Ams.Service.Logistics.ILogisticsService
{
    /// <summary>
    /// 工厂物料
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:30:16
    /// </summary>
    public interface IMmMarcService : IBaseService<MmMarc>
    {
        /// <summary>
        /// 获取工厂物料列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmMarcDto> GetList(MmMarcQueryDto parm);

        /// <summary>
        /// 获取工厂物料信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        MmMarc GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 工厂物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        MmMarc AddMmMarc(MmMarc parm);

        /// <summary>
        /// 更新
        /// 工厂物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateMmMarc(MmMarc parm);


        /// <summary>
        /// 批量导入
        /// 工厂物料
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportMmMarc(List<MmMarc> list);

        /// <summary>
        /// 导出
        /// 工厂物料
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<MmMarcDto> ExportList(MmMarcQueryDto parm);
    }
}
