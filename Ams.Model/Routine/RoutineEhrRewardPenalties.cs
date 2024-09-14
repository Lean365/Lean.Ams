namespace Ams.Model.Routine
{
    /// <summary>
    /// 奖惩
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:16:00
    /// </summary>
    [SugarTable("routine_ehr_reward_penalties", "奖惩")]
    public class RoutineEhrRewardPenalties : SysBase
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
        [SugarColumn(ColumnName = "Mo002", ColumnDescription = "工号", Length = 8, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mo002 { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [SugarColumn(ColumnName = "Mo003", ColumnDescription = "姓名", Length = 40)]
        public string Mo003 { get; set; }

        /// <summary>
        /// 奖惩类别
        /// </summary>
        [SugarColumn(ColumnName = "Mo004", ColumnDescription = "奖惩类别", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mo004 { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [SugarColumn(ColumnName = "Mo005", ColumnDescription = "金额", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mo005 { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [SugarColumn(ColumnName = "Mo006", ColumnDescription = "账号", Length = 30)]
        public string Mo006 { get; set; }
    }
}