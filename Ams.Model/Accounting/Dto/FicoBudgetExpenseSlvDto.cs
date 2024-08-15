
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 费用预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:28:29
    /// </summary>
    public class FicoBudgetExpenseSlvQueryDto : PagerInfo 
    {
        public string FbesYm { get; set; }
        public string FbesTitle { get; set; }
        public string FbesClass { get; set; }
        public string FbesTitlesub { get; set; }
        public string FbesClasssub { get; set; }
        public int? FbssFlag { get; set; }
        public int? FbssAudit { get; set; }
        public DateTime? BeginFbssAuditDate { get; set; }
        public DateTime? EndFbssAuditDate { get; set; }
        public DateTime? BeginFbssUndoDate { get; set; }
        public DateTime? EndFbssUndoDate { get; set; }
    }

    /// <summary>
    /// 费用预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:28:29
    /// </summary>
    public class FicoBudgetExpenseSlvDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbesSfId { get; set; }

        [ExcelIgnore]
        public long? FbesParentSfId { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbesYm { get; set; }

        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbesTitle { get; set; }

        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbesClass { get; set; }

        [ExcelColumn(Name = "明细科目")]
        [ExcelColumnName("明细科目")]
        public string FbesTitlesub { get; set; }

        [ExcelColumn(Name = "明细名称")]
        [ExcelColumnName("明细名称")]
        public string FbesClasssub { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string FbesClassmemo { get; set; }

        [ExcelColumn(Name = "预算金额")]
        [ExcelColumnName("预算金额")]
        public decimal FbesBudgetAmount { get; set; }

        [ExcelColumn(Name = "实际发生")]
        [ExcelColumnName("实际发生")]
        public decimal FbesActualAmount { get; set; }

        [ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal FbesDifferenceAmount { get; set; }

        [ExcelColumn(Name = "启用标记")]
        [ExcelColumnName("启用标记")]
        public int? FbssFlag { get; set; }

        [ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int? FbssAudit { get; set; }

        [ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]
        public string FbssAuditName { get; set; }

        [ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? FbssAuditDate { get; set; }

        [ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]
        public string FbssUndoName { get; set; }

        [ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]
        public DateTime? FbssUndoDate { get; set; }

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



        [ExcelColumn(Name = "年月")]
        public string FbesYmLabel { get; set; }
        [ExcelColumn(Name = "科目")]
        public string FbesTitleLabel { get; set; }
        [ExcelColumn(Name = "明细科目")]
        public string FbesTitlesubLabel { get; set; }
        [ExcelColumn(Name = "启用标记")]
        public string FbssFlagLabel { get; set; }
    }

    /// <summary>
    /// 费用预算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:28:29
    /// </summary>
    public class FicoBudgetExpenseSlvImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbesSfId { get; set; }

        [ExcelIgnore]
        public long? FbesParentSfId { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbesYm { get; set; }

        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbesTitle { get; set; }

        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbesClass { get; set; }

        [ExcelColumn(Name = "明细科目")]
        [ExcelColumnName("明细科目")]
        public string FbesTitlesub { get; set; }

        [ExcelColumn(Name = "明细名称")]
        [ExcelColumnName("明细名称")]
        public string FbesClasssub { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string FbesClassmemo { get; set; }

        [ExcelColumn(Name = "预算金额")]
        [ExcelColumnName("预算金额")]
        public decimal FbesBudgetAmount { get; set; }

        [ExcelColumn(Name = "实际发生")]
        [ExcelColumnName("实际发生")]
        public decimal FbesActualAmount { get; set; }

        [ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal FbesDifferenceAmount { get; set; }

        [ExcelColumn(Name = "启用标记")]
        [ExcelColumnName("启用标记")]
        public int? FbssFlag { get; set; }

        [ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int? FbssAudit { get; set; }

        [ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]
        public string FbssAuditName { get; set; }

        [ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? FbssAuditDate { get; set; }

        [ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]
        public string FbssUndoName { get; set; }

        [ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]
        public DateTime? FbssUndoDate { get; set; }

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
        [ExcelColumn(Name = "年月")]
        public string FbesYmLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "科目")]
        public string FbesTitleLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "明细科目")]
        public string FbesTitlesubLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "启用标记")]
        public string FbssFlagLabel { get; set; }
    }

}