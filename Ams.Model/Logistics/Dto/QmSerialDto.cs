namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 序列号扫描
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:55:51
    /// </summary>
    public class QmSerialQueryDto : PagerInfo
    {
        public string QminScan { get; set; }
        public DateTime? BeginQminDate { get; set; }
        public DateTime? EndQminDate { get; set; }
        public DateTime? BeginQminTime { get; set; }
        public DateTime? EndQminTime { get; set; }
        public string QmoutBill { get; set; }
        public string QmoutTransport { get; set; }
        public DateTime? BeginQmoutDate { get; set; }
        public DateTime? EndQmoutDate { get; set; }
    }

    /// <summary>
    /// 序列号扫描
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:55:51
    /// </summary>
    public class QmSerialDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QmserSfId { get; set; }

        [Required(ErrorMessage = "入库序列号不能为空")]
        [ExcelColumn(Name = "入库序列号")]
        [ExcelColumnName("入库序列号")]
        public string QminScan { get; set; }

        [ExcelColumn(Name = "入库日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入库日期")]
        public DateTime? QminDate { get; set; }

        [ExcelColumn(Name = "入库数量")]
        [ExcelColumnName("入库数量")]
        public int? QminQty { get; set; }

        [ExcelColumn(Name = "PCHostName")]
        [ExcelColumnName("PCHostName")]
        public string QminHostname { get; set; }

        [ExcelColumn(Name = "PCHostIp")]
        [ExcelColumnName("PCHostIp")]
        public string QminHostip { get; set; }

        [ExcelColumn(Name = "PCHostMac")]
        [ExcelColumnName("PCHostMac")]
        public string QminHostmac { get; set; }

        [ExcelColumn(Name = "入库扫描")]
        [ExcelColumnName("入库扫描")]
        public string QminUser { get; set; }

        [ExcelColumn(Name = "入库日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入库日期")]
        public DateTime? QminTime { get; set; }

        [ExcelColumn(Name = "出货发票")]
        [ExcelColumnName("出货发票")]
        public string QmoutBill { get; set; }

        [ExcelColumn(Name = "运输方式")]
        [ExcelColumnName("运输方式")]
        public string QmoutTransport { get; set; }

        [ExcelColumn(Name = "出库序列号")]
        [ExcelColumnName("出库序列号")]
        public string QmoutScan { get; set; }

        [ExcelColumn(Name = "出库日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("出库日期")]
        public DateTime? QmoutDate { get; set; }

        [ExcelColumn(Name = "出库数量")]
        [ExcelColumnName("出库数量")]
        public int? QmoutQty { get; set; }

        [ExcelColumn(Name = "区域仕向")]
        [ExcelColumnName("区域仕向")]
        public string QmoutRegion { get; set; }

        [ExcelColumn(Name = "PCHostName")]
        [ExcelColumnName("PCHostName")]
        public string QmoutHostname { get; set; }

        [ExcelColumn(Name = "PCHostIp")]
        [ExcelColumnName("PCHostIp")]
        public string QmoutHostip { get; set; }

        [ExcelColumn(Name = "PCHostMac")]
        [ExcelColumnName("PCHostMac")]
        public string QmoutHostmac { get; set; }

        [ExcelColumn(Name = "出库扫描")]
        [ExcelColumnName("出库扫描")]
        public string QmoutUser { get; set; }

        [ExcelColumn(Name = "出库日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("出库日期")]
        public DateTime? QmoutTime { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "运输方式")]
        public string QmoutTransportLabel { get; set; }

        [ExcelColumn(Name = "区域仕向")]
        public string QmoutRegionLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 序列号扫描
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:55:51
    /// </summary>
    public class QmSerialImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QmserSfId { get; set; }

        [Required(ErrorMessage = "入库序列号不能为空")]
        [ExcelColumn(Name = "入库序列号")]
        [ExcelColumnName("入库序列号")]
        public string QminScan { get; set; }

        [ExcelColumn(Name = "入库日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入库日期")]
        public DateTime? QminDate { get; set; }

        [ExcelColumn(Name = "入库数量")]
        [ExcelColumnName("入库数量")]
        public int? QminQty { get; set; }

        [ExcelColumn(Name = "PCHostName")]
        [ExcelColumnName("PCHostName")]
        public string QminHostname { get; set; }

        [ExcelColumn(Name = "PCHostIp")]
        [ExcelColumnName("PCHostIp")]
        public string QminHostip { get; set; }

        [ExcelColumn(Name = "PCHostMac")]
        [ExcelColumnName("PCHostMac")]
        public string QminHostmac { get; set; }

        [ExcelColumn(Name = "入库扫描")]
        [ExcelColumnName("入库扫描")]
        public string QminUser { get; set; }

        [ExcelColumn(Name = "入库日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入库日期")]
        public DateTime? QminTime { get; set; }

        [ExcelColumn(Name = "出货发票")]
        [ExcelColumnName("出货发票")]
        public string QmoutBill { get; set; }

        [ExcelColumn(Name = "运输方式")]
        [ExcelColumnName("运输方式")]
        public string QmoutTransport { get; set; }

        [ExcelColumn(Name = "出库序列号")]
        [ExcelColumnName("出库序列号")]
        public string QmoutScan { get; set; }

        [ExcelColumn(Name = "出库日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("出库日期")]
        public DateTime? QmoutDate { get; set; }

        [ExcelColumn(Name = "出库数量")]
        [ExcelColumnName("出库数量")]
        public int? QmoutQty { get; set; }

        [ExcelColumn(Name = "区域仕向")]
        [ExcelColumnName("区域仕向")]
        public string QmoutRegion { get; set; }

        [ExcelColumn(Name = "PCHostName")]
        [ExcelColumnName("PCHostName")]
        public string QmoutHostname { get; set; }

        [ExcelColumn(Name = "PCHostIp")]
        [ExcelColumnName("PCHostIp")]
        public string QmoutHostip { get; set; }

        [ExcelColumn(Name = "PCHostMac")]
        [ExcelColumnName("PCHostMac")]
        public string QmoutHostmac { get; set; }

        [ExcelColumn(Name = "出库扫描")]
        [ExcelColumnName("出库扫描")]
        public string QmoutUser { get; set; }

        [ExcelColumn(Name = "出库日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("出库日期")]
        public DateTime? QmoutTime { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "运输方式")]
        public string QmoutTransportLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "区域仕向")]
        public string QmoutRegionLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}