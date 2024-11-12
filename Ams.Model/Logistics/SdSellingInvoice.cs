namespace Ams.Model.Logistics
{
    /// <summary>
    /// 销售凭证
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/7 16:16:45
    /// </summary>
    [SugarTable("sd_selling_invoice", "销售凭证")]
    public class SdSellingInvoice : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? Id { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Mc002", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc002 { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "Mc003", ColumnDescription = "期间", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc003 { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "Mc004", ColumnDescription = "年月", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc004 { get; set; }

        /// <summary>
        /// 销售凭证
        /// </summary>
        [SugarColumn(ColumnName = "Mc005", ColumnDescription = "销售凭证", Length = 9, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc005 { get; set; }

        /// <summary>
        /// 凭证明细
        /// </summary>
        [SugarColumn(ColumnName = "Mc006", ColumnDescription = "凭证明细", Length = 3, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc006 { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        [SugarColumn(ColumnName = "Mc007", ColumnDescription = "客户", Length = 10, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc007 { get; set; }

        /// <summary>
        /// 机种名称
        /// </summary>
        [SugarColumn(ColumnName = "Mc008", ColumnDescription = "机种名称", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc008 { get; set; }

        /// <summary>
        /// 利润中心
        /// </summary>
        [SugarColumn(ColumnName = "Mc009", ColumnDescription = "利润中心", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc009 { get; set; }

        /// <summary>
        /// 销售物料
        /// </summary>
        [SugarColumn(ColumnName = "Mc010", ColumnDescription = "销售物料", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc010 { get; set; }

        /// <summary>
        /// 科目代码
        /// </summary>
        [SugarColumn(ColumnName = "Mc011", ColumnDescription = "科目代码", Length = 8, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc011 { get; set; }

        /// <summary>
        /// 销售数量
        /// </summary>
        [SugarColumn(ColumnName = "Mc012", ColumnDescription = "销售数量", DefaultValue = "0", Length = 18, DecimalDigits = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc012 { get; set; }

        /// <summary>
        /// 销售单位
        /// </summary>
        [SugarColumn(ColumnName = "Mc013", ColumnDescription = "销售单位", Length = 3, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc013 { get; set; }

        /// <summary>
        /// 原币销售额
        /// </summary>
        [SugarColumn(ColumnName = "Mc014", ColumnDescription = "原币销售额", DefaultValue = "0", Length = 18, DecimalDigits = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc014 { get; set; }

        /// <summary>
        /// 原币币种
        /// </summary>
        [SugarColumn(ColumnName = "Mc015", ColumnDescription = "原币币种", Length = 3, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc015 { get; set; }

        /// <summary>
        /// 本币销售额
        /// </summary>
        [SugarColumn(ColumnName = "Mc016", ColumnDescription = "本币销售额", DefaultValue = "0", Length = 18, DecimalDigits = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc016 { get; set; }

        /// <summary>
        /// 本币币种
        /// </summary>
        [SugarColumn(ColumnName = "Mc017", ColumnDescription = "本币币种", Length = 3, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc017 { get; set; }

        /// <summary>
        /// 参考凭证
        /// </summary>
        [SugarColumn(ColumnName = "Mc018", ColumnDescription = "参考凭证", Length = 10, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc018 { get; set; }

        /// <summary>
        /// 参考明细
        /// </summary>
        [SugarColumn(ColumnName = "Mc019", ColumnDescription = "参考明细", Length = 3, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc019 { get; set; }

        /// <summary>
        /// 过账日期
        /// </summary>
        public DateTime? Mc020 { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        [SugarColumn(ColumnName = "Mc021", ColumnDescription = "用户", Length = 10)]
        public string Mc021 { get; set; }

        /// <summary>
        /// 输入日期
        /// </summary>
        public DateTime? Mc022 { get; set; }

        /// <summary>
        /// 输入时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc023", ColumnDescription = "输入时间", Length = 16)]
        public string Mc023 { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [SugarColumn(ColumnName = "Mc024", ColumnDescription = "来源", Length = 2)]
        public string Mc024 { get; set; }

        /// <summary>
        /// 产品组
        /// </summary>
        [SugarColumn(ColumnName = "Mc025", ColumnDescription = "产品组", Length = 2)]
        public string Mc025 { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        [SugarColumn(ColumnName = "Mc026", ColumnDescription = "物料类型", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc026 { get; set; }

        /// <summary>
        /// 凭证类型
        /// </summary>
        [SugarColumn(ColumnName = "Mc027", ColumnDescription = "凭证类型", Length = 2)]
        public string Mc027 { get; set; }

        /// <summary>
        /// 凭证名称
        /// </summary>
        [SugarColumn(ColumnName = "Mc028", ColumnDescription = "凭证名称", Length = 10)]
        public string Mc028 { get; set; }
    }
}