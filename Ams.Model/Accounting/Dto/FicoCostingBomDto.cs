
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// bom核算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:34:34
    /// </summary>
    public class FicoCostingBomQueryDto : PagerInfo 
    {
        public string BcWerks { get; set; }
        public string BcLfgja { get; set; }
        public string BcLfmon { get; set; }
        public string BcPrdha { get; set; }
        public string BcMatnr { get; set; }
    }

    /// <summary>
    /// bom核算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:34:34
    /// </summary>
    public class FicoCostingBomDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long BcSfId { get; set; }

        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string BcWerks { get; set; }

        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string BcLfgja { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string BcLfmon { get; set; }

        [ExcelColumn(Name = "机种名称")]
        [ExcelColumnName("机种名称")]
        public string BcPrdha { get; set; }

        [ExcelColumn(Name = "成品物料")]
        [ExcelColumnName("成品物料")]
        public string BcMatnr { get; set; }

        [ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]
        public string BcMaktx { get; set; }

        [ExcelColumn(Name = "成本")]
        [ExcelColumnName("成本")]
        public decimal Bckost { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string BcWaers { get; set; }

        [ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("核算日期")]
        public DateTime? BcZkdat { get; set; }

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
        public string Remark { get; set; }

        [ExcelIgnore]
        public int? IsDeleted { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "工厂")]
        public string BcWerksLabel { get; set; }
        [ExcelColumn(Name = "期间")]
        public string BcLfgjaLabel { get; set; }
        [ExcelColumn(Name = "年月")]
        public string BcLfmonLabel { get; set; }
        [ExcelColumn(Name = "币种")]
        public string BcWaersLabel { get; set; }
    }

    /// <summary>
    /// bom核算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:34:34
    /// </summary>
    public class FicoCostingBomImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long BcSfId { get; set; }

        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string BcWerks { get; set; }

        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string BcLfgja { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string BcLfmon { get; set; }

        [ExcelColumn(Name = "机种名称")]
        [ExcelColumnName("机种名称")]
        public string BcPrdha { get; set; }

        [ExcelColumn(Name = "成品物料")]
        [ExcelColumnName("成品物料")]
        public string BcMatnr { get; set; }

        [ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]
        public string BcMaktx { get; set; }

        [ExcelColumn(Name = "成本")]
        [ExcelColumnName("成本")]
        public decimal Bckost { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string BcWaers { get; set; }

        [ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("核算日期")]
        public DateTime? BcZkdat { get; set; }

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
        public string Remark { get; set; }

        [ExcelIgnore]
        public int? IsDeleted { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string BcWerksLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "期间")]
        public string BcLfgjaLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string BcLfmonLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string BcWaersLabel { get; set; }
    }

}