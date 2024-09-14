
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 品质业务
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:48:39
    /// </summary>
    public class QmCostOperationQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Mc002 { get; set; }
        /// <summary>
        /// 日期 
        /// </summary>        
        public DateTime? BeginMc003 { get; set; }
        public DateTime? EndMc003 { get; set; }
    }

    /// <summary>
    /// 品质业务
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:48:39
    /// </summary>
    public class QmCostOperationDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Mc002 { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]

        public DateTime? Mc003 { get; set; }

        [Required(ErrorMessage = "间接赁率不能为空")]
        //[ExcelColumn(Name = "间接赁率")]
        [ExcelColumnName("间接赁率")]

        public decimal Mc004 { get; set; }

        [Required(ErrorMessage = "IQC检查费用不能为空")]
        //[ExcelColumn(Name = "IQC检查费用")]
        [ExcelColumnName("IQC检查费用")]

        public decimal Mc005 { get; set; }

        [Required(ErrorMessage = "检查时间不能为空")]
        //[ExcelColumn(Name = "检查时间")]
        [ExcelColumnName("检查时间")]

        public int Mc006 { get; set; }

        [Required(ErrorMessage = "差旅费不能为空")]
        //[ExcelColumn(Name = "差旅费")]
        [ExcelColumnName("差旅费")]

        public decimal Mc007 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]

        public decimal Mc008 { get; set; }

        //[ExcelColumn(Name = "特记说明")]
        [ExcelColumnName("特记说明")]

        public string Mc009 { get; set; }

        [Required(ErrorMessage = "初期检定.定期检定业务费用不能为空")]
        //[ExcelColumn(Name = "初期检定.定期检定业务费用")]
        [ExcelColumnName("初期检定.定期检定业务费用")]

        public decimal Mc010 { get; set; }

        [Required(ErrorMessage = "作业时间不能为空")]
        //[ExcelColumn(Name = "作业时间")]
        [ExcelColumnName("作业时间")]

        public int Mc011 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]

        public decimal Mc012 { get; set; }

        //[ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]

        public string Mc013 { get; set; }

        [Required(ErrorMessage = "测定器校正业务费用不能为空")]
        //[ExcelColumn(Name = "测定器校正业务费用")]
        [ExcelColumnName("测定器校正业务费用")]

        public decimal Mc014 { get; set; }

        [Required(ErrorMessage = "校正时间不能为空")]
        //[ExcelColumn(Name = "校正时间")]
        [ExcelColumnName("校正时间")]

        public int Mc015 { get; set; }

        [Required(ErrorMessage = "外部委托，搬运费不能为空")]
        //[ExcelColumn(Name = "外部委托，搬运费")]
        [ExcelColumnName("外部委托，搬运费")]

        public decimal Mc016 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]

        public decimal Mc017 { get; set; }

        //[ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]

        public string Mc018 { get; set; }

        [Required(ErrorMessage = "其他通常费用不能为空")]
        //[ExcelColumn(Name = "其他通常费用")]
        [ExcelColumnName("其他通常费用")]

        public decimal Mc019 { get; set; }

        [Required(ErrorMessage = "通常作业时间不能为空")]
        //[ExcelColumn(Name = "通常作业时间")]
        [ExcelColumnName("通常作业时间")]

        public int Mc020 { get; set; }

        [Required(ErrorMessage = "通常其他费用不能为空")]
        //[ExcelColumn(Name = "通常其他费用")]
        [ExcelColumnName("通常其他费用")]

        public decimal Mc021 { get; set; }

        //[ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]

        public string Mc022 { get; set; }

        //[ExcelColumn(Name = "附件1")]
        [ExcelColumnName("附件1")]

        public string Mc023 { get; set; }

        //[ExcelColumn(Name = "IQC品质问题対応记录者")]
        [ExcelColumnName("IQC品质问题対応记录者")]

        public string Mc024 { get; set; }

        [Required(ErrorMessage = "出货检查费用不能为空")]
        //[ExcelColumn(Name = "出货检查费用")]
        [ExcelColumnName("出货检查费用")]

        public decimal Mc025 { get; set; }

        [Required(ErrorMessage = "检查时间不能为空")]
        //[ExcelColumn(Name = "检查时间")]
        [ExcelColumnName("检查时间")]

        public int Mc026 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]

        public decimal Mc027 { get; set; }

        //[ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]

        public string Mc028 { get; set; }

        [Required(ErrorMessage = "信赖性评价.ORT业务费用不能为空")]
        //[ExcelColumn(Name = "信赖性评价.ORT业务费用")]
        [ExcelColumnName("信赖性评价.ORT业务费用")]

        public decimal Mc029 { get; set; }

        [Required(ErrorMessage = "评价时间不能为空")]
        //[ExcelColumn(Name = "评价时间")]
        [ExcelColumnName("评价时间")]

        public int Mc030 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]

        public decimal Mc031 { get; set; }

        //[ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]

        public string Mc032 { get; set; }

        [Required(ErrorMessage = "顾客品质要求对应业务费用不能为空")]
        //[ExcelColumn(Name = "顾客品质要求对应业务费用")]
        [ExcelColumnName("顾客品质要求对应业务费用")]

        public decimal Mc033 { get; set; }

        [Required(ErrorMessage = "评价作业时间不能为空")]
        //[ExcelColumn(Name = "评价作业时间")]
        [ExcelColumnName("评价作业时间")]

        public int Mc034 { get; set; }

        [Required(ErrorMessage = "评价其他费用不能为空")]
        //[ExcelColumn(Name = "评价其他费用")]
        [ExcelColumnName("评价其他费用")]

        public decimal Mc035 { get; set; }

        //[ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]

        public string Mc036 { get; set; }

        [Required(ErrorMessage = "其他通常业务费用不能为空")]
        //[ExcelColumn(Name = "其他通常业务费用")]
        [ExcelColumnName("其他通常业务费用")]

        public decimal Mc037 { get; set; }

        [Required(ErrorMessage = "通常业务作业时间不能为空")]
        //[ExcelColumn(Name = "通常业务作业时间")]
        [ExcelColumnName("通常业务作业时间")]

        public int Mc038 { get; set; }

        [Required(ErrorMessage = "通常业务其他费用不能为空")]
        //[ExcelColumn(Name = "通常业务其他费用")]
        [ExcelColumnName("通常业务其他费用")]

        public decimal Mc039 { get; set; }

        //[ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]

        public string Mc040 { get; set; }

        //[ExcelColumn(Name = "附件2")]
        [ExcelColumnName("附件2")]

        public string Mc041 { get; set; }

        //[ExcelColumn(Name = "QA品质问题対応记录者")]
        [ExcelColumnName("QA品质问题対応记录者")]

        public string Mc042 { get; set; }

        [ExcelIgnore]

        public string Ref01 { get; set; }

        [ExcelIgnore]

        public string Ref02 { get; set; }

        [ExcelIgnore]

        public string Ref03 { get; set; }

        [ExcelIgnore]

        public decimal Ref04 { get; set; }

        [ExcelIgnore]

        public decimal Ref05 { get; set; }

        [ExcelIgnore]

        public decimal Ref06 { get; set; }

        [ExcelIgnore]

        public string Udf01 { get; set; }

        [ExcelIgnore]

        public string Udf02 { get; set; }

        [ExcelIgnore]

        public string Udf03 { get; set; }

        [ExcelIgnore]

        public string Udf04 { get; set; }

        [ExcelIgnore]

        public string Udf05 { get; set; }

        [ExcelIgnore]

        public string Udf06 { get; set; }

        [ExcelIgnore]

        public int? Udf51 { get; set; }

        [ExcelIgnore]

        public int? Udf52 { get; set; }

        [ExcelIgnore]

        public int? Udf53 { get; set; }

        [ExcelIgnore]

        public decimal Udf54 { get; set; }

        [ExcelIgnore]

        public decimal Udf55 { get; set; }

        [ExcelIgnore]

        public decimal Udf56 { get; set; }

        [ExcelIgnore]

        public int? IsDeleted { get; set; }

        [ExcelIgnore]

        public string Remark { get; set; }

        [ExcelIgnore]

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "工厂")]
        public string Mc002Label { get; set; }
    }

    /// <summary>
    /// 品质业务
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:48:39
    /// </summary>
    public class QmCostOperationImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Mc002 { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Mc003 { get; set; }

        [Required(ErrorMessage = "间接赁率不能为空")]
        //[ExcelColumn(Name = "间接赁率")]
        [ExcelColumnName("间接赁率")]
        public decimal Mc004 { get; set; }

        [Required(ErrorMessage = "IQC检查费用不能为空")]
        //[ExcelColumn(Name = "IQC检查费用")]
        [ExcelColumnName("IQC检查费用")]
        public decimal Mc005 { get; set; }

        [Required(ErrorMessage = "检查时间不能为空")]
        //[ExcelColumn(Name = "检查时间")]
        [ExcelColumnName("检查时间")]
        public int Mc006 { get; set; }

        [Required(ErrorMessage = "差旅费不能为空")]
        //[ExcelColumn(Name = "差旅费")]
        [ExcelColumnName("差旅费")]
        public decimal Mc007 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Mc008 { get; set; }

        //[ExcelColumn(Name = "特记说明")]
        [ExcelColumnName("特记说明")]
        public string Mc009 { get; set; }

        [Required(ErrorMessage = "初期检定.定期检定业务费用不能为空")]
        //[ExcelColumn(Name = "初期检定.定期检定业务费用")]
        [ExcelColumnName("初期检定.定期检定业务费用")]
        public decimal Mc010 { get; set; }

        [Required(ErrorMessage = "作业时间不能为空")]
        //[ExcelColumn(Name = "作业时间")]
        [ExcelColumnName("作业时间")]
        public int Mc011 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Mc012 { get; set; }

        //[ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Mc013 { get; set; }

        [Required(ErrorMessage = "测定器校正业务费用不能为空")]
        //[ExcelColumn(Name = "测定器校正业务费用")]
        [ExcelColumnName("测定器校正业务费用")]
        public decimal Mc014 { get; set; }

        [Required(ErrorMessage = "校正时间不能为空")]
        //[ExcelColumn(Name = "校正时间")]
        [ExcelColumnName("校正时间")]
        public int Mc015 { get; set; }

        [Required(ErrorMessage = "外部委托，搬运费不能为空")]
        //[ExcelColumn(Name = "外部委托，搬运费")]
        [ExcelColumnName("外部委托，搬运费")]
        public decimal Mc016 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Mc017 { get; set; }

        //[ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Mc018 { get; set; }

        [Required(ErrorMessage = "其他通常费用不能为空")]
        //[ExcelColumn(Name = "其他通常费用")]
        [ExcelColumnName("其他通常费用")]
        public decimal Mc019 { get; set; }

        [Required(ErrorMessage = "通常作业时间不能为空")]
        //[ExcelColumn(Name = "通常作业时间")]
        [ExcelColumnName("通常作业时间")]
        public int Mc020 { get; set; }

        [Required(ErrorMessage = "通常其他费用不能为空")]
        //[ExcelColumn(Name = "通常其他费用")]
        [ExcelColumnName("通常其他费用")]
        public decimal Mc021 { get; set; }

        //[ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Mc022 { get; set; }

        //[ExcelColumn(Name = "附件1")]
        [ExcelColumnName("附件1")]
        public string Mc023 { get; set; }

        //[ExcelColumn(Name = "IQC品质问题対応记录者")]
        [ExcelColumnName("IQC品质问题対応记录者")]
        public string Mc024 { get; set; }

        [Required(ErrorMessage = "出货检查费用不能为空")]
        //[ExcelColumn(Name = "出货检查费用")]
        [ExcelColumnName("出货检查费用")]
        public decimal Mc025 { get; set; }

        [Required(ErrorMessage = "检查时间不能为空")]
        //[ExcelColumn(Name = "检查时间")]
        [ExcelColumnName("检查时间")]
        public int Mc026 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Mc027 { get; set; }

        //[ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Mc028 { get; set; }

        [Required(ErrorMessage = "信赖性评价.ORT业务费用不能为空")]
        //[ExcelColumn(Name = "信赖性评价.ORT业务费用")]
        [ExcelColumnName("信赖性评价.ORT业务费用")]
        public decimal Mc029 { get; set; }

        [Required(ErrorMessage = "评价时间不能为空")]
        //[ExcelColumn(Name = "评价时间")]
        [ExcelColumnName("评价时间")]
        public int Mc030 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Mc031 { get; set; }

        //[ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Mc032 { get; set; }

        [Required(ErrorMessage = "顾客品质要求对应业务费用不能为空")]
        //[ExcelColumn(Name = "顾客品质要求对应业务费用")]
        [ExcelColumnName("顾客品质要求对应业务费用")]
        public decimal Mc033 { get; set; }

        [Required(ErrorMessage = "评价作业时间不能为空")]
        //[ExcelColumn(Name = "评价作业时间")]
        [ExcelColumnName("评价作业时间")]
        public int Mc034 { get; set; }

        [Required(ErrorMessage = "评价其他费用不能为空")]
        //[ExcelColumn(Name = "评价其他费用")]
        [ExcelColumnName("评价其他费用")]
        public decimal Mc035 { get; set; }

        //[ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Mc036 { get; set; }

        [Required(ErrorMessage = "其他通常业务费用不能为空")]
        //[ExcelColumn(Name = "其他通常业务费用")]
        [ExcelColumnName("其他通常业务费用")]
        public decimal Mc037 { get; set; }

        [Required(ErrorMessage = "通常业务作业时间不能为空")]
        //[ExcelColumn(Name = "通常业务作业时间")]
        [ExcelColumnName("通常业务作业时间")]
        public int Mc038 { get; set; }

        [Required(ErrorMessage = "通常业务其他费用不能为空")]
        //[ExcelColumn(Name = "通常业务其他费用")]
        [ExcelColumnName("通常业务其他费用")]
        public decimal Mc039 { get; set; }

        //[ExcelColumn(Name = "特记")]
        [ExcelColumnName("特记")]
        public string Mc040 { get; set; }

        //[ExcelColumn(Name = "附件2")]
        [ExcelColumnName("附件2")]
        public string Mc041 { get; set; }

        //[ExcelColumn(Name = "QA品质问题対応记录者")]
        [ExcelColumnName("QA品质问题対応记录者")]
        public string Mc042 { get; set; }

        [ExcelIgnore]
        public string Ref01 { get; set; }

        [ExcelIgnore]
        public string Ref02 { get; set; }

        [ExcelIgnore]
        public string Ref03 { get; set; }

        [ExcelIgnore]
        public decimal Ref04 { get; set; }

        [ExcelIgnore]
        public decimal Ref05 { get; set; }

        [ExcelIgnore]
        public decimal Ref06 { get; set; }

        [ExcelIgnore]
        public string Udf01 { get; set; }

        [ExcelIgnore]
        public string Udf02 { get; set; }

        [ExcelIgnore]
        public string Udf03 { get; set; }

        [ExcelIgnore]
        public string Udf04 { get; set; }

        [ExcelIgnore]
        public string Udf05 { get; set; }

        [ExcelIgnore]
        public string Udf06 { get; set; }

        [ExcelIgnore]
        public int? Udf51 { get; set; }

        [ExcelIgnore]
        public int? Udf52 { get; set; }

        [ExcelIgnore]
        public int? Udf53 { get; set; }

        [ExcelIgnore]
        public decimal Udf54 { get; set; }

        [ExcelIgnore]
        public decimal Udf55 { get; set; }

        [ExcelIgnore]
        public decimal Udf56 { get; set; }

        [ExcelIgnore]
        public int? IsDeleted { get; set; }

        [ExcelIgnore]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string Mc002Label { get; set; }
    }

}