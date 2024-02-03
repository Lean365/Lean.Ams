
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 工资率
    /// 数据实体
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 7:33:39)
    /// </summary>
    [SugarTable("fico_wage_rates")]
    public class WageRates
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FwSFID { get; set; }

        /// <summary>
        /// 公司 
        /// </summary>
        public string FwCrop { get; set; }

        /// <summary>
        /// 年月 
        /// </summary>
        public string FwYm { get; set; }

        /// <summary>
        /// 币种 
        /// </summary>
        public string FwCcy { get; set; }

        /// <summary>
        /// 销售额 
        /// </summary>
        public decimal FwSalesVolume { get; set; }

        /// <summary>
        /// 工作天数 
        /// </summary>
        public decimal FwWorkingDays { get; set; }

        /// <summary>
        /// 直接工资率 
        /// </summary>
        public decimal FwDirectWageRate { get; set; }

        /// <summary>
        /// 直接人数 
        /// </summary>
        public decimal FwDirect { get; set; }

        /// <summary>
        /// 直接加班费 
        /// </summary>
        public decimal FwDirectOverTime { get; set; }

        /// <summary>
        /// 直接工资 
        /// </summary>
        public decimal FwDirectWages { get; set; }

        /// <summary>
        /// 间接工资率 
        /// </summary>
        public decimal FwInDirectWageRate { get; set; }

        /// <summary>
        /// 间接人数 
        /// </summary>
        public decimal FwInDirect { get; set; }

        /// <summary>
        /// 间接加班费 
        /// </summary>
        public decimal FwInDirectOverTime { get; set; }

        /// <summary>
        /// 间接工资 
        /// </summary>
        public decimal FwInDirectWages { get; set; }

        /// <summary>
        /// 自定义A 
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B 
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C 
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D 
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E 
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F 
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6 
        /// </summary>
        public decimal UDF56 { get; set; }

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