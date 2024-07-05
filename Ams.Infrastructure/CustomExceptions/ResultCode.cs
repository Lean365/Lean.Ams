using System.ComponentModel;

namespace Ams.Infrastructure.CustomExceptions
{
    /// <summary>
    /// 系统错误码枚举
    /// 200-成功，210-没有更多数据，101-参数错误，103-验证码错误，105-登录错误，1-操作失败，500-服务端出错啦，
    /// 110-自定义异常，116-非法请求，201-授权失败，202-请先绑定手机号，401-未授权，403-授权访问失败，400-Bad Request
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public enum ResultCode
    {
        [Description("success")]
        SUCCESS = 200,

        [Description("没有更多数据")]
        NO_DATA = 210,

        [Description("参数错误")]
        PARAM_ERROR = 101,

        [Description("验证码错误")]
        CAPTCHA_ERROR = 103,

        [Description("登录错误")]
        LOGIN_ERROR = 105,

        [Description("操作失败")]
        FAIL = 1,

        [Description("服务端出错啦")]
        GLOBAL_ERROR = 500,

        [Description("自定义异常")]
        CUSTOM_ERROR = 110,

        [Description("非法请求")]
        INVALID_REQUEST = 116,

        [Description("授权失败")]
        OAUTH_FAIL = 201,

        [Description("请先绑定手机号")]
        PHONE_BIND = 202,

        [Description("未授权")]
        DENY = 401,

        [Description("授权访问失败")]
        FORBIDDEN = 403,

        [Description("Bad Request")]
        BAD_REQUEST = 400
    }
}