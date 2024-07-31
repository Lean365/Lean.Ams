namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 客户信息
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 14:26:41
    /// </summary>
    public class SdClientQueryDto : PagerInfo
    {
        public string ScOrg { get; set; }
        public string ScIndustryType { get; set; }
        public string ScEnterpriseNature { get; set; }
        public string ScCode { get; set; }
        public string ScAbbr { get; set; }
        public string ScName { get; set; }
        public string ScTaxType { get; set; }
        public string ScCcy { get; set; }
        public string ScPayTerms { get; set; }
        public string ScPayMethod { get; set; }
        public string ScRecAccount { get; set; }
        public string ScTradeTerms { get; set; }
        public string ScShippingTerms { get; set; }
        public string ScCustomerGrade { get; set; }
        public string ScCustomerCredit { get; set; }
        public int? IsFroze { get; set; }
    }

    /// <summary>
    /// 客户信息
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 14:26:41
    /// </summary>
    public class SdClientDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long ScSfId { get; set; }

        [Required(ErrorMessage = "销售组织不能为空")]
        [ExcelColumn(Name = "销售组织")]
        [ExcelColumnName("销售组织")]
        public string ScOrg { get; set; }

        [Required(ErrorMessage = "行业类别不能为空")]
        [ExcelColumn(Name = "行业类别")]
        [ExcelColumnName("行业类别")]
        public string ScIndustryType { get; set; }

        [Required(ErrorMessage = "企业性质不能为空")]
        [ExcelColumn(Name = "企业性质")]
        [ExcelColumnName("企业性质")]
        public string ScEnterpriseNature { get; set; }

        [Required(ErrorMessage = "客户代码不能为空")]
        [ExcelColumn(Name = "客户代码")]
        [ExcelColumnName("客户代码")]
        public string ScCode { get; set; }

        [Required(ErrorMessage = "客户简称不能为空")]
        [ExcelColumn(Name = "客户简称")]
        [ExcelColumnName("客户简称")]
        public string ScAbbr { get; set; }

        [Required(ErrorMessage = "客户名称不能为空")]
        [ExcelColumn(Name = "客户名称")]
        [ExcelColumnName("客户名称")]
        public string ScName { get; set; }

        [Required(ErrorMessage = "企业法人不能为空")]
        [ExcelColumn(Name = "企业法人")]
        [ExcelColumnName("企业法人")]
        public string ScEbe { get; set; }

        [Required(ErrorMessage = "营业执照不能为空")]
        [ExcelColumn(Name = "营业执照")]
        [ExcelColumnName("营业执照")]
        public string ScBusinessNo { get; set; }

        [Required(ErrorMessage = "税号不能为空")]
        [ExcelColumn(Name = "税号")]
        [ExcelColumnName("税号")]
        public string ScTaxNo { get; set; }

        [Required(ErrorMessage = "税别不能为空")]
        [ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]
        public string ScTaxType { get; set; }

        [Required(ErrorMessage = "主营业务不能为空")]
        [ExcelColumn(Name = "主营业务")]
        [ExcelColumnName("主营业务")]
        public string ScMainBusiness { get; set; }

        [Required(ErrorMessage = "交易币种不能为空")]
        [ExcelColumn(Name = "交易币种")]
        [ExcelColumnName("交易币种")]
        public string ScCcy { get; set; }

        [Required(ErrorMessage = "付款条件不能为空")]
        [ExcelColumn(Name = "付款条件")]
        [ExcelColumnName("付款条件")]
        public string ScPayTerms { get; set; }

        [Required(ErrorMessage = "付款方式不能为空")]
        [ExcelColumn(Name = "付款方式")]
        [ExcelColumnName("付款方式")]
        public string ScPayMethod { get; set; }

        [Required(ErrorMessage = "统驭科目不能为空")]
        [ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]
        public string ScRecAccount { get; set; }

        [Required(ErrorMessage = "贸易条件不能为空")]
        [ExcelColumn(Name = "贸易条件")]
        [ExcelColumnName("贸易条件")]
        public string ScTradeTerms { get; set; }

        [Required(ErrorMessage = "装运条件不能为空")]
        [ExcelColumn(Name = "装运条件")]
        [ExcelColumnName("装运条件")]
        public string ScShippingTerms { get; set; }

        [ExcelColumn(Name = "客户等级")]
        [ExcelColumnName("客户等级")]
        public string ScCustomerGrade { get; set; }

        [ExcelColumn(Name = "客户信用")]
        [ExcelColumnName("客户信用")]
        public string ScCustomerCredit { get; set; }

        [ExcelColumn(Name = "首次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("首次交易")]
        public DateTime? ScFirstTransDate { get; set; }

        [ExcelColumn(Name = "最近交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("最近交易")]
        public DateTime? ScLastTransDate { get; set; }

        [Required(ErrorMessage = "银行代码不能为空")]
        [ExcelColumn(Name = "银行代码")]
        [ExcelColumnName("银行代码")]
        public string ScBankCode { get; set; }

        [Required(ErrorMessage = "银行名称不能为空")]
        [ExcelColumn(Name = "银行名称")]
        [ExcelColumnName("银行名称")]
        public string ScBankName { get; set; }

        [ExcelColumn(Name = "分行名称")]
        [ExcelColumnName("分行名称")]
        public string ScBranchName { get; set; }

        [Required(ErrorMessage = "银行所在国不能为空")]
        [ExcelColumn(Name = "银行所在国")]
        [ExcelColumnName("银行所在国")]
        public string ScBankCountry { get; set; }

        [Required(ErrorMessage = "银行所在州省不能为空")]
        [ExcelColumn(Name = "银行所在州省")]
        [ExcelColumnName("银行所在州省")]
        public string ScBankState { get; set; }

        [Required(ErrorMessage = "银行所在市不能为空")]
        [ExcelColumn(Name = "银行所在市")]
        [ExcelColumnName("银行所在市")]
        public string ScBankCity { get; set; }

        [Required(ErrorMessage = "银行所在县不能为空")]
        [ExcelColumn(Name = "银行所在县")]
        [ExcelColumnName("银行所在县")]
        public string ScBankCounty { get; set; }

        [Required(ErrorMessage = "银行地址不能为空")]
        [ExcelColumn(Name = "银行地址")]
        [ExcelColumnName("银行地址")]
        public string ScBankAddr { get; set; }

        [ExcelColumn(Name = "银行地址1")]
        [ExcelColumnName("银行地址1")]
        public string ScBankAddr1 { get; set; }

        [ExcelColumn(Name = "银行地址2")]
        [ExcelColumnName("银行地址2")]
        public string ScBankAddr2 { get; set; }

        [Required(ErrorMessage = "银行账号不能为空")]
        [ExcelColumn(Name = "银行账号")]
        [ExcelColumnName("银行账号")]
        public string ScBankAccount { get; set; }

        [ExcelColumn(Name = "SWIFT代码")]
        [ExcelColumnName("SWIFT代码")]
        public string ScBankSwiftNo { get; set; }

        [ExcelColumn(Name = "国家地区")]
        [ExcelColumnName("国家地区")]
        public string ScRegionCode { get; set; }

        [ExcelColumn(Name = "州省")]
        [ExcelColumnName("州省")]
        public string ScState { get; set; }

        [ExcelColumn(Name = "市")]
        [ExcelColumnName("市")]
        public string ScCity { get; set; }

        [ExcelColumn(Name = "县")]
        [ExcelColumnName("县")]
        public string ScCounty { get; set; }

        [Required(ErrorMessage = "地址不能为空")]
        [ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]
        public string ScAddr { get; set; }

        [ExcelColumn(Name = "地址1")]
        [ExcelColumnName("地址1")]
        public string ScAddr1 { get; set; }

        [ExcelColumn(Name = "地址2")]
        [ExcelColumnName("地址2")]
        public string ScAddr2 { get; set; }

        [ExcelColumn(Name = "联系人")]
        [ExcelColumnName("联系人")]
        public string ScContacts { get; set; }

        [ExcelColumn(Name = "电邮")]
        [ExcelColumnName("电邮")]
        public string ScEmail { get; set; }

        [ExcelColumn(Name = "电话")]
        [ExcelColumnName("电话")]
        public string ScTelNo { get; set; }

        [ExcelColumn(Name = "传真")]
        [ExcelColumnName("传真")]
        public string ScFaxNp { get; set; }

        [ExcelColumn(Name = "手机")]
        [ExcelColumnName("手机")]
        public string ScPhoneNo { get; set; }

        [Required(ErrorMessage = "冻结标记不能为空")]
        [ExcelColumn(Name = "冻结标记")]
        [ExcelColumnName("冻结标记")]
        public int IsFroze { get; set; }

        [ExcelColumn(Name = "营业执照附件")]
        [ExcelColumnName("营业执照附件")]
        public string ScLicenseAnnex { get; set; }

        [ExcelColumn(Name = "其它附件")]
        [ExcelColumnName("其它附件")]
        public string ScOtherAnnex { get; set; }

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

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "销售组织")]
        public string ScOrgLabel { get; set; }

        [ExcelColumn(Name = "税别")]
        public string ScTaxTypeLabel { get; set; }

        [ExcelColumn(Name = "交易币种")]
        public string ScCcyLabel { get; set; }

        [ExcelColumn(Name = "付款条件")]
        public string ScPayTermsLabel { get; set; }

        [ExcelColumn(Name = "付款方式")]
        public string ScPayMethodLabel { get; set; }

        [ExcelColumn(Name = "统驭科目")]
        public string ScRecAccountLabel { get; set; }

        [ExcelColumn(Name = "贸易条件")]
        public string ScTradeTermsLabel { get; set; }

        [ExcelColumn(Name = "装运条件")]
        public string ScShippingTermsLabel { get; set; }

        [ExcelColumn(Name = "客户等级")]
        public string ScCustomerGradeLabel { get; set; }

        [ExcelColumn(Name = "客户信用")]
        public string ScCustomerCreditLabel { get; set; }

        [ExcelColumn(Name = "银行所在国")]
        public string ScBankCountryLabel { get; set; }

        [ExcelColumn(Name = "银行所在州省")]
        public string ScBankStateLabel { get; set; }

        [ExcelColumn(Name = "银行所在市")]
        public string ScBankCityLabel { get; set; }

        [ExcelColumn(Name = "银行所在县")]
        public string ScBankCountyLabel { get; set; }

        [ExcelColumn(Name = "冻结标记")]
        public string IsFrozeLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 客户信息
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 14:26:41
    /// </summary>
    public class SdClientImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long ScSfId { get; set; }

        [Required(ErrorMessage = "销售组织不能为空")]
        [ExcelColumn(Name = "销售组织")]
        [ExcelColumnName("销售组织")]
        public string ScOrg { get; set; }

        [Required(ErrorMessage = "行业类别不能为空")]
        [ExcelColumn(Name = "行业类别")]
        [ExcelColumnName("行业类别")]
        public string ScIndustryType { get; set; }

        [Required(ErrorMessage = "企业性质不能为空")]
        [ExcelColumn(Name = "企业性质")]
        [ExcelColumnName("企业性质")]
        public string ScEnterpriseNature { get; set; }

        [Required(ErrorMessage = "客户代码不能为空")]
        [ExcelColumn(Name = "客户代码")]
        [ExcelColumnName("客户代码")]
        public string ScCode { get; set; }

        [Required(ErrorMessage = "客户简称不能为空")]
        [ExcelColumn(Name = "客户简称")]
        [ExcelColumnName("客户简称")]
        public string ScAbbr { get; set; }

        [Required(ErrorMessage = "客户名称不能为空")]
        [ExcelColumn(Name = "客户名称")]
        [ExcelColumnName("客户名称")]
        public string ScName { get; set; }

        [Required(ErrorMessage = "企业法人不能为空")]
        [ExcelColumn(Name = "企业法人")]
        [ExcelColumnName("企业法人")]
        public string ScEbe { get; set; }

        [Required(ErrorMessage = "营业执照不能为空")]
        [ExcelColumn(Name = "营业执照")]
        [ExcelColumnName("营业执照")]
        public string ScBusinessNo { get; set; }

        [Required(ErrorMessage = "税号不能为空")]
        [ExcelColumn(Name = "税号")]
        [ExcelColumnName("税号")]
        public string ScTaxNo { get; set; }

        [Required(ErrorMessage = "税别不能为空")]
        [ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]
        public string ScTaxType { get; set; }

        [Required(ErrorMessage = "主营业务不能为空")]
        [ExcelColumn(Name = "主营业务")]
        [ExcelColumnName("主营业务")]
        public string ScMainBusiness { get; set; }

        [Required(ErrorMessage = "交易币种不能为空")]
        [ExcelColumn(Name = "交易币种")]
        [ExcelColumnName("交易币种")]
        public string ScCcy { get; set; }

        [Required(ErrorMessage = "付款条件不能为空")]
        [ExcelColumn(Name = "付款条件")]
        [ExcelColumnName("付款条件")]
        public string ScPayTerms { get; set; }

        [Required(ErrorMessage = "付款方式不能为空")]
        [ExcelColumn(Name = "付款方式")]
        [ExcelColumnName("付款方式")]
        public string ScPayMethod { get; set; }

        [Required(ErrorMessage = "统驭科目不能为空")]
        [ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]
        public string ScRecAccount { get; set; }

        [Required(ErrorMessage = "贸易条件不能为空")]
        [ExcelColumn(Name = "贸易条件")]
        [ExcelColumnName("贸易条件")]
        public string ScTradeTerms { get; set; }

        [Required(ErrorMessage = "装运条件不能为空")]
        [ExcelColumn(Name = "装运条件")]
        [ExcelColumnName("装运条件")]
        public string ScShippingTerms { get; set; }

        [ExcelColumn(Name = "客户等级")]
        [ExcelColumnName("客户等级")]
        public string ScCustomerGrade { get; set; }

        [ExcelColumn(Name = "客户信用")]
        [ExcelColumnName("客户信用")]
        public string ScCustomerCredit { get; set; }

        [ExcelColumn(Name = "首次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("首次交易")]
        public DateTime? ScFirstTransDate { get; set; }

        [ExcelColumn(Name = "最近交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("最近交易")]
        public DateTime? ScLastTransDate { get; set; }

        [Required(ErrorMessage = "银行代码不能为空")]
        [ExcelColumn(Name = "银行代码")]
        [ExcelColumnName("银行代码")]
        public string ScBankCode { get; set; }

        [Required(ErrorMessage = "银行名称不能为空")]
        [ExcelColumn(Name = "银行名称")]
        [ExcelColumnName("银行名称")]
        public string ScBankName { get; set; }

        [ExcelColumn(Name = "分行名称")]
        [ExcelColumnName("分行名称")]
        public string ScBranchName { get; set; }

        [Required(ErrorMessage = "银行所在国不能为空")]
        [ExcelColumn(Name = "银行所在国")]
        [ExcelColumnName("银行所在国")]
        public string ScBankCountry { get; set; }

        [Required(ErrorMessage = "银行所在州省不能为空")]
        [ExcelColumn(Name = "银行所在州省")]
        [ExcelColumnName("银行所在州省")]
        public string ScBankState { get; set; }

        [Required(ErrorMessage = "银行所在市不能为空")]
        [ExcelColumn(Name = "银行所在市")]
        [ExcelColumnName("银行所在市")]
        public string ScBankCity { get; set; }

        [Required(ErrorMessage = "银行所在县不能为空")]
        [ExcelColumn(Name = "银行所在县")]
        [ExcelColumnName("银行所在县")]
        public string ScBankCounty { get; set; }

        [Required(ErrorMessage = "银行地址不能为空")]
        [ExcelColumn(Name = "银行地址")]
        [ExcelColumnName("银行地址")]
        public string ScBankAddr { get; set; }

        [ExcelColumn(Name = "银行地址1")]
        [ExcelColumnName("银行地址1")]
        public string ScBankAddr1 { get; set; }

        [ExcelColumn(Name = "银行地址2")]
        [ExcelColumnName("银行地址2")]
        public string ScBankAddr2 { get; set; }

        [Required(ErrorMessage = "银行账号不能为空")]
        [ExcelColumn(Name = "银行账号")]
        [ExcelColumnName("银行账号")]
        public string ScBankAccount { get; set; }

        [ExcelColumn(Name = "SWIFT代码")]
        [ExcelColumnName("SWIFT代码")]
        public string ScBankSwiftNo { get; set; }

        [ExcelColumn(Name = "国家地区")]
        [ExcelColumnName("国家地区")]
        public string ScRegionCode { get; set; }

        [ExcelColumn(Name = "州省")]
        [ExcelColumnName("州省")]
        public string ScState { get; set; }

        [ExcelColumn(Name = "市")]
        [ExcelColumnName("市")]
        public string ScCity { get; set; }

        [ExcelColumn(Name = "县")]
        [ExcelColumnName("县")]
        public string ScCounty { get; set; }

        [Required(ErrorMessage = "地址不能为空")]
        [ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]
        public string ScAddr { get; set; }

        [ExcelColumn(Name = "地址1")]
        [ExcelColumnName("地址1")]
        public string ScAddr1 { get; set; }

        [ExcelColumn(Name = "地址2")]
        [ExcelColumnName("地址2")]
        public string ScAddr2 { get; set; }

        [ExcelColumn(Name = "联系人")]
        [ExcelColumnName("联系人")]
        public string ScContacts { get; set; }

        [ExcelColumn(Name = "电邮")]
        [ExcelColumnName("电邮")]
        public string ScEmail { get; set; }

        [ExcelColumn(Name = "电话")]
        [ExcelColumnName("电话")]
        public string ScTelNo { get; set; }

        [ExcelColumn(Name = "传真")]
        [ExcelColumnName("传真")]
        public string ScFaxNp { get; set; }

        [ExcelColumn(Name = "手机")]
        [ExcelColumnName("手机")]
        public string ScPhoneNo { get; set; }

        [Required(ErrorMessage = "冻结标记不能为空")]
        [ExcelColumn(Name = "冻结标记")]
        [ExcelColumnName("冻结标记")]
        public int IsFroze { get; set; }

        [ExcelColumn(Name = "营业执照附件")]
        [ExcelColumnName("营业执照附件")]
        public string ScLicenseAnnex { get; set; }

        [ExcelColumn(Name = "其它附件")]
        [ExcelColumnName("其它附件")]
        public string ScOtherAnnex { get; set; }

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

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "销售组织")]
        public string ScOrgLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "税别")]
        public string ScTaxTypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "交易币种")]
        public string ScCcyLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "付款条件")]
        public string ScPayTermsLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "付款方式")]
        public string ScPayMethodLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "统驭科目")]
        public string ScRecAccountLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "贸易条件")]
        public string ScTradeTermsLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "装运条件")]
        public string ScShippingTermsLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "客户等级")]
        public string ScCustomerGradeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "客户信用")]
        public string ScCustomerCreditLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "银行所在国")]
        public string ScBankCountryLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "银行所在州省")]
        public string ScBankStateLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "银行所在市")]
        public string ScBankCityLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "银行所在县")]
        public string ScBankCountyLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "冻结标记")]
        public string IsFrozeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}