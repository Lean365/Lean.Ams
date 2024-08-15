namespace Ams.Service.Kernel.IKernelService
{
    public interface ISysPostService : IBaseService<SysPost>
    {
        string CheckPostNameUnique(SysPost sysPost);

        string CheckPostCodeUnique(SysPost sysPost);

        List<SysPost> GetAll();
    }
}