namespace Ams.Model.Routine
{
    /// <summary>
    /// 绩效
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 9:40:38
    /// </summary>
    [SugarTable("routine_ehr_performance", "绩效")]
    public class RoutineEhrPerformance : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [SugarColumn(ColumnName = "Ml002", ColumnDescription = "工号", Length = 8, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ml002 { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [SugarColumn(ColumnName = "Ml003", ColumnDescription = "姓名", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ml003 { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        [SugarColumn(ColumnName = "Ml004", ColumnDescription = "年度", Length = 6)]
        public string Ml004 { get; set; }

        /// <summary>
        /// 总分
        /// </summary>
        [SugarColumn(ColumnName = "Ml005", ColumnDescription = "总分", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ml005 { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [SugarColumn(ColumnName = "Ml006", ColumnDescription = "等级", Length = 1)]
        public string Ml006 { get; set; }

        /// <summary>
        /// 考核项目
        /// </summary>
        [SugarColumn(ColumnName = "Ml007", ColumnDescription = "考核项目", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ml007 { get; set; }

        /// <summary>
        /// 初次评分
        /// </summary>
        [SugarColumn(ColumnName = "Ml008", ColumnDescription = "初次评分", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ml008 { get; set; }

        /// <summary>
        /// 初评人
        /// </summary>
        [SugarColumn(ColumnName = "Ml009", ColumnDescription = "初评人", Length = 40)]
        public string Ml009 { get; set; }

        /// <summary>
        /// 初评日期
        /// </summary>
        public DateTime? Ml010 { get; set; }

        /// <summary>
        /// 二次评分
        /// </summary>
        [SugarColumn(ColumnName = "Ml011", ColumnDescription = "二次评分", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ml011 { get; set; }

        /// <summary>
        /// 二次考评人
        /// </summary>
        [SugarColumn(ColumnName = "Ml012", ColumnDescription = "二次考评人", Length = 40)]
        public string Ml012 { get; set; }

        /// <summary>
        /// 二次考评日期
        /// </summary>
        public DateTime? Ml013 { get; set; }

        /// <summary>
        /// 三次评分
        /// </summary>
        [SugarColumn(ColumnName = "Ml014", ColumnDescription = "三次评分", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ml014 { get; set; }

        /// <summary>
        /// 三次考评人
        /// </summary>
        [SugarColumn(ColumnName = "Ml015", ColumnDescription = "三次考评人", Length = 40)]
        public string Ml015 { get; set; }

        /// <summary>
        /// 三次考评日期
        /// </summary>
        public DateTime? Ml016 { get; set; }

        /// <summary>
        /// 四次评分
        /// </summary>
        [SugarColumn(ColumnName = "Ml017", ColumnDescription = "四次评分", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ml017 { get; set; }

        /// <summary>
        /// 四次考评人
        /// </summary>
        [SugarColumn(ColumnName = "Ml018", ColumnDescription = "四次考评人", Length = 40)]
        public string Ml018 { get; set; }

        /// <summary>
        /// 四次考评日期
        /// </summary>
        public DateTime? Ml019 { get; set; }

        /// <summary>
        /// 五次评分
        /// </summary>
        [SugarColumn(ColumnName = "Ml020", ColumnDescription = "五次评分", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ml020 { get; set; }

        /// <summary>
        /// 五次考评人
        /// </summary>
        [SugarColumn(ColumnName = "Ml021", ColumnDescription = "五次考评人", Length = 40)]
        public string Ml021 { get; set; }

        /// <summary>
        /// 五次考评日期
        /// </summary>
        public DateTime? Ml022 { get; set; }

        /// <summary>
        /// 六次评分
        /// </summary>
        [SugarColumn(ColumnName = "Ml023", ColumnDescription = "六次评分", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ml023 { get; set; }

        /// <summary>
        /// 六次考评人
        /// </summary>
        [SugarColumn(ColumnName = "Ml024", ColumnDescription = "六次考评人", Length = 40)]
        public string Ml024 { get; set; }

        /// <summary>
        /// 六次考评日期
        /// </summary>
        public DateTime? Ml025 { get; set; }
    }
}