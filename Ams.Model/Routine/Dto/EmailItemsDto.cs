namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 邮件发送记录查询对象
    /// </summary>
    public class EmailItemsQueryDto : PagerInfo
    {
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public int? IsSend { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
    }

    /// <summary>
    /// 邮件发送记录输入输出对象
    /// </summary>
    public class EmailItemsDto
    {
        //[Required(ErrorMessage = "Id不能为空")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        public string FromEmail { get; set; }

        public string Subject { get; set; }

        public string ToEmails { get; set; }

        public string EmailContent { get; set; }

        /// <summary>
        /// 是否已发送
        /// </summary>
        public int IsSend { get; set; }

        /// <summary>
        /// 发送结果
        /// </summary>
        public string SendResult { get; set; }

        public long[] IdArr { get; set; }
        public string FromName { get; set; }
    }
}