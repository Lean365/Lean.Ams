using Ams.Kernel.Model.System;

namespace Ams.Kernel.Services.IService.System
{
    /// <summary>
    /// 用户岗位
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    public interface ISysUserPostService
    {
        public void InsertUserPost(SysUser user);

        public List<long> GetUserPostsByUserId(long userId);

        public string GetPostsStrByUserId(long userId);

        bool Delete(long userId);
    }
}