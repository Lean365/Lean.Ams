namespace Ams.Model.Logistics
{
    /// <summary>
    /// 工厂物料
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:30:16
    /// </summary>
    [SugarTable("mm_marc", "工厂物料")]
    public class MmMarc : SysBase
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
        [SugarColumn(ColumnName = "Mc002", ColumnDescription = "集团", Length = 6)]
        public string Mc002 { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Mc004", ColumnDescription = "工厂", Length = 8)]
        public string Mc004 { get; set; }

        /// <summary>
        /// 物料号
        /// </summary>
        [SugarColumn(ColumnName = "Mc003", ColumnDescription = "物料号", Length = 36)]
        public string Mc003 { get; set; }

        /// <summary>
        /// 维护状态
        /// </summary>
        [SugarColumn(ColumnName = "Mc005", ColumnDescription = "维护状态", Length = 30)]
        public string Mc005 { get; set; }

        /// <summary>
        /// 工厂级删除
        /// </summary>
        [SugarColumn(ColumnName = "Mc006", ColumnDescription = "工厂级删除", Length = 2)]
        public string Mc006 { get; set; }

        /// <summary>
        /// 评估类别
        /// </summary>
        [SugarColumn(ColumnName = "Mc007", ColumnDescription = "评估类别", Length = 2)]
        public string Mc007 { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [SugarColumn(ColumnName = "Mc008", ColumnDescription = "批次", Length = 2)]
        public string Mc008 { get; set; }

        /// <summary>
        /// PS物料状态
        /// </summary>
        [SugarColumn(ColumnName = "Mc009", ColumnDescription = "PS物料状态", Length = 4)]
        public string Mc009 { get; set; }

        /// <summary>
        /// 有效起始日
        /// </summary>
        public DateTime? Mc010 { get; set; }

        /// <summary>
        /// ABC标识
        /// </summary>
        [SugarColumn(ColumnName = "Mc011", ColumnDescription = "ABC标识", Length = 2)]
        public string Mc011 { get; set; }

        /// <summary>
        /// 关键部件
        /// </summary>
        [SugarColumn(ColumnName = "Mc012", ColumnDescription = "关键部件", Length = 2)]
        public string Mc012 { get; set; }

        /// <summary>
        /// 采购组
        /// </summary>
        [SugarColumn(ColumnName = "Mc013", ColumnDescription = "采购组", Length = 6)]
        public string Mc013 { get; set; }

        /// <summary>
        /// 发货单位
        /// </summary>
        [SugarColumn(ColumnName = "Mc014", ColumnDescription = "发货单位", Length = 6)]
        public string Mc014 { get; set; }

        /// <summary>
        /// MRP 参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Mc015", ColumnDescription = "MRP 参数文件", Length = 8)]
        public string Mc015 { get; set; }

        /// <summary>
        /// MRP 类型
        /// </summary>
        [SugarColumn(ColumnName = "Mc016", ColumnDescription = "MRP 类型", Length = 4)]
        public string Mc016 { get; set; }

        /// <summary>
        /// MRP 控制者
        /// </summary>
        [SugarColumn(ColumnName = "Mc017", ColumnDescription = "MRP 控制者", Length = 6)]
        public string Mc017 { get; set; }

        /// <summary>
        /// MRP 控制者买方
        /// </summary>
        [SugarColumn(ColumnName = "Mc018", ColumnDescription = "MRP 控制者买方", Length = 2)]
        public string Mc018 { get; set; }

        /// <summary>
        /// 计划交货天数
        /// </summary>
        [SugarColumn(ColumnName = "Mc019", ColumnDescription = "计划交货天数", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc019 { get; set; }

        /// <summary>
        /// 收货处理时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc020", ColumnDescription = "收货处理时间", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc020 { get; set; }

        /// <summary>
        /// 期间标识
        /// </summary>
        [SugarColumn(ColumnName = "Mc021", ColumnDescription = "期间标识", Length = 2)]
        public string Mc021 { get; set; }

        /// <summary>
        /// 装配报废
        /// </summary>
        [SugarColumn(ColumnName = "Mc022", ColumnDescription = "装配报废", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc022 { get; set; }

        /// <summary>
        /// 批量大小
        /// </summary>
        [SugarColumn(ColumnName = "Mc023", ColumnDescription = "批量大小", Length = 4)]
        public string Mc023 { get; set; }

        /// <summary>
        /// 采购
        /// </summary>
        [SugarColumn(ColumnName = "Mc024", ColumnDescription = "采购", Length = 2)]
        public string Mc024 { get; set; }

        /// <summary>
        /// 特殊采购
        /// </summary>
        [SugarColumn(ColumnName = "Mc025", ColumnDescription = "特殊采购", Length = 4)]
        public string Mc025 { get; set; }

        /// <summary>
        /// 再订货点
        /// </summary>
        [SugarColumn(ColumnName = "Mc026", ColumnDescription = "再订货点", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc026 { get; set; }

        /// <summary>
        /// 安全库存
        /// </summary>
        [SugarColumn(ColumnName = "Mc027", ColumnDescription = "安全库存", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc027 { get; set; }

        /// <summary>
        /// 最小批量
        /// </summary>
        [SugarColumn(ColumnName = "Mc028", ColumnDescription = "最小批量", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc028 { get; set; }

        /// <summary>
        /// 最大批量
        /// </summary>
        [SugarColumn(ColumnName = "Mc029", ColumnDescription = "最大批量", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc029 { get; set; }

        /// <summary>
        /// 固定批量
        /// </summary>
        [SugarColumn(ColumnName = "Mc030", ColumnDescription = "固定批量", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc030 { get; set; }

        /// <summary>
        /// 舍入值
        /// </summary>
        [SugarColumn(ColumnName = "Mc031", ColumnDescription = "舍入值", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc031 { get; set; }

        /// <summary>
        /// 最大库存水平
        /// </summary>
        [SugarColumn(ColumnName = "Mc032", ColumnDescription = "最大库存水平", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc032 { get; set; }

        /// <summary>
        /// 订购成本
        /// </summary>
        [SugarColumn(ColumnName = "Mc033", ColumnDescription = "订购成本", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc033 { get; set; }

        /// <summary>
        /// 独立/集中
        /// </summary>
        [SugarColumn(ColumnName = "Mc034", ColumnDescription = "独立/集中", Length = 2)]
        public string Mc034 { get; set; }

        /// <summary>
        /// 库存成本
        /// </summary>
        [SugarColumn(ColumnName = "Mc035", ColumnDescription = "库存成本", Length = 2)]
        public string Mc035 { get; set; }

        /// <summary>
        /// 选择方法
        /// </summary>
        [SugarColumn(ColumnName = "Mc036", ColumnDescription = "选择方法", Length = 2)]
        public string Mc036 { get; set; }

        /// <summary>
        /// 非连续标识
        /// </summary>
        [SugarColumn(ColumnName = "Mc037", ColumnDescription = "非连续标识", Length = 2)]
        public string Mc037 { get; set; }

        /// <summary>
        /// 中断日期
        /// </summary>
        public DateTime? Mc038 { get; set; }

        /// <summary>
        /// 后续物料
        /// </summary>
        [SugarColumn(ColumnName = "Mc039", ColumnDescription = "后续物料", Length = 36)]
        public string Mc039 { get; set; }

        /// <summary>
        /// 需求分组
        /// </summary>
        [SugarColumn(ColumnName = "Mc040", ColumnDescription = "需求分组", Length = 2)]
        public string Mc040 { get; set; }

        /// <summary>
        /// 综合MRP
        /// </summary>
        [SugarColumn(ColumnName = "Mc041", ColumnDescription = "综合MRP", Length = 2)]
        public string Mc041 { get; set; }

        /// <summary>
        /// 计划边际码
        /// </summary>
        [SugarColumn(ColumnName = "Mc042", ColumnDescription = "计划边际码", Length = 6)]
        public string Mc042 { get; set; }

        /// <summary>
        /// 自动更改工厂订单
        /// </summary>
        [SugarColumn(ColumnName = "Mc043", ColumnDescription = "自动更改工厂订单", Length = 2)]
        public string Mc043 { get; set; }

        /// <summary>
        /// 自动批准
        /// </summary>
        [SugarColumn(ColumnName = "Mc044", ColumnDescription = "自动批准", Length = 2)]
        public string Mc044 { get; set; }

        /// <summary>
        /// 反冲
        /// </summary>
        [SugarColumn(ColumnName = "Mc045", ColumnDescription = "反冲", Length = 2)]
        public string Mc045 { get; set; }

        /// <summary>
        /// 生产管理员
        /// </summary>
        [SugarColumn(ColumnName = "Mc046", ColumnDescription = "生产管理员", Length = 6)]
        public string Mc046 { get; set; }

        /// <summary>
        /// 处理时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc047", ColumnDescription = "处理时间", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc047 { get; set; }

        /// <summary>
        /// 准备时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc048", ColumnDescription = "准备时间", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc048 { get; set; }

        /// <summary>
        /// 工序间
        /// </summary>
        [SugarColumn(ColumnName = "Mc049", ColumnDescription = "工序间", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc049 { get; set; }

        /// <summary>
        /// 基准数量
        /// </summary>
        [SugarColumn(ColumnName = "Mc050", ColumnDescription = "基准数量", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc050 { get; set; }

        /// <summary>
        /// 厂内生产时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc051", ColumnDescription = "厂内生产时间", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc051 { get; set; }

        /// <summary>
        /// 最大存储期间
        /// </summary>
        [SugarColumn(ColumnName = "Mc052", ColumnDescription = "最大存储期间", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc052 { get; set; }

        /// <summary>
        /// 时间单位
        /// </summary>
        [SugarColumn(ColumnName = "Mc053", ColumnDescription = "时间单位", Length = 6)]
        public string Mc053 { get; set; }

        /// <summary>
        /// 从产品货位库存
        /// </summary>
        [SugarColumn(ColumnName = "Mc054", ColumnDescription = "从产品货位库存", Length = 2)]
        public string Mc054 { get; set; }

        /// <summary>
        /// 初步计划
        /// </summary>
        [SugarColumn(ColumnName = "Mc055", ColumnDescription = "初步计划", Length = 2)]
        public string Mc055 { get; set; }

        /// <summary>
        /// 超量交货容差
        /// </summary>
        [SugarColumn(ColumnName = "Mc056", ColumnDescription = "超量交货容差", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc056 { get; set; }

        /// <summary>
        /// 未限制
        /// </summary>
        [SugarColumn(ColumnName = "Mc057", ColumnDescription = "未限制", Length = 2)]
        public string Mc057 { get; set; }

        /// <summary>
        /// 不足交货容差
        /// </summary>
        [SugarColumn(ColumnName = "Mc058", ColumnDescription = "不足交货容差", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc058 { get; set; }

        /// <summary>
        /// 总计补货提前时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc059", ColumnDescription = "总计补货提前时间", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc059 { get; set; }

        /// <summary>
        /// 替换部件
        /// </summary>
        [SugarColumn(ColumnName = "Mc060", ColumnDescription = "替换部件", Length = 2)]
        public string Mc060 { get; set; }

        /// <summary>
        /// 附加费
        /// </summary>
        [SugarColumn(ColumnName = "Mc061", ColumnDescription = "附加费", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc061 { get; set; }

        /// <summary>
        /// 生产状态
        /// </summary>
        [SugarColumn(ColumnName = "Mc062", ColumnDescription = "生产状态", Length = 4)]
        public string Mc062 { get; set; }

        /// <summary>
        /// 过帐到检验库存
        /// </summary>
        [SugarColumn(ColumnName = "Mc063", ColumnDescription = "过帐到检验库存", Length = 2)]
        public string Mc063 { get; set; }

        /// <summary>
        /// 样本
        /// </summary>
        [SugarColumn(ColumnName = "Mc064", ColumnDescription = "样本", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc064 { get; set; }

        /// <summary>
        /// 隔离
        /// </summary>
        [SugarColumn(ColumnName = "Mc065", ColumnDescription = "隔离", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc065 { get; set; }

        /// <summary>
        /// 控制码
        /// </summary>
        [SugarColumn(ColumnName = "Mc066", ColumnDescription = "控制码", Length = 16)]
        public string Mc066 { get; set; }

        /// <summary>
        /// 平均检查持续期
        /// </summary>
        [SugarColumn(ColumnName = "Mc067", ColumnDescription = "平均检查持续期", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc067 { get; set; }

        /// <summary>
        /// 检查计划
        /// </summary>
        [SugarColumn(ColumnName = "Mc068", ColumnDescription = "检查计划", Length = 1)]
        public string Mc068 { get; set; }

        /// <summary>
        /// 凭证需求
        /// </summary>
        [SugarColumn(ColumnName = "Mc069", ColumnDescription = "凭证需求", Length = 2)]
        public string Mc069 { get; set; }

        /// <summary>
        /// 活动性物质
        /// </summary>
        [SugarColumn(ColumnName = "Mc070", ColumnDescription = "活动性物质", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc070 { get; set; }

        /// <summary>
        /// 检查间隔
        /// </summary>
        [SugarColumn(ColumnName = "Mc071", ColumnDescription = "检查间隔", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc071 { get; set; }

        /// <summary>
        /// 下一次检查
        /// </summary>
        public DateTime? Mc072 { get; set; }

        /// <summary>
        /// 中转库存
        /// </summary>
        [SugarColumn(ColumnName = "Mc073", ColumnDescription = "中转库存", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc073 { get; set; }

        /// <summary>
        /// 装载组
        /// </summary>
        [SugarColumn(ColumnName = "Mc074", ColumnDescription = "装载组", Length = 1)]
        public string Mc074 { get; set; }

        /// <summary>
        /// 批次管理需求
        /// </summary>
        [SugarColumn(ColumnName = "Mc075", ColumnDescription = "批次管理需求", Length = 2)]
        public string Mc075 { get; set; }

        /// <summary>
        /// 配额使用
        /// </summary>
        [SugarColumn(ColumnName = "Mc076", ColumnDescription = "配额使用", Length = 2)]
        public string Mc076 { get; set; }

        /// <summary>
        /// 服务水平
        /// </summary>
        [SugarColumn(ColumnName = "Mc077", ColumnDescription = "服务水平", DefaultValue = "0", Length = 18, DecimalDigits = 0, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc077 { get; set; }

        /// <summary>
        /// 分割标识
        /// </summary>
        [SugarColumn(ColumnName = "Mc078", ColumnDescription = "分割标识", Length = 1)]
        public string Mc078 { get; set; }

        /// <summary>
        /// 计划版本
        /// </summary>
        [SugarColumn(ColumnName = "Mc079", ColumnDescription = "计划版本", Length = 1)]
        public string Mc079 { get; set; }

        /// <summary>
        /// 对象类型
        /// </summary>
        [SugarColumn(ColumnName = "Mc080", ColumnDescription = "对象类型", Length = 1)]
        public string Mc080 { get; set; }

        /// <summary>
        /// 对象标识
        /// </summary>
        [SugarColumn(ColumnName = "Mc081", ColumnDescription = "对象标识", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc081 { get; set; }

        /// <summary>
        /// 可用性检查
        /// </summary>
        [SugarColumn(ColumnName = "Mc082", ColumnDescription = "可用性检查", Length = 1)]
        public string Mc082 { get; set; }

        /// <summary>
        /// 会计年度变式
        /// </summary>
        [SugarColumn(ColumnName = "Mc083", ColumnDescription = "会计年度变式", Length = 4)]
        public string Mc083 { get; set; }

        /// <summary>
        /// 修正因子
        /// </summary>
        [SugarColumn(ColumnName = "Mc084", ColumnDescription = "修正因子", Length = 2)]
        public string Mc084 { get; set; }

        /// <summary>
        /// 准备时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc085", ColumnDescription = "准备时间", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc085 { get; set; }

        /// <summary>
        /// 基准数量
        /// </summary>
        [SugarColumn(ColumnName = "Mc086", ColumnDescription = "基准数量", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc086 { get; set; }

        /// <summary>
        /// 处理时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc087", ColumnDescription = "处理时间", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc087 { get; set; }

        /// <summary>
        /// 取消激活的
        /// </summary>
        [SugarColumn(ColumnName = "Mc088", ColumnDescription = "取消激活的", Length = 8)]
        public string Mc088 { get; set; }

        /// <summary>
        /// 货源
        /// </summary>
        [SugarColumn(ColumnName = "Mc089", ColumnDescription = "货源", Length = 2)]
        public string Mc089 { get; set; }

        /// <summary>
        /// 自动采购订单
        /// </summary>
        [SugarColumn(ColumnName = "Mc090", ColumnDescription = "自动采购订单", Length = 2)]
        public string Mc090 { get; set; }

        /// <summary>
        /// 源清单
        /// </summary>
        [SugarColumn(ColumnName = "Mc091", ColumnDescription = "源清单", Length = 2)]
        public string Mc091 { get; set; }

        /// <summary>
        /// 商品代码
        /// </summary>
        [SugarColumn(ColumnName = "Mc092", ColumnDescription = "商品代码", Length = 34)]
        public string Mc092 { get; set; }

        /// <summary>
        /// 原产地国
        /// </summary>
        [SugarColumn(ColumnName = "Mc093", ColumnDescription = "原产地国", Length = 6)]
        public string Mc093 { get; set; }

        /// <summary>
        /// 货源地
        /// </summary>
        [SugarColumn(ColumnName = "Mc094", ColumnDescription = "货源地", Length = 6)]
        public string Mc094 { get; set; }

        /// <summary>
        /// 商品代码单位
        /// </summary>
        [SugarColumn(ColumnName = "Mc095", ColumnDescription = "商品代码单位", Length = 6)]
        public string Mc095 { get; set; }

        /// <summary>
        /// 出口/进口组
        /// </summary>
        [SugarColumn(ColumnName = "Mc096", ColumnDescription = "出口/进口组", Length = 8)]
        public string Mc096 { get; set; }

        /// <summary>
        /// 利润中心
        /// </summary>
        [SugarColumn(ColumnName = "Mc097", ColumnDescription = "利润中心", Length = 20)]
        public string Mc097 { get; set; }

        /// <summary>
        /// 在途库存
        /// </summary>
        [SugarColumn(ColumnName = "Mc098", ColumnDescription = "在途库存", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc098 { get; set; }

        /// <summary>
        /// 计划日历
        /// </summary>
        [SugarColumn(ColumnName = "Mc099", ColumnDescription = "计划日历", Length = 6)]
        public string Mc099 { get; set; }

        /// <summary>
        /// 重复生产
        /// </summary>
        [SugarColumn(ColumnName = "Mc100", ColumnDescription = "重复生产", Length = 2)]
        public string Mc100 { get; set; }

        /// <summary>
        /// 计划的时界
        /// </summary>
        [SugarColumn(ColumnName = "Mc101", ColumnDescription = "计划的时界", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc101 { get; set; }

        /// <summary>
        /// 消耗模式
        /// </summary>
        [SugarColumn(ColumnName = "Mc102", ColumnDescription = "消耗模式", Length = 2)]
        public string Mc102 { get; set; }

        /// <summary>
        /// 消耗期间:逆向
        /// </summary>
        [SugarColumn(ColumnName = "Mc103", ColumnDescription = "消耗期间:逆向", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc103 { get; set; }

        /// <summary>
        /// 消耗时期-向前
        /// </summary>
        [SugarColumn(ColumnName = "Mc104", ColumnDescription = "消耗时期-向前", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc104 { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        [SugarColumn(ColumnName = "Mc105", ColumnDescription = "版本", Length = 2)]
        public string Mc105 { get; set; }

        /// <summary>
        /// 可选 BOM
        /// </summary>
        [SugarColumn(ColumnName = "Mc106", ColumnDescription = "可选 BOM", Length = 4)]
        public string Mc106 { get; set; }

        /// <summary>
        /// BOM 用途
        /// </summary>
        [SugarColumn(ColumnName = "Mc107", ColumnDescription = "BOM 用途", Length = 2)]
        public string Mc107 { get; set; }

        /// <summary>
        /// 组
        /// </summary>
        [SugarColumn(ColumnName = "Mc108", ColumnDescription = "组", Length = 16)]
        public string Mc108 { get; set; }

        /// <summary>
        /// 组计数器
        /// </summary>
        [SugarColumn(ColumnName = "Mc109", ColumnDescription = "组计数器", Length = 4)]
        public string Mc109 { get; set; }

        /// <summary>
        /// 成本核算批次
        /// </summary>
        [SugarColumn(ColumnName = "Mc110", ColumnDescription = "成本核算批次", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc110 { get; set; }

        /// <summary>
        /// 特殊工艺类型
        /// </summary>
        [SugarColumn(ColumnName = "Mc111", ColumnDescription = "特殊工艺类型", Length = 4)]
        public string Mc111 { get; set; }

        /// <summary>
        /// 生产单位
        /// </summary>
        [SugarColumn(ColumnName = "Mc112", ColumnDescription = "生产单位", Length = 6)]
        public string Mc112 { get; set; }

        /// <summary>
        /// 发货库存地点
        /// </summary>
        [SugarColumn(ColumnName = "Mc113", ColumnDescription = "发货库存地点", Length = 8)]
        public string Mc113 { get; set; }

        /// <summary>
        /// MRP组
        /// </summary>
        [SugarColumn(ColumnName = "Mc114", ColumnDescription = "MRP组", Length = 8)]
        public string Mc114 { get; set; }

        /// <summary>
        /// 组件报废
        /// </summary>
        [SugarColumn(ColumnName = "Mc115", ColumnDescription = "组件报废", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc115 { get; set; }

        /// <summary>
        /// 证书类型
        /// </summary>
        [SugarColumn(ColumnName = "Mc116", ColumnDescription = "证书类型", Length = 8)]
        public string Mc116 { get; set; }

        /// <summary>
        /// 检验设置
        /// </summary>
        [SugarColumn(ColumnName = "Mc117", ColumnDescription = "检验设置", Length = 2)]
        public string Mc117 { get; set; }

        /// <summary>
        /// 间隔时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc118", ColumnDescription = "间隔时间", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc118 { get; set; }

        /// <summary>
        /// 供货天数参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Mc119", ColumnDescription = "供货天数参数文件", Length = 6)]
        public string Mc119 { get; set; }

        /// <summary>
        /// 局部字段名
        /// </summary>
        [SugarColumn(ColumnName = "Mc120", ColumnDescription = "局部字段名", Length = 20)]
        public string Mc120 { get; set; }

        /// <summary>
        /// 周期盘点标识
        /// </summary>
        [SugarColumn(ColumnName = "Mc121", ColumnDescription = "周期盘点标识", Length = 2)]
        public string Mc121 { get; set; }

        /// <summary>
        /// 差异码
        /// </summary>
        [SugarColumn(ColumnName = "Mc122", ColumnDescription = "差异码", Length = 12)]
        public string Mc122 { get; set; }

        /// <summary>
        /// 序列号参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Mc123", ColumnDescription = "序列号参数文件", Length = 1)]
        public string Mc123 { get; set; }

        /// <summary>
        /// 内部对象号
        /// </summary>
        [SugarColumn(ColumnName = "Mc124", ColumnDescription = "内部对象号", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc124 { get; set; }

        /// <summary>
        /// 可配置的物料
        /// </summary>
        [SugarColumn(ColumnName = "Mc125", ColumnDescription = "可配置的物料", Length = 1)]
        public string Mc125 { get; set; }

        /// <summary>
        /// 重复生产参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Mc126", ColumnDescription = "重复生产参数文件", Length = 8)]
        public string Mc126 { get; set; }

        /// <summary>
        /// 负库存
        /// </summary>
        [SugarColumn(ColumnName = "Mc127", ColumnDescription = "负库存", Length = 2)]
        public string Mc127 { get; set; }

        /// <summary>
        /// 目标QM系统
        /// </summary>
        [SugarColumn(ColumnName = "Mc128", ColumnDescription = "目标QM系统", Length = 8)]
        public string Mc128 { get; set; }

        /// <summary>
        /// 计划周期
        /// </summary>
        [SugarColumn(ColumnName = "Mc129", ColumnDescription = "计划周期", Length = 1)]
        public string Mc129 { get; set; }

        /// <summary>
        /// 舍入参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Mc130", ColumnDescription = "舍入参数文件", Length = 8)]
        public string Mc130 { get; set; }

        /// <summary>
        /// 消耗
        /// </summary>
        [SugarColumn(ColumnName = "Mc131", ColumnDescription = "消耗", Length = 36)]
        public string Mc131 { get; set; }

        /// <summary>
        /// 寄存
        /// </summary>
        [SugarColumn(ColumnName = "Mc132", ColumnDescription = "寄存", Length = 8)]
        public string Mc132 { get; set; }

        /// <summary>
        /// 消耗日期到
        /// </summary>
        public DateTime? Mc133 { get; set; }

        /// <summary>
        /// 乘数
        /// </summary>
        [SugarColumn(ColumnName = "Mc134", ColumnDescription = "乘数", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc134 { get; set; }

        /// <summary>
        /// 自动重置
        /// </summary>
        [SugarColumn(ColumnName = "Mc135", ColumnDescription = "自动重置", Length = 2)]
        public string Mc135 { get; set; }

        /// <summary>
        /// 优先权
        /// </summary>
        [SugarColumn(ColumnName = "Mc136", ColumnDescription = "优先权", Length = 2)]
        public string Mc136 { get; set; }

        /// <summary>
        /// 免税证明
        /// </summary>
        [SugarColumn(ColumnName = "Mc137", ColumnDescription = "免税证明", Length = 2)]
        public string Mc137 { get; set; }

        /// <summary>
        /// 免税证书编号
        /// </summary>
        [SugarColumn(ColumnName = "Mc138", ColumnDescription = "免税证书编号", Length = 16)]
        public string Mc138 { get; set; }

        /// <summary>
        /// 免税证书的发放日
        /// </summary>
        public DateTime? Mc139 { get; set; }

        /// <summary>
        /// 供应商申报
        /// </summary>
        [SugarColumn(ColumnName = "Mc140", ColumnDescription = "供应商申报", Length = 2)]
        public string Mc140 { get; set; }

        /// <summary>
        /// 供应商申报日期
        /// </summary>
        public DateTime? Mc141 { get; set; }

        /// <summary>
        /// 军用物资
        /// </summary>
        [SugarColumn(ColumnName = "Mc142", ColumnDescription = "军用物资", Length = 2)]
        public string Mc142 { get; set; }

        /// <summary>
        /// 服务级别
        /// </summary>
        [SugarColumn(ColumnName = "Mc143", ColumnDescription = "服务级别", Length = 2)]
        public string Mc143 { get; set; }

        /// <summary>
        /// 联产品
        /// </summary>
        [SugarColumn(ColumnName = "Mc144", ColumnDescription = "联产品", Length = 2)]
        public string Mc144 { get; set; }

        /// <summary>
        /// 策略组
        /// </summary>
        [SugarColumn(ColumnName = "Mc145", ColumnDescription = "策略组", Length = 4)]
        public string Mc145 { get; set; }

        /// <summary>
        /// 内部对象号
        /// </summary>
        [SugarColumn(ColumnName = "Mc146", ColumnDescription = "内部对象号", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc146 { get; set; }

        /// <summary>
        /// 外部采购仓储位置
        /// </summary>
        [SugarColumn(ColumnName = "Mc147", ColumnDescription = "外部采购仓储位置", Length = 8)]
        public string Mc147 { get; set; }

        /// <summary>
        /// 散装物料
        /// </summary>
        [SugarColumn(ColumnName = "Mc148", ColumnDescription = "散装物料", Length = 2)]
        public string Mc148 { get; set; }

        /// <summary>
        /// 周期标识被固定
        /// </summary>
        [SugarColumn(ColumnName = "Mc149", ColumnDescription = "周期标识被固定", Length = 2)]
        public string Mc149 { get; set; }

        /// <summary>
        /// 库存确定组
        /// </summary>
        [SugarColumn(ColumnName = "Mc150", ColumnDescription = "库存确定组", Length = 8)]
        public string Mc150 { get; set; }

        /// <summary>
        /// QM 物料授权组
        /// </summary>
        [SugarColumn(ColumnName = "Mc151", ColumnDescription = "QM 物料授权组", Length = 12)]
        public string Mc151 { get; set; }

        /// <summary>
        /// 调整期间
        /// </summary>
        [SugarColumn(ColumnName = "Mc152", ColumnDescription = "调整期间", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc152 { get; set; }

        /// <summary>
        /// 任务清单类型
        /// </summary>
        [SugarColumn(ColumnName = "Mc153", ColumnDescription = "任务清单类型", Length = 2)]
        public string Mc153 { get; set; }

        /// <summary>
        /// 计量单位组
        /// </summary>
        [SugarColumn(ColumnName = "Mc154", ColumnDescription = "计量单位组", Length = 6)]
        public string Mc154 { get; set; }

        /// <summary>
        /// 转换组
        /// </summary>
        [SugarColumn(ColumnName = "Mc155", ColumnDescription = "转换组", Length = 8)]
        public string Mc155 { get; set; }

        /// <summary>
        /// 空气浮力因子
        /// </summary>
        [SugarColumn(ColumnName = "Mc156", ColumnDescription = "空气浮力因子", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc156 { get; set; }

        /// <summary>
        /// 生产参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Mc157", ColumnDescription = "生产参数文件", Length = 12)]
        public string Mc157 { get; set; }

        /// <summary>
        /// 安全时间标识
        /// </summary>
        [SugarColumn(ColumnName = "Mc158", ColumnDescription = "安全时间标识", Length = 2)]
        public string Mc158 { get; set; }

        /// <summary>
        /// 安全时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc159", ColumnDescription = "安全时间", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc159 { get; set; }

        /// <summary>
        /// 活动控制
        /// </summary>
        [SugarColumn(ColumnName = "Mc160", ColumnDescription = "活动控制", Length = 4)]
        public string Mc160 { get; set; }

        /// <summary>
        /// 批量输入
        /// </summary>
        [SugarColumn(ColumnName = "Mc161", ColumnDescription = "批量输入", Length = 2)]
        public string Mc161 { get; set; }

        /// <summary>
        /// 计量单位组
        /// </summary>
        [SugarColumn(ColumnName = "Mc162", ColumnDescription = "计量单位组", Length = 8)]
        public string Mc162 { get; set; }

        /// <summary>
        /// 物料运输组
        /// </summary>
        [SugarColumn(ColumnName = "Mc163", ColumnDescription = "物料运输组", Length = 16)]
        public string Mc163 { get; set; }

        /// <summary>
        /// 库存转移SV
        /// </summary>
        [SugarColumn(ColumnName = "Mc164", ColumnDescription = "库存转移SV", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc164 { get; set; }

        /// <summary>
        /// 运输库存SP
        /// </summary>
        [SugarColumn(ColumnName = "Mc165", ColumnDescription = "运输库存SP", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc165 { get; set; }

        /// <summary>
        /// 平滑促销消耗
        /// </summary>
        [SugarColumn(ColumnName = "Mc166", ColumnDescription = "平滑促销消耗", Length = 2)]
        public string Mc166 { get; set; }

        /// <summary>
        /// 生产版本
        /// </summary>
        [SugarColumn(ColumnName = "Mc167", ColumnDescription = "生产版本", Length = 8)]
        public string Mc167 { get; set; }

        /// <summary>
        /// 固定价格联产品
        /// </summary>
        [SugarColumn(ColumnName = "Mc168", ColumnDescription = "固定价格联产品", Length = 2)]
        public string Mc168 { get; set; }

        /// <summary>
        /// 后勤组
        /// </summary>
        [SugarColumn(ColumnName = "Mc169", ColumnDescription = "后勤组", Length = 8)]
        public string Mc169 { get; set; }

        /// <summary>
        /// 分销参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Mc170", ColumnDescription = "分销参数文件", Length = 6)]
        public string Mc170 { get; set; }

        /// <summary>
        /// 有约束的虚拟库存
        /// </summary>
        [SugarColumn(ColumnName = "Mc171", ColumnDescription = "有约束的虚拟库存", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc171 { get; set; }

        /// <summary>
        /// 空缺库存销售价
        /// </summary>
        [SugarColumn(ColumnName = "Mc172", ColumnDescription = "空缺库存销售价", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc172 { get; set; }

        /// <summary>
        /// 物料类别
        /// </summary>
        [SugarColumn(ColumnName = "Mc173", ColumnDescription = "物料类别", Length = 4)]
        public string Mc173 { get; set; }

        /// <summary>
        /// EU产品清单编号
        /// </summary>
        [SugarColumn(ColumnName = "Mc174", ColumnDescription = "EU产品清单编号", Length = 24)]
        public string Mc174 { get; set; }

        /// <summary>
        /// CAP 产品组
        /// </summary>
        [SugarColumn(ColumnName = "Mc175", ColumnDescription = "CAP 产品组", Length = 12)]
        public string Mc175 { get; set; }

        /// <summary>
        /// CAS 号码
        /// </summary>
        [SugarColumn(ColumnName = "Mc176", ColumnDescription = "CAS 号码", Length = 30)]
        public string Mc176 { get; set; }

        /// <summary>
        /// PRODCOM 号码
        /// </summary>
        [SugarColumn(ColumnName = "Mc177", ColumnDescription = "PRODCOM 号码", Length = 18)]
        public string Mc177 { get; set; }

        /// <summary>
        /// 控制代码
        /// </summary>
        [SugarColumn(ColumnName = "Mc178", ColumnDescription = "控制代码", Length = 32)]
        public string Mc178 { get; set; }

        /// <summary>
        /// JIT标识
        /// </summary>
        [SugarColumn(ColumnName = "Mc179", ColumnDescription = "JIT标识", Length = 2)]
        public string Mc179 { get; set; }

        /// <summary>
        /// 物料组
        /// </summary>
        [SugarColumn(ColumnName = "Mc180", ColumnDescription = "物料组", Length = 40)]
        public string Mc180 { get; set; }

        /// <summary>
        /// 建议供应区域
        /// </summary>
        [SugarColumn(ColumnName = "Mc181", ColumnDescription = "建议供应区域", Length = 20)]
        public string Mc181 { get; set; }

        /// <summary>
        /// 公平分享规则
        /// </summary>
        [SugarColumn(ColumnName = "Mc182", ColumnDescription = "公平分享规则", Length = 4)]
        public string Mc182 { get; set; }

        /// <summary>
        /// 推式分配
        /// </summary>
        [SugarColumn(ColumnName = "Mc183", ColumnDescription = "推式分配", Length = 2)]
        public string Mc183 { get; set; }

        /// <summary>
        /// 发布界限
        /// </summary>
        [SugarColumn(ColumnName = "Mc184", ColumnDescription = "发布界限", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc184 { get; set; }

        /// <summary>
        /// 最小批量
        /// </summary>
        [SugarColumn(ColumnName = "Mc185", ColumnDescription = "最小批量", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc185 { get; set; }

        /// <summary>
        /// 最大批量
        /// </summary>
        [SugarColumn(ColumnName = "Mc186", ColumnDescription = "最大批量", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc186 { get; set; }

        /// <summary>
        /// 固定批量
        /// </summary>
        [SugarColumn(ColumnName = "Mc187", ColumnDescription = "固定批量", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc187 { get; set; }

        /// <summary>
        /// 批尺寸增加
        /// </summary>
        [SugarColumn(ColumnName = "Mc188", ColumnDescription = "批尺寸增加", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc188 { get; set; }

        /// <summary>
        /// 该字段不再使用
        /// </summary>
        [SugarColumn(ColumnName = "Mc189", ColumnDescription = "该字段不再使用", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc189 { get; set; }

        /// <summary>
        /// 转换类型
        /// </summary>
        [SugarColumn(ColumnName = "Mc190", ColumnDescription = "转换类型", Length = 4)]
        public string Mc190 { get; set; }

        /// <summary>
        /// ST期间参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Mc191", ColumnDescription = "ST期间参数文件", Length = 6)]
        public string Mc191 { get; set; }

        /// <summary>
        /// MRP 相关需求
        /// </summary>
        [SugarColumn(ColumnName = "Mc192", ColumnDescription = "MRP 相关需求", Length = 2)]
        public string Mc192 { get; set; }

        /// <summary>
        /// MRP 范围存在
        /// </summary>
        [SugarColumn(ColumnName = "Mc193", ColumnDescription = "MRP 范围存在", Length = 2)]
        public string Mc193 { get; set; }

        /// <summary>
        /// 跨项目
        /// </summary>
        [SugarColumn(ColumnName = "Mc194", ColumnDescription = "跨项目", Length = 2)]
        public string Mc194 { get; set; }

        /// <summary>
        /// 总体参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Mc195", ColumnDescription = "总体参数文件", Length = 12)]
        public string Mc195 { get; set; }

        /// <summary>
        /// APO 相关
        /// </summary>
        [SugarColumn(ColumnName = "Mc196", ColumnDescription = "APO 相关", Length = 2)]
        public string Mc196 { get; set; }

        /// <summary>
        /// 最后的MARD
        /// </summary>
        [SugarColumn(ColumnName = "Mc197", ColumnDescription = "最后的MARD", Length = 2)]
        public string Mc197 { get; set; }

        /// <summary>
        /// 当前期间 (记帐期间)
        /// </summary>
        [SugarColumn(ColumnName = "Mc198", ColumnDescription = "当前期间 (记帐期间)", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc198 { get; set; }

        /// <summary>
        /// 当前期间的会计年度
        /// </summary>
        [SugarColumn(ColumnName = "Mc199", ColumnDescription = "当前期间的会计年度", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc199 { get; set; }

        /// <summary>
        /// 最小安全库存
        /// </summary>
        [SugarColumn(ColumnName = "Mc200", ColumnDescription = "最小安全库存", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc200 { get; set; }

        /// <summary>
        /// 无成本核算
        /// </summary>
        [SugarColumn(ColumnName = "Mc201", ColumnDescription = "无成本核算", Length = 2)]
        public string Mc201 { get; set; }

        /// <summary>
        /// 库存入库和出库
        /// </summary>
        [SugarColumn(ColumnName = "Mc202", ColumnDescription = "库存入库和出库", Length = 2)]
        public string Mc202 { get; set; }

        /// <summary>
        /// OB管理
        /// </summary>
        [SugarColumn(ColumnName = "Mc203", ColumnDescription = "OB管理", Length = 2)]
        public string Mc203 { get; set; }

        /// <summary>
        /// OB参考物料
        /// </summary>
        [SugarColumn(ColumnName = "Mc204", ColumnDescription = "OB参考物料", Length = 36)]
        public string Mc204 { get; set; }

        /// <summary>
        /// 评估收货锁定库存
        /// </summary>
        [SugarColumn(ColumnName = "Mc205", ColumnDescription = "评估收货锁定库存", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc205 { get; set; }

        /// <summary>
        /// 分段策略
        /// </summary>
        [SugarColumn(ColumnName = "Mc206", ColumnDescription = "分段策略", Length = 16)]
        public string Mc206 { get; set; }

        /// <summary>
        /// 分段状态
        /// </summary>
        [SugarColumn(ColumnName = "Mc207", ColumnDescription = "分段状态", Length = 2)]
        public string Mc207 { get; set; }

        /// <summary>
        /// 分段范围
        /// </summary>
        [SugarColumn(ColumnName = "Mc208", ColumnDescription = "分段范围", Length = 2)]
        public string Mc208 { get; set; }

        /// <summary>
        /// 排序库存
        /// </summary>
        [SugarColumn(ColumnName = "Mc209", ColumnDescription = "排序库存", Length = 2)]
        public string Mc209 { get; set; }

        /// <summary>
        /// 消耗优先级
        /// </summary>
        [SugarColumn(ColumnName = "Mc210", ColumnDescription = "消耗优先级", Length = 2)]
        public string Mc210 { get; set; }

        /// <summary>
        /// 离散批次编号
        /// </summary>
        [SugarColumn(ColumnName = "Mc211", ColumnDescription = "离散批次编号", Length = 2)]
        public string Mc211 { get; set; }

        /// <summary>
        /// 库存保护
        /// </summary>
        [SugarColumn(ColumnName = "Mc212", ColumnDescription = "库存保护", Length = 2)]
        public string Mc212 { get; set; }

        /// <summary>
        /// 订单分配运行
        /// </summary>
        [SugarColumn(ColumnName = "Mc213", ColumnDescription = "订单分配运行", Length = 2)]
        public string Mc213 { get; set; }

        /// <summary>
        /// 库存管理中激活季节
        /// </summary>
        [SugarColumn(ColumnName = "Mc214", ColumnDescription = "库存管理中激活季节", Length = 2)]
        public string Mc214 { get; set; }

        /// <summary>
        /// 包装组 (VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Mc215", ColumnDescription = "包装组 (VSO)", Length = 36)]
        public string Mc215 { get; set; }

        /// <summary>
        /// 提货行 (VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Mc216", ColumnDescription = "提货行 (VSO)", Length = 6)]
        public string Mc216 { get; set; }

        /// <summary>
        /// 物料编号 (VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Mc217", ColumnDescription = "物料编号 (VSO)", Length = 36)]
        public string Mc217 { get; set; }

        /// <summary>
        /// 纵向提取
        /// </summary>
        [SugarColumn(ColumnName = "Mc218", ColumnDescription = "纵向提取", Length = 2)]
        public string Mc218 { get; set; }

        /// <summary>
        /// IUID相关
        /// </summary>
        [SugarColumn(ColumnName = "Mc219", ColumnDescription = "IUID相关", Length = 2)]
        public string Mc219 { get; set; }

        /// <summary>
        /// IUID类型
        /// </summary>
        [SugarColumn(ColumnName = "Mc220", ColumnDescription = "IUID类型", Length = 20)]
        public string Mc220 { get; set; }

        /// <summary>
        /// 外部分配
        /// </summary>
        [SugarColumn(ColumnName = "Mc221", ColumnDescription = "外部分配", Length = 2)]
        public string Mc221 { get; set; }

        /// <summary>
        /// 寄售控制
        /// </summary>
        [SugarColumn(ColumnName = "Mc222", ColumnDescription = "寄售控制", Length = 2)]
        public string Mc222 { get; set; }

        /// <summary>
        /// 发货处理时间
        /// </summary>
        [SugarColumn(ColumnName = "Mc223", ColumnDescription = "发货处理时间", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc223 { get; set; }

        /// <summary>
        /// 交叉的采购组
        /// </summary>
        [SugarColumn(ColumnName = "Mc224", ColumnDescription = "交叉的采购组", Length = 2)]
        public string Mc224 { get; set; }

        /// <summary>
        /// 参考确定方案
        /// </summary>
        [SugarColumn(ColumnName = "Mc225", ColumnDescription = "参考确定方案", Length = 4)]
        public string Mc225 { get; set; }

        /// <summary>
        /// 最小目标范围
        /// </summary>
        [SugarColumn(ColumnName = "Mc226", ColumnDescription = "最小目标范围", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc226 { get; set; }

        /// <summary>
        /// 最大目标范围
        /// </summary>
        [SugarColumn(ColumnName = "Mc227", ColumnDescription = "最大目标范围", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mc227 { get; set; }

        /// <summary>
        /// 目标库存
        /// </summary>
        [SugarColumn(ColumnName = "Mc228", ColumnDescription = "目标库存", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mc228 { get; set; }
    }
}