namespace Ams.Model.Logistics
{
    /// <summary>
    /// 废弃部品
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:57
    /// </summary>
    [SugarTable("qm_cost_waste", "废弃部品")]
    public class QmCostWaste : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long QcwdSfId { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Qcwd001 { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "Qcwd002", ColumnDescription = "机种 ", Length = 20)]
        public string Qcwd002 { get; set; }

        /// <summary>
        /// 间接人员赁率
        /// </summary>
        [SugarColumn(ColumnName = "Qcwd003", ColumnDescription = "间接人员赁率 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcwd003 { get; set; }

        /// <summary>
        /// 部品品号
        /// </summary>
        [SugarColumn(ColumnName = "Qcwd004", ColumnDescription = "部品品号 ", Length = 15)]
        public string Qcwd004 { get; set; }

        /// <summary>
        /// 部品品名
        /// </summary>
        [SugarColumn(ColumnName = "Qcwd005", ColumnDescription = "部品品名 ", Length = 100)]
        public string Qcwd005 { get; set; }

        /// <summary>
        /// 事故内容
        /// </summary>
        [SugarColumn(ColumnName = "Qcwd006", ColumnDescription = "事故内容 ", Length = 300)]
        public string Qcwd006 { get; set; }

        /// <summary>
        /// 废弃费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcwd007", ColumnDescription = "废弃费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcwd007 { get; set; }

        /// <summary>
        /// 废弃数量
        /// </summary>
        [SugarColumn(ColumnName = "Qcwd008", ColumnDescription = "废弃数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcwd008 { get; set; }

        /// <summary>
        /// 部品单价
        /// </summary>
        [SugarColumn(ColumnName = "Qcwd009", ColumnDescription = "部品单价 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcwd009 { get; set; }

        /// <summary>
        /// 废弃处理费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcwd010", ColumnDescription = "废弃处理费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcwd010 { get; set; }

        /// <summary>
        /// 运费
        /// </summary>
        [SugarColumn(ColumnName = "Qcwd011", ColumnDescription = "运费 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcwd011 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcwd012", ColumnDescription = "其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcwd012 { get; set; }

        /// <summary>
        /// 处理作业时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Qcwd013", ColumnDescription = "处理作业时间(分) ", DefaultValue = "0")]
        public int Qcwd013 { get; set; }

        /// <summary>
        /// 关税
        /// </summary>
        [SugarColumn(ColumnName = "Qcwd014", ColumnDescription = "关税 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcwd014 { get; set; }

        /// <summary>
        /// 处理发生其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcwd015", ColumnDescription = "处理发生其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcwd015 { get; set; }

        /// <summary>
        /// 设变
        /// </summary>
        [SugarColumn(ColumnName = "Qcwd016", ColumnDescription = "设变 ", Length = 200)]
        public string Qcwd016 { get; set; }

        /// <summary>
        /// 担当
        /// </summary>
        [SugarColumn(ColumnName = "Qcwdrec", ColumnDescription = "担当 ", Length = 50)]
        public string Qcwdrec { get; set; }
    }
}