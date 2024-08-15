namespace Ams.Model.Accounting
{
    /// <summary>
    /// 加班预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:25:44
    /// </summary>
    [SugarTable("fico_budget_overtime_ma", "加班预算")]
    public class FicoBudgetOvertimeMa : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FboSfId { get; set; }

        /// <summary>
        /// 财年
        /// </summary>
        [SugarColumn(ColumnName = "FboFy", ColumnDescription = "财年", Length = 6)]
        public string FboFy { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "FboCorp", ColumnDescription = "公司", Length = 4)]
        public string FboCorp { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "FboDept", ColumnDescription = "部门", Length = 20)]
        public string FboDept { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(FicoBudgetOvertimeSlv.FbosParentSfId), nameof(FboSfId))] //自定义关系映射
        public List<FicoBudgetOvertimeSlv> FicoBudgetOvertimeSlvNav { get; set; }
    }
}