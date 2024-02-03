
namespace Ams.Model.Dto
{
    /// <summary>
    /// 财务期间
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 8:02:36)
    /// </summary>
    public class PeriodQueryDto : PagerInfo 
    {
        public string FpYm { get; set; }
    }

    /// <summary>
    /// 财务期间
    /// 输入输出对象
    /// </summary>
    public class PeriodDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FpSFID { get; set; }

        [Required(ErrorMessage = "财年不能为空")]
        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string FpFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FpYm { get; set; }

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

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelColumn(Name = "创建者")]
        [ExcelColumnName("创建者")]
        public string CreateBy { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("创建时间")]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "财年")]
        public string FpFyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string FpYmLabel { get; set; }
    }
}