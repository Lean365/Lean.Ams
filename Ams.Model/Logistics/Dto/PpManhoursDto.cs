
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 标准工时
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:04:58
    /// </summary>
    public class PpManhoursQueryDto : PagerInfo 
    {
        public DateTime? BeginMhEffDate { get; set; }
        public DateTime? EndMhEffDate { get; set; }
        public string MhPlant { get; set; }
        public string MhModelType { get; set; }
        public string MhRegionType { get; set; }
        public string MhItem { get; set; }
        public string MhWcName { get; set; }
    }

    /// <summary>
    /// 标准工时
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:04:58
    /// </summary>
    public class PpManhoursDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long MhSfId { get; set; }

        [ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日期")]
        public DateTime? MhEffDate { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string MhPlant { get; set; }

        [Required(ErrorMessage = "机种名不能为空")]
        [ExcelColumn(Name = "机种名")]
        [ExcelColumnName("机种名")]
        public string MhModelType { get; set; }

        [ExcelColumn(Name = "仕向别")]
        [ExcelColumnName("仕向别")]
        public string MhRegionType { get; set; }

        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string MhItem { get; set; }

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

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "工厂")]
        public string MhPlantLabel { get; set; }
        [ExcelColumn(Name = "工作中心")]
        public string MhWcNameLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 标准工时
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:04:58
    /// </summary>
    public class PpManhoursImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long MhSfId { get; set; }

        [ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日期")]
        public DateTime? MhEffDate { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string MhPlant { get; set; }

        [Required(ErrorMessage = "机种名不能为空")]
        [ExcelColumn(Name = "机种名")]
        [ExcelColumnName("机种名")]
        public string MhModelType { get; set; }

        [ExcelColumn(Name = "仕向别")]
        [ExcelColumnName("仕向别")]
        public string MhRegionType { get; set; }

        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string MhItem { get; set; }

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

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string MhPlantLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "工作中心")]
        public string MhWcNameLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}