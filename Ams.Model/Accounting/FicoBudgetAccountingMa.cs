namespace Ams.Model.Accounting
{
    /// <summary>
    /// 预算科目
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 8:42:51
    /// </summary>
    [SugarTable("fico_budget_accounting_ma", "预算科目")]
    public class FicoBudgetAccountingMa : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbamSfId { get; set; }

        /// <summary>
        /// 集团
        /// </summary>
        [SugarColumn(ColumnName = "FbamMandt", ColumnDescription = "集团 ", Length = 10)]
        public string FbamMandt { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        [SugarColumn(ColumnName = "FbamBukrs", ColumnDescription = "公司代码 ", Length = 8)]
        public string FbamBukrs { get; set; }

        /// <summary>
        /// 语言Key
        /// </summary>
        [SugarColumn(ColumnName = "FbamSpras", ColumnDescription = "语言Key ", Length = 255)]
        public string FbamSpras { get; set; }

        /// <summary>
        /// 预算科目
        /// </summary>
        [SugarColumn(ColumnName = "FbamFipls", ColumnDescription = "预算科目 ", Length = 20)]
        public string FbamFipls { get; set; }

        /// <summary>
        /// 会计科目
        /// </summary>
        [SugarColumn(ColumnName = "FbamSaknr", ColumnDescription = "会计科目 ", Length = 10)]
        public string FbamSaknr { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "FbamSatext", ColumnDescription = "名称 ", Length = 40)]
        public string FbamSatext { get; set; }

        /// <summary>
        /// 长文本
        /// </summary>
        [SugarColumn(ColumnName = "FbamLtext", ColumnDescription = "长文本 ", Length = 80)]
        public string FbamLtext { get; set; }

        /// <summary>
        /// 附加文本
        /// </summary>
        [SugarColumn(ColumnName = "FbamStext", ColumnDescription = "附加文本 ", Length = 100)]
        public string FbamStext { get; set; }

        /// <summary>
        /// 费用类型
        /// </summary>
        [SugarColumn(ColumnName = "FbamGvtyp", ColumnDescription = "费用类型 ", Length = 4)]
        public string FbamGvtyp { get; set; }

        /// <summary>
        /// 冻结
        /// </summary>
        [SugarColumn(ColumnName = "FbamXspea", ColumnDescription = "冻结 ", DefaultValue = "0")]
        public int? FbamXspea { get; set; }

        /// <summary>
        /// 统驭科目
        /// </summary>
        [SugarColumn(ColumnName = "FbamMitkz", ColumnDescription = "统驭科目 ", Length = 2)]
        public string FbamMitkz { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "FbamWaers", ColumnDescription = "币种 ", DefaultValue = "0")]
        public int? FbamWaers { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(FicoBudgetAccountingSlv.FbasParentSfId), nameof(FbamSfId))] //自定义关系映射
        public List<FicoBudgetAccountingSlv> FicoBudgetAccountingSlvNav { get; set; }
    }
}