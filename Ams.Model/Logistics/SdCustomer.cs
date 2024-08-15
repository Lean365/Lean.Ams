namespace Ams.Model.Logistics
{
    /// <summary>
    /// 顾客信息
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 13:49:23
    /// </summary>
    [SugarTable("sd_customer", "顾客信息")]
    public class SdCustomer : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long ScSfId { get; set; }

        /// <summary>
        /// 销售组织
        /// </summary>
        [SugarColumn(ColumnName = "ScOrg", ColumnDescription = "销售组织 ", Length = 4)]
        public string ScOrg { get; set; }

        /// <summary>
        /// 行业类别
        /// </summary>
        [SugarColumn(ColumnName = "ScIndustryType", ColumnDescription = "行业类别 ", Length = 1)]
        public string ScIndustryType { get; set; }

        /// <summary>
        /// 企业性质
        /// </summary>
        [SugarColumn(ColumnName = "ScEnterpriseNature", ColumnDescription = "企业性质 ", Length = 1)]
        public string ScEnterpriseNature { get; set; }

        /// <summary>
        /// 客户代码
        /// </summary>
        [SugarColumn(ColumnName = "ScCode", ColumnDescription = "客户代码 ", Length = 10)]
        public string ScCode { get; set; }

        /// <summary>
        /// 客户简称
        /// </summary>
        [SugarColumn(ColumnName = "ScAbbr", ColumnDescription = "客户简称 ", Length = 20)]
        public string ScAbbr { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [SugarColumn(ColumnName = "ScName", ColumnDescription = "客户名称 ", Length = 100)]
        public string ScName { get; set; }

        /// <summary>
        /// 企业法人
        /// </summary>
        [SugarColumn(ColumnName = "ScEbe", ColumnDescription = "企业法人 ", Length = 50)]
        public string ScEbe { get; set; }

        /// <summary>
        /// 税号
        /// </summary>
        [SugarColumn(ColumnName = "ScTaxNo", ColumnDescription = "税号 ", Length = 100)]
        public string ScTaxNo { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        [SugarColumn(ColumnName = "ScBusinessNo", ColumnDescription = "营业执照 ", Length = 100)]
        public string ScBusinessNo { get; set; }

        /// <summary>
        /// 税别
        /// </summary>
        [SugarColumn(ColumnName = "ScTaxType", ColumnDescription = "税别 ", Length = 2)]
        public string ScTaxType { get; set; }

        /// <summary>
        /// 主营业务
        /// </summary>
        [SugarColumn(ColumnName = "ScMainBusiness", ColumnDescription = "主营业务 ", Length = 200)]
        public string ScMainBusiness { get; set; }

        /// <summary>
        /// 交易币种
        /// </summary>
        [SugarColumn(ColumnName = "ScCcy", ColumnDescription = "交易币种 ", Length = 3)]
        public string ScCcy { get; set; }

        /// <summary>
        /// 付款条件
        /// </summary>
        [SugarColumn(ColumnName = "ScPayTerms", ColumnDescription = "付款条件 ", Length = 4)]
        public string ScPayTerms { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        [SugarColumn(ColumnName = "ScPayMethod", ColumnDescription = "付款方式 ", Length = 1)]
        public string ScPayMethod { get; set; }

        /// <summary>
        /// 统驭科目
        /// </summary>
        [SugarColumn(ColumnName = "ScRecAccount", ColumnDescription = "统驭科目 ", Length = 6)]
        public string ScRecAccount { get; set; }

        /// <summary>
        /// 贸易条件
        /// </summary>
        [SugarColumn(ColumnName = "ScTradeTerms", ColumnDescription = "贸易条件 ", Length = 3)]
        public string ScTradeTerms { get; set; }

        /// <summary>
        /// 装运条件
        /// </summary>
        [SugarColumn(ColumnName = "ScShippingTerms", ColumnDescription = "装运条件 ", Length = 3)]
        public string ScShippingTerms { get; set; }

        /// <summary>
        /// 客户等级
        /// </summary>
        [SugarColumn(ColumnName = "ScCustomerGrade", ColumnDescription = "客户等级 ", Length = 4)]
        public string ScCustomerGrade { get; set; }

        /// <summary>
        /// 客户信用
        /// </summary>
        [SugarColumn(ColumnName = "ScCustomerCredit", ColumnDescription = "客户信用 ", Length = 4)]
        public string ScCustomerCredit { get; set; }

        /// <summary>
        /// 首次交易
        /// </summary>
        public DateTime? ScFirstTransDate { get; set; }

        /// <summary>
        /// 最近交易
        /// </summary>
        public DateTime? ScLastTransDate { get; set; }

        /// <summary>
        /// 银行代码
        /// </summary>
        [SugarColumn(ColumnName = "ScBankCode", ColumnDescription = "银行代码 ", Length = 8)]
        public string ScBankCode { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        [SugarColumn(ColumnName = "ScBankName", ColumnDescription = "银行名称 ", Length = 255)]
        public string ScBankName { get; set; }

        /// <summary>
        /// 分行名称
        /// </summary>
        [SugarColumn(ColumnName = "ScBranchName", ColumnDescription = "分行名称 ", Length = 255)]
        public string ScBranchName { get; set; }

        /// <summary>
        /// 银行所在国
        /// </summary>
        [SugarColumn(ColumnName = "ScBankCountry", ColumnDescription = "银行所在国 ", Length = 2)]
        public string ScBankCountry { get; set; }

        /// <summary>
        /// 银行所在州省
        /// </summary>
        [SugarColumn(ColumnName = "ScBankState", ColumnDescription = "银行所在州省 ", Length = 40)]
        public string ScBankState { get; set; }

        /// <summary>
        /// 银行所在市
        /// </summary>
        [SugarColumn(ColumnName = "ScBankCity", ColumnDescription = "银行所在市 ", Length = 40)]
        public string ScBankCity { get; set; }

        /// <summary>
        /// 银行所在县
        /// </summary>
        [SugarColumn(ColumnName = "ScBankCounty", ColumnDescription = "银行所在县 ", Length = 40)]
        public string ScBankCounty { get; set; }

        /// <summary>
        /// 银行地址
        /// </summary>
        [SugarColumn(ColumnName = "ScBankAddr", ColumnDescription = "银行地址 ", Length = 400)]
        public string ScBankAddr { get; set; }

        /// <summary>
        /// 银行地址1
        /// </summary>
        [SugarColumn(ColumnName = "ScBankAddr1", ColumnDescription = "银行地址1 ", Length = 400)]
        public string ScBankAddr1 { get; set; }

        /// <summary>
        /// 银行地址2
        /// </summary>
        [SugarColumn(ColumnName = "ScBankAddr2", ColumnDescription = "银行地址2 ", Length = 400)]
        public string ScBankAddr2 { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        [SugarColumn(ColumnName = "ScBankAccount", ColumnDescription = "银行账号 ", Length = 20)]
        public string ScBankAccount { get; set; }

        /// <summary>
        /// SWIFT代码
        /// </summary>
        [SugarColumn(ColumnName = "ScBankSwiftNo", ColumnDescription = "SWIFT代码 ", Length = 50)]
        public string ScBankSwiftNo { get; set; }

        /// <summary>
        /// 国家地区
        /// </summary>
        [SugarColumn(ColumnName = "ScRegionCode", ColumnDescription = "国家地区 ", Length = 2)]
        public string ScRegionCode { get; set; }

        /// <summary>
        /// 州省
        /// </summary>
        [SugarColumn(ColumnName = "ScState", ColumnDescription = "州省 ", Length = 40)]
        public string ScState { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [SugarColumn(ColumnName = "ScCity", ColumnDescription = "市 ", Length = 40)]
        public string ScCity { get; set; }

        /// <summary>
        /// 县
        /// </summary>
        [SugarColumn(ColumnName = "ScCounty", ColumnDescription = "县 ", Length = 40)]
        public string ScCounty { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(ColumnName = "ScAddr", ColumnDescription = "地址 ", Length = 400)]
        public string ScAddr { get; set; }

        /// <summary>
        /// 地址1
        /// </summary>
        [SugarColumn(ColumnName = "ScAddr1", ColumnDescription = "地址1 ", Length = 400)]
        public string ScAddr1 { get; set; }

        /// <summary>
        /// 地址2
        /// </summary>
        [SugarColumn(ColumnName = "ScAddr2", ColumnDescription = "地址2 ", Length = 400)]
        public string ScAddr2 { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [SugarColumn(ColumnName = "ScContacts", ColumnDescription = "联系人 ", Length = 200)]
        public string ScContacts { get; set; }

        /// <summary>
        /// 电邮
        /// </summary>
        [SugarColumn(ColumnName = "ScEmail", ColumnDescription = "电邮 ", Length = 50)]
        public string ScEmail { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [SugarColumn(ColumnName = "ScTelNo", ColumnDescription = "电话 ", Length = 160)]
        public string ScTelNo { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [SugarColumn(ColumnName = "ScFaxNp", ColumnDescription = "传真 ", Length = 160)]
        public string ScFaxNp { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [SugarColumn(ColumnName = "ScPhoneNo", ColumnDescription = "手机 ", Length = 160)]
        public string ScPhoneNo { get; set; }

        /// <summary>
        /// 冻结标记
        /// </summary>
        [SugarColumn(ColumnName = "IsFroze", ColumnDescription = "冻结标记 ", DefaultValue = "0")]
        public int IsFroze { get; set; }

        /// <summary>
        /// 营业执照附件
        /// </summary>
        [SugarColumn(ColumnName = "ScLicenseAnnex", ColumnDescription = "营业执照附件 ", Length = 255)]
        public string ScLicenseAnnex { get; set; }

        /// <summary>
        /// 其它附件
        /// </summary>
        [SugarColumn(ColumnName = "ScOtherAnnex", ColumnDescription = "其它附件 ", Length = 255)]
        public string ScOtherAnnex { get; set; }
    }
}