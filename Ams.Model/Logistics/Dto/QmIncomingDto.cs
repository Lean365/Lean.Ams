namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 进料检验
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:53:50
    /// </summary>
    public class QmIncomingQueryDto : PagerInfo
    {
        public string QminPurOrder { get; set; }
        public string QminMaterial { get; set; }
        public DateTime? BeginQminPurDate { get; set; }
        public DateTime? EndQminPurDate { get; set; }
        public string QminInspector { get; set; }
        public DateTime? BeginQminCheckDate { get; set; }
        public DateTime? EndQminCheckDate { get; set; }
        public string[] QminInspectingItem { get; set; }
        public string QminSamplingLevel { get; set; }
        public string QminCheckMethod { get; set; }
        public string QminJudgment { get; set; }
        public string QminJudgmentLevel { get; set; }
    }

    /// <summary>
    /// 进料检验
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:53:50
    /// </summary>
    public class QmIncomingDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QminSfId { get; set; }

        [Required(ErrorMessage = "采购订单不能为空")]
        [ExcelColumn(Name = "采购订单")]
        [ExcelColumnName("采购订单")]
        public string QminPurOrder { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string QminMaterial { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal QminPurOrderQty { get; set; }

        [Required(ErrorMessage = "进货日期不能为空")]
        [ExcelColumn(Name = "进货日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("进货日期")]
        public DateTime? QminPurDate { get; set; }

        [Required(ErrorMessage = "检验员不能为空")]
        [ExcelColumn(Name = "检验员")]
        [ExcelColumnName("检验员")]
        public string QminInspector { get; set; }

        [Required(ErrorMessage = "检验日期不能为空")]
        [ExcelColumn(Name = "检验日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("检验日期")]
        public DateTime? QminCheckDate { get; set; }

        [Required(ErrorMessage = "检验项目不能为空")]
        [ExcelColumn(Name = "检验项目")]
        [ExcelColumnName("检验项目")]
        public string QminInspectingItem { get; set; }

        [Required(ErrorMessage = "检验水准不能为空")]
        [ExcelColumn(Name = "检验水准")]
        [ExcelColumnName("检验水准")]
        public string QminSamplingLevel { get; set; }

        [Required(ErrorMessage = "检验方式不能为空")]
        [ExcelColumn(Name = "检验方式")]
        [ExcelColumnName("检验方式")]
        public string QminCheckMethod { get; set; }

        [Required(ErrorMessage = "抽样数不能为空")]
        [ExcelColumn(Name = "抽样数")]
        [ExcelColumnName("抽样数")]
        public decimal QminSamplingQty { get; set; }

        [Required(ErrorMessage = "判定不能为空")]
        [ExcelColumn(Name = "判定")]
        [ExcelColumnName("判定")]
        public string QminJudgment { get; set; }

        [Required(ErrorMessage = "不良级别不能为空")]
        [ExcelColumn(Name = "不良级别")]
        [ExcelColumnName("不良级别")]
        public string QminJudgmentLevel { get; set; }

        [Required(ErrorMessage = "验退数不能为空")]
        [ExcelColumn(Name = "验退数")]
        [ExcelColumnName("验退数")]
        public decimal QminRejectQty { get; set; }

        [ExcelColumn(Name = "特记事项")]
        [ExcelColumnName("特记事项")]
        public string QminSpecialNotes { get; set; }

        [Required(ErrorMessage = "验收数量不能为空")]
        [ExcelColumn(Name = "验收数量")]
        [ExcelColumnName("验收数量")]
        public decimal QminAcceptQty { get; set; }

        [Required(ErrorMessage = "检验次数不能为空")]
        [ExcelColumn(Name = "检验次数")]
        [ExcelColumnName("检验次数")]
        public int QminCheckoutSequence { get; set; }

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

        [ExcelColumn(Name = "检验员")]
        public string QminInspectorLabel { get; set; }

        [ExcelColumn(Name = "检验项目")]
        public string QminInspectingItemLabel { get; set; }

        [ExcelColumn(Name = "检验水准")]
        public string QminSamplingLevelLabel { get; set; }

        [ExcelColumn(Name = "检验方式")]
        public string QminCheckMethodLabel { get; set; }

        [ExcelColumn(Name = "判定")]
        public string QminJudgmentLabel { get; set; }

        [ExcelColumn(Name = "不良级别")]
        public string QminJudgmentLevelLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 进料检验
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:53:50
    /// </summary>
    public class QmIncomingImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QminSfId { get; set; }

        [Required(ErrorMessage = "采购订单不能为空")]
        [ExcelColumn(Name = "采购订单")]
        [ExcelColumnName("采购订单")]
        public string QminPurOrder { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string QminMaterial { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal QminPurOrderQty { get; set; }

        [Required(ErrorMessage = "进货日期不能为空")]
        [ExcelColumn(Name = "进货日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("进货日期")]
        public DateTime? QminPurDate { get; set; }

        [Required(ErrorMessage = "检验员不能为空")]
        [ExcelColumn(Name = "检验员")]
        [ExcelColumnName("检验员")]
        public string QminInspector { get; set; }

        [Required(ErrorMessage = "检验日期不能为空")]
        [ExcelColumn(Name = "检验日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("检验日期")]
        public DateTime? QminCheckDate { get; set; }

        [Required(ErrorMessage = "检验项目不能为空")]
        [ExcelColumn(Name = "检验项目")]
        [ExcelColumnName("检验项目")]
        public string QminInspectingItem { get; set; }

        [Required(ErrorMessage = "检验水准不能为空")]
        [ExcelColumn(Name = "检验水准")]
        [ExcelColumnName("检验水准")]
        public string QminSamplingLevel { get; set; }

        [Required(ErrorMessage = "检验方式不能为空")]
        [ExcelColumn(Name = "检验方式")]
        [ExcelColumnName("检验方式")]
        public string QminCheckMethod { get; set; }

        [Required(ErrorMessage = "抽样数不能为空")]
        [ExcelColumn(Name = "抽样数")]
        [ExcelColumnName("抽样数")]
        public decimal QminSamplingQty { get; set; }

        [Required(ErrorMessage = "判定不能为空")]
        [ExcelColumn(Name = "判定")]
        [ExcelColumnName("判定")]
        public string QminJudgment { get; set; }

        [Required(ErrorMessage = "不良级别不能为空")]
        [ExcelColumn(Name = "不良级别")]
        [ExcelColumnName("不良级别")]
        public string QminJudgmentLevel { get; set; }

        [Required(ErrorMessage = "验退数不能为空")]
        [ExcelColumn(Name = "验退数")]
        [ExcelColumnName("验退数")]
        public decimal QminRejectQty { get; set; }

        [ExcelColumn(Name = "特记事项")]
        [ExcelColumnName("特记事项")]
        public string QminSpecialNotes { get; set; }

        [Required(ErrorMessage = "验收数量不能为空")]
        [ExcelColumn(Name = "验收数量")]
        [ExcelColumnName("验收数量")]
        public decimal QminAcceptQty { get; set; }

        [Required(ErrorMessage = "检验次数不能为空")]
        [ExcelColumn(Name = "检验次数")]
        [ExcelColumnName("检验次数")]
        public int QminCheckoutSequence { get; set; }

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
        [ExcelColumn(Name = "检验员")]
        public string QminInspectorLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "检验项目")]
        public string QminInspectingItemLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "检验水准")]
        public string QminSamplingLevelLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "检验方式")]
        public string QminCheckMethodLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "判定")]
        public string QminJudgmentLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "不良级别")]
        public string QminJudgmentLevelLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}