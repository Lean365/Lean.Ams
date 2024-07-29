
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 财务期间
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:59:13
    /// </summary>
    [SugarTable("fico_financial_period","财务期间")]
    public class FicoFinancialPeriod
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FpSfid { get; set; }

        /// <summary>
        /// 财年 
        /// </summary>
        [SugarColumn(ColumnName="FpFinancialYear", ColumnDescription = "财年 ",Length = 6)]
        public string FpFinancialYear { get; set; }

        /// <summary>
        /// 年月 
        /// </summary>
        [SugarColumn(ColumnName="FpYearMonth", ColumnDescription = "年月 ",Length = 6)]
        public string FpYearMonth { get; set; }

        /// <summary>
        /// 年 
        /// </summary>
        [SugarColumn(ColumnName="FpYear", ColumnDescription = "年 ",Length = 4)]
        public string FpYear { get; set; }

        /// <summary>
        /// 月 
        /// </summary>
        [SugarColumn(ColumnName="FpMonth", ColumnDescription = "月 ",Length = 2)]
        public string FpMonth { get; set; }

        /// <summary>
        /// 季度 
        /// </summary>
        [SugarColumn(ColumnName="FpQuarter", ColumnDescription = "季度 ",Length = 2)]
        public string FpQuarter { get; set; }

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