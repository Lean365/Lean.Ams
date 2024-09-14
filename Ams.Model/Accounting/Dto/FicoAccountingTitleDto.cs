
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 会计科目
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:53:13
    /// </summary>
    public class FicoAccountingTitleQueryDto : PagerInfo 
    {
        /// <summary>
        /// 公司代码 
        /// </summary>        
        public string Mb003 { get; set; }
        /// <summary>
        /// 币种 
        /// </summary>        
        public string Mb004 { get; set; }
        /// <summary>
        /// 科目编号 
        /// </summary>        
        public string Mb006 { get; set; }
        /// <summary>
        /// 短文本 
        /// </summary>        
        public string Mb011 { get; set; }
    }

    /// <summary>
    /// 会计科目
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:53:13
    /// </summary>
    public class FicoAccountingTitleDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]

        public string Mb002 { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        //[ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]

        public string Mb003 { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]

        public string Mb004 { get; set; }

        //[ExcelColumn(Name = "语言Key")]
        [ExcelColumnName("语言Key")]

        public string Mb005 { get; set; }

        [Required(ErrorMessage = "科目编号不能为空")]
        //[ExcelColumn(Name = "科目编号")]
        [ExcelColumnName("科目编号")]

        public string Mb006 { get; set; }

        //[ExcelColumn(Name = "科目表")]
        [ExcelColumnName("科目表")]

        public string Mb007 { get; set; }

        //[ExcelColumn(Name = "BS类别")]
        [ExcelColumnName("BS类别")]

        public string Mb008 { get; set; }

        //[ExcelColumn(Name = "PL类别")]
        [ExcelColumnName("PL类别")]

        public string Mb009 { get; set; }

        //[ExcelColumn(Name = "统驭类别")]
        [ExcelColumnName("统驭类别")]

        public string Mb010 { get; set; }

        //[ExcelColumn(Name = "短文本")]
        [ExcelColumnName("短文本")]

        public string Mb011 { get; set; }

        //[ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]

        public string Mb012 { get; set; }

        //[ExcelColumn(Name = "附加文本")]
        [ExcelColumnName("附加文本")]

        public string Mb013 { get; set; }

        //[ExcelColumn(Name = "科目组")]
        [ExcelColumnName("科目组")]

        public string Mb014 { get; set; }

        [Required(ErrorMessage = "冻结不能为空")]
        //[ExcelColumn(Name = "冻结")]
        [ExcelColumnName("冻结")]

        public int Mb015 { get; set; }

        [ExcelIgnore]

        public string REF01 { get; set; }

        [ExcelIgnore]

        public string REF02 { get; set; }

        [ExcelIgnore]

        public string REF03 { get; set; }

        [ExcelIgnore]

        public decimal REF04 { get; set; }

        [ExcelIgnore]

        public decimal REF05 { get; set; }

        [ExcelIgnore]

        public decimal REF06 { get; set; }

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

        [ExcelIgnore]

        public int? UDF51 { get; set; }

        [ExcelIgnore]

        public int? UDF52 { get; set; }

        [ExcelIgnore]

        public int? UDF53 { get; set; }

        [ExcelIgnore]

        public decimal UDF54 { get; set; }

        [ExcelIgnore]

        public decimal UDF55 { get; set; }

        [ExcelIgnore]

        public decimal UDF56 { get; set; }

        //[ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]

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



        [ExcelColumn(Name = "公司代码")]
        public string Mb003Label { get; set; }
        [ExcelColumn(Name = "币种")]
        public string Mb004Label { get; set; }
        [ExcelColumn(Name = "BS类别")]
        public string Mb008Label { get; set; }
        [ExcelColumn(Name = "PL类别")]
        public string Mb009Label { get; set; }
        [ExcelColumn(Name = "统驭类别")]
        public string Mb010Label { get; set; }
        [ExcelColumn(Name = "冻结")]
        public string Mb015Label { get; set; }
        //[ExcelColumn(Name = "软删除")]
        //public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 会计科目
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:53:13
    /// </summary>
    public class FicoAccountingTitleImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Mb002 { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        //[ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string Mb003 { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Mb004 { get; set; }

        //[ExcelColumn(Name = "语言Key")]
        [ExcelColumnName("语言Key")]
        public string Mb005 { get; set; }

        [Required(ErrorMessage = "科目编号不能为空")]
        //[ExcelColumn(Name = "科目编号")]
        [ExcelColumnName("科目编号")]
        public string Mb006 { get; set; }

        //[ExcelColumn(Name = "科目表")]
        [ExcelColumnName("科目表")]
        public string Mb007 { get; set; }

        //[ExcelColumn(Name = "BS类别")]
        [ExcelColumnName("BS类别")]
        public string Mb008 { get; set; }

        //[ExcelColumn(Name = "PL类别")]
        [ExcelColumnName("PL类别")]
        public string Mb009 { get; set; }

        //[ExcelColumn(Name = "统驭类别")]
        [ExcelColumnName("统驭类别")]
        public string Mb010 { get; set; }

        //[ExcelColumn(Name = "短文本")]
        [ExcelColumnName("短文本")]
        public string Mb011 { get; set; }

        //[ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]
        public string Mb012 { get; set; }

        //[ExcelColumn(Name = "附加文本")]
        [ExcelColumnName("附加文本")]
        public string Mb013 { get; set; }

        //[ExcelColumn(Name = "科目组")]
        [ExcelColumnName("科目组")]
        public string Mb014 { get; set; }

        [Required(ErrorMessage = "冻结不能为空")]
        //[ExcelColumn(Name = "冻结")]
        [ExcelColumnName("冻结")]
        public int Mb015 { get; set; }

        [ExcelIgnore]
        public string REF01 { get; set; }

        [ExcelIgnore]
        public string REF02 { get; set; }

        [ExcelIgnore]
        public string REF03 { get; set; }

        [ExcelIgnore]
        public decimal REF04 { get; set; }

        [ExcelIgnore]
        public decimal REF05 { get; set; }

        [ExcelIgnore]
        public decimal REF06 { get; set; }

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

        [ExcelIgnore]
        public int? UDF51 { get; set; }

        [ExcelIgnore]
        public int? UDF52 { get; set; }

        [ExcelIgnore]
        public int? UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        //[ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
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
        [ExcelColumn(Name = "公司代码")]
        public string Mb003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string Mb004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "BS类别")]
        public string Mb008Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "PL类别")]
        public string Mb009Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "统驭类别")]
        public string Mb010Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "冻结")]
        public string Mb015Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}