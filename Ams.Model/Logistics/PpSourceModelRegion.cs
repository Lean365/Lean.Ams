namespace Ams.Model.Logistics
{
    /// <summary>
    /// 源机种仕向
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:38:17
    /// </summary>
    [SugarTable("pp_source_model_region", "源机种仕向")]
    public class PpSourceModelRegion : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Ze002", ColumnDescription = "物料", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ze002 { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "Ze003", ColumnDescription = "机种", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ze003 { get; set; }

        /// <summary>
        /// 仕向
        /// </summary>
        [SugarColumn(ColumnName = "Ze004", ColumnDescription = "仕向", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ze004 { get; set; }

        /// <summary>
        /// 文本
        /// </summary>
        [SugarColumn(ColumnName = "Ze005", ColumnDescription = "文本", Length = 40)]
        public string Ze005 { get; set; }
    }
}