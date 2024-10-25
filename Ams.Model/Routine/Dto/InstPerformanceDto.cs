
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 机构目标
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 10:55:04
    /// </summary>
    public class InstPerformanceQueryDto : PagerInfo 
    {
        /// <summary>
        /// 期间 
        /// </summary>        
        public string Md002 { get; set; }
        /// <summary>
        /// 公司 
        /// </summary>        
        public string Md003 { get; set; }
    }

    /// <summary>
    /// 机构目标
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 10:55:04
    /// </summary>
    public class InstPerformanceDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? Id { get; set; }

        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]

        public string Md002 { get; set; }

        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]

        public string Md003 { get; set; }

        //[ExcelColumn(Name = "翻译键值")]
        [ExcelColumnName("翻译键值")]

        public string Md004 { get; set; }

        //[ExcelColumn(Name = "目标标识")]
        [ExcelColumnName("目标标识")]

        public string Md005 { get; set; }

        [ExcelIgnore]

        public string Remark { get; set; }

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

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "期间")]
        public string Md002Label { get; set; }
        [ExcelColumn(Name = "公司")]
        public string Md003Label { get; set; }
    }

    /// <summary>
    /// 机构目标
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 10:55:04
    /// </summary>
    public class InstPerformanceImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? Id { get; set; }

        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string Md002 { get; set; }

        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string Md003 { get; set; }

        //[ExcelColumn(Name = "翻译键值")]
        [ExcelColumnName("翻译键值")]
        public string Md004 { get; set; }

        //[ExcelColumn(Name = "目标标识")]
        [ExcelColumnName("目标标识")]
        public string Md005 { get; set; }

        [ExcelIgnore]
        public string Remark { get; set; }

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
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "期间")]
        public string Md002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司")]
        public string Md003Label { get; set; }
    }

}