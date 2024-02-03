using Ams.Model;
using Ams.Kernel.Model.Dto.System;
using Ams.Kernel.Model.System;

namespace Ams.Kernel.Services.IService.System
{
    /// <summary>
    /// 多语言配置service接口
    ///
    /// @author Lean365(Davis.Cheng)
    /// @date 2022-05-06
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
