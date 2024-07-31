
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 绩效
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 17:18:14
    /// </summary>
    public class RoutineEhrPerformanceQueryDto : PagerInfo 
    {
        public string EpWorkID { get; set; }
        public string EpAssessmentYear { get; set; }
        public DateTime? BeginEpAssessmentDate { get; set; }
        public DateTime? EndEpAssessmentDate { get; set; }
        public DateTime? BeginEpEffectiveDate { get; set; }
        public DateTime? EndEpEffectiveDate { get; set; }
        public DateTime? BeginEpAuditDate { get; set; }
        public DateTime? EndEpAuditDate { get; set; }
    }

    /// <summary>
    /// 绩效
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 17:18:14
    /// </summary>
    public class RoutineEhrPerformanceDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EpSfId { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long EpParentSfId { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        [ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string EpWorkID { get; set; }

        [ExcelColumn(Name = "考核年度")]
        [ExcelColumnName("考核年度")]
        public string EpAssessmentYear { get; set; }

        [ExcelColumn(Name = "考核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("考核日期")]
        public DateTime? EpAssessmentDate { get; set; }

        [ExcelColumn(Name = "工作绩效")]
        [ExcelColumnName("工作绩效")]
        public int? EpWorkPerformance { get; set; }

        [ExcelColumn(Name = "专业知识")]
        [ExcelColumnName("专业知识")]
        public int? EpExpertise { get; set; }

        [ExcelColumn(Name = "工作态度")]
        [ExcelColumnName("工作态度")]
        public int? EpWorkingAttitude { get; set; }

        [ExcelColumn(Name = "领导能力")]
        [ExcelColumnName("领导能力")]
        public int? EpLeadershipSkills { get; set; }

        [ExcelColumn(Name = "员工纪律")]
        [ExcelColumnName("员工纪律")]
        public int? EpDiscipline { get; set; }

        [ExcelColumn(Name = "员工士气")]
        [ExcelColumnName("员工士气")]
        public int? EpMorale { get; set; }

        [ExcelColumn(Name = "监督实效")]
        [ExcelColumnName("监督实效")]
        public int? EpEffectiveness { get; set; }

        [ExcelColumn(Name = "决策分析")]
        [ExcelColumnName("决策分析")]
        public int? EpDecision { get; set; }

        [ExcelColumn(Name = "沟通协调")]
        [ExcelColumnName("沟通协调")]
        public int? EpCommunication { get; set; }

        [ExcelColumn(Name = "成本意识")]
        [ExcelColumnName("成本意识")]
        public int? EpConsciousness { get; set; }

        [ExcelColumn(Name = "判断对策")]
        [ExcelColumnName("判断对策")]
        public int? EpJudgement { get; set; }

        [ExcelColumn(Name = "前瞻创造")]
        [ExcelColumnName("前瞻创造")]
        public int? EpCreativity { get; set; }

        [ExcelColumn(Name = "控制能力")]
        [ExcelColumnName("控制能力")]
        public int? EpControl { get; set; }

        [ExcelColumn(Name = "持续力")]
        [ExcelColumnName("持续力")]
        public int? EpSustainability { get; set; }

        [ExcelColumn(Name = "自信心")]
        [ExcelColumnName("自信心")]
        public int? EpSelfConfidence { get; set; }

        [ExcelColumn(Name = "适应能力")]
        [ExcelColumnName("适应能力")]
        public int? EpAdaptability { get; set; }

        [ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日期")]
        public DateTime? EpEffectiveDate { get; set; }

        [ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? EpAuditDate { get; set; }

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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "考核年度")]
        public string EpAssessmentYearLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 绩效
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 17:18:14
    /// </summary>
    public class RoutineEhrPerformanceImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EpSfId { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long EpParentSfId { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        [ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string EpWorkID { get; set; }

        [ExcelColumn(Name = "考核年度")]
        [ExcelColumnName("考核年度")]
        public string EpAssessmentYear { get; set; }

        [ExcelColumn(Name = "考核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("考核日期")]
        public DateTime? EpAssessmentDate { get; set; }

        [ExcelColumn(Name = "工作绩效")]
        [ExcelColumnName("工作绩效")]
        public int? EpWorkPerformance { get; set; }

        [ExcelColumn(Name = "专业知识")]
        [ExcelColumnName("专业知识")]
        public int? EpExpertise { get; set; }

        [ExcelColumn(Name = "工作态度")]
        [ExcelColumnName("工作态度")]
        public int? EpWorkingAttitude { get; set; }

        [ExcelColumn(Name = "领导能力")]
        [ExcelColumnName("领导能力")]
        public int? EpLeadershipSkills { get; set; }

        [ExcelColumn(Name = "员工纪律")]
        [ExcelColumnName("员工纪律")]
        public int? EpDiscipline { get; set; }

        [ExcelColumn(Name = "员工士气")]
        [ExcelColumnName("员工士气")]
        public int? EpMorale { get; set; }

        [ExcelColumn(Name = "监督实效")]
        [ExcelColumnName("监督实效")]
        public int? EpEffectiveness { get; set; }

        [ExcelColumn(Name = "决策分析")]
        [ExcelColumnName("决策分析")]
        public int? EpDecision { get; set; }

        [ExcelColumn(Name = "沟通协调")]
        [ExcelColumnName("沟通协调")]
        public int? EpCommunication { get; set; }

        [ExcelColumn(Name = "成本意识")]
        [ExcelColumnName("成本意识")]
        public int? EpConsciousness { get; set; }

        [ExcelColumn(Name = "判断对策")]
        [ExcelColumnName("判断对策")]
        public int? EpJudgement { get; set; }

        [ExcelColumn(Name = "前瞻创造")]
        [ExcelColumnName("前瞻创造")]
        public int? EpCreativity { get; set; }

        [ExcelColumn(Name = "控制能力")]
        [ExcelColumnName("控制能力")]
        public int? EpControl { get; set; }

        [ExcelColumn(Name = "持续力")]
        [ExcelColumnName("持续力")]
        public int? EpSustainability { get; set; }

        [ExcelColumn(Name = "自信心")]
        [ExcelColumnName("自信心")]
        public int? EpSelfConfidence { get; set; }

        [ExcelColumn(Name = "适应能力")]
        [ExcelColumnName("适应能力")]
        public int? EpAdaptability { get; set; }

        [ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日期")]
        public DateTime? EpEffectiveDate { get; set; }

        [ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? EpAuditDate { get; set; }

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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
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
        [ExcelColumn(Name = "考核年度")]
        public string EpAssessmentYearLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}