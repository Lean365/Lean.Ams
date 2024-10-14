namespace Ams.Model.Logistics
{
    /// <summary>
    /// 销售凭证
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:47:09
    /// </summary>
    [SugarTable("sd_selling_invoice", "销售凭证")]
    public class SdSellingInvoice : SysBase
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
        [SugarColumn(ColumnName = "Mc002", ColumnDescription = "工厂", Length = 255, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc002 { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "Mc003", ColumnDescription = "期间", Length = 255, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc003 { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "Mc004", ColumnDescription = "年月", Length = 255, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc004 { get; set; }

        /// <summary>
        /// 销售凭证
        /// </summary>
        [SugarColumn(ColumnName = "Mc005", ColumnDescription = "销售凭证", Length = 255)]
        public string Mc005 { get; set; }

        /// <summary>
        /// 凭证明细
        /// </summary>
        [SugarColumn(ColumnName = "Mc006", ColumnDescription = "凭证明细", Length = 255)]
        public string Mc006 { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        [SugarColumn(ColumnName = "Mc007", ColumnDescription = "客户", Length = 255, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc007 { get; set; }

        /// <summary>
        /// 利润中心
        /// </summary>
        [SugarColumn(ColumnName = "Mc008", ColumnDescription = "利润中心", Length = 255, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc008 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Mc009", ColumnDescription = "物料", Length = 255, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mc009 { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [SugarColumn(ColumnName = "Mc010", ColumnDescription = "科目", Length = 255)]
        public string Mc010 { get; set; }

        /// <summary>
        /// 销售数量
        /// </summary>
        [SugarColumn(ColumnName = "Mc011", ColumnDescription = "销售数量", DefaultValue = "0", Length = 18, DecimalDigits = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc011 { get; set; }

        /// <summary>
        /// 销售单位
        /// </summary>
        [SugarColumn(ColumnName = "Mc012", ColumnDescription = "销售单位", Length = 255)]
        public string Mc012 { get; set; }

        /// <summary>
        /// 原币销售额
        /// </summary>
        [SugarColumn(ColumnName = "Mc013", ColumnDescription = "原币销售额", DefaultValue = "0", Length = 18, DecimalDigits = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc013 { get; set; }

        /// <summary>
        /// 原币币种
        /// </summary>
        [SugarColumn(ColumnName = "Mc014", ColumnDescription = "原币币种", Length = 255)]
        public string Mc014 { get; set; }

        /// <summary>
        /// 本币销售额
        /// </summary>
        [SugarColumn(ColumnName = "Mc015", ColumnDescription = "本币销售额", DefaultValue = "0", Length = 18, DecimalDigits = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc015 { get; set; }

        /// <summary>
        /// 本币币种
        /// </summary>
        [SugarColumn(ColumnName = "Mc016", ColumnDescription = "本币币种", Length = 255)]
        public string Mc016 { get; set; }

        /// <summary>
        /// 参考凭证
        /// </summary>
        [SugarColumn(ColumnName = "Mc017", ColumnDescription = "参考凭证", Length = 255)]
        public string Mc017 { get; set; }

        /// <summary>
        /// 参考明细
        /// </summary>
        [SugarColumn(ColumnName = "Mc018", ColumnDescription = "参考明细", Length = 255)]
        public string Mc018 { get; set; }

        /// <summary>
        /// 过账日期
        /// </summary>
        public DateTime? Mc019 { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        [SugarColumn(ColumnName = "Mc020", ColumnDescription = "用户", Length = 255)]
        public string Mc020 { get; set; }

        /// <summary>
        /// 输入日期
        /// </summary>
        public DateTime? Mc021 { get; set; }

        /// <summary>
        /// 输入时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc022", ColumnDescription = "输入时间", Length = 255)]
        public string Mc022 { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [SugarColumn(ColumnName = "Mc023", ColumnDescription = "来源", Length = 255)]
        public string Mc023 { get; set; }

        /// <summary>
        /// 产品组
        /// </summary>
        [SugarColumn(ColumnName = "Mc024", ColumnDescription = "产品组", Length = 255)]
        public string Mc024 { get; set; }

        /// <summary>
        /// 凭证类型
        /// </summary>
        [SugarColumn(ColumnName = "Mc025", ColumnDescription = "凭证类型", Length = 255)]
        public string Mc025 { get; set; }

        /// <summary>
        /// 凭证名称
        /// </summary>
        [SugarColumn(ColumnName = "Mc026", ColumnDescription = "凭证名称", Length = 255)]
        public string Mc026 { get; set; }
    }
}