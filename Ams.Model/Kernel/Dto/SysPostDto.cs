using Ams.Model.Kernel;

namespace Ams.Model.Kernel.Dto
{
    public class SysPostQueryDto : PagerInfo
    {
        public string PostName { get; set; }
        public int IsStatus { get; set; }
        public string PostCode { get; set; }
        public string PostLevel { get; set; }
    }

    public class SysPostDto : SysPost
    {
        /// <summary>
        /// 用户个数
        /// </summary>
        public long UserNum { get; set; }
    }
}