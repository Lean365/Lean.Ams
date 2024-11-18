namespace Ams.Model.Logistics
{
    /// <summary>
    /// 不良统计
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/12 17:19:12
    /// </summary>
    [SugarTable("pp_defect_total", "不良统计")]
    public class PpDefectTotal : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? Id { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [SugarColumn(ColumnName = "Me002", ColumnDescription = "批次", Length = 20, ColumnDataType = "NVARCHAR")]
        public string Me002 { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "Me003", ColumnDescription = "机种", Length = 20, ColumnDataType = "NVARCHAR")]
        public string Me003 { get; set; }

        /// <summary>
        /// 班组
        /// </summary>
        [SugarColumn(ColumnName = "Me004", ColumnDescription = "班组", Length = 200, ColumnDataType = "NVARCHAR")]
        public string Me004 { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Me005 { get; set; }

        /// <summary>
        /// 工单
        /// </summary>
        [SugarColumn(ColumnName = "Me006", ColumnDescription = "工单", Length = 20, ColumnDataType = "NVARCHAR")]
        public string Me006 { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "Me007", ColumnDescription = "数量", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Me007 { get; set; }

        /// <summary>
        /// 生产
        /// </summary>
        [SugarColumn(ColumnName = "Me008", ColumnDescription = "生产", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Me008 { get; set; }

        /// <summary>
        /// 无不良数
        /// </summary>
        [SugarColumn(ColumnName = "Me009", ColumnDescription = "无不良数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Me009 { get; set; }

        /// <summary>
        /// 不良总数
        /// </summary>
        [SugarColumn(ColumnName = "Me010", ColumnDescription = "不良总数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Me010 { get; set; }

        /// <summary>
        /// 直行率
        /// </summary>
        [SugarColumn(ColumnName = "Me011", ColumnDescription = "直行率", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me011 { get; set; }

        /// <summary>
        /// 不良率
        /// </summary>
        [SugarColumn(ColumnName = "Me012", ColumnDescription = "不良率", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me012 { get; set; }
    }
}