namespace Ams.Service.Admin.IAdminService
{
    /// <summary>
    /// 本地语言
    /// 业务层处理
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/29 13:30:50
    /// </summary>
    public interface ISysLocaleLangService : IBaseService<SysLocaleLang>
    {
        PagedInfo<SysLocaleLang> GetList(SysLocaleLangQueryDto parm);

        List<SysLocaleLang> GetLangList(SysLocaleLangQueryDto parm);

        dynamic GetListToPivot(SysLocaleLangQueryDto parm);

        void StorageSysLocaleLang(SysLocaleLangDto parm);

        Dictionary<string, object> SetLang(List<SysLocaleLang> msgList);

        (string, object, object) ImportSysLocaleLang(List<SysLocaleLang> list);
    }
}