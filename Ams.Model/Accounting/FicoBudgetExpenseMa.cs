namespace Ams.Model.Accounting
{
    /// <summary>
    /// 费用预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:31:03
    /// </summary>
    [SugarTable("fico_budget_expense_ma", "费用预算")]
    public class FicoBudgetExpenseMa : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbeSfId { get; set; }

        /// <summary>
        /// 财年
        /// </summary>
        [SugarColumn(ColumnName = "FbeFy", ColumnDescription = "财年", Length = 6)]
        public string FbeFy { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "FbeCorp", ColumnDescription = "公司", Length = 4)]
        public string FbeCorp { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "FbeDept", ColumnDescription = "部门", Length = 20)]
        public string FbeDept { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(FicoBudgetExpenseSlv.FbesParentSfId), nameof(FbeSfId))] //自定义关系映射
        public List<FicoBudgetExpenseSlv> FicoBudgetExpenseSlvNav { get; set; }
    }
}