namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 出货检验
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:46:39
    /// </summary>
    public class QmOutgoingQueryDto : PagerInfo
    {
        public string QmoutProOrder { get; set; }
        public string QmoutProLine { get; set; }
        public string QmoutProModels { get; set; }
        public string QmoutProMaterial { get; set; }
        public string QmoutProLot { get; set; }
        public string QmoutProSerial { get; set; }
        public DateTime? BeginQmoutProDate { get; set; }
        public DateTime? EndQmoutProDate { get; set; }
        public string QmoutInspector { get; set; }
        public DateTime? BeginQmoutCheckDate { get; set; }
        public DateTime? EndQmoutCheckDate { get; set; }
        public string[] QmoutInspectingItem { get; set; }
        public string QmoutSamplingLevel { get; set; }
        public string QmoutCheckMethod { get; set; }
        public string QmoutJudgment { get; set; }
        public string QmoutJudgmentLevel { get; set; }
        public string QmoutCheckNotes { get; set; }
    }

    /// <summary>
    /// 出货检验
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:46:39
    /// </summary>
    public class QmOutgoingDto
    {
        [Required(ErrorMessage = "QmoutSfId不能为空")]
        [ExcelColumn(Name = "QmoutSfId")]
        [ExcelColumnName("QmoutSfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QmoutSfId { get; set; }

        [Required(ErrorMessage = "生产工单不能为空")]
        [ExcelColumn(Name = "生产工单")]
        [ExcelColumnName("生产工单")]
        public string QmoutProOrder { get; set; }

        [Required(ErrorMessage = "班组不能为空")]
        [ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string QmoutProLine { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string QmoutProModels { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string QmoutProMaterial { get; set; }

        [Required(ErrorMessage = "批次不能为空")]
        [ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string QmoutProLot { get; set; }

        [Required(ErrorMessage = "序号不能为空")]
        [ExcelColumn(Name = "序号")]
        [ExcelColumnName("序号")]
        public string QmoutProSerial { get; set; }

        [Required(ErrorMessage = "送检数量不能为空")]
        [ExcelColumn(Name = "送检数量")]
        [ExcelColumnName("送检数量")]
        public decimal QmoutProQty { get; set; }

        [Required(ErrorMessage = "生产日期不能为空")]
        [ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? QmoutProDate { get; set; }

        [Required(ErrorMessage = "检查员不能为空")]
        [ExcelColumn(Name = "检查员")]
        [ExcelColumnName("检查员")]
        public string QmoutInspector { get; set; }

        [Required(ErrorMessage = "查验日期不能为空")]
        [ExcelColumn(Name = "查验日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("查验日期")]
        public DateTime? QmoutCheckDate { get; set; }

        [Required(ErrorMessage = "检查项目不能为空")]
        [ExcelColumn(Name = "检查项目")]
        [ExcelColumnName("检查项目")]
        public string QmoutInspectingItem { get; set; }

        [Required(ErrorMessage = "检验水准不能为空")]
        [ExcelColumn(Name = "检验水准")]
        [ExcelColumnName("检验水准")]
        public string QmoutSamplingLevel { get; set; }

        [Required(ErrorMessage = "检验方式不能为空")]
        [ExcelColumn(Name = "检验方式")]
        [ExcelColumnName("检验方式")]
        public string QmoutCheckMethod { get; set; }

        [Required(ErrorMessage = "抽样数不能为空")]
        [ExcelColumn(Name = "抽样数")]
        [ExcelColumnName("抽样数")]
        public decimal QmoutSamplingQty { get; set; }

        [Required(ErrorMessage = "判定不能为空")]
        [ExcelColumn(Name = "判定")]
        [ExcelColumnName("判定")]
        public string QmoutJudgment { get; set; }

        [Required(ErrorMessage = "不良级别不能为空")]
        [ExcelColumn(Name = "不良级别")]
        [ExcelColumnName("不良级别")]
        public string QmoutJudgmentLevel { get; set; }

        [Required(ErrorMessage = "验退数不能为空")]
        [ExcelColumn(Name = "验退数")]
        [ExcelColumnName("验退数")]
        public decimal QmoutRejectQty { get; set; }

        [Required(ErrorMessage = "检查号码不能为空")]
        [ExcelColumn(Name = "检查号码")]
        [ExcelColumnName("检查号码")]
        public string QmoutCheckNotes { get; set; }

        [ExcelColumn(Name = "特记事项")]
        [ExcelColumnName("特记事项")]
        public string QmoutSpecialNotes { get; set; }

        [Required(ErrorMessage = "验收数量不能为空")]
        [ExcelColumn(Name = "验收数量")]
        [ExcelColumnName("验收数量")]
        public decimal QmoutAcceptQty { get; set; }

        [Required(ErrorMessage = "订单数量不能为空")]
        [ExcelColumn(Name = "订单数量")]
        [ExcelColumnName("订单数量")]
        public decimal QmoutOrderQty { get; set; }

        [Required(ErrorMessage = "检验次数不能为空")]
        [ExcelColumn(Name = "检验次数")]
        [ExcelColumnName("检验次数")]
        public int QmoutCheckoutSequence { get; set; }

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
        public string QmoutInspectorLabel { get; set; }

        [ExcelColumn(Name = "检查项目")]
        public string QmoutInspectingItemLabel { get; set; }

        [ExcelColumn(Name = "检验水准")]
        public string QmoutSamplingLevelLabel { get; set; }

        [ExcelColumn(Name = "检验方式")]
        public string QmoutCheckMethodLabel { get; set; }

        [ExcelColumn(Name = "判定")]
        public string QmoutJudgmentLabel { get; set; }

        [ExcelColumn(Name = "不良级别")]
        public string QmoutJudgmentLevelLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 出货检验
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:46:39
    /// </summary>
    public class QmOutgoingImportTpl
    {
        [Required(ErrorMessage = "QmoutSfId不能为空")]
        [ExcelColumn(Name = "QmoutSfId")]
        [ExcelColumnName("QmoutSfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QmoutSfId { get; set; }

        [Required(ErrorMessage = "生产工单不能为空")]
        [ExcelColumn(Name = "生产工单")]
        [ExcelColumnName("生产工单")]
        public string QmoutProOrder { get; set; }

        [Required(ErrorMessage = "班组不能为空")]
        [ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string QmoutProLine { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string QmoutProModels { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string QmoutProMaterial { get; set; }

        [Required(ErrorMessage = "批次不能为空")]
        [ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string QmoutProLot { get; set; }

        [Required(ErrorMessage = "序号不能为空")]
        [ExcelColumn(Name = "序号")]
        [ExcelColumnName("序号")]
        public string QmoutProSerial { get; set; }

        [Required(ErrorMessage = "送检数量不能为空")]
        [ExcelColumn(Name = "送检数量")]
        [ExcelColumnName("送检数量")]
        public decimal QmoutProQty { get; set; }

        [Required(ErrorMessage = "生产日期不能为空")]
        [ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? QmoutProDate { get; set; }

        [Required(ErrorMessage = "检查员不能为空")]
        [ExcelColumn(Name = "检查员")]
        [ExcelColumnName("检查员")]
        public string QmoutInspector { get; set; }

        [Required(ErrorMessage = "查验日期不能为空")]
        [ExcelColumn(Name = "查验日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("查验日期")]
        public DateTime? QmoutCheckDate { get; set; }

        [Required(ErrorMessage = "检查项目不能为空")]
        [ExcelColumn(Name = "检查项目")]
        [ExcelColumnName("检查项目")]
        public string QmoutInspectingItem { get; set; }

        [Required(ErrorMessage = "检验水准不能为空")]
        [ExcelColumn(Name = "检验水准")]
        [ExcelColumnName("检验水准")]
        public string QmoutSamplingLevel { get; set; }

        [Required(ErrorMessage = "检验方式不能为空")]
        [ExcelColumn(Name = "检验方式")]
        [ExcelColumnName("检验方式")]
        public string QmoutCheckMethod { get; set; }

        [Required(ErrorMessage = "抽样数不能为空")]
        [ExcelColumn(Name = "抽样数")]
        [ExcelColumnName("抽样数")]
        public decimal QmoutSamplingQty { get; set; }

        [Required(ErrorMessage = "判定不能为空")]
        [ExcelColumn(Name = "判定")]
        [ExcelColumnName("判定")]
        public string QmoutJudgment { get; set; }

        [Required(ErrorMessage = "不良级别不能为空")]
        [ExcelColumn(Name = "不良级别")]
        [ExcelColumnName("不良级别")]
        public string QmoutJudgmentLevel { get; set; }

        [Required(ErrorMessage = "验退数不能为空")]
        [ExcelColumn(Name = "验退数")]
        [ExcelColumnName("验退数")]
        public decimal QmoutRejectQty { get; set; }

        [Required(ErrorMessage = "检查号码不能为空")]
        [ExcelColumn(Name = "检查号码")]
        [ExcelColumnName("检查号码")]
        public string QmoutCheckNotes { get; set; }

        [ExcelColumn(Name = "特记事项")]
        [ExcelColumnName("特记事项")]
        public string QmoutSpecialNotes { get; set; }

        [Required(ErrorMessage = "验收数量不能为空")]
        [ExcelColumn(Name = "验收数量")]
        [ExcelColumnName("验收数量")]
        public decimal QmoutAcceptQty { get; set; }

        [Required(ErrorMessage = "订单数量不能为空")]
        [ExcelColumn(Name = "订单数量")]
        [ExcelColumnName("订单数量")]
        public decimal QmoutOrderQty { get; set; }

        [Required(ErrorMessage = "检验次数不能为空")]
        [ExcelColumn(Name = "检验次数")]
        [ExcelColumnName("检验次数")]
        public int QmoutCheckoutSequence { get; set; }

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
        public string QmoutInspectorLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "检查项目")]
        public string QmoutInspectingItemLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "检验水准")]
        public string QmoutSamplingLevelLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "检验方式")]
        public string QmoutCheckMethodLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "判定")]
        public string QmoutJudgmentLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "不良级别")]
        public string QmoutJudgmentLevelLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}