
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 客户
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/26 15:01:09
    /// </summary>
    public class SdClientQueryDto : PagerInfo 
    {
        /// <summary>
        /// 销售组织 
        /// </summary>        
        public string Ma003 { get; set; }
        /// <summary>
        /// 行业类别 
        /// </summary>        
        public string Ma004 { get; set; }
        /// <summary>
        /// 企业性质 
        /// </summary>        
        public string Ma005 { get; set; }
        /// <summary>
        /// 客户代码 
        /// </summary>        
        public string Ma006 { get; set; }
        /// <summary>
        /// 客户简称 
        /// </summary>        
        public string Ma007 { get; set; }
        /// <summary>
        /// 客户名称 
        /// </summary>        
        public string Ma008 { get; set; }
        /// <summary>
        /// 税别 
        /// </summary>        
        public string Ma012 { get; set; }
        /// <summary>
        /// 交易币种 
        /// </summary>        
        public string Ma014 { get; set; }
        /// <summary>
        /// 付款条件 
        /// </summary>        
        public string Ma015 { get; set; }
        /// <summary>
        /// 付款方式 
        /// </summary>        
        public string Ma016 { get; set; }
        /// <summary>
        /// 统驭科目 
        /// </summary>        
        public string Ma017 { get; set; }
        /// <summary>
        /// 客户等级 
        /// </summary>        
        public string Ma020 { get; set; }
        /// <summary>
        /// 供应商 
        /// </summary>        
        public string Ma024 { get; set; }
        /// <summary>
        /// 国家地区 
        /// </summary>        
        public string Ma025 { get; set; }
        /// <summary>
        /// 冻结标记 
        /// </summary>        
        public int? Ma039 { get; set; }
    }

    /// <summary>
    /// 客户
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/26 15:01:09
    /// </summary>
    public class SdClientDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]

        public string Ma002 { get; set; }

        [Required(ErrorMessage = "销售组织不能为空")]
        //[ExcelColumn(Name = "销售组织")]
        [ExcelColumnName("销售组织")]

        public string Ma003 { get; set; }

        [Required(ErrorMessage = "行业类别不能为空")]
        //[ExcelColumn(Name = "行业类别")]
        [ExcelColumnName("行业类别")]

        public string Ma004 { get; set; }

        [Required(ErrorMessage = "企业性质不能为空")]
        //[ExcelColumn(Name = "企业性质")]
        [ExcelColumnName("企业性质")]

        public string Ma005 { get; set; }

        [Required(ErrorMessage = "客户代码不能为空")]
        //[ExcelColumn(Name = "客户代码")]
        [ExcelColumnName("客户代码")]

        public string Ma006 { get; set; }

        //[ExcelColumn(Name = "客户简称")]
        [ExcelColumnName("客户简称")]

        public string Ma007 { get; set; }

        //[ExcelColumn(Name = "客户名称")]
        [ExcelColumnName("客户名称")]

        public string Ma008 { get; set; }

        //[ExcelColumn(Name = "企业法人")]
        [ExcelColumnName("企业法人")]

        public string Ma009 { get; set; }

        //[ExcelColumn(Name = "税号")]
        [ExcelColumnName("税号")]

        public string Ma010 { get; set; }

        //[ExcelColumn(Name = "营业执照")]
        [ExcelColumnName("营业执照")]

        public string Ma011 { get; set; }

        //[ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]

        public string Ma012 { get; set; }

        //[ExcelColumn(Name = "主营业务")]
        [ExcelColumnName("主营业务")]

        public string Ma013 { get; set; }

        //[ExcelColumn(Name = "交易币种")]
        [ExcelColumnName("交易币种")]

        public string Ma014 { get; set; }

        //[ExcelColumn(Name = "付款条件")]
        [ExcelColumnName("付款条件")]

        public string Ma015 { get; set; }

        //[ExcelColumn(Name = "付款方式")]
        [ExcelColumnName("付款方式")]

        public string Ma016 { get; set; }

        //[ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]

        public string Ma017 { get; set; }

        //[ExcelColumn(Name = "贸易条件")]
        [ExcelColumnName("贸易条件")]

        public string Ma018 { get; set; }

        //[ExcelColumn(Name = "装运条件")]
        [ExcelColumnName("装运条件")]

        public string Ma019 { get; set; }

        //[ExcelColumn(Name = "客户等级")]
        [ExcelColumnName("客户等级")]

        public string Ma020 { get; set; }

        //[ExcelColumn(Name = "客户信用")]
        [ExcelColumnName("客户信用")]

        public string Ma021 { get; set; }

        //[ExcelColumn(Name = "首次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("首次交易")]

        public DateTime? Ma022 { get; set; }

        //[ExcelColumn(Name = "最近交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("最近交易")]

        public DateTime? Ma023 { get; set; }

        //[ExcelColumn(Name = "供应商")]
        [ExcelColumnName("供应商")]

        public string Ma024 { get; set; }

        //[ExcelColumn(Name = "国家地区")]
        [ExcelColumnName("国家地区")]

        public string Ma025 { get; set; }

        //[ExcelColumn(Name = "州省")]
        [ExcelColumnName("州省")]

        public string Ma026 { get; set; }

        //[ExcelColumn(Name = "市")]
        [ExcelColumnName("市")]

        public string Ma027 { get; set; }

        //[ExcelColumn(Name = "县")]
        [ExcelColumnName("县")]

        public string Ma028 { get; set; }

        //[ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]

        public string Ma029 { get; set; }

        //[ExcelColumn(Name = "地址1")]
        [ExcelColumnName("地址1")]

        public string Ma030 { get; set; }

        //[ExcelColumn(Name = "地址2")]
        [ExcelColumnName("地址2")]

        public string Ma031 { get; set; }

        //[ExcelColumn(Name = "邮政编码")]
        [ExcelColumnName("邮政编码")]

        public string Ma032 { get; set; }

        //[ExcelColumn(Name = "地址号码")]
        [ExcelColumnName("地址号码")]

        public string Ma033 { get; set; }

        //[ExcelColumn(Name = "联系人")]
        [ExcelColumnName("联系人")]

        public string Ma034 { get; set; }

        //[ExcelColumn(Name = "电邮")]
        [ExcelColumnName("电邮")]

        public string Ma035 { get; set; }

        //[ExcelColumn(Name = "电话")]
        [ExcelColumnName("电话")]

        public string Ma036 { get; set; }

        //[ExcelColumn(Name = "传真")]
        [ExcelColumnName("传真")]

        public string Ma037 { get; set; }

        //[ExcelColumn(Name = "手机")]
        [ExcelColumnName("手机")]

        public string Ma038 { get; set; }

        [Required(ErrorMessage = "冻结标记不能为空")]
        //[ExcelColumn(Name = "冻结标记")]
        [ExcelColumnName("冻结标记")]

        public int Ma039 { get; set; }

        //[ExcelColumn(Name = "营业执照附件")]
        [ExcelColumnName("营业执照附件")]

        public string Ma040 { get; set; }

        //[ExcelColumn(Name = "其它附件")]
        [ExcelColumnName("其它附件")]

        public string Ma041 { get; set; }

        [ExcelIgnore]

        public string Remark { get; set; }

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

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "销售组织")]
        public string Ma003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "行业类别")]
        public string Ma004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "企业性质")]
        public string Ma005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "税别")]
        public string Ma012Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "交易币种")]
        public string Ma014Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "付款条件")]
        public string Ma015Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "付款方式")]
        public string Ma016Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "统驭科目")]
        public string Ma017Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "贸易条件")]
        public string Ma018Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "装运条件")]
        public string Ma019Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "客户等级")]
        public string Ma020Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "客户信用")]
        public string Ma021Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "国家地区")]
        public string Ma025Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "州省")]
        public string Ma026Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "市")]
        public string Ma027Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "冻结标记")]
        public string Ma039Label { get; set; }
    }

    /// <summary>
    /// 客户
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/26 15:01:09
    /// </summary>
    public class SdClientImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Ma002 { get; set; }

        [Required(ErrorMessage = "销售组织不能为空")]
        //[ExcelColumn(Name = "销售组织")]
        [ExcelColumnName("销售组织")]
        public string Ma003 { get; set; }

        [Required(ErrorMessage = "行业类别不能为空")]
        //[ExcelColumn(Name = "行业类别")]
        [ExcelColumnName("行业类别")]
        public string Ma004 { get; set; }

        [Required(ErrorMessage = "企业性质不能为空")]
        //[ExcelColumn(Name = "企业性质")]
        [ExcelColumnName("企业性质")]
        public string Ma005 { get; set; }

        [Required(ErrorMessage = "客户代码不能为空")]
        //[ExcelColumn(Name = "客户代码")]
        [ExcelColumnName("客户代码")]
        public string Ma006 { get; set; }

        //[ExcelColumn(Name = "客户简称")]
        [ExcelColumnName("客户简称")]
        public string Ma007 { get; set; }

        //[ExcelColumn(Name = "客户名称")]
        [ExcelColumnName("客户名称")]
        public string Ma008 { get; set; }

        //[ExcelColumn(Name = "企业法人")]
        [ExcelColumnName("企业法人")]
        public string Ma009 { get; set; }

        //[ExcelColumn(Name = "税号")]
        [ExcelColumnName("税号")]
        public string Ma010 { get; set; }

        //[ExcelColumn(Name = "营业执照")]
        [ExcelColumnName("营业执照")]
        public string Ma011 { get; set; }

        //[ExcelColumn(Name = "税别")]
        [ExcelColumnName("税别")]
        public string Ma012 { get; set; }

        //[ExcelColumn(Name = "主营业务")]
        [ExcelColumnName("主营业务")]
        public string Ma013 { get; set; }

        //[ExcelColumn(Name = "交易币种")]
        [ExcelColumnName("交易币种")]
        public string Ma014 { get; set; }

        //[ExcelColumn(Name = "付款条件")]
        [ExcelColumnName("付款条件")]
        public string Ma015 { get; set; }

        //[ExcelColumn(Name = "付款方式")]
        [ExcelColumnName("付款方式")]
        public string Ma016 { get; set; }

        //[ExcelColumn(Name = "统驭科目")]
        [ExcelColumnName("统驭科目")]
        public string Ma017 { get; set; }

        //[ExcelColumn(Name = "贸易条件")]
        [ExcelColumnName("贸易条件")]
        public string Ma018 { get; set; }

        //[ExcelColumn(Name = "装运条件")]
        [ExcelColumnName("装运条件")]
        public string Ma019 { get; set; }

        //[ExcelColumn(Name = "客户等级")]
        [ExcelColumnName("客户等级")]
        public string Ma020 { get; set; }

        //[ExcelColumn(Name = "客户信用")]
        [ExcelColumnName("客户信用")]
        public string Ma021 { get; set; }

        //[ExcelColumn(Name = "首次交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("首次交易")]
        public DateTime? Ma022 { get; set; }

        //[ExcelColumn(Name = "最近交易", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("最近交易")]
        public DateTime? Ma023 { get; set; }

        //[ExcelColumn(Name = "供应商")]
        [ExcelColumnName("供应商")]
        public string Ma024 { get; set; }

        //[ExcelColumn(Name = "国家地区")]
        [ExcelColumnName("国家地区")]
        public string Ma025 { get; set; }

        //[ExcelColumn(Name = "州省")]
        [ExcelColumnName("州省")]
        public string Ma026 { get; set; }

        //[ExcelColumn(Name = "市")]
        [ExcelColumnName("市")]
        public string Ma027 { get; set; }

        //[ExcelColumn(Name = "县")]
        [ExcelColumnName("县")]
        public string Ma028 { get; set; }

        //[ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]
        public string Ma029 { get; set; }

        //[ExcelColumn(Name = "地址1")]
        [ExcelColumnName("地址1")]
        public string Ma030 { get; set; }

        //[ExcelColumn(Name = "地址2")]
        [ExcelColumnName("地址2")]
        public string Ma031 { get; set; }

        //[ExcelColumn(Name = "邮政编码")]
        [ExcelColumnName("邮政编码")]
        public string Ma032 { get; set; }

        //[ExcelColumn(Name = "地址号码")]
        [ExcelColumnName("地址号码")]
        public string Ma033 { get; set; }

        //[ExcelColumn(Name = "联系人")]
        [ExcelColumnName("联系人")]
        public string Ma034 { get; set; }

        //[ExcelColumn(Name = "电邮")]
        [ExcelColumnName("电邮")]
        public string Ma035 { get; set; }

        //[ExcelColumn(Name = "电话")]
        [ExcelColumnName("电话")]
        public string Ma036 { get; set; }

        //[ExcelColumn(Name = "传真")]
        [ExcelColumnName("传真")]
        public string Ma037 { get; set; }

        //[ExcelColumn(Name = "手机")]
        [ExcelColumnName("手机")]
        public string Ma038 { get; set; }

        [Required(ErrorMessage = "冻结标记不能为空")]
        //[ExcelColumn(Name = "冻结标记")]
        [ExcelColumnName("冻结标记")]
        public int Ma039 { get; set; }

        //[ExcelColumn(Name = "营业执照附件")]
        [ExcelColumnName("营业执照附件")]
        public string Ma040 { get; set; }

        //[ExcelColumn(Name = "其它附件")]
        [ExcelColumnName("其它附件")]
        public string Ma041 { get; set; }

        [ExcelIgnore]
        public string Remark { get; set; }

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
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "销售组织")]
        public string Ma003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "行业类别")]
        public string Ma004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "企业性质")]
        public string Ma005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "税别")]
        public string Ma012Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "交易币种")]
        public string Ma014Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "付款条件")]
        public string Ma015Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "付款方式")]
        public string Ma016Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "统驭科目")]
        public string Ma017Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "贸易条件")]
        public string Ma018Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "装运条件")]
        public string Ma019Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "客户等级")]
        public string Ma020Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "客户信用")]
        public string Ma021Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "国家地区")]
        public string Ma025Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "州省")]
        public string Ma026Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "市")]
        public string Ma027Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "冻结标记")]
        public string Ma039Label { get; set; }
    }

}