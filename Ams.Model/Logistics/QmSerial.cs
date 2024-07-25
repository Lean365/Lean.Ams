namespace Ams.Model.Logistics
{
    /// <summary>
    /// 序列号扫描
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:55:51
    /// </summary>
    [SugarTable("qm_serial", "序列号扫描")]
    public class QmSerial : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long QmserSFID { get; set; }

        /// <summary>
        /// 入库序列号
        /// </summary>
        [SugarColumn(ColumnName = "QminScan", ColumnDescription = "入库序列号 ", Length = 50)]
        public string QminScan { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime? QminDate { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        [SugarColumn(ColumnName = "QminQty", ColumnDescription = "入库数量 ", DefaultValue = "0")]
        public int? QminQty { get; set; }

        /// <summary>
        /// PCHostName
        /// </summary>
        [SugarColumn(ColumnName = "QminHostname", ColumnDescription = "PCHostName ", Length = 20)]
        public string QminHostname { get; set; }

        /// <summary>
        /// PCHostIp
        /// </summary>
        [SugarColumn(ColumnName = "QminHostip", ColumnDescription = "PCHostIp ", Length = 20)]
        public string QminHostip { get; set; }

        /// <summary>
        /// PCHostMac
        /// </summary>
        [SugarColumn(ColumnName = "QminHostmac", ColumnDescription = "PCHostMac ", Length = 20)]
        public string QminHostmac { get; set; }

        /// <summary>
        /// 入库扫描
        /// </summary>
        [SugarColumn(ColumnName = "QminUser", ColumnDescription = "入库扫描 ", Length = 20)]
        public string QminUser { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime? QminTime { get; set; }

        /// <summary>
        /// 出货发票
        /// </summary>
        [SugarColumn(ColumnName = "QmoutBill", ColumnDescription = "出货发票 ", Length = 50)]
        public string QmoutBill { get; set; }

        /// <summary>
        /// 运输方式
        /// </summary>
        [SugarColumn(ColumnName = "QmoutTransport", ColumnDescription = "运输方式 ", Length = 50)]
        public string QmoutTransport { get; set; }

        /// <summary>
        /// 出库序列号
        /// </summary>
        [SugarColumn(ColumnName = "QmoutScan", ColumnDescription = "出库序列号 ", Length = 50)]
        public string QmoutScan { get; set; }

        /// <summary>
        /// 出库日期
        /// </summary>
        public DateTime? QmoutDate { get; set; }

        /// <summary>
        /// 出库数量
        /// </summary>
        [SugarColumn(ColumnName = "QmoutQty", ColumnDescription = "出库数量 ", DefaultValue = "0")]
        public int? QmoutQty { get; set; }

        /// <summary>
        /// 区域仕向
        /// </summary>
        [SugarColumn(ColumnName = "QmoutRegion", ColumnDescription = "区域仕向 ", Length = 20)]
        public string QmoutRegion { get; set; }

        /// <summary>
        /// PCHostName
        /// </summary>
        [SugarColumn(ColumnName = "QmoutHostname", ColumnDescription = "PCHostName ", Length = 20)]
        public string QmoutHostname { get; set; }

        /// <summary>
        /// PCHostIp
        /// </summary>
        [SugarColumn(ColumnName = "QmoutHostip", ColumnDescription = "PCHostIp ", Length = 20)]
        public string QmoutHostip { get; set; }

        /// <summary>
        /// PCHostMac
        /// </summary>
        [SugarColumn(ColumnName = "QmoutHostmac", ColumnDescription = "PCHostMac ", Length = 20)]
        public string QmoutHostmac { get; set; }

        /// <summary>
        /// 出库扫描
        /// </summary>
        [SugarColumn(ColumnName = "QmoutUser", ColumnDescription = "出库扫描 ", Length = 20)]
        public string QmoutUser { get; set; }

        /// <summary>
        /// 出库日期
        /// </summary>
        public DateTime? QmoutTime { get; set; }

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