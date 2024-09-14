
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 源物料
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:36:27
    /// </summary>
    public class PpSourceMaterialQueryDto : PagerInfo 
    {
        /// <summary>
        /// Plnt 
        /// </summary>        
        public string Zd002 { get; set; }
        /// <summary>
        /// 品目 
        /// </summary>        
        public string Zd003 { get; set; }
        /// <summary>
        /// 采购组 
        /// </summary>        
        public string Zd010 { get; set; }
    }

    /// <summary>
    /// 源物料
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:36:27
    /// </summary>
    public class PpSourceMaterialDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "Plnt不能为空")]
        //[ExcelColumn(Name = "Plnt")]
        [ExcelColumnName("Plnt")]

        public string Zd002 { get; set; }

        [Required(ErrorMessage = "品目不能为空")]
        //[ExcelColumn(Name = "品目")]
        [ExcelColumnName("品目")]

        public string Zd003 { get; set; }

        //[ExcelColumn(Name = "行业领域")]
        [ExcelColumnName("行业领域")]

        public string Zd004 { get; set; }

        //[ExcelColumn(Name = "物料类型")]
        [ExcelColumnName("物料类型")]

        public string Zd005 { get; set; }

        //[ExcelColumn(Name = "物料描述（短文本）")]
        [ExcelColumnName("物料描述（短文本）")]

        public string Zd006 { get; set; }

        //[ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]

        public string Zd007 { get; set; }

        //[ExcelColumn(Name = "产品层次")]
        [ExcelColumnName("产品层次")]

        public string Zd008 { get; set; }

        //[ExcelColumn(Name = "物料组")]
        [ExcelColumnName("物料组")]

        public string Zd009 { get; set; }

        //[ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]

        public string Zd010 { get; set; }

        //[ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]

        public string Zd011 { get; set; }

        //[ExcelColumn(Name = "特殊采购类")]
        [ExcelColumnName("特殊采购类")]

        public string Zd012 { get; set; }

        //[ExcelColumn(Name = "散装物料")]
        [ExcelColumnName("散装物料")]

        public string Zd013 { get; set; }

        [Required(ErrorMessage = "最小起订量不能为空")]
        //[ExcelColumn(Name = "最小起订量")]
        [ExcelColumnName("最小起订量")]

        public int Zd014 { get; set; }

        //[ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]

        public string Zd015 { get; set; }

        [Required(ErrorMessage = "舍入值不能为空")]
        //[ExcelColumn(Name = "舍入值")]
        [ExcelColumnName("舍入值")]

        public int Zd016 { get; set; }

        //[ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]

        public string Zd017 { get; set; }

        //[ExcelColumn(Name = "计划交货")]
        [ExcelColumnName("计划交货")]

        public string Zd018 { get; set; }

        [Required(ErrorMessage = "自制天数不能为空")]
        //[ExcelColumn(Name = "自制天数")]
        [ExcelColumnName("自制天数")]

        public decimal Zd019 { get; set; }

        //[ExcelColumn(Name = "过账检验")]
        [ExcelColumnName("过账检验")]

        public string Zd020 { get; set; }

        //[ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]

        public string Zd021 { get; set; }

        //[ExcelColumn(Name = "差异码")]
        [ExcelColumnName("差异码")]

        public string Zd022 { get; set; }

        //[ExcelColumn(Name = "批次管理")]
        [ExcelColumnName("批次管理")]

        public string Zd023 { get; set; }

        //[ExcelColumn(Name = "制造商零件编号")]
        [ExcelColumnName("制造商零件编号")]

        public string Zd024 { get; set; }

        //[ExcelColumn(Name = "制造商编号")]
        [ExcelColumnName("制造商编号")]

        public string Zd025 { get; set; }

        //[ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]

        public string Zd026 { get; set; }

        [Required(ErrorMessage = "移动平均价格/周期单价不能为空")]
        //[ExcelColumn(Name = "移动平均价格/周期单价")]
        [ExcelColumnName("移动平均价格/周期单价")]

        public decimal Zd027 { get; set; }

        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]

        public string Zd028 { get; set; }

        //[ExcelColumn(Name = "价格控制")]
        [ExcelColumnName("价格控制")]

        public string Zd029 { get; set; }

        //[ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]

        public string Zd030 { get; set; }

        //[ExcelColumn(Name = "生产仓储")]
        [ExcelColumnName("生产仓储")]

        public string Zd031 { get; set; }

        //[ExcelColumn(Name = "采购仓储")]
        [ExcelColumnName("采购仓储")]

        public string Zd032 { get; set; }

        //[ExcelColumn(Name = "库存仓位")]
        [ExcelColumnName("库存仓位")]

        public string Zd033 { get; set; }

        [Required(ErrorMessage = "库存不能为空")]
        //[ExcelColumn(Name = "库存")]
        [ExcelColumnName("库存")]

        public decimal Zd034 { get; set; }

        //[ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]

        public string Zd035 { get; set; }

        [ExcelIgnore]

        public string Remark { get; set; }

        [ExcelIgnore]

        public int? IsDeleted { get; set; }

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

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "Plnt")]
        public string Zd002Label { get; set; }
        [ExcelColumn(Name = "采购组")]
        public string Zd010Label { get; set; }
    }

    /// <summary>
    /// 源物料
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:36:27
    /// </summary>
    public class PpSourceMaterialImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "Plnt不能为空")]
        //[ExcelColumn(Name = "Plnt")]
        [ExcelColumnName("Plnt")]
        public string Zd002 { get; set; }

        [Required(ErrorMessage = "品目不能为空")]
        //[ExcelColumn(Name = "品目")]
        [ExcelColumnName("品目")]
        public string Zd003 { get; set; }

        //[ExcelColumn(Name = "行业领域")]
        [ExcelColumnName("行业领域")]
        public string Zd004 { get; set; }

        //[ExcelColumn(Name = "物料类型")]
        [ExcelColumnName("物料类型")]
        public string Zd005 { get; set; }

        //[ExcelColumn(Name = "物料描述（短文本）")]
        [ExcelColumnName("物料描述（短文本）")]
        public string Zd006 { get; set; }

        //[ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]
        public string Zd007 { get; set; }

        //[ExcelColumn(Name = "产品层次")]
        [ExcelColumnName("产品层次")]
        public string Zd008 { get; set; }

        //[ExcelColumn(Name = "物料组")]
        [ExcelColumnName("物料组")]
        public string Zd009 { get; set; }

        //[ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string Zd010 { get; set; }

        //[ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string Zd011 { get; set; }

        //[ExcelColumn(Name = "特殊采购类")]
        [ExcelColumnName("特殊采购类")]
        public string Zd012 { get; set; }

        //[ExcelColumn(Name = "散装物料")]
        [ExcelColumnName("散装物料")]
        public string Zd013 { get; set; }

        [Required(ErrorMessage = "最小起订量不能为空")]
        //[ExcelColumn(Name = "最小起订量")]
        [ExcelColumnName("最小起订量")]
        public int Zd014 { get; set; }

        //[ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]
        public string Zd015 { get; set; }

        [Required(ErrorMessage = "舍入值不能为空")]
        //[ExcelColumn(Name = "舍入值")]
        [ExcelColumnName("舍入值")]
        public int Zd016 { get; set; }

        //[ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]
        public string Zd017 { get; set; }

        //[ExcelColumn(Name = "计划交货")]
        [ExcelColumnName("计划交货")]
        public string Zd018 { get; set; }

        [Required(ErrorMessage = "自制天数不能为空")]
        //[ExcelColumn(Name = "自制天数")]
        [ExcelColumnName("自制天数")]
        public decimal Zd019 { get; set; }

        //[ExcelColumn(Name = "过账检验")]
        [ExcelColumnName("过账检验")]
        public string Zd020 { get; set; }

        //[ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string Zd021 { get; set; }

        //[ExcelColumn(Name = "差异码")]
        [ExcelColumnName("差异码")]
        public string Zd022 { get; set; }

        //[ExcelColumn(Name = "批次管理")]
        [ExcelColumnName("批次管理")]
        public string Zd023 { get; set; }

        //[ExcelColumn(Name = "制造商零件编号")]
        [ExcelColumnName("制造商零件编号")]
        public string Zd024 { get; set; }

        //[ExcelColumn(Name = "制造商编号")]
        [ExcelColumnName("制造商编号")]
        public string Zd025 { get; set; }

        //[ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]
        public string Zd026 { get; set; }

        [Required(ErrorMessage = "移动平均价格/周期单价不能为空")]
        //[ExcelColumn(Name = "移动平均价格/周期单价")]
        [ExcelColumnName("移动平均价格/周期单价")]
        public decimal Zd027 { get; set; }

        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Zd028 { get; set; }

        //[ExcelColumn(Name = "价格控制")]
        [ExcelColumnName("价格控制")]
        public string Zd029 { get; set; }

        //[ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]
        public string Zd030 { get; set; }

        //[ExcelColumn(Name = "生产仓储")]
        [ExcelColumnName("生产仓储")]
        public string Zd031 { get; set; }

        //[ExcelColumn(Name = "采购仓储")]
        [ExcelColumnName("采购仓储")]
        public string Zd032 { get; set; }

        //[ExcelColumn(Name = "库存仓位")]
        [ExcelColumnName("库存仓位")]
        public string Zd033 { get; set; }

        [Required(ErrorMessage = "库存不能为空")]
        //[ExcelColumn(Name = "库存")]
        [ExcelColumnName("库存")]
        public decimal Zd034 { get; set; }

        //[ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public string Zd035 { get; set; }

        [ExcelIgnore]
        public string Remark { get; set; }

        [ExcelIgnore]
        public int? IsDeleted { get; set; }

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
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "Plnt")]
        public string Zd002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "采购组")]
        public string Zd010Label { get; set; }
    }

}