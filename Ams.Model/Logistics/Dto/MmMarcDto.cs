
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 工厂物料
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:30:16
    /// </summary>
    public class MmMarcQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Mc004 { get; set; }
        /// <summary>
        /// 物料号 
        /// </summary>        
        public string Mc003 { get; set; }
    }

    /// <summary>
    /// 工厂物料
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:30:16
    /// </summary>
    public class MmMarcDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]

        public string Mc002 { get; set; }

        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Mc004 { get; set; }

        //[ExcelColumn(Name = "物料号")]
        [ExcelColumnName("物料号")]

        public string Mc003 { get; set; }

        //[ExcelColumn(Name = "维护状态")]
        [ExcelColumnName("维护状态")]

        public string Mc005 { get; set; }

        //[ExcelColumn(Name = "工厂级删除")]
        [ExcelColumnName("工厂级删除")]

        public string Mc006 { get; set; }

        //[ExcelColumn(Name = "评估类别")]
        [ExcelColumnName("评估类别")]

        public string Mc007 { get; set; }

        //[ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]

        public string Mc008 { get; set; }

        //[ExcelColumn(Name = "PS物料状态")]
        [ExcelColumnName("PS物料状态")]

        public string Mc009 { get; set; }

        //[ExcelColumn(Name = "有效起始日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效起始日")]

        public DateTime? Mc010 { get; set; }

        //[ExcelColumn(Name = "ABC标识")]
        [ExcelColumnName("ABC标识")]

        public string Mc011 { get; set; }

        //[ExcelColumn(Name = "关键部件")]
        [ExcelColumnName("关键部件")]

        public string Mc012 { get; set; }

        //[ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]

        public string Mc013 { get; set; }

        //[ExcelColumn(Name = "发货单位")]
        [ExcelColumnName("发货单位")]

        public string Mc014 { get; set; }

        //[ExcelColumn(Name = "MRP 参数文件")]
        [ExcelColumnName("MRP 参数文件")]

        public string Mc015 { get; set; }

        //[ExcelColumn(Name = "MRP 类型")]
        [ExcelColumnName("MRP 类型")]

        public string Mc016 { get; set; }

        //[ExcelColumn(Name = "MRP 控制者")]
        [ExcelColumnName("MRP 控制者")]

        public string Mc017 { get; set; }

        //[ExcelColumn(Name = "MRP 控制者买方")]
        [ExcelColumnName("MRP 控制者买方")]

        public string Mc018 { get; set; }

        [Required(ErrorMessage = "计划交货天数不能为空")]
        //[ExcelColumn(Name = "计划交货天数")]
        [ExcelColumnName("计划交货天数")]

        public decimal Mc019 { get; set; }

        [Required(ErrorMessage = "收货处理时间不能为空")]
        //[ExcelColumn(Name = "收货处理时间")]
        [ExcelColumnName("收货处理时间")]

        public decimal Mc020 { get; set; }

        //[ExcelColumn(Name = "期间标识")]
        [ExcelColumnName("期间标识")]

        public string Mc021 { get; set; }

        [Required(ErrorMessage = "装配报废不能为空")]
        //[ExcelColumn(Name = "装配报废")]
        [ExcelColumnName("装配报废")]

        public decimal Mc022 { get; set; }

        //[ExcelColumn(Name = "批量大小")]
        [ExcelColumnName("批量大小")]

        public string Mc023 { get; set; }

        //[ExcelColumn(Name = "采购")]
        [ExcelColumnName("采购")]

        public string Mc024 { get; set; }

        //[ExcelColumn(Name = "特殊采购")]
        [ExcelColumnName("特殊采购")]

        public string Mc025 { get; set; }

        [Required(ErrorMessage = "再订货点不能为空")]
        //[ExcelColumn(Name = "再订货点")]
        [ExcelColumnName("再订货点")]

        public decimal Mc026 { get; set; }

        [Required(ErrorMessage = "安全库存不能为空")]
        //[ExcelColumn(Name = "安全库存")]
        [ExcelColumnName("安全库存")]

        public decimal Mc027 { get; set; }

        [Required(ErrorMessage = "最小批量不能为空")]
        //[ExcelColumn(Name = "最小批量")]
        [ExcelColumnName("最小批量")]

        public decimal Mc028 { get; set; }

        [Required(ErrorMessage = "最大批量不能为空")]
        //[ExcelColumn(Name = "最大批量")]
        [ExcelColumnName("最大批量")]

        public decimal Mc029 { get; set; }

        [Required(ErrorMessage = "固定批量不能为空")]
        //[ExcelColumn(Name = "固定批量")]
        [ExcelColumnName("固定批量")]

        public decimal Mc030 { get; set; }

        //[ExcelColumn(Name = "舍入值")]
        [ExcelColumnName("舍入值")]

        public decimal Mc031 { get; set; }

        //[ExcelColumn(Name = "最大库存水平")]
        [ExcelColumnName("最大库存水平")]

        public decimal Mc032 { get; set; }

        [Required(ErrorMessage = "订购成本不能为空")]
        //[ExcelColumn(Name = "订购成本")]
        [ExcelColumnName("订购成本")]

        public decimal Mc033 { get; set; }

        //[ExcelColumn(Name = "独立/集中")]
        [ExcelColumnName("独立/集中")]

        public string Mc034 { get; set; }

        //[ExcelColumn(Name = "库存成本")]
        [ExcelColumnName("库存成本")]

        public string Mc035 { get; set; }

        //[ExcelColumn(Name = "选择方法")]
        [ExcelColumnName("选择方法")]

        public string Mc036 { get; set; }

        //[ExcelColumn(Name = "非连续标识")]
        [ExcelColumnName("非连续标识")]

        public string Mc037 { get; set; }

        //[ExcelColumn(Name = "中断日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("中断日期")]

        public DateTime? Mc038 { get; set; }

        //[ExcelColumn(Name = "后续物料")]
        [ExcelColumnName("后续物料")]

        public string Mc039 { get; set; }

        //[ExcelColumn(Name = "需求分组")]
        [ExcelColumnName("需求分组")]

        public string Mc040 { get; set; }

        //[ExcelColumn(Name = "综合MRP")]
        [ExcelColumnName("综合MRP")]

        public string Mc041 { get; set; }

        //[ExcelColumn(Name = "计划边际码")]
        [ExcelColumnName("计划边际码")]

        public string Mc042 { get; set; }

        //[ExcelColumn(Name = "自动更改工厂订单")]
        [ExcelColumnName("自动更改工厂订单")]

        public string Mc043 { get; set; }

        //[ExcelColumn(Name = "自动批准")]
        [ExcelColumnName("自动批准")]

        public string Mc044 { get; set; }

        //[ExcelColumn(Name = "反冲")]
        [ExcelColumnName("反冲")]

        public string Mc045 { get; set; }

        //[ExcelColumn(Name = "生产管理员")]
        [ExcelColumnName("生产管理员")]

        public string Mc046 { get; set; }

        [Required(ErrorMessage = "处理时间不能为空")]
        //[ExcelColumn(Name = "处理时间")]
        [ExcelColumnName("处理时间")]

        public decimal Mc047 { get; set; }

        [Required(ErrorMessage = "准备时间不能为空")]
        //[ExcelColumn(Name = "准备时间")]
        [ExcelColumnName("准备时间")]

        public decimal Mc048 { get; set; }

        [Required(ErrorMessage = "工序间不能为空")]
        //[ExcelColumn(Name = "工序间")]
        [ExcelColumnName("工序间")]

        public decimal Mc049 { get; set; }

        [Required(ErrorMessage = "基准数量不能为空")]
        //[ExcelColumn(Name = "基准数量")]
        [ExcelColumnName("基准数量")]

        public decimal Mc050 { get; set; }

        [Required(ErrorMessage = "厂内生产时间不能为空")]
        //[ExcelColumn(Name = "厂内生产时间")]
        [ExcelColumnName("厂内生产时间")]

        public decimal Mc051 { get; set; }

        [Required(ErrorMessage = "最大存储期间不能为空")]
        //[ExcelColumn(Name = "最大存储期间")]
        [ExcelColumnName("最大存储期间")]

        public decimal Mc052 { get; set; }

        //[ExcelColumn(Name = "时间单位")]
        [ExcelColumnName("时间单位")]

        public string Mc053 { get; set; }

        //[ExcelColumn(Name = "从产品货位库存")]
        [ExcelColumnName("从产品货位库存")]

        public string Mc054 { get; set; }

        //[ExcelColumn(Name = "初步计划")]
        [ExcelColumnName("初步计划")]

        public string Mc055 { get; set; }

        [Required(ErrorMessage = "超量交货容差不能为空")]
        //[ExcelColumn(Name = "超量交货容差")]
        [ExcelColumnName("超量交货容差")]

        public decimal Mc056 { get; set; }

        //[ExcelColumn(Name = "未限制")]
        [ExcelColumnName("未限制")]

        public string Mc057 { get; set; }

        [Required(ErrorMessage = "不足交货容差不能为空")]
        //[ExcelColumn(Name = "不足交货容差")]
        [ExcelColumnName("不足交货容差")]

        public decimal Mc058 { get; set; }

        [Required(ErrorMessage = "总计补货提前时间不能为空")]
        //[ExcelColumn(Name = "总计补货提前时间")]
        [ExcelColumnName("总计补货提前时间")]

        public decimal Mc059 { get; set; }

        //[ExcelColumn(Name = "替换部件")]
        [ExcelColumnName("替换部件")]

        public string Mc060 { get; set; }

        [Required(ErrorMessage = "附加费不能为空")]
        //[ExcelColumn(Name = "附加费")]
        [ExcelColumnName("附加费")]

        public decimal Mc061 { get; set; }

        //[ExcelColumn(Name = "生产状态")]
        [ExcelColumnName("生产状态")]

        public string Mc062 { get; set; }

        //[ExcelColumn(Name = "过帐到检验库存")]
        [ExcelColumnName("过帐到检验库存")]

        public string Mc063 { get; set; }

        [Required(ErrorMessage = "样本不能为空")]
        //[ExcelColumn(Name = "样本")]
        [ExcelColumnName("样本")]

        public decimal Mc064 { get; set; }

        //[ExcelColumn(Name = "隔离")]
        [ExcelColumnName("隔离")]

        public decimal Mc065 { get; set; }

        //[ExcelColumn(Name = "控制码")]
        [ExcelColumnName("控制码")]

        public string Mc066 { get; set; }

        //[ExcelColumn(Name = "平均检查持续期")]
        [ExcelColumnName("平均检查持续期")]

        public decimal Mc067 { get; set; }

        //[ExcelColumn(Name = "检查计划")]
        [ExcelColumnName("检查计划")]

        public string Mc068 { get; set; }

        //[ExcelColumn(Name = "凭证需求")]
        [ExcelColumnName("凭证需求")]

        public string Mc069 { get; set; }

        [Required(ErrorMessage = "活动性物质不能为空")]
        //[ExcelColumn(Name = "活动性物质")]
        [ExcelColumnName("活动性物质")]

        public decimal Mc070 { get; set; }

        [Required(ErrorMessage = "检查间隔不能为空")]
        //[ExcelColumn(Name = "检查间隔")]
        [ExcelColumnName("检查间隔")]

        public decimal Mc071 { get; set; }

        //[ExcelColumn(Name = "下一次检查", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("下一次检查")]

        public DateTime? Mc072 { get; set; }

        //[ExcelColumn(Name = "中转库存")]
        [ExcelColumnName("中转库存")]

        public decimal Mc073 { get; set; }

        //[ExcelColumn(Name = "装载组")]
        [ExcelColumnName("装载组")]

        public string Mc074 { get; set; }

        //[ExcelColumn(Name = "批次管理需求")]
        [ExcelColumnName("批次管理需求")]

        public string Mc075 { get; set; }

        //[ExcelColumn(Name = "配额使用")]
        [ExcelColumnName("配额使用")]

        public string Mc076 { get; set; }

        //[ExcelColumn(Name = "服务水平")]
        [ExcelColumnName("服务水平")]

        public decimal Mc077 { get; set; }

        //[ExcelColumn(Name = "分割标识")]
        [ExcelColumnName("分割标识")]

        public string Mc078 { get; set; }

        //[ExcelColumn(Name = "计划版本")]
        [ExcelColumnName("计划版本")]

        public string Mc079 { get; set; }

        //[ExcelColumn(Name = "对象类型")]
        [ExcelColumnName("对象类型")]

        public string Mc080 { get; set; }

        [Required(ErrorMessage = "对象标识不能为空")]
        //[ExcelColumn(Name = "对象标识")]
        [ExcelColumnName("对象标识")]

        public int Mc081 { get; set; }

        //[ExcelColumn(Name = "可用性检查")]
        [ExcelColumnName("可用性检查")]

        public string Mc082 { get; set; }

        //[ExcelColumn(Name = "会计年度变式")]
        [ExcelColumnName("会计年度变式")]

        public string Mc083 { get; set; }

        //[ExcelColumn(Name = "修正因子")]
        [ExcelColumnName("修正因子")]

        public string Mc084 { get; set; }

        [Required(ErrorMessage = "准备时间不能为空")]
        //[ExcelColumn(Name = "准备时间")]
        [ExcelColumnName("准备时间")]

        public decimal Mc085 { get; set; }

        [Required(ErrorMessage = "基准数量不能为空")]
        //[ExcelColumn(Name = "基准数量")]
        [ExcelColumnName("基准数量")]

        public decimal Mc086 { get; set; }

        [Required(ErrorMessage = "处理时间不能为空")]
        //[ExcelColumn(Name = "处理时间")]
        [ExcelColumnName("处理时间")]

        public decimal Mc087 { get; set; }

        //[ExcelColumn(Name = "取消激活的")]
        [ExcelColumnName("取消激活的")]

        public string Mc088 { get; set; }

        //[ExcelColumn(Name = "货源")]
        [ExcelColumnName("货源")]

        public string Mc089 { get; set; }

        //[ExcelColumn(Name = "自动采购订单")]
        [ExcelColumnName("自动采购订单")]

        public string Mc090 { get; set; }

        //[ExcelColumn(Name = "源清单")]
        [ExcelColumnName("源清单")]

        public string Mc091 { get; set; }

        //[ExcelColumn(Name = "商品代码")]
        [ExcelColumnName("商品代码")]

        public string Mc092 { get; set; }

        //[ExcelColumn(Name = "原产地国")]
        [ExcelColumnName("原产地国")]

        public string Mc093 { get; set; }

        //[ExcelColumn(Name = "货源地")]
        [ExcelColumnName("货源地")]

        public string Mc094 { get; set; }

        //[ExcelColumn(Name = "商品代码单位")]
        [ExcelColumnName("商品代码单位")]

        public string Mc095 { get; set; }

        //[ExcelColumn(Name = "出口/进口组")]
        [ExcelColumnName("出口/进口组")]

        public string Mc096 { get; set; }

        //[ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]

        public string Mc097 { get; set; }

        [Required(ErrorMessage = "在途库存不能为空")]
        //[ExcelColumn(Name = "在途库存")]
        [ExcelColumnName("在途库存")]

        public decimal Mc098 { get; set; }

        //[ExcelColumn(Name = "计划日历")]
        [ExcelColumnName("计划日历")]

        public string Mc099 { get; set; }

        //[ExcelColumn(Name = "重复生产")]
        [ExcelColumnName("重复生产")]

        public string Mc100 { get; set; }

        [Required(ErrorMessage = "计划的时界不能为空")]
        //[ExcelColumn(Name = "计划的时界")]
        [ExcelColumnName("计划的时界")]

        public int Mc101 { get; set; }

        //[ExcelColumn(Name = "消耗模式")]
        [ExcelColumnName("消耗模式")]

        public string Mc102 { get; set; }

        [Required(ErrorMessage = "消耗期间:逆向不能为空")]
        //[ExcelColumn(Name = "消耗期间:逆向")]
        [ExcelColumnName("消耗期间:逆向")]

        public int Mc103 { get; set; }

        [Required(ErrorMessage = "消耗时期-向前不能为空")]
        //[ExcelColumn(Name = "消耗时期-向前")]
        [ExcelColumnName("消耗时期-向前")]

        public int Mc104 { get; set; }

        //[ExcelColumn(Name = "版本")]
        [ExcelColumnName("版本")]

        public string Mc105 { get; set; }

        //[ExcelColumn(Name = "可选 BOM")]
        [ExcelColumnName("可选 BOM")]

        public string Mc106 { get; set; }

        //[ExcelColumn(Name = "BOM 用途")]
        [ExcelColumnName("BOM 用途")]

        public string Mc107 { get; set; }

        //[ExcelColumn(Name = "组")]
        [ExcelColumnName("组")]

        public string Mc108 { get; set; }

        //[ExcelColumn(Name = "组计数器")]
        [ExcelColumnName("组计数器")]

        public string Mc109 { get; set; }

        [Required(ErrorMessage = "成本核算批次不能为空")]
        //[ExcelColumn(Name = "成本核算批次")]
        [ExcelColumnName("成本核算批次")]

        public decimal Mc110 { get; set; }

        //[ExcelColumn(Name = "特殊工艺类型")]
        [ExcelColumnName("特殊工艺类型")]

        public string Mc111 { get; set; }

        //[ExcelColumn(Name = "生产单位")]
        [ExcelColumnName("生产单位")]

        public string Mc112 { get; set; }

        //[ExcelColumn(Name = "发货库存地点")]
        [ExcelColumnName("发货库存地点")]

        public string Mc113 { get; set; }

        //[ExcelColumn(Name = "MRP组")]
        [ExcelColumnName("MRP组")]

        public string Mc114 { get; set; }

        [Required(ErrorMessage = "组件报废不能为空")]
        //[ExcelColumn(Name = "组件报废")]
        [ExcelColumnName("组件报废")]

        public decimal Mc115 { get; set; }

        //[ExcelColumn(Name = "证书类型")]
        [ExcelColumnName("证书类型")]

        public string Mc116 { get; set; }

        //[ExcelColumn(Name = "检验设置")]
        [ExcelColumnName("检验设置")]

        public string Mc117 { get; set; }

        [Required(ErrorMessage = "间隔时间不能为空")]
        //[ExcelColumn(Name = "间隔时间")]
        [ExcelColumnName("间隔时间")]

        public decimal Mc118 { get; set; }

        //[ExcelColumn(Name = "供货天数参数文件")]
        [ExcelColumnName("供货天数参数文件")]

        public string Mc119 { get; set; }

        //[ExcelColumn(Name = "局部字段名")]
        [ExcelColumnName("局部字段名")]

        public string Mc120 { get; set; }

        //[ExcelColumn(Name = "周期盘点标识")]
        [ExcelColumnName("周期盘点标识")]

        public string Mc121 { get; set; }

        //[ExcelColumn(Name = "差异码")]
        [ExcelColumnName("差异码")]

        public string Mc122 { get; set; }

        //[ExcelColumn(Name = "序列号参数文件")]
        [ExcelColumnName("序列号参数文件")]

        public string Mc123 { get; set; }

        [Required(ErrorMessage = "内部对象号不能为空")]
        //[ExcelColumn(Name = "内部对象号")]
        [ExcelColumnName("内部对象号")]

        public int Mc124 { get; set; }

        //[ExcelColumn(Name = "可配置的物料")]
        [ExcelColumnName("可配置的物料")]

        public string Mc125 { get; set; }

        //[ExcelColumn(Name = "重复生产参数文件")]
        [ExcelColumnName("重复生产参数文件")]

        public string Mc126 { get; set; }

        //[ExcelColumn(Name = "负库存")]
        [ExcelColumnName("负库存")]

        public string Mc127 { get; set; }

        //[ExcelColumn(Name = "目标QM系统")]
        [ExcelColumnName("目标QM系统")]

        public string Mc128 { get; set; }

        //[ExcelColumn(Name = "计划周期")]
        [ExcelColumnName("计划周期")]

        public string Mc129 { get; set; }

        //[ExcelColumn(Name = "舍入参数文件")]
        [ExcelColumnName("舍入参数文件")]

        public string Mc130 { get; set; }

        //[ExcelColumn(Name = "消耗")]
        [ExcelColumnName("消耗")]

        public string Mc131 { get; set; }

        //[ExcelColumn(Name = "寄存")]
        [ExcelColumnName("寄存")]

        public string Mc132 { get; set; }

        //[ExcelColumn(Name = "消耗日期到", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("消耗日期到")]

        public DateTime? Mc133 { get; set; }

        [Required(ErrorMessage = "乘数不能为空")]
        //[ExcelColumn(Name = "乘数")]
        [ExcelColumnName("乘数")]

        public decimal Mc134 { get; set; }

        //[ExcelColumn(Name = "自动重置")]
        [ExcelColumnName("自动重置")]

        public string Mc135 { get; set; }

        //[ExcelColumn(Name = "优先权")]
        [ExcelColumnName("优先权")]

        public string Mc136 { get; set; }

        //[ExcelColumn(Name = "免税证明")]
        [ExcelColumnName("免税证明")]

        public string Mc137 { get; set; }

        //[ExcelColumn(Name = "免税证书编号")]
        [ExcelColumnName("免税证书编号")]

        public string Mc138 { get; set; }

        //[ExcelColumn(Name = "免税证书的发放日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("免税证书的发放日")]

        public DateTime? Mc139 { get; set; }

        //[ExcelColumn(Name = "供应商申报")]
        [ExcelColumnName("供应商申报")]

        public string Mc140 { get; set; }

        //[ExcelColumn(Name = "供应商申报日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("供应商申报日期")]

        public DateTime? Mc141 { get; set; }

        //[ExcelColumn(Name = "军用物资")]
        [ExcelColumnName("军用物资")]

        public string Mc142 { get; set; }

        //[ExcelColumn(Name = "服务级别")]
        [ExcelColumnName("服务级别")]

        public string Mc143 { get; set; }

        //[ExcelColumn(Name = "联产品")]
        [ExcelColumnName("联产品")]

        public string Mc144 { get; set; }

        //[ExcelColumn(Name = "策略组")]
        [ExcelColumnName("策略组")]

        public string Mc145 { get; set; }

        [Required(ErrorMessage = "内部对象号不能为空")]
        //[ExcelColumn(Name = "内部对象号")]
        [ExcelColumnName("内部对象号")]

        public int Mc146 { get; set; }

        //[ExcelColumn(Name = "外部采购仓储位置")]
        [ExcelColumnName("外部采购仓储位置")]

        public string Mc147 { get; set; }

        //[ExcelColumn(Name = "散装物料")]
        [ExcelColumnName("散装物料")]

        public string Mc148 { get; set; }

        //[ExcelColumn(Name = "周期标识被固定")]
        [ExcelColumnName("周期标识被固定")]

        public string Mc149 { get; set; }

        //[ExcelColumn(Name = "库存确定组")]
        [ExcelColumnName("库存确定组")]

        public string Mc150 { get; set; }

        //[ExcelColumn(Name = "QM 物料授权组")]
        [ExcelColumnName("QM 物料授权组")]

        public string Mc151 { get; set; }

        [Required(ErrorMessage = "调整期间不能为空")]
        //[ExcelColumn(Name = "调整期间")]
        [ExcelColumnName("调整期间")]

        public decimal Mc152 { get; set; }

        //[ExcelColumn(Name = "任务清单类型")]
        [ExcelColumnName("任务清单类型")]

        public string Mc153 { get; set; }

        //[ExcelColumn(Name = "计量单位组")]
        [ExcelColumnName("计量单位组")]

        public string Mc154 { get; set; }

        //[ExcelColumn(Name = "转换组")]
        [ExcelColumnName("转换组")]

        public string Mc155 { get; set; }

        [Required(ErrorMessage = "空气浮力因子不能为空")]
        //[ExcelColumn(Name = "空气浮力因子")]
        [ExcelColumnName("空气浮力因子")]

        public decimal Mc156 { get; set; }

        //[ExcelColumn(Name = "生产参数文件")]
        [ExcelColumnName("生产参数文件")]

        public string Mc157 { get; set; }

        //[ExcelColumn(Name = "安全时间标识")]
        [ExcelColumnName("安全时间标识")]

        public string Mc158 { get; set; }

        [Required(ErrorMessage = "安全时间不能为空")]
        //[ExcelColumn(Name = "安全时间")]
        [ExcelColumnName("安全时间")]

        public int Mc159 { get; set; }

        //[ExcelColumn(Name = "活动控制")]
        [ExcelColumnName("活动控制")]

        public string Mc160 { get; set; }

        //[ExcelColumn(Name = "批量输入")]
        [ExcelColumnName("批量输入")]

        public string Mc161 { get; set; }

        //[ExcelColumn(Name = "计量单位组")]
        [ExcelColumnName("计量单位组")]

        public string Mc162 { get; set; }

        //[ExcelColumn(Name = "物料运输组")]
        [ExcelColumnName("物料运输组")]

        public string Mc163 { get; set; }

        [Required(ErrorMessage = "库存转移SV不能为空")]
        //[ExcelColumn(Name = "库存转移SV")]
        [ExcelColumnName("库存转移SV")]

        public decimal Mc164 { get; set; }

        [Required(ErrorMessage = "运输库存SP不能为空")]
        //[ExcelColumn(Name = "运输库存SP")]
        [ExcelColumnName("运输库存SP")]

        public decimal Mc165 { get; set; }

        //[ExcelColumn(Name = "平滑促销消耗")]
        [ExcelColumnName("平滑促销消耗")]

        public string Mc166 { get; set; }

        //[ExcelColumn(Name = "生产版本")]
        [ExcelColumnName("生产版本")]

        public string Mc167 { get; set; }

        //[ExcelColumn(Name = "固定价格联产品")]
        [ExcelColumnName("固定价格联产品")]

        public string Mc168 { get; set; }

        //[ExcelColumn(Name = "后勤组")]
        [ExcelColumnName("后勤组")]

        public string Mc169 { get; set; }

        //[ExcelColumn(Name = "分销参数文件")]
        [ExcelColumnName("分销参数文件")]

        public string Mc170 { get; set; }

        [Required(ErrorMessage = "有约束的虚拟库存不能为空")]
        //[ExcelColumn(Name = "有约束的虚拟库存")]
        [ExcelColumnName("有约束的虚拟库存")]

        public decimal Mc171 { get; set; }

        [Required(ErrorMessage = "空缺库存销售价不能为空")]
        //[ExcelColumn(Name = "空缺库存销售价")]
        [ExcelColumnName("空缺库存销售价")]

        public decimal Mc172 { get; set; }

        //[ExcelColumn(Name = "物料类别")]
        [ExcelColumnName("物料类别")]

        public string Mc173 { get; set; }

        //[ExcelColumn(Name = "EU产品清单编号")]
        [ExcelColumnName("EU产品清单编号")]

        public string Mc174 { get; set; }

        //[ExcelColumn(Name = "CAP 产品组")]
        [ExcelColumnName("CAP 产品组")]

        public string Mc175 { get; set; }

        //[ExcelColumn(Name = "CAS 号码")]
        [ExcelColumnName("CAS 号码")]

        public string Mc176 { get; set; }

        //[ExcelColumn(Name = "PRODCOM 号码")]
        [ExcelColumnName("PRODCOM 号码")]

        public string Mc177 { get; set; }

        //[ExcelColumn(Name = "控制代码")]
        [ExcelColumnName("控制代码")]

        public string Mc178 { get; set; }

        //[ExcelColumn(Name = "JIT标识")]
        [ExcelColumnName("JIT标识")]

        public string Mc179 { get; set; }

        //[ExcelColumn(Name = "物料组")]
        [ExcelColumnName("物料组")]

        public string Mc180 { get; set; }

        //[ExcelColumn(Name = "建议供应区域")]
        [ExcelColumnName("建议供应区域")]

        public string Mc181 { get; set; }

        //[ExcelColumn(Name = "公平分享规则")]
        [ExcelColumnName("公平分享规则")]

        public string Mc182 { get; set; }

        //[ExcelColumn(Name = "推式分配")]
        [ExcelColumnName("推式分配")]

        public string Mc183 { get; set; }

        [Required(ErrorMessage = "发布界限不能为空")]
        //[ExcelColumn(Name = "发布界限")]
        [ExcelColumnName("发布界限")]

        public decimal Mc184 { get; set; }

        [Required(ErrorMessage = "最小批量不能为空")]
        //[ExcelColumn(Name = "最小批量")]
        [ExcelColumnName("最小批量")]

        public decimal Mc185 { get; set; }

        [Required(ErrorMessage = "最大批量不能为空")]
        //[ExcelColumn(Name = "最大批量")]
        [ExcelColumnName("最大批量")]

        public decimal Mc186 { get; set; }

        [Required(ErrorMessage = "固定批量不能为空")]
        //[ExcelColumn(Name = "固定批量")]
        [ExcelColumnName("固定批量")]

        public decimal Mc187 { get; set; }

        [Required(ErrorMessage = "批尺寸增加不能为空")]
        //[ExcelColumn(Name = "批尺寸增加")]
        [ExcelColumnName("批尺寸增加")]

        public decimal Mc188 { get; set; }

        [Required(ErrorMessage = "该字段不再使用不能为空")]
        //[ExcelColumn(Name = "该字段不再使用")]
        [ExcelColumnName("该字段不再使用")]

        public int Mc189 { get; set; }

        //[ExcelColumn(Name = "转换类型")]
        [ExcelColumnName("转换类型")]

        public string Mc190 { get; set; }

        //[ExcelColumn(Name = "ST期间参数文件")]
        [ExcelColumnName("ST期间参数文件")]

        public string Mc191 { get; set; }

        //[ExcelColumn(Name = "MRP 相关需求")]
        [ExcelColumnName("MRP 相关需求")]

        public string Mc192 { get; set; }

        //[ExcelColumn(Name = "MRP 范围存在")]
        [ExcelColumnName("MRP 范围存在")]

        public string Mc193 { get; set; }

        //[ExcelColumn(Name = "跨项目")]
        [ExcelColumnName("跨项目")]

        public string Mc194 { get; set; }

        //[ExcelColumn(Name = "总体参数文件")]
        [ExcelColumnName("总体参数文件")]

        public string Mc195 { get; set; }

        //[ExcelColumn(Name = "APO 相关")]
        [ExcelColumnName("APO 相关")]

        public string Mc196 { get; set; }

        //[ExcelColumn(Name = "最后的MARD")]
        [ExcelColumnName("最后的MARD")]

        public string Mc197 { get; set; }

        [Required(ErrorMessage = "当前期间 (记帐期间)不能为空")]
        //[ExcelColumn(Name = "当前期间 (记帐期间)")]
        [ExcelColumnName("当前期间 (记帐期间)")]

        public int Mc198 { get; set; }

        [Required(ErrorMessage = "当前期间的会计年度不能为空")]
        //[ExcelColumn(Name = "当前期间的会计年度")]
        [ExcelColumnName("当前期间的会计年度")]

        public int Mc199 { get; set; }

        [Required(ErrorMessage = "最小安全库存不能为空")]
        //[ExcelColumn(Name = "最小安全库存")]
        [ExcelColumnName("最小安全库存")]

        public decimal Mc200 { get; set; }

        //[ExcelColumn(Name = "无成本核算")]
        [ExcelColumnName("无成本核算")]

        public string Mc201 { get; set; }

        //[ExcelColumn(Name = "库存入库和出库")]
        [ExcelColumnName("库存入库和出库")]

        public string Mc202 { get; set; }

        //[ExcelColumn(Name = "OB管理")]
        [ExcelColumnName("OB管理")]

        public string Mc203 { get; set; }

        //[ExcelColumn(Name = "OB参考物料")]
        [ExcelColumnName("OB参考物料")]

        public string Mc204 { get; set; }

        [Required(ErrorMessage = "评估收货锁定库存不能为空")]
        //[ExcelColumn(Name = "评估收货锁定库存")]
        [ExcelColumnName("评估收货锁定库存")]

        public decimal Mc205 { get; set; }

        //[ExcelColumn(Name = "分段策略")]
        [ExcelColumnName("分段策略")]

        public string Mc206 { get; set; }

        //[ExcelColumn(Name = "分段状态")]
        [ExcelColumnName("分段状态")]

        public string Mc207 { get; set; }

        //[ExcelColumn(Name = "分段范围")]
        [ExcelColumnName("分段范围")]

        public string Mc208 { get; set; }

        //[ExcelColumn(Name = "排序库存")]
        [ExcelColumnName("排序库存")]

        public string Mc209 { get; set; }

        //[ExcelColumn(Name = "消耗优先级")]
        [ExcelColumnName("消耗优先级")]

        public string Mc210 { get; set; }

        //[ExcelColumn(Name = "离散批次编号")]
        [ExcelColumnName("离散批次编号")]

        public string Mc211 { get; set; }

        //[ExcelColumn(Name = "库存保护")]
        [ExcelColumnName("库存保护")]

        public string Mc212 { get; set; }

        //[ExcelColumn(Name = "订单分配运行")]
        [ExcelColumnName("订单分配运行")]

        public string Mc213 { get; set; }

        //[ExcelColumn(Name = "库存管理中激活季节")]
        [ExcelColumnName("库存管理中激活季节")]

        public string Mc214 { get; set; }

        //[ExcelColumn(Name = "包装组 (VSO)")]
        [ExcelColumnName("包装组 (VSO)")]

        public string Mc215 { get; set; }

        //[ExcelColumn(Name = "提货行 (VSO)")]
        [ExcelColumnName("提货行 (VSO)")]

        public string Mc216 { get; set; }

        //[ExcelColumn(Name = "物料编号 (VSO)")]
        [ExcelColumnName("物料编号 (VSO)")]

        public string Mc217 { get; set; }

        //[ExcelColumn(Name = "纵向提取")]
        [ExcelColumnName("纵向提取")]

        public string Mc218 { get; set; }

        //[ExcelColumn(Name = "IUID相关")]
        [ExcelColumnName("IUID相关")]

        public string Mc219 { get; set; }

        //[ExcelColumn(Name = "IUID类型")]
        [ExcelColumnName("IUID类型")]

        public string Mc220 { get; set; }

        //[ExcelColumn(Name = "外部分配")]
        [ExcelColumnName("外部分配")]

        public string Mc221 { get; set; }

        //[ExcelColumn(Name = "寄售控制")]
        [ExcelColumnName("寄售控制")]

        public string Mc222 { get; set; }

        [Required(ErrorMessage = "发货处理时间不能为空")]
        //[ExcelColumn(Name = "发货处理时间")]
        [ExcelColumnName("发货处理时间")]

        public decimal Mc223 { get; set; }

        //[ExcelColumn(Name = "交叉的采购组")]
        [ExcelColumnName("交叉的采购组")]

        public string Mc224 { get; set; }

        //[ExcelColumn(Name = "参考确定方案")]
        [ExcelColumnName("参考确定方案")]

        public string Mc225 { get; set; }

        [Required(ErrorMessage = "最小目标范围不能为空")]
        //[ExcelColumn(Name = "最小目标范围")]
        [ExcelColumnName("最小目标范围")]

        public int Mc226 { get; set; }

        [Required(ErrorMessage = "最大目标范围不能为空")]
        //[ExcelColumn(Name = "最大目标范围")]
        [ExcelColumnName("最大目标范围")]

        public int Mc227 { get; set; }

        [Required(ErrorMessage = "目标库存不能为空")]
        //[ExcelColumn(Name = "目标库存")]
        [ExcelColumnName("目标库存")]

        public decimal Mc228 { get; set; }

        [ExcelIgnore]

        public string Ref01 { get; set; }

        [ExcelIgnore]

        public string Ref02 { get; set; }

        [ExcelIgnore]

        public string Ref03 { get; set; }

        [ExcelIgnore]

        public decimal Ref04 { get; set; }

        [ExcelIgnore]

        public decimal Ref05 { get; set; }

        [ExcelIgnore]

        public decimal Ref06 { get; set; }

        [ExcelIgnore]

        public string Udf01 { get; set; }

        [ExcelIgnore]

        public string Udf02 { get; set; }

        [ExcelIgnore]

        public string Udf03 { get; set; }

        [ExcelIgnore]

        public string Udf04 { get; set; }

        [ExcelIgnore]

        public string Udf05 { get; set; }

        [ExcelIgnore]

        public string Udf06 { get; set; }

        [ExcelIgnore]

        public int? Udf51 { get; set; }

        [ExcelIgnore]

        public int? Udf52 { get; set; }

        [ExcelIgnore]

        public int? Udf53 { get; set; }

        [ExcelIgnore]

        public decimal Udf54 { get; set; }

        [ExcelIgnore]

        public decimal Udf55 { get; set; }

        [ExcelIgnore]

        public decimal Udf56 { get; set; }

        [ExcelIgnore]

        public int? IsDeleted { get; set; }

        [ExcelIgnore]

        public string Remark { get; set; }

        [ExcelIgnore]

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "工厂")]
        public string Mc004Label { get; set; }
    }

    /// <summary>
    /// 工厂物料
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:30:16
    /// </summary>
    public class MmMarcImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Mc002 { get; set; }

        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Mc004 { get; set; }

        //[ExcelColumn(Name = "物料号")]
        [ExcelColumnName("物料号")]
        public string Mc003 { get; set; }

        //[ExcelColumn(Name = "维护状态")]
        [ExcelColumnName("维护状态")]
        public string Mc005 { get; set; }

        //[ExcelColumn(Name = "工厂级删除")]
        [ExcelColumnName("工厂级删除")]
        public string Mc006 { get; set; }

        //[ExcelColumn(Name = "评估类别")]
        [ExcelColumnName("评估类别")]
        public string Mc007 { get; set; }

        //[ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string Mc008 { get; set; }

        //[ExcelColumn(Name = "PS物料状态")]
        [ExcelColumnName("PS物料状态")]
        public string Mc009 { get; set; }

        //[ExcelColumn(Name = "有效起始日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效起始日")]
        public DateTime? Mc010 { get; set; }

        //[ExcelColumn(Name = "ABC标识")]
        [ExcelColumnName("ABC标识")]
        public string Mc011 { get; set; }

        //[ExcelColumn(Name = "关键部件")]
        [ExcelColumnName("关键部件")]
        public string Mc012 { get; set; }

        //[ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string Mc013 { get; set; }

        //[ExcelColumn(Name = "发货单位")]
        [ExcelColumnName("发货单位")]
        public string Mc014 { get; set; }

        //[ExcelColumn(Name = "MRP 参数文件")]
        [ExcelColumnName("MRP 参数文件")]
        public string Mc015 { get; set; }

        //[ExcelColumn(Name = "MRP 类型")]
        [ExcelColumnName("MRP 类型")]
        public string Mc016 { get; set; }

        //[ExcelColumn(Name = "MRP 控制者")]
        [ExcelColumnName("MRP 控制者")]
        public string Mc017 { get; set; }

        //[ExcelColumn(Name = "MRP 控制者买方")]
        [ExcelColumnName("MRP 控制者买方")]
        public string Mc018 { get; set; }

        [Required(ErrorMessage = "计划交货天数不能为空")]
        //[ExcelColumn(Name = "计划交货天数")]
        [ExcelColumnName("计划交货天数")]
        public decimal Mc019 { get; set; }

        [Required(ErrorMessage = "收货处理时间不能为空")]
        //[ExcelColumn(Name = "收货处理时间")]
        [ExcelColumnName("收货处理时间")]
        public decimal Mc020 { get; set; }

        //[ExcelColumn(Name = "期间标识")]
        [ExcelColumnName("期间标识")]
        public string Mc021 { get; set; }

        [Required(ErrorMessage = "装配报废不能为空")]
        //[ExcelColumn(Name = "装配报废")]
        [ExcelColumnName("装配报废")]
        public decimal Mc022 { get; set; }

        //[ExcelColumn(Name = "批量大小")]
        [ExcelColumnName("批量大小")]
        public string Mc023 { get; set; }

        //[ExcelColumn(Name = "采购")]
        [ExcelColumnName("采购")]
        public string Mc024 { get; set; }

        //[ExcelColumn(Name = "特殊采购")]
        [ExcelColumnName("特殊采购")]
        public string Mc025 { get; set; }

        [Required(ErrorMessage = "再订货点不能为空")]
        //[ExcelColumn(Name = "再订货点")]
        [ExcelColumnName("再订货点")]
        public decimal Mc026 { get; set; }

        [Required(ErrorMessage = "安全库存不能为空")]
        //[ExcelColumn(Name = "安全库存")]
        [ExcelColumnName("安全库存")]
        public decimal Mc027 { get; set; }

        [Required(ErrorMessage = "最小批量不能为空")]
        //[ExcelColumn(Name = "最小批量")]
        [ExcelColumnName("最小批量")]
        public decimal Mc028 { get; set; }

        [Required(ErrorMessage = "最大批量不能为空")]
        //[ExcelColumn(Name = "最大批量")]
        [ExcelColumnName("最大批量")]
        public decimal Mc029 { get; set; }

        [Required(ErrorMessage = "固定批量不能为空")]
        //[ExcelColumn(Name = "固定批量")]
        [ExcelColumnName("固定批量")]
        public decimal Mc030 { get; set; }

        //[ExcelColumn(Name = "舍入值")]
        [ExcelColumnName("舍入值")]
        public decimal Mc031 { get; set; }

        //[ExcelColumn(Name = "最大库存水平")]
        [ExcelColumnName("最大库存水平")]
        public decimal Mc032 { get; set; }

        [Required(ErrorMessage = "订购成本不能为空")]
        //[ExcelColumn(Name = "订购成本")]
        [ExcelColumnName("订购成本")]
        public decimal Mc033 { get; set; }

        //[ExcelColumn(Name = "独立/集中")]
        [ExcelColumnName("独立/集中")]
        public string Mc034 { get; set; }

        //[ExcelColumn(Name = "库存成本")]
        [ExcelColumnName("库存成本")]
        public string Mc035 { get; set; }

        //[ExcelColumn(Name = "选择方法")]
        [ExcelColumnName("选择方法")]
        public string Mc036 { get; set; }

        //[ExcelColumn(Name = "非连续标识")]
        [ExcelColumnName("非连续标识")]
        public string Mc037 { get; set; }

        //[ExcelColumn(Name = "中断日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("中断日期")]
        public DateTime? Mc038 { get; set; }

        //[ExcelColumn(Name = "后续物料")]
        [ExcelColumnName("后续物料")]
        public string Mc039 { get; set; }

        //[ExcelColumn(Name = "需求分组")]
        [ExcelColumnName("需求分组")]
        public string Mc040 { get; set; }

        //[ExcelColumn(Name = "综合MRP")]
        [ExcelColumnName("综合MRP")]
        public string Mc041 { get; set; }

        //[ExcelColumn(Name = "计划边际码")]
        [ExcelColumnName("计划边际码")]
        public string Mc042 { get; set; }

        //[ExcelColumn(Name = "自动更改工厂订单")]
        [ExcelColumnName("自动更改工厂订单")]
        public string Mc043 { get; set; }

        //[ExcelColumn(Name = "自动批准")]
        [ExcelColumnName("自动批准")]
        public string Mc044 { get; set; }

        //[ExcelColumn(Name = "反冲")]
        [ExcelColumnName("反冲")]
        public string Mc045 { get; set; }

        //[ExcelColumn(Name = "生产管理员")]
        [ExcelColumnName("生产管理员")]
        public string Mc046 { get; set; }

        [Required(ErrorMessage = "处理时间不能为空")]
        //[ExcelColumn(Name = "处理时间")]
        [ExcelColumnName("处理时间")]
        public decimal Mc047 { get; set; }

        [Required(ErrorMessage = "准备时间不能为空")]
        //[ExcelColumn(Name = "准备时间")]
        [ExcelColumnName("准备时间")]
        public decimal Mc048 { get; set; }

        [Required(ErrorMessage = "工序间不能为空")]
        //[ExcelColumn(Name = "工序间")]
        [ExcelColumnName("工序间")]
        public decimal Mc049 { get; set; }

        [Required(ErrorMessage = "基准数量不能为空")]
        //[ExcelColumn(Name = "基准数量")]
        [ExcelColumnName("基准数量")]
        public decimal Mc050 { get; set; }

        [Required(ErrorMessage = "厂内生产时间不能为空")]
        //[ExcelColumn(Name = "厂内生产时间")]
        [ExcelColumnName("厂内生产时间")]
        public decimal Mc051 { get; set; }

        [Required(ErrorMessage = "最大存储期间不能为空")]
        //[ExcelColumn(Name = "最大存储期间")]
        [ExcelColumnName("最大存储期间")]
        public decimal Mc052 { get; set; }

        //[ExcelColumn(Name = "时间单位")]
        [ExcelColumnName("时间单位")]
        public string Mc053 { get; set; }

        //[ExcelColumn(Name = "从产品货位库存")]
        [ExcelColumnName("从产品货位库存")]
        public string Mc054 { get; set; }

        //[ExcelColumn(Name = "初步计划")]
        [ExcelColumnName("初步计划")]
        public string Mc055 { get; set; }

        [Required(ErrorMessage = "超量交货容差不能为空")]
        //[ExcelColumn(Name = "超量交货容差")]
        [ExcelColumnName("超量交货容差")]
        public decimal Mc056 { get; set; }

        //[ExcelColumn(Name = "未限制")]
        [ExcelColumnName("未限制")]
        public string Mc057 { get; set; }

        [Required(ErrorMessage = "不足交货容差不能为空")]
        //[ExcelColumn(Name = "不足交货容差")]
        [ExcelColumnName("不足交货容差")]
        public decimal Mc058 { get; set; }

        [Required(ErrorMessage = "总计补货提前时间不能为空")]
        //[ExcelColumn(Name = "总计补货提前时间")]
        [ExcelColumnName("总计补货提前时间")]
        public decimal Mc059 { get; set; }

        //[ExcelColumn(Name = "替换部件")]
        [ExcelColumnName("替换部件")]
        public string Mc060 { get; set; }

        [Required(ErrorMessage = "附加费不能为空")]
        //[ExcelColumn(Name = "附加费")]
        [ExcelColumnName("附加费")]
        public decimal Mc061 { get; set; }

        //[ExcelColumn(Name = "生产状态")]
        [ExcelColumnName("生产状态")]
        public string Mc062 { get; set; }

        //[ExcelColumn(Name = "过帐到检验库存")]
        [ExcelColumnName("过帐到检验库存")]
        public string Mc063 { get; set; }

        [Required(ErrorMessage = "样本不能为空")]
        //[ExcelColumn(Name = "样本")]
        [ExcelColumnName("样本")]
        public decimal Mc064 { get; set; }

        //[ExcelColumn(Name = "隔离")]
        [ExcelColumnName("隔离")]
        public decimal Mc065 { get; set; }

        //[ExcelColumn(Name = "控制码")]
        [ExcelColumnName("控制码")]
        public string Mc066 { get; set; }

        //[ExcelColumn(Name = "平均检查持续期")]
        [ExcelColumnName("平均检查持续期")]
        public decimal Mc067 { get; set; }

        //[ExcelColumn(Name = "检查计划")]
        [ExcelColumnName("检查计划")]
        public string Mc068 { get; set; }

        //[ExcelColumn(Name = "凭证需求")]
        [ExcelColumnName("凭证需求")]
        public string Mc069 { get; set; }

        [Required(ErrorMessage = "活动性物质不能为空")]
        //[ExcelColumn(Name = "活动性物质")]
        [ExcelColumnName("活动性物质")]
        public decimal Mc070 { get; set; }

        [Required(ErrorMessage = "检查间隔不能为空")]
        //[ExcelColumn(Name = "检查间隔")]
        [ExcelColumnName("检查间隔")]
        public decimal Mc071 { get; set; }

        //[ExcelColumn(Name = "下一次检查", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("下一次检查")]
        public DateTime? Mc072 { get; set; }

        //[ExcelColumn(Name = "中转库存")]
        [ExcelColumnName("中转库存")]
        public decimal Mc073 { get; set; }

        //[ExcelColumn(Name = "装载组")]
        [ExcelColumnName("装载组")]
        public string Mc074 { get; set; }

        //[ExcelColumn(Name = "批次管理需求")]
        [ExcelColumnName("批次管理需求")]
        public string Mc075 { get; set; }

        //[ExcelColumn(Name = "配额使用")]
        [ExcelColumnName("配额使用")]
        public string Mc076 { get; set; }

        //[ExcelColumn(Name = "服务水平")]
        [ExcelColumnName("服务水平")]
        public decimal Mc077 { get; set; }

        //[ExcelColumn(Name = "分割标识")]
        [ExcelColumnName("分割标识")]
        public string Mc078 { get; set; }

        //[ExcelColumn(Name = "计划版本")]
        [ExcelColumnName("计划版本")]
        public string Mc079 { get; set; }

        //[ExcelColumn(Name = "对象类型")]
        [ExcelColumnName("对象类型")]
        public string Mc080 { get; set; }

        [Required(ErrorMessage = "对象标识不能为空")]
        //[ExcelColumn(Name = "对象标识")]
        [ExcelColumnName("对象标识")]
        public int Mc081 { get; set; }

        //[ExcelColumn(Name = "可用性检查")]
        [ExcelColumnName("可用性检查")]
        public string Mc082 { get; set; }

        //[ExcelColumn(Name = "会计年度变式")]
        [ExcelColumnName("会计年度变式")]
        public string Mc083 { get; set; }

        //[ExcelColumn(Name = "修正因子")]
        [ExcelColumnName("修正因子")]
        public string Mc084 { get; set; }

        [Required(ErrorMessage = "准备时间不能为空")]
        //[ExcelColumn(Name = "准备时间")]
        [ExcelColumnName("准备时间")]
        public decimal Mc085 { get; set; }

        [Required(ErrorMessage = "基准数量不能为空")]
        //[ExcelColumn(Name = "基准数量")]
        [ExcelColumnName("基准数量")]
        public decimal Mc086 { get; set; }

        [Required(ErrorMessage = "处理时间不能为空")]
        //[ExcelColumn(Name = "处理时间")]
        [ExcelColumnName("处理时间")]
        public decimal Mc087 { get; set; }

        //[ExcelColumn(Name = "取消激活的")]
        [ExcelColumnName("取消激活的")]
        public string Mc088 { get; set; }

        //[ExcelColumn(Name = "货源")]
        [ExcelColumnName("货源")]
        public string Mc089 { get; set; }

        //[ExcelColumn(Name = "自动采购订单")]
        [ExcelColumnName("自动采购订单")]
        public string Mc090 { get; set; }

        //[ExcelColumn(Name = "源清单")]
        [ExcelColumnName("源清单")]
        public string Mc091 { get; set; }

        //[ExcelColumn(Name = "商品代码")]
        [ExcelColumnName("商品代码")]
        public string Mc092 { get; set; }

        //[ExcelColumn(Name = "原产地国")]
        [ExcelColumnName("原产地国")]
        public string Mc093 { get; set; }

        //[ExcelColumn(Name = "货源地")]
        [ExcelColumnName("货源地")]
        public string Mc094 { get; set; }

        //[ExcelColumn(Name = "商品代码单位")]
        [ExcelColumnName("商品代码单位")]
        public string Mc095 { get; set; }

        //[ExcelColumn(Name = "出口/进口组")]
        [ExcelColumnName("出口/进口组")]
        public string Mc096 { get; set; }

        //[ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string Mc097 { get; set; }

        [Required(ErrorMessage = "在途库存不能为空")]
        //[ExcelColumn(Name = "在途库存")]
        [ExcelColumnName("在途库存")]
        public decimal Mc098 { get; set; }

        //[ExcelColumn(Name = "计划日历")]
        [ExcelColumnName("计划日历")]
        public string Mc099 { get; set; }

        //[ExcelColumn(Name = "重复生产")]
        [ExcelColumnName("重复生产")]
        public string Mc100 { get; set; }

        [Required(ErrorMessage = "计划的时界不能为空")]
        //[ExcelColumn(Name = "计划的时界")]
        [ExcelColumnName("计划的时界")]
        public int Mc101 { get; set; }

        //[ExcelColumn(Name = "消耗模式")]
        [ExcelColumnName("消耗模式")]
        public string Mc102 { get; set; }

        [Required(ErrorMessage = "消耗期间:逆向不能为空")]
        //[ExcelColumn(Name = "消耗期间:逆向")]
        [ExcelColumnName("消耗期间:逆向")]
        public int Mc103 { get; set; }

        [Required(ErrorMessage = "消耗时期-向前不能为空")]
        //[ExcelColumn(Name = "消耗时期-向前")]
        [ExcelColumnName("消耗时期-向前")]
        public int Mc104 { get; set; }

        //[ExcelColumn(Name = "版本")]
        [ExcelColumnName("版本")]
        public string Mc105 { get; set; }

        //[ExcelColumn(Name = "可选 BOM")]
        [ExcelColumnName("可选 BOM")]
        public string Mc106 { get; set; }

        //[ExcelColumn(Name = "BOM 用途")]
        [ExcelColumnName("BOM 用途")]
        public string Mc107 { get; set; }

        //[ExcelColumn(Name = "组")]
        [ExcelColumnName("组")]
        public string Mc108 { get; set; }

        //[ExcelColumn(Name = "组计数器")]
        [ExcelColumnName("组计数器")]
        public string Mc109 { get; set; }

        [Required(ErrorMessage = "成本核算批次不能为空")]
        //[ExcelColumn(Name = "成本核算批次")]
        [ExcelColumnName("成本核算批次")]
        public decimal Mc110 { get; set; }

        //[ExcelColumn(Name = "特殊工艺类型")]
        [ExcelColumnName("特殊工艺类型")]
        public string Mc111 { get; set; }

        //[ExcelColumn(Name = "生产单位")]
        [ExcelColumnName("生产单位")]
        public string Mc112 { get; set; }

        //[ExcelColumn(Name = "发货库存地点")]
        [ExcelColumnName("发货库存地点")]
        public string Mc113 { get; set; }

        //[ExcelColumn(Name = "MRP组")]
        [ExcelColumnName("MRP组")]
        public string Mc114 { get; set; }

        [Required(ErrorMessage = "组件报废不能为空")]
        //[ExcelColumn(Name = "组件报废")]
        [ExcelColumnName("组件报废")]
        public decimal Mc115 { get; set; }

        //[ExcelColumn(Name = "证书类型")]
        [ExcelColumnName("证书类型")]
        public string Mc116 { get; set; }

        //[ExcelColumn(Name = "检验设置")]
        [ExcelColumnName("检验设置")]
        public string Mc117 { get; set; }

        [Required(ErrorMessage = "间隔时间不能为空")]
        //[ExcelColumn(Name = "间隔时间")]
        [ExcelColumnName("间隔时间")]
        public decimal Mc118 { get; set; }

        //[ExcelColumn(Name = "供货天数参数文件")]
        [ExcelColumnName("供货天数参数文件")]
        public string Mc119 { get; set; }

        //[ExcelColumn(Name = "局部字段名")]
        [ExcelColumnName("局部字段名")]
        public string Mc120 { get; set; }

        //[ExcelColumn(Name = "周期盘点标识")]
        [ExcelColumnName("周期盘点标识")]
        public string Mc121 { get; set; }

        //[ExcelColumn(Name = "差异码")]
        [ExcelColumnName("差异码")]
        public string Mc122 { get; set; }

        //[ExcelColumn(Name = "序列号参数文件")]
        [ExcelColumnName("序列号参数文件")]
        public string Mc123 { get; set; }

        [Required(ErrorMessage = "内部对象号不能为空")]
        //[ExcelColumn(Name = "内部对象号")]
        [ExcelColumnName("内部对象号")]
        public int Mc124 { get; set; }

        //[ExcelColumn(Name = "可配置的物料")]
        [ExcelColumnName("可配置的物料")]
        public string Mc125 { get; set; }

        //[ExcelColumn(Name = "重复生产参数文件")]
        [ExcelColumnName("重复生产参数文件")]
        public string Mc126 { get; set; }

        //[ExcelColumn(Name = "负库存")]
        [ExcelColumnName("负库存")]
        public string Mc127 { get; set; }

        //[ExcelColumn(Name = "目标QM系统")]
        [ExcelColumnName("目标QM系统")]
        public string Mc128 { get; set; }

        //[ExcelColumn(Name = "计划周期")]
        [ExcelColumnName("计划周期")]
        public string Mc129 { get; set; }

        //[ExcelColumn(Name = "舍入参数文件")]
        [ExcelColumnName("舍入参数文件")]
        public string Mc130 { get; set; }

        //[ExcelColumn(Name = "消耗")]
        [ExcelColumnName("消耗")]
        public string Mc131 { get; set; }

        //[ExcelColumn(Name = "寄存")]
        [ExcelColumnName("寄存")]
        public string Mc132 { get; set; }

        //[ExcelColumn(Name = "消耗日期到", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("消耗日期到")]
        public DateTime? Mc133 { get; set; }

        [Required(ErrorMessage = "乘数不能为空")]
        //[ExcelColumn(Name = "乘数")]
        [ExcelColumnName("乘数")]
        public decimal Mc134 { get; set; }

        //[ExcelColumn(Name = "自动重置")]
        [ExcelColumnName("自动重置")]
        public string Mc135 { get; set; }

        //[ExcelColumn(Name = "优先权")]
        [ExcelColumnName("优先权")]
        public string Mc136 { get; set; }

        //[ExcelColumn(Name = "免税证明")]
        [ExcelColumnName("免税证明")]
        public string Mc137 { get; set; }

        //[ExcelColumn(Name = "免税证书编号")]
        [ExcelColumnName("免税证书编号")]
        public string Mc138 { get; set; }

        //[ExcelColumn(Name = "免税证书的发放日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("免税证书的发放日")]
        public DateTime? Mc139 { get; set; }

        //[ExcelColumn(Name = "供应商申报")]
        [ExcelColumnName("供应商申报")]
        public string Mc140 { get; set; }

        //[ExcelColumn(Name = "供应商申报日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("供应商申报日期")]
        public DateTime? Mc141 { get; set; }

        //[ExcelColumn(Name = "军用物资")]
        [ExcelColumnName("军用物资")]
        public string Mc142 { get; set; }

        //[ExcelColumn(Name = "服务级别")]
        [ExcelColumnName("服务级别")]
        public string Mc143 { get; set; }

        //[ExcelColumn(Name = "联产品")]
        [ExcelColumnName("联产品")]
        public string Mc144 { get; set; }

        //[ExcelColumn(Name = "策略组")]
        [ExcelColumnName("策略组")]
        public string Mc145 { get; set; }

        [Required(ErrorMessage = "内部对象号不能为空")]
        //[ExcelColumn(Name = "内部对象号")]
        [ExcelColumnName("内部对象号")]
        public int Mc146 { get; set; }

        //[ExcelColumn(Name = "外部采购仓储位置")]
        [ExcelColumnName("外部采购仓储位置")]
        public string Mc147 { get; set; }

        //[ExcelColumn(Name = "散装物料")]
        [ExcelColumnName("散装物料")]
        public string Mc148 { get; set; }

        //[ExcelColumn(Name = "周期标识被固定")]
        [ExcelColumnName("周期标识被固定")]
        public string Mc149 { get; set; }

        //[ExcelColumn(Name = "库存确定组")]
        [ExcelColumnName("库存确定组")]
        public string Mc150 { get; set; }

        //[ExcelColumn(Name = "QM 物料授权组")]
        [ExcelColumnName("QM 物料授权组")]
        public string Mc151 { get; set; }

        [Required(ErrorMessage = "调整期间不能为空")]
        //[ExcelColumn(Name = "调整期间")]
        [ExcelColumnName("调整期间")]
        public decimal Mc152 { get; set; }

        //[ExcelColumn(Name = "任务清单类型")]
        [ExcelColumnName("任务清单类型")]
        public string Mc153 { get; set; }

        //[ExcelColumn(Name = "计量单位组")]
        [ExcelColumnName("计量单位组")]
        public string Mc154 { get; set; }

        //[ExcelColumn(Name = "转换组")]
        [ExcelColumnName("转换组")]
        public string Mc155 { get; set; }

        [Required(ErrorMessage = "空气浮力因子不能为空")]
        //[ExcelColumn(Name = "空气浮力因子")]
        [ExcelColumnName("空气浮力因子")]
        public decimal Mc156 { get; set; }

        //[ExcelColumn(Name = "生产参数文件")]
        [ExcelColumnName("生产参数文件")]
        public string Mc157 { get; set; }

        //[ExcelColumn(Name = "安全时间标识")]
        [ExcelColumnName("安全时间标识")]
        public string Mc158 { get; set; }

        [Required(ErrorMessage = "安全时间不能为空")]
        //[ExcelColumn(Name = "安全时间")]
        [ExcelColumnName("安全时间")]
        public int Mc159 { get; set; }

        //[ExcelColumn(Name = "活动控制")]
        [ExcelColumnName("活动控制")]
        public string Mc160 { get; set; }

        //[ExcelColumn(Name = "批量输入")]
        [ExcelColumnName("批量输入")]
        public string Mc161 { get; set; }

        //[ExcelColumn(Name = "计量单位组")]
        [ExcelColumnName("计量单位组")]
        public string Mc162 { get; set; }

        //[ExcelColumn(Name = "物料运输组")]
        [ExcelColumnName("物料运输组")]
        public string Mc163 { get; set; }

        [Required(ErrorMessage = "库存转移SV不能为空")]
        //[ExcelColumn(Name = "库存转移SV")]
        [ExcelColumnName("库存转移SV")]
        public decimal Mc164 { get; set; }

        [Required(ErrorMessage = "运输库存SP不能为空")]
        //[ExcelColumn(Name = "运输库存SP")]
        [ExcelColumnName("运输库存SP")]
        public decimal Mc165 { get; set; }

        //[ExcelColumn(Name = "平滑促销消耗")]
        [ExcelColumnName("平滑促销消耗")]
        public string Mc166 { get; set; }

        //[ExcelColumn(Name = "生产版本")]
        [ExcelColumnName("生产版本")]
        public string Mc167 { get; set; }

        //[ExcelColumn(Name = "固定价格联产品")]
        [ExcelColumnName("固定价格联产品")]
        public string Mc168 { get; set; }

        //[ExcelColumn(Name = "后勤组")]
        [ExcelColumnName("后勤组")]
        public string Mc169 { get; set; }

        //[ExcelColumn(Name = "分销参数文件")]
        [ExcelColumnName("分销参数文件")]
        public string Mc170 { get; set; }

        [Required(ErrorMessage = "有约束的虚拟库存不能为空")]
        //[ExcelColumn(Name = "有约束的虚拟库存")]
        [ExcelColumnName("有约束的虚拟库存")]
        public decimal Mc171 { get; set; }

        [Required(ErrorMessage = "空缺库存销售价不能为空")]
        //[ExcelColumn(Name = "空缺库存销售价")]
        [ExcelColumnName("空缺库存销售价")]
        public decimal Mc172 { get; set; }

        //[ExcelColumn(Name = "物料类别")]
        [ExcelColumnName("物料类别")]
        public string Mc173 { get; set; }

        //[ExcelColumn(Name = "EU产品清单编号")]
        [ExcelColumnName("EU产品清单编号")]
        public string Mc174 { get; set; }

        //[ExcelColumn(Name = "CAP 产品组")]
        [ExcelColumnName("CAP 产品组")]
        public string Mc175 { get; set; }

        //[ExcelColumn(Name = "CAS 号码")]
        [ExcelColumnName("CAS 号码")]
        public string Mc176 { get; set; }

        //[ExcelColumn(Name = "PRODCOM 号码")]
        [ExcelColumnName("PRODCOM 号码")]
        public string Mc177 { get; set; }

        //[ExcelColumn(Name = "控制代码")]
        [ExcelColumnName("控制代码")]
        public string Mc178 { get; set; }

        //[ExcelColumn(Name = "JIT标识")]
        [ExcelColumnName("JIT标识")]
        public string Mc179 { get; set; }

        //[ExcelColumn(Name = "物料组")]
        [ExcelColumnName("物料组")]
        public string Mc180 { get; set; }

        //[ExcelColumn(Name = "建议供应区域")]
        [ExcelColumnName("建议供应区域")]
        public string Mc181 { get; set; }

        //[ExcelColumn(Name = "公平分享规则")]
        [ExcelColumnName("公平分享规则")]
        public string Mc182 { get; set; }

        //[ExcelColumn(Name = "推式分配")]
        [ExcelColumnName("推式分配")]
        public string Mc183 { get; set; }

        [Required(ErrorMessage = "发布界限不能为空")]
        //[ExcelColumn(Name = "发布界限")]
        [ExcelColumnName("发布界限")]
        public decimal Mc184 { get; set; }

        [Required(ErrorMessage = "最小批量不能为空")]
        //[ExcelColumn(Name = "最小批量")]
        [ExcelColumnName("最小批量")]
        public decimal Mc185 { get; set; }

        [Required(ErrorMessage = "最大批量不能为空")]
        //[ExcelColumn(Name = "最大批量")]
        [ExcelColumnName("最大批量")]
        public decimal Mc186 { get; set; }

        [Required(ErrorMessage = "固定批量不能为空")]
        //[ExcelColumn(Name = "固定批量")]
        [ExcelColumnName("固定批量")]
        public decimal Mc187 { get; set; }

        [Required(ErrorMessage = "批尺寸增加不能为空")]
        //[ExcelColumn(Name = "批尺寸增加")]
        [ExcelColumnName("批尺寸增加")]
        public decimal Mc188 { get; set; }

        [Required(ErrorMessage = "该字段不再使用不能为空")]
        //[ExcelColumn(Name = "该字段不再使用")]
        [ExcelColumnName("该字段不再使用")]
        public int Mc189 { get; set; }

        //[ExcelColumn(Name = "转换类型")]
        [ExcelColumnName("转换类型")]
        public string Mc190 { get; set; }

        //[ExcelColumn(Name = "ST期间参数文件")]
        [ExcelColumnName("ST期间参数文件")]
        public string Mc191 { get; set; }

        //[ExcelColumn(Name = "MRP 相关需求")]
        [ExcelColumnName("MRP 相关需求")]
        public string Mc192 { get; set; }

        //[ExcelColumn(Name = "MRP 范围存在")]
        [ExcelColumnName("MRP 范围存在")]
        public string Mc193 { get; set; }

        //[ExcelColumn(Name = "跨项目")]
        [ExcelColumnName("跨项目")]
        public string Mc194 { get; set; }

        //[ExcelColumn(Name = "总体参数文件")]
        [ExcelColumnName("总体参数文件")]
        public string Mc195 { get; set; }

        //[ExcelColumn(Name = "APO 相关")]
        [ExcelColumnName("APO 相关")]
        public string Mc196 { get; set; }

        //[ExcelColumn(Name = "最后的MARD")]
        [ExcelColumnName("最后的MARD")]
        public string Mc197 { get; set; }

        [Required(ErrorMessage = "当前期间 (记帐期间)不能为空")]
        //[ExcelColumn(Name = "当前期间 (记帐期间)")]
        [ExcelColumnName("当前期间 (记帐期间)")]
        public int Mc198 { get; set; }

        [Required(ErrorMessage = "当前期间的会计年度不能为空")]
        //[ExcelColumn(Name = "当前期间的会计年度")]
        [ExcelColumnName("当前期间的会计年度")]
        public int Mc199 { get; set; }

        [Required(ErrorMessage = "最小安全库存不能为空")]
        //[ExcelColumn(Name = "最小安全库存")]
        [ExcelColumnName("最小安全库存")]
        public decimal Mc200 { get; set; }

        //[ExcelColumn(Name = "无成本核算")]
        [ExcelColumnName("无成本核算")]
        public string Mc201 { get; set; }

        //[ExcelColumn(Name = "库存入库和出库")]
        [ExcelColumnName("库存入库和出库")]
        public string Mc202 { get; set; }

        //[ExcelColumn(Name = "OB管理")]
        [ExcelColumnName("OB管理")]
        public string Mc203 { get; set; }

        //[ExcelColumn(Name = "OB参考物料")]
        [ExcelColumnName("OB参考物料")]
        public string Mc204 { get; set; }

        [Required(ErrorMessage = "评估收货锁定库存不能为空")]
        //[ExcelColumn(Name = "评估收货锁定库存")]
        [ExcelColumnName("评估收货锁定库存")]
        public decimal Mc205 { get; set; }

        //[ExcelColumn(Name = "分段策略")]
        [ExcelColumnName("分段策略")]
        public string Mc206 { get; set; }

        //[ExcelColumn(Name = "分段状态")]
        [ExcelColumnName("分段状态")]
        public string Mc207 { get; set; }

        //[ExcelColumn(Name = "分段范围")]
        [ExcelColumnName("分段范围")]
        public string Mc208 { get; set; }

        //[ExcelColumn(Name = "排序库存")]
        [ExcelColumnName("排序库存")]
        public string Mc209 { get; set; }

        //[ExcelColumn(Name = "消耗优先级")]
        [ExcelColumnName("消耗优先级")]
        public string Mc210 { get; set; }

        //[ExcelColumn(Name = "离散批次编号")]
        [ExcelColumnName("离散批次编号")]
        public string Mc211 { get; set; }

        //[ExcelColumn(Name = "库存保护")]
        [ExcelColumnName("库存保护")]
        public string Mc212 { get; set; }

        //[ExcelColumn(Name = "订单分配运行")]
        [ExcelColumnName("订单分配运行")]
        public string Mc213 { get; set; }

        //[ExcelColumn(Name = "库存管理中激活季节")]
        [ExcelColumnName("库存管理中激活季节")]
        public string Mc214 { get; set; }

        //[ExcelColumn(Name = "包装组 (VSO)")]
        [ExcelColumnName("包装组 (VSO)")]
        public string Mc215 { get; set; }

        //[ExcelColumn(Name = "提货行 (VSO)")]
        [ExcelColumnName("提货行 (VSO)")]
        public string Mc216 { get; set; }

        //[ExcelColumn(Name = "物料编号 (VSO)")]
        [ExcelColumnName("物料编号 (VSO)")]
        public string Mc217 { get; set; }

        //[ExcelColumn(Name = "纵向提取")]
        [ExcelColumnName("纵向提取")]
        public string Mc218 { get; set; }

        //[ExcelColumn(Name = "IUID相关")]
        [ExcelColumnName("IUID相关")]
        public string Mc219 { get; set; }

        //[ExcelColumn(Name = "IUID类型")]
        [ExcelColumnName("IUID类型")]
        public string Mc220 { get; set; }

        //[ExcelColumn(Name = "外部分配")]
        [ExcelColumnName("外部分配")]
        public string Mc221 { get; set; }

        //[ExcelColumn(Name = "寄售控制")]
        [ExcelColumnName("寄售控制")]
        public string Mc222 { get; set; }

        [Required(ErrorMessage = "发货处理时间不能为空")]
        //[ExcelColumn(Name = "发货处理时间")]
        [ExcelColumnName("发货处理时间")]
        public decimal Mc223 { get; set; }

        //[ExcelColumn(Name = "交叉的采购组")]
        [ExcelColumnName("交叉的采购组")]
        public string Mc224 { get; set; }

        //[ExcelColumn(Name = "参考确定方案")]
        [ExcelColumnName("参考确定方案")]
        public string Mc225 { get; set; }

        [Required(ErrorMessage = "最小目标范围不能为空")]
        //[ExcelColumn(Name = "最小目标范围")]
        [ExcelColumnName("最小目标范围")]
        public int Mc226 { get; set; }

        [Required(ErrorMessage = "最大目标范围不能为空")]
        //[ExcelColumn(Name = "最大目标范围")]
        [ExcelColumnName("最大目标范围")]
        public int Mc227 { get; set; }

        [Required(ErrorMessage = "目标库存不能为空")]
        //[ExcelColumn(Name = "目标库存")]
        [ExcelColumnName("目标库存")]
        public decimal Mc228 { get; set; }

        [ExcelIgnore]
        public string Ref01 { get; set; }

        [ExcelIgnore]
        public string Ref02 { get; set; }

        [ExcelIgnore]
        public string Ref03 { get; set; }

        [ExcelIgnore]
        public decimal Ref04 { get; set; }

        [ExcelIgnore]
        public decimal Ref05 { get; set; }

        [ExcelIgnore]
        public decimal Ref06 { get; set; }

        [ExcelIgnore]
        public string Udf01 { get; set; }

        [ExcelIgnore]
        public string Udf02 { get; set; }

        [ExcelIgnore]
        public string Udf03 { get; set; }

        [ExcelIgnore]
        public string Udf04 { get; set; }

        [ExcelIgnore]
        public string Udf05 { get; set; }

        [ExcelIgnore]
        public string Udf06 { get; set; }

        [ExcelIgnore]
        public int? Udf51 { get; set; }

        [ExcelIgnore]
        public int? Udf52 { get; set; }

        [ExcelIgnore]
        public int? Udf53 { get; set; }

        [ExcelIgnore]
        public decimal Udf54 { get; set; }

        [ExcelIgnore]
        public decimal Udf55 { get; set; }

        [ExcelIgnore]
        public decimal Udf56 { get; set; }

        [ExcelIgnore]
        public int? IsDeleted { get; set; }

        [ExcelIgnore]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string Mc004Label { get; set; }
    }

}