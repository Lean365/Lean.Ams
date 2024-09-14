
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 工资率
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:26:01
    /// </summary>
    public class FicoWageRatesQueryDto : PagerInfo 
    {
        /// <summary>
        /// 期间 
        /// </summary>        
        public string Mr002 { get; set; }
        /// <summary>
        /// 年月 
        /// </summary>        
        public string Mr003 { get; set; }
        /// <summary>
        /// 公司 
        /// </summary>        
        public string Mr004 { get; set; }
        /// <summary>
        /// 币种 
        /// </summary>        
        public string Mr005 { get; set; }
    }

    /// <summary>
    /// 工资率
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:26:01
    /// </summary>
    public class FicoWageRatesDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]

        public string Mr002 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]

        public string Mr003 { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]

        public string Mr004 { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]

        public string Mr005 { get; set; }

        [Required(ErrorMessage = "销售额不能为空")]
        //[ExcelColumn(Name = "销售额")]
        [ExcelColumnName("销售额")]

        public decimal Mr006 { get; set; }

        [Required(ErrorMessage = "工作天数不能为空")]
        //[ExcelColumn(Name = "工作天数")]
        [ExcelColumnName("工作天数")]

        public decimal Mr007 { get; set; }

        [Required(ErrorMessage = "直接工资率不能为空")]
        //[ExcelColumn(Name = "直接工资率")]
        [ExcelColumnName("直接工资率")]

        public decimal Mr008 { get; set; }

        [Required(ErrorMessage = "直接人数不能为空")]
        //[ExcelColumn(Name = "直接人数")]
        [ExcelColumnName("直接人数")]

        public decimal Mr009 { get; set; }

        [Required(ErrorMessage = "直接加班费不能为空")]
        //[ExcelColumn(Name = "直接加班费")]
        [ExcelColumnName("直接加班费")]

        public decimal Mr010 { get; set; }

        [Required(ErrorMessage = "直接工资不能为空")]
        //[ExcelColumn(Name = "直接工资")]
        [ExcelColumnName("直接工资")]

        public decimal Mr011 { get; set; }

        //[ExcelColumn(Name = "间接工资率")]
        [ExcelColumnName("间接工资率")]

        public decimal Mr012 { get; set; }

        //[ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]

        public decimal Mr013 { get; set; }

        //[ExcelColumn(Name = "间接加班费")]
        [ExcelColumnName("间接加班费")]

        public decimal Mr014 { get; set; }

        //[ExcelColumn(Name = "间接工资")]
        [ExcelColumnName("间接工资")]

        public decimal Mr015 { get; set; }

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
        public string Mr002Label { get; set; }
        [ExcelColumn(Name = "年月")]
        public string Mr003Label { get; set; }
        [ExcelColumn(Name = "公司")]
        public string Mr004Label { get; set; }
        [ExcelColumn(Name = "币种")]
        public string Mr005Label { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 工资率
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:26:01
    /// </summary>
    public class FicoWageRatesImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string Mr002 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string Mr003 { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string Mr004 { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Mr005 { get; set; }

        [Required(ErrorMessage = "销售额不能为空")]
        //[ExcelColumn(Name = "销售额")]
        [ExcelColumnName("销售额")]
        public decimal Mr006 { get; set; }

        [Required(ErrorMessage = "工作天数不能为空")]
        //[ExcelColumn(Name = "工作天数")]
        [ExcelColumnName("工作天数")]
        public decimal Mr007 { get; set; }

        [Required(ErrorMessage = "直接工资率不能为空")]
        //[ExcelColumn(Name = "直接工资率")]
        [ExcelColumnName("直接工资率")]
        public decimal Mr008 { get; set; }

        [Required(ErrorMessage = "直接人数不能为空")]
        //[ExcelColumn(Name = "直接人数")]
        [ExcelColumnName("直接人数")]
        public decimal Mr009 { get; set; }

        [Required(ErrorMessage = "直接加班费不能为空")]
        //[ExcelColumn(Name = "直接加班费")]
        [ExcelColumnName("直接加班费")]
        public decimal Mr010 { get; set; }

        [Required(ErrorMessage = "直接工资不能为空")]
        //[ExcelColumn(Name = "直接工资")]
        [ExcelColumnName("直接工资")]
        public decimal Mr011 { get; set; }

        //[ExcelColumn(Name = "间接工资率")]
        [ExcelColumnName("间接工资率")]
        public decimal Mr012 { get; set; }

        //[ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]
        public decimal Mr013 { get; set; }

        //[ExcelColumn(Name = "间接加班费")]
        [ExcelColumnName("间接加班费")]
        public decimal Mr014 { get; set; }

        //[ExcelColumn(Name = "间接工资")]
        [ExcelColumnName("间接工资")]
        public decimal Mr015 { get; set; }

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
        public string Mr002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string Mr003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司")]
        public string Mr004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string Mr005Label { get; set; }
    }

}