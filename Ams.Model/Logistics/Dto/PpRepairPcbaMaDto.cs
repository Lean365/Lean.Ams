namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 修理日报ma
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:04:48
    /// </summary>
    public class PpRepairPcbaMaQueryDto : PagerInfo
    {
        public DateTime? BeginPdrdate { get; set; }
        public DateTime? EndPdrdate { get; set; }
        public string Pdrmodel { get; set; }
        public string Pdrorder { get; set; }
        public string Pdrlot { get; set; }
    }

    /// <summary>
    /// 修理日报ma
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:04:48
    /// </summary>
    public class PpRepairPcbaMaDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PdrSfId { get; set; }

        [ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? Pdrdate { get; set; }

        [ExcelColumn(Name = "生产机种")]
        [ExcelColumnName("生产机种")]
        public string Pdrmodel { get; set; }

        [ExcelColumn(Name = "生产订单")]
        [ExcelColumnName("生产订单")]
        public string Pdrorder { get; set; }

        [ExcelColumn(Name = "生产LOT")]
        [ExcelColumnName("生产LOT")]
        public string Pdrlot { get; set; }

        [Required(ErrorMessage = "订单台数不能为空")]
        [ExcelColumn(Name = "订单台数")]
        [ExcelColumnName("订单台数")]
        public int Pdrorderqty { get; set; }

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
        public List<PpRepairPcbaSlvDto> PpRepairPcbaSlvNav { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }

        [ExcelColumn(Name = "板别")]
        public string PdrpcbtypeLabel { get; set; }

        [ExcelColumn(Name = "检出工程")]
        public string PdrpcbcheckoutLabel { get; set; }

        [ExcelColumn(Name = "责任归属")]
        public string PdrbadresponsibilityLabel { get; set; }

        [ExcelColumn(Name = "不良性质")]
        public string PdrbadpropLabel { get; set; }

        [ExcelColumn(Name = "修理")]
        public string PdrbadrepairmanLabel { get; set; }
    }

    /// <summary>
    /// 修理日报ma
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:04:48
    /// </summary>
    public class PpRepairPcbaMaImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PdrSfId { get; set; }

        [ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? Pdrdate { get; set; }

        [ExcelColumn(Name = "生产机种")]
        [ExcelColumnName("生产机种")]
        public string Pdrmodel { get; set; }

        [ExcelColumn(Name = "生产订单")]
        [ExcelColumnName("生产订单")]
        public string Pdrorder { get; set; }

        [ExcelColumn(Name = "生产LOT")]
        [ExcelColumnName("生产LOT")]
        public string Pdrlot { get; set; }

        [Required(ErrorMessage = "订单台数不能为空")]
        [ExcelColumn(Name = "订单台数")]
        [ExcelColumnName("订单台数")]
        public int Pdrorderqty { get; set; }

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
        public List<PpRepairPcbaSlvDto> PpRepairPcbaSlvNav { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "板别")]
        public string PdrpcbtypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "检出工程")]
        public string PdrpcbcheckoutLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "责任归属")]
        public string PdrbadresponsibilityLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "不良性质")]
        public string PdrbadpropLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "修理")]
        public string PdrbadrepairmanLabel { get; set; }
    }
}