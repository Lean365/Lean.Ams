using Ams.Model;

namespace Ams.Kernel.Model.Dto.System
{
    /// <summary>
    /// 系统岗位
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SysPostQueryDto : PagerInfo
    {
        public string PostName { get; set; }
        public int IsStated { get; set; }
        public string PostCode { get; set; }
    }

    /// <summary>
    /// 系统岗位
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SysPostDto : SysPost
    {
        /// <summary>
        /// 用户个数
        /// </summary>
        public long UserNum { get; set; }
    }
}