
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 培训
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 8:56:48
    /// </summary>
    public class RoutineEhrTrainingQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工号 
        /// </summary>        
        public string Mq002 { get; set; }
        /// <summary>
        /// 姓名 
        /// </summary>        
        public string Mq003 { get; set; }
        /// <summary>
        /// 年度 
        /// </summary>        
        public string Mq004 { get; set; }
        /// <summary>
        /// 项目 
        /// </summary>        
        public int? Mq005 { get; set; }
    }

    /// <summary>
    /// 培训
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 8:56:48
    /// </summary>
    public class RoutineEhrTrainingDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? Id { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]

        public string Mq002 { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        //[ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]

        public string Mq003 { get; set; }

        //[ExcelColumn(Name = "年度")]
        [ExcelColumnName("年度")]

        public string Mq004 { get; set; }

        [Required(ErrorMessage = "项目不能为空")]
        //[ExcelColumn(Name = "项目")]
        [ExcelColumnName("项目")]

        public int Mq005 { get; set; }

        //[ExcelColumn(Name = "内容")]
        [ExcelColumnName("内容")]

        public string Mq006 { get; set; }

        //[ExcelColumn(Name = "目的")]
        [ExcelColumnName("目的")]

        public string Mq007 { get; set; }

        [Required(ErrorMessage = "分数不能为空")]
        //[ExcelColumn(Name = "分数")]
        [ExcelColumnName("分数")]

        public int Mq008 { get; set; }

        //[ExcelColumn(Name = "结果")]
        [ExcelColumnName("结果")]

        public string Mq009 { get; set; }

        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]

        public DateTime? Mq010 { get; set; }

        //[ExcelColumn(Name = "指导老师")]
        [ExcelColumnName("指导老师")]

        public string Mq011 { get; set; }

        //[ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]

        public string Mq012 { get; set; }

        //[ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]

        public string Mq013 { get; set; }

        //[ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]

        public string Mq014 { get; set; }

        //[ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]

        public string Mq015 { get; set; }

        //[ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]

        public string Mq016 { get; set; }

        //[ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]

        public string Mq017 { get; set; }

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



        [ExcelColumn(Name = "年度")]
        public string Mq004Label { get; set; }
        [ExcelColumn(Name = "项目")]
        public string Mq005Label { get; set; }
        [ExcelColumn(Name = "结果")]
        public string Mq009Label { get; set; }
    }

    /// <summary>
    /// 培训
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 8:56:48
    /// </summary>
    public class RoutineEhrTrainingImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? Id { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string Mq002 { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        //[ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]
        public string Mq003 { get; set; }

        //[ExcelColumn(Name = "年度")]
        [ExcelColumnName("年度")]
        public string Mq004 { get; set; }

        [Required(ErrorMessage = "项目不能为空")]
        //[ExcelColumn(Name = "项目")]
        [ExcelColumnName("项目")]
        public int Mq005 { get; set; }

        //[ExcelColumn(Name = "内容")]
        [ExcelColumnName("内容")]
        public string Mq006 { get; set; }

        //[ExcelColumn(Name = "目的")]
        [ExcelColumnName("目的")]
        public string Mq007 { get; set; }

        [Required(ErrorMessage = "分数不能为空")]
        //[ExcelColumn(Name = "分数")]
        [ExcelColumnName("分数")]
        public int Mq008 { get; set; }

        //[ExcelColumn(Name = "结果")]
        [ExcelColumnName("结果")]
        public string Mq009 { get; set; }

        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Mq010 { get; set; }

        //[ExcelColumn(Name = "指导老师")]
        [ExcelColumnName("指导老师")]
        public string Mq011 { get; set; }

        //[ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]
        public string Mq012 { get; set; }

        //[ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]
        public string Mq013 { get; set; }

        //[ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]
        public string Mq014 { get; set; }

        //[ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]
        public string Mq015 { get; set; }

        //[ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]
        public string Mq016 { get; set; }

        //[ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]
        public string Mq017 { get; set; }

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



        [ExcelIgnore]
        [ExcelColumn(Name = "年度")]
        public string Mq004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "项目")]
        public string Mq005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "结果")]
        public string Mq009Label { get; set; }
    }

}