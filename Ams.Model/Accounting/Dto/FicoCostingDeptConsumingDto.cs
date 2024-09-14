
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 部门消耗
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:51:22
    /// </summary>
    public class FicoCostingDeptConsumingQueryDto : PagerInfo 
    {
        /// <summary>
        /// 期间 
        /// </summary>        
        public string Ml002 { get; set; }
        /// <summary>
        /// 年月 
        /// </summary>        
        public string Ml003 { get; set; }
        /// <summary>
        /// 公司代码 
        /// </summary>        
        public string Ml004 { get; set; }
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Ml013 { get; set; }
    }

    /// <summary>
    /// 部门消耗
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:51:22
    /// </summary>
    public class FicoCostingDeptConsumingDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]

        public string Ml002 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]

        public string Ml003 { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        //[ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]

        public string Ml004 { get; set; }

        //[ExcelColumn(Name = "统计类别")]
        [ExcelColumnName("统计类别")]

        public string Ml005 { get; set; }

        //[ExcelColumn(Name = "成本科目")]
        [ExcelColumnName("成本科目")]

        public string Ml006 { get; set; }

        //[ExcelColumn(Name = "科目代码")]
        [ExcelColumnName("科目代码")]

        public string Ml007 { get; set; }

        //[ExcelColumn(Name = "科目分类")]
        [ExcelColumnName("科目分类")]

        public string Ml008 { get; set; }

        //[ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]

        public decimal Ml009 { get; set; }

        //[ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]

        public decimal Ml010 { get; set; }

        //[ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]

        public decimal Ml011 { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Ml012 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Ml013 { get; set; }

        //[ExcelColumn(Name = "仓库")]
        [ExcelColumnName("仓库")]

        public string Ml014 { get; set; }

        //[ExcelColumn(Name = "移动类型")]
        [ExcelColumnName("移动类型")]

        public string Ml015 { get; set; }

        //[ExcelColumn(Name = "物料凭证")]
        [ExcelColumnName("物料凭证")]

        public string Ml016 { get; set; }

        //[ExcelColumn(Name = "项目明细")]
        [ExcelColumnName("项目明细")]

        public string Ml017 { get; set; }

        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]

        public decimal Ml018 { get; set; }

        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]

        public string Ml019 { get; set; }

        //[ExcelColumn(Name = "金额")]
        [ExcelColumnName("金额")]

        public decimal Ml020 { get; set; }

        //[ExcelColumn(Name = "预留单")]
        [ExcelColumnName("预留单")]

        public string Ml021 { get; set; }

        //[ExcelColumn(Name = "预留明细")]
        [ExcelColumnName("预留明细")]

        public string Ml022 { get; set; }

        //[ExcelColumn(Name = "领用日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("领用日期")]

        public DateTime? Ml023 { get; set; }

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

        public string Remark { get; set; }

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
        public string Ml002Label { get; set; }
        [ExcelColumn(Name = "年月")]
        public string Ml003Label { get; set; }
        [ExcelColumn(Name = "公司代码")]
        public string Ml004Label { get; set; }
        [ExcelColumn(Name = "工厂")]
        public string Ml012Label { get; set; }
    }

    /// <summary>
    /// 部门消耗
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:51:22
    /// </summary>
    public class FicoCostingDeptConsumingImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string Ml002 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string Ml003 { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        //[ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string Ml004 { get; set; }

        //[ExcelColumn(Name = "统计类别")]
        [ExcelColumnName("统计类别")]
        public string Ml005 { get; set; }

        //[ExcelColumn(Name = "成本科目")]
        [ExcelColumnName("成本科目")]
        public string Ml006 { get; set; }

        //[ExcelColumn(Name = "科目代码")]
        [ExcelColumnName("科目代码")]
        public string Ml007 { get; set; }

        //[ExcelColumn(Name = "科目分类")]
        [ExcelColumnName("科目分类")]
        public string Ml008 { get; set; }

        //[ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public decimal Ml009 { get; set; }

        //[ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]
        public decimal Ml010 { get; set; }

        //[ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal Ml011 { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Ml012 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Ml013 { get; set; }

        //[ExcelColumn(Name = "仓库")]
        [ExcelColumnName("仓库")]
        public string Ml014 { get; set; }

        //[ExcelColumn(Name = "移动类型")]
        [ExcelColumnName("移动类型")]
        public string Ml015 { get; set; }

        //[ExcelColumn(Name = "物料凭证")]
        [ExcelColumnName("物料凭证")]
        public string Ml016 { get; set; }

        //[ExcelColumn(Name = "项目明细")]
        [ExcelColumnName("项目明细")]
        public string Ml017 { get; set; }

        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal Ml018 { get; set; }

        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Ml019 { get; set; }

        //[ExcelColumn(Name = "金额")]
        [ExcelColumnName("金额")]
        public decimal Ml020 { get; set; }

        //[ExcelColumn(Name = "预留单")]
        [ExcelColumnName("预留单")]
        public string Ml021 { get; set; }

        //[ExcelColumn(Name = "预留明细")]
        [ExcelColumnName("预留明细")]
        public string Ml022 { get; set; }

        //[ExcelColumn(Name = "领用日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("领用日期")]
        public DateTime? Ml023 { get; set; }

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
        public string Remark { get; set; }

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
        public string Ml002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string Ml003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司代码")]
        public string Ml004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string Ml012Label { get; set; }
    }

}