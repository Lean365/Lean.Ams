namespace Ams.Model.Monitor
{
    /// <summary>
    /// 差异日志
    /// 数据实体对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    [SugarTable("monitor_diff_log", "审计日志")]
    [Tenant("0")]
    public class DiffLog : SysBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PId { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 业务数据内容
        /// </summary>
        [SugarColumn(Length = 4000)]
        public string BusinessData { get; set; }

        /// <summary>
        /// 差异类型insert，update，delete
        /// </summary>
        public string DiffType { get; set; }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        [SugarColumn(ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string Sql { get; set; }

        /// <summary>
        /// 变更前数据
        /// </summary>
        [SugarColumn(ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string BeforeData { get; set; }

        /// <summary>
        /// 变更后数据
        /// </summary>
        [SugarColumn(ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string AfterData { get; set; }

        /// <summary>
        /// 操作用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 数据库配置id
        /// </summary>
        public string ConfigId { get; set; }
    }
}