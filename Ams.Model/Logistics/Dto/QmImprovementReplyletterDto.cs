namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 分析对策
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:07:55
    /// </summary>
    public class QmImprovementReplyletterQueryDto : PagerInfo
    {
        public string QirdInspector { get; set; }
        public string QirdLine { get; set; }
        public string QirdOrder { get; set; }
        public string QirdModels { get; set; }
        public string QirdMaterial { get; set; }
        public string QirdRegion { get; set; }
        public DateTime? BeginQirdCheckDate { get; set; }
        public DateTime? EndQirdCheckDate { get; set; }
        public string QirdProLot { get; set; }
        public string QirdJudgmentLevel { get; set; }
        public string QirdCheckNotes { get; set; }
        public string QirdPersonnel { get; set; }
        public DateTime? BeginQirdDate { get; set; }
        public DateTime? EndQirdDate { get; set; }
        public string QirdVerify { get; set; }
        public DateTime? BeginQirdCarryoutdate { get; set; }
        public DateTime? EndQirdCarryoutdate { get; set; }
        public int? QirdCarryoutverify { get; set; }
    }

    /// <summary>
    /// 分析对策
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:07:55
    /// </summary>
    public class QmImprovementReplyletterDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QirdSfId { get; set; }

        [Required(ErrorMessage = "检查员不能为空")]
        [ExcelColumn(Name = "检查员")]
        [ExcelColumnName("检查员")]
        public string QirdInspector { get; set; }

        [Required(ErrorMessage = "班组不能为空")]
        [ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string QirdLine { get; set; }

        [Required(ErrorMessage = "订单不能为空")]
        [ExcelColumn(Name = "订单")]
        [ExcelColumnName("订单")]
        public string QirdOrder { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string QirdModels { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string QirdMaterial { get; set; }

        [ExcelColumn(Name = "仕向")]
        [ExcelColumnName("仕向")]
        public string QirdRegion { get; set; }

        [Required(ErrorMessage = "检验日期不能为空")]
        [ExcelColumn(Name = "检验日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("检验日期")]
        public DateTime? QirdCheckDate { get; set; }

        [ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string QirdProLot { get; set; }

        [ExcelColumn(Name = "序号")]
        [ExcelColumnName("序号")]
        public string QirdProSerial { get; set; }

        [Required(ErrorMessage = "验退数不能为空")]
        [ExcelColumn(Name = "验退数")]
        [ExcelColumnName("验退数")]
        public decimal QirdRejectQty { get; set; }

        [Required(ErrorMessage = "不良级别不能为空")]
        [ExcelColumn(Name = "不良级别")]
        [ExcelColumnName("不良级别")]
        public string QirdJudgmentLevel { get; set; }

        [Required(ErrorMessage = "不良内容不能为空")]
        [ExcelColumn(Name = "不良内容")]
        [ExcelColumnName("不良内容")]
        public string QirdCheckNotes { get; set; }

        [Required(ErrorMessage = "对策人员不能为空")]
        [ExcelColumn(Name = "对策人员")]
        [ExcelColumnName("对策人员")]
        public string QirdPersonnel { get; set; }

        [ExcelColumn(Name = "对应日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("对应日期")]
        public DateTime? QirdDate { get; set; }

        [ExcelColumn(Name = "直接原因")]
        [ExcelColumnName("直接原因")]
        public string QirdDirectreason { get; set; }

        [ExcelColumn(Name = "间接原因")]
        [ExcelColumnName("间接原因")]
        public string QirdIndirectreason { get; set; }

        [ExcelColumn(Name = "处置")]
        [ExcelColumnName("处置")]
        public string QirdDisposal { get; set; }

        [ExcelColumn(Name = "直接对策")]
        [ExcelColumnName("直接对策")]
        public string QirdDirectsolutions { get; set; }

        [ExcelColumn(Name = "间接对策")]
        [ExcelColumnName("间接对策")]
        public string QirdIndirectsolutions { get; set; }

        [Required(ErrorMessage = "检证人员不能为空")]
        [ExcelColumn(Name = "检证人员")]
        [ExcelColumnName("检证人员")]
        public string QirdVerify { get; set; }

        [ExcelColumn(Name = "实施日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("实施日期")]
        public DateTime? QirdCarryoutdate { get; set; }

        [Required(ErrorMessage = "实施查证不能为空")]
        [ExcelColumn(Name = "实施查证")]
        [ExcelColumnName("实施查证")]
        public int QirdCarryoutverify { get; set; }

        [ExcelColumn(Name = "对策实施查证")]
        [ExcelColumnName("对策实施查证")]
        public string QirdSolutionsverify { get; set; }

        [ExcelColumn(Name = "特记事项")]
        [ExcelColumnName("特记事项")]
        public string QirdNotes { get; set; }

        [ExcelColumn(Name = "发行号码")]
        [ExcelColumnName("发行号码")]
        public string QirdIssueno { get; set; }

        [ExcelColumn(Name = "附件")]
        [ExcelColumnName("附件")]
        public string QirdFileUrl { get; set; }

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
        public string QirdInspectorLabel { get; set; }

        [ExcelColumn(Name = "不良级别")]
        public string QirdJudgmentLevelLabel { get; set; }

        [ExcelColumn(Name = "实施查证")]
        public string QirdCarryoutverifyLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 分析对策
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 15:07:55
    /// </summary>
    public class QmImprovementReplyletterImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long QirdSfId { get; set; }

        [Required(ErrorMessage = "检查员不能为空")]
        [ExcelColumn(Name = "检查员")]
        [ExcelColumnName("检查员")]
        public string QirdInspector { get; set; }

        [Required(ErrorMessage = "班组不能为空")]
        [ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string QirdLine { get; set; }

        [Required(ErrorMessage = "订单不能为空")]
        [ExcelColumn(Name = "订单")]
        [ExcelColumnName("订单")]
        public string QirdOrder { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string QirdModels { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string QirdMaterial { get; set; }

        [ExcelColumn(Name = "仕向")]
        [ExcelColumnName("仕向")]
        public string QirdRegion { get; set; }

        [Required(ErrorMessage = "检验日期不能为空")]
        [ExcelColumn(Name = "检验日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("检验日期")]
        public DateTime? QirdCheckDate { get; set; }

        [ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string QirdProLot { get; set; }

        [ExcelColumn(Name = "序号")]
        [ExcelColumnName("序号")]
        public string QirdProSerial { get; set; }

        [Required(ErrorMessage = "验退数不能为空")]
        [ExcelColumn(Name = "验退数")]
        [ExcelColumnName("验退数")]
        public decimal QirdRejectQty { get; set; }

        [Required(ErrorMessage = "不良级别不能为空")]
        [ExcelColumn(Name = "不良级别")]
        [ExcelColumnName("不良级别")]
        public string QirdJudgmentLevel { get; set; }

        [Required(ErrorMessage = "不良内容不能为空")]
        [ExcelColumn(Name = "不良内容")]
        [ExcelColumnName("不良内容")]
        public string QirdCheckNotes { get; set; }

        [Required(ErrorMessage = "对策人员不能为空")]
        [ExcelColumn(Name = "对策人员")]
        [ExcelColumnName("对策人员")]
        public string QirdPersonnel { get; set; }

        [ExcelColumn(Name = "对应日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("对应日期")]
        public DateTime? QirdDate { get; set; }

        [ExcelColumn(Name = "直接原因")]
        [ExcelColumnName("直接原因")]
        public string QirdDirectreason { get; set; }

        [ExcelColumn(Name = "间接原因")]
        [ExcelColumnName("间接原因")]
        public string QirdIndirectreason { get; set; }

        [ExcelColumn(Name = "处置")]
        [ExcelColumnName("处置")]
        public string QirdDisposal { get; set; }

        [ExcelColumn(Name = "直接对策")]
        [ExcelColumnName("直接对策")]
        public string QirdDirectsolutions { get; set; }

        [ExcelColumn(Name = "间接对策")]
        [ExcelColumnName("间接对策")]
        public string QirdIndirectsolutions { get; set; }

        [Required(ErrorMessage = "检证人员不能为空")]
        [ExcelColumn(Name = "检证人员")]
        [ExcelColumnName("检证人员")]
        public string QirdVerify { get; set; }

        [ExcelColumn(Name = "实施日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("实施日期")]
        public DateTime? QirdCarryoutdate { get; set; }

        [Required(ErrorMessage = "实施查证不能为空")]
        [ExcelColumn(Name = "实施查证")]
        [ExcelColumnName("实施查证")]
        public int QirdCarryoutverify { get; set; }

        [ExcelColumn(Name = "对策实施查证")]
        [ExcelColumnName("对策实施查证")]
        public string QirdSolutionsverify { get; set; }

        [ExcelColumn(Name = "特记事项")]
        [ExcelColumnName("特记事项")]
        public string QirdNotes { get; set; }

        [ExcelColumn(Name = "发行号码")]
        [ExcelColumnName("发行号码")]
        public string QirdIssueno { get; set; }

        [ExcelColumn(Name = "附件")]
        [ExcelColumnName("附件")]
        public string QirdFileUrl { get; set; }

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
        public string QirdInspectorLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "不良级别")]
        public string QirdJudgmentLevelLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "实施查证")]
        public string QirdCarryoutverifyLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}