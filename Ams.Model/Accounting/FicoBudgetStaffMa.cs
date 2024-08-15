namespace Ams.Model.Accounting
{
    /// <summary>
    /// 人员预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:30:08
    /// </summary>
    [SugarTable("fico_budget_staff_ma", "人员预算")]
    public class FicoBudgetStaffMa : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbsSfId { get; set; }

        /// <summary>
        /// 财年
        /// </summary>
        [SugarColumn(ColumnName = "FbsFy", ColumnDescription = "财年", Length = 6)]
        public string FbsFy { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "FbsCorp", ColumnDescription = "公司", Length = 4)]
        public string FbsCorp { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "FbsDept", ColumnDescription = "部门", Length = 20)]
        public string FbsDept { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(FicoBudgetStaffSlv.FbssParentSfId), nameof(FbsSfId))] //自定义关系映射
        public List<FicoBudgetStaffSlv> FicoBudgetStaffSlvNav { get; set; }
    }
}