namespace Ams.Model.Routine
{
    /// <summary>
    /// 绩效
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:43
    /// </summary>
    [SugarTable("routine_ehr_performance_slv", "绩效")]
    public class RoutineEhrPerformanceSlv : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? ParentId { get; set; }

        /// <summary>
        /// 考核项目
        /// </summary>
        [SugarColumn(ColumnName = "Mm003", ColumnDescription = "考核项目", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mm003 { get; set; }

        /// <summary>
        /// 初次评分
        /// </summary>
        [SugarColumn(ColumnName = "Mm004", ColumnDescription = "初次评分", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mm004 { get; set; }

        /// <summary>
        /// 初评人
        /// </summary>
        [SugarColumn(ColumnName = "Mm005", ColumnDescription = "初评人", Length = 40)]
        public string Mm005 { get; set; }

        /// <summary>
        /// 初评日期
        /// </summary>
        public DateTime? Mm006 { get; set; }

        /// <summary>
        /// 二次评分
        /// </summary>
        [SugarColumn(ColumnName = "Mm007", ColumnDescription = "二次评分", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mm007 { get; set; }

        /// <summary>
        /// 二次考评人
        /// </summary>
        [SugarColumn(ColumnName = "Mm008", ColumnDescription = "二次考评人", Length = 40)]
        public string Mm008 { get; set; }

        /// <summary>
        /// 二次考评日期
        /// </summary>
        public DateTime? Mm009 { get; set; }

        /// <summary>
        /// 三次评分
        /// </summary>
        [SugarColumn(ColumnName = "Mm010", ColumnDescription = "三次评分", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mm010 { get; set; }

        /// <summary>
        /// 三次考评人
        /// </summary>
        [SugarColumn(ColumnName = "Mm011", ColumnDescription = "三次考评人", Length = 40)]
        public string Mm011 { get; set; }

        /// <summary>
        /// 三次考评日期
        /// </summary>
        public DateTime? Mm012 { get; set; }

        /// <summary>
        /// 四次评分
        /// </summary>
        [SugarColumn(ColumnName = "Mm013", ColumnDescription = "四次评分", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mm013 { get; set; }

        /// <summary>
        /// 四次考评人
        /// </summary>
        [SugarColumn(ColumnName = "Mm014", ColumnDescription = "四次考评人", Length = 40)]
        public string Mm014 { get; set; }

        /// <summary>
        /// 四次考评日期
        /// </summary>
        public DateTime? Mm015 { get; set; }

        /// <summary>
        /// 五次评分
        /// </summary>
        [SugarColumn(ColumnName = "Mm016", ColumnDescription = "五次评分", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mm016 { get; set; }

        /// <summary>
        /// 五次考评人
        /// </summary>
        [SugarColumn(ColumnName = "Mm017", ColumnDescription = "五次考评人", Length = 40)]
        public string Mm017 { get; set; }

        /// <summary>
        /// 五次考评日期
        /// </summary>
        public DateTime? Mm018 { get; set; }

        /// <summary>
        /// 六次评分
        /// </summary>
        [SugarColumn(ColumnName = "Mm019", ColumnDescription = "六次评分", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mm019 { get; set; }

        /// <summary>
        /// 六次考评人
        /// </summary>
        [SugarColumn(ColumnName = "Mm020", ColumnDescription = "六次考评人", Length = 40)]
        public string Mm020 { get; set; }

        /// <summary>
        /// 六次考评日期
        /// </summary>
        public DateTime? Mm021 { get; set; }
    }
}