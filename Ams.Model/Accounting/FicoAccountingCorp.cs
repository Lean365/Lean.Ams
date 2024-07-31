namespace Ams.Model.Accounting
{
    /// <summary>
    /// 公司科目
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 17:05:40
    /// </summary>
    [SugarTable("fico_accounting_corp", "公司科目")]
    public class FicoAccountingCorp : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FctSfId { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        [SugarColumn(ColumnName = "FctCorp", ColumnDescription = "公司代码 ", Length = 4)]
        public string FctCorp { get; set; }

        /// <summary>
        /// 科目代码
        /// </summary>
        [SugarColumn(ColumnName = "FctCode", ColumnDescription = "科目代码 ", Length = 10)]
        public string FctCode { get; set; }
    }
}