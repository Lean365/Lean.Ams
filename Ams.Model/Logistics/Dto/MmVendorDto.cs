
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 销售商
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:56
    /// </summary>
    public class MmVendorQueryDto : PagerInfo 
    {
        /// <summary>
        /// 购买组织 
        /// </summary>        
        public string Mg003 { get; set; }
        /// <summary>
        /// 行业类别 
        /// </summary>        
        public string Mg004 { get; set; }
        /// <summary>
        /// 企业性质 
        /// </summary>        
        public string Mg005 { get; set; }
        /// <summary>
        /// 供应商代码 
        /// </summary>        
        public string Mg006 { get; set; }
        /// <summary>
        /// 供应商简称 
        /// </summary>        
        public string Mg008 { get; set; }
        /// <summary>
        /// 供应商名称 
        /// </summary>        
        public string Mg010 { get; set; }
        /// <summary>
        /// 税别 
        /// </summary>        
        public string Mg015 { get; set; }
        /// <summary>
        /// 采购组 
        /// </summary>        
        public string Mg017 { get; set; }
        /// <summary>
        /// 交易币种 
        /// </summary>        
        public string Mg019 { get; set; }
        /// <summary>
        /// 付款条件 
        /// </summary>        
        public string Mg020 { get; set; }
        /// <summary>
        /// 付款方式 
        /// </summary>        
        public string Mg021 { get; set; }
        /// <summary>
        /// 统驭科目 
        /// </summary>        
        public string Mg022 { get; set; }
        /// <summary>
        /// 贸易条件 
        /// </summary>        
        public string Mg023 { get; set; }
        /// <summary>
        /// 供应商等级 
        /// </summary>        
        public string Mg026 { get; set; }
        /// <summary>
        /// 国家地区 
        /// </summary>        
        public string Mg031 { get; set; }
        /// <summary>
        /// 交易冻结 
        /// </summary>        
        public int? Mg051 { get; set; }
    }

    /// <summary>
    /// 销售商
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:56
    /// </summary>
    public class MmVendorDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]

        public string Mg002 { get; set; }

        [Required(ErrorMessage = "购买组织不能为空")]
        //[ExcelColumn(Name = "购买组织")]
        [ExcelColumnName("购买组织")]

        public string Mg003 { get; set; }

        [Required(ErrorMessage = "行业类别不能为空")]
        //[ExcelColumn(Name = "行业类别")]
        [ExcelColumnName("行业类别")]

        public string Mg004 { get; set; }

        [Required(ErrorMessage = "企业性质不能为空")]
        //[ExcelColumn(Name = "企业性质")]
        [ExcelColumnName("企业性质")]

        public string Mg005 { get; set; }

        [Required(ErrorMessage = "供应商代码不能为空")]
        //[ExcelColumn(Name = "供应商代码")]
        [ExcelColumnName("供应商代码")]

        public string Mg006 { get; set; }

        //[ExcelColumn(Name = "ABC标识")]
        [ExcelColumnName("ABC标识")]

        public string Mg007 { get; set; }

        //[ExcelColumn(Name = "供应商简称")]
        [ExcelColumnName("供应商简称")]

        public string Mg008 { get; set; }

        //[ExcelColumn(Name = "供应商名称")]
        [ExcelColumnName("供应商名称")]

        public string Mg010 { get; set; }

        //[ExcelColumn(Name = "企业法人")]
        [ExcelColumnName("企业法人")]

        public string Mg012 { get; set; }

        //[ExcelColumn(Name = "营业执照")]
        [ExcelColumnName("营业执照")]

        public string Mg013 { get; set; }

        //[ExcelColumn(Name = "税号")]
        [ExcelColumnName("税号")]

        public string Mg014 { get; set; }

        //[ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]

        public string Mg015 { get; set; }

        //[ExcelColumn(Name = "主营业务")]
        [ExcelColumnName("主营业务")]

        public string Mg016 { get; set; }

        //[ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]

        public string Mg017 { get; set; }

        //[ExcelColumn(Name = "交易币种")]
        [ExcelColumnName("交易币种")]

        public string Mg019 { get; set; }

        //[ExcelColumn(Name = "付款条件")]
        [ExcelColumnName("付款条件")]

        public string Mg020 { get; set; }

        //[ExcelColumn(Name = "付款方式")]
        [ExcelColumnName("付款方式")]

        public string Mg021 { get; set; }

        //[ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]

        public string Mg022 { get; set; }

        //[ExcelColumn(Name = "贸易条件")]
        [ExcelColumnName("贸易条件")]

        public string Mg023 { get; set; }

        //[ExcelColumn(Name = "装运条件")]
        [ExcelColumnName("装运条件")]

        public string Mg024 { get; set; }

        //[ExcelColumn(Name = "运输方式")]
        [ExcelColumnName("运输方式")]

        public string Mg025 { get; set; }

        //[ExcelColumn(Name = "供应商等级")]
        [ExcelColumnName("供应商等级")]

        public string Mg026 { get; set; }

        //[ExcelColumn(Name = "供应商信用")]
        [ExcelColumnName("供应商信用")]

        public string Mg027 { get; set; }

        //[ExcelColumn(Name = "客户")]
        [ExcelColumnName("客户")]

        public string Mg028 { get; set; }

        //[ExcelColumn(Name = "首次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("首次交易")]

        public DateTime? Mg029 { get; set; }

        //[ExcelColumn(Name = "末次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("末次交易")]

        public DateTime? Mg030 { get; set; }

        //[ExcelColumn(Name = "国家地区")]
        [ExcelColumnName("国家地区")]

        public string Mg031 { get; set; }

        //[ExcelColumn(Name = "州省")]
        [ExcelColumnName("州省")]

        public string Mg032 { get; set; }

        //[ExcelColumn(Name = "市")]
        [ExcelColumnName("市")]

        public string Mg033 { get; set; }

        //[ExcelColumn(Name = "县")]
        [ExcelColumnName("县")]

        public string Mg034 { get; set; }

        //[ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]

        public string Mg035 { get; set; }

        //[ExcelColumn(Name = "地址1")]
        [ExcelColumnName("地址1")]

        public string Mg037 { get; set; }

        //[ExcelColumn(Name = "地址2")]
        [ExcelColumnName("地址2")]

        public string Mg039 { get; set; }

        //[ExcelColumn(Name = "邮政编码")]
        [ExcelColumnName("邮政编码")]

        public string Mg041 { get; set; }

        //[ExcelColumn(Name = "地址号码")]
        [ExcelColumnName("地址号码")]

        public string Mg042 { get; set; }

        //[ExcelColumn(Name = "联系人")]
        [ExcelColumnName("联系人")]

        public string Mg043 { get; set; }

        //[ExcelColumn(Name = "邮件")]
        [ExcelColumnName("邮件")]

        public string Mg044 { get; set; }

        //[ExcelColumn(Name = "电话")]
        [ExcelColumnName("电话")]

        public string Mg045 { get; set; }

        //[ExcelColumn(Name = "传真")]
        [ExcelColumnName("传真")]

        public string Mg046 { get; set; }

        //[ExcelColumn(Name = "手机")]
        [ExcelColumnName("手机")]

        public string Mg047 { get; set; }

        //[ExcelColumn(Name = "帐户组")]
        [ExcelColumnName("帐户组")]

        public string Mg048 { get; set; }

        //[ExcelColumn(Name = "营业执照附件")]
        [ExcelColumnName("营业执照附件")]

        public string Mg049 { get; set; }

        //[ExcelColumn(Name = "其它附件")]
        [ExcelColumnName("其它附件")]

        public string Mg050 { get; set; }

        [Required(ErrorMessage = "交易冻结不能为空")]
        //[ExcelColumn(Name = "交易冻结")]
        [ExcelColumnName("交易冻结")]

        public int Mg051 { get; set; }

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
        public string Mg003Label { get; set; }
        [ExcelColumn(Name = "行业类别")]
        public string Mg004Label { get; set; }
        [ExcelColumn(Name = "企业性质")]
        public string Mg005Label { get; set; }
        [ExcelColumn(Name = "税别")]
        public string Mg015Label { get; set; }
        [ExcelColumn(Name = "采购组")]
        public string Mg017Label { get; set; }
        [ExcelColumn(Name = "交易币种")]
        public string Mg019Label { get; set; }
        [ExcelColumn(Name = "付款条件")]
        public string Mg020Label { get; set; }
        [ExcelColumn(Name = "付款方式")]
        public string Mg021Label { get; set; }
        [ExcelColumn(Name = "统驭科目")]
        public string Mg022Label { get; set; }
        [ExcelColumn(Name = "贸易条件")]
        public string Mg023Label { get; set; }
        [ExcelColumn(Name = "装运条件")]
        public string Mg024Label { get; set; }
        [ExcelColumn(Name = "运输方式")]
        public string Mg025Label { get; set; }
        [ExcelColumn(Name = "供应商等级")]
        public string Mg026Label { get; set; }
        [ExcelColumn(Name = "供应商信用")]
        public string Mg027Label { get; set; }
        [ExcelColumn(Name = "国家地区")]
        public string Mg031Label { get; set; }
        [ExcelColumn(Name = "州省")]
        public string Mg032Label { get; set; }
        [ExcelColumn(Name = "市")]
        public string Mg033Label { get; set; }
        [ExcelColumn(Name = "交易冻结")]
        public string Mg051Label { get; set; }
    }

    /// <summary>
    /// 销售商
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:56
    /// </summary>
    public class MmVendorImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Mg002 { get; set; }

        [Required(ErrorMessage = "购买组织不能为空")]
        //[ExcelColumn(Name = "购买组织")]
        [ExcelColumnName("购买组织")]
        public string Mg003 { get; set; }

        [Required(ErrorMessage = "行业类别不能为空")]
        //[ExcelColumn(Name = "行业类别")]
        [ExcelColumnName("行业类别")]
        public string Mg004 { get; set; }

        [Required(ErrorMessage = "企业性质不能为空")]
        //[ExcelColumn(Name = "企业性质")]
        [ExcelColumnName("企业性质")]
        public string Mg005 { get; set; }

        [Required(ErrorMessage = "供应商代码不能为空")]
        //[ExcelColumn(Name = "供应商代码")]
        [ExcelColumnName("供应商代码")]
        public string Mg006 { get; set; }

        //[ExcelColumn(Name = "ABC标识")]
        [ExcelColumnName("ABC标识")]
        public string Mg007 { get; set; }

        //[ExcelColumn(Name = "供应商简称")]
        [ExcelColumnName("供应商简称")]
        public string Mg008 { get; set; }

        //[ExcelColumn(Name = "供应商名称")]
        [ExcelColumnName("供应商名称")]
        public string Mg010 { get; set; }

        //[ExcelColumn(Name = "企业法人")]
        [ExcelColumnName("企业法人")]
        public string Mg012 { get; set; }

        //[ExcelColumn(Name = "营业执照")]
        [ExcelColumnName("营业执照")]
        public string Mg013 { get; set; }

        //[ExcelColumn(Name = "税号")]
        [ExcelColumnName("税号")]
        public string Mg014 { get; set; }

        //[ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]
        public string Mg015 { get; set; }

        //[ExcelColumn(Name = "主营业务")]
        [ExcelColumnName("主营业务")]
        public string Mg016 { get; set; }

        //[ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string Mg017 { get; set; }

        //[ExcelColumn(Name = "交易币种")]
        [ExcelColumnName("交易币种")]
        public string Mg019 { get; set; }

        //[ExcelColumn(Name = "付款条件")]
        [ExcelColumnName("付款条件")]
        public string Mg020 { get; set; }

        //[ExcelColumn(Name = "付款方式")]
        [ExcelColumnName("付款方式")]
        public string Mg021 { get; set; }

        //[ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]
        public string Mg022 { get; set; }

        //[ExcelColumn(Name = "贸易条件")]
        [ExcelColumnName("贸易条件")]
        public string Mg023 { get; set; }

        //[ExcelColumn(Name = "装运条件")]
        [ExcelColumnName("装运条件")]
        public string Mg024 { get; set; }

        //[ExcelColumn(Name = "运输方式")]
        [ExcelColumnName("运输方式")]
        public string Mg025 { get; set; }

        //[ExcelColumn(Name = "供应商等级")]
        [ExcelColumnName("供应商等级")]
        public string Mg026 { get; set; }

        //[ExcelColumn(Name = "供应商信用")]
        [ExcelColumnName("供应商信用")]
        public string Mg027 { get; set; }

        //[ExcelColumn(Name = "客户")]
        [ExcelColumnName("客户")]
        public string Mg028 { get; set; }

        //[ExcelColumn(Name = "首次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("首次交易")]
        public DateTime? Mg029 { get; set; }

        //[ExcelColumn(Name = "末次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("末次交易")]
        public DateTime? Mg030 { get; set; }

        //[ExcelColumn(Name = "国家地区")]
        [ExcelColumnName("国家地区")]
        public string Mg031 { get; set; }

        //[ExcelColumn(Name = "州省")]
        [ExcelColumnName("州省")]
        public string Mg032 { get; set; }

        //[ExcelColumn(Name = "市")]
        [ExcelColumnName("市")]
        public string Mg033 { get; set; }

        //[ExcelColumn(Name = "县")]
        [ExcelColumnName("县")]
        public string Mg034 { get; set; }

        //[ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]
        public string Mg035 { get; set; }

        //[ExcelColumn(Name = "地址1")]
        [ExcelColumnName("地址1")]
        public string Mg037 { get; set; }

        //[ExcelColumn(Name = "地址2")]
        [ExcelColumnName("地址2")]
        public string Mg039 { get; set; }

        //[ExcelColumn(Name = "邮政编码")]
        [ExcelColumnName("邮政编码")]
        public string Mg041 { get; set; }

        //[ExcelColumn(Name = "地址号码")]
        [ExcelColumnName("地址号码")]
        public string Mg042 { get; set; }

        //[ExcelColumn(Name = "联系人")]
        [ExcelColumnName("联系人")]
        public string Mg043 { get; set; }

        //[ExcelColumn(Name = "邮件")]
        [ExcelColumnName("邮件")]
        public string Mg044 { get; set; }

        //[ExcelColumn(Name = "电话")]
        [ExcelColumnName("电话")]
        public string Mg045 { get; set; }

        //[ExcelColumn(Name = "传真")]
        [ExcelColumnName("传真")]
        public string Mg046 { get; set; }

        //[ExcelColumn(Name = "手机")]
        [ExcelColumnName("手机")]
        public string Mg047 { get; set; }

        //[ExcelColumn(Name = "帐户组")]
        [ExcelColumnName("帐户组")]
        public string Mg048 { get; set; }

        //[ExcelColumn(Name = "营业执照附件")]
        [ExcelColumnName("营业执照附件")]
        public string Mg049 { get; set; }

        //[ExcelColumn(Name = "其它附件")]
        [ExcelColumnName("其它附件")]
        public string Mg050 { get; set; }

        [Required(ErrorMessage = "交易冻结不能为空")]
        //[ExcelColumn(Name = "交易冻结")]
        [ExcelColumnName("交易冻结")]
        public int Mg051 { get; set; }

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
        public string Mg003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "行业类别")]
        public string Mg004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "企业性质")]
        public string Mg005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "税别")]
        public string Mg015Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "采购组")]
        public string Mg017Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "交易币种")]
        public string Mg019Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "付款条件")]
        public string Mg020Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "付款方式")]
        public string Mg021Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "统驭科目")]
        public string Mg022Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "贸易条件")]
        public string Mg023Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "装运条件")]
        public string Mg024Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "运输方式")]
        public string Mg025Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "供应商等级")]
        public string Mg026Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "供应商信用")]
        public string Mg027Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "国家地区")]
        public string Mg031Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "州省")]
        public string Mg032Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "市")]
        public string Mg033Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "交易冻结")]
        public string Mg051Label { get; set; }
    }

}