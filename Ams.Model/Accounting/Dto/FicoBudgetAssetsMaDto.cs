using Ams.Model.Accounting;

namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 资产预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:25:02
    /// </summary>
    public class FicoBudgetAssetsMaQueryDto : PagerInfo 
    {
        public string FbaFy { get; set; }
        public string FbaCorp { get; set; }
        public string FbaDept { get; set; }
    }

    /// <summary>
    /// 资产预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:25:02
    /// </summary>
    public class FicoBudgetAssetsMaDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbaSfId { get; set; }

        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FbaFy { get; set; }

        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FbaCorp { get; set; }

        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public string FbaDept { get; set; }

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
        public List<FicoBudgetAssetsSlvDto> FicoBudgetAssetsSlvNav { get; set; }
        [ExcelColumn(Name = "财年")]
        public string FbaFyLabel { get; set; }
        [ExcelColumn(Name = "公司")]
        public string FbaCorpLabel { get; set; }
        [ExcelColumn(Name = "部门")]
        public string FbaDeptLabel { get; set; }
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
    /// @Date: 2024/8/9 13:25:02
    /// </summary>
    public class FicoBudgetAssetsMaImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbaSfId { get; set; }

        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FbaFy { get; set; }

        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FbaCorp { get; set; }

        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public string FbaDept { get; set; }

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
        public List<FicoBudgetAssetsSlvDto> FicoBudgetAssetsSlvNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "财年")]
        public string FbaFyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司")]
        public string FbaCorpLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "部门")]
        public string FbaDeptLabel { get; set; }
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