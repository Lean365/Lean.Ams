
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 组立明细
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:52
    /// </summary>
    public class PpOutputAssySlvQueryDto : PagerInfo 
    {
        /// <summary>
        /// 生产时段 
        /// </summary>        
        public string Mmb002 { get; set; }
    }

    /// <summary>
    /// 组立明细
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:52
    /// </summary>
    public class PpOutputAssySlvDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        //[ExcelColumn(Name = "父Id")]
        [ExcelColumnName("父Id")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? ParentId { get; set; }

        [Required(ErrorMessage = "生产时段不能为空")]
        //[ExcelColumn(Name = "生产时段")]
        [ExcelColumnName("生产时段")]

        public string Mmb002 { get; set; }

        [Required(ErrorMessage = "实际产能不能为空")]
        //[ExcelColumn(Name = "实际产能")]
        [ExcelColumnName("实际产能")]

        public int Mmb003 { get; set; }

        [Required(ErrorMessage = "停线时间不能为空")]
        //[ExcelColumn(Name = "停线时间")]
        [ExcelColumnName("停线时间")]

        public int Mmb004 { get; set; }

        //[ExcelColumn(Name = "停线")]
        [ExcelColumnName("停线")]

        public string Mmb005 { get; set; }

        //[ExcelColumn(Name = "停线说明")]
        [ExcelColumnName("停线说明")]

        public string Mmb006 { get; set; }

        //[ExcelColumn(Name = "未达成")]
        [ExcelColumnName("未达成")]

        public string Mmb007 { get; set; }

        //[ExcelColumn(Name = "未达成说明")]
        [ExcelColumnName("未达成说明")]

        public string Mmb008 { get; set; }

        [Required(ErrorMessage = "实际工数不能为空")]
        //[ExcelColumn(Name = "实际工数")]
        [ExcelColumnName("实际工数")]

        public int Mmb009 { get; set; }

        [Required(ErrorMessage = "投入工数不能为空")]
        //[ExcelColumn(Name = "投入工数")]
        [ExcelColumnName("投入工数")]

        public decimal Mmb010 { get; set; }

        [Required(ErrorMessage = "工时差异不能为空")]
        //[ExcelColumn(Name = "工时差异")]
        [ExcelColumnName("工时差异")]

        public decimal Mmb011 { get; set; }

        [Required(ErrorMessage = "产能差异不能为空")]
        //[ExcelColumn(Name = "产能差异")]
        [ExcelColumnName("产能差异")]

        public decimal Mmb012 { get; set; }

        [Required(ErrorMessage = "达成率不能为空")]
        //[ExcelColumn(Name = "达成率")]
        [ExcelColumnName("达成率")]

        public decimal Mmb013 { get; set; }

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



        [ExcelColumn(Name = "停线")]
        public string Mmb005Label { get; set; }
        [ExcelColumn(Name = "未达成")]
        public string Mmb007Label { get; set; }
    }

    /// <summary>
    /// 组立明细
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:52
    /// </summary>
    public class PpOutputAssySlvImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        //[ExcelColumn(Name = "父Id")]
        [ExcelColumnName("父Id")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? ParentId { get; set; }

        [Required(ErrorMessage = "生产时段不能为空")]
        //[ExcelColumn(Name = "生产时段")]
        [ExcelColumnName("生产时段")]
        public string Mmb002 { get; set; }

        [Required(ErrorMessage = "实际产能不能为空")]
        //[ExcelColumn(Name = "实际产能")]
        [ExcelColumnName("实际产能")]
        public int Mmb003 { get; set; }

        [Required(ErrorMessage = "停线时间不能为空")]
        //[ExcelColumn(Name = "停线时间")]
        [ExcelColumnName("停线时间")]
        public int Mmb004 { get; set; }

        //[ExcelColumn(Name = "停线")]
        [ExcelColumnName("停线")]
        public string Mmb005 { get; set; }

        //[ExcelColumn(Name = "停线说明")]
        [ExcelColumnName("停线说明")]
        public string Mmb006 { get; set; }

        //[ExcelColumn(Name = "未达成")]
        [ExcelColumnName("未达成")]
        public string Mmb007 { get; set; }

        //[ExcelColumn(Name = "未达成说明")]
        [ExcelColumnName("未达成说明")]
        public string Mmb008 { get; set; }

        [Required(ErrorMessage = "实际工数不能为空")]
        //[ExcelColumn(Name = "实际工数")]
        [ExcelColumnName("实际工数")]
        public int Mmb009 { get; set; }

        [Required(ErrorMessage = "投入工数不能为空")]
        //[ExcelColumn(Name = "投入工数")]
        [ExcelColumnName("投入工数")]
        public decimal Mmb010 { get; set; }

        [Required(ErrorMessage = "工时差异不能为空")]
        //[ExcelColumn(Name = "工时差异")]
        [ExcelColumnName("工时差异")]
        public decimal Mmb011 { get; set; }

        [Required(ErrorMessage = "产能差异不能为空")]
        //[ExcelColumn(Name = "产能差异")]
        [ExcelColumnName("产能差异")]
        public decimal Mmb012 { get; set; }

        [Required(ErrorMessage = "达成率不能为空")]
        //[ExcelColumn(Name = "达成率")]
        [ExcelColumnName("达成率")]
        public decimal Mmb013 { get; set; }

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
        [ExcelColumn(Name = "停线")]
        public string Mmb005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "未达成")]
        public string Mmb007Label { get; set; }
    }

}