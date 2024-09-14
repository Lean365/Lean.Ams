
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 物料信息
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:22:47
    /// </summary>
    public class MmMarbQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Mb002 { get; set; }
        /// <summary>
        /// 物料号 
        /// </summary>        
        public string Mb003 { get; set; }
        /// <summary>
        /// 行业领域 
        /// </summary>        
        public string Mb004 { get; set; }
        /// <summary>
        /// 物料类型 
        /// </summary>        
        public string Mb005 { get; set; }
        /// <summary>
        /// 物料描述 
        /// </summary>        
        public string Mb006 { get; set; }
        /// <summary>
        /// 基本单位 
        /// </summary>        
        public string Mb007 { get; set; }
        /// <summary>
        /// 物料组 
        /// </summary>        
        public string Mb009 { get; set; }
        /// <summary>
        /// 采购组 
        /// </summary>        
        public string Mb010 { get; set; }
        /// <summary>
        /// 采购 
        /// </summary>        
        public string Mb011 { get; set; }
        /// <summary>
        /// 特殊采购 
        /// </summary>        
        public string Mb012 { get; set; }
        /// <summary>
        /// 散装物料 
        /// </summary>        
        public string Mb013 { get; set; }
        /// <summary>
        /// 利润中心 
        /// </summary>        
        public string Mb021 { get; set; }
        /// <summary>
        /// 批次管理 
        /// </summary>        
        public string Mb023 { get; set; }
        /// <summary>
        /// 评估类 
        /// </summary>        
        public string Mb026 { get; set; }
        /// <summary>
        /// 币种 
        /// </summary>        
        public string Mb028 { get; set; }
        /// <summary>
        /// 发货库存地点 
        /// </summary>        
        public string Mb031 { get; set; }
        /// <summary>
        /// 工厂级删除标记 
        /// </summary>        
        public string Mb035 { get; set; }
    }

    /// <summary>
    /// 物料信息
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:22:47
    /// </summary>
    public class MmMarbDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Mb002 { get; set; }

        [Required(ErrorMessage = "物料号不能为空")]
        //[ExcelColumn(Name = "物料号")]
        [ExcelColumnName("物料号")]

        public string Mb003 { get; set; }

        [Required(ErrorMessage = "行业领域不能为空")]
        //[ExcelColumn(Name = "行业领域")]
        [ExcelColumnName("行业领域")]

        public string Mb004 { get; set; }

        [Required(ErrorMessage = "物料类型不能为空")]
        //[ExcelColumn(Name = "物料类型")]
        [ExcelColumnName("物料类型")]

        public string Mb005 { get; set; }

        //[ExcelColumn(Name = "物料描述")]
        [ExcelColumnName("物料描述")]

        public string Mb006 { get; set; }

        //[ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]

        public string Mb007 { get; set; }

        //[ExcelColumn(Name = "产品层次")]
        [ExcelColumnName("产品层次")]

        public string Mb008 { get; set; }

        //[ExcelColumn(Name = "物料组")]
        [ExcelColumnName("物料组")]

        public string Mb009 { get; set; }

        //[ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]

        public string Mb010 { get; set; }

        //[ExcelColumn(Name = "采购")]
        [ExcelColumnName("采购")]

        public string Mb011 { get; set; }

        //[ExcelColumn(Name = "特殊采购")]
        [ExcelColumnName("特殊采购")]

        public string Mb012 { get; set; }

        //[ExcelColumn(Name = "散装物料")]
        [ExcelColumnName("散装物料")]

        public string Mb013 { get; set; }

        //[ExcelColumn(Name = "最小批量")]
        [ExcelColumnName("最小批量")]

        public decimal Mb014 { get; set; }

        //[ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]

        public string Mb015 { get; set; }

        //[ExcelColumn(Name = "舍入值")]
        [ExcelColumnName("舍入值")]

        public decimal Mb016 { get; set; }

        //[ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]

        public string Mb017 { get; set; }

        //[ExcelColumn(Name = "计划交货天数")]
        [ExcelColumnName("计划交货天数")]

        public decimal Mb018 { get; set; }

        //[ExcelColumn(Name = "厂内生产时间")]
        [ExcelColumnName("厂内生产时间")]

        public decimal Mb019 { get; set; }

        //[ExcelColumn(Name = "过帐到检验库存")]
        [ExcelColumnName("过帐到检验库存")]

        public string Mb020 { get; set; }

        //[ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]

        public string Mb021 { get; set; }

        //[ExcelColumn(Name = "差异码")]
        [ExcelColumnName("差异码")]

        public string Mb022 { get; set; }

        //[ExcelColumn(Name = "批次管理")]
        [ExcelColumnName("批次管理")]

        public string Mb023 { get; set; }

        //[ExcelColumn(Name = "制造商零件编号")]
        [ExcelColumnName("制造商零件编号")]

        public string Mb024 { get; set; }

        //[ExcelColumn(Name = "制造商编号")]
        [ExcelColumnName("制造商编号")]

        public string Mb025 { get; set; }

        //[ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]

        public string Mb026 { get; set; }

        //[ExcelColumn(Name = "移动价格")]
        [ExcelColumnName("移动价格")]

        public decimal Mb027 { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]

        public string Mb028 { get; set; }

        //[ExcelColumn(Name = "价格控制")]
        [ExcelColumnName("价格控制")]

        public string Mb029 { get; set; }

        //[ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]

        public decimal Mb030 { get; set; }

        //[ExcelColumn(Name = "发货库存地点")]
        [ExcelColumnName("发货库存地点")]

        public string Mb031 { get; set; }

        //[ExcelColumn(Name = "外部采购仓储位置")]
        [ExcelColumnName("外部采购仓储位置")]

        public string Mb032 { get; set; }

        //[ExcelColumn(Name = "库存仓位")]
        [ExcelColumnName("库存仓位")]

        public string Mb033 { get; set; }

        //[ExcelColumn(Name = "总库存")]
        [ExcelColumnName("总库存")]

        public decimal Mb034 { get; set; }

        //[ExcelColumn(Name = "工厂级删除标记")]
        [ExcelColumnName("工厂级删除标记")]

        public string Mb035 { get; set; }

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



        [ExcelColumn(Name = "工厂")]
        public string Mb002Label { get; set; }
        [ExcelColumn(Name = "行业领域")]
        public string Mb004Label { get; set; }
        [ExcelColumn(Name = "物料类型")]
        public string Mb005Label { get; set; }
        [ExcelColumn(Name = "基本单位")]
        public string Mb007Label { get; set; }
        [ExcelColumn(Name = "物料组")]
        public string Mb009Label { get; set; }
        [ExcelColumn(Name = "采购组")]
        public string Mb010Label { get; set; }
        [ExcelColumn(Name = "采购")]
        public string Mb011Label { get; set; }
        [ExcelColumn(Name = "特殊采购")]
        public string Mb012Label { get; set; }
        [ExcelColumn(Name = "利润中心")]
        public string Mb021Label { get; set; }
        [ExcelColumn(Name = "评估类")]
        public string Mb026Label { get; set; }
        [ExcelColumn(Name = "币种")]
        public string Mb028Label { get; set; }
        [ExcelColumn(Name = "发货库存地点")]
        public string Mb031Label { get; set; }
        [ExcelColumn(Name = "库存仓位")]
        public string Mb033Label { get; set; }
        [ExcelColumn(Name = "工厂级删除标记")]
        public string Mb035Label { get; set; }
    }

    /// <summary>
    /// 物料信息
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:22:47
    /// </summary>
    public class MmMarbImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Mb002 { get; set; }

        [Required(ErrorMessage = "物料号不能为空")]
        //[ExcelColumn(Name = "物料号")]
        [ExcelColumnName("物料号")]
        public string Mb003 { get; set; }

        [Required(ErrorMessage = "行业领域不能为空")]
        //[ExcelColumn(Name = "行业领域")]
        [ExcelColumnName("行业领域")]
        public string Mb004 { get; set; }

        [Required(ErrorMessage = "物料类型不能为空")]
        //[ExcelColumn(Name = "物料类型")]
        [ExcelColumnName("物料类型")]
        public string Mb005 { get; set; }

        //[ExcelColumn(Name = "物料描述")]
        [ExcelColumnName("物料描述")]
        public string Mb006 { get; set; }

        //[ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]
        public string Mb007 { get; set; }

        //[ExcelColumn(Name = "产品层次")]
        [ExcelColumnName("产品层次")]
        public string Mb008 { get; set; }

        //[ExcelColumn(Name = "物料组")]
        [ExcelColumnName("物料组")]
        public string Mb009 { get; set; }

        //[ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string Mb010 { get; set; }

        //[ExcelColumn(Name = "采购")]
        [ExcelColumnName("采购")]
        public string Mb011 { get; set; }

        //[ExcelColumn(Name = "特殊采购")]
        [ExcelColumnName("特殊采购")]
        public string Mb012 { get; set; }

        //[ExcelColumn(Name = "散装物料")]
        [ExcelColumnName("散装物料")]
        public string Mb013 { get; set; }

        //[ExcelColumn(Name = "最小批量")]
        [ExcelColumnName("最小批量")]
        public decimal Mb014 { get; set; }

        //[ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]
        public string Mb015 { get; set; }

        //[ExcelColumn(Name = "舍入值")]
        [ExcelColumnName("舍入值")]
        public decimal Mb016 { get; set; }

        //[ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]
        public string Mb017 { get; set; }

        //[ExcelColumn(Name = "计划交货天数")]
        [ExcelColumnName("计划交货天数")]
        public decimal Mb018 { get; set; }

        //[ExcelColumn(Name = "厂内生产时间")]
        [ExcelColumnName("厂内生产时间")]
        public decimal Mb019 { get; set; }

        //[ExcelColumn(Name = "过帐到检验库存")]
        [ExcelColumnName("过帐到检验库存")]
        public string Mb020 { get; set; }

        //[ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string Mb021 { get; set; }

        //[ExcelColumn(Name = "差异码")]
        [ExcelColumnName("差异码")]
        public string Mb022 { get; set; }

        //[ExcelColumn(Name = "批次管理")]
        [ExcelColumnName("批次管理")]
        public string Mb023 { get; set; }

        //[ExcelColumn(Name = "制造商零件编号")]
        [ExcelColumnName("制造商零件编号")]
        public string Mb024 { get; set; }

        //[ExcelColumn(Name = "制造商编号")]
        [ExcelColumnName("制造商编号")]
        public string Mb025 { get; set; }

        //[ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]
        public string Mb026 { get; set; }

        //[ExcelColumn(Name = "移动价格")]
        [ExcelColumnName("移动价格")]
        public decimal Mb027 { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Mb028 { get; set; }

        //[ExcelColumn(Name = "价格控制")]
        [ExcelColumnName("价格控制")]
        public string Mb029 { get; set; }

        //[ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]
        public decimal Mb030 { get; set; }

        //[ExcelColumn(Name = "发货库存地点")]
        [ExcelColumnName("发货库存地点")]
        public string Mb031 { get; set; }

        //[ExcelColumn(Name = "外部采购仓储位置")]
        [ExcelColumnName("外部采购仓储位置")]
        public string Mb032 { get; set; }

        //[ExcelColumn(Name = "库存仓位")]
        [ExcelColumnName("库存仓位")]
        public string Mb033 { get; set; }

        //[ExcelColumn(Name = "总库存")]
        [ExcelColumnName("总库存")]
        public decimal Mb034 { get; set; }

        //[ExcelColumn(Name = "工厂级删除标记")]
        [ExcelColumnName("工厂级删除标记")]
        public string Mb035 { get; set; }

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
        [ExcelColumn(Name = "工厂")]
        public string Mb002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "行业领域")]
        public string Mb004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "物料类型")]
        public string Mb005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "基本单位")]
        public string Mb007Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "物料组")]
        public string Mb009Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "采购组")]
        public string Mb010Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "采购")]
        public string Mb011Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "特殊采购")]
        public string Mb012Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "利润中心")]
        public string Mb021Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "评估类")]
        public string Mb026Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string Mb028Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "发货库存地点")]
        public string Mb031Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "库存仓位")]
        public string Mb033Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "工厂级删除标记")]
        public string Mb035Label { get; set; }
    }

}