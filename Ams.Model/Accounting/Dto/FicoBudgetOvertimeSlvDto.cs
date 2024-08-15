
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 加班预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 12:06:46
    /// </summary>
    public class FicoBudgetOvertimeSlvQueryDto : PagerInfo 
    {
        public string FbosYm { get; set; }
        public string FbosTitle { get; set; }
        public string FbosClass { get; set; }
        public DateTime? BeginFbosAuditDate { get; set; }
        public DateTime? EndFbosAuditDate { get; set; }
        public DateTime? BeginFbosUndoDate { get; set; }
        public DateTime? EndFbosUndoDate { get; set; }
    }

    /// <summary>
    /// 加班预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 12:06:46
    /// </summary>
    public class FicoBudgetOvertimeSlvDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbosSfId { get; set; }

        [ExcelIgnore]
        public long? FbosParentSfId { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbosYm { get; set; }

        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbosTitle { get; set; }

        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbosClass { get; set; }

        [ExcelColumn(Name = "必要工数")]
        [ExcelColumnName("必要工数")]
        public decimal FbosRequiredst { get; set; }

        [ExcelColumn(Name = "保有人数")]
        [ExcelColumnName("保有人数")]
        public int? FbosDirectEmployee { get; set; }

        [ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]
        public int? FbosIndirectEmployee { get; set; }

        [ExcelColumn(Name = "上班天数")]
        [ExcelColumnName("上班天数")]
        public int? FbosDays { get; set; }

        [ExcelColumn(Name = "加班事由")]
        [ExcelColumnName("加班事由")]
        public string FbosContent { get; set; }

        [ExcelColumn(Name = "保有工数")]
        [ExcelColumnName("保有工数")]
        public decimal FbosRetainst { get; set; }

        [ExcelColumn(Name = "工数差异")]
        [ExcelColumnName("工数差异")]
        public decimal FbosRetainstdiff { get; set; }

        [ExcelColumn(Name = "投入加班")]
        [ExcelColumnName("投入加班")]
        public decimal FbosOvertime { get; set; }

        [ExcelColumn(Name = "平均投入加班")]
        [ExcelColumnName("平均投入加班")]
        public decimal FbosDirectovertime { get; set; }

        [ExcelColumn(Name = "间接加班")]
        [ExcelColumnName("间接加班")]
        public decimal FbosIndirectovertime { get; set; }

        [ExcelColumn(Name = "投入总加班")]
        [ExcelColumnName("投入总加班")]
        public decimal FbosOvertimetotal { get; set; }

        [ExcelColumn(Name = "启用标记")]
        [ExcelColumnName("启用标记")]
        public int? FbosFlag { get; set; }

        [ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int? FbosAudit { get; set; }

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
        public string FbosYmLabel { get; set; }
        [ExcelColumn(Name = "科目")]
        public string FbosTitleLabel { get; set; }
        [ExcelColumn(Name = "启用标记")]
        public string FbosFlagLabel { get; set; }
    }

    /// <summary>
    /// 加班预算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 12:06:46
    /// </summary>
    public class FicoBudgetOvertimeSlvImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbosSfId { get; set; }

        [ExcelIgnore]
        public long? FbosParentSfId { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbosYm { get; set; }

        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbosTitle { get; set; }

        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbosClass { get; set; }

        [ExcelColumn(Name = "必要工数")]
        [ExcelColumnName("必要工数")]
        public decimal FbosRequiredst { get; set; }

        [ExcelColumn(Name = "保有人数")]
        [ExcelColumnName("保有人数")]
        public int? FbosDirectEmployee { get; set; }

        [ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]
        public int? FbosIndirectEmployee { get; set; }

        [ExcelColumn(Name = "上班天数")]
        [ExcelColumnName("上班天数")]
        public int? FbosDays { get; set; }

        [ExcelColumn(Name = "加班事由")]
        [ExcelColumnName("加班事由")]
        public string FbosContent { get; set; }

        [ExcelColumn(Name = "保有工数")]
        [ExcelColumnName("保有工数")]
        public decimal FbosRetainst { get; set; }

        [ExcelColumn(Name = "工数差异")]
        [ExcelColumnName("工数差异")]
        public decimal FbosRetainstdiff { get; set; }

        [ExcelColumn(Name = "投入加班")]
        [ExcelColumnName("投入加班")]
        public decimal FbosOvertime { get; set; }

        [ExcelColumn(Name = "平均投入加班")]
        [ExcelColumnName("平均投入加班")]
        public decimal FbosDirectovertime { get; set; }

        [ExcelColumn(Name = "间接加班")]
        [ExcelColumnName("间接加班")]
        public decimal FbosIndirectovertime { get; set; }

        [ExcelColumn(Name = "投入总加班")]
        [ExcelColumnName("投入总加班")]
        public decimal FbosOvertimetotal { get; set; }

        [ExcelColumn(Name = "启用标记")]
        [ExcelColumnName("启用标记")]
        public int? FbosFlag { get; set; }

        [ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int? FbosAudit { get; set; }

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
        public string FbosYmLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "科目")]
        public string FbosTitleLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "启用标记")]
        public string FbosFlagLabel { get; set; }
    }

}