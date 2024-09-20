
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 看板
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/20 9:52:38
    /// </summary>
    public class RoutineBoardQueryDto : PagerInfo 
    {
        /// <summary>
        /// 公司名称 
        /// </summary>        
        public string Mb004 { get; set; }
    }

    /// <summary>
    /// 看板
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/20 9:52:38
    /// </summary>
    public class RoutineBoardDto
    {
        //[ExcelColumn(Name = "主键")]
        [ExcelColumnName("主键")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? Id { get; set; }

        [Required(ErrorMessage = "起始日不能为空")]
        //[ExcelColumn(Name = "起始日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("起始日")]

        public DateTime? Mb002 { get; set; }

        [Required(ErrorMessage = "结束日不能为空")]
        //[ExcelColumn(Name = "结束日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("结束日")]

        public DateTime? Mb003 { get; set; }

        [Required(ErrorMessage = "公司名称不能为空")]
        //[ExcelColumn(Name = "公司名称")]
        [ExcelColumnName("公司名称")]

        public string Mb004 { get; set; }

        [Required(ErrorMessage = "参访人员不能为空")]
        //[ExcelColumn(Name = "参访人员")]
        [ExcelColumnName("参访人员")]

        public string Mb005 { get; set; }

        [ExcelIgnore]

        public string Remark { get; set; }

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

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



    }

    /// <summary>
    /// 看板
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/20 9:52:38
    /// </summary>
    public class RoutineBoardImportTpl
    {
        //[ExcelColumn(Name = "主键")]
        [ExcelColumnName("主键")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? Id { get; set; }

        [Required(ErrorMessage = "起始日不能为空")]
        //[ExcelColumn(Name = "起始日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("起始日")]
        public DateTime? Mb002 { get; set; }

        [Required(ErrorMessage = "结束日不能为空")]
        //[ExcelColumn(Name = "结束日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("结束日")]
        public DateTime? Mb003 { get; set; }

        [Required(ErrorMessage = "公司名称不能为空")]
        //[ExcelColumn(Name = "公司名称")]
        [ExcelColumnName("公司名称")]
        public string Mb004 { get; set; }

        [Required(ErrorMessage = "参访人员不能为空")]
        //[ExcelColumn(Name = "参访人员")]
        [ExcelColumnName("参访人员")]
        public string Mb005 { get; set; }

        [ExcelIgnore]
        public string Remark { get; set; }

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
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



    }

}