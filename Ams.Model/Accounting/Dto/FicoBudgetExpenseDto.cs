namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 费用预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:03
    /// </summary>
    public class FicoBudgetExpenseQueryDto : PagerInfo
    {
        public string FbeCorp { get; set; }
        public string FbeDept { get; set; }
        public string FbeFm { get; set; }
        public string FbeTitle { get; set; }
        public string FbeTitlesub { get; set; }
        public DateTime? BeginFbsAuditDate { get; set; }
        public DateTime? EndFbsAuditDate { get; set; }
        public DateTime? BeginFbsUndoDate { get; set; }
        public DateTime? EndFbsUndoDate { get; set; }
    }

    /// <summary>
    /// 费用预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:03
    /// </summary>
    public class FicoBudgetExpenseDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbeSFID { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FbeCorp { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public string FbeDept { get; set; }

        [Required(ErrorMessage = "财年不能为空")]
        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FbeFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbeFm { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbeTitle { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbeClass { get; set; }

        [Required(ErrorMessage = "明细科目不能为空")]
        [ExcelColumn(Name = "明细科目")]
        [ExcelColumnName("明细科目")]
        public string FbeTitlesub { get; set; }

        [Required(ErrorMessage = "明细名称不能为空")]
        [ExcelColumn(Name = "明细名称")]
        [ExcelColumnName("明细名称")]
        public string FbeClasssub { get; set; }

        [Required(ErrorMessage = "说明不能为空")]
        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string FbeClassmemo { get; set; }

        [Required(ErrorMessage = "预算金额不能为空")]
        [ExcelColumn(Name = "预算金额")]
        [ExcelColumnName("预算金额")]
        public decimal FbeBudgetAmount { get; set; }

        [Required(ErrorMessage = "实际发生不能为空")]
        [ExcelColumn(Name = "实际发生")]
        [ExcelColumnName("实际发生")]
        public decimal FbeActualAmount { get; set; }

        [Required(ErrorMessage = "差异不能为空")]
        [ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal FbeDifferenceAmount { get; set; }

        [Required(ErrorMessage = "启用标记不能为空")]
        [ExcelColumn(Name = "启用标记")]
        [ExcelColumnName("启用标记")]
        public int FbsFlag { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        [ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int FbsAudit { get; set; }

        [ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]
        public string FbsAuditName { get; set; }

        [ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? FbsAuditDate { get; set; }

        [ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]
        public string FbsUndoName { get; set; }

        [ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]
        public DateTime? FbsUndoDate { get; set; }

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

        [ExcelColumn(Name = "公司")]
        public string FbeCorpLabel { get; set; }

        [ExcelColumn(Name = "部门")]
        public string FbeDeptLabel { get; set; }

        [ExcelColumn(Name = "年月")]
        public string FbeFmLabel { get; set; }

        [ExcelColumn(Name = "科目")]
        public string FbeTitleLabel { get; set; }

        [ExcelColumn(Name = "启用标记")]
        public string FbsFlagLabel { get; set; }

        [ExcelColumn(Name = "审核")]
        public string FbsAuditLabel { get; set; }

        [ExcelColumn(Name = "审核人员")]
        public string FbsAuditNameLabel { get; set; }

        [ExcelColumn(Name = "撤消人员")]
        public string FbsUndoNameLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 费用预算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:03
    /// </summary>
    public class FicoBudgetExpenseImportTpl
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbeSFID { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FbeCorp { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public string FbeDept { get; set; }

        [Required(ErrorMessage = "财年不能为空")]
        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FbeFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbeFm { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbeTitle { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbeClass { get; set; }

        [Required(ErrorMessage = "明细科目不能为空")]
        [ExcelColumn(Name = "明细科目")]
        [ExcelColumnName("明细科目")]
        public string FbeTitlesub { get; set; }

        [Required(ErrorMessage = "明细名称不能为空")]
        [ExcelColumn(Name = "明细名称")]
        [ExcelColumnName("明细名称")]
        public string FbeClasssub { get; set; }

        [Required(ErrorMessage = "说明不能为空")]
        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string FbeClassmemo { get; set; }

        [Required(ErrorMessage = "预算金额不能为空")]
        [ExcelColumn(Name = "预算金额")]
        [ExcelColumnName("预算金额")]
        public decimal FbeBudgetAmount { get; set; }

        [Required(ErrorMessage = "实际发生不能为空")]
        [ExcelColumn(Name = "实际发生")]
        [ExcelColumnName("实际发生")]
        public decimal FbeActualAmount { get; set; }

        [Required(ErrorMessage = "差异不能为空")]
        [ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal FbeDifferenceAmount { get; set; }

        [Required(ErrorMessage = "启用标记不能为空")]
        [ExcelColumn(Name = "启用标记")]
        [ExcelColumnName("启用标记")]
        public int FbsFlag { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        [ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int FbsAudit { get; set; }

        [ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]
        public string FbsAuditName { get; set; }

        [ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? FbsAuditDate { get; set; }

        [ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]
        public string FbsUndoName { get; set; }

        [ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]
        public DateTime? FbsUndoDate { get; set; }

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
        [ExcelColumn(Name = "公司")]
        public string FbeCorpLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "部门")]
        public string FbeDeptLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string FbeFmLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "科目")]
        public string FbeTitleLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "启用标记")]
        public string FbsFlagLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "审核")]
        public string FbsAuditLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "审核人员")]
        public string FbsAuditNameLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "撤消人员")]
        public string FbsUndoNameLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}