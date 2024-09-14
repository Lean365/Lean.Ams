
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 供应商
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:53
    /// </summary>
    public class MmSupplierQueryDto : PagerInfo 
    {
        /// <summary>
        /// 购买组织 
        /// </summary>        
        public string Mf003 { get; set; }
        /// <summary>
        /// 行业类别 
        /// </summary>        
        public string Mf004 { get; set; }
        /// <summary>
        /// 企业性质 
        /// </summary>        
        public string Mf005 { get; set; }
        /// <summary>
        /// 供应商代码 
        /// </summary>        
        public string Mf006 { get; set; }
        /// <summary>
        /// 供应商简称 
        /// </summary>        
        public string Mf008 { get; set; }
        /// <summary>
        /// 供应商名称 
        /// </summary>        
        public string Mf009 { get; set; }
        /// <summary>
        /// 税别 
        /// </summary>        
        public string Mf013 { get; set; }
        /// <summary>
        /// 采购组 
        /// </summary>        
        public string Mf015 { get; set; }
        /// <summary>
        /// 交易币种 
        /// </summary>        
        public string Mf016 { get; set; }
        /// <summary>
        /// 付款条件 
        /// </summary>        
        public string Mf017 { get; set; }
        /// <summary>
        /// 付款方式 
        /// </summary>        
        public string Mf018 { get; set; }
        /// <summary>
        /// 统驭科目 
        /// </summary>        
        public string Mf019 { get; set; }
        /// <summary>
        /// 贸易条件 
        /// </summary>        
        public string Mf020 { get; set; }
        /// <summary>
        /// 供应商等级 
        /// </summary>        
        public string Mf023 { get; set; }
        /// <summary>
        /// 国家地区 
        /// </summary>        
        public string Mf028 { get; set; }
        /// <summary>
        /// 交易冻结 
        /// </summary>        
        public int? Mf045 { get; set; }
    }

    /// <summary>
    /// 供应商
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:53
    /// </summary>
    public class MmSupplierDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]

        public string Mf002 { get; set; }

        [Required(ErrorMessage = "购买组织不能为空")]
        //[ExcelColumn(Name = "购买组织")]
        [ExcelColumnName("购买组织")]

        public string Mf003 { get; set; }

        [Required(ErrorMessage = "行业类别不能为空")]
        //[ExcelColumn(Name = "行业类别")]
        [ExcelColumnName("行业类别")]

        public string Mf004 { get; set; }

        [Required(ErrorMessage = "企业性质不能为空")]
        //[ExcelColumn(Name = "企业性质")]
        [ExcelColumnName("企业性质")]

        public string Mf005 { get; set; }

        [Required(ErrorMessage = "供应商代码不能为空")]
        //[ExcelColumn(Name = "供应商代码")]
        [ExcelColumnName("供应商代码")]

        public string Mf006 { get; set; }

        //[ExcelColumn(Name = "ABC标识")]
        [ExcelColumnName("ABC标识")]

        public string Mf007 { get; set; }

        //[ExcelColumn(Name = "供应商简称")]
        [ExcelColumnName("供应商简称")]

        public string Mf008 { get; set; }

        //[ExcelColumn(Name = "供应商名称")]
        [ExcelColumnName("供应商名称")]

        public string Mf009 { get; set; }

        //[ExcelColumn(Name = "企业法人")]
        [ExcelColumnName("企业法人")]

        public string Mf010 { get; set; }

        //[ExcelColumn(Name = "营业执照")]
        [ExcelColumnName("营业执照")]

        public string Mf011 { get; set; }

        //[ExcelColumn(Name = "税号")]
        [ExcelColumnName("税号")]

        public string Mf012 { get; set; }

        //[ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]

        public string Mf013 { get; set; }

        //[ExcelColumn(Name = "主营业务")]
        [ExcelColumnName("主营业务")]

        public string Mf014 { get; set; }

        //[ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]

        public string Mf015 { get; set; }

        //[ExcelColumn(Name = "交易币种")]
        [ExcelColumnName("交易币种")]

        public string Mf016 { get; set; }

        //[ExcelColumn(Name = "付款条件")]
        [ExcelColumnName("付款条件")]

        public string Mf017 { get; set; }

        //[ExcelColumn(Name = "付款方式")]
        [ExcelColumnName("付款方式")]

        public string Mf018 { get; set; }

        //[ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]

        public string Mf019 { get; set; }

        //[ExcelColumn(Name = "贸易条件")]
        [ExcelColumnName("贸易条件")]

        public string Mf020 { get; set; }

        //[ExcelColumn(Name = "装运条件")]
        [ExcelColumnName("装运条件")]

        public string Mf021 { get; set; }

        //[ExcelColumn(Name = "运输方式")]
        [ExcelColumnName("运输方式")]

        public string Mf022 { get; set; }

        //[ExcelColumn(Name = "供应商等级")]
        [ExcelColumnName("供应商等级")]

        public string Mf023 { get; set; }

        //[ExcelColumn(Name = "供应商信用")]
        [ExcelColumnName("供应商信用")]

        public string Mf024 { get; set; }

        //[ExcelColumn(Name = "客户")]
        [ExcelColumnName("客户")]

        public string Mf025 { get; set; }

        //[ExcelColumn(Name = "首次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("首次交易")]

        public DateTime? Mf026 { get; set; }

        //[ExcelColumn(Name = "末次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("末次交易")]

        public DateTime? Mf027 { get; set; }

        //[ExcelColumn(Name = "国家地区")]
        [ExcelColumnName("国家地区")]

        public string Mf028 { get; set; }

        //[ExcelColumn(Name = "州省")]
        [ExcelColumnName("州省")]

        public string Mf029 { get; set; }

        //[ExcelColumn(Name = "市")]
        [ExcelColumnName("市")]

        public string Mf030 { get; set; }

        //[ExcelColumn(Name = "县")]
        [ExcelColumnName("县")]

        public string Mf031 { get; set; }

        //[ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]

        public string Mf032 { get; set; }

        //[ExcelColumn(Name = "地址1")]
        [ExcelColumnName("地址1")]

        public string Mf033 { get; set; }

        //[ExcelColumn(Name = "地址2")]
        [ExcelColumnName("地址2")]

        public string Mf034 { get; set; }

        //[ExcelColumn(Name = "邮政编码")]
        [ExcelColumnName("邮政编码")]

        public string Mf035 { get; set; }

        //[ExcelColumn(Name = "地址号码")]
        [ExcelColumnName("地址号码")]

        public string Mf036 { get; set; }

        //[ExcelColumn(Name = "联系人")]
        [ExcelColumnName("联系人")]

        public string Mf037 { get; set; }

        //[ExcelColumn(Name = "邮件")]
        [ExcelColumnName("邮件")]

        public string Mf038 { get; set; }

        //[ExcelColumn(Name = "电话")]
        [ExcelColumnName("电话")]

        public string Mf039 { get; set; }

        //[ExcelColumn(Name = "传真")]
        [ExcelColumnName("传真")]

        public string Mf040 { get; set; }

        //[ExcelColumn(Name = "手机")]
        [ExcelColumnName("手机")]

        public string Mf041 { get; set; }

        //[ExcelColumn(Name = "帐户组")]
        [ExcelColumnName("帐户组")]

        public string Mf042 { get; set; }

        //[ExcelColumn(Name = "营业执照附件")]
        [ExcelColumnName("营业执照附件")]

        public string Mf043 { get; set; }

        //[ExcelColumn(Name = "其它附件")]
        [ExcelColumnName("其它附件")]

        public string Mf044 { get; set; }

        [Required(ErrorMessage = "交易冻结不能为空")]
        //[ExcelColumn(Name = "交易冻结")]
        [ExcelColumnName("交易冻结")]

        public int Mf045 { get; set; }

        [ExcelIgnore]

        public string Ref01 { get; set; }

        [ExcelIgnore]

        public string Ref02 { get; set; }

        [ExcelIgnore]

        public string Ref03 { get; set; }

        [ExcelIgnore]

        public decimal Ref04 { get; set; }

        [ExcelIgnore]

        public decimal Ref05 { get; set; }

        [ExcelIgnore]

        public decimal Ref06 { get; set; }

        [ExcelIgnore]

        public string Udf01 { get; set; }

        [ExcelIgnore]

        public string Udf02 { get; set; }

        [ExcelIgnore]

        public string Udf03 { get; set; }

        [ExcelIgnore]

        public string Udf04 { get; set; }

        [ExcelIgnore]

        public string Udf05 { get; set; }

        [ExcelIgnore]

        public string Udf06 { get; set; }

        [ExcelIgnore]

        public int? Udf51 { get; set; }

        [ExcelIgnore]

        public int? Udf52 { get; set; }

        [ExcelIgnore]

        public int? Udf53 { get; set; }

        [ExcelIgnore]

        public decimal Udf54 { get; set; }

        [ExcelIgnore]

        public decimal Udf55 { get; set; }

        [ExcelIgnore]

        public decimal Udf56 { get; set; }

        [ExcelIgnore]

        public int? IsDeleted { get; set; }

        [ExcelIgnore]

        public string Remark { get; set; }

        [ExcelIgnore]

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "购买组织")]
        public string Mf003Label { get; set; }
        [ExcelColumn(Name = "行业类别")]
        public string Mf004Label { get; set; }
        [ExcelColumn(Name = "企业性质")]
        public string Mf005Label { get; set; }
        [ExcelColumn(Name = "税别")]
        public string Mf013Label { get; set; }
        [ExcelColumn(Name = "采购组")]
        public string Mf015Label { get; set; }
        [ExcelColumn(Name = "交易币种")]
        public string Mf016Label { get; set; }
        [ExcelColumn(Name = "付款条件")]
        public string Mf017Label { get; set; }
        [ExcelColumn(Name = "付款方式")]
        public string Mf018Label { get; set; }
        [ExcelColumn(Name = "统驭科目")]
        public string Mf019Label { get; set; }
        [ExcelColumn(Name = "贸易条件")]
        public string Mf020Label { get; set; }
        [ExcelColumn(Name = "装运条件")]
        public string Mf021Label { get; set; }
        [ExcelColumn(Name = "运输方式")]
        public string Mf022Label { get; set; }
        [ExcelColumn(Name = "供应商等级")]
        public string Mf023Label { get; set; }
        [ExcelColumn(Name = "供应商信用")]
        public string Mf024Label { get; set; }
        [ExcelColumn(Name = "国家地区")]
        public string Mf028Label { get; set; }
        [ExcelColumn(Name = "州省")]
        public string Mf029Label { get; set; }
        [ExcelColumn(Name = "市")]
        public string Mf030Label { get; set; }
        [ExcelColumn(Name = "交易冻结")]
        public string Mf045Label { get; set; }
    }

    /// <summary>
    /// 供应商
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:53
    /// </summary>
    public class MmSupplierImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Mf002 { get; set; }

        [Required(ErrorMessage = "购买组织不能为空")]
        //[ExcelColumn(Name = "购买组织")]
        [ExcelColumnName("购买组织")]
        public string Mf003 { get; set; }

        [Required(ErrorMessage = "行业类别不能为空")]
        //[ExcelColumn(Name = "行业类别")]
        [ExcelColumnName("行业类别")]
        public string Mf004 { get; set; }

        [Required(ErrorMessage = "企业性质不能为空")]
        //[ExcelColumn(Name = "企业性质")]
        [ExcelColumnName("企业性质")]
        public string Mf005 { get; set; }

        [Required(ErrorMessage = "供应商代码不能为空")]
        //[ExcelColumn(Name = "供应商代码")]
        [ExcelColumnName("供应商代码")]
        public string Mf006 { get; set; }

        //[ExcelColumn(Name = "ABC标识")]
        [ExcelColumnName("ABC标识")]
        public string Mf007 { get; set; }

        //[ExcelColumn(Name = "供应商简称")]
        [ExcelColumnName("供应商简称")]
        public string Mf008 { get; set; }

        //[ExcelColumn(Name = "供应商名称")]
        [ExcelColumnName("供应商名称")]
        public string Mf009 { get; set; }

        //[ExcelColumn(Name = "企业法人")]
        [ExcelColumnName("企业法人")]
        public string Mf010 { get; set; }

        //[ExcelColumn(Name = "营业执照")]
        [ExcelColumnName("营业执照")]
        public string Mf011 { get; set; }

        //[ExcelColumn(Name = "税号")]
        [ExcelColumnName("税号")]
        public string Mf012 { get; set; }

        //[ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]
        public string Mf013 { get; set; }

        //[ExcelColumn(Name = "主营业务")]
        [ExcelColumnName("主营业务")]
        public string Mf014 { get; set; }

        //[ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string Mf015 { get; set; }

        //[ExcelColumn(Name = "交易币种")]
        [ExcelColumnName("交易币种")]
        public string Mf016 { get; set; }

        //[ExcelColumn(Name = "付款条件")]
        [ExcelColumnName("付款条件")]
        public string Mf017 { get; set; }

        //[ExcelColumn(Name = "付款方式")]
        [ExcelColumnName("付款方式")]
        public string Mf018 { get; set; }

        //[ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]
        public string Mf019 { get; set; }

        //[ExcelColumn(Name = "贸易条件")]
        [ExcelColumnName("贸易条件")]
        public string Mf020 { get; set; }

        //[ExcelColumn(Name = "装运条件")]
        [ExcelColumnName("装运条件")]
        public string Mf021 { get; set; }

        //[ExcelColumn(Name = "运输方式")]
        [ExcelColumnName("运输方式")]
        public string Mf022 { get; set; }

        //[ExcelColumn(Name = "供应商等级")]
        [ExcelColumnName("供应商等级")]
        public string Mf023 { get; set; }

        //[ExcelColumn(Name = "供应商信用")]
        [ExcelColumnName("供应商信用")]
        public string Mf024 { get; set; }

        //[ExcelColumn(Name = "客户")]
        [ExcelColumnName("客户")]
        public string Mf025 { get; set; }

        //[ExcelColumn(Name = "首次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("首次交易")]
        public DateTime? Mf026 { get; set; }

        //[ExcelColumn(Name = "末次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("末次交易")]
        public DateTime? Mf027 { get; set; }

        //[ExcelColumn(Name = "国家地区")]
        [ExcelColumnName("国家地区")]
        public string Mf028 { get; set; }

        //[ExcelColumn(Name = "州省")]
        [ExcelColumnName("州省")]
        public string Mf029 { get; set; }

        //[ExcelColumn(Name = "市")]
        [ExcelColumnName("市")]
        public string Mf030 { get; set; }

        //[ExcelColumn(Name = "县")]
        [ExcelColumnName("县")]
        public string Mf031 { get; set; }

        //[ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]
        public string Mf032 { get; set; }

        //[ExcelColumn(Name = "地址1")]
        [ExcelColumnName("地址1")]
        public string Mf033 { get; set; }

        //[ExcelColumn(Name = "地址2")]
        [ExcelColumnName("地址2")]
        public string Mf034 { get; set; }

        //[ExcelColumn(Name = "邮政编码")]
        [ExcelColumnName("邮政编码")]
        public string Mf035 { get; set; }

        //[ExcelColumn(Name = "地址号码")]
        [ExcelColumnName("地址号码")]
        public string Mf036 { get; set; }

        //[ExcelColumn(Name = "联系人")]
        [ExcelColumnName("联系人")]
        public string Mf037 { get; set; }

        //[ExcelColumn(Name = "邮件")]
        [ExcelColumnName("邮件")]
        public string Mf038 { get; set; }

        //[ExcelColumn(Name = "电话")]
        [ExcelColumnName("电话")]
        public string Mf039 { get; set; }

        //[ExcelColumn(Name = "传真")]
        [ExcelColumnName("传真")]
        public string Mf040 { get; set; }

        //[ExcelColumn(Name = "手机")]
        [ExcelColumnName("手机")]
        public string Mf041 { get; set; }

        //[ExcelColumn(Name = "帐户组")]
        [ExcelColumnName("帐户组")]
        public string Mf042 { get; set; }

        //[ExcelColumn(Name = "营业执照附件")]
        [ExcelColumnName("营业执照附件")]
        public string Mf043 { get; set; }

        //[ExcelColumn(Name = "其它附件")]
        [ExcelColumnName("其它附件")]
        public string Mf044 { get; set; }

        [Required(ErrorMessage = "交易冻结不能为空")]
        //[ExcelColumn(Name = "交易冻结")]
        [ExcelColumnName("交易冻结")]
        public int Mf045 { get; set; }

        [ExcelIgnore]
        public string Ref01 { get; set; }

        [ExcelIgnore]
        public string Ref02 { get; set; }

        [ExcelIgnore]
        public string Ref03 { get; set; }

        [ExcelIgnore]
        public decimal Ref04 { get; set; }

        [ExcelIgnore]
        public decimal Ref05 { get; set; }

        [ExcelIgnore]
        public decimal Ref06 { get; set; }

        [ExcelIgnore]
        public string Udf01 { get; set; }

        [ExcelIgnore]
        public string Udf02 { get; set; }

        [ExcelIgnore]
        public string Udf03 { get; set; }

        [ExcelIgnore]
        public string Udf04 { get; set; }

        [ExcelIgnore]
        public string Udf05 { get; set; }

        [ExcelIgnore]
        public string Udf06 { get; set; }

        [ExcelIgnore]
        public int? Udf51 { get; set; }

        [ExcelIgnore]
        public int? Udf52 { get; set; }

        [ExcelIgnore]
        public int? Udf53 { get; set; }

        [ExcelIgnore]
        public decimal Udf54 { get; set; }

        [ExcelIgnore]
        public decimal Udf55 { get; set; }

        [ExcelIgnore]
        public decimal Udf56 { get; set; }

        [ExcelIgnore]
        public int? IsDeleted { get; set; }

        [ExcelIgnore]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "购买组织")]
        public string Mf003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "行业类别")]
        public string Mf004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "企业性质")]
        public string Mf005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "税别")]
        public string Mf013Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "采购组")]
        public string Mf015Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "交易币种")]
        public string Mf016Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "付款条件")]
        public string Mf017Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "付款方式")]
        public string Mf018Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "统驭科目")]
        public string Mf019Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "贸易条件")]
        public string Mf020Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "装运条件")]
        public string Mf021Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "运输方式")]
        public string Mf022Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "供应商等级")]
        public string Mf023Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "供应商信用")]
        public string Mf024Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "国家地区")]
        public string Mf028Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "州省")]
        public string Mf029Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "市")]
        public string Mf030Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "交易冻结")]
        public string Mf045Label { get; set; }
    }

}