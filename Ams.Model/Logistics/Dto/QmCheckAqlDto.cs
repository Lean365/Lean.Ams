namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 抽样标准
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:39:24
    /// </summary>
    public class QmCheckAqlQueryDto : PagerInfo
    {
        public string QcaLevel { get; set; }
    }

    /// <summary>
    /// 抽样标准
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:39:24
    /// </summary>
    public class QmCheckAqlDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QcaSfId { get; set; }

        [Required(ErrorMessage = "查检水平不能为空")]
        [ExcelColumn(Name = "查检水平")]
        [ExcelColumnName("查检水平")]
        public string QcaLevel { get; set; }

        [Required(ErrorMessage = "批量范围不能为空")]
        [ExcelColumn(Name = "批量范围")]
        [ExcelColumnName("批量范围")]
        public string QcaRange { get; set; }

        [Required(ErrorMessage = "最小值不能为空")]
        [ExcelColumn(Name = "最小值")]
        [ExcelColumnName("最小值")]
        public int QcaRangeMinmum { get; set; }

        [Required(ErrorMessage = "最大值不能为空")]
        [ExcelColumn(Name = "最大值")]
        [ExcelColumnName("最大值")]
        public int QcaRangeMaximum { get; set; }

        [Required(ErrorMessage = "样本码不能为空")]
        [ExcelColumn(Name = "样本码")]
        [ExcelColumnName("样本码")]
        public string QcaSamplesCode { get; set; }

        [Required(ErrorMessage = "抽样数不能为空")]
        [ExcelColumn(Name = "抽样数")]
        [ExcelColumnName("抽样数")]
        public int QcaSamplesQty { get; set; }

        [Required(ErrorMessage = "合格项不能为空")]
        [ExcelColumn(Name = "合格项")]
        [ExcelColumnName("合格项")]
        public int QcaAcQty { get; set; }

        [Required(ErrorMessage = "不合格项不能为空")]
        [ExcelColumn(Name = "不合格项")]
        [ExcelColumnName("不合格项")]
        public int QcaReQty { get; set; }

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

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 抽样标准
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:39:24
    /// </summary>
    public class QmCheckAqlImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QcaSfId { get; set; }

        [Required(ErrorMessage = "查检水平不能为空")]
        [ExcelColumn(Name = "查检水平")]
        [ExcelColumnName("查检水平")]
        public string QcaLevel { get; set; }

        [Required(ErrorMessage = "批量范围不能为空")]
        [ExcelColumn(Name = "批量范围")]
        [ExcelColumnName("批量范围")]
        public string QcaRange { get; set; }

        [Required(ErrorMessage = "最小值不能为空")]
        [ExcelColumn(Name = "最小值")]
        [ExcelColumnName("最小值")]
        public int QcaRangeMinmum { get; set; }

        [Required(ErrorMessage = "最大值不能为空")]
        [ExcelColumn(Name = "最大值")]
        [ExcelColumnName("最大值")]
        public int QcaRangeMaximum { get; set; }

        [Required(ErrorMessage = "样本码不能为空")]
        [ExcelColumn(Name = "样本码")]
        [ExcelColumnName("样本码")]
        public string QcaSamplesCode { get; set; }

        [Required(ErrorMessage = "抽样数不能为空")]
        [ExcelColumn(Name = "抽样数")]
        [ExcelColumnName("抽样数")]
        public int QcaSamplesQty { get; set; }

        [Required(ErrorMessage = "合格项不能为空")]
        [ExcelColumn(Name = "合格项")]
        [ExcelColumnName("合格项")]
        public int QcaAcQty { get; set; }

        [Required(ErrorMessage = "不合格项不能为空")]
        [ExcelColumn(Name = "不合格项")]
        [ExcelColumnName("不合格项")]
        public int QcaReQty { get; set; }

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
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}