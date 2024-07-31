namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 废弃部品
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:57
    /// </summary>
    public class QmCostWasteQueryDto : PagerInfo
    {
        public DateTime? BeginQcwd001 { get; set; }
        public DateTime? EndQcwd001 { get; set; }
        public string Qcwd002 { get; set; }
        public string Qcwd004 { get; set; }
        public string Qcwd016 { get; set; }
        public string Qcwdrec { get; set; }
    }

    /// <summary>
    /// 废弃部品
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:57
    /// </summary>
    public class QmCostWasteDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QcwdSfId { get; set; }

        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Qcwd001 { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Qcwd002 { get; set; }

        [Required(ErrorMessage = "间接人员赁率不能为空")]
        [ExcelColumn(Name = "间接人员赁率")]
        [ExcelColumnName("间接人员赁率")]
        public decimal Qcwd003 { get; set; }

        [ExcelColumn(Name = "部品品号")]
        [ExcelColumnName("部品品号")]
        public string Qcwd004 { get; set; }

        [ExcelColumn(Name = "部品品名")]
        [ExcelColumnName("部品品名")]
        public string Qcwd005 { get; set; }

        [ExcelColumn(Name = "事故内容")]
        [ExcelColumnName("事故内容")]
        public string Qcwd006 { get; set; }

        [Required(ErrorMessage = "废弃费用不能为空")]
        [ExcelColumn(Name = "废弃费用")]
        [ExcelColumnName("废弃费用")]
        public decimal Qcwd007 { get; set; }

        [Required(ErrorMessage = "废弃数量不能为空")]
        [ExcelColumn(Name = "废弃数量")]
        [ExcelColumnName("废弃数量")]
        public decimal Qcwd008 { get; set; }

        [Required(ErrorMessage = "部品单价不能为空")]
        [ExcelColumn(Name = "部品单价")]
        [ExcelColumnName("部品单价")]
        public decimal Qcwd009 { get; set; }

        [Required(ErrorMessage = "废弃处理费用不能为空")]
        [ExcelColumn(Name = "废弃处理费用")]
        [ExcelColumnName("废弃处理费用")]
        public decimal Qcwd010 { get; set; }

        [Required(ErrorMessage = "运费不能为空")]
        [ExcelColumn(Name = "运费")]
        [ExcelColumnName("运费")]
        public decimal Qcwd011 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcwd012 { get; set; }

        [Required(ErrorMessage = "处理作业时间(分)不能为空")]
        [ExcelColumn(Name = "处理作业时间(分)")]
        [ExcelColumnName("处理作业时间(分)")]
        public int Qcwd013 { get; set; }

        [Required(ErrorMessage = "关税不能为空")]
        [ExcelColumn(Name = "关税")]
        [ExcelColumnName("关税")]
        public decimal Qcwd014 { get; set; }

        [Required(ErrorMessage = "处理发生其他费用不能为空")]
        [ExcelColumn(Name = "处理发生其他费用")]
        [ExcelColumnName("处理发生其他费用")]
        public decimal Qcwd015 { get; set; }

        [ExcelColumn(Name = "设变")]
        [ExcelColumnName("设变")]
        public string Qcwd016 { get; set; }

        [ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]
        public string Qcwdrec { get; set; }

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

        [ExcelColumn(Name = "机种")]
        public string Qcwd002Label { get; set; }

        [ExcelColumn(Name = "担当")]
        public string QcwdrecLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 废弃部品
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:11:57
    /// </summary>
    public class QmCostWasteImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QcwdSfId { get; set; }

        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Qcwd001 { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Qcwd002 { get; set; }

        [Required(ErrorMessage = "间接人员赁率不能为空")]
        [ExcelColumn(Name = "间接人员赁率")]
        [ExcelColumnName("间接人员赁率")]
        public decimal Qcwd003 { get; set; }

        [ExcelColumn(Name = "部品品号")]
        [ExcelColumnName("部品品号")]
        public string Qcwd004 { get; set; }

        [ExcelColumn(Name = "部品品名")]
        [ExcelColumnName("部品品名")]
        public string Qcwd005 { get; set; }

        [ExcelColumn(Name = "事故内容")]
        [ExcelColumnName("事故内容")]
        public string Qcwd006 { get; set; }

        [Required(ErrorMessage = "废弃费用不能为空")]
        [ExcelColumn(Name = "废弃费用")]
        [ExcelColumnName("废弃费用")]
        public decimal Qcwd007 { get; set; }

        [Required(ErrorMessage = "废弃数量不能为空")]
        [ExcelColumn(Name = "废弃数量")]
        [ExcelColumnName("废弃数量")]
        public decimal Qcwd008 { get; set; }

        [Required(ErrorMessage = "部品单价不能为空")]
        [ExcelColumn(Name = "部品单价")]
        [ExcelColumnName("部品单价")]
        public decimal Qcwd009 { get; set; }

        [Required(ErrorMessage = "废弃处理费用不能为空")]
        [ExcelColumn(Name = "废弃处理费用")]
        [ExcelColumnName("废弃处理费用")]
        public decimal Qcwd010 { get; set; }

        [Required(ErrorMessage = "运费不能为空")]
        [ExcelColumn(Name = "运费")]
        [ExcelColumnName("运费")]
        public decimal Qcwd011 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        [ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Qcwd012 { get; set; }

        [Required(ErrorMessage = "处理作业时间(分)不能为空")]
        [ExcelColumn(Name = "处理作业时间(分)")]
        [ExcelColumnName("处理作业时间(分)")]
        public int Qcwd013 { get; set; }

        [Required(ErrorMessage = "关税不能为空")]
        [ExcelColumn(Name = "关税")]
        [ExcelColumnName("关税")]
        public decimal Qcwd014 { get; set; }

        [Required(ErrorMessage = "处理发生其他费用不能为空")]
        [ExcelColumn(Name = "处理发生其他费用")]
        [ExcelColumnName("处理发生其他费用")]
        public decimal Qcwd015 { get; set; }

        [ExcelColumn(Name = "设变")]
        [ExcelColumnName("设变")]
        public string Qcwd016 { get; set; }

        [ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]
        public string Qcwdrec { get; set; }

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
        [ExcelColumn(Name = "机种")]
        public string Qcwd002Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "担当")]
        public string QcwdrecLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}