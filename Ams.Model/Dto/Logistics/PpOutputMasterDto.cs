using Ams.Model.Logistics;

namespace Ams.Model.Dto
{
    /// <summary>
    /// oph主表
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/29 8:56:11
    /// </summary>
    public class PpOutputMasterQueryDto : PagerInfo 
    {
        public string PomMfgOrder { get; set; }
        public string PomMfgLot { get; set; }
        public string PomMfgModel { get; set; }
        public string PomMfgItem { get; set; }
        public DateTime? BeginPomMfgDate { get; set; }
        public DateTime? EndPomMfgDate { get; set; }
        public string PomMfgLine { get; set; }
    }

    /// <summary>
    /// oph主表
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/29 8:56:11
    /// </summary>
    public class PpOutputMasterDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PomSfid { get; set; }

        [Required(ErrorMessage = "生产工单不能为空")]
        [ExcelColumn(Name = "生产工单")]
        [ExcelColumnName("生产工单")]
        public string PomMfgOrder { get; set; }

        [Required(ErrorMessage = "工单数量不能为空")]
        [ExcelColumn(Name = "工单数量")]
        [ExcelColumnName("工单数量")]
        public decimal PomMfgOrderQty { get; set; }

        [Required(ErrorMessage = "管理序列号不能为空")]
        [ExcelColumn(Name = "管理序列号")]
        [ExcelColumnName("管理序列号")]
        public string PomMfgOrderSerial { get; set; }

        [Required(ErrorMessage = "生产批次不能为空")]
        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string PomMfgLot { get; set; }

        [Required(ErrorMessage = "机种名不能为空")]
        [ExcelColumn(Name = "机种名")]
        [ExcelColumnName("机种名")]
        public string PomMfgModel { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string PomMfgItem { get; set; }

        [Required(ErrorMessage = "生产日期不能为空")]
        [ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? PomMfgDate { get; set; }

        [Required(ErrorMessage = "生产班组不能为空")]
        [ExcelColumn(Name = "生产班组")]
        [ExcelColumnName("生产班组")]
        public string PomMfgLine { get; set; }

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

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
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
        public List<PpOutputSlaveDto> PpOutputSlaveNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "生产工单")]
        public string PomMfgOrderLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "生产班组")]
        public string PomMfgLineLabel { get; set; }
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
    /// oph主表
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/29 8:56:11
    /// </summary>
    public class PpOutputMasterImportTpl
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PomSfid { get; set; }

        [Required(ErrorMessage = "生产工单不能为空")]
        [ExcelColumn(Name = "生产工单")]
        [ExcelColumnName("生产工单")]
        public string PomMfgOrder { get; set; }

        [Required(ErrorMessage = "工单数量不能为空")]
        [ExcelColumn(Name = "工单数量")]
        [ExcelColumnName("工单数量")]
        public decimal PomMfgOrderQty { get; set; }

        [Required(ErrorMessage = "管理序列号不能为空")]
        [ExcelColumn(Name = "管理序列号")]
        [ExcelColumnName("管理序列号")]
        public string PomMfgOrderSerial { get; set; }

        [Required(ErrorMessage = "生产批次不能为空")]
        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string PomMfgLot { get; set; }

        [Required(ErrorMessage = "机种名不能为空")]
        [ExcelColumn(Name = "机种名")]
        [ExcelColumnName("机种名")]
        public string PomMfgModel { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string PomMfgItem { get; set; }

        [Required(ErrorMessage = "生产日期不能为空")]
        [ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? PomMfgDate { get; set; }

        [Required(ErrorMessage = "生产班组不能为空")]
        [ExcelColumn(Name = "生产班组")]
        [ExcelColumnName("生产班组")]
        public string PomMfgLine { get; set; }

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

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
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
        public List<PpOutputSlaveDto> PpOutputSlaveNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "生产工单")]
        public string PomMfgOrderLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "生产班组")]
        public string PomMfgLineLabel { get; set; }
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