namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 供应商信息
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 11:22:58
    /// </summary>
    public class MmSupplierQueryDto : PagerInfo
    {
        public string SuOrg { get; set; }
        public string SuIndustryType { get; set; }
        public string SuEnterpriseNature { get; set; }
        public string SuCode { get; set; }
        public string SuAbbr { get; set; }
        public string SuName { get; set; }
        public string SuTaxType { get; set; }
        public string SuCcy { get; set; }
        public string SuPayTerms { get; set; }
        public string SuPayMethod { get; set; }
        public string SuRecAccount { get; set; }
        public string SuTradeTerms { get; set; }
        public string SuShippingTerms { get; set; }
        public string SuSupplierGrade { get; set; }
        public string SuSupplierCredit { get; set; }
        public DateTime? BeginSuFirstTransDate { get; set; }
        public DateTime? EndSuFirstTransDate { get; set; }
        public string SuRegionCode { get; set; }
        public int? IsFroze { get; set; }
    }

    /// <summary>
    /// 供应商信息
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 11:22:58
    /// </summary>
    public class MmSupplierDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SuSfId { get; set; }

        [Required(ErrorMessage = "购买组织不能为空")]
        [ExcelColumn(Name = "购买组织")]
        [ExcelColumnName("购买组织")]
        public string SuOrg { get; set; }

        [Required(ErrorMessage = "行业类别不能为空")]
        [ExcelColumn(Name = "行业类别")]
        [ExcelColumnName("行业类别")]
        public string SuIndustryType { get; set; }

        [Required(ErrorMessage = "企业性质不能为空")]
        [ExcelColumn(Name = "企业性质")]
        [ExcelColumnName("企业性质")]
        public string SuEnterpriseNature { get; set; }

        [Required(ErrorMessage = "供应商代码不能为空")]
        [ExcelColumn(Name = "供应商代码")]
        [ExcelColumnName("供应商代码")]
        public string SuCode { get; set; }

        [Required(ErrorMessage = "供应商简称不能为空")]
        [ExcelColumn(Name = "供应商简称")]
        [ExcelColumnName("供应商简称")]
        public string SuAbbr { get; set; }

        [Required(ErrorMessage = "供应商名称不能为空")]
        [ExcelColumn(Name = "供应商名称")]
        [ExcelColumnName("供应商名称")]
        public string SuName { get; set; }

        [Required(ErrorMessage = "企业法人不能为空")]
        [ExcelColumn(Name = "企业法人")]
        [ExcelColumnName("企业法人")]
        public string SuEbe { get; set; }

        [Required(ErrorMessage = "营业执照不能为空")]
        [ExcelColumn(Name = "营业执照")]
        [ExcelColumnName("营业执照")]
        public string SuBusinessNo { get; set; }

        [Required(ErrorMessage = "税号不能为空")]
        [ExcelColumn(Name = "税号")]
        [ExcelColumnName("税号")]
        public string SuTaxNo { get; set; }

        [Required(ErrorMessage = "税别不能为空")]
        [ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]
        public string SuTaxType { get; set; }

        [Required(ErrorMessage = "主营业务不能为空")]
        [ExcelColumn(Name = "主营业务")]
        [ExcelColumnName("主营业务")]
        public string SuMainBusiness { get; set; }

        [Required(ErrorMessage = "交易币种不能为空")]
        [ExcelColumn(Name = "交易币种")]
        [ExcelColumnName("交易币种")]
        public string SuCcy { get; set; }

        [Required(ErrorMessage = "付款条件不能为空")]
        [ExcelColumn(Name = "付款条件")]
        [ExcelColumnName("付款条件")]
        public string SuPayTerms { get; set; }

        [Required(ErrorMessage = "付款方式不能为空")]
        [ExcelColumn(Name = "付款方式")]
        [ExcelColumnName("付款方式")]
        public string SuPayMethod { get; set; }

        [Required(ErrorMessage = "统驭科目不能为空")]
        [ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]
        public string SuRecAccount { get; set; }

        [Required(ErrorMessage = "贸易条件不能为空")]
        [ExcelColumn(Name = "贸易条件")]
        [ExcelColumnName("贸易条件")]
        public string SuTradeTerms { get; set; }

        [Required(ErrorMessage = "装运条件不能为空")]
        [ExcelColumn(Name = "装运条件")]
        [ExcelColumnName("装运条件")]
        public string SuShippingTerms { get; set; }

        [ExcelColumn(Name = "供应商等级")]
        [ExcelColumnName("供应商等级")]
        public string SuSupplierGrade { get; set; }

        [ExcelColumn(Name = "供应商信用")]
        [ExcelColumnName("供应商信用")]
        public string SuSupplierCredit { get; set; }

        [ExcelColumn(Name = "首次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("首次交易")]
        public DateTime? SuFirstTransDate { get; set; }

        [ExcelColumn(Name = "末次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("末次交易")]
        public DateTime? SuLastTransDate { get; set; }

        [Required(ErrorMessage = "银行代码不能为空")]
        [ExcelColumn(Name = "银行代码")]
        [ExcelColumnName("银行代码")]
        public string SuBankCode { get; set; }

        [Required(ErrorMessage = "银行名称不能为空")]
        [ExcelColumn(Name = "银行名称")]
        [ExcelColumnName("银行名称")]
        public string SuBankName { get; set; }

        [ExcelColumn(Name = "分行名称")]
        [ExcelColumnName("分行名称")]
        public string SuBranchName { get; set; }

        [Required(ErrorMessage = "银行所在国不能为空")]
        [ExcelColumn(Name = "银行所在国")]
        [ExcelColumnName("银行所在国")]
        public string SuBankCountry { get; set; }

        [Required(ErrorMessage = "所在州省不能为空")]
        [ExcelColumn(Name = "所在州省")]
        [ExcelColumnName("所在州省")]
        public string SuBankState { get; set; }

        [Required(ErrorMessage = "所在市不能为空")]
        [ExcelColumn(Name = "所在市")]
        [ExcelColumnName("所在市")]
        public string SuBankCity { get; set; }

        [Required(ErrorMessage = "所在县不能为空")]
        [ExcelColumn(Name = "所在县")]
        [ExcelColumnName("所在县")]
        public string SuBankCounty { get; set; }

        [Required(ErrorMessage = "银行地址不能为空")]
        [ExcelColumn(Name = "银行地址")]
        [ExcelColumnName("银行地址")]
        public string SuBankAddr { get; set; }

        [ExcelColumn(Name = "银行地址1")]
        [ExcelColumnName("银行地址1")]
        public string SuBankAddr1 { get; set; }

        [ExcelColumn(Name = "银行地址2")]
        [ExcelColumnName("银行地址2")]
        public string SuBankAddr2 { get; set; }

        [Required(ErrorMessage = "银行账号不能为空")]
        [ExcelColumn(Name = "银行账号")]
        [ExcelColumnName("银行账号")]
        public string SuBankAccount { get; set; }

        [ExcelColumn(Name = "SWIFT代码")]
        [ExcelColumnName("SWIFT代码")]
        public string SuBankSwiftNo { get; set; }

        [ExcelColumn(Name = "国家地区")]
        [ExcelColumnName("国家地区")]
        public string SuRegionCode { get; set; }

        [ExcelColumn(Name = "州省")]
        [ExcelColumnName("州省")]
        public string SuState { get; set; }

        [ExcelColumn(Name = "市")]
        [ExcelColumnName("市")]
        public string SuCity { get; set; }

        [ExcelColumn(Name = "县")]
        [ExcelColumnName("县")]
        public string SuCounty { get; set; }

        [Required(ErrorMessage = "地址不能为空")]
        [ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]
        public string SuAddr { get; set; }

        [ExcelColumn(Name = "地址1")]
        [ExcelColumnName("地址1")]
        public string SuAddr1 { get; set; }

        [ExcelColumn(Name = "地址2")]
        [ExcelColumnName("地址2")]
        public string SuAddr2 { get; set; }

        [ExcelColumn(Name = "联系人")]
        [ExcelColumnName("联系人")]
        public string SuContacts { get; set; }

        [ExcelColumn(Name = "邮件")]
        [ExcelColumnName("邮件")]
        public string SuEmail { get; set; }

        [ExcelColumn(Name = "电话")]
        [ExcelColumnName("电话")]
        public string SuTelNo { get; set; }

        [ExcelColumn(Name = "传真")]
        [ExcelColumnName("传真")]
        public string SuFaxNp { get; set; }

        [ExcelColumn(Name = "手机")]
        [ExcelColumnName("手机")]
        public string SuPhoneNo { get; set; }

        [Required(ErrorMessage = "冻结标志不能为空")]
        [ExcelColumn(Name = "冻结标志")]
        [ExcelColumnName("冻结标志")]
        public int IsFroze { get; set; }

        [ExcelColumn(Name = "营业执照附件")]
        [ExcelColumnName("营业执照附件")]
        public string SuLicenseAnnex { get; set; }

        [ExcelColumn(Name = "其它附件")]
        [ExcelColumnName("其它附件")]
        public string SuOtherAnnex { get; set; }

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

        [ExcelColumn(Name = "购买组织")]
        public string SuOrgLabel { get; set; }

        [ExcelColumn(Name = "行业类别")]
        public string SuIndustryTypeLabel { get; set; }

        [ExcelColumn(Name = "企业性质")]
        public string SuEnterpriseNatureLabel { get; set; }

        [ExcelColumn(Name = "税别")]
        public string SuTaxTypeLabel { get; set; }

        [ExcelColumn(Name = "交易币种")]
        public string SuCcyLabel { get; set; }

        [ExcelColumn(Name = "付款条件")]
        public string SuPayTermsLabel { get; set; }

        [ExcelColumn(Name = "付款方式")]
        public string SuPayMethodLabel { get; set; }

        [ExcelColumn(Name = "统驭科目")]
        public string SuRecAccountLabel { get; set; }

        [ExcelColumn(Name = "贸易条件")]
        public string SuTradeTermsLabel { get; set; }

        [ExcelColumn(Name = "装运条件")]
        public string SuShippingTermsLabel { get; set; }

        [ExcelColumn(Name = "供应商等级")]
        public string SuSupplierGradeLabel { get; set; }

        [ExcelColumn(Name = "供应商信用")]
        public string SuSupplierCreditLabel { get; set; }

        [ExcelColumn(Name = "银行所在国")]
        public string SuBankCountryLabel { get; set; }

        [ExcelColumn(Name = "冻结标志")]
        public string IsFrozeLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 供应商信息
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 11:22:58
    /// </summary>
    public class MmSupplierImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SuSfId { get; set; }

        [Required(ErrorMessage = "购买组织不能为空")]
        [ExcelColumn(Name = "购买组织")]
        [ExcelColumnName("购买组织")]
        public string SuOrg { get; set; }

        [Required(ErrorMessage = "行业类别不能为空")]
        [ExcelColumn(Name = "行业类别")]
        [ExcelColumnName("行业类别")]
        public string SuIndustryType { get; set; }

        [Required(ErrorMessage = "企业性质不能为空")]
        [ExcelColumn(Name = "企业性质")]
        [ExcelColumnName("企业性质")]
        public string SuEnterpriseNature { get; set; }

        [Required(ErrorMessage = "供应商代码不能为空")]
        [ExcelColumn(Name = "供应商代码")]
        [ExcelColumnName("供应商代码")]
        public string SuCode { get; set; }

        [Required(ErrorMessage = "供应商简称不能为空")]
        [ExcelColumn(Name = "供应商简称")]
        [ExcelColumnName("供应商简称")]
        public string SuAbbr { get; set; }

        [Required(ErrorMessage = "供应商名称不能为空")]
        [ExcelColumn(Name = "供应商名称")]
        [ExcelColumnName("供应商名称")]
        public string SuName { get; set; }

        [Required(ErrorMessage = "企业法人不能为空")]
        [ExcelColumn(Name = "企业法人")]
        [ExcelColumnName("企业法人")]
        public string SuEbe { get; set; }

        [Required(ErrorMessage = "营业执照不能为空")]
        [ExcelColumn(Name = "营业执照")]
        [ExcelColumnName("营业执照")]
        public string SuBusinessNo { get; set; }

        [Required(ErrorMessage = "税号不能为空")]
        [ExcelColumn(Name = "税号")]
        [ExcelColumnName("税号")]
        public string SuTaxNo { get; set; }

        [Required(ErrorMessage = "税别不能为空")]
        [ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]
        public string SuTaxType { get; set; }

        [Required(ErrorMessage = "主营业务不能为空")]
        [ExcelColumn(Name = "主营业务")]
        [ExcelColumnName("主营业务")]
        public string SuMainBusiness { get; set; }

        [Required(ErrorMessage = "交易币种不能为空")]
        [ExcelColumn(Name = "交易币种")]
        [ExcelColumnName("交易币种")]
        public string SuCcy { get; set; }

        [Required(ErrorMessage = "付款条件不能为空")]
        [ExcelColumn(Name = "付款条件")]
        [ExcelColumnName("付款条件")]
        public string SuPayTerms { get; set; }

        [Required(ErrorMessage = "付款方式不能为空")]
        [ExcelColumn(Name = "付款方式")]
        [ExcelColumnName("付款方式")]
        public string SuPayMethod { get; set; }

        [Required(ErrorMessage = "统驭科目不能为空")]
        [ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]
        public string SuRecAccount { get; set; }

        [Required(ErrorMessage = "贸易条件不能为空")]
        [ExcelColumn(Name = "贸易条件")]
        [ExcelColumnName("贸易条件")]
        public string SuTradeTerms { get; set; }

        [Required(ErrorMessage = "装运条件不能为空")]
        [ExcelColumn(Name = "装运条件")]
        [ExcelColumnName("装运条件")]
        public string SuShippingTerms { get; set; }

        [ExcelColumn(Name = "供应商等级")]
        [ExcelColumnName("供应商等级")]
        public string SuSupplierGrade { get; set; }

        [ExcelColumn(Name = "供应商信用")]
        [ExcelColumnName("供应商信用")]
        public string SuSupplierCredit { get; set; }

        [ExcelColumn(Name = "首次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("首次交易")]
        public DateTime? SuFirstTransDate { get; set; }

        [ExcelColumn(Name = "末次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("末次交易")]
        public DateTime? SuLastTransDate { get; set; }

        [Required(ErrorMessage = "银行代码不能为空")]
        [ExcelColumn(Name = "银行代码")]
        [ExcelColumnName("银行代码")]
        public string SuBankCode { get; set; }

        [Required(ErrorMessage = "银行名称不能为空")]
        [ExcelColumn(Name = "银行名称")]
        [ExcelColumnName("银行名称")]
        public string SuBankName { get; set; }

        [ExcelColumn(Name = "分行名称")]
        [ExcelColumnName("分行名称")]
        public string SuBranchName { get; set; }

        [Required(ErrorMessage = "银行所在国不能为空")]
        [ExcelColumn(Name = "银行所在国")]
        [ExcelColumnName("银行所在国")]
        public string SuBankCountry { get; set; }

        [Required(ErrorMessage = "所在州省不能为空")]
        [ExcelColumn(Name = "所在州省")]
        [ExcelColumnName("所在州省")]
        public string SuBankState { get; set; }

        [Required(ErrorMessage = "所在市不能为空")]
        [ExcelColumn(Name = "所在市")]
        [ExcelColumnName("所在市")]
        public string SuBankCity { get; set; }

        [Required(ErrorMessage = "所在县不能为空")]
        [ExcelColumn(Name = "所在县")]
        [ExcelColumnName("所在县")]
        public string SuBankCounty { get; set; }

        [Required(ErrorMessage = "银行地址不能为空")]
        [ExcelColumn(Name = "银行地址")]
        [ExcelColumnName("银行地址")]
        public string SuBankAddr { get; set; }

        [ExcelColumn(Name = "银行地址1")]
        [ExcelColumnName("银行地址1")]
        public string SuBankAddr1 { get; set; }

        [ExcelColumn(Name = "银行地址2")]
        [ExcelColumnName("银行地址2")]
        public string SuBankAddr2 { get; set; }

        [Required(ErrorMessage = "银行账号不能为空")]
        [ExcelColumn(Name = "银行账号")]
        [ExcelColumnName("银行账号")]
        public string SuBankAccount { get; set; }

        [ExcelColumn(Name = "SWIFT代码")]
        [ExcelColumnName("SWIFT代码")]
        public string SuBankSwiftNo { get; set; }

        [ExcelColumn(Name = "国家地区")]
        [ExcelColumnName("国家地区")]
        public string SuRegionCode { get; set; }

        [ExcelColumn(Name = "州省")]
        [ExcelColumnName("州省")]
        public string SuState { get; set; }

        [ExcelColumn(Name = "市")]
        [ExcelColumnName("市")]
        public string SuCity { get; set; }

        [ExcelColumn(Name = "县")]
        [ExcelColumnName("县")]
        public string SuCounty { get; set; }

        [Required(ErrorMessage = "地址不能为空")]
        [ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]
        public string SuAddr { get; set; }

        [ExcelColumn(Name = "地址1")]
        [ExcelColumnName("地址1")]
        public string SuAddr1 { get; set; }

        [ExcelColumn(Name = "地址2")]
        [ExcelColumnName("地址2")]
        public string SuAddr2 { get; set; }

        [ExcelColumn(Name = "联系人")]
        [ExcelColumnName("联系人")]
        public string SuContacts { get; set; }

        [ExcelColumn(Name = "邮件")]
        [ExcelColumnName("邮件")]
        public string SuEmail { get; set; }

        [ExcelColumn(Name = "电话")]
        [ExcelColumnName("电话")]
        public string SuTelNo { get; set; }

        [ExcelColumn(Name = "传真")]
        [ExcelColumnName("传真")]
        public string SuFaxNp { get; set; }

        [ExcelColumn(Name = "手机")]
        [ExcelColumnName("手机")]
        public string SuPhoneNo { get; set; }

        [Required(ErrorMessage = "冻结标志不能为空")]
        [ExcelColumn(Name = "冻结标志")]
        [ExcelColumnName("冻结标志")]
        public int IsFroze { get; set; }

        [ExcelColumn(Name = "营业执照附件")]
        [ExcelColumnName("营业执照附件")]
        public string SuLicenseAnnex { get; set; }

        [ExcelColumn(Name = "其它附件")]
        [ExcelColumnName("其它附件")]
        public string SuOtherAnnex { get; set; }

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
        [ExcelColumn(Name = "购买组织")]
        public string SuOrgLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "行业类别")]
        public string SuIndustryTypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "企业性质")]
        public string SuEnterpriseNatureLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "税别")]
        public string SuTaxTypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "交易币种")]
        public string SuCcyLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "付款条件")]
        public string SuPayTermsLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "付款方式")]
        public string SuPayMethodLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "统驭科目")]
        public string SuRecAccountLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "贸易条件")]
        public string SuTradeTermsLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "装运条件")]
        public string SuShippingTermsLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "供应商等级")]
        public string SuSupplierGradeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "供应商信用")]
        public string SuSupplierCreditLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "银行所在国")]
        public string SuBankCountryLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "冻结标志")]
        public string IsFrozeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}