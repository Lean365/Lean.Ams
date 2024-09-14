namespace Ams.Model.Monitor
{
    /// <summary>
    /// 在线时长
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("monitor_duration", TableDescription = "在线时长")]
    [Tenant("0")]
    public class DurationLog : SysBase
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
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 地址位置
        /// </summary>
        [SugarColumn(Length = 200)]
        public string Location { get; set; }

        /// <summary>
        /// 用户IP
        /// </summary>
        [SugarColumn(Length = 20)]
        public string UserIP { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>

        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 登录平台
        /// </summary>
        [SugarColumn(Length = 40)]
        public string Platform { get; set; }
    }
}