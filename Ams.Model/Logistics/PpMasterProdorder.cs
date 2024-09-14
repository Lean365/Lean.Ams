namespace Ams.Model.Logistics
{
    /// <summary>
    /// 生产工单
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 12:05:47
    /// </summary>
    [SugarTable("pp_master_prodorder", "生产工单")]
    public class PpMasterProdorder : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 生产工厂
        /// </summary>
        [SugarColumn(ColumnName = "Mc002", ColumnDescription = "生产工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc002 { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        [SugarColumn(ColumnName = "Mc003", ColumnDescription = "订单类型", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc003 { get; set; }

        /// <summary>
        /// 订单号码
        /// </summary>
        [SugarColumn(ColumnName = "Mc004", ColumnDescription = "订单号码", Length = 7)]
        public string Mc004 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Mc005", ColumnDescription = "物料", Length = 20)]
        public string Mc005 { get; set; }

        /// <summary>
        /// 生产批次
        /// </summary>
        [SugarColumn(ColumnName = "Mc006", ColumnDescription = "生产批次", Length = 20)]
        public string Mc006 { get; set; }

        /// <summary>
        /// 工单数量
        /// </summary>
        [SugarColumn(ColumnName = "Mc007", ColumnDescription = "工单数量", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc007 { get; set; }

        /// <summary>
        /// 生产数量
        /// </summary>
        [SugarColumn(ColumnName = "Mc008", ColumnDescription = "生产数量", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc008 { get; set; }

        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime? Mc009 { get; set; }

        /// <summary>
        /// 工艺路线
        /// </summary>
        [SugarColumn(ColumnName = "Mc010", ColumnDescription = "工艺路线", Length = 8)]
        public string Mc010 { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [SugarColumn(ColumnName = "Mc011", ColumnDescription = "序列号", Length = 50)]
        public string Mc011 { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnName = "Mc012", ColumnDescription = "状态", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc012 { get; set; }
    }
}