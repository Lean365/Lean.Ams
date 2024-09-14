
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 社保
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:14:24
    /// </summary>
    public class RoutineEhrSocialSecurityQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工号 
        /// </summary>        
        public string Mp003 { get; set; }
        /// <summary>
        /// 生效日 
        /// </summary>        
        public DateTime? BeginMp004 { get; set; }
        public DateTime? EndMp004 { get; set; }
    }

    /// <summary>
    /// 社保
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:14:24
    /// </summary>
    public class RoutineEhrSocialSecurityDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]

        public long ParentId { get; set; }

        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]

        public string Mp003 { get; set; }

        //[ExcelColumn(Name = "生效日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日")]

        public DateTime? Mp004 { get; set; }

        //[ExcelColumn(Name = "养老")]
        [ExcelColumnName("养老")]

        public decimal Mp005 { get; set; }

        //[ExcelColumn(Name = "医疗")]
        [ExcelColumnName("医疗")]

        public decimal Mp006 { get; set; }

        //[ExcelColumn(Name = "工伤")]
        [ExcelColumnName("工伤")]

        public decimal Mp007 { get; set; }

        //[ExcelColumn(Name = "失业")]
        [ExcelColumnName("失业")]

        public decimal Mp008 { get; set; }

        //[ExcelColumn(Name = "生育")]
        [ExcelColumnName("生育")]

        public decimal Mp009 { get; set; }

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



    }

    /// <summary>
    /// 社保
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:14:24
    /// </summary>
    public class RoutineEhrSocialSecurityImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long ParentId { get; set; }

        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string Mp003 { get; set; }

        //[ExcelColumn(Name = "生效日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日")]
        public DateTime? Mp004 { get; set; }

        //[ExcelColumn(Name = "养老")]
        [ExcelColumnName("养老")]
        public decimal Mp005 { get; set; }

        //[ExcelColumn(Name = "医疗")]
        [ExcelColumnName("医疗")]
        public decimal Mp006 { get; set; }

        //[ExcelColumn(Name = "工伤")]
        [ExcelColumnName("工伤")]
        public decimal Mp007 { get; set; }

        //[ExcelColumn(Name = "失业")]
        [ExcelColumnName("失业")]
        public decimal Mp008 { get; set; }

        //[ExcelColumn(Name = "生育")]
        [ExcelColumnName("生育")]
        public decimal Mp009 { get; set; }

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



    }

}