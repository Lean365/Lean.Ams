
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 不良统计
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/12 17:19:12
    /// </summary>
    public class PpDefectTotalQueryDto : PagerInfo 
    {
        /// <summary>
        /// 批次 
        /// </summary>        
        public string Me002 { get; set; }
        /// <summary>
        /// 机种 
        /// </summary>        
        public string Me003 { get; set; }
        /// <summary>
        /// 班组 
        /// </summary>        
        public string Me004 { get; set; }
        /// <summary>
        /// 日期 
        /// </summary>        
        public DateTime? BeginMe005 { get; set; }
        public DateTime? EndMe005 { get; set; }
    }

    /// <summary>
    /// 不良统计
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/12 17:19:12
    /// </summary>
    public class PpDefectTotalDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? Id { get; set; }

        //[ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]

        public string Me002 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]

        public string Me003 { get; set; }

        //[ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]

        public string Me004 { get; set; }

        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]

        public DateTime? Me005 { get; set; }

        //[ExcelColumn(Name = "工单")]
        [ExcelColumnName("工单")]

        public string Me006 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]

        public int Me007 { get; set; }

        [Required(ErrorMessage = "生产不能为空")]
        //[ExcelColumn(Name = "生产")]
        [ExcelColumnName("生产")]

        public int Me008 { get; set; }

        [Required(ErrorMessage = "无不良数不能为空")]
        //[ExcelColumn(Name = "无不良数")]
        [ExcelColumnName("无不良数")]

        public int Me009 { get; set; }

        [Required(ErrorMessage = "不良总数不能为空")]
        //[ExcelColumn(Name = "不良总数")]
        [ExcelColumnName("不良总数")]

        public int Me010 { get; set; }

        [Required(ErrorMessage = "直行率不能为空")]
        //[ExcelColumn(Name = "直行率")]
        [ExcelColumnName("直行率")]

        public decimal Me011 { get; set; }

        [Required(ErrorMessage = "不良率不能为空")]
        //[ExcelColumn(Name = "不良率")]
        [ExcelColumnName("不良率")]

        public decimal Me012 { get; set; }

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



    }

    /// <summary>
    /// 不良统计
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/12 17:19:12
    /// </summary>
    public class PpDefectTotalImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? Id { get; set; }

        //[ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string Me002 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Me003 { get; set; }

        //[ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string Me004 { get; set; }

        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Me005 { get; set; }

        //[ExcelColumn(Name = "工单")]
        [ExcelColumnName("工单")]
        public string Me006 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public int Me007 { get; set; }

        [Required(ErrorMessage = "生产不能为空")]
        //[ExcelColumn(Name = "生产")]
        [ExcelColumnName("生产")]
        public int Me008 { get; set; }

        [Required(ErrorMessage = "无不良数不能为空")]
        //[ExcelColumn(Name = "无不良数")]
        [ExcelColumnName("无不良数")]
        public int Me009 { get; set; }

        [Required(ErrorMessage = "不良总数不能为空")]
        //[ExcelColumn(Name = "不良总数")]
        [ExcelColumnName("不良总数")]
        public int Me010 { get; set; }

        [Required(ErrorMessage = "直行率不能为空")]
        //[ExcelColumn(Name = "直行率")]
        [ExcelColumnName("直行率")]
        public decimal Me011 { get; set; }

        [Required(ErrorMessage = "不良率不能为空")]
        //[ExcelColumn(Name = "不良率")]
        [ExcelColumnName("不良率")]
        public decimal Me012 { get; set; }

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



    }

}