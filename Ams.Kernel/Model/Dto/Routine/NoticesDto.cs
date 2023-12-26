using System.ComponentModel.DataAnnotations;
using Ams.Model;
namespace Ams.Kernel.Model.Dto.Routine
{
    /// <summary>
    /// 通知公告表输入对象
    /// </summary>
    public class NoticesDto
    {
        public int NoticeId { get; set; }
        [Required]
        public string NoticeTitle { get; set; }
        public int NoticeType { get; set; }
        public string NoticeContent { get; set; }
        public int IsState { get; set; }
        public string Remark { get; set; }
    }

    /// <summary>
    /// 通知公告表查询对象
    /// </summary>
    public class NoticesQueryDto : PagerInfo
    {
        public string NoticeTitle { get; set; }
        public int? NoticeType { get; set; }
        public string CreateBy { get; set; }
        public int? IsState { get; set; }
    }
}
