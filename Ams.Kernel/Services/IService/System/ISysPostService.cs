namespace Ams.Kernel.Services.IService.System
{
    /// <summary>
    /// 岗位信息
    /// 业务层接口
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public interface ISysPostService : IBaseService<SysPost>
    {
        string CheckPostNameUnique(SysPost sysPost);

        string CheckPostCodeUnique(SysPost sysPost);

        List<SysPost> GetAll();
    }
}