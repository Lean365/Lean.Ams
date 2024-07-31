namespace Ams.Model.Routine
{
    /// <summary>
    /// 人事
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 16:57:41
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
        [SugarColumn(ColumnName = "EeName", ColumnDescription = "姓名 ", Length = 40)]
        public string EeName { get; set; }

        /// <summary>
        /// 曾用名
        /// </summary>
        [SugarColumn(ColumnName = "EeNameUsed", ColumnDescription = "曾用名 ", Length = 40)]
        public string EeNameUsed { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(ColumnName = "EeNickName", ColumnDescription = "昵称 ", Length = 40)]
        public string EeNickName { get; set; }

        /// <summary>
        /// 英文名
        /// </summary>
        [SugarColumn(ColumnName = "EeEnglishName", ColumnDescription = "英文名 ", Length = 200)]
        public string EeEnglishName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [SugarColumn(ColumnName = "EeGender", ColumnDescription = "性别 ", Length = 4)]
        public string EeGender { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? EeBirthday { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [SugarColumn(ColumnName = "EeIdentityCard", ColumnDescription = "身份证号 ", Length = 18)]
        public string EeIdentityCard { get; set; }

        /// <summary>
        /// 婚姻状态
        /// </summary>
        [SugarColumn(ColumnName = "EeWedlock", ColumnDescription = "婚姻状态 ", DefaultValue = "0")]
        public int EeWedlock { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [SugarColumn(ColumnName = "EeNationId", ColumnDescription = "民族 ", DefaultValue = "0")]
        public int EeNationId { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        [SugarColumn(ColumnName = "EeNativePlace", ColumnDescription = "籍贯 ", DefaultValue = "0")]
        public int EeNativePlace { get; set; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        [SugarColumn(ColumnName = "EePoliticId", ColumnDescription = "政治面貌 ", DefaultValue = "0")]
        public int EePoliticId { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        [SugarColumn(ColumnName = "EeEmail", ColumnDescription = "邮件 ", Length = 20)]
        public string EeEmail { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [SugarColumn(ColumnName = "EePhone", ColumnDescription = "电话 ", Length = 11)]
        public string EePhone { get; set; }

        /// <summary>
        /// 国家/地区
        /// </summary>
        [SugarColumn(ColumnName = "EeCountry", ColumnDescription = "国家/地区 ", Length = 2)]
        public string EeCountry { get; set; }

        /// <summary>
        /// 省区
        /// </summary>
        [SugarColumn(ColumnName = "EeProvince", ColumnDescription = "省区 ", Length = 10)]
        public string EeProvince { get; set; }

        /// <summary>
        /// 市区
        /// </summary>
        [SugarColumn(ColumnName = "EeCity", ColumnDescription = "市区 ", Length = 10)]
        public string EeCity { get; set; }

        /// <summary>
        /// 县区
        /// </summary>
        [SugarColumn(ColumnName = "EeCounty", ColumnDescription = "县区 ", Length = 10)]
        public string EeCounty { get; set; }

        /// <summary>
        /// 家庭住址
        /// </summary>
        [SugarColumn(ColumnName = "EeHomeAddress", ColumnDescription = "家庭住址 ", Length = 128)]
        public string EeHomeAddress { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        [SugarColumn(ColumnName = "EePostCode", ColumnDescription = "邮编 ", Length = 8)]
        public string EePostCode { get; set; }

        /// <summary>
        /// 户口性质
        /// </summary>
        [SugarColumn(ColumnName = "EeHouseholdType", ColumnDescription = "户口性质 ", DefaultValue = "0")]
        public int? EeHouseholdType { get; set; }

        /// <summary>
        /// 暂住地址
        /// </summary>
        [SugarColumn(ColumnName = "EeStayAddress", ColumnDescription = "暂住地址 ", Length = 128)]
        public string EeStayAddress { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "EeDepartmentId", ColumnDescription = "部门 ", DefaultValue = "0")]
        public int EeDepartmentId { get; set; }

        /// <summary>
        /// 职称
        /// </summary>
        [SugarColumn(ColumnName = "EeTitlesId", ColumnDescription = "职称 ", DefaultValue = "0")]
        public int EeTitlesId { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [SugarColumn(ColumnName = "EePostId", ColumnDescription = "职位 ", DefaultValue = "0")]
        public int EePostId { get; set; }

        /// <summary>
        /// 职级
        /// </summary>
        [SugarColumn(ColumnName = "EePostLevel", ColumnDescription = "职级 ", DefaultValue = "0")]
        public int EePostLevel { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        [SugarColumn(ColumnName = "EeDutyName", ColumnDescription = "职务 ", DefaultValue = "0")]
        public int EeDutyName { get; set; }

        /// <summary>
        /// 招聘来源
        /// </summary>
        [SugarColumn(ColumnName = "EeRecruited", ColumnDescription = "招聘来源 ", DefaultValue = "0")]
        public int EeRecruited { get; set; }

        /// <summary>
        /// 聘用形式
        /// </summary>
        [SugarColumn(ColumnName = "EeEngageForm", ColumnDescription = "聘用形式 ", Length = 8)]
        public string EeEngageForm { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        [SugarColumn(ColumnName = "EeTiptopDegrEe", ColumnDescription = "学历 ", DefaultValue = "0")]
        public int? EeTiptopDegrEe { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        [SugarColumn(ColumnName = "EeSpecialty", ColumnDescription = "专业 ", DefaultValue = "0")]
        public int? EeSpecialty { get; set; }

        /// <summary>
        /// 院校
        /// </summary>
        [SugarColumn(ColumnName = "EeSchool", ColumnDescription = "院校 ", Length = 32)]
        public string EeSchool { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [SugarColumn(ColumnName = "EeWorkID", ColumnDescription = "工号 ", Length = 8)]
        public string EeWorkID { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime? EeBeginDate { get; set; }

        /// <summary>
        /// 在职状态
        /// </summary>
        [SugarColumn(ColumnName = "EeWorkState", ColumnDescription = "在职状态 ", DefaultValue = "0")]
        public int? EeWorkState { get; set; }

        /// <summary>
        /// 试用期
        /// </summary>
        [SugarColumn(ColumnName = "EeProbation", ColumnDescription = "试用期 ", DefaultValue = "0")]
        public int? EeProbation { get; set; }

        /// <summary>
        /// 合同期限
        /// </summary>
        [SugarColumn(ColumnName = "EeContractTerm", ColumnDescription = "合同期限 ", DefaultValue = "0")]
        public int? EeContractTerm { get; set; }

        /// <summary>
        /// 转正日期
        /// </summary>
        public DateTime? EeConversionTime { get; set; }

        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime? EeLeaveDate { get; set; }

        /// <summary>
        /// 合同起始日
        /// </summary>
        public DateTime? EeBeginContract { get; set; }

        /// <summary>
        /// 合同终止日
        /// </summary>
        public DateTime? EeEndContract { get; set; }

        /// <summary>
        /// 工龄
        /// </summary>
        [SugarColumn(ColumnName = "EeWorkAge", ColumnDescription = "工龄 ", DefaultValue = "0")]
        public int? EeWorkAge { get; set; }

        /// <summary>
        /// 退休日期
        /// </summary>
        public DateTime? EeRetireDate { get; set; }

        /// <summary>
        /// 打卡否
        /// </summary>
        [SugarColumn(ColumnName = "EeClockIn", ColumnDescription = "打卡否 ", DefaultValue = "0")]
        public int? EeClockIn { get; set; }

        /// <summary>
        /// 班别
        /// </summary>
        [SugarColumn(ColumnName = "EeShiftsType", ColumnDescription = "班别 ", DefaultValue = "0")]
        public int? EeShiftsType { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [SugarColumn(ColumnName = "EeAvatar", ColumnDescription = "头像 ", Length = 255)]
        public string EeAvatar { get; set; }

        /// <summary>
        /// 学历附件
        /// </summary>
        [SugarColumn(ColumnName = "EeQualificationAnnex", ColumnDescription = "学历附件 ", Length = 255)]
        public string EeQualificationAnnex { get; set; }

        /// <summary>
        /// 职称附件
        /// </summary>
        [SugarColumn(ColumnName = "EeTitleAnnex", ColumnDescription = "职称附件 ", Length = 255)]
        public string EeTitleAnnex { get; set; }
    }
}