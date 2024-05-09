namespace Ams.Kernel.Model.Monitor
{
    /// <summary>
    /// 在线时长
    /// 数据实体对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [SugarTable("log_online_time", TableDescription = "在线时长")]
    [Tenant("0")]
    public class LogOnlineTime : SysBase
    {
        /// <summary>
        /// Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 用户id
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

        /// <summary>
        /// 登录时间
        /// </summary>

        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 登录平台
        /// </summary>
        public string Platform { get; set; }
    }
}