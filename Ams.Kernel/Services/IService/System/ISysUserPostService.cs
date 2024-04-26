namespace Ams.Kernel.Services.IService.System
{
    /// <summary>
    /// 用户岗位信息
    /// 业务层接口
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public interface ISysUserPostService
    {
        public void InsertUserPost(SysUser user);

        public List<long> GetUserPostsByUserId(long userId);

        public string GetPostsStrByUserId(long userId);

        bool Delete(long userId);
    }
}