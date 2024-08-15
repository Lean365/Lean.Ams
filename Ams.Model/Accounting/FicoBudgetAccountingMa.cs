namespace Ams.Model.Accounting
{
    /// <summary>
    /// 预算科目
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/7 8:08:11
    /// </summary>
    [SugarTable("fico_budget_accounting_ma", "预算科目")]
    public class FicoBudgetAccountingMa : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbasSfId { get; set; }

        /// <summary>
        /// 集团
        /// </summary>
        [SugarColumn(ColumnName = "FbasMandt", ColumnDescription = "集团   ", Length = 10)]
        public string FbasMandt { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        [SugarColumn(ColumnName = "FbasBukrs", ColumnDescription = "公司代码   ", Length = 8)]
        public string FbasBukrs { get; set; }

        /// <summary>
        /// 翻译Key
        /// </summary>
        [SugarColumn(ColumnName = "FbasSpras", ColumnDescription = "翻译Key   ", Length = 255)]
        public string FbasSpras { get; set; }

        /// <summary>
        /// 预算科目
        /// </summary>
        [SugarColumn(ColumnName = "FbasFipls", ColumnDescription = "预算科目   ", Length = 20)]
        public string FbasFipls { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "FbasWaers", ColumnDescription = "币种   ", Length = 3)]
        public string FbasWaers { get; set; }

        /// <summary>
        /// 会计科目
        /// </summary>
        [SugarColumn(ColumnName = "FbasSaknr", ColumnDescription = "会计科目   ", Length = 10)]
        public string FbasSaknr { get; set; }

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
        /// 费用类型
        /// </summary>
        [SugarColumn(ColumnName = "FbasGvtyp", ColumnDescription = "费用类型   ", Length = 4)]
        public string FbasGvtyp { get; set; }

        /// <summary>
        /// 统驭科目
        /// </summary>
        [SugarColumn(ColumnName = "FbasMitkz", ColumnDescription = "统驭科目   ", Length = 2)]
        public string FbasMitkz { get; set; }

        /// <summary>
        /// 冻结
        /// </summary>
        [SugarColumn(ColumnName = "FbasXspea", ColumnDescription = "冻结   ", DefaultValue = "0")]
        public int? FbasXspea { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(FicoBudgetAccountingSlv.FbasParentSfId), nameof(FbasSfId))] //自定义关系映射
        public List<FicoBudgetAccountingSlv> FicoBudgetAccountingSlvNav { get; set; }
    }
}