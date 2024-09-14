
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 实际对比
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 14:38:54
    /// </summary>
    public class FicoBudgetActualContQueryDto : PagerInfo 
    {
        /// <summary>
        /// 期间 
        /// </summary>        
        public string Me002 { get; set; }
        /// <summary>
        /// 年月 
        /// </summary>        
        public string Me003 { get; set; }
        /// <summary>
        /// 公司代码 
        /// </summary>        
        public string Me004 { get; set; }
        /// <summary>
        /// 币种 
        /// </summary>        
        public string Me009 { get; set; }
    }

    /// <summary>
    /// 实际对比
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 14:38:54
    /// </summary>
    public class FicoBudgetActualContDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]

        public string Me002 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]

        public string Me003 { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        //[ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]

        public string Me004 { get; set; }

        //[ExcelColumn(Name = "统计类别")]
        [ExcelColumnName("统计类别")]

        public string Me005 { get; set; }

        //[ExcelColumn(Name = "成本科目")]
        [ExcelColumnName("成本科目")]

        public string Me006 { get; set; }

        //[ExcelColumn(Name = "成本分类")]
        [ExcelColumnName("成本分类")]

        public string Me007 { get; set; }

        //[ExcelColumn(Name = "科目代码")]
        [ExcelColumnName("科目代码")]

        public string Me008 { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]

        public string Me009 { get; set; }

        [Required(ErrorMessage = "预算不能为空")]
        //[ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]

        public decimal Me010 { get; set; }

        [Required(ErrorMessage = "实际不能为空")]
        //[ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]

        public decimal Me011 { get; set; }

        [Required(ErrorMessage = "差异不能为空")]
        //[ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]

        public decimal Me012 { get; set; }

        //[ExcelColumn(Name = "核算人员")]
        [ExcelColumnName("核算人员")]

        public string Me013 { get; set; }

        //[ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("核算日期")]

        public DateTime? Me014 { get; set; }

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



        [ExcelColumn(Name = "期间")]
        public string Me002Label { get; set; }
        [ExcelColumn(Name = "年月")]
        public string Me003Label { get; set; }
        [ExcelColumn(Name = "公司代码")]
        public string Me004Label { get; set; }
        [ExcelColumn(Name = "币种")]
        public string Me009Label { get; set; }
    }

    /// <summary>
    /// 实际对比
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 14:38:54
    /// </summary>
    public class FicoBudgetActualContImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string Me002 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string Me003 { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        //[ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string Me004 { get; set; }

        //[ExcelColumn(Name = "统计类别")]
        [ExcelColumnName("统计类别")]
        public string Me005 { get; set; }

        //[ExcelColumn(Name = "成本科目")]
        [ExcelColumnName("成本科目")]
        public string Me006 { get; set; }

        //[ExcelColumn(Name = "成本分类")]
        [ExcelColumnName("成本分类")]
        public string Me007 { get; set; }

        //[ExcelColumn(Name = "科目代码")]
        [ExcelColumnName("科目代码")]
        public string Me008 { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Me009 { get; set; }

        [Required(ErrorMessage = "预算不能为空")]
        //[ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public decimal Me010 { get; set; }

        [Required(ErrorMessage = "实际不能为空")]
        //[ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]
        public decimal Me011 { get; set; }

        [Required(ErrorMessage = "差异不能为空")]
        //[ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal Me012 { get; set; }

        //[ExcelColumn(Name = "核算人员")]
        [ExcelColumnName("核算人员")]
        public string Me013 { get; set; }

        //[ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("核算日期")]
        public DateTime? Me014 { get; set; }

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
        [ExcelColumn(Name = "期间")]
        public string Me002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string Me003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司代码")]
        public string Me004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string Me009Label { get; set; }
    }

}