
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 考勤
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:31:57
    /// </summary>
    public class RoutineEhrAttendanceQueryDto : PagerInfo 
    {
        public string EeWorkID { get; set; }
    }

    /// <summary>
    /// 考勤
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:31:57
    /// </summary>
    public class RoutineEhrAttendanceDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EeSfId { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long EeParentSfId { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        [ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string EeWorkID { get; set; }

        [Required(ErrorMessage = "班别不能为空")]
        [ExcelColumn(Name = "班别")]
        [ExcelColumnName("班别")]
        public int EeShiftsType { get; set; }

        [ExcelColumn(Name = "假日别")]
        [ExcelColumnName("假日别")]
        public int? EeHolidayType { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? EeDate { get; set; }

        [ExcelColumn(Name = "上班时间")]
        [ExcelColumnName("上班时间")]
        public string EeClockIn { get; set; }

        [ExcelColumn(Name = "下班时间")]
        [ExcelColumnName("下班时间")]
        public string EeClockOff { get; set; }

        [ExcelColumn(Name = "加班上班时间")]
        [ExcelColumnName("加班上班时间")]
        public string EeOvertimeIn { get; set; }

        [ExcelColumn(Name = "加班下班时间")]
        [ExcelColumnName("加班下班时间")]
        public string EeOvertimeOff { get; set; }

        [ExcelColumn(Name = "迟到分钟")]
        [ExcelColumnName("迟到分钟")]
        public int? EeLateIn { get; set; }

        [ExcelColumn(Name = "迟到否")]
        [ExcelColumnName("迟到否")]
        public int? EeLate { get; set; }

        [ExcelColumn(Name = "早退分钟")]
        [ExcelColumnName("早退分钟")]
        public int? EeEarlyOff { get; set; }

        [ExcelColumn(Name = "早退否")]
        [ExcelColumnName("早退否")]
        public int? EeEarly { get; set; }

        [ExcelColumn(Name = "假日加班时数")]
        [ExcelColumnName("假日加班时数")]
        public int? EeHolidayOvertimeHours { get; set; }

        [ExcelColumn(Name = "异常")]
        [ExcelColumnName("异常")]
        public int? EeAbnormal { get; set; }

        [ExcelColumn(Name = "异常原因")]
        [ExcelColumnName("异常原因")]
        public string EeEeAbnormalCause { get; set; }

        [ExcelColumn(Name = "已有请假信息")]
        [ExcelColumnName("已有请假信息")]
        public int? EeLeaveType { get; set; }

        [ExcelColumn(Name = "正常加班")]
        [ExcelColumnName("正常加班")]
        public int? EeNormalOvertimeHours { get; set; }

        [ExcelColumn(Name = "节日加班")]
        [ExcelColumnName("节日加班")]
        public int? EeFestivalOvertimeHours { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 考勤
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:31:57
    /// </summary>
    public class RoutineEhrAttendanceImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EeSfId { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long EeParentSfId { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        [ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string EeWorkID { get; set; }

        [Required(ErrorMessage = "班别不能为空")]
        [ExcelColumn(Name = "班别")]
        [ExcelColumnName("班别")]
        public int EeShiftsType { get; set; }

        [ExcelColumn(Name = "假日别")]
        [ExcelColumnName("假日别")]
        public int? EeHolidayType { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? EeDate { get; set; }

        [ExcelColumn(Name = "上班时间")]
        [ExcelColumnName("上班时间")]
        public string EeClockIn { get; set; }

        [ExcelColumn(Name = "下班时间")]
        [ExcelColumnName("下班时间")]
        public string EeClockOff { get; set; }

        [ExcelColumn(Name = "加班上班时间")]
        [ExcelColumnName("加班上班时间")]
        public string EeOvertimeIn { get; set; }

        [ExcelColumn(Name = "加班下班时间")]
        [ExcelColumnName("加班下班时间")]
        public string EeOvertimeOff { get; set; }

        [ExcelColumn(Name = "迟到分钟")]
        [ExcelColumnName("迟到分钟")]
        public int? EeLateIn { get; set; }

        [ExcelColumn(Name = "迟到否")]
        [ExcelColumnName("迟到否")]
        public int? EeLate { get; set; }

        [ExcelColumn(Name = "早退分钟")]
        [ExcelColumnName("早退分钟")]
        public int? EeEarlyOff { get; set; }

        [ExcelColumn(Name = "早退否")]
        [ExcelColumnName("早退否")]
        public int? EeEarly { get; set; }

        [ExcelColumn(Name = "假日加班时数")]
        [ExcelColumnName("假日加班时数")]
        public int? EeHolidayOvertimeHours { get; set; }

        [ExcelColumn(Name = "异常")]
        [ExcelColumnName("异常")]
        public int? EeAbnormal { get; set; }

        [ExcelColumn(Name = "异常原因")]
        [ExcelColumnName("异常原因")]
        public string EeEeAbnormalCause { get; set; }

        [ExcelColumn(Name = "已有请假信息")]
        [ExcelColumnName("已有请假信息")]
        public int? EeLeaveType { get; set; }

        [ExcelColumn(Name = "正常加班")]
        [ExcelColumnName("正常加班")]
        public int? EeNormalOvertimeHours { get; set; }

        [ExcelColumn(Name = "节日加班")]
        [ExcelColumnName("节日加班")]
        public int? EeFestivalOvertimeHours { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}