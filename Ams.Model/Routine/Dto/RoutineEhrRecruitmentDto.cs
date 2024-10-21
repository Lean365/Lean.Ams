
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 招聘
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/18 15:46:34
    /// </summary>
    public class RoutineEhrRecruitmentQueryDto : PagerInfo 
    {
        /// <summary>
        /// 招聘部门 
        /// </summary>        
        public int? Mn004 { get; set; }
        /// <summary>
        /// 招聘职位 
        /// </summary>        
        public int? Mn005 { get; set; }
        /// <summary>
        /// 薪资范围 
        /// </summary>        
        public string Mn006 { get; set; }
        /// <summary>
        /// 紧急程度 
        /// </summary>        
        public int? Mn007 { get; set; }
        /// <summary>
        /// 工作城市 
        /// </summary>        
        public string Mn008 { get; set; }
    }

    /// <summary>
    /// 招聘
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/18 15:46:34
    /// </summary>
    public class RoutineEhrRecruitmentDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? Id { get; set; }

        [Required(ErrorMessage = "招聘起始日不能为空")]
        //[ExcelColumn(Name = "招聘起始日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("招聘起始日")]

        public DateTime? Mn002 { get; set; }

        [Required(ErrorMessage = "招聘截止日不能为空")]
        //[ExcelColumn(Name = "招聘截止日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("招聘截止日")]

        public DateTime? Mn003 { get; set; }

        [Required(ErrorMessage = "招聘部门不能为空")]
        //[ExcelColumn(Name = "招聘部门")]
        [ExcelColumnName("招聘部门")]

        public int Mn004 { get; set; }

        //[ExcelColumn(Name = "招聘职位")]
        [ExcelColumnName("招聘职位")]

        public int? Mn005 { get; set; }

        [Required(ErrorMessage = "薪资范围不能为空")]
        //[ExcelColumn(Name = "薪资范围")]
        [ExcelColumnName("薪资范围")]

        public string Mn006 { get; set; }

        [Required(ErrorMessage = "紧急程度不能为空")]
        //[ExcelColumn(Name = "紧急程度")]
        [ExcelColumnName("紧急程度")]

        public int Mn007 { get; set; }

        [Required(ErrorMessage = "工作城市不能为空")]
        //[ExcelColumn(Name = "工作城市")]
        [ExcelColumnName("工作城市")]

        public string Mn008 { get; set; }

        [Required(ErrorMessage = "工作经验不能为空")]
        //[ExcelColumn(Name = "工作经验")]
        [ExcelColumnName("工作经验")]

        public int Mn009 { get; set; }

        [Required(ErrorMessage = "学历要求不能为空")]
        //[ExcelColumn(Name = "学历要求")]
        [ExcelColumnName("学历要求")]

        public int Mn010 { get; set; }

        [Required(ErrorMessage = "聘用形式不能为空")]
        //[ExcelColumn(Name = "聘用形式")]
        [ExcelColumnName("聘用形式")]

        public int Mn011 { get; set; }

        [Required(ErrorMessage = "到岗日期不能为空")]
        //[ExcelColumn(Name = "到岗日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("到岗日期")]

        public DateTime? Mn012 { get; set; }

        [Required(ErrorMessage = "年龄要求不能为空")]
        //[ExcelColumn(Name = "年龄要求")]
        [ExcelColumnName("年龄要求")]

        public int Mn013 { get; set; }

        [Required(ErrorMessage = "面试否不能为空")]
        //[ExcelColumn(Name = "面试否")]
        [ExcelColumnName("面试否")]

        public int Mn014 { get; set; }

        [Required(ErrorMessage = "招聘人数不能为空")]
        //[ExcelColumn(Name = "招聘人数")]
        [ExcelColumnName("招聘人数")]

        public int Mn015 { get; set; }

        [Required(ErrorMessage = "招聘原因不能为空")]
        //[ExcelColumn(Name = "招聘原因")]
        [ExcelColumnName("招聘原因")]

        public int Mn016 { get; set; }

        [Required(ErrorMessage = "试用期限不能为空")]
        //[ExcelColumn(Name = "试用期限")]
        [ExcelColumnName("试用期限")]

        public int Mn017 { get; set; }

        [Required(ErrorMessage = "招聘状态不能为空")]
        //[ExcelColumn(Name = "招聘状态")]
        [ExcelColumnName("招聘状态")]

        public int Mn018 { get; set; }

        [Required(ErrorMessage = "相关资格证书不能为空")]
        //[ExcelColumn(Name = "相关资格证书")]
        [ExcelColumnName("相关资格证书")]

        public int Mn019 { get; set; }

        [Required(ErrorMessage = "岗位描述不能为空")]
        //[ExcelColumn(Name = "岗位描述")]
        [ExcelColumnName("岗位描述")]

        public string Mn020 { get; set; }

        //[ExcelColumn(Name = "面试官")]
        [ExcelColumnName("面试官")]

        public string Mn021 { get; set; }

        //[ExcelColumn(Name = "负责人")]
        [ExcelColumnName("负责人")]

        public string Mn022 { get; set; }

        [ExcelIgnore]

        public string Remark { get; set; }

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

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "招聘部门")]
        public string Mn004Label { get; set; }
        [ExcelColumn(Name = "招聘职位")]
        public string Mn005Label { get; set; }
        [ExcelColumn(Name = "薪资范围")]
        public string Mn006Label { get; set; }
        [ExcelColumn(Name = "紧急程度")]
        public string Mn007Label { get; set; }
        [ExcelColumn(Name = "工作城市")]
        public string Mn008Label { get; set; }
        [ExcelColumn(Name = "工作经验")]
        public string Mn009Label { get; set; }
        [ExcelColumn(Name = "学历要求")]
        public string Mn010Label { get; set; }
        [ExcelColumn(Name = "聘用形式")]
        public string Mn011Label { get; set; }
        [ExcelColumn(Name = "年龄要求")]
        public string Mn013Label { get; set; }
        [ExcelColumn(Name = "面试否")]
        public string Mn014Label { get; set; }
        [ExcelColumn(Name = "招聘原因")]
        public string Mn016Label { get; set; }
        [ExcelColumn(Name = "招聘状态")]
        public string Mn018Label { get; set; }
    }

    /// <summary>
    /// 招聘
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/18 15:46:34
    /// </summary>
    public class RoutineEhrRecruitmentImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? Id { get; set; }

        [Required(ErrorMessage = "招聘起始日不能为空")]
        //[ExcelColumn(Name = "招聘起始日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("招聘起始日")]
        public DateTime? Mn002 { get; set; }

        [Required(ErrorMessage = "招聘截止日不能为空")]
        //[ExcelColumn(Name = "招聘截止日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("招聘截止日")]
        public DateTime? Mn003 { get; set; }

        [Required(ErrorMessage = "招聘部门不能为空")]
        //[ExcelColumn(Name = "招聘部门")]
        [ExcelColumnName("招聘部门")]
        public int Mn004 { get; set; }

        //[ExcelColumn(Name = "招聘职位")]
        [ExcelColumnName("招聘职位")]
        public int? Mn005 { get; set; }

        [Required(ErrorMessage = "薪资范围不能为空")]
        //[ExcelColumn(Name = "薪资范围")]
        [ExcelColumnName("薪资范围")]
        public string Mn006 { get; set; }

        [Required(ErrorMessage = "紧急程度不能为空")]
        //[ExcelColumn(Name = "紧急程度")]
        [ExcelColumnName("紧急程度")]
        public int Mn007 { get; set; }

        [Required(ErrorMessage = "工作城市不能为空")]
        //[ExcelColumn(Name = "工作城市")]
        [ExcelColumnName("工作城市")]
        public string Mn008 { get; set; }

        [Required(ErrorMessage = "工作经验不能为空")]
        //[ExcelColumn(Name = "工作经验")]
        [ExcelColumnName("工作经验")]
        public int Mn009 { get; set; }

        [Required(ErrorMessage = "学历要求不能为空")]
        //[ExcelColumn(Name = "学历要求")]
        [ExcelColumnName("学历要求")]
        public int Mn010 { get; set; }

        [Required(ErrorMessage = "聘用形式不能为空")]
        //[ExcelColumn(Name = "聘用形式")]
        [ExcelColumnName("聘用形式")]
        public int Mn011 { get; set; }

        [Required(ErrorMessage = "到岗日期不能为空")]
        //[ExcelColumn(Name = "到岗日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("到岗日期")]
        public DateTime? Mn012 { get; set; }

        [Required(ErrorMessage = "年龄要求不能为空")]
        //[ExcelColumn(Name = "年龄要求")]
        [ExcelColumnName("年龄要求")]
        public int Mn013 { get; set; }

        [Required(ErrorMessage = "面试否不能为空")]
        //[ExcelColumn(Name = "面试否")]
        [ExcelColumnName("面试否")]
        public int Mn014 { get; set; }

        [Required(ErrorMessage = "招聘人数不能为空")]
        //[ExcelColumn(Name = "招聘人数")]
        [ExcelColumnName("招聘人数")]
        public int Mn015 { get; set; }

        [Required(ErrorMessage = "招聘原因不能为空")]
        //[ExcelColumn(Name = "招聘原因")]
        [ExcelColumnName("招聘原因")]
        public int Mn016 { get; set; }

        [Required(ErrorMessage = "试用期限不能为空")]
        //[ExcelColumn(Name = "试用期限")]
        [ExcelColumnName("试用期限")]
        public int Mn017 { get; set; }

        [Required(ErrorMessage = "招聘状态不能为空")]
        //[ExcelColumn(Name = "招聘状态")]
        [ExcelColumnName("招聘状态")]
        public int Mn018 { get; set; }

        [Required(ErrorMessage = "相关资格证书不能为空")]
        //[ExcelColumn(Name = "相关资格证书")]
        [ExcelColumnName("相关资格证书")]
        public int Mn019 { get; set; }

        [Required(ErrorMessage = "岗位描述不能为空")]
        //[ExcelColumn(Name = "岗位描述")]
        [ExcelColumnName("岗位描述")]
        public string Mn020 { get; set; }

        //[ExcelColumn(Name = "面试官")]
        [ExcelColumnName("面试官")]
        public string Mn021 { get; set; }

        //[ExcelColumn(Name = "负责人")]
        [ExcelColumnName("负责人")]
        public string Mn022 { get; set; }

        [ExcelIgnore]
        public string Remark { get; set; }

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
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "招聘部门")]
        public string Mn004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "招聘职位")]
        public string Mn005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "薪资范围")]
        public string Mn006Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "紧急程度")]
        public string Mn007Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "工作城市")]
        public string Mn008Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "工作经验")]
        public string Mn009Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "学历要求")]
        public string Mn010Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "聘用形式")]
        public string Mn011Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年龄要求")]
        public string Mn013Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "面试否")]
        public string Mn014Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "招聘原因")]
        public string Mn016Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "招聘状态")]
        public string Mn018Label { get; set; }
    }

}