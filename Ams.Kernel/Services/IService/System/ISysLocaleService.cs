namespace Ams.Kernel.Services.IService.System
{
    /// <summary>
    /// 本地语言
    /// 业务层接口
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public interface ISysLocaleService : IBaseService<SysLocale>
    {
        PagedInfo<SysLocale> GetList(SysLocaleQueryDto parm);

        List<SysLocale> GetLangList(SysLocaleQueryDto parm);

        dynamic GetListToPivot(SysLocaleQueryDto parm);

        void StorageSysLocale(SysLocaleDto parm);

        Dictionary<string, object> SetLang(List<SysLocale> msgList);

        (string, object, object) ImportSysLocale(List<SysLocale> list);
    }
}