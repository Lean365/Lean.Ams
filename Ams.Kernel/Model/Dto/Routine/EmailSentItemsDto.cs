using Ams.Model;

namespace Ams.Kernel.Model.Dto.Routine
{
    /// <summary>
    /// 邮件发送记录
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class EmailSentItemsQueryDto : PagerInfo
    {
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public int? IsSend { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
    }

    /// <summary>
    /// 邮件发送记录
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class EmailSentItemsDto
    {
        //[Required(ErrorMessage = "Id不能为空")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        public string FromEmail { get; set; }

        public string Subject { get; set; }

        public string ToEmails { get; set; }

        public string EmailContent { get; set; }

        public DateTime? createTime { get; set; }

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