using Ams.Model.Admin;

namespace Ams.Service.Admin.IAdminService
{
    public interface ISysPostService : IBaseService<SysPost>
    {
        string CheckPostNameUnique(SysPost sysPost);
        string CheckPostCodeUnique(SysPost sysPost);
        List<SysPost> GetAll();
    }
}
