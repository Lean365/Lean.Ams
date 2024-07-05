namespace Ams.Service.IService.Kernel
{
    /// <summary>
    /// 系统岗位
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public interface ISysPostService : IBaseService<SysPost>
    {
        string CheckPostNameUnique(SysPost sysPost);

        string CheckPostCodeUnique(SysPost sysPost);

        List<SysPost> GetAll();
    }
}