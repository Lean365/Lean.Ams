namespace Ams.Model.Accounting
{
    /// <summary>
    /// 月度存货
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:46:48
    /// </summary>
    [SugarTable("fico_monthly_inventory", "月度存货")]
    public class FicoMonthlyInventory : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long MiSfId { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "MiPlant", ColumnDescription = "工厂 ", Length = 4)]
        public string MiPlant { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "MiFy", ColumnDescription = "期间 ", Length = 6)]
        public string MiFy { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "MiYm", ColumnDescription = "年月 ", Length = 6)]
        public string MiYm { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "MiItem", ColumnDescription = "物料 ", Length = 20)]
        public string MiItem { get; set; }

        /// <summary>
        /// 评估类
        /// </summary>
        [SugarColumn(ColumnName = "MiValType", ColumnDescription = "评估类 ", Length = 4)]
        public string MiValType { get; set; }

        /// <summary>
        /// 价格控制
        /// </summary>
        [SugarColumn(ColumnName = "MiPriceControl", ColumnDescription = "价格控制 ", Length = 1)]
        public string MiPriceControl { get; set; }

        /// <summary>
        /// 移动平均价
        /// </summary>
        [SugarColumn(ColumnName = "MiMovingAverage", ColumnDescription = "移动平均价 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal MiMovingAverage { get; set; }

        /// <summary>
        /// Per单位
        /// </summary>
        [SugarColumn(ColumnName = "MiPerUnit", ColumnDescription = "Per单位 ", DefaultValue = "0")]
        public int MiPerUnit { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "MiLocalCcy", ColumnDescription = "币种 ", Length = 3)]
        public string MiLocalCcy { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        [SugarColumn(ColumnName = "MiInventoryQty", ColumnDescription = "库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal MiInventoryQty { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [SugarColumn(ColumnName = "MiInventoryAmount", ColumnDescription = "金额 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal MiInventoryAmount { get; set; }

        /// <summary>
        /// 登录日期
        /// </summary>
        public DateTime? MiBalancedate { get; set; }
    }
}