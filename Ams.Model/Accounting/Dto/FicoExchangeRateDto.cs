
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 汇率表
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 17:00:23
    /// </summary>
    public class FicoExchangeRateQueryDto : PagerInfo 
    {
        public string FerCorp { get; set; }
        public DateTime? BeginFerEffDate { get; set; }
        public DateTime? EndFerEffDate { get; set; }
        public string FerfmCcy { get; set; }
        public string FertoCcy { get; set; }
    }

    /// <summary>
    /// 汇率表
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 17:00:23
    /// </summary>
    public class FicoExchangeRateDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FerSfId { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FerCorp { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? FerEffDate { get; set; }

        [Required(ErrorMessage = "基数不能为空")]
        [ExcelColumn(Name = "基数")]
        [ExcelColumnName("基数")]
        public int FerStd { get; set; }

        [Required(ErrorMessage = "从币种不能为空")]
        [ExcelColumn(Name = "从币种")]
        [ExcelColumnName("从币种")]
        public string FerfmCcy { get; set; }

        [Required(ErrorMessage = "汇率不能为空")]
        [ExcelColumn(Name = "汇率")]
        [ExcelColumnName("汇率")]
        public decimal FerRate { get; set; }

        [Required(ErrorMessage = "到币种不能为空")]
        [ExcelColumn(Name = "到币种")]
        [ExcelColumnName("到币种")]
        public string FertoCcy { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "公司")]
        public string FerCorpLabel { get; set; }
        [ExcelColumn(Name = "从币种")]
        public string FerfmCcyLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 汇率表
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 17:00:23
    /// </summary>
    public class FicoExchangeRateImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FerSfId { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FerCorp { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? FerEffDate { get; set; }

        [Required(ErrorMessage = "基数不能为空")]
        [ExcelColumn(Name = "基数")]
        [ExcelColumnName("基数")]
        public int FerStd { get; set; }

        [Required(ErrorMessage = "从币种不能为空")]
        [ExcelColumn(Name = "从币种")]
        [ExcelColumnName("从币种")]
        public string FerfmCcy { get; set; }

        [Required(ErrorMessage = "汇率不能为空")]
        [ExcelColumn(Name = "汇率")]
        [ExcelColumnName("汇率")]
        public decimal FerRate { get; set; }

        [Required(ErrorMessage = "到币种不能为空")]
        [ExcelColumn(Name = "到币种")]
        [ExcelColumnName("到币种")]
        public string FertoCcy { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
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
        [ExcelColumn(Name = "公司")]
        public string FerCorpLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "从币种")]
        public string FerfmCcyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}