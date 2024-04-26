namespace Ams.Kernel.Model.Dto.Routine
{
    /// <summary>
    /// 已发邮件
    /// 查询对象
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SentItemsQueryDto : PagerInfo
    {
        /// <summary>
        /// 发送邮箱
        /// </summary>
        public string FromEmail { get; set; }

        /// <summary>
        /// 邮件主题
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 是否已发送
        /// </summary>
        public int? IsSend { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
    }

    /// <summary>
    /// 已发邮件
    /// 输入输出对象
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SentItemsDto
    {
        /// <summary>
        /// ID
        /// </summary>
        //[Required(ErrorMessage = "Id不能为空")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

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
        public string ToEmails { get; set; }

        /// <summary>
        /// 邮件内容
        /// </summary>
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
        /// ID数组，批量
        /// </summary>
        public long[] IdArr { get; set; }

        /// <summary>
        /// 发送人名称
        /// </summary>
        public string FromName { get; set; }
    }
}