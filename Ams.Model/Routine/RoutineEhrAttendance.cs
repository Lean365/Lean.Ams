namespace Ams.Model.Routine
{
    /// <summary>
    /// 考勤
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:26:15
    /// </summary>
    [SugarTable("routine_ehr_attendance", "考勤")]
    public class RoutineEhrAttendance : SysBase
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
        [SugarColumn(ColumnName = "Mg003", ColumnDescription = "工号", Length = 8, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mg003 { get; set; }

        /// <summary>
        /// 班别
        /// </summary>
        [SugarColumn(ColumnName = "Mg004", ColumnDescription = "班别", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg004 { get; set; }

        /// <summary>
        /// 假日别
        /// </summary>
        [SugarColumn(ColumnName = "Mg005", ColumnDescription = "假日别", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg005 { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Mg006 { get; set; }

        /// <summary>
        /// 上班时间
        /// </summary>
        [SugarColumn(ColumnName = "Mg007", ColumnDescription = "上班时间", Length = 16)]
        public string Mg007 { get; set; }

        /// <summary>
        /// 下班时间
        /// </summary>
        [SugarColumn(ColumnName = "Mg008", ColumnDescription = "下班时间", Length = 16)]
        public string Mg008 { get; set; }

        /// <summary>
        /// 加班上班时间
        /// </summary>
        [SugarColumn(ColumnName = "Mg009", ColumnDescription = "加班上班时间", Length = 16)]
        public string Mg009 { get; set; }

        /// <summary>
        /// 加班下班时间
        /// </summary>
        [SugarColumn(ColumnName = "Mg010", ColumnDescription = "加班下班时间", Length = 16)]
        public string Mg010 { get; set; }

        /// <summary>
        /// 迟到分钟
        /// </summary>
        [SugarColumn(ColumnName = "Mg011", ColumnDescription = "迟到分钟", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg011 { get; set; }

        /// <summary>
        /// 迟到否
        /// </summary>
        [SugarColumn(ColumnName = "Mg012", ColumnDescription = "迟到否", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg012 { get; set; }

        /// <summary>
        /// 早退分钟
        /// </summary>
        [SugarColumn(ColumnName = "Mg013", ColumnDescription = "早退分钟", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg013 { get; set; }

        /// <summary>
        /// 早退否
        /// </summary>
        [SugarColumn(ColumnName = "Mg014", ColumnDescription = "早退否", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg014 { get; set; }

        /// <summary>
        /// 假日加班时数
        /// </summary>
        [SugarColumn(ColumnName = "Mg015", ColumnDescription = "假日加班时数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg015 { get; set; }

        /// <summary>
        /// 异常
        /// </summary>
        [SugarColumn(ColumnName = "Mg016", ColumnDescription = "异常", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg016 { get; set; }

        /// <summary>
        /// 异常原因
        /// </summary>
        [SugarColumn(ColumnName = "Mg017", ColumnDescription = "异常原因", Length = 255)]
        public string Mg017 { get; set; }

        /// <summary>
        /// 已有请假信息
        /// </summary>
        [SugarColumn(ColumnName = "Mg018", ColumnDescription = "已有请假信息", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg018 { get; set; }

        /// <summary>
        /// 正常加班
        /// </summary>
        [SugarColumn(ColumnName = "Mg019", ColumnDescription = "正常加班", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg019 { get; set; }

        /// <summary>
        /// 节日加班
        /// </summary>
        [SugarColumn(ColumnName = "Mg020", ColumnDescription = "节日加班", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg020 { get; set; }
    }
}