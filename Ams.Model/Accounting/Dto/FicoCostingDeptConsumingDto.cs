
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 部门消耗
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 12:03:53
    /// </summary>
    public class FicoCostingDeptConsumingQueryDto : PagerInfo 
    {
        public string DcLfgja { get; set; }
        public string DcLfmon { get; set; }
        public string DcBukrs { get; set; }
        public string DcMatnr { get; set; }
    }

    /// <summary>
    /// 部门消耗
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 12:03:53
    /// </summary>
    public class FicoCostingDeptConsumingDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long DcSfId { get; set; }

        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string DcLfgja { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string DcLfmon { get; set; }

        [ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string DcBukrs { get; set; }

        [ExcelColumn(Name = "统计类别")]
        [ExcelColumnName("统计类别")]
        public string DcStatyp { get; set; }

        [ExcelColumn(Name = "成本科目")]
        [ExcelColumnName("成本科目")]
        public string DcKtosl { get; set; }

        [ExcelColumn(Name = "科目代码")]
        [ExcelColumnName("科目代码")]
        public string DcKonto { get; set; }

        [ExcelColumn(Name = "科目分类")]
        [ExcelColumnName("科目分类")]
        public string DcKotyp { get; set; }

        [ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public decimal DcAnval { get; set; }

        [ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]
        public decimal DcDmist { get; set; }

        [ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal DcBfaac { get; set; }

        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string DcWerks { get; set; }

        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string DcMatnr { get; set; }

        [ExcelColumn(Name = "仓库")]
        [ExcelColumnName("仓库")]
        public string DcLgort { get; set; }

        [ExcelColumn(Name = "移动类型")]
        [ExcelColumnName("移动类型")]
        public string DcBwart { get; set; }

        [ExcelColumn(Name = "物料凭证")]
        [ExcelColumnName("物料凭证")]
        public string DcMblnr { get; set; }

        [ExcelColumn(Name = "项目明细")]
        [ExcelColumnName("项目明细")]
        public string DcZeile { get; set; }

        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal DcMenge { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string DcWaers { get; set; }

        [ExcelColumn(Name = "金额")]
        [ExcelColumnName("金额")]
        public decimal DcDmbtr { get; set; }

        [ExcelColumn(Name = "预留单")]
        [ExcelColumnName("预留单")]
        public string DcRsnum { get; set; }

        [ExcelColumn(Name = "预留明细")]
        [ExcelColumnName("预留明细")]
        public string DcRspos { get; set; }

        [ExcelColumn(Name = "领用日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("领用日期")]
        public DateTime? DcBudat { get; set; }

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



        [ExcelColumn(Name = "期间")]
        public string DcLfgjaLabel { get; set; }
        [ExcelColumn(Name = "年月")]
        public string DcLfmonLabel { get; set; }
        [ExcelColumn(Name = "公司代码")]
        public string DcBukrsLabel { get; set; }
    }

    /// <summary>
    /// 部门消耗
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 12:03:53
    /// </summary>
    public class FicoCostingDeptConsumingImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long DcSfId { get; set; }

        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string DcLfgja { get; set; }

        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string DcLfmon { get; set; }

        [ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string DcBukrs { get; set; }

        [ExcelColumn(Name = "统计类别")]
        [ExcelColumnName("统计类别")]
        public string DcStatyp { get; set; }

        [ExcelColumn(Name = "成本科目")]
        [ExcelColumnName("成本科目")]
        public string DcKtosl { get; set; }

        [ExcelColumn(Name = "科目代码")]
        [ExcelColumnName("科目代码")]
        public string DcKonto { get; set; }

        [ExcelColumn(Name = "科目分类")]
        [ExcelColumnName("科目分类")]
        public string DcKotyp { get; set; }

        [ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public decimal DcAnval { get; set; }

        [ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]
        public decimal DcDmist { get; set; }

        [ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal DcBfaac { get; set; }

        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string DcWerks { get; set; }

        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string DcMatnr { get; set; }

        [ExcelColumn(Name = "仓库")]
        [ExcelColumnName("仓库")]
        public string DcLgort { get; set; }

        [ExcelColumn(Name = "移动类型")]
        [ExcelColumnName("移动类型")]
        public string DcBwart { get; set; }

        [ExcelColumn(Name = "物料凭证")]
        [ExcelColumnName("物料凭证")]
        public string DcMblnr { get; set; }

        [ExcelColumn(Name = "项目明细")]
        [ExcelColumnName("项目明细")]
        public string DcZeile { get; set; }

        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal DcMenge { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string DcWaers { get; set; }

        [ExcelColumn(Name = "金额")]
        [ExcelColumnName("金额")]
        public decimal DcDmbtr { get; set; }

        [ExcelColumn(Name = "预留单")]
        [ExcelColumnName("预留单")]
        public string DcRsnum { get; set; }

        [ExcelColumn(Name = "预留明细")]
        [ExcelColumnName("预留明细")]
        public string DcRspos { get; set; }

        [ExcelColumn(Name = "领用日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("领用日期")]
        public DateTime? DcBudat { get; set; }

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
        [ExcelColumn(Name = "期间")]
        public string DcLfgjaLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string DcLfmonLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司代码")]
        public string DcBukrsLabel { get; set; }
    }

}