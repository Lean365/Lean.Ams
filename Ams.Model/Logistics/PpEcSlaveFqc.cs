namespace Ams.Model.Logistics
{
    /// <summary>
    /// 品管
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:42:29
    /// </summary>
    [SugarTable("pp_ec_slave_fqc", "品管")]
    public class PpEcSlaveFqc : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>

        [SugarColumn(IsPrimaryKey = false, IsIdentity = false)]
        public long? FqcSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? FqcParentSfId { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        [SugarColumn(ColumnName = "FqcEcNo", ColumnDescription = "设变No. ", Length = 20)]
        public string FqcEcNo { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "FqcModel", ColumnDescription = "机种 ", Length = 200)]
        public string FqcModel { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "FqcItem", ColumnDescription = "物料 ", Length = 20)]
        public string FqcItem { get; set; }

        /// <summary>
        /// 实施标记
        /// </summary>
        [SugarColumn(ColumnName = "FqcImplStated", ColumnDescription = "实施标记 ", DefaultValue = "0")]
        public int FqcImplStated { get; set; }

        /// <summary>
        /// QA确认日期
        /// </summary>
        public DateTime? FqcEnteredDate { get; set; }

        /// <summary>
        /// 投入批次
        /// </summary>
        [SugarColumn(ColumnName = "FqcImplLot", ColumnDescription = "投入批次 ", Length = 255)]
        public string FqcImplLot { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "FqcNote", ColumnDescription = "说明 ", Length = 255)]
        public string FqcNote { get; set; }
    }
}