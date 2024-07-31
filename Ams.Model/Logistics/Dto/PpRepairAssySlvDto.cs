namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 组立不良slv
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 11:58:58
    /// </summary>
    public class PpRepairAssySlvQueryDto : PagerInfo
    {
        public string PpdBadType { get; set; }
        public string PpdBadSymptom { get; set; }
        public string PpdBadPosition { get; set; }
        public string PpdBadReason { get; set; }
    }

    /// <summary>
    /// 组立不良slv
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 11:58:58
    /// </summary>
    public class PpRepairAssySlvDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PpdSfId { get; set; }

        [Required(ErrorMessage = "PpdParentSfId不能为空")]
        [ExcelColumn(Name = "PpdParentSfId")]
        [ExcelColumnName("PpdParentSfId")]
        public long PpdParentSfId { get; set; }

        [ExcelColumn(Name = "不良类别")]
        [ExcelColumnName("不良类别")]
        public string PpdBadType { get; set; }

        [Required(ErrorMessage = "不良数量不能为空")]
        [ExcelColumn(Name = "不良数量")]
        [ExcelColumnName("不良数量")]
        public int PpdBadQty { get; set; }

        [Required(ErrorMessage = "不良总数不能为空")]
        [ExcelColumn(Name = "不良总数")]
        [ExcelColumnName("不良总数")]
        public int PpdBadTotal { get; set; }

        [ExcelColumn(Name = "不良状况")]
        [ExcelColumnName("不良状况")]
        public string PpdBadSymptom { get; set; }

        [ExcelColumn(Name = "不良个所")]
        [ExcelColumnName("不良个所")]
        public string PpdBadPosition { get; set; }

        [ExcelColumn(Name = "不良原因")]
        [ExcelColumnName("不良原因")]
        public string PpdBadReason { get; set; }

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

        [ExcelColumn(Name = "不良类别")]
        public string PpdBadTypeLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 组立不良slv
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 11:58:58
    /// </summary>
    public class PpRepairAssySlvImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PpdSfId { get; set; }

        [Required(ErrorMessage = "PpdParentSfId不能为空")]
        [ExcelColumn(Name = "PpdParentSfId")]
        [ExcelColumnName("PpdParentSfId")]
        public long PpdParentSfId { get; set; }

        [ExcelColumn(Name = "不良类别")]
        [ExcelColumnName("不良类别")]
        public string PpdBadType { get; set; }

        [Required(ErrorMessage = "不良数量不能为空")]
        [ExcelColumn(Name = "不良数量")]
        [ExcelColumnName("不良数量")]
        public int PpdBadQty { get; set; }

        [Required(ErrorMessage = "不良总数不能为空")]
        [ExcelColumn(Name = "不良总数")]
        [ExcelColumnName("不良总数")]
        public int PpdBadTotal { get; set; }

        [ExcelColumn(Name = "不良状况")]
        [ExcelColumnName("不良状况")]
        public string PpdBadSymptom { get; set; }

        [ExcelColumn(Name = "不良个所")]
        [ExcelColumnName("不良个所")]
        public string PpdBadPosition { get; set; }

        [ExcelColumn(Name = "不良原因")]
        [ExcelColumnName("不良原因")]
        public string PpdBadReason { get; set; }

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
        [ExcelColumn(Name = "不良类别")]
        public string PpdBadTypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}