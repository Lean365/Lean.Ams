
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 实际对比
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 17:07:36
    /// </summary>
    public class FicoBudgetActualContQueryDto : PagerInfo 
    {
        public string FbFy { get; set; }
        public string FbYm { get; set; }
        public string FbCorpCode { get; set; }
        public string FbStatCategory { get; set; }
        public string FbCostCode { get; set; }
        public string FbCostType { get; set; }
        public string FbTitleCode { get; set; }
        public string FbCcy { get; set; }
    }

    /// <summary>
    /// 实际对比
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 17:07:36
    /// </summary>
    public class FicoBudgetActualContDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbSfId { get; set; }

        [ExcelColumn(Name = "期间 ")]
        [ExcelColumnName("期间 ")]
        public string FbFy { get; set; }

        [ExcelColumn(Name = "年月 ")]
        [ExcelColumnName("年月 ")]
        public string FbYm { get; set; }

        [ExcelColumn(Name = "公司代码 ")]
        [ExcelColumnName("公司代码 ")]
        public string FbCorpCode { get; set; }

        [ExcelColumn(Name = "统计类别 ")]
        [ExcelColumnName("统计类别 ")]
        public string FbStatCategory { get; set; }

        [ExcelColumn(Name = "成本代码 ")]
        [ExcelColumnName("成本代码 ")]
        public string FbCostCode { get; set; }

        [ExcelColumn(Name = "成本分类 ")]
        [ExcelColumnName("成本分类 ")]
        public string FbCostType { get; set; }

        [ExcelColumn(Name = "科目代码 ")]
        [ExcelColumnName("科目代码 ")]
        public string FbTitleCode { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string FbCcy { get; set; }

        [ExcelColumn(Name = "预算 ")]
        [ExcelColumnName("预算 ")]
        public decimal FbBudgetAmt { get; set; }

        [ExcelColumn(Name = "实际 ")]
        [ExcelColumnName("实际 ")]
        public decimal FbActualAmt { get; set; }

        [ExcelColumn(Name = "差异 ")]
        [ExcelColumnName("差异 ")]
        public decimal FbDiffAmt { get; set; }

        [ExcelColumn(Name = "会计人员 ")]
        [ExcelColumnName("会计人员 ")]
        public string FbAccountant { get; set; }

        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? FbBalanceDate { get; set; }

        [ExcelColumn(Name = "预留A ")]
        [ExcelColumnName("预留A ")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B ")]
        [ExcelColumnName("预留B ")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C ")]
        [ExcelColumnName("预留C ")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1 ")]
        [ExcelColumnName("预留1 ")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2 ")]
        [ExcelColumnName("预留2 ")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3")]
        [ExcelColumnName("预留3")]
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

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明")]
        [ExcelColumnName("备注说明")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "期间 ")]
        public string FbFyLabel { get; set; }
        [ExcelColumn(Name = "年月 ")]
        public string FbYmLabel { get; set; }
        [ExcelColumn(Name = "公司代码 ")]
        public string FbCorpCodeLabel { get; set; }
        [ExcelColumn(Name = "统计类别 ")]
        public string FbStatCategoryLabel { get; set; }
        [ExcelColumn(Name = "成本代码 ")]
        public string FbCostCodeLabel { get; set; }
        [ExcelColumn(Name = "成本分类 ")]
        public string FbCostTypeLabel { get; set; }
        [ExcelColumn(Name = "科目代码 ")]
        public string FbTitleCodeLabel { get; set; }
        [ExcelColumn(Name = "币种")]
        public string FbCcyLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 实际对比
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 17:07:36
    /// </summary>
    public class FicoBudgetActualContImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbSfId { get; set; }

        [ExcelColumn(Name = "期间 ")]
        [ExcelColumnName("期间 ")]
        public string FbFy { get; set; }

        [ExcelColumn(Name = "年月 ")]
        [ExcelColumnName("年月 ")]
        public string FbYm { get; set; }

        [ExcelColumn(Name = "公司代码 ")]
        [ExcelColumnName("公司代码 ")]
        public string FbCorpCode { get; set; }

        [ExcelColumn(Name = "统计类别 ")]
        [ExcelColumnName("统计类别 ")]
        public string FbStatCategory { get; set; }

        [ExcelColumn(Name = "成本代码 ")]
        [ExcelColumnName("成本代码 ")]
        public string FbCostCode { get; set; }

        [ExcelColumn(Name = "成本分类 ")]
        [ExcelColumnName("成本分类 ")]
        public string FbCostType { get; set; }

        [ExcelColumn(Name = "科目代码 ")]
        [ExcelColumnName("科目代码 ")]
        public string FbTitleCode { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string FbCcy { get; set; }

        [ExcelColumn(Name = "预算 ")]
        [ExcelColumnName("预算 ")]
        public decimal FbBudgetAmt { get; set; }

        [ExcelColumn(Name = "实际 ")]
        [ExcelColumnName("实际 ")]
        public decimal FbActualAmt { get; set; }

        [ExcelColumn(Name = "差异 ")]
        [ExcelColumnName("差异 ")]
        public decimal FbDiffAmt { get; set; }

        [ExcelColumn(Name = "会计人员 ")]
        [ExcelColumnName("会计人员 ")]
        public string FbAccountant { get; set; }

        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? FbBalanceDate { get; set; }

        [ExcelColumn(Name = "预留A ")]
        [ExcelColumnName("预留A ")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B ")]
        [ExcelColumnName("预留B ")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C ")]
        [ExcelColumnName("预留C ")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1 ")]
        [ExcelColumnName("预留1 ")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2 ")]
        [ExcelColumnName("预留2 ")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3")]
        [ExcelColumnName("预留3")]
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

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明")]
        [ExcelColumnName("备注说明")]
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
        [ExcelColumn(Name = "期间 ")]
        public string FbFyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月 ")]
        public string FbYmLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司代码 ")]
        public string FbCorpCodeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "统计类别 ")]
        public string FbStatCategoryLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "成本代码 ")]
        public string FbCostCodeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "成本分类 ")]
        public string FbCostTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "科目代码 ")]
        public string FbTitleCodeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string FbCcyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}