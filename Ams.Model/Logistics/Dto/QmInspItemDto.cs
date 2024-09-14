
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 检测项目
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:48:49
    /// </summary>
    public class QmInspItemQueryDto : PagerInfo 
    {
        /// <summary>
        /// 项目代码 
        /// </summary>        
        public string Mh002 { get; set; }
        /// <summary>
        /// 项目名称 
        /// </summary>        
        public string Mh003 { get; set; }
        /// <summary>
        /// 项目类别 
        /// </summary>        
        public string Mh004 { get; set; }
        /// <summary>
        /// 检查工具 
        /// </summary>        
        public string Mh005 { get; set; }
    }

    /// <summary>
    /// 检测项目
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:48:49
    /// </summary>
    public class QmInspItemDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "项目代码不能为空")]
        //[ExcelColumn(Name = "项目代码")]
        [ExcelColumnName("项目代码")]

        public string Mh002 { get; set; }

        //[ExcelColumn(Name = "项目名称")]
        [ExcelColumnName("项目名称")]

        public string Mh003 { get; set; }

        //[ExcelColumn(Name = "项目类别")]
        [ExcelColumnName("项目类别")]

        public string Mh004 { get; set; }

        //[ExcelColumn(Name = "检查工具")]
        [ExcelColumnName("检查工具")]

        public string Mh005 { get; set; }

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



        [ExcelColumn(Name = "检查工具")]
        public string Mh005Label { get; set; }
    }

    /// <summary>
    /// 检测项目
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:48:49
    /// </summary>
    public class QmInspItemImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "项目代码不能为空")]
        //[ExcelColumn(Name = "项目代码")]
        [ExcelColumnName("项目代码")]
        public string Mh002 { get; set; }

        //[ExcelColumn(Name = "项目名称")]
        [ExcelColumnName("项目名称")]
        public string Mh003 { get; set; }

        //[ExcelColumn(Name = "项目类别")]
        [ExcelColumnName("项目类别")]
        public string Mh004 { get; set; }

        //[ExcelColumn(Name = "检查工具")]
        [ExcelColumnName("检查工具")]
        public string Mh005 { get; set; }

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
        [ExcelColumn(Name = "检查工具")]
        public string Mh005Label { get; set; }
    }

}