
namespace Ams.Model.Routine
{
    /// <summary>
    /// 培训
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 17:22:49
    /// </summary>
    [SugarTable("routine_ehr_training_slv","培训")]
    public class RoutineEhrTrainingSlv
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
        public long? EpParentSfId { get; set; }

        /// <summary>
        /// 项目 
        /// </summary>
        [SugarColumn(ColumnName="EpTrainingItems", ColumnDescription = "项目",DefaultValue = "0")]
        public int? EpTrainingItems { get; set; }

        /// <summary>
        /// 内容 
        /// </summary>
        [SugarColumn(ColumnName="EpTrainingContent", ColumnDescription = "内容",Length = -1)]
        public string EpTrainingContent { get; set; }

        /// <summary>
        /// 目的 
        /// </summary>
        [SugarColumn(ColumnName="EpTrainingPurpose", ColumnDescription = "目的",Length = -1)]
        public string EpTrainingPurpose { get; set; }

        /// <summary>
        /// 分数 
        /// </summary>
        [SugarColumn(ColumnName="EpTrainingScore", ColumnDescription = "分数",DefaultValue = "0")]
        public int? EpTrainingScore { get; set; }

        /// <summary>
        /// 结果 
        /// </summary>
        [SugarColumn(ColumnName="EpTrainingResults", ColumnDescription = "结果",Length = 4)]
        public string EpTrainingResults { get; set; }

        /// <summary>
        /// 日期 
        /// </summary>
        public DateTime? EpTrainingDate { get; set; }

        /// <summary>
        /// 指导老师 
        /// </summary>
        [SugarColumn(ColumnName="EpTrainingTeacher", ColumnDescription = "指导老师",Length = 40)]
        public string EpTrainingTeacher { get; set; }

        /// <summary>
        /// 确认 
        /// </summary>
        [SugarColumn(ColumnName="EpFirstConfirmer", ColumnDescription = "确认",Length = 40)]
        public string EpFirstConfirmer { get; set; }

        /// <summary>
        /// 确认 
        /// </summary>
        [SugarColumn(ColumnName="EpSecondConfirmer", ColumnDescription = "确认",Length = 40)]
        public string EpSecondConfirmer { get; set; }

        /// <summary>
        /// 确认 
        /// </summary>
        [SugarColumn(ColumnName="EpThirdConfirmer", ColumnDescription = "确认",Length = 40)]
        public string EpThirdConfirmer { get; set; }

        /// <summary>
        /// 承认 
        /// </summary>
        [SugarColumn(ColumnName="EpFourthApprover", ColumnDescription = "承认",Length = 40)]
        public string EpFourthApprover { get; set; }

        /// <summary>
        /// 承认 
        /// </summary>
        [SugarColumn(ColumnName="EpFifthApprover", ColumnDescription = "承认",Length = 40)]
        public string EpFifthApprover { get; set; }

        /// <summary>
        /// 承认 
        /// </summary>
        [SugarColumn(ColumnName="EpSixthApprover", ColumnDescription = "承认",Length = 40)]
        public string EpSixthApprover { get; set; }

        /// <summary>
        /// 预留A 
        /// </summary>
        [SugarColumn(ColumnName="REF01", ColumnDescription = "预留A",Length = 1)]
        public string REF01 { get; set; }

        /// <summary>
        /// 预留B 
        /// </summary>
        [SugarColumn(ColumnName="REF02", ColumnDescription = "预留B",Length = 8)]
        public string REF02 { get; set; }

        /// <summary>
        /// 预留C 
        /// </summary>
        [SugarColumn(ColumnName="REF03", ColumnDescription = "预留C",Length = 30)]
        public string REF03 { get; set; }

        /// <summary>
        /// 预留1 
        /// </summary>
        [SugarColumn(ColumnName="REF04", ColumnDescription = "预留1",DefaultValue = "0",Length = 18, DecimalDigits = 5)]
        public decimal REF04 { get; set; }

        /// <summary>
        /// 预留2 
        /// </summary>
        [SugarColumn(ColumnName="REF05", ColumnDescription = "预留2",DefaultValue = "0",Length = 18, DecimalDigits = 5)]
        public decimal REF05 { get; set; }

        /// <summary>
        /// 预留3 
        /// </summary>
        [SugarColumn(ColumnName="REF06", ColumnDescription = "预留3",DefaultValue = "0",Length = 18, DecimalDigits = 5)]
        public decimal REF06 { get; set; }

        /// <summary>
        /// 自定义A 
        /// </summary>
        [SugarColumn(ColumnName="UDF01", ColumnDescription = "自定义A",Length = 200)]
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B 
        /// </summary>
        [SugarColumn(ColumnName="UDF02", ColumnDescription = "自定义B",Length = 200)]
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C 
        /// </summary>
        [SugarColumn(ColumnName="UDF03", ColumnDescription = "自定义C",Length = 200)]
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D 
        /// </summary>
        [SugarColumn(ColumnName="UDF04", ColumnDescription = "自定义D",Length = 500)]
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E 
        /// </summary>
        [SugarColumn(ColumnName="UDF05", ColumnDescription = "自定义E",Length = 500)]
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F 
        /// </summary>
        [SugarColumn(ColumnName="UDF06", ColumnDescription = "自定义F",Length = 500)]
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1 
        /// </summary>
        [SugarColumn(ColumnName="UDF51", ColumnDescription = "自定义1",DefaultValue = "0")]
        public int? UDF51 { get; set; }

        /// <summary>
        /// 自定义2 
        /// </summary>
        [SugarColumn(ColumnName="UDF52", ColumnDescription = "自定义2",DefaultValue = "0")]
        public int? UDF52 { get; set; }

        /// <summary>
        /// 自定义3 
        /// </summary>
        [SugarColumn(ColumnName="UDF53", ColumnDescription = "自定义3",DefaultValue = "0")]
        public int? UDF53 { get; set; }

        /// <summary>
        /// 自定义4 
        /// </summary>
        [SugarColumn(ColumnName="UDF54", ColumnDescription = "自定义4",DefaultValue = "0",Length = 18, DecimalDigits = 5)]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5 
        /// </summary>
        [SugarColumn(ColumnName="UDF55", ColumnDescription = "自定义5",DefaultValue = "0",Length = 18, DecimalDigits = 5)]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6 
        /// </summary>
        [SugarColumn(ColumnName="UDF56", ColumnDescription = "自定义6",DefaultValue = "0",Length = 18, DecimalDigits = 5)]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        [SugarColumn(ColumnName="IsDeleted", ColumnDescription = "软删除",DefaultValue = "0")]
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 备注说明 
        /// </summary>
        [SugarColumn(ColumnName="Remark", ColumnDescription = "备注说明",Length = 500)]
        public string Remark { get; set; }

        /// <summary>
        /// 创建人员 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新人员 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 更新时间 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }

    }
}