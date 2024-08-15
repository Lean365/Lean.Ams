using Ams.Model.Accounting;

namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 费用预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:31:03
    /// </summary>
    public class FicoBudgetExpenseMaQueryDto : PagerInfo 
    {
        public string FbeFy { get; set; }
        public string FbeCorp { get; set; }
        public string FbeDept { get; set; }
    }

    /// <summary>
    /// 费用预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:31:03
    /// </summary>
    public class FicoBudgetExpenseMaDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbeSfId { get; set; }

        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FbeFy { get; set; }

        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FbeCorp { get; set; }

        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public string FbeDept { get; set; }

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
        public List<FicoBudgetExpenseSlvDto> FicoBudgetExpenseSlvNav { get; set; }
        [ExcelColumn(Name = "财年")]
        public string FbeFyLabel { get; set; }
        [ExcelColumn(Name = "公司")]
        public string FbeCorpLabel { get; set; }
        [ExcelColumn(Name = "部门")]
        public string FbeDeptLabel { get; set; }
        [ExcelColumn(Name = "科目")]
        public string FbesTitleLabel { get; set; }
        [ExcelColumn(Name = "明细科目")]
        public string FbesTitlesubLabel { get; set; }
        [ExcelColumn(Name = "启用标记")]
        public string FbssFlagLabel { get; set; }
    }

    /// <summary>
    /// 费用预算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:31:03
    /// </summary>
    public class FicoBudgetExpenseMaImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbeSfId { get; set; }

        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FbeFy { get; set; }

        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FbeCorp { get; set; }

        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public string FbeDept { get; set; }

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
        public List<FicoBudgetExpenseSlvDto> FicoBudgetExpenseSlvNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "财年")]
        public string FbeFyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司")]
        public string FbeCorpLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "部门")]
        public string FbeDeptLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "科目")]
        public string FbesTitleLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "明细科目")]
        public string FbesTitlesubLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "启用标记")]
        public string FbssFlagLabel { get; set; }
    }

}