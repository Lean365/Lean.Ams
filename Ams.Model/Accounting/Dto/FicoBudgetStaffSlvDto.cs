
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 人员预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:28:59
    /// </summary>
    public class FicoBudgetStaffSlvQueryDto : PagerInfo 
    {
        public string FbssYm { get; set; }
        public string FbssTitle { get; set; }
        public string FbssClass { get; set; }
        public string FbssCategory { get; set; }
        public int? FbssFlag { get; set; }
        public int? FbssAudit { get; set; }
        public DateTime? BeginFbssAuditDate { get; set; }
        public DateTime? EndFbssAuditDate { get; set; }
        public DateTime? BeginFbssUndoDate { get; set; }
        public DateTime? EndFbssUndoDate { get; set; }
    }

    /// <summary>
    /// 人员预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:28:59
    /// </summary>
    public class FicoBudgetStaffSlvDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbssSfId { get; set; }

        [ExcelIgnore]
        public long? FbssParentSfId { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbssYm { get; set; }

        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbssTitle { get; set; }

        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbssClass { get; set; }

        [ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string FbssCategory { get; set; }

        [ExcelColumn(Name = "保有")]
        [ExcelColumnName("保有")]
        public int? FbssKeepPersonnel { get; set; }

        [ExcelColumn(Name = "现有")]
        [ExcelColumnName("现有")]
        public int? FbssNowPersonnel { get; set; }

        [ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public int? FbssPersonnel { get; set; }

        [ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]
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
        public string FbssYmLabel { get; set; }
        [ExcelColumn(Name = "科目")]
        public string FbssTitleLabel { get; set; }
        [ExcelColumn(Name = "类别")]
        public string FbssCategoryLabel { get; set; }
        [ExcelColumn(Name = "启用")]
        public string FbssFlagLabel { get; set; }
    }

    /// <summary>
    /// 人员预算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:28:59
    /// </summary>
    public class FicoBudgetStaffSlvImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbssSfId { get; set; }

        [ExcelIgnore]
        public long? FbssParentSfId { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbssYm { get; set; }

        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbssTitle { get; set; }

        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbssClass { get; set; }

        [ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string FbssCategory { get; set; }

        [ExcelColumn(Name = "保有")]
        [ExcelColumnName("保有")]
        public int? FbssKeepPersonnel { get; set; }

        [ExcelColumn(Name = "现有")]
        [ExcelColumnName("现有")]
        public int? FbssNowPersonnel { get; set; }

        [ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public int? FbssPersonnel { get; set; }

        [ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]
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
        public string FbssYmLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "科目")]
        public string FbssTitleLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "类别")]
        public string FbssCategoryLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "启用")]
        public string FbssFlagLabel { get; set; }
    }

}