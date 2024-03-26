
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 财务期间
    /// 数据实体对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 8:02:36)
    /// </summary>
    [SugarTable("fico_period")]
    public class Period
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FpSFID { get; set; }

        /// <summary>
        /// 财年 
        /// </summary>
        public string FpFy { get; set; }

        /// <summary>
        /// 年月 
        /// </summary>
        public string FpYm { get; set; }

        /// <summary>
        /// 年 
        /// </summary>
        public string FpYear { get; set; }

        /// <summary>
        /// 月 
        /// </summary>
        public string FpMonth { get; set; }

        /// <summary>
        /// 季度 
        /// </summary>
        public string FpQuarter { get; set; }

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