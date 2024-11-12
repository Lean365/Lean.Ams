namespace Ams.Model.Monitor
{
    /// <summary>
    /// 任务日志
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("monitor_tasks_qz", "任务日志")]
    [Tenant("0")]
    public class TasksQzLog : SysBase
    {
        /// <summary>
        /// 日志Id
        /// </summary>
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public long JobLogId { get; set; }

        /// <summary>
        /// 任务Id
        /// </summary>
        [SugarColumn(Length = 50, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string JobId { get; set; }

        /// <summary>
        /// 任务名
        /// </summary>
        [SugarColumn(Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string JobName { get; set; }

        /// <summary>
        /// 任务分组
        /// </summary>
        [SugarColumn(Length = 50, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string JobGroup { get; set; }

        /// <summary>
        /// 执行状态（0正常 1失败）
        /// </summary>
        [SugarColumn(DefaultValue = "0")]
        public int IsStatus { get; set; }

        /// <summary>
        /// 异常
        /// </summary>
        [SugarColumn(ColumnDataType = "NVARCHAR(MAX)")]
        public string Exception { get; set; }

        /// <summary>
        /// 任务消息
        /// </summary>
        [SugarColumn(ColumnDataType = "NVARCHAR(MAX)")]
        public string JobMessage { get; set; }

        /// <summary>
        /// 调用目标字符串
        /// </summary>
        [SugarColumn(Length = 200)]
        public string InvokeTarget { get; set; }

        /// <summary>
        /// 执行用时，毫秒
        /// </summary>
        //[SqlSugar.SugarColumn(IsIgnore = true)]
        public double Elapsed { get; set; }
    }
}