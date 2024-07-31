namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 检查日报slv
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:01:22
    /// </summary>
    public class PpInspPcbaSlvQueryDto : PagerInfo
    {
        public string Pdilot { get; set; }
        public string Pdipcbtype { get; set; }
        public string Pdivisualtype { get; set; }
        public string Pdivctype { get; set; }
        public DateTime? BeginPdisideadate { get; set; }
        public DateTime? EndPdisideadate { get; set; }
        public DateTime? BeginPdisidebdate { get; set; }
        public DateTime? EndPdisidebdate { get; set; }
        public string PdibadPosition { get; set; }
    }

    /// <summary>
    /// 检查日报slv
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:01:22
    /// </summary>
    public class PpInspPcbaSlvDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PdiSfId { get; set; }

        [Required(ErrorMessage = "PdiParentSfId不能为空")]
        [ExcelColumn(Name = "PdiParentSfId")]
        [ExcelColumnName("PdiParentSfId")]
        public long PdiParentSfId { get; set; }

        [ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string Pdilot { get; set; }

        [ExcelColumn(Name = "Lot数")]
        [ExcelColumnName("Lot数")]
        public int? Pdilotqty { get; set; }

        [ExcelColumn(Name = "板别")]
        [ExcelColumnName("板别")]
        public string Pdipcbtype { get; set; }

        [ExcelColumn(Name = "目视线别")]
        [ExcelColumnName("目视线别")]
        public string Pdivisualtype { get; set; }

        [ExcelColumn(Name = "AOI线别")]
        [ExcelColumnName("AOI线别")]
        public string Pdivctype { get; set; }

        [ExcelColumn(Name = "B面实装", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("B面实装")]
        public DateTime? Pdisideadate { get; set; }

        [ExcelColumn(Name = "T面实装", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("T面实装")]
        public DateTime? Pdisidebdate { get; set; }

        [ExcelColumn(Name = "生产班别")]
        [ExcelColumnName("生产班别")]
        public string Pdidshiftname { get; set; }

        [ExcelColumn(Name = "检查员")]
        [ExcelColumnName("检查员")]
        public string Pdicensor { get; set; }

        [Required(ErrorMessage = "当日完成数不能为空")]
        [ExcelColumn(Name = "当日完成数")]
        [ExcelColumnName("当日完成数")]
        public int Pdirealqty { get; set; }

        [Required(ErrorMessage = "累计完成数不能为空")]
        [ExcelColumn(Name = "累计完成数")]
        [ExcelColumnName("累计完成数")]
        public int Pdirealtotal { get; set; }

        [Required(ErrorMessage = "检查台数不能为空")]
        [ExcelColumn(Name = "检查台数")]
        [ExcelColumnName("检查台数")]
        public int Pdiispqty { get; set; }

        [ExcelColumn(Name = "检查状态")]
        [ExcelColumnName("检查状态")]
        public string Pdipcbchecktype { get; set; }

        [ExcelColumn(Name = "生产线别")]
        [ExcelColumnName("生产线别")]
        public string Pdilinename { get; set; }

        [Required(ErrorMessage = "检查工数不能为空")]
        [ExcelColumn(Name = "检查工数")]
        [ExcelColumnName("检查工数")]
        public int Pdiinsqtime { get; set; }

        [Required(ErrorMessage = "AOI工数不能为空")]
        [ExcelColumn(Name = "AOI工数")]
        [ExcelColumnName("AOI工数")]
        public int Pdiaoitime { get; set; }

        [Required(ErrorMessage = "不良数量不能为空")]
        [ExcelColumn(Name = "不良数量")]
        [ExcelColumnName("不良数量")]
        public int Pdibadqty { get; set; }

        [ExcelColumn(Name = "手贴部品")]
        [ExcelColumnName("手贴部品")]
        public string Pdihandle { get; set; }

        [ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string Pdibadserial { get; set; }

        [ExcelColumn(Name = "内容")]
        [ExcelColumnName("内容")]
        public string Pdibadcontent { get; set; }

        [ExcelColumn(Name = "个所区分")]
        [ExcelColumnName("个所区分")]
        public string PdibadPosition { get; set; }

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

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 检查日报slv
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:01:22
    /// </summary>
    public class PpInspPcbaSlvImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PdiSfId { get; set; }

        [Required(ErrorMessage = "PdiParentSfId不能为空")]
        [ExcelColumn(Name = "PdiParentSfId")]
        [ExcelColumnName("PdiParentSfId")]
        public long PdiParentSfId { get; set; }

        [ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string Pdilot { get; set; }

        [ExcelColumn(Name = "Lot数")]
        [ExcelColumnName("Lot数")]
        public int? Pdilotqty { get; set; }

        [ExcelColumn(Name = "板别")]
        [ExcelColumnName("板别")]
        public string Pdipcbtype { get; set; }

        [ExcelColumn(Name = "目视线别")]
        [ExcelColumnName("目视线别")]
        public string Pdivisualtype { get; set; }

        [ExcelColumn(Name = "AOI线别")]
        [ExcelColumnName("AOI线别")]
        public string Pdivctype { get; set; }

        [ExcelColumn(Name = "B面实装", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("B面实装")]
        public DateTime? Pdisideadate { get; set; }

        [ExcelColumn(Name = "T面实装", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("T面实装")]
        public DateTime? Pdisidebdate { get; set; }

        [ExcelColumn(Name = "生产班别")]
        [ExcelColumnName("生产班别")]
        public string Pdidshiftname { get; set; }

        [ExcelColumn(Name = "检查员")]
        [ExcelColumnName("检查员")]
        public string Pdicensor { get; set; }

        [Required(ErrorMessage = "当日完成数不能为空")]
        [ExcelColumn(Name = "当日完成数")]
        [ExcelColumnName("当日完成数")]
        public int Pdirealqty { get; set; }

        [Required(ErrorMessage = "累计完成数不能为空")]
        [ExcelColumn(Name = "累计完成数")]
        [ExcelColumnName("累计完成数")]
        public int Pdirealtotal { get; set; }

        [Required(ErrorMessage = "检查台数不能为空")]
        [ExcelColumn(Name = "检查台数")]
        [ExcelColumnName("检查台数")]
        public int Pdiispqty { get; set; }

        [ExcelColumn(Name = "检查状态")]
        [ExcelColumnName("检查状态")]
        public string Pdipcbchecktype { get; set; }

        [ExcelColumn(Name = "生产线别")]
        [ExcelColumnName("生产线别")]
        public string Pdilinename { get; set; }

        [Required(ErrorMessage = "检查工数不能为空")]
        [ExcelColumn(Name = "检查工数")]
        [ExcelColumnName("检查工数")]
        public int Pdiinsqtime { get; set; }

        [Required(ErrorMessage = "AOI工数不能为空")]
        [ExcelColumn(Name = "AOI工数")]
        [ExcelColumnName("AOI工数")]
        public int Pdiaoitime { get; set; }

        [Required(ErrorMessage = "不良数量不能为空")]
        [ExcelColumn(Name = "不良数量")]
        [ExcelColumnName("不良数量")]
        public int Pdibadqty { get; set; }

        [ExcelColumn(Name = "手贴部品")]
        [ExcelColumnName("手贴部品")]
        public string Pdihandle { get; set; }

        [ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string Pdibadserial { get; set; }

        [ExcelColumn(Name = "内容")]
        [ExcelColumnName("内容")]
        public string Pdibadcontent { get; set; }

        [ExcelColumn(Name = "个所区分")]
        [ExcelColumnName("个所区分")]
        public string PdibadPosition { get; set; }

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

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}