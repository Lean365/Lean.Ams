
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 实际对比
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:50:08
    /// </summary>
    public class FicoBudgetActualContQueryDto : PagerInfo 
    {
        public string FbLfgja { get; set; }
        public string FbLfmon { get; set; }
        public string FbBukrs { get; set; }
        public string FbStatyp { get; set; }
        public string FbKtosl { get; set; }
        public string FbKotyp { get; set; }
        public string FbKonto { get; set; }
    }

    /// <summary>
    /// 实际对比
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:50:08
    /// </summary>
    public class FicoBudgetActualContDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbSfId { get; set; }

        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string FbLfgja { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbLfmon { get; set; }

        [ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string FbBukrs { get; set; }

        [ExcelColumn(Name = "统计类别")]
        [ExcelColumnName("统计类别")]
        public string FbStatyp { get; set; }

        [ExcelColumn(Name = "成本科目")]
        [ExcelColumnName("成本科目")]
        public string FbKtosl { get; set; }

        [ExcelColumn(Name = "成本分类")]
        [ExcelColumnName("成本分类")]
        public string FbKotyp { get; set; }

        [ExcelColumn(Name = "科目代码")]
        [ExcelColumnName("科目代码")]
        public string FbKonto { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string FbWerks { get; set; }

        [ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public decimal FbAnval { get; set; }

        [ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]
        public decimal FbDmist { get; set; }

        [ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal FbBfaac { get; set; }

        [ExcelColumn(Name = "核算人员")]
        [ExcelColumnName("核算人员")]
        public string FbPresp { get; set; }

        [ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("核算日期")]
        public DateTime? FbZkdat { get; set; }

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



        [ExcelColumn(Name = "期间")]
        public string FbLfgjaLabel { get; set; }
        [ExcelColumn(Name = "年月")]
        public string FbLfmonLabel { get; set; }
        [ExcelColumn(Name = "公司代码")]
        public string FbBukrsLabel { get; set; }
        [ExcelColumn(Name = "统计类别")]
        public string FbStatypLabel { get; set; }
        [ExcelColumn(Name = "成本分类")]
        public string FbKotypLabel { get; set; }
        [ExcelColumn(Name = "币种")]
        public string FbWerksLabel { get; set; }
    }

    /// <summary>
    /// 实际对比
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:50:08
    /// </summary>
    public class FicoBudgetActualContImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbSfId { get; set; }

        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string FbLfgja { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FbLfmon { get; set; }

        [ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string FbBukrs { get; set; }

        [ExcelColumn(Name = "统计类别")]
        [ExcelColumnName("统计类别")]
        public string FbStatyp { get; set; }

        [ExcelColumn(Name = "成本科目")]
        [ExcelColumnName("成本科目")]
        public string FbKtosl { get; set; }

        [ExcelColumn(Name = "成本分类")]
        [ExcelColumnName("成本分类")]
        public string FbKotyp { get; set; }

        [ExcelColumn(Name = "科目代码")]
        [ExcelColumnName("科目代码")]
        public string FbKonto { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string FbWerks { get; set; }

        [ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public decimal FbAnval { get; set; }

        [ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]
        public decimal FbDmist { get; set; }

        [ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal FbBfaac { get; set; }

        [ExcelColumn(Name = "核算人员")]
        [ExcelColumnName("核算人员")]
        public string FbPresp { get; set; }

        [ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("核算日期")]
        public DateTime? FbZkdat { get; set; }

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
        [ExcelColumn(Name = "期间")]
        public string FbLfgjaLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string FbLfmonLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司代码")]
        public string FbBukrsLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "统计类别")]
        public string FbStatypLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "成本分类")]
        public string FbKotypLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string FbWerksLabel { get; set; }
    }

}