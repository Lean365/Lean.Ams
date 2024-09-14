namespace Ams.Model.Routine
{
    /// <summary>
    /// 公积金
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:20:44
    /// </summary>
    [SugarTable("routine_ehr_funds", "公积金")]
    public class RoutineEhrFunds : SysBase
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
        /// 生效日
        /// </summary>
        public DateTime? Mj003 { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [SugarColumn(ColumnName = "Mj004", ColumnDescription = "工号", Length = 8, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mj004 { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [SugarColumn(ColumnName = "Mj005", ColumnDescription = "账号", Length = 40)]
        public string Mj005 { get; set; }

        /// <summary>
        /// 基数
        /// </summary>
        [SugarColumn(ColumnName = "Mj006", ColumnDescription = "基数", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mj006 { get; set; }

        /// <summary>
        /// 提取金额
        /// </summary>
        [SugarColumn(ColumnName = "Mj007", ColumnDescription = "提取金额", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mj007 { get; set; }
    }
}