namespace Ams.Model.Logistics
{
    /// <summary>
    /// Mm设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:41:14
    /// </summary>
    [SugarTable("pp_ec_slave_mm", "Mm设变")]
    public class PpEcSlaveMm : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>

        [SugarColumn(IsPrimaryKey = false, IsIdentity = false)]
        public long? MmSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? MmParentSfId { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        [SugarColumn(ColumnName = "MmEcNo", ColumnDescription = "设变No. ", Length = 20)]
        public string MmEcNo { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "MmModel", ColumnDescription = "机种 ", Length = 200)]
        public string MmModel { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "MmItem", ColumnDescription = "物料 ", Length = 20)]
        public string MmItem { get; set; }

        /// <summary>
        /// 实施标记
        /// </summary>
        [SugarColumn(ColumnName = "MmImplStated", ColumnDescription = "实施标记 ", DefaultValue = "0")]
        public int MmImplStated { get; set; }

        /// <summary>
        /// 部管登入日期
        /// </summary>
        public DateTime? MmEnteredDate { get; set; }

        /// <summary>
        /// 领用批次
        /// </summary>
        [SugarColumn(ColumnName = "MmLot", ColumnDescription = "领用批次 ", Length = 255)]
        public string MmLot { get; set; }

        /// <summary>
        /// 工单
        /// </summary>
        [SugarColumn(ColumnName = "MmProOrder", ColumnDescription = "工单 ", Length = 200)]
        public string MmProOrder { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "MmNote", ColumnDescription = "说明 ", Length = 255)]
        public string MmNote { get; set; }
    }
}