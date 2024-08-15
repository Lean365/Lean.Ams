
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 培训
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 17:22:49
    /// </summary>
    public class RoutineEhrTrainingSlvQueryDto : PagerInfo 
    {
        public int? EpTrainingItems { get; set; }
        public string EpTrainingContent { get; set; }
        public string EpTrainingResults { get; set; }
        public DateTime? BeginEpTrainingDate { get; set; }
        public DateTime? EndEpTrainingDate { get; set; }
    }

    /// <summary>
    /// 培训
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 17:22:49
    /// </summary>
    public class RoutineEhrTrainingSlvDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EpSfId { get; set; }

        [ExcelIgnore]
        public long? EpParentSfId { get; set; }

        [ExcelColumn(Name = "项目")]
        [ExcelColumnName("项目")]
        public int? EpTrainingItems { get; set; }

        [ExcelColumn(Name = "内容")]
        [ExcelColumnName("内容")]
        public string EpTrainingContent { get; set; }

        [ExcelColumn(Name = "目的")]
        [ExcelColumnName("目的")]
        public string EpTrainingPurpose { get; set; }

        [ExcelColumn(Name = "分数")]
        [ExcelColumnName("分数")]
        public int? EpTrainingScore { get; set; }

        [ExcelColumn(Name = "结果")]
        [ExcelColumnName("结果")]
        public string EpTrainingResults { get; set; }

        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? EpTrainingDate { get; set; }

        [ExcelColumn(Name = "指导老师")]
        [ExcelColumnName("指导老师")]
        public string EpTrainingTeacher { get; set; }

        [ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]
        public string EpFirstConfirmer { get; set; }

        [ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]
        public string EpSecondConfirmer { get; set; }

        [ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]
        public string EpThirdConfirmer { get; set; }

        [ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]
        public string EpFourthApprover { get; set; }

        [ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]
        public string EpFifthApprover { get; set; }

        [ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]
        public string EpSixthApprover { get; set; }

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



        [ExcelColumn(Name = "项目")]
        public string EpTrainingItemsLabel { get; set; }
        [ExcelColumn(Name = "结果")]
        public string EpTrainingResultsLabel { get; set; }
    }

    /// <summary>
    /// 培训
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 17:22:49
    /// </summary>
    public class RoutineEhrTrainingSlvImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelIgnore]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EpSfId { get; set; }

        [ExcelIgnore]
        public long? EpParentSfId { get; set; }

        [ExcelColumn(Name = "项目")]
        [ExcelColumnName("项目")]
        public int? EpTrainingItems { get; set; }

        [ExcelColumn(Name = "内容")]
        [ExcelColumnName("内容")]
        public string EpTrainingContent { get; set; }

        [ExcelColumn(Name = "目的")]
        [ExcelColumnName("目的")]
        public string EpTrainingPurpose { get; set; }

        [ExcelColumn(Name = "分数")]
        [ExcelColumnName("分数")]
        public int? EpTrainingScore { get; set; }

        [ExcelColumn(Name = "结果")]
        [ExcelColumnName("结果")]
        public string EpTrainingResults { get; set; }

        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? EpTrainingDate { get; set; }

        [ExcelColumn(Name = "指导老师")]
        [ExcelColumnName("指导老师")]
        public string EpTrainingTeacher { get; set; }

        [ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]
        public string EpFirstConfirmer { get; set; }

        [ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]
        public string EpSecondConfirmer { get; set; }

        [ExcelColumn(Name = "确认")]
        [ExcelColumnName("确认")]
        public string EpThirdConfirmer { get; set; }

        [ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]
        public string EpFourthApprover { get; set; }

        [ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]
        public string EpFifthApprover { get; set; }

        [ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]
        public string EpSixthApprover { get; set; }

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
        [ExcelColumn(Name = "项目")]
        public string EpTrainingItemsLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "结果")]
        public string EpTrainingResultsLabel { get; set; }
    }

}