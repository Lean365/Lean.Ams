namespace Ams.Service.Kernel.IKernelService
{
    public interface ISysUserPostService
    {
        public void InsertUserPost(SysUser user);

        public List<long> GetUserPostsByUserId(long userId);

        public string GetPostsStrByUserId(long userId);

        bool Delete(long userId);
    }
}