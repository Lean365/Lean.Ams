using System.ComponentModel.DataAnnotations;

namespace Ams.Model.System.Dto
{
    /// <summary>
    /// 用户注册
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class RegisterDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        public string Username { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }

        [Required(ErrorMessage = "确认密码不能为空")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 唯一标识
        /// </summary>
        public string Uuid { get; set; } = "";

        /// <summary>
        /// 头像
        /// </summary>
        public string Photo { get; set; }

        public string UserIP { get; set; }
    }
}