
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 财务期间
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:59:13
    /// </summary>
    public class FicoFinancialPeriodQueryDto : PagerInfo 
    {
        public string FpFinancialYear { get; set; }
        public string FpYearMonth { get; set; }
        public string FpYear { get; set; }
        public string FpMonth { get; set; }
        public string FpQuarter { get; set; }
    }

    /// <summary>
    /// 财务期间
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:59:13
    /// </summary>
    public class FicoFinancialPeriodDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FpSfId { get; set; }

        [Required(ErrorMessage = "财年不能为空")]
        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FpFinancialYear { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FpYearMonth { get; set; }

        [Required(ErrorMessage = "年不能为空")]
        [ExcelColumn(Name = "年")]
        [ExcelColumnName("年")]
        public string FpYear { get; set; }

        [Required(ErrorMessage = "月不能为空")]
        [ExcelColumn(Name = "月")]
        [ExcelColumnName("月")]
        public string FpMonth { get; set; }

        [Required(ErrorMessage = "季度不能为空")]
        [ExcelColumn(Name = "季度")]
        [ExcelColumnName("季度")]
        public string FpQuarter { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 财务期间
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:59:13
    /// </summary>
    public class FicoFinancialPeriodImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FpSfId { get; set; }

        [Required(ErrorMessage = "财年不能为空")]
        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FpFinancialYear { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FpYearMonth { get; set; }

        [Required(ErrorMessage = "年不能为空")]
        [ExcelColumn(Name = "年")]
        [ExcelColumnName("年")]
        public string FpYear { get; set; }

        [Required(ErrorMessage = "月不能为空")]
        [ExcelColumn(Name = "月")]
        [ExcelColumnName("月")]
        public string FpMonth { get; set; }

        [Required(ErrorMessage = "季度不能为空")]
        [ExcelColumn(Name = "季度")]
        [ExcelColumnName("季度")]
        public string FpQuarter { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
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
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}