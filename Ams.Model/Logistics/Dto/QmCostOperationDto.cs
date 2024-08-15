namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 品质业务
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:02
    /// </summary>
    public class QmCostOperationQueryDto : PagerInfo
    {
        public DateTime? BeginQcod001 { get; set; }
        public DateTime? EndQcod001 { get; set; }
    }

    /// <summary>
    /// 品质业务
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:02
    /// </summary>
    public class QmCostOperationDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QcodSfId { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Qcod001 { get; set; }

        [Required(ErrorMessage = "间接赁率不能为空")]
        [ExcelColumn(Name = "间接赁率")]
        [ExcelColumnName("间接赁率")]
        public decimal Qcod002 { get; set; }

        [Required(ErrorMessage = "IQC检查费用不能为空")]
        [ExcelColumn(Name = "IQC检查费用")]
        [ExcelColumnName("IQC检查费用")]
        public decimal Qcod003 { get; set; }

        [Required(ErrorMessage = "检查时间不能为空")]
        [ExcelColumn(Name = "检查时间")]
        [ExcelColumnName("检查时间")]
        public int Qcod004 { get; set; }

        [Required(ErrorMessage = "差旅费不能为空")]
        [ExcelColumn(Name = "差旅费")]
        [ExcelColumnName("差旅费")]
        public decimal Qcod005 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcod006 { get; set; }

        [ExcelColumn(Name = "特记说明")]
        [ExcelColumnName("特记说明")]
        public string Qcod007 { get; set; }

        [Required(ErrorMessage = "初期检定?定期检定业务费用不能为空")]
        [ExcelColumn(Name = "初期检定?定期检定业务费用")]
        [ExcelColumnName("初期检定?定期检定业务费用")]
        public decimal Qcod008 { get; set; }

        [Required(ErrorMessage = "作业时间不能为空")]
        [ExcelColumn(Name = "作业时间")]
        [ExcelColumnName("作业时间")]
        public int Qcod009 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcod010 { get; set; }

        [ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Qcod011 { get; set; }

        [Required(ErrorMessage = "测定器校正业务费用不能为空")]
        [ExcelColumn(Name = "测定器校正业务费用")]
        [ExcelColumnName("测定器校正业务费用")]
        public decimal Qcod012 { get; set; }

        [Required(ErrorMessage = "校正时间不能为空")]
        [ExcelColumn(Name = "校正时间")]
        [ExcelColumnName("校正时间")]
        public int Qcod013 { get; set; }

        [Required(ErrorMessage = "外部委托，搬运费不能为空")]
        [ExcelColumn(Name = "外部委托，搬运费")]
        [ExcelColumnName("外部委托，搬运费")]
        public decimal Qcod014 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcod015 { get; set; }

        [ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Qcod016 { get; set; }

        [Required(ErrorMessage = "其他通常费用不能为空")]
        [ExcelColumn(Name = "其他通常费用")]
        [ExcelColumnName("其他通常费用")]
        public decimal Qcod017 { get; set; }

        [Required(ErrorMessage = "通常作业时间不能为空")]
        [ExcelColumn(Name = "通常作业时间")]
        [ExcelColumnName("通常作业时间")]
        public int Qcod018 { get; set; }

        [Required(ErrorMessage = "通常其他费用不能为空")]
        [ExcelColumn(Name = "通常其他费用")]
        [ExcelColumnName("通常其他费用")]
        public decimal Qcod019 { get; set; }

        [ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Qcod020 { get; set; }

        [ExcelColumn(Name = "IQC品质问题対応记录者")]
        [ExcelColumnName("IQC品质问题対応记录者")]
        public string Qcodqcr { get; set; }

        [Required(ErrorMessage = "出货检查费用不能为空")]
        [ExcelColumn(Name = "出货检查费用")]
        [ExcelColumnName("出货检查费用")]
        public decimal Qcod021 { get; set; }

        [Required(ErrorMessage = "检查时间不能为空")]
        [ExcelColumn(Name = "检查时间")]
        [ExcelColumnName("检查时间")]
        public int Qcod022 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcod023 { get; set; }

        [ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Qcod024 { get; set; }

        [Required(ErrorMessage = "信赖性评价?ORT业务费用不能为空")]
        [ExcelColumn(Name = "信赖性评价?ORT业务费用")]
        [ExcelColumnName("信赖性评价?ORT业务费用")]
        public decimal Qcod025 { get; set; }

        [Required(ErrorMessage = "评价时间不能为空")]
        [ExcelColumn(Name = "评价时间")]
        [ExcelColumnName("评价时间")]
        public int Qcod026 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcod027 { get; set; }

        [ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Qcod028 { get; set; }

        [Required(ErrorMessage = "顾客品质要求对应业务费用不能为空")]
        [ExcelColumn(Name = "顾客品质要求对应业务费用")]
        [ExcelColumnName("顾客品质要求对应业务费用")]
        public decimal Qcod029 { get; set; }

        [Required(ErrorMessage = "评价作业时间不能为空")]
        [ExcelColumn(Name = "评价作业时间")]
        [ExcelColumnName("评价作业时间")]
        public int Qcod030 { get; set; }

        [Required(ErrorMessage = "评价其他费用不能为空")]
        [ExcelColumn(Name = "评价其他费用")]
        [ExcelColumnName("评价其他费用")]
        public decimal Qcod031 { get; set; }

        [ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Qcod032 { get; set; }

        [Required(ErrorMessage = "其他通常业务费用不能为空")]
        [ExcelColumn(Name = "其他通常业务费用")]
        [ExcelColumnName("其他通常业务费用")]
        public decimal Qcod033 { get; set; }

        [Required(ErrorMessage = "通常业务作业时间不能为空")]
        [ExcelColumn(Name = "通常业务作业时间")]
        [ExcelColumnName("通常业务作业时间")]
        public int Qcod034 { get; set; }

        [Required(ErrorMessage = "通常业务其他费用不能为空")]
        [ExcelColumn(Name = "通常业务其他费用")]
        [ExcelColumnName("通常业务其他费用")]
        public decimal Qcod035 { get; set; }

        [ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Qcod036 { get; set; }

        [ExcelColumn(Name = "QA品质问题対応记录者")]
        [ExcelColumnName("QA品质问题対応记录者")]
        public string Qcodqar { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 品质业务
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:02
    /// </summary>
    public class QmCostOperationImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QcodSfId { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Qcod001 { get; set; }

        [Required(ErrorMessage = "间接赁率不能为空")]
        [ExcelColumn(Name = "间接赁率")]
        [ExcelColumnName("间接赁率")]
        public decimal Qcod002 { get; set; }

        [Required(ErrorMessage = "IQC检查费用不能为空")]
        [ExcelColumn(Name = "IQC检查费用")]
        [ExcelColumnName("IQC检查费用")]
        public decimal Qcod003 { get; set; }

        [Required(ErrorMessage = "检查时间不能为空")]
        [ExcelColumn(Name = "检查时间")]
        [ExcelColumnName("检查时间")]
        public int Qcod004 { get; set; }

        [Required(ErrorMessage = "差旅费不能为空")]
        [ExcelColumn(Name = "差旅费")]
        [ExcelColumnName("差旅费")]
        public decimal Qcod005 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcod006 { get; set; }

        [ExcelColumn(Name = "特记说明")]
        [ExcelColumnName("特记说明")]
        public string Qcod007 { get; set; }

        [Required(ErrorMessage = "初期检定?定期检定业务费用不能为空")]
        [ExcelColumn(Name = "初期检定?定期检定业务费用")]
        [ExcelColumnName("初期检定?定期检定业务费用")]
        public decimal Qcod008 { get; set; }

        [Required(ErrorMessage = "作业时间不能为空")]
        [ExcelColumn(Name = "作业时间")]
        [ExcelColumnName("作业时间")]
        public int Qcod009 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcod010 { get; set; }

        [ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Qcod011 { get; set; }

        [Required(ErrorMessage = "测定器校正业务费用不能为空")]
        [ExcelColumn(Name = "测定器校正业务费用")]
        [ExcelColumnName("测定器校正业务费用")]
        public decimal Qcod012 { get; set; }

        [Required(ErrorMessage = "校正时间不能为空")]
        [ExcelColumn(Name = "校正时间")]
        [ExcelColumnName("校正时间")]
        public int Qcod013 { get; set; }

        [Required(ErrorMessage = "外部委托，搬运费不能为空")]
        [ExcelColumn(Name = "外部委托，搬运费")]
        [ExcelColumnName("外部委托，搬运费")]
        public decimal Qcod014 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcod015 { get; set; }

        [ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Qcod016 { get; set; }

        [Required(ErrorMessage = "其他通常费用不能为空")]
        [ExcelColumn(Name = "其他通常费用")]
        [ExcelColumnName("其他通常费用")]
        public decimal Qcod017 { get; set; }

        [Required(ErrorMessage = "通常作业时间不能为空")]
        [ExcelColumn(Name = "通常作业时间")]
        [ExcelColumnName("通常作业时间")]
        public int Qcod018 { get; set; }

        [Required(ErrorMessage = "通常其他费用不能为空")]
        [ExcelColumn(Name = "通常其他费用")]
        [ExcelColumnName("通常其他费用")]
        public decimal Qcod019 { get; set; }

        [ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Qcod020 { get; set; }

        [ExcelColumn(Name = "IQC品质问题対応记录者")]
        [ExcelColumnName("IQC品质问题対応记录者")]
        public string Qcodqcr { get; set; }

        [Required(ErrorMessage = "出货检查费用不能为空")]
        [ExcelColumn(Name = "出货检查费用")]
        [ExcelColumnName("出货检查费用")]
        public decimal Qcod021 { get; set; }

        [Required(ErrorMessage = "检查时间不能为空")]
        [ExcelColumn(Name = "检查时间")]
        [ExcelColumnName("检查时间")]
        public int Qcod022 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcod023 { get; set; }

        [ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Qcod024 { get; set; }

        [Required(ErrorMessage = "信赖性评价?ORT业务费用不能为空")]
        [ExcelColumn(Name = "信赖性评价?ORT业务费用")]
        [ExcelColumnName("信赖性评价?ORT业务费用")]
        public decimal Qcod025 { get; set; }

        [Required(ErrorMessage = "评价时间不能为空")]
        [ExcelColumn(Name = "评价时间")]
        [ExcelColumnName("评价时间")]
        public int Qcod026 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcod027 { get; set; }

        [ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Qcod028 { get; set; }

        [Required(ErrorMessage = "顾客品质要求对应业务费用不能为空")]
        [ExcelColumn(Name = "顾客品质要求对应业务费用")]
        [ExcelColumnName("顾客品质要求对应业务费用")]
        public decimal Qcod029 { get; set; }

        [Required(ErrorMessage = "评价作业时间不能为空")]
        [ExcelColumn(Name = "评价作业时间")]
        [ExcelColumnName("评价作业时间")]
        public int Qcod030 { get; set; }

        [Required(ErrorMessage = "评价其他费用不能为空")]
        [ExcelColumn(Name = "评价其他费用")]
        [ExcelColumnName("评价其他费用")]
        public decimal Qcod031 { get; set; }

        [ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Qcod032 { get; set; }

        [Required(ErrorMessage = "其他通常业务费用不能为空")]
        [ExcelColumn(Name = "其他通常业务费用")]
        [ExcelColumnName("其他通常业务费用")]
        public decimal Qcod033 { get; set; }

        [Required(ErrorMessage = "通常业务作业时间不能为空")]
        [ExcelColumn(Name = "通常业务作业时间")]
        [ExcelColumnName("通常业务作业时间")]
        public int Qcod034 { get; set; }

        [Required(ErrorMessage = "通常业务其他费用不能为空")]
        [ExcelColumn(Name = "通常业务其他费用")]
        [ExcelColumnName("通常业务其他费用")]
        public decimal Qcod035 { get; set; }

        [ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Qcod036 { get; set; }

        [ExcelColumn(Name = "QA品质问题対応记录者")]
        [ExcelColumnName("QA品质问题対応记录者")]
        public string Qcodqar { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}