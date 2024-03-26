namespace Ams.Kernel.Model.Monitor
{
    /// <summary>
    /// 登录日志
    /// 数据实体对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 13:57:42)
    /// </summary>
    [SugarTable("log_login", "登录日志")]
    [Tenant("0")]
    public class LogLogin : SysBase
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long InfoId { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登录状态 0成功 1失败
        /// </summary>
        [SugarColumn(DefaultValue = "0")]
        public int IsState { get; set; }

        /// <summary>
        /// 登录IP地址
        /// </summary>
        public string Ipaddr { get; set; } = string.Empty;

        /// <summary>
        /// 登录地点
        /// </summary>
        public string LoginLocation { get; set; } = string.Empty;

        /// <summary>
        /// 浏览器类型
        /// </summary>
        public string Browser { get; set; } = string.Empty;

        /// <summary>
        /// 操作系统
        /// </summary>
        public string Os { get; set; } = string.Empty;

        /// <summary>
        /// 提示消息
        /// </summary>
        public string Msg { get; set; } = string.Empty;

        /// <summary>
        /// 访问时间
        /// </summary>
        public DateTime LoginTime { get; set; } = DateTime.Now;

        [SugarColumn(IsIgnore = true)]
        public DateTime? BeginTime { get; set; }

        [SugarColumn(IsIgnore = true)]
        public DateTime? EndTime { get; set; }
    }

    public class StatiLogLoginDto
    {
        /// <summary>
        /// 去重数据
        /// </summary>
        public int DeRepeatNum { get; set; }

        public int Num { get; set; }
        public DateTime Date { get; set; }
        public string WeekName { get; set; }
    }
}