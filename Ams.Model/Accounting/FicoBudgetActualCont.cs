namespace Ams.Model.Accounting
{
    /// <summary>
    /// 实际对比
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:50:08
    /// </summary>
    [SugarTable("fico_budget_actual_cont", "实际对比")]
    public class FicoBudgetActualCont : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbSfId { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "FbLfgja", ColumnDescription = "期间", Length = 6)]
        public string FbLfgja { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "FbLfmon", ColumnDescription = "年月", Length = 6)]
        public string FbLfmon { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        [SugarColumn(ColumnName = "FbBukrs", ColumnDescription = "公司代码", Length = 4)]
        public string FbBukrs { get; set; }

        /// <summary>
        /// 统计类别
        /// </summary>
        [SugarColumn(ColumnName = "FbStatyp", ColumnDescription = "统计类别", Length = 4)]
        public string FbStatyp { get; set; }

        /// <summary>
        /// 成本科目
        /// </summary>
        [SugarColumn(ColumnName = "FbKtosl", ColumnDescription = "成本科目", Length = 10)]
        public string FbKtosl { get; set; }

        /// <summary>
        /// 成本分类
        /// </summary>
        [SugarColumn(ColumnName = "FbKotyp", ColumnDescription = "成本分类", Length = 1)]
        public string FbKotyp { get; set; }

        /// <summary>
        /// 科目代码
        /// </summary>
        [SugarColumn(ColumnName = "FbKonto", ColumnDescription = "科目代码", Length = 10)]
        public string FbKonto { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "FbWerks", ColumnDescription = "币种", Length = 3)]
        public string FbWerks { get; set; }

        /// <summary>
        /// 预算
        /// </summary>
        [SugarColumn(ColumnName = "FbAnval", ColumnDescription = "预算", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbAnval { get; set; }

        /// <summary>
        /// 实际
        /// </summary>
        [SugarColumn(ColumnName = "FbDmist", ColumnDescription = "实际", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbDmist { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        [SugarColumn(ColumnName = "FbBfaac", ColumnDescription = "差异", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbBfaac { get; set; }

        /// <summary>
        /// 核算人员
        /// </summary>
        [SugarColumn(ColumnName = "FbPresp", ColumnDescription = "核算人员", Length = 10)]
        public string FbPresp { get; set; }

        /// <summary>
        /// 核算日期
        /// </summary>
        public DateTime? FbZkdat { get; set; }
    }
}