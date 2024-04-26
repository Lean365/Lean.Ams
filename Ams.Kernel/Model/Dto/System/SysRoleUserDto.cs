using System.ComponentModel.DataAnnotations;

namespace Ams.Kernel.Model.Dto.System
{
    public class SysRoleUserQueryDto : PagerInfo
    {
        public long RoleId { get; set; }

        public string UserName { get; set; }
    }

    public class SysRoleUsersCreateDto
    {
        /// <summary>
        /// 角色信息id
        /// </summary>
        [Display(Name = "角色信息id")]
        [Required(ErrorMessage = "roleId 不能为空")]
        public long RoleId { get; set; }

        /// <summary>
        /// 用户编码 [1,2,3,4]
        /// </summary>
        [Display(Name = "用户编码 [1,2,3,4]")]
        public List<long> UserIds { get; set; }
    }
}