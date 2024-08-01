namespace Ams.Model.Logistics
{
    /// <summary>
    /// 从设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:30:08
    /// </summary>
    [SugarTable("pp_ec_slave", "从设变")]
    public class PpEcSlave : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long EcsSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EcsParentSfId { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        [SugarColumn(ColumnName = "EcsEcNo", ColumnDescription = "设变No. ", Length = 20)]
        public string EcsEcNo { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "EcsModel", ColumnDescription = "机种 ", Length = 200)]
        public string EcsModel { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "EcsItem", ColumnDescription = "物料 ", Length = 20)]
        public string EcsItem { get; set; }

        /// <summary>
        /// 物料文本
        /// </summary>
        [SugarColumn(ColumnName = "EcsItemText", ColumnDescription = "物料文本 ", Length = 40)]
        public string EcsItemText { get; set; }

        /// <summary>
        /// 子物料
        /// </summary>
        [SugarColumn(ColumnName = "EcsSubItem", ColumnDescription = "子物料 ", Length = 20)]
        public string EcsSubItem { get; set; }

        /// <summary>
        /// 子物料文本
        /// </summary>
        [SugarColumn(ColumnName = "EcsSubItemText", ColumnDescription = "子物料文本 ", Length = 40)]
        public string EcsSubItemText { get; set; }

        /// <summary>
        /// 旧物料
        /// </summary>
        [SugarColumn(ColumnName = "EcsOldItem", ColumnDescription = "旧物料 ", Length = 20)]
        public string EcsOldItem { get; set; }

        /// <summary>
        /// 旧文本
        /// </summary>
        [SugarColumn(ColumnName = "EcsOldItemText", ColumnDescription = "旧文本 ", Length = 40)]
        public string EcsOldItemText { get; set; }

        /// <summary>
        /// 旧品库存
        /// </summary>
        [SugarColumn(ColumnName = "EcsOldCurrStock", ColumnDescription = "旧品库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal EcsOldCurrStock { get; set; }

        /// <summary>
        /// 用量
        /// </summary>
        [SugarColumn(ColumnName = "EcsOldUsageQty", ColumnDescription = "用量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal EcsOldUsageQty { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [SugarColumn(ColumnName = "EcsOldSetLoc", ColumnDescription = "位置 ", Length = 20)]
        public string EcsOldSetLoc { get; set; }

        /// <summary>
        /// 新物料
        /// </summary>
        [SugarColumn(ColumnName = "EcsNewItem", ColumnDescription = "新物料 ", Length = 20)]
        public string EcsNewItem { get; set; }

        /// <summary>
        /// 新文本
        /// </summary>
        [SugarColumn(ColumnName = "EcsNewItemText", ColumnDescription = "新文本 ", Length = 40)]
        public string EcsNewItemText { get; set; }

        /// <summary>
        /// 新品库存
        /// </summary>
        [SugarColumn(ColumnName = "EcsNewCurrStock", ColumnDescription = "新品库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal EcsNewCurrStock { get; set; }

        /// <summary>
        /// 用量
        /// </summary>
        [SugarColumn(ColumnName = "EcsNewUsageQty", ColumnDescription = "用量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal EcsNewUsageQty { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [SugarColumn(ColumnName = "EcsNewSetLoc", ColumnDescription = "位置 ", Length = 20)]
        public string EcsNewSetLoc { get; set; }

        /// <summary>
        /// bom番号
        /// </summary>
        [SugarColumn(ColumnName = "EcsBomNo", ColumnDescription = "bom番号 ", Length = 4)]
        public string EcsBomNo { get; set; }

        /// <summary>
        /// 互换
        /// </summary>
        [SugarColumn(ColumnName = "EcsChange", ColumnDescription = "互换 ", Length = 4)]
        public string EcsChange { get; set; }

        /// <summary>
        /// 区分
        /// </summary>
        [SugarColumn(ColumnName = "EcsDistLocal", ColumnDescription = "区分 ", Length = 4)]
        public string EcsDistLocal { get; set; }

        /// <summary>
        /// 指示
        /// </summary>
        [SugarColumn(ColumnName = "EcsInstNote", ColumnDescription = "指示 ", Length = 4)]
        public string EcsInstNote { get; set; }

        /// <summary>
        /// 旧品处理
        /// </summary>
        [SugarColumn(ColumnName = "EcsOldProcess", ColumnDescription = "旧品处理 ", Length = 4)]
        public string EcsOldProcess { get; set; }

        /// <summary>
        /// bom日期
        /// </summary>
        public DateTime? EcsBomDate { get; set; }

        /// <summary>
        /// 采购类型
        /// </summary>
        [SugarColumn(ColumnName = "EcsPurType", ColumnDescription = "采购类型 ", Length = 1)]
        public string EcsPurType { get; set; }

        /// <summary>
        /// 采购组
        /// </summary>
        [SugarColumn(ColumnName = "EcsPurGroup", ColumnDescription = "采购组 ", Length = 20)]
        public string EcsPurGroup { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        [SugarColumn(ColumnName = "EcsSloc", ColumnDescription = "仓库 ", Length = 4)]
        public string EcsSloc { get; set; }

        /// <summary>
        /// 检验否
        /// </summary>
        [SugarColumn(ColumnName = "EcsInsmk", ColumnDescription = "检验否 ", Length = 1)]
        public string EcsInsmk { get; set; }

        /// <summary>
        /// 工厂状态
        /// </summary>
        [SugarColumn(ColumnName = "EcsPlntStated", ColumnDescription = "工厂状态 ", Length = 4)]
        public string EcsPlntStated { get; set; }

        /// <summary>
        /// SOP
        /// </summary>
        [SugarColumn(ColumnName = "EcsSopStated", ColumnDescription = "SOP ", DefaultValue = "0")]
        public int EcsSopStated { get; set; }

        /// <summary>
        /// 实施标记
        /// </summary>
        [SugarColumn(ColumnName = "EcsImplStated", ColumnDescription = "实施标记 ", DefaultValue = "0")]
        public int EcsImplStated { get; set; }

        /// <summary>
        /// 采购登入日期
        /// </summary>
        public DateTime? EcsPurEnteredDate { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        [SugarColumn(ColumnName = "EcsPurSupplier", ColumnDescription = "供应商 ", Length = 20)]
        public string EcsPurSupplier { get; set; }

        /// <summary>
        /// 采购PO
        /// </summary>
        [SugarColumn(ColumnName = "EcsPurOrder", ColumnDescription = "采购PO ", Length = 20)]
        public string EcsPurOrder { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "EcsPurNote", ColumnDescription = "说明 ", Length = 255)]
        public string EcsPurNote { get; set; }

        /// <summary>
        /// 生管登入日期
        /// </summary>
        public DateTime? EcsPmcEnteredDate { get; set; }

        /// <summary>
        /// 预投入批次
        /// </summary>
        [SugarColumn(ColumnName = "EcsPmcPreLot", ColumnDescription = "预投入批次 ", Length = 255)]
        public string EcsPmcPreLot { get; set; }

        /// <summary>
        /// 旧品处理
        /// </summary>
        [SugarColumn(ColumnName = "EcsPmcDisposal", ColumnDescription = "旧品处理 ", Length = 255)]
        public string EcsPmcDisposal { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "EcsPmcNote", ColumnDescription = "备注 ", Length = 255)]
        public string EcsPmcNote { get; set; }

        /// <summary>
        /// IQC登入日期
        /// </summary>
        public DateTime? EcsIqcEnteredDate { get; set; }

        /// <summary>
        /// 检验订单
        /// </summary>
        [SugarColumn(ColumnName = "EcsIqcOrder", ColumnDescription = "检验订单 ", Length = 20)]
        public string EcsIqcOrder { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "EcsIqcNote", ColumnDescription = "说明 ", Length = 255)]
        public string EcsIqcNote { get; set; }

        /// <summary>
        /// 部管登入日期
        /// </summary>
        public DateTime? EcsMmEnteredDate { get; set; }

        /// <summary>
        /// 领用批次
        /// </summary>
        [SugarColumn(ColumnName = "EcsMmLot", ColumnDescription = "领用批次 ", Length = 255)]
        public string EcsMmLot { get; set; }

        /// <summary>
        /// 工单
        /// </summary>
        [SugarColumn(ColumnName = "EcsMmProOrder", ColumnDescription = "工单 ", Length = 200)]
        public string EcsMmProOrder { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "EcsMmNote", ColumnDescription = "说明 ", Length = 255)]
        public string EcsMmNote { get; set; }

        /// <summary>
        /// 制一登入日期
        /// </summary>
        public DateTime? EcsAssyEnteredDate { get; set; }

        /// <summary>
        /// 班组
        /// </summary>
        [SugarColumn(ColumnName = "EcsAssyLine", ColumnDescription = "班组 ", Length = 20)]
        public string EcsAssyLine { get; set; }

        /// <summary>
        /// 生产批次
        /// </summary>
        [SugarColumn(ColumnName = "EcsAssyPutLot", ColumnDescription = "生产批次 ", Length = 255)]
        public string EcsAssyPutLot { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "EcsAssyNote", ColumnDescription = "说明 ", Length = 255)]
        public string EcsAssyNote { get; set; }

        /// <summary>
        /// 制二登入日期
        /// </summary>
        public DateTime? EcsPcbaEnteredDate { get; set; }

        /// <summary>
        /// Pcba班组
        /// </summary>
        [SugarColumn(ColumnName = "EcsPcbaLine", ColumnDescription = "Pcba班组 ", Length = 20)]
        public string EcsPcbaLine { get; set; }

        /// <summary>
        /// Pcba批次
        /// </summary>
        [SugarColumn(ColumnName = "EcsPcbaPutLot", ColumnDescription = "Pcba批次 ", Length = 255)]
        public string EcsPcbaPutLot { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "EcsPcbaNote", ColumnDescription = "说明 ", Length = 255)]
        public string EcsPcbaNote { get; set; }

        /// <summary>
        /// QA确认日期
        /// </summary>
        public DateTime? EcsFqcEnteredDate { get; set; }

        /// <summary>
        /// 检验批次
        /// </summary>
        [SugarColumn(ColumnName = "EcsFqcImplLot", ColumnDescription = "检验批次 ", Length = 255)]
        public string EcsFqcImplLot { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "EcsFqcNote", ColumnDescription = "说明 ", Length = 255)]
        public string EcsFqcNote { get; set; }
    }
}