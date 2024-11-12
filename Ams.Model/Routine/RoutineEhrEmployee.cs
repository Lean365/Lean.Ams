namespace Ams.Model.Routine
{
    /// <summary>
    /// 人事
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/31 17:15:08
    /// </summary>
    [SugarTable("routine_ehr_employee", "人事")]
    public class RoutineEhrEmployee : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [SugarColumn(ColumnName = "Mh002", ColumnDescription = "姓名", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mh002 { get; set; }

        /// <summary>
        /// 曾用名
        /// </summary>
        [SugarColumn(ColumnName = "Mh003", ColumnDescription = "曾用名", Length = 40)]
        public string Mh003 { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(ColumnName = "Mh004", ColumnDescription = "昵称", Length = 40)]
        public string Mh004 { get; set; }

        /// <summary>
        /// 英文名
        /// </summary>
        [SugarColumn(ColumnName = "Mh005", ColumnDescription = "英文名", Length = 200)]
        public string Mh005 { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [SugarColumn(ColumnName = "Mh006", ColumnDescription = "性别", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh006 { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Mh007 { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [SugarColumn(ColumnName = "Mh008", ColumnDescription = "身份证号", Length = 18)]
        public string Mh008 { get; set; }

        /// <summary>
        /// 婚姻状态
        /// </summary>
        [SugarColumn(ColumnName = "Mh009", ColumnDescription = "婚姻状态", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh009 { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [SugarColumn(ColumnName = "Mh010", ColumnDescription = "民族", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh010 { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        [SugarColumn(ColumnName = "Mh011", ColumnDescription = "籍贯", Length = 100)]
        public string Mh011 { get; set; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        [SugarColumn(ColumnName = "Mh012", ColumnDescription = "政治面貌", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh012 { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        [SugarColumn(ColumnName = "Mh013", ColumnDescription = "邮件", Length = 200)]
        public string Mh013 { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [SugarColumn(ColumnName = "Mh014", ColumnDescription = "电话", Length = 40)]
        public string Mh014 { get; set; }

        /// <summary>
        /// 国家/地区
        /// </summary>
        [SugarColumn(ColumnName = "Mh015", ColumnDescription = "国家/地区", Length = 2)]
        public string Mh015 { get; set; }

        /// <summary>
        /// 省区
        /// </summary>
        [SugarColumn(ColumnName = "Mh016", ColumnDescription = "省区", Length = 10)]
        public string Mh016 { get; set; }

        /// <summary>
        /// 市区
        /// </summary>
        [SugarColumn(ColumnName = "Mh017", ColumnDescription = "市区", Length = 30)]
        public string Mh017 { get; set; }

        /// <summary>
        /// 县区
        /// </summary>
        [SugarColumn(ColumnName = "Mh018", ColumnDescription = "县区", Length = 50)]
        public string Mh018 { get; set; }

        /// <summary>
        /// 家庭住址
        /// </summary>
        [SugarColumn(ColumnName = "Mh019", ColumnDescription = "家庭住址", Length = 128)]
        public string Mh019 { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        [SugarColumn(ColumnName = "Mh020", ColumnDescription = "邮编", Length = 8)]
        public string Mh020 { get; set; }

        /// <summary>
        /// 户口性质
        /// </summary>
        [SugarColumn(ColumnName = "Mh021", ColumnDescription = "户口性质", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh021 { get; set; }

        /// <summary>
        /// 暂住地址
        /// </summary>
        [SugarColumn(ColumnName = "Mh022", ColumnDescription = "暂住地址", Length = 128)]
        public string Mh022 { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "Mh023", ColumnDescription = "部门", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh023 { get; set; }

        /// <summary>
        /// 职称
        /// </summary>
        [SugarColumn(ColumnName = "Mh024", ColumnDescription = "职称", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh024 { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [SugarColumn(ColumnName = "Mh025", ColumnDescription = "职位", Length = 3, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mh025 { get; set; }

        /// <summary>
        /// 职级
        /// </summary>
        [SugarColumn(ColumnName = "Mh026", ColumnDescription = "职级", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh026 { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        [SugarColumn(ColumnName = "Mh027", ColumnDescription = "职务", Length = 3, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mh027 { get; set; }

        /// <summary>
        /// 招聘来源
        /// </summary>
        [SugarColumn(ColumnName = "Mh028", ColumnDescription = "招聘来源", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh028 { get; set; }

        /// <summary>
        /// 聘用形式
        /// </summary>
        [SugarColumn(ColumnName = "Mh029", ColumnDescription = "聘用形式", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh029 { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        [SugarColumn(ColumnName = "Mh030", ColumnDescription = "学历", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh030 { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        [SugarColumn(ColumnName = "Mh031", ColumnDescription = "专业", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh031 { get; set; }

        /// <summary>
        /// 院校
        /// </summary>
        [SugarColumn(ColumnName = "Mh032", ColumnDescription = "院校", Length = 100)]
        public string Mh032 { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [SugarColumn(ColumnName = "Mh033", ColumnDescription = "工号", Length = 8, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mh033 { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime? Mh034 { get; set; }

        /// <summary>
        /// 在职状态
        /// </summary>
        [SugarColumn(ColumnName = "Mh035", ColumnDescription = "在职状态", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh035 { get; set; }

        /// <summary>
        /// 试用期
        /// </summary>
        [SugarColumn(ColumnName = "Mh036", ColumnDescription = "试用期", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh036 { get; set; }

        /// <summary>
        /// 合同期限
        /// </summary>
        [SugarColumn(ColumnName = "Mh037", ColumnDescription = "合同期限", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh037 { get; set; }

        /// <summary>
        /// 转正日期
        /// </summary>
        public DateTime? Mh038 { get; set; }

        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime? Mh039 { get; set; }

        /// <summary>
        /// 合同起始日
        /// </summary>
        public DateTime? Mh040 { get; set; }

        /// <summary>
        /// 合同终止日
        /// </summary>
        public DateTime? Mh041 { get; set; }

        /// <summary>
        /// 工龄
        /// </summary>
        [SugarColumn(ColumnName = "Mh042", ColumnDescription = "工龄", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh042 { get; set; }

        /// <summary>
        /// 退休日期
        /// </summary>
        public DateTime? Mh043 { get; set; }

        /// <summary>
        /// 打卡否
        /// </summary>
        [SugarColumn(ColumnName = "Mh044", ColumnDescription = "打卡否", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh044 { get; set; }

        /// <summary>
        /// 班别
        /// </summary>
        [SugarColumn(ColumnName = "Mh045", ColumnDescription = "班别", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh045 { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [SugarColumn(ColumnName = "Mh046", ColumnDescription = "头像", Length = 255)]
        public string Mh046 { get; set; }

        /// <summary>
        /// 学历附件
        /// </summary>
        [SugarColumn(ColumnName = "Mh047", ColumnDescription = "学历附件", Length = 255)]
        public string Mh047 { get; set; }

        /// <summary>
        /// 职称附件
        /// </summary>
        [SugarColumn(ColumnName = "Mh048", ColumnDescription = "职称附件", Length = 255)]
        public string Mh048 { get; set; }

        /// <summary>
        /// 系统访问
        /// </summary>
        [SugarColumn(ColumnName = "Mh049", ColumnDescription = "系统访问", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int? Mh049 { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [SugarColumn(ColumnName = "Mh050", ColumnDescription = "年龄", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int? Mh050 { get; set; }

        /// <summary>
        /// 有效日
        /// </summary>
        public DateTime? Mh051 { get; set; }

        /// <summary>
        /// 过期日
        /// </summary>
        public DateTime? Mh052 { get; set; }
    }
}