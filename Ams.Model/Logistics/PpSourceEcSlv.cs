namespace Ams.Model.Logistics
{
    /// <summary>
    /// 从源设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:04:44
    /// </summary>
    [SugarTable("pp_source_ec_slv", "从源设变")]
    public class PpSourceEcSlv : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long SfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        public long ParentSfId { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        [SugarColumn(ColumnName = "Zpabds001", ColumnDescription = "设变No. ", Length = 6)]
        public string Zpabds001 { get; set; }

        /// <summary>
        /// 完成品
        /// </summary>
        [SugarColumn(ColumnName = "Zpabds002", ColumnDescription = "完成品 ", Length = 20)]
        public string Zpabds002 { get; set; }

        /// <summary>
        /// 上阶
        /// </summary>
        [SugarColumn(ColumnName = "Zpabds003", ColumnDescription = "上阶 ", Length = 20)]
        public string Zpabds003 { get; set; }

        /// <summary>
        /// 旧物料
        /// </summary>
        [SugarColumn(ColumnName = "Zpabds004", ColumnDescription = "旧物料 ", Length = 20)]
        public string Zpabds004 { get; set; }

        /// <summary>
        /// 品名
        /// </summary>
        [SugarColumn(ColumnName = "Zpabds005", ColumnDescription = "品名 ", Length = 40)]
        public string Zpabds005 { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "Zpabds006", ColumnDescription = "数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Zpabds006 { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [SugarColumn(ColumnName = "Zpabds007", ColumnDescription = "位置 ", Length = 40)]
        public string Zpabds007 { get; set; }

        /// <summary>
        /// 新物料
        /// </summary>
        [SugarColumn(ColumnName = "Zpabds008", ColumnDescription = "新物料 ", Length = 20)]
        public string Zpabds008 { get; set; }

        /// <summary>
        /// 品名
        /// </summary>
        [SugarColumn(ColumnName = "Zpabds009", ColumnDescription = "品名 ", Length = 40)]
        public string Zpabds009 { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "Zpabds010", ColumnDescription = "数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Zpabds010 { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [SugarColumn(ColumnName = "Zpabds011", ColumnDescription = "位置 ", Length = 40)]
        public string Zpabds011 { get; set; }

        /// <summary>
        /// BOM番号
        /// </summary>
        [SugarColumn(ColumnName = "Zpabds012", ColumnDescription = "BOM番号 ", Length = 4)]
        public string Zpabds012 { get; set; }

        /// <summary>
        /// 互换性
        /// </summary>
        [SugarColumn(ColumnName = "Zpabds013", ColumnDescription = "互换性 ", Length = 4)]
        public string Zpabds013 { get; set; }

        /// <summary>
        /// 区分
        /// </summary>
        [SugarColumn(ColumnName = "Zpabds014", ColumnDescription = "区分 ", Length = 4)]
        public string Zpabds014 { get; set; }

        /// <summary>
        /// 安排指示
        /// </summary>
        [SugarColumn(ColumnName = "Zpabds015", ColumnDescription = "安排指示 ", Length = 4)]
        public string Zpabds015 { get; set; }

        /// <summary>
        /// 旧品处理
        /// </summary>
        [SugarColumn(ColumnName = "Zpabds016", ColumnDescription = "旧品处理 ", Length = 4)]
        public string Zpabds016 { get; set; }

        /// <summary>
        /// BOM生效
        /// </summary>
        public DateTime? Zpabds017 { get; set; }

        /// <summary>
        /// 处理标记
        /// </summary>
        [SugarColumn(ColumnName = "IsSolved", ColumnDescription = "处理标记 ", Length = 3)]
        public string IsSolved { get; set; }
    }
}