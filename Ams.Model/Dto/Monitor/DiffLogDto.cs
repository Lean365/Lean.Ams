namespace Ams.Model.Dto.Monitor
{
    /// <summary>
    /// 审计日志
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public class DiffLogQueryDto : PagerInfo
    {
        public string TableName { get; set; }
        public string DiffType { get; set; }
        public string UserName { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
    }

    /// <summary>
    /// 审计日志
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public class DiffLogDto
    {
        [Required(ErrorMessage = "主键不能为空")]
        [ExcelColumn(Name = "主键", Width = 15)]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PId { get; set; }

        [ExcelColumn(Name = "表名", Width = 15)]
        public string TableName { get; set; }

        [ExcelColumn(Name = "业务数据内容")]
        public string BusinessData { get; set; }

        [ExcelColumn(Name = "差异类型")]
        public string DiffType { get; set; }

        [ExcelColumn(Name = "执行sql语句", Width = 30)]
        public string Sql { get; set; }

        [ExcelColumn(Name = "变更前数据", Width = 30)]
        public string BeforeData { get; set; } = string.Empty;

        [ExcelColumn(Name = "变更后数据", Width = 30)]
        public string AfterData { get; set; } = string.Empty;

        [ExcelColumn(Name = "操作用户名")]
        public string UserName { get; set; }

        [ExcelColumn(Name = "数据库配置id")]
        public string ConfigId { get; set; }
    }
}