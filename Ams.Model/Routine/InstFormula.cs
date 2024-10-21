namespace Ams.Model.Routine
{
    /// <summary>
    /// 计算公式
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 11:06:35
    /// </summary>
    [SugarTable("inst_formula", "计算公式")]
    public class InstFormula : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [SugarColumn(ColumnName = "Mb002", ColumnDescription = "类别", Length = 1, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb002 { get; set; }

        /// <summary>
        /// 翻译键值
        /// </summary>
        [SugarColumn(ColumnName = "Mb003", ColumnDescription = "翻译键值", Length = 100)]
        public string Mb003 { get; set; }

        /// <summary>
        /// 公式标识
        /// </summary>
        [SugarColumn(ColumnName = "Mb004", ColumnDescription = "公式标识", Length = -1, ColumnDataType = "NVARCHAR")]
        public string Mb004 { get; set; }
    }
}