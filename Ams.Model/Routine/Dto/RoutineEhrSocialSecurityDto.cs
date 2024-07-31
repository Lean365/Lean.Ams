
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 社保
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:30:43
    /// </summary>
    public class RoutineEhrSocialSecurityQueryDto : PagerInfo 
    {
        public string EeWorkID { get; set; }
        public DateTime? BeginEssEffectiveDate { get; set; }
        public DateTime? EndEssEffectiveDate { get; set; }
    }

    /// <summary>
    /// 社保
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:30:43
    /// </summary>
    public class RoutineEhrSocialSecurityDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EeSfId { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long EeParentSfId { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        [ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string EeWorkID { get; set; }

        [Required(ErrorMessage = "生效日不能为空")]
        [ExcelColumn(Name = "生效日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日")]
        public DateTime? EssEffectiveDate { get; set; }

        [ExcelColumn(Name = "养老")]
        [ExcelColumnName("养老")]
        public decimal EeOldAgeInsur { get; set; }

        [ExcelColumn(Name = "医疗")]
        [ExcelColumnName("医疗")]
        public decimal EeMedicalInsur { get; set; }

        [ExcelColumn(Name = "工伤")]
        [ExcelColumnName("工伤")]
        public decimal EeInjuryInsur { get; set; }

        [ExcelColumn(Name = "失业")]
        [ExcelColumnName("失业")]
        public decimal EeUnemploymentInsur { get; set; }

        [ExcelColumn(Name = "生育")]
        [ExcelColumnName("生育")]
        public decimal EeMaternityInsur { get; set; }

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
    /// 社保
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:30:43
    /// </summary>
    public class RoutineEhrSocialSecurityImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EeSfId { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long EeParentSfId { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        [ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string EeWorkID { get; set; }

        [Required(ErrorMessage = "生效日不能为空")]
        [ExcelColumn(Name = "生效日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日")]
        public DateTime? EssEffectiveDate { get; set; }

        [ExcelColumn(Name = "养老")]
        [ExcelColumnName("养老")]
        public decimal EeOldAgeInsur { get; set; }

        [ExcelColumn(Name = "医疗")]
        [ExcelColumnName("医疗")]
        public decimal EeMedicalInsur { get; set; }

        [ExcelColumn(Name = "工伤")]
        [ExcelColumnName("工伤")]
        public decimal EeInjuryInsur { get; set; }

        [ExcelColumn(Name = "失业")]
        [ExcelColumnName("失业")]
        public decimal EeUnemploymentInsur { get; set; }

        [ExcelColumn(Name = "生育")]
        [ExcelColumnName("生育")]
        public decimal EeMaternityInsur { get; set; }

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