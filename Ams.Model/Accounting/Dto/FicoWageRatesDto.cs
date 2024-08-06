
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 工资率
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:12
    /// </summary>
    public class FicoWageRatesQueryDto : PagerInfo 
    {
        public string FwCrop { get; set; }
        public string FwYm { get; set; }
        public string FwCcy { get; set; }
    }

    /// <summary>
    /// 工资率
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:12
    /// </summary>
    public class FicoWageRatesDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FwSfId { get; set; }

        [ExcelColumn(Name = "公司 ")]
        [ExcelColumnName("公司 ")]
        public string FwCrop { get; set; }

        [ExcelColumn(Name = "年月 ")]
        [ExcelColumnName("年月 ")]
        public string FwYm { get; set; }

        [ExcelColumn(Name = "币种 ")]
        [ExcelColumnName("币种 ")]
        public string FwCcy { get; set; }

        [ExcelColumn(Name = "销售额 ")]
        [ExcelColumnName("销售额 ")]
        public decimal FwSalesVolume { get; set; }

        [ExcelColumn(Name = "工作天数 ")]
        [ExcelColumnName("工作天数 ")]
        public decimal FwWorkingDays { get; set; }

        [ExcelColumn(Name = "直接工资率 ")]
        [ExcelColumnName("直接工资率 ")]
        public decimal FwDirectWageRate { get; set; }

        [ExcelColumn(Name = "直接人数 ")]
        [ExcelColumnName("直接人数 ")]
        public decimal FwDirect { get; set; }

        [ExcelColumn(Name = "直接加班费 ")]
        [ExcelColumnName("直接加班费 ")]
        public decimal FwDirectOverTime { get; set; }

        [ExcelColumn(Name = "直接工资 ")]
        [ExcelColumnName("直接工资 ")]
        public decimal FwDirectWages { get; set; }

        [ExcelColumn(Name = "间接工资率 ")]
        [ExcelColumnName("间接工资率 ")]
        public decimal FwInDirectWageRate { get; set; }

        [ExcelColumn(Name = "间接人数 ")]
        [ExcelColumnName("间接人数 ")]
        public decimal FwInDirect { get; set; }

        [ExcelColumn(Name = "间接加班费 ")]
        [ExcelColumnName("间接加班费 ")]
        public decimal FwInDirectOverTime { get; set; }

        [ExcelColumn(Name = "间接工资 ")]
        [ExcelColumnName("间接工资 ")]
        public decimal FwInDirectWages { get; set; }

        [ExcelColumn(Name = "预留A ")]
        [ExcelColumnName("预留A ")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B ")]
        [ExcelColumnName("预留B ")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C ")]
        [ExcelColumnName("预留C ")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1 ")]
        [ExcelColumnName("预留1 ")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2 ")]
        [ExcelColumnName("预留2 ")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3")]
        [ExcelColumnName("预留3")]
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

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明")]
        [ExcelColumnName("备注说明")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "公司 ")]
        public string FwCropLabel { get; set; }
        [ExcelColumn(Name = "年月 ")]
        public string FwYmLabel { get; set; }
        [ExcelColumn(Name = "币种 ")]
        public string FwCcyLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 工资率
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:12
    /// </summary>
    public class FicoWageRatesImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FwSfId { get; set; }

        [ExcelColumn(Name = "公司 ")]
        [ExcelColumnName("公司 ")]
        public string FwCrop { get; set; }

        [ExcelColumn(Name = "年月 ")]
        [ExcelColumnName("年月 ")]
        public string FwYm { get; set; }

        [ExcelColumn(Name = "币种 ")]
        [ExcelColumnName("币种 ")]
        public string FwCcy { get; set; }

        [ExcelColumn(Name = "销售额 ")]
        [ExcelColumnName("销售额 ")]
        public decimal FwSalesVolume { get; set; }

        [ExcelColumn(Name = "工作天数 ")]
        [ExcelColumnName("工作天数 ")]
        public decimal FwWorkingDays { get; set; }

        [ExcelColumn(Name = "直接工资率 ")]
        [ExcelColumnName("直接工资率 ")]
        public decimal FwDirectWageRate { get; set; }

        [ExcelColumn(Name = "直接人数 ")]
        [ExcelColumnName("直接人数 ")]
        public decimal FwDirect { get; set; }

        [ExcelColumn(Name = "直接加班费 ")]
        [ExcelColumnName("直接加班费 ")]
        public decimal FwDirectOverTime { get; set; }

        [ExcelColumn(Name = "直接工资 ")]
        [ExcelColumnName("直接工资 ")]
        public decimal FwDirectWages { get; set; }

        [ExcelColumn(Name = "间接工资率 ")]
        [ExcelColumnName("间接工资率 ")]
        public decimal FwInDirectWageRate { get; set; }

        [ExcelColumn(Name = "间接人数 ")]
        [ExcelColumnName("间接人数 ")]
        public decimal FwInDirect { get; set; }

        [ExcelColumn(Name = "间接加班费 ")]
        [ExcelColumnName("间接加班费 ")]
        public decimal FwInDirectOverTime { get; set; }

        [ExcelColumn(Name = "间接工资 ")]
        [ExcelColumnName("间接工资 ")]
        public decimal FwInDirectWages { get; set; }

        [ExcelColumn(Name = "预留A ")]
        [ExcelColumnName("预留A ")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B ")]
        [ExcelColumnName("预留B ")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C ")]
        [ExcelColumnName("预留C ")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1 ")]
        [ExcelColumnName("预留1 ")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2 ")]
        [ExcelColumnName("预留2 ")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3")]
        [ExcelColumnName("预留3")]
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

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明")]
        [ExcelColumnName("备注说明")]
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
        [ExcelColumn(Name = "公司 ")]
        public string FwCropLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月 ")]
        public string FwYmLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种 ")]
        public string FwCcyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}