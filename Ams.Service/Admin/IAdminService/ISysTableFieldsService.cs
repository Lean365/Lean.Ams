using Ams.Model.Admin.Dto;
using Ams.Model.Admin;

namespace Ams.Service.Admin.IAdminService
{
    /// <summary>
    /// 表字段
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/4 16:50:01
    /// </summary>
    public interface ISysTableFieldsService : IBaseService<SysTableFields>
    {
        /// <summary>
        /// 获取表字段列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SysTableFieldsDto> GetList(SysTableFieldsQueryDto parm);

        /// <summary>
        /// 获取表字段信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        SysTableFields GetInfo(long Id);
        /// <summary>
        /// 校验
        /// 输入项目唯一性
        /// </summary>
        /// <param name="enterString"></param>
        /// <returns></returns>
        public string CheckInputUnique(string enterString);
        /// <summary>
        /// 新增
        /// 表字段
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        SysTableFields AddSysTableFields(SysTableFields parm);

        /// <summary>
        /// 更新
        /// 表字段
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        int UpdateSysTableFields(SysTableFields parm);


        /// <summary>
        /// 批量导入
        /// 表字段
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        (string, object, object) ImportSysTableFields(List<SysTableFields> list);

        /// <summary>
        /// 导出
        /// 表字段
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        PagedInfo<SysTableFieldsDto> ExportList(SysTableFieldsQueryDto parm);
    }
}
