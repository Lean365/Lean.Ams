namespace Ams.Model.Monitor
{
    /// <summary>
    /// 登录日志
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("monitor_login", "登录日志")]
    [Tenant("0")]
    public class LoginLog : SysBase
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long InfoId { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        [SugarColumn(Length = 40)]
        public string UserName { get; set; }

        /// <summary>
        /// 登录状态 0成功 1失败
        /// </summary>
        [SugarColumn(DefaultValue = "0")]
        public int IsStatus { get; set; }

        /// <summary>
        /// 登录IP地址
        /// </summary>
        [SugarColumn(Length = 20)]
        public string Ipaddr { get; set; } = string.Empty;

        /// <summary>
        /// 登录地点
        /// </summary>
        [SugarColumn(Length = 40)]
        public string LoginLocation { get; set; } = string.Empty;

        /// <summary>
        /// 浏览器类型
        /// </summary>
        [SugarColumn(Length = 160)]
        public string Browser { get; set; } = string.Empty;

        /// <summary>
        /// 操作系统
        /// </summary>
        [SugarColumn(Length = 40)]
        public string Os { get; set; } = string.Empty;

        /// <summary>
        /// 提示消息
        /// </summary>
        [SugarColumn(Length = 40)]
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
        /// 客户端id
        /// </summary>
        [SugarColumn(Length = 80)]
        public string ClientId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 位置
        /// </summary>

        [SugarColumn(Length = 200, IsIgnore = true)]
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