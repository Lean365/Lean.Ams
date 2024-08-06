namespace Ams.Model.Logistics
{
    /// <summary>
    /// 组立
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:43:00
    /// </summary>
    [SugarTable("pp_ec_slave_assy", "组立")]
    public class PpEcSlaveAssy : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>

        [SugarColumn(IsPrimaryKey = false, IsIdentity = false)]
        public long? AssySfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? AssyParentSfId { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        [SugarColumn(ColumnName = "AssyEcNo", ColumnDescription = "设变No. ", Length = 20)]
        public string AssyEcNo { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "AssyModel", ColumnDescription = "机种 ", Length = 200)]
        public string AssyModel { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "AssyItem", ColumnDescription = "物料 ", Length = 20)]
        public string AssyItem { get; set; }

        /// <summary>
        /// 实施标记
        /// </summary>
        [SugarColumn(ColumnName = "AssyImplStated", ColumnDescription = "实施标记 ", DefaultValue = "0")]
        public int? AssyImplStated { get; set; }

        /// <summary>
        /// 制一登入日期
        /// </summary>
        public DateTime? AssyEnteredDate { get; set; }

        /// <summary>
        /// 班组
        /// </summary>
        [SugarColumn(ColumnName = "AssyLine", ColumnDescription = "班组 ", Length = 20)]
        public string AssyLine { get; set; }

        /// <summary>
        /// 生产批次
        /// </summary>
        [SugarColumn(ColumnName = "AssyPutLot", ColumnDescription = "生产批次 ", Length = 255)]
        public string AssyPutLot { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "AssyNote", ColumnDescription = "说明 ", Length = 255)]
        public string AssyNote { get; set; }
    }
}