using Ams.Model;
using Ams.Model.Admin;

namespace Ams.Model.Admin.Dto
{
    public class SysPostDto : SysPost
    {
        /// <summary>
        /// 用户个数
        /// </summary>
        public long UserNum { get; set; }
    }

    public class SysPostQueryDto : PagerInfo
    {
        public string PostName { get; set; }
        public int IsStatus { get; set; }
        public string PostCode { get; set; }
    }
}