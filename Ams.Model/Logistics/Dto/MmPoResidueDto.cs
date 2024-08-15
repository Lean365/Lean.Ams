namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// PO残清单
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:59:13
    /// </summary>
    public class MmPoResidueQueryDto : PagerInfo
    {
        public string PrPlant { get; set; }
        public string PrSupplierCode { get; set; }
        public string PrSupplierName { get; set; }
        public string PrPurItem { get; set; }
        public string PrLocation { get; set; }
        public DateTime? BeginPrDelivDate { get; set; }
        public DateTime? EndPrDelivDate { get; set; }
        public string PrPurOrder { get; set; }
        public string PrPurGroup { get; set; }
        public DateTime? BeginPrPurDate { get; set; }
        public DateTime? EndPrPurDate { get; set; }
        public string PrPurCcy { get; set; }
        public string PrPurTaxType { get; set; }
        public string PrPrctr { get; set; }
        public DateTime? BeginPrBalancedate { get; set; }
        public DateTime? EndPrBalancedate { get; set; }
    }

    /// <summary>
    /// PO残清单
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:59:13
    /// </summary>
    public class MmPoResidueDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PrSfId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string PrPlant { get; set; }

        [Required(ErrorMessage = "供应商ID不能为空")]
        [ExcelColumn(Name = "供应商ID")]
        [ExcelColumnName("供应商ID")]
        public string PrSupplierCode { get; set; }

        [Required(ErrorMessage = "供应商名称不能为空")]
        [ExcelColumn(Name = "供应商名称")]
        [ExcelColumnName("供应商名称")]
        public string PrSupplierName { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string PrPurItem { get; set; }

        [Required(ErrorMessage = "物料文本不能为空")]
        [ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]
        public string PrPurItemText { get; set; }

        [Required(ErrorMessage = "仓库不能为空")]
        [ExcelColumn(Name = "仓库")]
        [ExcelColumnName("仓库")]
        public string PrLocation { get; set; }

        [Required(ErrorMessage = "交货日期不能为空")]
        [ExcelColumn(Name = "交货日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("交货日期")]
        public DateTime? PrDelivDate { get; set; }

        [Required(ErrorMessage = "未交不能为空")]
        [ExcelColumn(Name = "未交")]
        [ExcelColumnName("未交")]
        public decimal PrUnpaidQty { get; set; }

        [Required(ErrorMessage = "已交不能为空")]
        [ExcelColumn(Name = "已交")]
        [ExcelColumnName("已交")]
        public decimal PrAlreadyQty { get; set; }

        [Required(ErrorMessage = "订单号不能为空")]
        [ExcelColumn(Name = "订单号")]
        [ExcelColumnName("订单号")]
        public string PrPurOrder { get; set; }

        [Required(ErrorMessage = "订单明细不能为空")]
        [ExcelColumn(Name = "订单明细")]
        [ExcelColumnName("订单明细")]
        public string PrPurOrderDetails { get; set; }

        [Required(ErrorMessage = "订单数量不能为空")]
        [ExcelColumn(Name = "订单数量")]
        [ExcelColumnName("订单数量")]
        public decimal PrPlannedQty { get; set; }

        [Required(ErrorMessage = "采购组不能为空")]
        [ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string PrPurGroup { get; set; }

        [Required(ErrorMessage = "采购日期不能为空")]
        [ExcelColumn(Name = "采购日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("采购日期")]
        public DateTime? PrPurDate { get; set; }

        [Required(ErrorMessage = "单位不能为空")]
        [ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]
        public string PrPurUnit { get; set; }

        [Required(ErrorMessage = "价格单位不能为空")]
        [ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]
        public decimal PrUnitPrice { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string PrPurCcy { get; set; }

        [Required(ErrorMessage = "税别不能为空")]
        [ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]
        public string PrPurTaxType { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        [ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string PrPrctr { get; set; }

        [Required(ErrorMessage = "PO残发行日期不能为空")]
        [ExcelColumn(Name = "PO残发行日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("PO残发行日期")]
        public DateTime? PrBalancedate { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "工厂")]
        public string PrPlantLabel { get; set; }

        [ExcelColumn(Name = "供应商ID")]
        public string PrSupplierCodeLabel { get; set; }

        [ExcelColumn(Name = "仓库")]
        public string PrLocationLabel { get; set; }

        [ExcelColumn(Name = "采购组")]
        public string PrPurGroupLabel { get; set; }

        [ExcelColumn(Name = "单位")]
        public string PrPurUnitLabel { get; set; }

        [ExcelColumn(Name = "币种")]
        public string PrPurCcyLabel { get; set; }

        [ExcelColumn(Name = "税别")]
        public string PrPurTaxTypeLabel { get; set; }

        [ExcelColumn(Name = "利润中心")]
        public string PrPrctrLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// PO残清单
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:59:13
    /// </summary>
    public class MmPoResidueImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PrSfId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string PrPlant { get; set; }

        [Required(ErrorMessage = "供应商ID不能为空")]
        [ExcelColumn(Name = "供应商ID")]
        [ExcelColumnName("供应商ID")]
        public string PrSupplierCode { get; set; }

        [Required(ErrorMessage = "供应商名称不能为空")]
        [ExcelColumn(Name = "供应商名称")]
        [ExcelColumnName("供应商名称")]
        public string PrSupplierName { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string PrPurItem { get; set; }

        [Required(ErrorMessage = "物料文本不能为空")]
        [ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]
        public string PrPurItemText { get; set; }

        [Required(ErrorMessage = "仓库不能为空")]
        [ExcelColumn(Name = "仓库")]
        [ExcelColumnName("仓库")]
        public string PrLocation { get; set; }

        [Required(ErrorMessage = "交货日期不能为空")]
        [ExcelColumn(Name = "交货日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("交货日期")]
        public DateTime? PrDelivDate { get; set; }

        [Required(ErrorMessage = "未交不能为空")]
        [ExcelColumn(Name = "未交")]
        [ExcelColumnName("未交")]
        public decimal PrUnpaidQty { get; set; }

        [Required(ErrorMessage = "已交不能为空")]
        [ExcelColumn(Name = "已交")]
        [ExcelColumnName("已交")]
        public decimal PrAlreadyQty { get; set; }

        [Required(ErrorMessage = "订单号不能为空")]
        [ExcelColumn(Name = "订单号")]
        [ExcelColumnName("订单号")]
        public string PrPurOrder { get; set; }

        [Required(ErrorMessage = "订单明细不能为空")]
        [ExcelColumn(Name = "订单明细")]
        [ExcelColumnName("订单明细")]
        public string PrPurOrderDetails { get; set; }

        [Required(ErrorMessage = "订单数量不能为空")]
        [ExcelColumn(Name = "订单数量")]
        [ExcelColumnName("订单数量")]
        public decimal PrPlannedQty { get; set; }

        [Required(ErrorMessage = "采购组不能为空")]
        [ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string PrPurGroup { get; set; }

        [Required(ErrorMessage = "采购日期不能为空")]
        [ExcelColumn(Name = "采购日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("采购日期")]
        public DateTime? PrPurDate { get; set; }

        [Required(ErrorMessage = "单位不能为空")]
        [ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]
        public string PrPurUnit { get; set; }

        [Required(ErrorMessage = "价格单位不能为空")]
        [ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]
        public decimal PrUnitPrice { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string PrPurCcy { get; set; }

        [Required(ErrorMessage = "税别不能为空")]
        [ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]
        public string PrPurTaxType { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        [ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string PrPrctr { get; set; }

        [Required(ErrorMessage = "PO残发行日期不能为空")]
        [ExcelColumn(Name = "PO残发行日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("PO残发行日期")]
        public DateTime? PrBalancedate { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string PrPlantLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "供应商ID")]
        public string PrSupplierCodeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "仓库")]
        public string PrLocationLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "采购组")]
        public string PrPurGroupLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "单位")]
        public string PrPurUnitLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string PrPurCcyLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "税别")]
        public string PrPurTaxTypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "利润中心")]
        public string PrPrctrLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}