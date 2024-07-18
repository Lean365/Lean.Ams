namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 人员预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:25:54
    /// </summary>
    public class FicoBudgetStaffQueryDto : PagerInfo
    {
        public string FbsCorp { get; set; }
        public string FbsDept { get; set; }
        public string FbsFm { get; set; }
        public string FbsTitle { get; set; }
        public string FbsCategory { get; set; }
        public int? FbsFlag { get; set; }
        public int? FbsAudit { get; set; }
        public DateTime? BeginFbsAuditDate { get; set; }
        public DateTime? EndFbsAuditDate { get; set; }
        public DateTime? BeginFbsUndoDate { get; set; }
        public DateTime? EndFbsUndoDate { get; set; }
    }

    /// <summary>
    /// 人员预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:25:54
    /// </summary>
    public class FicoBudgetStaffDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbsSFID { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FbsCorp { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public string FbsDept { get; set; }

        [Required(ErrorMessage = "财年不能为空")]
        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FbsFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbsFm { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbsTitle { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbsClass { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        [ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string FbsCategory { get; set; }

        [Required(ErrorMessage = "保有不能为空")]
        [ExcelColumn(Name = "保有")]
        [ExcelColumnName("保有")]
        public int FbsKeepPersonnel { get; set; }

        [Required(ErrorMessage = "现有不能为空")]
        [ExcelColumn(Name = "现有")]
        [ExcelColumnName("现有")]
        public int FbsNowPersonnel { get; set; }

        [Required(ErrorMessage = "预算不能为空")]
        [ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public int FbsPersonnel { get; set; }

        [Required(ErrorMessage = "启用不能为空")]
        [ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]
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
        public string FbsCorpLabel { get; set; }

        [ExcelColumn(Name = "部门")]
        public string FbsDeptLabel { get; set; }

        [ExcelColumn(Name = "年月")]
        public string FbsFmLabel { get; set; }

        [ExcelColumn(Name = "科目")]
        public string FbsTitleLabel { get; set; }

        [ExcelColumn(Name = "类别")]
        public string FbsCategoryLabel { get; set; }

        [ExcelColumn(Name = "启用")]
        public string FbsFlagLabel { get; set; }

        [ExcelColumn(Name = "审核")]
        public string FbsAuditLabel { get; set; }

        [ExcelColumn(Name = "审核人员")]
        public string FbsAuditNameLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 人员预算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:25:54
    /// </summary>
    public class FicoBudgetStaffImportTpl
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbsSFID { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FbsCorp { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public string FbsDept { get; set; }

        [Required(ErrorMessage = "财年不能为空")]
        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FbsFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbsFm { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbsTitle { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbsClass { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        [ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string FbsCategory { get; set; }

        [Required(ErrorMessage = "保有不能为空")]
        [ExcelColumn(Name = "保有")]
        [ExcelColumnName("保有")]
        public int FbsKeepPersonnel { get; set; }

        [Required(ErrorMessage = "现有不能为空")]
        [ExcelColumn(Name = "现有")]
        [ExcelColumnName("现有")]
        public int FbsNowPersonnel { get; set; }

        [Required(ErrorMessage = "预算不能为空")]
        [ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public int FbsPersonnel { get; set; }

        [Required(ErrorMessage = "启用不能为空")]
        [ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]
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
        public string FbsCorpLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "部门")]
        public string FbsDeptLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string FbsFmLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "科目")]
        public string FbsTitleLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "类别")]
        public string FbsCategoryLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "启用")]
        public string FbsFlagLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "审核")]
        public string FbsAuditLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "审核人员")]
        public string FbsAuditNameLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}