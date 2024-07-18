namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 加班预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:25:59
    /// </summary>
    public class FicoBudgetOvertimeQueryDto : PagerInfo
    {
        public string FboCorp { get; set; }
        public string FboDept { get; set; }
        public string FboFm { get; set; }
        public string FboTitle { get; set; }
        public string FboContent { get; set; }
        public DateTime? BeginFboAuditDate { get; set; }
        public DateTime? EndFboAuditDate { get; set; }
        public DateTime? BeginFboUndoDate { get; set; }
        public DateTime? EndFboUndoDate { get; set; }
    }

    /// <summary>
    /// 加班预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:25:59
    /// </summary>
    public class FicoBudgetOvertimeDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FboSFID { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FboCorp { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public string FboDept { get; set; }

        [Required(ErrorMessage = "财年不能为空")]
        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FboFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FboFm { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FboTitle { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FboClass { get; set; }

        [Required(ErrorMessage = "必要工数不能为空")]
        [ExcelColumn(Name = "必要工数")]
        [ExcelColumnName("必要工数")]
        public decimal FboRequiredst { get; set; }

        [Required(ErrorMessage = "保有人数不能为空")]
        [ExcelColumn(Name = "保有人数")]
        [ExcelColumnName("保有人数")]
        public int FboDirectEmployee { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        [ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]
        public int FboIndirectEmployee { get; set; }

        [Required(ErrorMessage = "上班天数不能为空")]
        [ExcelColumn(Name = "上班天数")]
        [ExcelColumnName("上班天数")]
        public int FboDays { get; set; }

        [Required(ErrorMessage = "加班事由不能为空")]
        [ExcelColumn(Name = "加班事由")]
        [ExcelColumnName("加班事由")]
        public string FboContent { get; set; }

        [Required(ErrorMessage = "保有工数不能为空")]
        [ExcelColumn(Name = "保有工数")]
        [ExcelColumnName("保有工数")]
        public decimal FboRetainst { get; set; }

        [Required(ErrorMessage = "工数差异不能为空")]
        [ExcelColumn(Name = "工数差异")]
        [ExcelColumnName("工数差异")]
        public decimal FboRetainstdiff { get; set; }

        [Required(ErrorMessage = "投入加班不能为空")]
        [ExcelColumn(Name = "投入加班")]
        [ExcelColumnName("投入加班")]
        public decimal FboOvertime { get; set; }

        [Required(ErrorMessage = "平均投入加班不能为空")]
        [ExcelColumn(Name = "平均投入加班")]
        [ExcelColumnName("平均投入加班")]
        public decimal FboDirectovertime { get; set; }

        [Required(ErrorMessage = "间接加班不能为空")]
        [ExcelColumn(Name = "间接加班")]
        [ExcelColumnName("间接加班")]
        public decimal FboIndirectovertime { get; set; }

        [Required(ErrorMessage = "投入总加班不能为空")]
        [ExcelColumn(Name = "投入总加班")]
        [ExcelColumnName("投入总加班")]
        public decimal FboOvertimetotal { get; set; }

        [Required(ErrorMessage = "启用标记不能为空")]
        [ExcelColumn(Name = "启用标记")]
        [ExcelColumnName("启用标记")]
        public int FboFlag { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        [ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int FboAudit { get; set; }

        [ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]
        public string FboAuditName { get; set; }

        [ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? FboAuditDate { get; set; }

        [ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]
        public string FboUndoName { get; set; }

        [ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]
        public DateTime? FboUndoDate { get; set; }

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
        public string FboCorpLabel { get; set; }

        [ExcelColumn(Name = "部门")]
        public string FboDeptLabel { get; set; }

        [ExcelColumn(Name = "年月")]
        public string FboFmLabel { get; set; }

        [ExcelColumn(Name = "科目")]
        public string FboTitleLabel { get; set; }

        [ExcelColumn(Name = "启用标记")]
        public string FboFlagLabel { get; set; }

        [ExcelColumn(Name = "审核")]
        public string FboAuditLabel { get; set; }

        [ExcelColumn(Name = "审核人员")]
        public string FboAuditNameLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 加班预算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:25:59
    /// </summary>
    public class FicoBudgetOvertimeImportTpl
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FboSFID { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FboCorp { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public string FboDept { get; set; }

        [Required(ErrorMessage = "财年不能为空")]
        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FboFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FboFm { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FboTitle { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FboClass { get; set; }

        [Required(ErrorMessage = "必要工数不能为空")]
        [ExcelColumn(Name = "必要工数")]
        [ExcelColumnName("必要工数")]
        public decimal FboRequiredst { get; set; }

        [Required(ErrorMessage = "保有人数不能为空")]
        [ExcelColumn(Name = "保有人数")]
        [ExcelColumnName("保有人数")]
        public int FboDirectEmployee { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        [ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]
        public int FboIndirectEmployee { get; set; }

        [Required(ErrorMessage = "上班天数不能为空")]
        [ExcelColumn(Name = "上班天数")]
        [ExcelColumnName("上班天数")]
        public int FboDays { get; set; }

        [Required(ErrorMessage = "加班事由不能为空")]
        [ExcelColumn(Name = "加班事由")]
        [ExcelColumnName("加班事由")]
        public string FboContent { get; set; }

        [Required(ErrorMessage = "保有工数不能为空")]
        [ExcelColumn(Name = "保有工数")]
        [ExcelColumnName("保有工数")]
        public decimal FboRetainst { get; set; }

        [Required(ErrorMessage = "工数差异不能为空")]
        [ExcelColumn(Name = "工数差异")]
        [ExcelColumnName("工数差异")]
        public decimal FboRetainstdiff { get; set; }

        [Required(ErrorMessage = "投入加班不能为空")]
        [ExcelColumn(Name = "投入加班")]
        [ExcelColumnName("投入加班")]
        public decimal FboOvertime { get; set; }

        [Required(ErrorMessage = "平均投入加班不能为空")]
        [ExcelColumn(Name = "平均投入加班")]
        [ExcelColumnName("平均投入加班")]
        public decimal FboDirectovertime { get; set; }

        [Required(ErrorMessage = "间接加班不能为空")]
        [ExcelColumn(Name = "间接加班")]
        [ExcelColumnName("间接加班")]
        public decimal FboIndirectovertime { get; set; }

        [Required(ErrorMessage = "投入总加班不能为空")]
        [ExcelColumn(Name = "投入总加班")]
        [ExcelColumnName("投入总加班")]
        public decimal FboOvertimetotal { get; set; }

        [Required(ErrorMessage = "启用标记不能为空")]
        [ExcelColumn(Name = "启用标记")]
        [ExcelColumnName("启用标记")]
        public int FboFlag { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        [ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int FboAudit { get; set; }

        [ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]
        public string FboAuditName { get; set; }

        [ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? FboAuditDate { get; set; }

        [ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]
        public string FboUndoName { get; set; }

        [ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]
        public DateTime? FboUndoDate { get; set; }

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
        public string FboCorpLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "部门")]
        public string FboDeptLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string FboFmLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "科目")]
        public string FboTitleLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "启用标记")]
        public string FboFlagLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "审核")]
        public string FboAuditLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "审核人员")]
        public string FboAuditNameLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}