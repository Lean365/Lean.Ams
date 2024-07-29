
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 加班预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 9:28:52
    /// </summary>
    public class FicoBudgetOvertimeSlvQueryDto : PagerInfo 
    {
        public string FbosTitle { get; set; }
        public string FbosClass { get; set; }
        public int? FbosFlag { get; set; }
        public int? FbosAudit { get; set; }
        public DateTime? BeginFbosAuditDate { get; set; }
        public DateTime? EndFbosAuditDate { get; set; }
    }

    /// <summary>
    /// 加班预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 9:28:52
    /// </summary>
    public class FicoBudgetOvertimeSlvDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbosSfid { get; set; }

        [Required(ErrorMessage = "FbosParentSfid不能为空")]
        [ExcelColumn(Name = "FbosParentSfid")]
        [ExcelColumnName("FbosParentSfid")]
        public long FbosParentSfid { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbosTitle { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbosClass { get; set; }

        [Required(ErrorMessage = "必要工数不能为空")]
        [ExcelColumn(Name = "必要工数")]
        [ExcelColumnName("必要工数")]
        public decimal FbosRequiredst { get; set; }

        [Required(ErrorMessage = "保有人数不能为空")]
        [ExcelColumn(Name = "保有人数")]
        [ExcelColumnName("保有人数")]
        public int FbosDirectEmployee { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        [ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]
        public int FbosIndirectEmployee { get; set; }

        [Required(ErrorMessage = "上班天数不能为空")]
        [ExcelColumn(Name = "上班天数")]
        [ExcelColumnName("上班天数")]
        public int FbosDays { get; set; }

        [Required(ErrorMessage = "加班事由不能为空")]
        [ExcelColumn(Name = "加班事由")]
        [ExcelColumnName("加班事由")]
        public string FbosContent { get; set; }

        [Required(ErrorMessage = "保有工数不能为空")]
        [ExcelColumn(Name = "保有工数")]
        [ExcelColumnName("保有工数")]
        public decimal FbosRetainst { get; set; }

        [Required(ErrorMessage = "工数差异不能为空")]
        [ExcelColumn(Name = "工数差异")]
        [ExcelColumnName("工数差异")]
        public decimal FbosRetainstdiff { get; set; }

        [Required(ErrorMessage = "投入加班不能为空")]
        [ExcelColumn(Name = "投入加班")]
        [ExcelColumnName("投入加班")]
        public decimal FbosOvertime { get; set; }

        [Required(ErrorMessage = "平均投入加班不能为空")]
        [ExcelColumn(Name = "平均投入加班")]
        [ExcelColumnName("平均投入加班")]
        public decimal FbosDirectovertime { get; set; }

        [Required(ErrorMessage = "间接加班不能为空")]
        [ExcelColumn(Name = "间接加班")]
        [ExcelColumnName("间接加班")]
        public decimal FbosIndirectovertime { get; set; }

        [Required(ErrorMessage = "投入总加班不能为空")]
        [ExcelColumn(Name = "投入总加班")]
        [ExcelColumnName("投入总加班")]
        public decimal FbosOvertimetotal { get; set; }

        [Required(ErrorMessage = "启用标记不能为空")]
        [ExcelColumn(Name = "启用标记")]
        [ExcelColumnName("启用标记")]
        public int FbosFlag { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        [ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int FbosAudit { get; set; }

        [ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]
        public string FbosAuditName { get; set; }

        [ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? FbosAuditDate { get; set; }

        [ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]
        public string FbosUndoName { get; set; }

        [ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]
        public DateTime? FbosUndoDate { get; set; }

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
        public string FbosTitleLabel { get; set; }
        [ExcelColumn(Name = "启用标记")]
        public string FbosFlagLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 加班预算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 9:28:52
    /// </summary>
    public class FicoBudgetOvertimeSlvImportTpl
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbosSfid { get; set; }

        [Required(ErrorMessage = "FbosParentSfid不能为空")]
        [ExcelColumn(Name = "FbosParentSfid")]
        [ExcelColumnName("FbosParentSfid")]
        public long FbosParentSfid { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbosTitle { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbosClass { get; set; }

        [Required(ErrorMessage = "必要工数不能为空")]
        [ExcelColumn(Name = "必要工数")]
        [ExcelColumnName("必要工数")]
        public decimal FbosRequiredst { get; set; }

        [Required(ErrorMessage = "保有人数不能为空")]
        [ExcelColumn(Name = "保有人数")]
        [ExcelColumnName("保有人数")]
        public int FbosDirectEmployee { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        [ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]
        public int FbosIndirectEmployee { get; set; }

        [Required(ErrorMessage = "上班天数不能为空")]
        [ExcelColumn(Name = "上班天数")]
        [ExcelColumnName("上班天数")]
        public int FbosDays { get; set; }

        [Required(ErrorMessage = "加班事由不能为空")]
        [ExcelColumn(Name = "加班事由")]
        [ExcelColumnName("加班事由")]
        public string FbosContent { get; set; }

        [Required(ErrorMessage = "保有工数不能为空")]
        [ExcelColumn(Name = "保有工数")]
        [ExcelColumnName("保有工数")]
        public decimal FbosRetainst { get; set; }

        [Required(ErrorMessage = "工数差异不能为空")]
        [ExcelColumn(Name = "工数差异")]
        [ExcelColumnName("工数差异")]
        public decimal FbosRetainstdiff { get; set; }

        [Required(ErrorMessage = "投入加班不能为空")]
        [ExcelColumn(Name = "投入加班")]
        [ExcelColumnName("投入加班")]
        public decimal FbosOvertime { get; set; }

        [Required(ErrorMessage = "平均投入加班不能为空")]
        [ExcelColumn(Name = "平均投入加班")]
        [ExcelColumnName("平均投入加班")]
        public decimal FbosDirectovertime { get; set; }

        [Required(ErrorMessage = "间接加班不能为空")]
        [ExcelColumn(Name = "间接加班")]
        [ExcelColumnName("间接加班")]
        public decimal FbosIndirectovertime { get; set; }

        [Required(ErrorMessage = "投入总加班不能为空")]
        [ExcelColumn(Name = "投入总加班")]
        [ExcelColumnName("投入总加班")]
        public decimal FbosOvertimetotal { get; set; }

        [Required(ErrorMessage = "启用标记不能为空")]
        [ExcelColumn(Name = "启用标记")]
        [ExcelColumnName("启用标记")]
        public int FbosFlag { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        [ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int FbosAudit { get; set; }

        [ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]
        public string FbosAuditName { get; set; }

        [ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? FbosAuditDate { get; set; }

        [ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]
        public string FbosUndoName { get; set; }

        [ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]
        public DateTime? FbosUndoDate { get; set; }

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
        public string FbosTitleLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "启用标记")]
        public string FbosFlagLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}