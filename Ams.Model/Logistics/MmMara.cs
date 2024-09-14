namespace Ams.Model.Logistics
{
    /// <summary>
    /// 常规物料
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 10:59:57
    /// </summary>
    [SugarTable("mm_mara", "常规物料")]
    public class MmMara : SysBase
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
        [SugarColumn(ColumnName = "Ma002", ColumnDescription = "集团", Length = 6)]
        public string Ma002 { get; set; }

        /// <summary>
        /// 物料号
        /// </summary>
        [SugarColumn(ColumnName = "Ma003", ColumnDescription = "物料号", Length = 36, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma003 { get; set; }

        /// <summary>
        /// 完整状态
        /// </summary>
        [SugarColumn(ColumnName = "Ma004", ColumnDescription = "完整状态", Length = 30)]
        public string Ma004 { get; set; }

        /// <summary>
        /// 维护状态
        /// </summary>
        [SugarColumn(ColumnName = "Ma005", ColumnDescription = "维护状态", Length = 30)]
        public string Ma005 { get; set; }

        /// <summary>
        /// 集团删除
        /// </summary>
        [SugarColumn(ColumnName = "Ma006", ColumnDescription = "集团删除", Length = 2)]
        public string Ma006 { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        [SugarColumn(ColumnName = "Ma007", ColumnDescription = "物料类型", Length = 8, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma007 { get; set; }

        /// <summary>
        /// 行业领域
        /// </summary>
        [SugarColumn(ColumnName = "Ma008", ColumnDescription = "行业领域", Length = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma008 { get; set; }

        /// <summary>
        /// 物料组
        /// </summary>
        [SugarColumn(ColumnName = "Ma009", ColumnDescription = "物料组", Length = 18)]
        public string Ma009 { get; set; }

        /// <summary>
        /// 旧物料号
        /// </summary>
        [SugarColumn(ColumnName = "Ma010", ColumnDescription = "旧物料号", Length = 36)]
        public string Ma010 { get; set; }

        /// <summary>
        /// 基本单位
        /// </summary>
        [SugarColumn(ColumnName = "Ma011", ColumnDescription = "基本单位", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma011 { get; set; }

        /// <summary>
        /// 订单单位
        /// </summary>
        [SugarColumn(ColumnName = "Ma012", ColumnDescription = "订单单位", Length = 6)]
        public string Ma012 { get; set; }

        /// <summary>
        /// 凭证
        /// </summary>
        [SugarColumn(ColumnName = "Ma013", ColumnDescription = "凭证", Length = 44)]
        public string Ma013 { get; set; }

        /// <summary>
        /// 凭证类型
        /// </summary>
        [SugarColumn(ColumnName = "Ma014", ColumnDescription = "凭证类型", Length = 6)]
        public string Ma014 { get; set; }

        /// <summary>
        /// 凭证版本
        /// </summary>
        [SugarColumn(ColumnName = "Ma015", ColumnDescription = "凭证版本", Length = 4)]
        public string Ma015 { get; set; }

        /// <summary>
        /// 页面大小
        /// </summary>
        [SugarColumn(ColumnName = "Ma016", ColumnDescription = "页面大小", Length = 8)]
        public string Ma016 { get; set; }

        /// <summary>
        /// 文档变更号
        /// </summary>
        [SugarColumn(ColumnName = "Ma017", ColumnDescription = "文档变更号", Length = 12)]
        public string Ma017 { get; set; }

        /// <summary>
        /// 页号
        /// </summary>
        [SugarColumn(ColumnName = "Ma018", ColumnDescription = "页号", Length = 6)]
        public string Ma018 { get; set; }

        /// <summary>
        /// 页数
        /// </summary>
        [SugarColumn(ColumnName = "Ma019", ColumnDescription = "页数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma019 { get; set; }

        /// <summary>
        /// 备忘录
        /// </summary>
        [SugarColumn(ColumnName = "Ma020", ColumnDescription = "备忘录", Length = 36)]
        public string Ma020 { get; set; }

        /// <summary>
        /// 页格式
        /// </summary>
        [SugarColumn(ColumnName = "Ma021", ColumnDescription = "页格式", Length = 8)]
        public string Ma021 { get; set; }

        /// <summary>
        /// 大小/量纲
        /// </summary>
        [SugarColumn(ColumnName = "Ma022", ColumnDescription = "大小/量纲", Length = 64)]
        public string Ma022 { get; set; }

        /// <summary>
        /// 基本物料
        /// </summary>
        [SugarColumn(ColumnName = "Ma023", ColumnDescription = "基本物料", Length = 96)]
        public string Ma023 { get; set; }

        /// <summary>
        /// 行业标准
        /// </summary>
        [SugarColumn(ColumnName = "Ma024", ColumnDescription = "行业标准", Length = 36)]
        public string Ma024 { get; set; }

        /// <summary>
        /// 实验室/设计室
        /// </summary>
        [SugarColumn(ColumnName = "Ma025", ColumnDescription = "实验室/设计室", Length = 6)]
        public string Ma025 { get; set; }

        /// <summary>
        /// 采购值代码
        /// </summary>
        [SugarColumn(ColumnName = "Ma026", ColumnDescription = "采购值代码", Length = 8)]
        public string Ma026 { get; set; }

        /// <summary>
        /// 毛重
        /// </summary>
        [SugarColumn(ColumnName = "Ma027", ColumnDescription = "毛重", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma027 { get; set; }

        /// <summary>
        /// 净重
        /// </summary>
        [SugarColumn(ColumnName = "Ma028", ColumnDescription = "净重", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma028 { get; set; }

        /// <summary>
        /// 重量单位
        /// </summary>
        [SugarColumn(ColumnName = "Ma029", ColumnDescription = "重量单位", Length = 6)]
        public string Ma029 { get; set; }

        /// <summary>
        /// 业务量
        /// </summary>
        [SugarColumn(ColumnName = "Ma030", ColumnDescription = "业务量", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma030 { get; set; }

        /// <summary>
        /// 体积单位
        /// </summary>
        [SugarColumn(ColumnName = "Ma031", ColumnDescription = "体积单位", Length = 6)]
        public string Ma031 { get; set; }

        /// <summary>
        /// 容器需求
        /// </summary>
        [SugarColumn(ColumnName = "Ma032", ColumnDescription = "容器需求", Length = 4)]
        public string Ma032 { get; set; }

        /// <summary>
        /// 存储条件
        /// </summary>
        [SugarColumn(ColumnName = "Ma033", ColumnDescription = "存储条件", Length = 4)]
        public string Ma033 { get; set; }

        /// <summary>
        /// 温度
        /// </summary>
        [SugarColumn(ColumnName = "Ma034", ColumnDescription = "温度", Length = 4)]
        public string Ma034 { get; set; }

        /// <summary>
        /// 低层代码
        /// </summary>
        [SugarColumn(ColumnName = "Ma035", ColumnDescription = "低层代码", Length = 6)]
        public string Ma035 { get; set; }

        /// <summary>
        /// 运输组
        /// </summary>
        [SugarColumn(ColumnName = "Ma036", ColumnDescription = "运输组", Length = 8)]
        public string Ma036 { get; set; }

        /// <summary>
        /// 危险物料号
        /// </summary>
        [SugarColumn(ColumnName = "Ma037", ColumnDescription = "危险物料号", Length = 36)]
        public string Ma037 { get; set; }

        /// <summary>
        /// 产品组
        /// </summary>
        [SugarColumn(ColumnName = "Ma038", ColumnDescription = "产品组", Length = 4)]
        public string Ma038 { get; set; }

        /// <summary>
        /// 竞争者
        /// </summary>
        [SugarColumn(ColumnName = "Ma039", ColumnDescription = "竞争者", Length = 20)]
        public string Ma039 { get; set; }

        /// <summary>
        /// EAN号
        /// </summary>
        [SugarColumn(ColumnName = "Ma040", ColumnDescription = "EAN号", Length = 1)]
        public string Ma040 { get; set; }

        /// <summary>
        /// GR单数量
        /// </summary>
        [SugarColumn(ColumnName = "Ma041", ColumnDescription = "GR单数量", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma041 { get; set; }

        /// <summary>
        /// 采购规则
        /// </summary>
        [SugarColumn(ColumnName = "Ma042", ColumnDescription = "采购规则", Length = 1)]
        public string Ma042 { get; set; }

        /// <summary>
        /// 货源
        /// </summary>
        [SugarColumn(ColumnName = "Ma043", ColumnDescription = "货源", Length = 2)]
        public string Ma043 { get; set; }

        /// <summary>
        /// 季节
        /// </summary>
        [SugarColumn(ColumnName = "Ma044", ColumnDescription = "季节", Length = 8)]
        public string Ma044 { get; set; }

        /// <summary>
        /// 标签类型
        /// </summary>
        [SugarColumn(ColumnName = "Ma045", ColumnDescription = "标签类型", Length = 4)]
        public string Ma045 { get; set; }

        /// <summary>
        /// 标签格式
        /// </summary>
        [SugarColumn(ColumnName = "Ma046", ColumnDescription = "标签格式", Length = 1)]
        public string Ma046 { get; set; }

        /// <summary>
        /// 取消激活
        /// </summary>
        [SugarColumn(ColumnName = "Ma047", ColumnDescription = "取消激活", Length = 2)]
        public string Ma047 { get; set; }

        /// <summary>
        /// EAN
        /// </summary>
        [SugarColumn(ColumnName = "Ma048", ColumnDescription = "EAN", Length = 36)]
        public string Ma048 { get; set; }

        /// <summary>
        /// EAN类别
        /// </summary>
        [SugarColumn(ColumnName = "Ma049", ColumnDescription = "EAN类别", Length = 4)]
        public string Ma049 { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        [SugarColumn(ColumnName = "Ma050", ColumnDescription = "长度", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma050 { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        [SugarColumn(ColumnName = "Ma051", ColumnDescription = "宽度", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma051 { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        [SugarColumn(ColumnName = "Ma052", ColumnDescription = "高度", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma052 { get; set; }

        /// <summary>
        /// 尺寸单位
        /// </summary>
        [SugarColumn(ColumnName = "Ma053", ColumnDescription = "尺寸单位", Length = 6)]
        public string Ma053 { get; set; }

        /// <summary>
        /// 产品层次
        /// </summary>
        [SugarColumn(ColumnName = "Ma054", ColumnDescription = "产品层次", Length = 36)]
        public string Ma054 { get; set; }

        /// <summary>
        /// 净改变成本核算
        /// </summary>
        [SugarColumn(ColumnName = "Ma055", ColumnDescription = "净改变成本核算", Length = 2)]
        public string Ma055 { get; set; }

        /// <summary>
        /// CAD标识
        /// </summary>
        [SugarColumn(ColumnName = "Ma056", ColumnDescription = "CAD标识", Length = 2)]
        public string Ma056 { get; set; }

        /// <summary>
        /// QM采购
        /// </summary>
        [SugarColumn(ColumnName = "Ma057", ColumnDescription = "QM采购", Length = 2)]
        public string Ma057 { get; set; }

        /// <summary>
        /// 允许的包装重量
        /// </summary>
        [SugarColumn(ColumnName = "Ma058", ColumnDescription = "允许的包装重量", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma058 { get; set; }

        /// <summary>
        /// 重量单位
        /// </summary>
        [SugarColumn(ColumnName = "Ma059", ColumnDescription = "重量单位", Length = 6)]
        public string Ma059 { get; set; }

        /// <summary>
        /// 允许体积
        /// </summary>
        [SugarColumn(ColumnName = "Ma060", ColumnDescription = "允许体积", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma060 { get; set; }

        /// <summary>
        /// 体积单位
        /// </summary>
        [SugarColumn(ColumnName = "Ma061", ColumnDescription = "体积单位", Length = 6)]
        public string Ma061 { get; set; }

        /// <summary>
        /// 超重量容差
        /// </summary>
        [SugarColumn(ColumnName = "Ma062", ColumnDescription = "超重量容差", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma062 { get; set; }

        /// <summary>
        /// 超体积容差
        /// </summary>
        [SugarColumn(ColumnName = "Ma063", ColumnDescription = "超体积容差", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma063 { get; set; }

        /// <summary>
        /// 可变订单单位
        /// </summary>
        [SugarColumn(ColumnName = "Ma064", ColumnDescription = "可变订单单位", Length = 2)]
        public string Ma064 { get; set; }

        /// <summary>
        /// 修订等级
        /// </summary>
        [SugarColumn(ColumnName = "Ma065", ColumnDescription = "修订等级", Length = 2)]
        public string Ma065 { get; set; }

        /// <summary>
        /// 可配置
        /// </summary>
        [SugarColumn(ColumnName = "Ma066", ColumnDescription = "可配置", Length = 2)]
        public string Ma066 { get; set; }

        /// <summary>
        /// 批次管理需求
        /// </summary>
        [SugarColumn(ColumnName = "Ma067", ColumnDescription = "批次管理需求", Length = 2)]
        public string Ma067 { get; set; }

        /// <summary>
        /// 包装物料类型
        /// </summary>
        [SugarColumn(ColumnName = "Ma068", ColumnDescription = "包装物料类型", Length = 8)]
        public string Ma068 { get; set; }

        /// <summary>
        /// 最大层次
        /// </summary>
        [SugarColumn(ColumnName = "Ma069", ColumnDescription = "最大层次", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma069 { get; set; }

        /// <summary>
        /// 堆栈因子
        /// </summary>
        [SugarColumn(ColumnName = "Ma070", ColumnDescription = "堆栈因子", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma070 { get; set; }

        /// <summary>
        /// 物料组包装物料
        /// </summary>
        [SugarColumn(ColumnName = "Ma071", ColumnDescription = "物料组包装物料", Length = 1)]
        public string Ma071 { get; set; }

        /// <summary>
        /// 权限组
        /// </summary>
        [SugarColumn(ColumnName = "Ma072", ColumnDescription = "权限组", Length = 8)]
        public string Ma072 { get; set; }

        /// <summary>
        /// 有效起始日
        /// </summary>
        public DateTime? Ma073 { get; set; }

        /// <summary>
        /// 有效结束日
        /// </summary>
        public DateTime? Ma074 { get; set; }

        /// <summary>
        /// 季度年
        /// </summary>
        [SugarColumn(ColumnName = "Ma075", ColumnDescription = "季度年", Length = 8)]
        public string Ma075 { get; set; }

        /// <summary>
        /// 价格标记
        /// </summary>
        [SugarColumn(ColumnName = "Ma076", ColumnDescription = "价格标记", Length = 4)]
        public string Ma076 { get; set; }

        /// <summary>
        /// 空白BOM
        /// </summary>
        [SugarColumn(ColumnName = "Ma077", ColumnDescription = "空白BOM", Length = 2)]
        public string Ma077 { get; set; }

        /// <summary>
        /// 外部物料组
        /// </summary>
        [SugarColumn(ColumnName = "Ma078", ColumnDescription = "外部物料组", Length = 1)]
        public string Ma078 { get; set; }

        /// <summary>
        /// 一般可配置物料
        /// </summary>
        [SugarColumn(ColumnName = "Ma079", ColumnDescription = "一般可配置物料", Length = 1)]
        public string Ma079 { get; set; }

        /// <summary>
        /// 物料类别
        /// </summary>
        [SugarColumn(ColumnName = "Ma080", ColumnDescription = "物料类别", Length = 1)]
        public string Ma080 { get; set; }

        /// <summary>
        /// 联产品
        /// </summary>
        [SugarColumn(ColumnName = "Ma081", ColumnDescription = "联产品", Length = 1)]
        public string Ma081 { get; set; }

        /// <summary>
        /// 后续物料
        /// </summary>
        [SugarColumn(ColumnName = "Ma082", ColumnDescription = "后续物料", Length = 1)]
        public string Ma082 { get; set; }

        /// <summary>
        /// 定价参考物料
        /// </summary>
        [SugarColumn(ColumnName = "Ma083", ColumnDescription = "定价参考物料", Length = 1)]
        public string Ma083 { get; set; }

        /// <summary>
        /// 跨工厂状态
        /// </summary>
        [SugarColumn(ColumnName = "Ma084", ColumnDescription = "跨工厂状态", Length = 1)]
        public string Ma084 { get; set; }

        /// <summary>
        /// 跨分销链状态
        /// </summary>
        [SugarColumn(ColumnName = "Ma085", ColumnDescription = "跨分销链状态", Length = 4)]
        public string Ma085 { get; set; }

        /// <summary>
        /// 跨工厂有效日期
        /// </summary>
        public DateTime? Ma086 { get; set; }

        /// <summary>
        /// 跨分销有效日期
        /// </summary>
        public DateTime? Ma087 { get; set; }

        /// <summary>
        /// 税收分类
        /// </summary>
        [SugarColumn(ColumnName = "Ma088", ColumnDescription = "税收分类", Length = 2)]
        public string Ma088 { get; set; }

        /// <summary>
        /// 类别参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Ma089", ColumnDescription = "类别参数文件", Length = 1)]
        public string Ma089 { get; set; }

        /// <summary>
        /// 剩余货架寿命
        /// </summary>
        [SugarColumn(ColumnName = "Ma090", ColumnDescription = "剩余货架寿命", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma090 { get; set; }

        /// <summary>
        /// 总货架寿命
        /// </summary>
        [SugarColumn(ColumnName = "Ma091", ColumnDescription = "总货架寿命", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma091 { get; set; }

        /// <summary>
        /// 仓储百分比
        /// </summary>
        [SugarColumn(ColumnName = "Ma092", ColumnDescription = "仓储百分比", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma092 { get; set; }

        /// <summary>
        /// 内容单位
        /// </summary>
        [SugarColumn(ColumnName = "Ma093", ColumnDescription = "内容单位", Length = 1)]
        public string Ma093 { get; set; }

        /// <summary>
        /// 净内容
        /// </summary>
        [SugarColumn(ColumnName = "Ma094", ColumnDescription = "净内容", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma094 { get; set; }

        /// <summary>
        /// 比较价格单位
        /// </summary>
        [SugarColumn(ColumnName = "Ma095", ColumnDescription = "比较价格单位", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma095 { get; set; }

        /// <summary>
        /// 物料组标签
        /// </summary>
        [SugarColumn(ColumnName = "Ma096", ColumnDescription = "物料组标签", Length = 36)]
        public string Ma096 { get; set; }

        /// <summary>
        /// 毛内容
        /// </summary>
        [SugarColumn(ColumnName = "Ma097", ColumnDescription = "毛内容", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma097 { get; set; }

        /// <summary>
        /// 转换方法
        /// </summary>
        [SugarColumn(ColumnName = "Ma098", ColumnDescription = "转换方法", Length = 2)]
        public string Ma098 { get; set; }

        /// <summary>
        /// 内部对象号
        /// </summary>
        [SugarColumn(ColumnName = "Ma099", ColumnDescription = "内部对象号", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma099 { get; set; }

        /// <summary>
        /// 环境相关
        /// </summary>
        [SugarColumn(ColumnName = "Ma100", ColumnDescription = "环境相关", Length = 2)]
        public string Ma100 { get; set; }

        /// <summary>
        /// 产品分配
        /// </summary>
        [SugarColumn(ColumnName = "Ma101", ColumnDescription = "产品分配", Length = 1)]
        public string Ma101 { get; set; }

        /// <summary>
        /// 定价参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Ma102", ColumnDescription = "定价参数文件", Length = 2)]
        public string Ma102 { get; set; }

        /// <summary>
        /// 折扣类型
        /// </summary>
        [SugarColumn(ColumnName = "Ma103", ColumnDescription = "折扣类型", Length = 1)]
        public string Ma103 { get; set; }

        /// <summary>
        /// 制造商零件编号
        /// </summary>
        [SugarColumn(ColumnName = "Ma104", ColumnDescription = "制造商零件编号", Length = 80)]
        public string Ma104 { get; set; }

        /// <summary>
        /// 制造商
        /// </summary>
        [SugarColumn(ColumnName = "Ma105", ColumnDescription = "制造商", Length = 1)]
        public string Ma105 { get; set; }

        /// <summary>
        /// 内部物料编号
        /// </summary>
        [SugarColumn(ColumnName = "Ma106", ColumnDescription = "内部物料编号", Length = 36)]
        public string Ma106 { get; set; }

        /// <summary>
        /// 制造商部件参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Ma107", ColumnDescription = "制造商部件参数文件", Length = 1)]
        public string Ma107 { get; set; }

        /// <summary>
        /// 测量单位用法
        /// </summary>
        [SugarColumn(ColumnName = "Ma108", ColumnDescription = "测量单位用法", Length = 2)]
        public string Ma108 { get; set; }

        /// <summary>
        /// 展开
        /// </summary>
        [SugarColumn(ColumnName = "Ma109", ColumnDescription = "展开", Length = 1)]
        public string Ma109 { get; set; }

        /// <summary>
        /// 危险货物标识参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Ma110", ColumnDescription = "危险货物标识参数文件", Length = 6)]
        public string Ma110 { get; set; }

        /// <summary>
        /// 高粘性的
        /// </summary>
        [SugarColumn(ColumnName = "Ma111", ColumnDescription = "高粘性的", Length = 1)]
        public string Ma111 { get; set; }

        /// <summary>
        /// 固体/液体
        /// </summary>
        [SugarColumn(ColumnName = "Ma112", ColumnDescription = "固体/液体", Length = 2)]
        public string Ma112 { get; set; }

        /// <summary>
        /// 序列号层次
        /// </summary>
        [SugarColumn(ColumnName = "Ma113", ColumnDescription = "序列号层次", Length = 1)]
        public string Ma113 { get; set; }

        /// <summary>
        /// 密闭
        /// </summary>
        [SugarColumn(ColumnName = "Ma114", ColumnDescription = "密闭", Length = 2)]
        public string Ma114 { get; set; }

        /// <summary>
        /// 需要批量记录
        /// </summary>
        [SugarColumn(ColumnName = "Ma115", ColumnDescription = "需要批量记录", Length = 1)]
        public string Ma115 { get; set; }

        /// <summary>
        /// 参数有效值
        /// </summary>
        [SugarColumn(ColumnName = "Ma116", ColumnDescription = "参数有效值", Length = 2)]
        public string Ma116 { get; set; }

        /// <summary>
        /// 完成水平
        /// </summary>
        [SugarColumn(ColumnName = "Ma117", ColumnDescription = "完成水平", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma117 { get; set; }

        /// <summary>
        /// 期间标识
        /// </summary>
        [SugarColumn(ColumnName = "Ma118", ColumnDescription = "期间标识", Length = 2)]
        public string Ma118 { get; set; }

        /// <summary>
        /// 舍入规则
        /// </summary>
        [SugarColumn(ColumnName = "Ma119", ColumnDescription = "舍入规则", Length = 1)]
        public string Ma119 { get; set; }

        /// <summary>
        /// 产品成份
        /// </summary>
        [SugarColumn(ColumnName = "Ma120", ColumnDescription = "产品成份", Length = 2)]
        public string Ma120 { get; set; }

        /// <summary>
        /// 普通项目类别组
        /// </summary>
        [SugarColumn(ColumnName = "Ma121", ColumnDescription = "普通项目类别组", Length = 1)]
        public string Ma121 { get; set; }

        /// <summary>
        /// 后勤变量
        /// </summary>
        [SugarColumn(ColumnName = "Ma122", ColumnDescription = "后勤变量", Length = 2)]
        public string Ma122 { get; set; }

        /// <summary>
        /// 物料被锁定
        /// </summary>
        [SugarColumn(ColumnName = "Ma123", ColumnDescription = "物料被锁定", Length = 1)]
        public string Ma123 { get; set; }

        /// <summary>
        /// 配置相关
        /// </summary>
        [SugarColumn(ColumnName = "Ma124", ColumnDescription = "配置相关", Length = 2)]
        public string Ma124 { get; set; }

        /// <summary>
        /// 分类清单类型
        /// </summary>
        [SugarColumn(ColumnName = "Ma125", ColumnDescription = "分类清单类型", Length = 1)]
        public string Ma125 { get; set; }

        /// <summary>
        /// 过期日期
        /// </summary>
        [SugarColumn(ColumnName = "Ma126", ColumnDescription = "过期日期", Length = 2)]
        public string Ma126 { get; set; }

        /// <summary>
        /// EAN变式
        /// </summary>
        [SugarColumn(ColumnName = "Ma127", ColumnDescription = "EAN变式", Length = 1)]
        public string Ma127 { get; set; }

        /// <summary>
        /// 一般物料
        /// </summary>
        [SugarColumn(ColumnName = "Ma128", ColumnDescription = "一般物料", Length = 36)]
        public string Ma128 { get; set; }

        /// <summary>
        /// 包装参考物料
        /// </summary>
        [SugarColumn(ColumnName = "Ma129", ColumnDescription = "包装参考物料", Length = 1)]
        public string Ma129 { get; set; }

        /// <summary>
        /// GDS相关
        /// </summary>
        [SugarColumn(ColumnName = "Ma130", ColumnDescription = "GDS相关", Length = 2)]
        public string Ma130 { get; set; }

        /// <summary>
        /// 原始接受
        /// </summary>
        [SugarColumn(ColumnName = "Ma131", ColumnDescription = "原始接受", Length = 1)]
        public string Ma131 { get; set; }

        /// <summary>
        /// 标准处理单位类型
        /// </summary>
        [SugarColumn(ColumnName = "Ma132", ColumnDescription = "标准处理单位类型", Length = 8)]
        public string Ma132 { get; set; }

        /// <summary>
        /// 可偷窃的
        /// </summary>
        [SugarColumn(ColumnName = "Ma133", ColumnDescription = "可偷窃的", Length = 1)]
        public string Ma133 { get; set; }

        /// <summary>
        /// 仓库存储条件
        /// </summary>
        [SugarColumn(ColumnName = "Ma134", ColumnDescription = "仓库存储条件", Length = 4)]
        public string Ma134 { get; set; }

        /// <summary>
        /// 仓库物料组
        /// </summary>
        [SugarColumn(ColumnName = "Ma135", ColumnDescription = "仓库物料组", Length = 1)]
        public string Ma135 { get; set; }

        /// <summary>
        /// 处理标识
        /// </summary>
        [SugarColumn(ColumnName = "Ma136", ColumnDescription = "处理标识", Length = 8)]
        public string Ma136 { get; set; }

        /// <summary>
        /// 危险物料
        /// </summary>
        [SugarColumn(ColumnName = "Ma137", ColumnDescription = "危险物料", Length = 1)]
        public string Ma137 { get; set; }

        /// <summary>
        /// 处理单位类型
        /// </summary>
        [SugarColumn(ColumnName = "Ma138", ColumnDescription = "处理单位类型", Length = 8)]
        public string Ma138 { get; set; }

        /// <summary>
        /// 可变皮重
        /// </summary>
        [SugarColumn(ColumnName = "Ma139", ColumnDescription = "可变皮重", Length = 1)]
        public string Ma139 { get; set; }

        /// <summary>
        /// 最大容量
        /// </summary>
        [SugarColumn(ColumnName = "Ma140", ColumnDescription = "最大容量", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma140 { get; set; }

        /// <summary>
        /// 最大容量容差
        /// </summary>
        [SugarColumn(ColumnName = "Ma141", ColumnDescription = "最大容量容差", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma141 { get; set; }

        /// <summary>
        /// 最大长度
        /// </summary>
        [SugarColumn(ColumnName = "Ma142", ColumnDescription = "最大长度", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma142 { get; set; }

        /// <summary>
        /// 最大宽度
        /// </summary>
        [SugarColumn(ColumnName = "Ma143", ColumnDescription = "最大宽度", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma143 { get; set; }

        /// <summary>
        /// 最大高度
        /// </summary>
        [SugarColumn(ColumnName = "Ma144", ColumnDescription = "最大高度", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma144 { get; set; }

        /// <summary>
        /// 计量单位
        /// </summary>
        [SugarColumn(ColumnName = "Ma145", ColumnDescription = "计量单位", Length = 1)]
        public string Ma145 { get; set; }

        /// <summary>
        /// 原产地国
        /// </summary>
        [SugarColumn(ColumnName = "Ma146", ColumnDescription = "原产地国", Length = 6)]
        public string Ma146 { get; set; }

        /// <summary>
        /// 物料运输组
        /// </summary>
        [SugarColumn(ColumnName = "Ma147", ColumnDescription = "物料运输组", Length = 1)]
        public string Ma147 { get; set; }

        /// <summary>
        /// 隔离期间
        /// </summary>
        [SugarColumn(ColumnName = "Ma148", ColumnDescription = "隔离期间", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma148 { get; set; }

        /// <summary>
        /// 时间单位
        /// </summary>
        [SugarColumn(ColumnName = "Ma149", ColumnDescription = "时间单位", Length = 1)]
        public string Ma149 { get; set; }

        /// <summary>
        /// 质量检查组
        /// </summary>
        [SugarColumn(ColumnName = "Ma150", ColumnDescription = "质量检查组", Length = 8)]
        public string Ma150 { get; set; }

        /// <summary>
        /// 序列号参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Ma151", ColumnDescription = "序列号参数文件", Length = 1)]
        public string Ma151 { get; set; }

        /// <summary>
        /// 表格名
        /// </summary>
        [SugarColumn(ColumnName = "Ma152", ColumnDescription = "表格名", Length = 60)]
        public string Ma152 { get; set; }

        /// <summary>
        /// 后勤计量单位
        /// </summary>
        [SugarColumn(ColumnName = "Ma153", ColumnDescription = "后勤计量单位", Length = 1)]
        public string Ma153 { get; set; }

        /// <summary>
        /// 称重物料相关
        /// </summary>
        [SugarColumn(ColumnName = "Ma154", ColumnDescription = "称重物料相关", Length = 2)]
        public string Ma154 { get; set; }

        /// <summary>
        /// CW参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Ma155", ColumnDescription = "CW参数文件", Length = 1)]
        public string Ma155 { get; set; }

        /// <summary>
        /// CW容差组
        /// </summary>
        [SugarColumn(ColumnName = "Ma156", ColumnDescription = "CW容差组", Length = 18)]
        public string Ma156 { get; set; }

        /// <summary>
        /// 调整参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Ma157", ColumnDescription = "调整参数文件", Length = 1)]
        public string Ma157 { get; set; }

        /// <summary>
        /// 知识产权
        /// </summary>
        [SugarColumn(ColumnName = "Ma158", ColumnDescription = "知识产权", Length = 80)]
        public string Ma158 { get; set; }

        /// <summary>
        /// 允许的变式价格
        /// </summary>
        [SugarColumn(ColumnName = "Ma159", ColumnDescription = "允许的变式价格", Length = 1)]
        public string Ma159 { get; set; }

        /// <summary>
        /// 中间
        /// </summary>
        [SugarColumn(ColumnName = "Ma160", ColumnDescription = "中间", Length = 12)]
        public string Ma160 { get; set; }

        /// <summary>
        /// 实物商品
        /// </summary>
        [SugarColumn(ColumnName = "Ma161", ColumnDescription = "实物商品", Length = 1)]
        public string Ma161 { get; set; }

        /// <summary>
        /// 动物源
        /// </summary>
        [SugarColumn(ColumnName = "Ma162", ColumnDescription = "动物源", Length = 2)]
        public string Ma162 { get; set; }

        /// <summary>
        /// 纺织组分功能
        /// </summary>
        [SugarColumn(ColumnName = "Ma163", ColumnDescription = "纺织组分功能", Length = 1)]
        public string Ma163 { get; set; }

        /// <summary>
        /// 分段结构
        /// </summary>
        [SugarColumn(ColumnName = "Ma164", ColumnDescription = "分段结构", Length = 8)]
        public string Ma164 { get; set; }

        /// <summary>
        /// 分段策略
        /// </summary>
        [SugarColumn(ColumnName = "Ma165", ColumnDescription = "分段策略", Length = 1)]
        public string Ma165 { get; set; }

        /// <summary>
        /// 分段状态
        /// </summary>
        [SugarColumn(ColumnName = "Ma166", ColumnDescription = "分段状态", Length = 2)]
        public string Ma166 { get; set; }

        /// <summary>
        /// 分段范围
        /// </summary>
        [SugarColumn(ColumnName = "Ma167", ColumnDescription = "分段范围", Length = 1)]
        public string Ma167 { get; set; }

        /// <summary>
        /// 分段相关
        /// </summary>
        [SugarColumn(ColumnName = "Ma168", ColumnDescription = "分段相关", Length = 2)]
        public string Ma168 { get; set; }

        /// <summary>
        /// ANP Code
        /// </summary>
        [SugarColumn(ColumnName = "Ma169", ColumnDescription = "ANP Code", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma169 { get; set; }

        /// <summary>
        /// Fashion属性1
        /// </summary>
        [SugarColumn(ColumnName = "Ma170", ColumnDescription = "Fashion属性1", Length = 20)]
        public string Ma170 { get; set; }

        /// <summary>
        /// Fashion属性2
        /// </summary>
        [SugarColumn(ColumnName = "Ma171", ColumnDescription = "Fashion属性2", Length = 1)]
        public string Ma171 { get; set; }

        /// <summary>
        /// Fashion属性3
        /// </summary>
        [SugarColumn(ColumnName = "Ma172", ColumnDescription = "Fashion属性3", Length = 12)]
        public string Ma172 { get; set; }

        /// <summary>
        /// 季节使用
        /// </summary>
        [SugarColumn(ColumnName = "Ma173", ColumnDescription = "季节使用", Length = 1)]
        public string Ma173 { get; set; }

        /// <summary>
        /// 库存管理中激活季节
        /// </summary>
        [SugarColumn(ColumnName = "Ma174", ColumnDescription = "库存管理中激活季节", Length = 2)]
        public string Ma174 { get; set; }

        /// <summary>
        /// 物料转换标识
        /// </summary>
        [SugarColumn(ColumnName = "Ma175", ColumnDescription = "物料转换标识", Length = 1)]
        public string Ma175 { get; set; }

        /// <summary>
        /// 装载单位
        /// </summary>
        [SugarColumn(ColumnName = "Ma176", ColumnDescription = "装载单位", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma176 { get; set; }

        /// <summary>
        /// 装载单位组
        /// </summary>
        [SugarColumn(ColumnName = "Ma177", ColumnDescription = "装载单位组", Length = 1)]
        public string Ma177 { get; set; }

        /// <summary>
        /// 结构类别
        /// </summary>
        [SugarColumn(ColumnName = "Ma178", ColumnDescription = "结构类别", Length = 2)]
        public string Ma178 { get; set; }

        /// <summary>
        /// 容差类型
        /// </summary>
        [SugarColumn(ColumnName = "Ma179", ColumnDescription = "容差类型", Length = 1)]
        public string Ma179 { get; set; }

        /// <summary>
        /// 计算组
        /// </summary>
        [SugarColumn(ColumnName = "Ma180", ColumnDescription = "计算组", Length = 20)]
        public string Ma180 { get; set; }

        /// <summary>
        /// DSD 分组
        /// </summary>
        [SugarColumn(ColumnName = "Ma181", ColumnDescription = "DSD 分组", Length = 1)]
        public string Ma181 { get; set; }

        /// <summary>
        /// 允许倾斜
        /// </summary>
        [SugarColumn(ColumnName = "Ma182", ColumnDescription = "允许倾斜", Length = 2)]
        public string Ma182 { get; set; }

        /// <summary>
        /// 无堆栈
        /// </summary>
        [SugarColumn(ColumnName = "Ma183", ColumnDescription = "无堆栈", Length = 1)]
        public string Ma183 { get; set; }

        /// <summary>
        /// 底层
        /// </summary>
        [SugarColumn(ColumnName = "Ma184", ColumnDescription = "底层", Length = 2)]
        public string Ma184 { get; set; }

        /// <summary>
        /// 顶层
        /// </summary>
        [SugarColumn(ColumnName = "Ma185", ColumnDescription = "顶层", Length = 1)]
        public string Ma185 { get; set; }

        /// <summary>
        /// 堆栈因子
        /// </summary>
        [SugarColumn(ColumnName = "Ma186", ColumnDescription = "堆栈因子", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma186 { get; set; }

        /// <summary>
        /// 无包装物料装载
        /// </summary>
        [SugarColumn(ColumnName = "Ma187", ColumnDescription = "无包装物料装载", Length = 1)]
        public string Ma187 { get; set; }

        /// <summary>
        /// 悬挂深度
        /// </summary>
        [SugarColumn(ColumnName = "Ma188", ColumnDescription = "悬挂深度", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma188 { get; set; }

        /// <summary>
        /// 悬挂宽度
        /// </summary>
        [SugarColumn(ColumnName = "Ma189", ColumnDescription = "悬挂宽度", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma189 { get; set; }

        /// <summary>
        /// 最大叠放高度
        /// </summary>
        [SugarColumn(ColumnName = "Ma190", ColumnDescription = "最大叠放高度", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma190 { get; set; }

        /// <summary>
        /// 最小叠放高度
        /// </summary>
        [SugarColumn(ColumnName = "Ma191", ColumnDescription = "最小叠放高度", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma191 { get; set; }

        /// <summary>
        /// 叠放高度容差
        /// </summary>
        [SugarColumn(ColumnName = "Ma192", ColumnDescription = "叠放高度容差", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ma192 { get; set; }

        /// <summary>
        /// 物料编号PKM
        /// </summary>
        [SugarColumn(ColumnName = "Ma193", ColumnDescription = "物料编号PKM", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma193 { get; set; }

        /// <summary>
        /// VSO
        /// </summary>
        [SugarColumn(ColumnName = "Ma194", ColumnDescription = "VSO", Length = 6)]
        public string Ma194 { get; set; }

        /// <summary>
        /// 请求已清PKM
        /// </summary>
        [SugarColumn(ColumnName = "Ma195", ColumnDescription = "请求已清PKM", Length = 1)]
        public string Ma195 { get; set; }

        /// <summary>
        /// Packaging Code
        /// </summary>
        [SugarColumn(ColumnName = "Ma196", ColumnDescription = "Packaging Code", Length = 20)]
        public string Ma196 { get; set; }

        /// <summary>
        /// 危险品的包装状态
        /// </summary>
        [SugarColumn(ColumnName = "Ma197", ColumnDescription = "危险品的包装状态", Length = 1)]
        public string Ma197 { get; set; }

        /// <summary>
        /// 物料条件管理
        /// </summary>
        [SugarColumn(ColumnName = "Ma198", ColumnDescription = "物料条件管理", Length = 2)]
        public string Ma198 { get; set; }

        /// <summary>
        /// 返回代码
        /// </summary>
        [SugarColumn(ColumnName = "Ma199", ColumnDescription = "返回代码", Length = 1)]
        public string Ma199 { get; set; }

        /// <summary>
        /// 后勤等级退货
        /// </summary>
        [SugarColumn(ColumnName = "Ma200", ColumnDescription = "后勤等级退货", Length = 2)]
        public string Ma200 { get; set; }

        /// <summary>
        /// NATO项目
        /// </summary>
        [SugarColumn(ColumnName = "Ma201", ColumnDescription = "NATO项目", Length = 1)]
        public string Ma201 { get; set; }

        /// <summary>
        /// 完全互换组
        /// </summary>
        [SugarColumn(ColumnName = "Ma202", ColumnDescription = "完全互换组", Length = 36)]
        public string Ma202 { get; set; }

        /// <summary>
        /// 链编号
        /// </summary>
        [SugarColumn(ColumnName = "Ma203", ColumnDescription = "链编号", Length = 1)]
        public string Ma203 { get; set; }

        /// <summary>
        /// 创建状态
        /// </summary>
        [SugarColumn(ColumnName = "Ma204", ColumnDescription = "创建状态", Length = 4)]
        public string Ma204 { get; set; }

        /// <summary>
        /// 内部特性1
        /// </summary>
        [SugarColumn(ColumnName = "Ma205", ColumnDescription = "内部特性1", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma205 { get; set; }

        /// <summary>
        /// 内部特性2
        /// </summary>
        [SugarColumn(ColumnName = "Ma206", ColumnDescription = "内部特性2", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma206 { get; set; }

        /// <summary>
        /// 内部特性3
        /// </summary>
        [SugarColumn(ColumnName = "Ma207", ColumnDescription = "内部特性3", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma207 { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        [SugarColumn(ColumnName = "Ma208", ColumnDescription = "颜色", Length = 36)]
        public string Ma208 { get; set; }

        /// <summary>
        /// 主尺寸
        /// </summary>
        [SugarColumn(ColumnName = "Ma209", ColumnDescription = "主尺寸", Length = 1)]
        public string Ma209 { get; set; }

        /// <summary>
        /// 次尺寸
        /// </summary>
        [SugarColumn(ColumnName = "Ma210", ColumnDescription = "次尺寸", Length = 36)]
        public string Ma210 { get; set; }

        /// <summary>
        /// 特性值
        /// </summary>
        [SugarColumn(ColumnName = "Ma211", ColumnDescription = "特性值", Length = 1)]
        public string Ma211 { get; set; }

        /// <summary>
        /// 护理代码
        /// </summary>
        [SugarColumn(ColumnName = "Ma212", ColumnDescription = "护理代码", Length = 32)]
        public string Ma212 { get; set; }

        /// <summary>
        /// 商标
        /// </summary>
        [SugarColumn(ColumnName = "Ma213", ColumnDescription = "商标", Length = 1)]
        public string Ma213 { get; set; }

        /// <summary>
        /// 组件1
        /// </summary>
        [SugarColumn(ColumnName = "Ma214", ColumnDescription = "组件1", Length = 6)]
        public string Ma214 { get; set; }

        /// <summary>
        /// 百分比共享1
        /// </summary>
        [SugarColumn(ColumnName = "Ma215", ColumnDescription = "百分比共享1", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma215 { get; set; }

        /// <summary>
        /// 组件2
        /// </summary>
        [SugarColumn(ColumnName = "Ma216", ColumnDescription = "组件2", Length = 6)]
        public string Ma216 { get; set; }

        /// <summary>
        /// 百分比共2
        /// </summary>
        [SugarColumn(ColumnName = "Ma217", ColumnDescription = "百分比共2", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma217 { get; set; }

        /// <summary>
        /// 组件3
        /// </summary>
        [SugarColumn(ColumnName = "Ma218", ColumnDescription = "组件3", Length = 6)]
        public string Ma218 { get; set; }

        /// <summary>
        /// 百分比共享3
        /// </summary>
        [SugarColumn(ColumnName = "Ma219", ColumnDescription = "百分比共享3", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma219 { get; set; }

        /// <summary>
        /// 组件4
        /// </summary>
        [SugarColumn(ColumnName = "Ma220", ColumnDescription = "组件4", Length = 6)]
        public string Ma220 { get; set; }

        /// <summary>
        /// 百分比共享4
        /// </summary>
        [SugarColumn(ColumnName = "Ma221", ColumnDescription = "百分比共享4", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma221 { get; set; }

        /// <summary>
        /// 组件5
        /// </summary>
        [SugarColumn(ColumnName = "Ma222", ColumnDescription = "组件5", Length = 6)]
        public string Ma222 { get; set; }

        /// <summary>
        /// 百分比共享5
        /// </summary>
        [SugarColumn(ColumnName = "Ma223", ColumnDescription = "百分比共享5", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma223 { get; set; }

        /// <summary>
        /// 时装等级
        /// </summary>
        [SugarColumn(ColumnName = "Ma224", ColumnDescription = "时装等级", Length = 8)]
        public string Ma224 { get; set; }
    }
}