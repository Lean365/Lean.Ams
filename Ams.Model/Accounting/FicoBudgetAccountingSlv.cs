
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 预算科目
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 8:38:32
    /// </summary>
    [SugarTable("fico_budget_accounting_slv","预算科目")]
    public class FicoBudgetAccountingSlv
    {
        /// <summary>
        /// ID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbasSfid { get; set; }

        /// <summary>
        /// 父ID 
        /// </summary>
        [SugarColumn(ColumnName="FbasParentSfid", ColumnDescription = "父ID ",Length = 10)]
        public string FbasParentSfid { get; set; }

        /// <summary>
        /// 语言Key 
        /// </summary>
        [SugarColumn(ColumnName="FbasSpras", ColumnDescription = "语言Key ",Length = 255)]
        public string FbasSpras { get; set; }

        /// <summary>
        /// 明细科目 
        /// </summary>
        [SugarColumn(ColumnName="FbasFdpls", ColumnDescription = "明细科目 ",Length = 20)]
        public string FbasFdpls { get; set; }

        /// <summary>
        /// 名称 
        /// </summary>
        [SugarColumn(ColumnName="FbasSatext", ColumnDescription = "名称 ",Length = 40)]
        public string FbasSatext { get; set; }

        /// <summary>
        /// 长文本 
        /// </summary>
        [SugarColumn(ColumnName="FbasLtext", ColumnDescription = "长文本 ",Length = 80)]
        public string FbasLtext { get; set; }

        /// <summary>
        /// 附加文本 
        /// </summary>
        [SugarColumn(ColumnName="FbasStext", ColumnDescription = "附加文本 ",Length = 100)]
        public string FbasStext { get; set; }

        /// <summary>
        /// 费用类型 
        /// </summary>
        [SugarColumn(ColumnName="FbasGvtyp", ColumnDescription = "费用类型 ",Length = 4)]
        public string FbasGvtyp { get; set; }

        /// <summary>
        /// 冻结 
        /// </summary>
        [SugarColumn(ColumnName="FbasXspea", ColumnDescription = "冻结 ",DefaultValue = "0")]
        public int? FbasXspea { get; set; }

        /// <summary>
        /// 统驭科目 
        /// </summary>
        [SugarColumn(ColumnName="FbasMitkz", ColumnDescription = "统驭科目 ",Length = 2)]
        public string FbasMitkz { get; set; }

        /// <summary>
        /// 币种 
        /// </summary>
        [SugarColumn(ColumnName="FbasWaers", ColumnDescription = "币种 ",DefaultValue = "0")]
        public int? FbasWaers { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        [SugarColumn(ColumnName="IsDeleted", ColumnDescription = "软删除 ",DefaultValue = "0")]
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 说明 
        /// </summary>
        [SugarColumn(ColumnName="Remark", ColumnDescription = "说明 ",Length = 255)]
        public string Remark { get; set; }

        /// <summary>
        /// 创建者 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新者 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 更新时间 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }

    }
}