namespace Ams.Model.Routine
{
    /// <summary>
    /// 绩效
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 17:18:14
    /// </summary>
    [SugarTable("routine_ehr_performance", "绩效")]
    public class RoutineEhrPerformance : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long EpSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public long EpParentSfId { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [SugarColumn(ColumnName = "EpWorkID", ColumnDescription = "工号 ", Length = 8)]
        public string EpWorkID { get; set; }

        /// <summary>
        /// 考核年度
        /// </summary>
        [SugarColumn(ColumnName = "EpAssessmentYear", ColumnDescription = "考核年度 ", Length = 4)]
        public string EpAssessmentYear { get; set; }

        /// <summary>
        /// 考核日期
        /// </summary>
        public DateTime? EpAssessmentDate { get; set; }

        /// <summary>
        /// 工作绩效
        /// </summary>
        [SugarColumn(ColumnName = "EpWorkPerformance", ColumnDescription = "工作绩效 ", DefaultValue = "0")]
        public int? EpWorkPerformance { get; set; }

        /// <summary>
        /// 专业知识
        /// </summary>
        [SugarColumn(ColumnName = "EpExpertise", ColumnDescription = "专业知识 ", DefaultValue = "0")]
        public int? EpExpertise { get; set; }

        /// <summary>
        /// 工作态度
        /// </summary>
        [SugarColumn(ColumnName = "EpWorkingAttitude", ColumnDescription = "工作态度 ", DefaultValue = "0")]
        public int? EpWorkingAttitude { get; set; }

        /// <summary>
        /// 领导能力
        /// </summary>
        [SugarColumn(ColumnName = "EpLeadershipSkills", ColumnDescription = "领导能力 ", DefaultValue = "0")]
        public int? EpLeadershipSkills { get; set; }

        /// <summary>
        /// 员工纪律
        /// </summary>
        [SugarColumn(ColumnName = "EpDiscipline", ColumnDescription = "员工纪律 ", DefaultValue = "0")]
        public int? EpDiscipline { get; set; }

        /// <summary>
        /// 员工士气
        /// </summary>
        [SugarColumn(ColumnName = "EpMorale", ColumnDescription = "员工士气 ", DefaultValue = "0")]
        public int? EpMorale { get; set; }

        /// <summary>
        /// 监督实效
        /// </summary>
        [SugarColumn(ColumnName = "EpEffectiveness", ColumnDescription = "监督实效 ", DefaultValue = "0")]
        public int? EpEffectiveness { get; set; }

        /// <summary>
        /// 决策分析
        /// </summary>
        [SugarColumn(ColumnName = "EpDecision", ColumnDescription = "决策分析 ", DefaultValue = "0")]
        public int? EpDecision { get; set; }

        /// <summary>
        /// 沟通协调
        /// </summary>
        [SugarColumn(ColumnName = "EpCommunication", ColumnDescription = "沟通协调 ", DefaultValue = "0")]
        public int? EpCommunication { get; set; }

        /// <summary>
        /// 成本意识
        /// </summary>
        [SugarColumn(ColumnName = "EpConsciousness", ColumnDescription = "成本意识 ", DefaultValue = "0")]
        public int? EpConsciousness { get; set; }

        /// <summary>
        /// 判断对策
        /// </summary>
        [SugarColumn(ColumnName = "EpJudgement", ColumnDescription = "判断对策 ", DefaultValue = "0")]
        public int? EpJudgement { get; set; }

        /// <summary>
        /// 前瞻创造
        /// </summary>
        [SugarColumn(ColumnName = "EpCreativity", ColumnDescription = "前瞻创造 ", DefaultValue = "0")]
        public int? EpCreativity { get; set; }

        /// <summary>
        /// 控制能力
        /// </summary>
        [SugarColumn(ColumnName = "EpControl", ColumnDescription = "控制能力 ", DefaultValue = "0")]
        public int? EpControl { get; set; }

        /// <summary>
        /// 持续力
        /// </summary>
        [SugarColumn(ColumnName = "EpSustainability", ColumnDescription = "持续力 ", DefaultValue = "0")]
        public int? EpSustainability { get; set; }

        /// <summary>
        /// 自信心
        /// </summary>
        [SugarColumn(ColumnName = "EpSelfConfidence", ColumnDescription = "自信心 ", DefaultValue = "0")]
        public int? EpSelfConfidence { get; set; }

        /// <summary>
        /// 适应能力
        /// </summary>
        [SugarColumn(ColumnName = "EpAdaptability", ColumnDescription = "适应能力 ", DefaultValue = "0")]
        public int? EpAdaptability { get; set; }

        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime? EpEffectiveDate { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? EpAuditDate { get; set; }
    }
}