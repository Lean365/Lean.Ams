namespace Ams.Model.Logistics
{
    /// <summary>
    /// 不合格联络
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:07:53
    /// </summary>
    [SugarTable("qm_unqualified_contactletter", "不合格联络")]
    public class QmUnqualifiedContactletter : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long QucdSfId { get; set; }

        /// <summary>
        /// 检查员
        /// </summary>
        [SugarColumn(ColumnName = "QucdInspector", ColumnDescription = "检查员 ", Length = 20)]
        public string QucdInspector { get; set; }

        /// <summary>
        /// 班组
        /// </summary>
        [SugarColumn(ColumnName = "QucdLine", ColumnDescription = "班组 ", Length = 10)]
        public string QucdLine { get; set; }

        /// <summary>
        /// 订单
        /// </summary>
        [SugarColumn(ColumnName = "QucdOrder", ColumnDescription = "订单 ", Length = 20)]
        public string QucdOrder { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "QucdModels", ColumnDescription = "机种 ", Length = 20)]
        public string QucdModels { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "QucdMaterial", ColumnDescription = "物料 ", Length = 20)]
        public string QucdMaterial { get; set; }

        /// <summary>
        /// 仕向
        /// </summary>
        [SugarColumn(ColumnName = "QucdRegion", ColumnDescription = "仕向 ", Length = 20)]
        public string QucdRegion { get; set; }

        /// <summary>
        /// 查验日期
        /// </summary>
        public DateTime? QucdCheckDate { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [SugarColumn(ColumnName = "QucdProLot", ColumnDescription = "批次 ", Length = 20)]
        public string QucdProLot { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [SugarColumn(ColumnName = "QucdProSerial", ColumnDescription = "序号 ", Length = 50)]
        public string QucdProSerial { get; set; }

        /// <summary>
        /// 验退数
        /// </summary>
        [SugarColumn(ColumnName = "QucdRejectQty", ColumnDescription = "验退数 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal QucdRejectQty { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        [SugarColumn(ColumnName = "QucdJudgmentLevel", ColumnDescription = "级别 ", Length = 10)]
        public string QucdJudgmentLevel { get; set; }

        /// <summary>
        /// 判定说明
        /// </summary>
        [SugarColumn(ColumnName = "QucdCheckNotes", ColumnDescription = "判定说明 ", Length = 300)]
        public string QucdCheckNotes { get; set; }

        /// <summary>
        /// 发行号码
        /// </summary>
        [SugarColumn(ColumnName = "QucdIssueno", ColumnDescription = "发行号码 ", Length = 20)]
        public string QucdIssueno { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        [SugarColumn(ColumnName = "QucdFileUrl", ColumnDescription = "附件 ", Length = 20)]
        public string QucdFileUrl { get; set; }
    }
}