
namespace Ams.Model.Logistics
{
    /// <summary>
    /// 厂商信息
    /// 数据实体对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 16:26:50)
    /// </summary>
    [SugarTable("mm_vendor")]
    public class Vendor
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long VeSFID { get; set; }

        /// <summary>
        /// 购买组织 
        /// </summary>
        public string VeOrg { get; set; }

        /// <summary>
        /// 行业类别 
        /// </summary>
        public string VeIndustryType { get; set; }

        /// <summary>
        /// 企业性质 
        /// </summary>
        public string VeEnterpriseNature { get; set; }

        /// <summary>
        /// 供应商代码 
        /// </summary>
        public string VeCode { get; set; }

        /// <summary>
        /// 供应商简称 
        /// </summary>
        public string VeAbbr { get; set; }

        /// <summary>
        /// 供应商名称 
        /// </summary>
        public string VeName { get; set; }

        /// <summary>
        /// 企业法人 
        /// </summary>
        public string VeEbe { get; set; }

        /// <summary>
        /// 营业执照 
        /// </summary>
        public string VeBusinessNo { get; set; }

        /// <summary>
        /// 税号 
        /// </summary>
        public string VeTaxNo { get; set; }

        /// <summary>
        /// 税别 
        /// </summary>
        public string VeTaxType { get; set; }

        /// <summary>
        /// 主营业务 
        /// </summary>
        public string VeMainBusiness { get; set; }

        /// <summary>
        /// 交易币种 
        /// </summary>
        public string VeCcy { get; set; }

        /// <summary>
        /// 付款条件 
        /// </summary>
        public string VePayTerms { get; set; }

        /// <summary>
        /// 付款方式 
        /// </summary>
        public string VePayMethod { get; set; }

        /// <summary>
        /// 统驭科目 
        /// </summary>
        public string VeRecAccount { get; set; }

        /// <summary>
        /// 贸易条件 
        /// </summary>
        public string VeTradeTerms { get; set; }

        /// <summary>
        /// 装运条件 
        /// </summary>
        public string VeShippingTerms { get; set; }

        /// <summary>
        /// 供应商等级 
        /// </summary>
        public string VeSupplierGrade { get; set; }

        /// <summary>
        /// 供应商信用 
        /// </summary>
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
        public string VeBankCode { get; set; }

        /// <summary>
        /// 银行名称 
        /// </summary>
        public string VeBankName { get; set; }

        /// <summary>
        /// 分行名称 
        /// </summary>
        public string VeBranchName { get; set; }

        /// <summary>
        /// 银行所在国 
        /// </summary>
        public string VeBankCountry { get; set; }

        /// <summary>
        /// 所在州省 
        /// </summary>
        public string VeBankState { get; set; }

        /// <summary>
        /// 所在市 
        /// </summary>
        public string VeBankCity { get; set; }

        /// <summary>
        /// 所在县 
        /// </summary>
        public string VeBankCounty { get; set; }

        /// <summary>
        /// 银行地址 
        /// </summary>
        public string VeBankAddr { get; set; }

        /// <summary>
        /// 银行地址1 
        /// </summary>
        public string VeBankAddr1 { get; set; }

        /// <summary>
        /// 银行地址2 
        /// </summary>
        public string VeBankAddr2 { get; set; }

        /// <summary>
        /// 银行账号 
        /// </summary>
        public string VeBankAccount { get; set; }

        /// <summary>
        /// SWIFT代码 
        /// </summary>
        public string VeBankSwiftNo { get; set; }

        /// <summary>
        /// 国家地区 
        /// </summary>
        public string VeRegionCode { get; set; }

        /// <summary>
        /// 州省 
        /// </summary>
        public string VeState { get; set; }

        /// <summary>
        /// 市 
        /// </summary>
        public string VeCity { get; set; }

        /// <summary>
        /// 县 
        /// </summary>
        public string VeCounty { get; set; }

        /// <summary>
        /// 地址 
        /// </summary>
        public string VeAddr { get; set; }

        /// <summary>
        /// 地址1 
        /// </summary>
        public string VeAddr1 { get; set; }

        /// <summary>
        /// 地址2 
        /// </summary>
        public string VeAddr2 { get; set; }

        /// <summary>
        /// 联系人 
        /// </summary>
        public string VeContacts { get; set; }

        /// <summary>
        /// 邮件 
        /// </summary>
        public string VeEmail { get; set; }

        /// <summary>
        /// 电话 
        /// </summary>
        public string VeTelNo { get; set; }

        /// <summary>
        /// 传真 
        /// </summary>
        public string VeFaxNp { get; set; }

        /// <summary>
        /// 手机 
        /// </summary>
        public string VePhoneNo { get; set; }

        /// <summary>
        /// 冻结标志 
        /// </summary>
        public int IsFroze { get; set; }

        /// <summary>
        /// 营业执照附件 
        /// </summary>
        public string VeLicenseAnnex { get; set; }

        /// <summary>
        /// 其它附件 
        /// </summary>
        public string VeOtherAnnex { get; set; }

        /// <summary>
        /// 自定义A 
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B 
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C 
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D 
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E 
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F 
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6 
        /// </summary>
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 说明 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 创建者 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新者 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 更新时间 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }

    }
}