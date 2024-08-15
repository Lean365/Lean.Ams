namespace Ams.Model.Accounting
{
    /// <summary>
    /// 部门消耗
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 12:03:53
    /// </summary>
    [SugarTable("fico_costing_dept_consuming", "部门消耗")]
    public class FicoCostingDeptConsuming : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long DcSfId { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "DcLfgja", ColumnDescription = "期间", Length = 6)]
        public string DcLfgja { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "DcLfmon", ColumnDescription = "年月", Length = 6)]
        public string DcLfmon { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        [SugarColumn(ColumnName = "DcBukrs", ColumnDescription = "公司代码", Length = 4)]
        public string DcBukrs { get; set; }

        /// <summary>
        /// 统计类别
        /// </summary>
        [SugarColumn(ColumnName = "DcStatyp", ColumnDescription = "统计类别", Length = 10)]
        public string DcStatyp { get; set; }

        /// <summary>
        /// 成本科目
        /// </summary>
        [SugarColumn(ColumnName = "DcKtosl", ColumnDescription = "成本科目", Length = 10)]
        public string DcKtosl { get; set; }

        /// <summary>
        /// 科目代码
        /// </summary>
        [SugarColumn(ColumnName = "DcKonto", ColumnDescription = "科目代码", Length = 10)]
        public string DcKonto { get; set; }

        /// <summary>
        /// 科目分类
        /// </summary>
        [SugarColumn(ColumnName = "DcKotyp", ColumnDescription = "科目分类", Length = 40)]
        public string DcKotyp { get; set; }

        /// <summary>
        /// 预算
        /// </summary>
        [SugarColumn(ColumnName = "DcAnval", ColumnDescription = "预算", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal DcAnval { get; set; }

        /// <summary>
        /// 实际
        /// </summary>
        [SugarColumn(ColumnName = "DcDmist", ColumnDescription = "实际", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal DcDmist { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        [SugarColumn(ColumnName = "DcBfaac", ColumnDescription = "差异", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal DcBfaac { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "DcWerks", ColumnDescription = "工厂", Length = 4)]
        public string DcWerks { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "DcMatnr", ColumnDescription = "物料", Length = 20)]
        public string DcMatnr { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        [SugarColumn(ColumnName = "DcLgort", ColumnDescription = "仓库", Length = 4)]
        public string DcLgort { get; set; }

        /// <summary>
        /// 移动类型
        /// </summary>
        [SugarColumn(ColumnName = "DcBwart", ColumnDescription = "移动类型", Length = 3)]
        public string DcBwart { get; set; }

        /// <summary>
        /// 物料凭证
        /// </summary>
        [SugarColumn(ColumnName = "DcMblnr", ColumnDescription = "物料凭证", Length = 10)]
        public string DcMblnr { get; set; }

        /// <summary>
        /// 项目明细
        /// </summary>
        [SugarColumn(ColumnName = "DcZeile", ColumnDescription = "项目明细", Length = 5)]
        public string DcZeile { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "DcMenge", ColumnDescription = "数量", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal DcMenge { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "DcWaers", ColumnDescription = "币种", Length = 3)]
        public string DcWaers { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [SugarColumn(ColumnName = "DcDmbtr", ColumnDescription = "金额", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal DcDmbtr { get; set; }

        /// <summary>
        /// 预留单
        /// </summary>
        [SugarColumn(ColumnName = "DcRsnum", ColumnDescription = "预留单", Length = 10)]
        public string DcRsnum { get; set; }

        /// <summary>
        /// 预留明细
        /// </summary>
        [SugarColumn(ColumnName = "DcRspos", ColumnDescription = "预留明细", Length = 10)]
        public string DcRspos { get; set; }

        /// <summary>
        /// 领用日期
        /// </summary>
        public DateTime? DcBudat { get; set; }
    }
}