namespace Ams.Model.Logistics
{
    /// <summary>
    /// Pcba设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:40:40
    /// </summary>
    [SugarTable("pp_ec_slave_pcba", "Pcba设变")]
    public class PpEcSlavePcba : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>

        [SugarColumn(IsPrimaryKey = false, IsIdentity = false)]
        public long? PcbaSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? PcbaParentSfId { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        [SugarColumn(ColumnName = "PcbaEcNo", ColumnDescription = "设变No. ", Length = 20)]
        public string PcbaEcNo { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "PcbaModel", ColumnDescription = "机种 ", Length = 200)]
        public string PcbaModel { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "PcbaItem", ColumnDescription = "物料 ", Length = 20)]
        public string PcbaItem { get; set; }

        /// <summary>
        /// 实施标记
        /// </summary>
        [SugarColumn(ColumnName = "PcbaImplStated", ColumnDescription = "实施标记 ", DefaultValue = "0")]
        public int PcbaImplStated { get; set; }

        /// <summary>
        /// 制二登入日期
        /// </summary>
        public DateTime? PcbaEnteredDate { get; set; }

        /// <summary>
        /// Pcba班组
        /// </summary>
        [SugarColumn(ColumnName = "PcbaLine", ColumnDescription = "Pcba班组 ", Length = 20)]
        public string PcbaLine { get; set; }

        /// <summary>
        /// Pcba批次
        /// </summary>
        [SugarColumn(ColumnName = "PcbaPutLot", ColumnDescription = "Pcba批次 ", Length = 255)]
        public string PcbaPutLot { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "PcbaNote", ColumnDescription = "说明 ", Length = 255)]
        public string PcbaNote { get; set; }
    }
}