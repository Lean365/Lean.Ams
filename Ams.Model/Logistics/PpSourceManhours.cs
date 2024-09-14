namespace Ams.Model.Logistics
{
    /// <summary>
    /// 源工时
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:39:17
    /// </summary>
    [SugarTable("pp_source_manhours", "源工时")]
    public class PpSourceManhours : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Zc002", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Zc002 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Zc003", ColumnDescription = "物料", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Zc003 { get; set; }

        /// <summary>
        /// 工作中心
        /// </summary>
        [SugarColumn(ColumnName = "Zc004", ColumnDescription = "工作中心", Length = 10)]
        public string Zc004 { get; set; }

        /// <summary>
        /// 工作中心描述
        /// </summary>
        [SugarColumn(ColumnName = "Zc005", ColumnDescription = "工作中心描述", Length = 40)]
        public string Zc005 { get; set; }

        /// <summary>
        /// 标准值
        /// </summary>
        [SugarColumn(ColumnName = "Zc006", ColumnDescription = "标准值", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Zc006 { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [SugarColumn(ColumnName = "Zc007", ColumnDescription = "单位", Length = 1)]
        public string Zc007 { get; set; }

        /// <summary>
        /// 标准值
        /// </summary>
        [SugarColumn(ColumnName = "Zc008", ColumnDescription = "标准值", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Zc008 { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [SugarColumn(ColumnName = "Zc009", ColumnDescription = "单位", Length = 3)]
        public string Zc009 { get; set; }
    }
}