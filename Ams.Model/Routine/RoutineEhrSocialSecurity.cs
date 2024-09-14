namespace Ams.Model.Routine
{
    /// <summary>
    /// 社保
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:14:24
    /// </summary>
    [SugarTable("routine_ehr_social_security", "社保")]
    public class RoutineEhrSocialSecurity : SysBase
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
        public long ParentId { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [SugarColumn(ColumnName = "Mp003", ColumnDescription = "工号", Length = 8)]
        public string Mp003 { get; set; }

        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime? Mp004 { get; set; }

        /// <summary>
        /// 养老
        /// </summary>
        [SugarColumn(ColumnName = "Mp005", ColumnDescription = "养老", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mp005 { get; set; }

        /// <summary>
        /// 医疗
        /// </summary>
        [SugarColumn(ColumnName = "Mp006", ColumnDescription = "医疗", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mp006 { get; set; }

        /// <summary>
        /// 工伤
        /// </summary>
        [SugarColumn(ColumnName = "Mp007", ColumnDescription = "工伤", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mp007 { get; set; }

        /// <summary>
        /// 失业
        /// </summary>
        [SugarColumn(ColumnName = "Mp008", ColumnDescription = "失业", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mp008 { get; set; }

        /// <summary>
        /// 生育
        /// </summary>
        [SugarColumn(ColumnName = "Mp009", ColumnDescription = "生育", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mp009 { get; set; }
    }
}