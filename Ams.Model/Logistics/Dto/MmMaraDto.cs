namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 常规物料
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:37:36
    /// </summary>
    public class MmMaraQueryDto : PagerInfo
    {
        public string Matnr { get; set; }
        public string Lvorm { get; set; }
        public string Mtart { get; set; }
        public string Mbrsh { get; set; }
        public string Matkl { get; set; }
        public string Meins { get; set; }
        public string Gewei { get; set; }
        public string Voleh { get; set; }
        public string Mstae { get; set; }
    }

    /// <summary>
    /// 常规物料
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:37:36
    /// </summary>
    public class MmMaraDto
    {
        [Required(ErrorMessage = "ID主键不能为空")]
        [ExcelColumn(Name = "ID主键")]
        [ExcelColumnName("ID主键")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SfId { get; set; }

        [ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Mandt { get; set; }

        [Required(ErrorMessage = "物料号不能为空")]
        [ExcelColumn(Name = "物料号")]
        [ExcelColumnName("物料号")]
        public string Matnr { get; set; }

        [ExcelColumn(Name = "创建日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("创建日期")]
        public DateTime? Ersda { get; set; }

        [ExcelColumn(Name = "创建对象的人员名称")]
        [ExcelColumnName("创建对象的人员名称")]
        public string Ernam { get; set; }

        [ExcelColumn(Name = "上次更改的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("上次更改的日期")]
        public DateTime? Laeda { get; set; }

        [ExcelColumn(Name = "对象更改人员的名称")]
        [ExcelColumnName("对象更改人员的名称")]
        public string Aenam { get; set; }

        [ExcelColumn(Name = "维护全部物料状态")]
        [ExcelColumnName("维护全部物料状态")]
        public string Vpsta { get; set; }

        [ExcelColumn(Name = "维护状态")]
        [ExcelColumnName("维护状态")]
        public string Pstat { get; set; }

        [Required(ErrorMessage = "在客户级标记要删除的物料不能为空")]
        [ExcelColumn(Name = "在客户级标记要删除的物料")]
        [ExcelColumnName("在客户级标记要删除的物料")]
        public string Lvorm { get; set; }

        [Required(ErrorMessage = "物料类型不能为空")]
        [ExcelColumn(Name = "物料类型")]
        [ExcelColumnName("物料类型")]
        public string Mtart { get; set; }

        [Required(ErrorMessage = "行业领域不能为空")]
        [ExcelColumn(Name = "行业领域")]
        [ExcelColumnName("行业领域")]
        public string Mbrsh { get; set; }

        [Required(ErrorMessage = "物料组不能为空")]
        [ExcelColumn(Name = "物料组")]
        [ExcelColumnName("物料组")]
        public string Matkl { get; set; }

        [ExcelColumn(Name = "旧物料号")]
        [ExcelColumnName("旧物料号")]
        public string Bismt { get; set; }

        [Required(ErrorMessage = "基本计量单位不能为空")]
        [ExcelColumn(Name = "基本计量单位")]
        [ExcelColumnName("基本计量单位")]
        public string Meins { get; set; }

        [ExcelColumn(Name = "采购订单的计量单位")]
        [ExcelColumnName("采购订单的计量单位")]
        public string Bstme { get; set; }

        [ExcelColumn(Name = "文档号码(无文档管理系统)")]
        [ExcelColumnName("文档号码(无文档管理系统)")]
        public string Zeinr { get; set; }

        [ExcelColumn(Name = "凭证类型(无凭证管理系统)")]
        [ExcelColumnName("凭证类型(无凭证管理系统)")]
        public string Zeiar { get; set; }

        [ExcelColumn(Name = "文档版本（无文档管理系统）")]
        [ExcelColumnName("文档版本（无文档管理系统）")]
        public string Zeivr { get; set; }

        [ExcelColumn(Name = "文件的页面大小（不包括文件管理系统）")]
        [ExcelColumnName("文件的页面大小（不包括文件管理系统）")]
        public string Zeifo { get; set; }

        [ExcelColumn(Name = "文档变更号(无文档管理系统)")]
        [ExcelColumnName("文档变更号(无文档管理系统)")]
        public string Aeszn { get; set; }

        [ExcelColumn(Name = "凭证的页号(不带凭证管理系统)")]
        [ExcelColumnName("凭证的页号(不带凭证管理系统)")]
        public string Blatt { get; set; }

        [ExcelColumn(Name = "页数(没有凭证管理系统)")]
        [ExcelColumnName("页数(没有凭证管理系统)")]
        public int? Blanz { get; set; }

        [ExcelColumn(Name = "生产/检验备忘录")]
        [ExcelColumnName("生产/检验备忘录")]
        public string Ferth { get; set; }

        [ExcelColumn(Name = "生产备忘录的页格式")]
        [ExcelColumnName("生产备忘录的页格式")]
        public string Formt { get; set; }

        [ExcelColumn(Name = "大小/量纲")]
        [ExcelColumnName("大小/量纲")]
        public string Groes { get; set; }

        [ExcelColumn(Name = "基本物料")]
        [ExcelColumnName("基本物料")]
        public string Wrkst { get; set; }

        [ExcelColumn(Name = "行业标准描述（例如 ANSI 或 ISO）")]
        [ExcelColumnName("行业标准描述（例如 ANSI 或 ISO）")]
        public string Normt { get; set; }

        [ExcelColumn(Name = "实验室/设计室")]
        [ExcelColumnName("实验室/设计室")]
        public string Labor { get; set; }

        [ExcelColumn(Name = "采购价值代码")]
        [ExcelColumnName("采购价值代码")]
        public string Ekwsl { get; set; }

        [ExcelColumn(Name = "毛重")]
        [ExcelColumnName("毛重")]
        public decimal Brgew { get; set; }

        [ExcelColumn(Name = "净重")]
        [ExcelColumnName("净重")]
        public decimal Ntgew { get; set; }

        [Required(ErrorMessage = "重量单位不能为空")]
        [ExcelColumn(Name = "重量单位")]
        [ExcelColumnName("重量单位")]
        public string Gewei { get; set; }

        [ExcelColumn(Name = "业务量")]
        [ExcelColumnName("业务量")]
        public decimal Volum { get; set; }

        [Required(ErrorMessage = "体积单位不能为空")]
        [ExcelColumn(Name = "体积单位")]
        [ExcelColumnName("体积单位")]
        public string Voleh { get; set; }

        [ExcelColumn(Name = "容器需求")]
        [ExcelColumnName("容器需求")]
        public string Behvo { get; set; }

        [ExcelColumn(Name = "存储条件")]
        [ExcelColumnName("存储条件")]
        public string Raube { get; set; }

        [ExcelColumn(Name = "温度条件标识")]
        [ExcelColumnName("温度条件标识")]
        public string Tempb { get; set; }

        [ExcelColumn(Name = "低层代码")]
        [ExcelColumnName("低层代码")]
        public string Disst { get; set; }

        [ExcelColumn(Name = "运输组")]
        [ExcelColumnName("运输组")]
        public string Tragr { get; set; }

        [ExcelColumn(Name = "危险物料号")]
        [ExcelColumnName("危险物料号")]
        public string Stoff { get; set; }

        [ExcelColumn(Name = "产品组")]
        [ExcelColumnName("产品组")]
        public string Spart { get; set; }

        [ExcelColumn(Name = "竞争者")]
        [ExcelColumnName("竞争者")]
        public string Kunnr { get; set; }

        [ExcelColumn(Name = "欧洲物品号 (EAN) - 已过时的 !!!!!")]
        [ExcelColumnName("欧洲物品号 (EAN) - 已过时的 !!!!!")]
        public string Eannr { get; set; }

        [ExcelColumn(Name = "数量: 待打印的 GR/GI 单数量")]
        [ExcelColumnName("数量: 待打印的 GR/GI 单数量")]
        public decimal Wesch { get; set; }

        [ExcelColumn(Name = "采购规则")]
        [ExcelColumnName("采购规则")]
        public string Bwvor { get; set; }

        [ExcelColumn(Name = "货源")]
        [ExcelColumnName("货源")]
        public string Bwscl { get; set; }

        [ExcelColumn(Name = "季节类别")]
        [ExcelColumnName("季节类别")]
        public string Saiso { get; set; }

        [ExcelColumn(Name = "标签类型")]
        [ExcelColumnName("标签类型")]
        public string Etiar { get; set; }

        [ExcelColumn(Name = "标签格式")]
        [ExcelColumnName("标签格式")]
        public string Etifo { get; set; }

        [ExcelColumn(Name = "取消激活的")]
        [ExcelColumnName("取消激活的")]
        public string Entar { get; set; }

        [ExcelColumn(Name = "国际文件号(EAN/UPC)")]
        [ExcelColumnName("国际文件号(EAN/UPC)")]
        public string Ean11 { get; set; }

        [ExcelColumn(Name = "国际商品编码的类别 (EAN)")]
        [ExcelColumnName("国际商品编码的类别 (EAN)")]
        public string Numtp { get; set; }

        [ExcelColumn(Name = "长度")]
        [ExcelColumnName("长度")]
        public decimal Laeng { get; set; }

        [ExcelColumn(Name = "宽度")]
        [ExcelColumnName("宽度")]
        public decimal Breit { get; set; }

        [ExcelColumn(Name = "高度")]
        [ExcelColumnName("高度")]
        public decimal Hoehe { get; set; }

        [ExcelColumn(Name = "长度/宽度/高度的尺寸单位")]
        [ExcelColumnName("长度/宽度/高度的尺寸单位")]
        public string Meabm { get; set; }

        [ExcelColumn(Name = "产品层次")]
        [ExcelColumnName("产品层次")]
        public string Prdha { get; set; }

        [ExcelColumn(Name = "库存转移净改变成本核算")]
        [ExcelColumnName("库存转移净改变成本核算")]
        public string Aeklk { get; set; }

        [ExcelColumn(Name = "CAD 标识")]
        [ExcelColumnName("CAD 标识")]
        public string Cadkz { get; set; }

        [ExcelColumn(Name = "激活采购中的 QM")]
        [ExcelColumnName("激活采购中的 QM")]
        public string Qmpur { get; set; }

        [ExcelColumn(Name = "允许的包装重量")]
        [ExcelColumnName("允许的包装重量")]
        public decimal Ergew { get; set; }

        [ExcelColumn(Name = "加权的单位(允许打包加权)")]
        [ExcelColumnName("加权的单位(允许打包加权)")]
        public string Ergei { get; set; }

        [ExcelColumn(Name = "允许的包装体积")]
        [ExcelColumnName("允许的包装体积")]
        public decimal Ervol { get; set; }

        [ExcelColumn(Name = "体积单位(允许打包体积)")]
        [ExcelColumnName("体积单位(允许打包体积)")]
        public string Ervoe { get; set; }

        [ExcelColumn(Name = "处理单位的超重量容差")]
        [ExcelColumnName("处理单位的超重量容差")]
        public decimal Gewto { get; set; }

        [ExcelColumn(Name = "处理单位的超量冗差")]
        [ExcelColumnName("处理单位的超量冗差")]
        public decimal Volto { get; set; }

        [ExcelColumn(Name = "可变采购订单单位活动")]
        [ExcelColumnName("可变采购订单单位活动")]
        public string Vabme { get; set; }

        [ExcelColumn(Name = "标识: 修改水平已分配到物料")]
        [ExcelColumnName("标识: 修改水平已分配到物料")]
        public string Kzrev { get; set; }

        [ExcelColumn(Name = "可配置的物料")]
        [ExcelColumnName("可配置的物料")]
        public string Kzkfg { get; set; }

        [ExcelColumn(Name = "批次管理需求的标识")]
        [ExcelColumnName("批次管理需求的标识")]
        public string Xchpf { get; set; }

        [ExcelColumn(Name = "包装物料类型")]
        [ExcelColumnName("包装物料类型")]
        public string Vhart { get; set; }

        [ExcelColumn(Name = "最大层次 (按体积)")]
        [ExcelColumnName("最大层次 (按体积)")]
        public decimal Fuelg { get; set; }

        [ExcelColumn(Name = "堆栈因子")]
        [ExcelColumnName("堆栈因子")]
        public int? Stfak { get; set; }

        [ExcelColumn(Name = "物料组: 包装物料")]
        [ExcelColumnName("物料组: 包装物料")]
        public string Magrv { get; set; }

        [ExcelColumn(Name = "权限组")]
        [ExcelColumnName("权限组")]
        public string Begru { get; set; }

        [ExcelColumn(Name = "开始生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("开始生效日期")]
        public DateTime? Datab { get; set; }

        [ExcelColumn(Name = "删除日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("删除日期")]
        public DateTime? Liqdt { get; set; }

        [ExcelColumn(Name = "季度年")]
        [ExcelColumnName("季度年")]
        public string Saisj { get; set; }

        [ExcelColumn(Name = "价格标记类别")]
        [ExcelColumnName("价格标记类别")]
        public string Plgtp { get; set; }

        [ExcelColumn(Name = "空白物料清单")]
        [ExcelColumnName("空白物料清单")]
        public string Mlgut { get; set; }

        [ExcelColumn(Name = "外部物料组")]
        [ExcelColumnName("外部物料组")]
        public string Extwg { get; set; }

        [ExcelColumn(Name = "一般可配置物料")]
        [ExcelColumnName("一般可配置物料")]
        public string Satnr { get; set; }

        [ExcelColumn(Name = "物料类别")]
        [ExcelColumnName("物料类别")]
        public string Attyp { get; set; }

        [ExcelColumn(Name = "指示符 : 物料是联产品")]
        [ExcelColumnName("指示符 : 物料是联产品")]
        public string Kzkup { get; set; }

        [ExcelColumn(Name = "标记：物料有一后续物料")]
        [ExcelColumnName("标记：物料有一后续物料")]
        public string Kznfm { get; set; }

        [ExcelColumn(Name = "定价参考物料")]
        [ExcelColumnName("定价参考物料")]
        public string Pmata { get; set; }

        [Required(ErrorMessage = "跨工厂物料状态不能为空")]
        [ExcelColumn(Name = "跨工厂物料状态")]
        [ExcelColumnName("跨工厂物料状态")]
        public string Mstae { get; set; }

        [ExcelColumn(Name = "跨分销链物料状态")]
        [ExcelColumnName("跨分销链物料状态")]
        public string Mstav { get; set; }

        [ExcelColumn(Name = "从跨工厂物料状态有效起的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("从跨工厂物料状态有效起的日期")]
        public DateTime? Mstde { get; set; }

        [ExcelColumn(Name = "从跨分销链物料状态有效起的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("从跨分销链物料状态有效起的日期")]
        public DateTime? Mstdv { get; set; }

        [ExcelColumn(Name = "物料从税收分类")]
        [ExcelColumnName("物料从税收分类")]
        public string Taklv { get; set; }

        [ExcelColumn(Name = "类别参数文件")]
        [ExcelColumnName("类别参数文件")]
        public string Rbnrm { get; set; }

        [ExcelColumn(Name = "最短剩余货架寿命")]
        [ExcelColumnName("最短剩余货架寿命")]
        public decimal Mhdrz { get; set; }

        [ExcelColumn(Name = "总货架寿命")]
        [ExcelColumnName("总货架寿命")]
        public decimal Mhdhb { get; set; }

        [ExcelColumn(Name = "仓储百分比")]
        [ExcelColumnName("仓储百分比")]
        public decimal Mhdlp { get; set; }

        [ExcelColumn(Name = "内容单位")]
        [ExcelColumnName("内容单位")]
        public string Inhme { get; set; }

        [ExcelColumn(Name = "净内容")]
        [ExcelColumnName("净内容")]
        public decimal Inhal { get; set; }

        [ExcelColumn(Name = "比较价格单位")]
        [ExcelColumnName("比较价格单位")]
        public decimal Vpreh { get; set; }

        [ExcelColumn(Name = "IS-R 标签：物料组（在 4.0 中不活动）")]
        [ExcelColumnName("IS-R 标签：物料组（在 4.0 中不活动）")]
        public string Etiag { get; set; }

        [ExcelColumn(Name = "毛内容")]
        [ExcelColumnName("毛内容")]
        public decimal Inhbr { get; set; }

        [ExcelColumn(Name = "数量转换方法")]
        [ExcelColumnName("数量转换方法")]
        public string Cmeth { get; set; }

        [ExcelColumn(Name = "内部对象号")]
        [ExcelColumnName("内部对象号")]
        public int? Cuobf { get; set; }

        [ExcelColumn(Name = "环境相关")]
        [ExcelColumnName("环境相关")]
        public string Kzumw { get; set; }

        [ExcelColumn(Name = "产品分配确定程序")]
        [ExcelColumnName("产品分配确定程序")]
        public string Kosch { get; set; }

        [ExcelColumn(Name = "变式的定价参数文件")]
        [ExcelColumnName("变式的定价参数文件")]
        public string Sprof { get; set; }

        [ExcelColumn(Name = "针对物料的折扣类型")]
        [ExcelColumnName("针对物料的折扣类型")]
        public string Nrfhg { get; set; }

        [ExcelColumn(Name = "制造商零件编号")]
        [ExcelColumnName("制造商零件编号")]
        public string Mfrpn { get; set; }

        [ExcelColumn(Name = "制造商编号")]
        [ExcelColumnName("制造商编号")]
        public string Mfrnr { get; set; }

        [ExcelColumn(Name = "公司自己 (内部) 的盘点管理物料编号")]
        [ExcelColumnName("公司自己 (内部) 的盘点管理物料编号")]
        public string Bmatn { get; set; }

        [ExcelColumn(Name = "制造商部件参数文件")]
        [ExcelColumnName("制造商部件参数文件")]
        public string Mprof { get; set; }

        [ExcelColumn(Name = "计量单位使用")]
        [ExcelColumnName("计量单位使用")]
        public string Kzwsm { get; set; }

        [ExcelColumn(Name = "在季节内展开")]
        [ExcelColumnName("在季节内展开")]
        public string Saity { get; set; }

        [ExcelColumn(Name = "危险货物标识参数文件")]
        [ExcelColumnName("危险货物标识参数文件")]
        public string Profl { get; set; }

        [ExcelColumn(Name = "标识符:高粘性的")]
        [ExcelColumnName("标识符:高粘性的")]
        public string Ihivi { get; set; }

        [ExcelColumn(Name = "标识符:固体/液体")]
        [ExcelColumnName("标识符:固体/液体")]
        public string Iloos { get; set; }

        [ExcelColumn(Name = "序列号的清晰的级别")]
        [ExcelColumnName("序列号的清晰的级别")]
        public string Serlv { get; set; }

        [ExcelColumn(Name = "包装物料是密闭包装的")]
        [ExcelColumnName("包装物料是密闭包装的")]
        public string Kzgvh { get; set; }

        [ExcelColumn(Name = "指示符：需要批准的批量记录")]
        [ExcelColumnName("指示符：需要批准的批量记录")]
        public string Xgchp { get; set; }

        [ExcelColumn(Name = "指定有效参数值/覆盖更改编号")]
        [ExcelColumnName("指定有效参数值/覆盖更改编号")]
        public string Kzeff { get; set; }

        [ExcelColumn(Name = "物料完成的水平")]
        [ExcelColumnName("物料完成的水平")]
        public int? Compl { get; set; }

        [ExcelColumn(Name = "货架寿命到期日的期间标识")]
        [ExcelColumnName("货架寿命到期日的期间标识")]
        public string Iprkz { get; set; }

        [ExcelColumn(Name = "货架寿命到期日期计算舍入规则")]
        [ExcelColumnName("货架寿命到期日期计算舍入规则")]
        public string Rdmhd { get; set; }

        [ExcelColumn(Name = "标识：印刷在包装上的产品成份")]
        [ExcelColumnName("标识：印刷在包装上的产品成份")]
        public string Przus { get; set; }

        [ExcelColumn(Name = "普通项目类别组")]
        [ExcelColumnName("普通项目类别组")]
        public string Mtposmara { get; set; }

        [ExcelColumn(Name = "含后勤变量的一般物料")]
        [ExcelColumnName("含后勤变量的一般物料")]
        public string Bflme { get; set; }

        [ExcelColumn(Name = "物料被锁定")]
        [ExcelColumnName("物料被锁定")]
        public string Matfi { get; set; }

        [ExcelColumn(Name = "与配置管理相关")]
        [ExcelColumnName("与配置管理相关")]
        public string Cmrel { get; set; }

        [ExcelColumn(Name = "分类清单类型")]
        [ExcelColumnName("分类清单类型")]
        public string Bbtyp { get; set; }

        [ExcelColumn(Name = "过期日期")]
        [ExcelColumnName("过期日期")]
        public string Sledbbd { get; set; }

        [ExcelColumn(Name = "全球贸易项目编号变式")]
        [ExcelColumnName("全球贸易项目编号变式")]
        public string Gtinvariant { get; set; }

        [ExcelColumn(Name = "在预包装物料中的一般物料的物料编号")]
        [ExcelColumnName("在预包装物料中的一般物料的物料编号")]
        public string Gennr { get; set; }

        [ExcelColumn(Name = "以相同方式包装的物料的参考物料")]
        [ExcelColumnName("以相同方式包装的物料的参考物料")]
        public string Rmatp { get; set; }

        [ExcelColumn(Name = "标识：全局数据同步相关")]
        [ExcelColumnName("标识：全局数据同步相关")]
        public string Gdsrelevant { get; set; }

        [ExcelColumn(Name = "原始接受")]
        [ExcelColumnName("原始接受")]
        public string Weora { get; set; }

        [ExcelColumn(Name = "标准处理单位类型")]
        [ExcelColumnName("标准处理单位类型")]
        public string Hutypdflt { get; set; }

        [ExcelColumn(Name = "可偷窃的")]
        [ExcelColumnName("可偷窃的")]
        public string Pilferable { get; set; }

        [ExcelColumn(Name = "仓库存储条件")]
        [ExcelColumnName("仓库存储条件")]
        public string Whstc { get; set; }

        [ExcelColumn(Name = "仓库物料组")]
        [ExcelColumnName("仓库物料组")]
        public string Whmatgr { get; set; }

        [ExcelColumn(Name = "处理标识")]
        [ExcelColumnName("处理标识")]
        public string Hndlcode { get; set; }

        [ExcelColumn(Name = "与危险物料相关")]
        [ExcelColumnName("与危险物料相关")]
        public string Hazmat { get; set; }

        [ExcelColumn(Name = "处理单位类型")]
        [ExcelColumnName("处理单位类型")]
        public string Hutyp { get; set; }

        [ExcelColumn(Name = "可变皮重")]
        [ExcelColumnName("可变皮重")]
        public string Tarevar { get; set; }

        [ExcelColumn(Name = "包装物料的最大允许容量")]
        [ExcelColumnName("包装物料的最大允许容量")]
        public decimal Maxc { get; set; }

        [ExcelColumn(Name = "处理单位的最大容量容差")]
        [ExcelColumnName("处理单位的最大容量容差")]
        public decimal Maxctol { get; set; }

        [ExcelColumn(Name = "包装物料的最大包长度")]
        [ExcelColumnName("包装物料的最大包长度")]
        public decimal Maxl { get; set; }

        [ExcelColumn(Name = "包装物料的最大包宽度")]
        [ExcelColumnName("包装物料的最大包宽度")]
        public decimal Maxb { get; set; }

        [ExcelColumn(Name = "包装物料的最大包高度")]
        [ExcelColumnName("包装物料的最大包高度")]
        public decimal Maxh { get; set; }

        [ExcelColumn(Name = "最大包装长/宽/高的计量单位")]
        [ExcelColumnName("最大包装长/宽/高的计量单位")]
        public string Maxdimuom { get; set; }

        [ExcelColumn(Name = "物料原产地国家")]
        [ExcelColumnName("物料原产地国家")]
        public string Herkl { get; set; }

        [ExcelColumn(Name = "物料运输组")]
        [ExcelColumnName("物料运输组")]
        public string Mfrgr { get; set; }

        [ExcelColumn(Name = "隔离期间")]
        [ExcelColumnName("隔离期间")]
        public decimal Qqtime { get; set; }

        [ExcelColumn(Name = "隔离期间的时间单位")]
        [ExcelColumnName("隔离期间的时间单位")]
        public string Qqtimeuom { get; set; }

        [ExcelColumn(Name = "质量检查组")]
        [ExcelColumnName("质量检查组")]
        public string Qgrp { get; set; }

        [ExcelColumn(Name = "序列号参数文件")]
        [ExcelColumnName("序列号参数文件")]
        public string Serial { get; set; }

        [ExcelColumn(Name = "表格名")]
        [ExcelColumnName("表格名")]
        public string Pssmartform { get; set; }

        [ExcelColumn(Name = "EWM CW: 后勤计量单位")]
        [ExcelColumnName("EWM CW: 后勤计量单位")]
        public string Logunit { get; set; }

        [ExcelColumn(Name = "EWM CW: 物料是称重物料")]
        [ExcelColumnName("EWM CW: 物料是称重物料")]
        public string Cwqrel { get; set; }

        [ExcelColumn(Name = "EWM CW: 输入 CW 数量的称重参数文件")]
        [ExcelColumnName("EWM CW: 输入 CW 数量的称重参数文件")]
        public string Cwqproc { get; set; }

        [ExcelColumn(Name = "EWM-CW: EWM 的称重容差组")]
        [ExcelColumnName("EWM-CW: EWM 的称重容差组")]
        public string Cwqtolgr { get; set; }

        [ExcelColumn(Name = "调整参数文件")]
        [ExcelColumnName("调整参数文件")]
        public string Adprof { get; set; }

        [ExcelColumn(Name = "知识产权标识（CRM 产品）")]
        [ExcelColumnName("知识产权标识（CRM 产品）")]
        public string Ipmipproduct { get; set; }

        [ExcelColumn(Name = "允许的变式价格（针对物料主数据）")]
        [ExcelColumnName("允许的变式价格（针对物料主数据）")]
        public string Allowpmatigno { get; set; }

        [ExcelColumn(Name = "中间")]
        [ExcelColumnName("中间")]
        public string Medium { get; set; }

        [ExcelColumn(Name = "实物商品")]
        [ExcelColumnName("实物商品")]
        public string Commodity { get; set; }

        [ExcelColumn(Name = "标识：包含动物源的非纺织部分")]
        [ExcelColumnName("标识：包含动物源的非纺织部分")]
        public string Animalorigin { get; set; }

        [ExcelColumn(Name = "标识：新纺织组分功能")]
        [ExcelColumnName("标识：新纺织组分功能")]
        public string Textilecompind { get; set; }

        [ExcelColumn(Name = "分段结构")]
        [ExcelColumnName("分段结构")]
        public string Sgtcsgr { get; set; }

        [ExcelColumn(Name = "分段策略")]
        [ExcelColumnName("分段策略")]
        public string Sgtcovsa { get; set; }

        [ExcelColumn(Name = "分段物料主数据状态")]
        [ExcelColumnName("分段物料主数据状态")]
        public string Sgtstat { get; set; }

        [ExcelColumn(Name = "分段策略范围")]
        [ExcelColumnName("分段策略范围")]
        public string Sgtscope { get; set; }

        [ExcelColumn(Name = "分段相关")]
        [ExcelColumnName("分段相关")]
        public string Sgtrel { get; set; }

        [ExcelColumn(Name = "ANP Code")]
        [ExcelColumnName("ANP Code")]
        public int? Anp { get; set; }

        [ExcelColumn(Name = "Fashion 信息字段：1")]
        [ExcelColumnName("Fashion 信息字段：1")]
        public string Fshmgat1 { get; set; }

        [ExcelColumn(Name = "Fashion 信息字段：2")]
        [ExcelColumnName("Fashion 信息字段：2")]
        public string Fshmgat2 { get; set; }

        [ExcelColumn(Name = "Fashion 信息字段：3")]
        [ExcelColumnName("Fashion 信息字段：3")]
        public string Fshmgat3 { get; set; }

        [ExcelColumn(Name = "标识：季节使用")]
        [ExcelColumnName("标识：季节使用")]
        public string Fshsealv { get; set; }

        [ExcelColumn(Name = "标识：在库存管理中激活季节")]
        [ExcelColumnName("标识：在库存管理中激活季节")]
        public string Fshseaim { get; set; }

        [ExcelColumn(Name = "特征值转换的物料转换标识")]
        [ExcelColumnName("特征值转换的物料转换标识")]
        public string Fshscmid { get; set; }

        [ExcelColumn(Name = "装载单位")]
        [ExcelColumnName("装载单位")]
        public int? Bev1luleinh { get; set; }

        [ExcelColumn(Name = "装载单位组：IS 饮料")]
        [ExcelColumnName("装载单位组：IS 饮料")]
        public string Bev1luldegrp { get; set; }

        [ExcelColumn(Name = "物料关系的结构类别")]
        [ExcelColumnName("物料关系的结构类别")]
        public string Bev1nestruccat { get; set; }

        [ExcelColumn(Name = "容差类型标识")]
        [ExcelColumnName("容差类型标识")]
        public string Dsdsltoltyp { get; set; }

        [ExcelColumn(Name = "计算组")]
        [ExcelColumnName("计算组")]
        public string Dsdsvcntgrp { get; set; }

        [ExcelColumn(Name = "DSD 分组")]
        [ExcelColumnName("DSD 分组")]
        public string Dsdvcgroup { get; set; }

        [ExcelColumn(Name = "可以倾斜物料 (车辆空间优化)")]
        [ExcelColumnName("可以倾斜物料 (车辆空间优化)")]
        public string Vsortiltind { get; set; }

        [ExcelColumn(Name = "不允许堆栈 (VSO)")]
        [ExcelColumnName("不允许堆栈 (VSO)")]
        public string Vsorstackind { get; set; }

        [ExcelColumn(Name = "底层 (车辆空间最优化)")]
        [ExcelColumnName("底层 (车辆空间最优化)")]
        public string Vsorbotind { get; set; }

        [ExcelColumn(Name = "顶层 (VSO)")]
        [ExcelColumnName("顶层 (VSO)")]
        public string Vsortopind { get; set; }

        [ExcelColumn(Name = "堆栈因子 (车辆空间优化)")]
        [ExcelColumnName("堆栈因子 (车辆空间优化)")]
        public int? Vsorstackno { get; set; }

        [ExcelColumn(Name = "无包装物料的装载 (VSO)")]
        [ExcelColumnName("无包装物料的装载 (VSO)")]
        public string Vsorpalind { get; set; }

        [ExcelColumn(Name = "包装物料的允许悬挂深度 (VSO)")]
        [ExcelColumnName("包装物料的允许悬挂深度 (VSO)")]
        public decimal Vsorpalovrd { get; set; }

        [ExcelColumn(Name = "装运物料的允许悬挂宽度 (VSO)")]
        [ExcelColumnName("装运物料的允许悬挂宽度 (VSO)")]
        public decimal Vsorpalovrw { get; set; }

        [ExcelColumn(Name = "包装物料的最大叠放高度 (VSO)")]
        [ExcelColumnName("包装物料的最大叠放高度 (VSO)")]
        public decimal Vsorpalbht { get; set; }

        [ExcelColumn(Name = "包装物料的最小叠放高度 (VSO)")]
        [ExcelColumnName("包装物料的最小叠放高度 (VSO)")]
        public decimal Vsorpalminh { get; set; }

        [ExcelColumn(Name = "超出最大叠放高度的容差 (VSO)")]
        [ExcelColumnName("超出最大叠放高度的容差 (VSO)")]
        public decimal Vsortolbht { get; set; }

        [ExcelColumn(Name = "每个已结清 PKM 的物料编号(VSO)")]
        [ExcelColumnName("每个已结清 PKM 的物料编号(VSO)")]
        public int? Vsornopgvh { get; set; }

        [ExcelColumn(Name = "计量单位车辆空间优化")]
        [ExcelColumnName("计量单位车辆空间优化")]
        public string Vsorquanunit { get; set; }

        [ExcelColumn(Name = "请求的已清包装物料 (VSO)")]
        [ExcelColumnName("请求的已清包装物料 (VSO)")]
        public string Vsorkzgvhind { get; set; }

        [ExcelColumn(Name = "Packaging Code")]
        [ExcelColumnName("Packaging Code")]
        public string Packcode { get; set; }

        [ExcelColumn(Name = "危险品的包装状态")]
        [ExcelColumnName("危险品的包装状态")]
        public string Dgpackstatus { get; set; }

        [ExcelColumn(Name = "物料条件管理")]
        [ExcelColumnName("物料条件管理")]
        public string Mcond { get; set; }

        [ExcelColumn(Name = "返回代码")]
        [ExcelColumnName("返回代码")]
        public string Retdelc { get; set; }

        [ExcelColumn(Name = "后勤等级退货")]
        [ExcelColumnName("后勤等级退货")]
        public string Loglevreto { get; set; }

        [ExcelColumn(Name = "NATO 项目标识编号")]
        [ExcelColumnName("NATO 项目标识编号")]
        public string Nsnid { get; set; }

        [ExcelColumn(Name = "完全互换组")]
        [ExcelColumnName("完全互换组")]
        public string Imatn { get; set; }

        [ExcelColumn(Name = "替换链编号")]
        [ExcelColumnName("替换链编号")]
        public string Picnum { get; set; }

        [ExcelColumn(Name = "创建状态 - 季节性采购")]
        [ExcelColumnName("创建状态 - 季节性采购")]
        public string Bstat { get; set; }

        [ExcelColumn(Name = "颜色特性的内部特性编号")]
        [ExcelColumnName("颜色特性的内部特性编号")]
        public int? Coloratinn { get; set; }

        [ExcelColumn(Name = "主尺寸的特性的内部特性编号")]
        [ExcelColumnName("主尺寸的特性的内部特性编号")]
        public int? Size1atinn { get; set; }

        [ExcelColumn(Name = "次尺寸的特性的内部特性编号")]
        [ExcelColumnName("次尺寸的特性的内部特性编号")]
        public int? Size2atinn { get; set; }

        [ExcelColumn(Name = "变式颜色的特性值")]
        [ExcelColumnName("变式颜色的特性值")]
        public string Color { get; set; }

        [ExcelColumn(Name = "变式主尺寸的特性值")]
        [ExcelColumnName("变式主尺寸的特性值")]
        public string Size1 { get; set; }

        [ExcelColumn(Name = "变式的次尺寸的特性值")]
        [ExcelColumnName("变式的次尺寸的特性值")]
        public string Size2 { get; set; }

        [ExcelColumn(Name = "评估目的的特性值")]
        [ExcelColumnName("评估目的的特性值")]
        public string Freechar { get; set; }

        [ExcelColumn(Name = "护理代码（例如洗涤代码, 烫平衣服代码, 等等)")]
        [ExcelColumnName("护理代码（例如洗涤代码, 烫平衣服代码, 等等)")]
        public string Carecode { get; set; }

        [ExcelColumn(Name = "商标")]
        [ExcelColumnName("商标")]
        public string Brandid { get; set; }

        [ExcelColumn(Name = "纺织品的光纤代码（组件1）")]
        [ExcelColumnName("纺织品的光纤代码（组件1）")]
        public string Fibercode1 { get; set; }

        [ExcelColumn(Name = "光纤的百分比共享（组件1）")]
        [ExcelColumnName("光纤的百分比共享（组件1）")]
        public int? Fiberpart1 { get; set; }

        [ExcelColumn(Name = "纺织品的光纤代码（组件2）")]
        [ExcelColumnName("纺织品的光纤代码（组件2）")]
        public string Fibercode2 { get; set; }

        [ExcelColumn(Name = "光纤的百分比共享（组件2）")]
        [ExcelColumnName("光纤的百分比共享（组件2）")]
        public int? Fiberpart2 { get; set; }

        [ExcelColumn(Name = "纺织品的光纤代码（组件3）")]
        [ExcelColumnName("纺织品的光纤代码（组件3）")]
        public string Fibercode3 { get; set; }

        [ExcelColumn(Name = "光纤的百分比共享（组件3）")]
        [ExcelColumnName("光纤的百分比共享（组件3）")]
        public int? Fiberpart3 { get; set; }

        [ExcelColumn(Name = "纺织品的光纤代码（组件4）")]
        [ExcelColumnName("纺织品的光纤代码（组件4）")]
        public string Fibercode4 { get; set; }

        [ExcelColumn(Name = "光纤的百分比共享（组件4）")]
        [ExcelColumnName("光纤的百分比共享（组件4）")]
        public int? Fiberpart4 { get; set; }

        [ExcelColumn(Name = "纺织品的光纤代码（组件5）")]
        [ExcelColumnName("纺织品的光纤代码（组件5）")]
        public string Fibercode5 { get; set; }

        [ExcelColumn(Name = "光纤的百分比共享（组件5）")]
        [ExcelColumnName("光纤的百分比共享（组件5）")]
        public int? Fiberpart5 { get; set; }

        [ExcelColumn(Name = "时装等级")]
        [ExcelColumnName("时装等级")]
        public string Fashgrd { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "在客户级标记要删除的物料")]
        public string LvormLabel { get; set; }

        [ExcelColumn(Name = "物料类型")]
        public string MtartLabel { get; set; }

        [ExcelColumn(Name = "行业领域")]
        public string MbrshLabel { get; set; }

        [ExcelColumn(Name = "物料组")]
        public string MatklLabel { get; set; }

        [ExcelColumn(Name = "基本计量单位")]
        public string MeinsLabel { get; set; }

        [ExcelColumn(Name = "跨工厂物料状态")]
        public string MstaeLabel { get; set; }
    }

    /// <summary>
    /// 常规物料
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:37:36
    /// </summary>
    public class MmMaraImportTpl
    {
        [Required(ErrorMessage = "ID主键不能为空")]
        [ExcelColumn(Name = "ID主键")]
        [ExcelColumnName("ID主键")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SfId { get; set; }

        [ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Mandt { get; set; }

        [Required(ErrorMessage = "物料号不能为空")]
        [ExcelColumn(Name = "物料号")]
        [ExcelColumnName("物料号")]
        public string Matnr { get; set; }

        [ExcelColumn(Name = "创建日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("创建日期")]
        public DateTime? Ersda { get; set; }

        [ExcelColumn(Name = "创建对象的人员名称")]
        [ExcelColumnName("创建对象的人员名称")]
        public string Ernam { get; set; }

        [ExcelColumn(Name = "上次更改的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("上次更改的日期")]
        public DateTime? Laeda { get; set; }

        [ExcelColumn(Name = "对象更改人员的名称")]
        [ExcelColumnName("对象更改人员的名称")]
        public string Aenam { get; set; }

        [ExcelColumn(Name = "维护全部物料状态")]
        [ExcelColumnName("维护全部物料状态")]
        public string Vpsta { get; set; }

        [ExcelColumn(Name = "维护状态")]
        [ExcelColumnName("维护状态")]
        public string Pstat { get; set; }

        [Required(ErrorMessage = "在客户级标记要删除的物料不能为空")]
        [ExcelColumn(Name = "在客户级标记要删除的物料")]
        [ExcelColumnName("在客户级标记要删除的物料")]
        public string Lvorm { get; set; }

        [Required(ErrorMessage = "物料类型不能为空")]
        [ExcelColumn(Name = "物料类型")]
        [ExcelColumnName("物料类型")]
        public string Mtart { get; set; }

        [Required(ErrorMessage = "行业领域不能为空")]
        [ExcelColumn(Name = "行业领域")]
        [ExcelColumnName("行业领域")]
        public string Mbrsh { get; set; }

        [Required(ErrorMessage = "物料组不能为空")]
        [ExcelColumn(Name = "物料组")]
        [ExcelColumnName("物料组")]
        public string Matkl { get; set; }

        [ExcelColumn(Name = "旧物料号")]
        [ExcelColumnName("旧物料号")]
        public string Bismt { get; set; }

        [Required(ErrorMessage = "基本计量单位不能为空")]
        [ExcelColumn(Name = "基本计量单位")]
        [ExcelColumnName("基本计量单位")]
        public string Meins { get; set; }

        [ExcelColumn(Name = "采购订单的计量单位")]
        [ExcelColumnName("采购订单的计量单位")]
        public string Bstme { get; set; }

        [ExcelColumn(Name = "文档号码(无文档管理系统)")]
        [ExcelColumnName("文档号码(无文档管理系统)")]
        public string Zeinr { get; set; }

        [ExcelColumn(Name = "凭证类型(无凭证管理系统)")]
        [ExcelColumnName("凭证类型(无凭证管理系统)")]
        public string Zeiar { get; set; }

        [ExcelColumn(Name = "文档版本（无文档管理系统）")]
        [ExcelColumnName("文档版本（无文档管理系统）")]
        public string Zeivr { get; set; }

        [ExcelColumn(Name = "文件的页面大小（不包括文件管理系统）")]
        [ExcelColumnName("文件的页面大小（不包括文件管理系统）")]
        public string Zeifo { get; set; }

        [ExcelColumn(Name = "文档变更号(无文档管理系统)")]
        [ExcelColumnName("文档变更号(无文档管理系统)")]
        public string Aeszn { get; set; }

        [ExcelColumn(Name = "凭证的页号(不带凭证管理系统)")]
        [ExcelColumnName("凭证的页号(不带凭证管理系统)")]
        public string Blatt { get; set; }

        [ExcelColumn(Name = "页数(没有凭证管理系统)")]
        [ExcelColumnName("页数(没有凭证管理系统)")]
        public int? Blanz { get; set; }

        [ExcelColumn(Name = "生产/检验备忘录")]
        [ExcelColumnName("生产/检验备忘录")]
        public string Ferth { get; set; }

        [ExcelColumn(Name = "生产备忘录的页格式")]
        [ExcelColumnName("生产备忘录的页格式")]
        public string Formt { get; set; }

        [ExcelColumn(Name = "大小/量纲")]
        [ExcelColumnName("大小/量纲")]
        public string Groes { get; set; }

        [ExcelColumn(Name = "基本物料")]
        [ExcelColumnName("基本物料")]
        public string Wrkst { get; set; }

        [ExcelColumn(Name = "行业标准描述（例如 ANSI 或 ISO）")]
        [ExcelColumnName("行业标准描述（例如 ANSI 或 ISO）")]
        public string Normt { get; set; }

        [ExcelColumn(Name = "实验室/设计室")]
        [ExcelColumnName("实验室/设计室")]
        public string Labor { get; set; }

        [ExcelColumn(Name = "采购价值代码")]
        [ExcelColumnName("采购价值代码")]
        public string Ekwsl { get; set; }

        [ExcelColumn(Name = "毛重")]
        [ExcelColumnName("毛重")]
        public decimal Brgew { get; set; }

        [ExcelColumn(Name = "净重")]
        [ExcelColumnName("净重")]
        public decimal Ntgew { get; set; }

        [Required(ErrorMessage = "重量单位不能为空")]
        [ExcelColumn(Name = "重量单位")]
        [ExcelColumnName("重量单位")]
        public string Gewei { get; set; }

        [ExcelColumn(Name = "业务量")]
        [ExcelColumnName("业务量")]
        public decimal Volum { get; set; }

        [Required(ErrorMessage = "体积单位不能为空")]
        [ExcelColumn(Name = "体积单位")]
        [ExcelColumnName("体积单位")]
        public string Voleh { get; set; }

        [ExcelColumn(Name = "容器需求")]
        [ExcelColumnName("容器需求")]
        public string Behvo { get; set; }

        [ExcelColumn(Name = "存储条件")]
        [ExcelColumnName("存储条件")]
        public string Raube { get; set; }

        [ExcelColumn(Name = "温度条件标识")]
        [ExcelColumnName("温度条件标识")]
        public string Tempb { get; set; }

        [ExcelColumn(Name = "低层代码")]
        [ExcelColumnName("低层代码")]
        public string Disst { get; set; }

        [ExcelColumn(Name = "运输组")]
        [ExcelColumnName("运输组")]
        public string Tragr { get; set; }

        [ExcelColumn(Name = "危险物料号")]
        [ExcelColumnName("危险物料号")]
        public string Stoff { get; set; }

        [ExcelColumn(Name = "产品组")]
        [ExcelColumnName("产品组")]
        public string Spart { get; set; }

        [ExcelColumn(Name = "竞争者")]
        [ExcelColumnName("竞争者")]
        public string Kunnr { get; set; }

        [ExcelColumn(Name = "欧洲物品号 (EAN) - 已过时的 !!!!!")]
        [ExcelColumnName("欧洲物品号 (EAN) - 已过时的 !!!!!")]
        public string Eannr { get; set; }

        [ExcelColumn(Name = "数量: 待打印的 GR/GI 单数量")]
        [ExcelColumnName("数量: 待打印的 GR/GI 单数量")]
        public decimal Wesch { get; set; }

        [ExcelColumn(Name = "采购规则")]
        [ExcelColumnName("采购规则")]
        public string Bwvor { get; set; }

        [ExcelColumn(Name = "货源")]
        [ExcelColumnName("货源")]
        public string Bwscl { get; set; }

        [ExcelColumn(Name = "季节类别")]
        [ExcelColumnName("季节类别")]
        public string Saiso { get; set; }

        [ExcelColumn(Name = "标签类型")]
        [ExcelColumnName("标签类型")]
        public string Etiar { get; set; }

        [ExcelColumn(Name = "标签格式")]
        [ExcelColumnName("标签格式")]
        public string Etifo { get; set; }

        [ExcelColumn(Name = "取消激活的")]
        [ExcelColumnName("取消激活的")]
        public string Entar { get; set; }

        [ExcelColumn(Name = "国际文件号(EAN/UPC)")]
        [ExcelColumnName("国际文件号(EAN/UPC)")]
        public string Ean11 { get; set; }

        [ExcelColumn(Name = "国际商品编码的类别 (EAN)")]
        [ExcelColumnName("国际商品编码的类别 (EAN)")]
        public string Numtp { get; set; }

        [ExcelColumn(Name = "长度")]
        [ExcelColumnName("长度")]
        public decimal Laeng { get; set; }

        [ExcelColumn(Name = "宽度")]
        [ExcelColumnName("宽度")]
        public decimal Breit { get; set; }

        [ExcelColumn(Name = "高度")]
        [ExcelColumnName("高度")]
        public decimal Hoehe { get; set; }

        [ExcelColumn(Name = "长度/宽度/高度的尺寸单位")]
        [ExcelColumnName("长度/宽度/高度的尺寸单位")]
        public string Meabm { get; set; }

        [ExcelColumn(Name = "产品层次")]
        [ExcelColumnName("产品层次")]
        public string Prdha { get; set; }

        [ExcelColumn(Name = "库存转移净改变成本核算")]
        [ExcelColumnName("库存转移净改变成本核算")]
        public string Aeklk { get; set; }

        [ExcelColumn(Name = "CAD 标识")]
        [ExcelColumnName("CAD 标识")]
        public string Cadkz { get; set; }

        [ExcelColumn(Name = "激活采购中的 QM")]
        [ExcelColumnName("激活采购中的 QM")]
        public string Qmpur { get; set; }

        [ExcelColumn(Name = "允许的包装重量")]
        [ExcelColumnName("允许的包装重量")]
        public decimal Ergew { get; set; }

        [ExcelColumn(Name = "加权的单位(允许打包加权)")]
        [ExcelColumnName("加权的单位(允许打包加权)")]
        public string Ergei { get; set; }

        [ExcelColumn(Name = "允许的包装体积")]
        [ExcelColumnName("允许的包装体积")]
        public decimal Ervol { get; set; }

        [ExcelColumn(Name = "体积单位(允许打包体积)")]
        [ExcelColumnName("体积单位(允许打包体积)")]
        public string Ervoe { get; set; }

        [ExcelColumn(Name = "处理单位的超重量容差")]
        [ExcelColumnName("处理单位的超重量容差")]
        public decimal Gewto { get; set; }

        [ExcelColumn(Name = "处理单位的超量冗差")]
        [ExcelColumnName("处理单位的超量冗差")]
        public decimal Volto { get; set; }

        [ExcelColumn(Name = "可变采购订单单位活动")]
        [ExcelColumnName("可变采购订单单位活动")]
        public string Vabme { get; set; }

        [ExcelColumn(Name = "标识: 修改水平已分配到物料")]
        [ExcelColumnName("标识: 修改水平已分配到物料")]
        public string Kzrev { get; set; }

        [ExcelColumn(Name = "可配置的物料")]
        [ExcelColumnName("可配置的物料")]
        public string Kzkfg { get; set; }

        [ExcelColumn(Name = "批次管理需求的标识")]
        [ExcelColumnName("批次管理需求的标识")]
        public string Xchpf { get; set; }

        [ExcelColumn(Name = "包装物料类型")]
        [ExcelColumnName("包装物料类型")]
        public string Vhart { get; set; }

        [ExcelColumn(Name = "最大层次 (按体积)")]
        [ExcelColumnName("最大层次 (按体积)")]
        public decimal Fuelg { get; set; }

        [ExcelColumn(Name = "堆栈因子")]
        [ExcelColumnName("堆栈因子")]
        public int? Stfak { get; set; }

        [ExcelColumn(Name = "物料组: 包装物料")]
        [ExcelColumnName("物料组: 包装物料")]
        public string Magrv { get; set; }

        [ExcelColumn(Name = "权限组")]
        [ExcelColumnName("权限组")]
        public string Begru { get; set; }

        [ExcelColumn(Name = "开始生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("开始生效日期")]
        public DateTime? Datab { get; set; }

        [ExcelColumn(Name = "删除日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("删除日期")]
        public DateTime? Liqdt { get; set; }

        [ExcelColumn(Name = "季度年")]
        [ExcelColumnName("季度年")]
        public string Saisj { get; set; }

        [ExcelColumn(Name = "价格标记类别")]
        [ExcelColumnName("价格标记类别")]
        public string Plgtp { get; set; }

        [ExcelColumn(Name = "空白物料清单")]
        [ExcelColumnName("空白物料清单")]
        public string Mlgut { get; set; }

        [ExcelColumn(Name = "外部物料组")]
        [ExcelColumnName("外部物料组")]
        public string Extwg { get; set; }

        [ExcelColumn(Name = "一般可配置物料")]
        [ExcelColumnName("一般可配置物料")]
        public string Satnr { get; set; }

        [ExcelColumn(Name = "物料类别")]
        [ExcelColumnName("物料类别")]
        public string Attyp { get; set; }

        [ExcelColumn(Name = "指示符 : 物料是联产品")]
        [ExcelColumnName("指示符 : 物料是联产品")]
        public string Kzkup { get; set; }

        [ExcelColumn(Name = "标记：物料有一后续物料")]
        [ExcelColumnName("标记：物料有一后续物料")]
        public string Kznfm { get; set; }

        [ExcelColumn(Name = "定价参考物料")]
        [ExcelColumnName("定价参考物料")]
        public string Pmata { get; set; }

        [Required(ErrorMessage = "跨工厂物料状态不能为空")]
        [ExcelColumn(Name = "跨工厂物料状态")]
        [ExcelColumnName("跨工厂物料状态")]
        public string Mstae { get; set; }

        [ExcelColumn(Name = "跨分销链物料状态")]
        [ExcelColumnName("跨分销链物料状态")]
        public string Mstav { get; set; }

        [ExcelColumn(Name = "从跨工厂物料状态有效起的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("从跨工厂物料状态有效起的日期")]
        public DateTime? Mstde { get; set; }

        [ExcelColumn(Name = "从跨分销链物料状态有效起的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("从跨分销链物料状态有效起的日期")]
        public DateTime? Mstdv { get; set; }

        [ExcelColumn(Name = "物料从税收分类")]
        [ExcelColumnName("物料从税收分类")]
        public string Taklv { get; set; }

        [ExcelColumn(Name = "类别参数文件")]
        [ExcelColumnName("类别参数文件")]
        public string Rbnrm { get; set; }

        [ExcelColumn(Name = "最短剩余货架寿命")]
        [ExcelColumnName("最短剩余货架寿命")]
        public decimal Mhdrz { get; set; }

        [ExcelColumn(Name = "总货架寿命")]
        [ExcelColumnName("总货架寿命")]
        public decimal Mhdhb { get; set; }

        [ExcelColumn(Name = "仓储百分比")]
        [ExcelColumnName("仓储百分比")]
        public decimal Mhdlp { get; set; }

        [ExcelColumn(Name = "内容单位")]
        [ExcelColumnName("内容单位")]
        public string Inhme { get; set; }

        [ExcelColumn(Name = "净内容")]
        [ExcelColumnName("净内容")]
        public decimal Inhal { get; set; }

        [ExcelColumn(Name = "比较价格单位")]
        [ExcelColumnName("比较价格单位")]
        public decimal Vpreh { get; set; }

        [ExcelColumn(Name = "IS-R 标签：物料组（在 4.0 中不活动）")]
        [ExcelColumnName("IS-R 标签：物料组（在 4.0 中不活动）")]
        public string Etiag { get; set; }

        [ExcelColumn(Name = "毛内容")]
        [ExcelColumnName("毛内容")]
        public decimal Inhbr { get; set; }

        [ExcelColumn(Name = "数量转换方法")]
        [ExcelColumnName("数量转换方法")]
        public string Cmeth { get; set; }

        [ExcelColumn(Name = "内部对象号")]
        [ExcelColumnName("内部对象号")]
        public int? Cuobf { get; set; }

        [ExcelColumn(Name = "环境相关")]
        [ExcelColumnName("环境相关")]
        public string Kzumw { get; set; }

        [ExcelColumn(Name = "产品分配确定程序")]
        [ExcelColumnName("产品分配确定程序")]
        public string Kosch { get; set; }

        [ExcelColumn(Name = "变式的定价参数文件")]
        [ExcelColumnName("变式的定价参数文件")]
        public string Sprof { get; set; }

        [ExcelColumn(Name = "针对物料的折扣类型")]
        [ExcelColumnName("针对物料的折扣类型")]
        public string Nrfhg { get; set; }

        [ExcelColumn(Name = "制造商零件编号")]
        [ExcelColumnName("制造商零件编号")]
        public string Mfrpn { get; set; }

        [ExcelColumn(Name = "制造商编号")]
        [ExcelColumnName("制造商编号")]
        public string Mfrnr { get; set; }

        [ExcelColumn(Name = "公司自己 (内部) 的盘点管理物料编号")]
        [ExcelColumnName("公司自己 (内部) 的盘点管理物料编号")]
        public string Bmatn { get; set; }

        [ExcelColumn(Name = "制造商部件参数文件")]
        [ExcelColumnName("制造商部件参数文件")]
        public string Mprof { get; set; }

        [ExcelColumn(Name = "计量单位使用")]
        [ExcelColumnName("计量单位使用")]
        public string Kzwsm { get; set; }

        [ExcelColumn(Name = "在季节内展开")]
        [ExcelColumnName("在季节内展开")]
        public string Saity { get; set; }

        [ExcelColumn(Name = "危险货物标识参数文件")]
        [ExcelColumnName("危险货物标识参数文件")]
        public string Profl { get; set; }

        [ExcelColumn(Name = "标识符:高粘性的")]
        [ExcelColumnName("标识符:高粘性的")]
        public string Ihivi { get; set; }

        [ExcelColumn(Name = "标识符:固体/液体")]
        [ExcelColumnName("标识符:固体/液体")]
        public string Iloos { get; set; }

        [ExcelColumn(Name = "序列号的清晰的级别")]
        [ExcelColumnName("序列号的清晰的级别")]
        public string Serlv { get; set; }

        [ExcelColumn(Name = "包装物料是密闭包装的")]
        [ExcelColumnName("包装物料是密闭包装的")]
        public string Kzgvh { get; set; }

        [ExcelColumn(Name = "指示符：需要批准的批量记录")]
        [ExcelColumnName("指示符：需要批准的批量记录")]
        public string Xgchp { get; set; }

        [ExcelColumn(Name = "指定有效参数值/覆盖更改编号")]
        [ExcelColumnName("指定有效参数值/覆盖更改编号")]
        public string Kzeff { get; set; }

        [ExcelColumn(Name = "物料完成的水平")]
        [ExcelColumnName("物料完成的水平")]
        public int? Compl { get; set; }

        [ExcelColumn(Name = "货架寿命到期日的期间标识")]
        [ExcelColumnName("货架寿命到期日的期间标识")]
        public string Iprkz { get; set; }

        [ExcelColumn(Name = "货架寿命到期日期计算舍入规则")]
        [ExcelColumnName("货架寿命到期日期计算舍入规则")]
        public string Rdmhd { get; set; }

        [ExcelColumn(Name = "标识：印刷在包装上的产品成份")]
        [ExcelColumnName("标识：印刷在包装上的产品成份")]
        public string Przus { get; set; }

        [ExcelColumn(Name = "普通项目类别组")]
        [ExcelColumnName("普通项目类别组")]
        public string Mtposmara { get; set; }

        [ExcelColumn(Name = "含后勤变量的一般物料")]
        [ExcelColumnName("含后勤变量的一般物料")]
        public string Bflme { get; set; }

        [ExcelColumn(Name = "物料被锁定")]
        [ExcelColumnName("物料被锁定")]
        public string Matfi { get; set; }

        [ExcelColumn(Name = "与配置管理相关")]
        [ExcelColumnName("与配置管理相关")]
        public string Cmrel { get; set; }

        [ExcelColumn(Name = "分类清单类型")]
        [ExcelColumnName("分类清单类型")]
        public string Bbtyp { get; set; }

        [ExcelColumn(Name = "过期日期")]
        [ExcelColumnName("过期日期")]
        public string Sledbbd { get; set; }

        [ExcelColumn(Name = "全球贸易项目编号变式")]
        [ExcelColumnName("全球贸易项目编号变式")]
        public string Gtinvariant { get; set; }

        [ExcelColumn(Name = "在预包装物料中的一般物料的物料编号")]
        [ExcelColumnName("在预包装物料中的一般物料的物料编号")]
        public string Gennr { get; set; }

        [ExcelColumn(Name = "以相同方式包装的物料的参考物料")]
        [ExcelColumnName("以相同方式包装的物料的参考物料")]
        public string Rmatp { get; set; }

        [ExcelColumn(Name = "标识：全局数据同步相关")]
        [ExcelColumnName("标识：全局数据同步相关")]
        public string Gdsrelevant { get; set; }

        [ExcelColumn(Name = "原始接受")]
        [ExcelColumnName("原始接受")]
        public string Weora { get; set; }

        [ExcelColumn(Name = "标准处理单位类型")]
        [ExcelColumnName("标准处理单位类型")]
        public string Hutypdflt { get; set; }

        [ExcelColumn(Name = "可偷窃的")]
        [ExcelColumnName("可偷窃的")]
        public string Pilferable { get; set; }

        [ExcelColumn(Name = "仓库存储条件")]
        [ExcelColumnName("仓库存储条件")]
        public string Whstc { get; set; }

        [ExcelColumn(Name = "仓库物料组")]
        [ExcelColumnName("仓库物料组")]
        public string Whmatgr { get; set; }

        [ExcelColumn(Name = "处理标识")]
        [ExcelColumnName("处理标识")]
        public string Hndlcode { get; set; }

        [ExcelColumn(Name = "与危险物料相关")]
        [ExcelColumnName("与危险物料相关")]
        public string Hazmat { get; set; }

        [ExcelColumn(Name = "处理单位类型")]
        [ExcelColumnName("处理单位类型")]
        public string Hutyp { get; set; }

        [ExcelColumn(Name = "可变皮重")]
        [ExcelColumnName("可变皮重")]
        public string Tarevar { get; set; }

        [ExcelColumn(Name = "包装物料的最大允许容量")]
        [ExcelColumnName("包装物料的最大允许容量")]
        public decimal Maxc { get; set; }

        [ExcelColumn(Name = "处理单位的最大容量容差")]
        [ExcelColumnName("处理单位的最大容量容差")]
        public decimal Maxctol { get; set; }

        [ExcelColumn(Name = "包装物料的最大包长度")]
        [ExcelColumnName("包装物料的最大包长度")]
        public decimal Maxl { get; set; }

        [ExcelColumn(Name = "包装物料的最大包宽度")]
        [ExcelColumnName("包装物料的最大包宽度")]
        public decimal Maxb { get; set; }

        [ExcelColumn(Name = "包装物料的最大包高度")]
        [ExcelColumnName("包装物料的最大包高度")]
        public decimal Maxh { get; set; }

        [ExcelColumn(Name = "最大包装长/宽/高的计量单位")]
        [ExcelColumnName("最大包装长/宽/高的计量单位")]
        public string Maxdimuom { get; set; }

        [ExcelColumn(Name = "物料原产地国家")]
        [ExcelColumnName("物料原产地国家")]
        public string Herkl { get; set; }

        [ExcelColumn(Name = "物料运输组")]
        [ExcelColumnName("物料运输组")]
        public string Mfrgr { get; set; }

        [ExcelColumn(Name = "隔离期间")]
        [ExcelColumnName("隔离期间")]
        public decimal Qqtime { get; set; }

        [ExcelColumn(Name = "隔离期间的时间单位")]
        [ExcelColumnName("隔离期间的时间单位")]
        public string Qqtimeuom { get; set; }

        [ExcelColumn(Name = "质量检查组")]
        [ExcelColumnName("质量检查组")]
        public string Qgrp { get; set; }

        [ExcelColumn(Name = "序列号参数文件")]
        [ExcelColumnName("序列号参数文件")]
        public string Serial { get; set; }

        [ExcelColumn(Name = "表格名")]
        [ExcelColumnName("表格名")]
        public string Pssmartform { get; set; }

        [ExcelColumn(Name = "EWM CW: 后勤计量单位")]
        [ExcelColumnName("EWM CW: 后勤计量单位")]
        public string Logunit { get; set; }

        [ExcelColumn(Name = "EWM CW: 物料是称重物料")]
        [ExcelColumnName("EWM CW: 物料是称重物料")]
        public string Cwqrel { get; set; }

        [ExcelColumn(Name = "EWM CW: 输入 CW 数量的称重参数文件")]
        [ExcelColumnName("EWM CW: 输入 CW 数量的称重参数文件")]
        public string Cwqproc { get; set; }

        [ExcelColumn(Name = "EWM-CW: EWM 的称重容差组")]
        [ExcelColumnName("EWM-CW: EWM 的称重容差组")]
        public string Cwqtolgr { get; set; }

        [ExcelColumn(Name = "调整参数文件")]
        [ExcelColumnName("调整参数文件")]
        public string Adprof { get; set; }

        [ExcelColumn(Name = "知识产权标识（CRM 产品）")]
        [ExcelColumnName("知识产权标识（CRM 产品）")]
        public string Ipmipproduct { get; set; }

        [ExcelColumn(Name = "允许的变式价格（针对物料主数据）")]
        [ExcelColumnName("允许的变式价格（针对物料主数据）")]
        public string Allowpmatigno { get; set; }

        [ExcelColumn(Name = "中间")]
        [ExcelColumnName("中间")]
        public string Medium { get; set; }

        [ExcelColumn(Name = "实物商品")]
        [ExcelColumnName("实物商品")]
        public string Commodity { get; set; }

        [ExcelColumn(Name = "标识：包含动物源的非纺织部分")]
        [ExcelColumnName("标识：包含动物源的非纺织部分")]
        public string Animalorigin { get; set; }

        [ExcelColumn(Name = "标识：新纺织组分功能")]
        [ExcelColumnName("标识：新纺织组分功能")]
        public string Textilecompind { get; set; }

        [ExcelColumn(Name = "分段结构")]
        [ExcelColumnName("分段结构")]
        public string Sgtcsgr { get; set; }

        [ExcelColumn(Name = "分段策略")]
        [ExcelColumnName("分段策略")]
        public string Sgtcovsa { get; set; }

        [ExcelColumn(Name = "分段物料主数据状态")]
        [ExcelColumnName("分段物料主数据状态")]
        public string Sgtstat { get; set; }

        [ExcelColumn(Name = "分段策略范围")]
        [ExcelColumnName("分段策略范围")]
        public string Sgtscope { get; set; }

        [ExcelColumn(Name = "分段相关")]
        [ExcelColumnName("分段相关")]
        public string Sgtrel { get; set; }

        [ExcelColumn(Name = "ANP Code")]
        [ExcelColumnName("ANP Code")]
        public int? Anp { get; set; }

        [ExcelColumn(Name = "Fashion 信息字段：1")]
        [ExcelColumnName("Fashion 信息字段：1")]
        public string Fshmgat1 { get; set; }

        [ExcelColumn(Name = "Fashion 信息字段：2")]
        [ExcelColumnName("Fashion 信息字段：2")]
        public string Fshmgat2 { get; set; }

        [ExcelColumn(Name = "Fashion 信息字段：3")]
        [ExcelColumnName("Fashion 信息字段：3")]
        public string Fshmgat3 { get; set; }

        [ExcelColumn(Name = "标识：季节使用")]
        [ExcelColumnName("标识：季节使用")]
        public string Fshsealv { get; set; }

        [ExcelColumn(Name = "标识：在库存管理中激活季节")]
        [ExcelColumnName("标识：在库存管理中激活季节")]
        public string Fshseaim { get; set; }

        [ExcelColumn(Name = "特征值转换的物料转换标识")]
        [ExcelColumnName("特征值转换的物料转换标识")]
        public string Fshscmid { get; set; }

        [ExcelColumn(Name = "装载单位")]
        [ExcelColumnName("装载单位")]
        public int? Bev1luleinh { get; set; }

        [ExcelColumn(Name = "装载单位组：IS 饮料")]
        [ExcelColumnName("装载单位组：IS 饮料")]
        public string Bev1luldegrp { get; set; }

        [ExcelColumn(Name = "物料关系的结构类别")]
        [ExcelColumnName("物料关系的结构类别")]
        public string Bev1nestruccat { get; set; }

        [ExcelColumn(Name = "容差类型标识")]
        [ExcelColumnName("容差类型标识")]
        public string Dsdsltoltyp { get; set; }

        [ExcelColumn(Name = "计算组")]
        [ExcelColumnName("计算组")]
        public string Dsdsvcntgrp { get; set; }

        [ExcelColumn(Name = "DSD 分组")]
        [ExcelColumnName("DSD 分组")]
        public string Dsdvcgroup { get; set; }

        [ExcelColumn(Name = "可以倾斜物料 (车辆空间优化)")]
        [ExcelColumnName("可以倾斜物料 (车辆空间优化)")]
        public string Vsortiltind { get; set; }

        [ExcelColumn(Name = "不允许堆栈 (VSO)")]
        [ExcelColumnName("不允许堆栈 (VSO)")]
        public string Vsorstackind { get; set; }

        [ExcelColumn(Name = "底层 (车辆空间最优化)")]
        [ExcelColumnName("底层 (车辆空间最优化)")]
        public string Vsorbotind { get; set; }

        [ExcelColumn(Name = "顶层 (VSO)")]
        [ExcelColumnName("顶层 (VSO)")]
        public string Vsortopind { get; set; }

        [ExcelColumn(Name = "堆栈因子 (车辆空间优化)")]
        [ExcelColumnName("堆栈因子 (车辆空间优化)")]
        public int? Vsorstackno { get; set; }

        [ExcelColumn(Name = "无包装物料的装载 (VSO)")]
        [ExcelColumnName("无包装物料的装载 (VSO)")]
        public string Vsorpalind { get; set; }

        [ExcelColumn(Name = "包装物料的允许悬挂深度 (VSO)")]
        [ExcelColumnName("包装物料的允许悬挂深度 (VSO)")]
        public decimal Vsorpalovrd { get; set; }

        [ExcelColumn(Name = "装运物料的允许悬挂宽度 (VSO)")]
        [ExcelColumnName("装运物料的允许悬挂宽度 (VSO)")]
        public decimal Vsorpalovrw { get; set; }

        [ExcelColumn(Name = "包装物料的最大叠放高度 (VSO)")]
        [ExcelColumnName("包装物料的最大叠放高度 (VSO)")]
        public decimal Vsorpalbht { get; set; }

        [ExcelColumn(Name = "包装物料的最小叠放高度 (VSO)")]
        [ExcelColumnName("包装物料的最小叠放高度 (VSO)")]
        public decimal Vsorpalminh { get; set; }

        [ExcelColumn(Name = "超出最大叠放高度的容差 (VSO)")]
        [ExcelColumnName("超出最大叠放高度的容差 (VSO)")]
        public decimal Vsortolbht { get; set; }

        [ExcelColumn(Name = "每个已结清 PKM 的物料编号(VSO)")]
        [ExcelColumnName("每个已结清 PKM 的物料编号(VSO)")]
        public int? Vsornopgvh { get; set; }

        [ExcelColumn(Name = "计量单位车辆空间优化")]
        [ExcelColumnName("计量单位车辆空间优化")]
        public string Vsorquanunit { get; set; }

        [ExcelColumn(Name = "请求的已清包装物料 (VSO)")]
        [ExcelColumnName("请求的已清包装物料 (VSO)")]
        public string Vsorkzgvhind { get; set; }

        [ExcelColumn(Name = "Packaging Code")]
        [ExcelColumnName("Packaging Code")]
        public string Packcode { get; set; }

        [ExcelColumn(Name = "危险品的包装状态")]
        [ExcelColumnName("危险品的包装状态")]
        public string Dgpackstatus { get; set; }

        [ExcelColumn(Name = "物料条件管理")]
        [ExcelColumnName("物料条件管理")]
        public string Mcond { get; set; }

        [ExcelColumn(Name = "返回代码")]
        [ExcelColumnName("返回代码")]
        public string Retdelc { get; set; }

        [ExcelColumn(Name = "后勤等级退货")]
        [ExcelColumnName("后勤等级退货")]
        public string Loglevreto { get; set; }

        [ExcelColumn(Name = "NATO 项目标识编号")]
        [ExcelColumnName("NATO 项目标识编号")]
        public string Nsnid { get; set; }

        [ExcelColumn(Name = "完全互换组")]
        [ExcelColumnName("完全互换组")]
        public string Imatn { get; set; }

        [ExcelColumn(Name = "替换链编号")]
        [ExcelColumnName("替换链编号")]
        public string Picnum { get; set; }

        [ExcelColumn(Name = "创建状态 - 季节性采购")]
        [ExcelColumnName("创建状态 - 季节性采购")]
        public string Bstat { get; set; }

        [ExcelColumn(Name = "颜色特性的内部特性编号")]
        [ExcelColumnName("颜色特性的内部特性编号")]
        public int? Coloratinn { get; set; }

        [ExcelColumn(Name = "主尺寸的特性的内部特性编号")]
        [ExcelColumnName("主尺寸的特性的内部特性编号")]
        public int? Size1atinn { get; set; }

        [ExcelColumn(Name = "次尺寸的特性的内部特性编号")]
        [ExcelColumnName("次尺寸的特性的内部特性编号")]
        public int? Size2atinn { get; set; }

        [ExcelColumn(Name = "变式颜色的特性值")]
        [ExcelColumnName("变式颜色的特性值")]
        public string Color { get; set; }

        [ExcelColumn(Name = "变式主尺寸的特性值")]
        [ExcelColumnName("变式主尺寸的特性值")]
        public string Size1 { get; set; }

        [ExcelColumn(Name = "变式的次尺寸的特性值")]
        [ExcelColumnName("变式的次尺寸的特性值")]
        public string Size2 { get; set; }

        [ExcelColumn(Name = "评估目的的特性值")]
        [ExcelColumnName("评估目的的特性值")]
        public string Freechar { get; set; }

        [ExcelColumn(Name = "护理代码（例如洗涤代码, 烫平衣服代码, 等等)")]
        [ExcelColumnName("护理代码（例如洗涤代码, 烫平衣服代码, 等等)")]
        public string Carecode { get; set; }

        [ExcelColumn(Name = "商标")]
        [ExcelColumnName("商标")]
        public string Brandid { get; set; }

        [ExcelColumn(Name = "纺织品的光纤代码（组件1）")]
        [ExcelColumnName("纺织品的光纤代码（组件1）")]
        public string Fibercode1 { get; set; }

        [ExcelColumn(Name = "光纤的百分比共享（组件1）")]
        [ExcelColumnName("光纤的百分比共享（组件1）")]
        public int? Fiberpart1 { get; set; }

        [ExcelColumn(Name = "纺织品的光纤代码（组件2）")]
        [ExcelColumnName("纺织品的光纤代码（组件2）")]
        public string Fibercode2 { get; set; }

        [ExcelColumn(Name = "光纤的百分比共享（组件2）")]
        [ExcelColumnName("光纤的百分比共享（组件2）")]
        public int? Fiberpart2 { get; set; }

        [ExcelColumn(Name = "纺织品的光纤代码（组件3）")]
        [ExcelColumnName("纺织品的光纤代码（组件3）")]
        public string Fibercode3 { get; set; }

        [ExcelColumn(Name = "光纤的百分比共享（组件3）")]
        [ExcelColumnName("光纤的百分比共享（组件3）")]
        public int? Fiberpart3 { get; set; }

        [ExcelColumn(Name = "纺织品的光纤代码（组件4）")]
        [ExcelColumnName("纺织品的光纤代码（组件4）")]
        public string Fibercode4 { get; set; }

        [ExcelColumn(Name = "光纤的百分比共享（组件4）")]
        [ExcelColumnName("光纤的百分比共享（组件4）")]
        public int? Fiberpart4 { get; set; }

        [ExcelColumn(Name = "纺织品的光纤代码（组件5）")]
        [ExcelColumnName("纺织品的光纤代码（组件5）")]
        public string Fibercode5 { get; set; }

        [ExcelColumn(Name = "光纤的百分比共享（组件5）")]
        [ExcelColumnName("光纤的百分比共享（组件5）")]
        public int? Fiberpart5 { get; set; }

        [ExcelColumn(Name = "时装等级")]
        [ExcelColumnName("时装等级")]
        public string Fashgrd { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "在客户级标记要删除的物料")]
        public string LvormLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "物料类型")]
        public string MtartLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "行业领域")]
        public string MbrshLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "物料组")]
        public string MatklLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "基本计量单位")]
        public string MeinsLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "跨工厂物料状态")]
        public string MstaeLabel { get; set; }
    }
}