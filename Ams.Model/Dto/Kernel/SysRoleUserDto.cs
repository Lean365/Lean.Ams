namespace Ams.Model.Dto.Kernel
{
    /// <summary>
    /// 角色用户查询条件
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public class RoleUserQueryDto : PagerInfo
    {
        public long RoleId { get; set; }

        public string UserName { get; set; }
    }

    /// <summary>
    /// 角色用户创建
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public class RoleUsersCreateDto
    {
        /// <summary>
        /// 角色id
        /// </summary>
        [Display(Name = "角色id")]
        [Required(ErrorMessage = "roleId 不能为空")]
        public long RoleId { get; set; }

        /// <summary>
        /// 用户编码 [1,2,3,4]
        /// </summary>
        [Display(Name = "用户编码 [1,2,3,4]")]
        public List<long> UserIds { get; set; }
    }
}