namespace Ams.Model.Logistics
{
    /// <summary>
    /// 物料信息
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:22:47
    /// </summary>
    [SugarTable("mm_marb", "物料信息")]
    public class MmMarb : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Mb002", ColumnDescription = "工厂", Length = 8, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb002 { get; set; }

        /// <summary>
        /// 物料号
        /// </summary>
        [SugarColumn(ColumnName = "Mb003", ColumnDescription = "物料号", Length = 36, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb003 { get; set; }

        /// <summary>
        /// 行业领域
        /// </summary>
        [SugarColumn(ColumnName = "Mb004", ColumnDescription = "行业领域", Length = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb004 { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        [SugarColumn(ColumnName = "Mb005", ColumnDescription = "物料类型", Length = 8, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb005 { get; set; }

        /// <summary>
        /// 物料描述
        /// </summary>
        [SugarColumn(ColumnName = "Mb006", ColumnDescription = "物料描述", Length = 40)]
        public string Mb006 { get; set; }

        /// <summary>
        /// 基本单位
        /// </summary>
        [SugarColumn(ColumnName = "Mb007", ColumnDescription = "基本单位", Length = 6)]
        public string Mb007 { get; set; }

        /// <summary>
        /// 产品层次
        /// </summary>
        [SugarColumn(ColumnName = "Mb008", ColumnDescription = "产品层次", Length = 36)]
        public string Mb008 { get; set; }

        /// <summary>
        /// 物料组
        /// </summary>
        [SugarColumn(ColumnName = "Mb009", ColumnDescription = "物料组", Length = 18)]
        public string Mb009 { get; set; }

        /// <summary>
        /// 采购组
        /// </summary>
        [SugarColumn(ColumnName = "Mb010", ColumnDescription = "采购组", Length = 6)]
        public string Mb010 { get; set; }

        /// <summary>
        /// 采购
        /// </summary>
        [SugarColumn(ColumnName = "Mb011", ColumnDescription = "采购", Length = 2)]
        public string Mb011 { get; set; }

        /// <summary>
        /// 特殊采购
        /// </summary>
        [SugarColumn(ColumnName = "Mb012", ColumnDescription = "特殊采购", Length = 4)]
        public string Mb012 { get; set; }

        /// <summary>
        /// 散装物料
        /// </summary>
        [SugarColumn(ColumnName = "Mb013", ColumnDescription = "散装物料", Length = 2)]
        public string Mb013 { get; set; }

        /// <summary>
        /// 最小批量
        /// </summary>
        [SugarColumn(ColumnName = "Mb014", ColumnDescription = "最小批量", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mb014 { get; set; }

        /// <summary>
        /// 基本单位
        /// </summary>
        [SugarColumn(ColumnName = "Mb015", ColumnDescription = "基本单位", Length = 6)]
        public string Mb015 { get; set; }

        /// <summary>
        /// 舍入值
        /// </summary>
        [SugarColumn(ColumnName = "Mb016", ColumnDescription = "舍入值", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mb016 { get; set; }

        /// <summary>
        /// 基本单位
        /// </summary>
        [SugarColumn(ColumnName = "Mb017", ColumnDescription = "基本单位", Length = 6)]
        public string Mb017 { get; set; }

        /// <summary>
        /// 计划交货天数
        /// </summary>
        [SugarColumn(ColumnName = "Mb018", ColumnDescription = "计划交货天数", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mb018 { get; set; }

        /// <summary>
        /// 厂内生产时间
        /// </summary>
        [SugarColumn(ColumnName = "Mb019", ColumnDescription = "厂内生产时间", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mb019 { get; set; }

        /// <summary>
        /// 过帐到检验库存
        /// </summary>
        [SugarColumn(ColumnName = "Mb020", ColumnDescription = "过帐到检验库存", Length = 2)]
        public string Mb020 { get; set; }

        /// <summary>
        /// 利润中心
        /// </summary>
        [SugarColumn(ColumnName = "Mb021", ColumnDescription = "利润中心", Length = 20)]
        public string Mb021 { get; set; }

        /// <summary>
        /// 差异码
        /// </summary>
        [SugarColumn(ColumnName = "Mb022", ColumnDescription = "差异码", Length = 12)]
        public string Mb022 { get; set; }

        /// <summary>
        /// 批次管理
        /// </summary>
        [SugarColumn(ColumnName = "Mb023", ColumnDescription = "批次管理", Length = 2)]
        public string Mb023 { get; set; }

        /// <summary>
        /// 制造商零件编号
        /// </summary>
        [SugarColumn(ColumnName = "Mb024", ColumnDescription = "制造商零件编号", Length = 80)]
        public string Mb024 { get; set; }

        /// <summary>
        /// 制造商编号
        /// </summary>
        [SugarColumn(ColumnName = "Mb025", ColumnDescription = "制造商编号", Length = 20)]
        public string Mb025 { get; set; }

        /// <summary>
        /// 评估类
        /// </summary>
        [SugarColumn(ColumnName = "Mb026", ColumnDescription = "评估类", Length = 4)]
        public string Mb026 { get; set; }

        /// <summary>
        /// 移动价格
        /// </summary>
        [SugarColumn(ColumnName = "Mb027", ColumnDescription = "移动价格", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mb027 { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "Mb028", ColumnDescription = "币种", Length = 3, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb028 { get; set; }

        /// <summary>
        /// 价格控制
        /// </summary>
        [SugarColumn(ColumnName = "Mb029", ColumnDescription = "价格控制", Length = 1)]
        public string Mb029 { get; set; }

        /// <summary>
        /// 价格单位
        /// </summary>
        [SugarColumn(ColumnName = "Mb030", ColumnDescription = "价格单位", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mb030 { get; set; }

        /// <summary>
        /// 发货库存地点
        /// </summary>
        [SugarColumn(ColumnName = "Mb031", ColumnDescription = "发货库存地点", Length = 8)]
        public string Mb031 { get; set; }

        /// <summary>
        /// 外部采购仓储位置
        /// </summary>
        [SugarColumn(ColumnName = "Mb032", ColumnDescription = "外部采购仓储位置", Length = 8)]
        public string Mb032 { get; set; }

        /// <summary>
        /// 库存仓位
        /// </summary>
        [SugarColumn(ColumnName = "Mb033", ColumnDescription = "库存仓位", Length = 40)]
        public string Mb033 { get; set; }

        /// <summary>
        /// 总库存
        /// </summary>
        [SugarColumn(ColumnName = "Mb034", ColumnDescription = "总库存", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mb034 { get; set; }

        /// <summary>
        /// 工厂级删除标记
        /// </summary>
        [SugarColumn(ColumnName = "Mb035", ColumnDescription = "工厂级删除标记", Length = 2)]
        public string Mb035 { get; set; }
    }
}