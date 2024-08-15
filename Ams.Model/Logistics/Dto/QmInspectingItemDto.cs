namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 检测项目
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:07:59
    /// </summary>
    public class QmInspectingItemQueryDto : PagerInfo
    {
        public string QminsItemCode { get; set; }
        public string QminsItemName { get; set; }
        public string QminsItemType { get; set; }
        public string QminsItemQcTool { get; set; }
    }

    /// <summary>
    /// 检测项目
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:07:59
    /// </summary>
    public class QmInspectingItemDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QminsItemSfId { get; set; }

        [Required(ErrorMessage = "项目代码不能为空")]
        [ExcelColumn(Name = "项目代码")]
        [ExcelColumnName("项目代码")]
        public string QminsItemCode { get; set; }

        [Required(ErrorMessage = "项目名称不能为空")]
        [ExcelColumn(Name = "项目名称")]
        [ExcelColumnName("项目名称")]
        public string QminsItemName { get; set; }

        [Required(ErrorMessage = "项目类别不能为空")]
        [ExcelColumn(Name = "项目类别")]
        [ExcelColumnName("项目类别")]
        public string QminsItemType { get; set; }

        [ExcelColumn(Name = "检查工具")]
        [ExcelColumnName("检查工具")]
        public string QminsItemQcTool { get; set; }

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

        [ExcelColumn(Name = "项目类别")]
        public string QminsItemTypeLabel { get; set; }

        [ExcelColumn(Name = "检查工具")]
        public string QminsItemQcToolLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 检测项目
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:07:59
    /// </summary>
    public class QmInspectingItemImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QminsItemSfId { get; set; }

        [Required(ErrorMessage = "项目代码不能为空")]
        [ExcelColumn(Name = "项目代码")]
        [ExcelColumnName("项目代码")]
        public string QminsItemCode { get; set; }

        [Required(ErrorMessage = "项目名称不能为空")]
        [ExcelColumn(Name = "项目名称")]
        [ExcelColumnName("项目名称")]
        public string QminsItemName { get; set; }

        [Required(ErrorMessage = "项目类别不能为空")]
        [ExcelColumn(Name = "项目类别")]
        [ExcelColumnName("项目类别")]
        public string QminsItemType { get; set; }

        [ExcelColumn(Name = "检查工具")]
        [ExcelColumnName("检查工具")]
        public string QminsItemQcTool { get; set; }

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
        [ExcelColumn(Name = "项目类别")]
        public string QminsItemTypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "检查工具")]
        public string QminsItemQcToolLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}