namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 物料信息
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 14:13:37
    /// </summary>
    public class MmMarbQueryDto : PagerInfo
    {
        public string Werks { get; set; }
        public string Matnr { get; set; }
        public string Mbrsh { get; set; }
        public string Mtart { get; set; }
        public string Meins { get; set; }
        public string Matkl { get; set; }
        public string Ekgrp { get; set; }
        public string Beskz { get; set; }
        public string Sobsl { get; set; }
        public string Insmk { get; set; }
        public string Prctr { get; set; }
        public string Xchpf { get; set; }
        public string Bklas { get; set; }
        public string Waers { get; set; }
        public string Lgpro { get; set; }
        public string Lgfsb { get; set; }
        public string Lvorm { get; set; }
    }

    /// <summary>
    /// 物料信息
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 14:13:37
    /// </summary>
    public class MmMarbDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SfId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Werks { get; set; }

        [Required(ErrorMessage = "物料号不能为空")]
        [ExcelColumn(Name = "物料号")]
        [ExcelColumnName("物料号")]
        public string Matnr { get; set; }

        [Required(ErrorMessage = "行业领域不能为空")]
        [ExcelColumn(Name = "行业领域")]
        [ExcelColumnName("行业领域")]
        public string Mbrsh { get; set; }

        [Required(ErrorMessage = "物料类型不能为空")]
        [ExcelColumn(Name = "物料类型")]
        [ExcelColumnName("物料类型")]
        public string Mtart { get; set; }

        [ExcelColumn(Name = "物料描述（短文本）")]
        [ExcelColumnName("物料描述（短文本）")]
        public string Maktx { get; set; }

        [Required(ErrorMessage = "基本计量单位不能为空")]
        [ExcelColumn(Name = "基本计量单位")]
        [ExcelColumnName("基本计量单位")]
        public string Meins { get; set; }

        [ExcelColumn(Name = "产品层次")]
        [ExcelColumnName("产品层次")]
        public string Prdha { get; set; }

        [Required(ErrorMessage = "物料组不能为空")]
        [ExcelColumn(Name = "物料组")]
        [ExcelColumnName("物料组")]
        public string Matkl { get; set; }

        [Required(ErrorMessage = "采购组不能为空")]
        [ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string Ekgrp { get; set; }

        [Required(ErrorMessage = "采购类型不能为空")]
        [ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string Beskz { get; set; }

        [Required(ErrorMessage = "特殊采购类型不能为空")]
        [ExcelColumn(Name = "特殊采购类型")]
        [ExcelColumnName("特殊采购类型")]
        public string Sobsl { get; set; }

        [ExcelColumn(Name = "标识：散装物料")]
        [ExcelColumnName("标识：散装物料")]
        public string Schgt { get; set; }

        [ExcelColumn(Name = "最小批量")]
        [ExcelColumnName("最小批量")]
        public decimal Bstmi { get; set; }

        [ExcelColumn(Name = "基本计量单位")]
        [ExcelColumnName("基本计量单位")]
        public string Bstme { get; set; }

        [ExcelColumn(Name = "采购订单数量的舍入值")]
        [ExcelColumnName("采购订单数量的舍入值")]
        public decimal Bstrf { get; set; }

        [ExcelColumn(Name = "基本计量单位")]
        [ExcelColumnName("基本计量单位")]
        public string Kzwsm { get; set; }

        [ExcelColumn(Name = "计划的天数内交货")]
        [ExcelColumnName("计划的天数内交货")]
        public decimal Plifz { get; set; }

        [ExcelColumn(Name = "厂内生产时间")]
        [ExcelColumnName("厂内生产时间")]
        public decimal Dzeit { get; set; }

        [Required(ErrorMessage = "过帐到检验库存不能为空")]
        [ExcelColumn(Name = "过帐到检验库存")]
        [ExcelColumnName("过帐到检验库存")]
        public string Insmk { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        [ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string Prctr { get; set; }

        [ExcelColumn(Name = "差异码")]
        [ExcelColumnName("差异码")]
        public string Awsls { get; set; }

        [Required(ErrorMessage = "批次管理需求的标识不能为空")]
        [ExcelColumn(Name = "批次管理需求的标识")]
        [ExcelColumnName("批次管理需求的标识")]
        public string Xchpf { get; set; }

        [ExcelColumn(Name = "制造商零件编号")]
        [ExcelColumnName("制造商零件编号")]
        public string Mfrpn { get; set; }

        [ExcelColumn(Name = "制造商编号")]
        [ExcelColumnName("制造商编号")]
        public string Mfrnr { get; set; }

        [Required(ErrorMessage = "评估类不能为空")]
        [ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]
        public string Bklas { get; set; }

        [ExcelColumn(Name = "移动平均价格/周期单价")]
        [ExcelColumnName("移动平均价格/周期单价")]
        public decimal Verpr { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Waers { get; set; }

        [ExcelColumn(Name = "价格控制指示符")]
        [ExcelColumnName("价格控制指示符")]
        public string Vprsv { get; set; }

        [ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]
        public decimal Peinh { get; set; }

        [Required(ErrorMessage = "发货库存地点不能为空")]
        [ExcelColumn(Name = "发货库存地点")]
        [ExcelColumnName("发货库存地点")]
        public string Lgpro { get; set; }

        [Required(ErrorMessage = "外部采购的缺省仓储位置不能为空")]
        [ExcelColumn(Name = "外部采购的缺省仓储位置")]
        [ExcelColumnName("外部采购的缺省仓储位置")]
        public string Lgfsb { get; set; }

        [ExcelColumn(Name = "库存仓位")]
        [ExcelColumnName("库存仓位")]
        public string Lgpbe { get; set; }

        [ExcelColumn(Name = "总计已估计库存")]
        [ExcelColumnName("总计已估计库存")]
        public decimal Lbkum { get; set; }

        [Required(ErrorMessage = "在工厂级标记要删除的物料不能为空")]
        [ExcelColumn(Name = "在工厂级标记要删除的物料")]
        [ExcelColumnName("在工厂级标记要删除的物料")]
        public string Lvorm { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "工厂")]
        public string WerksLabel { get; set; }

        [ExcelColumn(Name = "行业领域")]
        public string MbrshLabel { get; set; }

        [ExcelColumn(Name = "物料类型")]
        public string MtartLabel { get; set; }

        [ExcelColumn(Name = "基本计量单位")]
        public string MeinsLabel { get; set; }

        [ExcelColumn(Name = "物料组")]
        public string MatklLabel { get; set; }

        [ExcelColumn(Name = "采购组")]
        public string EkgrpLabel { get; set; }

        [ExcelColumn(Name = "采购类型")]
        public string BeskzLabel { get; set; }

        [ExcelColumn(Name = "特殊采购类型")]
        public string SobslLabel { get; set; }

        [ExcelColumn(Name = "标识：散装物料")]
        public string SchgtLabel { get; set; }

        [ExcelColumn(Name = "利润中心")]
        public string PrctrLabel { get; set; }

        [ExcelColumn(Name = "评估类")]
        public string BklasLabel { get; set; }

        [ExcelColumn(Name = "币种")]
        public string WaersLabel { get; set; }

        [ExcelColumn(Name = "发货库存地点")]
        public string LgproLabel { get; set; }

        [ExcelColumn(Name = "在工厂级标记要删除的物料")]
        public string LvormLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 物料信息
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 14:13:37
    /// </summary>
    public class MmMarbImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SfId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Werks { get; set; }

        [Required(ErrorMessage = "物料号不能为空")]
        [ExcelColumn(Name = "物料号")]
        [ExcelColumnName("物料号")]
        public string Matnr { get; set; }

        [Required(ErrorMessage = "行业领域不能为空")]
        [ExcelColumn(Name = "行业领域")]
        [ExcelColumnName("行业领域")]
        public string Mbrsh { get; set; }

        [Required(ErrorMessage = "物料类型不能为空")]
        [ExcelColumn(Name = "物料类型")]
        [ExcelColumnName("物料类型")]
        public string Mtart { get; set; }

        [ExcelColumn(Name = "物料描述（短文本）")]
        [ExcelColumnName("物料描述（短文本）")]
        public string Maktx { get; set; }

        [Required(ErrorMessage = "基本计量单位不能为空")]
        [ExcelColumn(Name = "基本计量单位")]
        [ExcelColumnName("基本计量单位")]
        public string Meins { get; set; }

        [ExcelColumn(Name = "产品层次")]
        [ExcelColumnName("产品层次")]
        public string Prdha { get; set; }

        [Required(ErrorMessage = "物料组不能为空")]
        [ExcelColumn(Name = "物料组")]
        [ExcelColumnName("物料组")]
        public string Matkl { get; set; }

        [Required(ErrorMessage = "采购组不能为空")]
        [ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string Ekgrp { get; set; }

        [Required(ErrorMessage = "采购类型不能为空")]
        [ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string Beskz { get; set; }

        [Required(ErrorMessage = "特殊采购类型不能为空")]
        [ExcelColumn(Name = "特殊采购类型")]
        [ExcelColumnName("特殊采购类型")]
        public string Sobsl { get; set; }

        [ExcelColumn(Name = "标识：散装物料")]
        [ExcelColumnName("标识：散装物料")]
        public string Schgt { get; set; }

        [ExcelColumn(Name = "最小批量")]
        [ExcelColumnName("最小批量")]
        public decimal Bstmi { get; set; }

        [ExcelColumn(Name = "基本计量单位")]
        [ExcelColumnName("基本计量单位")]
        public string Bstme { get; set; }

        [ExcelColumn(Name = "采购订单数量的舍入值")]
        [ExcelColumnName("采购订单数量的舍入值")]
        public decimal Bstrf { get; set; }

        [ExcelColumn(Name = "基本计量单位")]
        [ExcelColumnName("基本计量单位")]
        public string Kzwsm { get; set; }

        [ExcelColumn(Name = "计划的天数内交货")]
        [ExcelColumnName("计划的天数内交货")]
        public decimal Plifz { get; set; }

        [ExcelColumn(Name = "厂内生产时间")]
        [ExcelColumnName("厂内生产时间")]
        public decimal Dzeit { get; set; }

        [Required(ErrorMessage = "过帐到检验库存不能为空")]
        [ExcelColumn(Name = "过帐到检验库存")]
        [ExcelColumnName("过帐到检验库存")]
        public string Insmk { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        [ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string Prctr { get; set; }

        [ExcelColumn(Name = "差异码")]
        [ExcelColumnName("差异码")]
        public string Awsls { get; set; }

        [Required(ErrorMessage = "批次管理需求的标识不能为空")]
        [ExcelColumn(Name = "批次管理需求的标识")]
        [ExcelColumnName("批次管理需求的标识")]
        public string Xchpf { get; set; }

        [ExcelColumn(Name = "制造商零件编号")]
        [ExcelColumnName("制造商零件编号")]
        public string Mfrpn { get; set; }

        [ExcelColumn(Name = "制造商编号")]
        [ExcelColumnName("制造商编号")]
        public string Mfrnr { get; set; }

        [Required(ErrorMessage = "评估类不能为空")]
        [ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]
        public string Bklas { get; set; }

        [ExcelColumn(Name = "移动平均价格/周期单价")]
        [ExcelColumnName("移动平均价格/周期单价")]
        public decimal Verpr { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Waers { get; set; }

        [ExcelColumn(Name = "价格控制指示符")]
        [ExcelColumnName("价格控制指示符")]
        public string Vprsv { get; set; }

        [ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]
        public decimal Peinh { get; set; }

        [Required(ErrorMessage = "发货库存地点不能为空")]
        [ExcelColumn(Name = "发货库存地点")]
        [ExcelColumnName("发货库存地点")]
        public string Lgpro { get; set; }

        [Required(ErrorMessage = "外部采购的缺省仓储位置不能为空")]
        [ExcelColumn(Name = "外部采购的缺省仓储位置")]
        [ExcelColumnName("外部采购的缺省仓储位置")]
        public string Lgfsb { get; set; }

        [ExcelColumn(Name = "库存仓位")]
        [ExcelColumnName("库存仓位")]
        public string Lgpbe { get; set; }

        [ExcelColumn(Name = "总计已估计库存")]
        [ExcelColumnName("总计已估计库存")]
        public decimal Lbkum { get; set; }

        [Required(ErrorMessage = "在工厂级标记要删除的物料不能为空")]
        [ExcelColumn(Name = "在工厂级标记要删除的物料")]
        [ExcelColumnName("在工厂级标记要删除的物料")]
        public string Lvorm { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string WerksLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "行业领域")]
        public string MbrshLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "物料类型")]
        public string MtartLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "基本计量单位")]
        public string MeinsLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "物料组")]
        public string MatklLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "采购组")]
        public string EkgrpLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "采购类型")]
        public string BeskzLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "特殊采购类型")]
        public string SobslLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "标识：散装物料")]
        public string SchgtLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "利润中心")]
        public string PrctrLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "评估类")]
        public string BklasLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string WaersLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "发货库存地点")]
        public string LgproLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "在工厂级标记要删除的物料")]
        public string LvormLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}