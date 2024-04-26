namespace Ams.Kernel.Model
{
    /// <summary>
    /// 已发邮件
    /// 数据实体类：routine_email_items
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [SugarTable("routine_sent_items", "已发邮件")]
    [Tenant("0")]
    public class SentItems : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 发送人名称
        /// </summary>
        public string FromName { get; set; }

        /// <summary>
        /// 发送邮箱
        /// </summary>
        public string FromEmail { get; set; }

        /// <summary>
        /// 邮件主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 接收邮箱
        /// </summary>
        [SugarColumn(ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string ToEmails { get; set; }

        /// <summary>
        /// 邮件内容
        /// </summary>
        [SugarColumn(ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string EmailContent { get; set; }

        /// <summary>
        /// 是否已发送
        /// </summary>
        public int IsSend { get; set; }

        /// <summary>
        /// 发送结果
        /// </summary>
        public string SendResult { get; set; }

        /// <summary>
        /// 附件地址
        /// </summary>
        public string FileUrl { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        public DateTime SendTime { get; set; }
    }
}