namespace Ams.Model.Logistics
{
    /// <summary>
    /// 供应商信息
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 11:22:58
    /// </summary>
    [SugarTable("mm_supplier", "供应商信息")]
    public class MmSupplier : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long SuSfId { get; set; }

        /// <summary>
        /// 购买组织
        /// </summary>
        [SugarColumn(ColumnName = "SuOrg", ColumnDescription = "购买组织 ", Length = 4)]
        public string SuOrg { get; set; }

        /// <summary>
        /// 行业类别
        /// </summary>
        [SugarColumn(ColumnName = "SuIndustryType", ColumnDescription = "行业类别 ", Length = 1)]
        public string SuIndustryType { get; set; }

        /// <summary>
        /// 企业性质
        /// </summary>
        [SugarColumn(ColumnName = "SuEnterpriseNature", ColumnDescription = "企业性质 ", Length = 1)]
        public string SuEnterpriseNature { get; set; }

        /// <summary>
        /// 供应商代码
        /// </summary>
        [SugarColumn(ColumnName = "SuCode", ColumnDescription = "供应商代码 ", Length = 10)]
        public string SuCode { get; set; }

        /// <summary>
        /// 供应商简称
        /// </summary>
        [SugarColumn(ColumnName = "SuAbbr", ColumnDescription = "供应商简称 ", Length = 20)]
        public string SuAbbr { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [SugarColumn(ColumnName = "SuName", ColumnDescription = "供应商名称 ", Length = 100)]
        public string SuName { get; set; }

        /// <summary>
        /// 企业法人
        /// </summary>
        [SugarColumn(ColumnName = "SuEbe", ColumnDescription = "企业法人 ", Length = 50)]
        public string SuEbe { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        [SugarColumn(ColumnName = "SuBusinessNo", ColumnDescription = "营业执照 ", Length = 100)]
        public string SuBusinessNo { get; set; }

        /// <summary>
        /// 税号
        /// </summary>
        [SugarColumn(ColumnName = "SuTaxNo", ColumnDescription = "税号 ", Length = 100)]
        public string SuTaxNo { get; set; }

        /// <summary>
        /// 税别
        /// </summary>
        [SugarColumn(ColumnName = "SuTaxType", ColumnDescription = "税别 ", Length = 2)]
        public string SuTaxType { get; set; }

        /// <summary>
        /// 主营业务
        /// </summary>
        [SugarColumn(ColumnName = "SuMainBusiness", ColumnDescription = "主营业务 ", Length = 200)]
        public string SuMainBusiness { get; set; }

        /// <summary>
        /// 交易币种
        /// </summary>
        [SugarColumn(ColumnName = "SuCcy", ColumnDescription = "交易币种 ", Length = 3)]
        public string SuCcy { get; set; }

        /// <summary>
        /// 付款条件
        /// </summary>
        [SugarColumn(ColumnName = "SuPayTerms", ColumnDescription = "付款条件 ", Length = 4)]
        public string SuPayTerms { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        [SugarColumn(ColumnName = "SuPayMethod", ColumnDescription = "付款方式 ", Length = 1)]
        public string SuPayMethod { get; set; }

        /// <summary>
        /// 统驭科目
        /// </summary>
        [SugarColumn(ColumnName = "SuRecAccount", ColumnDescription = "统驭科目 ", Length = 6)]
        public string SuRecAccount { get; set; }

        /// <summary>
        /// 贸易条件
        /// </summary>
        [SugarColumn(ColumnName = "SuTradeTerms", ColumnDescription = "贸易条件 ", Length = 3)]
        public string SuTradeTerms { get; set; }

        /// <summary>
        /// 装运条件
        /// </summary>
        [SugarColumn(ColumnName = "SuShippingTerms", ColumnDescription = "装运条件 ", Length = 3)]
        public string SuShippingTerms { get; set; }

        /// <summary>
        /// 供应商等级
        /// </summary>
        [SugarColumn(ColumnName = "SuSupplierGrade", ColumnDescription = "供应商等级 ", Length = 1)]
        public string SuSupplierGrade { get; set; }

        /// <summary>
        /// 供应商信用
        /// </summary>
        [SugarColumn(ColumnName = "SuSupplierCredit", ColumnDescription = "供应商信用 ", Length = 1)]
        public string SuSupplierCredit { get; set; }

        /// <summary>
        /// 首次交易
        /// </summary>
        public DateTime? SuFirstTransDate { get; set; }

        /// <summary>
        /// 末次交易
        /// </summary>
        public DateTime? SuLastTransDate { get; set; }

        /// <summary>
        /// 银行代码
        /// </summary>
        [SugarColumn(ColumnName = "SuBankCode", ColumnDescription = "银行代码 ", Length = 8)]
        public string SuBankCode { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        [SugarColumn(ColumnName = "SuBankName", ColumnDescription = "银行名称 ", Length = 255)]
        public string SuBankName { get; set; }

        /// <summary>
        /// 分行名称
        /// </summary>
        [SugarColumn(ColumnName = "SuBranchName", ColumnDescription = "分行名称 ", Length = 255)]
        public string SuBranchName { get; set; }

        /// <summary>
        /// 银行所在国
        /// </summary>
        [SugarColumn(ColumnName = "SuBankCountry", ColumnDescription = "银行所在国 ", Length = 2)]
        public string SuBankCountry { get; set; }

        /// <summary>
        /// 所在州省
        /// </summary>
        [SugarColumn(ColumnName = "SuBankState", ColumnDescription = "所在州省 ", Length = 40)]
        public string SuBankState { get; set; }

        /// <summary>
        /// 所在市
        /// </summary>
        [SugarColumn(ColumnName = "SuBankCity", ColumnDescription = "所在市 ", Length = 40)]
        public string SuBankCity { get; set; }

        /// <summary>
        /// 所在县
        /// </summary>
        [SugarColumn(ColumnName = "SuBankCounty", ColumnDescription = "所在县 ", Length = 40)]
        public string SuBankCounty { get; set; }

        /// <summary>
        /// 银行地址
        /// </summary>
        [SugarColumn(ColumnName = "SuBankAddr", ColumnDescription = "银行地址 ", Length = 400)]
        public string SuBankAddr { get; set; }

        /// <summary>
        /// 银行地址1
        /// </summary>
        [SugarColumn(ColumnName = "SuBankAddr1", ColumnDescription = "银行地址1 ", Length = 400)]
        public string SuBankAddr1 { get; set; }

        /// <summary>
        /// 银行地址2
        /// </summary>
        [SugarColumn(ColumnName = "SuBankAddr2", ColumnDescription = "银行地址2 ", Length = 400)]
        public string SuBankAddr2 { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        [SugarColumn(ColumnName = "SuBankAccount", ColumnDescription = "银行账号 ", Length = 3)]
        public string SuBankAccount { get; set; }

        /// <summary>
        /// SWIFT代码
        /// </summary>
        [SugarColumn(ColumnName = "SuBankSwiftNo", ColumnDescription = "SWIFT代码 ", Length = 3)]
        public string SuBankSwiftNo { get; set; }

        /// <summary>
        /// 国家地区
        /// </summary>
        [SugarColumn(ColumnName = "SuRegionCode", ColumnDescription = "国家地区 ", Length = 2)]
        public string SuRegionCode { get; set; }

        /// <summary>
        /// 州省
        /// </summary>
        [SugarColumn(ColumnName = "SuState", ColumnDescription = "州省 ", Length = 40)]
        public string SuState { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [SugarColumn(ColumnName = "SuCity", ColumnDescription = "市 ", Length = 40)]
        public string SuCity { get; set; }

        /// <summary>
        /// 县
        /// </summary>
        [SugarColumn(ColumnName = "SuCounty", ColumnDescription = "县 ", Length = 40)]
        public string SuCounty { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(ColumnName = "SuAddr", ColumnDescription = "地址 ", Length = 400)]
        public string SuAddr { get; set; }

        /// <summary>
        /// 地址1
        /// </summary>
        [SugarColumn(ColumnName = "SuAddr1", ColumnDescription = "地址1 ", Length = 400)]
        public string SuAddr1 { get; set; }

        /// <summary>
        /// 地址2
        /// </summary>
        [SugarColumn(ColumnName = "SuAddr2", ColumnDescription = "地址2 ", Length = 400)]
        public string SuAddr2 { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [SugarColumn(ColumnName = "SuContacts", ColumnDescription = "联系人 ", Length = 200)]
        public string SuContacts { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        [SugarColumn(ColumnName = "SuEmail", ColumnDescription = "邮件 ", Length = 50)]
        public string SuEmail { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [SugarColumn(ColumnName = "SuTelNo", ColumnDescription = "电话 ", Length = 160)]
        public string SuTelNo { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [SugarColumn(ColumnName = "SuFaxNp", ColumnDescription = "传真 ", Length = 160)]
        public string SuFaxNp { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [SugarColumn(ColumnName = "SuPhoneNo", ColumnDescription = "手机 ", Length = 160)]
        public string SuPhoneNo { get; set; }

        /// <summary>
        /// 冻结标志
        /// </summary>
        [SugarColumn(ColumnName = "IsFroze", ColumnDescription = "冻结标志 ", DefaultValue = "0")]
        public int IsFroze { get; set; }

        /// <summary>
        /// 营业执照附件
        /// </summary>
        [SugarColumn(ColumnName = "SuLicenseAnnex", ColumnDescription = "营业执照附件 ", Length = 255)]
        public string SuLicenseAnnex { get; set; }

        /// <summary>
        /// 其它附件
        /// </summary>
        [SugarColumn(ColumnName = "SuOtherAnnex", ColumnDescription = "其它附件 ", Length = 255)]
        public string SuOtherAnnex { get; set; }
    }
}