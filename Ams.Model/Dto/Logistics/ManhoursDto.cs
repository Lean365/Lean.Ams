
namespace Ams.Model.Dto
{
    /// <summary>
    /// 标准工时
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 9:28:16)
    /// </summary>
    public class ManhoursQueryDto : PagerInfo 
    {
        public DateTime? BeginMhEffDate { get; set; }
        public DateTime? EndMhEffDate { get; set; }
        public string MhPlant { get; set; }
        public string MhItem { get; set; }
        public string MhWcName { get; set; }
    }

    /// <summary>
    /// 标准工时
    /// 输入输出对象
    /// </summary>
    public class ManhoursDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long MhSFID { get; set; }

        [ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日期")]
        public DateTime? MhEffDate { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string MhPlant { get; set; }

        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string MhItem { get; set; }

        [ExcelColumn(Name = "机种名")]
        [ExcelColumnName("机种名")]
        public string MhModelType { get; set; }

        [ExcelColumn(Name = "仕向别")]
        [ExcelColumnName("仕向别")]
        public string MhRegionType { get; set; }

        [ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]
        public string MhItemText { get; set; }

        [Required(ErrorMessage = "工作中心不能为空")]
        [ExcelColumn(Name = "工作中心")]
        [ExcelColumnName("工作中心")]
        public string MhWcName { get; set; }

        [ExcelColumn(Name = "工作中心文本")]
        [ExcelColumnName("工作中心文本")]
        public string MhWcText { get; set; }

        [Required(ErrorMessage = "标准点数不能为空")]
        [ExcelColumn(Name = "标准点数")]
        [ExcelColumnName("标准点数")]
        public decimal MhStdShort { get; set; }

        [ExcelColumn(Name = "Short单位")]
        [ExcelColumnName("Short单位")]
        public string MhShortUnit { get; set; }

        [Required(ErrorMessage = "点数换算汇率不能为空")]
        [ExcelColumn(Name = "点数换算汇率")]
        [ExcelColumnName("点数换算汇率")]
        public decimal MhToMinRate { get; set; }

        [Required(ErrorMessage = "标准工时不能为空")]
        [ExcelColumn(Name = "标准工时")]
        [ExcelColumnName("标准工时")]
        public decimal MhStdTime { get; set; }

        [ExcelColumn(Name = "工时单位")]
        [ExcelColumnName("工时单位")]
        public string MhTimeUnit { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelColumn(Name = "创建者")]
        [ExcelColumnName("创建者")]
        public string CreateBy { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("创建时间")]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string MhPlantLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "物料")]
        public string MhItemLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "工作中心")]
        public string MhWcNameLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "点数换算汇率")]
        public string MhToMinRateLabel { get; set; }
    }
}