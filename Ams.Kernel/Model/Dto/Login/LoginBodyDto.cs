using System.ComponentModel.DataAnnotations;

namespace Ams.Kernel.Model.Dto.Login
{
    /// <summary>
    /// 登录参数
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class LoginBodyDto
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

        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 唯一标识
        /// </summary>
        public string Uuid { get; set; } = "";

        public string LoginIP { get; set; }
        public string ClientId { get; set; }
    }
}