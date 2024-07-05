namespace Ams.Model.Dto.Login
{
    /// <summary>
    /// 手机登录DTO
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
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

        /// <summary>
        /// 0、登录 1、绑定
        /// </summary>
        public int SendType { get; set; }
    }
}