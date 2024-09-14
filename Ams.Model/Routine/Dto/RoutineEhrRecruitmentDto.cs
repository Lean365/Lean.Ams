
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 招聘
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:16:55
    /// </summary>
    public class RoutineEhrRecruitmentQueryDto : PagerInfo 
    {
        /// <summary>
        /// 招聘日期 
        /// </summary>        
        public DateTime? BeginMn002 { get; set; }
        public DateTime? EndMn002 { get; set; }
        /// <summary>
        /// 姓名 
        /// </summary>        
        public string Mn003 { get; set; }
        /// <summary>
        /// 部门 
        /// </summary>        
        public int? Mn004 { get; set; }
        /// <summary>
        /// 聘用形式 
        /// </summary>        
        public string Mn009 { get; set; }
    }

    /// <summary>
    /// 招聘
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:16:55
    /// </summary>
    public class RoutineEhrRecruitmentDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "招聘日期不能为空")]
        //[ExcelColumn(Name = "招聘日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("招聘日期")]

        public DateTime? Mn002 { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        //[ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]

        public string Mn003 { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        //[ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]

        public int Mn004 { get; set; }

        [Required(ErrorMessage = "职称不能为空")]
        //[ExcelColumn(Name = "职称")]
        [ExcelColumnName("职称")]

        public int Mn005 { get; set; }

        [Required(ErrorMessage = "岗位不能为空")]
        //[ExcelColumn(Name = "岗位")]
        [ExcelColumnName("岗位")]

        public int Mn006 { get; set; }

        [Required(ErrorMessage = "等级不能为空")]
        //[ExcelColumn(Name = "等级")]
        [ExcelColumnName("等级")]

        public int Mn007 { get; set; }

        [Required(ErrorMessage = "职务不能为空")]
        //[ExcelColumn(Name = "职务")]
        [ExcelColumnName("职务")]

        public int Mn008 { get; set; }

        //[ExcelColumn(Name = "聘用形式")]
        [ExcelColumnName("聘用形式")]

        public string Mn009 { get; set; }

        //[ExcelColumn(Name = "入职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入职日期")]

        public DateTime? Mn010 { get; set; }

        //[ExcelColumn(Name = "在职状态")]
        [ExcelColumnName("在职状态")]

        public string Mn011 { get; set; }

        //[ExcelColumn(Name = "试用期")]
        [ExcelColumnName("试用期")]

        public string Mn012 { get; set; }

        [Required(ErrorMessage = "试用工资不能为空")]
        //[ExcelColumn(Name = "试用工资")]
        [ExcelColumnName("试用工资")]

        public decimal Mn013 { get; set; }

        //[ExcelColumn(Name = "合同期限")]
        [ExcelColumnName("合同期限")]

        public string Mn014 { get; set; }

        [Required(ErrorMessage = "转正工资不能为空")]
        //[ExcelColumn(Name = "转正工资")]
        [ExcelColumnName("转正工资")]

        public decimal Mn015 { get; set; }

        //[ExcelColumn(Name = "转正日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("转正日期")]

        public DateTime? Mn016 { get; set; }

        //[ExcelColumn(Name = "合同终止日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同终止日")]

        public DateTime? Mn017 { get; set; }

        //[ExcelColumn(Name = "合同起始日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同起始日")]

        public DateTime? Mn018 { get; set; }

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

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelIgnore]

        public int IsDeleted { get; set; }

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



        [ExcelColumn(Name = "部门")]
        public string Mn004Label { get; set; }
        [ExcelColumn(Name = "聘用形式")]
        public string Mn009Label { get; set; }
    }

    /// <summary>
    /// 招聘
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:16:55
    /// </summary>
    public class RoutineEhrRecruitmentImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "招聘日期不能为空")]
        //[ExcelColumn(Name = "招聘日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("招聘日期")]
        public DateTime? Mn002 { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        //[ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]
        public string Mn003 { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        //[ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public int Mn004 { get; set; }

        [Required(ErrorMessage = "职称不能为空")]
        //[ExcelColumn(Name = "职称")]
        [ExcelColumnName("职称")]
        public int Mn005 { get; set; }

        [Required(ErrorMessage = "岗位不能为空")]
        //[ExcelColumn(Name = "岗位")]
        [ExcelColumnName("岗位")]
        public int Mn006 { get; set; }

        [Required(ErrorMessage = "等级不能为空")]
        //[ExcelColumn(Name = "等级")]
        [ExcelColumnName("等级")]
        public int Mn007 { get; set; }

        [Required(ErrorMessage = "职务不能为空")]
        //[ExcelColumn(Name = "职务")]
        [ExcelColumnName("职务")]
        public int Mn008 { get; set; }

        //[ExcelColumn(Name = "聘用形式")]
        [ExcelColumnName("聘用形式")]
        public string Mn009 { get; set; }

        //[ExcelColumn(Name = "入职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入职日期")]
        public DateTime? Mn010 { get; set; }

        //[ExcelColumn(Name = "在职状态")]
        [ExcelColumnName("在职状态")]
        public string Mn011 { get; set; }

        //[ExcelColumn(Name = "试用期")]
        [ExcelColumnName("试用期")]
        public string Mn012 { get; set; }

        [Required(ErrorMessage = "试用工资不能为空")]
        //[ExcelColumn(Name = "试用工资")]
        [ExcelColumnName("试用工资")]
        public decimal Mn013 { get; set; }

        //[ExcelColumn(Name = "合同期限")]
        [ExcelColumnName("合同期限")]
        public string Mn014 { get; set; }

        [Required(ErrorMessage = "转正工资不能为空")]
        //[ExcelColumn(Name = "转正工资")]
        [ExcelColumnName("转正工资")]
        public decimal Mn015 { get; set; }

        //[ExcelColumn(Name = "转正日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("转正日期")]
        public DateTime? Mn016 { get; set; }

        //[ExcelColumn(Name = "合同终止日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同终止日")]
        public DateTime? Mn017 { get; set; }

        //[ExcelColumn(Name = "合同起始日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同起始日")]
        public DateTime? Mn018 { get; set; }

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

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelIgnore]
        public int IsDeleted { get; set; }

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
        [ExcelColumn(Name = "部门")]
        public string Mn004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "聘用形式")]
        public string Mn009Label { get; set; }
    }

}