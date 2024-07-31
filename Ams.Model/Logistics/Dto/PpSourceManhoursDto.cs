namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 源工时
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:11:09
    /// </summary>
    public class PpSourceManhoursQueryDto : PagerInfo
    {
        public string Zpbldz001 { get; set; }
        public string Zpbldz002 { get; set; }
        public string Zpbldz003 { get; set; }
    }

    /// <summary>
    /// 源工时
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:11:09
    /// </summary>
    public class PpSourceManhoursDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SfId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Zpbldz001 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Zpbldz002 { get; set; }

        [Required(ErrorMessage = "工作中心不能为空")]
        [ExcelColumn(Name = "工作中心")]
        [ExcelColumnName("工作中心")]
        public string Zpbldz003 { get; set; }

        [ExcelColumn(Name = "工作中心描述")]
        [ExcelColumnName("工作中心描述")]
        public string Zpbldz004 { get; set; }

        [Required(ErrorMessage = "标准值不能为空")]
        [ExcelColumn(Name = "标准值")]
        [ExcelColumnName("标准值")]
        public decimal Zpbldz005 { get; set; }

        [ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]
        public string Zpbldz006 { get; set; }

        [Required(ErrorMessage = "标准值不能为空")]
        [ExcelColumn(Name = "标准值")]
        [ExcelColumnName("标准值")]
        public decimal Zpbldz007 { get; set; }

        [ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]
        public string Zpbldz008 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "工厂")]
        public string Zpbldz001Label { get; set; }

        [ExcelColumn(Name = "工作中心")]
        public string Zpbldz003Label { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 源工时
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:11:09
    /// </summary>
    public class PpSourceManhoursImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SfId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Zpbldz001 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Zpbldz002 { get; set; }

        [Required(ErrorMessage = "工作中心不能为空")]
        [ExcelColumn(Name = "工作中心")]
        [ExcelColumnName("工作中心")]
        public string Zpbldz003 { get; set; }

        [ExcelColumn(Name = "工作中心描述")]
        [ExcelColumnName("工作中心描述")]
        public string Zpbldz004 { get; set; }

        [Required(ErrorMessage = "标准值不能为空")]
        [ExcelColumn(Name = "标准值")]
        [ExcelColumnName("标准值")]
        public decimal Zpbldz005 { get; set; }

        [ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]
        public string Zpbldz006 { get; set; }

        [Required(ErrorMessage = "标准值不能为空")]
        [ExcelColumn(Name = "标准值")]
        [ExcelColumnName("标准值")]
        public decimal Zpbldz007 { get; set; }

        [ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]
        public string Zpbldz008 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string Zpbldz001Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "工作中心")]
        public string Zpbldz003Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}