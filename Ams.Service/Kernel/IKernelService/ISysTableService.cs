using Ams.Model.Kernel.Dto;
using Ams.Model.Kernel;

namespace Ams.Service.Kernel.IKernelService
{
    /// <summary>
    /// 表名称
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 10:27:13
    /// </summary>
    public interface ISysTableService : IBaseService<SysTable>
    {
        /// <summary>
        /// 获取表名称列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SysTableDto> GetList(SysTableQueryDto parm);

        /// <summary>
        /// 获取表名称信息
        /// </summary>
        /// <param name="TbId"></param>
        /// <returns></returns>
        SysTable GetInfo(long TbId);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 表名称
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        SysTable AddSysTable(SysTable parm);

        /// <summary>
        /// 更新
        /// 表名称
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateSysTable(SysTable parm);


        /// <summary>
        /// 批量导入
        /// 表名称
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportSysTable(List<SysTable> list);

        /// <summary>
        /// 导出
        /// 表名称
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SysTableDto> ExportList(SysTableQueryDto parm);
    }
}
