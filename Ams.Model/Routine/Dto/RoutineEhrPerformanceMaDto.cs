using Ams.Model.Routine;

namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 绩效
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:19:03
    /// </summary>
    public class RoutineEhrPerformanceMaQueryDto : PagerInfo 
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
    /// @Date: 2024/9/12 15:19:03
    /// </summary>
    public class RoutineEhrPerformanceMaDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

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

        //[ExcelColumn(Name = "总分")]
        [ExcelColumnName("总分")]

        public decimal Ml005 { get; set; }

        //[ExcelColumn(Name = "等级")]
        [ExcelColumnName("等级")]

        public string Ml006 { get; set; }

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



        [ExcelIgnore]
        public List<RoutineEhrPerformanceSlvDto> RoutineEhrPerformanceSlvNav { get; set; }
        [ExcelColumn(Name = "年度")]
        public string Ml004Label { get; set; }
        [ExcelColumn(Name = "等级")]
        public string Ml006Label { get; set; }
        [ExcelColumn(Name = "考核项目")]
        public string Mm003Label { get; set; }
    }

    /// <summary>
    /// 绩效
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:19:03
    /// </summary>
    public class RoutineEhrPerformanceMaImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

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

        //[ExcelColumn(Name = "总分")]
        [ExcelColumnName("总分")]
        public decimal Ml005 { get; set; }

        //[ExcelColumn(Name = "等级")]
        [ExcelColumnName("等级")]
        public string Ml006 { get; set; }

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



        [ExcelIgnore]
        public List<RoutineEhrPerformanceSlvDto> RoutineEhrPerformanceSlvNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年度")]
        public string Ml004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "等级")]
        public string Ml006Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "考核项目")]
        public string Mm003Label { get; set; }
    }

}