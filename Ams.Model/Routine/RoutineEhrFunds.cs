namespace Ams.Model.Routine
{
    /// <summary>
    /// 公积金
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:33:02
    /// </summary>
    [SugarTable("routine_ehr_funds", "公积金")]
    public class RoutineEhrFunds : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long EfSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public long EfParentSfId { get; set; }

        /// <summary>
        /// 生效日
        /// </summary>
        public DateTime? EfEffectiveDate { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [SugarColumn(ColumnName = "EfWorkID", ColumnDescription = "工号 ", Length = 8)]
        public string EfWorkID { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [SugarColumn(ColumnName = "EfFundNo", ColumnDescription = "账号 ", Length = 40)]
        public string EfFundNo { get; set; }

        /// <summary>
        /// 基数
        /// </summary>
        [SugarColumn(ColumnName = "EfFundBase", ColumnDescription = "基数 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal EfFundBase { get; set; }

        /// <summary>
        /// 提取金额
        /// </summary>
        [SugarColumn(ColumnName = "EeExtract", ColumnDescription = "提取金额 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal EeExtract { get; set; }
    }
}