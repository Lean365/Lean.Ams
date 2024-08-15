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
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long QmserSfId { get; set; }

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
    }
}