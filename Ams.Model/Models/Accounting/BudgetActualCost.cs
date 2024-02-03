
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 预算实际明细
    /// 数据实体
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 10:41:09)
    /// </summary>
    [SugarTable("fico_budget_actual_cost")]
    public class BudgetActualCost
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbSFID { get; set; }

        /// <summary>
        /// 期间 
        /// </summary>
        public string FbFy { get; set; }

        /// <summary>
        /// 年月 
        /// </summary>
        public string FbYm { get; set; }

        /// <summary>
        /// 公司代码 
        /// </summary>
        public string FbCorpCode { get; set; }

        /// <summary>
        /// 公司名称 
        /// </summary>
        public string FbCorpName { get; set; }

        /// <summary>
        /// 统计类别 
        /// </summary>
        public string FbExpCategory { get; set; }

        /// <summary>
        /// 成本代码 
        /// </summary>
        public string FbCostCode { get; set; }

        /// <summary>
        /// 成本名称 
        /// </summary>
        public string FbCostName { get; set; }

        /// <summary>
        /// 科目代码 
        /// </summary>
        public string FbTitleCode { get; set; }

        /// <summary>
        /// 科目名称 
        /// </summary>
        public string FbTitleName { get; set; }

        /// <summary>
        /// 科目分类 
        /// </summary>
        public string FbTitleNote { get; set; }

        /// <summary>
        /// 预算 
        /// </summary>
        public decimal FbBudgetAmt { get; set; }

        /// <summary>
        /// 实际 
        /// </summary>
        public decimal FbActualAmt { get; set; }

        /// <summary>
        /// 差异 
        /// </summary>
        public decimal FbDiffAmt { get; set; }

        /// <summary>
        /// 会计人员 
        /// </summary>
        public string FbAccountant { get; set; }

        /// <summary>
        /// 日期 
        /// </summary>
        public DateTime? FbBalanceDate { get; set; }

        /// <summary>
        /// 删除 
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