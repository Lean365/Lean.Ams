namespace Ams.Model.Logistics
{
    /// <summary>
    /// 从客诉管理
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:39:58
    /// </summary>
    [SugarTable("qm_complaints_slave", "从客诉管理")]
    public class QmComplaintsSlave : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long QmcsSFID { get; set; }

        /// <summary>
        /// 外部客诉No.
        /// </summary>
        [SugarColumn(ColumnName = "QmcsIssuesNo", ColumnDescription = "外部客诉No. ", Length = 20)]
        public string QmcsIssuesNo { get; set; }

        /// <summary>
        /// 班组
        /// </summary>
        [SugarColumn(ColumnName = "QmcsLine", ColumnDescription = "班组 ", Length = 20)]
        public string QmcsLine { get; set; }

        /// <summary>
        /// 处理日期
        /// </summary>
        public DateTime? QmcsProcessingDate { get; set; }

        /// <summary>
        /// 问题描述
        /// </summary>
        [SugarColumn(ColumnName = "QmcsDescription", ColumnDescription = "问题描述 ", Length = 4000)]
        public string QmcsDescription { get; set; }

        /// <summary>
        /// 原因分析
        /// </summary>
        [SugarColumn(ColumnName = "QmcsCauseAnalysis", ColumnDescription = "原因分析 ", Length = 4000)]
        public string QmcsCauseAnalysis { get; set; }

        /// <summary>
        /// 作业员
        /// </summary>
        [SugarColumn(ColumnName = "QmcsOperator", ColumnDescription = "作业员 ", Length = 40)]
        public string QmcsOperator { get; set; }

        /// <summary>
        /// 工位
        /// </summary>
        [SugarColumn(ColumnName = "QmcsStation", ColumnDescription = "工位 ", Length = 4000)]
        public string QmcsStation { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [SugarColumn(ColumnName = "QmcsLot", ColumnDescription = "批次 ", Length = 40)]
        public string QmcsLot { get; set; }

        /// <summary>
        /// 改善对策
        /// </summary>
        [SugarColumn(ColumnName = "QmcsMeasures", ColumnDescription = "改善对策 ", Length = 4000)]
        public string QmcsMeasures { get; set; }

        /// <summary>
        /// 改善文件
        /// </summary>
        [SugarColumn(ColumnName = "QmcsReformDocs", ColumnDescription = "改善文件 ", Length = 200)]
        public string QmcsReformDocs { get; set; }

        /// <summary>
        /// 自定义A
        /// </summary>
        [SugarColumn(ColumnName = "UDF01", ColumnDescription = "自定义A ", Length = 200)]
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B
        /// </summary>
        [SugarColumn(ColumnName = "UDF02", ColumnDescription = "自定义B ", Length = 200)]
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C
        /// </summary>
        [SugarColumn(ColumnName = "UDF03", ColumnDescription = "自定义C ", Length = 200)]
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D
        /// </summary>
        [SugarColumn(ColumnName = "UDF04", ColumnDescription = "自定义D ", Length = 200)]
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E
        /// </summary>
        [SugarColumn(ColumnName = "UDF05", ColumnDescription = "自定义E ", Length = 200)]
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F
        /// </summary>
        [SugarColumn(ColumnName = "UDF06", ColumnDescription = "自定义F ", Length = 200)]
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1
        /// </summary>
        [SugarColumn(ColumnName = "UDF51", ColumnDescription = "自定义1 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2
        /// </summary>
        [SugarColumn(ColumnName = "UDF52", ColumnDescription = "自定义2 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3
        /// </summary>
        [SugarColumn(ColumnName = "UDF53", ColumnDescription = "自定义3 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4
        /// </summary>
        [SugarColumn(ColumnName = "UDF54", ColumnDescription = "自定义4 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5
        /// </summary>
        [SugarColumn(ColumnName = "UDF55", ColumnDescription = "自定义5 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6
        /// </summary>
        [SugarColumn(ColumnName = "UDF56", ColumnDescription = "自定义6 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        [SugarColumn(ColumnName = "IsDeleted", ColumnDescription = "软删除 ", DefaultValue = "0")]
        public int IsDeleted { get; set; }
    }
}