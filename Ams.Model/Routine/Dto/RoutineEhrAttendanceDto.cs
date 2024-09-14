
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 考勤
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:26:15
    /// </summary>
    public class RoutineEhrAttendanceQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工号 
        /// </summary>        
        public string Mg003 { get; set; }
        /// <summary>
        /// 班别 
        /// </summary>        
        public int? Mg004 { get; set; }
        /// <summary>
        /// 日期 
        /// </summary>        
        public DateTime? BeginMg006 { get; set; }
        public DateTime? EndMg006 { get; set; }
    }

    /// <summary>
    /// 考勤
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:26:15
    /// </summary>
    public class RoutineEhrAttendanceDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]

        public long ParentId { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]

        public string Mg003 { get; set; }

        [Required(ErrorMessage = "班别不能为空")]
        //[ExcelColumn(Name = "班别")]
        [ExcelColumnName("班别")]

        public int Mg004 { get; set; }

        [Required(ErrorMessage = "假日别不能为空")]
        //[ExcelColumn(Name = "假日别")]
        [ExcelColumnName("假日别")]

        public int Mg005 { get; set; }

        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]

        public DateTime? Mg006 { get; set; }

        //[ExcelColumn(Name = "上班时间")]
        [ExcelColumnName("上班时间")]

        public string Mg007 { get; set; }

        //[ExcelColumn(Name = "下班时间")]
        [ExcelColumnName("下班时间")]

        public string Mg008 { get; set; }

        //[ExcelColumn(Name = "加班上班时间")]
        [ExcelColumnName("加班上班时间")]

        public string Mg009 { get; set; }

        //[ExcelColumn(Name = "加班下班时间")]
        [ExcelColumnName("加班下班时间")]

        public string Mg010 { get; set; }

        [Required(ErrorMessage = "迟到分钟不能为空")]
        //[ExcelColumn(Name = "迟到分钟")]
        [ExcelColumnName("迟到分钟")]

        public int Mg011 { get; set; }

        [Required(ErrorMessage = "迟到否不能为空")]
        //[ExcelColumn(Name = "迟到否")]
        [ExcelColumnName("迟到否")]

        public int Mg012 { get; set; }

        [Required(ErrorMessage = "早退分钟不能为空")]
        //[ExcelColumn(Name = "早退分钟")]
        [ExcelColumnName("早退分钟")]

        public int Mg013 { get; set; }

        [Required(ErrorMessage = "早退否不能为空")]
        //[ExcelColumn(Name = "早退否")]
        [ExcelColumnName("早退否")]

        public int Mg014 { get; set; }

        [Required(ErrorMessage = "假日加班时数不能为空")]
        //[ExcelColumn(Name = "假日加班时数")]
        [ExcelColumnName("假日加班时数")]

        public int Mg015 { get; set; }

        [Required(ErrorMessage = "异常不能为空")]
        //[ExcelColumn(Name = "异常")]
        [ExcelColumnName("异常")]

        public int Mg016 { get; set; }

        //[ExcelColumn(Name = "异常原因")]
        [ExcelColumnName("异常原因")]

        public string Mg017 { get; set; }

        [Required(ErrorMessage = "已有请假信息不能为空")]
        //[ExcelColumn(Name = "已有请假信息")]
        [ExcelColumnName("已有请假信息")]

        public int Mg018 { get; set; }

        [Required(ErrorMessage = "正常加班不能为空")]
        //[ExcelColumn(Name = "正常加班")]
        [ExcelColumnName("正常加班")]

        public int Mg019 { get; set; }

        [Required(ErrorMessage = "节日加班不能为空")]
        //[ExcelColumn(Name = "节日加班")]
        [ExcelColumnName("节日加班")]

        public int Mg020 { get; set; }

        [ExcelIgnore]

        public string Ref01 { get; set; }

        [ExcelIgnore]

        public string Ref02 { get; set; }

        [ExcelIgnore]

        public string Ref03 { get; set; }

        [ExcelIgnore]

        public decimal Ref04 { get; set; }

        [ExcelIgnore]

        public decimal Ref05 { get; set; }

        [ExcelIgnore]

        public decimal Ref06 { get; set; }

        [ExcelIgnore]

        public string Udf01 { get; set; }

        [ExcelIgnore]

        public string Udf02 { get; set; }

        [ExcelIgnore]

        public string Udf03 { get; set; }

        [ExcelIgnore]

        public string Udf04 { get; set; }

        [ExcelIgnore]

        public string Udf05 { get; set; }

        [ExcelIgnore]

        public string Udf06 { get; set; }

        [ExcelIgnore]

        public int? Udf51 { get; set; }

        [ExcelIgnore]

        public int? Udf52 { get; set; }

        [ExcelIgnore]

        public int? Udf53 { get; set; }

        [ExcelIgnore]

        public decimal Udf54 { get; set; }

        [ExcelIgnore]

        public decimal Udf55 { get; set; }

        [ExcelIgnore]

        public decimal Udf56 { get; set; }

        [ExcelIgnore]

        public int? IsDeleted { get; set; }

        [ExcelIgnore]

        public string Remark { get; set; }

        [ExcelIgnore]

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "班别")]
        public string Mg004Label { get; set; }
    }

    /// <summary>
    /// 考勤
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:26:15
    /// </summary>
    public class RoutineEhrAttendanceImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long ParentId { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string Mg003 { get; set; }

        [Required(ErrorMessage = "班别不能为空")]
        //[ExcelColumn(Name = "班别")]
        [ExcelColumnName("班别")]
        public int Mg004 { get; set; }

        [Required(ErrorMessage = "假日别不能为空")]
        //[ExcelColumn(Name = "假日别")]
        [ExcelColumnName("假日别")]
        public int Mg005 { get; set; }

        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Mg006 { get; set; }

        //[ExcelColumn(Name = "上班时间")]
        [ExcelColumnName("上班时间")]
        public string Mg007 { get; set; }

        //[ExcelColumn(Name = "下班时间")]
        [ExcelColumnName("下班时间")]
        public string Mg008 { get; set; }

        //[ExcelColumn(Name = "加班上班时间")]
        [ExcelColumnName("加班上班时间")]
        public string Mg009 { get; set; }

        //[ExcelColumn(Name = "加班下班时间")]
        [ExcelColumnName("加班下班时间")]
        public string Mg010 { get; set; }

        [Required(ErrorMessage = "迟到分钟不能为空")]
        //[ExcelColumn(Name = "迟到分钟")]
        [ExcelColumnName("迟到分钟")]
        public int Mg011 { get; set; }

        [Required(ErrorMessage = "迟到否不能为空")]
        //[ExcelColumn(Name = "迟到否")]
        [ExcelColumnName("迟到否")]
        public int Mg012 { get; set; }

        [Required(ErrorMessage = "早退分钟不能为空")]
        //[ExcelColumn(Name = "早退分钟")]
        [ExcelColumnName("早退分钟")]
        public int Mg013 { get; set; }

        [Required(ErrorMessage = "早退否不能为空")]
        //[ExcelColumn(Name = "早退否")]
        [ExcelColumnName("早退否")]
        public int Mg014 { get; set; }

        [Required(ErrorMessage = "假日加班时数不能为空")]
        //[ExcelColumn(Name = "假日加班时数")]
        [ExcelColumnName("假日加班时数")]
        public int Mg015 { get; set; }

        [Required(ErrorMessage = "异常不能为空")]
        //[ExcelColumn(Name = "异常")]
        [ExcelColumnName("异常")]
        public int Mg016 { get; set; }

        //[ExcelColumn(Name = "异常原因")]
        [ExcelColumnName("异常原因")]
        public string Mg017 { get; set; }

        [Required(ErrorMessage = "已有请假信息不能为空")]
        //[ExcelColumn(Name = "已有请假信息")]
        [ExcelColumnName("已有请假信息")]
        public int Mg018 { get; set; }

        [Required(ErrorMessage = "正常加班不能为空")]
        //[ExcelColumn(Name = "正常加班")]
        [ExcelColumnName("正常加班")]
        public int Mg019 { get; set; }

        [Required(ErrorMessage = "节日加班不能为空")]
        //[ExcelColumn(Name = "节日加班")]
        [ExcelColumnName("节日加班")]
        public int Mg020 { get; set; }

        [ExcelIgnore]
        public string Ref01 { get; set; }

        [ExcelIgnore]
        public string Ref02 { get; set; }

        [ExcelIgnore]
        public string Ref03 { get; set; }

        [ExcelIgnore]
        public decimal Ref04 { get; set; }

        [ExcelIgnore]
        public decimal Ref05 { get; set; }

        [ExcelIgnore]
        public decimal Ref06 { get; set; }

        [ExcelIgnore]
        public string Udf01 { get; set; }

        [ExcelIgnore]
        public string Udf02 { get; set; }

        [ExcelIgnore]
        public string Udf03 { get; set; }

        [ExcelIgnore]
        public string Udf04 { get; set; }

        [ExcelIgnore]
        public string Udf05 { get; set; }

        [ExcelIgnore]
        public string Udf06 { get; set; }

        [ExcelIgnore]
        public int? Udf51 { get; set; }

        [ExcelIgnore]
        public int? Udf52 { get; set; }

        [ExcelIgnore]
        public int? Udf53 { get; set; }

        [ExcelIgnore]
        public decimal Udf54 { get; set; }

        [ExcelIgnore]
        public decimal Udf55 { get; set; }

        [ExcelIgnore]
        public decimal Udf56 { get; set; }

        [ExcelIgnore]
        public int? IsDeleted { get; set; }

        [ExcelIgnore]
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
        [ExcelColumn(Name = "班别")]
        public string Mg004Label { get; set; }
    }

}