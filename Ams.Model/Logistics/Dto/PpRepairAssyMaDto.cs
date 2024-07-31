namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 组立不良ma
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:00:50
    /// </summary>
    public class PpRepairAssyMaQueryDto : PagerInfo
    {
        public string PpdOrderNo { get; set; }
        public string PpdLot { get; set; }
        public string PpdModel { get; set; }
        public DateTime? BeginPpdDate { get; set; }
        public DateTime? EndPpdDate { get; set; }
        public string PpdLineName { get; set; }
    }

    /// <summary>
    /// 组立不良ma
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:00:50
    /// </summary>
    public class PpRepairAssyMaDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PpdSfId { get; set; }

        [ExcelColumn(Name = "生产订单")]
        [ExcelColumnName("生产订单")]
        public string PpdOrderNo { get; set; }

        [Required(ErrorMessage = "订单数量不能为空")]
        [ExcelColumn(Name = "订单数量")]
        [ExcelColumnName("订单数量")]
        public int PpdOrderQty { get; set; }

        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string PpdLot { get; set; }

        [ExcelColumn(Name = "生产机种")]
        [ExcelColumnName("生产机种")]
        public string PpdModel { get; set; }

        [ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? PpdDate { get; set; }

        [ExcelColumn(Name = "生产班组")]
        [ExcelColumnName("生产班组")]
        public string PpdLineName { get; set; }

        [Required(ErrorMessage = "生产实绩不能为空")]
        [ExcelColumn(Name = "生产实绩")]
        [ExcelColumnName("生产实绩")]
        public int PpdRealQty { get; set; }

        [Required(ErrorMessage = "无不良数不能为空")]
        [ExcelColumn(Name = "无不良数")]
        [ExcelColumnName("无不良数")]
        public int PpdNobadQty { get; set; }

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
        public List<PpRepairAssySlvDto> PpDefectAssyRepairSlvNav { get; set; }

        [ExcelColumn(Name = "生产班组")]
        public string PpdLineNameLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }

        [ExcelColumn(Name = "不良类别")]
        public string PpdBadTypeLabel { get; set; }
    }

    /// <summary>
    /// 组立不良ma
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:00:50
    /// </summary>
    public class PpRepairAssyMaImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PpdSfId { get; set; }

        [ExcelColumn(Name = "生产订单")]
        [ExcelColumnName("生产订单")]
        public string PpdOrderNo { get; set; }

        [Required(ErrorMessage = "订单数量不能为空")]
        [ExcelColumn(Name = "订单数量")]
        [ExcelColumnName("订单数量")]
        public int PpdOrderQty { get; set; }

        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string PpdLot { get; set; }

        [ExcelColumn(Name = "生产机种")]
        [ExcelColumnName("生产机种")]
        public string PpdModel { get; set; }

        [ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? PpdDate { get; set; }

        [ExcelColumn(Name = "生产班组")]
        [ExcelColumnName("生产班组")]
        public string PpdLineName { get; set; }

        [Required(ErrorMessage = "生产实绩不能为空")]
        [ExcelColumn(Name = "生产实绩")]
        [ExcelColumnName("生产实绩")]
        public int PpdRealQty { get; set; }

        [Required(ErrorMessage = "无不良数不能为空")]
        [ExcelColumn(Name = "无不良数")]
        [ExcelColumnName("无不良数")]
        public int PpdNobadQty { get; set; }

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
        public List<PpRepairAssySlvDto> PpDefectAssyRepairSlvNav { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "生产班组")]
        public string PpdLineNameLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "不良类别")]
        public string PpdBadTypeLabel { get; set; }
    }
}