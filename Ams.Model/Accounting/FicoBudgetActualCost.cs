namespace Ams.Model.Accounting
{
    /// <summary>
    /// 预算实际明细
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:42:06
    /// </summary>
    [SugarTable("fico_budget_actual_cost", "预算实际明细")]
    public class FicoBudgetActualCost : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
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
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsDeleted { get; set; }
    }
}