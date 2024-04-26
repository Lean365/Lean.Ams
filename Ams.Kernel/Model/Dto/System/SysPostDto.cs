using Ams.Kernel.Model.System;
using Ams.Model;

namespace Ams.Kernel.Model.Dto.System
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
        public int IsStated { get; set; }
        public string PostCode { get; set; }
    }
}
