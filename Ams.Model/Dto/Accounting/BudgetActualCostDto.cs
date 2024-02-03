
namespace Ams.Model.Dto
{
    /// <summary>
    /// 预算实际明细
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 10:41:09)
    /// </summary>
    public class BudgetActualCostQueryDto : PagerInfo 
    {
        public string FbYm { get; set; }
        public string FbCorpCode { get; set; }
    }

    /// <summary>
    /// 预算实际明细
    /// 输入输出对象
    /// </summary>
    public class BudgetActualCostDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbSFID { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string FbFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbYm { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        [ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string FbCorpCode { get; set; }

        [Required(ErrorMessage = "公司名称不能为空")]
        [ExcelColumn(Name = "公司名称")]
        [ExcelColumnName("公司名称")]
        public string FbCorpName { get; set; }

        [Required(ErrorMessage = "统计类别不能为空")]
        [ExcelColumn(Name = "统计类别")]
        [ExcelColumnName("统计类别")]
        public string FbExpCategory { get; set; }

        [Required(ErrorMessage = "成本代码不能为空")]
        [ExcelColumn(Name = "成本代码")]
        [ExcelColumnName("成本代码")]
        public string FbCostCode { get; set; }

        [Required(ErrorMessage = "成本名称不能为空")]
        [ExcelColumn(Name = "成本名称")]
        [ExcelColumnName("成本名称")]
        public string FbCostName { get; set; }

        [Required(ErrorMessage = "科目代码不能为空")]
        [ExcelColumn(Name = "科目代码")]
        [ExcelColumnName("科目代码")]
        public string FbTitleCode { get; set; }

        [Required(ErrorMessage = "科目名称不能为空")]
        [ExcelColumn(Name = "科目名称")]
        [ExcelColumnName("科目名称")]
        public string FbTitleName { get; set; }

        [Required(ErrorMessage = "科目分类不能为空")]
        [ExcelColumn(Name = "科目分类")]
        [ExcelColumnName("科目分类")]
        public string FbTitleNote { get; set; }

        [Required(ErrorMessage = "预算不能为空")]
        [ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public decimal FbBudgetAmt { get; set; }

        [Required(ErrorMessage = "实际不能为空")]
        [ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]
        public decimal FbActualAmt { get; set; }

        [Required(ErrorMessage = "差异不能为空")]
        [ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal FbDiffAmt { get; set; }

        [Required(ErrorMessage = "会计人员不能为空")]
        [ExcelColumn(Name = "会计人员")]
        [ExcelColumnName("会计人员")]
        public string FbAccountant { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? FbBalanceDate { get; set; }

        [ExcelColumn(Name = "删除")]
        [ExcelColumnName("删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string Remark { get; set; }

        [ExcelColumn(Name = "创建者")]
        [ExcelColumnName("创建者")]
        public string CreateBy { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("创建时间")]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "期间")]
        public string FbFyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string FbYmLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司代码")]
        public string FbCorpCodeLabel { get; set; }
    }
}