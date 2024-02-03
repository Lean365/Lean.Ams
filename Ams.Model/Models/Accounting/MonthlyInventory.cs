
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 月度存货
    /// 数据实体
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 8:20:25)
    /// </summary>
    [SugarTable("fico_monthly_inventory")]
    public class MonthlyInventory
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long MiSFID { get; set; }

        /// <summary>
        /// 工厂 
        /// </summary>
        public string MiPlant { get; set; }

        /// <summary>
        /// 期间 
        /// </summary>
        public string MiFy { get; set; }

        /// <summary>
        /// 年月 
        /// </summary>
        public string MiYm { get; set; }

        /// <summary>
        /// 物料 
        /// </summary>
        public string MiItem { get; set; }

        /// <summary>
        /// 评估类 
        /// </summary>
        public string MiValType { get; set; }

        /// <summary>
        /// 价格控制 
        /// </summary>
        public string MiPriceControl { get; set; }

        /// <summary>
        /// 移动平均价 
        /// </summary>
        public decimal MiMovingAverage { get; set; }

        /// <summary>
        /// Per单位 
        /// </summary>
        public int MiPerUnit { get; set; }

        /// <summary>
        /// 币种 
        /// </summary>
        public string MiLocalCcy { get; set; }

        /// <summary>
        /// 库存 
        /// </summary>
        public decimal MiInventoryQty { get; set; }

        /// <summary>
        /// 金额 
        /// </summary>
        public decimal MiInventoryAmount { get; set; }

        /// <summary>
        /// 登录日期 
        /// </summary>
        public DateTime? MiBalancedate { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 说明 
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