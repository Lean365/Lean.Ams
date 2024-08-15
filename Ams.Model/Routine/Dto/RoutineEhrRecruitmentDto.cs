
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 招聘
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:31:16
    /// </summary>
    public class RoutineEhrRecruitmentQueryDto : PagerInfo 
    {
        public string EeWorkID { get; set; }
        public string EeName { get; set; }
    }

    /// <summary>
    /// 招聘
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:31:16
    /// </summary>
    public class RoutineEhrRecruitmentDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EeSfId { get; set; }

        [ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string EeWorkID { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        [ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]
        public string EeName { get; set; }

        [Required(ErrorMessage = "工资日期不能为空")]
        [ExcelColumn(Name = "工资日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("工资日期")]
        public DateTime? EeBirthday { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public int EeDepartmentId { get; set; }

        [Required(ErrorMessage = "职称不能为空")]
        [ExcelColumn(Name = "职称")]
        [ExcelColumnName("职称")]
        public int EeTitlesId { get; set; }

        [Required(ErrorMessage = "岗位不能为空")]
        [ExcelColumn(Name = "岗位")]
        [ExcelColumnName("岗位")]
        public int EePostId { get; set; }

        [Required(ErrorMessage = "等级不能为空")]
        [ExcelColumn(Name = "等级")]
        [ExcelColumnName("等级")]
        public int EePostLevel { get; set; }

        [Required(ErrorMessage = "职务不能为空")]
        [ExcelColumn(Name = "职务")]
        [ExcelColumnName("职务")]
        public int EeDutyName { get; set; }

        [ExcelColumn(Name = "聘用形式")]
        [ExcelColumnName("聘用形式")]
        public string EeEngageForm { get; set; }

        [ExcelColumn(Name = "入职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入职日期")]
        public DateTime? EeBeginDate { get; set; }

        [ExcelColumn(Name = "在职状态")]
        [ExcelColumnName("在职状态")]
        public string EeWorkState { get; set; }

        [ExcelColumn(Name = "试用期")]
        [ExcelColumnName("试用期")]
        public string EeProbation { get; set; }

        [ExcelColumn(Name = "合同期限")]
        [ExcelColumnName("合同期限")]
        public string EeContractTerm { get; set; }

        [ExcelColumn(Name = "转正日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("转正日期")]
        public DateTime? EeConversionTime { get; set; }

        [ExcelColumn(Name = "离职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("离职日期")]
        public DateTime? EeLeaveDate { get; set; }

        [ExcelColumn(Name = "合同起始日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同起始日")]
        public DateTime? EeBeginContract { get; set; }

        [ExcelColumn(Name = "合同终止日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同终止日")]
        public DateTime? EeBndContract { get; set; }

        [ExcelColumn(Name = "工龄")]
        [ExcelColumnName("工龄")]
        public int? EeWorkAge { get; set; }

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
    /// 招聘
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 9:31:16
    /// </summary>
    public class RoutineEhrRecruitmentImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EeSfId { get; set; }

        [ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string EeWorkID { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        [ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]
        public string EeName { get; set; }

        [Required(ErrorMessage = "工资日期不能为空")]
        [ExcelColumn(Name = "工资日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("工资日期")]
        public DateTime? EeBirthday { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public int EeDepartmentId { get; set; }

        [Required(ErrorMessage = "职称不能为空")]
        [ExcelColumn(Name = "职称")]
        [ExcelColumnName("职称")]
        public int EeTitlesId { get; set; }

        [Required(ErrorMessage = "岗位不能为空")]
        [ExcelColumn(Name = "岗位")]
        [ExcelColumnName("岗位")]
        public int EePostId { get; set; }

        [Required(ErrorMessage = "等级不能为空")]
        [ExcelColumn(Name = "等级")]
        [ExcelColumnName("等级")]
        public int EePostLevel { get; set; }

        [Required(ErrorMessage = "职务不能为空")]
        [ExcelColumn(Name = "职务")]
        [ExcelColumnName("职务")]
        public int EeDutyName { get; set; }

        [ExcelColumn(Name = "聘用形式")]
        [ExcelColumnName("聘用形式")]
        public string EeEngageForm { get; set; }

        [ExcelColumn(Name = "入职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入职日期")]
        public DateTime? EeBeginDate { get; set; }

        [ExcelColumn(Name = "在职状态")]
        [ExcelColumnName("在职状态")]
        public string EeWorkState { get; set; }

        [ExcelColumn(Name = "试用期")]
        [ExcelColumnName("试用期")]
        public string EeProbation { get; set; }

        [ExcelColumn(Name = "合同期限")]
        [ExcelColumnName("合同期限")]
        public string EeContractTerm { get; set; }

        [ExcelColumn(Name = "转正日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("转正日期")]
        public DateTime? EeConversionTime { get; set; }

        [ExcelColumn(Name = "离职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("离职日期")]
        public DateTime? EeLeaveDate { get; set; }

        [ExcelColumn(Name = "合同起始日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同起始日")]
        public DateTime? EeBeginContract { get; set; }

        [ExcelColumn(Name = "合同终止日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同终止日")]
        public DateTime? EeBndContract { get; set; }

        [ExcelColumn(Name = "工龄")]
        [ExcelColumnName("工龄")]
        public int? EeWorkAge { get; set; }

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