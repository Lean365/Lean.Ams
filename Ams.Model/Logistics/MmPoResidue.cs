namespace Ams.Model.Logistics
{
    /// <summary>
    /// PO残清单
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:59:13
    /// </summary>
    [SugarTable("mm_po_residue", "PO残清单")]
    public class MmPoResidue : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long PrSfId { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "PrPlant", ColumnDescription = "工厂 ", Length = 4)]
        public string PrPlant { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        [SugarColumn(ColumnName = "PrSupplierCode", ColumnDescription = "供应商ID ", Length = 10)]
        public string PrSupplierCode { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [SugarColumn(ColumnName = "PrSupplierName", ColumnDescription = "供应商名称 ", Length = 40)]
        public string PrSupplierName { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "PrPurItem", ColumnDescription = "物料 ", Length = 20)]
        public string PrPurItem { get; set; }

        /// <summary>
        /// 物料文本
        /// </summary>
        [SugarColumn(ColumnName = "PrPurItemText", ColumnDescription = "物料文本 ", Length = 40)]
        public string PrPurItemText { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        [SugarColumn(ColumnName = "PrLocation", ColumnDescription = "仓库 ", Length = 4)]
        public string PrLocation { get; set; }

        /// <summary>
        /// 交货日期
        /// </summary>
        public DateTime? PrDelivDate { get; set; }

        /// <summary>
        /// 未交
        /// </summary>
        [SugarColumn(ColumnName = "PrUnpaidQty", ColumnDescription = "未交 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal PrUnpaidQty { get; set; }

        /// <summary>
        /// 已交
        /// </summary>
        [SugarColumn(ColumnName = "PrAlreadyQty", ColumnDescription = "已交 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal PrAlreadyQty { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [SugarColumn(ColumnName = "PrPurOrder", ColumnDescription = "订单号 ", Length = 10)]
        public string PrPurOrder { get; set; }

        /// <summary>
        /// 订单明细
        /// </summary>
        [SugarColumn(ColumnName = "PrPurOrderDetails", ColumnDescription = "订单明细 ", Length = 5)]
        public string PrPurOrderDetails { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        [SugarColumn(ColumnName = "PrPlannedQty", ColumnDescription = "订单数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal PrPlannedQty { get; set; }

        /// <summary>
        /// 采购组
        /// </summary>
        [SugarColumn(ColumnName = "PrPurGroup", ColumnDescription = "采购组 ", Length = 4)]
        public string PrPurGroup { get; set; }

        /// <summary>
        /// 采购日期
        /// </summary>
        public DateTime? PrPurDate { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [SugarColumn(ColumnName = "PrPurUnit", ColumnDescription = "单位 ", Length = 3)]
        public string PrPurUnit { get; set; }

        /// <summary>
        /// 价格单位
        /// </summary>
        [SugarColumn(ColumnName = "PrUnitPrice", ColumnDescription = "价格单位 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal PrUnitPrice { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "PrPurCcy", ColumnDescription = "币种 ", Length = 3)]
        public string PrPurCcy { get; set; }

        /// <summary>
        /// 税别
        /// </summary>
        [SugarColumn(ColumnName = "PrPurTaxType", ColumnDescription = "税别 ", Length = 2)]
        public string PrPurTaxType { get; set; }

        /// <summary>
        /// 利润中心
        /// </summary>
        [SugarColumn(ColumnName = "PrPrctr", ColumnDescription = "利润中心 ", Length = 4)]
        public string PrPrctr { get; set; }

        /// <summary>
        /// PO残发行日期
        /// </summary>
        public DateTime? PrBalancedate { get; set; }
    }
}