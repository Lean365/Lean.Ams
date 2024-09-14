
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 绩效
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:43
    /// </summary>
    public class RoutineEhrPerformanceSlvQueryDto : PagerInfo 
    {
        /// <summary>
        /// 考核项目 
        /// </summary>        
        public int? Mm003 { get; set; }
    }

    /// <summary>
    /// 绩效
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:43
    /// </summary>
    public class RoutineEhrPerformanceSlvDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? ParentId { get; set; }

        [Required(ErrorMessage = "考核项目不能为空")]
        //[ExcelColumn(Name = "考核项目")]
        [ExcelColumnName("考核项目")]

        public int Mm003 { get; set; }

        //[ExcelColumn(Name = "初次评分")]
        [ExcelColumnName("初次评分")]

        public decimal Mm004 { get; set; }

        //[ExcelColumn(Name = "初评人")]
        [ExcelColumnName("初评人")]

        public string Mm005 { get; set; }

        //[ExcelColumn(Name = "初评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("初评日期")]

        public DateTime? Mm006 { get; set; }

        //[ExcelColumn(Name = "二次评分")]
        [ExcelColumnName("二次评分")]

        public decimal Mm007 { get; set; }

        //[ExcelColumn(Name = "二次考评人")]
        [ExcelColumnName("二次考评人")]

        public string Mm008 { get; set; }

        //[ExcelColumn(Name = "二次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("二次考评日期")]

        public DateTime? Mm009 { get; set; }

        //[ExcelColumn(Name = "三次评分")]
        [ExcelColumnName("三次评分")]

        public decimal Mm010 { get; set; }

        //[ExcelColumn(Name = "三次考评人")]
        [ExcelColumnName("三次考评人")]

        public string Mm011 { get; set; }

        //[ExcelColumn(Name = "三次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("三次考评日期")]

        public DateTime? Mm012 { get; set; }

        //[ExcelColumn(Name = "四次评分")]
        [ExcelColumnName("四次评分")]

        public decimal Mm013 { get; set; }

        //[ExcelColumn(Name = "四次考评人")]
        [ExcelColumnName("四次考评人")]

        public string Mm014 { get; set; }

        //[ExcelColumn(Name = "四次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("四次考评日期")]

        public DateTime? Mm015 { get; set; }

        //[ExcelColumn(Name = "五次评分")]
        [ExcelColumnName("五次评分")]

        public decimal Mm016 { get; set; }

        //[ExcelColumn(Name = "五次考评人")]
        [ExcelColumnName("五次考评人")]

        public string Mm017 { get; set; }

        //[ExcelColumn(Name = "五次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("五次考评日期")]

        public DateTime? Mm018 { get; set; }

        //[ExcelColumn(Name = "六次评分")]
        [ExcelColumnName("六次评分")]

        public decimal Mm019 { get; set; }

        //[ExcelColumn(Name = "六次考评人")]
        [ExcelColumnName("六次考评人")]

        public string Mm020 { get; set; }

        //[ExcelColumn(Name = "六次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("六次考评日期")]

        public DateTime? Mm021 { get; set; }

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



        [ExcelColumn(Name = "考核项目")]
        public string Mm003Label { get; set; }
    }

    /// <summary>
    /// 绩效
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:43
    /// </summary>
    public class RoutineEhrPerformanceSlvImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? ParentId { get; set; }

        [Required(ErrorMessage = "考核项目不能为空")]
        //[ExcelColumn(Name = "考核项目")]
        [ExcelColumnName("考核项目")]
        public int Mm003 { get; set; }

        //[ExcelColumn(Name = "初次评分")]
        [ExcelColumnName("初次评分")]
        public decimal Mm004 { get; set; }

        //[ExcelColumn(Name = "初评人")]
        [ExcelColumnName("初评人")]
        public string Mm005 { get; set; }

        //[ExcelColumn(Name = "初评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("初评日期")]
        public DateTime? Mm006 { get; set; }

        //[ExcelColumn(Name = "二次评分")]
        [ExcelColumnName("二次评分")]
        public decimal Mm007 { get; set; }

        //[ExcelColumn(Name = "二次考评人")]
        [ExcelColumnName("二次考评人")]
        public string Mm008 { get; set; }

        //[ExcelColumn(Name = "二次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("二次考评日期")]
        public DateTime? Mm009 { get; set; }

        //[ExcelColumn(Name = "三次评分")]
        [ExcelColumnName("三次评分")]
        public decimal Mm010 { get; set; }

        //[ExcelColumn(Name = "三次考评人")]
        [ExcelColumnName("三次考评人")]
        public string Mm011 { get; set; }

        //[ExcelColumn(Name = "三次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("三次考评日期")]
        public DateTime? Mm012 { get; set; }

        //[ExcelColumn(Name = "四次评分")]
        [ExcelColumnName("四次评分")]
        public decimal Mm013 { get; set; }

        //[ExcelColumn(Name = "四次考评人")]
        [ExcelColumnName("四次考评人")]
        public string Mm014 { get; set; }

        //[ExcelColumn(Name = "四次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("四次考评日期")]
        public DateTime? Mm015 { get; set; }

        //[ExcelColumn(Name = "五次评分")]
        [ExcelColumnName("五次评分")]
        public decimal Mm016 { get; set; }

        //[ExcelColumn(Name = "五次考评人")]
        [ExcelColumnName("五次考评人")]
        public string Mm017 { get; set; }

        //[ExcelColumn(Name = "五次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("五次考评日期")]
        public DateTime? Mm018 { get; set; }

        //[ExcelColumn(Name = "六次评分")]
        [ExcelColumnName("六次评分")]
        public decimal Mm019 { get; set; }

        //[ExcelColumn(Name = "六次考评人")]
        [ExcelColumnName("六次考评人")]
        public string Mm020 { get; set; }

        //[ExcelColumn(Name = "六次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("六次考评日期")]
        public DateTime? Mm021 { get; set; }

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
        [ExcelColumn(Name = "考核项目")]
        public string Mm003Label { get; set; }
    }

}