
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 从设变
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:30:08
    /// </summary>
    public class PpEcSlaveQueryDto : PagerInfo 
    {
        public string EcsEcNo { get; set; }
        public string EcsModel { get; set; }
        public string EcsItem { get; set; }
        public string EcsSubItem { get; set; }
        public string EcsOldItem { get; set; }
        public string EcsPurType { get; set; }
        public string EcsPurGroup { get; set; }
        public string EcsSloc { get; set; }
        public string EcsInsmk { get; set; }
        public string EcsPlntStated { get; set; }
        public int? EcsSopStated { get; set; }
        public int? EcsImplStated { get; set; }
    }

    /// <summary>
    /// 从设变
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:30:08
    /// </summary>
    public class PpEcSlaveDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EcsSfId { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long EcsParentSfId { get; set; }

        [Required(ErrorMessage = "设变No.不能为空")]
        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string EcsEcNo { get; set; }

        [Required(ErrorMessage = "机种不能为空")]
        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string EcsModel { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string EcsItem { get; set; }

        [Required(ErrorMessage = "物料文本不能为空")]
        [ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]
        public string EcsItemText { get; set; }

        [ExcelColumn(Name = "子物料")]
        [ExcelColumnName("子物料")]
        public string EcsSubItem { get; set; }

        [ExcelColumn(Name = "子物料文本")]
        [ExcelColumnName("子物料文本")]
        public string EcsSubItemText { get; set; }

        [ExcelColumn(Name = "旧物料")]
        [ExcelColumnName("旧物料")]
        public string EcsOldItem { get; set; }

        [ExcelColumn(Name = "旧文本")]
        [ExcelColumnName("旧文本")]
        public string EcsOldItemText { get; set; }

        [Required(ErrorMessage = "旧品库存不能为空")]
        [ExcelColumn(Name = "旧品库存")]
        [ExcelColumnName("旧品库存")]
        public decimal EcsOldCurrStock { get; set; }

        [Required(ErrorMessage = "用量不能为空")]
        [ExcelColumn(Name = "用量")]
        [ExcelColumnName("用量")]
        public decimal EcsOldUsageQty { get; set; }

        [ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string EcsOldSetLoc { get; set; }

        [ExcelColumn(Name = "新物料")]
        [ExcelColumnName("新物料")]
        public string EcsNewItem { get; set; }

        [ExcelColumn(Name = "新文本")]
        [ExcelColumnName("新文本")]
        public string EcsNewItemText { get; set; }

        [Required(ErrorMessage = "新品库存不能为空")]
        [ExcelColumn(Name = "新品库存")]
        [ExcelColumnName("新品库存")]
        public decimal EcsNewCurrStock { get; set; }

        [Required(ErrorMessage = "用量不能为空")]
        [ExcelColumn(Name = "用量")]
        [ExcelColumnName("用量")]
        public decimal EcsNewUsageQty { get; set; }

        [ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string EcsNewSetLoc { get; set; }

        [ExcelColumn(Name = "bom番号")]
        [ExcelColumnName("bom番号")]
        public string EcsBomNo { get; set; }

        [ExcelColumn(Name = "互换")]
        [ExcelColumnName("互换")]
        public string EcsChange { get; set; }

        [ExcelColumn(Name = "区分")]
        [ExcelColumnName("区分")]
        public string EcsDistLocal { get; set; }

        [ExcelColumn(Name = "指示")]
        [ExcelColumnName("指示")]
        public string EcsInstNote { get; set; }

        [ExcelColumn(Name = "旧品处理")]
        [ExcelColumnName("旧品处理")]
        public string EcsOldProcess { get; set; }

        [Required(ErrorMessage = "bom日期不能为空")]
        [ExcelColumn(Name = "bom日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("bom日期")]
        public DateTime? EcsBomDate { get; set; }

        [Required(ErrorMessage = "采购类型不能为空")]
        [ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string EcsPurType { get; set; }

        [Required(ErrorMessage = "采购组不能为空")]
        [ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string EcsPurGroup { get; set; }

        [Required(ErrorMessage = "仓库不能为空")]
        [ExcelColumn(Name = "仓库")]
        [ExcelColumnName("仓库")]
        public string EcsSloc { get; set; }

        [ExcelColumn(Name = "检验否")]
        [ExcelColumnName("检验否")]
        public string EcsInsmk { get; set; }

        [ExcelColumn(Name = "工厂状态")]
        [ExcelColumnName("工厂状态")]
        public string EcsPlntStated { get; set; }

        [Required(ErrorMessage = "SOP不能为空")]
        [ExcelColumn(Name = "SOP")]
        [ExcelColumnName("SOP")]
        public int EcsSopStated { get; set; }

        [Required(ErrorMessage = "实施标记不能为空")]
        [ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int EcsImplStated { get; set; }

        [ExcelColumn(Name = "采购登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("采购登入日期")]
        public DateTime? EcsPurEnteredDate { get; set; }

        [ExcelColumn(Name = "供应商")]
        [ExcelColumnName("供应商")]
        public string EcsPurSupplier { get; set; }

        [ExcelColumn(Name = "采购PO")]
        [ExcelColumnName("采购PO")]
        public string EcsPurOrder { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EcsPurNote { get; set; }

        [ExcelColumn(Name = "生管登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生管登入日期")]
        public DateTime? EcsPmcEnteredDate { get; set; }

        [ExcelColumn(Name = "预投入批次")]
        [ExcelColumnName("预投入批次")]
        public string EcsPmcPreLot { get; set; }

        [ExcelColumn(Name = "旧品处理")]
        [ExcelColumnName("旧品处理")]
        public string EcsPmcDisposal { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string EcsPmcNote { get; set; }

        [ExcelColumn(Name = "IQC登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("IQC登入日期")]
        public DateTime? EcsIqcEnteredDate { get; set; }

        [ExcelColumn(Name = "检验订单")]
        [ExcelColumnName("检验订单")]
        public string EcsIqcOrder { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EcsIqcNote { get; set; }

        [ExcelColumn(Name = "部管登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("部管登入日期")]
        public DateTime? EcsMmEnteredDate { get; set; }

        [ExcelColumn(Name = "领用批次")]
        [ExcelColumnName("领用批次")]
        public string EcsMmLot { get; set; }

        [ExcelColumn(Name = "工单")]
        [ExcelColumnName("工单")]
        public string EcsMmProOrder { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EcsMmNote { get; set; }

        [ExcelColumn(Name = "制一登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("制一登入日期")]
        public DateTime? EcsAssyEnteredDate { get; set; }

        [ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string EcsAssyLine { get; set; }

        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string EcsAssyPutLot { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EcsAssyNote { get; set; }

        [ExcelColumn(Name = "制二登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("制二登入日期")]
        public DateTime? EcsPcbaEnteredDate { get; set; }

        [ExcelColumn(Name = "Pcba班组")]
        [ExcelColumnName("Pcba班组")]
        public string EcsPcbaLine { get; set; }

        [ExcelColumn(Name = "Pcba批次")]
        [ExcelColumnName("Pcba批次")]
        public string EcsPcbaPutLot { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EcsPcbaNote { get; set; }

        [ExcelColumn(Name = "QA确认日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("QA确认日期")]
        public DateTime? EcsFqcEnteredDate { get; set; }

        [ExcelColumn(Name = "检验批次")]
        [ExcelColumnName("检验批次")]
        public string EcsFqcImplLot { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EcsFqcNote { get; set; }

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



        [ExcelColumn(Name = "采购类型")]
        public string EcsPurTypeLabel { get; set; }
        [ExcelColumn(Name = "采购组")]
        public string EcsPurGroupLabel { get; set; }
        [ExcelColumn(Name = "仓库")]
        public string EcsSlocLabel { get; set; }
        [ExcelColumn(Name = "检验否")]
        public string EcsInsmkLabel { get; set; }
        [ExcelColumn(Name = "工厂状态")]
        public string EcsPlntStatedLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 从设变
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:30:08
    /// </summary>
    public class PpEcSlaveImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EcsSfId { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long EcsParentSfId { get; set; }

        [Required(ErrorMessage = "设变No.不能为空")]
        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string EcsEcNo { get; set; }

        [Required(ErrorMessage = "机种不能为空")]
        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string EcsModel { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string EcsItem { get; set; }

        [Required(ErrorMessage = "物料文本不能为空")]
        [ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]
        public string EcsItemText { get; set; }

        [ExcelColumn(Name = "子物料")]
        [ExcelColumnName("子物料")]
        public string EcsSubItem { get; set; }

        [ExcelColumn(Name = "子物料文本")]
        [ExcelColumnName("子物料文本")]
        public string EcsSubItemText { get; set; }

        [ExcelColumn(Name = "旧物料")]
        [ExcelColumnName("旧物料")]
        public string EcsOldItem { get; set; }

        [ExcelColumn(Name = "旧文本")]
        [ExcelColumnName("旧文本")]
        public string EcsOldItemText { get; set; }

        [Required(ErrorMessage = "旧品库存不能为空")]
        [ExcelColumn(Name = "旧品库存")]
        [ExcelColumnName("旧品库存")]
        public decimal EcsOldCurrStock { get; set; }

        [Required(ErrorMessage = "用量不能为空")]
        [ExcelColumn(Name = "用量")]
        [ExcelColumnName("用量")]
        public decimal EcsOldUsageQty { get; set; }

        [ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string EcsOldSetLoc { get; set; }

        [ExcelColumn(Name = "新物料")]
        [ExcelColumnName("新物料")]
        public string EcsNewItem { get; set; }

        [ExcelColumn(Name = "新文本")]
        [ExcelColumnName("新文本")]
        public string EcsNewItemText { get; set; }

        [Required(ErrorMessage = "新品库存不能为空")]
        [ExcelColumn(Name = "新品库存")]
        [ExcelColumnName("新品库存")]
        public decimal EcsNewCurrStock { get; set; }

        [Required(ErrorMessage = "用量不能为空")]
        [ExcelColumn(Name = "用量")]
        [ExcelColumnName("用量")]
        public decimal EcsNewUsageQty { get; set; }

        [ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string EcsNewSetLoc { get; set; }

        [ExcelColumn(Name = "bom番号")]
        [ExcelColumnName("bom番号")]
        public string EcsBomNo { get; set; }

        [ExcelColumn(Name = "互换")]
        [ExcelColumnName("互换")]
        public string EcsChange { get; set; }

        [ExcelColumn(Name = "区分")]
        [ExcelColumnName("区分")]
        public string EcsDistLocal { get; set; }

        [ExcelColumn(Name = "指示")]
        [ExcelColumnName("指示")]
        public string EcsInstNote { get; set; }

        [ExcelColumn(Name = "旧品处理")]
        [ExcelColumnName("旧品处理")]
        public string EcsOldProcess { get; set; }

        [Required(ErrorMessage = "bom日期不能为空")]
        [ExcelColumn(Name = "bom日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("bom日期")]
        public DateTime? EcsBomDate { get; set; }

        [Required(ErrorMessage = "采购类型不能为空")]
        [ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string EcsPurType { get; set; }

        [Required(ErrorMessage = "采购组不能为空")]
        [ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string EcsPurGroup { get; set; }

        [Required(ErrorMessage = "仓库不能为空")]
        [ExcelColumn(Name = "仓库")]
        [ExcelColumnName("仓库")]
        public string EcsSloc { get; set; }

        [ExcelColumn(Name = "检验否")]
        [ExcelColumnName("检验否")]
        public string EcsInsmk { get; set; }

        [ExcelColumn(Name = "工厂状态")]
        [ExcelColumnName("工厂状态")]
        public string EcsPlntStated { get; set; }

        [Required(ErrorMessage = "SOP不能为空")]
        [ExcelColumn(Name = "SOP")]
        [ExcelColumnName("SOP")]
        public int EcsSopStated { get; set; }

        [Required(ErrorMessage = "实施标记不能为空")]
        [ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int EcsImplStated { get; set; }

        [ExcelColumn(Name = "采购登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("采购登入日期")]
        public DateTime? EcsPurEnteredDate { get; set; }

        [ExcelColumn(Name = "供应商")]
        [ExcelColumnName("供应商")]
        public string EcsPurSupplier { get; set; }

        [ExcelColumn(Name = "采购PO")]
        [ExcelColumnName("采购PO")]
        public string EcsPurOrder { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EcsPurNote { get; set; }

        [ExcelColumn(Name = "生管登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生管登入日期")]
        public DateTime? EcsPmcEnteredDate { get; set; }

        [ExcelColumn(Name = "预投入批次")]
        [ExcelColumnName("预投入批次")]
        public string EcsPmcPreLot { get; set; }

        [ExcelColumn(Name = "旧品处理")]
        [ExcelColumnName("旧品处理")]
        public string EcsPmcDisposal { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string EcsPmcNote { get; set; }

        [ExcelColumn(Name = "IQC登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("IQC登入日期")]
        public DateTime? EcsIqcEnteredDate { get; set; }

        [ExcelColumn(Name = "检验订单")]
        [ExcelColumnName("检验订单")]
        public string EcsIqcOrder { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EcsIqcNote { get; set; }

        [ExcelColumn(Name = "部管登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("部管登入日期")]
        public DateTime? EcsMmEnteredDate { get; set; }

        [ExcelColumn(Name = "领用批次")]
        [ExcelColumnName("领用批次")]
        public string EcsMmLot { get; set; }

        [ExcelColumn(Name = "工单")]
        [ExcelColumnName("工单")]
        public string EcsMmProOrder { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EcsMmNote { get; set; }

        [ExcelColumn(Name = "制一登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("制一登入日期")]
        public DateTime? EcsAssyEnteredDate { get; set; }

        [ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string EcsAssyLine { get; set; }

        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string EcsAssyPutLot { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EcsAssyNote { get; set; }

        [ExcelColumn(Name = "制二登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("制二登入日期")]
        public DateTime? EcsPcbaEnteredDate { get; set; }

        [ExcelColumn(Name = "Pcba班组")]
        [ExcelColumnName("Pcba班组")]
        public string EcsPcbaLine { get; set; }

        [ExcelColumn(Name = "Pcba批次")]
        [ExcelColumnName("Pcba批次")]
        public string EcsPcbaPutLot { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EcsPcbaNote { get; set; }

        [ExcelColumn(Name = "QA确认日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("QA确认日期")]
        public DateTime? EcsFqcEnteredDate { get; set; }

        [ExcelColumn(Name = "检验批次")]
        [ExcelColumnName("检验批次")]
        public string EcsFqcImplLot { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EcsFqcNote { get; set; }

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
        [ExcelColumn(Name = "采购类型")]
        public string EcsPurTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "采购组")]
        public string EcsPurGroupLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "仓库")]
        public string EcsSlocLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "检验否")]
        public string EcsInsmkLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "工厂状态")]
        public string EcsPlntStatedLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}