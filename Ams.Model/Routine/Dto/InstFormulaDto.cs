
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 计算公式
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:17:40
    /// </summary>
    public class InstFormulaQueryDto : PagerInfo 
    {
        /// <summary>
        /// 类别 
        /// </summary>        
        public string Mb002 { get; set; }
    }

    /// <summary>
    /// 计算公式
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:17:40
    /// </summary>
    public class InstFormulaDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        //[ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]

        public string Mb002 { get; set; }

        [Required(ErrorMessage = "翻译键值不能为空")]
        //[ExcelColumn(Name = "翻译键值")]
        [ExcelColumnName("翻译键值")]

        public string Mb003 { get; set; }

        [Required(ErrorMessage = "公式标识不能为空")]
        //[ExcelColumn(Name = "公式标识")]
        [ExcelColumnName("公式标识")]

        public string Mb004 { get; set; }

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



        [ExcelColumn(Name = "类别")]
        public string Mb002Label { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 计算公式
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:17:40
    /// </summary>
    public class InstFormulaImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        //[ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string Mb002 { get; set; }

        [Required(ErrorMessage = "翻译键值不能为空")]
        //[ExcelColumn(Name = "翻译键值")]
        [ExcelColumnName("翻译键值")]
        public string Mb003 { get; set; }

        [Required(ErrorMessage = "公式标识不能为空")]
        //[ExcelColumn(Name = "公式标识")]
        [ExcelColumnName("公式标识")]
        public string Mb004 { get; set; }

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
        [ExcelColumn(Name = "类别")]
        public string Mb002Label { get; set; }
    }

}