using Ams.Model.Kernel;

namespace Ams.Model.Dto.Kernel
{
    /// <summary>
    /// 系统岗位
    /// 查询条件
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public class SysPostQueryDto : PagerInfo
    {
        public string PostName { get; set; }
        public int IsStatus { get; set; }
        public string PostCode { get; set; }
        public string PostLevel { get; set; }
    }

    /// <summary>
    /// 系统岗位
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public class SysPostDto : SysPost
    {
        /// <summary>
        /// 用户个数
        /// </summary>
        public long UserNum { get; set; }
    }
}