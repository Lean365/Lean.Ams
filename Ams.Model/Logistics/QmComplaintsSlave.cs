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
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long QmcsSfId { get; set; }

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
    }
}