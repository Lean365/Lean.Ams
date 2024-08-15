namespace Ams.Model.Routine
{
    /// <summary>
    /// 社保
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:30:43
    /// </summary>
    [SugarTable("routine_ehr_social_security", "社保")]
    public class RoutineEhrSocialSecurity : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long EeSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public long EeParentSfId { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [SugarColumn(ColumnName = "EeWorkID", ColumnDescription = "工号 ", Length = 8)]
        public string EeWorkID { get; set; }

        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime? EssEffectiveDate { get; set; }

        /// <summary>
        /// 养老
        /// </summary>
        [SugarColumn(ColumnName = "EeOldAgeInsur", ColumnDescription = "养老 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal EeOldAgeInsur { get; set; }

        /// <summary>
        /// 医疗
        /// </summary>
        [SugarColumn(ColumnName = "EeMedicalInsur", ColumnDescription = "医疗 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal EeMedicalInsur { get; set; }

        /// <summary>
        /// 工伤
        /// </summary>
        [SugarColumn(ColumnName = "EeInjuryInsur", ColumnDescription = "工伤 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal EeInjuryInsur { get; set; }

        /// <summary>
        /// 失业
        /// </summary>
        [SugarColumn(ColumnName = "EeUnemploymentInsur", ColumnDescription = "失业 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal EeUnemploymentInsur { get; set; }

        /// <summary>
        /// 生育
        /// </summary>
        [SugarColumn(ColumnName = "EeMaternityInsur", ColumnDescription = "生育 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal EeMaternityInsur { get; set; }
    }
}