namespace Ams.Model.Logistics
{
    /// <summary>
    /// 出货检验
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:46:39
    /// </summary>
    [SugarTable("qm_outgoing", "出货检验")]
    public class QmOutgoing : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long QmoutSfId { get; set; }

        /// <summary>
        /// 生产工单
        /// </summary>
        [SugarColumn(ColumnName = "QmoutProOrder", ColumnDescription = "生产工单 ", Length = 20)]
        public string QmoutProOrder { get; set; }

        /// <summary>
        /// 班组
        /// </summary>
        [SugarColumn(ColumnName = "QmoutProLine", ColumnDescription = "班组 ", Length = 10)]
        public string QmoutProLine { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "QmoutProModels", ColumnDescription = "机种 ", Length = 20)]
        public string QmoutProModels { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "QmoutProMaterial", ColumnDescription = "物料 ", Length = 20)]
        public string QmoutProMaterial { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [SugarColumn(ColumnName = "QmoutProLot", ColumnDescription = "批次 ", Length = 20)]
        public string QmoutProLot { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [SugarColumn(ColumnName = "QmoutProSerial", ColumnDescription = "序号 ", Length = 50)]
        public string QmoutProSerial { get; set; }

        /// <summary>
        /// 送检数量
        /// </summary>
        [SugarColumn(ColumnName = "QmoutProQty", ColumnDescription = "送检数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal QmoutProQty { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? QmoutProDate { get; set; }

        /// <summary>
        /// 检查员
        /// </summary>
        [SugarColumn(ColumnName = "QmoutInspector", ColumnDescription = "检查员 ", Length = 20)]
        public string QmoutInspector { get; set; }

        /// <summary>
        /// 查验日期
        /// </summary>
        public DateTime? QmoutCheckDate { get; set; }

        /// <summary>
        /// 检查项目
        /// </summary>
        [SugarColumn(ColumnName = "QmoutInspectingItem", ColumnDescription = "检查项目 ", Length = 50)]
        public string QmoutInspectingItem { get; set; }

        /// <summary>
        /// 检验水准
        /// </summary>
        [SugarColumn(ColumnName = "QmoutSamplingLevel", ColumnDescription = "检验水准 ", Length = 4)]
        public string QmoutSamplingLevel { get; set; }

        /// <summary>
        /// 检验方式
        /// </summary>
        [SugarColumn(ColumnName = "QmoutCheckMethod", ColumnDescription = "检验方式 ", Length = 4)]
        public string QmoutCheckMethod { get; set; }

        /// <summary>
        /// 抽样数
        /// </summary>
        [SugarColumn(ColumnName = "QmoutSamplingQty", ColumnDescription = "抽样数 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal QmoutSamplingQty { get; set; }

        /// <summary>
        /// 判定
        /// </summary>
        [SugarColumn(ColumnName = "QmoutJudgment", ColumnDescription = "判定 ", Length = 4)]
        public string QmoutJudgment { get; set; }

        /// <summary>
        /// 不良级别
        /// </summary>
        [SugarColumn(ColumnName = "QmoutJudgmentLevel", ColumnDescription = "不良级别 ", Length = 10)]
        public string QmoutJudgmentLevel { get; set; }

        /// <summary>
        /// 验退数
        /// </summary>
        [SugarColumn(ColumnName = "QmoutRejectQty", ColumnDescription = "验退数 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal QmoutRejectQty { get; set; }

        /// <summary>
        /// 检查号码
        /// </summary>
        [SugarColumn(ColumnName = "QmoutCheckNotes", ColumnDescription = "检查号码 ", Length = 500)]
        public string QmoutCheckNotes { get; set; }

        /// <summary>
        /// 特记事项
        /// </summary>
        [SugarColumn(ColumnName = "QmoutSpecialNotes", ColumnDescription = "特记事项 ", Length = 500)]
        public string QmoutSpecialNotes { get; set; }

        /// <summary>
        /// 验收数量
        /// </summary>
        [SugarColumn(ColumnName = "QmoutAcceptQty", ColumnDescription = "验收数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal QmoutAcceptQty { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        [SugarColumn(ColumnName = "QmoutOrderQty", ColumnDescription = "订单数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal QmoutOrderQty { get; set; }

        /// <summary>
        /// 检验次数
        /// </summary>
        [SugarColumn(ColumnName = "QmoutCheckoutSequence", ColumnDescription = "检验次数 ", DefaultValue = "0")]
        public int QmoutCheckoutSequence { get; set; }
    }
}