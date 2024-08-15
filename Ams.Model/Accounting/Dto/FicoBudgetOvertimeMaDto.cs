using Ams.Model.Accounting;

namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 加班预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:25:44
    /// </summary>
    public class FicoBudgetOvertimeMaQueryDto : PagerInfo 
    {
        public string FboFy { get; set; }
        public string FboCorp { get; set; }
        public string FboDept { get; set; }
    }

    /// <summary>
    /// 加班预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:25:44
    /// </summary>
    public class FicoBudgetOvertimeMaDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FboSfId { get; set; }

        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FboFy { get; set; }

        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FboCorp { get; set; }

        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public string FboDept { get; set; }

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
        public List<FicoBudgetOvertimeSlvDto> FicoBudgetOvertimeSlvNav { get; set; }
        [ExcelColumn(Name = "财年")]
        public string FboFyLabel { get; set; }
        [ExcelColumn(Name = "公司")]
        public string FboCorpLabel { get; set; }
        [ExcelColumn(Name = "部门")]
        public string FboDeptLabel { get; set; }
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
    /// @Date: 2024/8/9 13:25:44
    /// </summary>
    public class FicoBudgetOvertimeMaImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FboSfId { get; set; }

        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FboFy { get; set; }

        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FboCorp { get; set; }

        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public string FboDept { get; set; }

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
        public List<FicoBudgetOvertimeSlvDto> FicoBudgetOvertimeSlvNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "财年")]
        public string FboFyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司")]
        public string FboCorpLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "部门")]
        public string FboDeptLabel { get; set; }
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