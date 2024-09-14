
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 奖惩
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:16:00
    /// </summary>
    public class RoutineEhrRewardPenaltiesQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工号 
        /// </summary>        
        public string Mo002 { get; set; }
        /// <summary>
        /// 姓名 
        /// </summary>        
        public string Mo003 { get; set; }
        /// <summary>
        /// 奖惩类别 
        /// </summary>        
        public int? Mo004 { get; set; }
    }

    /// <summary>
    /// 奖惩
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:16:00
    /// </summary>
    public class RoutineEhrRewardPenaltiesDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]

        public string Mo002 { get; set; }

        //[ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]

        public string Mo003 { get; set; }

        [Required(ErrorMessage = "奖惩类别不能为空")]
        //[ExcelColumn(Name = "奖惩类别")]
        [ExcelColumnName("奖惩类别")]

        public int Mo004 { get; set; }

        [Required(ErrorMessage = "金额不能为空")]
        //[ExcelColumn(Name = "金额")]
        [ExcelColumnName("金额")]

        public decimal Mo005 { get; set; }

        //[ExcelColumn(Name = "账号")]
        [ExcelColumnName("账号")]

        public string Mo006 { get; set; }

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

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelIgnore]

        public int IsDeleted { get; set; }

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



        [ExcelColumn(Name = "奖惩类别")]
        public string Mo004Label { get; set; }
    }

    /// <summary>
    /// 奖惩
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:16:00
    /// </summary>
    public class RoutineEhrRewardPenaltiesImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string Mo002 { get; set; }

        //[ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]
        public string Mo003 { get; set; }

        [Required(ErrorMessage = "奖惩类别不能为空")]
        //[ExcelColumn(Name = "奖惩类别")]
        [ExcelColumnName("奖惩类别")]
        public int Mo004 { get; set; }

        [Required(ErrorMessage = "金额不能为空")]
        //[ExcelColumn(Name = "金额")]
        [ExcelColumnName("金额")]
        public decimal Mo005 { get; set; }

        //[ExcelColumn(Name = "账号")]
        [ExcelColumnName("账号")]
        public string Mo006 { get; set; }

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

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelIgnore]
        public int IsDeleted { get; set; }

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
        [ExcelColumn(Name = "奖惩类别")]
        public string Mo004Label { get; set; }
    }

}