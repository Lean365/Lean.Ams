
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 绩效
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 9:40:38
    /// </summary>
    public class RoutineEhrPerformanceQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工号 
        /// </summary>        
        public string Ml002 { get; set; }
        /// <summary>
        /// 姓名 
        /// </summary>        
        public string Ml003 { get; set; }
        /// <summary>
        /// 年度 
        /// </summary>        
        public string Ml004 { get; set; }
        /// <summary>
        /// 等级 
        /// </summary>        
        public string Ml006 { get; set; }
    }

    /// <summary>
    /// 绩效
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 9:40:38
    /// </summary>
    public class RoutineEhrPerformanceDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? Id { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]

        public string Ml002 { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        //[ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]

        public string Ml003 { get; set; }

        //[ExcelColumn(Name = "年度")]
        [ExcelColumnName("年度")]

        public string Ml004 { get; set; }

        [Required(ErrorMessage = "总分不能为空")]
        //[ExcelColumn(Name = "总分")]
        [ExcelColumnName("总分")]

        public decimal Ml005 { get; set; }

        //[ExcelColumn(Name = "等级")]
        [ExcelColumnName("等级")]

        public string Ml006 { get; set; }

        [Required(ErrorMessage = "考核项目不能为空")]
        //[ExcelColumn(Name = "考核项目")]
        [ExcelColumnName("考核项目")]

        public int Ml007 { get; set; }

        [Required(ErrorMessage = "初次评分不能为空")]
        //[ExcelColumn(Name = "初次评分")]
        [ExcelColumnName("初次评分")]

        public decimal Ml008 { get; set; }

        //[ExcelColumn(Name = "初评人")]
        [ExcelColumnName("初评人")]

        public string Ml009 { get; set; }

        //[ExcelColumn(Name = "初评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("初评日期")]

        public DateTime? Ml010 { get; set; }

        [Required(ErrorMessage = "二次评分不能为空")]
        //[ExcelColumn(Name = "二次评分")]
        [ExcelColumnName("二次评分")]

        public decimal Ml011 { get; set; }

        //[ExcelColumn(Name = "二次考评人")]
        [ExcelColumnName("二次考评人")]

        public string Ml012 { get; set; }

        //[ExcelColumn(Name = "二次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("二次考评日期")]

        public DateTime? Ml013 { get; set; }

        [Required(ErrorMessage = "三次评分不能为空")]
        //[ExcelColumn(Name = "三次评分")]
        [ExcelColumnName("三次评分")]

        public decimal Ml014 { get; set; }

        //[ExcelColumn(Name = "三次考评人")]
        [ExcelColumnName("三次考评人")]

        public string Ml015 { get; set; }

        //[ExcelColumn(Name = "三次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("三次考评日期")]

        public DateTime? Ml016 { get; set; }

        [Required(ErrorMessage = "四次评分不能为空")]
        //[ExcelColumn(Name = "四次评分")]
        [ExcelColumnName("四次评分")]

        public decimal Ml017 { get; set; }

        //[ExcelColumn(Name = "四次考评人")]
        [ExcelColumnName("四次考评人")]

        public string Ml018 { get; set; }

        //[ExcelColumn(Name = "四次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("四次考评日期")]

        public DateTime? Ml019 { get; set; }

        [Required(ErrorMessage = "五次评分不能为空")]
        //[ExcelColumn(Name = "五次评分")]
        [ExcelColumnName("五次评分")]

        public decimal Ml020 { get; set; }

        //[ExcelColumn(Name = "五次考评人")]
        [ExcelColumnName("五次考评人")]

        public string Ml021 { get; set; }

        //[ExcelColumn(Name = "五次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("五次考评日期")]

        public DateTime? Ml022 { get; set; }

        [Required(ErrorMessage = "六次评分不能为空")]
        //[ExcelColumn(Name = "六次评分")]
        [ExcelColumnName("六次评分")]

        public decimal Ml023 { get; set; }

        //[ExcelColumn(Name = "六次考评人")]
        [ExcelColumnName("六次考评人")]

        public string Ml024 { get; set; }

        //[ExcelColumn(Name = "六次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("六次考评日期")]

        public DateTime? Ml025 { get; set; }

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
        public string Ml004Label { get; set; }
        [ExcelColumn(Name = "等级")]
        public string Ml006Label { get; set; }
    }

    /// <summary>
    /// 绩效
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 9:40:38
    /// </summary>
    public class RoutineEhrPerformanceImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? Id { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string Ml002 { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        //[ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]
        public string Ml003 { get; set; }

        //[ExcelColumn(Name = "年度")]
        [ExcelColumnName("年度")]
        public string Ml004 { get; set; }

        [Required(ErrorMessage = "总分不能为空")]
        //[ExcelColumn(Name = "总分")]
        [ExcelColumnName("总分")]
        public decimal Ml005 { get; set; }

        //[ExcelColumn(Name = "等级")]
        [ExcelColumnName("等级")]
        public string Ml006 { get; set; }

        [Required(ErrorMessage = "考核项目不能为空")]
        //[ExcelColumn(Name = "考核项目")]
        [ExcelColumnName("考核项目")]
        public int Ml007 { get; set; }

        [Required(ErrorMessage = "初次评分不能为空")]
        //[ExcelColumn(Name = "初次评分")]
        [ExcelColumnName("初次评分")]
        public decimal Ml008 { get; set; }

        //[ExcelColumn(Name = "初评人")]
        [ExcelColumnName("初评人")]
        public string Ml009 { get; set; }

        //[ExcelColumn(Name = "初评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("初评日期")]
        public DateTime? Ml010 { get; set; }

        [Required(ErrorMessage = "二次评分不能为空")]
        //[ExcelColumn(Name = "二次评分")]
        [ExcelColumnName("二次评分")]
        public decimal Ml011 { get; set; }

        //[ExcelColumn(Name = "二次考评人")]
        [ExcelColumnName("二次考评人")]
        public string Ml012 { get; set; }

        //[ExcelColumn(Name = "二次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("二次考评日期")]
        public DateTime? Ml013 { get; set; }

        [Required(ErrorMessage = "三次评分不能为空")]
        //[ExcelColumn(Name = "三次评分")]
        [ExcelColumnName("三次评分")]
        public decimal Ml014 { get; set; }

        //[ExcelColumn(Name = "三次考评人")]
        [ExcelColumnName("三次考评人")]
        public string Ml015 { get; set; }

        //[ExcelColumn(Name = "三次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("三次考评日期")]
        public DateTime? Ml016 { get; set; }

        [Required(ErrorMessage = "四次评分不能为空")]
        //[ExcelColumn(Name = "四次评分")]
        [ExcelColumnName("四次评分")]
        public decimal Ml017 { get; set; }

        //[ExcelColumn(Name = "四次考评人")]
        [ExcelColumnName("四次考评人")]
        public string Ml018 { get; set; }

        //[ExcelColumn(Name = "四次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("四次考评日期")]
        public DateTime? Ml019 { get; set; }

        [Required(ErrorMessage = "五次评分不能为空")]
        //[ExcelColumn(Name = "五次评分")]
        [ExcelColumnName("五次评分")]
        public decimal Ml020 { get; set; }

        //[ExcelColumn(Name = "五次考评人")]
        [ExcelColumnName("五次考评人")]
        public string Ml021 { get; set; }

        //[ExcelColumn(Name = "五次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("五次考评日期")]
        public DateTime? Ml022 { get; set; }

        [Required(ErrorMessage = "六次评分不能为空")]
        //[ExcelColumn(Name = "六次评分")]
        [ExcelColumnName("六次评分")]
        public decimal Ml023 { get; set; }

        //[ExcelColumn(Name = "六次考评人")]
        [ExcelColumnName("六次考评人")]
        public string Ml024 { get; set; }

        //[ExcelColumn(Name = "六次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("六次考评日期")]
        public DateTime? Ml025 { get; set; }

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
        public string Ml004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "等级")]
        public string Ml006Label { get; set; }
    }

}