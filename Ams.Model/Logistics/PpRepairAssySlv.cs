namespace Ams.Model.Logistics
{
    /// <summary>
    /// 组立不良slv
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 11:58:58
    /// </summary>
    [SugarTable("pp_repair_assy_slv", "组立不良slv")]
    public class PpRepairAssySlv : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long PpdSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PpdParentSfId { get; set; }

        /// <summary>
        /// 不良类别
        /// </summary>
        [SugarColumn(ColumnName = "PpdBadType", ColumnDescription = "不良类别 ", Length = 20)]
        public string PpdBadType { get; set; }

        /// <summary>
        /// 不良数量
        /// </summary>
        [SugarColumn(ColumnName = "PpdBadQty", ColumnDescription = "不良数量 ", DefaultValue = "0")]
        public int PpdBadQty { get; set; }

        /// <summary>
        /// 不良总数
        /// </summary>
        [SugarColumn(ColumnName = "PpdBadTotal", ColumnDescription = "不良总数 ", DefaultValue = "0")]
        public int PpdBadTotal { get; set; }

        /// <summary>
        /// 不良状况
        /// </summary>
        [SugarColumn(ColumnName = "PpdBadSymptom", ColumnDescription = "不良状况 ", Length = 200)]
        public string PpdBadSymptom { get; set; }

        /// <summary>
        /// 不良个所
        /// </summary>
        [SugarColumn(ColumnName = "PpdBadPosition", ColumnDescription = "不良个所 ", Length = 200)]
        public string PpdBadPosition { get; set; }

        /// <summary>
        /// 不良原因
        /// </summary>
        [SugarColumn(ColumnName = "PpdBadReason", ColumnDescription = "不良原因 ", Length = 200)]
        public string PpdBadReason { get; set; }
    }
}