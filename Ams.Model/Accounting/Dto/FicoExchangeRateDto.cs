
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 币种汇率
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:52:45
    /// </summary>
    public class FicoExchangeRateQueryDto : PagerInfo 
    {
        /// <summary>
        /// 公司 
        /// </summary>        
        public string Mm002 { get; set; }
        /// <summary>
        /// 日期 
        /// </summary>        
        public DateTime? BeginMm003 { get; set; }
        public DateTime? EndMm003 { get; set; }
        /// <summary>
        /// 从币种 
        /// </summary>        
        public string Mm004 { get; set; }
    }

    /// <summary>
    /// 币种汇率
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:52:45
    /// </summary>
    public class FicoExchangeRateDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]

        public string Mm002 { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]

        public DateTime? Mm003 { get; set; }

        [Required(ErrorMessage = "从币种不能为空")]
        //[ExcelColumn(Name = "从币种")]
        [ExcelColumnName("从币种")]

        public string Mm004 { get; set; }

        [Required(ErrorMessage = "基数不能为空")]
        //[ExcelColumn(Name = "基数")]
        [ExcelColumnName("基数")]

        public int Mm005 { get; set; }

        [Required(ErrorMessage = "汇率不能为空")]
        //[ExcelColumn(Name = "汇率")]
        [ExcelColumnName("汇率")]

        public decimal Mm006 { get; set; }

        //[ExcelColumn(Name = "到币种")]
        [ExcelColumnName("到币种")]

        public string Mm007 { get; set; }

        [ExcelIgnore]

        public string Ref01 { get; set; }

        [ExcelIgnore]

        public string Ref02 { get; set; }

        [ExcelIgnore]

        public string Ref03 { get; set; }

        [Required(ErrorMessage = "预留1不能为空")]
        [ExcelIgnore]

        public decimal Ref04 { get; set; }

        [Required(ErrorMessage = "预留2不能为空")]
        [ExcelIgnore]

        public decimal Ref05 { get; set; }

        [Required(ErrorMessage = "预留3不能为空")]
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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]

        public int Udf51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]

        public int Udf52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]

        public int Udf53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]

        public decimal Udf54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]

        public decimal Udf55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
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



        [ExcelColumn(Name = "公司")]
        public string Mm002Label { get; set; }
        [ExcelColumn(Name = "从币种")]
        public string Mm004Label { get; set; }
    }

    /// <summary>
    /// 币种汇率
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:52:45
    /// </summary>
    public class FicoExchangeRateImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string Mm002 { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Mm003 { get; set; }

        [Required(ErrorMessage = "从币种不能为空")]
        //[ExcelColumn(Name = "从币种")]
        [ExcelColumnName("从币种")]
        public string Mm004 { get; set; }

        [Required(ErrorMessage = "基数不能为空")]
        //[ExcelColumn(Name = "基数")]
        [ExcelColumnName("基数")]
        public int Mm005 { get; set; }

        [Required(ErrorMessage = "汇率不能为空")]
        //[ExcelColumn(Name = "汇率")]
        [ExcelColumnName("汇率")]
        public decimal Mm006 { get; set; }

        //[ExcelColumn(Name = "到币种")]
        [ExcelColumnName("到币种")]
        public string Mm007 { get; set; }

        [ExcelIgnore]
        public string Ref01 { get; set; }

        [ExcelIgnore]
        public string Ref02 { get; set; }

        [ExcelIgnore]
        public string Ref03 { get; set; }

        [Required(ErrorMessage = "预留1不能为空")]
        [ExcelIgnore]
        public decimal Ref04 { get; set; }

        [Required(ErrorMessage = "预留2不能为空")]
        [ExcelIgnore]
        public decimal Ref05 { get; set; }

        [Required(ErrorMessage = "预留3不能为空")]
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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public int Udf51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public int Udf52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public int Udf53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal Udf54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal Udf55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
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
        [ExcelColumn(Name = "公司")]
        public string Mm002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "从币种")]
        public string Mm004Label { get; set; }
    }

}