namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 工厂物料
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:45:06
    /// </summary>
    public class MmMarcQueryDto : PagerInfo
    {
        public string Matnr { get; set; }
        public string Werks { get; set; }
        public string Lvorm { get; set; }
        public string Ekgrp { get; set; }
        public string Beskz { get; set; }
        public string Sobsl { get; set; }
        public string Insmk { get; set; }
        public string Kautb { get; set; }
        public string Kordb { get; set; }
        public string Prctr { get; set; }
        public string Lgpro { get; set; }
        public string Lgfsb { get; set; }
    }

    /// <summary>
    /// 工厂物料
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:45:06
    /// </summary>
    public class MmMarcDto
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

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Werks { get; set; }

        [ExcelColumn(Name = "维护状态")]
        [ExcelColumnName("维护状态")]
        public string Pstat { get; set; }

        [Required(ErrorMessage = "在工厂级标记要删除的物料不能为空")]
        [ExcelColumn(Name = "在工厂级标记要删除的物料")]
        [ExcelColumnName("在工厂级标记要删除的物料")]
        public string Lvorm { get; set; }

        [ExcelColumn(Name = "评估类别")]
        [ExcelColumnName("评估类别")]
        public string Bwtty { get; set; }

        [ExcelColumn(Name = "批量管理标识(内部)")]
        [ExcelColumnName("批量管理标识(内部)")]
        public string Xchar { get; set; }

        [ExcelColumn(Name = "工厂特定的物料状态")]
        [ExcelColumnName("工厂特定的物料状态")]
        public string Mmsta { get; set; }

        [ExcelColumn(Name = "工厂特定物料状态有效的起始日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("工厂特定物料状态有效的起始日期")]
        public DateTime? Mmstd { get; set; }

        [ExcelColumn(Name = "ABC标识")]
        [ExcelColumnName("ABC标识")]
        public string Maabc { get; set; }

        [ExcelColumn(Name = "标志：关键部件")]
        [ExcelColumnName("标志：关键部件")]
        public string Kzkri { get; set; }

        [Required(ErrorMessage = "采购组不能为空")]
        [ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string Ekgrp { get; set; }

        [ExcelColumn(Name = "发货单位")]
        [ExcelColumnName("发货单位")]
        public string Ausme { get; set; }

        [ExcelColumn(Name = "物料: MRP 参数文件")]
        [ExcelColumnName("物料: MRP 参数文件")]
        public string Dispr { get; set; }

        [ExcelColumn(Name = "物料需求计划类型")]
        [ExcelColumnName("物料需求计划类型")]
        public string Dismm { get; set; }

        [ExcelColumn(Name = "MRP 控制者（物料计划人）")]
        [ExcelColumnName("MRP 控制者（物料计划人）")]
        public string Dispo { get; set; }

        [ExcelColumn(Name = "标识: MRP控制者是买方(未激活的)")]
        [ExcelColumnName("标识: MRP控制者是买方(未激活的)")]
        public string Kzdie { get; set; }

        [ExcelColumn(Name = "计划的天数内交货")]
        [ExcelColumnName("计划的天数内交货")]
        public decimal Plifz { get; set; }

        [ExcelColumn(Name = "以天计的收货处理时间")]
        [ExcelColumnName("以天计的收货处理时间")]
        public decimal Webaz { get; set; }

        [ExcelColumn(Name = "期间标识")]
        [ExcelColumnName("期间标识")]
        public string Perkz { get; set; }

        [ExcelColumn(Name = "装配报废百分比")]
        [ExcelColumnName("装配报废百分比")]
        public decimal Ausss { get; set; }

        [ExcelColumn(Name = "批量 (物料计划)")]
        [ExcelColumnName("批量 (物料计划)")]
        public string Disls { get; set; }

        [Required(ErrorMessage = "采购类型不能为空")]
        [ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string Beskz { get; set; }

        [Required(ErrorMessage = "特殊采购类型不能为空")]
        [ExcelColumn(Name = "特殊采购类型")]
        [ExcelColumnName("特殊采购类型")]
        public string Sobsl { get; set; }

        [ExcelColumn(Name = "再订货点")]
        [ExcelColumnName("再订货点")]
        public decimal Minbe { get; set; }

        [ExcelColumn(Name = "安全库存")]
        [ExcelColumnName("安全库存")]
        public decimal Eisbe { get; set; }

        [ExcelColumn(Name = "最小批量")]
        [ExcelColumnName("最小批量")]
        public decimal Bstmi { get; set; }

        [ExcelColumn(Name = "最大批量大小")]
        [ExcelColumnName("最大批量大小")]
        public decimal Bstma { get; set; }

        [ExcelColumn(Name = "固定批量大小")]
        [ExcelColumnName("固定批量大小")]
        public decimal Bstfe { get; set; }

        [ExcelColumn(Name = "采购订单数量的舍入值")]
        [ExcelColumnName("采购订单数量的舍入值")]
        public decimal Bstrf { get; set; }

        [ExcelColumn(Name = "最大库存水平")]
        [ExcelColumnName("最大库存水平")]
        public decimal Mabst { get; set; }

        [ExcelColumn(Name = "订购成本")]
        [ExcelColumnName("订购成本")]
        public decimal Losfx { get; set; }

        [ExcelColumn(Name = "对于独立和集中需求的相关需求标识")]
        [ExcelColumnName("对于独立和集中需求的相关需求标识")]
        public string Sbdkz { get; set; }

        [ExcelColumn(Name = "库存成本标识")]
        [ExcelColumnName("库存成本标识")]
        public string Lagpr { get; set; }

        [ExcelColumn(Name = "选择可替换物料单的方法")]
        [ExcelColumnName("选择可替换物料单的方法")]
        public string Altsl { get; set; }

        [ExcelColumn(Name = "中止指示符")]
        [ExcelColumnName("中止指示符")]
        public string Kzaus { get; set; }

        [ExcelColumn(Name = "中断日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("中断日期")]
        public DateTime? Ausdt { get; set; }

        [ExcelColumn(Name = "后续物料")]
        [ExcelColumnName("后续物料")]
        public string Nfmat { get; set; }

        [ExcelColumn(Name = "需求分组指示符")]
        [ExcelColumnName("需求分组指示符")]
        public string Kzbed { get; set; }

        [ExcelColumn(Name = "综合MRP标识")]
        [ExcelColumnName("综合MRP标识")]
        public string Miskz { get; set; }

        [ExcelColumn(Name = "浮动的计划边际码")]
        [ExcelColumnName("浮动的计划边际码")]
        public string Fhori { get; set; }

        [ExcelColumn(Name = "标识: 计划订单的自动修正")]
        [ExcelColumnName("标识: 计划订单的自动修正")]
        public string Pfrei { get; set; }

        [ExcelColumn(Name = "用于生产订单的批准标识")]
        [ExcelColumnName("用于生产订单的批准标识")]
        public string Ffrei { get; set; }

        [ExcelColumn(Name = "标识：反冲")]
        [ExcelColumnName("标识：反冲")]
        public string Rgekz { get; set; }

        [ExcelColumn(Name = "生产管理员")]
        [ExcelColumnName("生产管理员")]
        public string Fevor { get; set; }

        [ExcelColumn(Name = "处理时间")]
        [ExcelColumnName("处理时间")]
        public decimal Bearz { get; set; }

        [ExcelColumn(Name = "建立和拆卸时间")]
        [ExcelColumnName("建立和拆卸时间")]
        public decimal Ruezt { get; set; }

        [ExcelColumn(Name = "工序间时间")]
        [ExcelColumnName("工序间时间")]
        public decimal Tranz { get; set; }

        [ExcelColumn(Name = "基准数量")]
        [ExcelColumnName("基准数量")]
        public decimal Basmg { get; set; }

        [ExcelColumn(Name = "厂内生产时间")]
        [ExcelColumnName("厂内生产时间")]
        public decimal Dzeit { get; set; }

        [ExcelColumn(Name = "最大存储期间")]
        [ExcelColumnName("最大存储期间")]
        public decimal Maxlz { get; set; }

        [ExcelColumn(Name = "最大库存期间单位")]
        [ExcelColumnName("最大库存期间单位")]
        public string Lzeih { get; set; }

        [ExcelColumn(Name = "标识: 从生产区的库存提取")]
        [ExcelColumnName("标识: 从生产区的库存提取")]
        public string Kzpro { get; set; }

        [ExcelColumn(Name = "标识: 在初步计划中包括的物料")]
        [ExcelColumnName("标识: 在初步计划中包括的物料")]
        public string Gpmkz { get; set; }

        [ExcelColumn(Name = "超量交货容差限制")]
        [ExcelColumnName("超量交货容差限制")]
        public decimal Ueeto { get; set; }

        [ExcelColumn(Name = "标识：允许未限制的过量交货")]
        [ExcelColumnName("标识：允许未限制的过量交货")]
        public string Ueetk { get; set; }

        [ExcelColumn(Name = "不足交货容差限制")]
        [ExcelColumnName("不足交货容差限制")]
        public decimal Uneto { get; set; }

        [ExcelColumn(Name = "总计补货提前时间(按工作日)")]
        [ExcelColumnName("总计补货提前时间(按工作日)")]
        public decimal Wzeit { get; set; }

        [ExcelColumn(Name = "替换部件")]
        [ExcelColumnName("替换部件")]
        public string Atpkz { get; set; }

        [ExcelColumn(Name = "用百分比表示的成本的附加因子")]
        [ExcelColumnName("用百分比表示的成本的附加因子")]
        public decimal Vzusl { get; set; }

        [ExcelColumn(Name = "生产状态")]
        [ExcelColumnName("生产状态")]
        public string Herbl { get; set; }

        [Required(ErrorMessage = "过帐到检验库存不能为空")]
        [ExcelColumn(Name = "过帐到检验库存")]
        [ExcelColumnName("过帐到检验库存")]
        public string Insmk { get; set; }

        [ExcelColumn(Name = "质量检查的样本(在%中)(取消激活)")]
        [ExcelColumnName("质量检查的样本(在%中)(取消激活)")]
        public decimal Sproz { get; set; }

        [ExcelColumn(Name = "隔离期(未激活)")]
        [ExcelColumnName("隔离期(未激活)")]
        public decimal Quazt { get; set; }

        [ExcelColumn(Name = "采购中质量管理的控制码")]
        [ExcelColumnName("采购中质量管理的控制码")]
        public string Ssqss { get; set; }

        [ExcelColumn(Name = "平均检查持续期间(未激活的的)")]
        [ExcelColumnName("平均检查持续期间(未激活的的)")]
        public decimal Mpdau { get; set; }

        [ExcelColumn(Name = "检查计划的标识(未激活)")]
        [ExcelColumnName("检查计划的标识(未激活)")]
        public string Kzppv { get; set; }

        [ExcelColumn(Name = "凭证需求标识")]
        [ExcelColumnName("凭证需求标识")]
        public string Kzdkz { get; set; }

        [ExcelColumn(Name = "活动性物质内容(未激活的)")]
        [ExcelColumnName("活动性物质内容(未激活的)")]
        public decimal Wstgh { get; set; }

        [ExcelColumn(Name = "循环检查间隔")]
        [ExcelColumnName("循环检查间隔")]
        public decimal Prfrq { get; set; }

        [ExcelColumn(Name = "根据检验抽样检查的日期(取消激活)", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("根据检验抽样检查的日期(取消激活)")]
        public DateTime? Nkmpr { get; set; }

        [ExcelColumn(Name = "中转库存（工厂到工厂）")]
        [ExcelColumnName("中转库存（工厂到工厂）")]
        public decimal Umlmc { get; set; }

        [ExcelColumn(Name = "装载组")]
        [ExcelColumnName("装载组")]
        public string Ladgr { get; set; }

        [ExcelColumn(Name = "批次管理需求的标识")]
        [ExcelColumnName("批次管理需求的标识")]
        public string Xchpf { get; set; }

        [ExcelColumn(Name = "配额分配使用")]
        [ExcelColumnName("配额分配使用")]
        public string Usequ { get; set; }

        [ExcelColumn(Name = "服务水平")]
        [ExcelColumnName("服务水平")]
        public decimal Lgrad { get; set; }

        [ExcelColumn(Name = "分割标识")]
        [ExcelColumnName("分割标识")]
        public string Auftl { get; set; }

        [ExcelColumn(Name = "计划版本")]
        [ExcelColumnName("计划版本")]
        public string Plvar { get; set; }

        [ExcelColumn(Name = "对象类型")]
        [ExcelColumnName("对象类型")]
        public string Otype { get; set; }

        [ExcelColumn(Name = "对象标识")]
        [ExcelColumnName("对象标识")]
        public int? Objid { get; set; }

        [ExcelColumn(Name = "可用性检查的检查组")]
        [ExcelColumnName("可用性检查的检查组")]
        public string Mtvfp { get; set; }

        [ExcelColumn(Name = "会计年度变式")]
        [ExcelColumnName("会计年度变式")]
        public string Periv { get; set; }

        [ExcelColumn(Name = "标识: 考虑修正因子")]
        [ExcelColumnName("标识: 考虑修正因子")]
        public string Kzkfk { get; set; }

        [ExcelColumn(Name = "装运建立时间")]
        [ExcelColumnName("装运建立时间")]
        public decimal Vrvez { get; set; }

        [ExcelColumn(Name = "在装运中有关能力计划的基准数量")]
        [ExcelColumnName("在装运中有关能力计划的基准数量")]
        public decimal Vbamg { get; set; }

        [ExcelColumn(Name = "处理时间: 装运")]
        [ExcelColumnName("处理时间: 装运")]
        public decimal Vbeaz { get; set; }

        [ExcelColumn(Name = "取消激活的")]
        [ExcelColumnName("取消激活的")]
        public string Lizyk { get; set; }

        [ExcelColumn(Name = "货源")]
        [ExcelColumnName("货源")]
        public string Bwscl { get; set; }

        [Required(ErrorMessage = "标识: 允许自动采购订单不能为空")]
        [ExcelColumn(Name = "标识: 允许自动采购订单")]
        [ExcelColumnName("标识: 允许自动采购订单")]
        public string Kautb { get; set; }

        [Required(ErrorMessage = "标识: 源清单要求不能为空")]
        [ExcelColumn(Name = "标识: 源清单要求")]
        [ExcelColumnName("标识: 源清单要求")]
        public string Kordb { get; set; }

        [ExcelColumn(Name = "外贸的商品代码和进口代码")]
        [ExcelColumnName("外贸的商品代码和进口代码")]
        public string Stawn { get; set; }

        [ExcelColumn(Name = "物料原产地国家")]
        [ExcelColumnName("物料原产地国家")]
        public string Herkl { get; set; }

        [ExcelColumn(Name = "物料原产地（非特惠货源）")]
        [ExcelColumnName("物料原产地（非特惠货源）")]
        public string Herkr { get; set; }

        [ExcelColumn(Name = "商品代码的计量单位(外贸)")]
        [ExcelColumnName("商品代码的计量单位(外贸)")]
        public string Expme { get; set; }

        [ExcelColumn(Name = "出口/进口物料组")]
        [ExcelColumnName("出口/进口物料组")]
        public string Mtver { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        [ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string Prctr { get; set; }

        [ExcelColumn(Name = "在途库存")]
        [ExcelColumnName("在途库存")]
        public decimal Trame { get; set; }

        [ExcelColumn(Name = "PPC 计划日历")]
        [ExcelColumnName("PPC 计划日历")]
        public string Mrppp { get; set; }

        [ExcelColumn(Name = "标识: 允许的重复制造")]
        [ExcelColumnName("标识: 允许的重复制造")]
        public string Sauft { get; set; }

        [ExcelColumn(Name = "计划的时界")]
        [ExcelColumnName("计划的时界")]
        public int? Fxhor { get; set; }

        [ExcelColumn(Name = "消耗模式")]
        [ExcelColumnName("消耗模式")]
        public string Vrmod { get; set; }

        [ExcelColumn(Name = "消耗期间:逆向")]
        [ExcelColumnName("消耗期间:逆向")]
        public int? Vint1 { get; set; }

        [ExcelColumn(Name = "消耗时期-向前")]
        [ExcelColumnName("消耗时期-向前")]
        public int? Vint2 { get; set; }

        [ExcelColumn(Name = "版本标识符")]
        [ExcelColumnName("版本标识符")]
        public string Verkz { get; set; }

        [ExcelColumn(Name = "可选的 BOM")]
        [ExcelColumnName("可选的 BOM")]
        public string Stlal { get; set; }

        [ExcelColumn(Name = "BOM 用途")]
        [ExcelColumnName("BOM 用途")]
        public string Stlan { get; set; }

        [ExcelColumn(Name = "任务清单组码")]
        [ExcelColumnName("任务清单组码")]
        public string Plnnr { get; set; }

        [ExcelColumn(Name = "组计数器")]
        [ExcelColumnName("组计数器")]
        public string Aplal { get; set; }

        [ExcelColumn(Name = "批量产品成本核算")]
        [ExcelColumnName("批量产品成本核算")]
        public decimal Losgr { get; set; }

        [ExcelColumn(Name = "成本核算的特殊采购类型")]
        [ExcelColumnName("成本核算的特殊采购类型")]
        public string Sobsk { get; set; }

        [ExcelColumn(Name = "生产单位")]
        [ExcelColumnName("生产单位")]
        public string Frtme { get; set; }

        [Required(ErrorMessage = "发货库存地点不能为空")]
        [ExcelColumn(Name = "发货库存地点")]
        [ExcelColumnName("发货库存地点")]
        public string Lgpro { get; set; }

        [ExcelColumn(Name = "物料需求计划组")]
        [ExcelColumnName("物料需求计划组")]
        public string Disgr { get; set; }

        [ExcelColumn(Name = "部件废品百分数")]
        [ExcelColumnName("部件废品百分数")]
        public decimal Kausf { get; set; }

        [ExcelColumn(Name = "证书类型")]
        [ExcelColumnName("证书类型")]
        public string Qzgtp { get; set; }

        [ExcelColumn(Name = "物料/工厂的检验设置存在")]
        [ExcelColumnName("物料/工厂的检验设置存在")]
        public string Qmatv { get; set; }

        [ExcelColumn(Name = "间隔时间（多个计划订单分阶段生产时，计划订单之间的间隔时间)")]
        [ExcelColumnName("间隔时间（多个计划订单分阶段生产时，计划订单之间的间隔时间)")]
        public decimal Takzt { get; set; }

        [ExcelColumn(Name = "供货天数参数文件")]
        [ExcelColumnName("供货天数参数文件")]
        public string Rwpro { get; set; }

        [ExcelColumn(Name = "连接到SOP上的CO/PA局部字段名")]
        [ExcelColumnName("连接到SOP上的CO/PA局部字段名")]
        public string Copam { get; set; }

        [ExcelColumn(Name = "周期盘点的盘点标识")]
        [ExcelColumnName("周期盘点的盘点标识")]
        public string Abcin { get; set; }

        [ExcelColumn(Name = "差异码")]
        [ExcelColumnName("差异码")]
        public string Awsls { get; set; }

        [ExcelColumn(Name = "序列号参数文件")]
        [ExcelColumnName("序列号参数文件")]
        public string Sernp { get; set; }

        [ExcelColumn(Name = "内部对象号")]
        [ExcelColumnName("内部对象号")]
        public int? Cuobj { get; set; }

        [ExcelColumn(Name = "可配置的物料")]
        [ExcelColumnName("可配置的物料")]
        public string Stdpd { get; set; }

        [ExcelColumn(Name = "重复生产参数文件")]
        [ExcelColumnName("重复生产参数文件")]
        public string Sfepr { get; set; }

        [ExcelColumn(Name = "工厂中允许负库存")]
        [ExcelColumnName("工厂中允许负库存")]
        public string Xmcng { get; set; }

        [ExcelColumn(Name = "要求的供应商质量管理系统")]
        [ExcelColumnName("要求的供应商质量管理系统")]
        public string Qssys { get; set; }

        [ExcelColumn(Name = "计划周期")]
        [ExcelColumnName("计划周期")]
        public string Lfrhy { get; set; }

        [ExcelColumn(Name = "舍入参数文件")]
        [ExcelColumnName("舍入参数文件")]
        public string Rdprf { get; set; }

        [ExcelColumn(Name = "消耗的参考物料")]
        [ExcelColumnName("消耗的参考物料")]
        public string Vrbmt { get; set; }

        [ExcelColumn(Name = "消耗的参考工厂")]
        [ExcelColumnName("消耗的参考工厂")]
        public string Vrbwk { get; set; }

        [ExcelColumn(Name = "到消耗物料将被复制的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("到消耗物料将被复制的日期")]
        public DateTime? Vrbdt { get; set; }

        [ExcelColumn(Name = "消耗的参考物料的乘数")]
        [ExcelColumnName("消耗的参考物料的乘数")]
        public decimal Vrbfk { get; set; }

        [ExcelColumn(Name = "自动重置预测模式")]
        [ExcelColumnName("自动重置预测模式")]
        public string Autru { get; set; }

        [ExcelColumn(Name = "进/出口中优惠指示符")]
        [ExcelColumnName("进/出口中优惠指示符")]
        public string Prefe { get; set; }

        [ExcelColumn(Name = "免税证明：法律控制指示符")]
        [ExcelColumnName("免税证明：法律控制指示符")]
        public string Prenc { get; set; }

        [ExcelColumn(Name = "法律控制的免税证书编号")]
        [ExcelColumnName("法律控制的免税证书编号")]
        public string Preno { get; set; }

        [ExcelColumn(Name = "免税证明：免税证书的发放日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("免税证明：免税证书的发放日")]
        public DateTime? Prend { get; set; }

        [ExcelColumn(Name = "标识：存在供应商申报")]
        [ExcelColumnName("标识：存在供应商申报")]
        public string Prene { get; set; }

        [ExcelColumn(Name = "供应商申报的有效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("供应商申报的有效日期")]
        public DateTime? Preng { get; set; }

        [ExcelColumn(Name = "指示符：军用物资")]
        [ExcelColumnName("指示符：军用物资")]
        public string Itark { get; set; }

        [ExcelColumn(Name = "IS－R服务级别")]
        [ExcelColumnName("IS－R服务级别")]
        public string Servg { get; set; }

        [ExcelColumn(Name = "指示符 : 物料是联产品")]
        [ExcelColumnName("指示符 : 物料是联产品")]
        public string Kzkup { get; set; }

        [ExcelColumn(Name = "计划策略组")]
        [ExcelColumnName("计划策略组")]
        public string Strgr { get; set; }

        [ExcelColumn(Name = "计划中的可配置物料的内部对象号")]
        [ExcelColumnName("计划中的可配置物料的内部对象号")]
        public int? Cuobv { get; set; }

        [Required(ErrorMessage = "外部采购的缺省仓储位置不能为空")]
        [ExcelColumn(Name = "外部采购的缺省仓储位置")]
        [ExcelColumnName("外部采购的缺省仓储位置")]
        public string Lgfsb { get; set; }

        [Required(ErrorMessage = "标识：散装物料不能为空")]
        [ExcelColumn(Name = "标识：散装物料")]
        [ExcelColumnName("标识：散装物料")]
        public string Schgt { get; set; }

        [ExcelColumn(Name = "周期标识被固定")]
        [ExcelColumnName("周期标识被固定")]
        public string Ccfix { get; set; }

        [ExcelColumn(Name = "库存确定组")]
        [ExcelColumnName("库存确定组")]
        public string Eprio { get; set; }

        [ExcelColumn(Name = "QM 中活动的物料授权组")]
        [ExcelColumnName("QM 中活动的物料授权组")]
        public string Qmata { get; set; }

        [ExcelColumn(Name = "计划独立需求的调整期间")]
        [ExcelColumnName("计划独立需求的调整期间")]
        public decimal Resvp { get; set; }

        [ExcelColumn(Name = "任务清单类型")]
        [ExcelColumnName("任务清单类型")]
        public string Plnty { get; set; }

        [ExcelColumn(Name = "计量组单位 (石油,天然气,...)")]
        [ExcelColumnName("计量组单位 (石油,天然气,...)")]
        public string Uomgr { get; set; }

        [ExcelColumn(Name = "转换组 (石油,天然气,..)")]
        [ExcelColumnName("转换组 (石油,天然气,..)")]
        public string Umrsl { get; set; }

        [ExcelColumn(Name = "空气浮力因子")]
        [ExcelColumnName("空气浮力因子")]
        public decimal Abfac { get; set; }

        [ExcelColumn(Name = "生产计划参数文件")]
        [ExcelColumnName("生产计划参数文件")]
        public string Sfcpf { get; set; }

        [ExcelColumn(Name = "安全时间标识（含或不含安全时间）")]
        [ExcelColumnName("安全时间标识（含或不含安全时间）")]
        public string Shflg { get; set; }

        [ExcelColumn(Name = "安全时间（按工作日计算）")]
        [ExcelColumnName("安全时间（按工作日计算）")]
        public int? Shzet { get; set; }

        [ExcelColumn(Name = "活动控制：计划订单处理")]
        [ExcelColumnName("活动控制：计划订单处理")]
        public string Mdach { get; set; }

        [ExcelColumn(Name = "在生产/处理订单中批量输入的确定")]
        [ExcelColumnName("在生产/处理订单中批量输入的确定")]
        public string Kzech { get; set; }

        [ExcelColumn(Name = "计量单位组")]
        [ExcelColumnName("计量单位组")]
        public string Megru { get; set; }

        [ExcelColumn(Name = "物料运输组")]
        [ExcelColumnName("物料运输组")]
        public string Mfrgr { get; set; }

        [ExcelColumn(Name = "VO 物料的库存转移销售值（工厂到工厂）")]
        [ExcelColumnName("VO 物料的库存转移销售值（工厂到工厂）")]
        public decimal Vkumc { get; set; }

        [ExcelColumn(Name = "仅记值物料的销售价格计的运输值")]
        [ExcelColumnName("仅记值物料的销售价格计的运输值")]
        public decimal Vktrw { get; set; }

        [ExcelColumn(Name = "指示符: 平滑促销消耗")]
        [ExcelColumnName("指示符: 平滑促销消耗")]
        public string Kzagl { get; set; }

        [ExcelColumn(Name = "将进行成本核算的生产版本")]
        [ExcelColumnName("将进行成本核算的生产版本")]
        public string Fvidk { get; set; }

        [ExcelColumn(Name = "固定价格联产品")]
        [ExcelColumnName("固定价格联产品")]
        public string Fxpru { get; set; }

        [ExcelColumn(Name = "用于计算工作负荷的后勤处理组")]
        [ExcelColumnName("用于计算工作负荷的后勤处理组")]
        public string Loggr { get; set; }

        [ExcelColumn(Name = "工厂物料分销参数文件")]
        [ExcelColumnName("工厂物料分销参数文件")]
        public string Fprfm { get; set; }

        [ExcelColumn(Name = "有约束的虚拟库存")]
        [ExcelColumnName("有约束的虚拟库存")]
        public decimal Glgmg { get; set; }

        [ExcelColumn(Name = "连接空缺库存的销售价")]
        [ExcelColumnName("连接空缺库存的销售价")]
        public decimal Vkglg { get; set; }

        [ExcelColumn(Name = "物料: CFOP类别")]
        [ExcelColumnName("物料: CFOP类别")]
        public string Indus { get; set; }

        [ExcelColumn(Name = "CAP：CAP 产品清单编号")]
        [ExcelColumnName("CAP：CAP 产品清单编号")]
        public string Mownr { get; set; }

        [ExcelColumn(Name = "共同农业市场政策：CAP 产品组－外贸")]
        [ExcelColumnName("共同农业市场政策：CAP 产品组－外贸")]
        public string Mogru { get; set; }

        [ExcelColumn(Name = "外贸药品 CAS 号码")]
        [ExcelColumnName("外贸药品 CAS 号码")]
        public string Casnr { get; set; }

        [ExcelColumn(Name = "生产统计：外贸 PRODCOM 号码")]
        [ExcelColumnName("生产统计：外贸 PRODCOM 号码")]
        public string Gpnum { get; set; }

        [ExcelColumn(Name = "对外贸易消费税控制代码")]
        [ExcelColumnName("对外贸易消费税控制代码")]
        public string Steuc { get; set; }

        [ExcelColumn(Name = "标识: 与 JIT 交货计划相关的物料")]
        [ExcelColumnName("标识: 与 JIT 交货计划相关的物料")]
        public string Fabkz { get; set; }

        [ExcelColumn(Name = "转换矩阵的物料组")]
        [ExcelColumnName("转换矩阵的物料组")]
        public string Matgr { get; set; }

        [ExcelColumn(Name = "物料主记录中建议的供应区域")]
        [ExcelColumnName("物料主记录中建议的供应区域")]
        public string Vspvb { get; set; }

        [ExcelColumn(Name = "公平分享规则")]
        [ExcelColumnName("公平分享规则")]
        public string Dplfs { get; set; }

        [ExcelColumn(Name = "指示器:推式分配")]
        [ExcelColumnName("指示器:推式分配")]
        public string Dplpu { get; set; }

        [ExcelColumn(Name = "发布的天数界限")]
        [ExcelColumnName("发布的天数界限")]
        public decimal Dplho { get; set; }

        [ExcelColumn(Name = "匹配供应量的最小批尺寸")]
        [ExcelColumnName("匹配供应量的最小批尺寸")]
        public decimal Minls { get; set; }

        [ExcelColumn(Name = "匹配供应需求的最大批尺寸")]
        [ExcelColumnName("匹配供应需求的最大批尺寸")]
        public decimal Maxls { get; set; }

        [ExcelColumn(Name = "匹配供应需求的固定批大小")]
        [ExcelColumnName("匹配供应需求的固定批大小")]
        public decimal Fixls { get; set; }

        [ExcelColumn(Name = "匹配供应需求增加批尺寸")]
        [ExcelColumnName("匹配供应需求增加批尺寸")]
        public decimal Ltinc { get; set; }

        [ExcelColumn(Name = "该字段不再使用")]
        [ExcelColumnName("该字段不再使用")]
        public int? Compl { get; set; }

        [ExcelColumn(Name = "用于生产指标的转换类型")]
        [ExcelColumnName("用于生产指标的转换类型")]
        public string Convt { get; set; }

        [ExcelColumn(Name = "安全时间的期间参数文件")]
        [ExcelColumnName("安全时间的期间参数文件")]
        public string Shpro { get; set; }

        [ExcelColumn(Name = "相关需求的 MRP  关联")]
        [ExcelColumnName("相关需求的 MRP  关联")]
        public string Ahdis { get; set; }

        [ExcelColumn(Name = "指示：MRP  范围存在")]
        [ExcelColumnName("指示：MRP  范围存在")]
        public string Diber { get; set; }

        [ExcelColumn(Name = "跨项目物料指示符")]
        [ExcelColumnName("跨项目物料指示符")]
        public string Kzpsp { get; set; }

        [ExcelColumn(Name = "订单更改管理的总体参数文件")]
        [ExcelColumnName("订单更改管理的总体参数文件")]
        public string Ocmpf { get; set; }

        [ExcelColumn(Name = "指示：物料是否与 APO 相关")]
        [ExcelColumnName("指示：物料是否与 APO 相关")]
        public string Apokz { get; set; }

        [ExcelColumn(Name = "最后的MARD 期间之前，MARDH 记录已经存在")]
        [ExcelColumnName("最后的MARD 期间之前，MARDH 记录已经存在")]
        public string Mcrue { get; set; }

        [ExcelColumn(Name = "当前期间 (记帐期间)")]
        [ExcelColumnName("当前期间 (记帐期间)")]
        public int? Lfmon { get; set; }

        [ExcelColumn(Name = "当前期间的会计年度")]
        [ExcelColumnName("当前期间的会计年度")]
        public int? Lfgja { get; set; }

        [ExcelColumn(Name = "最小安全库存")]
        [ExcelColumnName("最小安全库存")]
        public decimal Eislo { get; set; }

        [ExcelColumn(Name = "无成本核算")]
        [ExcelColumnName("无成本核算")]
        public string Ncost { get; set; }

        [ExcelColumn(Name = "库存入库和库存出库的策略")]
        [ExcelColumnName("库存入库和库存出库的策略")]
        public string Rotationdate { get; set; }

        [ExcelColumn(Name = "初始批次管理的标识")]
        [ExcelColumnName("初始批次管理的标识")]
        public string Uchkz { get; set; }

        [ExcelColumn(Name = "初始批量的参考物料")]
        [ExcelColumnName("初始批量的参考物料")]
        public string Ucmat { get; set; }

        [ExcelColumn(Name = "评估的收货锁定库存")]
        [ExcelColumnName("评估的收货锁定库存")]
        public decimal Bwesb { get; set; }

        [ExcelColumn(Name = "分段策略")]
        [ExcelColumnName("分段策略")]
        public string Sgtcovs { get; set; }

        [ExcelColumn(Name = "分段状态")]
        [ExcelColumnName("分段状态")]
        public string Sgtstatc { get; set; }

        [ExcelColumn(Name = "分段策略范围")]
        [ExcelColumnName("分段策略范围")]
        public string Sgtscope { get; set; }

        [ExcelColumn(Name = "根据交货日期或段排序库存")]
        [ExcelColumnName("根据交货日期或段排序库存")]
        public string Sgtmrpsi { get; set; }

        [ExcelColumn(Name = "消耗优先级")]
        [ExcelColumnName("消耗优先级")]
        public string Sgtprcm { get; set; }

        [ExcelColumn(Name = "离散批次编号")]
        [ExcelColumnName("离散批次编号")]
        public string Sgtchint { get; set; }

        [ExcelColumn(Name = "库存保护标识")]
        [ExcelColumnName("库存保护标识")]
        public string Sgtstkprt { get; set; }

        [ExcelColumn(Name = "订单分配运行")]
        [ExcelColumnName("订单分配运行")]
        public string Fshmgarunreq { get; set; }

        [ExcelColumn(Name = "标识：在库存管理中激活季节")]
        [ExcelColumnName("标识：在库存管理中激活季节")]
        public string Fshseaim { get; set; }

        [ExcelColumn(Name = "物料的包装组 (VSO)")]
        [ExcelColumnName("物料的包装组 (VSO)")]
        public string Vsorpkgrp { get; set; }

        [ExcelColumn(Name = "自动提货区域内的行 (VSO)")]
        [ExcelColumnName("自动提货区域内的行 (VSO)")]
        public string Vsorlanenum { get; set; }

        [ExcelColumn(Name = "供应商包装物料的物料编号 (VSO)")]
        [ExcelColumnName("供应商包装物料的物料编号 (VSO)")]
        public string Vsorpalvend { get; set; }

        [ExcelColumn(Name = "仅纵向提取包装物料 (VSO)")]
        [ExcelColumnName("仅纵向提取包装物料 (VSO)")]
        public string Vsorforkdir { get; set; }

        [ExcelColumn(Name = "项目唯一标识相关")]
        [ExcelColumnName("项目唯一标识相关")]
        public string Iuidrelevant { get; set; }

        [ExcelColumn(Name = "唯一项目标识的结构类型")]
        [ExcelColumnName("唯一项目标识的结构类型")]
        public string Iuidtype { get; set; }

        [ExcelColumn(Name = "UII 的外部分配")]
        [ExcelColumnName("UII 的外部分配")]
        public string Uidiea { get; set; }

        [ExcelColumn(Name = "寄售控制")]
        [ExcelColumnName("寄售控制")]
        public string Consprocg { get; set; }

        [ExcelColumn(Name = "按天数发货处理时间")]
        [ExcelColumnName("按天数发货处理时间")]
        public decimal Giprtime { get; set; }

        [ExcelColumn(Name = "采购交叉的采购组")]
        [ExcelColumnName("采购交叉的采购组")]
        public string Multipleekgrp { get; set; }

        [ExcelColumn(Name = "参考确定方案")]
        [ExcelColumnName("参考确定方案")]
        public string Refschema { get; set; }

        [ExcelColumn(Name = "覆盖的最小目标范围")]
        [ExcelColumnName("覆盖的最小目标范围")]
        public int? Mintroc { get; set; }

        [ExcelColumn(Name = "覆盖的最大目标范围")]
        [ExcelColumnName("覆盖的最大目标范围")]
        public int? Maxtroc { get; set; }

        [ExcelColumn(Name = "目标库存")]
        [ExcelColumnName("目标库存")]
        public decimal Targetstock { get; set; }

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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "工厂")]
        public string WerksLabel { get; set; }

        [ExcelColumn(Name = "在工厂级标记要删除的物料")]
        public string LvormLabel { get; set; }

        [ExcelColumn(Name = "采购组")]
        public string EkgrpLabel { get; set; }

        [ExcelColumn(Name = "采购类型")]
        public string BeskzLabel { get; set; }

        [ExcelColumn(Name = "特殊采购类型")]
        public string SobslLabel { get; set; }

        [ExcelColumn(Name = "过帐到检验库存")]
        public string InsmkLabel { get; set; }

        [ExcelColumn(Name = "对象类型")]
        public string OtypeLabel { get; set; }

        [ExcelColumn(Name = "利润中心")]
        public string PrctrLabel { get; set; }

        [ExcelColumn(Name = "发货库存地点")]
        public string LgproLabel { get; set; }
    }

    /// <summary>
    /// 工厂物料
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:45:06
    /// </summary>
    public class MmMarcImportTpl
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

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Werks { get; set; }

        [ExcelColumn(Name = "维护状态")]
        [ExcelColumnName("维护状态")]
        public string Pstat { get; set; }

        [Required(ErrorMessage = "在工厂级标记要删除的物料不能为空")]
        [ExcelColumn(Name = "在工厂级标记要删除的物料")]
        [ExcelColumnName("在工厂级标记要删除的物料")]
        public string Lvorm { get; set; }

        [ExcelColumn(Name = "评估类别")]
        [ExcelColumnName("评估类别")]
        public string Bwtty { get; set; }

        [ExcelColumn(Name = "批量管理标识(内部)")]
        [ExcelColumnName("批量管理标识(内部)")]
        public string Xchar { get; set; }

        [ExcelColumn(Name = "工厂特定的物料状态")]
        [ExcelColumnName("工厂特定的物料状态")]
        public string Mmsta { get; set; }

        [ExcelColumn(Name = "工厂特定物料状态有效的起始日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("工厂特定物料状态有效的起始日期")]
        public DateTime? Mmstd { get; set; }

        [ExcelColumn(Name = "ABC标识")]
        [ExcelColumnName("ABC标识")]
        public string Maabc { get; set; }

        [ExcelColumn(Name = "标志：关键部件")]
        [ExcelColumnName("标志：关键部件")]
        public string Kzkri { get; set; }

        [Required(ErrorMessage = "采购组不能为空")]
        [ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string Ekgrp { get; set; }

        [ExcelColumn(Name = "发货单位")]
        [ExcelColumnName("发货单位")]
        public string Ausme { get; set; }

        [ExcelColumn(Name = "物料: MRP 参数文件")]
        [ExcelColumnName("物料: MRP 参数文件")]
        public string Dispr { get; set; }

        [ExcelColumn(Name = "物料需求计划类型")]
        [ExcelColumnName("物料需求计划类型")]
        public string Dismm { get; set; }

        [ExcelColumn(Name = "MRP 控制者（物料计划人）")]
        [ExcelColumnName("MRP 控制者（物料计划人）")]
        public string Dispo { get; set; }

        [ExcelColumn(Name = "标识: MRP控制者是买方(未激活的)")]
        [ExcelColumnName("标识: MRP控制者是买方(未激活的)")]
        public string Kzdie { get; set; }

        [ExcelColumn(Name = "计划的天数内交货")]
        [ExcelColumnName("计划的天数内交货")]
        public decimal Plifz { get; set; }

        [ExcelColumn(Name = "以天计的收货处理时间")]
        [ExcelColumnName("以天计的收货处理时间")]
        public decimal Webaz { get; set; }

        [ExcelColumn(Name = "期间标识")]
        [ExcelColumnName("期间标识")]
        public string Perkz { get; set; }

        [ExcelColumn(Name = "装配报废百分比")]
        [ExcelColumnName("装配报废百分比")]
        public decimal Ausss { get; set; }

        [ExcelColumn(Name = "批量 (物料计划)")]
        [ExcelColumnName("批量 (物料计划)")]
        public string Disls { get; set; }

        [Required(ErrorMessage = "采购类型不能为空")]
        [ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string Beskz { get; set; }

        [Required(ErrorMessage = "特殊采购类型不能为空")]
        [ExcelColumn(Name = "特殊采购类型")]
        [ExcelColumnName("特殊采购类型")]
        public string Sobsl { get; set; }

        [ExcelColumn(Name = "再订货点")]
        [ExcelColumnName("再订货点")]
        public decimal Minbe { get; set; }

        [ExcelColumn(Name = "安全库存")]
        [ExcelColumnName("安全库存")]
        public decimal Eisbe { get; set; }

        [ExcelColumn(Name = "最小批量")]
        [ExcelColumnName("最小批量")]
        public decimal Bstmi { get; set; }

        [ExcelColumn(Name = "最大批量大小")]
        [ExcelColumnName("最大批量大小")]
        public decimal Bstma { get; set; }

        [ExcelColumn(Name = "固定批量大小")]
        [ExcelColumnName("固定批量大小")]
        public decimal Bstfe { get; set; }

        [ExcelColumn(Name = "采购订单数量的舍入值")]
        [ExcelColumnName("采购订单数量的舍入值")]
        public decimal Bstrf { get; set; }

        [ExcelColumn(Name = "最大库存水平")]
        [ExcelColumnName("最大库存水平")]
        public decimal Mabst { get; set; }

        [ExcelColumn(Name = "订购成本")]
        [ExcelColumnName("订购成本")]
        public decimal Losfx { get; set; }

        [ExcelColumn(Name = "对于独立和集中需求的相关需求标识")]
        [ExcelColumnName("对于独立和集中需求的相关需求标识")]
        public string Sbdkz { get; set; }

        [ExcelColumn(Name = "库存成本标识")]
        [ExcelColumnName("库存成本标识")]
        public string Lagpr { get; set; }

        [ExcelColumn(Name = "选择可替换物料单的方法")]
        [ExcelColumnName("选择可替换物料单的方法")]
        public string Altsl { get; set; }

        [ExcelColumn(Name = "中止指示符")]
        [ExcelColumnName("中止指示符")]
        public string Kzaus { get; set; }

        [ExcelColumn(Name = "中断日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("中断日期")]
        public DateTime? Ausdt { get; set; }

        [ExcelColumn(Name = "后续物料")]
        [ExcelColumnName("后续物料")]
        public string Nfmat { get; set; }

        [ExcelColumn(Name = "需求分组指示符")]
        [ExcelColumnName("需求分组指示符")]
        public string Kzbed { get; set; }

        [ExcelColumn(Name = "综合MRP标识")]
        [ExcelColumnName("综合MRP标识")]
        public string Miskz { get; set; }

        [ExcelColumn(Name = "浮动的计划边际码")]
        [ExcelColumnName("浮动的计划边际码")]
        public string Fhori { get; set; }

        [ExcelColumn(Name = "标识: 计划订单的自动修正")]
        [ExcelColumnName("标识: 计划订单的自动修正")]
        public string Pfrei { get; set; }

        [ExcelColumn(Name = "用于生产订单的批准标识")]
        [ExcelColumnName("用于生产订单的批准标识")]
        public string Ffrei { get; set; }

        [ExcelColumn(Name = "标识：反冲")]
        [ExcelColumnName("标识：反冲")]
        public string Rgekz { get; set; }

        [ExcelColumn(Name = "生产管理员")]
        [ExcelColumnName("生产管理员")]
        public string Fevor { get; set; }

        [ExcelColumn(Name = "处理时间")]
        [ExcelColumnName("处理时间")]
        public decimal Bearz { get; set; }

        [ExcelColumn(Name = "建立和拆卸时间")]
        [ExcelColumnName("建立和拆卸时间")]
        public decimal Ruezt { get; set; }

        [ExcelColumn(Name = "工序间时间")]
        [ExcelColumnName("工序间时间")]
        public decimal Tranz { get; set; }

        [ExcelColumn(Name = "基准数量")]
        [ExcelColumnName("基准数量")]
        public decimal Basmg { get; set; }

        [ExcelColumn(Name = "厂内生产时间")]
        [ExcelColumnName("厂内生产时间")]
        public decimal Dzeit { get; set; }

        [ExcelColumn(Name = "最大存储期间")]
        [ExcelColumnName("最大存储期间")]
        public decimal Maxlz { get; set; }

        [ExcelColumn(Name = "最大库存期间单位")]
        [ExcelColumnName("最大库存期间单位")]
        public string Lzeih { get; set; }

        [ExcelColumn(Name = "标识: 从生产区的库存提取")]
        [ExcelColumnName("标识: 从生产区的库存提取")]
        public string Kzpro { get; set; }

        [ExcelColumn(Name = "标识: 在初步计划中包括的物料")]
        [ExcelColumnName("标识: 在初步计划中包括的物料")]
        public string Gpmkz { get; set; }

        [ExcelColumn(Name = "超量交货容差限制")]
        [ExcelColumnName("超量交货容差限制")]
        public decimal Ueeto { get; set; }

        [ExcelColumn(Name = "标识：允许未限制的过量交货")]
        [ExcelColumnName("标识：允许未限制的过量交货")]
        public string Ueetk { get; set; }

        [ExcelColumn(Name = "不足交货容差限制")]
        [ExcelColumnName("不足交货容差限制")]
        public decimal Uneto { get; set; }

        [ExcelColumn(Name = "总计补货提前时间(按工作日)")]
        [ExcelColumnName("总计补货提前时间(按工作日)")]
        public decimal Wzeit { get; set; }

        [ExcelColumn(Name = "替换部件")]
        [ExcelColumnName("替换部件")]
        public string Atpkz { get; set; }

        [ExcelColumn(Name = "用百分比表示的成本的附加因子")]
        [ExcelColumnName("用百分比表示的成本的附加因子")]
        public decimal Vzusl { get; set; }

        [ExcelColumn(Name = "生产状态")]
        [ExcelColumnName("生产状态")]
        public string Herbl { get; set; }

        [Required(ErrorMessage = "过帐到检验库存不能为空")]
        [ExcelColumn(Name = "过帐到检验库存")]
        [ExcelColumnName("过帐到检验库存")]
        public string Insmk { get; set; }

        [ExcelColumn(Name = "质量检查的样本(在%中)(取消激活)")]
        [ExcelColumnName("质量检查的样本(在%中)(取消激活)")]
        public decimal Sproz { get; set; }

        [ExcelColumn(Name = "隔离期(未激活)")]
        [ExcelColumnName("隔离期(未激活)")]
        public decimal Quazt { get; set; }

        [ExcelColumn(Name = "采购中质量管理的控制码")]
        [ExcelColumnName("采购中质量管理的控制码")]
        public string Ssqss { get; set; }

        [ExcelColumn(Name = "平均检查持续期间(未激活的的)")]
        [ExcelColumnName("平均检查持续期间(未激活的的)")]
        public decimal Mpdau { get; set; }

        [ExcelColumn(Name = "检查计划的标识(未激活)")]
        [ExcelColumnName("检查计划的标识(未激活)")]
        public string Kzppv { get; set; }

        [ExcelColumn(Name = "凭证需求标识")]
        [ExcelColumnName("凭证需求标识")]
        public string Kzdkz { get; set; }

        [ExcelColumn(Name = "活动性物质内容(未激活的)")]
        [ExcelColumnName("活动性物质内容(未激活的)")]
        public decimal Wstgh { get; set; }

        [ExcelColumn(Name = "循环检查间隔")]
        [ExcelColumnName("循环检查间隔")]
        public decimal Prfrq { get; set; }

        [ExcelColumn(Name = "根据检验抽样检查的日期(取消激活)", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("根据检验抽样检查的日期(取消激活)")]
        public DateTime? Nkmpr { get; set; }

        [ExcelColumn(Name = "中转库存（工厂到工厂）")]
        [ExcelColumnName("中转库存（工厂到工厂）")]
        public decimal Umlmc { get; set; }

        [ExcelColumn(Name = "装载组")]
        [ExcelColumnName("装载组")]
        public string Ladgr { get; set; }

        [ExcelColumn(Name = "批次管理需求的标识")]
        [ExcelColumnName("批次管理需求的标识")]
        public string Xchpf { get; set; }

        [ExcelColumn(Name = "配额分配使用")]
        [ExcelColumnName("配额分配使用")]
        public string Usequ { get; set; }

        [ExcelColumn(Name = "服务水平")]
        [ExcelColumnName("服务水平")]
        public decimal Lgrad { get; set; }

        [ExcelColumn(Name = "分割标识")]
        [ExcelColumnName("分割标识")]
        public string Auftl { get; set; }

        [ExcelColumn(Name = "计划版本")]
        [ExcelColumnName("计划版本")]
        public string Plvar { get; set; }

        [ExcelColumn(Name = "对象类型")]
        [ExcelColumnName("对象类型")]
        public string Otype { get; set; }

        [ExcelColumn(Name = "对象标识")]
        [ExcelColumnName("对象标识")]
        public int? Objid { get; set; }

        [ExcelColumn(Name = "可用性检查的检查组")]
        [ExcelColumnName("可用性检查的检查组")]
        public string Mtvfp { get; set; }

        [ExcelColumn(Name = "会计年度变式")]
        [ExcelColumnName("会计年度变式")]
        public string Periv { get; set; }

        [ExcelColumn(Name = "标识: 考虑修正因子")]
        [ExcelColumnName("标识: 考虑修正因子")]
        public string Kzkfk { get; set; }

        [ExcelColumn(Name = "装运建立时间")]
        [ExcelColumnName("装运建立时间")]
        public decimal Vrvez { get; set; }

        [ExcelColumn(Name = "在装运中有关能力计划的基准数量")]
        [ExcelColumnName("在装运中有关能力计划的基准数量")]
        public decimal Vbamg { get; set; }

        [ExcelColumn(Name = "处理时间: 装运")]
        [ExcelColumnName("处理时间: 装运")]
        public decimal Vbeaz { get; set; }

        [ExcelColumn(Name = "取消激活的")]
        [ExcelColumnName("取消激活的")]
        public string Lizyk { get; set; }

        [ExcelColumn(Name = "货源")]
        [ExcelColumnName("货源")]
        public string Bwscl { get; set; }

        [Required(ErrorMessage = "标识: 允许自动采购订单不能为空")]
        [ExcelColumn(Name = "标识: 允许自动采购订单")]
        [ExcelColumnName("标识: 允许自动采购订单")]
        public string Kautb { get; set; }

        [Required(ErrorMessage = "标识: 源清单要求不能为空")]
        [ExcelColumn(Name = "标识: 源清单要求")]
        [ExcelColumnName("标识: 源清单要求")]
        public string Kordb { get; set; }

        [ExcelColumn(Name = "外贸的商品代码和进口代码")]
        [ExcelColumnName("外贸的商品代码和进口代码")]
        public string Stawn { get; set; }

        [ExcelColumn(Name = "物料原产地国家")]
        [ExcelColumnName("物料原产地国家")]
        public string Herkl { get; set; }

        [ExcelColumn(Name = "物料原产地（非特惠货源）")]
        [ExcelColumnName("物料原产地（非特惠货源）")]
        public string Herkr { get; set; }

        [ExcelColumn(Name = "商品代码的计量单位(外贸)")]
        [ExcelColumnName("商品代码的计量单位(外贸)")]
        public string Expme { get; set; }

        [ExcelColumn(Name = "出口/进口物料组")]
        [ExcelColumnName("出口/进口物料组")]
        public string Mtver { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        [ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string Prctr { get; set; }

        [ExcelColumn(Name = "在途库存")]
        [ExcelColumnName("在途库存")]
        public decimal Trame { get; set; }

        [ExcelColumn(Name = "PPC 计划日历")]
        [ExcelColumnName("PPC 计划日历")]
        public string Mrppp { get; set; }

        [ExcelColumn(Name = "标识: 允许的重复制造")]
        [ExcelColumnName("标识: 允许的重复制造")]
        public string Sauft { get; set; }

        [ExcelColumn(Name = "计划的时界")]
        [ExcelColumnName("计划的时界")]
        public int? Fxhor { get; set; }

        [ExcelColumn(Name = "消耗模式")]
        [ExcelColumnName("消耗模式")]
        public string Vrmod { get; set; }

        [ExcelColumn(Name = "消耗期间:逆向")]
        [ExcelColumnName("消耗期间:逆向")]
        public int? Vint1 { get; set; }

        [ExcelColumn(Name = "消耗时期-向前")]
        [ExcelColumnName("消耗时期-向前")]
        public int? Vint2 { get; set; }

        [ExcelColumn(Name = "版本标识符")]
        [ExcelColumnName("版本标识符")]
        public string Verkz { get; set; }

        [ExcelColumn(Name = "可选的 BOM")]
        [ExcelColumnName("可选的 BOM")]
        public string Stlal { get; set; }

        [ExcelColumn(Name = "BOM 用途")]
        [ExcelColumnName("BOM 用途")]
        public string Stlan { get; set; }

        [ExcelColumn(Name = "任务清单组码")]
        [ExcelColumnName("任务清单组码")]
        public string Plnnr { get; set; }

        [ExcelColumn(Name = "组计数器")]
        [ExcelColumnName("组计数器")]
        public string Aplal { get; set; }

        [ExcelColumn(Name = "批量产品成本核算")]
        [ExcelColumnName("批量产品成本核算")]
        public decimal Losgr { get; set; }

        [ExcelColumn(Name = "成本核算的特殊采购类型")]
        [ExcelColumnName("成本核算的特殊采购类型")]
        public string Sobsk { get; set; }

        [ExcelColumn(Name = "生产单位")]
        [ExcelColumnName("生产单位")]
        public string Frtme { get; set; }

        [Required(ErrorMessage = "发货库存地点不能为空")]
        [ExcelColumn(Name = "发货库存地点")]
        [ExcelColumnName("发货库存地点")]
        public string Lgpro { get; set; }

        [ExcelColumn(Name = "物料需求计划组")]
        [ExcelColumnName("物料需求计划组")]
        public string Disgr { get; set; }

        [ExcelColumn(Name = "部件废品百分数")]
        [ExcelColumnName("部件废品百分数")]
        public decimal Kausf { get; set; }

        [ExcelColumn(Name = "证书类型")]
        [ExcelColumnName("证书类型")]
        public string Qzgtp { get; set; }

        [ExcelColumn(Name = "物料/工厂的检验设置存在")]
        [ExcelColumnName("物料/工厂的检验设置存在")]
        public string Qmatv { get; set; }

        [ExcelColumn(Name = "间隔时间（多个计划订单分阶段生产时，计划订单之间的间隔时间)")]
        [ExcelColumnName("间隔时间（多个计划订单分阶段生产时，计划订单之间的间隔时间)")]
        public decimal Takzt { get; set; }

        [ExcelColumn(Name = "供货天数参数文件")]
        [ExcelColumnName("供货天数参数文件")]
        public string Rwpro { get; set; }

        [ExcelColumn(Name = "连接到SOP上的CO/PA局部字段名")]
        [ExcelColumnName("连接到SOP上的CO/PA局部字段名")]
        public string Copam { get; set; }

        [ExcelColumn(Name = "周期盘点的盘点标识")]
        [ExcelColumnName("周期盘点的盘点标识")]
        public string Abcin { get; set; }

        [ExcelColumn(Name = "差异码")]
        [ExcelColumnName("差异码")]
        public string Awsls { get; set; }

        [ExcelColumn(Name = "序列号参数文件")]
        [ExcelColumnName("序列号参数文件")]
        public string Sernp { get; set; }

        [ExcelColumn(Name = "内部对象号")]
        [ExcelColumnName("内部对象号")]
        public int? Cuobj { get; set; }

        [ExcelColumn(Name = "可配置的物料")]
        [ExcelColumnName("可配置的物料")]
        public string Stdpd { get; set; }

        [ExcelColumn(Name = "重复生产参数文件")]
        [ExcelColumnName("重复生产参数文件")]
        public string Sfepr { get; set; }

        [ExcelColumn(Name = "工厂中允许负库存")]
        [ExcelColumnName("工厂中允许负库存")]
        public string Xmcng { get; set; }

        [ExcelColumn(Name = "要求的供应商质量管理系统")]
        [ExcelColumnName("要求的供应商质量管理系统")]
        public string Qssys { get; set; }

        [ExcelColumn(Name = "计划周期")]
        [ExcelColumnName("计划周期")]
        public string Lfrhy { get; set; }

        [ExcelColumn(Name = "舍入参数文件")]
        [ExcelColumnName("舍入参数文件")]
        public string Rdprf { get; set; }

        [ExcelColumn(Name = "消耗的参考物料")]
        [ExcelColumnName("消耗的参考物料")]
        public string Vrbmt { get; set; }

        [ExcelColumn(Name = "消耗的参考工厂")]
        [ExcelColumnName("消耗的参考工厂")]
        public string Vrbwk { get; set; }

        [ExcelColumn(Name = "到消耗物料将被复制的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("到消耗物料将被复制的日期")]
        public DateTime? Vrbdt { get; set; }

        [ExcelColumn(Name = "消耗的参考物料的乘数")]
        [ExcelColumnName("消耗的参考物料的乘数")]
        public decimal Vrbfk { get; set; }

        [ExcelColumn(Name = "自动重置预测模式")]
        [ExcelColumnName("自动重置预测模式")]
        public string Autru { get; set; }

        [ExcelColumn(Name = "进/出口中优惠指示符")]
        [ExcelColumnName("进/出口中优惠指示符")]
        public string Prefe { get; set; }

        [ExcelColumn(Name = "免税证明：法律控制指示符")]
        [ExcelColumnName("免税证明：法律控制指示符")]
        public string Prenc { get; set; }

        [ExcelColumn(Name = "法律控制的免税证书编号")]
        [ExcelColumnName("法律控制的免税证书编号")]
        public string Preno { get; set; }

        [ExcelColumn(Name = "免税证明：免税证书的发放日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("免税证明：免税证书的发放日")]
        public DateTime? Prend { get; set; }

        [ExcelColumn(Name = "标识：存在供应商申报")]
        [ExcelColumnName("标识：存在供应商申报")]
        public string Prene { get; set; }

        [ExcelColumn(Name = "供应商申报的有效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("供应商申报的有效日期")]
        public DateTime? Preng { get; set; }

        [ExcelColumn(Name = "指示符：军用物资")]
        [ExcelColumnName("指示符：军用物资")]
        public string Itark { get; set; }

        [ExcelColumn(Name = "IS－R服务级别")]
        [ExcelColumnName("IS－R服务级别")]
        public string Servg { get; set; }

        [ExcelColumn(Name = "指示符 : 物料是联产品")]
        [ExcelColumnName("指示符 : 物料是联产品")]
        public string Kzkup { get; set; }

        [ExcelColumn(Name = "计划策略组")]
        [ExcelColumnName("计划策略组")]
        public string Strgr { get; set; }

        [ExcelColumn(Name = "计划中的可配置物料的内部对象号")]
        [ExcelColumnName("计划中的可配置物料的内部对象号")]
        public int? Cuobv { get; set; }

        [Required(ErrorMessage = "外部采购的缺省仓储位置不能为空")]
        [ExcelColumn(Name = "外部采购的缺省仓储位置")]
        [ExcelColumnName("外部采购的缺省仓储位置")]
        public string Lgfsb { get; set; }

        [Required(ErrorMessage = "标识：散装物料不能为空")]
        [ExcelColumn(Name = "标识：散装物料")]
        [ExcelColumnName("标识：散装物料")]
        public string Schgt { get; set; }

        [ExcelColumn(Name = "周期标识被固定")]
        [ExcelColumnName("周期标识被固定")]
        public string Ccfix { get; set; }

        [ExcelColumn(Name = "库存确定组")]
        [ExcelColumnName("库存确定组")]
        public string Eprio { get; set; }

        [ExcelColumn(Name = "QM 中活动的物料授权组")]
        [ExcelColumnName("QM 中活动的物料授权组")]
        public string Qmata { get; set; }

        [ExcelColumn(Name = "计划独立需求的调整期间")]
        [ExcelColumnName("计划独立需求的调整期间")]
        public decimal Resvp { get; set; }

        [ExcelColumn(Name = "任务清单类型")]
        [ExcelColumnName("任务清单类型")]
        public string Plnty { get; set; }

        [ExcelColumn(Name = "计量组单位 (石油,天然气,...)")]
        [ExcelColumnName("计量组单位 (石油,天然气,...)")]
        public string Uomgr { get; set; }

        [ExcelColumn(Name = "转换组 (石油,天然气,..)")]
        [ExcelColumnName("转换组 (石油,天然气,..)")]
        public string Umrsl { get; set; }

        [ExcelColumn(Name = "空气浮力因子")]
        [ExcelColumnName("空气浮力因子")]
        public decimal Abfac { get; set; }

        [ExcelColumn(Name = "生产计划参数文件")]
        [ExcelColumnName("生产计划参数文件")]
        public string Sfcpf { get; set; }

        [ExcelColumn(Name = "安全时间标识（含或不含安全时间）")]
        [ExcelColumnName("安全时间标识（含或不含安全时间）")]
        public string Shflg { get; set; }

        [ExcelColumn(Name = "安全时间（按工作日计算）")]
        [ExcelColumnName("安全时间（按工作日计算）")]
        public int? Shzet { get; set; }

        [ExcelColumn(Name = "活动控制：计划订单处理")]
        [ExcelColumnName("活动控制：计划订单处理")]
        public string Mdach { get; set; }

        [ExcelColumn(Name = "在生产/处理订单中批量输入的确定")]
        [ExcelColumnName("在生产/处理订单中批量输入的确定")]
        public string Kzech { get; set; }

        [ExcelColumn(Name = "计量单位组")]
        [ExcelColumnName("计量单位组")]
        public string Megru { get; set; }

        [ExcelColumn(Name = "物料运输组")]
        [ExcelColumnName("物料运输组")]
        public string Mfrgr { get; set; }

        [ExcelColumn(Name = "VO 物料的库存转移销售值（工厂到工厂）")]
        [ExcelColumnName("VO 物料的库存转移销售值（工厂到工厂）")]
        public decimal Vkumc { get; set; }

        [ExcelColumn(Name = "仅记值物料的销售价格计的运输值")]
        [ExcelColumnName("仅记值物料的销售价格计的运输值")]
        public decimal Vktrw { get; set; }

        [ExcelColumn(Name = "指示符: 平滑促销消耗")]
        [ExcelColumnName("指示符: 平滑促销消耗")]
        public string Kzagl { get; set; }

        [ExcelColumn(Name = "将进行成本核算的生产版本")]
        [ExcelColumnName("将进行成本核算的生产版本")]
        public string Fvidk { get; set; }

        [ExcelColumn(Name = "固定价格联产品")]
        [ExcelColumnName("固定价格联产品")]
        public string Fxpru { get; set; }

        [ExcelColumn(Name = "用于计算工作负荷的后勤处理组")]
        [ExcelColumnName("用于计算工作负荷的后勤处理组")]
        public string Loggr { get; set; }

        [ExcelColumn(Name = "工厂物料分销参数文件")]
        [ExcelColumnName("工厂物料分销参数文件")]
        public string Fprfm { get; set; }

        [ExcelColumn(Name = "有约束的虚拟库存")]
        [ExcelColumnName("有约束的虚拟库存")]
        public decimal Glgmg { get; set; }

        [ExcelColumn(Name = "连接空缺库存的销售价")]
        [ExcelColumnName("连接空缺库存的销售价")]
        public decimal Vkglg { get; set; }

        [ExcelColumn(Name = "物料: CFOP类别")]
        [ExcelColumnName("物料: CFOP类别")]
        public string Indus { get; set; }

        [ExcelColumn(Name = "CAP：CAP 产品清单编号")]
        [ExcelColumnName("CAP：CAP 产品清单编号")]
        public string Mownr { get; set; }

        [ExcelColumn(Name = "共同农业市场政策：CAP 产品组－外贸")]
        [ExcelColumnName("共同农业市场政策：CAP 产品组－外贸")]
        public string Mogru { get; set; }

        [ExcelColumn(Name = "外贸药品 CAS 号码")]
        [ExcelColumnName("外贸药品 CAS 号码")]
        public string Casnr { get; set; }

        [ExcelColumn(Name = "生产统计：外贸 PRODCOM 号码")]
        [ExcelColumnName("生产统计：外贸 PRODCOM 号码")]
        public string Gpnum { get; set; }

        [ExcelColumn(Name = "对外贸易消费税控制代码")]
        [ExcelColumnName("对外贸易消费税控制代码")]
        public string Steuc { get; set; }

        [ExcelColumn(Name = "标识: 与 JIT 交货计划相关的物料")]
        [ExcelColumnName("标识: 与 JIT 交货计划相关的物料")]
        public string Fabkz { get; set; }

        [ExcelColumn(Name = "转换矩阵的物料组")]
        [ExcelColumnName("转换矩阵的物料组")]
        public string Matgr { get; set; }

        [ExcelColumn(Name = "物料主记录中建议的供应区域")]
        [ExcelColumnName("物料主记录中建议的供应区域")]
        public string Vspvb { get; set; }

        [ExcelColumn(Name = "公平分享规则")]
        [ExcelColumnName("公平分享规则")]
        public string Dplfs { get; set; }

        [ExcelColumn(Name = "指示器:推式分配")]
        [ExcelColumnName("指示器:推式分配")]
        public string Dplpu { get; set; }

        [ExcelColumn(Name = "发布的天数界限")]
        [ExcelColumnName("发布的天数界限")]
        public decimal Dplho { get; set; }

        [ExcelColumn(Name = "匹配供应量的最小批尺寸")]
        [ExcelColumnName("匹配供应量的最小批尺寸")]
        public decimal Minls { get; set; }

        [ExcelColumn(Name = "匹配供应需求的最大批尺寸")]
        [ExcelColumnName("匹配供应需求的最大批尺寸")]
        public decimal Maxls { get; set; }

        [ExcelColumn(Name = "匹配供应需求的固定批大小")]
        [ExcelColumnName("匹配供应需求的固定批大小")]
        public decimal Fixls { get; set; }

        [ExcelColumn(Name = "匹配供应需求增加批尺寸")]
        [ExcelColumnName("匹配供应需求增加批尺寸")]
        public decimal Ltinc { get; set; }

        [ExcelColumn(Name = "该字段不再使用")]
        [ExcelColumnName("该字段不再使用")]
        public int? Compl { get; set; }

        [ExcelColumn(Name = "用于生产指标的转换类型")]
        [ExcelColumnName("用于生产指标的转换类型")]
        public string Convt { get; set; }

        [ExcelColumn(Name = "安全时间的期间参数文件")]
        [ExcelColumnName("安全时间的期间参数文件")]
        public string Shpro { get; set; }

        [ExcelColumn(Name = "相关需求的 MRP  关联")]
        [ExcelColumnName("相关需求的 MRP  关联")]
        public string Ahdis { get; set; }

        [ExcelColumn(Name = "指示：MRP  范围存在")]
        [ExcelColumnName("指示：MRP  范围存在")]
        public string Diber { get; set; }

        [ExcelColumn(Name = "跨项目物料指示符")]
        [ExcelColumnName("跨项目物料指示符")]
        public string Kzpsp { get; set; }

        [ExcelColumn(Name = "订单更改管理的总体参数文件")]
        [ExcelColumnName("订单更改管理的总体参数文件")]
        public string Ocmpf { get; set; }

        [ExcelColumn(Name = "指示：物料是否与 APO 相关")]
        [ExcelColumnName("指示：物料是否与 APO 相关")]
        public string Apokz { get; set; }

        [ExcelColumn(Name = "最后的MARD 期间之前，MARDH 记录已经存在")]
        [ExcelColumnName("最后的MARD 期间之前，MARDH 记录已经存在")]
        public string Mcrue { get; set; }

        [ExcelColumn(Name = "当前期间 (记帐期间)")]
        [ExcelColumnName("当前期间 (记帐期间)")]
        public int? Lfmon { get; set; }

        [ExcelColumn(Name = "当前期间的会计年度")]
        [ExcelColumnName("当前期间的会计年度")]
        public int? Lfgja { get; set; }

        [ExcelColumn(Name = "最小安全库存")]
        [ExcelColumnName("最小安全库存")]
        public decimal Eislo { get; set; }

        [ExcelColumn(Name = "无成本核算")]
        [ExcelColumnName("无成本核算")]
        public string Ncost { get; set; }

        [ExcelColumn(Name = "库存入库和库存出库的策略")]
        [ExcelColumnName("库存入库和库存出库的策略")]
        public string Rotationdate { get; set; }

        [ExcelColumn(Name = "初始批次管理的标识")]
        [ExcelColumnName("初始批次管理的标识")]
        public string Uchkz { get; set; }

        [ExcelColumn(Name = "初始批量的参考物料")]
        [ExcelColumnName("初始批量的参考物料")]
        public string Ucmat { get; set; }

        [ExcelColumn(Name = "评估的收货锁定库存")]
        [ExcelColumnName("评估的收货锁定库存")]
        public decimal Bwesb { get; set; }

        [ExcelColumn(Name = "分段策略")]
        [ExcelColumnName("分段策略")]
        public string Sgtcovs { get; set; }

        [ExcelColumn(Name = "分段状态")]
        [ExcelColumnName("分段状态")]
        public string Sgtstatc { get; set; }

        [ExcelColumn(Name = "分段策略范围")]
        [ExcelColumnName("分段策略范围")]
        public string Sgtscope { get; set; }

        [ExcelColumn(Name = "根据交货日期或段排序库存")]
        [ExcelColumnName("根据交货日期或段排序库存")]
        public string Sgtmrpsi { get; set; }

        [ExcelColumn(Name = "消耗优先级")]
        [ExcelColumnName("消耗优先级")]
        public string Sgtprcm { get; set; }

        [ExcelColumn(Name = "离散批次编号")]
        [ExcelColumnName("离散批次编号")]
        public string Sgtchint { get; set; }

        [ExcelColumn(Name = "库存保护标识")]
        [ExcelColumnName("库存保护标识")]
        public string Sgtstkprt { get; set; }

        [ExcelColumn(Name = "订单分配运行")]
        [ExcelColumnName("订单分配运行")]
        public string Fshmgarunreq { get; set; }

        [ExcelColumn(Name = "标识：在库存管理中激活季节")]
        [ExcelColumnName("标识：在库存管理中激活季节")]
        public string Fshseaim { get; set; }

        [ExcelColumn(Name = "物料的包装组 (VSO)")]
        [ExcelColumnName("物料的包装组 (VSO)")]
        public string Vsorpkgrp { get; set; }

        [ExcelColumn(Name = "自动提货区域内的行 (VSO)")]
        [ExcelColumnName("自动提货区域内的行 (VSO)")]
        public string Vsorlanenum { get; set; }

        [ExcelColumn(Name = "供应商包装物料的物料编号 (VSO)")]
        [ExcelColumnName("供应商包装物料的物料编号 (VSO)")]
        public string Vsorpalvend { get; set; }

        [ExcelColumn(Name = "仅纵向提取包装物料 (VSO)")]
        [ExcelColumnName("仅纵向提取包装物料 (VSO)")]
        public string Vsorforkdir { get; set; }

        [ExcelColumn(Name = "项目唯一标识相关")]
        [ExcelColumnName("项目唯一标识相关")]
        public string Iuidrelevant { get; set; }

        [ExcelColumn(Name = "唯一项目标识的结构类型")]
        [ExcelColumnName("唯一项目标识的结构类型")]
        public string Iuidtype { get; set; }

        [ExcelColumn(Name = "UII 的外部分配")]
        [ExcelColumnName("UII 的外部分配")]
        public string Uidiea { get; set; }

        [ExcelColumn(Name = "寄售控制")]
        [ExcelColumnName("寄售控制")]
        public string Consprocg { get; set; }

        [ExcelColumn(Name = "按天数发货处理时间")]
        [ExcelColumnName("按天数发货处理时间")]
        public decimal Giprtime { get; set; }

        [ExcelColumn(Name = "采购交叉的采购组")]
        [ExcelColumnName("采购交叉的采购组")]
        public string Multipleekgrp { get; set; }

        [ExcelColumn(Name = "参考确定方案")]
        [ExcelColumnName("参考确定方案")]
        public string Refschema { get; set; }

        [ExcelColumn(Name = "覆盖的最小目标范围")]
        [ExcelColumnName("覆盖的最小目标范围")]
        public int? Mintroc { get; set; }

        [ExcelColumn(Name = "覆盖的最大目标范围")]
        [ExcelColumnName("覆盖的最大目标范围")]
        public int? Maxtroc { get; set; }

        [ExcelColumn(Name = "目标库存")]
        [ExcelColumnName("目标库存")]
        public decimal Targetstock { get; set; }

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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string WerksLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "在工厂级标记要删除的物料")]
        public string LvormLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "采购组")]
        public string EkgrpLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "采购类型")]
        public string BeskzLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "特殊采购类型")]
        public string SobslLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "过帐到检验库存")]
        public string InsmkLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "对象类型")]
        public string OtypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "利润中心")]
        public string PrctrLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "发货库存地点")]
        public string LgproLabel { get; set; }
    }
}