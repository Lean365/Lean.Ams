
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 加班预算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:57:03
    /// </summary>
    public class FicoBudgetOvertimeQueryDto : PagerInfo 
    {
        /// <summary>
        /// 财年 
        /// </summary>        
        public string Mi004 { get; set; }
        /// <summary>
        /// 年月 
        /// </summary>        
        public string Mi005 { get; set; }
        /// <summary>
        /// 公司 
        /// </summary>        
        public string Mi006 { get; set; }
        /// <summary>
        /// 科目 
        /// </summary>        
        public string Mi007 { get; set; }
    }

    /// <summary>
    /// 加班预算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:57:03
    /// </summary>
    public class FicoBudgetOvertimeDto
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

        [Required(ErrorMessage = "财年不能为空")]
        //[ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]

        public string Mi004 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]

        public string Mi005 { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]

        public string Mi006 { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        //[ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]

        public string Mi007 { get; set; }

        //[ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]

        public string Mi008 { get; set; }

        //[ExcelColumn(Name = "必要工数")]
        [ExcelColumnName("必要工数")]

        public decimal Mi009 { get; set; }

        [Required(ErrorMessage = "保有人数不能为空")]
        //[ExcelColumn(Name = "保有人数")]
        [ExcelColumnName("保有人数")]

        public int Mi010 { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        //[ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]

        public int Mi011 { get; set; }

        [Required(ErrorMessage = "上班天数不能为空")]
        //[ExcelColumn(Name = "上班天数")]
        [ExcelColumnName("上班天数")]

        public int Mi012 { get; set; }

        //[ExcelColumn(Name = "加班事由")]
        [ExcelColumnName("加班事由")]

        public string Mi013 { get; set; }

        //[ExcelColumn(Name = "保有工数")]
        [ExcelColumnName("保有工数")]

        public decimal Mi014 { get; set; }

        //[ExcelColumn(Name = "工数差异")]
        [ExcelColumnName("工数差异")]

        public decimal Mi015 { get; set; }

        //[ExcelColumn(Name = "投入加班")]
        [ExcelColumnName("投入加班")]

        public decimal Mi016 { get; set; }

        //[ExcelColumn(Name = "平均投入加班")]
        [ExcelColumnName("平均投入加班")]

        public decimal Mi017 { get; set; }

        //[ExcelColumn(Name = "间接加班")]
        [ExcelColumnName("间接加班")]

        public decimal Mi018 { get; set; }

        //[ExcelColumn(Name = "投入总加班")]
        [ExcelColumnName("投入总加班")]

        public decimal Mi019 { get; set; }

        [Required(ErrorMessage = "启用标记不能为空")]
        //[ExcelColumn(Name = "启用标记")]
        [ExcelColumnName("启用标记")]

        public int Mi020 { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        //[ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]

        public int Mi021 { get; set; }

        //[ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]

        public string Mi022 { get; set; }

        //[ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]

        public DateTime? Mi023 { get; set; }

        //[ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]

        public string Mi024 { get; set; }

        //[ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]

        public DateTime? Mi025 { get; set; }

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



        [ExcelColumn(Name = "财年")]
        public string Mi004Label { get; set; }
        [ExcelColumn(Name = "年月")]
        public string Mi005Label { get; set; }
        [ExcelColumn(Name = "公司")]
        public string Mi006Label { get; set; }
        [ExcelColumn(Name = "科目")]
        public string Mi007Label { get; set; }
    }

    /// <summary>
    /// 加班预算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:57:03
    /// </summary>
    public class FicoBudgetOvertimeImportTpl
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

        [Required(ErrorMessage = "财年不能为空")]
        //[ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string Mi004 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string Mi005 { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string Mi006 { get; set; }

        [Required(ErrorMessage = "科目不能为空")]
        //[ExcelColumn(Name = "科目")]
        [ExcelColumnName("科目")]
        public string Mi007 { get; set; }

        //[ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string Mi008 { get; set; }

        //[ExcelColumn(Name = "必要工数")]
        [ExcelColumnName("必要工数")]
        public decimal Mi009 { get; set; }

        [Required(ErrorMessage = "保有人数不能为空")]
        //[ExcelColumn(Name = "保有人数")]
        [ExcelColumnName("保有人数")]
        public int Mi010 { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        //[ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]
        public int Mi011 { get; set; }

        [Required(ErrorMessage = "上班天数不能为空")]
        //[ExcelColumn(Name = "上班天数")]
        [ExcelColumnName("上班天数")]
        public int Mi012 { get; set; }

        //[ExcelColumn(Name = "加班事由")]
        [ExcelColumnName("加班事由")]
        public string Mi013 { get; set; }

        //[ExcelColumn(Name = "保有工数")]
        [ExcelColumnName("保有工数")]
        public decimal Mi014 { get; set; }

        //[ExcelColumn(Name = "工数差异")]
        [ExcelColumnName("工数差异")]
        public decimal Mi015 { get; set; }

        //[ExcelColumn(Name = "投入加班")]
        [ExcelColumnName("投入加班")]
        public decimal Mi016 { get; set; }

        //[ExcelColumn(Name = "平均投入加班")]
        [ExcelColumnName("平均投入加班")]
        public decimal Mi017 { get; set; }

        //[ExcelColumn(Name = "间接加班")]
        [ExcelColumnName("间接加班")]
        public decimal Mi018 { get; set; }

        //[ExcelColumn(Name = "投入总加班")]
        [ExcelColumnName("投入总加班")]
        public decimal Mi019 { get; set; }

        [Required(ErrorMessage = "启用标记不能为空")]
        //[ExcelColumn(Name = "启用标记")]
        [ExcelColumnName("启用标记")]
        public int Mi020 { get; set; }

        [Required(ErrorMessage = "审核不能为空")]
        //[ExcelColumn(Name = "审核")]
        [ExcelColumnName("审核")]
        public int Mi021 { get; set; }

        //[ExcelColumn(Name = "审核人员")]
        [ExcelColumnName("审核人员")]
        public string Mi022 { get; set; }

        //[ExcelColumn(Name = "审核日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("审核日期")]
        public DateTime? Mi023 { get; set; }

        //[ExcelColumn(Name = "撤消人员")]
        [ExcelColumnName("撤消人员")]
        public string Mi024 { get; set; }

        //[ExcelColumn(Name = "撤消日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("撤消日期")]
        public DateTime? Mi025 { get; set; }

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
        [ExcelColumn(Name = "财年")]
        public string Mi004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string Mi005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司")]
        public string Mi006Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "科目")]
        public string Mi007Label { get; set; }
    }

}