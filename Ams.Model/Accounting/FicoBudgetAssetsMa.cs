namespace Ams.Model.Accounting
{
    /// <summary>
    /// 资产预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:25:02
    /// </summary>
    [SugarTable("fico_budget_assets_ma", "资产预算")]
    public class FicoBudgetAssetsMa : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbaSfId { get; set; }

        /// <summary>
        /// 财年
        /// </summary>
        [SugarColumn(ColumnName = "FbaFy", ColumnDescription = "财年", Length = 6)]
        public string FbaFy { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "FbaCorp", ColumnDescription = "公司", Length = 4)]
        public string FbaCorp { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "FbaDept", ColumnDescription = "部门", Length = 20)]
        public string FbaDept { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(FicoBudgetAssetsSlv.FbasParentSfId), nameof(FbaSfId))] //自定义关系映射
        public List<FicoBudgetAssetsSlv> FicoBudgetAssetsSlvNav { get; set; }
    }
}