
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 人事信息
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:48:53
    /// </summary>
    public class RoutineEhrEmployeeQueryDto : PagerInfo 
    {
        public string EeName { get; set; }
        public string EeEnglishName { get; set; }
        public string EeGender { get; set; }
        public DateTime? BeginEeBirthday { get; set; }
        public DateTime? EndEeBirthday { get; set; }
        public string EeIdentityCard { get; set; }
        public string EeWedlock { get; set; }
        public string EeNationId { get; set; }
        public string EeNativePlace { get; set; }
        public string EePoliticId { get; set; }
        public string EeCountry { get; set; }
        public string EeHouseholdType { get; set; }
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
        public string EeWorkState { get; set; }
    }

    /// <summary>
    /// 人事信息
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:48:53
    /// </summary>
    public class RoutineEhrEmployeeDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long EeSFID { get; set; }

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
        public string EeGender { get; set; }

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
        public string EeWedlock { get; set; }

        [Required(ErrorMessage = "民族不能为空")]
        [ExcelColumn(Name = "民族")]
        [ExcelColumnName("民族")]
        public string EeNationId { get; set; }

        [Required(ErrorMessage = "籍贯不能为空")]
        [ExcelColumn(Name = "籍贯")]
        [ExcelColumnName("籍贯")]
        public string EeNativePlace { get; set; }

        [Required(ErrorMessage = "政治面貌不能为空")]
        [ExcelColumn(Name = "政治面貌")]
        [ExcelColumnName("政治面貌")]
        public string EePoliticId { get; set; }

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

        [Required(ErrorMessage = "家庭住址不能为空")]
        [ExcelColumn(Name = "家庭住址")]
        [ExcelColumnName("家庭住址")]
        public string EeHomeAddress { get; set; }

        [ExcelColumn(Name = "邮编")]
        [ExcelColumnName("邮编")]
        public string EePostCode { get; set; }

        [ExcelColumn(Name = "户口性质")]
        [ExcelColumnName("户口性质")]
        public string EeHouseholdType { get; set; }

        [ExcelColumn(Name = "暂住地址")]
        [ExcelColumnName("暂住地址")]
        public string EeStayAddress { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        [ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public int EeDepartmentId { get; set; }

        [Required(ErrorMessage = "职称不能为空")]
        [ExcelColumn(Name = "职称")]
        [ExcelColumnName("职称")]
        public int EeTitlesId { get; set; }

        [Required(ErrorMessage = "职位不能为空")]
        [ExcelColumn(Name = "职位")]
        [ExcelColumnName("职位")]
        public int EePostId { get; set; }

        [Required(ErrorMessage = "职级不能为空")]
        [ExcelColumn(Name = "职级")]
        [ExcelColumnName("职级")]
        public int EePostLevel { get; set; }

        [Required(ErrorMessage = "职务不能为空")]
        [ExcelColumn(Name = "职务")]
        [ExcelColumnName("职务")]
        public int EeDutyName { get; set; }

        [Required(ErrorMessage = "招聘来源不能为空")]
        [ExcelColumn(Name = "招聘来源")]
        [ExcelColumnName("招聘来源")]
        public int EeRecruited { get; set; }

        [ExcelColumn(Name = "聘用形式")]
        [ExcelColumnName("聘用形式")]
        public string EeEngageForm { get; set; }

        [ExcelColumn(Name = "学历")]
        [ExcelColumnName("学历")]
        public int? EeTiptopDegrEe { get; set; }

        [ExcelColumn(Name = "专业")]
        [ExcelColumnName("专业")]
        public int? EeSpecialty { get; set; }

        [ExcelColumn(Name = "院校")]
        [ExcelColumnName("院校")]
        public string EeSchool { get; set; }

        [ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string EeWorkID { get; set; }

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

        [ExcelColumn(Name = "头像")]
        [ExcelColumnName("头像")]
        public string EeAvatar { get; set; }

        [ExcelColumn(Name = "学历附件")]
        [ExcelColumnName("学历附件")]
        public string EeQualificationAnnex { get; set; }

        [ExcelColumn(Name = "职称附件")]
        [ExcelColumnName("职称附件")]
        public string EeTitleAnnex { get; set; }

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



        [ExcelColumn(Name = "性别")]
        public string EeGenderLabel { get; set; }
        [ExcelColumn(Name = "婚姻状态")]
        public string EeWedlockLabel { get; set; }
        [ExcelColumn(Name = "民族")]
        public string EeNationIdLabel { get; set; }
        [ExcelColumn(Name = "政治面貌")]
        public string EePoliticIdLabel { get; set; }
        [ExcelColumn(Name = "国家/地区")]
        public string EeCountryLabel { get; set; }
        [ExcelColumn(Name = "户口性质")]
        public string EeHouseholdTypeLabel { get; set; }
        [ExcelColumn(Name = "职称")]
        public string EeTitlesIdLabel { get; set; }
        [ExcelColumn(Name = "职位")]
        public string EePostIdLabel { get; set; }
        [ExcelColumn(Name = "职级")]
        public string EePostLevelLabel { get; set; }
        [ExcelColumn(Name = "招聘来源")]
        public string EeRecruitedLabel { get; set; }
        [ExcelColumn(Name = "聘用形式")]
        public string EeEngageFormLabel { get; set; }
        [ExcelColumn(Name = "学历")]
        public string EeTiptopDegrEeLabel { get; set; }
        [ExcelColumn(Name = "专业")]
        public string EeSpecialtyLabel { get; set; }
        [ExcelColumn(Name = "在职状态")]
        public string EeWorkStateLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}