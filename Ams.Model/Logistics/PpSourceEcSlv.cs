namespace Ams.Model.Logistics
{
    /// <summary>
    /// 从源设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:08:51
    /// </summary>
    [SugarTable("pp_source_ec_slv", "从源设变")]
    public class PpSourceEcSlv : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public long Zb002 { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        [SugarColumn(ColumnName = "Zb003", ColumnDescription = "设变No.", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Zb003 { get; set; }

        /// <summary>
        /// 完成品
        /// </summary>
        [SugarColumn(ColumnName = "Zb004", ColumnDescription = "完成品", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Zb004 { get; set; }

        /// <summary>
        /// 上阶
        /// </summary>
        [SugarColumn(ColumnName = "Zb005", ColumnDescription = "上阶", Length = 20)]
        public string Zb005 { get; set; }

        /// <summary>
        /// 旧物料
        /// </summary>
        [SugarColumn(ColumnName = "Zb006", ColumnDescription = "旧物料", Length = 20)]
        public string Zb006 { get; set; }

        /// <summary>
        /// 品名
        /// </summary>
        [SugarColumn(ColumnName = "Zb007", ColumnDescription = "品名", Length = 40)]
        public string Zb007 { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "Zb008", ColumnDescription = "数量", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Zb008 { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [SugarColumn(ColumnName = "Zb009", ColumnDescription = "位置", Length = 40)]
        public string Zb009 { get; set; }

        /// <summary>
        /// 新物料
        /// </summary>
        [SugarColumn(ColumnName = "Zb010", ColumnDescription = "新物料", Length = 20)]
        public string Zb010 { get; set; }

        /// <summary>
        /// 品名
        /// </summary>
        [SugarColumn(ColumnName = "Zb011", ColumnDescription = "品名", Length = 40)]
        public string Zb011 { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "Zb012", ColumnDescription = "数量", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Zb012 { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [SugarColumn(ColumnName = "Zb013", ColumnDescription = "位置", Length = 40)]
        public string Zb013 { get; set; }

        /// <summary>
        /// BOM番号
        /// </summary>
        [SugarColumn(ColumnName = "Zb014", ColumnDescription = "BOM番号", Length = 4)]
        public string Zb014 { get; set; }

        /// <summary>
        /// 互换性
        /// </summary>
        [SugarColumn(ColumnName = "Zb015", ColumnDescription = "互换性", Length = 4)]
        public string Zb015 { get; set; }

        /// <summary>
        /// 区分
        /// </summary>
        [SugarColumn(ColumnName = "Zb016", ColumnDescription = "区分", Length = 4)]
        public string Zb016 { get; set; }

        /// <summary>
        /// 安排指示
        /// </summary>
        [SugarColumn(ColumnName = "Zb017", ColumnDescription = "安排指示", Length = 4)]
        public string Zb017 { get; set; }

        /// <summary>
        /// 旧品处理
        /// </summary>
        [SugarColumn(ColumnName = "Zb018", ColumnDescription = "旧品处理", Length = 4)]
        public string Zb018 { get; set; }

        /// <summary>
        /// BOM生效
        /// </summary>
        public DateTime? Zb019 { get; set; }

        /// <summary>
        /// 处理标记
        /// </summary>
        [SugarColumn(ColumnName = "Zb020", ColumnDescription = "处理标记", Length = 3)]
        public string Zb020 { get; set; }
    }
}