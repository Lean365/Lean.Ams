using System.ComponentModel.DataAnnotations;
using Ams.Model;

namespace Ams.Kernel.Model.Dto.System
{
    /// <summary>
    /// 角色用户
    /// 查询条件
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SysRoleUserQueryDto : PagerInfo
    {
        public long RoleId { get; set; }

        public string UserName { get; set; }
    }

    /// <summary>
    /// 角色用户
    /// 创建对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SysRoleUsersCreateDto
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