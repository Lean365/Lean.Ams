
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 培训
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:39
    /// </summary>
    public class RoutineEhrTrainingSlvQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 培训
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:39
    /// </summary>
    public class RoutineEhrTrainingSlvDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? ParentId { get; set; }

        [Required(ErrorMessage = "项目不能为空")]
        //[ExcelColumn(Name = "项目")]
        [ExcelColumnName("项目")]

        public int Mr003 { get; set; }

        //[ExcelColumn(Name = "内容")]
        [ExcelColumnName("内容")]

        public string Mr004 { get; set; }

        //[ExcelColumn(Name = "目的")]
        [ExcelColumnName("目的")]

        public string Mr005 { get; set; }

        [Required(ErrorMessage = "分数不能为空")]
        //[ExcelColumn(Name = "分数")]
        [ExcelColumnName("分数")]

        public int Mr006 { get; set; }

        //[ExcelColumn(Name = "结果")]
        [ExcelColumnName("结果")]

        public string Mr007 { get; set; }

        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]

        public DateTime? Mr008 { get; set; }

        //[ExcelColumn(Name = "指导老师")]
        [ExcelColumnName("指导老师")]

        public string Mr009 { get; set; }

        //[ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]

        public string Mr010 { get; set; }

        //[ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]

        public string Mr011 { get; set; }

        //[ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]

        public string Mr012 { get; set; }

        //[ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]

        public string Mr013 { get; set; }

        //[ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]

        public string Mr014 { get; set; }

        //[ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]

        public string Mr015 { get; set; }

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

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelIgnore]

        public int IsDeleted { get; set; }

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



        [ExcelColumn(Name = "项目")]
        public string Mr003Label { get; set; }
        [ExcelColumn(Name = "结果")]
        public string Mr007Label { get; set; }
    }

    /// <summary>
    /// 培训
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:39
    /// </summary>
    public class RoutineEhrTrainingSlvImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? ParentId { get; set; }

        [Required(ErrorMessage = "项目不能为空")]
        //[ExcelColumn(Name = "项目")]
        [ExcelColumnName("项目")]
        public int Mr003 { get; set; }

        //[ExcelColumn(Name = "内容")]
        [ExcelColumnName("内容")]
        public string Mr004 { get; set; }

        //[ExcelColumn(Name = "目的")]
        [ExcelColumnName("目的")]
        public string Mr005 { get; set; }

        [Required(ErrorMessage = "分数不能为空")]
        //[ExcelColumn(Name = "分数")]
        [ExcelColumnName("分数")]
        public int Mr006 { get; set; }

        //[ExcelColumn(Name = "结果")]
        [ExcelColumnName("结果")]
        public string Mr007 { get; set; }

        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Mr008 { get; set; }

        //[ExcelColumn(Name = "指导老师")]
        [ExcelColumnName("指导老师")]
        public string Mr009 { get; set; }

        //[ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]
        public string Mr010 { get; set; }

        //[ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]
        public string Mr011 { get; set; }

        //[ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]
        public string Mr012 { get; set; }

        //[ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]
        public string Mr013 { get; set; }

        //[ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]
        public string Mr014 { get; set; }

        //[ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]
        public string Mr015 { get; set; }

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

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelIgnore]
        public int IsDeleted { get; set; }

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
        [ExcelColumn(Name = "项目")]
        public string Mr003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "结果")]
        public string Mr007Label { get; set; }
    }

}