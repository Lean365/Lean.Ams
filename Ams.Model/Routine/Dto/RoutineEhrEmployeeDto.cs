
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 人事
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:25:31
    /// </summary>
    public class RoutineEhrEmployeeQueryDto : PagerInfo 
    {
        /// <summary>
        /// 姓名 
        /// </summary>        
        public string Mh002 { get; set; }
        /// <summary>
        /// 性别 
        /// </summary>        
        public int? Mh006 { get; set; }
        /// <summary>
        /// 出生日期 
        /// </summary>        
        public DateTime? BeginMh007 { get; set; }
        public DateTime? EndMh007 { get; set; }
        /// <summary>
        /// 婚姻状态 
        /// </summary>        
        public int? Mh009 { get; set; }
        /// <summary>
        /// 民族 
        /// </summary>        
        public int? Mh010 { get; set; }
        /// <summary>
        /// 籍贯 
        /// </summary>        
        public string Mh011 { get; set; }
        /// <summary>
        /// 政治面貌 
        /// </summary>        
        public int? Mh012 { get; set; }
        /// <summary>
        /// 国家/地区 
        /// </summary>        
        public string Mh015 { get; set; }
        /// <summary>
        /// 部门 
        /// </summary>        
        public int? Mh023 { get; set; }
        /// <summary>
        /// 职称 
        /// </summary>        
        public int? Mh024 { get; set; }
        /// <summary>
        /// 学历 
        /// </summary>        
        public int? Mh030 { get; set; }
        /// <summary>
        /// 工号 
        /// </summary>        
        public string Mh033 { get; set; }
        /// <summary>
        /// 入职日期 
        /// </summary>        
        public DateTime? BeginMh034 { get; set; }
        public DateTime? EndMh034 { get; set; }
        /// <summary>
        /// 在职状态 
        /// </summary>        
        public int? Mh035 { get; set; }
        /// <summary>
        /// 离职日期 
        /// </summary>        
        public DateTime? BeginMh039 { get; set; }
        public DateTime? EndMh039 { get; set; }
        /// <summary>
        /// 打卡否 
        /// </summary>        
        public int? Mh044 { get; set; }
        /// <summary>
        /// 班别 
        /// </summary>        
        public int? Mh045 { get; set; }
    }

    /// <summary>
    /// 人事
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:25:31
    /// </summary>
    public class RoutineEhrEmployeeDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        //[ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]

        public string Mh002 { get; set; }

        //[ExcelColumn(Name = "曾用名")]
        [ExcelColumnName("曾用名")]

        public string Mh003 { get; set; }

        //[ExcelColumn(Name = "昵称")]
        [ExcelColumnName("昵称")]

        public string Mh004 { get; set; }

        //[ExcelColumn(Name = "英文名")]
        [ExcelColumnName("英文名")]

        public string Mh005 { get; set; }

        [Required(ErrorMessage = "性别不能为空")]
        //[ExcelColumn(Name = "性别")]
        [ExcelColumnName("性别")]

        public int Mh006 { get; set; }

        //[ExcelColumn(Name = "出生日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("出生日期")]

        public DateTime? Mh007 { get; set; }

        //[ExcelColumn(Name = "身份证号")]
        [ExcelColumnName("身份证号")]

        public string Mh008 { get; set; }

        [Required(ErrorMessage = "婚姻状态不能为空")]
        //[ExcelColumn(Name = "婚姻状态")]
        [ExcelColumnName("婚姻状态")]

        public int Mh009 { get; set; }

        [Required(ErrorMessage = "民族不能为空")]
        //[ExcelColumn(Name = "民族")]
        [ExcelColumnName("民族")]

        public int Mh010 { get; set; }

        //[ExcelColumn(Name = "籍贯")]
        [ExcelColumnName("籍贯")]

        public string Mh011 { get; set; }

        [Required(ErrorMessage = "政治面貌不能为空")]
        //[ExcelColumn(Name = "政治面貌")]
        [ExcelColumnName("政治面貌")]

        public int Mh012 { get; set; }

        //[ExcelColumn(Name = "邮件")]
        [ExcelColumnName("邮件")]

        public string Mh013 { get; set; }

        //[ExcelColumn(Name = "电话")]
        [ExcelColumnName("电话")]

        public string Mh014 { get; set; }

        //[ExcelColumn(Name = "国家/地区")]
        [ExcelColumnName("国家/地区")]

        public string Mh015 { get; set; }

        //[ExcelColumn(Name = "省区")]
        [ExcelColumnName("省区")]

        public string Mh016 { get; set; }

        //[ExcelColumn(Name = "市区")]
        [ExcelColumnName("市区")]

        public string Mh017 { get; set; }

        //[ExcelColumn(Name = "县区")]
        [ExcelColumnName("县区")]

        public string Mh018 { get; set; }

        //[ExcelColumn(Name = "家庭住址")]
        [ExcelColumnName("家庭住址")]

        public string Mh019 { get; set; }

        //[ExcelColumn(Name = "邮编")]
        [ExcelColumnName("邮编")]

        public string Mh020 { get; set; }

        [Required(ErrorMessage = "户口性质不能为空")]
        //[ExcelColumn(Name = "户口性质")]
        [ExcelColumnName("户口性质")]

        public int Mh021 { get; set; }

        //[ExcelColumn(Name = "暂住地址")]
        [ExcelColumnName("暂住地址")]

        public string Mh022 { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        //[ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]

        public int Mh023 { get; set; }

        [Required(ErrorMessage = "职称不能为空")]
        //[ExcelColumn(Name = "职称")]
        [ExcelColumnName("职称")]

        public int Mh024 { get; set; }

        [Required(ErrorMessage = "职位不能为空")]
        //[ExcelColumn(Name = "职位")]
        [ExcelColumnName("职位")]

        public int Mh025 { get; set; }

        [Required(ErrorMessage = "职级不能为空")]
        //[ExcelColumn(Name = "职级")]
        [ExcelColumnName("职级")]

        public int Mh026 { get; set; }

        [Required(ErrorMessage = "职务不能为空")]
        //[ExcelColumn(Name = "职务")]
        [ExcelColumnName("职务")]

        public int Mh027 { get; set; }

        [Required(ErrorMessage = "招聘来源不能为空")]
        //[ExcelColumn(Name = "招聘来源")]
        [ExcelColumnName("招聘来源")]

        public int Mh028 { get; set; }

        [Required(ErrorMessage = "聘用形式不能为空")]
        //[ExcelColumn(Name = "聘用形式")]
        [ExcelColumnName("聘用形式")]

        public int Mh029 { get; set; }

        [Required(ErrorMessage = "学历不能为空")]
        //[ExcelColumn(Name = "学历")]
        [ExcelColumnName("学历")]

        public int Mh030 { get; set; }

        [Required(ErrorMessage = "专业不能为空")]
        //[ExcelColumn(Name = "专业")]
        [ExcelColumnName("专业")]

        public int Mh031 { get; set; }

        //[ExcelColumn(Name = "院校")]
        [ExcelColumnName("院校")]

        public string Mh032 { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]

        public string Mh033 { get; set; }

        //[ExcelColumn(Name = "入职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入职日期")]

        public DateTime? Mh034 { get; set; }

        [Required(ErrorMessage = "在职状态不能为空")]
        //[ExcelColumn(Name = "在职状态")]
        [ExcelColumnName("在职状态")]

        public int Mh035 { get; set; }

        [Required(ErrorMessage = "试用期不能为空")]
        //[ExcelColumn(Name = "试用期")]
        [ExcelColumnName("试用期")]

        public int Mh036 { get; set; }

        [Required(ErrorMessage = "合同期限不能为空")]
        //[ExcelColumn(Name = "合同期限")]
        [ExcelColumnName("合同期限")]

        public int Mh037 { get; set; }

        //[ExcelColumn(Name = "转正日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("转正日期")]

        public DateTime? Mh038 { get; set; }

        //[ExcelColumn(Name = "离职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("离职日期")]

        public DateTime? Mh039 { get; set; }

        //[ExcelColumn(Name = "合同起始日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同起始日")]

        public DateTime? Mh040 { get; set; }

        //[ExcelColumn(Name = "合同终止日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同终止日")]

        public DateTime? Mh041 { get; set; }

        [Required(ErrorMessage = "工龄不能为空")]
        //[ExcelColumn(Name = "工龄")]
        [ExcelColumnName("工龄")]

        public int Mh042 { get; set; }

        //[ExcelColumn(Name = "退休日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("退休日期")]

        public DateTime? Mh043 { get; set; }

        [Required(ErrorMessage = "打卡否不能为空")]
        //[ExcelColumn(Name = "打卡否")]
        [ExcelColumnName("打卡否")]

        public int Mh044 { get; set; }

        [Required(ErrorMessage = "班别不能为空")]
        //[ExcelColumn(Name = "班别")]
        [ExcelColumnName("班别")]

        public int Mh045 { get; set; }

        //[ExcelColumn(Name = "头像")]
        [ExcelColumnName("头像")]

        public string Mh046 { get; set; }

        //[ExcelColumn(Name = "学历附件")]
        [ExcelColumnName("学历附件")]

        public string Mh047 { get; set; }

        //[ExcelColumn(Name = "职称附件")]
        [ExcelColumnName("职称附件")]

        public string Mh048 { get; set; }

        [ExcelIgnore]

        public string Ref01 { get; set; }

        [ExcelIgnore]

        public string Ref02 { get; set; }

        [ExcelIgnore]

        public string Ref03 { get; set; }

        [ExcelIgnore]

        public decimal Ref04 { get; set; }

        [ExcelIgnore]

        public decimal Ref05 { get; set; }

        [ExcelIgnore]

        public decimal Ref06 { get; set; }

        [ExcelIgnore]

        public string Udf01 { get; set; }

        [ExcelIgnore]

        public string Udf02 { get; set; }

        [ExcelIgnore]

        public string Udf03 { get; set; }

        [ExcelIgnore]

        public string Udf04 { get; set; }

        [ExcelIgnore]

        public string Udf05 { get; set; }

        [ExcelIgnore]

        public string Udf06 { get; set; }

        [ExcelIgnore]

        public int? Udf51 { get; set; }

        [ExcelIgnore]

        public int? Udf52 { get; set; }

        [ExcelIgnore]

        public int? Udf53 { get; set; }

        [ExcelIgnore]

        public decimal Udf54 { get; set; }

        [ExcelIgnore]

        public decimal Udf55 { get; set; }

        [ExcelIgnore]

        public decimal Udf56 { get; set; }

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
        public string Mh006Label { get; set; }
        [ExcelColumn(Name = "婚姻状态")]
        public string Mh009Label { get; set; }
        [ExcelColumn(Name = "民族")]
        public string Mh010Label { get; set; }
        [ExcelColumn(Name = "籍贯")]
        public string Mh011Label { get; set; }
        [ExcelColumn(Name = "政治面貌")]
        public string Mh012Label { get; set; }
        [ExcelColumn(Name = "国家/地区")]
        public string Mh015Label { get; set; }
        [ExcelColumn(Name = "省区")]
        public string Mh016Label { get; set; }
        [ExcelColumn(Name = "市区")]
        public string Mh017Label { get; set; }
        [ExcelColumn(Name = "户口性质")]
        public string Mh021Label { get; set; }
        [ExcelColumn(Name = "部门")]
        public string Mh023Label { get; set; }
        [ExcelColumn(Name = "职称")]
        public string Mh024Label { get; set; }
        [ExcelColumn(Name = "职位")]
        public string Mh025Label { get; set; }
        [ExcelColumn(Name = "职级")]
        public string Mh026Label { get; set; }
        [ExcelColumn(Name = "招聘来源")]
        public string Mh028Label { get; set; }
        [ExcelColumn(Name = "聘用形式")]
        public string Mh029Label { get; set; }
        [ExcelColumn(Name = "学历")]
        public string Mh030Label { get; set; }
        [ExcelColumn(Name = "专业")]
        public string Mh031Label { get; set; }
        [ExcelColumn(Name = "在职状态")]
        public string Mh035Label { get; set; }
        [ExcelColumn(Name = "打卡否")]
        public string Mh044Label { get; set; }
        [ExcelColumn(Name = "班别")]
        public string Mh045Label { get; set; }
    }

    /// <summary>
    /// 人事
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:25:31
    /// </summary>
    public class RoutineEhrEmployeeImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        //[ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]
        public string Mh002 { get; set; }

        //[ExcelColumn(Name = "曾用名")]
        [ExcelColumnName("曾用名")]
        public string Mh003 { get; set; }

        //[ExcelColumn(Name = "昵称")]
        [ExcelColumnName("昵称")]
        public string Mh004 { get; set; }

        //[ExcelColumn(Name = "英文名")]
        [ExcelColumnName("英文名")]
        public string Mh005 { get; set; }

        [Required(ErrorMessage = "性别不能为空")]
        //[ExcelColumn(Name = "性别")]
        [ExcelColumnName("性别")]
        public int Mh006 { get; set; }

        //[ExcelColumn(Name = "出生日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("出生日期")]
        public DateTime? Mh007 { get; set; }

        //[ExcelColumn(Name = "身份证号")]
        [ExcelColumnName("身份证号")]
        public string Mh008 { get; set; }

        [Required(ErrorMessage = "婚姻状态不能为空")]
        //[ExcelColumn(Name = "婚姻状态")]
        [ExcelColumnName("婚姻状态")]
        public int Mh009 { get; set; }

        [Required(ErrorMessage = "民族不能为空")]
        //[ExcelColumn(Name = "民族")]
        [ExcelColumnName("民族")]
        public int Mh010 { get; set; }

        //[ExcelColumn(Name = "籍贯")]
        [ExcelColumnName("籍贯")]
        public string Mh011 { get; set; }

        [Required(ErrorMessage = "政治面貌不能为空")]
        //[ExcelColumn(Name = "政治面貌")]
        [ExcelColumnName("政治面貌")]
        public int Mh012 { get; set; }

        //[ExcelColumn(Name = "邮件")]
        [ExcelColumnName("邮件")]
        public string Mh013 { get; set; }

        //[ExcelColumn(Name = "电话")]
        [ExcelColumnName("电话")]
        public string Mh014 { get; set; }

        //[ExcelColumn(Name = "国家/地区")]
        [ExcelColumnName("国家/地区")]
        public string Mh015 { get; set; }

        //[ExcelColumn(Name = "省区")]
        [ExcelColumnName("省区")]
        public string Mh016 { get; set; }

        //[ExcelColumn(Name = "市区")]
        [ExcelColumnName("市区")]
        public string Mh017 { get; set; }

        //[ExcelColumn(Name = "县区")]
        [ExcelColumnName("县区")]
        public string Mh018 { get; set; }

        //[ExcelColumn(Name = "家庭住址")]
        [ExcelColumnName("家庭住址")]
        public string Mh019 { get; set; }

        //[ExcelColumn(Name = "邮编")]
        [ExcelColumnName("邮编")]
        public string Mh020 { get; set; }

        [Required(ErrorMessage = "户口性质不能为空")]
        //[ExcelColumn(Name = "户口性质")]
        [ExcelColumnName("户口性质")]
        public int Mh021 { get; set; }

        //[ExcelColumn(Name = "暂住地址")]
        [ExcelColumnName("暂住地址")]
        public string Mh022 { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        //[ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public int Mh023 { get; set; }

        [Required(ErrorMessage = "职称不能为空")]
        //[ExcelColumn(Name = "职称")]
        [ExcelColumnName("职称")]
        public int Mh024 { get; set; }

        [Required(ErrorMessage = "职位不能为空")]
        //[ExcelColumn(Name = "职位")]
        [ExcelColumnName("职位")]
        public int Mh025 { get; set; }

        [Required(ErrorMessage = "职级不能为空")]
        //[ExcelColumn(Name = "职级")]
        [ExcelColumnName("职级")]
        public int Mh026 { get; set; }

        [Required(ErrorMessage = "职务不能为空")]
        //[ExcelColumn(Name = "职务")]
        [ExcelColumnName("职务")]
        public int Mh027 { get; set; }

        [Required(ErrorMessage = "招聘来源不能为空")]
        //[ExcelColumn(Name = "招聘来源")]
        [ExcelColumnName("招聘来源")]
        public int Mh028 { get; set; }

        [Required(ErrorMessage = "聘用形式不能为空")]
        //[ExcelColumn(Name = "聘用形式")]
        [ExcelColumnName("聘用形式")]
        public int Mh029 { get; set; }

        [Required(ErrorMessage = "学历不能为空")]
        //[ExcelColumn(Name = "学历")]
        [ExcelColumnName("学历")]
        public int Mh030 { get; set; }

        [Required(ErrorMessage = "专业不能为空")]
        //[ExcelColumn(Name = "专业")]
        [ExcelColumnName("专业")]
        public int Mh031 { get; set; }

        //[ExcelColumn(Name = "院校")]
        [ExcelColumnName("院校")]
        public string Mh032 { get; set; }

        [Required(ErrorMessage = "工号不能为空")]
        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string Mh033 { get; set; }

        //[ExcelColumn(Name = "入职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入职日期")]
        public DateTime? Mh034 { get; set; }

        [Required(ErrorMessage = "在职状态不能为空")]
        //[ExcelColumn(Name = "在职状态")]
        [ExcelColumnName("在职状态")]
        public int Mh035 { get; set; }

        [Required(ErrorMessage = "试用期不能为空")]
        //[ExcelColumn(Name = "试用期")]
        [ExcelColumnName("试用期")]
        public int Mh036 { get; set; }

        [Required(ErrorMessage = "合同期限不能为空")]
        //[ExcelColumn(Name = "合同期限")]
        [ExcelColumnName("合同期限")]
        public int Mh037 { get; set; }

        //[ExcelColumn(Name = "转正日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("转正日期")]
        public DateTime? Mh038 { get; set; }

        //[ExcelColumn(Name = "离职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("离职日期")]
        public DateTime? Mh039 { get; set; }

        //[ExcelColumn(Name = "合同起始日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同起始日")]
        public DateTime? Mh040 { get; set; }

        //[ExcelColumn(Name = "合同终止日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同终止日")]
        public DateTime? Mh041 { get; set; }

        [Required(ErrorMessage = "工龄不能为空")]
        //[ExcelColumn(Name = "工龄")]
        [ExcelColumnName("工龄")]
        public int Mh042 { get; set; }

        //[ExcelColumn(Name = "退休日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("退休日期")]
        public DateTime? Mh043 { get; set; }

        [Required(ErrorMessage = "打卡否不能为空")]
        //[ExcelColumn(Name = "打卡否")]
        [ExcelColumnName("打卡否")]
        public int Mh044 { get; set; }

        [Required(ErrorMessage = "班别不能为空")]
        //[ExcelColumn(Name = "班别")]
        [ExcelColumnName("班别")]
        public int Mh045 { get; set; }

        //[ExcelColumn(Name = "头像")]
        [ExcelColumnName("头像")]
        public string Mh046 { get; set; }

        //[ExcelColumn(Name = "学历附件")]
        [ExcelColumnName("学历附件")]
        public string Mh047 { get; set; }

        //[ExcelColumn(Name = "职称附件")]
        [ExcelColumnName("职称附件")]
        public string Mh048 { get; set; }

        [ExcelIgnore]
        public string Ref01 { get; set; }

        [ExcelIgnore]
        public string Ref02 { get; set; }

        [ExcelIgnore]
        public string Ref03 { get; set; }

        [ExcelIgnore]
        public decimal Ref04 { get; set; }

        [ExcelIgnore]
        public decimal Ref05 { get; set; }

        [ExcelIgnore]
        public decimal Ref06 { get; set; }

        [ExcelIgnore]
        public string Udf01 { get; set; }

        [ExcelIgnore]
        public string Udf02 { get; set; }

        [ExcelIgnore]
        public string Udf03 { get; set; }

        [ExcelIgnore]
        public string Udf04 { get; set; }

        [ExcelIgnore]
        public string Udf05 { get; set; }

        [ExcelIgnore]
        public string Udf06 { get; set; }

        [ExcelIgnore]
        public int? Udf51 { get; set; }

        [ExcelIgnore]
        public int? Udf52 { get; set; }

        [ExcelIgnore]
        public int? Udf53 { get; set; }

        [ExcelIgnore]
        public decimal Udf54 { get; set; }

        [ExcelIgnore]
        public decimal Udf55 { get; set; }

        [ExcelIgnore]
        public decimal Udf56 { get; set; }

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
        public string Mh006Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "婚姻状态")]
        public string Mh009Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "民族")]
        public string Mh010Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "籍贯")]
        public string Mh011Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "政治面貌")]
        public string Mh012Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "国家/地区")]
        public string Mh015Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "省区")]
        public string Mh016Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "市区")]
        public string Mh017Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "户口性质")]
        public string Mh021Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "部门")]
        public string Mh023Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "职称")]
        public string Mh024Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "职位")]
        public string Mh025Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "职级")]
        public string Mh026Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "招聘来源")]
        public string Mh028Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "聘用形式")]
        public string Mh029Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "学历")]
        public string Mh030Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "专业")]
        public string Mh031Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "在职状态")]
        public string Mh035Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "打卡否")]
        public string Mh044Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "班别")]
        public string Mh045Label { get; set; }
    }

}