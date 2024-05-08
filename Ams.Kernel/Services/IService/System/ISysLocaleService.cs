using Ams.Model;

namespace Ams.Kernel.Services.IService.System
{
    /// <summary>
    /// 本地语言service接口
    ///
    /// @author zr
    /// @date 2022-05-06
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