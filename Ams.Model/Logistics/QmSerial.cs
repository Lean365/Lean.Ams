namespace Ams.Model.Logistics
{
    /// <summary>
    /// 序列号扫描
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:36:33
    /// </summary>
    [SugarTable("qm_serial", "序列号扫描")]
    public class QmSerial : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 入库序列号
        /// </summary>
        [SugarColumn(ColumnName = "Mk002", ColumnDescription = "入库序列号", Length = 50)]
        public string Mk002 { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime? Mk003 { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        [SugarColumn(ColumnName = "Mk004", ColumnDescription = "入库数量", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mk004 { get; set; }

        /// <summary>
        /// HinName
        /// </summary>
        [SugarColumn(ColumnName = "Mk005", ColumnDescription = "HinName", Length = 20)]
        public string Mk005 { get; set; }

        /// <summary>
        /// HinIp
        /// </summary>
        [SugarColumn(ColumnName = "Mk006", ColumnDescription = "HinIp", Length = 20)]
        public string Mk006 { get; set; }

        /// <summary>
        /// HinMac
        /// </summary>
        [SugarColumn(ColumnName = "Mk007", ColumnDescription = "HinMac", Length = 20)]
        public string Mk007 { get; set; }

        /// <summary>
        /// 入库扫描
        /// </summary>
        [SugarColumn(ColumnName = "Mk008", ColumnDescription = "入库扫描", Length = 20)]
        public string Mk008 { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime? Mk009 { get; set; }

        /// <summary>
        /// 出货发票
        /// </summary>
        [SugarColumn(ColumnName = "Mk010", ColumnDescription = "出货发票", Length = 50)]
        public string Mk010 { get; set; }

        /// <summary>
        /// 运输方式
        /// </summary>
        [SugarColumn(ColumnName = "Mk011", ColumnDescription = "运输方式", Length = 50)]
        public string Mk011 { get; set; }

        /// <summary>
        /// 出库序列号
        /// </summary>
        [SugarColumn(ColumnName = "Mk012", ColumnDescription = "出库序列号", Length = 50)]
        public string Mk012 { get; set; }

        /// <summary>
        /// 出库日期
        /// </summary>
        public DateTime? Mk013 { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        [SugarColumn(ColumnName = "Mk014", ColumnDescription = "出库数量", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mk014 { get; set; }

        /// <summary>
        /// 区域仕向
        /// </summary>
        [SugarColumn(ColumnName = "Mk015", ColumnDescription = "区域仕向", Length = 20)]
        public string Mk015 { get; set; }

        /// <summary>
        /// HouName
        /// </summary>
        [SugarColumn(ColumnName = "Mk016", ColumnDescription = "HouName", Length = 20)]
        public string Mk016 { get; set; }

        /// <summary>
        /// HouIp
        /// </summary>
        [SugarColumn(ColumnName = "Mk017", ColumnDescription = "HouIp", Length = 20)]
        public string Mk017 { get; set; }

        /// <summary>
        /// HouMac
        /// </summary>
        [SugarColumn(ColumnName = "Mk018", ColumnDescription = "HouMac", Length = 20)]
        public string Mk018 { get; set; }

        /// <summary>
        /// 出库扫描
        /// </summary>
        [SugarColumn(ColumnName = "Mk019", ColumnDescription = "出库扫描", Length = 20)]
        public string Mk019 { get; set; }

        /// <summary>
        /// 出库日期
        /// </summary>
        public DateTime? Mk020 { get; set; }
    }
}