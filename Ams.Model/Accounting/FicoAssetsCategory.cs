namespace Ams.Model.Accounting
{
    /// <summary>
    /// 资产类别
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/12 16:16:33
    /// </summary>
    [SugarTable("fico_assets_category", "资产类别")]
    public class FicoAssetsCategory : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "Mc002", ColumnDescription = "公司", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc002 { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [SugarColumn(ColumnName = "Mc003", ColumnDescription = "类别", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc003 { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "Mc004", ColumnDescription = "名称", Length = 40, ColumnDataType = "NVARCHAR", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc004 { get; set; }

        /// <summary>
        /// 长文本
        /// </summary>
        [SugarColumn(ColumnName = "Mc005", ColumnDescription = "长文本", Length = 100, ColumnDataType = "NVARCHAR", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc005 { get; set; }
    }
}