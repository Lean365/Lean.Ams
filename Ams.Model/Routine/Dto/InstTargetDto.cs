
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 机构目标
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 10:30:14
    /// </summary>
    public class InstTargetQueryDto : PagerInfo 
    {
        public string IkAbbrName { get; set; }
        public string IkAnnual { get; set; }
    }

    /// <summary>
    /// 机构目标
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 10:30:14
    /// </summary>
    public class InstTargetDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long IkSfId { get; set; }

        [ExcelColumn(Name = "公司简称")]
        [ExcelColumnName("公司简称")]
        public string IkAbbrName { get; set; }

        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string IkAnnual { get; set; }

        [ExcelColumn(Name = "语言")]
        [ExcelColumnName("语言")]
        public string IkLangKey { get; set; }

        [ExcelColumn(Name = "目标")]
        [ExcelColumnName("目标")]
        public string IkTarget { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [ExcelIgnore]
        public int? UDF51 { get; set; }

        [ExcelIgnore]
        public int? UDF52 { get; set; }

        [ExcelIgnore]
        public int? UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除 ")]
        [ExcelColumnName("软删除 ")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明")]
        [ExcelColumnName("备注说明")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "财年")]
        public string IkAnnualLabel { get; set; }
        [ExcelColumn(Name = "软删除 ")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 机构目标
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 10:30:14
    /// </summary>
    public class InstTargetImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long IkSfId { get; set; }

        [ExcelColumn(Name = "公司简称")]
        [ExcelColumnName("公司简称")]
        public string IkAbbrName { get; set; }

        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string IkAnnual { get; set; }

        [ExcelColumn(Name = "语言")]
        [ExcelColumnName("语言")]
        public string IkLangKey { get; set; }

        [ExcelColumn(Name = "目标")]
        [ExcelColumnName("目标")]
        public string IkTarget { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [ExcelIgnore]
        public int? UDF51 { get; set; }

        [ExcelIgnore]
        public int? UDF52 { get; set; }

        [ExcelIgnore]
        public int? UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除 ")]
        [ExcelColumnName("软删除 ")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明")]
        [ExcelColumnName("备注说明")]
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
        [ExcelColumn(Name = "财年")]
        public string IkAnnualLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除 ")]
        public string IsDeletedLabel { get; set; }
    }

}