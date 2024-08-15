namespace Ams.Model.Logistics
{
    /// <summary>
    /// 常规物料
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:37:36
    /// </summary>
    [SugarTable("mm_mara", "常规物料")]
    public class MmMara : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long SfId { get; set; }

        /// <summary>
        /// 集团
        /// </summary>
        [SugarColumn(ColumnName = "Mandt", ColumnDescription = "集团 ", Length = 6)]
        public string Mandt { get; set; }

        /// <summary>
        /// 物料号
        /// </summary>
        [SugarColumn(ColumnName = "Matnr", ColumnDescription = "物料号 ", Length = 36)]
        public string Matnr { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? Ersda { get; set; }

        /// <summary>
        /// 创建对象的人员名称
        /// </summary>
        [SugarColumn(ColumnName = "Ernam", ColumnDescription = "创建对象的人员名称 ", Length = 24)]
        public string Ernam { get; set; }

        /// <summary>
        /// 上次更改的日期
        /// </summary>
        public DateTime? Laeda { get; set; }

        /// <summary>
        /// 对象更改人员的名称
        /// </summary>
        [SugarColumn(ColumnName = "Aenam", ColumnDescription = "对象更改人员的名称 ", Length = 24)]
        public string Aenam { get; set; }

        /// <summary>
        /// 维护全部物料状态
        /// </summary>
        [SugarColumn(ColumnName = "Vpsta", ColumnDescription = "维护全部物料状态 ", Length = 30)]
        public string Vpsta { get; set; }

        /// <summary>
        /// 维护状态
        /// </summary>
        [SugarColumn(ColumnName = "Pstat", ColumnDescription = "维护状态 ", Length = 30)]
        public string Pstat { get; set; }

        /// <summary>
        /// 在客户级标记要删除的物料
        /// </summary>
        [SugarColumn(ColumnName = "Lvorm", ColumnDescription = "在客户级标记要删除的物料 ", Length = 2)]
        public string Lvorm { get; set; }

        /// <summary>
        /// 物料类型
        /// </summary>
        [SugarColumn(ColumnName = "Mtart", ColumnDescription = "物料类型 ", Length = 8)]
        public string Mtart { get; set; }

        /// <summary>
        /// 行业领域
        /// </summary>
        [SugarColumn(ColumnName = "Mbrsh", ColumnDescription = "行业领域 ", Length = 2)]
        public string Mbrsh { get; set; }

        /// <summary>
        /// 物料组
        /// </summary>
        [SugarColumn(ColumnName = "Matkl", ColumnDescription = "物料组 ", Length = 18)]
        public string Matkl { get; set; }

        /// <summary>
        /// 旧物料号
        /// </summary>
        [SugarColumn(ColumnName = "Bismt", ColumnDescription = "旧物料号 ", Length = 36)]
        public string Bismt { get; set; }

        /// <summary>
        /// 基本计量单位
        /// </summary>
        [SugarColumn(ColumnName = "Meins", ColumnDescription = "基本计量单位 ", Length = 6)]
        public string Meins { get; set; }

        /// <summary>
        /// 采购订单的计量单位
        /// </summary>
        [SugarColumn(ColumnName = "Bstme", ColumnDescription = "采购订单的计量单位 ", Length = 6)]
        public string Bstme { get; set; }

        /// <summary>
        /// 文档号码(无文档管理系统)
        /// </summary>
        [SugarColumn(ColumnName = "Zeinr", ColumnDescription = "文档号码(无文档管理系统) ", Length = 44)]
        public string Zeinr { get; set; }

        /// <summary>
        /// 凭证类型(无凭证管理系统)
        /// </summary>
        [SugarColumn(ColumnName = "Zeiar", ColumnDescription = "凭证类型(无凭证管理系统) ", Length = 6)]
        public string Zeiar { get; set; }

        /// <summary>
        /// 文档版本（无文档管理系统）
        /// </summary>
        [SugarColumn(ColumnName = "Zeivr", ColumnDescription = "文档版本（无文档管理系统） ", Length = 4)]
        public string Zeivr { get; set; }

        /// <summary>
        /// 文件的页面大小（不包括文件管理系统）
        /// </summary>
        [SugarColumn(ColumnName = "Zeifo", ColumnDescription = "文件的页面大小（不包括文件管理系统） ", Length = 8)]
        public string Zeifo { get; set; }

        /// <summary>
        /// 文档变更号(无文档管理系统)
        /// </summary>
        [SugarColumn(ColumnName = "Aeszn", ColumnDescription = "文档变更号(无文档管理系统) ", Length = 12)]
        public string Aeszn { get; set; }

        /// <summary>
        /// 凭证的页号(不带凭证管理系统)
        /// </summary>
        [SugarColumn(ColumnName = "Blatt", ColumnDescription = "凭证的页号(不带凭证管理系统) ", Length = 6)]
        public string Blatt { get; set; }

        /// <summary>
        /// 页数(没有凭证管理系统)
        /// </summary>
        [SugarColumn(ColumnName = "Blanz", ColumnDescription = "页数(没有凭证管理系统) ", DefaultValue = "0")]
        public int? Blanz { get; set; }

        /// <summary>
        /// 生产/检验备忘录
        /// </summary>
        [SugarColumn(ColumnName = "Ferth", ColumnDescription = "生产/检验备忘录 ", Length = 36)]
        public string Ferth { get; set; }

        /// <summary>
        /// 生产备忘录的页格式
        /// </summary>
        [SugarColumn(ColumnName = "Formt", ColumnDescription = "生产备忘录的页格式 ", Length = 8)]
        public string Formt { get; set; }

        /// <summary>
        /// 大小/量纲
        /// </summary>
        [SugarColumn(ColumnName = "Groes", ColumnDescription = "大小/量纲 ", Length = 64)]
        public string Groes { get; set; }

        /// <summary>
        /// 基本物料
        /// </summary>
        [SugarColumn(ColumnName = "Wrkst", ColumnDescription = "基本物料 ", Length = 96)]
        public string Wrkst { get; set; }

        /// <summary>
        /// 行业标准描述（例如 ANSI 或 ISO）
        /// </summary>
        [SugarColumn(ColumnName = "Normt", ColumnDescription = "行业标准描述（例如 ANSI 或 ISO） ", Length = 36)]
        public string Normt { get; set; }

        /// <summary>
        /// 实验室/设计室
        /// </summary>
        [SugarColumn(ColumnName = "Labor", ColumnDescription = "实验室/设计室 ", Length = 6)]
        public string Labor { get; set; }

        /// <summary>
        /// 采购价值代码
        /// </summary>
        [SugarColumn(ColumnName = "Ekwsl", ColumnDescription = "采购价值代码 ", Length = 8)]
        public string Ekwsl { get; set; }

        /// <summary>
        /// 毛重
        /// </summary>
        [SugarColumn(ColumnName = "Brgew", ColumnDescription = "毛重 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Brgew { get; set; }

        /// <summary>
        /// 净重
        /// </summary>
        [SugarColumn(ColumnName = "Ntgew", ColumnDescription = "净重 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Ntgew { get; set; }

        /// <summary>
        /// 重量单位
        /// </summary>
        [SugarColumn(ColumnName = "Gewei", ColumnDescription = "重量单位 ", Length = 6)]
        public string Gewei { get; set; }

        /// <summary>
        /// 业务量
        /// </summary>
        [SugarColumn(ColumnName = "Volum", ColumnDescription = "业务量 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Volum { get; set; }

        /// <summary>
        /// 体积单位
        /// </summary>
        [SugarColumn(ColumnName = "Voleh", ColumnDescription = "体积单位 ", Length = 6)]
        public string Voleh { get; set; }

        /// <summary>
        /// 容器需求
        /// </summary>
        [SugarColumn(ColumnName = "Behvo", ColumnDescription = "容器需求 ", Length = 4)]
        public string Behvo { get; set; }

        /// <summary>
        /// 存储条件
        /// </summary>
        [SugarColumn(ColumnName = "Raube", ColumnDescription = "存储条件 ", Length = 4)]
        public string Raube { get; set; }

        /// <summary>
        /// 温度条件标识
        /// </summary>
        [SugarColumn(ColumnName = "Tempb", ColumnDescription = "温度条件标识 ", Length = 4)]
        public string Tempb { get; set; }

        /// <summary>
        /// 低层代码
        /// </summary>
        [SugarColumn(ColumnName = "Disst", ColumnDescription = "低层代码 ", Length = 6)]
        public string Disst { get; set; }

        /// <summary>
        /// 运输组
        /// </summary>
        [SugarColumn(ColumnName = "Tragr", ColumnDescription = "运输组 ", Length = 8)]
        public string Tragr { get; set; }

        /// <summary>
        /// 危险物料号
        /// </summary>
        [SugarColumn(ColumnName = "Stoff", ColumnDescription = "危险物料号 ", Length = 36)]
        public string Stoff { get; set; }

        /// <summary>
        /// 产品组
        /// </summary>
        [SugarColumn(ColumnName = "Spart", ColumnDescription = "产品组 ", Length = 4)]
        public string Spart { get; set; }

        /// <summary>
        /// 竞争者
        /// </summary>
        [SugarColumn(ColumnName = "Kunnr", ColumnDescription = "竞争者 ", Length = 20)]
        public string Kunnr { get; set; }

        /// <summary>
        /// 欧洲物品号 (EAN) - 已过时的 !!!!!
        /// </summary>
        [SugarColumn(ColumnName = "Eannr", ColumnDescription = "欧洲物品号 (EAN) - 已过时的 !!!!! ", Length = 26)]
        public string Eannr { get; set; }

        /// <summary>
        /// 数量: 待打印的 GR/GI 单数量
        /// </summary>
        [SugarColumn(ColumnName = "Wesch", ColumnDescription = "数量: 待打印的 GR/GI 单数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Wesch { get; set; }

        /// <summary>
        /// 采购规则
        /// </summary>
        [SugarColumn(ColumnName = "Bwvor", ColumnDescription = "采购规则 ", Length = 2)]
        public string Bwvor { get; set; }

        /// <summary>
        /// 货源
        /// </summary>
        [SugarColumn(ColumnName = "Bwscl", ColumnDescription = "货源 ", Length = 2)]
        public string Bwscl { get; set; }

        /// <summary>
        /// 季节类别
        /// </summary>
        [SugarColumn(ColumnName = "Saiso", ColumnDescription = "季节类别 ", Length = 8)]
        public string Saiso { get; set; }

        /// <summary>
        /// 标签类型
        /// </summary>
        [SugarColumn(ColumnName = "Etiar", ColumnDescription = "标签类型 ", Length = 4)]
        public string Etiar { get; set; }

        /// <summary>
        /// 标签格式
        /// </summary>
        [SugarColumn(ColumnName = "Etifo", ColumnDescription = "标签格式 ", Length = 4)]
        public string Etifo { get; set; }

        /// <summary>
        /// 取消激活的
        /// </summary>
        [SugarColumn(ColumnName = "Entar", ColumnDescription = "取消激活的 ", Length = 2)]
        public string Entar { get; set; }

        /// <summary>
        /// 国际文件号(EAN/UPC)
        /// </summary>
        [SugarColumn(ColumnName = "Ean11", ColumnDescription = "国际文件号(EAN/UPC) ", Length = 36)]
        public string Ean11 { get; set; }

        /// <summary>
        /// 国际商品编码的类别 (EAN)
        /// </summary>
        [SugarColumn(ColumnName = "Numtp", ColumnDescription = "国际商品编码的类别 (EAN) ", Length = 4)]
        public string Numtp { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        [SugarColumn(ColumnName = "Laeng", ColumnDescription = "长度 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Laeng { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        [SugarColumn(ColumnName = "Breit", ColumnDescription = "宽度 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Breit { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        [SugarColumn(ColumnName = "Hoehe", ColumnDescription = "高度 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Hoehe { get; set; }

        /// <summary>
        /// 长度/宽度/高度的尺寸单位
        /// </summary>
        [SugarColumn(ColumnName = "Meabm", ColumnDescription = "长度/宽度/高度的尺寸单位 ", Length = 6)]
        public string Meabm { get; set; }

        /// <summary>
        /// 产品层次
        /// </summary>
        [SugarColumn(ColumnName = "Prdha", ColumnDescription = "产品层次 ", Length = 36)]
        public string Prdha { get; set; }

        /// <summary>
        /// 库存转移净改变成本核算
        /// </summary>
        [SugarColumn(ColumnName = "Aeklk", ColumnDescription = "库存转移净改变成本核算 ", Length = 2)]
        public string Aeklk { get; set; }

        /// <summary>
        /// CAD 标识
        /// </summary>
        [SugarColumn(ColumnName = "Cadkz", ColumnDescription = "CAD 标识 ", Length = 2)]
        public string Cadkz { get; set; }

        /// <summary>
        /// 激活采购中的 QM
        /// </summary>
        [SugarColumn(ColumnName = "Qmpur", ColumnDescription = "激活采购中的 QM ", Length = 2)]
        public string Qmpur { get; set; }

        /// <summary>
        /// 允许的包装重量
        /// </summary>
        [SugarColumn(ColumnName = "Ergew", ColumnDescription = "允许的包装重量 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Ergew { get; set; }

        /// <summary>
        /// 加权的单位(允许打包加权)
        /// </summary>
        [SugarColumn(ColumnName = "Ergei", ColumnDescription = "加权的单位(允许打包加权) ", Length = 6)]
        public string Ergei { get; set; }

        /// <summary>
        /// 允许的包装体积
        /// </summary>
        [SugarColumn(ColumnName = "Ervol", ColumnDescription = "允许的包装体积 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Ervol { get; set; }

        /// <summary>
        /// 体积单位(允许打包体积)
        /// </summary>
        [SugarColumn(ColumnName = "Ervoe", ColumnDescription = "体积单位(允许打包体积) ", Length = 6)]
        public string Ervoe { get; set; }

        /// <summary>
        /// 处理单位的超重量容差
        /// </summary>
        [SugarColumn(ColumnName = "Gewto", ColumnDescription = "处理单位的超重量容差 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Gewto { get; set; }

        /// <summary>
        /// 处理单位的超量冗差
        /// </summary>
        [SugarColumn(ColumnName = "Volto", ColumnDescription = "处理单位的超量冗差 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Volto { get; set; }

        /// <summary>
        /// 可变采购订单单位活动
        /// </summary>
        [SugarColumn(ColumnName = "Vabme", ColumnDescription = "可变采购订单单位活动 ", Length = 2)]
        public string Vabme { get; set; }

        /// <summary>
        /// 标识: 修改水平已分配到物料
        /// </summary>
        [SugarColumn(ColumnName = "Kzrev", ColumnDescription = "标识: 修改水平已分配到物料 ", Length = 2)]
        public string Kzrev { get; set; }

        /// <summary>
        /// 可配置的物料
        /// </summary>
        [SugarColumn(ColumnName = "Kzkfg", ColumnDescription = "可配置的物料 ", Length = 2)]
        public string Kzkfg { get; set; }

        /// <summary>
        /// 批次管理需求的标识
        /// </summary>
        [SugarColumn(ColumnName = "Xchpf", ColumnDescription = "批次管理需求的标识 ", Length = 2)]
        public string Xchpf { get; set; }

        /// <summary>
        /// 包装物料类型
        /// </summary>
        [SugarColumn(ColumnName = "Vhart", ColumnDescription = "包装物料类型 ", Length = 8)]
        public string Vhart { get; set; }

        /// <summary>
        /// 最大层次 (按体积)
        /// </summary>
        [SugarColumn(ColumnName = "Fuelg", ColumnDescription = "最大层次 (按体积) ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Fuelg { get; set; }

        /// <summary>
        /// 堆栈因子
        /// </summary>
        [SugarColumn(ColumnName = "Stfak", ColumnDescription = "堆栈因子 ", DefaultValue = "0")]
        public int? Stfak { get; set; }

        /// <summary>
        /// 物料组: 包装物料
        /// </summary>
        [SugarColumn(ColumnName = "Magrv", ColumnDescription = "物料组: 包装物料 ", Length = 8)]
        public string Magrv { get; set; }

        /// <summary>
        /// 权限组
        /// </summary>
        [SugarColumn(ColumnName = "Begru", ColumnDescription = "权限组 ", Length = 8)]
        public string Begru { get; set; }

        /// <summary>
        /// 开始生效日期
        /// </summary>
        public DateTime? Datab { get; set; }

        /// <summary>
        /// 删除日期
        /// </summary>
        public DateTime? Liqdt { get; set; }

        /// <summary>
        /// 季度年
        /// </summary>
        [SugarColumn(ColumnName = "Saisj", ColumnDescription = "季度年 ", Length = 8)]
        public string Saisj { get; set; }

        /// <summary>
        /// 价格标记类别
        /// </summary>
        [SugarColumn(ColumnName = "Plgtp", ColumnDescription = "价格标记类别 ", Length = 4)]
        public string Plgtp { get; set; }

        /// <summary>
        /// 空白物料清单
        /// </summary>
        [SugarColumn(ColumnName = "Mlgut", ColumnDescription = "空白物料清单 ", Length = 2)]
        public string Mlgut { get; set; }

        /// <summary>
        /// 外部物料组
        /// </summary>
        [SugarColumn(ColumnName = "Extwg", ColumnDescription = "外部物料组 ", Length = 36)]
        public string Extwg { get; set; }

        /// <summary>
        /// 一般可配置物料
        /// </summary>
        [SugarColumn(ColumnName = "Satnr", ColumnDescription = "一般可配置物料 ", Length = 36)]
        public string Satnr { get; set; }

        /// <summary>
        /// 物料类别
        /// </summary>
        [SugarColumn(ColumnName = "Attyp", ColumnDescription = "物料类别 ", Length = 4)]
        public string Attyp { get; set; }

        /// <summary>
        /// 指示符 : 物料是联产品
        /// </summary>
        [SugarColumn(ColumnName = "Kzkup", ColumnDescription = "指示符 : 物料是联产品 ", Length = 2)]
        public string Kzkup { get; set; }

        /// <summary>
        /// 标记：物料有一后续物料
        /// </summary>
        [SugarColumn(ColumnName = "Kznfm", ColumnDescription = "标记：物料有一后续物料 ", Length = 2)]
        public string Kznfm { get; set; }

        /// <summary>
        /// 定价参考物料
        /// </summary>
        [SugarColumn(ColumnName = "Pmata", ColumnDescription = "定价参考物料 ", Length = 36)]
        public string Pmata { get; set; }

        /// <summary>
        /// 跨工厂物料状态
        /// </summary>
        [SugarColumn(ColumnName = "Mstae", ColumnDescription = "跨工厂物料状态 ", Length = 4)]
        public string Mstae { get; set; }

        /// <summary>
        /// 跨分销链物料状态
        /// </summary>
        [SugarColumn(ColumnName = "Mstav", ColumnDescription = "跨分销链物料状态 ", Length = 4)]
        public string Mstav { get; set; }

        /// <summary>
        /// 从跨工厂物料状态有效起的日期
        /// </summary>
        public DateTime? Mstde { get; set; }

        /// <summary>
        /// 从跨分销链物料状态有效起的日期
        /// </summary>
        public DateTime? Mstdv { get; set; }

        /// <summary>
        /// 物料从税收分类
        /// </summary>
        [SugarColumn(ColumnName = "Taklv", ColumnDescription = "物料从税收分类 ", Length = 2)]
        public string Taklv { get; set; }

        /// <summary>
        /// 类别参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Rbnrm", ColumnDescription = "类别参数文件 ", Length = 18)]
        public string Rbnrm { get; set; }

        /// <summary>
        /// 最短剩余货架寿命
        /// </summary>
        [SugarColumn(ColumnName = "Mhdrz", ColumnDescription = "最短剩余货架寿命 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Mhdrz { get; set; }

        /// <summary>
        /// 总货架寿命
        /// </summary>
        [SugarColumn(ColumnName = "Mhdhb", ColumnDescription = "总货架寿命 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Mhdhb { get; set; }

        /// <summary>
        /// 仓储百分比
        /// </summary>
        [SugarColumn(ColumnName = "Mhdlp", ColumnDescription = "仓储百分比 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Mhdlp { get; set; }

        /// <summary>
        /// 内容单位
        /// </summary>
        [SugarColumn(ColumnName = "Inhme", ColumnDescription = "内容单位 ", Length = 6)]
        public string Inhme { get; set; }

        /// <summary>
        /// 净内容
        /// </summary>
        [SugarColumn(ColumnName = "Inhal", ColumnDescription = "净内容 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Inhal { get; set; }

        /// <summary>
        /// 比较价格单位
        /// </summary>
        [SugarColumn(ColumnName = "Vpreh", ColumnDescription = "比较价格单位 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vpreh { get; set; }

        /// <summary>
        /// IS-R 标签：物料组（在 4.0 中不活动）
        /// </summary>
        [SugarColumn(ColumnName = "Etiag", ColumnDescription = "IS-R 标签：物料组（在 4.0 中不活动） ", Length = 36)]
        public string Etiag { get; set; }

        /// <summary>
        /// 毛内容
        /// </summary>
        [SugarColumn(ColumnName = "Inhbr", ColumnDescription = "毛内容 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Inhbr { get; set; }

        /// <summary>
        /// 数量转换方法
        /// </summary>
        [SugarColumn(ColumnName = "Cmeth", ColumnDescription = "数量转换方法 ", Length = 2)]
        public string Cmeth { get; set; }

        /// <summary>
        /// 内部对象号
        /// </summary>
        [SugarColumn(ColumnName = "Cuobf", ColumnDescription = "内部对象号 ", DefaultValue = "0")]
        public int? Cuobf { get; set; }

        /// <summary>
        /// 环境相关
        /// </summary>
        [SugarColumn(ColumnName = "Kzumw", ColumnDescription = "环境相关 ", Length = 2)]
        public string Kzumw { get; set; }

        /// <summary>
        /// 产品分配确定程序
        /// </summary>
        [SugarColumn(ColumnName = "Kosch", ColumnDescription = "产品分配确定程序 ", Length = 36)]
        public string Kosch { get; set; }

        /// <summary>
        /// 变式的定价参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Sprof", ColumnDescription = "变式的定价参数文件 ", Length = 2)]
        public string Sprof { get; set; }

        /// <summary>
        /// 针对物料的折扣类型
        /// </summary>
        [SugarColumn(ColumnName = "Nrfhg", ColumnDescription = "针对物料的折扣类型 ", Length = 2)]
        public string Nrfhg { get; set; }

        /// <summary>
        /// 制造商零件编号
        /// </summary>
        [SugarColumn(ColumnName = "Mfrpn", ColumnDescription = "制造商零件编号 ", Length = 80)]
        public string Mfrpn { get; set; }

        /// <summary>
        /// 制造商编号
        /// </summary>
        [SugarColumn(ColumnName = "Mfrnr", ColumnDescription = "制造商编号 ", Length = 20)]
        public string Mfrnr { get; set; }

        /// <summary>
        /// 公司自己 (内部) 的盘点管理物料编号
        /// </summary>
        [SugarColumn(ColumnName = "Bmatn", ColumnDescription = "公司自己 (内部) 的盘点管理物料编号 ", Length = 36)]
        public string Bmatn { get; set; }

        /// <summary>
        /// 制造商部件参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Mprof", ColumnDescription = "制造商部件参数文件 ", Length = 8)]
        public string Mprof { get; set; }

        /// <summary>
        /// 计量单位使用
        /// </summary>
        [SugarColumn(ColumnName = "Kzwsm", ColumnDescription = "计量单位使用 ", Length = 2)]
        public string Kzwsm { get; set; }

        /// <summary>
        /// 在季节内展开
        /// </summary>
        [SugarColumn(ColumnName = "Saity", ColumnDescription = "在季节内展开 ", Length = 4)]
        public string Saity { get; set; }

        /// <summary>
        /// 危险货物标识参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Profl", ColumnDescription = "危险货物标识参数文件 ", Length = 6)]
        public string Profl { get; set; }

        /// <summary>
        /// 标识符:高粘性的
        /// </summary>
        [SugarColumn(ColumnName = "Ihivi", ColumnDescription = "标识符:高粘性的 ", Length = 2)]
        public string Ihivi { get; set; }

        /// <summary>
        /// 标识符:固体/液体
        /// </summary>
        [SugarColumn(ColumnName = "Iloos", ColumnDescription = "标识符:固体/液体 ", Length = 2)]
        public string Iloos { get; set; }

        /// <summary>
        /// 序列号的清晰的级别
        /// </summary>
        [SugarColumn(ColumnName = "Serlv", ColumnDescription = "序列号的清晰的级别 ", Length = 2)]
        public string Serlv { get; set; }

        /// <summary>
        /// 包装物料是密闭包装的
        /// </summary>
        [SugarColumn(ColumnName = "Kzgvh", ColumnDescription = "包装物料是密闭包装的 ", Length = 2)]
        public string Kzgvh { get; set; }

        /// <summary>
        /// 指示符：需要批准的批量记录
        /// </summary>
        [SugarColumn(ColumnName = "Xgchp", ColumnDescription = "指示符：需要批准的批量记录 ", Length = 2)]
        public string Xgchp { get; set; }

        /// <summary>
        /// 指定有效参数值/覆盖更改编号
        /// </summary>
        [SugarColumn(ColumnName = "Kzeff", ColumnDescription = "指定有效参数值/覆盖更改编号 ", Length = 2)]
        public string Kzeff { get; set; }

        /// <summary>
        /// 物料完成的水平
        /// </summary>
        [SugarColumn(ColumnName = "Compl", ColumnDescription = "物料完成的水平 ", DefaultValue = "0")]
        public int? Compl { get; set; }

        /// <summary>
        /// 货架寿命到期日的期间标识
        /// </summary>
        [SugarColumn(ColumnName = "Iprkz", ColumnDescription = "货架寿命到期日的期间标识 ", Length = 2)]
        public string Iprkz { get; set; }

        /// <summary>
        /// 货架寿命到期日期计算舍入规则
        /// </summary>
        [SugarColumn(ColumnName = "Rdmhd", ColumnDescription = "货架寿命到期日期计算舍入规则 ", Length = 2)]
        public string Rdmhd { get; set; }

        /// <summary>
        /// 标识：印刷在包装上的产品成份
        /// </summary>
        [SugarColumn(ColumnName = "Przus", ColumnDescription = "标识：印刷在包装上的产品成份 ", Length = 2)]
        public string Przus { get; set; }

        /// <summary>
        /// 普通项目类别组
        /// </summary>
        [SugarColumn(ColumnName = "Mtposmara", ColumnDescription = "普通项目类别组 ", Length = 8)]
        public string Mtposmara { get; set; }

        /// <summary>
        /// 含后勤变量的一般物料
        /// </summary>
        [SugarColumn(ColumnName = "Bflme", ColumnDescription = "含后勤变量的一般物料 ", Length = 2)]
        public string Bflme { get; set; }

        /// <summary>
        /// 物料被锁定
        /// </summary>
        [SugarColumn(ColumnName = "Matfi", ColumnDescription = "物料被锁定 ", Length = 2)]
        public string Matfi { get; set; }

        /// <summary>
        /// 与配置管理相关
        /// </summary>
        [SugarColumn(ColumnName = "Cmrel", ColumnDescription = "与配置管理相关 ", Length = 2)]
        public string Cmrel { get; set; }

        /// <summary>
        /// 分类清单类型
        /// </summary>
        [SugarColumn(ColumnName = "Bbtyp", ColumnDescription = "分类清单类型 ", Length = 2)]
        public string Bbtyp { get; set; }

        /// <summary>
        /// 过期日期
        /// </summary>
        [SugarColumn(ColumnName = "Sledbbd", ColumnDescription = "过期日期 ", Length = 2)]
        public string Sledbbd { get; set; }

        /// <summary>
        /// 全球贸易项目编号变式
        /// </summary>
        [SugarColumn(ColumnName = "Gtinvariant", ColumnDescription = "全球贸易项目编号变式 ", Length = 4)]
        public string Gtinvariant { get; set; }

        /// <summary>
        /// 在预包装物料中的一般物料的物料编号
        /// </summary>
        [SugarColumn(ColumnName = "Gennr", ColumnDescription = "在预包装物料中的一般物料的物料编号 ", Length = 36)]
        public string Gennr { get; set; }

        /// <summary>
        /// 以相同方式包装的物料的参考物料
        /// </summary>
        [SugarColumn(ColumnName = "Rmatp", ColumnDescription = "以相同方式包装的物料的参考物料 ", Length = 36)]
        public string Rmatp { get; set; }

        /// <summary>
        /// 标识：全局数据同步相关
        /// </summary>
        [SugarColumn(ColumnName = "Gdsrelevant", ColumnDescription = "标识：全局数据同步相关 ", Length = 2)]
        public string Gdsrelevant { get; set; }

        /// <summary>
        /// 原始接受
        /// </summary>
        [SugarColumn(ColumnName = "Weora", ColumnDescription = "原始接受 ", Length = 2)]
        public string Weora { get; set; }

        /// <summary>
        /// 标准处理单位类型
        /// </summary>
        [SugarColumn(ColumnName = "Hutypdflt", ColumnDescription = "标准处理单位类型 ", Length = 8)]
        public string Hutypdflt { get; set; }

        /// <summary>
        /// 可偷窃的
        /// </summary>
        [SugarColumn(ColumnName = "Pilferable", ColumnDescription = "可偷窃的 ", Length = 2)]
        public string Pilferable { get; set; }

        /// <summary>
        /// 仓库存储条件
        /// </summary>
        [SugarColumn(ColumnName = "Whstc", ColumnDescription = "仓库存储条件 ", Length = 4)]
        public string Whstc { get; set; }

        /// <summary>
        /// 仓库物料组
        /// </summary>
        [SugarColumn(ColumnName = "Whmatgr", ColumnDescription = "仓库物料组 ", Length = 8)]
        public string Whmatgr { get; set; }

        /// <summary>
        /// 处理标识
        /// </summary>
        [SugarColumn(ColumnName = "Hndlcode", ColumnDescription = "处理标识 ", Length = 8)]
        public string Hndlcode { get; set; }

        /// <summary>
        /// 与危险物料相关
        /// </summary>
        [SugarColumn(ColumnName = "Hazmat", ColumnDescription = "与危险物料相关 ", Length = 2)]
        public string Hazmat { get; set; }

        /// <summary>
        /// 处理单位类型
        /// </summary>
        [SugarColumn(ColumnName = "Hutyp", ColumnDescription = "处理单位类型 ", Length = 8)]
        public string Hutyp { get; set; }

        /// <summary>
        /// 可变皮重
        /// </summary>
        [SugarColumn(ColumnName = "Tarevar", ColumnDescription = "可变皮重 ", Length = 2)]
        public string Tarevar { get; set; }

        /// <summary>
        /// 包装物料的最大允许容量
        /// </summary>
        [SugarColumn(ColumnName = "Maxc", ColumnDescription = "包装物料的最大允许容量 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Maxc { get; set; }

        /// <summary>
        /// 处理单位的最大容量容差
        /// </summary>
        [SugarColumn(ColumnName = "Maxctol", ColumnDescription = "处理单位的最大容量容差 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Maxctol { get; set; }

        /// <summary>
        /// 包装物料的最大包长度
        /// </summary>
        [SugarColumn(ColumnName = "Maxl", ColumnDescription = "包装物料的最大包长度 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Maxl { get; set; }

        /// <summary>
        /// 包装物料的最大包宽度
        /// </summary>
        [SugarColumn(ColumnName = "Maxb", ColumnDescription = "包装物料的最大包宽度 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Maxb { get; set; }

        /// <summary>
        /// 包装物料的最大包高度
        /// </summary>
        [SugarColumn(ColumnName = "Maxh", ColumnDescription = "包装物料的最大包高度 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Maxh { get; set; }

        /// <summary>
        /// 最大包装长/宽/高的计量单位
        /// </summary>
        [SugarColumn(ColumnName = "Maxdimuom", ColumnDescription = "最大包装长/宽/高的计量单位 ", Length = 6)]
        public string Maxdimuom { get; set; }

        /// <summary>
        /// 物料原产地国家
        /// </summary>
        [SugarColumn(ColumnName = "Herkl", ColumnDescription = "物料原产地国家 ", Length = 6)]
        public string Herkl { get; set; }

        /// <summary>
        /// 物料运输组
        /// </summary>
        [SugarColumn(ColumnName = "Mfrgr", ColumnDescription = "物料运输组 ", Length = 16)]
        public string Mfrgr { get; set; }

        /// <summary>
        /// 隔离期间
        /// </summary>
        [SugarColumn(ColumnName = "Qqtime", ColumnDescription = "隔离期间 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Qqtime { get; set; }

        /// <summary>
        /// 隔离期间的时间单位
        /// </summary>
        [SugarColumn(ColumnName = "Qqtimeuom", ColumnDescription = "隔离期间的时间单位 ", Length = 6)]
        public string Qqtimeuom { get; set; }

        /// <summary>
        /// 质量检查组
        /// </summary>
        [SugarColumn(ColumnName = "Qgrp", ColumnDescription = "质量检查组 ", Length = 8)]
        public string Qgrp { get; set; }

        /// <summary>
        /// 序列号参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Serial", ColumnDescription = "序列号参数文件 ", Length = 8)]
        public string Serial { get; set; }

        /// <summary>
        /// 表格名
        /// </summary>
        [SugarColumn(ColumnName = "Pssmartform", ColumnDescription = "表格名 ", Length = 60)]
        public string Pssmartform { get; set; }

        /// <summary>
        /// EWM CW: 后勤计量单位
        /// </summary>
        [SugarColumn(ColumnName = "Logunit", ColumnDescription = "EWM CW: 后勤计量单位 ", Length = 6)]
        public string Logunit { get; set; }

        /// <summary>
        /// EWM CW: 物料是称重物料
        /// </summary>
        [SugarColumn(ColumnName = "Cwqrel", ColumnDescription = "EWM CW: 物料是称重物料 ", Length = 2)]
        public string Cwqrel { get; set; }

        /// <summary>
        /// EWM CW: 输入 CW 数量的称重参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Cwqproc", ColumnDescription = "EWM CW: 输入 CW 数量的称重参数文件 ", Length = 4)]
        public string Cwqproc { get; set; }

        /// <summary>
        /// EWM-CW: EWM 的称重容差组
        /// </summary>
        [SugarColumn(ColumnName = "Cwqtolgr", ColumnDescription = "EWM-CW: EWM 的称重容差组 ", Length = 18)]
        public string Cwqtolgr { get; set; }

        /// <summary>
        /// 调整参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Adprof", ColumnDescription = "调整参数文件 ", Length = 6)]
        public string Adprof { get; set; }

        /// <summary>
        /// 知识产权标识（CRM 产品）
        /// </summary>
        [SugarColumn(ColumnName = "Ipmipproduct", ColumnDescription = "知识产权标识（CRM 产品） ", Length = 80)]
        public string Ipmipproduct { get; set; }

        /// <summary>
        /// 允许的变式价格（针对物料主数据）
        /// </summary>
        [SugarColumn(ColumnName = "Allowpmatigno", ColumnDescription = "允许的变式价格（针对物料主数据） ", Length = 2)]
        public string Allowpmatigno { get; set; }

        /// <summary>
        /// 中间
        /// </summary>
        [SugarColumn(ColumnName = "Medium", ColumnDescription = "中间 ", Length = 12)]
        public string Medium { get; set; }

        /// <summary>
        /// 实物商品
        /// </summary>
        [SugarColumn(ColumnName = "Commodity", ColumnDescription = "实物商品 ", Length = 36)]
        public string Commodity { get; set; }

        /// <summary>
        /// 标识：包含动物源的非纺织部分
        /// </summary>
        [SugarColumn(ColumnName = "Animalorigin", ColumnDescription = "标识：包含动物源的非纺织部分 ", Length = 2)]
        public string Animalorigin { get; set; }

        /// <summary>
        /// 标识：新纺织组分功能
        /// </summary>
        [SugarColumn(ColumnName = "Textilecompind", ColumnDescription = "标识：新纺织组分功能 ", Length = 2)]
        public string Textilecompind { get; set; }

        /// <summary>
        /// 分段结构
        /// </summary>
        [SugarColumn(ColumnName = "Sgtcsgr", ColumnDescription = "分段结构 ", Length = 8)]
        public string Sgtcsgr { get; set; }

        /// <summary>
        /// 分段策略
        /// </summary>
        [SugarColumn(ColumnName = "Sgtcovsa", ColumnDescription = "分段策略 ", Length = 16)]
        public string Sgtcovsa { get; set; }

        /// <summary>
        /// 分段物料主数据状态
        /// </summary>
        [SugarColumn(ColumnName = "Sgtstat", ColumnDescription = "分段物料主数据状态 ", Length = 2)]
        public string Sgtstat { get; set; }

        /// <summary>
        /// 分段策略范围
        /// </summary>
        [SugarColumn(ColumnName = "Sgtscope", ColumnDescription = "分段策略范围 ", Length = 2)]
        public string Sgtscope { get; set; }

        /// <summary>
        /// 分段相关
        /// </summary>
        [SugarColumn(ColumnName = "Sgtrel", ColumnDescription = "分段相关 ", Length = 2)]
        public string Sgtrel { get; set; }

        /// <summary>
        /// ANP Code
        /// </summary>
        [SugarColumn(ColumnName = "Anp", ColumnDescription = "ANP Code ", DefaultValue = "0")]
        public int? Anp { get; set; }

        /// <summary>
        /// Fashion 信息字段：1
        /// </summary>
        [SugarColumn(ColumnName = "Fshmgat1", ColumnDescription = "Fashion 信息字段：1 ", Length = 20)]
        public string Fshmgat1 { get; set; }

        /// <summary>
        /// Fashion 信息字段：2
        /// </summary>
        [SugarColumn(ColumnName = "Fshmgat2", ColumnDescription = "Fashion 信息字段：2 ", Length = 20)]
        public string Fshmgat2 { get; set; }

        /// <summary>
        /// Fashion 信息字段：3
        /// </summary>
        [SugarColumn(ColumnName = "Fshmgat3", ColumnDescription = "Fashion 信息字段：3 ", Length = 12)]
        public string Fshmgat3 { get; set; }

        /// <summary>
        /// 标识：季节使用
        /// </summary>
        [SugarColumn(ColumnName = "Fshsealv", ColumnDescription = "标识：季节使用 ", Length = 2)]
        public string Fshsealv { get; set; }

        /// <summary>
        /// 标识：在库存管理中激活季节
        /// </summary>
        [SugarColumn(ColumnName = "Fshseaim", ColumnDescription = "标识：在库存管理中激活季节 ", Length = 2)]
        public string Fshseaim { get; set; }

        /// <summary>
        /// 特征值转换的物料转换标识
        /// </summary>
        [SugarColumn(ColumnName = "Fshscmid", ColumnDescription = "特征值转换的物料转换标识 ", Length = 4)]
        public string Fshscmid { get; set; }

        /// <summary>
        /// 装载单位
        /// </summary>
        [SugarColumn(ColumnName = "Bev1luleinh", ColumnDescription = "装载单位 ", DefaultValue = "0")]
        public int? Bev1luleinh { get; set; }

        /// <summary>
        /// 装载单位组：IS 饮料
        /// </summary>
        [SugarColumn(ColumnName = "Bev1luldegrp", ColumnDescription = "装载单位组：IS 饮料 ", Length = 6)]
        public string Bev1luldegrp { get; set; }

        /// <summary>
        /// 物料关系的结构类别
        /// </summary>
        [SugarColumn(ColumnName = "Bev1nestruccat", ColumnDescription = "物料关系的结构类别 ", Length = 2)]
        public string Bev1nestruccat { get; set; }

        /// <summary>
        /// 容差类型标识
        /// </summary>
        [SugarColumn(ColumnName = "Dsdsltoltyp", ColumnDescription = "容差类型标识 ", Length = 8)]
        public string Dsdsltoltyp { get; set; }

        /// <summary>
        /// 计算组
        /// </summary>
        [SugarColumn(ColumnName = "Dsdsvcntgrp", ColumnDescription = "计算组 ", Length = 20)]
        public string Dsdsvcntgrp { get; set; }

        /// <summary>
        /// DSD 分组
        /// </summary>
        [SugarColumn(ColumnName = "Dsdvcgroup", ColumnDescription = "DSD 分组 ", Length = 12)]
        public string Dsdvcgroup { get; set; }

        /// <summary>
        /// 可以倾斜物料 (车辆空间优化)
        /// </summary>
        [SugarColumn(ColumnName = "Vsortiltind", ColumnDescription = "可以倾斜物料 (车辆空间优化) ", Length = 2)]
        public string Vsortiltind { get; set; }

        /// <summary>
        /// 不允许堆栈 (VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Vsorstackind", ColumnDescription = "不允许堆栈 (VSO) ", Length = 2)]
        public string Vsorstackind { get; set; }

        /// <summary>
        /// 底层 (车辆空间最优化)
        /// </summary>
        [SugarColumn(ColumnName = "Vsorbotind", ColumnDescription = "底层 (车辆空间最优化) ", Length = 2)]
        public string Vsorbotind { get; set; }

        /// <summary>
        /// 顶层 (VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Vsortopind", ColumnDescription = "顶层 (VSO) ", Length = 2)]
        public string Vsortopind { get; set; }

        /// <summary>
        /// 堆栈因子 (车辆空间优化)
        /// </summary>
        [SugarColumn(ColumnName = "Vsorstackno", ColumnDescription = "堆栈因子 (车辆空间优化) ", DefaultValue = "0")]
        public int? Vsorstackno { get; set; }

        /// <summary>
        /// 无包装物料的装载 (VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Vsorpalind", ColumnDescription = "无包装物料的装载 (VSO) ", Length = 2)]
        public string Vsorpalind { get; set; }

        /// <summary>
        /// 包装物料的允许悬挂深度 (VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Vsorpalovrd", ColumnDescription = "包装物料的允许悬挂深度 (VSO) ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vsorpalovrd { get; set; }

        /// <summary>
        /// 装运物料的允许悬挂宽度 (VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Vsorpalovrw", ColumnDescription = "装运物料的允许悬挂宽度 (VSO) ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vsorpalovrw { get; set; }

        /// <summary>
        /// 包装物料的最大叠放高度 (VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Vsorpalbht", ColumnDescription = "包装物料的最大叠放高度 (VSO) ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vsorpalbht { get; set; }

        /// <summary>
        /// 包装物料的最小叠放高度 (VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Vsorpalminh", ColumnDescription = "包装物料的最小叠放高度 (VSO) ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vsorpalminh { get; set; }

        /// <summary>
        /// 超出最大叠放高度的容差 (VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Vsortolbht", ColumnDescription = "超出最大叠放高度的容差 (VSO) ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vsortolbht { get; set; }

        /// <summary>
        /// 每个已结清 PKM 的物料编号(VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Vsornopgvh", ColumnDescription = "每个已结清 PKM 的物料编号(VSO) ", DefaultValue = "0")]
        public int? Vsornopgvh { get; set; }

        /// <summary>
        /// 计量单位车辆空间优化
        /// </summary>
        [SugarColumn(ColumnName = "Vsorquanunit", ColumnDescription = "计量单位车辆空间优化 ", Length = 6)]
        public string Vsorquanunit { get; set; }

        /// <summary>
        /// 请求的已清包装物料 (VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Vsorkzgvhind", ColumnDescription = "请求的已清包装物料 (VSO) ", Length = 2)]
        public string Vsorkzgvhind { get; set; }

        /// <summary>
        /// Packaging Code
        /// </summary>
        [SugarColumn(ColumnName = "Packcode", ColumnDescription = "Packaging Code ", Length = 20)]
        public string Packcode { get; set; }

        /// <summary>
        /// 危险品的包装状态
        /// </summary>
        [SugarColumn(ColumnName = "Dgpackstatus", ColumnDescription = "危险品的包装状态 ", Length = 20)]
        public string Dgpackstatus { get; set; }

        /// <summary>
        /// 物料条件管理
        /// </summary>
        [SugarColumn(ColumnName = "Mcond", ColumnDescription = "物料条件管理 ", Length = 2)]
        public string Mcond { get; set; }

        /// <summary>
        /// 返回代码
        /// </summary>
        [SugarColumn(ColumnName = "Retdelc", ColumnDescription = "返回代码 ", Length = 2)]
        public string Retdelc { get; set; }

        /// <summary>
        /// 后勤等级退货
        /// </summary>
        [SugarColumn(ColumnName = "Loglevreto", ColumnDescription = "后勤等级退货 ", Length = 2)]
        public string Loglevreto { get; set; }

        /// <summary>
        /// NATO 项目标识编号
        /// </summary>
        [SugarColumn(ColumnName = "Nsnid", ColumnDescription = "NATO 项目标识编号 ", Length = 18)]
        public string Nsnid { get; set; }

        /// <summary>
        /// 完全互换组
        /// </summary>
        [SugarColumn(ColumnName = "Imatn", ColumnDescription = "完全互换组 ", Length = 36)]
        public string Imatn { get; set; }

        /// <summary>
        /// 替换链编号
        /// </summary>
        [SugarColumn(ColumnName = "Picnum", ColumnDescription = "替换链编号 ", Length = 36)]
        public string Picnum { get; set; }

        /// <summary>
        /// 创建状态 - 季节性采购
        /// </summary>
        [SugarColumn(ColumnName = "Bstat", ColumnDescription = "创建状态 - 季节性采购 ", Length = 4)]
        public string Bstat { get; set; }

        /// <summary>
        /// 颜色特性的内部特性编号
        /// </summary>
        [SugarColumn(ColumnName = "Coloratinn", ColumnDescription = "颜色特性的内部特性编号 ", DefaultValue = "0")]
        public int? Coloratinn { get; set; }

        /// <summary>
        /// 主尺寸的特性的内部特性编号
        /// </summary>
        [SugarColumn(ColumnName = "Size1atinn", ColumnDescription = "主尺寸的特性的内部特性编号 ", DefaultValue = "0")]
        public int? Size1atinn { get; set; }

        /// <summary>
        /// 次尺寸的特性的内部特性编号
        /// </summary>
        [SugarColumn(ColumnName = "Size2atinn", ColumnDescription = "次尺寸的特性的内部特性编号 ", DefaultValue = "0")]
        public int? Size2atinn { get; set; }

        /// <summary>
        /// 变式颜色的特性值
        /// </summary>
        [SugarColumn(ColumnName = "Color", ColumnDescription = "变式颜色的特性值 ", Length = 36)]
        public string Color { get; set; }

        /// <summary>
        /// 变式主尺寸的特性值
        /// </summary>
        [SugarColumn(ColumnName = "Size1", ColumnDescription = "变式主尺寸的特性值 ", Length = 36)]
        public string Size1 { get; set; }

        /// <summary>
        /// 变式的次尺寸的特性值
        /// </summary>
        [SugarColumn(ColumnName = "Size2", ColumnDescription = "变式的次尺寸的特性值 ", Length = 36)]
        public string Size2 { get; set; }

        /// <summary>
        /// 评估目的的特性值
        /// </summary>
        [SugarColumn(ColumnName = "Freechar", ColumnDescription = "评估目的的特性值 ", Length = 36)]
        public string Freechar { get; set; }

        /// <summary>
        /// 护理代码（例如洗涤代码, 烫平衣服代码, 等等)
        /// </summary>
        [SugarColumn(ColumnName = "Carecode", ColumnDescription = "护理代码（例如洗涤代码, 烫平衣服代码, 等等) ", Length = 32)]
        public string Carecode { get; set; }

        /// <summary>
        /// 商标
        /// </summary>
        [SugarColumn(ColumnName = "Brandid", ColumnDescription = "商标 ", Length = 8)]
        public string Brandid { get; set; }

        /// <summary>
        /// 纺织品的光纤代码（组件1）
        /// </summary>
        [SugarColumn(ColumnName = "Fibercode1", ColumnDescription = "纺织品的光纤代码（组件1） ", Length = 6)]
        public string Fibercode1 { get; set; }

        /// <summary>
        /// 光纤的百分比共享（组件1）
        /// </summary>
        [SugarColumn(ColumnName = "Fiberpart1", ColumnDescription = "光纤的百分比共享（组件1） ", DefaultValue = "0")]
        public int? Fiberpart1 { get; set; }

        /// <summary>
        /// 纺织品的光纤代码（组件2）
        /// </summary>
        [SugarColumn(ColumnName = "Fibercode2", ColumnDescription = "纺织品的光纤代码（组件2） ", Length = 6)]
        public string Fibercode2 { get; set; }

        /// <summary>
        /// 光纤的百分比共享（组件2）
        /// </summary>
        [SugarColumn(ColumnName = "Fiberpart2", ColumnDescription = "光纤的百分比共享（组件2） ", DefaultValue = "0")]
        public int? Fiberpart2 { get; set; }

        /// <summary>
        /// 纺织品的光纤代码（组件3）
        /// </summary>
        [SugarColumn(ColumnName = "Fibercode3", ColumnDescription = "纺织品的光纤代码（组件3） ", Length = 6)]
        public string Fibercode3 { get; set; }

        /// <summary>
        /// 光纤的百分比共享（组件3）
        /// </summary>
        [SugarColumn(ColumnName = "Fiberpart3", ColumnDescription = "光纤的百分比共享（组件3） ", DefaultValue = "0")]
        public int? Fiberpart3 { get; set; }

        /// <summary>
        /// 纺织品的光纤代码（组件4）
        /// </summary>
        [SugarColumn(ColumnName = "Fibercode4", ColumnDescription = "纺织品的光纤代码（组件4） ", Length = 6)]
        public string Fibercode4 { get; set; }

        /// <summary>
        /// 光纤的百分比共享（组件4）
        /// </summary>
        [SugarColumn(ColumnName = "Fiberpart4", ColumnDescription = "光纤的百分比共享（组件4） ", DefaultValue = "0")]
        public int? Fiberpart4 { get; set; }

        /// <summary>
        /// 纺织品的光纤代码（组件5）
        /// </summary>
        [SugarColumn(ColumnName = "Fibercode5", ColumnDescription = "纺织品的光纤代码（组件5） ", Length = 6)]
        public string Fibercode5 { get; set; }

        /// <summary>
        /// 光纤的百分比共享（组件5）
        /// </summary>
        [SugarColumn(ColumnName = "Fiberpart5", ColumnDescription = "光纤的百分比共享（组件5） ", DefaultValue = "0")]
        public int? Fiberpart5 { get; set; }

        /// <summary>
        /// 时装等级
        /// </summary>
        [SugarColumn(ColumnName = "Fashgrd", ColumnDescription = "时装等级 ", Length = 8)]
        public string Fashgrd { get; set; }
    }
}