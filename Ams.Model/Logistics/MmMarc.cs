namespace Ams.Model.Logistics
{
    /// <summary>
    /// 工厂物料
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:45:06
    /// </summary>
    [SugarTable("mm_marc", "工厂物料")]
    public class MmMarc : SysBase
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
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Werks", ColumnDescription = "工厂 ", Length = 8)]
        public string Werks { get; set; }

        /// <summary>
        /// 维护状态
        /// </summary>
        [SugarColumn(ColumnName = "Pstat", ColumnDescription = "维护状态 ", Length = 30)]
        public string Pstat { get; set; }

        /// <summary>
        /// 在工厂级标记要删除的物料
        /// </summary>
        [SugarColumn(ColumnName = "Lvorm", ColumnDescription = "在工厂级标记要删除的物料 ", Length = 2)]
        public string Lvorm { get; set; }

        /// <summary>
        /// 评估类别
        /// </summary>
        [SugarColumn(ColumnName = "Bwtty", ColumnDescription = "评估类别 ", Length = 2)]
        public string Bwtty { get; set; }

        /// <summary>
        /// 批量管理标识(内部)
        /// </summary>
        [SugarColumn(ColumnName = "Xchar", ColumnDescription = "批量管理标识(内部) ", Length = 2)]
        public string Xchar { get; set; }

        /// <summary>
        /// 工厂特定的物料状态
        /// </summary>
        [SugarColumn(ColumnName = "Mmsta", ColumnDescription = "工厂特定的物料状态 ", Length = 4)]
        public string Mmsta { get; set; }

        /// <summary>
        /// 工厂特定物料状态有效的起始日期
        /// </summary>
        public DateTime? Mmstd { get; set; }

        /// <summary>
        /// ABC标识
        /// </summary>
        [SugarColumn(ColumnName = "Maabc", ColumnDescription = "ABC标识 ", Length = 2)]
        public string Maabc { get; set; }

        /// <summary>
        /// 标志：关键部件
        /// </summary>
        [SugarColumn(ColumnName = "Kzkri", ColumnDescription = "标志：关键部件 ", Length = 2)]
        public string Kzkri { get; set; }

        /// <summary>
        /// 采购组
        /// </summary>
        [SugarColumn(ColumnName = "Ekgrp", ColumnDescription = "采购组 ", Length = 6)]
        public string Ekgrp { get; set; }

        /// <summary>
        /// 发货单位
        /// </summary>
        [SugarColumn(ColumnName = "Ausme", ColumnDescription = "发货单位 ", Length = 6)]
        public string Ausme { get; set; }

        /// <summary>
        /// 物料: MRP 参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Dispr", ColumnDescription = "物料: MRP 参数文件 ", Length = 8)]
        public string Dispr { get; set; }

        /// <summary>
        /// 物料需求计划类型
        /// </summary>
        [SugarColumn(ColumnName = "Dismm", ColumnDescription = "物料需求计划类型 ", Length = 4)]
        public string Dismm { get; set; }

        /// <summary>
        /// MRP 控制者（物料计划人）
        /// </summary>
        [SugarColumn(ColumnName = "Dispo", ColumnDescription = "MRP 控制者（物料计划人） ", Length = 6)]
        public string Dispo { get; set; }

        /// <summary>
        /// 标识: MRP控制者是买方(未激活的)
        /// </summary>
        [SugarColumn(ColumnName = "Kzdie", ColumnDescription = "标识: MRP控制者是买方(未激活的) ", Length = 2)]
        public string Kzdie { get; set; }

        /// <summary>
        /// 计划的天数内交货
        /// </summary>
        [SugarColumn(ColumnName = "Plifz", ColumnDescription = "计划的天数内交货 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Plifz { get; set; }

        /// <summary>
        /// 以天计的收货处理时间
        /// </summary>
        [SugarColumn(ColumnName = "Webaz", ColumnDescription = "以天计的收货处理时间 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Webaz { get; set; }

        /// <summary>
        /// 期间标识
        /// </summary>
        [SugarColumn(ColumnName = "Perkz", ColumnDescription = "期间标识 ", Length = 2)]
        public string Perkz { get; set; }

        /// <summary>
        /// 装配报废百分比
        /// </summary>
        [SugarColumn(ColumnName = "Ausss", ColumnDescription = "装配报废百分比 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Ausss { get; set; }

        /// <summary>
        /// 批量 (物料计划)
        /// </summary>
        [SugarColumn(ColumnName = "Disls", ColumnDescription = "批量 (物料计划) ", Length = 4)]
        public string Disls { get; set; }

        /// <summary>
        /// 采购类型
        /// </summary>
        [SugarColumn(ColumnName = "Beskz", ColumnDescription = "采购类型 ", Length = 2)]
        public string Beskz { get; set; }

        /// <summary>
        /// 特殊采购类型
        /// </summary>
        [SugarColumn(ColumnName = "Sobsl", ColumnDescription = "特殊采购类型 ", Length = 4)]
        public string Sobsl { get; set; }

        /// <summary>
        /// 再订货点
        /// </summary>
        [SugarColumn(ColumnName = "Minbe", ColumnDescription = "再订货点 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Minbe { get; set; }

        /// <summary>
        /// 安全库存
        /// </summary>
        [SugarColumn(ColumnName = "Eisbe", ColumnDescription = "安全库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Eisbe { get; set; }

        /// <summary>
        /// 最小批量
        /// </summary>
        [SugarColumn(ColumnName = "Bstmi", ColumnDescription = "最小批量 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Bstmi { get; set; }

        /// <summary>
        /// 最大批量大小
        /// </summary>
        [SugarColumn(ColumnName = "Bstma", ColumnDescription = "最大批量大小 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Bstma { get; set; }

        /// <summary>
        /// 固定批量大小
        /// </summary>
        [SugarColumn(ColumnName = "Bstfe", ColumnDescription = "固定批量大小 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Bstfe { get; set; }

        /// <summary>
        /// 采购订单数量的舍入值
        /// </summary>
        [SugarColumn(ColumnName = "Bstrf", ColumnDescription = "采购订单数量的舍入值 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Bstrf { get; set; }

        /// <summary>
        /// 最大库存水平
        /// </summary>
        [SugarColumn(ColumnName = "Mabst", ColumnDescription = "最大库存水平 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Mabst { get; set; }

        /// <summary>
        /// 订购成本
        /// </summary>
        [SugarColumn(ColumnName = "Losfx", ColumnDescription = "订购成本 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Losfx { get; set; }

        /// <summary>
        /// 对于独立和集中需求的相关需求标识
        /// </summary>
        [SugarColumn(ColumnName = "Sbdkz", ColumnDescription = "对于独立和集中需求的相关需求标识 ", Length = 2)]
        public string Sbdkz { get; set; }

        /// <summary>
        /// 库存成本标识
        /// </summary>
        [SugarColumn(ColumnName = "Lagpr", ColumnDescription = "库存成本标识 ", Length = 2)]
        public string Lagpr { get; set; }

        /// <summary>
        /// 选择可替换物料单的方法
        /// </summary>
        [SugarColumn(ColumnName = "Altsl", ColumnDescription = "选择可替换物料单的方法 ", Length = 2)]
        public string Altsl { get; set; }

        /// <summary>
        /// 中止指示符
        /// </summary>
        [SugarColumn(ColumnName = "Kzaus", ColumnDescription = "中止指示符 ", Length = 2)]
        public string Kzaus { get; set; }

        /// <summary>
        /// 中断日期
        /// </summary>
        public DateTime? Ausdt { get; set; }

        /// <summary>
        /// 后续物料
        /// </summary>
        [SugarColumn(ColumnName = "Nfmat", ColumnDescription = "后续物料 ", Length = 36)]
        public string Nfmat { get; set; }

        /// <summary>
        /// 需求分组指示符
        /// </summary>
        [SugarColumn(ColumnName = "Kzbed", ColumnDescription = "需求分组指示符 ", Length = 2)]
        public string Kzbed { get; set; }

        /// <summary>
        /// 综合MRP标识
        /// </summary>
        [SugarColumn(ColumnName = "Miskz", ColumnDescription = "综合MRP标识 ", Length = 2)]
        public string Miskz { get; set; }

        /// <summary>
        /// 浮动的计划边际码
        /// </summary>
        [SugarColumn(ColumnName = "Fhori", ColumnDescription = "浮动的计划边际码 ", Length = 6)]
        public string Fhori { get; set; }

        /// <summary>
        /// 标识: 计划订单的自动修正
        /// </summary>
        [SugarColumn(ColumnName = "Pfrei", ColumnDescription = "标识: 计划订单的自动修正 ", Length = 2)]
        public string Pfrei { get; set; }

        /// <summary>
        /// 用于生产订单的批准标识
        /// </summary>
        [SugarColumn(ColumnName = "Ffrei", ColumnDescription = "用于生产订单的批准标识 ", Length = 2)]
        public string Ffrei { get; set; }

        /// <summary>
        /// 标识：反冲
        /// </summary>
        [SugarColumn(ColumnName = "Rgekz", ColumnDescription = "标识：反冲 ", Length = 2)]
        public string Rgekz { get; set; }

        /// <summary>
        /// 生产管理员
        /// </summary>
        [SugarColumn(ColumnName = "Fevor", ColumnDescription = "生产管理员 ", Length = 6)]
        public string Fevor { get; set; }

        /// <summary>
        /// 处理时间
        /// </summary>
        [SugarColumn(ColumnName = "Bearz", ColumnDescription = "处理时间 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Bearz { get; set; }

        /// <summary>
        /// 建立和拆卸时间
        /// </summary>
        [SugarColumn(ColumnName = "Ruezt", ColumnDescription = "建立和拆卸时间 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Ruezt { get; set; }

        /// <summary>
        /// 工序间时间
        /// </summary>
        [SugarColumn(ColumnName = "Tranz", ColumnDescription = "工序间时间 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Tranz { get; set; }

        /// <summary>
        /// 基准数量
        /// </summary>
        [SugarColumn(ColumnName = "Basmg", ColumnDescription = "基准数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Basmg { get; set; }

        /// <summary>
        /// 厂内生产时间
        /// </summary>
        [SugarColumn(ColumnName = "Dzeit", ColumnDescription = "厂内生产时间 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Dzeit { get; set; }

        /// <summary>
        /// 最大存储期间
        /// </summary>
        [SugarColumn(ColumnName = "Maxlz", ColumnDescription = "最大存储期间 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Maxlz { get; set; }

        /// <summary>
        /// 最大库存期间单位
        /// </summary>
        [SugarColumn(ColumnName = "Lzeih", ColumnDescription = "最大库存期间单位 ", Length = 6)]
        public string Lzeih { get; set; }

        /// <summary>
        /// 标识: 从生产区的库存提取
        /// </summary>
        [SugarColumn(ColumnName = "Kzpro", ColumnDescription = "标识: 从生产区的库存提取 ", Length = 2)]
        public string Kzpro { get; set; }

        /// <summary>
        /// 标识: 在初步计划中包括的物料
        /// </summary>
        [SugarColumn(ColumnName = "Gpmkz", ColumnDescription = "标识: 在初步计划中包括的物料 ", Length = 2)]
        public string Gpmkz { get; set; }

        /// <summary>
        /// 超量交货容差限制
        /// </summary>
        [SugarColumn(ColumnName = "Ueeto", ColumnDescription = "超量交货容差限制 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Ueeto { get; set; }

        /// <summary>
        /// 标识：允许未限制的过量交货
        /// </summary>
        [SugarColumn(ColumnName = "Ueetk", ColumnDescription = "标识：允许未限制的过量交货 ", Length = 2)]
        public string Ueetk { get; set; }

        /// <summary>
        /// 不足交货容差限制
        /// </summary>
        [SugarColumn(ColumnName = "Uneto", ColumnDescription = "不足交货容差限制 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Uneto { get; set; }

        /// <summary>
        /// 总计补货提前时间(按工作日)
        /// </summary>
        [SugarColumn(ColumnName = "Wzeit", ColumnDescription = "总计补货提前时间(按工作日) ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Wzeit { get; set; }

        /// <summary>
        /// 替换部件
        /// </summary>
        [SugarColumn(ColumnName = "Atpkz", ColumnDescription = "替换部件 ", Length = 2)]
        public string Atpkz { get; set; }

        /// <summary>
        /// 用百分比表示的成本的附加因子
        /// </summary>
        [SugarColumn(ColumnName = "Vzusl", ColumnDescription = "用百分比表示的成本的附加因子 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vzusl { get; set; }

        /// <summary>
        /// 生产状态
        /// </summary>
        [SugarColumn(ColumnName = "Herbl", ColumnDescription = "生产状态 ", Length = 4)]
        public string Herbl { get; set; }

        /// <summary>
        /// 过帐到检验库存
        /// </summary>
        [SugarColumn(ColumnName = "Insmk", ColumnDescription = "过帐到检验库存 ", Length = 2)]
        public string Insmk { get; set; }

        /// <summary>
        /// 质量检查的样本(在%中)(取消激活)
        /// </summary>
        [SugarColumn(ColumnName = "Sproz", ColumnDescription = "质量检查的样本(在%中)(取消激活) ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Sproz { get; set; }

        /// <summary>
        /// 隔离期(未激活)
        /// </summary>
        [SugarColumn(ColumnName = "Quazt", ColumnDescription = "隔离期(未激活) ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Quazt { get; set; }

        /// <summary>
        /// 采购中质量管理的控制码
        /// </summary>
        [SugarColumn(ColumnName = "Ssqss", ColumnDescription = "采购中质量管理的控制码 ", Length = 16)]
        public string Ssqss { get; set; }

        /// <summary>
        /// 平均检查持续期间(未激活的的)
        /// </summary>
        [SugarColumn(ColumnName = "Mpdau", ColumnDescription = "平均检查持续期间(未激活的的) ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Mpdau { get; set; }

        /// <summary>
        /// 检查计划的标识(未激活)
        /// </summary>
        [SugarColumn(ColumnName = "Kzppv", ColumnDescription = "检查计划的标识(未激活) ", Length = 2)]
        public string Kzppv { get; set; }

        /// <summary>
        /// 凭证需求标识
        /// </summary>
        [SugarColumn(ColumnName = "Kzdkz", ColumnDescription = "凭证需求标识 ", Length = 2)]
        public string Kzdkz { get; set; }

        /// <summary>
        /// 活动性物质内容(未激活的)
        /// </summary>
        [SugarColumn(ColumnName = "Wstgh", ColumnDescription = "活动性物质内容(未激活的) ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Wstgh { get; set; }

        /// <summary>
        /// 循环检查间隔
        /// </summary>
        [SugarColumn(ColumnName = "Prfrq", ColumnDescription = "循环检查间隔 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Prfrq { get; set; }

        /// <summary>
        /// 根据检验抽样检查的日期(取消激活)
        /// </summary>
        public DateTime? Nkmpr { get; set; }

        /// <summary>
        /// 中转库存（工厂到工厂）
        /// </summary>
        [SugarColumn(ColumnName = "Umlmc", ColumnDescription = "中转库存（工厂到工厂） ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Umlmc { get; set; }

        /// <summary>
        /// 装载组
        /// </summary>
        [SugarColumn(ColumnName = "Ladgr", ColumnDescription = "装载组 ", Length = 8)]
        public string Ladgr { get; set; }

        /// <summary>
        /// 批次管理需求的标识
        /// </summary>
        [SugarColumn(ColumnName = "Xchpf", ColumnDescription = "批次管理需求的标识 ", Length = 2)]
        public string Xchpf { get; set; }

        /// <summary>
        /// 配额分配使用
        /// </summary>
        [SugarColumn(ColumnName = "Usequ", ColumnDescription = "配额分配使用 ", Length = 2)]
        public string Usequ { get; set; }

        /// <summary>
        /// 服务水平
        /// </summary>
        [SugarColumn(ColumnName = "Lgrad", ColumnDescription = "服务水平 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Lgrad { get; set; }

        /// <summary>
        /// 分割标识
        /// </summary>
        [SugarColumn(ColumnName = "Auftl", ColumnDescription = "分割标识 ", Length = 2)]
        public string Auftl { get; set; }

        /// <summary>
        /// 计划版本
        /// </summary>
        [SugarColumn(ColumnName = "Plvar", ColumnDescription = "计划版本 ", Length = 4)]
        public string Plvar { get; set; }

        /// <summary>
        /// 对象类型
        /// </summary>
        [SugarColumn(ColumnName = "Otype", ColumnDescription = "对象类型 ", Length = 4)]
        public string Otype { get; set; }

        /// <summary>
        /// 对象标识
        /// </summary>
        [SugarColumn(ColumnName = "Objid", ColumnDescription = "对象标识 ", DefaultValue = "0")]
        public int? Objid { get; set; }

        /// <summary>
        /// 可用性检查的检查组
        /// </summary>
        [SugarColumn(ColumnName = "Mtvfp", ColumnDescription = "可用性检查的检查组 ", Length = 4)]
        public string Mtvfp { get; set; }

        /// <summary>
        /// 会计年度变式
        /// </summary>
        [SugarColumn(ColumnName = "Periv", ColumnDescription = "会计年度变式 ", Length = 4)]
        public string Periv { get; set; }

        /// <summary>
        /// 标识: 考虑修正因子
        /// </summary>
        [SugarColumn(ColumnName = "Kzkfk", ColumnDescription = "标识: 考虑修正因子 ", Length = 2)]
        public string Kzkfk { get; set; }

        /// <summary>
        /// 装运建立时间
        /// </summary>
        [SugarColumn(ColumnName = "Vrvez", ColumnDescription = "装运建立时间 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vrvez { get; set; }

        /// <summary>
        /// 在装运中有关能力计划的基准数量
        /// </summary>
        [SugarColumn(ColumnName = "Vbamg", ColumnDescription = "在装运中有关能力计划的基准数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vbamg { get; set; }

        /// <summary>
        /// 处理时间: 装运
        /// </summary>
        [SugarColumn(ColumnName = "Vbeaz", ColumnDescription = "处理时间: 装运 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vbeaz { get; set; }

        /// <summary>
        /// 取消激活的
        /// </summary>
        [SugarColumn(ColumnName = "Lizyk", ColumnDescription = "取消激活的 ", Length = 8)]
        public string Lizyk { get; set; }

        /// <summary>
        /// 货源
        /// </summary>
        [SugarColumn(ColumnName = "Bwscl", ColumnDescription = "货源 ", Length = 2)]
        public string Bwscl { get; set; }

        /// <summary>
        /// 标识: "允许自动采购订单"
        /// </summary>
        [SugarColumn(ColumnName = "Kautb", ColumnDescription = "标识: 允许自动采购订单 ", Length = 2)]
        public string Kautb { get; set; }

        /// <summary>
        /// 标识: 源清单要求
        /// </summary>
        [SugarColumn(ColumnName = "Kordb", ColumnDescription = "标识: 源清单要求 ", Length = 2)]
        public string Kordb { get; set; }

        /// <summary>
        /// 外贸的商品代码和进口代码
        /// </summary>
        [SugarColumn(ColumnName = "Stawn", ColumnDescription = "外贸的商品代码和进口代码 ", Length = 34)]
        public string Stawn { get; set; }

        /// <summary>
        /// 物料原产地国家
        /// </summary>
        [SugarColumn(ColumnName = "Herkl", ColumnDescription = "物料原产地国家 ", Length = 6)]
        public string Herkl { get; set; }

        /// <summary>
        /// 物料原产地（非特惠货源）
        /// </summary>
        [SugarColumn(ColumnName = "Herkr", ColumnDescription = "物料原产地（非特惠货源） ", Length = 6)]
        public string Herkr { get; set; }

        /// <summary>
        /// 商品代码的计量单位(外贸)
        /// </summary>
        [SugarColumn(ColumnName = "Expme", ColumnDescription = "商品代码的计量单位(外贸) ", Length = 6)]
        public string Expme { get; set; }

        /// <summary>
        /// 出口/进口物料组
        /// </summary>
        [SugarColumn(ColumnName = "Mtver", ColumnDescription = "出口/进口物料组 ", Length = 8)]
        public string Mtver { get; set; }

        /// <summary>
        /// 利润中心
        /// </summary>
        [SugarColumn(ColumnName = "Prctr", ColumnDescription = "利润中心 ", Length = 20)]
        public string Prctr { get; set; }

        /// <summary>
        /// 在途库存
        /// </summary>
        [SugarColumn(ColumnName = "Trame", ColumnDescription = "在途库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Trame { get; set; }

        /// <summary>
        /// PPC 计划日历
        /// </summary>
        [SugarColumn(ColumnName = "Mrppp", ColumnDescription = "PPC 计划日历 ", Length = 6)]
        public string Mrppp { get; set; }

        /// <summary>
        /// 标识: 允许的重复制造
        /// </summary>
        [SugarColumn(ColumnName = "Sauft", ColumnDescription = "标识: 允许的重复制造 ", Length = 2)]
        public string Sauft { get; set; }

        /// <summary>
        /// 计划的时界
        /// </summary>
        [SugarColumn(ColumnName = "Fxhor", ColumnDescription = "计划的时界 ", DefaultValue = "0")]
        public int? Fxhor { get; set; }

        /// <summary>
        /// 消耗模式
        /// </summary>
        [SugarColumn(ColumnName = "Vrmod", ColumnDescription = "消耗模式 ", Length = 2)]
        public string Vrmod { get; set; }

        /// <summary>
        /// 消耗期间:逆向
        /// </summary>
        [SugarColumn(ColumnName = "Vint1", ColumnDescription = "消耗期间:逆向 ", DefaultValue = "0")]
        public int? Vint1 { get; set; }

        /// <summary>
        /// 消耗时期-向前
        /// </summary>
        [SugarColumn(ColumnName = "Vint2", ColumnDescription = "消耗时期-向前 ", DefaultValue = "0")]
        public int? Vint2 { get; set; }

        /// <summary>
        /// 版本标识符
        /// </summary>
        [SugarColumn(ColumnName = "Verkz", ColumnDescription = "版本标识符 ", Length = 2)]
        public string Verkz { get; set; }

        /// <summary>
        /// 可选的 BOM
        /// </summary>
        [SugarColumn(ColumnName = "Stlal", ColumnDescription = "可选的 BOM ", Length = 4)]
        public string Stlal { get; set; }

        /// <summary>
        /// BOM 用途
        /// </summary>
        [SugarColumn(ColumnName = "Stlan", ColumnDescription = "BOM 用途 ", Length = 2)]
        public string Stlan { get; set; }

        /// <summary>
        /// 任务清单组码
        /// </summary>
        [SugarColumn(ColumnName = "Plnnr", ColumnDescription = "任务清单组码 ", Length = 16)]
        public string Plnnr { get; set; }

        /// <summary>
        /// 组计数器
        /// </summary>
        [SugarColumn(ColumnName = "Aplal", ColumnDescription = "组计数器 ", Length = 4)]
        public string Aplal { get; set; }

        /// <summary>
        /// 批量产品成本核算
        /// </summary>
        [SugarColumn(ColumnName = "Losgr", ColumnDescription = "批量产品成本核算 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Losgr { get; set; }

        /// <summary>
        /// 成本核算的特殊采购类型
        /// </summary>
        [SugarColumn(ColumnName = "Sobsk", ColumnDescription = "成本核算的特殊采购类型 ", Length = 4)]
        public string Sobsk { get; set; }

        /// <summary>
        /// 生产单位
        /// </summary>
        [SugarColumn(ColumnName = "Frtme", ColumnDescription = "生产单位 ", Length = 6)]
        public string Frtme { get; set; }

        /// <summary>
        /// 发货库存地点
        /// </summary>
        [SugarColumn(ColumnName = "Lgpro", ColumnDescription = "发货库存地点 ", Length = 8)]
        public string Lgpro { get; set; }

        /// <summary>
        /// 物料需求计划组
        /// </summary>
        [SugarColumn(ColumnName = "Disgr", ColumnDescription = "物料需求计划组 ", Length = 8)]
        public string Disgr { get; set; }

        /// <summary>
        /// 部件废品百分数
        /// </summary>
        [SugarColumn(ColumnName = "Kausf", ColumnDescription = "部件废品百分数 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Kausf { get; set; }

        /// <summary>
        /// 证书类型
        /// </summary>
        [SugarColumn(ColumnName = "Qzgtp", ColumnDescription = "证书类型 ", Length = 8)]
        public string Qzgtp { get; set; }

        /// <summary>
        /// 物料/工厂的检验设置存在
        /// </summary>
        [SugarColumn(ColumnName = "Qmatv", ColumnDescription = "物料/工厂的检验设置存在 ", Length = 2)]
        public string Qmatv { get; set; }

        /// <summary>
        /// 间隔时间（多个计划订单分阶段生产时，计划订单之间的间隔时间)
        /// </summary>
        [SugarColumn(ColumnName = "Takzt", ColumnDescription = "间隔时间（多个计划订单分阶段生产时，计划订单之间的间隔时间) ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Takzt { get; set; }

        /// <summary>
        /// 供货天数参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Rwpro", ColumnDescription = "供货天数参数文件 ", Length = 6)]
        public string Rwpro { get; set; }

        /// <summary>
        /// 连接到SOP上的CO/PA局部字段名
        /// </summary>
        [SugarColumn(ColumnName = "Copam", ColumnDescription = "连接到SOP上的CO/PA局部字段名 ", Length = 20)]
        public string Copam { get; set; }

        /// <summary>
        /// 周期盘点的盘点标识
        /// </summary>
        [SugarColumn(ColumnName = "Abcin", ColumnDescription = "周期盘点的盘点标识 ", Length = 2)]
        public string Abcin { get; set; }

        /// <summary>
        /// 差异码
        /// </summary>
        [SugarColumn(ColumnName = "Awsls", ColumnDescription = "差异码 ", Length = 12)]
        public string Awsls { get; set; }

        /// <summary>
        /// 序列号参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Sernp", ColumnDescription = "序列号参数文件 ", Length = 8)]
        public string Sernp { get; set; }

        /// <summary>
        /// 内部对象号
        /// </summary>
        [SugarColumn(ColumnName = "Cuobj", ColumnDescription = "内部对象号 ", DefaultValue = "0")]
        public int? Cuobj { get; set; }

        /// <summary>
        /// 可配置的物料
        /// </summary>
        [SugarColumn(ColumnName = "Stdpd", ColumnDescription = "可配置的物料 ", Length = 36)]
        public string Stdpd { get; set; }

        /// <summary>
        /// 重复生产参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Sfepr", ColumnDescription = "重复生产参数文件 ", Length = 8)]
        public string Sfepr { get; set; }

        /// <summary>
        /// 工厂中允许负库存
        /// </summary>
        [SugarColumn(ColumnName = "Xmcng", ColumnDescription = "工厂中允许负库存 ", Length = 2)]
        public string Xmcng { get; set; }

        /// <summary>
        /// 要求的供应商质量管理系统
        /// </summary>
        [SugarColumn(ColumnName = "Qssys", ColumnDescription = "要求的供应商质量管理系统 ", Length = 8)]
        public string Qssys { get; set; }

        /// <summary>
        /// 计划周期
        /// </summary>
        [SugarColumn(ColumnName = "Lfrhy", ColumnDescription = "计划周期 ", Length = 6)]
        public string Lfrhy { get; set; }

        /// <summary>
        /// 舍入参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Rdprf", ColumnDescription = "舍入参数文件 ", Length = 8)]
        public string Rdprf { get; set; }

        /// <summary>
        /// 消耗的参考物料
        /// </summary>
        [SugarColumn(ColumnName = "Vrbmt", ColumnDescription = "消耗的参考物料 ", Length = 36)]
        public string Vrbmt { get; set; }

        /// <summary>
        /// 消耗的参考工厂
        /// </summary>
        [SugarColumn(ColumnName = "Vrbwk", ColumnDescription = "消耗的参考工厂 ", Length = 8)]
        public string Vrbwk { get; set; }

        /// <summary>
        /// 到消耗物料将被复制的日期
        /// </summary>
        public DateTime? Vrbdt { get; set; }

        /// <summary>
        /// 消耗的参考物料的乘数
        /// </summary>
        [SugarColumn(ColumnName = "Vrbfk", ColumnDescription = "消耗的参考物料的乘数 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vrbfk { get; set; }

        /// <summary>
        /// 自动重置预测模式
        /// </summary>
        [SugarColumn(ColumnName = "Autru", ColumnDescription = "自动重置预测模式 ", Length = 2)]
        public string Autru { get; set; }

        /// <summary>
        /// 进/出口中优惠指示符
        /// </summary>
        [SugarColumn(ColumnName = "Prefe", ColumnDescription = "进/出口中优惠指示符 ", Length = 2)]
        public string Prefe { get; set; }

        /// <summary>
        /// 免税证明：法律控制指示符
        /// </summary>
        [SugarColumn(ColumnName = "Prenc", ColumnDescription = "免税证明：法律控制指示符 ", Length = 2)]
        public string Prenc { get; set; }

        /// <summary>
        /// 法律控制的免税证书编号
        /// </summary>
        [SugarColumn(ColumnName = "Preno", ColumnDescription = "法律控制的免税证书编号 ", Length = 16)]
        public string Preno { get; set; }

        /// <summary>
        /// 免税证明：免税证书的发放日
        /// </summary>
        public DateTime? Prend { get; set; }

        /// <summary>
        /// 标识：存在供应商申报
        /// </summary>
        [SugarColumn(ColumnName = "Prene", ColumnDescription = "标识：存在供应商申报 ", Length = 2)]
        public string Prene { get; set; }

        /// <summary>
        /// 供应商申报的有效日期
        /// </summary>
        public DateTime? Preng { get; set; }

        /// <summary>
        /// 指示符：军用物资
        /// </summary>
        [SugarColumn(ColumnName = "Itark", ColumnDescription = "指示符：军用物资 ", Length = 2)]
        public string Itark { get; set; }

        /// <summary>
        /// IS－R服务级别
        /// </summary>
        [SugarColumn(ColumnName = "Servg", ColumnDescription = "IS－R服务级别 ", Length = 2)]
        public string Servg { get; set; }

        /// <summary>
        /// 指示符 : 物料是联产品
        /// </summary>
        [SugarColumn(ColumnName = "Kzkup", ColumnDescription = "指示符 : 物料是联产品 ", Length = 2)]
        public string Kzkup { get; set; }

        /// <summary>
        /// 计划策略组
        /// </summary>
        [SugarColumn(ColumnName = "Strgr", ColumnDescription = "计划策略组 ", Length = 4)]
        public string Strgr { get; set; }

        /// <summary>
        /// 计划中的可配置物料的内部对象号
        /// </summary>
        [SugarColumn(ColumnName = "Cuobv", ColumnDescription = "计划中的可配置物料的内部对象号 ", DefaultValue = "0")]
        public int? Cuobv { get; set; }

        /// <summary>
        /// 外部采购的缺省仓储位置
        /// </summary>
        [SugarColumn(ColumnName = "Lgfsb", ColumnDescription = "外部采购的缺省仓储位置 ", Length = 8)]
        public string Lgfsb { get; set; }

        /// <summary>
        /// 标识：散装物料
        /// </summary>
        [SugarColumn(ColumnName = "Schgt", ColumnDescription = "标识：散装物料 ", Length = 2)]
        public string Schgt { get; set; }

        /// <summary>
        /// 周期标识被固定
        /// </summary>
        [SugarColumn(ColumnName = "Ccfix", ColumnDescription = "周期标识被固定 ", Length = 2)]
        public string Ccfix { get; set; }

        /// <summary>
        /// 库存确定组
        /// </summary>
        [SugarColumn(ColumnName = "Eprio", ColumnDescription = "库存确定组 ", Length = 8)]
        public string Eprio { get; set; }

        /// <summary>
        /// QM 中活动的物料授权组
        /// </summary>
        [SugarColumn(ColumnName = "Qmata", ColumnDescription = "QM 中活动的物料授权组 ", Length = 12)]
        public string Qmata { get; set; }

        /// <summary>
        /// 计划独立需求的调整期间
        /// </summary>
        [SugarColumn(ColumnName = "Resvp", ColumnDescription = "计划独立需求的调整期间 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Resvp { get; set; }

        /// <summary>
        /// 任务清单类型
        /// </summary>
        [SugarColumn(ColumnName = "Plnty", ColumnDescription = "任务清单类型 ", Length = 2)]
        public string Plnty { get; set; }

        /// <summary>
        /// 计量组单位 (石油,天然气,...)
        /// </summary>
        [SugarColumn(ColumnName = "Uomgr", ColumnDescription = "计量组单位 (石油,天然气,...) ", Length = 6)]
        public string Uomgr { get; set; }

        /// <summary>
        /// 转换组 (石油,天然气,..)
        /// </summary>
        [SugarColumn(ColumnName = "Umrsl", ColumnDescription = "转换组 (石油,天然气,..) ", Length = 8)]
        public string Umrsl { get; set; }

        /// <summary>
        /// 空气浮力因子
        /// </summary>
        [SugarColumn(ColumnName = "Abfac", ColumnDescription = "空气浮力因子 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Abfac { get; set; }

        /// <summary>
        /// 生产计划参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Sfcpf", ColumnDescription = "生产计划参数文件 ", Length = 12)]
        public string Sfcpf { get; set; }

        /// <summary>
        /// 安全时间标识（含或不含安全时间）
        /// </summary>
        [SugarColumn(ColumnName = "Shflg", ColumnDescription = "安全时间标识（含或不含安全时间） ", Length = 2)]
        public string Shflg { get; set; }

        /// <summary>
        /// 安全时间（按工作日计算）
        /// </summary>
        [SugarColumn(ColumnName = "Shzet", ColumnDescription = "安全时间（按工作日计算） ", DefaultValue = "0")]
        public int? Shzet { get; set; }

        /// <summary>
        /// 活动控制：计划订单处理
        /// </summary>
        [SugarColumn(ColumnName = "Mdach", ColumnDescription = "活动控制：计划订单处理 ", Length = 4)]
        public string Mdach { get; set; }

        /// <summary>
        /// 在生产/处理订单中批量输入的确定
        /// </summary>
        [SugarColumn(ColumnName = "Kzech", ColumnDescription = "在生产/处理订单中批量输入的确定 ", Length = 2)]
        public string Kzech { get; set; }

        /// <summary>
        /// 计量单位组
        /// </summary>
        [SugarColumn(ColumnName = "Megru", ColumnDescription = "计量单位组 ", Length = 8)]
        public string Megru { get; set; }

        /// <summary>
        /// 物料运输组
        /// </summary>
        [SugarColumn(ColumnName = "Mfrgr", ColumnDescription = "物料运输组 ", Length = 16)]
        public string Mfrgr { get; set; }

        /// <summary>
        /// VO 物料的库存转移销售值（工厂到工厂）
        /// </summary>
        [SugarColumn(ColumnName = "Vkumc", ColumnDescription = "VO 物料的库存转移销售值（工厂到工厂） ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vkumc { get; set; }

        /// <summary>
        /// 仅记值物料的销售价格计的运输值
        /// </summary>
        [SugarColumn(ColumnName = "Vktrw", ColumnDescription = "仅记值物料的销售价格计的运输值 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vktrw { get; set; }

        /// <summary>
        /// 指示符: 平滑促销消耗
        /// </summary>
        [SugarColumn(ColumnName = "Kzagl", ColumnDescription = "指示符: 平滑促销消耗 ", Length = 2)]
        public string Kzagl { get; set; }

        /// <summary>
        /// 将进行成本核算的生产版本
        /// </summary>
        [SugarColumn(ColumnName = "Fvidk", ColumnDescription = "将进行成本核算的生产版本 ", Length = 8)]
        public string Fvidk { get; set; }

        /// <summary>
        /// 固定价格联产品
        /// </summary>
        [SugarColumn(ColumnName = "Fxpru", ColumnDescription = "固定价格联产品 ", Length = 2)]
        public string Fxpru { get; set; }

        /// <summary>
        /// 用于计算工作负荷的后勤处理组
        /// </summary>
        [SugarColumn(ColumnName = "Loggr", ColumnDescription = "用于计算工作负荷的后勤处理组 ", Length = 8)]
        public string Loggr { get; set; }

        /// <summary>
        /// 工厂物料分销参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Fprfm", ColumnDescription = "工厂物料分销参数文件 ", Length = 6)]
        public string Fprfm { get; set; }

        /// <summary>
        /// 有约束的虚拟库存
        /// </summary>
        [SugarColumn(ColumnName = "Glgmg", ColumnDescription = "有约束的虚拟库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Glgmg { get; set; }

        /// <summary>
        /// 连接空缺库存的销售价
        /// </summary>
        [SugarColumn(ColumnName = "Vkglg", ColumnDescription = "连接空缺库存的销售价 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vkglg { get; set; }

        /// <summary>
        /// 物料: CFOP类别
        /// </summary>
        [SugarColumn(ColumnName = "Indus", ColumnDescription = "物料: CFOP类别 ", Length = 4)]
        public string Indus { get; set; }

        /// <summary>
        /// CAP：CAP 产品清单编号
        /// </summary>
        [SugarColumn(ColumnName = "Mownr", ColumnDescription = "CAP：CAP 产品清单编号 ", Length = 24)]
        public string Mownr { get; set; }

        /// <summary>
        /// 共同农业市场政策：CAP 产品组－外贸
        /// </summary>
        [SugarColumn(ColumnName = "Mogru", ColumnDescription = "共同农业市场政策：CAP 产品组－外贸 ", Length = 12)]
        public string Mogru { get; set; }

        /// <summary>
        /// 外贸药品 CAS 号码
        /// </summary>
        [SugarColumn(ColumnName = "Casnr", ColumnDescription = "外贸药品 CAS 号码 ", Length = 30)]
        public string Casnr { get; set; }

        /// <summary>
        /// 生产统计：外贸 PRODCOM 号码
        /// </summary>
        [SugarColumn(ColumnName = "Gpnum", ColumnDescription = "生产统计：外贸 PRODCOM 号码 ", Length = 18)]
        public string Gpnum { get; set; }

        /// <summary>
        /// 对外贸易消费税控制代码
        /// </summary>
        [SugarColumn(ColumnName = "Steuc", ColumnDescription = "对外贸易消费税控制代码 ", Length = 32)]
        public string Steuc { get; set; }

        /// <summary>
        /// 标识: 与 JIT 交货计划相关的物料
        /// </summary>
        [SugarColumn(ColumnName = "Fabkz", ColumnDescription = "标识: 与 JIT 交货计划相关的物料 ", Length = 2)]
        public string Fabkz { get; set; }

        /// <summary>
        /// 转换矩阵的物料组
        /// </summary>
        [SugarColumn(ColumnName = "Matgr", ColumnDescription = "转换矩阵的物料组 ", Length = 40)]
        public string Matgr { get; set; }

        /// <summary>
        /// 物料主记录中建议的供应区域
        /// </summary>
        [SugarColumn(ColumnName = "Vspvb", ColumnDescription = "物料主记录中建议的供应区域 ", Length = 20)]
        public string Vspvb { get; set; }

        /// <summary>
        /// 公平分享规则
        /// </summary>
        [SugarColumn(ColumnName = "Dplfs", ColumnDescription = "公平分享规则 ", Length = 4)]
        public string Dplfs { get; set; }

        /// <summary>
        /// 指示器:推式分配
        /// </summary>
        [SugarColumn(ColumnName = "Dplpu", ColumnDescription = "指示器:推式分配 ", Length = 2)]
        public string Dplpu { get; set; }

        /// <summary>
        /// 发布的天数界限
        /// </summary>
        [SugarColumn(ColumnName = "Dplho", ColumnDescription = "发布的天数界限 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Dplho { get; set; }

        /// <summary>
        /// 匹配供应量的最小批尺寸
        /// </summary>
        [SugarColumn(ColumnName = "Minls", ColumnDescription = "匹配供应量的最小批尺寸 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Minls { get; set; }

        /// <summary>
        /// 匹配供应需求的最大批尺寸
        /// </summary>
        [SugarColumn(ColumnName = "Maxls", ColumnDescription = "匹配供应需求的最大批尺寸 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Maxls { get; set; }

        /// <summary>
        /// 匹配供应需求的固定批大小
        /// </summary>
        [SugarColumn(ColumnName = "Fixls", ColumnDescription = "匹配供应需求的固定批大小 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Fixls { get; set; }

        /// <summary>
        /// 匹配供应需求增加批尺寸
        /// </summary>
        [SugarColumn(ColumnName = "Ltinc", ColumnDescription = "匹配供应需求增加批尺寸 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Ltinc { get; set; }

        /// <summary>
        /// 该字段不再使用
        /// </summary>
        [SugarColumn(ColumnName = "Compl", ColumnDescription = "该字段不再使用 ", DefaultValue = "0")]
        public int? Compl { get; set; }

        /// <summary>
        /// 用于生产指标的转换类型
        /// </summary>
        [SugarColumn(ColumnName = "Convt", ColumnDescription = "用于生产指标的转换类型 ", Length = 4)]
        public string Convt { get; set; }

        /// <summary>
        /// 安全时间的期间参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Shpro", ColumnDescription = "安全时间的期间参数文件 ", Length = 6)]
        public string Shpro { get; set; }

        /// <summary>
        /// 相关需求的 MRP  关联
        /// </summary>
        [SugarColumn(ColumnName = "Ahdis", ColumnDescription = "相关需求的 MRP  关联 ", Length = 2)]
        public string Ahdis { get; set; }

        /// <summary>
        /// 指示：MRP  范围存在
        /// </summary>
        [SugarColumn(ColumnName = "Diber", ColumnDescription = "指示：MRP  范围存在 ", Length = 2)]
        public string Diber { get; set; }

        /// <summary>
        /// 跨项目物料指示符
        /// </summary>
        [SugarColumn(ColumnName = "Kzpsp", ColumnDescription = "跨项目物料指示符 ", Length = 2)]
        public string Kzpsp { get; set; }

        /// <summary>
        /// 订单更改管理的总体参数文件
        /// </summary>
        [SugarColumn(ColumnName = "Ocmpf", ColumnDescription = "订单更改管理的总体参数文件 ", Length = 12)]
        public string Ocmpf { get; set; }

        /// <summary>
        /// 指示：物料是否与 APO 相关
        /// </summary>
        [SugarColumn(ColumnName = "Apokz", ColumnDescription = "指示：物料是否与 APO 相关 ", Length = 2)]
        public string Apokz { get; set; }

        /// <summary>
        /// 最后的MARD 期间之前，MARDH 记录已经存在
        /// </summary>
        [SugarColumn(ColumnName = "Mcrue", ColumnDescription = "最后的MARD 期间之前，MARDH 记录已经存在 ", Length = 2)]
        public string Mcrue { get; set; }

        /// <summary>
        /// 当前期间 (记帐期间)
        /// </summary>
        [SugarColumn(ColumnName = "Lfmon", ColumnDescription = "当前期间 (记帐期间) ", DefaultValue = "0")]
        public int? Lfmon { get; set; }

        /// <summary>
        /// 当前期间的会计年度
        /// </summary>
        [SugarColumn(ColumnName = "Lfgja", ColumnDescription = "当前期间的会计年度 ", DefaultValue = "0")]
        public int? Lfgja { get; set; }

        /// <summary>
        /// 最小安全库存
        /// </summary>
        [SugarColumn(ColumnName = "Eislo", ColumnDescription = "最小安全库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Eislo { get; set; }

        /// <summary>
        /// 无成本核算
        /// </summary>
        [SugarColumn(ColumnName = "Ncost", ColumnDescription = "无成本核算 ", Length = 2)]
        public string Ncost { get; set; }

        /// <summary>
        /// 库存入库和库存出库的策略
        /// </summary>
        [SugarColumn(ColumnName = "Rotationdate", ColumnDescription = "库存入库和库存出库的策略 ", Length = 2)]
        public string Rotationdate { get; set; }

        /// <summary>
        /// 初始批次管理的标识
        /// </summary>
        [SugarColumn(ColumnName = "Uchkz", ColumnDescription = "初始批次管理的标识 ", Length = 2)]
        public string Uchkz { get; set; }

        /// <summary>
        /// 初始批量的参考物料
        /// </summary>
        [SugarColumn(ColumnName = "Ucmat", ColumnDescription = "初始批量的参考物料 ", Length = 36)]
        public string Ucmat { get; set; }

        /// <summary>
        /// 评估的收货锁定库存
        /// </summary>
        [SugarColumn(ColumnName = "Bwesb", ColumnDescription = "评估的收货锁定库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Bwesb { get; set; }

        /// <summary>
        /// 分段策略
        /// </summary>
        [SugarColumn(ColumnName = "Sgtcovs", ColumnDescription = "分段策略 ", Length = 16)]
        public string Sgtcovs { get; set; }

        /// <summary>
        /// 分段状态
        /// </summary>
        [SugarColumn(ColumnName = "Sgtstatc", ColumnDescription = "分段状态 ", Length = 2)]
        public string Sgtstatc { get; set; }

        /// <summary>
        /// 分段策略范围
        /// </summary>
        [SugarColumn(ColumnName = "Sgtscope", ColumnDescription = "分段策略范围 ", Length = 2)]
        public string Sgtscope { get; set; }

        /// <summary>
        /// 根据交货日期或段排序库存
        /// </summary>
        [SugarColumn(ColumnName = "Sgtmrpsi", ColumnDescription = "根据交货日期或段排序库存 ", Length = 2)]
        public string Sgtmrpsi { get; set; }

        /// <summary>
        /// 消耗优先级
        /// </summary>
        [SugarColumn(ColumnName = "Sgtprcm", ColumnDescription = "消耗优先级 ", Length = 2)]
        public string Sgtprcm { get; set; }

        /// <summary>
        /// 离散批次编号
        /// </summary>
        [SugarColumn(ColumnName = "Sgtchint", ColumnDescription = "离散批次编号 ", Length = 2)]
        public string Sgtchint { get; set; }

        /// <summary>
        /// 库存保护标识
        /// </summary>
        [SugarColumn(ColumnName = "Sgtstkprt", ColumnDescription = "库存保护标识 ", Length = 2)]
        public string Sgtstkprt { get; set; }

        /// <summary>
        /// 订单分配运行
        /// </summary>
        [SugarColumn(ColumnName = "Fshmgarunreq", ColumnDescription = "订单分配运行 ", Length = 2)]
        public string Fshmgarunreq { get; set; }

        /// <summary>
        /// 标识：在库存管理中激活季节
        /// </summary>
        [SugarColumn(ColumnName = "Fshseaim", ColumnDescription = "标识：在库存管理中激活季节 ", Length = 2)]
        public string Fshseaim { get; set; }

        /// <summary>
        /// 物料的包装组 (VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Vsorpkgrp", ColumnDescription = "物料的包装组 (VSO) ", Length = 36)]
        public string Vsorpkgrp { get; set; }

        /// <summary>
        /// 自动提货区域内的行 (VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Vsorlanenum", ColumnDescription = "自动提货区域内的行 (VSO) ", Length = 6)]
        public string Vsorlanenum { get; set; }

        /// <summary>
        /// 供应商包装物料的物料编号 (VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Vsorpalvend", ColumnDescription = "供应商包装物料的物料编号 (VSO) ", Length = 36)]
        public string Vsorpalvend { get; set; }

        /// <summary>
        /// 仅纵向提取包装物料 (VSO)
        /// </summary>
        [SugarColumn(ColumnName = "Vsorforkdir", ColumnDescription = "仅纵向提取包装物料 (VSO) ", Length = 2)]
        public string Vsorforkdir { get; set; }

        /// <summary>
        /// 项目唯一标识相关
        /// </summary>
        [SugarColumn(ColumnName = "Iuidrelevant", ColumnDescription = "项目唯一标识相关 ", Length = 2)]
        public string Iuidrelevant { get; set; }

        /// <summary>
        /// 唯一项目标识的结构类型
        /// </summary>
        [SugarColumn(ColumnName = "Iuidtype", ColumnDescription = "唯一项目标识的结构类型 ", Length = 20)]
        public string Iuidtype { get; set; }

        /// <summary>
        /// UII 的外部分配
        /// </summary>
        [SugarColumn(ColumnName = "Uidiea", ColumnDescription = "UII 的外部分配 ", Length = 2)]
        public string Uidiea { get; set; }

        /// <summary>
        /// 寄售控制
        /// </summary>
        [SugarColumn(ColumnName = "Consprocg", ColumnDescription = "寄售控制 ", Length = 2)]
        public string Consprocg { get; set; }

        /// <summary>
        /// 按天数发货处理时间
        /// </summary>
        [SugarColumn(ColumnName = "Giprtime", ColumnDescription = "按天数发货处理时间 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Giprtime { get; set; }

        /// <summary>
        /// 采购交叉的采购组
        /// </summary>
        [SugarColumn(ColumnName = "Multipleekgrp", ColumnDescription = "采购交叉的采购组 ", Length = 2)]
        public string Multipleekgrp { get; set; }

        /// <summary>
        /// 参考确定方案
        /// </summary>
        [SugarColumn(ColumnName = "Refschema", ColumnDescription = "参考确定方案 ", Length = 4)]
        public string Refschema { get; set; }

        /// <summary>
        /// 覆盖的最小目标范围
        /// </summary>
        [SugarColumn(ColumnName = "Mintroc", ColumnDescription = "覆盖的最小目标范围 ", DefaultValue = "0")]
        public int? Mintroc { get; set; }

        /// <summary>
        /// 覆盖的最大目标范围
        /// </summary>
        [SugarColumn(ColumnName = "Maxtroc", ColumnDescription = "覆盖的最大目标范围 ", DefaultValue = "0")]
        public int? Maxtroc { get; set; }

        /// <summary>
        /// 目标库存
        /// </summary>
        [SugarColumn(ColumnName = "Targetstock", ColumnDescription = "目标库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Targetstock { get; set; }
    }
}