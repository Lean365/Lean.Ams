namespace Ams.Model.Logistics
{
    /// <summary>
    /// 分析对策
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:07:55
    /// </summary>
    [SugarTable("qm_improvement_replyletter", "分析对策")]
    public class QmImprovementReplyletter : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long QirdSFID { get; set; }

        /// <summary>
        /// 检查员
        /// </summary>
        [SugarColumn(ColumnName = "QirdInspector", ColumnDescription = "检查员 ", Length = 20)]
        public string QirdInspector { get; set; }

        /// <summary>
        /// 班组
        /// </summary>
        [SugarColumn(ColumnName = "QirdLine", ColumnDescription = "班组 ", Length = 10)]
        public string QirdLine { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        [SugarColumn(ColumnName = "QirdOrder", ColumnDescription = "订单 ", Length = 20)]
        public string QirdOrder { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "QirdModels", ColumnDescription = "机种 ", Length = 20)]
        public string QirdModels { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "QirdMaterial", ColumnDescription = "物料 ", Length = 20)]
        public string QirdMaterial { get; set; }

        /// <summary>
        /// 仕向
        /// </summary>
        [SugarColumn(ColumnName = "QirdRegion", ColumnDescription = "仕向 ", Length = 20)]
        public string QirdRegion { get; set; }

        /// <summary>
        /// 检验日期
        /// </summary>
        public DateTime? QirdCheckDate { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [SugarColumn(ColumnName = "QirdProLot", ColumnDescription = "批次 ", Length = 20)]
        public string QirdProLot { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [SugarColumn(ColumnName = "QirdProSerial", ColumnDescription = "序号 ", Length = 50)]
        public string QirdProSerial { get; set; }

        /// <summary>
        /// 验退数
        /// </summary>
        [SugarColumn(ColumnName = "QirdRejectQty", ColumnDescription = "验退数 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal QirdRejectQty { get; set; }

        /// <summary>
        /// 不良级别
        /// </summary>
        [SugarColumn(ColumnName = "QirdJudgmentLevel", ColumnDescription = "不良级别 ", Length = 10)]
        public string QirdJudgmentLevel { get; set; }

        /// <summary>
        /// 不良内容
        /// </summary>
        [SugarColumn(ColumnName = "QirdCheckNotes", ColumnDescription = "不良内容 ", Length = 300)]
        public string QirdCheckNotes { get; set; }

        /// <summary>
        /// 对策人员
        /// </summary>
        [SugarColumn(ColumnName = "QirdPersonnel", ColumnDescription = "对策人员 ", Length = 20)]
        public string QirdPersonnel { get; set; }

        /// <summary>
        /// 对应日期
        /// </summary>
        public DateTime? QirdDate { get; set; }

        /// <summary>
        /// 直接原因
        /// </summary>
        [SugarColumn(ColumnName = "QirdDirectreason", ColumnDescription = "直接原因 ", Length = 300)]
        public string QirdDirectreason { get; set; }

        /// <summary>
        /// 间接原因
        /// </summary>
        [SugarColumn(ColumnName = "QirdIndirectreason", ColumnDescription = "间接原因 ", Length = 300)]
        public string QirdIndirectreason { get; set; }

        /// <summary>
        /// 处置
        /// </summary>
        [SugarColumn(ColumnName = "QirdDisposal", ColumnDescription = "处置 ", Length = 300)]
        public string QirdDisposal { get; set; }

        /// <summary>
        /// 直接对策
        /// </summary>
        [SugarColumn(ColumnName = "QirdDirectsolutions", ColumnDescription = "直接对策 ", Length = 300)]
        public string QirdDirectsolutions { get; set; }

        /// <summary>
        /// 间接对策
        /// </summary>
        [SugarColumn(ColumnName = "QirdIndirectsolutions", ColumnDescription = "间接对策 ", Length = 300)]
        public string QirdIndirectsolutions { get; set; }

        /// <summary>
        /// 检证人员
        /// </summary>
        [SugarColumn(ColumnName = "QirdVerify", ColumnDescription = "检证人员 ", Length = 20)]
        public string QirdVerify { get; set; }

        /// <summary>
        /// 实施日期
        /// </summary>
        public DateTime? QirdCarryoutdate { get; set; }

        /// <summary>
        /// 实施查证
        /// </summary>
        [SugarColumn(ColumnName = "QirdCarryoutverify", ColumnDescription = "实施查证 ", DefaultValue = "0")]
        public int QirdCarryoutverify { get; set; }

        /// <summary>
        /// 对策实施查证
        /// </summary>
        [SugarColumn(ColumnName = "QirdSolutionsverify", ColumnDescription = "对策实施查证 ", Length = 300)]
        public string QirdSolutionsverify { get; set; }

        /// <summary>
        /// 特记事项
        /// </summary>
        [SugarColumn(ColumnName = "QirdNotes", ColumnDescription = "特记事项 ", Length = 300)]
        public string QirdNotes { get; set; }

        /// <summary>
        /// 发行号码
        /// </summary>
        [SugarColumn(ColumnName = "QirdIssueno", ColumnDescription = "发行号码 ", Length = 20)]
        public string QirdIssueno { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        [SugarColumn(ColumnName = "QirdFileUrl", ColumnDescription = "附件 ", Length = 20)]
        public string QirdFileUrl { get; set; }

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