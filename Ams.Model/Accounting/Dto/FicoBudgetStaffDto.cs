
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 人员预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/14 13:41:08
    /// </summary>
    public class FicoBudgetStaffQueryDto : PagerInfo 
    {
        /// <summary>
        /// 部门ID 
        /// </summary>        
        public long? DeptId { get; set; }
        /// <summary>
        /// 财年 
        /// </summary>        
        public string Mj004 { get; set; }
        /// <summary>
        /// 年月 
        /// </summary>        
        public string Mj005 { get; set; }
        /// <summary>
        /// 公司 
        /// </summary>        
        public string Mj006 { get; set; }
        /// <summary>
        /// 科目 
        /// </summary>        
        public string Mj007 { get; set; }
        /// <summary>
        /// 名称 
        /// </summary>        
        public string Mj008 { get; set; }
        /// <summary>
        /// 审核 
        /// </summary>        
        public int? Mj014 { get; set; }
    }

    /// <summary>
    /// 人员预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/14 13:41:08
    /// </summary>
    public class FicoBudgetStaffDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? Id { get; set; }

        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]

        public long? ParentId { get; set; }

        //[ExcelColumn(Name = "部门ID")]
        [ExcelColumnName("部门ID")]

        public long? DeptId { get; set; }

        [Required(ErrorMessage = "财年不能为空")]
        //[ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]

        public string Mj004 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]

        public string Mj005 { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]

        public string Mj006 { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        //[ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]

        public string Mj007 { get; set; }

        //[ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]

        public string Mj008 { get; set; }

        //[ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]

        public string Mj009 { get; set; }

        [Required(ErrorMessage = "保有不能为空")]
        //[ExcelColumn(Name = "保有")]
        [ExcelColumnName("保有")]

        public int Mj010 { get; set; }

        [Required(ErrorMessage = "现有不能为空")]
        //[ExcelColumn(Name = "现有")]
        [ExcelColumnName("现有")]

        public int Mj011 { get; set; }

        [Required(ErrorMessage = "预算不能为空")]
        //[ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]

        public int Mj012 { get; set; }

        [Required(ErrorMessage = "启用不能为空")]
        //[ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]

        public int Mj013 { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        //[ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]

        public int Mj014 { get; set; }

        //[ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]

        public string Mj015 { get; set; }

        //[ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]

        public DateTime? Mj016 { get; set; }

        //[ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]

        public string Mj017 { get; set; }

        //[ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]

        public DateTime? Mj018 { get; set; }

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



        [ExcelColumn(Name = "部门ID")]
        public string DeptIdLabel { get; set; }
        [ExcelColumn(Name = "财年")]
        public string Mj004Label { get; set; }
        [ExcelColumn(Name = "年月")]
        public string Mj005Label { get; set; }
        [ExcelColumn(Name = "公司")]
        public string Mj006Label { get; set; }
        [ExcelColumn(Name = "科目")]
        public string Mj007Label { get; set; }
        [ExcelColumn(Name = "类别")]
        public string Mj009Label { get; set; }
        [ExcelColumn(Name = "启用")]
        public string Mj013Label { get; set; }
    }

    /// <summary>
    /// 人员预算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/14 13:41:08
    /// </summary>
    public class FicoBudgetStaffImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? Id { get; set; }

        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long? ParentId { get; set; }

        //[ExcelColumn(Name = "部门ID")]
        [ExcelColumnName("部门ID")]
        public long? DeptId { get; set; }

        [Required(ErrorMessage = "财年不能为空")]
        //[ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string Mj004 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string Mj005 { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string Mj006 { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        //[ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string Mj007 { get; set; }

        //[ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string Mj008 { get; set; }

        //[ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string Mj009 { get; set; }

        [Required(ErrorMessage = "保有不能为空")]
        //[ExcelColumn(Name = "保有")]
        [ExcelColumnName("保有")]
        public int Mj010 { get; set; }

        [Required(ErrorMessage = "现有不能为空")]
        //[ExcelColumn(Name = "现有")]
        [ExcelColumnName("现有")]
        public int Mj011 { get; set; }

        [Required(ErrorMessage = "预算不能为空")]
        //[ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public int Mj012 { get; set; }

        [Required(ErrorMessage = "启用不能为空")]
        //[ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]
        public int Mj013 { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        //[ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int Mj014 { get; set; }

        //[ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]
        public string Mj015 { get; set; }

        //[ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? Mj016 { get; set; }

        //[ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]
        public string Mj017 { get; set; }

        //[ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]
        public DateTime? Mj018 { get; set; }

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
        [ExcelColumn(Name = "部门ID")]
        public string DeptIdLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "财年")]
        public string Mj004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string Mj005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司")]
        public string Mj006Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "科目")]
        public string Mj007Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "类别")]
        public string Mj009Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "启用")]
        public string Mj013Label { get; set; }
    }

}