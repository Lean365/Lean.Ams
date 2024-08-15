
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 资产预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:23:49
    /// </summary>
    public class FicoBudgetAssetsSlvQueryDto : PagerInfo 
    {
        public string FbasYm { get; set; }
        public string FbasTitle { get; set; }
        public string FbasClass { get; set; }
        public string FbasName { get; set; }
        public int? FbasFlag { get; set; }
        public int? FbasAudit { get; set; }
        public DateTime? BeginFbasAuditDate { get; set; }
        public DateTime? EndFbasAuditDate { get; set; }
        public DateTime? BeginFbasUndoDate { get; set; }
        public DateTime? EndFbasUndoDate { get; set; }
    }

    /// <summary>
    /// 资产预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:23:49
    /// </summary>
    public class FicoBudgetAssetsSlvDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbasSfId { get; set; }

        [ExcelIgnore]
        public long? FbasParentSfId { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbasYm { get; set; }

        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbasTitle { get; set; }

        [ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string FbasClass { get; set; }

        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbasName { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string FbasDesc { get; set; }

        [ExcelColumn(Name = "年限")]
        [ExcelColumnName("年限")]
        public int? FbasServiceLife { get; set; }

        [ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public decimal FbasBudgetAmount { get; set; }

        [ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]
        public decimal FbasActualAmount { get; set; }

        [ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal FbasDifferenceAmount { get; set; }

        [ExcelColumn(Name = "折旧")]
        [ExcelColumnName("折旧")]
        public decimal FbasDepreciation { get; set; }

        [ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]
        public int? FbasFlag { get; set; }

        [ExcelColumn(Name = "审核标志")]
        [ExcelColumnName("审核标志")]
        public int? FbasAudit { get; set; }

        [ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]
        public string FbasAuditName { get; set; }

        [ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? FbasAuditDate { get; set; }

        [ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]
        public string FbasUndoName { get; set; }

        [ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]
        public DateTime? FbasUndoDate { get; set; }

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
        public string FbasYmLabel { get; set; }
        [ExcelColumn(Name = "科目")]
        public string FbasTitleLabel { get; set; }
        [ExcelColumn(Name = "类别")]
        public string FbasClassLabel { get; set; }
        [ExcelColumn(Name = "启用")]
        public string FbasFlagLabel { get; set; }
    }

    /// <summary>
    /// 资产预算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:23:49
    /// </summary>
    public class FicoBudgetAssetsSlvImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbasSfId { get; set; }

        [ExcelIgnore]
        public long? FbasParentSfId { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbasYm { get; set; }

        [ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string FbasTitle { get; set; }

        [ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string FbasClass { get; set; }

        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string FbasName { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string FbasDesc { get; set; }

        [ExcelColumn(Name = "年限")]
        [ExcelColumnName("年限")]
        public int? FbasServiceLife { get; set; }

        [ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public decimal FbasBudgetAmount { get; set; }

        [ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]
        public decimal FbasActualAmount { get; set; }

        [ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal FbasDifferenceAmount { get; set; }

        [ExcelColumn(Name = "折旧")]
        [ExcelColumnName("折旧")]
        public decimal FbasDepreciation { get; set; }

        [ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]
        public int? FbasFlag { get; set; }

        [ExcelColumn(Name = "审核标志")]
        [ExcelColumnName("审核标志")]
        public int? FbasAudit { get; set; }

        [ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]
        public string FbasAuditName { get; set; }

        [ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? FbasAuditDate { get; set; }

        [ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]
        public string FbasUndoName { get; set; }

        [ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]
        public DateTime? FbasUndoDate { get; set; }

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
        public string FbasYmLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "科目")]
        public string FbasTitleLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "类别")]
        public string FbasClassLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "启用")]
        public string FbasFlagLabel { get; set; }
    }

}