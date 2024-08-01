namespace Ams.Model.Logistics
{
    /// <summary>
    /// Pmc设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:45:42
    /// </summary>
    [SugarTable("pp_ec_slave_pmc", "Pmc设变")]
    public class PpEcSlavePmc : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? PmcSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? PmcParentSfId { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        [SugarColumn(ColumnName = "PmcEcNo", ColumnDescription = "设变No.  ", Length = 20)]
        public string PmcEcNo { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "PmcModel", ColumnDescription = "机种  ", Length = 200)]
        public string PmcModel { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "PmcItem", ColumnDescription = "物料  ", Length = 20)]
        public string PmcItem { get; set; }

        /// <summary>
        /// 实施标记
        /// </summary>
        [SugarColumn(ColumnName = "PmcImplStated", ColumnDescription = "实施标记  ", DefaultValue = "0")]
        public int PmcImplStated { get; set; }

        /// <summary>
        /// 输入日期
        /// </summary>
        public DateTime? PmcEnteredDate { get; set; }

        /// <summary>
        /// 预投批次
        /// </summary>
        [SugarColumn(ColumnName = "PmcPreLot", ColumnDescription = "预投批次  ", Length = 255)]
        public string PmcPreLot { get; set; }

        /// <summary>
        /// 旧品处理
        /// </summary>
        [SugarColumn(ColumnName = "PmcDisposal", ColumnDescription = "旧品处理  ", DefaultValue = "0")]
        public int? PmcDisposal { get; set; }

        /// <summary>
        /// 记事
        /// </summary>
        [SugarColumn(ColumnName = "PmcNote", ColumnDescription = "记事  ", Length = 255)]
        public string PmcNote { get; set; }
    }
}