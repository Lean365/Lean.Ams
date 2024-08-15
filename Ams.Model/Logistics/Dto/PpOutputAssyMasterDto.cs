using Ams.Model.Logistics;

namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 制一OPH主表
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:09:23
    /// </summary>
    public class PpOutputAssyMasterQueryDto : PagerInfo 
    {
        public string PomOrderNo { get; set; }
        public string PomLot { get; set; }
        public string PomModel { get; set; }
        public string PomItem { get; set; }
        public DateTime? BeginPomDate { get; set; }
        public DateTime? EndPomDate { get; set; }
        public string PomLine { get; set; }
    }

    /// <summary>
    /// 制一OPH主表
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:09:23
    /// </summary>
    public class PpOutputAssyMasterDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PomSfId { get; set; }

        [Required(ErrorMessage = "工单类别不能为空")]
        [ExcelColumn(Name = "工单类别")]
        [ExcelColumnName("工单类别")]
        public string PomOrderType { get; set; }

        [Required(ErrorMessage = "工单号码不能为空")]
        [ExcelColumn(Name = "工单号码")]
        [ExcelColumnName("工单号码")]
        public string PomOrderNo { get; set; }

        [Required(ErrorMessage = "工单数量不能为空")]
        [ExcelColumn(Name = "工单数量")]
        [ExcelColumnName("工单数量")]
        public decimal PomOrderQty { get; set; }

        [Required(ErrorMessage = "序列号不能为空")]
        [ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string PomOrderSerial { get; set; }

        [Required(ErrorMessage = "生产批次不能为空")]
        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string PomLot { get; set; }

        [Required(ErrorMessage = "机种名不能为空")]
        [ExcelColumn(Name = "机种名")]
        [ExcelColumnName("机种名")]
        public string PomModel { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string PomItem { get; set; }

        [Required(ErrorMessage = "生产日期不能为空")]
        [ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? PomDate { get; set; }

        [Required(ErrorMessage = "生产班组不能为空")]
        [ExcelColumn(Name = "生产班组")]
        [ExcelColumnName("生产班组")]
        public string PomLine { get; set; }

        [Required(ErrorMessage = "直接人数不能为空")]
        [ExcelColumn(Name = "直接人数")]
        [ExcelColumnName("直接人数")]
        public int PomDirect { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        [ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]
        public int PomIndirect { get; set; }

        [Required(ErrorMessage = "标准工时不能为空")]
        [ExcelColumn(Name = "标准工时")]
        [ExcelColumnName("标准工时")]
        public decimal PomStdTime { get; set; }

        [Required(ErrorMessage = "标准产能不能为空")]
        [ExcelColumn(Name = "标准产能")]
        [ExcelColumnName("标准产能")]
        public decimal PomStdOutput { get; set; }

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

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        public List<PpOutputAssySlaveDto> PpOutputAssySlaveNav { get; set; }
        [ExcelColumn(Name = "生产班组")]
        public string PomLineLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
        [ExcelColumn(Name = "生产时段")]
        public string PosProductionTimeLabel { get; set; }
        [ExcelColumn(Name = "停线原因")]
        public string PosDownTimeReasonsLabel { get; set; }
        [ExcelColumn(Name = "未达成原因")]
        public string PosMissingReasonsLabel { get; set; }
    }

    /// <summary>
    /// 制一OPH主表
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:09:23
    /// </summary>
    public class PpOutputAssyMasterImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PomSfId { get; set; }

        [Required(ErrorMessage = "工单类别不能为空")]
        [ExcelColumn(Name = "工单类别")]
        [ExcelColumnName("工单类别")]
        public string PomOrderType { get; set; }

        [Required(ErrorMessage = "工单号码不能为空")]
        [ExcelColumn(Name = "工单号码")]
        [ExcelColumnName("工单号码")]
        public string PomOrderNo { get; set; }

        [Required(ErrorMessage = "工单数量不能为空")]
        [ExcelColumn(Name = "工单数量")]
        [ExcelColumnName("工单数量")]
        public decimal PomOrderQty { get; set; }

        [Required(ErrorMessage = "序列号不能为空")]
        [ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string PomOrderSerial { get; set; }

        [Required(ErrorMessage = "生产批次不能为空")]
        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string PomLot { get; set; }

        [Required(ErrorMessage = "机种名不能为空")]
        [ExcelColumn(Name = "机种名")]
        [ExcelColumnName("机种名")]
        public string PomModel { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string PomItem { get; set; }

        [Required(ErrorMessage = "生产日期不能为空")]
        [ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? PomDate { get; set; }

        [Required(ErrorMessage = "生产班组不能为空")]
        [ExcelColumn(Name = "生产班组")]
        [ExcelColumnName("生产班组")]
        public string PomLine { get; set; }

        [Required(ErrorMessage = "直接人数不能为空")]
        [ExcelColumn(Name = "直接人数")]
        [ExcelColumnName("直接人数")]
        public int PomDirect { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        [ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]
        public int PomIndirect { get; set; }

        [Required(ErrorMessage = "标准工时不能为空")]
        [ExcelColumn(Name = "标准工时")]
        [ExcelColumnName("标准工时")]
        public decimal PomStdTime { get; set; }

        [Required(ErrorMessage = "标准产能不能为空")]
        [ExcelColumn(Name = "标准产能")]
        [ExcelColumnName("标准产能")]
        public decimal PomStdOutput { get; set; }

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

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        public List<PpOutputAssySlaveDto> PpOutputAssySlaveNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "生产班组")]
        public string PomLineLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "生产时段")]
        public string PosProductionTimeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "停线原因")]
        public string PosDownTimeReasonsLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "未达成原因")]
        public string PosMissingReasonsLabel { get; set; }
    }

}