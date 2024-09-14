
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 源机种仕向
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:38:17
    /// </summary>
    public class PpSourceModelRegionQueryDto : PagerInfo 
    {
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Ze002 { get; set; }
        /// <summary>
        /// 机种 
        /// </summary>        
        public string Ze003 { get; set; }
        /// <summary>
        /// 仕向 
        /// </summary>        
        public string Ze004 { get; set; }
    }

    /// <summary>
    /// 源机种仕向
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:38:17
    /// </summary>
    public class PpSourceModelRegionDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Ze002 { get; set; }

        [Required(ErrorMessage = "机种不能为空")]
        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]

        public string Ze003 { get; set; }

        [Required(ErrorMessage = "仕向不能为空")]
        //[ExcelColumn(Name = "仕向")]
        [ExcelColumnName("仕向")]

        public string Ze004 { get; set; }

        //[ExcelColumn(Name = "文本")]
        [ExcelColumnName("文本")]

        public string Ze005 { get; set; }

        [ExcelIgnore]

        public string Ref01 { get; set; }

        [ExcelIgnore]

        public string Ref02 { get; set; }

        [ExcelIgnore]

        public string Ref03 { get; set; }

        [ExcelIgnore]

        public decimal Ref04 { get; set; }

        [ExcelIgnore]

        public decimal Ref05 { get; set; }

        [ExcelIgnore]

        public decimal Ref06 { get; set; }

        [ExcelIgnore]

        public string Udf01 { get; set; }

        [ExcelIgnore]

        public string Udf02 { get; set; }

        [ExcelIgnore]

        public string Udf03 { get; set; }

        [ExcelIgnore]

        public string Udf04 { get; set; }

        [ExcelIgnore]

        public string Udf05 { get; set; }

        [ExcelIgnore]

        public string Udf06 { get; set; }

        [ExcelIgnore]

        public int? Udf51 { get; set; }

        [ExcelIgnore]

        public int? Udf52 { get; set; }

        [ExcelIgnore]

        public int? Udf53 { get; set; }

        [ExcelIgnore]

        public decimal Udf54 { get; set; }

        [ExcelIgnore]

        public decimal Udf55 { get; set; }

        [ExcelIgnore]

        public decimal Udf56 { get; set; }

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



    }

    /// <summary>
    /// 源机种仕向
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:38:17
    /// </summary>
    public class PpSourceModelRegionImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Ze002 { get; set; }

        [Required(ErrorMessage = "机种不能为空")]
        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Ze003 { get; set; }

        [Required(ErrorMessage = "仕向不能为空")]
        //[ExcelColumn(Name = "仕向")]
        [ExcelColumnName("仕向")]
        public string Ze004 { get; set; }

        //[ExcelColumn(Name = "文本")]
        [ExcelColumnName("文本")]
        public string Ze005 { get; set; }

        [ExcelIgnore]
        public string Ref01 { get; set; }

        [ExcelIgnore]
        public string Ref02 { get; set; }

        [ExcelIgnore]
        public string Ref03 { get; set; }

        [ExcelIgnore]
        public decimal Ref04 { get; set; }

        [ExcelIgnore]
        public decimal Ref05 { get; set; }

        [ExcelIgnore]
        public decimal Ref06 { get; set; }

        [ExcelIgnore]
        public string Udf01 { get; set; }

        [ExcelIgnore]
        public string Udf02 { get; set; }

        [ExcelIgnore]
        public string Udf03 { get; set; }

        [ExcelIgnore]
        public string Udf04 { get; set; }

        [ExcelIgnore]
        public string Udf05 { get; set; }

        [ExcelIgnore]
        public string Udf06 { get; set; }

        [ExcelIgnore]
        public int? Udf51 { get; set; }

        [ExcelIgnore]
        public int? Udf52 { get; set; }

        [ExcelIgnore]
        public int? Udf53 { get; set; }

        [ExcelIgnore]
        public decimal Udf54 { get; set; }

        [ExcelIgnore]
        public decimal Udf55 { get; set; }

        [ExcelIgnore]
        public decimal Udf56 { get; set; }

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



    }

}