namespace Ams.Model.Accounting
{
    /// <summary>
    /// 部门消耗
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 17:02:09
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
        [SugarColumn(ColumnName = "DcFy", ColumnDescription = "期间 ", Length = 6)]
        public string DcFy { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "DcYm", ColumnDescription = "年月 ", Length = 6)]
        public string DcYm { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        [SugarColumn(ColumnName = "DcCorpCode", ColumnDescription = "公司代码 ", Length = 4)]
        public string DcCorpCode { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [SugarColumn(ColumnName = "DcCorpName", ColumnDescription = "公司名称 ", Length = 40)]
        public string DcCorpName { get; set; }

        /// <summary>
        /// 统计类别
        /// </summary>
        [SugarColumn(ColumnName = "DcExpCategory", ColumnDescription = "统计类别 ", Length = 10)]
        public string DcExpCategory { get; set; }

        /// <summary>
        /// 成本代码
        /// </summary>
        [SugarColumn(ColumnName = "DcCostCode", ColumnDescription = "成本代码 ", Length = 10)]
        public string DcCostCode { get; set; }

        /// <summary>
        /// 成本名称
        /// </summary>
        [SugarColumn(ColumnName = "DcCostName", ColumnDescription = "成本名称 ", Length = 40)]
        public string DcCostName { get; set; }

        /// <summary>
        /// 科目代码
        /// </summary>
        [SugarColumn(ColumnName = "DcTitleCode", ColumnDescription = "科目代码 ", Length = 10)]
        public string DcTitleCode { get; set; }

        /// <summary>
        /// 科目名称
        /// </summary>
        [SugarColumn(ColumnName = "DcTitleName", ColumnDescription = "科目名称 ", Length = 40)]
        public string DcTitleName { get; set; }

        /// <summary>
        /// 科目分类
        /// </summary>
        [SugarColumn(ColumnName = "DcTitleNote", ColumnDescription = "科目分类 ", Length = 40)]
        public string DcTitleNote { get; set; }

        /// <summary>
        /// 预算
        /// </summary>
        [SugarColumn(ColumnName = "DcBudgetAmt", ColumnDescription = "预算 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal DcBudgetAmt { get; set; }

        /// <summary>
        /// 实际
        /// </summary>
        [SugarColumn(ColumnName = "DcActualAmt", ColumnDescription = "实际 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal DcActualAmt { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        [SugarColumn(ColumnName = "DcDiffAmt", ColumnDescription = "差异 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal DcDiffAmt { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "DcPlant", ColumnDescription = "工厂 ", Length = 4)]
        public string DcPlant { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "DcMateriel", ColumnDescription = "物料 ", Length = 20)]
        public string DcMateriel { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        [SugarColumn(ColumnName = "DcStorageLocation", ColumnDescription = "仓库 ", Length = 4)]
        public string DcStorageLocation { get; set; }

        /// <summary>
        /// 移动类型
        /// </summary>
        [SugarColumn(ColumnName = "DcMoveType", ColumnDescription = "移动类型 ", Length = 3)]
        public string DcMoveType { get; set; }

        /// <summary>
        /// 物料凭证
        /// </summary>
        [SugarColumn(ColumnName = "DcMaterielDoc", ColumnDescription = "物料凭证 ", Length = 10)]
        public string DcMaterielDoc { get; set; }

        /// <summary>
        /// 凭证明细
        /// </summary>
        [SugarColumn(ColumnName = "DcMaterielDocDetails", ColumnDescription = "凭证明细 ", Length = 5)]
        public string DcMaterielDocDetails { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "DcUseQty", ColumnDescription = "数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal DcUseQty { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [SugarColumn(ColumnName = "DcUseAmt", ColumnDescription = "金额 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal DcUseAmt { get; set; }

        /// <summary>
        /// 预留单
        /// </summary>
        [SugarColumn(ColumnName = "DcReserveDoc", ColumnDescription = "预留单 ", Length = 10)]
        public string DcReserveDoc { get; set; }

        /// <summary>
        /// 预留明细
        /// </summary>
        [SugarColumn(ColumnName = "DcAccountant", ColumnDescription = "预留明细 ", Length = 10)]
        public string DcAccountant { get; set; }

        /// <summary>
        /// 登录日期
        /// </summary>
        public DateTime? DcBalanceDate { get; set; }
    }
}