
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 薪资
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:20:02
    /// </summary>
    public class RoutineEhrPayrollQueryDto : PagerInfo 
    {
        /// <summary>
        /// 部门 
        /// </summary>        
        public int? Mk002 { get; set; }
        /// <summary>
        /// 工号 
        /// </summary>        
        public string Mk003 { get; set; }
        /// <summary>
        /// 姓名 
        /// </summary>        
        public string Mk004 { get; set; }
    }

    /// <summary>
    /// 薪资
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:20:02
    /// </summary>
    public class RoutineEhrPayrollDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]

        public long Id { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        //[ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]

        public int Mk002 { get; set; }

        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]

        public string Mk003 { get; set; }

        //[ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]

        public string Mk004 { get; set; }

        [Required(ErrorMessage = "岗位不能为空")]
        //[ExcelColumn(Name = "岗位")]
        [ExcelColumnName("岗位")]

        public int Mk005 { get; set; }

        [Required(ErrorMessage = "等级不能为空")]
        //[ExcelColumn(Name = "等级")]
        [ExcelColumnName("等级")]

        public int Mk006 { get; set; }

        //[ExcelColumn(Name = "薪别")]
        [ExcelColumnName("薪别")]

        public string Mk007 { get; set; }

        //[ExcelColumn(Name = "入职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入职日期")]

        public DateTime? Mk008 { get; set; }

        //[ExcelColumn(Name = "离职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("离职日期")]

        public DateTime? Mk009 { get; set; }

        [Required(ErrorMessage = "税别不能为空")]
        //[ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]

        public int Mk010 { get; set; }

        [Required(ErrorMessage = "基本工资不能为空")]
        //[ExcelColumn(Name = "基本工资")]
        [ExcelColumnName("基本工资")]

        public decimal Mk011 { get; set; }

        //[ExcelColumn(Name = "全勤")]
        [ExcelColumnName("全勤")]

        public decimal Mk012 { get; set; }

        //[ExcelColumn(Name = "全勤否")]
        [ExcelColumnName("全勤否")]

        public int? Mk013 { get; set; }

        //[ExcelColumn(Name = "职位津贴")]
        [ExcelColumnName("职位津贴")]

        public decimal Mk014 { get; set; }

        //[ExcelColumn(Name = "职能调整")]
        [ExcelColumnName("职能调整")]

        public decimal Mk015 { get; set; }

        //[ExcelColumn(Name = "补助(夜霄，银行，其它)")]
        [ExcelColumnName("补助(夜霄，银行，其它)")]

        public decimal Mk016 { get; set; }

        //[ExcelColumn(Name = "其它津贴")]
        [ExcelColumnName("其它津贴")]

        public decimal Mk017 { get; set; }

        //[ExcelColumn(Name = "保险")]
        [ExcelColumnName("保险")]

        public decimal Mk018 { get; set; }

        [Required(ErrorMessage = "工龄不能为空")]
        //[ExcelColumn(Name = "工龄")]
        [ExcelColumnName("工龄")]

        public int Mk019 { get; set; }

        //[ExcelColumn(Name = "社保")]
        [ExcelColumnName("社保")]

        public decimal Mk020 { get; set; }

        //[ExcelColumn(Name = "奖金")]
        [ExcelColumnName("奖金")]

        public decimal Mk021 { get; set; }

        //[ExcelColumn(Name = "加班")]
        [ExcelColumnName("加班")]

        public decimal Mk022 { get; set; }

        //[ExcelColumn(Name = "特殊津贴")]
        [ExcelColumnName("特殊津贴")]

        public decimal Mk023 { get; set; }

        //[ExcelColumn(Name = "伙食")]
        [ExcelColumnName("伙食")]

        public decimal Nk024 { get; set; }

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



        [ExcelColumn(Name = "部门")]
        public string Mk002Label { get; set; }
    }

    /// <summary>
    /// 薪资
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:20:02
    /// </summary>
    public class RoutineEhrPayrollImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long Id { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        //[ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public int Mk002 { get; set; }

        //[ExcelColumn(Name = "工号")]
        [ExcelColumnName("工号")]
        public string Mk003 { get; set; }

        //[ExcelColumn(Name = "姓名")]
        [ExcelColumnName("姓名")]
        public string Mk004 { get; set; }

        [Required(ErrorMessage = "岗位不能为空")]
        //[ExcelColumn(Name = "岗位")]
        [ExcelColumnName("岗位")]
        public int Mk005 { get; set; }

        [Required(ErrorMessage = "等级不能为空")]
        //[ExcelColumn(Name = "等级")]
        [ExcelColumnName("等级")]
        public int Mk006 { get; set; }

        //[ExcelColumn(Name = "薪别")]
        [ExcelColumnName("薪别")]
        public string Mk007 { get; set; }

        //[ExcelColumn(Name = "入职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("入职日期")]
        public DateTime? Mk008 { get; set; }

        //[ExcelColumn(Name = "离职日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("离职日期")]
        public DateTime? Mk009 { get; set; }

        [Required(ErrorMessage = "税别不能为空")]
        //[ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]
        public int Mk010 { get; set; }

        [Required(ErrorMessage = "基本工资不能为空")]
        //[ExcelColumn(Name = "基本工资")]
        [ExcelColumnName("基本工资")]
        public decimal Mk011 { get; set; }

        //[ExcelColumn(Name = "全勤")]
        [ExcelColumnName("全勤")]
        public decimal Mk012 { get; set; }

        //[ExcelColumn(Name = "全勤否")]
        [ExcelColumnName("全勤否")]
        public int? Mk013 { get; set; }

        //[ExcelColumn(Name = "职位津贴")]
        [ExcelColumnName("职位津贴")]
        public decimal Mk014 { get; set; }

        //[ExcelColumn(Name = "职能调整")]
        [ExcelColumnName("职能调整")]
        public decimal Mk015 { get; set; }

        //[ExcelColumn(Name = "补助(夜霄，银行，其它)")]
        [ExcelColumnName("补助(夜霄，银行，其它)")]
        public decimal Mk016 { get; set; }

        //[ExcelColumn(Name = "其它津贴")]
        [ExcelColumnName("其它津贴")]
        public decimal Mk017 { get; set; }

        //[ExcelColumn(Name = "保险")]
        [ExcelColumnName("保险")]
        public decimal Mk018 { get; set; }

        [Required(ErrorMessage = "工龄不能为空")]
        //[ExcelColumn(Name = "工龄")]
        [ExcelColumnName("工龄")]
        public int Mk019 { get; set; }

        //[ExcelColumn(Name = "社保")]
        [ExcelColumnName("社保")]
        public decimal Mk020 { get; set; }

        //[ExcelColumn(Name = "奖金")]
        [ExcelColumnName("奖金")]
        public decimal Mk021 { get; set; }

        //[ExcelColumn(Name = "加班")]
        [ExcelColumnName("加班")]
        public decimal Mk022 { get; set; }

        //[ExcelColumn(Name = "特殊津贴")]
        [ExcelColumnName("特殊津贴")]
        public decimal Mk023 { get; set; }

        //[ExcelColumn(Name = "伙食")]
        [ExcelColumnName("伙食")]
        public decimal Nk024 { get; set; }

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
        [ExcelColumn(Name = "部门")]
        public string Mk002Label { get; set; }
    }

}