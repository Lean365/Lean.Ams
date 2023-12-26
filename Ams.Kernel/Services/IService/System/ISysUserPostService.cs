using Ams.Kernel.Model.System;

namespace Ams.Kernel.Services.IService.System
{
    public interface ISysUserPostService
    {
        public void InsertUserPost(SysUser user);

        public List<long> GetUserPostsByUserId(long userId);

        public string GetPostsStrByUserId(long userId);
        bool Delete(long userId);
    }
}
