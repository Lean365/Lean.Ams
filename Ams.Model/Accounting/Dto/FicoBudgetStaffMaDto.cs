using Ams.Model.Accounting;

namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 人员预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:30:08
    /// </summary>
    public class FicoBudgetStaffMaQueryDto : PagerInfo 
    {
        public string FbsFy { get; set; }
        public string FbsCorp { get; set; }
        public string FbsDept { get; set; }
    }

    /// <summary>
    /// 人员预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:30:08
    /// </summary>
    public class FicoBudgetStaffMaDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbsSfId { get; set; }

        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FbsFy { get; set; }

        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FbsCorp { get; set; }

        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public string FbsDept { get; set; }

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
        public List<FicoBudgetStaffSlvDto> FicoBudgetStaffSlvNav { get; set; }
        [ExcelColumn(Name = "财年")]
        public string FbsFyLabel { get; set; }
        [ExcelColumn(Name = "公司")]
        public string FbsCorpLabel { get; set; }
        [ExcelColumn(Name = "部门")]
        public string FbsDeptLabel { get; set; }
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
    /// @Date: 2024/8/9 13:30:08
    /// </summary>
    public class FicoBudgetStaffMaImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbsSfId { get; set; }

        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FbsFy { get; set; }

        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FbsCorp { get; set; }

        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public string FbsDept { get; set; }

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
        public List<FicoBudgetStaffSlvDto> FicoBudgetStaffSlvNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "财年")]
        public string FbsFyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司")]
        public string FbsCorpLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "部门")]
        public string FbsDeptLabel { get; set; }
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