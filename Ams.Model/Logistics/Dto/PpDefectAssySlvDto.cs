
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 不良明细
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/12 17:18:57
    /// </summary>
    public class PpDefectAssySlvQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 不良明细
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/12 17:18:57
    /// </summary>
    public class PpDefectAssySlvDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? Id { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]

        public long ParentId { get; set; }

        //[ExcelColumn(Name = "不良类别")]
        [ExcelColumnName("不良类别")]

        public string Mfa003 { get; set; }

        [Required(ErrorMessage = "不良数量不能为空")]
        //[ExcelColumn(Name = "不良数量")]
        [ExcelColumnName("不良数量")]

        public int Mfa004 { get; set; }

        [Required(ErrorMessage = "不良总数不能为空")]
        //[ExcelColumn(Name = "不良总数")]
        [ExcelColumnName("不良总数")]

        public int Mfa005 { get; set; }

        //[ExcelColumn(Name = "不良状况")]
        [ExcelColumnName("不良状况")]

        public string Mfa006 { get; set; }

        //[ExcelColumn(Name = "不良个所")]
        [ExcelColumnName("不良个所")]

        public string Mfa007 { get; set; }

        //[ExcelColumn(Name = "不良原因")]
        [ExcelColumnName("不良原因")]

        public string Mfa008 { get; set; }

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
        [ExcelColumn(Name = "不良类别")]
        public string Mfa003Label { get; set; }
    }

    /// <summary>
    /// 不良明细
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/12 17:18:57
    /// </summary>
    public class PpDefectAssySlvImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? Id { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long ParentId { get; set; }

        //[ExcelColumn(Name = "不良类别")]
        [ExcelColumnName("不良类别")]
        public string Mfa003 { get; set; }

        [Required(ErrorMessage = "不良数量不能为空")]
        //[ExcelColumn(Name = "不良数量")]
        [ExcelColumnName("不良数量")]
        public int Mfa004 { get; set; }

        [Required(ErrorMessage = "不良总数不能为空")]
        //[ExcelColumn(Name = "不良总数")]
        [ExcelColumnName("不良总数")]
        public int Mfa005 { get; set; }

        //[ExcelColumn(Name = "不良状况")]
        [ExcelColumnName("不良状况")]
        public string Mfa006 { get; set; }

        //[ExcelColumn(Name = "不良个所")]
        [ExcelColumnName("不良个所")]
        public string Mfa007 { get; set; }

        //[ExcelColumn(Name = "不良原因")]
        [ExcelColumnName("不良原因")]
        public string Mfa008 { get; set; }

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
        [ExcelColumn(Name = "不良类别")]
        public string Mfa003Label { get; set; }
    }

}