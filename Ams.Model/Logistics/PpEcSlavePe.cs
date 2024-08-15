namespace Ams.Model.Logistics
{
    /// <summary>
    /// Pe设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:39:48
    /// </summary>
    [SugarTable("pp_ec_slave_pe", "Pe设变")]
    public class PpEcSlavePe : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>

        [SugarColumn(IsPrimaryKey = false, IsIdentity = false)]
        public long? PeSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? PeParentSfId { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        [SugarColumn(ColumnName = "PeEcNo", ColumnDescription = "设变No. ", Length = 20)]
        public string PeEcNo { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "PeModel", ColumnDescription = "机种 ", Length = 200)]
        public string PeModel { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "PeItem", ColumnDescription = "物料 ", Length = 20)]
        public string PeItem { get; set; }

        /// <summary>
        /// 子物料
        /// </summary>
        [SugarColumn(ColumnName = "PeSubItem", ColumnDescription = "子物料 ", Length = 20)]
        public string PeSubItem { get; set; }

        /// <summary>
        /// SOP
        /// </summary>
        [SugarColumn(ColumnName = "PeSopStated", ColumnDescription = "SOP ", DefaultValue = "0")]
        public int PeSopStated { get; set; }

        /// <summary>
        /// 实施标记
        /// </summary>
        [SugarColumn(ColumnName = "PeImplStated", ColumnDescription = "实施标记 ", DefaultValue = "0")]
        public int PeImplStated { get; set; }

        /// <summary>
        /// SOP确认日期
        /// </summary>
        public DateTime? PeEnteredDate { get; set; }

        /// <summary>
        /// SOP部门
        /// </summary>
        [SugarColumn(ColumnName = "PeDeptSop", ColumnDescription = "SOP部门 ", DefaultValue = "0")]
        public int PeDeptSop { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "PeNote", ColumnDescription = "说明 ", Length = 255)]
        public string PeNote { get; set; }
    }
}