
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 人事
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 8:07:34
    /// </summary>
    public class RoutineEhrEmployeeQueryDto : PagerInfo 
    {
        public string EeName { get; set; }
        public string EeGender { get; set; }
        public DateTime? BeginEeBirthday { get; set; }
        public DateTime? EndEeBirthday { get; set; }
        public string EeIdentityCard { get; set; }
        public int? EeWedlock { get; set; }
        public int? EeNationId { get; set; }
        public int? EeNativePlace { get; set; }
        public int? EePoliticId { get; set; }
        public string EeCountry { get; set; }
        public string EeProvince { get; set; }
        public int? EeHouseholdType { get; set; }
        public int? EeDepartmentId { get; set; }
        public int? EeTitlesId { get; set; }
        public int? EePostId { get; set; }
        public int? EePostLevel { get; set; }
        public int? EeDutyName { get; set; }
        public int? EeRecruited { get; set; }
        public string EeEngageForm { get; set; }
        public int? EeTiptopDegrEe { get; set; }
        public int? EeSpecialty { get; set; }
        public string EeWorkID { get; set; }
        public DateTime? BeginEeBeginDate { get; set; }
        public DateTime? EndEeBeginDate { get; set; }
        public int? EeWorkState { get; set; }
        public DateTime? BeginEeConversionTime { get; set; }
        public DateTime? EndEeConversionTime { get; set; }
        public DateTime? BeginEeLeaveDate { get; set; }
        public DateTime? EndEeLeaveDate { get; set; }
        public DateTime? BeginEeEndContract { get; set; }
        public DateTime? EndEeEndContract { get; set; }
        public DateTime? BeginEeRetireDate { get; set; }
        public DateTime? EndEeRetireDate { get; set; }
    }

    /// <summary>
    /// 人事
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 8:07:34
    /// </summary>
    public class RoutineEhrEmployeeDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EeSfId { get; set; }

        [ExcelColumn(Name = "姓名 ")]
        [ExcelColumnName("姓名 ")]
        public string EeName { get; set; }

        [ExcelColumn(Name = "曾用名 ")]
        [ExcelColumnName("曾用名 ")]
        public string EeNameUsed { get; set; }

        [ExcelColumn(Name = "昵称 ")]
        [ExcelColumnName("昵称 ")]
        public string EeNickName { get; set; }

        [ExcelColumn(Name = "英文名 ")]
        [ExcelColumnName("英文名 ")]
        public string EeEnglishName { get; set; }

        [ExcelColumn(Name = "性别 ")]
        [ExcelColumnName("性别 ")]
        public string EeGender { get; set; }

        [ExcelColumn(Name = "出生日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("出生日期")]
        public DateTime? EeBirthday { get; set; }

        [ExcelColumn(Name = "身份证号 ")]
        [ExcelColumnName("身份证号 ")]
        public string EeIdentityCard { get; set; }

        [ExcelColumn(Name = "婚姻状态 ")]
        [ExcelColumnName("婚姻状态 ")]
        public int? EeWedlock { get; set; }

        [ExcelColumn(Name = "民族 ")]
        [ExcelColumnName("民族 ")]
        public int? EeNationId { get; set; }

        [ExcelColumn(Name = "籍贯 ")]
        [ExcelColumnName("籍贯 ")]
        public int? EeNativePlace { get; set; }

        [ExcelColumn(Name = "政治面貌 ")]
        [ExcelColumnName("政治面貌 ")]
        public int? EePoliticId { get; set; }

        [ExcelColumn(Name = "邮件 ")]
        [ExcelColumnName("邮件 ")]
        public string EeEmail { get; set; }

        [ExcelColumn(Name = "电话 ")]
        [ExcelColumnName("电话 ")]
        public string EePhone { get; set; }

        [ExcelColumn(Name = "国家/地区 ")]
        [ExcelColumnName("国家/地区 ")]
        public string EeCountry { get; set; }

        [ExcelColumn(Name = "省区 ")]
        [ExcelColumnName("省区 ")]
        public string EeProvince { get; set; }

        [ExcelColumn(Name = "市区 ")]
        [ExcelColumnName("市区 ")]
        public string EeCity { get; set; }

        [ExcelColumn(Name = "县区 ")]
        [ExcelColumnName("县区 ")]
        public string EeCounty { get; set; }

        [ExcelColumn(Name = "家庭住址 ")]
        [ExcelColumnName("家庭住址 ")]
        public string EeHomeAddress { get; set; }

        [ExcelColumn(Name = "邮编 ")]
        [ExcelColumnName("邮编 ")]
        public string EePostCode { get; set; }

        [ExcelColumn(Name = "户口性质 ")]
        [ExcelColumnName("户口性质 ")]
        public int? EeHouseholdType { get; set; }

        [ExcelColumn(Name = "暂住地址 ")]
        [ExcelColumnName("暂住地址 ")]
        public string EeStayAddress { get; set; }

        [ExcelColumn(Name = "部门 ")]
        [ExcelColumnName("部门 ")]
        public int? EeDepartmentId { get; set; }

        [ExcelColumn(Name = "职称 ")]
        [ExcelColumnName("职称 ")]
        public int? EeTitlesId { get; set; }

        [ExcelColumn(Name = "职位 ")]
        [ExcelColumnName("职位 ")]
        public int? EePostId { get; set; }

        [ExcelColumn(Name = "职级 ")]
        [ExcelColumnName("职级 ")]
        public int? EePostLevel { get; set; }

        [ExcelColumn(Name = "职务 ")]
        [ExcelColumnName("职务 ")]
        public int? EeDutyName { get; set; }

        [ExcelColumn(Name = "招聘来源 ")]
        [ExcelColumnName("招聘来源 ")]
        public int? EeRecruited { get; set; }

        [ExcelColumn(Name = "聘用形式 ")]
        [ExcelColumnName("聘用形式 ")]
        public string EeEngageForm { get; set; }

        [ExcelColumn(Name = "学历 ")]
        [ExcelColumnName("学历 ")]
        public int? EeTiptopDegrEe { get; set; }

        [ExcelColumn(Name = "专业 ")]
        [ExcelColumnName("专业 ")]
        public int? EeSpecialty { get; set; }

        [ExcelColumn(Name = "院校 ")]
        [ExcelColumnName("院校 ")]
        public string EeSchool { get; set; }

        [Required(ErrorMessage = "工号 不能为空")]
        [ExcelColumn(Name = "工号 ")]
        [ExcelColumnName("工号 ")]
        public string EeWorkID { get; set; }

        [ExcelColumn(Name = "入职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入职日期")]
        public DateTime? EeBeginDate { get; set; }

        [ExcelColumn(Name = "在职状态 ")]
        [ExcelColumnName("在职状态 ")]
        public int? EeWorkState { get; set; }

        [ExcelColumn(Name = "试用期 ")]
        [ExcelColumnName("试用期 ")]
        public int? EeProbation { get; set; }

        [ExcelColumn(Name = "合同期限 ")]
        [ExcelColumnName("合同期限 ")]
        public int? EeContractTerm { get; set; }

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
        public DateTime? EeEndContract { get; set; }

        [ExcelColumn(Name = "工龄 ")]
        [ExcelColumnName("工龄 ")]
        public int? EeWorkAge { get; set; }

        [ExcelColumn(Name = "退休日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("退休日期")]
        public DateTime? EeRetireDate { get; set; }

        [ExcelColumn(Name = "打卡否 ")]
        [ExcelColumnName("打卡否 ")]
        public int? EeClockIn { get; set; }

        [ExcelColumn(Name = "班别 ")]
        [ExcelColumnName("班别 ")]
        public int? EeShiftsType { get; set; }

        [ExcelColumn(Name = "头像 ")]
        [ExcelColumnName("头像 ")]
        public string EeAvatar { get; set; }

        [ExcelColumn(Name = "学历附件 ")]
        [ExcelColumnName("学历附件 ")]
        public string EeQualificationAnnex { get; set; }

        [ExcelColumn(Name = "职称附件 ")]
        [ExcelColumnName("职称附件 ")]
        public string EeTitleAnnex { get; set; }

        [ExcelColumn(Name = "预留A ")]
        [ExcelColumnName("预留A ")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B ")]
        [ExcelColumnName("预留B ")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C ")]
        [ExcelColumnName("预留C ")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1 ")]
        [ExcelColumnName("预留1 ")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2 ")]
        [ExcelColumnName("预留2 ")]
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

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
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



        [ExcelColumn(Name = "性别 ")]
        public string EeGenderLabel { get; set; }
        [ExcelColumn(Name = "婚姻状态 ")]
        public string EeWedlockLabel { get; set; }
        [ExcelColumn(Name = "民族 ")]
        public string EeNationIdLabel { get; set; }
        [ExcelColumn(Name = "籍贯 ")]
        public string EeNativePlaceLabel { get; set; }
        [ExcelColumn(Name = "政治面貌 ")]
        public string EePoliticIdLabel { get; set; }
        [ExcelColumn(Name = "国家/地区 ")]
        public string EeCountryLabel { get; set; }
        [ExcelColumn(Name = "省区 ")]
        public string EeProvinceLabel { get; set; }
        [ExcelColumn(Name = "市区 ")]
        public string EeCityLabel { get; set; }
        [ExcelColumn(Name = "户口性质 ")]
        public string EeHouseholdTypeLabel { get; set; }
        [ExcelColumn(Name = "部门 ")]
        public string EeDepartmentIdLabel { get; set; }
        [ExcelColumn(Name = "职称 ")]
        public string EeTitlesIdLabel { get; set; }
        [ExcelColumn(Name = "职位 ")]
        public string EePostIdLabel { get; set; }
        [ExcelColumn(Name = "职级 ")]
        public string EePostLevelLabel { get; set; }
        [ExcelColumn(Name = "招聘来源 ")]
        public string EeRecruitedLabel { get; set; }
        [ExcelColumn(Name = "聘用形式 ")]
        public string EeEngageFormLabel { get; set; }
        [ExcelColumn(Name = "学历 ")]
        public string EeTiptopDegrEeLabel { get; set; }
        [ExcelColumn(Name = "专业 ")]
        public string EeSpecialtyLabel { get; set; }
        [ExcelColumn(Name = "在职状态 ")]
        public string EeWorkStateLabel { get; set; }
        [ExcelColumn(Name = "打卡否 ")]
        public string EeClockInLabel { get; set; }
        [ExcelColumn(Name = "班别 ")]
        public string EeShiftsTypeLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 人事
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 8:07:34
    /// </summary>
    public class RoutineEhrEmployeeImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EeSfId { get; set; }

        [ExcelColumn(Name = "姓名 ")]
        [ExcelColumnName("姓名 ")]
        public string EeName { get; set; }

        [ExcelColumn(Name = "曾用名 ")]
        [ExcelColumnName("曾用名 ")]
        public string EeNameUsed { get; set; }

        [ExcelColumn(Name = "昵称 ")]
        [ExcelColumnName("昵称 ")]
        public string EeNickName { get; set; }

        [ExcelColumn(Name = "英文名 ")]
        [ExcelColumnName("英文名 ")]
        public string EeEnglishName { get; set; }

        [ExcelColumn(Name = "性别 ")]
        [ExcelColumnName("性别 ")]
        public string EeGender { get; set; }

        [ExcelColumn(Name = "出生日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("出生日期")]
        public DateTime? EeBirthday { get; set; }

        [ExcelColumn(Name = "身份证号 ")]
        [ExcelColumnName("身份证号 ")]
        public string EeIdentityCard { get; set; }

        [ExcelColumn(Name = "婚姻状态 ")]
        [ExcelColumnName("婚姻状态 ")]
        public int? EeWedlock { get; set; }

        [ExcelColumn(Name = "民族 ")]
        [ExcelColumnName("民族 ")]
        public int? EeNationId { get; set; }

        [ExcelColumn(Name = "籍贯 ")]
        [ExcelColumnName("籍贯 ")]
        public int? EeNativePlace { get; set; }

        [ExcelColumn(Name = "政治面貌 ")]
        [ExcelColumnName("政治面貌 ")]
        public int? EePoliticId { get; set; }

        [ExcelColumn(Name = "邮件 ")]
        [ExcelColumnName("邮件 ")]
        public string EeEmail { get; set; }

        [ExcelColumn(Name = "电话 ")]
        [ExcelColumnName("电话 ")]
        public string EePhone { get; set; }

        [ExcelColumn(Name = "国家/地区 ")]
        [ExcelColumnName("国家/地区 ")]
        public string EeCountry { get; set; }

        [ExcelColumn(Name = "省区 ")]
        [ExcelColumnName("省区 ")]
        public string EeProvince { get; set; }

        [ExcelColumn(Name = "市区 ")]
        [ExcelColumnName("市区 ")]
        public string EeCity { get; set; }

        [ExcelColumn(Name = "县区 ")]
        [ExcelColumnName("县区 ")]
        public string EeCounty { get; set; }

        [ExcelColumn(Name = "家庭住址 ")]
        [ExcelColumnName("家庭住址 ")]
        public string EeHomeAddress { get; set; }

        [ExcelColumn(Name = "邮编 ")]
        [ExcelColumnName("邮编 ")]
        public string EePostCode { get; set; }

        [ExcelColumn(Name = "户口性质 ")]
        [ExcelColumnName("户口性质 ")]
        public int? EeHouseholdType { get; set; }

        [ExcelColumn(Name = "暂住地址 ")]
        [ExcelColumnName("暂住地址 ")]
        public string EeStayAddress { get; set; }

        [ExcelColumn(Name = "部门 ")]
        [ExcelColumnName("部门 ")]
        public int? EeDepartmentId { get; set; }

        [ExcelColumn(Name = "职称 ")]
        [ExcelColumnName("职称 ")]
        public int? EeTitlesId { get; set; }

        [ExcelColumn(Name = "职位 ")]
        [ExcelColumnName("职位 ")]
        public int? EePostId { get; set; }

        [ExcelColumn(Name = "职级 ")]
        [ExcelColumnName("职级 ")]
        public int? EePostLevel { get; set; }

        [ExcelColumn(Name = "职务 ")]
        [ExcelColumnName("职务 ")]
        public int? EeDutyName { get; set; }

        [ExcelColumn(Name = "招聘来源 ")]
        [ExcelColumnName("招聘来源 ")]
        public int? EeRecruited { get; set; }

        [ExcelColumn(Name = "聘用形式 ")]
        [ExcelColumnName("聘用形式 ")]
        public string EeEngageForm { get; set; }

        [ExcelColumn(Name = "学历 ")]
        [ExcelColumnName("学历 ")]
        public int? EeTiptopDegrEe { get; set; }

        [ExcelColumn(Name = "专业 ")]
        [ExcelColumnName("专业 ")]
        public int? EeSpecialty { get; set; }

        [ExcelColumn(Name = "院校 ")]
        [ExcelColumnName("院校 ")]
        public string EeSchool { get; set; }

        [Required(ErrorMessage = "工号 不能为空")]
        [ExcelColumn(Name = "工号 ")]
        [ExcelColumnName("工号 ")]
        public string EeWorkID { get; set; }

        [ExcelColumn(Name = "入职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入职日期")]
        public DateTime? EeBeginDate { get; set; }

        [ExcelColumn(Name = "在职状态 ")]
        [ExcelColumnName("在职状态 ")]
        public int? EeWorkState { get; set; }

        [ExcelColumn(Name = "试用期 ")]
        [ExcelColumnName("试用期 ")]
        public int? EeProbation { get; set; }

        [ExcelColumn(Name = "合同期限 ")]
        [ExcelColumnName("合同期限 ")]
        public int? EeContractTerm { get; set; }

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
        public DateTime? EeEndContract { get; set; }

        [ExcelColumn(Name = "工龄 ")]
        [ExcelColumnName("工龄 ")]
        public int? EeWorkAge { get; set; }

        [ExcelColumn(Name = "退休日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("退休日期")]
        public DateTime? EeRetireDate { get; set; }

        [ExcelColumn(Name = "打卡否 ")]
        [ExcelColumnName("打卡否 ")]
        public int? EeClockIn { get; set; }

        [ExcelColumn(Name = "班别 ")]
        [ExcelColumnName("班别 ")]
        public int? EeShiftsType { get; set; }

        [ExcelColumn(Name = "头像 ")]
        [ExcelColumnName("头像 ")]
        public string EeAvatar { get; set; }

        [ExcelColumn(Name = "学历附件 ")]
        [ExcelColumnName("学历附件 ")]
        public string EeQualificationAnnex { get; set; }

        [ExcelColumn(Name = "职称附件 ")]
        [ExcelColumnName("职称附件 ")]
        public string EeTitleAnnex { get; set; }

        [ExcelColumn(Name = "预留A ")]
        [ExcelColumnName("预留A ")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B ")]
        [ExcelColumnName("预留B ")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C ")]
        [ExcelColumnName("预留C ")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1 ")]
        [ExcelColumnName("预留1 ")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2 ")]
        [ExcelColumnName("预留2 ")]
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

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
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
        [ExcelColumn(Name = "性别 ")]
        public string EeGenderLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "婚姻状态 ")]
        public string EeWedlockLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "民族 ")]
        public string EeNationIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "籍贯 ")]
        public string EeNativePlaceLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "政治面貌 ")]
        public string EePoliticIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "国家/地区 ")]
        public string EeCountryLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "省区 ")]
        public string EeProvinceLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "市区 ")]
        public string EeCityLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "户口性质 ")]
        public string EeHouseholdTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "部门 ")]
        public string EeDepartmentIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "职称 ")]
        public string EeTitlesIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "职位 ")]
        public string EePostIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "职级 ")]
        public string EePostLevelLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "招聘来源 ")]
        public string EeRecruitedLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "聘用形式 ")]
        public string EeEngageFormLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "学历 ")]
        public string EeTiptopDegrEeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "专业 ")]
        public string EeSpecialtyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "在职状态 ")]
        public string EeWorkStateLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "打卡否 ")]
        public string EeClockInLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "班别 ")]
        public string EeShiftsTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}