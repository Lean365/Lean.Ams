using Ams.Model.Routine;

namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 培训
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:13:49
    /// </summary>
    public class RoutineEhrTrainingMaQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工号 
        /// </summary>        
        public string Mq002 { get; set; }
        /// <summary>
        /// 姓名 
        /// </summary>        
        public string Mq003 { get; set; }
        /// <summary>
        /// 年度 
        /// </summary>        
        public string Mq004 { get; set; }
    }

    /// <summary>
    /// 培训
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:13:49
    /// </summary>
    public class RoutineEhrTrainingMaDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]

        public string Mq002 { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        //[ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]

        public string Mq003 { get; set; }

        //[ExcelColumn(Name = "年度")]
        [ExcelColumnName("年度")]

        public string Mq004 { get; set; }

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
        public List<RoutineEhrTrainingSlvDto> RoutineEhrTrainingSlvNav { get; set; }
        [ExcelColumn(Name = "年度")]
        public string Mq004Label { get; set; }
        [ExcelColumn(Name = "项目")]
        public string Mr003Label { get; set; }
        [ExcelColumn(Name = "结果")]
        public string Mr007Label { get; set; }
    }

    /// <summary>
    /// 培训
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:13:49
    /// </summary>
    public class RoutineEhrTrainingMaImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string Mq002 { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        //[ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]
        public string Mq003 { get; set; }

        //[ExcelColumn(Name = "年度")]
        [ExcelColumnName("年度")]
        public string Mq004 { get; set; }

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
        public List<RoutineEhrTrainingSlvDto> RoutineEhrTrainingSlvNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年度")]
        public string Mq004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "项目")]
        public string Mr003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "结果")]
        public string Mr007Label { get; set; }
    }

}