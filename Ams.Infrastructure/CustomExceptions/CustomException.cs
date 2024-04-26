using System;

namespace Ams.Infrastructure.CustomExceptions
{
    /// <summary>
    /// 自定义异常
    /// @Author Lean365(Davis.Ching)
    /// @Date 2004-02-01
    /// </summary>
    public class CustomException : Exception
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 前端提示语
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 记录到日志的详细内容
        /// </summary>
        public string LogMsg { get; set; }

        /// <summary>
        /// 是否通知
        /// </summary>
        public bool Notice { get; set; } = true;

        /// <summary>
        /// 自定义异常
        /// </summary>
        /// <param name="msg"></param>
        public CustomException(string msg) : base(msg)
        {
        }

        /// <summary>
        /// 自定义异常
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        public CustomException(int code, string msg) : base(msg)
        {
            Code = code;
            Msg = msg;
        }

        /// <summary>
        /// 自定义异常
        /// </summary>
        /// <param name="resultCode"></param>
        /// <param name="msg"></param>
        /// <param name="notice"></param>
        public CustomException(ResultCode resultCode, string msg, bool notice = true) : base(msg)
        {
            Code = (int)resultCode;
            Notice = notice;
        }

        /// <summary>
        /// 自定义异常
        /// </summary>
        /// <param name="resultCode"></param>
        /// <param name="msg"></param>
        /// <param name="errorMsg">用于记录详细日志到输出介质</param>
        public CustomException(ResultCode resultCode, string msg, object errorMsg) : base(msg)
        {
            Code = (int)resultCode;
            LogMsg = errorMsg.ToString();
        }
    }
}