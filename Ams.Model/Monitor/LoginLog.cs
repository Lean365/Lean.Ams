namespace Ams.Model.Monitor
{
    /// <summary>
    /// sys_logininfor 表
    /// </summary>
    [SugarTable("monitor_login_log", "登录日志")]
    [Tenant("0")]
    public class LoginLog : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long InfoId { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 登录状态 0成功 1失败
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsStatus { get; set; }

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

        /// <summary>
        /// 开始时间
        /// </summary>

        [SugarColumn(IsIgnore = true)]
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>

        [SugarColumn(IsIgnore = true)]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 客户端ID
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }

        [SugarColumn(IsIgnore = true)]
        public string Position
        {
            get
            {
                var temp_location = LoginLocation.Split("-")?[0];
                if (temp_location == "0")
                {
                    return "IP未知";
                }
                return temp_location;
            }
        }
    }
}