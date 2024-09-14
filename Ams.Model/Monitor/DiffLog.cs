namespace Ams.Model.Monitor
{
    /// <summary>
    /// 审计日志
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("monitor_diff", "审计日志")]
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
        [SugarColumn(Length = 40)]
        public string TableName { get; set; }

        /// <summary>
        /// 业务数据内容
        /// </summary>
        [SugarColumn(Length = 4000)]
        public string BusinessData { get; set; }

        /// <summary>
        /// 差异类型insert，update，delete
        /// </summary>
        [SugarColumn(Length = 40)]
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
        [SugarColumn(Length = 40)]
        public string UserName { get; set; }

        /// <summary>
        /// 数据库配置id
        /// </summary>
        [SugarColumn(Length = 40)]
        public string ConfigId { get; set; }
    }
}