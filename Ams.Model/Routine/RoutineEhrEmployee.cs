
namespace Ams.Model.Routine
{
    /// <summary>
    /// 人事信息
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:48:53
    /// </summary>
    [SugarTable("routine_ehr_employee","人事信息")]
    public class RoutineEhrEmployee
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long EeSFID { get; set; }

        /// <summary>
        /// 姓名 
        /// </summary>
        public string EeName { get; set; }

        /// <summary>
        /// 曾用名 
        /// </summary>
        public string EeNameUsed { get; set; }

        /// <summary>
        /// 昵称 
        /// </summary>
        public string EeNickName { get; set; }

        /// <summary>
        /// 英文名 
        /// </summary>
        public string EeEnglishName { get; set; }

        /// <summary>
        /// 性别 
        /// </summary>
        public string EeGender { get; set; }

        /// <summary>
        /// 出生日期 
        /// </summary>
        public DateTime? EeBirthday { get; set; }

        /// <summary>
        /// 身份证号 
        /// </summary>
        public string EeIdentityCard { get; set; }

        /// <summary>
        /// 婚姻状态 
        /// </summary>
        public string EeWedlock { get; set; }

        /// <summary>
        /// 民族 
        /// </summary>
        public string EeNationId { get; set; }

        /// <summary>
        /// 籍贯 
        /// </summary>
        public string EeNativePlace { get; set; }

        /// <summary>
        /// 政治面貌 
        /// </summary>
        public string EePoliticId { get; set; }

        /// <summary>
        /// 邮件 
        /// </summary>
        public string EeEmail { get; set; }

        /// <summary>
        /// 电话 
        /// </summary>
        public string EePhone { get; set; }

        /// <summary>
        /// 国家/地区 
        /// </summary>
        public string EeCountry { get; set; }

        /// <summary>
        /// 省区 
        /// </summary>
        public string EeProvince { get; set; }

        /// <summary>
        /// 市区 
        /// </summary>
        public string EeCity { get; set; }

        /// <summary>
        /// 县区 
        /// </summary>
        public string EeCounty { get; set; }

        /// <summary>
        /// 家庭住址 
        /// </summary>
        public string EeHomeAddress { get; set; }

        /// <summary>
        /// 邮编 
        /// </summary>
        public string EePostCode { get; set; }

        /// <summary>
        /// 户口性质 
        /// </summary>
        public string EeHouseholdType { get; set; }

        /// <summary>
        /// 暂住地址 
        /// </summary>
        public string EeStayAddress { get; set; }

        /// <summary>
        /// 部门 
        /// </summary>
        public int EeDepartmentId { get; set; }

        /// <summary>
        /// 职称 
        /// </summary>
        public int EeTitlesId { get; set; }

        /// <summary>
        /// 职位 
        /// </summary>
        public int EePostId { get; set; }

        /// <summary>
        /// 职级 
        /// </summary>
        public int EePostLevel { get; set; }

        /// <summary>
        /// 职务 
        /// </summary>
        public int EeDutyName { get; set; }

        /// <summary>
        /// 招聘来源 
        /// </summary>
        public int EeRecruited { get; set; }

        /// <summary>
        /// 聘用形式 
        /// </summary>
        public string EeEngageForm { get; set; }

        /// <summary>
        /// 学历 
        /// </summary>
        public int? EeTiptopDegrEe { get; set; }

        /// <summary>
        /// 专业 
        /// </summary>
        public int? EeSpecialty { get; set; }

        /// <summary>
        /// 院校 
        /// </summary>
        public string EeSchool { get; set; }

        /// <summary>
        /// 工号 
        /// </summary>
        public string EeWorkID { get; set; }

        /// <summary>
        /// 入职日期 
        /// </summary>
        public DateTime? EeBeginDate { get; set; }

        /// <summary>
        /// 在职状态 
        /// </summary>
        public string EeWorkState { get; set; }

        /// <summary>
        /// 试用期 
        /// </summary>
        public string EeProbation { get; set; }

        /// <summary>
        /// 合同期限 
        /// </summary>
        public string EeContractTerm { get; set; }

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
        public DateTime? EeBndContract { get; set; }

        /// <summary>
        /// 工龄 
        /// </summary>
        public int? EeWorkAge { get; set; }

        /// <summary>
        /// 头像 
        /// </summary>
        public string EeAvatar { get; set; }

        /// <summary>
        /// 学历附件 
        /// </summary>
        public string EeQualificationAnnex { get; set; }

        /// <summary>
        /// 职称附件 
        /// </summary>
        public string EeTitleAnnex { get; set; }

        /// <summary>
        /// 自定义A 
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B 
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C 
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D 
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E 
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F 
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6 
        /// </summary>
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        public int IsDeleted { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建者 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新者 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 更新时间 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }

    }
}