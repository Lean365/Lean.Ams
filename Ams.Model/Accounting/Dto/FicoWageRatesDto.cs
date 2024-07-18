namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 工资率
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:25:51
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
    /// @Date: 2024/7/18 16:25:51
    /// </summary>
    public class FicoWageRatesDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FwSFID { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FwCrop { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FwYm { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string FwCcy { get; set; }

        [Required(ErrorMessage = "销售额不能为空")]
        [ExcelColumn(Name = "销售额")]
        [ExcelColumnName("销售额")]
        public decimal FwSalesVolume { get; set; }

        [Required(ErrorMessage = "工作天数不能为空")]
        [ExcelColumn(Name = "工作天数")]
        [ExcelColumnName("工作天数")]
        public decimal FwWorkingDays { get; set; }

        [Required(ErrorMessage = "直接工资率不能为空")]
        [ExcelColumn(Name = "直接工资率")]
        [ExcelColumnName("直接工资率")]
        public decimal FwDirectWageRate { get; set; }

        [Required(ErrorMessage = "直接人数不能为空")]
        [ExcelColumn(Name = "直接人数")]
        [ExcelColumnName("直接人数")]
        public decimal FwDirect { get; set; }

        [Required(ErrorMessage = "直接加班费不能为空")]
        [ExcelColumn(Name = "直接加班费")]
        [ExcelColumnName("直接加班费")]
        public decimal FwDirectOverTime { get; set; }

        [Required(ErrorMessage = "直接工资不能为空")]
        [ExcelColumn(Name = "直接工资")]
        [ExcelColumnName("直接工资")]
        public decimal FwDirectWages { get; set; }

        [Required(ErrorMessage = "间接工资率不能为空")]
        [ExcelColumn(Name = "间接工资率")]
        [ExcelColumnName("间接工资率")]
        public decimal FwInDirectWageRate { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        [ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]
        public decimal FwInDirect { get; set; }

        [Required(ErrorMessage = "间接加班费不能为空")]
        [ExcelColumn(Name = "间接加班费")]
        [ExcelColumnName("间接加班费")]
        public decimal FwInDirectOverTime { get; set; }

        [Required(ErrorMessage = "间接工资不能为空")]
        [ExcelColumn(Name = "间接工资")]
        [ExcelColumnName("间接工资")]
        public decimal FwInDirectWages { get; set; }

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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "公司")]
        public string FwCropLabel { get; set; }

        [ExcelColumn(Name = "年月")]
        public string FwYmLabel { get; set; }

        [ExcelColumn(Name = "币种")]
        public string FwCcyLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 工资率
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:25:51
    /// </summary>
    public class FicoWageRatesImportTpl
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FwSFID { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FwCrop { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string FwYm { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string FwCcy { get; set; }

        [Required(ErrorMessage = "销售额不能为空")]
        [ExcelColumn(Name = "销售额")]
        [ExcelColumnName("销售额")]
        public decimal FwSalesVolume { get; set; }

        [Required(ErrorMessage = "工作天数不能为空")]
        [ExcelColumn(Name = "工作天数")]
        [ExcelColumnName("工作天数")]
        public decimal FwWorkingDays { get; set; }

        [Required(ErrorMessage = "直接工资率不能为空")]
        [ExcelColumn(Name = "直接工资率")]
        [ExcelColumnName("直接工资率")]
        public decimal FwDirectWageRate { get; set; }

        [Required(ErrorMessage = "直接人数不能为空")]
        [ExcelColumn(Name = "直接人数")]
        [ExcelColumnName("直接人数")]
        public decimal FwDirect { get; set; }

        [Required(ErrorMessage = "直接加班费不能为空")]
        [ExcelColumn(Name = "直接加班费")]
        [ExcelColumnName("直接加班费")]
        public decimal FwDirectOverTime { get; set; }

        [Required(ErrorMessage = "直接工资不能为空")]
        [ExcelColumn(Name = "直接工资")]
        [ExcelColumnName("直接工资")]
        public decimal FwDirectWages { get; set; }

        [Required(ErrorMessage = "间接工资率不能为空")]
        [ExcelColumn(Name = "间接工资率")]
        [ExcelColumnName("间接工资率")]
        public decimal FwInDirectWageRate { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        [ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]
        public decimal FwInDirect { get; set; }

        [Required(ErrorMessage = "间接加班费不能为空")]
        [ExcelColumn(Name = "间接加班费")]
        [ExcelColumnName("间接加班费")]
        public decimal FwInDirectOverTime { get; set; }

        [Required(ErrorMessage = "间接工资不能为空")]
        [ExcelColumn(Name = "间接工资")]
        [ExcelColumnName("间接工资")]
        public decimal FwInDirectWages { get; set; }

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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "公司")]
        public string FwCropLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string FwYmLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string FwCcyLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}