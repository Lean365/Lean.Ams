using Ams.Model.Admin.Dto;
using Ams.Model.Admin;

namespace Ams.Service.Admin.IAdminService
{
    /// <summary>
    /// 表名称
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/4 16:50:06
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
        /// <param name="Id"></param>
        /// <returns></returns>
        SysTable GetInfo(long Id);
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
