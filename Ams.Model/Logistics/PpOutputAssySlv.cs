namespace Ams.Model.Logistics
{
    /// <summary>
    /// 组立明细
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:52
    /// </summary>
    [SugarTable("pp_output_assy_slv", "组立明细")]
    public class PpOutputAssySlv : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 父Id
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? ParentId { get; set; }

        /// <summary>
        /// 生产时段
        /// </summary>
        [SugarColumn(ColumnName = "Mmb002", ColumnDescription = "生产时段", Length = 11, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mmb002 { get; set; }

        /// <summary>
        /// 实际产能
        /// </summary>
        [SugarColumn(ColumnName = "Mmb003", ColumnDescription = "实际产能", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mmb003 { get; set; }

        /// <summary>
        /// 停线时间
        /// </summary>
        [SugarColumn(ColumnName = "Mmb004", ColumnDescription = "停线时间", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mmb004 { get; set; }

        /// <summary>
        /// 停线
        /// </summary>
        [SugarColumn(ColumnName = "Mmb005", ColumnDescription = "停线", Length = 200)]
        public string Mmb005 { get; set; }

        /// <summary>
        /// 停线说明
        /// </summary>
        [SugarColumn(ColumnName = "Mmb006", ColumnDescription = "停线说明", Length = 200)]
        public string Mmb006 { get; set; }

        /// <summary>
        /// 未达成
        /// </summary>
        [SugarColumn(ColumnName = "Mmb007", ColumnDescription = "未达成", Length = 200)]
        public string Mmb007 { get; set; }

        /// <summary>
        /// 未达成说明
        /// </summary>
        [SugarColumn(ColumnName = "Mmb008", ColumnDescription = "未达成说明", Length = 200)]
        public string Mmb008 { get; set; }

        /// <summary>
        /// 实际工数
        /// </summary>
        [SugarColumn(ColumnName = "Mmb009", ColumnDescription = "实际工数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mmb009 { get; set; }

        /// <summary>
        /// 投入工数
        /// </summary>
        [SugarColumn(ColumnName = "Mmb010", ColumnDescription = "投入工数", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mmb010 { get; set; }

        /// <summary>
        /// 工时差异
        /// </summary>
        [SugarColumn(ColumnName = "Mmb011", ColumnDescription = "工时差异", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mmb011 { get; set; }

        /// <summary>
        /// 产能差异
        /// </summary>
        [SugarColumn(ColumnName = "Mmb012", ColumnDescription = "产能差异", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mmb012 { get; set; }

        /// <summary>
        /// 达成率
        /// </summary>
        [SugarColumn(ColumnName = "Mmb013", ColumnDescription = "达成率", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mmb013 { get; set; }
    }
}