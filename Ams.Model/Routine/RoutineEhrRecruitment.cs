namespace Ams.Model.Routine
{
    /// <summary>
    /// 招聘
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/18 15:46:34
    /// </summary>
    [SugarTable("routine_ehr_recruitment", "招聘")]
    public class RoutineEhrRecruitment : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 招聘起始日
        /// </summary>
        public DateTime? Mn002 { get; set; }

        /// <summary>
        /// 招聘截止日
        /// </summary>
        public DateTime? Mn003 { get; set; }

        /// <summary>
        /// 招聘部门
        /// </summary>
        [SugarColumn(ColumnName = "Mn004", ColumnDescription = "招聘部门", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn004 { get; set; }

        /// <summary>
        /// 招聘职位
        /// </summary>
        [SugarColumn(ColumnName = "Mn005", ColumnDescription = "招聘职位", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int? Mn005 { get; set; }

        /// <summary>
        /// 薪资范围
        /// </summary>
        [SugarColumn(ColumnName = "Mn006", ColumnDescription = "薪资范围", Length = 50, ColumnDataType = "NVARCHAR", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mn006 { get; set; }

        /// <summary>
        /// 紧急程度
        /// </summary>
        [SugarColumn(ColumnName = "Mn007", ColumnDescription = "紧急程度", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn007 { get; set; }

        /// <summary>
        /// 工作城市
        /// </summary>
        [SugarColumn(ColumnName = "Mn008", ColumnDescription = "工作城市", Length = 10, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mn008 { get; set; }

        /// <summary>
        /// 工作经验
        /// </summary>
        [SugarColumn(ColumnName = "Mn009", ColumnDescription = "工作经验", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn009 { get; set; }

        /// <summary>
        /// 学历要求
        /// </summary>
        [SugarColumn(ColumnName = "Mn010", ColumnDescription = "学历要求", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn010 { get; set; }

        /// <summary>
        /// 聘用形式
        /// </summary>
        [SugarColumn(ColumnName = "Mn011", ColumnDescription = "聘用形式", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn011 { get; set; }

        /// <summary>
        /// 到岗日期
        /// </summary>
        public DateTime? Mn012 { get; set; }

        /// <summary>
        /// 年龄要求
        /// </summary>
        [SugarColumn(ColumnName = "Mn013", ColumnDescription = "年龄要求", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn013 { get; set; }

        /// <summary>
        /// 面试否
        /// </summary>
        [SugarColumn(ColumnName = "Mn014", ColumnDescription = "面试否", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn014 { get; set; }

        /// <summary>
        /// 招聘人数
        /// </summary>
        [SugarColumn(ColumnName = "Mn015", ColumnDescription = "招聘人数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn015 { get; set; }

        /// <summary>
        /// 招聘原因
        /// </summary>
        [SugarColumn(ColumnName = "Mn016", ColumnDescription = "招聘原因", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn016 { get; set; }

        /// <summary>
        /// 试用期限
        /// </summary>
        [SugarColumn(ColumnName = "Mn017", ColumnDescription = "试用期限", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn017 { get; set; }

        /// <summary>
        /// 招聘状态
        /// </summary>
        [SugarColumn(ColumnName = "Mn018", ColumnDescription = "招聘状态", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn018 { get; set; }

        /// <summary>
        /// 相关资格证书
        /// </summary>
        [SugarColumn(ColumnName = "Mn019", ColumnDescription = "相关资格证书", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mn019 { get; set; }

        /// <summary>
        /// 岗位描述
        /// </summary>
        [SugarColumn(ColumnName = "Mn020", ColumnDescription = "岗位描述", Length = 1000, ColumnDataType = "NVARCHAR", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mn020 { get; set; }

        /// <summary>
        /// 面试官
        /// </summary>
        [SugarColumn(ColumnName = "Mn021", ColumnDescription = "面试官", Length = 64)]
        public string Mn021 { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        [SugarColumn(ColumnName = "Mn022", ColumnDescription = "负责人", Length = 64)]
        public string Mn022 { get; set; }
    }
}