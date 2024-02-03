
namespace Ams.Model.Accounting
{
    /// <summary>
    /// bom成本核算
    /// 数据实体
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 10:37:37)
    /// </summary>
    [SugarTable("fico_bom_costing")]
    public class BomCosting
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long BcSFID { get; set; }

        /// <summary>
        /// 工厂 
        /// </summary>
        public string BcPlant { get; set; }

        /// <summary>
        /// 期间 
        /// </summary>
        public string BcFy { get; set; }

        /// <summary>
        /// 年月 
        /// </summary>
        public string BcYm { get; set; }

        /// <summary>
        /// 成品物料 
        /// </summary>
        public string BcBomItem { get; set; }

        /// <summary>
        /// 物料文本 
        /// </summary>
        public string BcItemText { get; set; }

        /// <summary>
        /// 成本 
        /// </summary>
        public decimal BcBomCost { get; set; }

        /// <summary>
        /// 币种 
        /// </summary>
        public string BcCurrency { get; set; }

        /// <summary>
        /// 核算日期 
        /// </summary>
        public DateTime? BcBalancedate { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
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