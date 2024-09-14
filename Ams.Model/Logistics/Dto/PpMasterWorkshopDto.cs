
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 生产班组
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 12:06:17
    /// </summary>
    public class PpMasterWorkshopQueryDto : PagerInfo 
    {
        /// <summary>
        /// 班组类别 
        /// </summary>        
        public string Md002 { get; set; }
        /// <summary>
        /// 班组代码 
        /// </summary>        
        public string Md003 { get; set; }
        /// <summary>
        /// 班组名称 
        /// </summary>        
        public string Md005 { get; set; }
    }

    /// <summary>
    /// 生产班组
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 12:06:17
    /// </summary>
    public class PpMasterWorkshopDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "班组类别不能为空")]
        //[ExcelColumn(Name = "班组类别")]
        [ExcelColumnName("班组类别")]

        public string Md002 { get; set; }

        [Required(ErrorMessage = "班组代码不能为空")]
        //[ExcelColumn(Name = "班组代码")]
        [ExcelColumnName("班组代码")]

        public string Md003 { get; set; }

        //[ExcelColumn(Name = "语言Key")]
        [ExcelColumnName("语言Key")]

        public string Md004 { get; set; }

        [Required(ErrorMessage = "班组名称不能为空")]
        //[ExcelColumn(Name = "班组名称")]
        [ExcelColumnName("班组名称")]

        public string Md005 { get; set; }

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



        [ExcelColumn(Name = "班组类别")]
        public string Md002Label { get; set; }
    }

    /// <summary>
    /// 生产班组
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 12:06:17
    /// </summary>
    public class PpMasterWorkshopImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "班组类别不能为空")]
        //[ExcelColumn(Name = "班组类别")]
        [ExcelColumnName("班组类别")]
        public string Md002 { get; set; }

        [Required(ErrorMessage = "班组代码不能为空")]
        //[ExcelColumn(Name = "班组代码")]
        [ExcelColumnName("班组代码")]
        public string Md003 { get; set; }

        //[ExcelColumn(Name = "语言Key")]
        [ExcelColumnName("语言Key")]
        public string Md004 { get; set; }

        [Required(ErrorMessage = "班组名称不能为空")]
        //[ExcelColumn(Name = "班组名称")]
        [ExcelColumnName("班组名称")]
        public string Md005 { get; set; }

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
        [ExcelColumn(Name = "班组类别")]
        public string Md002Label { get; set; }
    }

}