namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 资产预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:07
    /// </summary>
    public class FicoBudgetAssetQueryDto : PagerInfo
    {
        public string FbaCorp { get; set; }
        public string FbaDept { get; set; }
        public string FbaFy { get; set; }
        public string FbaFm { get; set; }
        public string FbaTitle { get; set; }
        public string FbaClass { get; set; }
        public string FbaName { get; set; }
        public int? FbaFlag { get; set; }
        public int? FbaAudit { get; set; }
        public DateTime? BeginFbaAuditDate { get; set; }
        public DateTime? EndFbaAuditDate { get; set; }
        public DateTime? BeginFbaUndoDate { get; set; }
        public DateTime? EndFbaUndoDate { get; set; }
    }

    /// <summary>
    /// 资产预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:07
    /// </summary>
    public class FicoBudgetAssetDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbaSFID { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FbaCorp { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public string FbaDept { get; set; }

        [Required(ErrorMessage = "财年不能为空")]
        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FbaFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbaFm { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbaTitle { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        [ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string FbaClass { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbaName { get; set; }

        [Required(ErrorMessage = "说明不能为空")]
        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string FbaDesc { get; set; }

        [Required(ErrorMessage = "年限不能为空")]
        [ExcelColumn(Name = "年限")]
        [ExcelColumnName("年限")]
        public int FbaServiceLife { get; set; }

        [Required(ErrorMessage = "预算不能为空")]
        [ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public decimal FbaBudgetAmount { get; set; }

        [Required(ErrorMessage = "实际不能为空")]
        [ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]
        public decimal FbaActualAmount { get; set; }

        [Required(ErrorMessage = "差异不能为空")]
        [ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal FbaDifferenceAmount { get; set; }

        [Required(ErrorMessage = "折旧不能为空")]
        [ExcelColumn(Name = "折旧")]
        [ExcelColumnName("折旧")]
        public decimal FbaDepreciation { get; set; }

        [Required(ErrorMessage = "启用不能为空")]
        [ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]
        public int FbaFlag { get; set; }

        [Required(ErrorMessage = "审核标志不能为空")]
        [ExcelColumn(Name = "审核标志")]
        [ExcelColumnName("审核标志")]
        public int FbaAudit { get; set; }

        [ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]
        public string FbaAuditName { get; set; }

        [ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? FbaAuditDate { get; set; }

        [ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]
        public string FbaUndoName { get; set; }

        [ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]
        public DateTime? FbaUndoDate { get; set; }

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
        public string FbaCorpLabel { get; set; }

        [ExcelColumn(Name = "部门")]
        public string FbaDeptLabel { get; set; }

        [ExcelColumn(Name = "财年")]
        public string FbaFyLabel { get; set; }

        [ExcelColumn(Name = "年月")]
        public string FbaFmLabel { get; set; }

        [ExcelColumn(Name = "科目")]
        public string FbaTitleLabel { get; set; }

        [ExcelColumn(Name = "类别")]
        public string FbaClassLabel { get; set; }

        [ExcelColumn(Name = "启用")]
        public string FbaFlagLabel { get; set; }

        [ExcelColumn(Name = "审核标志")]
        public string FbaAuditLabel { get; set; }

        [ExcelColumn(Name = "审核人员")]
        public string FbaAuditNameLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 资产预算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:07
    /// </summary>
    public class FicoBudgetAssetImportTpl
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbaSFID { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FbaCorp { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public string FbaDept { get; set; }

        [Required(ErrorMessage = "财年不能为空")]
        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FbaFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbaFm { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbaTitle { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        [ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string FbaClass { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbaName { get; set; }

        [Required(ErrorMessage = "说明不能为空")]
        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string FbaDesc { get; set; }

        [Required(ErrorMessage = "年限不能为空")]
        [ExcelColumn(Name = "年限")]
        [ExcelColumnName("年限")]
        public int FbaServiceLife { get; set; }

        [Required(ErrorMessage = "预算不能为空")]
        [ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public decimal FbaBudgetAmount { get; set; }

        [Required(ErrorMessage = "实际不能为空")]
        [ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]
        public decimal FbaActualAmount { get; set; }

        [Required(ErrorMessage = "差异不能为空")]
        [ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal FbaDifferenceAmount { get; set; }

        [Required(ErrorMessage = "折旧不能为空")]
        [ExcelColumn(Name = "折旧")]
        [ExcelColumnName("折旧")]
        public decimal FbaDepreciation { get; set; }

        [Required(ErrorMessage = "启用不能为空")]
        [ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]
        public int FbaFlag { get; set; }

        [Required(ErrorMessage = "审核标志不能为空")]
        [ExcelColumn(Name = "审核标志")]
        [ExcelColumnName("审核标志")]
        public int FbaAudit { get; set; }

        [ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]
        public string FbaAuditName { get; set; }

        [ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? FbaAuditDate { get; set; }

        [ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]
        public string FbaUndoName { get; set; }

        [ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]
        public DateTime? FbaUndoDate { get; set; }

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
        public string FbaCorpLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "部门")]
        public string FbaDeptLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "财年")]
        public string FbaFyLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string FbaFmLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "科目")]
        public string FbaTitleLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "类别")]
        public string FbaClassLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "启用")]
        public string FbaFlagLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "审核标志")]
        public string FbaAuditLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "审核人员")]
        public string FbaAuditNameLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}