using Ams.Model;

namespace Ams.Kernel.Model.Dto.Login
{
    /// <summary>
    /// 登录日志
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SysLoginQueryDto : PagerInfo
    {
        public string Status { get; set; }
        public long? UserId { get; set; }
        public string Ipaddr { get; set; } = string.Empty;
        public string UserName { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
    }

    /// <summary>
    /// 登录日志
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SysLoginDto : SysBase
    {
        public int PageNum { get; set; }

        /// <summary>
        /// IP 地址
        /// </summary>
        public string Ipaddr { get; set; }

        /// <summary>
        /// 登录状态 0成功 1失败
        /// </summary>
        public int IsStated { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
    }
}