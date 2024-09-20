namespace Ams.Model.Logistics
{
    /// <summary>
    /// 废弃部品
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/18 8:30:51
    /// </summary>
    [SugarTable("qm_cost_discard", "废弃部品")]
    public class QmCostDiscard : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? Id { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Me002", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Me002 { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Me003 { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "Me004", ColumnDescription = "机种", Length = 20)]
        public string Me004 { get; set; }

        /// <summary>
        /// 间接人员赁率
        /// </summary>
        [SugarColumn(ColumnName = "Me005", ColumnDescription = "间接人员赁率", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me005 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Me006", ColumnDescription = "物料", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Me006 { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [SugarColumn(ColumnName = "Me007", ColumnDescription = "描述", Length = 40)]
        public string Me007 { get; set; }

        /// <summary>
        /// 事故内容
        /// </summary>
        [SugarColumn(ColumnName = "Me008", ColumnDescription = "事故内容", Length = 300)]
        public string Me008 { get; set; }

        /// <summary>
        /// 废弃费用
        /// </summary>
        [SugarColumn(ColumnName = "Me009", ColumnDescription = "废弃费用", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me009 { get; set; }

        /// <summary>
        /// 废弃数量
        /// </summary>
        [SugarColumn(ColumnName = "Me010", ColumnDescription = "废弃数量", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me010 { get; set; }

        /// <summary>
        /// 部品单价
        /// </summary>
        [SugarColumn(ColumnName = "Me011", ColumnDescription = "部品单价", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me011 { get; set; }

        /// <summary>
        /// 废弃处理费用
        /// </summary>
        [SugarColumn(ColumnName = "Me012", ColumnDescription = "废弃处理费用", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me012 { get; set; }

        /// <summary>
        /// 运费
        /// </summary>
        [SugarColumn(ColumnName = "Me013", ColumnDescription = "运费", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me013 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Me014", ColumnDescription = "其他费用", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me014 { get; set; }

        /// <summary>
        /// 处理作业时间(分)
        /// </summary>
        [SugarColumn(ColumnName = "Me015", ColumnDescription = "处理作业时间(分)", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Me015 { get; set; }

        /// <summary>
        /// 关税
        /// </summary>
        [SugarColumn(ColumnName = "Me016", ColumnDescription = "关税", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me016 { get; set; }

        /// <summary>
        /// 处理发生其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Me017", ColumnDescription = "处理发生其他费用", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me017 { get; set; }

        /// <summary>
        /// 设变
        /// </summary>
        [SugarColumn(ColumnName = "Me018", ColumnDescription = "设变", Length = 200)]
        public string Me018 { get; set; }

        /// <summary>
        /// 担当
        /// </summary>
        [SugarColumn(ColumnName = "Me019", ColumnDescription = "担当", Length = 40)]
        public string Me019 { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        [SugarColumn(ColumnName = "Me020", ColumnDescription = "附件", Length = 255)]
        public string Me020 { get; set; }
    }
}