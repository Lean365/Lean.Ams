namespace Ams.Model.Logistics
{
    /// <summary>
    /// 源物料
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:36:27
    /// </summary>
    [SugarTable("pp_source_material", "源物料")]
    public class PpSourceMaterial : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// Plnt
        /// </summary>
        [SugarColumn(ColumnName = "Zd002", ColumnDescription = "Plnt", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Zd002 { get; set; }

        /// <summary>
        /// 品目
        /// </summary>
        [SugarColumn(ColumnName = "Zd003", ColumnDescription = "品目", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Zd003 { get; set; }

        /// <summary>
        /// 行业领域
        /// </summary>
        [SugarColumn(ColumnName = "Zd004", ColumnDescription = "行业领域", Length = 1)]
        public string Zd004 { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        [SugarColumn(ColumnName = "Zd005", ColumnDescription = "物料类型", Length = 4)]
        public string Zd005 { get; set; }

        /// <summary>
        /// 物料描述（短文本）
        /// </summary>
        [SugarColumn(ColumnName = "Zd006", ColumnDescription = "物料描述（短文本）", Length = 40)]
        public string Zd006 { get; set; }

        /// <summary>
        /// 基本单位
        /// </summary>
        [SugarColumn(ColumnName = "Zd007", ColumnDescription = "基本单位", Length = 4)]
        public string Zd007 { get; set; }

        /// <summary>
        /// 产品层次
        /// </summary>
        [SugarColumn(ColumnName = "Zd008", ColumnDescription = "产品层次", Length = 40)]
        public string Zd008 { get; set; }

        /// <summary>
        /// 物料组
        /// </summary>
        [SugarColumn(ColumnName = "Zd009", ColumnDescription = "物料组", Length = 10)]
        public string Zd009 { get; set; }

        /// <summary>
        /// 采购组
        /// </summary>
        [SugarColumn(ColumnName = "Zd010", ColumnDescription = "采购组", Length = 4)]
        public string Zd010 { get; set; }

        /// <summary>
        /// 采购类型
        /// </summary>
        [SugarColumn(ColumnName = "Zd011", ColumnDescription = "采购类型", Length = 1)]
        public string Zd011 { get; set; }

        /// <summary>
        /// 特殊采购类
        /// </summary>
        [SugarColumn(ColumnName = "Zd012", ColumnDescription = "特殊采购类", Length = 2)]
        public string Zd012 { get; set; }

        /// <summary>
        /// 散装物料
        /// </summary>
        [SugarColumn(ColumnName = "Zd013", ColumnDescription = "散装物料", Length = 1)]
        public string Zd013 { get; set; }

        /// <summary>
        /// 最小起订量
        /// </summary>
        [SugarColumn(ColumnName = "Zd014", ColumnDescription = "最小起订量", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Zd014 { get; set; }

        /// <summary>
        /// 基本单位
        /// </summary>
        [SugarColumn(ColumnName = "Zd015", ColumnDescription = "基本单位", Length = 4)]
        public string Zd015 { get; set; }

        /// <summary>
        /// 舍入值
        /// </summary>
        [SugarColumn(ColumnName = "Zd016", ColumnDescription = "舍入值", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Zd016 { get; set; }

        /// <summary>
        /// 基本单位
        /// </summary>
        [SugarColumn(ColumnName = "Zd017", ColumnDescription = "基本单位", Length = 4)]
        public string Zd017 { get; set; }

        /// <summary>
        /// 计划交货
        /// </summary>
        [SugarColumn(ColumnName = "Zd018", ColumnDescription = "计划交货", Length = 8)]
        public string Zd018 { get; set; }

        /// <summary>
        /// 自制天数
        /// </summary>
        [SugarColumn(ColumnName = "Zd019", ColumnDescription = "自制天数", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Zd019 { get; set; }

        /// <summary>
        /// 过账检验
        /// </summary>
        [SugarColumn(ColumnName = "Zd020", ColumnDescription = "过账检验", Length = 1)]
        public string Zd020 { get; set; }

        /// <summary>
        /// 利润中心
        /// </summary>
        [SugarColumn(ColumnName = "Zd021", ColumnDescription = "利润中心", Length = 5)]
        public string Zd021 { get; set; }

        /// <summary>
        /// 差异码
        /// </summary>
        [SugarColumn(ColumnName = "Zd022", ColumnDescription = "差异码", Length = 10)]
        public string Zd022 { get; set; }

        /// <summary>
        /// 批次管理
        /// </summary>
        [SugarColumn(ColumnName = "Zd023", ColumnDescription = "批次管理", Length = 1)]
        public string Zd023 { get; set; }

        /// <summary>
        /// 制造商零件编号
        /// </summary>
        [SugarColumn(ColumnName = "Zd024", ColumnDescription = "制造商零件编号", Length = 40)]
        public string Zd024 { get; set; }

        /// <summary>
        /// 制造商编号
        /// </summary>
        [SugarColumn(ColumnName = "Zd025", ColumnDescription = "制造商编号", Length = 40)]
        public string Zd025 { get; set; }

        /// <summary>
        /// 评估类
        /// </summary>
        [SugarColumn(ColumnName = "Zd026", ColumnDescription = "评估类", Length = 4)]
        public string Zd026 { get; set; }

        /// <summary>
        /// 移动平均价格/周期单价
        /// </summary>
        [SugarColumn(ColumnName = "Zd027", ColumnDescription = "移动平均价格/周期单价", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Zd027 { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "Zd028", ColumnDescription = "币种", Length = 4)]
        public string Zd028 { get; set; }

        /// <summary>
        /// 价格控制
        /// </summary>
        [SugarColumn(ColumnName = "Zd029", ColumnDescription = "价格控制", Length = 1)]
        public string Zd029 { get; set; }

        /// <summary>
        /// 价格单位
        /// </summary>
        [SugarColumn(ColumnName = "Zd030", ColumnDescription = "价格单位", Length = 4)]
        public string Zd030 { get; set; }

        /// <summary>
        /// 生产仓储
        /// </summary>
        [SugarColumn(ColumnName = "Zd031", ColumnDescription = "生产仓储", Length = 4)]
        public string Zd031 { get; set; }

        /// <summary>
        /// 采购仓储
        /// </summary>
        [SugarColumn(ColumnName = "Zd032", ColumnDescription = "采购仓储", Length = 4)]
        public string Zd032 { get; set; }

        /// <summary>
        /// 库存仓位
        /// </summary>
        [SugarColumn(ColumnName = "Zd033", ColumnDescription = "库存仓位", Length = 40)]
        public string Zd033 { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        [SugarColumn(ColumnName = "Zd034", ColumnDescription = "库存", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Zd034 { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnName = "Zd035", ColumnDescription = "状态", Length = 2)]
        public string Zd035 { get; set; }
    }
}