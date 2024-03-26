namespace Ams.Kernel.Model.Dto.Monitor
{
    /// <summary>
    /// 登录日志
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// </summary>
    public class LogLoginDto : SysBase
    {
        public int PageNum { get; set; }

        /// <summary>
        /// IP 地址
        /// </summary>
        public string Ipaddr { get; set; }

        /// <summary>
        /// 登录状态 0成功 1失败
        /// </summary>
        public int IsState { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
    }
}