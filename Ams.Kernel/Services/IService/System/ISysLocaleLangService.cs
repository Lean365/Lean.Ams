using Ams.Kernel.Model.Dto.System;
using Ams.Kernel.Model.System;
using Ams.Model;

namespace Ams.Kernel.Services.IService.System
{
    /// <summary>
    /// 本地语言
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
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