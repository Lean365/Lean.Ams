namespace Ams.Model.Accounting
{
    /// <summary>
    /// 明细科目
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 17:37:35
    /// </summary>
    [SugarTable("fico_budget_accounting_slv", "明细科目")]
    public class FicoBudgetAccountingSlv : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbasSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public long FbasParentSfId { get; set; }

        /// <summary>
        /// 翻译Key
        /// </summary>
        [SugarColumn(ColumnName = "FbasSpras", ColumnDescription = "翻译Key   ", Length = 255)]
        public string FbasSpras { get; set; }

        /// <summary>
        /// 明细科目
        /// </summary>
        [SugarColumn(ColumnName = "FbasFdpls", ColumnDescription = "明细科目   ", Length = 20)]
        public string FbasFdpls { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "FbasStext", ColumnDescription = "名称   ", Length = 40)]
        public string FbasStext { get; set; }

        /// <summary>
        /// 长文本
        /// </summary>
        [SugarColumn(ColumnName = "FbasLtext", ColumnDescription = "长文本   ", Length = 80)]
        public string FbasLtext { get; set; }

        /// <summary>
        /// 附加文本
        /// </summary>
        [SugarColumn(ColumnName = "FbasAtext", ColumnDescription = "附加文本   ", Length = 120)]
        public string FbasAtext { get; set; }

        /// <summary>
        /// 冻结
        /// </summary>
        [SugarColumn(ColumnName = "FbasXspea", ColumnDescription = "冻结   ", DefaultValue = "0")]
        public int? FbasXspea { get; set; }
    }
}