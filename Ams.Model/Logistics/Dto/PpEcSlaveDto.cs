namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 从设变
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:27:37
    /// </summary>
    public class PpEcSlaveQueryDto : PagerInfo
    {
    }

    /// <summary>
    /// 从设变
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:27:37
    /// </summary>
    public class PpEcSlaveDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EsSFID { get; set; }

        [Required(ErrorMessage = "EsParentSfid不能为空")]
        [ExcelColumn(Name = "EsParentSfid")]
        [ExcelColumnName("EsParentSfid")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EsParentSfid { get; set; }

        [Required(ErrorMessage = "输入日不能为空")]
        [ExcelColumn(Name = "输入日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("输入日")]
        public DateTime? EsEntryDate { get; set; }

        [Required(ErrorMessage = "设变No.不能为空")]
        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string EsEcNo { get; set; }

        [Required(ErrorMessage = "机种不能为空")]
        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string EsModel { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string EsItem { get; set; }

        [ExcelColumn(Name = "子物料")]
        [ExcelColumnName("子物料")]
        public string EsSubItem { get; set; }

        [ExcelColumn(Name = "旧物料")]
        [ExcelColumnName("旧物料")]
        public string EsOldItem { get; set; }

        [ExcelColumn(Name = "旧文本")]
        [ExcelColumnName("旧文本")]
        public string EsOldItemText { get; set; }

        [Required(ErrorMessage = "用量不能为空")]
        [ExcelColumn(Name = "用量")]
        [ExcelColumnName("用量")]
        public decimal EsOldUsageQty { get; set; }

        [ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string EsOldSetLoc { get; set; }

        [ExcelColumn(Name = "新物料")]
        [ExcelColumnName("新物料")]
        public string EsNewItem { get; set; }

        [ExcelColumn(Name = "新文本")]
        [ExcelColumnName("新文本")]
        public string EsNewItemText { get; set; }

        [Required(ErrorMessage = "用量不能为空")]
        [ExcelColumn(Name = "用量")]
        [ExcelColumnName("用量")]
        public decimal EsNewUsageQty { get; set; }

        [ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string EsNewSetLoc { get; set; }

        [ExcelColumn(Name = "bom番号")]
        [ExcelColumnName("bom番号")]
        public string EsBomNo { get; set; }

        [ExcelColumn(Name = "互换")]
        [ExcelColumnName("互换")]
        public string EsChange { get; set; }

        [ExcelColumn(Name = "区分")]
        [ExcelColumnName("区分")]
        public string Eslocal { get; set; }

        [ExcelColumn(Name = "指示")]
        [ExcelColumnName("指示")]
        public string Esnote { get; set; }

        [ExcelColumn(Name = "旧品处理")]
        [ExcelColumnName("旧品处理")]
        public string EsOldProcess { get; set; }

        [Required(ErrorMessage = "bom日期不能为空")]
        [ExcelColumn(Name = "bom日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("bom日期")]
        public DateTime? EsBomDate { get; set; }

        [Required(ErrorMessage = "实施部门不能为空")]
        [ExcelColumn(Name = "实施部门")]
        [ExcelColumnName("实施部门")]
        public string EmEcImpDept { get; set; }

        [Required(ErrorMessage = "采购类型不能为空")]
        [ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string EsPurType { get; set; }

        [Required(ErrorMessage = "仓库不能为空")]
        [ExcelColumn(Name = "仓库")]
        [ExcelColumnName("仓库")]
        public string EsSloc { get; set; }

        [ExcelColumn(Name = "检验否")]
        [ExcelColumnName("检验否")]
        public string EsInsmk { get; set; }

        [ExcelColumn(Name = "工厂状态")]
        [ExcelColumnName("工厂状态")]
        public string EsMstae { get; set; }

        [Required(ErrorMessage = "SOP不能为空")]
        [ExcelColumn(Name = "SOP")]
        [ExcelColumnName("SOP")]
        public int EsSopStae { get; set; }

        [Required(ErrorMessage = "旧品库存不能为空")]
        [ExcelColumn(Name = "旧品库存")]
        [ExcelColumnName("旧品库存")]
        public decimal EsOldCurrStock { get; set; }

        [Required(ErrorMessage = "新品库存不能为空")]
        [ExcelColumn(Name = "新品库存")]
        [ExcelColumnName("新品库存")]
        public decimal EsNewCurrStock { get; set; }

        [ExcelColumn(Name = "采购登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("采购登入日期")]
        public DateTime? EsPurEntryDate { get; set; }

        [ExcelColumn(Name = "供应商")]
        [ExcelColumnName("供应商")]
        public string EsSupplier { get; set; }

        [ExcelColumn(Name = "采购PO")]
        [ExcelColumnName("采购PO")]
        public string EsPurOrder { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EsPurNote { get; set; }

        [ExcelColumn(Name = "采购新增")]
        [ExcelColumnName("采购新增")]
        public string EsPurCreator { get; set; }

        [ExcelIgnore]
        public DateTime? EsPurCreateTime { get; set; }

        [ExcelColumn(Name = "采购修改")]
        [ExcelColumnName("采购修改")]
        public string EsPurModifier { get; set; }

        [ExcelColumn(Name = "采购修改日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("采购修改日期")]
        public DateTime? EsPurModifyTime { get; set; }

        [ExcelColumn(Name = "生管登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生管登入日期")]
        public DateTime? EsPmcEntryDate { get; set; }

        [ExcelColumn(Name = "预投入批次")]
        [ExcelColumnName("预投入批次")]
        public string EsPmcLot { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EsPmcMemo { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string EsPmcNote { get; set; }

        [ExcelColumn(Name = "生管新增")]
        [ExcelColumnName("生管新增")]
        public string EsPmcCreator { get; set; }

        [ExcelIgnore]
        public DateTime? EsPmcCreateTime { get; set; }

        [ExcelColumn(Name = "生管修改")]
        [ExcelColumnName("生管修改")]
        public string EsPmcModifier { get; set; }

        [ExcelColumn(Name = "生管修改日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生管修改日期")]
        public DateTime? EsPmcModifyTime { get; set; }

        [ExcelColumn(Name = "IQC登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("IQC登入日期")]
        public DateTime? EsIqcEntryDate { get; set; }

        [ExcelColumn(Name = "检验订单")]
        [ExcelColumnName("检验订单")]
        public string EsIqcOrder { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EsIqcNote { get; set; }

        [ExcelColumn(Name = "IQC新增")]
        [ExcelColumnName("IQC新增")]
        public string EsIqcCreator { get; set; }

        [ExcelIgnore]
        public DateTime? EsIqcCreateTime { get; set; }

        [ExcelColumn(Name = "IQC修改")]
        [ExcelColumnName("IQC修改")]
        public string EsIqcModifier { get; set; }

        [ExcelColumn(Name = "IQC修改日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("IQC修改日期")]
        public DateTime? EsIqcModifyTime { get; set; }

        [ExcelColumn(Name = "部管登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("部管登入日期")]
        public DateTime? EsMmEntryDate { get; set; }

        [ExcelColumn(Name = "领用批次")]
        [ExcelColumnName("领用批次")]
        public string EsMmLot { get; set; }

        [ExcelColumn(Name = "工单")]
        [ExcelColumnName("工单")]
        public string EsMmMocNo { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EsMmNote { get; set; }

        [ExcelColumn(Name = "EsMmCreator")]
        [ExcelColumnName("EsMmCreator")]
        public string EsMmCreator { get; set; }

        [ExcelIgnore]
        public DateTime? EsMmCreateTime { get; set; }

        [ExcelColumn(Name = "EsMmModifier")]
        [ExcelColumnName("EsMmModifier")]
        public string EsMmModifier { get; set; }

        [ExcelColumn(Name = "EsMmModifyTime", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("EsMmModifyTime")]
        public DateTime? EsMmModifyTime { get; set; }

        [ExcelColumn(Name = "制一登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("制一登入日期")]
        public DateTime? EsPpEntryDate { get; set; }

        [ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string EsPpLine { get; set; }

        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string EsPpLot { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EsPpNote { get; set; }

        [ExcelColumn(Name = "EsPpCreator")]
        [ExcelColumnName("EsPpCreator")]
        public string EsPpCreator { get; set; }

        [ExcelIgnore]
        public DateTime? EsPpCreateTime { get; set; }

        [ExcelColumn(Name = "EsPpModifier")]
        [ExcelColumnName("EsPpModifier")]
        public string EsPpModifier { get; set; }

        [ExcelColumn(Name = "EsPpModifyTime", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("EsPpModifyTime")]
        public DateTime? EsPpModifyTime { get; set; }

        [ExcelColumn(Name = "制二登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("制二登入日期")]
        public DateTime? EsPcbaEntryDate { get; set; }

        [ExcelColumn(Name = "Pcba班组")]
        [ExcelColumnName("Pcba班组")]
        public string EsPcbaLine { get; set; }

        [ExcelColumn(Name = "Pcba批次")]
        [ExcelColumnName("Pcba批次")]
        public string EsPcbaLot { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EsPcbaNote { get; set; }

        [ExcelColumn(Name = "EsPcbaCreator")]
        [ExcelColumnName("EsPcbaCreator")]
        public string EsPcbaCreator { get; set; }

        [ExcelIgnore]
        public DateTime? EsPcbaCreateTime { get; set; }

        [ExcelColumn(Name = "EsPcbaModifier")]
        [ExcelColumnName("EsPcbaModifier")]
        public string EsPcbaModifier { get; set; }

        [ExcelColumn(Name = "EsPcbaModifyTime", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("EsPcbaModifyTime")]
        public DateTime? EsPcbaModifyTime { get; set; }

        [ExcelColumn(Name = "QA确认日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("QA确认日期")]
        public DateTime? EsQaEntryDate { get; set; }

        [ExcelColumn(Name = "检验批次")]
        [ExcelColumnName("检验批次")]
        public string EsQaLot { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string EsQaNote { get; set; }

        [ExcelColumn(Name = "EsQaCreator")]
        [ExcelColumnName("EsQaCreator")]
        public string EsQaCreator { get; set; }

        [ExcelIgnore]
        public DateTime? EsQaCreateTime { get; set; }

        [ExcelColumn(Name = "EsQaModifier")]
        [ExcelColumnName("EsQaModifier")]
        public string EsQaModifier { get; set; }

        [ExcelColumn(Name = "EsQaModifyTime", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("EsQaModifyTime")]
        public DateTime? EsQaModifyTime { get; set; }

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

        [ExcelColumn(Name = "采购类型")]
        public string EsPurTypeLabel { get; set; }

        [ExcelColumn(Name = "检验否")]
        public string EsInsmkLabel { get; set; }

        [ExcelColumn(Name = "SOP")]
        public string EsSopStaeLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}