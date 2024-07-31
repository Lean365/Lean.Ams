namespace Ams.Model.Logistics
{
    /// <summary>
    /// 源物料
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:18:11
    /// </summary>
    [SugarTable("pp_source_material", "源物料")]
    public class PpSourceMaterial : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long SfId { get; set; }

        /// <summary>
        /// Plnt
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz001", ColumnDescription = "Plnt ", Length = 4)]
        public string Zcadz001 { get; set; }

        /// <summary>
        /// 品目
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz002", ColumnDescription = "品目 ", Length = 20)]
        public string Zcadz002 { get; set; }

        /// <summary>
        /// 行业领域
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz003", ColumnDescription = "行业领域 ", Length = 1)]
        public string Zcadz003 { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz004", ColumnDescription = "物料类型 ", Length = 4)]
        public string Zcadz004 { get; set; }

        /// <summary>
        /// 物料描述（短文本）
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz005", ColumnDescription = "物料描述（短文本） ", Length = 40)]
        public string Zcadz005 { get; set; }

        /// <summary>
        /// 基本单位
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz006", ColumnDescription = "基本单位 ", Length = 4)]
        public string Zcadz006 { get; set; }

        /// <summary>
        /// 产品层次
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz007", ColumnDescription = "产品层次 ", Length = 40)]
        public string Zcadz007 { get; set; }

        /// <summary>
        /// 物料组
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz008", ColumnDescription = "物料组 ", Length = 10)]
        public string Zcadz008 { get; set; }

        /// <summary>
        /// 采购组
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz009", ColumnDescription = "采购组 ", Length = 4)]
        public string Zcadz009 { get; set; }

        /// <summary>
        /// 采购类型
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz010", ColumnDescription = "采购类型 ", Length = 1)]
        public string Zcadz010 { get; set; }

        /// <summary>
        /// 特殊采购类
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz011", ColumnDescription = "特殊采购类 ", Length = 2)]
        public string Zcadz011 { get; set; }

        /// <summary>
        /// 散装物料
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz012", ColumnDescription = "散装物料 ", Length = 1)]
        public string Zcadz012 { get; set; }

        /// <summary>
        /// 最小起订量
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz013", ColumnDescription = "最小起订量 ", DefaultValue = "0")]
        public int Zcadz013 { get; set; }

        /// <summary>
        /// 基本单位
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz014", ColumnDescription = "基本单位 ", Length = 4)]
        public string Zcadz014 { get; set; }

        /// <summary>
        /// 舍入值
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz015", ColumnDescription = "舍入值 ", DefaultValue = "0")]
        public int Zcadz015 { get; set; }

        /// <summary>
        /// 基本单位
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz016", ColumnDescription = "基本单位 ", Length = 4)]
        public string Zcadz016 { get; set; }

        /// <summary>
        /// 计划交货
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz017", ColumnDescription = "计划交货 ", Length = 8)]
        public string Zcadz017 { get; set; }

        /// <summary>
        /// 自制天数
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz018", ColumnDescription = "自制天数 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Zcadz018 { get; set; }

        /// <summary>
        /// 过账检验
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz019", ColumnDescription = "过账检验 ", Length = 1)]
        public string Zcadz019 { get; set; }

        /// <summary>
        /// 利润中心
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz020", ColumnDescription = "利润中心 ", Length = 5)]
        public string Zcadz020 { get; set; }

        /// <summary>
        /// 差异码
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz021", ColumnDescription = "差异码 ", Length = 10)]
        public string Zcadz021 { get; set; }

        /// <summary>
        /// 批次管理
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz022", ColumnDescription = "批次管理 ", Length = 1)]
        public string Zcadz022 { get; set; }

        /// <summary>
        /// 制造商零件编号
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz023", ColumnDescription = "制造商零件编号 ", Length = 40)]
        public string Zcadz023 { get; set; }

        /// <summary>
        /// 制造商编号
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz024", ColumnDescription = "制造商编号 ", Length = 40)]
        public string Zcadz024 { get; set; }

        /// <summary>
        /// 评估类
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz025", ColumnDescription = "评估类 ", Length = 4)]
        public string Zcadz025 { get; set; }

        /// <summary>
        /// 移动平均价格/周期单价
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz026", ColumnDescription = "移动平均价格/周期单价 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Zcadz026 { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz027", ColumnDescription = "币种 ", Length = 4)]
        public string Zcadz027 { get; set; }

        /// <summary>
        /// 价格控制
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz028", ColumnDescription = "价格控制 ", Length = 1)]
        public string Zcadz028 { get; set; }

        /// <summary>
        /// 价格单位
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz029", ColumnDescription = "价格单位 ", Length = 4)]
        public string Zcadz029 { get; set; }

        /// <summary>
        /// 生产仓储
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz030", ColumnDescription = "生产仓储 ", Length = 4)]
        public string Zcadz030 { get; set; }

        /// <summary>
        /// 采购仓储
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz031", ColumnDescription = "采购仓储 ", Length = 4)]
        public string Zcadz031 { get; set; }

        /// <summary>
        /// 库存仓位
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz032", ColumnDescription = "库存仓位 ", Length = 40)]
        public string Zcadz032 { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz033", ColumnDescription = "库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Zcadz033 { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnName = "Zcadz034", ColumnDescription = "状态 ", Length = 2)]
        public string Zcadz034 { get; set; }
    }
}