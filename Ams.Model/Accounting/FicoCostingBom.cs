
namespace Ams.Model.Accounting
{
    /// <summary>
    /// bom成本核算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 17:04:41
    /// </summary>
    [SugarTable("fico_costing_bom","bom成本核算")]
    public class FicoCostingBom
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long BcSfid { get; set; }

        /// <summary>
        /// 工厂 
        /// </summary>
        [SugarColumn(ColumnName="BcPlant", ColumnDescription = "工厂 ",Length = 4)]
        public string BcPlant { get; set; }

        /// <summary>
        /// 期间 
        /// </summary>
        [SugarColumn(ColumnName="BcFy", ColumnDescription = "期间 ",Length = 6)]
        public string BcFy { get; set; }

        /// <summary>
        /// 年月 
        /// </summary>
        [SugarColumn(ColumnName="BcYm", ColumnDescription = "年月 ",Length = 6)]
        public string BcYm { get; set; }

        /// <summary>
        /// 成品物料 
        /// </summary>
        [SugarColumn(ColumnName="BcBomItem", ColumnDescription = "成品物料 ",Length = 20)]
        public string BcBomItem { get; set; }

        /// <summary>
        /// 物料文本 
        /// </summary>
        [SugarColumn(ColumnName="BcItemText", ColumnDescription = "物料文本 ",Length = 40)]
        public string BcItemText { get; set; }

        /// <summary>
        /// 成本 
        /// </summary>
        [SugarColumn(ColumnName="BcBomCost", ColumnDescription = "成本 ",DefaultValue = "0",Length = 18, DecimalDigits = 5)]
        public decimal BcBomCost { get; set; }

        /// <summary>
        /// 币种 
        /// </summary>
        [SugarColumn(ColumnName="BcCurrency", ColumnDescription = "币种 ",Length = 3)]
        public string BcCurrency { get; set; }

        /// <summary>
        /// 核算日期 
        /// </summary>
        public DateTime? BcBalancedate { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        [SugarColumn(ColumnName="IsDeleted", ColumnDescription = "软删除 ",DefaultValue = "0")]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        [SugarColumn(ColumnName="Remark", ColumnDescription = "备注 ",Length = 2000)]
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