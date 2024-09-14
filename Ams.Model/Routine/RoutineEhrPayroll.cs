namespace Ams.Model.Routine
{
    /// <summary>
    /// 薪资
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:20:02
    /// </summary>
    [SugarTable("routine_ehr_payroll", "薪资")]
    public class RoutineEhrPayroll : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "Mk002", ColumnDescription = "部门", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mk002 { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [SugarColumn(ColumnName = "Mk003", ColumnDescription = "工号", Length = 8)]
        public string Mk003 { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [SugarColumn(ColumnName = "Mk004", ColumnDescription = "姓名", Length = 40)]
        public string Mk004 { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>
        [SugarColumn(ColumnName = "Mk005", ColumnDescription = "岗位", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mk005 { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [SugarColumn(ColumnName = "Mk006", ColumnDescription = "等级", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mk006 { get; set; }

        /// <summary>
        /// 薪别
        /// </summary>
        [SugarColumn(ColumnName = "Mk007", ColumnDescription = "薪别", Length = 2)]
        public string Mk007 { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime? Mk008 { get; set; }

        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime? Mk009 { get; set; }

        /// <summary>
        /// 税别
        /// </summary>
        [SugarColumn(ColumnName = "Mk010", ColumnDescription = "税别", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mk010 { get; set; }

        /// <summary>
        /// 基本工资
        /// </summary>
        [SugarColumn(ColumnName = "Mk011", ColumnDescription = "基本工资", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mk011 { get; set; }

        /// <summary>
        /// 全勤
        /// </summary>
        [SugarColumn(ColumnName = "Mk012", ColumnDescription = "全勤", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mk012 { get; set; }

        /// <summary>
        /// 全勤否
        /// </summary>
        [SugarColumn(ColumnName = "Mk013", ColumnDescription = "全勤否", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int? Mk013 { get; set; }

        /// <summary>
        /// 职位津贴
        /// </summary>
        [SugarColumn(ColumnName = "Mk014", ColumnDescription = "职位津贴", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mk014 { get; set; }

        /// <summary>
        /// 职能调整
        /// </summary>
        [SugarColumn(ColumnName = "Mk015", ColumnDescription = "职能调整", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mk015 { get; set; }

        /// <summary>
        /// 补助(夜霄，银行，其它)
        /// </summary>
        [SugarColumn(ColumnName = "Mk016", ColumnDescription = "补助(夜霄，银行，其它)", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mk016 { get; set; }

        /// <summary>
        /// 其它津贴
        /// </summary>
        [SugarColumn(ColumnName = "Mk017", ColumnDescription = "其它津贴", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mk017 { get; set; }

        /// <summary>
        /// 保险
        /// </summary>
        [SugarColumn(ColumnName = "Mk018", ColumnDescription = "保险", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mk018 { get; set; }

        /// <summary>
        /// 工龄
        /// </summary>
        [SugarColumn(ColumnName = "Mk019", ColumnDescription = "工龄", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mk019 { get; set; }

        /// <summary>
        /// 社保
        /// </summary>
        [SugarColumn(ColumnName = "Mk020", ColumnDescription = "社保", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mk020 { get; set; }

        /// <summary>
        /// 奖金
        /// </summary>
        [SugarColumn(ColumnName = "Mk021", ColumnDescription = "奖金", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mk021 { get; set; }

        /// <summary>
        /// 加班
        /// </summary>
        [SugarColumn(ColumnName = "Mk022", ColumnDescription = "加班", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mk022 { get; set; }

        /// <summary>
        /// 特殊津贴
        /// </summary>
        [SugarColumn(ColumnName = "Mk023", ColumnDescription = "特殊津贴", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mk023 { get; set; }

        /// <summary>
        /// 伙食
        /// </summary>
        [SugarColumn(ColumnName = "Nk024", ColumnDescription = "伙食", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Nk024 { get; set; }
    }
}