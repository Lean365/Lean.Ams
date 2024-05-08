namespace Ams.Kernel.Model.Dto.System
{
    /// <summary>
    /// 用户信息
    /// 查询条件
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SysUserQueryDto
    {
        public long? UserId { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
        public string Phonenumber { get; set; }

        /// <summary>
        /// 用户性别（0男 1女 2未知）
        /// </summary>
        public int Sex { get; set; }

        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int IsStated { get; set; }
        public long DeptId { get; set; }
    }

    /// <summary>
    /// 用户信息
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SysUserDto
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
        public string Phonenumber { get; set; }
        public string Avatar { get; set; }

        /// <summary>
        /// 用户性别（0男 1女 2未知）
        /// </summary>
        public int Sex { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// 帐号状态（0正常 1停用）
        /// </summary>
        public int IsStated { get; set; }

        /// <summary>
        /// 最后登录IP
        /// </summary>
        public string LoginIP { get; set; }

        /// <summary>
        /// 部门Id
        /// </summary>
        public long DeptId { get; set; }

        /// <summary>
        /// 角色id集合
        /// </summary>
        public long[] RoleIds { get; set; }

        /// <summary>
        /// 岗位集合
        /// </summary>
        public int[] PostIds { get; set; }

        public string WelcomeContent { get; set; }
        public string WelcomeMessage { get; set; }
        public bool IsAdmin { get; set; }
    }
}