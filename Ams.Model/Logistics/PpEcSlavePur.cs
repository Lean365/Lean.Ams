namespace Ams.Model.Logistics
{
    /// <summary>
    /// Pur设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 14:43:11
    /// </summary>
    [SugarTable("pp_ec_slave_pur", "Pur设变")]
    public class PpEcSlavePur : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>

        [SugarColumn(IsPrimaryKey = false, IsIdentity = false)]
        public long PurSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PurParentSfId { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        [SugarColumn(ColumnName = "PurEcNo", ColumnDescription = "设变No. ", Length = 20)]
        public string PurEcNo { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "PurModel", ColumnDescription = "机种 ", Length = 200)]
        public string PurModel { get; set; }

        /// <summary>
        /// 新物料
        /// </summary>
        [SugarColumn(ColumnName = "PurNewItem", ColumnDescription = "新物料 ", Length = 20)]
        public string PurNewItem { get; set; }

        /// <summary>
        /// 新文本
        /// </summary>
        [SugarColumn(ColumnName = "PurNewItemText", ColumnDescription = "新文本 ", Length = 40)]
        public string PurNewItemText { get; set; }

        /// <summary>
        /// 新品库存
        /// </summary>
        [SugarColumn(ColumnName = "PurNewCurrStock", ColumnDescription = "新品库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal PurNewCurrStock { get; set; }

        /// <summary>
        /// 采购类型
        /// </summary>
        [SugarColumn(ColumnName = "PurType", ColumnDescription = "采购类型 ", Length = 1)]
        public string PurType { get; set; }

        /// <summary>
        /// 采购组
        /// </summary>
        [SugarColumn(ColumnName = "PurGroup", ColumnDescription = "采购组 ", Length = 10)]
        public string PurGroup { get; set; }

        /// <summary>
        /// 检验到库存
        /// </summary>
        [SugarColumn(ColumnName = "PurInsmk", ColumnDescription = "检验到库存 ", Length = 1)]
        public string PurInsmk { get; set; }

        /// <summary>
        /// 实施标记
        /// </summary>
        [SugarColumn(ColumnName = "PurImplStated", ColumnDescription = "实施标记 ", DefaultValue = "0")]
        public int PurImplStated { get; set; }

        /// <summary>
        /// 采购登入日期
        /// </summary>
        public DateTime? PurEnteredDate { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        [SugarColumn(ColumnName = "PurSupplier", ColumnDescription = "供应商 ", Length = 20)]
        public string PurSupplier { get; set; }

        /// <summary>
        /// 采购PO
        /// </summary>
        [SugarColumn(ColumnName = "PurPreOrder", ColumnDescription = "采购PO ", Length = 20)]
        public string PurPreOrder { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "PurNote", ColumnDescription = "说明 ", Length = 255)]
        public string PurNote { get; set; }
    }
}