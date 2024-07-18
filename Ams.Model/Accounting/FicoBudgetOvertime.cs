namespace Ams.Model.Accounting
{
    /// <summary>
    /// 加班预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:25:59
    /// </summary>
    [SugarTable("fico_budget_overtime", "加班预算")]
    public class FicoBudgetOvertime : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FboSFID { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "FboCorp", ColumnDescription = "公司 ", Length = 4)]
        public string FboCorp { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "FboDept", ColumnDescription = "部门 ", Length = 20)]
        public string FboDept { get; set; }

        /// <summary>
        /// 财年
        /// </summary>
        [SugarColumn(ColumnName = "FboFy", ColumnDescription = "财年 ", Length = 6)]
        public string FboFy { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "FboFm", ColumnDescription = "年月 ", Length = 100)]
        public string FboFm { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [SugarColumn(ColumnName = "FboTitle", ColumnDescription = "科目 ", Length = 40)]
        public string FboTitle { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "FboClass", ColumnDescription = "名称 ", Length = 100)]
        public string FboClass { get; set; }

        /// <summary>
        /// 必要工数
        /// </summary>
        [SugarColumn(ColumnName = "FboRequiredst", ColumnDescription = "必要工数 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FboRequiredst { get; set; }

        /// <summary>
        /// 保有人数
        /// </summary>
        [SugarColumn(ColumnName = "FboDirectEmployee", ColumnDescription = "保有人数 ", DefaultValue = "0")]
        public int FboDirectEmployee { get; set; }

        /// <summary>
        /// 间接人数
        /// </summary>
        [SugarColumn(ColumnName = "FboIndirectEmployee", ColumnDescription = "间接人数 ", DefaultValue = "0")]
        public int FboIndirectEmployee { get; set; }

        /// <summary>
        /// 上班天数
        /// </summary>
        [SugarColumn(ColumnName = "FboDays", ColumnDescription = "上班天数 ", DefaultValue = "0")]
        public int FboDays { get; set; }

        /// <summary>
        /// 加班事由
        /// </summary>
        [SugarColumn(ColumnName = "FboContent", ColumnDescription = "加班事由 ", Length = 500)]
        public string FboContent { get; set; }

        /// <summary>
        /// 保有工数
        /// </summary>
        [SugarColumn(ColumnName = "FboRetainst", ColumnDescription = "保有工数 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FboRetainst { get; set; }

        /// <summary>
        /// 工数差异
        /// </summary>
        [SugarColumn(ColumnName = "FboRetainstdiff", ColumnDescription = "工数差异 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FboRetainstdiff { get; set; }

        /// <summary>
        /// 投入加班
        /// </summary>
        [SugarColumn(ColumnName = "FboOvertime", ColumnDescription = "投入加班 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FboOvertime { get; set; }

        /// <summary>
        /// 平均投入加班
        /// </summary>
        [SugarColumn(ColumnName = "FboDirectovertime", ColumnDescription = "平均投入加班 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FboDirectovertime { get; set; }

        /// <summary>
        /// 间接加班
        /// </summary>
        [SugarColumn(ColumnName = "FboIndirectovertime", ColumnDescription = "间接加班 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FboIndirectovertime { get; set; }

        /// <summary>
        /// 投入总加班
        /// </summary>
        [SugarColumn(ColumnName = "FboOvertimetotal", ColumnDescription = "投入总加班 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FboOvertimetotal { get; set; }

        /// <summary>
        /// 启用标记
        /// </summary>
        [SugarColumn(ColumnName = "FboFlag", ColumnDescription = "启用标记 ", DefaultValue = "0")]
        public int FboFlag { get; set; }

        /// <summary>
        /// 审核
        /// </summary>
        [SugarColumn(ColumnName = "FboAudit", ColumnDescription = "审核 ", DefaultValue = "0")]
        public int FboAudit { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        [SugarColumn(ColumnName = "FboAuditName", ColumnDescription = "审核人员 ", Length = 20)]
        public string FboAuditName { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? FboAuditDate { get; set; }

        /// <summary>
        /// 撤消人员
        /// </summary>
        [SugarColumn(ColumnName = "FboUndoName", ColumnDescription = "撤消人员 ", Length = 20)]
        public string FboUndoName { get; set; }

        /// <summary>
        /// 撤消日期
        /// </summary>
        public DateTime? FboUndoDate { get; set; }

        /// <summary>
        /// 自定义A
        /// </summary>
        [SugarColumn(ColumnName = "UDF01", ColumnDescription = "自定义A ", Length = 200)]
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B
        /// </summary>
        [SugarColumn(ColumnName = "UDF02", ColumnDescription = "自定义B ", Length = 200)]
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C
        /// </summary>
        [SugarColumn(ColumnName = "UDF03", ColumnDescription = "自定义C ", Length = 200)]
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D
        /// </summary>
        [SugarColumn(ColumnName = "UDF04", ColumnDescription = "自定义D ", Length = 200)]
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E
        /// </summary>
        [SugarColumn(ColumnName = "UDF05", ColumnDescription = "自定义E ", Length = 200)]
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F
        /// </summary>
        [SugarColumn(ColumnName = "UDF06", ColumnDescription = "自定义F ", Length = 200)]
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1
        /// </summary>
        [SugarColumn(ColumnName = "UDF51", ColumnDescription = "自定义1 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2
        /// </summary>
        [SugarColumn(ColumnName = "UDF52", ColumnDescription = "自定义2 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3
        /// </summary>
        [SugarColumn(ColumnName = "UDF53", ColumnDescription = "自定义3 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4
        /// </summary>
        [SugarColumn(ColumnName = "UDF54", ColumnDescription = "自定义4 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5
        /// </summary>
        [SugarColumn(ColumnName = "UDF55", ColumnDescription = "自定义5 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6
        /// </summary>
        [SugarColumn(ColumnName = "UDF56", ColumnDescription = "自定义6 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        [SugarColumn(ColumnName = "IsDeleted", ColumnDescription = "软删除 ", DefaultValue = "0")]
        public int IsDeleted { get; set; }
    }
}