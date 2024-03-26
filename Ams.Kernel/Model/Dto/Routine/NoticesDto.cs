using System.ComponentModel.DataAnnotations;
using Ams.Model;

namespace Ams.Kernel.Model.Dto.Routine
{
    /// <summary>
    /// 通知公告
    /// 输入输出对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// </summary>
    public class NoticesDto
    {
        public int NoticeId { get; set; }

        [Required]
        public string NoticeTitle { get; set; }

        public int NoticeType { get; set; }
        public string NoticeContent { get; set; }
        public string NoticeFileurl { get; set; }
        public int IsState { get; set; }
        public string Remark { get; set; }
    }

    /// <summary>
    /// 通知公告表
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// </summary>
    public class NoticesQueryDto : PagerInfo
    {
        public string NoticeTitle { get; set; }
        public int? NoticeType { get; set; }
        public string CreateBy { get; set; }
        public int? IsState { get; set; }
    }
}