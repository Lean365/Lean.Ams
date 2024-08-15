namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 检查日报ma
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:01:30
    /// </summary>
    public class PpInspPcbaMaQueryDto : PagerInfo
    {
        public DateTime? BeginPdiinspdate { get; set; }
        public DateTime? EndPdiinspdate { get; set; }
        public string Pdimodel { get; set; }
        public string Pdiorder { get; set; }
        public string Pdilot { get; set; }
    }

    /// <summary>
    /// 检查日报ma
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:01:30
    /// </summary>
    public class PpInspPcbaMaDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PdiSfId { get; set; }

        [ExcelColumn(Name = "检查日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("检查日期")]
        public DateTime? Pdiinspdate { get; set; }

        [ExcelColumn(Name = "生产机种")]
        [ExcelColumnName("生产机种")]
        public string Pdimodel { get; set; }

        [ExcelColumn(Name = "生产工单")]
        [ExcelColumnName("生产工单")]
        public string Pdiorder { get; set; }

        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string Pdilot { get; set; }

        [Required(ErrorMessage = "工单台数不能为空")]
        [ExcelColumn(Name = "工单台数")]
        [ExcelColumnName("工单台数")]
        public int Pdiorderqty { get; set; }

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
        public List<PpInspPcbaSlvDto> PpInspPcbaSlvNav { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }

        [ExcelColumn(Name = "板别")]
        public string PdipcbtypeLabel { get; set; }

        [ExcelColumn(Name = "目视线别")]
        public string PdivisualtypeLabel { get; set; }

        [ExcelColumn(Name = "AOI线别")]
        public string PdivctypeLabel { get; set; }

        [ExcelColumn(Name = "生产班别")]
        public string PdidshiftnameLabel { get; set; }

        [ExcelColumn(Name = "检查状态")]
        public string PdipcbchecktypeLabel { get; set; }

        [ExcelColumn(Name = "生产线别")]
        public string PdilinenameLabel { get; set; }

        [ExcelColumn(Name = "个所区分")]
        public string PdibadPositionLabel { get; set; }
    }

    /// <summary>
    /// 检查日报ma
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:01:30
    /// </summary>
    public class PpInspPcbaMaImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PdiSfId { get; set; }

        [ExcelColumn(Name = "检查日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("检查日期")]
        public DateTime? Pdiinspdate { get; set; }

        [ExcelColumn(Name = "生产机种")]
        [ExcelColumnName("生产机种")]
        public string Pdimodel { get; set; }

        [ExcelColumn(Name = "生产工单")]
        [ExcelColumnName("生产工单")]
        public string Pdiorder { get; set; }

        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string Pdilot { get; set; }

        [Required(ErrorMessage = "工单台数不能为空")]
        [ExcelColumn(Name = "工单台数")]
        [ExcelColumnName("工单台数")]
        public int Pdiorderqty { get; set; }

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
        public List<PpInspPcbaSlvDto> PpInspPcbaSlvNav { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "板别")]
        public string PdipcbtypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "目视线别")]
        public string PdivisualtypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "AOI线别")]
        public string PdivctypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "生产班别")]
        public string PdidshiftnameLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "检查状态")]
        public string PdipcbchecktypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "生产线别")]
        public string PdilinenameLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "个所区分")]
        public string PdibadPositionLabel { get; set; }
    }
}