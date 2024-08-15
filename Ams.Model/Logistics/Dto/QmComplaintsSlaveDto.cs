namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 从客诉管理
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:39:58
    /// </summary>
    public class QmComplaintsSlaveQueryDto : PagerInfo
    {
        public string QmcsIssuesNo { get; set; }
        public string QmcsLine { get; set; }
        public DateTime? BeginQmcsProcessingDate { get; set; }
        public DateTime? EndQmcsProcessingDate { get; set; }
        public string QmcsOperator { get; set; }
    }

    /// <summary>
    /// 从客诉管理
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:39:58
    /// </summary>
    public class QmComplaintsSlaveDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QmcsSfId { get; set; }

        [Required(ErrorMessage = "外部客诉No.不能为空")]
        [ExcelColumn(Name = "外部客诉No.")]
        [ExcelColumnName("外部客诉No.")]
        public string QmcsIssuesNo { get; set; }

        [ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string QmcsLine { get; set; }

        [ExcelColumn(Name = "处理日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("处理日期")]
        public DateTime? QmcsProcessingDate { get; set; }

        [ExcelColumn(Name = "问题描述")]
        [ExcelColumnName("问题描述")]
        public string QmcsDescription { get; set; }

        [ExcelColumn(Name = "原因分析")]
        [ExcelColumnName("原因分析")]
        public string QmcsCauseAnalysis { get; set; }

        [ExcelColumn(Name = "作业员")]
        [ExcelColumnName("作业员")]
        public string QmcsOperator { get; set; }

        [ExcelColumn(Name = "工位")]
        [ExcelColumnName("工位")]
        public string QmcsStation { get; set; }

        [ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string QmcsLot { get; set; }

        [ExcelColumn(Name = "改善对策")]
        [ExcelColumnName("改善对策")]
        public string QmcsMeasures { get; set; }

        [ExcelColumn(Name = "改善文件")]
        [ExcelColumnName("改善文件")]
        public string QmcsReformDocs { get; set; }

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

        [ExcelColumn(Name = "班组")]
        public string QmcsLineLabel { get; set; }

        [ExcelColumn(Name = "作业员")]
        public string QmcsOperatorLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 从客诉管理
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 8:39:58
    /// </summary>
    public class QmComplaintsSlaveImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QmcsSfId { get; set; }

        [Required(ErrorMessage = "外部客诉No.不能为空")]
        [ExcelColumn(Name = "外部客诉No.")]
        [ExcelColumnName("外部客诉No.")]
        public string QmcsIssuesNo { get; set; }

        [ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string QmcsLine { get; set; }

        [ExcelColumn(Name = "处理日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("处理日期")]
        public DateTime? QmcsProcessingDate { get; set; }

        [ExcelColumn(Name = "问题描述")]
        [ExcelColumnName("问题描述")]
        public string QmcsDescription { get; set; }

        [ExcelColumn(Name = "原因分析")]
        [ExcelColumnName("原因分析")]
        public string QmcsCauseAnalysis { get; set; }

        [ExcelColumn(Name = "作业员")]
        [ExcelColumnName("作业员")]
        public string QmcsOperator { get; set; }

        [ExcelColumn(Name = "工位")]
        [ExcelColumnName("工位")]
        public string QmcsStation { get; set; }

        [ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string QmcsLot { get; set; }

        [ExcelColumn(Name = "改善对策")]
        [ExcelColumnName("改善对策")]
        public string QmcsMeasures { get; set; }

        [ExcelColumn(Name = "改善文件")]
        [ExcelColumnName("改善文件")]
        public string QmcsReformDocs { get; set; }

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
        [ExcelColumn(Name = "班组")]
        public string QmcsLineLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "作业员")]
        public string QmcsOperatorLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}