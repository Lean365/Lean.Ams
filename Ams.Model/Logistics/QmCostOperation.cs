namespace Ams.Model.Logistics
{
    /// <summary>
    /// 品质业务
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:02
    /// </summary>
    [SugarTable("qm_cost_operation", "品质业务")]
    public class QmCostOperation : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long QcodSfId { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Qcod001 { get; set; }

        /// <summary>
        /// 间接赁率
        /// </summary>
        [SugarColumn(ColumnName = "Qcod002", ColumnDescription = "间接赁率 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod002 { get; set; }

        /// <summary>
        /// IQC检查费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcod003", ColumnDescription = "IQC检查费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod003 { get; set; }

        /// <summary>
        /// 检查时间
        /// </summary>
        [SugarColumn(ColumnName = "Qcod004", ColumnDescription = "检查时间 ", DefaultValue = "0")]
        public int Qcod004 { get; set; }

        /// <summary>
        /// 差旅费
        /// </summary>
        [SugarColumn(ColumnName = "Qcod005", ColumnDescription = "差旅费 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod005 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcod006", ColumnDescription = "其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod006 { get; set; }

        /// <summary>
        /// 特记说明
        /// </summary>
        [SugarColumn(ColumnName = "Qcod007", ColumnDescription = "特记说明 ", Length = 500)]
        public string Qcod007 { get; set; }

        /// <summary>
        /// 初期检定?定期检定业务费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcod008", ColumnDescription = "初期检定?定期检定业务费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod008 { get; set; }

        /// <summary>
        /// 作业时间
        /// </summary>
        [SugarColumn(ColumnName = "Qcod009", ColumnDescription = "作业时间 ", DefaultValue = "0")]
        public int Qcod009 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcod010", ColumnDescription = "其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod010 { get; set; }

        /// <summary>
        /// 特记
        /// </summary>
        [SugarColumn(ColumnName = "Qcod011", ColumnDescription = "特记 ", Length = 500)]
        public string Qcod011 { get; set; }

        /// <summary>
        /// 测定器校正业务费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcod012", ColumnDescription = "测定器校正业务费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod012 { get; set; }

        /// <summary>
        /// 校正时间
        /// </summary>
        [SugarColumn(ColumnName = "Qcod013", ColumnDescription = "校正时间 ", DefaultValue = "0")]
        public int Qcod013 { get; set; }

        /// <summary>
        /// 外部委托，搬运费
        /// </summary>
        [SugarColumn(ColumnName = "Qcod014", ColumnDescription = "外部委托，搬运费 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod014 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcod015", ColumnDescription = "其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod015 { get; set; }

        /// <summary>
        /// 特记
        /// </summary>
        [SugarColumn(ColumnName = "Qcod016", ColumnDescription = "特记 ", Length = 500)]
        public string Qcod016 { get; set; }

        /// <summary>
        /// 其他通常费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcod017", ColumnDescription = "其他通常费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod017 { get; set; }

        /// <summary>
        /// 通常作业时间
        /// </summary>
        [SugarColumn(ColumnName = "Qcod018", ColumnDescription = "通常作业时间 ", DefaultValue = "0")]
        public int Qcod018 { get; set; }

        /// <summary>
        /// 通常其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcod019", ColumnDescription = "通常其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod019 { get; set; }

        /// <summary>
        /// 特记
        /// </summary>
        [SugarColumn(ColumnName = "Qcod020", ColumnDescription = "特记 ", Length = 500)]
        public string Qcod020 { get; set; }

        /// <summary>
        /// IQC品质问题対応记录者
        /// </summary>
        [SugarColumn(ColumnName = "Qcodqcr", ColumnDescription = "IQC品质问题対応记录者 ", Length = 50)]
        public string Qcodqcr { get; set; }

        /// <summary>
        /// 出货检查费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcod021", ColumnDescription = "出货检查费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod021 { get; set; }

        /// <summary>
        /// 检查时间
        /// </summary>
        [SugarColumn(ColumnName = "Qcod022", ColumnDescription = "检查时间 ", DefaultValue = "0")]
        public int Qcod022 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcod023", ColumnDescription = "其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod023 { get; set; }

        /// <summary>
        /// 特记
        /// </summary>
        [SugarColumn(ColumnName = "Qcod024", ColumnDescription = "特记 ", Length = 500)]
        public string Qcod024 { get; set; }

        /// <summary>
        /// 信赖性评价?ORT业务费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcod025", ColumnDescription = "信赖性评价?ORT业务费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod025 { get; set; }

        /// <summary>
        /// 评价时间
        /// </summary>
        [SugarColumn(ColumnName = "Qcod026", ColumnDescription = "评价时间 ", DefaultValue = "0")]
        public int Qcod026 { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcod027", ColumnDescription = "其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod027 { get; set; }

        /// <summary>
        /// 特记
        /// </summary>
        [SugarColumn(ColumnName = "Qcod028", ColumnDescription = "特记 ", Length = 500)]
        public string Qcod028 { get; set; }

        /// <summary>
        /// 顾客品质要求对应业务费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcod029", ColumnDescription = "顾客品质要求对应业务费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod029 { get; set; }

        /// <summary>
        /// 评价作业时间
        /// </summary>
        [SugarColumn(ColumnName = "Qcod030", ColumnDescription = "评价作业时间 ", DefaultValue = "0")]
        public int Qcod030 { get; set; }

        /// <summary>
        /// 评价其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcod031", ColumnDescription = "评价其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod031 { get; set; }

        /// <summary>
        /// 特记
        /// </summary>
        [SugarColumn(ColumnName = "Qcod032", ColumnDescription = "特记 ", Length = 500)]
        public string Qcod032 { get; set; }

        /// <summary>
        /// 其他通常业务费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcod033", ColumnDescription = "其他通常业务费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod033 { get; set; }

        /// <summary>
        /// 通常业务作业时间
        /// </summary>
        [SugarColumn(ColumnName = "Qcod034", ColumnDescription = "通常业务作业时间 ", DefaultValue = "0")]
        public int Qcod034 { get; set; }

        /// <summary>
        /// 通常业务其他费用
        /// </summary>
        [SugarColumn(ColumnName = "Qcod035", ColumnDescription = "通常业务其他费用 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Qcod035 { get; set; }

        /// <summary>
        /// 特记
        /// </summary>
        [SugarColumn(ColumnName = "Qcod036", ColumnDescription = "特记 ", Length = 500)]
        public string Qcod036 { get; set; }

        /// <summary>
        /// QA品质问题対応记录者
        /// </summary>
        [SugarColumn(ColumnName = "Qcodqar", ColumnDescription = "QA品质问题対応记录者 ", Length = 50)]
        public string Qcodqar { get; set; }
    }
}