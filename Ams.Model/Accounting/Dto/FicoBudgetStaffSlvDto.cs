
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 人员预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 9:25:23
    /// </summary>
    public class FicoBudgetStaffSlvQueryDto : PagerInfo 
    {
        public string FbssTitle { get; set; }
        public string FbssClass { get; set; }
        public string FbssCategory { get; set; }
        public int? FbssFlag { get; set; }
        public int? FbssAudit { get; set; }
        public DateTime? BeginFbssAuditDate { get; set; }
        public DateTime? EndFbssAuditDate { get; set; }
    }

    /// <summary>
    /// 人员预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 9:25:23
    /// </summary>
    public class FicoBudgetStaffSlvDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbssSfId { get; set; }

        [Required(ErrorMessage = "FbssParentSfId不能为空")]
        [ExcelColumn(Name = "FbssParentSfId")]
        [ExcelColumnName("FbssParentSfId")]
        public long FbssParentSfId { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbssTitle { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbssClass { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        [ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string FbssCategory { get; set; }

        [Required(ErrorMessage = "保有不能为空")]
        [ExcelColumn(Name = "保有")]
        [ExcelColumnName("保有")]
        public int FbssKeepPersonnel { get; set; }

        [Required(ErrorMessage = "现有不能为空")]
        [ExcelColumn(Name = "现有")]
        [ExcelColumnName("现有")]
        public int FbssNowPersonnel { get; set; }

        [Required(ErrorMessage = "预算不能为空")]
        [ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public int FbssPersonnel { get; set; }

        [Required(ErrorMessage = "启用不能为空")]
        [ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]
        public int FbssFlag { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        [ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int FbssAudit { get; set; }

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

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "科目")]
        public string FbssTitleLabel { get; set; }
        [ExcelColumn(Name = "类别")]
        public string FbssCategoryLabel { get; set; }
        [ExcelColumn(Name = "启用")]
        public string FbssFlagLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 人员预算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 9:25:23
    /// </summary>
    public class FicoBudgetStaffSlvImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbssSfId { get; set; }

        [Required(ErrorMessage = "FbssParentSfId不能为空")]
        [ExcelColumn(Name = "FbssParentSfId")]
        [ExcelColumnName("FbssParentSfId")]
        public long FbssParentSfId { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbssTitle { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbssClass { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        [ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string FbssCategory { get; set; }

        [Required(ErrorMessage = "保有不能为空")]
        [ExcelColumn(Name = "保有")]
        [ExcelColumnName("保有")]
        public int FbssKeepPersonnel { get; set; }

        [Required(ErrorMessage = "现有不能为空")]
        [ExcelColumn(Name = "现有")]
        [ExcelColumnName("现有")]
        public int FbssNowPersonnel { get; set; }

        [Required(ErrorMessage = "预算不能为空")]
        [ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public int FbssPersonnel { get; set; }

        [Required(ErrorMessage = "启用不能为空")]
        [ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]
        public int FbssFlag { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        [ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int FbssAudit { get; set; }

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

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "科目")]
        public string FbssTitleLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "类别")]
        public string FbssCategoryLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "启用")]
        public string FbssFlagLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}