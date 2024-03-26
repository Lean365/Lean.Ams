
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 汇率表
    /// 数据实体对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 8:07:17)
    /// </summary>
    [SugarTable("fico_exchange_rate")]
    public class ExchangeRate
    {
        /// <summary>
        /// FSID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FerSFID { get; set; }

        /// <summary>
        /// 公司 
        /// </summary>
        public string FerCorp { get; set; }

        /// <summary>
        /// 日期 
        /// </summary>
        public DateTime? FerEffDate { get; set; }

        /// <summary>
        /// 基数 
        /// </summary>
        public int FerStd { get; set; }

        /// <summary>
        /// 从币种 
        /// </summary>
        public string FerfmCcy { get; set; }

        /// <summary>
        /// 汇率 
        /// </summary>
        public decimal FerRate { get; set; }

        /// <summary>
        /// 到币种 
        /// </summary>
        public string FertoCcy { get; set; }

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