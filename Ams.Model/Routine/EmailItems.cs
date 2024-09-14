namespace Ams.Model.Routine
{
    /// <summary>
    /// 邮件记录
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("routine_email_items", TableDescription = "邮件记录")]
    [Tenant("0")]
    public class EmailItems : SysBase
    {
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 发件人
        /// </summary>
        [SugarColumn(ColumnName = "FromName", ColumnDescription = "发件人", Length = 40)]
        public string FromName { get; set; }

        /// <summary>
        /// 发送邮箱
        /// </summary>
        [SugarColumn(ColumnName = "FromEmail", ColumnDescription = "发件人", Length = 100)]
        public string FromEmail { get; set; }

        /// <summary>
        /// 邮件主题
        /// </summary>
        [SugarColumn(ColumnName = "Subject", ColumnDescription = "邮件主题", Length = 200)]
        public string Subject { get; set; }

        /// <summary>
        /// 收件人
        /// </summary>
        [SugarColumn(ColumnName = "ToEmails", ColumnDescription = "收件人", ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string ToEmails { get; set; }

        /// <summary>
        /// 邮件内容
        /// </summary>
        [SugarColumn(ColumnName = "EmailContent", ColumnDescription = "邮件内容", ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string EmailContent { get; set; }

        /// <summary>
        /// 发送状态
        /// </summary>
        [SugarColumn(ColumnName = "IsSend", ColumnDescription = "发送状态", DefaultValue = "0")]
        public int IsSend { get; set; }

        /// <summary>
        /// 发送结果
        /// </summary>
        [SugarColumn(ColumnName = "SendResult", ColumnDescription = "发送结果", Length = 200)]
        public string SendResult { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        [SugarColumn(ColumnName = "FileUrl", ColumnDescription = "附件", Length = 500)]
        public string FileUrl { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        [SugarColumn(ColumnName = "SendTime", ColumnDescription = "发送时间")]
        public DateTime SendTime { get; set; } = DateTime.Now;
    }
}