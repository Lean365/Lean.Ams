
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 公积金
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:33:02
    /// </summary>
    public class RoutineEhrFundsQueryDto : PagerInfo 
    {
        public DateTime? BeginEfEffectiveDate { get; set; }
        public DateTime? EndEfEffectiveDate { get; set; }
        public string EfWorkID { get; set; }
        public string EfFundNo { get; set; }
    }

    /// <summary>
    /// 公积金
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:33:02
    /// </summary>
    public class RoutineEhrFundsDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EfSfId { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long EfParentSfId { get; set; }

        [Required(ErrorMessage = "生效日不能为空")]
        [ExcelColumn(Name = "生效日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日")]
        public DateTime? EfEffectiveDate { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        [ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string EfWorkID { get; set; }

        [Required(ErrorMessage = "账号不能为空")]
        [ExcelColumn(Name = "账号")]
        [ExcelColumnName("账号")]
        public string EfFundNo { get; set; }

        [Required(ErrorMessage = "基数不能为空")]
        [ExcelColumn(Name = "基数")]
        [ExcelColumnName("基数")]
        public decimal EfFundBase { get; set; }

        [Required(ErrorMessage = "提取金额不能为空")]
        [ExcelColumn(Name = "提取金额")]
        [ExcelColumnName("提取金额")]
        public decimal EeExtract { get; set; }

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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 公积金
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:33:02
    /// </summary>
    public class RoutineEhrFundsImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EfSfId { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long EfParentSfId { get; set; }

        [Required(ErrorMessage = "生效日不能为空")]
        [ExcelColumn(Name = "生效日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日")]
        public DateTime? EfEffectiveDate { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        [ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string EfWorkID { get; set; }

        [Required(ErrorMessage = "账号不能为空")]
        [ExcelColumn(Name = "账号")]
        [ExcelColumnName("账号")]
        public string EfFundNo { get; set; }

        [Required(ErrorMessage = "基数不能为空")]
        [ExcelColumn(Name = "基数")]
        [ExcelColumnName("基数")]
        public decimal EfFundBase { get; set; }

        [Required(ErrorMessage = "提取金额不能为空")]
        [ExcelColumn(Name = "提取金额")]
        [ExcelColumnName("提取金额")]
        public decimal EeExtract { get; set; }

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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
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
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}