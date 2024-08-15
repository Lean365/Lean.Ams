namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 源物料
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:18:11
    /// </summary>
    public class PpSourceMaterialQueryDto : PagerInfo
    {
        public string Zcadz002 { get; set; }
        public string Zcadz003 { get; set; }
        public string Zcadz004 { get; set; }
        public string Zcadz005 { get; set; }
        public string Zcadz006 { get; set; }
        public string Zcadz008 { get; set; }
        public string Zcadz009 { get; set; }
        public string Zcadz010 { get; set; }
        public string Zcadz011 { get; set; }
        public string Zcadz019 { get; set; }
        public string Zcadz022 { get; set; }
        public string Zcadz025 { get; set; }
        public string Zcadz027 { get; set; }
        public string Zcadz030 { get; set; }
        public string Zcadz031 { get; set; }
        public string Zcadz032 { get; set; }
        public string Zcadz034 { get; set; }
    }

    /// <summary>
    /// 源物料
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:18:11
    /// </summary>
    public class PpSourceMaterialDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SfId { get; set; }

        [ExcelColumn(Name = "Plnt")]
        [ExcelColumnName("Plnt")]
        public string Zcadz001 { get; set; }

        [Required(ErrorMessage = "品目不能为空")]
        [ExcelColumn(Name = "品目")]
        [ExcelColumnName("品目")]
        public string Zcadz002 { get; set; }

        [ExcelColumn(Name = "行业领域")]
        [ExcelColumnName("行业领域")]
        public string Zcadz003 { get; set; }

        [ExcelColumn(Name = "物料类型")]
        [ExcelColumnName("物料类型")]
        public string Zcadz004 { get; set; }

        [ExcelColumn(Name = "物料描述（短文本）")]
        [ExcelColumnName("物料描述（短文本）")]
        public string Zcadz005 { get; set; }

        [ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]
        public string Zcadz006 { get; set; }

        [ExcelColumn(Name = "产品层次")]
        [ExcelColumnName("产品层次")]
        public string Zcadz007 { get; set; }

        [ExcelColumn(Name = "物料组")]
        [ExcelColumnName("物料组")]
        public string Zcadz008 { get; set; }

        [ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string Zcadz009 { get; set; }

        [ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string Zcadz010 { get; set; }

        [ExcelColumn(Name = "特殊采购类")]
        [ExcelColumnName("特殊采购类")]
        public string Zcadz011 { get; set; }

        [ExcelColumn(Name = "散装物料")]
        [ExcelColumnName("散装物料")]
        public string Zcadz012 { get; set; }

        [Required(ErrorMessage = "最小起订量不能为空")]
        [ExcelColumn(Name = "最小起订量")]
        [ExcelColumnName("最小起订量")]
        public int Zcadz013 { get; set; }

        [ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]
        public string Zcadz014 { get; set; }

        [Required(ErrorMessage = "舍入值不能为空")]
        [ExcelColumn(Name = "舍入值")]
        [ExcelColumnName("舍入值")]
        public int Zcadz015 { get; set; }

        [ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]
        public string Zcadz016 { get; set; }

        [ExcelColumn(Name = "计划交货")]
        [ExcelColumnName("计划交货")]
        public string Zcadz017 { get; set; }

        [Required(ErrorMessage = "自制天数不能为空")]
        [ExcelColumn(Name = "自制天数")]
        [ExcelColumnName("自制天数")]
        public decimal Zcadz018 { get; set; }

        [ExcelColumn(Name = "过账检验")]
        [ExcelColumnName("过账检验")]
        public string Zcadz019 { get; set; }

        [ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string Zcadz020 { get; set; }

        [ExcelColumn(Name = "差异码")]
        [ExcelColumnName("差异码")]
        public string Zcadz021 { get; set; }

        [ExcelColumn(Name = "批次管理")]
        [ExcelColumnName("批次管理")]
        public string Zcadz022 { get; set; }

        [ExcelColumn(Name = "制造商零件编号")]
        [ExcelColumnName("制造商零件编号")]
        public string Zcadz023 { get; set; }

        [ExcelColumn(Name = "制造商编号")]
        [ExcelColumnName("制造商编号")]
        public string Zcadz024 { get; set; }

        [ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]
        public string Zcadz025 { get; set; }

        [Required(ErrorMessage = "移动平均价格/周期单价不能为空")]
        [ExcelColumn(Name = "移动平均价格/周期单价")]
        [ExcelColumnName("移动平均价格/周期单价")]
        public decimal Zcadz026 { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Zcadz027 { get; set; }

        [ExcelColumn(Name = "价格控制")]
        [ExcelColumnName("价格控制")]
        public string Zcadz028 { get; set; }

        [ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]
        public string Zcadz029 { get; set; }

        [ExcelColumn(Name = "生产仓储")]
        [ExcelColumnName("生产仓储")]
        public string Zcadz030 { get; set; }

        [ExcelColumn(Name = "采购仓储")]
        [ExcelColumnName("采购仓储")]
        public string Zcadz031 { get; set; }

        [ExcelColumn(Name = "库存仓位")]
        [ExcelColumnName("库存仓位")]
        public string Zcadz032 { get; set; }

        [Required(ErrorMessage = "库存不能为空")]
        [ExcelColumn(Name = "库存")]
        [ExcelColumnName("库存")]
        public decimal Zcadz033 { get; set; }

        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public string Zcadz034 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "Plnt")]
        public string Zcadz001Label { get; set; }

        [ExcelColumn(Name = "行业领域")]
        public string Zcadz003Label { get; set; }

        [ExcelColumn(Name = "物料类型")]
        public string Zcadz004Label { get; set; }

        [ExcelColumn(Name = "基本单位")]
        public string Zcadz006Label { get; set; }

        [ExcelColumn(Name = "物料组")]
        public string Zcadz008Label { get; set; }

        [ExcelColumn(Name = "采购组")]
        public string Zcadz009Label { get; set; }

        [ExcelColumn(Name = "采购类型")]
        public string Zcadz010Label { get; set; }

        [ExcelColumn(Name = "特殊采购类")]
        public string Zcadz011Label { get; set; }

        [ExcelColumn(Name = "散装物料")]
        public string Zcadz012Label { get; set; }

        [ExcelColumn(Name = "评估类")]
        public string Zcadz025Label { get; set; }

        [ExcelColumn(Name = "币种")]
        public string Zcadz027Label { get; set; }

        [ExcelColumn(Name = "生产仓储")]
        public string Zcadz030Label { get; set; }

        [ExcelColumn(Name = "状态")]
        public string Zcadz034Label { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 源物料
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:18:11
    /// </summary>
    public class PpSourceMaterialImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SfId { get; set; }

        [ExcelColumn(Name = "Plnt")]
        [ExcelColumnName("Plnt")]
        public string Zcadz001 { get; set; }

        [Required(ErrorMessage = "品目不能为空")]
        [ExcelColumn(Name = "品目")]
        [ExcelColumnName("品目")]
        public string Zcadz002 { get; set; }

        [ExcelColumn(Name = "行业领域")]
        [ExcelColumnName("行业领域")]
        public string Zcadz003 { get; set; }

        [ExcelColumn(Name = "物料类型")]
        [ExcelColumnName("物料类型")]
        public string Zcadz004 { get; set; }

        [ExcelColumn(Name = "物料描述（短文本）")]
        [ExcelColumnName("物料描述（短文本）")]
        public string Zcadz005 { get; set; }

        [ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]
        public string Zcadz006 { get; set; }

        [ExcelColumn(Name = "产品层次")]
        [ExcelColumnName("产品层次")]
        public string Zcadz007 { get; set; }

        [ExcelColumn(Name = "物料组")]
        [ExcelColumnName("物料组")]
        public string Zcadz008 { get; set; }

        [ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string Zcadz009 { get; set; }

        [ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string Zcadz010 { get; set; }

        [ExcelColumn(Name = "特殊采购类")]
        [ExcelColumnName("特殊采购类")]
        public string Zcadz011 { get; set; }

        [ExcelColumn(Name = "散装物料")]
        [ExcelColumnName("散装物料")]
        public string Zcadz012 { get; set; }

        [Required(ErrorMessage = "最小起订量不能为空")]
        [ExcelColumn(Name = "最小起订量")]
        [ExcelColumnName("最小起订量")]
        public int Zcadz013 { get; set; }

        [ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]
        public string Zcadz014 { get; set; }

        [Required(ErrorMessage = "舍入值不能为空")]
        [ExcelColumn(Name = "舍入值")]
        [ExcelColumnName("舍入值")]
        public int Zcadz015 { get; set; }

        [ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]
        public string Zcadz016 { get; set; }

        [ExcelColumn(Name = "计划交货")]
        [ExcelColumnName("计划交货")]
        public string Zcadz017 { get; set; }

        [Required(ErrorMessage = "自制天数不能为空")]
        [ExcelColumn(Name = "自制天数")]
        [ExcelColumnName("自制天数")]
        public decimal Zcadz018 { get; set; }

        [ExcelColumn(Name = "过账检验")]
        [ExcelColumnName("过账检验")]
        public string Zcadz019 { get; set; }

        [ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string Zcadz020 { get; set; }

        [ExcelColumn(Name = "差异码")]
        [ExcelColumnName("差异码")]
        public string Zcadz021 { get; set; }

        [ExcelColumn(Name = "批次管理")]
        [ExcelColumnName("批次管理")]
        public string Zcadz022 { get; set; }

        [ExcelColumn(Name = "制造商零件编号")]
        [ExcelColumnName("制造商零件编号")]
        public string Zcadz023 { get; set; }

        [ExcelColumn(Name = "制造商编号")]
        [ExcelColumnName("制造商编号")]
        public string Zcadz024 { get; set; }

        [ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]
        public string Zcadz025 { get; set; }

        [Required(ErrorMessage = "移动平均价格/周期单价不能为空")]
        [ExcelColumn(Name = "移动平均价格/周期单价")]
        [ExcelColumnName("移动平均价格/周期单价")]
        public decimal Zcadz026 { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Zcadz027 { get; set; }

        [ExcelColumn(Name = "价格控制")]
        [ExcelColumnName("价格控制")]
        public string Zcadz028 { get; set; }

        [ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]
        public string Zcadz029 { get; set; }

        [ExcelColumn(Name = "生产仓储")]
        [ExcelColumnName("生产仓储")]
        public string Zcadz030 { get; set; }

        [ExcelColumn(Name = "采购仓储")]
        [ExcelColumnName("采购仓储")]
        public string Zcadz031 { get; set; }

        [ExcelColumn(Name = "库存仓位")]
        [ExcelColumnName("库存仓位")]
        public string Zcadz032 { get; set; }

        [Required(ErrorMessage = "库存不能为空")]
        [ExcelColumn(Name = "库存")]
        [ExcelColumnName("库存")]
        public decimal Zcadz033 { get; set; }

        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public string Zcadz034 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "Plnt")]
        public string Zcadz001Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "行业领域")]
        public string Zcadz003Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "物料类型")]
        public string Zcadz004Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "基本单位")]
        public string Zcadz006Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "物料组")]
        public string Zcadz008Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "采购组")]
        public string Zcadz009Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "采购类型")]
        public string Zcadz010Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "特殊采购类")]
        public string Zcadz011Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "散装物料")]
        public string Zcadz012Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "评估类")]
        public string Zcadz025Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string Zcadz027Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "生产仓储")]
        public string Zcadz030Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "状态")]
        public string Zcadz034Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}