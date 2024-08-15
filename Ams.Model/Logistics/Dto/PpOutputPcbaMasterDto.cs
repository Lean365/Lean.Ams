using Ams.Model.Logistics;

namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 制二OPH主表
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:09:27
    /// </summary>
    public class PpOutputPcbaMasterQueryDto : PagerInfo 
    {
        public string PomOrderNo { get; set; }
        public string PomLot { get; set; }
        public string PomModel { get; set; }
        public string PomItem { get; set; }
        public string PomSerial { get; set; }
        public string PomDeptName { get; set; }
        public DateTime? BeginPomDate { get; set; }
        public DateTime? EndPomDate { get; set; }
    }

    /// <summary>
    /// 制二OPH主表
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:09:27
    /// </summary>
    public class PpOutputPcbaMasterDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PomSfId { get; set; }

        [Required(ErrorMessage = "订单类别不能为空")]
        [ExcelColumn(Name = "订单类别")]
        [ExcelColumnName("订单类别")]
        public string PomOrderType { get; set; }

        [Required(ErrorMessage = "订单号码不能为空")]
        [ExcelColumn(Name = "订单号码")]
        [ExcelColumnName("订单号码")]
        public string PomOrderNo { get; set; }

        [Required(ErrorMessage = "订单数量不能为空")]
        [ExcelColumn(Name = "订单数量")]
        [ExcelColumnName("订单数量")]
        public decimal PomOrderQty { get; set; }

        [Required(ErrorMessage = "生产批次不能为空")]
        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string PomLot { get; set; }

        [Required(ErrorMessage = "机种不能为空")]
        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string PomModel { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string PomItem { get; set; }

        [Required(ErrorMessage = "序列号不能为空")]
        [ExcelIgnore]
        public string PomSerial { get; set; }

        [Required(ErrorMessage = "生产班组不能为空")]
        [ExcelColumn(Name = "生产班组")]
        [ExcelColumnName("生产班组")]
        public string PomDeptName { get; set; }

        [Required(ErrorMessage = "生产日期不能为空")]
        [ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? PomDate { get; set; }

        [Required(ErrorMessage = "直接人数不能为空")]
        [ExcelColumn(Name = "直接人数")]
        [ExcelColumnName("直接人数")]
        public int PomDirect { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        [ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]
        public int PomIndirect { get; set; }

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
        public List<PpOutputPcbaSlaveDto> PpOutputPcbaSlaveNav { get; set; }
        [ExcelColumn(Name = "生产班组")]
        public string PomDeptNameLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
        [ExcelColumn(Name = "板别")]
        public string PosPcbaTypeLabel { get; set; }
        [ExcelColumn(Name = "板面")]
        public string PosPcbaSideLabel { get; set; }
        [ExcelColumn(Name = "完成情况")]
        public string PosPcbaStatedLabel { get; set; }
        [ExcelColumn(Name = "停线原因")]
        public string PosDownTimeReasonsLabel { get; set; }
        [ExcelColumn(Name = "未达成原因")]
        public string PosMissingReasonsLabel { get; set; }
    }

    /// <summary>
    /// 制二OPH主表
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:09:27
    /// </summary>
    public class PpOutputPcbaMasterImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PomSfId { get; set; }

        [Required(ErrorMessage = "订单类别不能为空")]
        [ExcelColumn(Name = "订单类别")]
        [ExcelColumnName("订单类别")]
        public string PomOrderType { get; set; }

        [Required(ErrorMessage = "订单号码不能为空")]
        [ExcelColumn(Name = "订单号码")]
        [ExcelColumnName("订单号码")]
        public string PomOrderNo { get; set; }

        [Required(ErrorMessage = "订单数量不能为空")]
        [ExcelColumn(Name = "订单数量")]
        [ExcelColumnName("订单数量")]
        public decimal PomOrderQty { get; set; }

        [Required(ErrorMessage = "生产批次不能为空")]
        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string PomLot { get; set; }

        [Required(ErrorMessage = "机种不能为空")]
        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string PomModel { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string PomItem { get; set; }

        [Required(ErrorMessage = "序列号不能为空")]
        [ExcelIgnore]
        public string PomSerial { get; set; }

        [Required(ErrorMessage = "生产班组不能为空")]
        [ExcelColumn(Name = "生产班组")]
        [ExcelColumnName("生产班组")]
        public string PomDeptName { get; set; }

        [Required(ErrorMessage = "生产日期不能为空")]
        [ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? PomDate { get; set; }

        [Required(ErrorMessage = "直接人数不能为空")]
        [ExcelColumn(Name = "直接人数")]
        [ExcelColumnName("直接人数")]
        public int PomDirect { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        [ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]
        public int PomIndirect { get; set; }

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
        public List<PpOutputPcbaSlaveDto> PpOutputPcbaSlaveNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "生产班组")]
        public string PomDeptNameLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "板别")]
        public string PosPcbaTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "板面")]
        public string PosPcbaSideLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "完成情况")]
        public string PosPcbaStatedLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "停线原因")]
        public string PosDownTimeReasonsLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "未达成原因")]
        public string PosMissingReasonsLabel { get; set; }
    }

}