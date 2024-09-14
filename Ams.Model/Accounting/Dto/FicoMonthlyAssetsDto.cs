
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 月度资产
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:54:31
    /// </summary>
    public class FicoMonthlyAssetsQueryDto : PagerInfo 
    {
        /// <summary>
        /// 期间 
        /// </summary>        
        public string Mo002 { get; set; }
        /// <summary>
        /// 年月 
        /// </summary>        
        public string Mo003 { get; set; }
        /// <summary>
        /// 公司 
        /// </summary>        
        public string Mo004 { get; set; }
        /// <summary>
        /// 成本中心 
        /// </summary>        
        public string Mo008 { get; set; }
        /// <summary>
        /// 资产简称 
        /// </summary>        
        public string Mo009 { get; set; }
        /// <summary>
        /// 资本化日期 
        /// </summary>        
        public DateTime? BeginMo016 { get; set; }
        public DateTime? EndMo016 { get; set; }
        /// <summary>
        /// 报废日期 
        /// </summary>        
        public DateTime? BeginMo018 { get; set; }
        public DateTime? EndMo018 { get; set; }
    }

    /// <summary>
    /// 月度资产
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:54:31
    /// </summary>
    public class FicoMonthlyAssetsDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]

        public string Mo002 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]

        public string Mo003 { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]

        public string Mo004 { get; set; }

        //[ExcelColumn(Name = "使用部门")]
        [ExcelColumnName("使用部门")]

        public string Mo005 { get; set; }

        //[ExcelColumn(Name = "资产类别")]
        [ExcelColumnName("资产类别")]

        public string Mo006 { get; set; }

        //[ExcelColumn(Name = "资产编码")]
        [ExcelColumnName("资产编码")]

        public string Mo007 { get; set; }

        //[ExcelColumn(Name = "成本中心")]
        [ExcelColumnName("成本中心")]

        public string Mo008 { get; set; }

        //[ExcelColumn(Name = "资产简称")]
        [ExcelColumnName("资产简称")]

        public string Mo009 { get; set; }

        //[ExcelColumn(Name = "资产全称")]
        [ExcelColumnName("资产全称")]

        public string Mo010 { get; set; }

        //[ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]

        public string Mo011 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]

        public int Mo012 { get; set; }

        [Required(ErrorMessage = "管理区分不能为空")]
        //[ExcelColumn(Name = "管理区分")]
        [ExcelColumnName("管理区分")]

        public int Mo013 { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]

        public string Mo014 { get; set; }

        [Required(ErrorMessage = "购买价格不能为空")]
        //[ExcelColumn(Name = "购买价格")]
        [ExcelColumnName("购买价格")]

        public decimal Mo015 { get; set; }

        //[ExcelColumn(Name = "资本化日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("资本化日期")]

        public DateTime? Mo016 { get; set; }

        [Required(ErrorMessage = "折旧价值不能为空")]
        //[ExcelColumn(Name = "折旧价值")]
        [ExcelColumnName("折旧价值")]

        public decimal Mo017 { get; set; }

        //[ExcelColumn(Name = "报废日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("报废日期")]

        public DateTime? Mo018 { get; set; }

        [Required(ErrorMessage = "残值不能为空")]
        //[ExcelColumn(Name = "残值")]
        [ExcelColumnName("残值")]

        public decimal Mo019 { get; set; }

        //[ExcelColumn(Name = "存放位置")]
        [ExcelColumnName("存放位置")]

        public string Mo020 { get; set; }

        [Required(ErrorMessage = "使用年限不能为空")]
        //[ExcelColumn(Name = "使用年限")]
        [ExcelColumnName("使用年限")]

        public decimal Mo021 { get; set; }

        [Required(ErrorMessage = "是否停用不能为空")]
        //[ExcelColumn(Name = "是否停用")]
        [ExcelColumnName("是否停用")]

        public int Mo022 { get; set; }

        //[ExcelColumn(Name = "供应商")]
        [ExcelColumnName("供应商")]

        public string Mo023 { get; set; }

        //[ExcelColumn(Name = "制造商")]
        [ExcelColumnName("制造商")]

        public string Mo024 { get; set; }

        //[ExcelColumn(Name = "供应商物料")]
        [ExcelColumnName("供应商物料")]

        public string Mo025 { get; set; }

        //[ExcelColumn(Name = "制造商物料")]
        [ExcelColumnName("制造商物料")]

        public string Mo026 { get; set; }

        [Required(ErrorMessage = "资产形态不能为空")]
        //[ExcelColumn(Name = "资产形态")]
        [ExcelColumnName("资产形态")]

        public int Mo027 { get; set; }

        [Required(ErrorMessage = "资产存在否不能为空")]
        //[ExcelColumn(Name = "资产存在否")]
        [ExcelColumnName("资产存在否")]

        public int Mo028 { get; set; }

        //[ExcelColumn(Name = "盘点人员")]
        [ExcelColumnName("盘点人员")]

        public string Mo029 { get; set; }

        //[ExcelColumn(Name = "周期盘点日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("周期盘点日期")]

        public DateTime? Mo030 { get; set; }

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
        public string Mo002Label { get; set; }
        [ExcelColumn(Name = "年月")]
        public string Mo003Label { get; set; }
        [ExcelColumn(Name = "公司")]
        public string Mo004Label { get; set; }
        [ExcelColumn(Name = "成本中心")]
        public string Mo008Label { get; set; }
        [ExcelColumn(Name = "是否停用")]
        public string Mo022Label { get; set; }
    }

    /// <summary>
    /// 月度资产
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:54:31
    /// </summary>
    public class FicoMonthlyAssetsImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string Mo002 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string Mo003 { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        //[ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string Mo004 { get; set; }

        //[ExcelColumn(Name = "使用部门")]
        [ExcelColumnName("使用部门")]
        public string Mo005 { get; set; }

        //[ExcelColumn(Name = "资产类别")]
        [ExcelColumnName("资产类别")]
        public string Mo006 { get; set; }

        //[ExcelColumn(Name = "资产编码")]
        [ExcelColumnName("资产编码")]
        public string Mo007 { get; set; }

        //[ExcelColumn(Name = "成本中心")]
        [ExcelColumnName("成本中心")]
        public string Mo008 { get; set; }

        //[ExcelColumn(Name = "资产简称")]
        [ExcelColumnName("资产简称")]
        public string Mo009 { get; set; }

        //[ExcelColumn(Name = "资产全称")]
        [ExcelColumnName("资产全称")]
        public string Mo010 { get; set; }

        //[ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]
        public string Mo011 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public int Mo012 { get; set; }

        [Required(ErrorMessage = "管理区分不能为空")]
        //[ExcelColumn(Name = "管理区分")]
        [ExcelColumnName("管理区分")]
        public int Mo013 { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Mo014 { get; set; }

        [Required(ErrorMessage = "购买价格不能为空")]
        //[ExcelColumn(Name = "购买价格")]
        [ExcelColumnName("购买价格")]
        public decimal Mo015 { get; set; }

        //[ExcelColumn(Name = "资本化日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("资本化日期")]
        public DateTime? Mo016 { get; set; }

        [Required(ErrorMessage = "折旧价值不能为空")]
        //[ExcelColumn(Name = "折旧价值")]
        [ExcelColumnName("折旧价值")]
        public decimal Mo017 { get; set; }

        //[ExcelColumn(Name = "报废日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("报废日期")]
        public DateTime? Mo018 { get; set; }

        [Required(ErrorMessage = "残值不能为空")]
        //[ExcelColumn(Name = "残值")]
        [ExcelColumnName("残值")]
        public decimal Mo019 { get; set; }

        //[ExcelColumn(Name = "存放位置")]
        [ExcelColumnName("存放位置")]
        public string Mo020 { get; set; }

        [Required(ErrorMessage = "使用年限不能为空")]
        //[ExcelColumn(Name = "使用年限")]
        [ExcelColumnName("使用年限")]
        public decimal Mo021 { get; set; }

        [Required(ErrorMessage = "是否停用不能为空")]
        //[ExcelColumn(Name = "是否停用")]
        [ExcelColumnName("是否停用")]
        public int Mo022 { get; set; }

        //[ExcelColumn(Name = "供应商")]
        [ExcelColumnName("供应商")]
        public string Mo023 { get; set; }

        //[ExcelColumn(Name = "制造商")]
        [ExcelColumnName("制造商")]
        public string Mo024 { get; set; }

        //[ExcelColumn(Name = "供应商物料")]
        [ExcelColumnName("供应商物料")]
        public string Mo025 { get; set; }

        //[ExcelColumn(Name = "制造商物料")]
        [ExcelColumnName("制造商物料")]
        public string Mo026 { get; set; }

        [Required(ErrorMessage = "资产形态不能为空")]
        //[ExcelColumn(Name = "资产形态")]
        [ExcelColumnName("资产形态")]
        public int Mo027 { get; set; }

        [Required(ErrorMessage = "资产存在否不能为空")]
        //[ExcelColumn(Name = "资产存在否")]
        [ExcelColumnName("资产存在否")]
        public int Mo028 { get; set; }

        //[ExcelColumn(Name = "盘点人员")]
        [ExcelColumnName("盘点人员")]
        public string Mo029 { get; set; }

        //[ExcelColumn(Name = "周期盘点日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("周期盘点日期")]
        public DateTime? Mo030 { get; set; }

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
        public string Mo002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string Mo003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司")]
        public string Mo004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "成本中心")]
        public string Mo008Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "是否停用")]
        public string Mo022Label { get; set; }
    }

}