namespace Ams.Model.Monitor
{
    /// <summary>
    /// 短信验证
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("monitor_sms", tableDescription: "短信验证")]
    [Tenant("0")]
    public class SmsLog : SysBase
    {
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true)]
        public long Id { get; set; }

        /// <summary>
        /// 短信验证码
        /// </summary>
        [SugarColumn(Length = 10)]
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
        [SugarColumn(Length = 200)]
        public string SmsContent { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        [SugarColumn(InsertServerTime = true)]
        public DateTime SendTime { get; set; }

        /// <summary>
        /// 用户IP
        /// </summary>
        [SugarColumn(Length = 20)]
        public string UserIP { get; set; }

        /// <summary>
        /// 地理位置
        /// </summary>
        [SugarColumn(Length = 200)]
        public string Location { get; set; }

        /// <summary>
        /// 1、登录 2、注册 3、找回密码
        /// </summary>
        public int SendType { get; set; }
    }
}