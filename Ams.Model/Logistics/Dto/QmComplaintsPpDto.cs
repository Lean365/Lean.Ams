
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// PP客诉
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:14:58
    /// </summary>
    public class QmComplaintsPpQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Ma002 { get; set; }
        /// <summary>
        /// 外部客诉No. 
        /// </summary>        
        public string Ma003 { get; set; }
        /// <summary>
        /// 处理日期 
        /// </summary>        
        public DateTime? BeginMa005 { get; set; }
        public DateTime? EndMa005 { get; set; }
    }

    /// <summary>
    /// PP客诉
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:14:58
    /// </summary>
    public class QmComplaintsPpDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Ma002 { get; set; }

        [Required(ErrorMessage = "外部客诉No.不能为空")]
        //[ExcelColumn(Name = "外部客诉No.")]
        [ExcelColumnName("外部客诉No.")]

        public string Ma003 { get; set; }

        //[ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]

        public string Ma004 { get; set; }

        //[ExcelColumn(Name = "处理日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("处理日期")]

        public DateTime? Ma005 { get; set; }

        //[ExcelColumn(Name = "问题描述")]
        [ExcelColumnName("问题描述")]

        public string Ma006 { get; set; }

        //[ExcelColumn(Name = "原因分析")]
        [ExcelColumnName("原因分析")]

        public string Ma007 { get; set; }

        //[ExcelColumn(Name = "作业员")]
        [ExcelColumnName("作业员")]

        public string Ma008 { get; set; }

        //[ExcelColumn(Name = "工位")]
        [ExcelColumnName("工位")]

        public string Ma009 { get; set; }

        //[ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]

        public string Ma010 { get; set; }

        //[ExcelColumn(Name = "改善对策")]
        [ExcelColumnName("改善对策")]

        public string Ma011 { get; set; }

        //[ExcelColumn(Name = "改善文件")]
        [ExcelColumnName("改善文件")]

        public string Ma012 { get; set; }

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
        public string Ma002Label { get; set; }
        [ExcelColumn(Name = "班组")]
        public string Ma004Label { get; set; }
    }

    /// <summary>
    /// PP客诉
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:14:58
    /// </summary>
    public class QmComplaintsPpImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Ma002 { get; set; }

        [Required(ErrorMessage = "外部客诉No.不能为空")]
        //[ExcelColumn(Name = "外部客诉No.")]
        [ExcelColumnName("外部客诉No.")]
        public string Ma003 { get; set; }

        //[ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string Ma004 { get; set; }

        //[ExcelColumn(Name = "处理日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("处理日期")]
        public DateTime? Ma005 { get; set; }

        //[ExcelColumn(Name = "问题描述")]
        [ExcelColumnName("问题描述")]
        public string Ma006 { get; set; }

        //[ExcelColumn(Name = "原因分析")]
        [ExcelColumnName("原因分析")]
        public string Ma007 { get; set; }

        //[ExcelColumn(Name = "作业员")]
        [ExcelColumnName("作业员")]
        public string Ma008 { get; set; }

        //[ExcelColumn(Name = "工位")]
        [ExcelColumnName("工位")]
        public string Ma009 { get; set; }

        //[ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string Ma010 { get; set; }

        //[ExcelColumn(Name = "改善对策")]
        [ExcelColumnName("改善对策")]
        public string Ma011 { get; set; }

        //[ExcelColumn(Name = "改善文件")]
        [ExcelColumnName("改善文件")]
        public string Ma012 { get; set; }

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
        public string Ma002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "班组")]
        public string Ma004Label { get; set; }
    }

}