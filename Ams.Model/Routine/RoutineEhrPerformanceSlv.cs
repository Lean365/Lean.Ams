
namespace Ams.Model.Routine
{
    /// <summary>
    /// 绩效
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 17:21:01
    /// </summary>
    [SugarTable("routine_ehr_performance_slv","绩效")]
    public class RoutineEhrPerformanceSlv
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
        /// 考核项目 
        /// </summary>
        [SugarColumn(ColumnName="EpEvalItems", ColumnDescription = "考核项目",DefaultValue = "0")]
        public int? EpEvalItems { get; set; }

        /// <summary>
        /// 初次评分 
        /// </summary>
        [SugarColumn(ColumnName="EpFirstEvalScore", ColumnDescription = "初次评分",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal EpFirstEvalScore { get; set; }

        /// <summary>
        /// 初评人 
        /// </summary>
        [SugarColumn(ColumnName="EpFirstEvaluator", ColumnDescription = "初评人",Length = 40)]
        public string EpFirstEvaluator { get; set; }

        /// <summary>
        /// 初评日期 
        /// </summary>
        public DateTime? EpFirstEvalDate { get; set; }

        /// <summary>
        /// 二次评分 
        /// </summary>
        [SugarColumn(ColumnName="EpSecondEvalScore", ColumnDescription = "二次评分",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal EpSecondEvalScore { get; set; }

        /// <summary>
        /// 二次考评人 
        /// </summary>
        [SugarColumn(ColumnName="ESecondEvaluator", ColumnDescription = "二次考评人",Length = 40)]
        public string ESecondEvaluator { get; set; }

        /// <summary>
        /// 二次考评日期 
        /// </summary>
        public DateTime? EpSecondEvalDate { get; set; }

        /// <summary>
        /// 三次评分 
        /// </summary>
        [SugarColumn(ColumnName="EpThirdEvalScore", ColumnDescription = "三次评分",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal EpThirdEvalScore { get; set; }

        /// <summary>
        /// 三次考评人 
        /// </summary>
        [SugarColumn(ColumnName="EpThirdEvaluator", ColumnDescription = "三次考评人",Length = 40)]
        public string EpThirdEvaluator { get; set; }

        /// <summary>
        /// 三次考评日期 
        /// </summary>
        public DateTime? EpThirdEvalDate { get; set; }

        /// <summary>
        /// 四次评分 
        /// </summary>
        [SugarColumn(ColumnName="EpFourthEvalScore", ColumnDescription = "四次评分",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal EpFourthEvalScore { get; set; }

        /// <summary>
        /// 四次考评人 
        /// </summary>
        [SugarColumn(ColumnName="EpFourthEvaluator", ColumnDescription = "四次考评人",Length = 40)]
        public string EpFourthEvaluator { get; set; }

        /// <summary>
        /// 四次考评日期 
        /// </summary>
        public DateTime? EpFourthEvalDate { get; set; }

        /// <summary>
        /// 五次评分 
        /// </summary>
        [SugarColumn(ColumnName="EpFifthEvalScore", ColumnDescription = "五次评分",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal EpFifthEvalScore { get; set; }

        /// <summary>
        /// 五次考评人 
        /// </summary>
        [SugarColumn(ColumnName="EpFifthEvaluator", ColumnDescription = "五次考评人",Length = 40)]
        public string EpFifthEvaluator { get; set; }

        /// <summary>
        /// 五次考评日期 
        /// </summary>
        public DateTime? EFifthEvalDate { get; set; }

        /// <summary>
        /// 六次评分 
        /// </summary>
        [SugarColumn(ColumnName="EpSixthEvalScore", ColumnDescription = "六次评分",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal EpSixthEvalScore { get; set; }

        /// <summary>
        /// 六次考评人 
        /// </summary>
        [SugarColumn(ColumnName="EpSixthEvaluator", ColumnDescription = "六次考评人",Length = 40)]
        public string EpSixthEvaluator { get; set; }

        /// <summary>
        /// 六次考评日期 
        /// </summary>
        public DateTime? EpSixthEvalDate { get; set; }

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