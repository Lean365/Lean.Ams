using Ams.Model.Kernel;

namespace Ams.Service.IService.Kernel
{
    public interface ISysUserPostService
    {
        public void InsertUserPost(SysUser user);

        public List<long> GetUserPostsByUserId(long userId);

        public string GetPostsStrByUserId(long userId);

        bool Delete(long userId);
    }
}