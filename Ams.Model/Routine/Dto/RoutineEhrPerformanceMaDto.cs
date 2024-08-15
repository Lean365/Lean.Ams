using Ams.Model.Routine;

namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 绩效
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 17:21:08
    /// </summary>
    public class RoutineEhrPerformanceMaQueryDto : PagerInfo 
    {
        public string EpEmployeeId { get; set; }
        public string EpName { get; set; }
        public string EpEvalYear { get; set; }
        public string EpEvalGrade { get; set; }
    }

    /// <summary>
    /// 绩效
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 17:21:08
    /// </summary>
    public class RoutineEhrPerformanceMaDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EpSfId { get; set; }

        [ExcelIgnore]
        public string EpEmployeeId { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        [ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]
        public string EpName { get; set; }

        [ExcelColumn(Name = "年度")]
        [ExcelColumnName("年度")]
        public string EpEvalYear { get; set; }

        [ExcelColumn(Name = "总分")]
        [ExcelColumnName("总分")]
        public decimal EpEvalOverallScore { get; set; }

        [ExcelColumn(Name = "等级")]
        [ExcelColumnName("等级")]
        public string EpEvalGrade { get; set; }

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
        public List<RoutineEhrPerformanceSlvDto> RoutineEhrPerformanceSlvNav { get; set; }
        [ExcelColumn(Name = "姓名")]
        public string EpNameLabel { get; set; }
        [ExcelColumn(Name = "年度")]
        public string EpEvalYearLabel { get; set; }
        [ExcelColumn(Name = "等级")]
        public string EpEvalGradeLabel { get; set; }
        [ExcelColumn(Name = "考核项目")]
        public string EpEvalItemsLabel { get; set; }
    }

    /// <summary>
    /// 绩效
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 17:21:08
    /// </summary>
    public class RoutineEhrPerformanceMaImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EpSfId { get; set; }

        [ExcelIgnore]
        public string EpEmployeeId { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        [ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]
        public string EpName { get; set; }

        [ExcelColumn(Name = "年度")]
        [ExcelColumnName("年度")]
        public string EpEvalYear { get; set; }

        [ExcelColumn(Name = "总分")]
        [ExcelColumnName("总分")]
        public decimal EpEvalOverallScore { get; set; }

        [ExcelColumn(Name = "等级")]
        [ExcelColumnName("等级")]
        public string EpEvalGrade { get; set; }

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
        public List<RoutineEhrPerformanceSlvDto> RoutineEhrPerformanceSlvNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "姓名")]
        public string EpNameLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年度")]
        public string EpEvalYearLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "等级")]
        public string EpEvalGradeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "考核项目")]
        public string EpEvalItemsLabel { get; set; }
    }

}