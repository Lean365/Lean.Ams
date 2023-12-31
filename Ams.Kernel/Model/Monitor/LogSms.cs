﻿namespace Ams.Kernel.Model.Monitor
{
    /// <summary>
    /// 短信验证码记录
    /// </summary>
    [SugarTable("log_sms")]
    public class LogSms:SysBase
    {
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true)]
        public long Id { get; set; }
        /// <summary>
        /// 短信验证码
        /// </summary>
        public string SmsCode { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public long Userid { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public long PhoneNum { get; set; }
        /// <summary>
        /// 短信内容
        /// </summary>
        public string SmsContent { get; set; }

        /// <summary>
        /// 用户IP
        /// </summary>
        public string UserIP { get; set; }
        /// <summary>
        /// 地理位置
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 1、登录 2、注册 3、找回密码
        /// </summary>
        public int SendType { get; set; }
    }
}
