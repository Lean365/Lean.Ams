
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 费用预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/16 8:05:21
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
        /// 部门 
        /// </summary>        
        public int? Mh006 { get; set; }
        /// <summary>
        /// 科目 
        /// </summary>        
        public string Mh007 { get; set; }
        /// <summary>
        /// 类别 
        /// </summary>        
        public string Mh008 { get; set; }
        /// <summary>
        /// 用途 
        /// </summary>        
        public string Mh009 { get; set; }
        /// <summary>
        /// 审核 
        /// </summary>        
        public int? Mh016 { get; set; }
    }

    /// <summary>
    /// 费用预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/16 8:05:21
    /// </summary>
    public class FicoBudgetExpenseDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? Id { get; set; }

        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]

        public long? ParentId { get; set; }

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

        [Required(ErrorMessage = "部门不能为空")]
        //[ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]

        public int Mh006 { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        //[ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]

        public string Mh007 { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        //[ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]

        public string Mh008 { get; set; }

        //[ExcelColumn(Name = "用途")]
        [ExcelColumnName("用途")]

        public string Mh009 { get; set; }

        [Required(ErrorMessage = "单价不能为空")]
        //[ExcelColumn(Name = "单价")]
        [ExcelColumnName("单价")]

        public int Mh010 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]

        public int Mh011 { get; set; }

        [Required(ErrorMessage = "金额不能为空")]
        //[ExcelColumn(Name = "金额")]
        [ExcelColumnName("金额")]

        public decimal Mh012 { get; set; }

        [Required(ErrorMessage = "实际不能为空")]
        //[ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]

        public decimal Mh013 { get; set; }

        [Required(ErrorMessage = "差异不能为空")]
        //[ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]

        public decimal Mh014 { get; set; }

        [Required(ErrorMessage = "启用不能为空")]
        //[ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]

        public int Mh015 { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        //[ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]

        public int Mh016 { get; set; }

        //[ExcelColumn(Name = "审核人")]
        [ExcelColumnName("审核人")]

        public string Mh017 { get; set; }

        //[ExcelColumn(Name = "审核日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日")]

        public DateTime? Mh018 { get; set; }

        //[ExcelColumn(Name = "撤消人")]
        [ExcelColumnName("撤消人")]

        public string Mh019 { get; set; }

        //[ExcelColumn(Name = "撤消日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日")]

        public DateTime? Mh020 { get; set; }

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



        [ExcelColumn(Name = "期间")]
        public string Mh003Label { get; set; }
        [ExcelColumn(Name = "年月")]
        public string Mh004Label { get; set; }
        [ExcelColumn(Name = "公司")]
        public string Mh005Label { get; set; }
        [ExcelColumn(Name = "部门")]
        public string Mh006Label { get; set; }
        [ExcelColumn(Name = "科目")]
        public string Mh007Label { get; set; }
        [ExcelColumn(Name = "类别")]
        public string Mh008Label { get; set; }
        [ExcelColumn(Name = "启用")]
        public string Mh015Label { get; set; }
    }

    /// <summary>
    /// 费用预算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/16 8:05:21
    /// </summary>
    public class FicoBudgetExpenseImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? Id { get; set; }

        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long? ParentId { get; set; }

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

        [Required(ErrorMessage = "部门不能为空")]
        //[ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public int Mh006 { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        //[ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string Mh007 { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        //[ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string Mh008 { get; set; }

        //[ExcelColumn(Name = "用途")]
        [ExcelColumnName("用途")]
        public string Mh009 { get; set; }

        [Required(ErrorMessage = "单价不能为空")]
        //[ExcelColumn(Name = "单价")]
        [ExcelColumnName("单价")]
        public int Mh010 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public int Mh011 { get; set; }

        [Required(ErrorMessage = "金额不能为空")]
        //[ExcelColumn(Name = "金额")]
        [ExcelColumnName("金额")]
        public decimal Mh012 { get; set; }

        [Required(ErrorMessage = "实际不能为空")]
        //[ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]
        public decimal Mh013 { get; set; }

        [Required(ErrorMessage = "差异不能为空")]
        //[ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal Mh014 { get; set; }

        [Required(ErrorMessage = "启用不能为空")]
        //[ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]
        public int Mh015 { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        //[ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int Mh016 { get; set; }

        //[ExcelColumn(Name = "审核人")]
        [ExcelColumnName("审核人")]
        public string Mh017 { get; set; }

        //[ExcelColumn(Name = "审核日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日")]
        public DateTime? Mh018 { get; set; }

        //[ExcelColumn(Name = "撤消人")]
        [ExcelColumnName("撤消人")]
        public string Mh019 { get; set; }

        //[ExcelColumn(Name = "撤消日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日")]
        public DateTime? Mh020 { get; set; }

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
        [ExcelColumn(Name = "期间")]
        public string Mh003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string Mh004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司")]
        public string Mh005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "部门")]
        public string Mh006Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "科目")]
        public string Mh007Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "类别")]
        public string Mh008Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "启用")]
        public string Mh015Label { get; set; }
    }

}