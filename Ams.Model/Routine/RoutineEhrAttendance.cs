namespace Ams.Model.Routine
{
    /// <summary>
    /// 考勤
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:31:57
    /// </summary>
    [SugarTable("routine_ehr_attendance", "考勤")]
    public class RoutineEhrAttendance : SysBase
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
        /// 班别
        /// </summary>
        [SugarColumn(ColumnName = "EeShiftsType", ColumnDescription = "班别 ", DefaultValue = "0")]
        public int EeShiftsType { get; set; }

        /// <summary>
        /// 假日别
        /// </summary>
        [SugarColumn(ColumnName = "EeHolidayType", ColumnDescription = "假日别 ", DefaultValue = "0")]
        public int? EeHolidayType { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? EeDate { get; set; }

        /// <summary>
        /// 上班时间
        /// </summary>
        [SugarColumn(ColumnName = "EeClockIn", ColumnDescription = "上班时间 ", Length = 16)]
        public string EeClockIn { get; set; }

        /// <summary>
        /// 下班时间
        /// </summary>
        [SugarColumn(ColumnName = "EeClockOff", ColumnDescription = "下班时间 ", Length = 16)]
        public string EeClockOff { get; set; }

        /// <summary>
        /// 加班上班时间
        /// </summary>
        [SugarColumn(ColumnName = "EeOvertimeIn", ColumnDescription = "加班上班时间 ", Length = 16)]
        public string EeOvertimeIn { get; set; }

        /// <summary>
        /// 加班下班时间
        /// </summary>
        [SugarColumn(ColumnName = "EeOvertimeOff", ColumnDescription = "加班下班时间 ", Length = 16)]
        public string EeOvertimeOff { get; set; }

        /// <summary>
        /// 迟到分钟
        /// </summary>
        [SugarColumn(ColumnName = "EeLateIn", ColumnDescription = "迟到分钟 ", DefaultValue = "0")]
        public int? EeLateIn { get; set; }

        /// <summary>
        /// 迟到否
        /// </summary>
        [SugarColumn(ColumnName = "EeLate", ColumnDescription = "迟到否 ", DefaultValue = "0")]
        public int? EeLate { get; set; }

        /// <summary>
        /// 早退分钟
        /// </summary>
        [SugarColumn(ColumnName = "EeEarlyOff", ColumnDescription = "早退分钟 ", DefaultValue = "0")]
        public int? EeEarlyOff { get; set; }

        /// <summary>
        /// 早退否
        /// </summary>
        [SugarColumn(ColumnName = "EeEarly", ColumnDescription = "早退否 ", DefaultValue = "0")]
        public int? EeEarly { get; set; }

        /// <summary>
        /// 假日加班时数
        /// </summary>
        [SugarColumn(ColumnName = "EeHolidayOvertimeHours", ColumnDescription = "假日加班时数 ", DefaultValue = "0")]
        public int? EeHolidayOvertimeHours { get; set; }

        /// <summary>
        /// 异常
        /// </summary>
        [SugarColumn(ColumnName = "EeAbnormal", ColumnDescription = "异常 ", DefaultValue = "0")]
        public int? EeAbnormal { get; set; }

        /// <summary>
        /// 异常原因
        /// </summary>
        [SugarColumn(ColumnName = "EeEeAbnormalCause", ColumnDescription = "异常原因 ", Length = 255)]
        public string EeEeAbnormalCause { get; set; }

        /// <summary>
        /// 已有请假信息
        /// </summary>
        [SugarColumn(ColumnName = "EeLeaveType", ColumnDescription = "已有请假信息 ", DefaultValue = "0")]
        public int? EeLeaveType { get; set; }

        /// <summary>
        /// 正常加班
        /// </summary>
        [SugarColumn(ColumnName = "EeNormalOvertimeHours", ColumnDescription = "正常加班 ", DefaultValue = "0")]
        public int? EeNormalOvertimeHours { get; set; }

        /// <summary>
        /// 节日加班
        /// </summary>
        [SugarColumn(ColumnName = "EeFestivalOvertimeHours", ColumnDescription = "节日加班 ", DefaultValue = "0")]
        public int? EeFestivalOvertimeHours { get; set; }
    }
}