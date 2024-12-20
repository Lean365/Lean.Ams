namespace Ams.Model.Logistics
{
    /// <summary>
    /// 供应商
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:38:53
    /// </summary>
    [SugarTable("mm_supplier", "供应商")]
    public class MmSupplier : SysBase
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
        [SugarColumn(ColumnName = "Mf002", ColumnDescription = "集团", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mf002 { get; set; }

        /// <summary>
        /// 购买组织
        /// </summary>
        [SugarColumn(ColumnName = "Mf003", ColumnDescription = "购买组织", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mf003 { get; set; }

        /// <summary>
        /// 行业类别
        /// </summary>
        [SugarColumn(ColumnName = "Mf004", ColumnDescription = "行业类别", Length = 1, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mf004 { get; set; }

        /// <summary>
        /// 企业性质
        /// </summary>
        [SugarColumn(ColumnName = "Mf005", ColumnDescription = "企业性质", Length = 1, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mf005 { get; set; }

        /// <summary>
        /// 供应商代码
        /// </summary>
        [SugarColumn(ColumnName = "Mf006", ColumnDescription = "供应商代码", Length = 10, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mf006 { get; set; }

        /// <summary>
        /// ABC标识
        /// </summary>
        [SugarColumn(ColumnName = "Mf007", ColumnDescription = "ABC标识", Length = 20)]
        public string Mf007 { get; set; }

        /// <summary>
        /// 供应商简称
        /// </summary>
        [SugarColumn(ColumnName = "Mf008", ColumnDescription = "供应商简称", Length = 40, ColumnDataType = "NVARCHAR")]
        public string Mf008 { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        [SugarColumn(ColumnName = "Mf009", ColumnDescription = "供应商名称", Length = 200, ColumnDataType = "NVARCHAR")]
        public string Mf009 { get; set; }

        /// <summary>
        /// 企业法人
        /// </summary>
        [SugarColumn(ColumnName = "Mf010", ColumnDescription = "企业法人", Length = 50)]
        public string Mf010 { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        [SugarColumn(ColumnName = "Mf011", ColumnDescription = "营业执照", Length = 100)]
        public string Mf011 { get; set; }

        /// <summary>
        /// 税号
        /// </summary>
        [SugarColumn(ColumnName = "Mf012", ColumnDescription = "税号", Length = 100)]
        public string Mf012 { get; set; }

        /// <summary>
        /// 税别
        /// </summary>
        [SugarColumn(ColumnName = "Mf013", ColumnDescription = "税别", Length = 2)]
        public string Mf013 { get; set; }

        /// <summary>
        /// 主营业务
        /// </summary>
        [SugarColumn(ColumnName = "Mf014", ColumnDescription = "主营业务", Length = 200)]
        public string Mf014 { get; set; }

        /// <summary>
        /// 采购组
        /// </summary>
        [SugarColumn(ColumnName = "Mf015", ColumnDescription = "采购组", Length = 6, ColumnDataType = "NVARCHAR")]
        public string Mf015 { get; set; }

        /// <summary>
        /// 交易币种
        /// </summary>
        [SugarColumn(ColumnName = "Mf016", ColumnDescription = "交易币种", Length = 3)]
        public string Mf016 { get; set; }

        /// <summary>
        /// 付款条件
        /// </summary>
        [SugarColumn(ColumnName = "Mf017", ColumnDescription = "付款条件", Length = 4)]
        public string Mf017 { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        [SugarColumn(ColumnName = "Mf018", ColumnDescription = "付款方式", Length = 4)]
        public string Mf018 { get; set; }

        /// <summary>
        /// 统驭科目
        /// </summary>
        [SugarColumn(ColumnName = "Mf019", ColumnDescription = "统驭科目", Length = 6)]
        public string Mf019 { get; set; }

        /// <summary>
        /// 贸易条件
        /// </summary>
        [SugarColumn(ColumnName = "Mf020", ColumnDescription = "贸易条件", Length = 40)]
        public string Mf020 { get; set; }

        /// <summary>
        /// 装运条件
        /// </summary>
        [SugarColumn(ColumnName = "Mf021", ColumnDescription = "装运条件", Length = 3)]
        public string Mf021 { get; set; }

        /// <summary>
        /// 运输方式
        /// </summary>
        [SugarColumn(ColumnName = "Mf022", ColumnDescription = "运输方式", Length = 1)]
        public string Mf022 { get; set; }

        /// <summary>
        /// 供应商等级
        /// </summary>
        [SugarColumn(ColumnName = "Mf023", ColumnDescription = "供应商等级", Length = 1)]
        public string Mf023 { get; set; }

        /// <summary>
        /// 供应商信用
        /// </summary>
        [SugarColumn(ColumnName = "Mf024", ColumnDescription = "供应商信用", Length = 1)]
        public string Mf024 { get; set; }

        /// <summary>
        /// 客户
        /// </summary>
        [SugarColumn(ColumnName = "Mf025", ColumnDescription = "客户", Length = 8)]
        public string Mf025 { get; set; }

        /// <summary>
        /// 首次交易
        /// </summary>
        public DateTime? Mf026 { get; set; }

        /// <summary>
        /// 末次交易
        /// </summary>
        public DateTime? Mf027 { get; set; }

        /// <summary>
        /// 国家地区
        /// </summary>
        [SugarColumn(ColumnName = "Mf028", ColumnDescription = "国家地区", Length = 2)]
        public string Mf028 { get; set; }

        /// <summary>
        /// 州省
        /// </summary>
        [SugarColumn(ColumnName = "Mf029", ColumnDescription = "州省", Length = 40)]
        public string Mf029 { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [SugarColumn(ColumnName = "Mf030", ColumnDescription = "市", Length = 40)]
        public string Mf030 { get; set; }

        /// <summary>
        /// 县
        /// </summary>
        [SugarColumn(ColumnName = "Mf031", ColumnDescription = "县", Length = 40)]
        public string Mf031 { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(ColumnName = "Mf032", ColumnDescription = "地址", Length = 200, ColumnDataType = "NVARCHAR")]
        public string Mf032 { get; set; }

        /// <summary>
        /// 地址1
        /// </summary>
        [SugarColumn(ColumnName = "Mf033", ColumnDescription = "地址1", Length = 400, ColumnDataType = "NVARCHAR")]
        public string Mf033 { get; set; }

        /// <summary>
        /// 地址2
        /// </summary>
        [SugarColumn(ColumnName = "Mf034", ColumnDescription = "地址2", Length = 600, ColumnDataType = "NVARCHAR")]
        public string Mf034 { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        [SugarColumn(ColumnName = "Mf035", ColumnDescription = "邮政编码", Length = 20)]
        public string Mf035 { get; set; }

        /// <summary>
        /// 地址号码
        /// </summary>
        [SugarColumn(ColumnName = "Mf036", ColumnDescription = "地址号码", Length = 20)]
        public string Mf036 { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [SugarColumn(ColumnName = "Mf037", ColumnDescription = "联系人", Length = 200)]
        public string Mf037 { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        [SugarColumn(ColumnName = "Mf038", ColumnDescription = "邮件", Length = 50)]
        public string Mf038 { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [SugarColumn(ColumnName = "Mf039", ColumnDescription = "电话", Length = 160)]
        public string Mf039 { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [SugarColumn(ColumnName = "Mf040", ColumnDescription = "传真", Length = 160)]
        public string Mf040 { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [SugarColumn(ColumnName = "Mf041", ColumnDescription = "手机", Length = 160)]
        public string Mf041 { get; set; }

        /// <summary>
        /// 帐户组
        /// </summary>
        [SugarColumn(ColumnName = "Mf042", ColumnDescription = "帐户组", Length = 8)]
        public string Mf042 { get; set; }

        /// <summary>
        /// 营业执照附件
        /// </summary>
        [SugarColumn(ColumnName = "Mf043", ColumnDescription = "营业执照附件", Length = 255)]
        public string Mf043 { get; set; }

        /// <summary>
        /// 其它附件
        /// </summary>
        [SugarColumn(ColumnName = "Mf044", ColumnDescription = "其它附件", Length = 255)]
        public string Mf044 { get; set; }

        /// <summary>
        /// 交易冻结
        /// </summary>
        [SugarColumn(ColumnName = "Mf045", ColumnDescription = "交易冻结", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mf045 { get; set; }
    }
}