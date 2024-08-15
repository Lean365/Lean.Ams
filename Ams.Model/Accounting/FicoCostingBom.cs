namespace Ams.Model.Accounting
{
    /// <summary>
    /// bom核算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:34:34
    /// </summary>
    [SugarTable("fico_costing_bom", "bom核算")]
    public class FicoCostingBom : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long BcSfId { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "BcWerks", ColumnDescription = "工厂", Length = 4)]
        public string BcWerks { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "BcLfgja", ColumnDescription = "期间", Length = 6)]
        public string BcLfgja { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "BcLfmon", ColumnDescription = "年月", Length = 6)]
        public string BcLfmon { get; set; }

        /// <summary>
        /// 机种名称
        /// </summary>
        [SugarColumn(ColumnName = "BcPrdha", ColumnDescription = "机种名称", Length = 40)]
        public string BcPrdha { get; set; }

        /// <summary>
        /// 成品物料
        /// </summary>
        [SugarColumn(ColumnName = "BcMatnr", ColumnDescription = "成品物料", Length = 20)]
        public string BcMatnr { get; set; }

        /// <summary>
        /// 物料文本
        /// </summary>
        [SugarColumn(ColumnName = "BcMaktx", ColumnDescription = "物料文本", Length = 40)]
        public string BcMaktx { get; set; }

        /// <summary>
        /// 成本
        /// </summary>
        [SugarColumn(ColumnName = "Bckost", ColumnDescription = "成本", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Bckost { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "BcWaers", ColumnDescription = "币种", Length = 3)]
        public string BcWaers { get; set; }

        /// <summary>
        /// 核算日期
        /// </summary>
        public DateTime? BcZkdat { get; set; }
    }
}