namespace Ams.Service.Kernel.IKernelService
{
    /// <summary>
    /// 本地语言service接口
    ///
    /// @author Lean365(Davis.Ching)
    /// @date 2024-05-20
    /// </summary>
    public interface ISysLocaleLangService : IBaseService<SysLocaleLang>
    {
        PagedInfo<SysLocaleLang> GetList(SysLocaleLangQueryDto parm);

        List<SysLocaleLang> GetLangList(SysLocaleLangQueryDto parm);

        dynamic GetListToPivot(SysLocaleLangQueryDto parm);

        void StorageCommonLang(SysLocaleLangDto parm);

        Dictionary<string, object> SetLang(List<SysLocaleLang> msgList);

        (string, object, object) ImportCommonLang(List<SysLocaleLang> list);
    }
}