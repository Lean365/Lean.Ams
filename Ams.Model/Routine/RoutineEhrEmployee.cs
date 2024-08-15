namespace Ams.Model.Routine
{
    /// <summary>
    /// 人事
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 8:47:39
    /// </summary>
    [SugarTable("routine_ehr_employee", "人事")]
    public class RoutineEhrEmployee : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long EeSfId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [SugarColumn(ColumnName = "EeName", ColumnDescription = "姓名", Length = 40)]
        public string EeName { get; set; }

        /// <summary>
        /// 曾用名
        /// </summary>
        [SugarColumn(ColumnName = "EeNameUsed", ColumnDescription = "曾用名", Length = 40)]
        public string EeNameUsed { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(ColumnName = "EeNickName", ColumnDescription = "昵称", Length = 40)]
        public string EeNickName { get; set; }

        /// <summary>
        /// 英文名
        /// </summary>
        [SugarColumn(ColumnName = "EeEnglishName", ColumnDescription = "英文名", Length = 200)]
        public string EeEnglishName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [SugarColumn(ColumnName = "EeGenderId", ColumnDescription = "性别", DefaultValue = "0")]
        public int EeGenderId { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? EeBirthday { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [SugarColumn(ColumnName = "EeIdentityCard", ColumnDescription = "身份证号", Length = 18)]
        public string EeIdentityCard { get; set; }

        /// <summary>
        /// 婚姻状态
        /// </summary>
        [SugarColumn(ColumnName = "EeWedlockId", ColumnDescription = "婚姻状态", DefaultValue = "0")]
        public int EeWedlockId { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [SugarColumn(ColumnName = "EeNationId", ColumnDescription = "民族", DefaultValue = "0")]
        public int EeNationId { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        [SugarColumn(ColumnName = "EeNativePlace", ColumnDescription = "籍贯", Length = 100)]
        public string EeNativePlace { get; set; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        [SugarColumn(ColumnName = "EePoliticId", ColumnDescription = "政治面貌", DefaultValue = "0")]
        public int EePoliticId { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        [SugarColumn(ColumnName = "EeEmail", ColumnDescription = "邮件", Length = 20)]
        public string EeEmail { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [SugarColumn(ColumnName = "EePhone", ColumnDescription = "电话", Length = 11)]
        public string EePhone { get; set; }

        /// <summary>
        /// 国家/地区
        /// </summary>
        [SugarColumn(ColumnName = "EeCountry", ColumnDescription = "国家/地区", Length = 2)]
        public string EeCountry { get; set; }

        /// <summary>
        /// 省区
        /// </summary>
        [SugarColumn(ColumnName = "EeProvince", ColumnDescription = "省区", Length = 10)]
        public string EeProvince { get; set; }

        /// <summary>
        /// 市区
        /// </summary>
        [SugarColumn(ColumnName = "EeCity", ColumnDescription = "市区", Length = 30)]
        public string EeCity { get; set; }

        /// <summary>
        /// 县区
        /// </summary>
        [SugarColumn(ColumnName = "EeCounty", ColumnDescription = "县区", Length = 50)]
        public string EeCounty { get; set; }

        /// <summary>
        /// 家庭住址
        /// </summary>
        [SugarColumn(ColumnName = "EeHomeAddress", ColumnDescription = "家庭住址", Length = 128)]
        public string EeHomeAddress { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        [SugarColumn(ColumnName = "EePostCode", ColumnDescription = "邮编", Length = 8)]
        public string EePostCode { get; set; }

        /// <summary>
        /// 户口性质
        /// </summary>
        [SugarColumn(ColumnName = "EeHouseholdTypeId", ColumnDescription = "户口性质", DefaultValue = "0")]
        public int EeHouseholdTypeId { get; set; }

        /// <summary>
        /// 暂住地址
        /// </summary>
        [SugarColumn(ColumnName = "EeStayAddress", ColumnDescription = "暂住地址", Length = 128)]
        public string EeStayAddress { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "EeDepartmentId", ColumnDescription = "部门", DefaultValue = "0")]
        public int EeDepartmentId { get; set; }

        /// <summary>
        /// 职称
        /// </summary>
        [SugarColumn(ColumnName = "EeTitlesId", ColumnDescription = "职称", DefaultValue = "0")]
        public int? EeTitlesId { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [SugarColumn(ColumnName = "EePostId", ColumnDescription = "职位", DefaultValue = "0")]
        public int? EePostId { get; set; }

        /// <summary>
        /// 职级
        /// </summary>
        [SugarColumn(ColumnName = "EePostLevel", ColumnDescription = "职级", DefaultValue = "0")]
        public int? EePostLevel { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        [SugarColumn(ColumnName = "EeDutyId", ColumnDescription = "职务", DefaultValue = "0")]
        public int? EeDutyId { get; set; }

        /// <summary>
        /// 招聘来源
        /// </summary>
        [SugarColumn(ColumnName = "EeRecruited", ColumnDescription = "招聘来源", DefaultValue = "0")]
        public int? EeRecruited { get; set; }

        /// <summary>
        /// 聘用形式
        /// </summary>
        [SugarColumn(ColumnName = "EeEngageFormId", ColumnDescription = "聘用形式", DefaultValue = "0")]
        public int? EeEngageFormId { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        [SugarColumn(ColumnName = "EeEducationalBackgroundId", ColumnDescription = "学历", DefaultValue = "0")]
        public int? EeEducationalBackgroundId { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        [SugarColumn(ColumnName = "EeSpecialtyId", ColumnDescription = "专业", DefaultValue = "0")]
        public int? EeSpecialtyId { get; set; }

        /// <summary>
        /// 院校
        /// </summary>
        [SugarColumn(ColumnName = "EeCollegeName", ColumnDescription = "院校", Length = 100)]
        public string EeCollegeName { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [SugarColumn(ColumnName = "EeEmployeeId", ColumnDescription = "工号", Length = 8)]
        public string EeEmployeeId { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime? EeJoinedDate { get; set; }

        /// <summary>
        /// 在职状态
        /// </summary>
        [SugarColumn(ColumnName = "EeEmployedStatus", ColumnDescription = "在职状态", DefaultValue = "0")]
        public int? EeEmployedStatus { get; set; }

        /// <summary>
        /// 试用期
        /// </summary>
        [SugarColumn(ColumnName = "EeProbationPeriod", ColumnDescription = "试用期", DefaultValue = "0")]
        public int? EeProbationPeriod { get; set; }

        /// <summary>
        /// 合同期限
        /// </summary>
        [SugarColumn(ColumnName = "EeContractPeriod", ColumnDescription = "合同期限", DefaultValue = "0")]
        public int? EeContractPeriod { get; set; }

        /// <summary>
        /// 转正日期
        /// </summary>
        public DateTime? EePositiveDate { get; set; }

        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime? EeLeaveDate { get; set; }

        /// <summary>
        /// 合同起始日
        /// </summary>
        public DateTime? EeContractBeginDate { get; set; }

        /// <summary>
        /// 合同终止日
        /// </summary>
        public DateTime? EeContractEndDate { get; set; }

        /// <summary>
        /// 工龄
        /// </summary>
        [SugarColumn(ColumnName = "EeSeniority", ColumnDescription = "工龄", DefaultValue = "0")]
        public int? EeSeniority { get; set; }

        /// <summary>
        /// 退休日期
        /// </summary>
        public DateTime? EeRetirementDate { get; set; }

        /// <summary>
        /// 打卡否
        /// </summary>
        [SugarColumn(ColumnName = "EeClockInId", ColumnDescription = "打卡否", DefaultValue = "0")]
        public int EeClockInId { get; set; }

        /// <summary>
        /// 班别
        /// </summary>
        [SugarColumn(ColumnName = "EeShiftsTypeId", ColumnDescription = "班别", DefaultValue = "0")]
        public int EeShiftsTypeId { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [SugarColumn(ColumnName = "EeAvatarFileUrl", ColumnDescription = "头像", Length = 255)]
        public string EeAvatarFileUrl { get; set; }

        /// <summary>
        /// 学历附件
        /// </summary>
        [SugarColumn(ColumnName = "EeQualificationFileUrl", ColumnDescription = "学历附件", Length = 255)]
        public string EeQualificationFileUrl { get; set; }

        /// <summary>
        /// 职称附件
        /// </summary>
        [SugarColumn(ColumnName = "EeTitleFileUrl", ColumnDescription = "职称附件", Length = 255)]
        public string EeTitleFileUrl { get; set; }
    }
}