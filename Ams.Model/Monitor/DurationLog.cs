namespace Ams.Model.Monitor
{
    /// <summary>
    /// 用户在线时长
    /// </summary>
    [SugarTable("monitor_duration_log", TableDescription = "在线时长")]
    [Tenant("0")]
    public class DurationLog : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 在线时长(分)
        /// </summary>
        public double OnlineTime { get; set; }

        /// <summary>
        /// 今日在线时长
        /// </summary>
        public double TodayOnlineTime { get; set; }

        /// <summary>
        /// 地址位置
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 用户IP
        /// </summary>
        public string UserIP { get; set; }

        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 登录平台
        /// </summary>
        public string Platform { get; set; }
    }
}