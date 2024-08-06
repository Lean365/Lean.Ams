namespace Ams.Model.Logistics
{
    /// <summary>
    /// Te设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:39:03
    /// </summary>
    [SugarTable("pp_ec_slave_te", "Te设变")]
    public class PpEcSlaveTe : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>

        [SugarColumn(IsPrimaryKey = false, IsIdentity = false)]
        public long? TeSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? TeParentSfId { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        [SugarColumn(ColumnName = "TeEcNo", ColumnDescription = "设变No. ", Length = 20)]
        public string TeEcNo { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "TeModel", ColumnDescription = "机种 ", Length = 200)]
        public string TeModel { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "TeItem", ColumnDescription = "物料 ", Length = 20)]
        public string TeItem { get; set; }

        /// <summary>
        /// 子物料
        /// </summary>
        [SugarColumn(ColumnName = "TeSubItem", ColumnDescription = "子物料 ", Length = 20)]
        public string TeSubItem { get; set; }

        /// <summary>
        /// 旧物料
        /// </summary>
        [SugarColumn(ColumnName = "TeOldItem", ColumnDescription = "旧物料 ", Length = 20)]
        public string TeOldItem { get; set; }

        /// <summary>
        /// 旧文本
        /// </summary>
        [SugarColumn(ColumnName = "TeOldItemText", ColumnDescription = "旧文本 ", Length = 40)]
        public string TeOldItemText { get; set; }

        /// <summary>
        /// 旧品库存
        /// </summary>
        [SugarColumn(ColumnName = "TeOldCurrStock", ColumnDescription = "旧品库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal TeOldCurrStock { get; set; }

        /// <summary>
        /// 用量
        /// </summary>
        [SugarColumn(ColumnName = "TeOldUsageQty", ColumnDescription = "用量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal TeOldUsageQty { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [SugarColumn(ColumnName = "TeOldSetLoc", ColumnDescription = "位置 ", Length = 20)]
        public string TeOldSetLoc { get; set; }

        /// <summary>
        /// 新物料
        /// </summary>
        [SugarColumn(ColumnName = "TeNewItem", ColumnDescription = "新物料 ", Length = 20)]
        public string TeNewItem { get; set; }

        /// <summary>
        /// 新文本
        /// </summary>
        [SugarColumn(ColumnName = "TeNewItemText", ColumnDescription = "新文本 ", Length = 40)]
        public string TeNewItemText { get; set; }

        /// <summary>
        /// 新品库存
        /// </summary>
        [SugarColumn(ColumnName = "TeNewCurrStock", ColumnDescription = "新品库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal TeNewCurrStock { get; set; }

        /// <summary>
        /// 用量
        /// </summary>
        [SugarColumn(ColumnName = "TeNewUsageQty", ColumnDescription = "用量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal TeNewUsageQty { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [SugarColumn(ColumnName = "TeNewSetLoc", ColumnDescription = "位置 ", Length = 20)]
        public string TeNewSetLoc { get; set; }

        /// <summary>
        /// bom番号
        /// </summary>
        [SugarColumn(ColumnName = "TeBomNo", ColumnDescription = "bom番号 ", Length = 4)]
        public string TeBomNo { get; set; }

        /// <summary>
        /// 互换
        /// </summary>
        [SugarColumn(ColumnName = "TeChange", ColumnDescription = "互换 ", Length = 4)]
        public string TeChange { get; set; }

        /// <summary>
        /// 区分
        /// </summary>
        [SugarColumn(ColumnName = "TeDistLocal", ColumnDescription = "区分 ", Length = 4)]
        public string TeDistLocal { get; set; }

        /// <summary>
        /// 指示
        /// </summary>
        [SugarColumn(ColumnName = "TeInstNote", ColumnDescription = "指示 ", Length = 4)]
        public string TeInstNote { get; set; }

        /// <summary>
        /// 旧品处理
        /// </summary>
        [SugarColumn(ColumnName = "TeOldProcess", ColumnDescription = "旧品处理 ", Length = 4)]
        public string TeOldProcess { get; set; }

        /// <summary>
        /// bom日期
        /// </summary>
        public DateTime? TeBomDate { get; set; }

        /// <summary>
        /// 采购类型
        /// </summary>
        [SugarColumn(ColumnName = "TePurType", ColumnDescription = "采购类型 ", Length = 1)]
        public string TePurType { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        [SugarColumn(ColumnName = "TeSloc", ColumnDescription = "仓库 ", Length = 4)]
        public string TeSloc { get; set; }

        /// <summary>
        /// 检验否
        /// </summary>
        [SugarColumn(ColumnName = "TeInsmk", ColumnDescription = "检验否 ", Length = 1)]
        public string TeInsmk { get; set; }

        /// <summary>
        /// 工厂状态
        /// </summary>
        [SugarColumn(ColumnName = "TePlntStated", ColumnDescription = "工厂状态 ", Length = 4)]
        public string TePlntStated { get; set; }

        /// <summary>
        /// SOP
        /// </summary>
        [SugarColumn(ColumnName = "TeSopStated", ColumnDescription = "SOP ", DefaultValue = "0")]
        public int TeSopStated { get; set; }

        /// <summary>
        /// 实施标记
        /// </summary>
        [SugarColumn(ColumnName = "TeImplStated", ColumnDescription = "实施标记 ", DefaultValue = "0")]
        public int TeImplStated { get; set; }
    }
}