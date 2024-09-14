namespace Ams.Model.Logistics
{
    /// <summary>
    /// PO残清单
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:51
    /// </summary>
    [SugarTable("mm_po_residue", "PO残清单")]
    public class MmPoResidue : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Me002", ColumnDescription = "工厂", Length = 4)]
        public string Me002 { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        [SugarColumn(ColumnName = "Me003", ColumnDescription = "供应商ID", Length = 10)]
        public string Me003 { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [SugarColumn(ColumnName = "Me004", ColumnDescription = "供应商名称", Length = 40)]
        public string Me004 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Me005", ColumnDescription = "物料", Length = 20)]
        public string Me005 { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        [SugarColumn(ColumnName = "Me006", ColumnDescription = "仓库", Length = 4)]
        public string Me006 { get; set; }

        /// <summary>
        /// 交货日期
        /// </summary>
        public DateTime? Me007 { get; set; }

        /// <summary>
        /// 未交
        /// </summary>
        [SugarColumn(ColumnName = "Me008", ColumnDescription = "未交", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me008 { get; set; }

        /// <summary>
        /// 已交
        /// </summary>
        [SugarColumn(ColumnName = "Me009", ColumnDescription = "已交", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me009 { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [SugarColumn(ColumnName = "Me010", ColumnDescription = "订单号", Length = 10)]
        public string Me010 { get; set; }

        /// <summary>
        /// 订单明细
        /// </summary>
        [SugarColumn(ColumnName = "Me011", ColumnDescription = "订单明细", Length = 5)]
        public string Me011 { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        [SugarColumn(ColumnName = "Me012", ColumnDescription = "订单数量", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me012 { get; set; }

        /// <summary>
        /// 采购组
        /// </summary>
        [SugarColumn(ColumnName = "Me013", ColumnDescription = "采购组", Length = 4)]
        public string Me013 { get; set; }

        /// <summary>
        /// 采购日期
        /// </summary>
        public DateTime? Me014 { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [SugarColumn(ColumnName = "Me015", ColumnDescription = "单位", Length = 3)]
        public string Me015 { get; set; }

        /// <summary>
        /// 价格单位
        /// </summary>
        [SugarColumn(ColumnName = "Me016", ColumnDescription = "价格单位", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me016 { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "Me017", ColumnDescription = "币种", Length = 3)]
        public string Me017 { get; set; }

        /// <summary>
        /// 税别
        /// </summary>
        [SugarColumn(ColumnName = "Me018", ColumnDescription = "税别", Length = 2)]
        public string Me018 { get; set; }

        /// <summary>
        /// 利润中心
        /// </summary>
        [SugarColumn(ColumnName = "Me019", ColumnDescription = "利润中心", Length = 4)]
        public string Me019 { get; set; }

        /// <summary>
        /// PO残发行日期
        /// </summary>
        public DateTime? Me020 { get; set; }
    }
}