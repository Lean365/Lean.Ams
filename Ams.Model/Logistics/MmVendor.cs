namespace Ams.Model.Logistics
{
    /// <summary>
    /// 厂商信息
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 11:23:27
    /// </summary>
    [SugarTable("mm_vendor", "厂商信息")]
    public class MmVendor : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long VeSfId { get; set; }

        /// <summary>
        /// 购买组织
        /// </summary>
        [SugarColumn(ColumnName = "VeOrg", ColumnDescription = "购买组织 ", Length = 4)]
        public string VeOrg { get; set; }

        /// <summary>
        /// 行业类别
        /// </summary>
        [SugarColumn(ColumnName = "VeIndustryType", ColumnDescription = "行业类别 ", Length = 1)]
        public string VeIndustryType { get; set; }

        /// <summary>
        /// 企业性质
        /// </summary>
        [SugarColumn(ColumnName = "VeEnterpriseNature", ColumnDescription = "企业性质 ", Length = 1)]
        public string VeEnterpriseNature { get; set; }

        /// <summary>
        /// 供应商代码
        /// </summary>
        [SugarColumn(ColumnName = "VeCode", ColumnDescription = "供应商代码 ", Length = 10)]
        public string VeCode { get; set; }

        /// <summary>
        /// 供应商简称
        /// </summary>
        [SugarColumn(ColumnName = "VeAbbr", ColumnDescription = "供应商简称 ", Length = 20)]
        public string VeAbbr { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [SugarColumn(ColumnName = "VeName", ColumnDescription = "供应商名称 ", Length = 100)]
        public string VeName { get; set; }

        /// <summary>
        /// 企业法人
        /// </summary>
        [SugarColumn(ColumnName = "VeEbe", ColumnDescription = "企业法人 ", Length = 50)]
        public string VeEbe { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        [SugarColumn(ColumnName = "VeBusinessNo", ColumnDescription = "营业执照 ", Length = 100)]
        public string VeBusinessNo { get; set; }

        /// <summary>
        /// 税号
        /// </summary>
        [SugarColumn(ColumnName = "VeTaxNo", ColumnDescription = "税号 ", Length = 100)]
        public string VeTaxNo { get; set; }

        /// <summary>
        /// 税别
        /// </summary>
        [SugarColumn(ColumnName = "VeTaxType", ColumnDescription = "税别 ", Length = 2)]
        public string VeTaxType { get; set; }

        /// <summary>
        /// 主营业务
        /// </summary>
        [SugarColumn(ColumnName = "VeMainBusiness", ColumnDescription = "主营业务 ", Length = 200)]
        public string VeMainBusiness { get; set; }

        /// <summary>
        /// 交易币种
        /// </summary>
        [SugarColumn(ColumnName = "VeCcy", ColumnDescription = "交易币种 ", Length = 3)]
        public string VeCcy { get; set; }

        /// <summary>
        /// 付款条件
        /// </summary>
        [SugarColumn(ColumnName = "VePayTerms", ColumnDescription = "付款条件 ", Length = 4)]
        public string VePayTerms { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        [SugarColumn(ColumnName = "VePayMethod", ColumnDescription = "付款方式 ", Length = 1)]
        public string VePayMethod { get; set; }

        /// <summary>
        /// 统驭科目
        /// </summary>
        [SugarColumn(ColumnName = "VeRecAccount", ColumnDescription = "统驭科目 ", Length = 6)]
        public string VeRecAccount { get; set; }

        /// <summary>
        /// 贸易条件
        /// </summary>
        [SugarColumn(ColumnName = "VeTradeTerms", ColumnDescription = "贸易条件 ", Length = 3)]
        public string VeTradeTerms { get; set; }

        /// <summary>
        /// 装运条件
        /// </summary>
        [SugarColumn(ColumnName = "VeShippingTerms", ColumnDescription = "装运条件 ", Length = 3)]
        public string VeShippingTerms { get; set; }

        /// <summary>
        /// 供应商等级
        /// </summary>
        [SugarColumn(ColumnName = "VeSupplierGrade", ColumnDescription = "供应商等级 ", Length = 1)]
        public string VeSupplierGrade { get; set; }

        /// <summary>
        /// 供应商信用
        /// </summary>
        [SugarColumn(ColumnName = "VeSupplierCredit", ColumnDescription = "供应商信用 ", Length = 1)]
        public string VeSupplierCredit { get; set; }

        /// <summary>
        /// 首次交易
        /// </summary>
        public DateTime? VeFirstTransDate { get; set; }

        /// <summary>
        /// 末次交易
        /// </summary>
        public DateTime? VeLastTransDate { get; set; }

        /// <summary>
        /// 银行代码
        /// </summary>
        [SugarColumn(ColumnName = "VeBankCode", ColumnDescription = "银行代码 ", Length = 8)]
        public string VeBankCode { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        [SugarColumn(ColumnName = "VeBankName", ColumnDescription = "银行名称 ", Length = 255)]
        public string VeBankName { get; set; }

        /// <summary>
        /// 分行名称
        /// </summary>
        [SugarColumn(ColumnName = "VeBranchName", ColumnDescription = "分行名称 ", Length = 255)]
        public string VeBranchName { get; set; }

        /// <summary>
        /// 银行所在国
        /// </summary>
        [SugarColumn(ColumnName = "VeBankCountry", ColumnDescription = "银行所在国 ", Length = 2)]
        public string VeBankCountry { get; set; }

        /// <summary>
        /// 所在州省
        /// </summary>
        [SugarColumn(ColumnName = "VeBankState", ColumnDescription = "所在州省 ", Length = 40)]
        public string VeBankState { get; set; }

        /// <summary>
        /// 所在市
        /// </summary>
        [SugarColumn(ColumnName = "VeBankCity", ColumnDescription = "所在市 ", Length = 40)]
        public string VeBankCity { get; set; }

        /// <summary>
        /// 所在县
        /// </summary>
        [SugarColumn(ColumnName = "VeBankCounty", ColumnDescription = "所在县 ", Length = 40)]
        public string VeBankCounty { get; set; }

        /// <summary>
        /// 银行地址
        /// </summary>
        [SugarColumn(ColumnName = "VeBankAddr", ColumnDescription = "银行地址 ", Length = 400)]
        public string VeBankAddr { get; set; }

        /// <summary>
        /// 银行地址1
        /// </summary>
        [SugarColumn(ColumnName = "VeBankAddr1", ColumnDescription = "银行地址1 ", Length = 400)]
        public string VeBankAddr1 { get; set; }

        /// <summary>
        /// 银行地址2
        /// </summary>
        [SugarColumn(ColumnName = "VeBankAddr2", ColumnDescription = "银行地址2 ", Length = 400)]
        public string VeBankAddr2 { get; set; }

        /// <summary>
        /// 银行账号
        /// </summary>
        [SugarColumn(ColumnName = "VeBankAccount", ColumnDescription = "银行账号 ", Length = 3)]
        public string VeBankAccount { get; set; }

        /// <summary>
        /// SWIFT代码
        /// </summary>
        [SugarColumn(ColumnName = "VeBankSwiftNo", ColumnDescription = "SWIFT代码 ", Length = 3)]
        public string VeBankSwiftNo { get; set; }

        /// <summary>
        /// 国家地区
        /// </summary>
        [SugarColumn(ColumnName = "VeRegionCode", ColumnDescription = "国家地区 ", Length = 2)]
        public string VeRegionCode { get; set; }

        /// <summary>
        /// 州省
        /// </summary>
        [SugarColumn(ColumnName = "VeState", ColumnDescription = "州省 ", Length = 40)]
        public string VeState { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [SugarColumn(ColumnName = "VeCity", ColumnDescription = "市 ", Length = 40)]
        public string VeCity { get; set; }

        /// <summary>
        /// 县
        /// </summary>
        [SugarColumn(ColumnName = "VeCounty", ColumnDescription = "县 ", Length = 40)]
        public string VeCounty { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(ColumnName = "VeAddr", ColumnDescription = "地址 ", Length = 400)]
        public string VeAddr { get; set; }

        /// <summary>
        /// 地址1
        /// </summary>
        [SugarColumn(ColumnName = "VeAddr1", ColumnDescription = "地址1 ", Length = 400)]
        public string VeAddr1 { get; set; }

        /// <summary>
        /// 地址2
        /// </summary>
        [SugarColumn(ColumnName = "VeAddr2", ColumnDescription = "地址2 ", Length = 400)]
        public string VeAddr2 { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [SugarColumn(ColumnName = "VeContacts", ColumnDescription = "联系人 ", Length = 200)]
        public string VeContacts { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        [SugarColumn(ColumnName = "VeEmail", ColumnDescription = "邮件 ", Length = 50)]
        public string VeEmail { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [SugarColumn(ColumnName = "VeTelNo", ColumnDescription = "电话 ", Length = 160)]
        public string VeTelNo { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [SugarColumn(ColumnName = "VeFaxNp", ColumnDescription = "传真 ", Length = 160)]
        public string VeFaxNp { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [SugarColumn(ColumnName = "VePhoneNo", ColumnDescription = "手机 ", Length = 160)]
        public string VePhoneNo { get; set; }

        /// <summary>
        /// 冻结标志
        /// </summary>
        [SugarColumn(ColumnName = "IsFroze", ColumnDescription = "冻结标志 ", DefaultValue = "0")]
        public int IsFroze { get; set; }

        /// <summary>
        /// 营业执照附件
        /// </summary>
        [SugarColumn(ColumnName = "VeLicenseAnnex", ColumnDescription = "营业执照附件 ", Length = 255)]
        public string VeLicenseAnnex { get; set; }

        /// <summary>
        /// 其它附件
        /// </summary>
        [SugarColumn(ColumnName = "VeOtherAnnex", ColumnDescription = "其它附件 ", Length = 255)]
        public string VeOtherAnnex { get; set; }
    }
}