
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 源工时
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:39:17
    /// </summary>
    public class PpSourceManhoursQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Zc002 { get; set; }
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Zc003 { get; set; }
        /// <summary>
        /// 工作中心 
        /// </summary>        
        public string Zc004 { get; set; }
    }

    /// <summary>
    /// 源工时
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:39:17
    /// </summary>
    public class PpSourceManhoursDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Zc002 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Zc003 { get; set; }

        //[ExcelColumn(Name = "工作中心")]
        [ExcelColumnName("工作中心")]

        public string Zc004 { get; set; }

        //[ExcelColumn(Name = "工作中心描述")]
        [ExcelColumnName("工作中心描述")]

        public string Zc005 { get; set; }

        [Required(ErrorMessage = "标准值不能为空")]
        //[ExcelColumn(Name = "标准值")]
        [ExcelColumnName("标准值")]

        public decimal Zc006 { get; set; }

        //[ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]

        public string Zc007 { get; set; }

        [Required(ErrorMessage = "标准值不能为空")]
        //[ExcelColumn(Name = "标准值")]
        [ExcelColumnName("标准值")]

        public decimal Zc008 { get; set; }

        //[ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]

        public string Zc009 { get; set; }

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



        [ExcelColumn(Name = "工厂")]
        public string Zc002Label { get; set; }
        [ExcelColumn(Name = "工作中心")]
        public string Zc004Label { get; set; }
    }

    /// <summary>
    /// 源工时
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:39:17
    /// </summary>
    public class PpSourceManhoursImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Zc002 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Zc003 { get; set; }

        //[ExcelColumn(Name = "工作中心")]
        [ExcelColumnName("工作中心")]
        public string Zc004 { get; set; }

        //[ExcelColumn(Name = "工作中心描述")]
        [ExcelColumnName("工作中心描述")]
        public string Zc005 { get; set; }

        [Required(ErrorMessage = "标准值不能为空")]
        //[ExcelColumn(Name = "标准值")]
        [ExcelColumnName("标准值")]
        public decimal Zc006 { get; set; }

        //[ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]
        public string Zc007 { get; set; }

        [Required(ErrorMessage = "标准值不能为空")]
        //[ExcelColumn(Name = "标准值")]
        [ExcelColumnName("标准值")]
        public decimal Zc008 { get; set; }

        //[ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]
        public string Zc009 { get; set; }

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
        [ExcelColumn(Name = "工厂")]
        public string Zc002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "工作中心")]
        public string Zc004Label { get; set; }
    }

}