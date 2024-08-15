
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 人事
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 8:47:39
    /// </summary>
    public class RoutineEhrEmployeeQueryDto : PagerInfo 
    {
        public string EeName { get; set; }
        public string EeEnglishName { get; set; }
        public int? EeGenderId { get; set; }
        public DateTime? BeginEeBirthday { get; set; }
        public DateTime? EndEeBirthday { get; set; }
        public string EeIdentityCard { get; set; }
        public int? EeWedlockId { get; set; }
        public int? EeNationId { get; set; }
        public int? EePoliticId { get; set; }
        public string EeCountry { get; set; }
        public string EeProvince { get; set; }
        public string EeCity { get; set; }
        public string EeCounty { get; set; }
        public int? EeHouseholdTypeId { get; set; }
        public int? EeDepartmentId { get; set; }
        public int? EeTitlesId { get; set; }
        public int? EePostId { get; set; }
        public int? EePostLevel { get; set; }
        public int? EeRecruited { get; set; }
        public int? EeEngageFormId { get; set; }
        public int? EeEducationalBackgroundId { get; set; }
        public int? EeSpecialtyId { get; set; }
        public string EeEmployeeId { get; set; }
        public DateTime? BeginEeJoinedDate { get; set; }
        public DateTime? EndEeJoinedDate { get; set; }
        public int? EeEmployedStatus { get; set; }
        public DateTime? BeginEeLeaveDate { get; set; }
        public DateTime? EndEeLeaveDate { get; set; }
        public DateTime? BeginEeContractEndDate { get; set; }
        public DateTime? EndEeContractEndDate { get; set; }
        public DateTime? BeginEeRetirementDate { get; set; }
        public DateTime? EndEeRetirementDate { get; set; }
        public int? EeClockInId { get; set; }
        public int? EeShiftsTypeId { get; set; }
    }

    /// <summary>
    /// 人事
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 8:47:39
    /// </summary>
    public class RoutineEhrEmployeeDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EeSfId { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        [ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]
        public string EeName { get; set; }

        [ExcelColumn(Name = "曾用名")]
        [ExcelColumnName("曾用名")]
        public string EeNameUsed { get; set; }

        [ExcelColumn(Name = "昵称")]
        [ExcelColumnName("昵称")]
        public string EeNickName { get; set; }

        [ExcelColumn(Name = "英文名")]
        [ExcelColumnName("英文名")]
        public string EeEnglishName { get; set; }

        [Required(ErrorMessage = "性别不能为空")]
        [ExcelColumn(Name = "性别")]
        [ExcelColumnName("性别")]
        public int EeGenderId { get; set; }

        [Required(ErrorMessage = "出生日期不能为空")]
        [ExcelColumn(Name = "出生日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("出生日期")]
        public DateTime? EeBirthday { get; set; }

        [Required(ErrorMessage = "身份证号不能为空")]
        [ExcelColumn(Name = "身份证号")]
        [ExcelColumnName("身份证号")]
        public string EeIdentityCard { get; set; }

        [Required(ErrorMessage = "婚姻状态不能为空")]
        [ExcelColumn(Name = "婚姻状态")]
        [ExcelColumnName("婚姻状态")]
        public int EeWedlockId { get; set; }

        [Required(ErrorMessage = "民族不能为空")]
        [ExcelColumn(Name = "民族")]
        [ExcelColumnName("民族")]
        public int EeNationId { get; set; }

        [Required(ErrorMessage = "籍贯不能为空")]
        [ExcelColumn(Name = "籍贯")]
        [ExcelColumnName("籍贯")]
        public string EeNativePlace { get; set; }

        [Required(ErrorMessage = "政治面貌不能为空")]
        [ExcelColumn(Name = "政治面貌")]
        [ExcelColumnName("政治面貌")]
        public int EePoliticId { get; set; }

        [ExcelColumn(Name = "邮件")]
        [ExcelColumnName("邮件")]
        public string EeEmail { get; set; }

        [ExcelColumn(Name = "电话")]
        [ExcelColumnName("电话")]
        public string EePhone { get; set; }

        [Required(ErrorMessage = "国家/地区不能为空")]
        [ExcelColumn(Name = "国家/地区")]
        [ExcelColumnName("国家/地区")]
        public string EeCountry { get; set; }

        [Required(ErrorMessage = "省区不能为空")]
        [ExcelColumn(Name = "省区")]
        [ExcelColumnName("省区")]
        public string EeProvince { get; set; }

        [Required(ErrorMessage = "市区不能为空")]
        [ExcelColumn(Name = "市区")]
        [ExcelColumnName("市区")]
        public string EeCity { get; set; }

        [Required(ErrorMessage = "县区不能为空")]
        [ExcelColumn(Name = "县区")]
        [ExcelColumnName("县区")]
        public string EeCounty { get; set; }

        [ExcelColumn(Name = "家庭住址")]
        [ExcelColumnName("家庭住址")]
        public string EeHomeAddress { get; set; }

        [ExcelColumn(Name = "邮编")]
        [ExcelColumnName("邮编")]
        public string EePostCode { get; set; }

        [Required(ErrorMessage = "户口性质不能为空")]
        [ExcelColumn(Name = "户口性质")]
        [ExcelColumnName("户口性质")]
        public int EeHouseholdTypeId { get; set; }

        [ExcelColumn(Name = "暂住地址")]
        [ExcelColumnName("暂住地址")]
        public string EeStayAddress { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public int EeDepartmentId { get; set; }

        [ExcelColumn(Name = "职称")]
        [ExcelColumnName("职称")]
        public int? EeTitlesId { get; set; }

        [ExcelColumn(Name = "职位")]
        [ExcelColumnName("职位")]
        public int? EePostId { get; set; }

        [ExcelColumn(Name = "职级")]
        [ExcelColumnName("职级")]
        public int? EePostLevel { get; set; }

        [ExcelColumn(Name = "职务")]
        [ExcelColumnName("职务")]
        public int? EeDutyId { get; set; }

        [ExcelColumn(Name = "招聘来源")]
        [ExcelColumnName("招聘来源")]
        public int? EeRecruited { get; set; }

        [ExcelColumn(Name = "聘用形式")]
        [ExcelColumnName("聘用形式")]
        public int? EeEngageFormId { get; set; }

        [ExcelColumn(Name = "学历")]
        [ExcelColumnName("学历")]
        public int? EeEducationalBackgroundId { get; set; }

        [ExcelColumn(Name = "专业")]
        [ExcelColumnName("专业")]
        public int? EeSpecialtyId { get; set; }

        [ExcelColumn(Name = "院校")]
        [ExcelColumnName("院校")]
        public string EeCollegeName { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        [ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string EeEmployeeId { get; set; }

        [Required(ErrorMessage = "入职日期不能为空")]
        [ExcelColumn(Name = "入职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入职日期")]
        public DateTime? EeJoinedDate { get; set; }

        [ExcelColumn(Name = "在职状态")]
        [ExcelColumnName("在职状态")]
        public int? EeEmployedStatus { get; set; }

        [ExcelColumn(Name = "试用期")]
        [ExcelColumnName("试用期")]
        public int? EeProbationPeriod { get; set; }

        [ExcelColumn(Name = "合同期限")]
        [ExcelColumnName("合同期限")]
        public int? EeContractPeriod { get; set; }

        [ExcelColumn(Name = "转正日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("转正日期")]
        public DateTime? EePositiveDate { get; set; }

        [ExcelColumn(Name = "离职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("离职日期")]
        public DateTime? EeLeaveDate { get; set; }

        [ExcelColumn(Name = "合同起始日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同起始日")]
        public DateTime? EeContractBeginDate { get; set; }

        [ExcelColumn(Name = "合同终止日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同终止日")]
        public DateTime? EeContractEndDate { get; set; }

        [ExcelColumn(Name = "工龄")]
        [ExcelColumnName("工龄")]
        public int? EeSeniority { get; set; }

        [ExcelColumn(Name = "退休日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("退休日期")]
        public DateTime? EeRetirementDate { get; set; }

        [Required(ErrorMessage = "打卡否不能为空")]
        [ExcelColumn(Name = "打卡否")]
        [ExcelColumnName("打卡否")]
        public int EeClockInId { get; set; }

        [Required(ErrorMessage = "班别不能为空")]
        [ExcelColumn(Name = "班别")]
        [ExcelColumnName("班别")]
        public int EeShiftsTypeId { get; set; }

        [ExcelColumn(Name = "头像")]
        [ExcelColumnName("头像")]
        public string EeAvatarFileUrl { get; set; }

        [ExcelColumn(Name = "学历附件")]
        [ExcelColumnName("学历附件")]
        public string EeQualificationFileUrl { get; set; }

        [ExcelColumn(Name = "职称附件")]
        [ExcelColumnName("职称附件")]
        public string EeTitleFileUrl { get; set; }

        [ExcelColumn(Name = "预留A")]
        [ExcelColumnName("预留A")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B")]
        [ExcelColumnName("预留B")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C")]
        [ExcelColumnName("预留C")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1")]
        [ExcelColumnName("预留1")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2")]
        [ExcelColumnName("预留2")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3")]
        [ExcelColumnName("预留3")]
        public decimal REF06 { get; set; }

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



        [ExcelColumn(Name = "性别")]
        public string EeGenderIdLabel { get; set; }
        [ExcelColumn(Name = "婚姻状态")]
        public string EeWedlockIdLabel { get; set; }
        [ExcelColumn(Name = "民族")]
        public string EeNationIdLabel { get; set; }
        [ExcelColumn(Name = "政治面貌")]
        public string EePoliticIdLabel { get; set; }
        [ExcelColumn(Name = "国家/地区")]
        public string EeCountryLabel { get; set; }
        [ExcelColumn(Name = "省区")]
        public string EeProvinceLabel { get; set; }
        [ExcelColumn(Name = "户口性质")]
        public string EeHouseholdTypeIdLabel { get; set; }
        [ExcelColumn(Name = "部门")]
        public string EeDepartmentIdLabel { get; set; }
        [ExcelColumn(Name = "职称")]
        public string EeTitlesIdLabel { get; set; }
        [ExcelColumn(Name = "职位")]
        public string EePostIdLabel { get; set; }
        [ExcelColumn(Name = "职级")]
        public string EePostLevelLabel { get; set; }
        [ExcelColumn(Name = "招聘来源")]
        public string EeRecruitedLabel { get; set; }
        [ExcelColumn(Name = "聘用形式")]
        public string EeEngageFormIdLabel { get; set; }
        [ExcelColumn(Name = "学历")]
        public string EeEducationalBackgroundIdLabel { get; set; }
        [ExcelColumn(Name = "专业")]
        public string EeSpecialtyIdLabel { get; set; }
        [ExcelColumn(Name = "在职状态")]
        public string EeEmployedStatusLabel { get; set; }
        [ExcelColumn(Name = "打卡否")]
        public string EeClockInIdLabel { get; set; }
        [ExcelColumn(Name = "班别")]
        public string EeShiftsTypeIdLabel { get; set; }
    }

    /// <summary>
    /// 人事
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 8:47:39
    /// </summary>
    public class RoutineEhrEmployeeImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EeSfId { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        [ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]
        public string EeName { get; set; }

        [ExcelColumn(Name = "曾用名")]
        [ExcelColumnName("曾用名")]
        public string EeNameUsed { get; set; }

        [ExcelColumn(Name = "昵称")]
        [ExcelColumnName("昵称")]
        public string EeNickName { get; set; }

        [ExcelColumn(Name = "英文名")]
        [ExcelColumnName("英文名")]
        public string EeEnglishName { get; set; }

        [Required(ErrorMessage = "性别不能为空")]
        [ExcelColumn(Name = "性别")]
        [ExcelColumnName("性别")]
        public int EeGenderId { get; set; }

        [Required(ErrorMessage = "出生日期不能为空")]
        [ExcelColumn(Name = "出生日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("出生日期")]
        public DateTime? EeBirthday { get; set; }

        [Required(ErrorMessage = "身份证号不能为空")]
        [ExcelColumn(Name = "身份证号")]
        [ExcelColumnName("身份证号")]
        public string EeIdentityCard { get; set; }

        [Required(ErrorMessage = "婚姻状态不能为空")]
        [ExcelColumn(Name = "婚姻状态")]
        [ExcelColumnName("婚姻状态")]
        public int EeWedlockId { get; set; }

        [Required(ErrorMessage = "民族不能为空")]
        [ExcelColumn(Name = "民族")]
        [ExcelColumnName("民族")]
        public int EeNationId { get; set; }

        [Required(ErrorMessage = "籍贯不能为空")]
        [ExcelColumn(Name = "籍贯")]
        [ExcelColumnName("籍贯")]
        public string EeNativePlace { get; set; }

        [Required(ErrorMessage = "政治面貌不能为空")]
        [ExcelColumn(Name = "政治面貌")]
        [ExcelColumnName("政治面貌")]
        public int EePoliticId { get; set; }

        [ExcelColumn(Name = "邮件")]
        [ExcelColumnName("邮件")]
        public string EeEmail { get; set; }

        [ExcelColumn(Name = "电话")]
        [ExcelColumnName("电话")]
        public string EePhone { get; set; }

        [Required(ErrorMessage = "国家/地区不能为空")]
        [ExcelColumn(Name = "国家/地区")]
        [ExcelColumnName("国家/地区")]
        public string EeCountry { get; set; }

        [Required(ErrorMessage = "省区不能为空")]
        [ExcelColumn(Name = "省区")]
        [ExcelColumnName("省区")]
        public string EeProvince { get; set; }

        [Required(ErrorMessage = "市区不能为空")]
        [ExcelColumn(Name = "市区")]
        [ExcelColumnName("市区")]
        public string EeCity { get; set; }

        [Required(ErrorMessage = "县区不能为空")]
        [ExcelColumn(Name = "县区")]
        [ExcelColumnName("县区")]
        public string EeCounty { get; set; }

        [ExcelColumn(Name = "家庭住址")]
        [ExcelColumnName("家庭住址")]
        public string EeHomeAddress { get; set; }

        [ExcelColumn(Name = "邮编")]
        [ExcelColumnName("邮编")]
        public string EePostCode { get; set; }

        [Required(ErrorMessage = "户口性质不能为空")]
        [ExcelColumn(Name = "户口性质")]
        [ExcelColumnName("户口性质")]
        public int EeHouseholdTypeId { get; set; }

        [ExcelColumn(Name = "暂住地址")]
        [ExcelColumnName("暂住地址")]
        public string EeStayAddress { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public int EeDepartmentId { get; set; }

        [ExcelColumn(Name = "职称")]
        [ExcelColumnName("职称")]
        public int? EeTitlesId { get; set; }

        [ExcelColumn(Name = "职位")]
        [ExcelColumnName("职位")]
        public int? EePostId { get; set; }

        [ExcelColumn(Name = "职级")]
        [ExcelColumnName("职级")]
        public int? EePostLevel { get; set; }

        [ExcelColumn(Name = "职务")]
        [ExcelColumnName("职务")]
        public int? EeDutyId { get; set; }

        [ExcelColumn(Name = "招聘来源")]
        [ExcelColumnName("招聘来源")]
        public int? EeRecruited { get; set; }

        [ExcelColumn(Name = "聘用形式")]
        [ExcelColumnName("聘用形式")]
        public int? EeEngageFormId { get; set; }

        [ExcelColumn(Name = "学历")]
        [ExcelColumnName("学历")]
        public int? EeEducationalBackgroundId { get; set; }

        [ExcelColumn(Name = "专业")]
        [ExcelColumnName("专业")]
        public int? EeSpecialtyId { get; set; }

        [ExcelColumn(Name = "院校")]
        [ExcelColumnName("院校")]
        public string EeCollegeName { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        [ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string EeEmployeeId { get; set; }

        [Required(ErrorMessage = "入职日期不能为空")]
        [ExcelColumn(Name = "入职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入职日期")]
        public DateTime? EeJoinedDate { get; set; }

        [ExcelColumn(Name = "在职状态")]
        [ExcelColumnName("在职状态")]
        public int? EeEmployedStatus { get; set; }

        [ExcelColumn(Name = "试用期")]
        [ExcelColumnName("试用期")]
        public int? EeProbationPeriod { get; set; }

        [ExcelColumn(Name = "合同期限")]
        [ExcelColumnName("合同期限")]
        public int? EeContractPeriod { get; set; }

        [ExcelColumn(Name = "转正日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("转正日期")]
        public DateTime? EePositiveDate { get; set; }

        [ExcelColumn(Name = "离职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("离职日期")]
        public DateTime? EeLeaveDate { get; set; }

        [ExcelColumn(Name = "合同起始日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同起始日")]
        public DateTime? EeContractBeginDate { get; set; }

        [ExcelColumn(Name = "合同终止日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同终止日")]
        public DateTime? EeContractEndDate { get; set; }

        [ExcelColumn(Name = "工龄")]
        [ExcelColumnName("工龄")]
        public int? EeSeniority { get; set; }

        [ExcelColumn(Name = "退休日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("退休日期")]
        public DateTime? EeRetirementDate { get; set; }

        [Required(ErrorMessage = "打卡否不能为空")]
        [ExcelColumn(Name = "打卡否")]
        [ExcelColumnName("打卡否")]
        public int EeClockInId { get; set; }

        [Required(ErrorMessage = "班别不能为空")]
        [ExcelColumn(Name = "班别")]
        [ExcelColumnName("班别")]
        public int EeShiftsTypeId { get; set; }

        [ExcelColumn(Name = "头像")]
        [ExcelColumnName("头像")]
        public string EeAvatarFileUrl { get; set; }

        [ExcelColumn(Name = "学历附件")]
        [ExcelColumnName("学历附件")]
        public string EeQualificationFileUrl { get; set; }

        [ExcelColumn(Name = "职称附件")]
        [ExcelColumnName("职称附件")]
        public string EeTitleFileUrl { get; set; }

        [ExcelColumn(Name = "预留A")]
        [ExcelColumnName("预留A")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B")]
        [ExcelColumnName("预留B")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C")]
        [ExcelColumnName("预留C")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1")]
        [ExcelColumnName("预留1")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2")]
        [ExcelColumnName("预留2")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3")]
        [ExcelColumnName("预留3")]
        public decimal REF06 { get; set; }

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
        [ExcelColumn(Name = "性别")]
        public string EeGenderIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "婚姻状态")]
        public string EeWedlockIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "民族")]
        public string EeNationIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "政治面貌")]
        public string EePoliticIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "国家/地区")]
        public string EeCountryLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "省区")]
        public string EeProvinceLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "户口性质")]
        public string EeHouseholdTypeIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "部门")]
        public string EeDepartmentIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "职称")]
        public string EeTitlesIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "职位")]
        public string EePostIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "职级")]
        public string EePostLevelLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "招聘来源")]
        public string EeRecruitedLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "聘用形式")]
        public string EeEngageFormIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "学历")]
        public string EeEducationalBackgroundIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "专业")]
        public string EeSpecialtyIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "在职状态")]
        public string EeEmployedStatusLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "打卡否")]
        public string EeClockInIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "班别")]
        public string EeShiftsTypeIdLabel { get; set; }
    }

}