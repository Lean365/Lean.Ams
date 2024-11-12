namespace Ams.Model.Logistics
{
    /// <summary>
    /// 客户
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/7 16:02:07
    /// </summary>
    [SugarTable("sd_client", "客户")]
    public class SdClient : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? Id { get; set; }

        /// <summary>
        /// 集团
        /// </summary>
        [SugarColumn(ColumnName = "Ma002", ColumnDescription = "集团", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma002 { get; set; }

        /// <summary>
        /// 销售组织
        /// </summary>
        [SugarColumn(ColumnName = "Ma003", ColumnDescription = "销售组织", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma003 { get; set; }

        /// <summary>
        /// 行业类别
        /// </summary>
        [SugarColumn(ColumnName = "Ma004", ColumnDescription = "行业类别", Length = 1, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma004 { get; set; }

        /// <summary>
        /// 企业性质
        /// </summary>
        [SugarColumn(ColumnName = "Ma005", ColumnDescription = "企业性质", Length = 1, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma005 { get; set; }

        /// <summary>
        /// 客户代码
        /// </summary>
        [SugarColumn(ColumnName = "Ma006", ColumnDescription = "客户代码", Length = 10, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma006 { get; set; }

        /// <summary>
        /// 客户简称
        /// </summary>
        [SugarColumn(ColumnName = "Ma007", ColumnDescription = "客户简称", Length = 40, ColumnDataType = "NVARCHAR")]
        public string Ma007 { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [SugarColumn(ColumnName = "Ma008", ColumnDescription = "客户名称", Length = 200, ColumnDataType = "NVARCHAR")]
        public string Ma008 { get; set; }

        /// <summary>
        /// 企业法人
        /// </summary>
        [SugarColumn(ColumnName = "Ma009", ColumnDescription = "企业法人", Length = 50)]
        public string Ma009 { get; set; }

        /// <summary>
        /// 税号
        /// </summary>
        [SugarColumn(ColumnName = "Ma010", ColumnDescription = "税号", Length = 100)]
        public string Ma010 { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        [SugarColumn(ColumnName = "Ma011", ColumnDescription = "营业执照", Length = 100)]
        public string Ma011 { get; set; }

        /// <summary>
        /// 税别
        /// </summary>
        [SugarColumn(ColumnName = "Ma012", ColumnDescription = "税别", Length = 2)]
        public string Ma012 { get; set; }

        /// <summary>
        /// 主营业务
        /// </summary>
        [SugarColumn(ColumnName = "Ma013", ColumnDescription = "主营业务", Length = 200)]
        public string Ma013 { get; set; }

        /// <summary>
        /// 交易币种
        /// </summary>
        [SugarColumn(ColumnName = "Ma014", ColumnDescription = "交易币种", Length = 3)]
        public string Ma014 { get; set; }

        /// <summary>
        /// 付款条件
        /// </summary>
        [SugarColumn(ColumnName = "Ma015", ColumnDescription = "付款条件", Length = 4)]
        public string Ma015 { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        [SugarColumn(ColumnName = "Ma016", ColumnDescription = "付款方式", Length = 1)]
        public string Ma016 { get; set; }

        /// <summary>
        /// 统驭科目
        /// </summary>
        [SugarColumn(ColumnName = "Ma017", ColumnDescription = "统驭科目", Length = 6)]
        public string Ma017 { get; set; }

        /// <summary>
        /// 贸易条件
        /// </summary>
        [SugarColumn(ColumnName = "Ma018", ColumnDescription = "贸易条件", Length = 3)]
        public string Ma018 { get; set; }

        /// <summary>
        /// 装运条件
        /// </summary>
        [SugarColumn(ColumnName = "Ma019", ColumnDescription = "装运条件", Length = 3)]
        public string Ma019 { get; set; }

        /// <summary>
        /// 客户等级
        /// </summary>
        [SugarColumn(ColumnName = "Ma020", ColumnDescription = "客户等级", Length = 4)]
        public string Ma020 { get; set; }

        /// <summary>
        /// 客户信用
        /// </summary>
        [SugarColumn(ColumnName = "Ma021", ColumnDescription = "客户信用", Length = 4)]
        public string Ma021 { get; set; }

        /// <summary>
        /// 首次交易
        /// </summary>
        public DateTime? Ma022 { get; set; }

        /// <summary>
        /// 最近交易
        /// </summary>
        public DateTime? Ma023 { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        [SugarColumn(ColumnName = "Ma024", ColumnDescription = "供应商", Length = 40)]
        public string Ma024 { get; set; }

        /// <summary>
        /// 国家地区
        /// </summary>
        [SugarColumn(ColumnName = "Ma025", ColumnDescription = "国家地区", Length = 2)]
        public string Ma025 { get; set; }

        /// <summary>
        /// 州省
        /// </summary>
        [SugarColumn(ColumnName = "Ma026", ColumnDescription = "州省", Length = 40)]
        public string Ma026 { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [SugarColumn(ColumnName = "Ma027", ColumnDescription = "市", Length = 40)]
        public string Ma027 { get; set; }

        /// <summary>
        /// 县
        /// </summary>
        [SugarColumn(ColumnName = "Ma028", ColumnDescription = "县", Length = 40)]
        public string Ma028 { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(ColumnName = "Ma029", ColumnDescription = "地址", Length = 200, ColumnDataType = "NVARCHAR")]
        public string Ma029 { get; set; }

        /// <summary>
        /// 地址1
        /// </summary>
        [SugarColumn(ColumnName = "Ma030", ColumnDescription = "地址1", Length = 200, ColumnDataType = "NVARCHAR")]
        public string Ma030 { get; set; }

        /// <summary>
        /// 地址2
        /// </summary>
        [SugarColumn(ColumnName = "Ma031", ColumnDescription = "地址2", Length = 200, ColumnDataType = "NVARCHAR")]
        public string Ma031 { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        [SugarColumn(ColumnName = "Ma032", ColumnDescription = "邮政编码", Length = 20)]
        public string Ma032 { get; set; }

        /// <summary>
        /// 地址号码
        /// </summary>
        [SugarColumn(ColumnName = "Ma033", ColumnDescription = "地址号码", Length = 20)]
        public string Ma033 { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [SugarColumn(ColumnName = "Ma034", ColumnDescription = "联系人", Length = 200)]
        public string Ma034 { get; set; }

        /// <summary>
        /// 电邮
        /// </summary>
        [SugarColumn(ColumnName = "Ma035", ColumnDescription = "电邮", Length = 50)]
        public string Ma035 { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [SugarColumn(ColumnName = "Ma036", ColumnDescription = "电话", Length = 160)]
        public string Ma036 { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [SugarColumn(ColumnName = "Ma037", ColumnDescription = "传真", Length = 160)]
        public string Ma037 { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [SugarColumn(ColumnName = "Ma038", ColumnDescription = "手机", Length = 160)]
        public string Ma038 { get; set; }

        /// <summary>
        /// 冻结标记
        /// </summary>
        [SugarColumn(ColumnName = "Ma039", ColumnDescription = "冻结标记", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma039 { get; set; }

        /// <summary>
        /// 营业执照附件
        /// </summary>
        [SugarColumn(ColumnName = "Ma040", ColumnDescription = "营业执照附件", Length = 255)]
        public string Ma040 { get; set; }

        /// <summary>
        /// 其它附件
        /// </summary>
        [SugarColumn(ColumnName = "Ma041", ColumnDescription = "其它附件", Length = 255)]
        public string Ma041 { get; set; }
    }
}