using Ams.Model;
using Ams.Model.Dto.Kernel;
using Ams.Model.Kernel;

namespace Ams.Service.IService.Kernel
{
    /// <summary>
    /// 本地语言service接口
    ///
    /// @author zr
    /// @date 2022-05-06
    /// </summary>
    public interface ISysLocaleLangService : IBaseService<SysLocaleLang>
    {
        PagedInfo<SysLocaleLang> GetList(CommonLangQueryDto parm);

        List<SysLocaleLang> GetLangList(CommonLangQueryDto parm);

        dynamic GetListToPivot(CommonLangQueryDto parm);

        void StorageCommonLang(SysLocaleLangDto parm);

        Dictionary<string, object> SetLang(List<SysLocaleLang> msgList);

        (string, object, object) ImportCommonLang(List<SysLocaleLang> list);
    }
}