
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 抽样标准
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:39:16
    /// </summary>
    public class QmInspAqlQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 抽样标准
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:39:16
    /// </summary>
    public class QmInspAqlDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "查检水平不能为空")]
        //[ExcelColumn(Name = "查检水平")]
        [ExcelColumnName("查检水平")]

        public string Mg002 { get; set; }

        [Required(ErrorMessage = "批量范围不能为空")]
        //[ExcelColumn(Name = "批量范围")]
        [ExcelColumnName("批量范围")]

        public string Mg003 { get; set; }

        [Required(ErrorMessage = "最小值不能为空")]
        //[ExcelColumn(Name = "最小值")]
        [ExcelColumnName("最小值")]

        public int Mg004 { get; set; }

        [Required(ErrorMessage = "最大值不能为空")]
        //[ExcelColumn(Name = "最大值")]
        [ExcelColumnName("最大值")]

        public int Mg005 { get; set; }

        //[ExcelColumn(Name = "样本码")]
        [ExcelColumnName("样本码")]

        public string Mg006 { get; set; }

        [Required(ErrorMessage = "抽样数不能为空")]
        //[ExcelColumn(Name = "抽样数")]
        [ExcelColumnName("抽样数")]

        public int Mg007 { get; set; }

        [Required(ErrorMessage = "合格项不能为空")]
        //[ExcelColumn(Name = "合格项")]
        [ExcelColumnName("合格项")]

        public int Mg008 { get; set; }

        [Required(ErrorMessage = "不合格项不能为空")]
        //[ExcelColumn(Name = "不合格项")]
        [ExcelColumnName("不合格项")]

        public int Mg009 { get; set; }

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



    }

    /// <summary>
    /// 抽样标准
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:39:16
    /// </summary>
    public class QmInspAqlImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "查检水平不能为空")]
        //[ExcelColumn(Name = "查检水平")]
        [ExcelColumnName("查检水平")]
        public string Mg002 { get; set; }

        [Required(ErrorMessage = "批量范围不能为空")]
        //[ExcelColumn(Name = "批量范围")]
        [ExcelColumnName("批量范围")]
        public string Mg003 { get; set; }

        [Required(ErrorMessage = "最小值不能为空")]
        //[ExcelColumn(Name = "最小值")]
        [ExcelColumnName("最小值")]
        public int Mg004 { get; set; }

        [Required(ErrorMessage = "最大值不能为空")]
        //[ExcelColumn(Name = "最大值")]
        [ExcelColumnName("最大值")]
        public int Mg005 { get; set; }

        //[ExcelColumn(Name = "样本码")]
        [ExcelColumnName("样本码")]
        public string Mg006 { get; set; }

        [Required(ErrorMessage = "抽样数不能为空")]
        //[ExcelColumn(Name = "抽样数")]
        [ExcelColumnName("抽样数")]
        public int Mg007 { get; set; }

        [Required(ErrorMessage = "合格项不能为空")]
        //[ExcelColumn(Name = "合格项")]
        [ExcelColumnName("合格项")]
        public int Mg008 { get; set; }

        [Required(ErrorMessage = "不合格项不能为空")]
        //[ExcelColumn(Name = "不合格项")]
        [ExcelColumnName("不合格项")]
        public int Mg009 { get; set; }

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



    }

}