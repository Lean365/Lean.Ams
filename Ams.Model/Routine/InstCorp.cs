namespace Ams.Model.Routine
{
    /// <summary>
    /// 公司代码
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:19:56
    /// </summary>
    [SugarTable("inst_corp", "公司代码")]
    public class InstCorp : SysBase
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
        [SugarColumn(ColumnName = "Ma002", ColumnDescription = "集团", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma002 { get; set; }

        /// <summary>
        /// 性质
        /// </summary>
        [SugarColumn(ColumnName = "Ma003", ColumnDescription = "性质", Length = 1, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma003 { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [SugarColumn(ColumnName = "Ma004", ColumnDescription = "类别", Length = 1, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma004 { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        [SugarColumn(ColumnName = "Ma005", ColumnDescription = "代码", Length = 8, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma005 { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        [SugarColumn(ColumnName = "Ma006", ColumnDescription = "简称", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma006 { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "Ma007", ColumnDescription = "名称", Length = 200, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma007 { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        [SugarColumn(ColumnName = "Ma009", ColumnDescription = "国家", Length = 6)]
        public string Ma009 { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [SugarColumn(ColumnName = "Ma008", ColumnDescription = "城市", Length = 50)]
        public string Ma008 { get; set; }

        /// <summary>
        /// 货币码
        /// </summary>
        [SugarColumn(ColumnName = "Ma010", ColumnDescription = "货币码", Length = 3)]
        public string Ma010 { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        [SugarColumn(ColumnName = "Ma011", ColumnDescription = "语言", Length = 6)]
        public string Ma011 { get; set; }

        /// <summary>
        /// 帐目表
        /// </summary>
        [SugarColumn(ColumnName = "Ma012", ColumnDescription = "帐目表", Length = 8)]
        public string Ma012 { get; set; }

        /// <summary>
        /// 最大汇率偏差
        /// </summary>
        [SugarColumn(ColumnName = "Ma013", ColumnDescription = "最大汇率偏差", DefaultValue = "0")]
        public int? Ma013 { get; set; }

        /// <summary>
        /// 会计年度变式
        /// </summary>
        [SugarColumn(ColumnName = "Ma014", ColumnDescription = "会计年度变式", Length = 4)]
        public string Ma014 { get; set; }

        /// <summary>
        /// 分配标识符
        /// </summary>
        [SugarColumn(ColumnName = "Ma015", ColumnDescription = "分配标识符", Length = 2)]
        public string Ma015 { get; set; }

        /// <summary>
        /// 公司简称
        /// </summary>
        [SugarColumn(ColumnName = "Ma016", ColumnDescription = "公司简称", Length = 12)]
        public string Ma016 { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(ColumnName = "Ma017", ColumnDescription = "地址", Length = 20)]
        public string Ma017 { get; set; }

        /// <summary>
        /// 增值税登记号
        /// </summary>
        [SugarColumn(ColumnName = "Ma018", ColumnDescription = "增值税登记号", Length = 40)]
        public string Ma018 { get; set; }

        /// <summary>
        /// 财务管理范围
        /// </summary>
        [SugarColumn(ColumnName = "Ma019", ColumnDescription = "财务管理范围", Length = 8)]
        public string Ma019 { get; set; }

        /// <summary>
        /// 现金管理项目
        /// </summary>
        [SugarColumn(ColumnName = "Ma020", ColumnDescription = "现金管理项目", Length = 2)]
        public string Ma020 { get; set; }

        /// <summary>
        /// 现金预算管理
        /// </summary>
        [SugarColumn(ColumnName = "Ma021", ColumnDescription = "现金预算管理", Length = 2)]
        public string Ma021 { get; set; }

        /// <summary>
        /// 资金管理更新
        /// </summary>
        [SugarColumn(ColumnName = "Ma022", ColumnDescription = "资金管理更新", Length = 2)]
        public string Ma022 { get; set; }

        /// <summary>
        /// 地区税务代码
        /// </summary>
        [SugarColumn(ColumnName = "Ma023", ColumnDescription = "地区税务代码", Length = 30)]
        public string Ma023 { get; set; }

        /// <summary>
        /// 基金分配科目
        /// </summary>
        public DateTime? Ma024 { get; set; }

        /// <summary>
        /// 公司变式
        /// </summary>
        [SugarColumn(ColumnName = "Ma025", ColumnDescription = "公司变式", Length = 2)]
        public string Ma025 { get; set; }

        /// <summary>
        /// 预测公司
        /// </summary>
        [SugarColumn(ColumnName = "Ma026", ColumnDescription = "预测公司", Length = 8)]
        public string Ma026 { get; set; }

        /// <summary>
        /// 现金管理
        /// </summary>
        [SugarColumn(ColumnName = "Ma027", ColumnDescription = "现金管理", Length = 2)]
        public string Ma027 { get; set; }

        /// <summary>
        /// 起息日
        /// </summary>
        [SugarColumn(ColumnName = "Ma028", ColumnDescription = "起息日", Length = 2)]
        public string Ma028 { get; set; }

        /// <summary>
        /// 折扣金额净值
        /// </summary>
        [SugarColumn(ColumnName = "Ma029", ColumnDescription = "折扣金额净值", Length = 2)]
        public string Ma029 { get; set; }

        /// <summary>
        /// 贷方控制范围
        /// </summary>
        [SugarColumn(ColumnName = "Ma030", ColumnDescription = "贷方控制范围", Length = 8)]
        public string Ma030 { get; set; }

        /// <summary>
        /// 净折扣额
        /// </summary>
        [SugarColumn(ColumnName = "Ma031", ColumnDescription = "净折扣额", Length = 2)]
        public string Ma031 { get; set; }

        /// <summary>
        /// 从样本科目复制
        /// </summary>
        [SugarColumn(ColumnName = "Ma032", ColumnDescription = "从样本科目复制", Length = 8)]
        public string Ma032 { get; set; }

        /// <summary>
        /// 业务部门资产负债表
        /// </summary>
        [SugarColumn(ColumnName = "Ma033", ColumnDescription = "业务部门资产负债表", Length = 2)]
        public string Ma033 { get; set; }

        /// <summary>
        /// 建议会计年度
        /// </summary>
        [SugarColumn(ColumnName = "Ma034", ColumnDescription = "建议会计年度", Length = 2)]
        public string Ma034 { get; set; }

        /// <summary>
        /// 外向换算记帐
        /// </summary>
        [SugarColumn(ColumnName = "Ma035", ColumnDescription = "外向换算记帐", Length = 2)]
        public string Ma035 { get; set; }

        /// <summary>
        /// 生产公司代码
        /// </summary>
        [SugarColumn(ColumnName = "Ma036", ColumnDescription = "生产公司代码", Length = 2)]
        public string Ma036 { get; set; }

        /// <summary>
        /// 采购科目
        /// </summary>
        [SugarColumn(ColumnName = "Ma037", ColumnDescription = "采购科目", Length = 2)]
        public string Ma037 { get; set; }

        /// <summary>
        /// 联营公司会计
        /// </summary>
        [SugarColumn(ColumnName = "Ma038", ColumnDescription = "联营公司会计", Length = 2)]
        public string Ma038 { get; set; }

        /// <summary>
        /// 金融资产管理
        /// </summary>
        [SugarColumn(ColumnName = "Ma039", ColumnDescription = "金融资产管理", Length = 2)]
        public string Ma039 { get; set; }

        /// <summary>
        /// 汇率差额
        /// </summary>
        [SugarColumn(ColumnName = "Ma040", ColumnDescription = "汇率差额", Length = 2)]
        public string Ma040 { get; set; }

        /// <summary>
        /// 更新MM
        /// </summary>
        [SugarColumn(ColumnName = "Ma041", ColumnDescription = "更新MM", Length = 2)]
        public string Ma041 { get; set; }

        /// <summary>
        /// 更新SD
        /// </summary>
        [SugarColumn(ColumnName = "Ma042", ColumnDescription = "更新SD", Length = 2)]
        public string Ma042 { get; set; }

        /// <summary>
        /// 外部公司代码
        /// </summary>
        [SugarColumn(ColumnName = "Ma043", ColumnDescription = "外部公司代码", Length = 2)]
        public string Ma043 { get; set; }

        /// <summary>
        /// 原始码
        /// </summary>
        [SugarColumn(ColumnName = "Ma044", ColumnDescription = "原始码", Length = 8)]
        public string Ma044 { get; set; }

        /// <summary>
        /// 法定科目表
        /// </summary>
        [SugarColumn(ColumnName = "Ma045", ColumnDescription = "法定科目表", Length = 8)]
        public string Ma045 { get; set; }

        /// <summary>
        /// 税组
        /// </summary>
        [SugarColumn(ColumnName = "Ma046", ColumnDescription = "税组", Length = 8)]
        public string Ma046 { get; set; }

        /// <summary>
        /// 全球公司代码
        /// </summary>
        [SugarColumn(ColumnName = "Ma047", ColumnDescription = "全球公司代码", Length = 12)]
        public string Ma047 { get; set; }

        /// <summary>
        /// 字段状态变式
        /// </summary>
        [SugarColumn(ColumnName = "Ma048", ColumnDescription = "字段状态变式", Length = 8)]
        public string Ma048 { get; set; }

        /// <summary>
        /// 记帐期间变式
        /// </summary>
        [SugarColumn(ColumnName = "Ma049", ColumnDescription = "记帐期间变式", Length = 8)]
        public string Ma049 { get; set; }

        /// <summary>
        /// 套期请求
        /// </summary>
        [SugarColumn(ColumnName = "Ma050", ColumnDescription = "套期请求", Length = 2)]
        public string Ma050 { get; set; }

        /// <summary>
        /// 外币换算税金
        /// </summary>
        [SugarColumn(ColumnName = "Ma051", ColumnDescription = "外币换算税金", Length = 2)]
        public string Ma051 { get; set; }

        /// <summary>
        /// 工作流变式
        /// </summary>
        [SugarColumn(ColumnName = "Ma052", ColumnDescription = "工作流变式", Length = 8)]
        public string Ma052 { get; set; }

        /// <summary>
        /// 库存管理
        /// </summary>
        [SugarColumn(ColumnName = "Ma053", ColumnDescription = "库存管理", Length = 2)]
        public string Ma053 { get; set; }

        /// <summary>
        /// 采购订单
        /// </summary>
        [SugarColumn(ColumnName = "Ma054", ColumnDescription = "采购订单", Length = 2)]
        public string Ma054 { get; set; }

        /// <summary>
        /// 采购申请
        /// </summary>
        [SugarColumn(ColumnName = "Ma055", ColumnDescription = "采购申请", Length = 2)]
        public string Ma055 { get; set; }

        /// <summary>
        /// 合同
        /// </summary>
        [SugarColumn(ColumnName = "Ma056", ColumnDescription = "合同", Length = 2)]
        public string Ma056 { get; set; }

        /// <summary>
        /// 税金确定
        /// </summary>
        [SugarColumn(ColumnName = "Ma057", ColumnDescription = "税金确定", Length = 2)]
        public string Ma057 { get; set; }

        /// <summary>
        /// 进项税码
        /// </summary>
        [SugarColumn(ColumnName = "Ma058", ColumnDescription = "进项税码", Length = 4)]
        public string Ma058 { get; set; }

        /// <summary>
        /// 销项税码
        /// </summary>
        [SugarColumn(ColumnName = "Ma059", ColumnDescription = "销项税码", Length = 4)]
        public string Ma059 { get; set; }

        /// <summary>
        /// 进口数据
        /// </summary>
        [SugarColumn(ColumnName = "Ma060", ColumnDescription = "进口数据", Length = 2)]
        public string Ma060 { get; set; }

        /// <summary>
        /// 允许负数记帐
        /// </summary>
        [SugarColumn(ColumnName = "Ma061", ColumnDescription = "允许负数记帐", Length = 2)]
        public string Ma061 { get; set; }

        /// <summary>
        /// 信用控制范围
        /// </summary>
        [SugarColumn(ColumnName = "Ma062", ColumnDescription = "信用控制范围", Length = 2)]
        public string Ma062 { get; set; }

        /// <summary>
        /// 预扣税
        /// </summary>
        [SugarColumn(ColumnName = "Ma063", ColumnDescription = "预扣税", Length = 2)]
        public string Ma063 { get; set; }

        /// <summary>
        /// 记帐日期
        /// </summary>
        [SugarColumn(ColumnName = "Ma064", ColumnDescription = "记帐日期", Length = 2)]
        public string Ma064 { get; set; }

        /// <summary>
        /// 通货膨胀方法
        /// </summary>
        [SugarColumn(ColumnName = "Ma065", ColumnDescription = "通货膨胀方法", Length = 8)]
        public string Ma065 { get; set; }

        /// <summary>
        /// 字段状态变式
        /// </summary>
        [SugarColumn(ColumnName = "Ma066", ColumnDescription = "字段状态变式", Length = 8)]
        public string Ma066 { get; set; }

        /// <summary>
        /// 复制控制GR
        /// </summary>
        [SugarColumn(ColumnName = "Ma067", ColumnDescription = "复制控制GR", Length = 2)]
        public string Ma067 { get; set; }

        /// <summary>
        /// 收货进口控制
        /// </summary>
        [SugarColumn(ColumnName = "Ma068", ColumnDescription = "收货进口控制", Length = 2)]
        public string Ma068 { get; set; }

        /// <summary>
        /// 冲销科目方法
        /// </summary>
        [SugarColumn(ColumnName = "Ma069", ColumnDescription = "冲销科目方法", DefaultValue = "0")]
        public int? Ma069 { get; set; }

        /// <summary>
        /// BA变式
        /// </summary>
        [SugarColumn(ColumnName = "Ma070", ColumnDescription = "BA变式", Length = 4)]
        public string Ma070 { get; set; }

        /// <summary>
        /// 销售会计核算
        /// </summary>
        [SugarColumn(ColumnName = "Ma071", ColumnDescription = "销售会计核算", Length = 2)]
        public string Ma071 { get; set; }

        /// <summary>
        /// 应收科目抵押激活
        /// </summary>
        [SugarColumn(ColumnName = "Ma072", ColumnDescription = "应收科目抵押激活", Length = 2)]
        public string Ma072 { get; set; }

        /// <summary>
        /// 可行的金额划分
        /// </summary>
        [SugarColumn(ColumnName = "Ma073", ColumnDescription = "可行的金额划分", Length = 2)]
        public string Ma073 { get; set; }

        /// <summary>
        /// 附加费计算方法
        /// </summary>
        [SugarColumn(ColumnName = "Ma074", ColumnDescription = "附加费计算方法", Length = 2)]
        public string Ma074 { get; set; }

        /// <summary>
        /// 征税类别
        /// </summary>
        [SugarColumn(ColumnName = "Ma075", ColumnDescription = "征税类别", Length = 4)]
        public string Ma075 { get; set; }

        /// <summary>
        /// 金额更正
        /// </summary>
        [SugarColumn(ColumnName = "Ma076", ColumnDescription = "金额更正", Length = 4)]
        public string Ma076 { get; set; }

        /// <summary>
        /// 税码更正
        /// </summary>
        [SugarColumn(ColumnName = "Ma077", ColumnDescription = "税码更正", Length = 4)]
        public string Ma077 { get; set; }

        /// <summary>
        /// 汇款文件类型
        /// </summary>
        [SugarColumn(ColumnName = "Ma078", ColumnDescription = "汇款文件类型", Length = 4)]
        public string Ma078 { get; set; }

        /// <summary>
        /// 递延税规则
        /// </summary>
        [SugarColumn(ColumnName = "Ma079", ColumnDescription = "递延税规则", Length = 8)]
        public string Ma079 { get; set; }

        /// <summary>
        /// 报税日期
        /// </summary>
        [SugarColumn(ColumnName = "Ma080", ColumnDescription = "报税日期", Length = 2)]
        public string Ma080 { get; set; }

        /// <summary>
        /// 过帐期间变式
        /// </summary>
        [SugarColumn(ColumnName = "Ma081", ColumnDescription = "过帐期间变式", Length = 2)]
        public string Ma081 { get; set; }

        /// <summary>
        /// 购物车
        /// </summary>
        [SugarColumn(ColumnName = "Ma082", ColumnDescription = "购物车", Length = 2)]
        public string Ma082 { get; set; }

        /// <summary>
        /// 基金管理分配
        /// </summary>
        [SugarColumn(ColumnName = "Ma083", ColumnDescription = "基金管理分配", Length = 2)]
        public string Ma083 { get; set; }
    }
}