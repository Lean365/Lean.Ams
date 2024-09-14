namespace Ams.Model.Logistics
{
    /// <summary>
    /// 品质业务
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:48:39
    /// </summary>
    [SugarTable("qm_cost_operation", "品质业务")]
    public class QmCostOperation : SysBase
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
        [SugarColumn(ColumnName = "Mc002", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc002 { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Mc003 { get; set; }

        /// <summary>
        /// 间接赁率
        /// </summary>
        [SugarColumn(ColumnName = "Mc004", ColumnDescription = "间接赁率", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc004 { get; set; }

        /// <summary>
        /// IQC检查费用
        /// </summary>
        [SugarColumn(ColumnName = "Mc005", ColumnDescription = "IQC检查费用", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc005 { get; set; }

        /// <summary>
        /// 检查时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc006", ColumnDescription = "检查时间", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc006 { get; set; }

        /// <summary>
        /// 差旅费
        /// </summary>
        [SugarColumn(ColumnName = "Mc007", ColumnDescription = "差旅费", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc007 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Mc008", ColumnDescription = "其他费用", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc008 { get; set; }

        /// <summary>
        /// 特记说明
        /// </summary>
        [SugarColumn(ColumnName = "Mc009", ColumnDescription = "特记说明", Length = 500)]
        public string Mc009 { get; set; }

        /// <summary>
        /// 初期检定.定期检定业务费用
        /// </summary>
        [SugarColumn(ColumnName = "Mc010", ColumnDescription = "初期检定.定期检定业务费用", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc010 { get; set; }

        /// <summary>
        /// 作业时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc011", ColumnDescription = "作业时间", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc011 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Mc012", ColumnDescription = "其他费用", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc012 { get; set; }

        /// <summary>
        /// 特记
        /// </summary>
        [SugarColumn(ColumnName = "Mc013", ColumnDescription = "特记", Length = 500)]
        public string Mc013 { get; set; }

        /// <summary>
        /// 测定器校正业务费用
        /// </summary>
        [SugarColumn(ColumnName = "Mc014", ColumnDescription = "测定器校正业务费用", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc014 { get; set; }

        /// <summary>
        /// 校正时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc015", ColumnDescription = "校正时间", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc015 { get; set; }

        /// <summary>
        /// 外部委托，搬运费
        /// </summary>
        [SugarColumn(ColumnName = "Mc016", ColumnDescription = "外部委托，搬运费", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc016 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Mc017", ColumnDescription = "其他费用", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc017 { get; set; }

        /// <summary>
        /// 特记
        /// </summary>
        [SugarColumn(ColumnName = "Mc018", ColumnDescription = "特记", Length = 500)]
        public string Mc018 { get; set; }

        /// <summary>
        /// 其他通常费用
        /// </summary>
        [SugarColumn(ColumnName = "Mc019", ColumnDescription = "其他通常费用", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc019 { get; set; }

        /// <summary>
        /// 通常作业时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc020", ColumnDescription = "通常作业时间", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc020 { get; set; }

        /// <summary>
        /// 通常其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Mc021", ColumnDescription = "通常其他费用", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc021 { get; set; }

        /// <summary>
        /// 特记
        /// </summary>
        [SugarColumn(ColumnName = "Mc022", ColumnDescription = "特记", Length = 500)]
        public string Mc022 { get; set; }

        /// <summary>
        /// 附件1
        /// </summary>
        [SugarColumn(ColumnName = "Mc023", ColumnDescription = "附件1", Length = 255)]
        public string Mc023 { get; set; }

        /// <summary>
        /// IQC品质问题対応记录者
        /// </summary>
        [SugarColumn(ColumnName = "Mc024", ColumnDescription = "IQC品质问题対応记录者", Length = 50)]
        public string Mc024 { get; set; }

        /// <summary>
        /// 出货检查费用
        /// </summary>
        [SugarColumn(ColumnName = "Mc025", ColumnDescription = "出货检查费用", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc025 { get; set; }

        /// <summary>
        /// 检查时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc026", ColumnDescription = "检查时间", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc026 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Mc027", ColumnDescription = "其他费用", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc027 { get; set; }

        /// <summary>
        /// 特记
        /// </summary>
        [SugarColumn(ColumnName = "Mc028", ColumnDescription = "特记", Length = 500)]
        public string Mc028 { get; set; }

        /// <summary>
        /// 信赖性评价.ORT业务费用
        /// </summary>
        [SugarColumn(ColumnName = "Mc029", ColumnDescription = "信赖性评价.ORT业务费用", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc029 { get; set; }

        /// <summary>
        /// 评价时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc030", ColumnDescription = "评价时间", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc030 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Mc031", ColumnDescription = "其他费用", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc031 { get; set; }

        /// <summary>
        /// 特记
        /// </summary>
        [SugarColumn(ColumnName = "Mc032", ColumnDescription = "特记", Length = 500)]
        public string Mc032 { get; set; }

        /// <summary>
        /// 顾客品质要求对应业务费用
        /// </summary>
        [SugarColumn(ColumnName = "Mc033", ColumnDescription = "顾客品质要求对应业务费用", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc033 { get; set; }

        /// <summary>
        /// 评价作业时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc034", ColumnDescription = "评价作业时间", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc034 { get; set; }

        /// <summary>
        /// 评价其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Mc035", ColumnDescription = "评价其他费用", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc035 { get; set; }

        /// <summary>
        /// 特记
        /// </summary>
        [SugarColumn(ColumnName = "Mc036", ColumnDescription = "特记", Length = 500)]
        public string Mc036 { get; set; }

        /// <summary>
        /// 其他通常业务费用
        /// </summary>
        [SugarColumn(ColumnName = "Mc037", ColumnDescription = "其他通常业务费用", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc037 { get; set; }

        /// <summary>
        /// 通常业务作业时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc038", ColumnDescription = "通常业务作业时间", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc038 { get; set; }

        /// <summary>
        /// 通常业务其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Mc039", ColumnDescription = "通常业务其他费用", DefaultValue = "0", Length = 9, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc039 { get; set; }

        /// <summary>
        /// 特记
        /// </summary>
        [SugarColumn(ColumnName = "Mc040", ColumnDescription = "特记", Length = 500)]
        public string Mc040 { get; set; }

        /// <summary>
        /// 附件2
        /// </summary>
        [SugarColumn(ColumnName = "Mc041", ColumnDescription = "附件2", Length = 255)]
        public string Mc041 { get; set; }

        /// <summary>
        /// QA品质问题対応记录者
        /// </summary>
        [SugarColumn(ColumnName = "Mc042", ColumnDescription = "QA品质问题対応记录者", Length = 50)]
        public string Mc042 { get; set; }
    }
}