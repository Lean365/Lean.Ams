
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 公积金
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:20:44
    /// </summary>
    public class RoutineEhrFundsQueryDto : PagerInfo 
    {
        /// <summary>
        /// 生效日 
        /// </summary>        
        public DateTime? BeginMj003 { get; set; }
        public DateTime? EndMj003 { get; set; }
        /// <summary>
        /// 工号 
        /// </summary>        
        public string Mj004 { get; set; }
    }

    /// <summary>
    /// 公积金
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:20:44
    /// </summary>
    public class RoutineEhrFundsDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]

        public long ParentId { get; set; }

        [Required(ErrorMessage = "生效日不能为空")]
        //[ExcelColumn(Name = "生效日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日")]

        public DateTime? Mj003 { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]

        public string Mj004 { get; set; }

        //[ExcelColumn(Name = "账号")]
        [ExcelColumnName("账号")]

        public string Mj005 { get; set; }

        //[ExcelColumn(Name = "基数")]
        [ExcelColumnName("基数")]

        public decimal Mj006 { get; set; }

        //[ExcelColumn(Name = "提取金额")]
        [ExcelColumnName("提取金额")]

        public decimal Mj007 { get; set; }

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
    /// 公积金
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:20:44
    /// </summary>
    public class RoutineEhrFundsImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long ParentId { get; set; }

        [Required(ErrorMessage = "生效日不能为空")]
        //[ExcelColumn(Name = "生效日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日")]
        public DateTime? Mj003 { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string Mj004 { get; set; }

        //[ExcelColumn(Name = "账号")]
        [ExcelColumnName("账号")]
        public string Mj005 { get; set; }

        //[ExcelColumn(Name = "基数")]
        [ExcelColumnName("基数")]
        public decimal Mj006 { get; set; }

        //[ExcelColumn(Name = "提取金额")]
        [ExcelColumnName("提取金额")]
        public decimal Mj007 { get; set; }

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