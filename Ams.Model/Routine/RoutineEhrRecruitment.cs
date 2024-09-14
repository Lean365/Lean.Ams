namespace Ams.Model.Routine
{
    /// <summary>
    /// 招聘
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:16:55
    /// </summary>
    [SugarTable("routine_ehr_recruitment", "招聘")]
    public class RoutineEhrRecruitment : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 招聘日期
        /// </summary>
        public DateTime? Mn002 { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [SugarColumn(ColumnName = "Mn003", ColumnDescription = "姓名", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mn003 { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "Mn004", ColumnDescription = "部门", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn004 { get; set; }

        /// <summary>
        /// 职称
        /// </summary>
        [SugarColumn(ColumnName = "Mn005", ColumnDescription = "职称", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn005 { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>
        [SugarColumn(ColumnName = "Mn006", ColumnDescription = "岗位", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn006 { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [SugarColumn(ColumnName = "Mn007", ColumnDescription = "等级", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn007 { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        [SugarColumn(ColumnName = "Mn008", ColumnDescription = "职务", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn008 { get; set; }

        /// <summary>
        /// 聘用形式
        /// </summary>
        [SugarColumn(ColumnName = "Mn009", ColumnDescription = "聘用形式", Length = 8)]
        public string Mn009 { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime? Mn010 { get; set; }

        /// <summary>
        /// 在职状态
        /// </summary>
        [SugarColumn(ColumnName = "Mn011", ColumnDescription = "在职状态", Length = 3)]
        public string Mn011 { get; set; }

        /// <summary>
        /// 试用期
        /// </summary>
        [SugarColumn(ColumnName = "Mn012", ColumnDescription = "试用期", Length = 3)]
        public string Mn012 { get; set; }

        /// <summary>
        /// 试用工资
        /// </summary>
        [SugarColumn(ColumnName = "Mn013", ColumnDescription = "试用工资", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mn013 { get; set; }

        /// <summary>
        /// 合同期限
        /// </summary>
        [SugarColumn(ColumnName = "Mn014", ColumnDescription = "合同期限", Length = 3)]
        public string Mn014 { get; set; }

        /// <summary>
        /// 转正工资
        /// </summary>
        [SugarColumn(ColumnName = "Mn015", ColumnDescription = "转正工资", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mn015 { get; set; }

        /// <summary>
        /// 转正日期
        /// </summary>
        public DateTime? Mn016 { get; set; }

        /// <summary>
        /// 合同终止日
        /// </summary>
        public DateTime? Mn017 { get; set; }

        /// <summary>
        /// 合同起始日
        /// </summary>
        public DateTime? Mn018 { get; set; }
    }
}