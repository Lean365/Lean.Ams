namespace Ams.Model.Logistics
{
    /// <summary>
    /// 顾客
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/26 15:20:13
    /// </summary>
    [SugarTable("sd_customer", "顾客")]
    public class SdCustomer : SysBase
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
        [SugarColumn(ColumnName = "Mb002", ColumnDescription = "集团", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb002 { get; set; }

        /// <summary>
        /// 销售组织
        /// </summary>
        [SugarColumn(ColumnName = "Mb003", ColumnDescription = "销售组织", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb003 { get; set; }

        /// <summary>
        /// 行业类别
        /// </summary>
        [SugarColumn(ColumnName = "Mb004", ColumnDescription = "行业类别", Length = 1, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb004 { get; set; }

        /// <summary>
        /// 企业性质
        /// </summary>
        [SugarColumn(ColumnName = "Mb005", ColumnDescription = "企业性质", Length = 1, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb005 { get; set; }

        /// <summary>
        /// 客户代码
        /// </summary>
        [SugarColumn(ColumnName = "Mb006", ColumnDescription = "客户代码", Length = 10, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb006 { get; set; }

        /// <summary>
        /// 客户简称
        /// </summary>
        [SugarColumn(ColumnName = "Mb007", ColumnDescription = "客户简称", Length = 40, ColumnDataType = "NVARCHAR")]
        public string Mb007 { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        [SugarColumn(ColumnName = "Mb008", ColumnDescription = "客户名称", Length = 200, ColumnDataType = "NVARCHAR")]
        public string Mb008 { get; set; }

        /// <summary>
        /// 企业法人
        /// </summary>
        [SugarColumn(ColumnName = "Mb009", ColumnDescription = "企业法人", Length = 50)]
        public string Mb009 { get; set; }

        /// <summary>
        /// 税号
        /// </summary>
        [SugarColumn(ColumnName = "Mb010", ColumnDescription = "税号", Length = 100)]
        public string Mb010 { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        [SugarColumn(ColumnName = "Mb011", ColumnDescription = "营业执照", Length = 100)]
        public string Mb011 { get; set; }

        /// <summary>
        /// 税别
        /// </summary>
        [SugarColumn(ColumnName = "Mb012", ColumnDescription = "税别", Length = 2)]
        public string Mb012 { get; set; }

        /// <summary>
        /// 主营业务
        /// </summary>
        [SugarColumn(ColumnName = "Mb013", ColumnDescription = "主营业务", Length = 200)]
        public string Mb013 { get; set; }

        /// <summary>
        /// 交易币种
        /// </summary>
        [SugarColumn(ColumnName = "Mb014", ColumnDescription = "交易币种", Length = 3)]
        public string Mb014 { get; set; }

        /// <summary>
        /// 付款条件
        /// </summary>
        [SugarColumn(ColumnName = "Mb015", ColumnDescription = "付款条件", Length = 4)]
        public string Mb015 { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        [SugarColumn(ColumnName = "Mb016", ColumnDescription = "付款方式", Length = 1)]
        public string Mb016 { get; set; }

        /// <summary>
        /// 统驭科目
        /// </summary>
        [SugarColumn(ColumnName = "Mb017", ColumnDescription = "统驭科目", Length = 6)]
        public string Mb017 { get; set; }

        /// <summary>
        /// 贸易条件
        /// </summary>
        [SugarColumn(ColumnName = "Mb018", ColumnDescription = "贸易条件", Length = 3)]
        public string Mb018 { get; set; }

        /// <summary>
        /// 装运条件
        /// </summary>
        [SugarColumn(ColumnName = "Mb019", ColumnDescription = "装运条件", Length = 3)]
        public string Mb019 { get; set; }

        /// <summary>
        /// 客户等级
        /// </summary>
        [SugarColumn(ColumnName = "Mb020", ColumnDescription = "客户等级", Length = 4)]
        public string Mb020 { get; set; }

        /// <summary>
        /// 客户信用
        /// </summary>
        [SugarColumn(ColumnName = "Mb021", ColumnDescription = "客户信用", Length = 4)]
        public string Mb021 { get; set; }

        /// <summary>
        /// 首次交易
        /// </summary>
        public DateTime? Mb022 { get; set; }

        /// <summary>
        /// 最近交易
        /// </summary>
        public DateTime? Mb023 { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        [SugarColumn(ColumnName = "Mb024", ColumnDescription = "供应商", Length = 40)]
        public string Mb024 { get; set; }

        /// <summary>
        /// 国家地区
        /// </summary>
        [SugarColumn(ColumnName = "Mb025", ColumnDescription = "国家地区", Length = 2)]
        public string Mb025 { get; set; }

        /// <summary>
        /// 州省
        /// </summary>
        [SugarColumn(ColumnName = "Mb026", ColumnDescription = "州省", Length = 40)]
        public string Mb026 { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [SugarColumn(ColumnName = "Mb027", ColumnDescription = "市", Length = 40)]
        public string Mb027 { get; set; }

        /// <summary>
        /// 县
        /// </summary>
        [SugarColumn(ColumnName = "Mb028", ColumnDescription = "县", Length = 40)]
        public string Mb028 { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(ColumnName = "Mb029", ColumnDescription = "地址", Length = 200, ColumnDataType = "NVARCHAR")]
        public string Mb029 { get; set; }

        /// <summary>
        /// 地址1
        /// </summary>
        [SugarColumn(ColumnName = "Mb030", ColumnDescription = "地址1", Length = 200, ColumnDataType = "NVARCHAR")]
        public string Mb030 { get; set; }

        /// <summary>
        /// 地址2
        /// </summary>
        [SugarColumn(ColumnName = "Mb031", ColumnDescription = "地址2", Length = 200, ColumnDataType = "NVARCHAR")]
        public string Mb031 { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        [SugarColumn(ColumnName = "Mb032", ColumnDescription = "邮政编码", Length = 20)]
        public string Mb032 { get; set; }

        /// <summary>
        /// 地址号码
        /// </summary>
        [SugarColumn(ColumnName = "Mb033", ColumnDescription = "地址号码", Length = 20)]
        public string Mb033 { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [SugarColumn(ColumnName = "Mb034", ColumnDescription = "联系人", Length = 200)]
        public string Mb034 { get; set; }

        /// <summary>
        /// 电邮
        /// </summary>
        [SugarColumn(ColumnName = "Mb035", ColumnDescription = "电邮", Length = 50)]
        public string Mb035 { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [SugarColumn(ColumnName = "Mb036", ColumnDescription = "电话", Length = 160)]
        public string Mb036 { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        [SugarColumn(ColumnName = "Mb037", ColumnDescription = "传真", Length = 160)]
        public string Mb037 { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [SugarColumn(ColumnName = "Mb038", ColumnDescription = "手机", Length = 160)]
        public string Mb038 { get; set; }

        /// <summary>
        /// 冻结标记
        /// </summary>
        [SugarColumn(ColumnName = "Mb039", ColumnDescription = "冻结标记", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mb039 { get; set; }

        /// <summary>
        /// 营业执照附件
        /// </summary>
        [SugarColumn(ColumnName = "Mb040", ColumnDescription = "营业执照附件", Length = 255)]
        public string Mb040 { get; set; }

        /// <summary>
        /// 其它附件
        /// </summary>
        [SugarColumn(ColumnName = "Mb041", ColumnDescription = "其它附件", Length = 255)]
        public string Mb041 { get; set; }
    }
}