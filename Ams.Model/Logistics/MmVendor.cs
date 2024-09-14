namespace Ams.Model.Logistics
{
    /// <summary>
    /// 销售商
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:56
    /// </summary>
    [SugarTable("mm_vendor", "销售商")]
    public class MmVendor : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 集团
        /// </summary>
        [SugarColumn(ColumnName = "Mg002", ColumnDescription = "集团", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mg002 { get; set; }

        /// <summary>
        /// 购买组织
        /// </summary>
        [SugarColumn(ColumnName = "Mg003", ColumnDescription = "购买组织", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mg003 { get; set; }

        /// <summary>
        /// 行业类别
        /// </summary>
        [SugarColumn(ColumnName = "Mg004", ColumnDescription = "行业类别", Length = 1, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mg004 { get; set; }

        /// <summary>
        /// 企业性质
        /// </summary>
        [SugarColumn(ColumnName = "Mg005", ColumnDescription = "企业性质", Length = 1, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mg005 { get; set; }

        /// <summary>
        /// 供应商代码
        /// </summary>
        [SugarColumn(ColumnName = "Mg006", ColumnDescription = "供应商代码", Length = 10, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mg006 { get; set; }

        /// <summary>
        /// ABC标识
        /// </summary>
        [SugarColumn(ColumnName = "Mg007", ColumnDescription = "ABC标识", Length = 20)]
        public string Mg007 { get; set; }

        /// <summary>
        /// 供应商简称
        /// </summary>
        [SugarColumn(ColumnName = "Mg008", ColumnDescription = "供应商简称", Length = 40, ColumnDataType = "NVARCHAR")]
        public string Mg008 { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [SugarColumn(ColumnName = "Mg010", ColumnDescription = "供应商名称", Length = 200, ColumnDataType = "NVARCHAR")]
        public string Mg010 { get; set; }

        /// <summary>
        /// 企业法人
        /// </summary>
        [SugarColumn(ColumnName = "Mg012", ColumnDescription = "企业法人", Length = 50)]
        public string Mg012 { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        [SugarColumn(ColumnName = "Mg013", ColumnDescription = "营业执照", Length = 100)]
        public string Mg013 { get; set; }

        /// <summary>
        /// 税号
        /// </summary>
        [SugarColumn(ColumnName = "Mg014", ColumnDescription = "税号", Length = 100)]
        public string Mg014 { get; set; }

        /// <summary>
        /// 税别
        /// </summary>
        [SugarColumn(ColumnName = "Mg015", ColumnDescription = "税别", Length = 2)]
        public string Mg015 { get; set; }

        /// <summary>
        /// 主营业务
        /// </summary>
        [SugarColumn(ColumnName = "Mg016", ColumnDescription = "主营业务", Length = 200)]
        public string Mg016 { get; set; }

        /// <summary>
        /// 采购组
        /// </summary>
        [SugarColumn(ColumnName = "Mg017", ColumnDescription = "采购组", Length = 6, ColumnDataType = "NVARCHAR")]
        public string Mg017 { get; set; }

        /// <summary>
        /// 交易币种
        /// </summary>
        [SugarColumn(ColumnName = "Mg019", ColumnDescription = "交易币种", Length = 3)]
        public string Mg019 { get; set; }

        /// <summary>
        /// 付款条件
        /// </summary>
        [SugarColumn(ColumnName = "Mg020", ColumnDescription = "付款条件", Length = 4)]
        public string Mg020 { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        [SugarColumn(ColumnName = "Mg021", ColumnDescription = "付款方式", Length = 4)]
        public string Mg021 { get; set; }

        /// <summary>
        /// 统驭科目
        /// </summary>
        [SugarColumn(ColumnName = "Mg022", ColumnDescription = "统驭科目", Length = 6)]
        public string Mg022 { get; set; }

        /// <summary>
        /// 贸易条件
        /// </summary>
        [SugarColumn(ColumnName = "Mg023", ColumnDescription = "贸易条件", Length = 40)]
        public string Mg023 { get; set; }

        /// <summary>
        /// 装运条件
        /// </summary>
        [SugarColumn(ColumnName = "Mg024", ColumnDescription = "装运条件", Length = 3)]
        public string Mg024 { get; set; }

        /// <summary>
        /// 运输方式
        /// </summary>
        [SugarColumn(ColumnName = "Mg025", ColumnDescription = "运输方式", Length = 1)]
        public string Mg025 { get; set; }

        /// <summary>
        /// 供应商等级
        /// </summary>
        [SugarColumn(ColumnName = "Mg026", ColumnDescription = "供应商等级", Length = 1)]
        public string Mg026 { get; set; }

        /// <summary>
        /// 供应商信用
        /// </summary>
        [SugarColumn(ColumnName = "Mg027", ColumnDescription = "供应商信用", Length = 1)]
        public string Mg027 { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        [SugarColumn(ColumnName = "Mg028", ColumnDescription = "客户", Length = 8)]
        public string Mg028 { get; set; }

        /// <summary>
        /// 首次交易
        /// </summary>
        public DateTime? Mg029 { get; set; }

        /// <summary>
        /// 末次交易
        /// </summary>
        public DateTime? Mg030 { get; set; }

        /// <summary>
        /// 国家地区
        /// </summary>
        [SugarColumn(ColumnName = "Mg031", ColumnDescription = "国家地区", Length = 2)]
        public string Mg031 { get; set; }

        /// <summary>
        /// 州省
        /// </summary>
        [SugarColumn(ColumnName = "Mg032", ColumnDescription = "州省", Length = 40)]
        public string Mg032 { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [SugarColumn(ColumnName = "Mg033", ColumnDescription = "市", Length = 40)]
        public string Mg033 { get; set; }

        /// <summary>
        /// 县
        /// </summary>
        [SugarColumn(ColumnName = "Mg034", ColumnDescription = "县", Length = 40)]
        public string Mg034 { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(ColumnName = "Mg035", ColumnDescription = "地址", Length = 400, ColumnDataType = "NVARCHAR")]
        public string Mg035 { get; set; }

        /// <summary>
        /// 地址1
        /// </summary>
        [SugarColumn(ColumnName = "Mg037", ColumnDescription = "地址1", Length = 800, ColumnDataType = "NVARCHAR")]
        public string Mg037 { get; set; }

        /// <summary>
        /// 地址2
        /// </summary>
        [SugarColumn(ColumnName = "Mg039", ColumnDescription = "地址2", Length = 1200, ColumnDataType = "NVARCHAR")]
        public string Mg039 { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        [SugarColumn(ColumnName = "Mg041", ColumnDescription = "邮政编码", Length = 20)]
        public string Mg041 { get; set; }

        /// <summary>
        /// 地址号码
        /// </summary>
        [SugarColumn(ColumnName = "Mg042", ColumnDescription = "地址号码", Length = 20)]
        public string Mg042 { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [SugarColumn(ColumnName = "Mg043", ColumnDescription = "联系人", Length = 200)]
        public string Mg043 { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        [SugarColumn(ColumnName = "Mg044", ColumnDescription = "邮件", Length = 50)]
        public string Mg044 { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [SugarColumn(ColumnName = "Mg045", ColumnDescription = "电话", Length = 160)]
        public string Mg045 { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [SugarColumn(ColumnName = "Mg046", ColumnDescription = "传真", Length = 160)]
        public string Mg046 { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [SugarColumn(ColumnName = "Mg047", ColumnDescription = "手机", Length = 160)]
        public string Mg047 { get; set; }

        /// <summary>
        /// 帐户组
        /// </summary>
        [SugarColumn(ColumnName = "Mg048", ColumnDescription = "帐户组", Length = 8)]
        public string Mg048 { get; set; }

        /// <summary>
        /// 营业执照附件
        /// </summary>
        [SugarColumn(ColumnName = "Mg049", ColumnDescription = "营业执照附件", Length = 255)]
        public string Mg049 { get; set; }

        /// <summary>
        /// 其它附件
        /// </summary>
        [SugarColumn(ColumnName = "Mg050", ColumnDescription = "其它附件", Length = 255)]
        public string Mg050 { get; set; }

        /// <summary>
        /// 交易冻结
        /// </summary>
        [SugarColumn(ColumnName = "Mg051", ColumnDescription = "交易冻结", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg051 { get; set; }
    }
}