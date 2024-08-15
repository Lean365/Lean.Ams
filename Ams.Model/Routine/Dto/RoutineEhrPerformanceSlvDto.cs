
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 绩效
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 17:21:01
    /// </summary>
    public class RoutineEhrPerformanceSlvQueryDto : PagerInfo 
    {
        public int? EpEvalItems { get; set; }
        public DateTime? BeginEpFirstEvalDate { get; set; }
        public DateTime? EndEpFirstEvalDate { get; set; }
        public DateTime? BeginEpSixthEvalDate { get; set; }
        public DateTime? EndEpSixthEvalDate { get; set; }
    }

    /// <summary>
    /// 绩效
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 17:21:01
    /// </summary>
    public class RoutineEhrPerformanceSlvDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EpSfId { get; set; }

        [ExcelIgnore]
        public long? EpParentSfId { get; set; }

        [ExcelColumn(Name = "考核项目")]
        [ExcelColumnName("考核项目")]
        public int? EpEvalItems { get; set; }

        [ExcelColumn(Name = "初次评分")]
        [ExcelColumnName("初次评分")]
        public decimal EpFirstEvalScore { get; set; }

        [ExcelColumn(Name = "初评人")]
        [ExcelColumnName("初评人")]
        public string EpFirstEvaluator { get; set; }

        [ExcelColumn(Name = "初评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("初评日期")]
        public DateTime? EpFirstEvalDate { get; set; }

        [ExcelColumn(Name = "二次评分")]
        [ExcelColumnName("二次评分")]
        public decimal EpSecondEvalScore { get; set; }

        [ExcelColumn(Name = "二次考评人")]
        [ExcelColumnName("二次考评人")]
        public string ESecondEvaluator { get; set; }

        [ExcelColumn(Name = "二次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("二次考评日期")]
        public DateTime? EpSecondEvalDate { get; set; }

        [ExcelColumn(Name = "三次评分")]
        [ExcelColumnName("三次评分")]
        public decimal EpThirdEvalScore { get; set; }

        [ExcelColumn(Name = "三次考评人")]
        [ExcelColumnName("三次考评人")]
        public string EpThirdEvaluator { get; set; }

        [ExcelColumn(Name = "三次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("三次考评日期")]
        public DateTime? EpThirdEvalDate { get; set; }

        [ExcelColumn(Name = "四次评分")]
        [ExcelColumnName("四次评分")]
        public decimal EpFourthEvalScore { get; set; }

        [ExcelColumn(Name = "四次考评人")]
        [ExcelColumnName("四次考评人")]
        public string EpFourthEvaluator { get; set; }

        [ExcelColumn(Name = "四次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("四次考评日期")]
        public DateTime? EpFourthEvalDate { get; set; }

        [ExcelColumn(Name = "五次评分")]
        [ExcelColumnName("五次评分")]
        public decimal EpFifthEvalScore { get; set; }

        [ExcelColumn(Name = "五次考评人")]
        [ExcelColumnName("五次考评人")]
        public string EpFifthEvaluator { get; set; }

        [ExcelColumn(Name = "五次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("五次考评日期")]
        public DateTime? EFifthEvalDate { get; set; }

        [ExcelColumn(Name = "六次评分")]
        [ExcelColumnName("六次评分")]
        public decimal EpSixthEvalScore { get; set; }

        [ExcelColumn(Name = "六次考评人")]
        [ExcelColumnName("六次考评人")]
        public string EpSixthEvaluator { get; set; }

        [ExcelColumn(Name = "六次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("六次考评日期")]
        public DateTime? EpSixthEvalDate { get; set; }

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



        [ExcelColumn(Name = "考核项目")]
        public string EpEvalItemsLabel { get; set; }
    }

    /// <summary>
    /// 绩效
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 17:21:01
    /// </summary>
    public class RoutineEhrPerformanceSlvImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EpSfId { get; set; }

        [ExcelIgnore]
        public long? EpParentSfId { get; set; }

        [ExcelColumn(Name = "考核项目")]
        [ExcelColumnName("考核项目")]
        public int? EpEvalItems { get; set; }

        [ExcelColumn(Name = "初次评分")]
        [ExcelColumnName("初次评分")]
        public decimal EpFirstEvalScore { get; set; }

        [ExcelColumn(Name = "初评人")]
        [ExcelColumnName("初评人")]
        public string EpFirstEvaluator { get; set; }

        [ExcelColumn(Name = "初评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("初评日期")]
        public DateTime? EpFirstEvalDate { get; set; }

        [ExcelColumn(Name = "二次评分")]
        [ExcelColumnName("二次评分")]
        public decimal EpSecondEvalScore { get; set; }

        [ExcelColumn(Name = "二次考评人")]
        [ExcelColumnName("二次考评人")]
        public string ESecondEvaluator { get; set; }

        [ExcelColumn(Name = "二次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("二次考评日期")]
        public DateTime? EpSecondEvalDate { get; set; }

        [ExcelColumn(Name = "三次评分")]
        [ExcelColumnName("三次评分")]
        public decimal EpThirdEvalScore { get; set; }

        [ExcelColumn(Name = "三次考评人")]
        [ExcelColumnName("三次考评人")]
        public string EpThirdEvaluator { get; set; }

        [ExcelColumn(Name = "三次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("三次考评日期")]
        public DateTime? EpThirdEvalDate { get; set; }

        [ExcelColumn(Name = "四次评分")]
        [ExcelColumnName("四次评分")]
        public decimal EpFourthEvalScore { get; set; }

        [ExcelColumn(Name = "四次考评人")]
        [ExcelColumnName("四次考评人")]
        public string EpFourthEvaluator { get; set; }

        [ExcelColumn(Name = "四次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("四次考评日期")]
        public DateTime? EpFourthEvalDate { get; set; }

        [ExcelColumn(Name = "五次评分")]
        [ExcelColumnName("五次评分")]
        public decimal EpFifthEvalScore { get; set; }

        [ExcelColumn(Name = "五次考评人")]
        [ExcelColumnName("五次考评人")]
        public string EpFifthEvaluator { get; set; }

        [ExcelColumn(Name = "五次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("五次考评日期")]
        public DateTime? EFifthEvalDate { get; set; }

        [ExcelColumn(Name = "六次评分")]
        [ExcelColumnName("六次评分")]
        public decimal EpSixthEvalScore { get; set; }

        [ExcelColumn(Name = "六次考评人")]
        [ExcelColumnName("六次考评人")]
        public string EpSixthEvaluator { get; set; }

        [ExcelColumn(Name = "六次考评日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("六次考评日期")]
        public DateTime? EpSixthEvalDate { get; set; }

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
        [ExcelColumn(Name = "考核项目")]
        public string EpEvalItemsLabel { get; set; }
    }

}