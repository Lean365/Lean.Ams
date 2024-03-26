using System.ComponentModel.DataAnnotations;

namespace Ams.Kernel.Model.Dto.System
{
    /// <summary>
    /// 手机登录
    /// 输入输出对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    public class PhoneLoginDto
    {
        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 唯一标识
        /// </summary>
        public string Uuid { get; set; } = "";

        public string LoginIP { get; set; }

        [Required(ErrorMessage = "手机号不能为空")]
        public string PhoneNum { get; set; }

        /// <summary>
        /// 手机短信验证码
        /// </summary>
        //[Required(ErrorMessage = "短信验证码不能为空")]
        public string PhoneCode { get; set; }
    }
}