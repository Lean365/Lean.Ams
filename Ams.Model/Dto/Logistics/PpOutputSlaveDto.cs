
namespace Ams.Model.Dto
{
    /// <summary>
    /// oph从表
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/28 15:35:46
    /// </summary>
    public class PpOutputSlaveQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// oph从表
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/28 15:35:46
    /// </summary>
    public class PpOutputSlaveDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PosSfid { get; set; }

        [Required(ErrorMessage = "父SFID不能为空")]
        [ExcelColumn(Name = "父SFID")]
        [ExcelColumnName("父SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PosParentSfid { get; set; }

        [ExcelColumn(Name = "生产时段")]
        [ExcelColumnName("生产时段")]
        public string PosProductionTime { get; set; }

        [Required(ErrorMessage = "实际产能不能为空")]
        [ExcelColumn(Name = "实际产能")]
        [ExcelColumnName("实际产能")]
        public int PosRealOutput { get; set; }

        [Required(ErrorMessage = "停线时间不能为空")]
        [ExcelColumn(Name = "停线时间")]
        [ExcelColumnName("停线时间")]
        public int PosDownTime { get; set; }

        [ExcelColumn(Name = "停线原因")]
        [ExcelColumnName("停线原因")]
        public string PosDownTimeReasons { get; set; }

        [ExcelColumn(Name = "停线说明")]
        [ExcelColumnName("停线说明")]
        public string PosDownTimeDescription { get; set; }

        [ExcelColumn(Name = "未达成原因")]
        [ExcelColumnName("未达成原因")]
        public string PosUnfinishedReasons { get; set; }

        [ExcelColumn(Name = "未达成说明")]
        [ExcelColumnName("未达成说明")]
        public string PosUnfinishedDescription { get; set; }

        [Required(ErrorMessage = "实际工数不能为空")]
        [ExcelColumn(Name = "实际工数")]
        [ExcelColumnName("实际工数")]
        public int PosRealWorkhours { get; set; }

        [ExcelColumn(Name = "投入工数")]
        [ExcelColumnName("投入工数")]
        public decimal PosInputsWorkhours { get; set; }

        [ExcelColumn(Name = "工时差异")]
        [ExcelColumnName("工时差异")]
        public decimal PosRealWorkinghoursDiff { get; set; }

        [ExcelColumn(Name = "产能差异")]
        [ExcelColumnName("产能差异")]
        public decimal PosRealOutputDiff { get; set; }

        [ExcelColumn(Name = "达成率")]
        [ExcelColumnName("达成率")]
        public decimal PosAchievedRate { get; set; }

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

        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string Remark { get; set; }

        [ExcelColumn(Name = "创建者")]
        [ExcelColumnName("创建者")]
        public string CreateBy { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("创建时间")]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "生产时段")]
        public string PosProductionTimeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "停线原因")]
        public string PosDownTimeReasonsLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "未达成原因")]
        public string PosUnfinishedReasonsLabel { get; set; }
    }
    /// <summary>
    /// oph从表
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/28 15:35:46
    /// </summary>
    public class PpOutputSlaveImportTpl
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

        [ExcelColumn(Name = "生产时段")]
        [ExcelColumnName("生产时段")]
        public string PosProductionTime { get; set; }

        [Required(ErrorMessage = "实际产能不能为空")]
        [ExcelColumn(Name = "实际产能")]
        [ExcelColumnName("实际产能")]
        public int PosRealOutput { get; set; }

        [Required(ErrorMessage = "停线时间不能为空")]
        [ExcelColumn(Name = "停线时间")]
        [ExcelColumnName("停线时间")]
        public int PosDownTime { get; set; }

        [ExcelColumn(Name = "停线原因")]
        [ExcelColumnName("停线原因")]
        public string PosDownTimeReasons { get; set; }

        [ExcelColumn(Name = "停线说明")]
        [ExcelColumnName("停线说明")]
        public string PosDownTimeDescription { get; set; }

        [ExcelColumn(Name = "未达成原因")]
        [ExcelColumnName("未达成原因")]
        public string PosUnfinishedReasons { get; set; }

        [ExcelColumn(Name = "未达成说明")]
        [ExcelColumnName("未达成说明")]
        public string PosUnfinishedDescription { get; set; }

        [Required(ErrorMessage = "实际工数不能为空")]
        [ExcelColumn(Name = "实际工数")]
        [ExcelColumnName("实际工数")]
        public int PosRealWorkhours { get; set; }

        [ExcelColumn(Name = "投入工数")]
        [ExcelColumnName("投入工数")]
        public decimal PosInputsWorkhours { get; set; }

        [ExcelColumn(Name = "工时差异")]
        [ExcelColumnName("工时差异")]
        public decimal PosRealWorkinghoursDiff { get; set; }

        [ExcelColumn(Name = "产能差异")]
        [ExcelColumnName("产能差异")]
        public decimal PosRealOutputDiff { get; set; }

        [ExcelColumn(Name = "达成率")]
        [ExcelColumnName("达成率")]
        public decimal PosAchievedRate { get; set; }

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

        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string Remark { get; set; }

        [ExcelColumn(Name = "创建者")]
        [ExcelColumnName("创建者")]
        public string CreateBy { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("创建时间")]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "生产时段")]
        public string PosProductionTimeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "停线原因")]
        public string PosDownTimeReasonsLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "未达成原因")]
        public string PosUnfinishedReasonsLabel { get; set; }
    }

}