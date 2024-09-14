namespace Ams.Model.Accounting
{
    /// <summary>
    /// 月度资产
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:54:31
    /// </summary>
    [SugarTable("fico_monthly_assets", "月度资产")]
    public class FicoMonthlyAssets : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "Mo002", ColumnDescription = "期间", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mo002 { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "Mo003", ColumnDescription = "年月", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mo003 { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "Mo004", ColumnDescription = "公司", Length = 255, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mo004 { get; set; }

        /// <summary>
        /// 使用部门
        /// </summary>
        [SugarColumn(ColumnName = "Mo005", ColumnDescription = "使用部门", Length = 255)]
        public string Mo005 { get; set; }

        /// <summary>
        /// 资产类别
        /// </summary>
        [SugarColumn(ColumnName = "Mo006", ColumnDescription = "资产类别", Length = 255)]
        public string Mo006 { get; set; }

        /// <summary>
        /// 资产编码
        /// </summary>
        [SugarColumn(ColumnName = "Mo007", ColumnDescription = "资产编码", Length = 255)]
        public string Mo007 { get; set; }

        /// <summary>
        /// 成本中心
        /// </summary>
        [SugarColumn(ColumnName = "Mo008", ColumnDescription = "成本中心", Length = 255)]
        public string Mo008 { get; set; }

        /// <summary>
        /// 资产简称
        /// </summary>
        [SugarColumn(ColumnName = "Mo009", ColumnDescription = "资产简称", Length = 255)]
        public string Mo009 { get; set; }

        /// <summary>
        /// 资产全称
        /// </summary>
        [SugarColumn(ColumnName = "Mo010", ColumnDescription = "资产全称", Length = 255)]
        public string Mo010 { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [SugarColumn(ColumnName = "Mo011", ColumnDescription = "单位", Length = 255)]
        public string Mo011 { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "Mo012", ColumnDescription = "数量", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mo012 { get; set; }

        /// <summary>
        /// 管理区分
        /// </summary>
        [SugarColumn(ColumnName = "Mo013", ColumnDescription = "管理区分", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mo013 { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "Mo014", ColumnDescription = "币种", Length = 3, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mo014 { get; set; }

        /// <summary>
        /// 购买价格
        /// </summary>
        [SugarColumn(ColumnName = "Mo015", ColumnDescription = "购买价格", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mo015 { get; set; }

        /// <summary>
        /// 资本化日期
        /// </summary>
        public DateTime? Mo016 { get; set; }

        /// <summary>
        /// 折旧价值
        /// </summary>
        [SugarColumn(ColumnName = "Mo017", ColumnDescription = "折旧价值", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mo017 { get; set; }

        /// <summary>
        /// 报废日期
        /// </summary>
        public DateTime? Mo018 { get; set; }

        /// <summary>
        /// 残值
        /// </summary>
        [SugarColumn(ColumnName = "Mo019", ColumnDescription = "残值", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mo019 { get; set; }

        /// <summary>
        /// 存放位置
        /// </summary>
        [SugarColumn(ColumnName = "Mo020", ColumnDescription = "存放位置", Length = 255)]
        public string Mo020 { get; set; }

        /// <summary>
        /// 使用年限
        /// </summary>
        [SugarColumn(ColumnName = "Mo021", ColumnDescription = "使用年限", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mo021 { get; set; }

        /// <summary>
        /// 是否停用
        /// </summary>
        [SugarColumn(ColumnName = "Mo022", ColumnDescription = "是否停用", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mo022 { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        [SugarColumn(ColumnName = "Mo023", ColumnDescription = "供应商", Length = 255)]
        public string Mo023 { get; set; }

        /// <summary>
        /// 制造商
        /// </summary>
        [SugarColumn(ColumnName = "Mo024", ColumnDescription = "制造商", Length = 255)]
        public string Mo024 { get; set; }

        /// <summary>
        /// 供应商物料
        /// </summary>
        [SugarColumn(ColumnName = "Mo025", ColumnDescription = "供应商物料", Length = 255)]
        public string Mo025 { get; set; }

        /// <summary>
        /// 制造商物料
        /// </summary>
        [SugarColumn(ColumnName = "Mo026", ColumnDescription = "制造商物料", Length = 255)]
        public string Mo026 { get; set; }

        /// <summary>
        /// 资产形态
        /// </summary>
        [SugarColumn(ColumnName = "Mo027", ColumnDescription = "资产形态", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mo027 { get; set; }

        /// <summary>
        /// 资产存在否
        /// </summary>
        [SugarColumn(ColumnName = "Mo028", ColumnDescription = "资产存在否", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mo028 { get; set; }

        /// <summary>
        /// 盘点人员
        /// </summary>
        [SugarColumn(ColumnName = "Mo029", ColumnDescription = "盘点人员", Length = 255)]
        public string Mo029 { get; set; }

        /// <summary>
        /// 周期盘点日期
        /// </summary>
        public DateTime? Mo030 { get; set; }
    }
}