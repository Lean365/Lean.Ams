
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// bom核算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:12:02
    /// </summary>
    public class FicoCostingBomQueryDto : PagerInfo 
    {
        /// <summary>
        /// 期间 
        /// </summary>        
        public string Mk002 { get; set; }
        /// <summary>
        /// 年月 
        /// </summary>        
        public string Mk003 { get; set; }
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Mk004 { get; set; }
        /// <summary>
        /// 成品物料 
        /// </summary>        
        public string Mk006 { get; set; }
    }

    /// <summary>
    /// bom核算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:12:02
    /// </summary>
    public class FicoCostingBomDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]

        public string Mk002 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]

        public string Mk003 { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Mk004 { get; set; }

        //[ExcelColumn(Name = "机种名称")]
        [ExcelColumnName("机种名称")]

        public string Mk005 { get; set; }

        [Required(ErrorMessage = "成品物料不能为空")]
        //[ExcelColumn(Name = "成品物料")]
        [ExcelColumnName("成品物料")]

        public string Mk006 { get; set; }

        //[ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]

        public string Mk007 { get; set; }

        [Required(ErrorMessage = "成本不能为空")]
        //[ExcelColumn(Name = "成本")]
        [ExcelColumnName("成本")]

        public decimal Mk008 { get; set; }

        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]

        public string Mk009 { get; set; }

        //[ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("核算日期")]

        public DateTime? Mk010 { get; set; }

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

        public string Remark { get; set; }

        [ExcelIgnore]

        public int? IsDeleted { get; set; }

        [ExcelIgnore]

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "期间")]
        public string Mk002Label { get; set; }
        [ExcelColumn(Name = "年月")]
        public string Mk003Label { get; set; }
        [ExcelColumn(Name = "工厂")]
        public string Mk004Label { get; set; }
    }

    /// <summary>
    /// bom核算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:12:02
    /// </summary>
    public class FicoCostingBomImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string Mk002 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string Mk003 { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Mk004 { get; set; }

        //[ExcelColumn(Name = "机种名称")]
        [ExcelColumnName("机种名称")]
        public string Mk005 { get; set; }

        [Required(ErrorMessage = "成品物料不能为空")]
        //[ExcelColumn(Name = "成品物料")]
        [ExcelColumnName("成品物料")]
        public string Mk006 { get; set; }

        //[ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]
        public string Mk007 { get; set; }

        [Required(ErrorMessage = "成本不能为空")]
        //[ExcelColumn(Name = "成本")]
        [ExcelColumnName("成本")]
        public decimal Mk008 { get; set; }

        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Mk009 { get; set; }

        //[ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("核算日期")]
        public DateTime? Mk010 { get; set; }

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
        public string Remark { get; set; }

        [ExcelIgnore]
        public int? IsDeleted { get; set; }

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
        public string Mk002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string Mk003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string Mk004Label { get; set; }
    }

}