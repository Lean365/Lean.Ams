
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 资产预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/15 14:12:43
    /// </summary>
    public class FicoBudgetAssetsQueryDto : PagerInfo 
    {
        /// <summary>
        /// 期间 
        /// </summary>        
        public string Mg003 { get; set; }
        /// <summary>
        /// 年月 
        /// </summary>        
        public string Mg004 { get; set; }
        /// <summary>
        /// 公司 
        /// </summary>        
        public string Mg005 { get; set; }
        /// <summary>
        /// 部门 
        /// </summary>        
        public int? Mg006 { get; set; }
        /// <summary>
        /// 预算科目 
        /// </summary>        
        public string Mg007 { get; set; }
        /// <summary>
        /// 费用类别 
        /// </summary>        
        public string Mg008 { get; set; }
        /// <summary>
        /// 资产名称 
        /// </summary>        
        public string Mg009 { get; set; }
        /// <summary>
        /// 审核 
        /// </summary>        
        public int? Mg019 { get; set; }
    }

    /// <summary>
    /// 资产预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/15 14:12:43
    /// </summary>
    public class FicoBudgetAssetsDto
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

        public string Mg003 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]

        public string Mg004 { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]

        public string Mg005 { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        //[ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]

        public int Mg006 { get; set; }

        [Required(ErrorMessage = "预算科目不能为空")]
        //[ExcelColumn(Name = "预算科目")]
        [ExcelColumnName("预算科目")]

        public string Mg007 { get; set; }

        [Required(ErrorMessage = "费用类别不能为空")]
        //[ExcelColumn(Name = "费用类别")]
        [ExcelColumnName("费用类别")]

        public string Mg008 { get; set; }

        [Required(ErrorMessage = "资产名称不能为空")]
        //[ExcelColumn(Name = "资产名称")]
        [ExcelColumnName("资产名称")]

        public string Mg009 { get; set; }

        //[ExcelColumn(Name = "用途说明")]
        [ExcelColumnName("用途说明")]

        public string Mg010 { get; set; }

        [Required(ErrorMessage = "年限不能为空")]
        //[ExcelColumn(Name = "年限")]
        [ExcelColumnName("年限")]

        public int Mg011 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]

        public int Mg012 { get; set; }

        [Required(ErrorMessage = "单价不能为空")]
        //[ExcelColumn(Name = "单价")]
        [ExcelColumnName("单价")]

        public decimal Mg013 { get; set; }

        [Required(ErrorMessage = "金额不能为空")]
        //[ExcelColumn(Name = "金额")]
        [ExcelColumnName("金额")]

        public decimal Mg014 { get; set; }

        [Required(ErrorMessage = "实际不能为空")]
        //[ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]

        public decimal Mg015 { get; set; }

        [Required(ErrorMessage = "差异不能为空")]
        //[ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]

        public decimal Mg016 { get; set; }

        [Required(ErrorMessage = "折旧不能为空")]
        //[ExcelColumn(Name = "折旧")]
        [ExcelColumnName("折旧")]

        public decimal Mg017 { get; set; }

        [Required(ErrorMessage = "启用不能为空")]
        //[ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]

        public int Mg018 { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        //[ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]

        public int Mg019 { get; set; }

        //[ExcelColumn(Name = "审核人")]
        [ExcelColumnName("审核人")]

        public string Mg020 { get; set; }

        //[ExcelColumn(Name = "审核日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日")]

        public DateTime? Mg021 { get; set; }

        //[ExcelColumn(Name = "撤消人")]
        [ExcelColumnName("撤消人")]

        public string Mg022 { get; set; }

        //[ExcelColumn(Name = "撤消日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日")]

        public DateTime? Mg023 { get; set; }

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
        public string Mg003Label { get; set; }
        [ExcelColumn(Name = "年月")]
        public string Mg004Label { get; set; }
        [ExcelColumn(Name = "公司")]
        public string Mg005Label { get; set; }
        [ExcelColumn(Name = "部门")]
        public string Mg006Label { get; set; }
        [ExcelColumn(Name = "预算科目")]
        public string Mg007Label { get; set; }
        [ExcelColumn(Name = "费用类别")]
        public string Mg008Label { get; set; }
        [ExcelColumn(Name = "启用")]
        public string Mg018Label { get; set; }
    }

    /// <summary>
    /// 资产预算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/15 14:12:43
    /// </summary>
    public class FicoBudgetAssetsImportTpl
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
        public string Mg003 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string Mg004 { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string Mg005 { get; set; }

        [Required(ErrorMessage = "部门不能为空")]
        //[ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public int Mg006 { get; set; }

        [Required(ErrorMessage = "预算科目不能为空")]
        //[ExcelColumn(Name = "预算科目")]
        [ExcelColumnName("预算科目")]
        public string Mg007 { get; set; }

        [Required(ErrorMessage = "费用类别不能为空")]
        //[ExcelColumn(Name = "费用类别")]
        [ExcelColumnName("费用类别")]
        public string Mg008 { get; set; }

        [Required(ErrorMessage = "资产名称不能为空")]
        //[ExcelColumn(Name = "资产名称")]
        [ExcelColumnName("资产名称")]
        public string Mg009 { get; set; }

        //[ExcelColumn(Name = "用途说明")]
        [ExcelColumnName("用途说明")]
        public string Mg010 { get; set; }

        [Required(ErrorMessage = "年限不能为空")]
        //[ExcelColumn(Name = "年限")]
        [ExcelColumnName("年限")]
        public int Mg011 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public int Mg012 { get; set; }

        [Required(ErrorMessage = "单价不能为空")]
        //[ExcelColumn(Name = "单价")]
        [ExcelColumnName("单价")]
        public decimal Mg013 { get; set; }

        [Required(ErrorMessage = "金额不能为空")]
        //[ExcelColumn(Name = "金额")]
        [ExcelColumnName("金额")]
        public decimal Mg014 { get; set; }

        [Required(ErrorMessage = "实际不能为空")]
        //[ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]
        public decimal Mg015 { get; set; }

        [Required(ErrorMessage = "差异不能为空")]
        //[ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal Mg016 { get; set; }

        [Required(ErrorMessage = "折旧不能为空")]
        //[ExcelColumn(Name = "折旧")]
        [ExcelColumnName("折旧")]
        public decimal Mg017 { get; set; }

        [Required(ErrorMessage = "启用不能为空")]
        //[ExcelColumn(Name = "启用")]
        [ExcelColumnName("启用")]
        public int Mg018 { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        //[ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int Mg019 { get; set; }

        //[ExcelColumn(Name = "审核人")]
        [ExcelColumnName("审核人")]
        public string Mg020 { get; set; }

        //[ExcelColumn(Name = "审核日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日")]
        public DateTime? Mg021 { get; set; }

        //[ExcelColumn(Name = "撤消人")]
        [ExcelColumnName("撤消人")]
        public string Mg022 { get; set; }

        //[ExcelColumn(Name = "撤消日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日")]
        public DateTime? Mg023 { get; set; }

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
        public string Mg003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string Mg004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司")]
        public string Mg005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "部门")]
        public string Mg006Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "预算科目")]
        public string Mg007Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "费用类别")]
        public string Mg008Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "启用")]
        public string Mg018Label { get; set; }
    }

}