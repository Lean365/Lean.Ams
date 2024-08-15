namespace Ams.Model.Accounting
{
    /// <summary>
    /// 公司科目
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 11:09:24
    /// </summary>
    [SugarTable("fico_accounting_corp", "公司科目")]
    public class FicoAccountingCorp : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long SfId { get; set; }

        /// <summary>
        /// 集团
        /// </summary>
        [SugarColumn(ColumnName = "Mandt", ColumnDescription = "集团 ", Length = 10)]
        public string Mandt { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        [SugarColumn(ColumnName = "Bukrs", ColumnDescription = "公司代码   ", Length = 4)]
        public string Bukrs { get; set; }

        /// <summary>
        /// 翻译Key
        /// </summary>
        [SugarColumn(ColumnName = "Spras", ColumnDescription = "翻译Key  ", Length = 100)]
        public string Spras { get; set; }

        /// <summary>
        /// 科目代码
        /// </summary>
        [SugarColumn(ColumnName = "Saknr", ColumnDescription = "科目代码   ", Length = 10)]
        public string Saknr { get; set; }

        /// <summary>
        /// 文本
        /// </summary>
        [SugarColumn(ColumnName = "Stext", ColumnDescription = "文本 ", Length = 40)]
        public string Stext { get; set; }

        /// <summary>
        /// 长文本
        /// </summary>
        [SugarColumn(ColumnName = "Ltext", ColumnDescription = "长文本 ", Length = 120)]
        public string Ltext { get; set; }
    }
}