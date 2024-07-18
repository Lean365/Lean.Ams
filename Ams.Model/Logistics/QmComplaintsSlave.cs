namespace Ams.Model.Logistics
{
    /// <summary>
    /// 从客诉管理
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 12:08:23
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
        public string QmcsIssuesNo { get; set; }

        /// <summary>
        /// 班组
        /// </summary>
        public string QmcsLine { get; set; }

        /// <summary>
        /// 处理日期
        /// </summary>
        public DateTime? QmcsProcessingDate { get; set; }

        /// <summary>
        /// 问题描述
        /// </summary>
        public string QmcsDescription { get; set; }

        /// <summary>
        /// 原因分析
        /// </summary>
        public string QmcsCauseAnalysis { get; set; }

        /// <summary>
        /// 作业员
        /// </summary>
        public string QmcsOperator { get; set; }

        /// <summary>
        /// 工位
        /// </summary>
        public string QmcsStation { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        public string QmcsLot { get; set; }

        /// <summary>
        /// 改善对策
        /// </summary>
        public string QmcsMeasures { get; set; }

        /// <summary>
        /// 改善文件
        /// </summary>
        public string QmcsReformDocs { get; set; }

        /// <summary>
        /// 自定义A
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsDeleted { get; set; }
    }
}