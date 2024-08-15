namespace Ams.Model.Logistics
{
    /// <summary>
    /// Iqc设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:41:59
    /// </summary>
    [SugarTable("pp_ec_slave_iqc", "Iqc设变")]
    public class PpEcSlaveIqc : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>

        [SugarColumn(IsPrimaryKey = false, IsIdentity = false)]
        public long? IqcSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? IqcParentSfId { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        [SugarColumn(ColumnName = "IqcEcNo", ColumnDescription = "设变No. ", Length = 20)]
        public string IqcEcNo { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "IqcModel", ColumnDescription = "机种 ", Length = 200)]
        public string IqcModel { get; set; }

        /// <summary>
        /// 新物料
        /// </summary>
        [SugarColumn(ColumnName = "IqcNewItem", ColumnDescription = "新物料 ", Length = 20)]
        public string IqcNewItem { get; set; }

        /// <summary>
        /// 新文本
        /// </summary>
        [SugarColumn(ColumnName = "IqcNewItemText", ColumnDescription = "新文本 ", Length = 40)]
        public string IqcNewItemText { get; set; }

        /// <summary>
        /// 新品库存
        /// </summary>
        [SugarColumn(ColumnName = "IqcNewCurrStock", ColumnDescription = "新品库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal IqcNewCurrStock { get; set; }

        /// <summary>
        /// 采购类型
        /// </summary>
        [SugarColumn(ColumnName = "IqcPurType", ColumnDescription = "采购类型 ", Length = 1)]
        public string IqcPurType { get; set; }

        /// <summary>
        /// 采购组
        /// </summary>
        [SugarColumn(ColumnName = "IqcPurGroup", ColumnDescription = "采购组 ", Length = 10)]
        public string IqcPurGroup { get; set; }

        /// <summary>
        /// 检验否
        /// </summary>
        [SugarColumn(ColumnName = "IqcInsmk", ColumnDescription = "检验否 ", Length = 1)]
        public string IqcInsmk { get; set; }

        /// <summary>
        /// 实施标记
        /// </summary>
        [SugarColumn(ColumnName = "IqcImplStated", ColumnDescription = "实施标记 ", DefaultValue = "0")]
        public int IqcImplStated { get; set; }

        /// <summary>
        /// IQC登入日期
        /// </summary>
        public DateTime? IqcEnteredDate { get; set; }

        /// <summary>
        /// 检验订单
        /// </summary>
        [SugarColumn(ColumnName = "IqcPurOrder", ColumnDescription = "检验订单 ", Length = 20)]
        public string IqcPurOrder { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "IqcNote", ColumnDescription = "说明 ", Length = 255)]
        public string IqcNote { get; set; }
    }
}