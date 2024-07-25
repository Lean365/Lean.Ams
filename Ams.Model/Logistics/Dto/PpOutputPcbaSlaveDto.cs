namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 制二OPH从表
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 9:31:04
    /// </summary>
    public class PpOutputPcbaSlaveQueryDto : PagerInfo
    {
        public string PosLineName { get; set; }
    }

    /// <summary>
    /// 制二OPH从表
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 9:31:04
    /// </summary>
    public class PpOutputPcbaSlaveDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PosSfid { get; set; }

        [Required(ErrorMessage = "父SFID不能为空")]
        [ExcelColumn(Name = "父SFID")]
        [ExcelColumnName("父SFID")]
        public long PosParentSfid { get; set; }

        [Required(ErrorMessage = "班组不能为空")]
        [ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string PosLineName { get; set; }

        [Required(ErrorMessage = "Lot数不能为空")]
        [ExcelColumn(Name = "Lot数")]
        [ExcelColumnName("Lot数")]
        public int PosLotQty { get; set; }

        [Required(ErrorMessage = "生产实绩不能为空")]
        [ExcelColumn(Name = "生产实绩")]
        [ExcelColumnName("生产实绩")]
        public int PosRealOutput { get; set; }

        [Required(ErrorMessage = "累计生产数不能为空")]
        [ExcelColumn(Name = "累计生产数")]
        [ExcelColumnName("累计生产数")]
        public int PosRealTotal { get; set; }

        [ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string PosPcbSerial { get; set; }

        [ExcelColumn(Name = "完成情况")]
        [ExcelColumnName("完成情况")]
        public string PosPcbaStated { get; set; }

        [Required(ErrorMessage = "生产工数不能为空")]
        [ExcelColumn(Name = "生产工数")]
        [ExcelColumnName("生产工数")]
        public int PosProTime { get; set; }

        [Required(ErrorMessage = "切换次数不能为空")]
        [ExcelColumn(Name = "切换次数")]
        [ExcelColumnName("切换次数")]
        public int PosHandoffNum { get; set; }

        [Required(ErrorMessage = "切换时间不能为空")]
        [ExcelColumn(Name = "切换时间")]
        [ExcelColumnName("切换时间")]
        public int PosHandoffTime { get; set; }

        [Required(ErrorMessage = "切停机时间不能为空")]
        [ExcelColumn(Name = "切停机时间")]
        [ExcelColumnName("切停机时间")]
        public int PosDownTime { get; set; }

        [Required(ErrorMessage = "损失工数不能为空")]
        [ExcelColumn(Name = "损失工数")]
        [ExcelColumnName("损失工数")]
        public int PosLossTime { get; set; }

        [Required(ErrorMessage = "投入工数不能为空")]
        [ExcelColumn(Name = "投入工数")]
        [ExcelColumnName("投入工数")]
        public int PosMakeTime { get; set; }

        [Required(ErrorMessage = "不良台数不能为空")]
        [ExcelColumn(Name = "不良台数")]
        [ExcelColumnName("不良台数")]
        public int PosBadQty { get; set; }

        [Required(ErrorMessage = "手插仕损不能为空")]
        [ExcelColumn(Name = "手插仕损")]
        [ExcelColumnName("手插仕损")]
        public int PosManualLoss { get; set; }

        [Required(ErrorMessage = "修正仕损不能为空")]
        [ExcelColumn(Name = "修正仕损")]
        [ExcelColumnName("修正仕损")]
        public int PosRepairLoss { get; set; }

        [ExcelColumn(Name = "停线原因")]
        [ExcelColumnName("停线原因")]
        public string PosDownTimeReasons { get; set; }

        [ExcelColumn(Name = "停线备注说明")]
        [ExcelColumnName("停线备注说明")]
        public string PosDownTimeDescription { get; set; }

        [ExcelColumn(Name = "未达成原因")]
        [ExcelColumnName("未达成原因")]
        public string PosMissingReasons { get; set; }

        [ExcelColumn(Name = "未达成备注说明")]
        [ExcelColumnName("未达成备注说明")]
        public string PosMissingDescription { get; set; }

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
        public string PosLineNameLabel { get; set; }

        [ExcelColumn(Name = "完成情况")]
        public string PosPcbaStatedLabel { get; set; }

        [ExcelColumn(Name = "停线原因")]
        public string PosDownTimeReasonsLabel { get; set; }

        [ExcelColumn(Name = "未达成原因")]
        public string PosMissingReasonsLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 制二OPH从表
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 9:31:04
    /// </summary>
    public class PpOutputPcbaSlaveImportTpl
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PosSfid { get; set; }

        [Required(ErrorMessage = "父SFID不能为空")]
        [ExcelColumn(Name = "父SFID")]
        [ExcelColumnName("父SFID")]
        public long PosParentSfid { get; set; }

        [Required(ErrorMessage = "班组不能为空")]
        [ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string PosLineName { get; set; }

        [Required(ErrorMessage = "Lot数不能为空")]
        [ExcelColumn(Name = "Lot数")]
        [ExcelColumnName("Lot数")]
        public int PosLotQty { get; set; }

        [Required(ErrorMessage = "生产实绩不能为空")]
        [ExcelColumn(Name = "生产实绩")]
        [ExcelColumnName("生产实绩")]
        public int PosRealOutput { get; set; }

        [Required(ErrorMessage = "累计生产数不能为空")]
        [ExcelColumn(Name = "累计生产数")]
        [ExcelColumnName("累计生产数")]
        public int PosRealTotal { get; set; }

        [ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string PosPcbSerial { get; set; }

        [ExcelColumn(Name = "完成情况")]
        [ExcelColumnName("完成情况")]
        public string PosPcbaStated { get; set; }

        [Required(ErrorMessage = "生产工数不能为空")]
        [ExcelColumn(Name = "生产工数")]
        [ExcelColumnName("生产工数")]
        public int PosProTime { get; set; }

        [Required(ErrorMessage = "切换次数不能为空")]
        [ExcelColumn(Name = "切换次数")]
        [ExcelColumnName("切换次数")]
        public int PosHandoffNum { get; set; }

        [Required(ErrorMessage = "切换时间不能为空")]
        [ExcelColumn(Name = "切换时间")]
        [ExcelColumnName("切换时间")]
        public int PosHandoffTime { get; set; }

        [Required(ErrorMessage = "切停机时间不能为空")]
        [ExcelColumn(Name = "切停机时间")]
        [ExcelColumnName("切停机时间")]
        public int PosDownTime { get; set; }

        [Required(ErrorMessage = "损失工数不能为空")]
        [ExcelColumn(Name = "损失工数")]
        [ExcelColumnName("损失工数")]
        public int PosLossTime { get; set; }

        [Required(ErrorMessage = "投入工数不能为空")]
        [ExcelColumn(Name = "投入工数")]
        [ExcelColumnName("投入工数")]
        public int PosMakeTime { get; set; }

        [Required(ErrorMessage = "不良台数不能为空")]
        [ExcelColumn(Name = "不良台数")]
        [ExcelColumnName("不良台数")]
        public int PosBadQty { get; set; }

        [Required(ErrorMessage = "手插仕损不能为空")]
        [ExcelColumn(Name = "手插仕损")]
        [ExcelColumnName("手插仕损")]
        public int PosManualLoss { get; set; }

        [Required(ErrorMessage = "修正仕损不能为空")]
        [ExcelColumn(Name = "修正仕损")]
        [ExcelColumnName("修正仕损")]
        public int PosRepairLoss { get; set; }

        [ExcelColumn(Name = "停线原因")]
        [ExcelColumnName("停线原因")]
        public string PosDownTimeReasons { get; set; }

        [ExcelColumn(Name = "停线备注说明")]
        [ExcelColumnName("停线备注说明")]
        public string PosDownTimeDescription { get; set; }

        [ExcelColumn(Name = "未达成原因")]
        [ExcelColumnName("未达成原因")]
        public string PosMissingReasons { get; set; }

        [ExcelColumn(Name = "未达成备注说明")]
        [ExcelColumnName("未达成备注说明")]
        public string PosMissingDescription { get; set; }

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
        public string PosLineNameLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "完成情况")]
        public string PosPcbaStatedLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "停线原因")]
        public string PosDownTimeReasonsLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "未达成原因")]
        public string PosMissingReasonsLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}