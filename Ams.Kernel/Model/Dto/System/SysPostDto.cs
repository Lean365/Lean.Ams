using Ams.Kernel.Model.System;
using Ams.Model;

namespace Ams.Kernel.Model.Dto.System
{
    /// <summary>
    /// 系统岗位
    /// 输入输出对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    public class SysPostDto : SysPost
    {
        /// <summary>
        /// 用户个数
        /// </summary>
        public long UserNum { get; set; }
    }

    /// <summary>
    /// 系统岗位
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)

    public class SysPostQueryDto : PagerInfo
    {
        public string PostName { get; set; }
        public int IsState { get; set; }
        public string PostCode { get; set; }
    }
}