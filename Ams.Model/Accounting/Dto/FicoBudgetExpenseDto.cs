
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 费用预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:57:41
    /// </summary>
    public class FicoBudgetExpenseQueryDto : PagerInfo 
    {
        /// <summary>
        /// 期间 
        /// </summary>        
        public string Mh003 { get; set; }
        /// <summary>
        /// 年月 
        /// </summary>        
        public string Mh004 { get; set; }
        /// <summary>
        /// 公司 
        /// </summary>        
        public string Mh005 { get; set; }
        /// <summary>
        /// 科目 
        /// </summary>        
        public string Mh006 { get; set; }
    }

    /// <summary>
    /// 费用预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:57:41
    /// </summary>
    public class FicoBudgetExpenseDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]

        public long? ParentId { get; set; }

        //[ExcelColumn(Name = "部门ID")]
        [ExcelColumnName("部门ID")]

        public long? DeptId { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]

        public string Mh003 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]

        public string Mh004 { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]

        public string Mh005 { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        //[ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]

        public string Mh006 { get; set; }

        //[ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]

        public string Mh007 { get; set; }

        //[ExcelColumn(Name = "明细科目")]
        [ExcelColumnName("明细科目")]

        public string Mh008 { get; set; }

        //[ExcelColumn(Name = "明细名称")]
        [ExcelColumnName("明细名称")]

        public string Mh009 { get; set; }

        //[ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]

        public string Mh010 { get; set; }

        [Required(ErrorMessage = "预算金额不能为空")]
        //[ExcelColumn(Name = "预算金额")]
        [ExcelColumnName("预算金额")]

        public decimal Mh011 { get; set; }

        [Required(ErrorMessage = "实际发生不能为空")]
        //[ExcelColumn(Name = "实际发生")]
        [ExcelColumnName("实际发生")]

        public decimal Mh012 { get; set; }

        [Required(ErrorMessage = "差异不能为空")]
        //[ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]

        public decimal Mh013 { get; set; }

        [Required(ErrorMessage = "启用标记不能为空")]
        //[ExcelColumn(Name = "启用标记")]
        [ExcelColumnName("启用标记")]

        public int Mh014 { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        //[ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]

        public int Mh015 { get; set; }

        //[ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]

        public string Mh016 { get; set; }

        //[ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]

        public DateTime? Mh017 { get; set; }

        //[ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]

        public string Mh018 { get; set; }

        //[ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]

        public DateTime? Mh019 { get; set; }

        [ExcelIgnore]

        public string Ref01 { get; set; }

        [ExcelIgnore]

        public string Ref02 { get; set; }

        [ExcelIgnore]

        public string Ref03 { get; set; }

        [Required(ErrorMessage = "预留1不能为空")]
        [ExcelIgnore]

        public decimal Ref04 { get; set; }

        [Required(ErrorMessage = "预留2不能为空")]
        [ExcelIgnore]

        public decimal Ref05 { get; set; }

        [Required(ErrorMessage = "预留3不能为空")]
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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]

        public int Udf51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]

        public int Udf52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]

        public int Udf53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]

        public decimal Udf54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]

        public decimal Udf55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
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



        [ExcelColumn(Name = "期间")]
        public string Mh003Label { get; set; }
        [ExcelColumn(Name = "年月")]
        public string Mh004Label { get; set; }
        [ExcelColumn(Name = "公司")]
        public string Mh005Label { get; set; }
        [ExcelColumn(Name = "科目")]
        public string Mh006Label { get; set; }
    }

    /// <summary>
    /// 费用预算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:57:41
    /// </summary>
    public class FicoBudgetExpenseImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long? ParentId { get; set; }

        //[ExcelColumn(Name = "部门ID")]
        [ExcelColumnName("部门ID")]
        public long? DeptId { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string Mh003 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string Mh004 { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string Mh005 { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        //[ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string Mh006 { get; set; }

        //[ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string Mh007 { get; set; }

        //[ExcelColumn(Name = "明细科目")]
        [ExcelColumnName("明细科目")]
        public string Mh008 { get; set; }

        //[ExcelColumn(Name = "明细名称")]
        [ExcelColumnName("明细名称")]
        public string Mh009 { get; set; }

        //[ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string Mh010 { get; set; }

        [Required(ErrorMessage = "预算金额不能为空")]
        //[ExcelColumn(Name = "预算金额")]
        [ExcelColumnName("预算金额")]
        public decimal Mh011 { get; set; }

        [Required(ErrorMessage = "实际发生不能为空")]
        //[ExcelColumn(Name = "实际发生")]
        [ExcelColumnName("实际发生")]
        public decimal Mh012 { get; set; }

        [Required(ErrorMessage = "差异不能为空")]
        //[ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal Mh013 { get; set; }

        [Required(ErrorMessage = "启用标记不能为空")]
        //[ExcelColumn(Name = "启用标记")]
        [ExcelColumnName("启用标记")]
        public int Mh014 { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        //[ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int Mh015 { get; set; }

        //[ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]
        public string Mh016 { get; set; }

        //[ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? Mh017 { get; set; }

        //[ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]
        public string Mh018 { get; set; }

        //[ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]
        public DateTime? Mh019 { get; set; }

        [ExcelIgnore]
        public string Ref01 { get; set; }

        [ExcelIgnore]
        public string Ref02 { get; set; }

        [ExcelIgnore]
        public string Ref03 { get; set; }

        [Required(ErrorMessage = "预留1不能为空")]
        [ExcelIgnore]
        public decimal Ref04 { get; set; }

        [Required(ErrorMessage = "预留2不能为空")]
        [ExcelIgnore]
        public decimal Ref05 { get; set; }

        [Required(ErrorMessage = "预留3不能为空")]
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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public int Udf51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public int Udf52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public int Udf53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal Udf54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal Udf55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
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
        [ExcelColumn(Name = "期间")]
        public string Mh003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string Mh004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司")]
        public string Mh005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "科目")]
        public string Mh006Label { get; set; }
    }

}