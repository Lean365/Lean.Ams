namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 不合格联络
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:07:53
    /// </summary>
    public class QmUnqualifiedContactletterQueryDto : PagerInfo
    {
        public string QucdInspector { get; set; }
        public string QucdLine { get; set; }
        public string QucdOrder { get; set; }
        public string QucdModels { get; set; }
        public string QucdMaterial { get; set; }
        public string QucdRegion { get; set; }
        public DateTime? BeginQucdCheckDate { get; set; }
        public DateTime? EndQucdCheckDate { get; set; }
        public string QucdProLot { get; set; }
        public string QucdProSerial { get; set; }
        public string QucdJudgmentLevel { get; set; }
        public string QucdIssueno { get; set; }
    }

    /// <summary>
    /// 不合格联络
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:07:53
    /// </summary>
    public class QmUnqualifiedContactletterDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QucdSfId { get; set; }

        [Required(ErrorMessage = "检查员不能为空")]
        [ExcelColumn(Name = "检查员")]
        [ExcelColumnName("检查员")]
        public string QucdInspector { get; set; }

        [Required(ErrorMessage = "班组不能为空")]
        [ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string QucdLine { get; set; }

        [Required(ErrorMessage = "订单不能为空")]
        [ExcelColumn(Name = "订单")]
        [ExcelColumnName("订单")]
        public string QucdOrder { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string QucdModels { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string QucdMaterial { get; set; }

        [ExcelColumn(Name = "仕向")]
        [ExcelColumnName("仕向")]
        public string QucdRegion { get; set; }

        [Required(ErrorMessage = "查验日期不能为空")]
        [ExcelColumn(Name = "查验日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("查验日期")]
        public DateTime? QucdCheckDate { get; set; }

        [ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string QucdProLot { get; set; }

        [ExcelColumn(Name = "序号")]
        [ExcelColumnName("序号")]
        public string QucdProSerial { get; set; }

        [Required(ErrorMessage = "验退数不能为空")]
        [ExcelColumn(Name = "验退数")]
        [ExcelColumnName("验退数")]
        public decimal QucdRejectQty { get; set; }

        [Required(ErrorMessage = "级别不能为空")]
        [ExcelColumn(Name = "级别")]
        [ExcelColumnName("级别")]
        public string QucdJudgmentLevel { get; set; }

        [Required(ErrorMessage = "判定说明不能为空")]
        [ExcelColumn(Name = "判定说明")]
        [ExcelColumnName("判定说明")]
        public string QucdCheckNotes { get; set; }

        [ExcelColumn(Name = "发行号码")]
        [ExcelColumnName("发行号码")]
        public string QucdIssueno { get; set; }

        [ExcelColumn(Name = "附件")]
        [ExcelColumnName("附件")]
        public string QucdFileUrl { get; set; }

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

        [ExcelColumn(Name = "检查员")]
        public string QucdInspectorLabel { get; set; }

        [ExcelColumn(Name = "级别")]
        public string QucdJudgmentLevelLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 不合格联络
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:07:53
    /// </summary>
    public class QmUnqualifiedContactletterImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QucdSfId { get; set; }

        [Required(ErrorMessage = "检查员不能为空")]
        [ExcelColumn(Name = "检查员")]
        [ExcelColumnName("检查员")]
        public string QucdInspector { get; set; }

        [Required(ErrorMessage = "班组不能为空")]
        [ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string QucdLine { get; set; }

        [Required(ErrorMessage = "订单不能为空")]
        [ExcelColumn(Name = "订单")]
        [ExcelColumnName("订单")]
        public string QucdOrder { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string QucdModels { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string QucdMaterial { get; set; }

        [ExcelColumn(Name = "仕向")]
        [ExcelColumnName("仕向")]
        public string QucdRegion { get; set; }

        [Required(ErrorMessage = "查验日期不能为空")]
        [ExcelColumn(Name = "查验日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("查验日期")]
        public DateTime? QucdCheckDate { get; set; }

        [ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string QucdProLot { get; set; }

        [ExcelColumn(Name = "序号")]
        [ExcelColumnName("序号")]
        public string QucdProSerial { get; set; }

        [Required(ErrorMessage = "验退数不能为空")]
        [ExcelColumn(Name = "验退数")]
        [ExcelColumnName("验退数")]
        public decimal QucdRejectQty { get; set; }

        [Required(ErrorMessage = "级别不能为空")]
        [ExcelColumn(Name = "级别")]
        [ExcelColumnName("级别")]
        public string QucdJudgmentLevel { get; set; }

        [Required(ErrorMessage = "判定说明不能为空")]
        [ExcelColumn(Name = "判定说明")]
        [ExcelColumnName("判定说明")]
        public string QucdCheckNotes { get; set; }

        [ExcelColumn(Name = "发行号码")]
        [ExcelColumnName("发行号码")]
        public string QucdIssueno { get; set; }

        [ExcelColumn(Name = "附件")]
        [ExcelColumnName("附件")]
        public string QucdFileUrl { get; set; }

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
        [ExcelColumn(Name = "检查员")]
        public string QucdInspectorLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "级别")]
        public string QucdJudgmentLevelLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}