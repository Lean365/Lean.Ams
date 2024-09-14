
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 预算科目
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:59:02
    /// </summary>
    public class FicoBudgetAccountingQueryDto : PagerInfo 
    {
        /// <summary>
        /// 公司代码 
        /// </summary>        
        public string Md004 { get; set; }
        /// <summary>
        /// 预算科目 
        /// </summary>        
        public string Md006 { get; set; }
        /// <summary>
        /// 币种 
        /// </summary>        
        public string Md007 { get; set; }
        /// <summary>
        /// 会计科目 
        /// </summary>        
        public string Md008 { get; set; }
        /// <summary>
        /// 名称 
        /// </summary>        
        public string Md009 { get; set; }
    }

    /// <summary>
    /// 预算科目
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:59:02
    /// </summary>
    public class FicoBudgetAccountingDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]

        public long Id { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]

        public long ParentId { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]

        public string Md003 { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        //[ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]

        public string Md004 { get; set; }

        //[ExcelColumn(Name = "语言Key")]
        [ExcelColumnName("语言Key")]

        public string Md005 { get; set; }

        [Required(ErrorMessage = "预算科目不能为空")]
        //[ExcelColumn(Name = "预算科目")]
        [ExcelColumnName("预算科目")]

        public string Md006 { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]

        public string Md007 { get; set; }

        [Required(ErrorMessage = "会计科目不能为空")]
        //[ExcelColumn(Name = "会计科目")]
        [ExcelColumnName("会计科目")]

        public string Md008 { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        //[ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]

        public string Md009 { get; set; }

        //[ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]

        public string Md010 { get; set; }

        //[ExcelColumn(Name = "附加文本")]
        [ExcelColumnName("附加文本")]

        public string Md011 { get; set; }

        //[ExcelColumn(Name = "费用类型")]
        [ExcelColumnName("费用类型")]

        public string Md012 { get; set; }

        //[ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]

        public string Md013 { get; set; }

        [Required(ErrorMessage = "冻结不能为空")]
        //[ExcelColumn(Name = "冻结")]
        [ExcelColumnName("冻结")]

        public int Md014 { get; set; }

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



        [ExcelColumn(Name = "公司代码")]
        public string Md004Label { get; set; }
        [ExcelColumn(Name = "币种")]
        public string Md007Label { get; set; }
        [ExcelColumn(Name = "冻结")]
        public string Md014Label { get; set; }
        //[ExcelColumn(Name = "软删除")]
        //public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 预算科目
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:59:02
    /// </summary>
    public class FicoBudgetAccountingImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long Id { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long ParentId { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Md003 { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        //[ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string Md004 { get; set; }

        //[ExcelColumn(Name = "语言Key")]
        [ExcelColumnName("语言Key")]
        public string Md005 { get; set; }

        [Required(ErrorMessage = "预算科目不能为空")]
        //[ExcelColumn(Name = "预算科目")]
        [ExcelColumnName("预算科目")]
        public string Md006 { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Md007 { get; set; }

        [Required(ErrorMessage = "会计科目不能为空")]
        //[ExcelColumn(Name = "会计科目")]
        [ExcelColumnName("会计科目")]
        public string Md008 { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        //[ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string Md009 { get; set; }

        //[ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]
        public string Md010 { get; set; }

        //[ExcelColumn(Name = "附加文本")]
        [ExcelColumnName("附加文本")]
        public string Md011 { get; set; }

        //[ExcelColumn(Name = "费用类型")]
        [ExcelColumnName("费用类型")]
        public string Md012 { get; set; }

        //[ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]
        public string Md013 { get; set; }

        [Required(ErrorMessage = "冻结不能为空")]
        //[ExcelColumn(Name = "冻结")]
        [ExcelColumnName("冻结")]
        public int Md014 { get; set; }

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
        [ExcelColumn(Name = "公司代码")]
        public string Md004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string Md007Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "冻结")]
        public string Md014Label { get; set; }
    }

}