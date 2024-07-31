namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 厂商信息
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 11:23:27
    /// </summary>
    public class MmVendorQueryDto : PagerInfo
    {
        public string VeOrg { get; set; }
        public string VeIndustryType { get; set; }
        public string VeEnterpriseNature { get; set; }
        public string VeCode { get; set; }
        public string VeAbbr { get; set; }
        public string VeName { get; set; }
        public string VeTaxType { get; set; }
        public string VeCcy { get; set; }
        public string VePayTerms { get; set; }
        public string VePayMethod { get; set; }
        public string VeRecAccount { get; set; }
        public string VeTradeTerms { get; set; }
        public string VeShippingTerms { get; set; }
        public string VeSupplierGrade { get; set; }
        public string VeSupplierCredit { get; set; }
        public DateTime? BeginVeFirstTransDate { get; set; }
        public DateTime? EndVeFirstTransDate { get; set; }
        public string VeRegionCode { get; set; }
        public int? IsFroze { get; set; }
    }

    /// <summary>
    /// 厂商信息
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 11:23:27
    /// </summary>
    public class MmVendorDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long VeSfId { get; set; }

        [Required(ErrorMessage = "购买组织不能为空")]
        [ExcelColumn(Name = "购买组织")]
        [ExcelColumnName("购买组织")]
        public string VeOrg { get; set; }

        [Required(ErrorMessage = "行业类别不能为空")]
        [ExcelColumn(Name = "行业类别")]
        [ExcelColumnName("行业类别")]
        public string VeIndustryType { get; set; }

        [Required(ErrorMessage = "企业性质不能为空")]
        [ExcelColumn(Name = "企业性质")]
        [ExcelColumnName("企业性质")]
        public string VeEnterpriseNature { get; set; }

        [Required(ErrorMessage = "供应商代码不能为空")]
        [ExcelColumn(Name = "供应商代码")]
        [ExcelColumnName("供应商代码")]
        public string VeCode { get; set; }

        [Required(ErrorMessage = "供应商简称不能为空")]
        [ExcelColumn(Name = "供应商简称")]
        [ExcelColumnName("供应商简称")]
        public string VeAbbr { get; set; }

        [Required(ErrorMessage = "供应商名称不能为空")]
        [ExcelColumn(Name = "供应商名称")]
        [ExcelColumnName("供应商名称")]
        public string VeName { get; set; }

        [Required(ErrorMessage = "企业法人不能为空")]
        [ExcelColumn(Name = "企业法人")]
        [ExcelColumnName("企业法人")]
        public string VeEbe { get; set; }

        [Required(ErrorMessage = "营业执照不能为空")]
        [ExcelColumn(Name = "营业执照")]
        [ExcelColumnName("营业执照")]
        public string VeBusinessNo { get; set; }

        [Required(ErrorMessage = "税号不能为空")]
        [ExcelColumn(Name = "税号")]
        [ExcelColumnName("税号")]
        public string VeTaxNo { get; set; }

        [Required(ErrorMessage = "税别不能为空")]
        [ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]
        public string VeTaxType { get; set; }

        [Required(ErrorMessage = "主营业务不能为空")]
        [ExcelColumn(Name = "主营业务")]
        [ExcelColumnName("主营业务")]
        public string VeMainBusiness { get; set; }

        [Required(ErrorMessage = "交易币种不能为空")]
        [ExcelColumn(Name = "交易币种")]
        [ExcelColumnName("交易币种")]
        public string VeCcy { get; set; }

        [Required(ErrorMessage = "付款条件不能为空")]
        [ExcelColumn(Name = "付款条件")]
        [ExcelColumnName("付款条件")]
        public string VePayTerms { get; set; }

        [Required(ErrorMessage = "付款方式不能为空")]
        [ExcelColumn(Name = "付款方式")]
        [ExcelColumnName("付款方式")]
        public string VePayMethod { get; set; }

        [Required(ErrorMessage = "统驭科目不能为空")]
        [ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]
        public string VeRecAccount { get; set; }

        [Required(ErrorMessage = "贸易条件不能为空")]
        [ExcelColumn(Name = "贸易条件")]
        [ExcelColumnName("贸易条件")]
        public string VeTradeTerms { get; set; }

        [Required(ErrorMessage = "装运条件不能为空")]
        [ExcelColumn(Name = "装运条件")]
        [ExcelColumnName("装运条件")]
        public string VeShippingTerms { get; set; }

        [ExcelColumn(Name = "供应商等级")]
        [ExcelColumnName("供应商等级")]
        public string VeSupplierGrade { get; set; }

        [ExcelColumn(Name = "供应商信用")]
        [ExcelColumnName("供应商信用")]
        public string VeSupplierCredit { get; set; }

        [ExcelColumn(Name = "首次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("首次交易")]
        public DateTime? VeFirstTransDate { get; set; }

        [ExcelColumn(Name = "末次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("末次交易")]
        public DateTime? VeLastTransDate { get; set; }

        [Required(ErrorMessage = "银行代码不能为空")]
        [ExcelColumn(Name = "银行代码")]
        [ExcelColumnName("银行代码")]
        public string VeBankCode { get; set; }

        [Required(ErrorMessage = "银行名称不能为空")]
        [ExcelColumn(Name = "银行名称")]
        [ExcelColumnName("银行名称")]
        public string VeBankName { get; set; }

        [ExcelColumn(Name = "分行名称")]
        [ExcelColumnName("分行名称")]
        public string VeBranchName { get; set; }

        [Required(ErrorMessage = "银行所在国不能为空")]
        [ExcelColumn(Name = "银行所在国")]
        [ExcelColumnName("银行所在国")]
        public string VeBankCountry { get; set; }

        [Required(ErrorMessage = "所在州省不能为空")]
        [ExcelColumn(Name = "所在州省")]
        [ExcelColumnName("所在州省")]
        public string VeBankState { get; set; }

        [Required(ErrorMessage = "所在市不能为空")]
        [ExcelColumn(Name = "所在市")]
        [ExcelColumnName("所在市")]
        public string VeBankCity { get; set; }

        [Required(ErrorMessage = "所在县不能为空")]
        [ExcelColumn(Name = "所在县")]
        [ExcelColumnName("所在县")]
        public string VeBankCounty { get; set; }

        [Required(ErrorMessage = "银行地址不能为空")]
        [ExcelColumn(Name = "银行地址")]
        [ExcelColumnName("银行地址")]
        public string VeBankAddr { get; set; }

        [ExcelColumn(Name = "银行地址1")]
        [ExcelColumnName("银行地址1")]
        public string VeBankAddr1 { get; set; }

        [ExcelColumn(Name = "银行地址2")]
        [ExcelColumnName("银行地址2")]
        public string VeBankAddr2 { get; set; }

        [Required(ErrorMessage = "银行账号不能为空")]
        [ExcelColumn(Name = "银行账号")]
        [ExcelColumnName("银行账号")]
        public string VeBankAccount { get; set; }

        [ExcelColumn(Name = "SWIFT代码")]
        [ExcelColumnName("SWIFT代码")]
        public string VeBankSwiftNo { get; set; }

        [ExcelColumn(Name = "国家地区")]
        [ExcelColumnName("国家地区")]
        public string VeRegionCode { get; set; }

        [ExcelColumn(Name = "州省")]
        [ExcelColumnName("州省")]
        public string VeState { get; set; }

        [ExcelColumn(Name = "市")]
        [ExcelColumnName("市")]
        public string VeCity { get; set; }

        [ExcelColumn(Name = "县")]
        [ExcelColumnName("县")]
        public string VeCounty { get; set; }

        [Required(ErrorMessage = "地址不能为空")]
        [ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]
        public string VeAddr { get; set; }

        [ExcelColumn(Name = "地址1")]
        [ExcelColumnName("地址1")]
        public string VeAddr1 { get; set; }

        [ExcelColumn(Name = "地址2")]
        [ExcelColumnName("地址2")]
        public string VeAddr2 { get; set; }

        [ExcelColumn(Name = "联系人")]
        [ExcelColumnName("联系人")]
        public string VeContacts { get; set; }

        [ExcelColumn(Name = "邮件")]
        [ExcelColumnName("邮件")]
        public string VeEmail { get; set; }

        [ExcelColumn(Name = "电话")]
        [ExcelColumnName("电话")]
        public string VeTelNo { get; set; }

        [ExcelColumn(Name = "传真")]
        [ExcelColumnName("传真")]
        public string VeFaxNp { get; set; }

        [ExcelColumn(Name = "手机")]
        [ExcelColumnName("手机")]
        public string VePhoneNo { get; set; }

        [Required(ErrorMessage = "冻结标志不能为空")]
        [ExcelColumn(Name = "冻结标志")]
        [ExcelColumnName("冻结标志")]
        public int IsFroze { get; set; }

        [ExcelColumn(Name = "营业执照附件")]
        [ExcelColumnName("营业执照附件")]
        public string VeLicenseAnnex { get; set; }

        [ExcelColumn(Name = "其它附件")]
        [ExcelColumnName("其它附件")]
        public string VeOtherAnnex { get; set; }

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
        public string VeOrgLabel { get; set; }

        [ExcelColumn(Name = "行业类别")]
        public string VeIndustryTypeLabel { get; set; }

        [ExcelColumn(Name = "企业性质")]
        public string VeEnterpriseNatureLabel { get; set; }

        [ExcelColumn(Name = "税别")]
        public string VeTaxTypeLabel { get; set; }

        [ExcelColumn(Name = "交易币种")]
        public string VeCcyLabel { get; set; }

        [ExcelColumn(Name = "付款条件")]
        public string VePayTermsLabel { get; set; }

        [ExcelColumn(Name = "付款方式")]
        public string VePayMethodLabel { get; set; }

        [ExcelColumn(Name = "统驭科目")]
        public string VeRecAccountLabel { get; set; }

        [ExcelColumn(Name = "贸易条件")]
        public string VeTradeTermsLabel { get; set; }

        [ExcelColumn(Name = "装运条件")]
        public string VeShippingTermsLabel { get; set; }

        [ExcelColumn(Name = "供应商等级")]
        public string VeSupplierGradeLabel { get; set; }

        [ExcelColumn(Name = "供应商信用")]
        public string VeSupplierCreditLabel { get; set; }

        [ExcelColumn(Name = "银行所在国")]
        public string VeBankCountryLabel { get; set; }

        [ExcelColumn(Name = "冻结标志")]
        public string IsFrozeLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 厂商信息
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 11:23:27
    /// </summary>
    public class MmVendorImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long VeSfId { get; set; }

        [Required(ErrorMessage = "购买组织不能为空")]
        [ExcelColumn(Name = "购买组织")]
        [ExcelColumnName("购买组织")]
        public string VeOrg { get; set; }

        [Required(ErrorMessage = "行业类别不能为空")]
        [ExcelColumn(Name = "行业类别")]
        [ExcelColumnName("行业类别")]
        public string VeIndustryType { get; set; }

        [Required(ErrorMessage = "企业性质不能为空")]
        [ExcelColumn(Name = "企业性质")]
        [ExcelColumnName("企业性质")]
        public string VeEnterpriseNature { get; set; }

        [Required(ErrorMessage = "供应商代码不能为空")]
        [ExcelColumn(Name = "供应商代码")]
        [ExcelColumnName("供应商代码")]
        public string VeCode { get; set; }

        [Required(ErrorMessage = "供应商简称不能为空")]
        [ExcelColumn(Name = "供应商简称")]
        [ExcelColumnName("供应商简称")]
        public string VeAbbr { get; set; }

        [Required(ErrorMessage = "供应商名称不能为空")]
        [ExcelColumn(Name = "供应商名称")]
        [ExcelColumnName("供应商名称")]
        public string VeName { get; set; }

        [Required(ErrorMessage = "企业法人不能为空")]
        [ExcelColumn(Name = "企业法人")]
        [ExcelColumnName("企业法人")]
        public string VeEbe { get; set; }

        [Required(ErrorMessage = "营业执照不能为空")]
        [ExcelColumn(Name = "营业执照")]
        [ExcelColumnName("营业执照")]
        public string VeBusinessNo { get; set; }

        [Required(ErrorMessage = "税号不能为空")]
        [ExcelColumn(Name = "税号")]
        [ExcelColumnName("税号")]
        public string VeTaxNo { get; set; }

        [Required(ErrorMessage = "税别不能为空")]
        [ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]
        public string VeTaxType { get; set; }

        [Required(ErrorMessage = "主营业务不能为空")]
        [ExcelColumn(Name = "主营业务")]
        [ExcelColumnName("主营业务")]
        public string VeMainBusiness { get; set; }

        [Required(ErrorMessage = "交易币种不能为空")]
        [ExcelColumn(Name = "交易币种")]
        [ExcelColumnName("交易币种")]
        public string VeCcy { get; set; }

        [Required(ErrorMessage = "付款条件不能为空")]
        [ExcelColumn(Name = "付款条件")]
        [ExcelColumnName("付款条件")]
        public string VePayTerms { get; set; }

        [Required(ErrorMessage = "付款方式不能为空")]
        [ExcelColumn(Name = "付款方式")]
        [ExcelColumnName("付款方式")]
        public string VePayMethod { get; set; }

        [Required(ErrorMessage = "统驭科目不能为空")]
        [ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]
        public string VeRecAccount { get; set; }

        [Required(ErrorMessage = "贸易条件不能为空")]
        [ExcelColumn(Name = "贸易条件")]
        [ExcelColumnName("贸易条件")]
        public string VeTradeTerms { get; set; }

        [Required(ErrorMessage = "装运条件不能为空")]
        [ExcelColumn(Name = "装运条件")]
        [ExcelColumnName("装运条件")]
        public string VeShippingTerms { get; set; }

        [ExcelColumn(Name = "供应商等级")]
        [ExcelColumnName("供应商等级")]
        public string VeSupplierGrade { get; set; }

        [ExcelColumn(Name = "供应商信用")]
        [ExcelColumnName("供应商信用")]
        public string VeSupplierCredit { get; set; }

        [ExcelColumn(Name = "首次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("首次交易")]
        public DateTime? VeFirstTransDate { get; set; }

        [ExcelColumn(Name = "末次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("末次交易")]
        public DateTime? VeLastTransDate { get; set; }

        [Required(ErrorMessage = "银行代码不能为空")]
        [ExcelColumn(Name = "银行代码")]
        [ExcelColumnName("银行代码")]
        public string VeBankCode { get; set; }

        [Required(ErrorMessage = "银行名称不能为空")]
        [ExcelColumn(Name = "银行名称")]
        [ExcelColumnName("银行名称")]
        public string VeBankName { get; set; }

        [ExcelColumn(Name = "分行名称")]
        [ExcelColumnName("分行名称")]
        public string VeBranchName { get; set; }

        [Required(ErrorMessage = "银行所在国不能为空")]
        [ExcelColumn(Name = "银行所在国")]
        [ExcelColumnName("银行所在国")]
        public string VeBankCountry { get; set; }

        [Required(ErrorMessage = "所在州省不能为空")]
        [ExcelColumn(Name = "所在州省")]
        [ExcelColumnName("所在州省")]
        public string VeBankState { get; set; }

        [Required(ErrorMessage = "所在市不能为空")]
        [ExcelColumn(Name = "所在市")]
        [ExcelColumnName("所在市")]
        public string VeBankCity { get; set; }

        [Required(ErrorMessage = "所在县不能为空")]
        [ExcelColumn(Name = "所在县")]
        [ExcelColumnName("所在县")]
        public string VeBankCounty { get; set; }

        [Required(ErrorMessage = "银行地址不能为空")]
        [ExcelColumn(Name = "银行地址")]
        [ExcelColumnName("银行地址")]
        public string VeBankAddr { get; set; }

        [ExcelColumn(Name = "银行地址1")]
        [ExcelColumnName("银行地址1")]
        public string VeBankAddr1 { get; set; }

        [ExcelColumn(Name = "银行地址2")]
        [ExcelColumnName("银行地址2")]
        public string VeBankAddr2 { get; set; }

        [Required(ErrorMessage = "银行账号不能为空")]
        [ExcelColumn(Name = "银行账号")]
        [ExcelColumnName("银行账号")]
        public string VeBankAccount { get; set; }

        [ExcelColumn(Name = "SWIFT代码")]
        [ExcelColumnName("SWIFT代码")]
        public string VeBankSwiftNo { get; set; }

        [ExcelColumn(Name = "国家地区")]
        [ExcelColumnName("国家地区")]
        public string VeRegionCode { get; set; }

        [ExcelColumn(Name = "州省")]
        [ExcelColumnName("州省")]
        public string VeState { get; set; }

        [ExcelColumn(Name = "市")]
        [ExcelColumnName("市")]
        public string VeCity { get; set; }

        [ExcelColumn(Name = "县")]
        [ExcelColumnName("县")]
        public string VeCounty { get; set; }

        [Required(ErrorMessage = "地址不能为空")]
        [ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]
        public string VeAddr { get; set; }

        [ExcelColumn(Name = "地址1")]
        [ExcelColumnName("地址1")]
        public string VeAddr1 { get; set; }

        [ExcelColumn(Name = "地址2")]
        [ExcelColumnName("地址2")]
        public string VeAddr2 { get; set; }

        [ExcelColumn(Name = "联系人")]
        [ExcelColumnName("联系人")]
        public string VeContacts { get; set; }

        [ExcelColumn(Name = "邮件")]
        [ExcelColumnName("邮件")]
        public string VeEmail { get; set; }

        [ExcelColumn(Name = "电话")]
        [ExcelColumnName("电话")]
        public string VeTelNo { get; set; }

        [ExcelColumn(Name = "传真")]
        [ExcelColumnName("传真")]
        public string VeFaxNp { get; set; }

        [ExcelColumn(Name = "手机")]
        [ExcelColumnName("手机")]
        public string VePhoneNo { get; set; }

        [Required(ErrorMessage = "冻结标志不能为空")]
        [ExcelColumn(Name = "冻结标志")]
        [ExcelColumnName("冻结标志")]
        public int IsFroze { get; set; }

        [ExcelColumn(Name = "营业执照附件")]
        [ExcelColumnName("营业执照附件")]
        public string VeLicenseAnnex { get; set; }

        [ExcelColumn(Name = "其它附件")]
        [ExcelColumnName("其它附件")]
        public string VeOtherAnnex { get; set; }

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
        public string VeOrgLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "行业类别")]
        public string VeIndustryTypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "企业性质")]
        public string VeEnterpriseNatureLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "税别")]
        public string VeTaxTypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "交易币种")]
        public string VeCcyLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "付款条件")]
        public string VePayTermsLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "付款方式")]
        public string VePayMethodLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "统驭科目")]
        public string VeRecAccountLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "贸易条件")]
        public string VeTradeTermsLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "装运条件")]
        public string VeShippingTermsLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "供应商等级")]
        public string VeSupplierGradeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "供应商信用")]
        public string VeSupplierCreditLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "银行所在国")]
        public string VeBankCountryLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "冻结标志")]
        public string IsFrozeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}