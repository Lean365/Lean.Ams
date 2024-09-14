
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 常规物料
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 10:59:57
    /// </summary>
    public class MmMaraQueryDto : PagerInfo 
    {
        /// <summary>
        /// 物料号 
        /// </summary>        
        public string Ma003 { get; set; }
        /// <summary>
        /// 物料类型 
        /// </summary>        
        public string Ma007 { get; set; }
        /// <summary>
        /// 行业领域 
        /// </summary>        
        public string Ma008 { get; set; }
        /// <summary>
        /// 基本单位 
        /// </summary>        
        public string Ma011 { get; set; }
    }

    /// <summary>
    /// 常规物料
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 10:59:57
    /// </summary>
    public class MmMaraDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]

        public string Ma002 { get; set; }

        [Required(ErrorMessage = "物料号不能为空")]
        //[ExcelColumn(Name = "物料号")]
        [ExcelColumnName("物料号")]

        public string Ma003 { get; set; }

        //[ExcelColumn(Name = "完整状态")]
        [ExcelColumnName("完整状态")]

        public string Ma004 { get; set; }

        //[ExcelColumn(Name = "维护状态")]
        [ExcelColumnName("维护状态")]

        public string Ma005 { get; set; }

        //[ExcelColumn(Name = "集团删除")]
        [ExcelColumnName("集团删除")]

        public string Ma006 { get; set; }

        [Required(ErrorMessage = "物料类型不能为空")]
        //[ExcelColumn(Name = "物料类型")]
        [ExcelColumnName("物料类型")]

        public string Ma007 { get; set; }

        [Required(ErrorMessage = "行业领域不能为空")]
        //[ExcelColumn(Name = "行业领域")]
        [ExcelColumnName("行业领域")]

        public string Ma008 { get; set; }

        //[ExcelColumn(Name = "物料组")]
        [ExcelColumnName("物料组")]

        public string Ma009 { get; set; }

        //[ExcelColumn(Name = "旧物料号")]
        [ExcelColumnName("旧物料号")]

        public string Ma010 { get; set; }

        [Required(ErrorMessage = "基本单位不能为空")]
        //[ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]

        public string Ma011 { get; set; }

        //[ExcelColumn(Name = "订单单位")]
        [ExcelColumnName("订单单位")]

        public string Ma012 { get; set; }

        //[ExcelColumn(Name = "凭证")]
        [ExcelColumnName("凭证")]

        public string Ma013 { get; set; }

        //[ExcelColumn(Name = "凭证类型")]
        [ExcelColumnName("凭证类型")]

        public string Ma014 { get; set; }

        //[ExcelColumn(Name = "凭证版本")]
        [ExcelColumnName("凭证版本")]

        public string Ma015 { get; set; }

        //[ExcelColumn(Name = "页面大小")]
        [ExcelColumnName("页面大小")]

        public string Ma016 { get; set; }

        //[ExcelColumn(Name = "文档变更号")]
        [ExcelColumnName("文档变更号")]

        public string Ma017 { get; set; }

        //[ExcelColumn(Name = "页号")]
        [ExcelColumnName("页号")]

        public string Ma018 { get; set; }

        [Required(ErrorMessage = "页数不能为空")]
        //[ExcelColumn(Name = "页数")]
        [ExcelColumnName("页数")]

        public int Ma019 { get; set; }

        //[ExcelColumn(Name = "备忘录")]
        [ExcelColumnName("备忘录")]

        public string Ma020 { get; set; }

        //[ExcelColumn(Name = "页格式")]
        [ExcelColumnName("页格式")]

        public string Ma021 { get; set; }

        //[ExcelColumn(Name = "大小/量纲")]
        [ExcelColumnName("大小/量纲")]

        public string Ma022 { get; set; }

        //[ExcelColumn(Name = "基本物料")]
        [ExcelColumnName("基本物料")]

        public string Ma023 { get; set; }

        //[ExcelColumn(Name = "行业标准")]
        [ExcelColumnName("行业标准")]

        public string Ma024 { get; set; }

        //[ExcelColumn(Name = "实验室/设计室")]
        [ExcelColumnName("实验室/设计室")]

        public string Ma025 { get; set; }

        //[ExcelColumn(Name = "采购值代码")]
        [ExcelColumnName("采购值代码")]

        public string Ma026 { get; set; }

        [Required(ErrorMessage = "毛重不能为空")]
        //[ExcelColumn(Name = "毛重")]
        [ExcelColumnName("毛重")]

        public decimal Ma027 { get; set; }

        [Required(ErrorMessage = "净重不能为空")]
        //[ExcelColumn(Name = "净重")]
        [ExcelColumnName("净重")]

        public decimal Ma028 { get; set; }

        //[ExcelColumn(Name = "重量单位")]
        [ExcelColumnName("重量单位")]

        public string Ma029 { get; set; }

        [Required(ErrorMessage = "业务量不能为空")]
        //[ExcelColumn(Name = "业务量")]
        [ExcelColumnName("业务量")]

        public decimal Ma030 { get; set; }

        //[ExcelColumn(Name = "体积单位")]
        [ExcelColumnName("体积单位")]

        public string Ma031 { get; set; }

        //[ExcelColumn(Name = "容器需求")]
        [ExcelColumnName("容器需求")]

        public string Ma032 { get; set; }

        //[ExcelColumn(Name = "存储条件")]
        [ExcelColumnName("存储条件")]

        public string Ma033 { get; set; }

        //[ExcelColumn(Name = "温度")]
        [ExcelColumnName("温度")]

        public string Ma034 { get; set; }

        //[ExcelColumn(Name = "低层代码")]
        [ExcelColumnName("低层代码")]

        public string Ma035 { get; set; }

        //[ExcelColumn(Name = "运输组")]
        [ExcelColumnName("运输组")]

        public string Ma036 { get; set; }

        //[ExcelColumn(Name = "危险物料号")]
        [ExcelColumnName("危险物料号")]

        public string Ma037 { get; set; }

        //[ExcelColumn(Name = "产品组")]
        [ExcelColumnName("产品组")]

        public string Ma038 { get; set; }

        //[ExcelColumn(Name = "竞争者")]
        [ExcelColumnName("竞争者")]

        public string Ma039 { get; set; }

        //[ExcelColumn(Name = "EAN号")]
        [ExcelColumnName("EAN号")]

        public string Ma040 { get; set; }

        [Required(ErrorMessage = "GR单数量不能为空")]
        //[ExcelColumn(Name = "GR单数量")]
        [ExcelColumnName("GR单数量")]

        public decimal Ma041 { get; set; }

        //[ExcelColumn(Name = "采购规则")]
        [ExcelColumnName("采购规则")]

        public string Ma042 { get; set; }

        //[ExcelColumn(Name = "货源")]
        [ExcelColumnName("货源")]

        public string Ma043 { get; set; }

        //[ExcelColumn(Name = "季节")]
        [ExcelColumnName("季节")]

        public string Ma044 { get; set; }

        //[ExcelColumn(Name = "标签类型")]
        [ExcelColumnName("标签类型")]

        public string Ma045 { get; set; }

        //[ExcelColumn(Name = "标签格式")]
        [ExcelColumnName("标签格式")]

        public string Ma046 { get; set; }

        //[ExcelColumn(Name = "取消激活")]
        [ExcelColumnName("取消激活")]

        public string Ma047 { get; set; }

        //[ExcelColumn(Name = "EAN")]
        [ExcelColumnName("EAN")]

        public string Ma048 { get; set; }

        //[ExcelColumn(Name = "EAN类别")]
        [ExcelColumnName("EAN类别")]

        public string Ma049 { get; set; }

        [Required(ErrorMessage = "长度不能为空")]
        //[ExcelColumn(Name = "长度")]
        [ExcelColumnName("长度")]

        public decimal Ma050 { get; set; }

        [Required(ErrorMessage = "宽度不能为空")]
        //[ExcelColumn(Name = "宽度")]
        [ExcelColumnName("宽度")]

        public decimal Ma051 { get; set; }

        [Required(ErrorMessage = "高度不能为空")]
        //[ExcelColumn(Name = "高度")]
        [ExcelColumnName("高度")]

        public decimal Ma052 { get; set; }

        //[ExcelColumn(Name = "尺寸单位")]
        [ExcelColumnName("尺寸单位")]

        public string Ma053 { get; set; }

        //[ExcelColumn(Name = "产品层次")]
        [ExcelColumnName("产品层次")]

        public string Ma054 { get; set; }

        //[ExcelColumn(Name = "净改变成本核算")]
        [ExcelColumnName("净改变成本核算")]

        public string Ma055 { get; set; }

        //[ExcelColumn(Name = "CAD标识")]
        [ExcelColumnName("CAD标识")]

        public string Ma056 { get; set; }

        //[ExcelColumn(Name = "QM采购")]
        [ExcelColumnName("QM采购")]

        public string Ma057 { get; set; }

        [Required(ErrorMessage = "允许的包装重量不能为空")]
        //[ExcelColumn(Name = "允许的包装重量")]
        [ExcelColumnName("允许的包装重量")]

        public decimal Ma058 { get; set; }

        //[ExcelColumn(Name = "重量单位")]
        [ExcelColumnName("重量单位")]

        public string Ma059 { get; set; }

        [Required(ErrorMessage = "允许体积不能为空")]
        //[ExcelColumn(Name = "允许体积")]
        [ExcelColumnName("允许体积")]

        public decimal Ma060 { get; set; }

        //[ExcelColumn(Name = "体积单位")]
        [ExcelColumnName("体积单位")]

        public string Ma061 { get; set; }

        [Required(ErrorMessage = "超重量容差不能为空")]
        //[ExcelColumn(Name = "超重量容差")]
        [ExcelColumnName("超重量容差")]

        public decimal Ma062 { get; set; }

        [Required(ErrorMessage = "超体积容差不能为空")]
        //[ExcelColumn(Name = "超体积容差")]
        [ExcelColumnName("超体积容差")]

        public decimal Ma063 { get; set; }

        //[ExcelColumn(Name = "可变订单单位")]
        [ExcelColumnName("可变订单单位")]

        public string Ma064 { get; set; }

        //[ExcelColumn(Name = "修订等级")]
        [ExcelColumnName("修订等级")]

        public string Ma065 { get; set; }

        //[ExcelColumn(Name = "可配置")]
        [ExcelColumnName("可配置")]

        public string Ma066 { get; set; }

        //[ExcelColumn(Name = "批次管理需求")]
        [ExcelColumnName("批次管理需求")]

        public string Ma067 { get; set; }

        //[ExcelColumn(Name = "包装物料类型")]
        [ExcelColumnName("包装物料类型")]

        public string Ma068 { get; set; }

        [Required(ErrorMessage = "最大层次不能为空")]
        //[ExcelColumn(Name = "最大层次")]
        [ExcelColumnName("最大层次")]

        public decimal Ma069 { get; set; }

        [Required(ErrorMessage = "堆栈因子不能为空")]
        //[ExcelColumn(Name = "堆栈因子")]
        [ExcelColumnName("堆栈因子")]

        public int Ma070 { get; set; }

        //[ExcelColumn(Name = "物料组包装物料")]
        [ExcelColumnName("物料组包装物料")]

        public string Ma071 { get; set; }

        //[ExcelColumn(Name = "权限组")]
        [ExcelColumnName("权限组")]

        public string Ma072 { get; set; }

        //[ExcelColumn(Name = "有效起始日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效起始日")]

        public DateTime? Ma073 { get; set; }

        //[ExcelColumn(Name = "有效结束日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效结束日")]

        public DateTime? Ma074 { get; set; }

        //[ExcelColumn(Name = "季度年")]
        [ExcelColumnName("季度年")]

        public string Ma075 { get; set; }

        //[ExcelColumn(Name = "价格标记")]
        [ExcelColumnName("价格标记")]

        public string Ma076 { get; set; }

        //[ExcelColumn(Name = "空白BOM")]
        [ExcelColumnName("空白BOM")]

        public string Ma077 { get; set; }

        //[ExcelColumn(Name = "外部物料组")]
        [ExcelColumnName("外部物料组")]

        public string Ma078 { get; set; }

        //[ExcelColumn(Name = "一般可配置物料")]
        [ExcelColumnName("一般可配置物料")]

        public string Ma079 { get; set; }

        //[ExcelColumn(Name = "物料类别")]
        [ExcelColumnName("物料类别")]

        public string Ma080 { get; set; }

        //[ExcelColumn(Name = "联产品")]
        [ExcelColumnName("联产品")]

        public string Ma081 { get; set; }

        //[ExcelColumn(Name = "后续物料")]
        [ExcelColumnName("后续物料")]

        public string Ma082 { get; set; }

        //[ExcelColumn(Name = "定价参考物料")]
        [ExcelColumnName("定价参考物料")]

        public string Ma083 { get; set; }

        //[ExcelColumn(Name = "跨工厂状态")]
        [ExcelColumnName("跨工厂状态")]

        public string Ma084 { get; set; }

        //[ExcelColumn(Name = "跨分销链状态")]
        [ExcelColumnName("跨分销链状态")]

        public string Ma085 { get; set; }

        //[ExcelColumn(Name = "跨工厂有效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("跨工厂有效日期")]

        public DateTime? Ma086 { get; set; }

        //[ExcelColumn(Name = "跨分销有效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("跨分销有效日期")]

        public DateTime? Ma087 { get; set; }

        //[ExcelColumn(Name = "税收分类")]
        [ExcelColumnName("税收分类")]

        public string Ma088 { get; set; }

        //[ExcelColumn(Name = "类别参数文件")]
        [ExcelColumnName("类别参数文件")]

        public string Ma089 { get; set; }

        [Required(ErrorMessage = "剩余货架寿命不能为空")]
        //[ExcelColumn(Name = "剩余货架寿命")]
        [ExcelColumnName("剩余货架寿命")]

        public decimal Ma090 { get; set; }

        [Required(ErrorMessage = "总货架寿命不能为空")]
        //[ExcelColumn(Name = "总货架寿命")]
        [ExcelColumnName("总货架寿命")]

        public decimal Ma091 { get; set; }

        [Required(ErrorMessage = "仓储百分比不能为空")]
        //[ExcelColumn(Name = "仓储百分比")]
        [ExcelColumnName("仓储百分比")]

        public decimal Ma092 { get; set; }

        //[ExcelColumn(Name = "内容单位")]
        [ExcelColumnName("内容单位")]

        public string Ma093 { get; set; }

        [Required(ErrorMessage = "净内容不能为空")]
        //[ExcelColumn(Name = "净内容")]
        [ExcelColumnName("净内容")]

        public decimal Ma094 { get; set; }

        [Required(ErrorMessage = "比较价格单位不能为空")]
        //[ExcelColumn(Name = "比较价格单位")]
        [ExcelColumnName("比较价格单位")]

        public decimal Ma095 { get; set; }

        //[ExcelColumn(Name = "物料组标签")]
        [ExcelColumnName("物料组标签")]

        public string Ma096 { get; set; }

        [Required(ErrorMessage = "毛内容不能为空")]
        //[ExcelColumn(Name = "毛内容")]
        [ExcelColumnName("毛内容")]

        public decimal Ma097 { get; set; }

        //[ExcelColumn(Name = "转换方法")]
        [ExcelColumnName("转换方法")]

        public string Ma098 { get; set; }

        [Required(ErrorMessage = "内部对象号不能为空")]
        //[ExcelColumn(Name = "内部对象号")]
        [ExcelColumnName("内部对象号")]

        public int Ma099 { get; set; }

        //[ExcelColumn(Name = "环境相关")]
        [ExcelColumnName("环境相关")]

        public string Ma100 { get; set; }

        //[ExcelColumn(Name = "产品分配")]
        [ExcelColumnName("产品分配")]

        public string Ma101 { get; set; }

        //[ExcelColumn(Name = "定价参数文件")]
        [ExcelColumnName("定价参数文件")]

        public string Ma102 { get; set; }

        //[ExcelColumn(Name = "折扣类型")]
        [ExcelColumnName("折扣类型")]

        public string Ma103 { get; set; }

        //[ExcelColumn(Name = "制造商零件编号")]
        [ExcelColumnName("制造商零件编号")]

        public string Ma104 { get; set; }

        //[ExcelColumn(Name = "制造商")]
        [ExcelColumnName("制造商")]

        public string Ma105 { get; set; }

        //[ExcelColumn(Name = "内部物料编号")]
        [ExcelColumnName("内部物料编号")]

        public string Ma106 { get; set; }

        //[ExcelColumn(Name = "制造商部件参数文件")]
        [ExcelColumnName("制造商部件参数文件")]

        public string Ma107 { get; set; }

        //[ExcelColumn(Name = "测量单位用法")]
        [ExcelColumnName("测量单位用法")]

        public string Ma108 { get; set; }

        //[ExcelColumn(Name = "展开")]
        [ExcelColumnName("展开")]

        public string Ma109 { get; set; }

        //[ExcelColumn(Name = "危险货物标识参数文件")]
        [ExcelColumnName("危险货物标识参数文件")]

        public string Ma110 { get; set; }

        //[ExcelColumn(Name = "高粘性的")]
        [ExcelColumnName("高粘性的")]

        public string Ma111 { get; set; }

        //[ExcelColumn(Name = "固体/液体")]
        [ExcelColumnName("固体/液体")]

        public string Ma112 { get; set; }

        //[ExcelColumn(Name = "序列号层次")]
        [ExcelColumnName("序列号层次")]

        public string Ma113 { get; set; }

        //[ExcelColumn(Name = "密闭")]
        [ExcelColumnName("密闭")]

        public string Ma114 { get; set; }

        //[ExcelColumn(Name = "需要批量记录")]
        [ExcelColumnName("需要批量记录")]

        public string Ma115 { get; set; }

        //[ExcelColumn(Name = "参数有效值")]
        [ExcelColumnName("参数有效值")]

        public string Ma116 { get; set; }

        [Required(ErrorMessage = "完成水平不能为空")]
        //[ExcelColumn(Name = "完成水平")]
        [ExcelColumnName("完成水平")]

        public int Ma117 { get; set; }

        //[ExcelColumn(Name = "期间标识")]
        [ExcelColumnName("期间标识")]

        public string Ma118 { get; set; }

        //[ExcelColumn(Name = "舍入规则")]
        [ExcelColumnName("舍入规则")]

        public string Ma119 { get; set; }

        //[ExcelColumn(Name = "产品成份")]
        [ExcelColumnName("产品成份")]

        public string Ma120 { get; set; }

        //[ExcelColumn(Name = "普通项目类别组")]
        [ExcelColumnName("普通项目类别组")]

        public string Ma121 { get; set; }

        //[ExcelColumn(Name = "后勤变量")]
        [ExcelColumnName("后勤变量")]

        public string Ma122 { get; set; }

        //[ExcelColumn(Name = "物料被锁定")]
        [ExcelColumnName("物料被锁定")]

        public string Ma123 { get; set; }

        //[ExcelColumn(Name = "配置相关")]
        [ExcelColumnName("配置相关")]

        public string Ma124 { get; set; }

        //[ExcelColumn(Name = "分类清单类型")]
        [ExcelColumnName("分类清单类型")]

        public string Ma125 { get; set; }

        //[ExcelColumn(Name = "过期日期")]
        [ExcelColumnName("过期日期")]

        public string Ma126 { get; set; }

        //[ExcelColumn(Name = "EAN变式")]
        [ExcelColumnName("EAN变式")]

        public string Ma127 { get; set; }

        //[ExcelColumn(Name = "一般物料")]
        [ExcelColumnName("一般物料")]

        public string Ma128 { get; set; }

        //[ExcelColumn(Name = "包装参考物料")]
        [ExcelColumnName("包装参考物料")]

        public string Ma129 { get; set; }

        //[ExcelColumn(Name = "GDS相关")]
        [ExcelColumnName("GDS相关")]

        public string Ma130 { get; set; }

        //[ExcelColumn(Name = "原始接受")]
        [ExcelColumnName("原始接受")]

        public string Ma131 { get; set; }

        //[ExcelColumn(Name = "标准处理单位类型")]
        [ExcelColumnName("标准处理单位类型")]

        public string Ma132 { get; set; }

        //[ExcelColumn(Name = "可偷窃的")]
        [ExcelColumnName("可偷窃的")]

        public string Ma133 { get; set; }

        //[ExcelColumn(Name = "仓库存储条件")]
        [ExcelColumnName("仓库存储条件")]

        public string Ma134 { get; set; }

        //[ExcelColumn(Name = "仓库物料组")]
        [ExcelColumnName("仓库物料组")]

        public string Ma135 { get; set; }

        //[ExcelColumn(Name = "处理标识")]
        [ExcelColumnName("处理标识")]

        public string Ma136 { get; set; }

        //[ExcelColumn(Name = "危险物料")]
        [ExcelColumnName("危险物料")]

        public string Ma137 { get; set; }

        //[ExcelColumn(Name = "处理单位类型")]
        [ExcelColumnName("处理单位类型")]

        public string Ma138 { get; set; }

        //[ExcelColumn(Name = "可变皮重")]
        [ExcelColumnName("可变皮重")]

        public string Ma139 { get; set; }

        [Required(ErrorMessage = "最大容量不能为空")]
        //[ExcelColumn(Name = "最大容量")]
        [ExcelColumnName("最大容量")]

        public decimal Ma140 { get; set; }

        [Required(ErrorMessage = "最大容量容差不能为空")]
        //[ExcelColumn(Name = "最大容量容差")]
        [ExcelColumnName("最大容量容差")]

        public decimal Ma141 { get; set; }

        [Required(ErrorMessage = "最大长度不能为空")]
        //[ExcelColumn(Name = "最大长度")]
        [ExcelColumnName("最大长度")]

        public decimal Ma142 { get; set; }

        [Required(ErrorMessage = "最大宽度不能为空")]
        //[ExcelColumn(Name = "最大宽度")]
        [ExcelColumnName("最大宽度")]

        public decimal Ma143 { get; set; }

        [Required(ErrorMessage = "最大高度不能为空")]
        //[ExcelColumn(Name = "最大高度")]
        [ExcelColumnName("最大高度")]

        public decimal Ma144 { get; set; }

        //[ExcelColumn(Name = "计量单位")]
        [ExcelColumnName("计量单位")]

        public string Ma145 { get; set; }

        //[ExcelColumn(Name = "原产地国")]
        [ExcelColumnName("原产地国")]

        public string Ma146 { get; set; }

        //[ExcelColumn(Name = "物料运输组")]
        [ExcelColumnName("物料运输组")]

        public string Ma147 { get; set; }

        [Required(ErrorMessage = "隔离期间不能为空")]
        //[ExcelColumn(Name = "隔离期间")]
        [ExcelColumnName("隔离期间")]

        public decimal Ma148 { get; set; }

        //[ExcelColumn(Name = "时间单位")]
        [ExcelColumnName("时间单位")]

        public string Ma149 { get; set; }

        //[ExcelColumn(Name = "质量检查组")]
        [ExcelColumnName("质量检查组")]

        public string Ma150 { get; set; }

        //[ExcelColumn(Name = "序列号参数文件")]
        [ExcelColumnName("序列号参数文件")]

        public string Ma151 { get; set; }

        //[ExcelColumn(Name = "表格名")]
        [ExcelColumnName("表格名")]

        public string Ma152 { get; set; }

        //[ExcelColumn(Name = "后勤计量单位")]
        [ExcelColumnName("后勤计量单位")]

        public string Ma153 { get; set; }

        //[ExcelColumn(Name = "称重物料相关")]
        [ExcelColumnName("称重物料相关")]

        public string Ma154 { get; set; }

        //[ExcelColumn(Name = "CW参数文件")]
        [ExcelColumnName("CW参数文件")]

        public string Ma155 { get; set; }

        //[ExcelColumn(Name = "CW容差组")]
        [ExcelColumnName("CW容差组")]

        public string Ma156 { get; set; }

        //[ExcelColumn(Name = "调整参数文件")]
        [ExcelColumnName("调整参数文件")]

        public string Ma157 { get; set; }

        //[ExcelColumn(Name = "知识产权")]
        [ExcelColumnName("知识产权")]

        public string Ma158 { get; set; }

        //[ExcelColumn(Name = "允许的变式价格")]
        [ExcelColumnName("允许的变式价格")]

        public string Ma159 { get; set; }

        //[ExcelColumn(Name = "中间")]
        [ExcelColumnName("中间")]

        public string Ma160 { get; set; }

        //[ExcelColumn(Name = "实物商品")]
        [ExcelColumnName("实物商品")]

        public string Ma161 { get; set; }

        //[ExcelColumn(Name = "动物源")]
        [ExcelColumnName("动物源")]

        public string Ma162 { get; set; }

        //[ExcelColumn(Name = "纺织组分功能")]
        [ExcelColumnName("纺织组分功能")]

        public string Ma163 { get; set; }

        //[ExcelColumn(Name = "分段结构")]
        [ExcelColumnName("分段结构")]

        public string Ma164 { get; set; }

        //[ExcelColumn(Name = "分段策略")]
        [ExcelColumnName("分段策略")]

        public string Ma165 { get; set; }

        //[ExcelColumn(Name = "分段状态")]
        [ExcelColumnName("分段状态")]

        public string Ma166 { get; set; }

        //[ExcelColumn(Name = "分段范围")]
        [ExcelColumnName("分段范围")]

        public string Ma167 { get; set; }

        //[ExcelColumn(Name = "分段相关")]
        [ExcelColumnName("分段相关")]

        public string Ma168 { get; set; }

        [Required(ErrorMessage = "ANP Code不能为空")]
        //[ExcelColumn(Name = "ANP Code")]
        [ExcelColumnName("ANP Code")]

        public int Ma169 { get; set; }

        //[ExcelColumn(Name = "Fashion属性1")]
        [ExcelColumnName("Fashion属性1")]

        public string Ma170 { get; set; }

        //[ExcelColumn(Name = "Fashion属性2")]
        [ExcelColumnName("Fashion属性2")]

        public string Ma171 { get; set; }

        //[ExcelColumn(Name = "Fashion属性3")]
        [ExcelColumnName("Fashion属性3")]

        public string Ma172 { get; set; }

        //[ExcelColumn(Name = "季节使用")]
        [ExcelColumnName("季节使用")]

        public string Ma173 { get; set; }

        //[ExcelColumn(Name = "库存管理中激活季节")]
        [ExcelColumnName("库存管理中激活季节")]

        public string Ma174 { get; set; }

        //[ExcelColumn(Name = "物料转换标识")]
        [ExcelColumnName("物料转换标识")]

        public string Ma175 { get; set; }

        [Required(ErrorMessage = "装载单位不能为空")]
        //[ExcelColumn(Name = "装载单位")]
        [ExcelColumnName("装载单位")]

        public int Ma176 { get; set; }

        //[ExcelColumn(Name = "装载单位组")]
        [ExcelColumnName("装载单位组")]

        public string Ma177 { get; set; }

        //[ExcelColumn(Name = "结构类别")]
        [ExcelColumnName("结构类别")]

        public string Ma178 { get; set; }

        //[ExcelColumn(Name = "容差类型")]
        [ExcelColumnName("容差类型")]

        public string Ma179 { get; set; }

        //[ExcelColumn(Name = "计算组")]
        [ExcelColumnName("计算组")]

        public string Ma180 { get; set; }

        //[ExcelColumn(Name = "DSD 分组")]
        [ExcelColumnName("DSD 分组")]

        public string Ma181 { get; set; }

        //[ExcelColumn(Name = "允许倾斜")]
        [ExcelColumnName("允许倾斜")]

        public string Ma182 { get; set; }

        //[ExcelColumn(Name = "无堆栈")]
        [ExcelColumnName("无堆栈")]

        public string Ma183 { get; set; }

        //[ExcelColumn(Name = "底层")]
        [ExcelColumnName("底层")]

        public string Ma184 { get; set; }

        //[ExcelColumn(Name = "顶层")]
        [ExcelColumnName("顶层")]

        public string Ma185 { get; set; }

        [Required(ErrorMessage = "堆栈因子不能为空")]
        //[ExcelColumn(Name = "堆栈因子")]
        [ExcelColumnName("堆栈因子")]

        public int Ma186 { get; set; }

        //[ExcelColumn(Name = "无包装物料装载")]
        [ExcelColumnName("无包装物料装载")]

        public string Ma187 { get; set; }

        [Required(ErrorMessage = "悬挂深度不能为空")]
        //[ExcelColumn(Name = "悬挂深度")]
        [ExcelColumnName("悬挂深度")]

        public decimal Ma188 { get; set; }

        [Required(ErrorMessage = "悬挂宽度不能为空")]
        //[ExcelColumn(Name = "悬挂宽度")]
        [ExcelColumnName("悬挂宽度")]

        public decimal Ma189 { get; set; }

        [Required(ErrorMessage = "最大叠放高度不能为空")]
        //[ExcelColumn(Name = "最大叠放高度")]
        [ExcelColumnName("最大叠放高度")]

        public decimal Ma190 { get; set; }

        [Required(ErrorMessage = "最小叠放高度不能为空")]
        //[ExcelColumn(Name = "最小叠放高度")]
        [ExcelColumnName("最小叠放高度")]

        public decimal Ma191 { get; set; }

        [Required(ErrorMessage = "叠放高度容差不能为空")]
        //[ExcelColumn(Name = "叠放高度容差")]
        [ExcelColumnName("叠放高度容差")]

        public decimal Ma192 { get; set; }

        [Required(ErrorMessage = "物料编号PKM不能为空")]
        //[ExcelColumn(Name = "物料编号PKM")]
        [ExcelColumnName("物料编号PKM")]

        public int Ma193 { get; set; }

        //[ExcelColumn(Name = "VSO")]
        [ExcelColumnName("VSO")]

        public string Ma194 { get; set; }

        //[ExcelColumn(Name = "请求已清PKM")]
        [ExcelColumnName("请求已清PKM")]

        public string Ma195 { get; set; }

        //[ExcelColumn(Name = "Packaging Code")]
        [ExcelColumnName("Packaging Code")]

        public string Ma196 { get; set; }

        //[ExcelColumn(Name = "危险品的包装状态")]
        [ExcelColumnName("危险品的包装状态")]

        public string Ma197 { get; set; }

        //[ExcelColumn(Name = "物料条件管理")]
        [ExcelColumnName("物料条件管理")]

        public string Ma198 { get; set; }

        //[ExcelColumn(Name = "返回代码")]
        [ExcelColumnName("返回代码")]

        public string Ma199 { get; set; }

        //[ExcelColumn(Name = "后勤等级退货")]
        [ExcelColumnName("后勤等级退货")]

        public string Ma200 { get; set; }

        //[ExcelColumn(Name = "NATO项目")]
        [ExcelColumnName("NATO项目")]

        public string Ma201 { get; set; }

        //[ExcelColumn(Name = "完全互换组")]
        [ExcelColumnName("完全互换组")]

        public string Ma202 { get; set; }

        //[ExcelColumn(Name = "链编号")]
        [ExcelColumnName("链编号")]

        public string Ma203 { get; set; }

        //[ExcelColumn(Name = "创建状态")]
        [ExcelColumnName("创建状态")]

        public string Ma204 { get; set; }

        [Required(ErrorMessage = "内部特性1不能为空")]
        //[ExcelColumn(Name = "内部特性1")]
        [ExcelColumnName("内部特性1")]

        public int Ma205 { get; set; }

        [Required(ErrorMessage = "内部特性2不能为空")]
        //[ExcelColumn(Name = "内部特性2")]
        [ExcelColumnName("内部特性2")]

        public int Ma206 { get; set; }

        [Required(ErrorMessage = "内部特性3不能为空")]
        //[ExcelColumn(Name = "内部特性3")]
        [ExcelColumnName("内部特性3")]

        public int Ma207 { get; set; }

        //[ExcelColumn(Name = "颜色")]
        [ExcelColumnName("颜色")]

        public string Ma208 { get; set; }

        //[ExcelColumn(Name = "主尺寸")]
        [ExcelColumnName("主尺寸")]

        public string Ma209 { get; set; }

        //[ExcelColumn(Name = "次尺寸")]
        [ExcelColumnName("次尺寸")]

        public string Ma210 { get; set; }

        //[ExcelColumn(Name = "特性值")]
        [ExcelColumnName("特性值")]

        public string Ma211 { get; set; }

        //[ExcelColumn(Name = "护理代码")]
        [ExcelColumnName("护理代码")]

        public string Ma212 { get; set; }

        //[ExcelColumn(Name = "商标")]
        [ExcelColumnName("商标")]

        public string Ma213 { get; set; }

        //[ExcelColumn(Name = "组件1")]
        [ExcelColumnName("组件1")]

        public string Ma214 { get; set; }

        [Required(ErrorMessage = "百分比共享1不能为空")]
        //[ExcelColumn(Name = "百分比共享1")]
        [ExcelColumnName("百分比共享1")]

        public int Ma215 { get; set; }

        //[ExcelColumn(Name = "组件2")]
        [ExcelColumnName("组件2")]

        public string Ma216 { get; set; }

        [Required(ErrorMessage = "百分比共2不能为空")]
        //[ExcelColumn(Name = "百分比共2")]
        [ExcelColumnName("百分比共2")]

        public int Ma217 { get; set; }

        //[ExcelColumn(Name = "组件3")]
        [ExcelColumnName("组件3")]

        public string Ma218 { get; set; }

        [Required(ErrorMessage = "百分比共享3不能为空")]
        //[ExcelColumn(Name = "百分比共享3")]
        [ExcelColumnName("百分比共享3")]

        public int Ma219 { get; set; }

        //[ExcelColumn(Name = "组件4")]
        [ExcelColumnName("组件4")]

        public string Ma220 { get; set; }

        [Required(ErrorMessage = "百分比共享4不能为空")]
        //[ExcelColumn(Name = "百分比共享4")]
        [ExcelColumnName("百分比共享4")]

        public int Ma221 { get; set; }

        //[ExcelColumn(Name = "组件5")]
        [ExcelColumnName("组件5")]

        public string Ma222 { get; set; }

        [Required(ErrorMessage = "百分比共享5不能为空")]
        //[ExcelColumn(Name = "百分比共享5")]
        [ExcelColumnName("百分比共享5")]

        public int Ma223 { get; set; }

        //[ExcelColumn(Name = "时装等级")]
        [ExcelColumnName("时装等级")]

        public string Ma224 { get; set; }

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



        [ExcelColumn(Name = "集团删除")]
        public string Ma006Label { get; set; }
        [ExcelColumn(Name = "物料类型")]
        public string Ma007Label { get; set; }
        [ExcelColumn(Name = "行业领域")]
        public string Ma008Label { get; set; }
        [ExcelColumn(Name = "物料组")]
        public string Ma009Label { get; set; }
        [ExcelColumn(Name = "基本单位")]
        public string Ma011Label { get; set; }
    }

    /// <summary>
    /// 常规物料
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 10:59:57
    /// </summary>
    public class MmMaraImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Ma002 { get; set; }

        [Required(ErrorMessage = "物料号不能为空")]
        //[ExcelColumn(Name = "物料号")]
        [ExcelColumnName("物料号")]
        public string Ma003 { get; set; }

        //[ExcelColumn(Name = "完整状态")]
        [ExcelColumnName("完整状态")]
        public string Ma004 { get; set; }

        //[ExcelColumn(Name = "维护状态")]
        [ExcelColumnName("维护状态")]
        public string Ma005 { get; set; }

        //[ExcelColumn(Name = "集团删除")]
        [ExcelColumnName("集团删除")]
        public string Ma006 { get; set; }

        [Required(ErrorMessage = "物料类型不能为空")]
        //[ExcelColumn(Name = "物料类型")]
        [ExcelColumnName("物料类型")]
        public string Ma007 { get; set; }

        [Required(ErrorMessage = "行业领域不能为空")]
        //[ExcelColumn(Name = "行业领域")]
        [ExcelColumnName("行业领域")]
        public string Ma008 { get; set; }

        //[ExcelColumn(Name = "物料组")]
        [ExcelColumnName("物料组")]
        public string Ma009 { get; set; }

        //[ExcelColumn(Name = "旧物料号")]
        [ExcelColumnName("旧物料号")]
        public string Ma010 { get; set; }

        [Required(ErrorMessage = "基本单位不能为空")]
        //[ExcelColumn(Name = "基本单位")]
        [ExcelColumnName("基本单位")]
        public string Ma011 { get; set; }

        //[ExcelColumn(Name = "订单单位")]
        [ExcelColumnName("订单单位")]
        public string Ma012 { get; set; }

        //[ExcelColumn(Name = "凭证")]
        [ExcelColumnName("凭证")]
        public string Ma013 { get; set; }

        //[ExcelColumn(Name = "凭证类型")]
        [ExcelColumnName("凭证类型")]
        public string Ma014 { get; set; }

        //[ExcelColumn(Name = "凭证版本")]
        [ExcelColumnName("凭证版本")]
        public string Ma015 { get; set; }

        //[ExcelColumn(Name = "页面大小")]
        [ExcelColumnName("页面大小")]
        public string Ma016 { get; set; }

        //[ExcelColumn(Name = "文档变更号")]
        [ExcelColumnName("文档变更号")]
        public string Ma017 { get; set; }

        //[ExcelColumn(Name = "页号")]
        [ExcelColumnName("页号")]
        public string Ma018 { get; set; }

        [Required(ErrorMessage = "页数不能为空")]
        //[ExcelColumn(Name = "页数")]
        [ExcelColumnName("页数")]
        public int Ma019 { get; set; }

        //[ExcelColumn(Name = "备忘录")]
        [ExcelColumnName("备忘录")]
        public string Ma020 { get; set; }

        //[ExcelColumn(Name = "页格式")]
        [ExcelColumnName("页格式")]
        public string Ma021 { get; set; }

        //[ExcelColumn(Name = "大小/量纲")]
        [ExcelColumnName("大小/量纲")]
        public string Ma022 { get; set; }

        //[ExcelColumn(Name = "基本物料")]
        [ExcelColumnName("基本物料")]
        public string Ma023 { get; set; }

        //[ExcelColumn(Name = "行业标准")]
        [ExcelColumnName("行业标准")]
        public string Ma024 { get; set; }

        //[ExcelColumn(Name = "实验室/设计室")]
        [ExcelColumnName("实验室/设计室")]
        public string Ma025 { get; set; }

        //[ExcelColumn(Name = "采购值代码")]
        [ExcelColumnName("采购值代码")]
        public string Ma026 { get; set; }

        [Required(ErrorMessage = "毛重不能为空")]
        //[ExcelColumn(Name = "毛重")]
        [ExcelColumnName("毛重")]
        public decimal Ma027 { get; set; }

        [Required(ErrorMessage = "净重不能为空")]
        //[ExcelColumn(Name = "净重")]
        [ExcelColumnName("净重")]
        public decimal Ma028 { get; set; }

        //[ExcelColumn(Name = "重量单位")]
        [ExcelColumnName("重量单位")]
        public string Ma029 { get; set; }

        [Required(ErrorMessage = "业务量不能为空")]
        //[ExcelColumn(Name = "业务量")]
        [ExcelColumnName("业务量")]
        public decimal Ma030 { get; set; }

        //[ExcelColumn(Name = "体积单位")]
        [ExcelColumnName("体积单位")]
        public string Ma031 { get; set; }

        //[ExcelColumn(Name = "容器需求")]
        [ExcelColumnName("容器需求")]
        public string Ma032 { get; set; }

        //[ExcelColumn(Name = "存储条件")]
        [ExcelColumnName("存储条件")]
        public string Ma033 { get; set; }

        //[ExcelColumn(Name = "温度")]
        [ExcelColumnName("温度")]
        public string Ma034 { get; set; }

        //[ExcelColumn(Name = "低层代码")]
        [ExcelColumnName("低层代码")]
        public string Ma035 { get; set; }

        //[ExcelColumn(Name = "运输组")]
        [ExcelColumnName("运输组")]
        public string Ma036 { get; set; }

        //[ExcelColumn(Name = "危险物料号")]
        [ExcelColumnName("危险物料号")]
        public string Ma037 { get; set; }

        //[ExcelColumn(Name = "产品组")]
        [ExcelColumnName("产品组")]
        public string Ma038 { get; set; }

        //[ExcelColumn(Name = "竞争者")]
        [ExcelColumnName("竞争者")]
        public string Ma039 { get; set; }

        //[ExcelColumn(Name = "EAN号")]
        [ExcelColumnName("EAN号")]
        public string Ma040 { get; set; }

        [Required(ErrorMessage = "GR单数量不能为空")]
        //[ExcelColumn(Name = "GR单数量")]
        [ExcelColumnName("GR单数量")]
        public decimal Ma041 { get; set; }

        //[ExcelColumn(Name = "采购规则")]
        [ExcelColumnName("采购规则")]
        public string Ma042 { get; set; }

        //[ExcelColumn(Name = "货源")]
        [ExcelColumnName("货源")]
        public string Ma043 { get; set; }

        //[ExcelColumn(Name = "季节")]
        [ExcelColumnName("季节")]
        public string Ma044 { get; set; }

        //[ExcelColumn(Name = "标签类型")]
        [ExcelColumnName("标签类型")]
        public string Ma045 { get; set; }

        //[ExcelColumn(Name = "标签格式")]
        [ExcelColumnName("标签格式")]
        public string Ma046 { get; set; }

        //[ExcelColumn(Name = "取消激活")]
        [ExcelColumnName("取消激活")]
        public string Ma047 { get; set; }

        //[ExcelColumn(Name = "EAN")]
        [ExcelColumnName("EAN")]
        public string Ma048 { get; set; }

        //[ExcelColumn(Name = "EAN类别")]
        [ExcelColumnName("EAN类别")]
        public string Ma049 { get; set; }

        [Required(ErrorMessage = "长度不能为空")]
        //[ExcelColumn(Name = "长度")]
        [ExcelColumnName("长度")]
        public decimal Ma050 { get; set; }

        [Required(ErrorMessage = "宽度不能为空")]
        //[ExcelColumn(Name = "宽度")]
        [ExcelColumnName("宽度")]
        public decimal Ma051 { get; set; }

        [Required(ErrorMessage = "高度不能为空")]
        //[ExcelColumn(Name = "高度")]
        [ExcelColumnName("高度")]
        public decimal Ma052 { get; set; }

        //[ExcelColumn(Name = "尺寸单位")]
        [ExcelColumnName("尺寸单位")]
        public string Ma053 { get; set; }

        //[ExcelColumn(Name = "产品层次")]
        [ExcelColumnName("产品层次")]
        public string Ma054 { get; set; }

        //[ExcelColumn(Name = "净改变成本核算")]
        [ExcelColumnName("净改变成本核算")]
        public string Ma055 { get; set; }

        //[ExcelColumn(Name = "CAD标识")]
        [ExcelColumnName("CAD标识")]
        public string Ma056 { get; set; }

        //[ExcelColumn(Name = "QM采购")]
        [ExcelColumnName("QM采购")]
        public string Ma057 { get; set; }

        [Required(ErrorMessage = "允许的包装重量不能为空")]
        //[ExcelColumn(Name = "允许的包装重量")]
        [ExcelColumnName("允许的包装重量")]
        public decimal Ma058 { get; set; }

        //[ExcelColumn(Name = "重量单位")]
        [ExcelColumnName("重量单位")]
        public string Ma059 { get; set; }

        [Required(ErrorMessage = "允许体积不能为空")]
        //[ExcelColumn(Name = "允许体积")]
        [ExcelColumnName("允许体积")]
        public decimal Ma060 { get; set; }

        //[ExcelColumn(Name = "体积单位")]
        [ExcelColumnName("体积单位")]
        public string Ma061 { get; set; }

        [Required(ErrorMessage = "超重量容差不能为空")]
        //[ExcelColumn(Name = "超重量容差")]
        [ExcelColumnName("超重量容差")]
        public decimal Ma062 { get; set; }

        [Required(ErrorMessage = "超体积容差不能为空")]
        //[ExcelColumn(Name = "超体积容差")]
        [ExcelColumnName("超体积容差")]
        public decimal Ma063 { get; set; }

        //[ExcelColumn(Name = "可变订单单位")]
        [ExcelColumnName("可变订单单位")]
        public string Ma064 { get; set; }

        //[ExcelColumn(Name = "修订等级")]
        [ExcelColumnName("修订等级")]
        public string Ma065 { get; set; }

        //[ExcelColumn(Name = "可配置")]
        [ExcelColumnName("可配置")]
        public string Ma066 { get; set; }

        //[ExcelColumn(Name = "批次管理需求")]
        [ExcelColumnName("批次管理需求")]
        public string Ma067 { get; set; }

        //[ExcelColumn(Name = "包装物料类型")]
        [ExcelColumnName("包装物料类型")]
        public string Ma068 { get; set; }

        [Required(ErrorMessage = "最大层次不能为空")]
        //[ExcelColumn(Name = "最大层次")]
        [ExcelColumnName("最大层次")]
        public decimal Ma069 { get; set; }

        [Required(ErrorMessage = "堆栈因子不能为空")]
        //[ExcelColumn(Name = "堆栈因子")]
        [ExcelColumnName("堆栈因子")]
        public int Ma070 { get; set; }

        //[ExcelColumn(Name = "物料组包装物料")]
        [ExcelColumnName("物料组包装物料")]
        public string Ma071 { get; set; }

        //[ExcelColumn(Name = "权限组")]
        [ExcelColumnName("权限组")]
        public string Ma072 { get; set; }

        //[ExcelColumn(Name = "有效起始日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效起始日")]
        public DateTime? Ma073 { get; set; }

        //[ExcelColumn(Name = "有效结束日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效结束日")]
        public DateTime? Ma074 { get; set; }

        //[ExcelColumn(Name = "季度年")]
        [ExcelColumnName("季度年")]
        public string Ma075 { get; set; }

        //[ExcelColumn(Name = "价格标记")]
        [ExcelColumnName("价格标记")]
        public string Ma076 { get; set; }

        //[ExcelColumn(Name = "空白BOM")]
        [ExcelColumnName("空白BOM")]
        public string Ma077 { get; set; }

        //[ExcelColumn(Name = "外部物料组")]
        [ExcelColumnName("外部物料组")]
        public string Ma078 { get; set; }

        //[ExcelColumn(Name = "一般可配置物料")]
        [ExcelColumnName("一般可配置物料")]
        public string Ma079 { get; set; }

        //[ExcelColumn(Name = "物料类别")]
        [ExcelColumnName("物料类别")]
        public string Ma080 { get; set; }

        //[ExcelColumn(Name = "联产品")]
        [ExcelColumnName("联产品")]
        public string Ma081 { get; set; }

        //[ExcelColumn(Name = "后续物料")]
        [ExcelColumnName("后续物料")]
        public string Ma082 { get; set; }

        //[ExcelColumn(Name = "定价参考物料")]
        [ExcelColumnName("定价参考物料")]
        public string Ma083 { get; set; }

        //[ExcelColumn(Name = "跨工厂状态")]
        [ExcelColumnName("跨工厂状态")]
        public string Ma084 { get; set; }

        //[ExcelColumn(Name = "跨分销链状态")]
        [ExcelColumnName("跨分销链状态")]
        public string Ma085 { get; set; }

        //[ExcelColumn(Name = "跨工厂有效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("跨工厂有效日期")]
        public DateTime? Ma086 { get; set; }

        //[ExcelColumn(Name = "跨分销有效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("跨分销有效日期")]
        public DateTime? Ma087 { get; set; }

        //[ExcelColumn(Name = "税收分类")]
        [ExcelColumnName("税收分类")]
        public string Ma088 { get; set; }

        //[ExcelColumn(Name = "类别参数文件")]
        [ExcelColumnName("类别参数文件")]
        public string Ma089 { get; set; }

        [Required(ErrorMessage = "剩余货架寿命不能为空")]
        //[ExcelColumn(Name = "剩余货架寿命")]
        [ExcelColumnName("剩余货架寿命")]
        public decimal Ma090 { get; set; }

        [Required(ErrorMessage = "总货架寿命不能为空")]
        //[ExcelColumn(Name = "总货架寿命")]
        [ExcelColumnName("总货架寿命")]
        public decimal Ma091 { get; set; }

        [Required(ErrorMessage = "仓储百分比不能为空")]
        //[ExcelColumn(Name = "仓储百分比")]
        [ExcelColumnName("仓储百分比")]
        public decimal Ma092 { get; set; }

        //[ExcelColumn(Name = "内容单位")]
        [ExcelColumnName("内容单位")]
        public string Ma093 { get; set; }

        [Required(ErrorMessage = "净内容不能为空")]
        //[ExcelColumn(Name = "净内容")]
        [ExcelColumnName("净内容")]
        public decimal Ma094 { get; set; }

        [Required(ErrorMessage = "比较价格单位不能为空")]
        //[ExcelColumn(Name = "比较价格单位")]
        [ExcelColumnName("比较价格单位")]
        public decimal Ma095 { get; set; }

        //[ExcelColumn(Name = "物料组标签")]
        [ExcelColumnName("物料组标签")]
        public string Ma096 { get; set; }

        [Required(ErrorMessage = "毛内容不能为空")]
        //[ExcelColumn(Name = "毛内容")]
        [ExcelColumnName("毛内容")]
        public decimal Ma097 { get; set; }

        //[ExcelColumn(Name = "转换方法")]
        [ExcelColumnName("转换方法")]
        public string Ma098 { get; set; }

        [Required(ErrorMessage = "内部对象号不能为空")]
        //[ExcelColumn(Name = "内部对象号")]
        [ExcelColumnName("内部对象号")]
        public int Ma099 { get; set; }

        //[ExcelColumn(Name = "环境相关")]
        [ExcelColumnName("环境相关")]
        public string Ma100 { get; set; }

        //[ExcelColumn(Name = "产品分配")]
        [ExcelColumnName("产品分配")]
        public string Ma101 { get; set; }

        //[ExcelColumn(Name = "定价参数文件")]
        [ExcelColumnName("定价参数文件")]
        public string Ma102 { get; set; }

        //[ExcelColumn(Name = "折扣类型")]
        [ExcelColumnName("折扣类型")]
        public string Ma103 { get; set; }

        //[ExcelColumn(Name = "制造商零件编号")]
        [ExcelColumnName("制造商零件编号")]
        public string Ma104 { get; set; }

        //[ExcelColumn(Name = "制造商")]
        [ExcelColumnName("制造商")]
        public string Ma105 { get; set; }

        //[ExcelColumn(Name = "内部物料编号")]
        [ExcelColumnName("内部物料编号")]
        public string Ma106 { get; set; }

        //[ExcelColumn(Name = "制造商部件参数文件")]
        [ExcelColumnName("制造商部件参数文件")]
        public string Ma107 { get; set; }

        //[ExcelColumn(Name = "测量单位用法")]
        [ExcelColumnName("测量单位用法")]
        public string Ma108 { get; set; }

        //[ExcelColumn(Name = "展开")]
        [ExcelColumnName("展开")]
        public string Ma109 { get; set; }

        //[ExcelColumn(Name = "危险货物标识参数文件")]
        [ExcelColumnName("危险货物标识参数文件")]
        public string Ma110 { get; set; }

        //[ExcelColumn(Name = "高粘性的")]
        [ExcelColumnName("高粘性的")]
        public string Ma111 { get; set; }

        //[ExcelColumn(Name = "固体/液体")]
        [ExcelColumnName("固体/液体")]
        public string Ma112 { get; set; }

        //[ExcelColumn(Name = "序列号层次")]
        [ExcelColumnName("序列号层次")]
        public string Ma113 { get; set; }

        //[ExcelColumn(Name = "密闭")]
        [ExcelColumnName("密闭")]
        public string Ma114 { get; set; }

        //[ExcelColumn(Name = "需要批量记录")]
        [ExcelColumnName("需要批量记录")]
        public string Ma115 { get; set; }

        //[ExcelColumn(Name = "参数有效值")]
        [ExcelColumnName("参数有效值")]
        public string Ma116 { get; set; }

        [Required(ErrorMessage = "完成水平不能为空")]
        //[ExcelColumn(Name = "完成水平")]
        [ExcelColumnName("完成水平")]
        public int Ma117 { get; set; }

        //[ExcelColumn(Name = "期间标识")]
        [ExcelColumnName("期间标识")]
        public string Ma118 { get; set; }

        //[ExcelColumn(Name = "舍入规则")]
        [ExcelColumnName("舍入规则")]
        public string Ma119 { get; set; }

        //[ExcelColumn(Name = "产品成份")]
        [ExcelColumnName("产品成份")]
        public string Ma120 { get; set; }

        //[ExcelColumn(Name = "普通项目类别组")]
        [ExcelColumnName("普通项目类别组")]
        public string Ma121 { get; set; }

        //[ExcelColumn(Name = "后勤变量")]
        [ExcelColumnName("后勤变量")]
        public string Ma122 { get; set; }

        //[ExcelColumn(Name = "物料被锁定")]
        [ExcelColumnName("物料被锁定")]
        public string Ma123 { get; set; }

        //[ExcelColumn(Name = "配置相关")]
        [ExcelColumnName("配置相关")]
        public string Ma124 { get; set; }

        //[ExcelColumn(Name = "分类清单类型")]
        [ExcelColumnName("分类清单类型")]
        public string Ma125 { get; set; }

        //[ExcelColumn(Name = "过期日期")]
        [ExcelColumnName("过期日期")]
        public string Ma126 { get; set; }

        //[ExcelColumn(Name = "EAN变式")]
        [ExcelColumnName("EAN变式")]
        public string Ma127 { get; set; }

        //[ExcelColumn(Name = "一般物料")]
        [ExcelColumnName("一般物料")]
        public string Ma128 { get; set; }

        //[ExcelColumn(Name = "包装参考物料")]
        [ExcelColumnName("包装参考物料")]
        public string Ma129 { get; set; }

        //[ExcelColumn(Name = "GDS相关")]
        [ExcelColumnName("GDS相关")]
        public string Ma130 { get; set; }

        //[ExcelColumn(Name = "原始接受")]
        [ExcelColumnName("原始接受")]
        public string Ma131 { get; set; }

        //[ExcelColumn(Name = "标准处理单位类型")]
        [ExcelColumnName("标准处理单位类型")]
        public string Ma132 { get; set; }

        //[ExcelColumn(Name = "可偷窃的")]
        [ExcelColumnName("可偷窃的")]
        public string Ma133 { get; set; }

        //[ExcelColumn(Name = "仓库存储条件")]
        [ExcelColumnName("仓库存储条件")]
        public string Ma134 { get; set; }

        //[ExcelColumn(Name = "仓库物料组")]
        [ExcelColumnName("仓库物料组")]
        public string Ma135 { get; set; }

        //[ExcelColumn(Name = "处理标识")]
        [ExcelColumnName("处理标识")]
        public string Ma136 { get; set; }

        //[ExcelColumn(Name = "危险物料")]
        [ExcelColumnName("危险物料")]
        public string Ma137 { get; set; }

        //[ExcelColumn(Name = "处理单位类型")]
        [ExcelColumnName("处理单位类型")]
        public string Ma138 { get; set; }

        //[ExcelColumn(Name = "可变皮重")]
        [ExcelColumnName("可变皮重")]
        public string Ma139 { get; set; }

        [Required(ErrorMessage = "最大容量不能为空")]
        //[ExcelColumn(Name = "最大容量")]
        [ExcelColumnName("最大容量")]
        public decimal Ma140 { get; set; }

        [Required(ErrorMessage = "最大容量容差不能为空")]
        //[ExcelColumn(Name = "最大容量容差")]
        [ExcelColumnName("最大容量容差")]
        public decimal Ma141 { get; set; }

        [Required(ErrorMessage = "最大长度不能为空")]
        //[ExcelColumn(Name = "最大长度")]
        [ExcelColumnName("最大长度")]
        public decimal Ma142 { get; set; }

        [Required(ErrorMessage = "最大宽度不能为空")]
        //[ExcelColumn(Name = "最大宽度")]
        [ExcelColumnName("最大宽度")]
        public decimal Ma143 { get; set; }

        [Required(ErrorMessage = "最大高度不能为空")]
        //[ExcelColumn(Name = "最大高度")]
        [ExcelColumnName("最大高度")]
        public decimal Ma144 { get; set; }

        //[ExcelColumn(Name = "计量单位")]
        [ExcelColumnName("计量单位")]
        public string Ma145 { get; set; }

        //[ExcelColumn(Name = "原产地国")]
        [ExcelColumnName("原产地国")]
        public string Ma146 { get; set; }

        //[ExcelColumn(Name = "物料运输组")]
        [ExcelColumnName("物料运输组")]
        public string Ma147 { get; set; }

        [Required(ErrorMessage = "隔离期间不能为空")]
        //[ExcelColumn(Name = "隔离期间")]
        [ExcelColumnName("隔离期间")]
        public decimal Ma148 { get; set; }

        //[ExcelColumn(Name = "时间单位")]
        [ExcelColumnName("时间单位")]
        public string Ma149 { get; set; }

        //[ExcelColumn(Name = "质量检查组")]
        [ExcelColumnName("质量检查组")]
        public string Ma150 { get; set; }

        //[ExcelColumn(Name = "序列号参数文件")]
        [ExcelColumnName("序列号参数文件")]
        public string Ma151 { get; set; }

        //[ExcelColumn(Name = "表格名")]
        [ExcelColumnName("表格名")]
        public string Ma152 { get; set; }

        //[ExcelColumn(Name = "后勤计量单位")]
        [ExcelColumnName("后勤计量单位")]
        public string Ma153 { get; set; }

        //[ExcelColumn(Name = "称重物料相关")]
        [ExcelColumnName("称重物料相关")]
        public string Ma154 { get; set; }

        //[ExcelColumn(Name = "CW参数文件")]
        [ExcelColumnName("CW参数文件")]
        public string Ma155 { get; set; }

        //[ExcelColumn(Name = "CW容差组")]
        [ExcelColumnName("CW容差组")]
        public string Ma156 { get; set; }

        //[ExcelColumn(Name = "调整参数文件")]
        [ExcelColumnName("调整参数文件")]
        public string Ma157 { get; set; }

        //[ExcelColumn(Name = "知识产权")]
        [ExcelColumnName("知识产权")]
        public string Ma158 { get; set; }

        //[ExcelColumn(Name = "允许的变式价格")]
        [ExcelColumnName("允许的变式价格")]
        public string Ma159 { get; set; }

        //[ExcelColumn(Name = "中间")]
        [ExcelColumnName("中间")]
        public string Ma160 { get; set; }

        //[ExcelColumn(Name = "实物商品")]
        [ExcelColumnName("实物商品")]
        public string Ma161 { get; set; }

        //[ExcelColumn(Name = "动物源")]
        [ExcelColumnName("动物源")]
        public string Ma162 { get; set; }

        //[ExcelColumn(Name = "纺织组分功能")]
        [ExcelColumnName("纺织组分功能")]
        public string Ma163 { get; set; }

        //[ExcelColumn(Name = "分段结构")]
        [ExcelColumnName("分段结构")]
        public string Ma164 { get; set; }

        //[ExcelColumn(Name = "分段策略")]
        [ExcelColumnName("分段策略")]
        public string Ma165 { get; set; }

        //[ExcelColumn(Name = "分段状态")]
        [ExcelColumnName("分段状态")]
        public string Ma166 { get; set; }

        //[ExcelColumn(Name = "分段范围")]
        [ExcelColumnName("分段范围")]
        public string Ma167 { get; set; }

        //[ExcelColumn(Name = "分段相关")]
        [ExcelColumnName("分段相关")]
        public string Ma168 { get; set; }

        [Required(ErrorMessage = "ANP Code不能为空")]
        //[ExcelColumn(Name = "ANP Code")]
        [ExcelColumnName("ANP Code")]
        public int Ma169 { get; set; }

        //[ExcelColumn(Name = "Fashion属性1")]
        [ExcelColumnName("Fashion属性1")]
        public string Ma170 { get; set; }

        //[ExcelColumn(Name = "Fashion属性2")]
        [ExcelColumnName("Fashion属性2")]
        public string Ma171 { get; set; }

        //[ExcelColumn(Name = "Fashion属性3")]
        [ExcelColumnName("Fashion属性3")]
        public string Ma172 { get; set; }

        //[ExcelColumn(Name = "季节使用")]
        [ExcelColumnName("季节使用")]
        public string Ma173 { get; set; }

        //[ExcelColumn(Name = "库存管理中激活季节")]
        [ExcelColumnName("库存管理中激活季节")]
        public string Ma174 { get; set; }

        //[ExcelColumn(Name = "物料转换标识")]
        [ExcelColumnName("物料转换标识")]
        public string Ma175 { get; set; }

        [Required(ErrorMessage = "装载单位不能为空")]
        //[ExcelColumn(Name = "装载单位")]
        [ExcelColumnName("装载单位")]
        public int Ma176 { get; set; }

        //[ExcelColumn(Name = "装载单位组")]
        [ExcelColumnName("装载单位组")]
        public string Ma177 { get; set; }

        //[ExcelColumn(Name = "结构类别")]
        [ExcelColumnName("结构类别")]
        public string Ma178 { get; set; }

        //[ExcelColumn(Name = "容差类型")]
        [ExcelColumnName("容差类型")]
        public string Ma179 { get; set; }

        //[ExcelColumn(Name = "计算组")]
        [ExcelColumnName("计算组")]
        public string Ma180 { get; set; }

        //[ExcelColumn(Name = "DSD 分组")]
        [ExcelColumnName("DSD 分组")]
        public string Ma181 { get; set; }

        //[ExcelColumn(Name = "允许倾斜")]
        [ExcelColumnName("允许倾斜")]
        public string Ma182 { get; set; }

        //[ExcelColumn(Name = "无堆栈")]
        [ExcelColumnName("无堆栈")]
        public string Ma183 { get; set; }

        //[ExcelColumn(Name = "底层")]
        [ExcelColumnName("底层")]
        public string Ma184 { get; set; }

        //[ExcelColumn(Name = "顶层")]
        [ExcelColumnName("顶层")]
        public string Ma185 { get; set; }

        [Required(ErrorMessage = "堆栈因子不能为空")]
        //[ExcelColumn(Name = "堆栈因子")]
        [ExcelColumnName("堆栈因子")]
        public int Ma186 { get; set; }

        //[ExcelColumn(Name = "无包装物料装载")]
        [ExcelColumnName("无包装物料装载")]
        public string Ma187 { get; set; }

        [Required(ErrorMessage = "悬挂深度不能为空")]
        //[ExcelColumn(Name = "悬挂深度")]
        [ExcelColumnName("悬挂深度")]
        public decimal Ma188 { get; set; }

        [Required(ErrorMessage = "悬挂宽度不能为空")]
        //[ExcelColumn(Name = "悬挂宽度")]
        [ExcelColumnName("悬挂宽度")]
        public decimal Ma189 { get; set; }

        [Required(ErrorMessage = "最大叠放高度不能为空")]
        //[ExcelColumn(Name = "最大叠放高度")]
        [ExcelColumnName("最大叠放高度")]
        public decimal Ma190 { get; set; }

        [Required(ErrorMessage = "最小叠放高度不能为空")]
        //[ExcelColumn(Name = "最小叠放高度")]
        [ExcelColumnName("最小叠放高度")]
        public decimal Ma191 { get; set; }

        [Required(ErrorMessage = "叠放高度容差不能为空")]
        //[ExcelColumn(Name = "叠放高度容差")]
        [ExcelColumnName("叠放高度容差")]
        public decimal Ma192 { get; set; }

        [Required(ErrorMessage = "物料编号PKM不能为空")]
        //[ExcelColumn(Name = "物料编号PKM")]
        [ExcelColumnName("物料编号PKM")]
        public int Ma193 { get; set; }

        //[ExcelColumn(Name = "VSO")]
        [ExcelColumnName("VSO")]
        public string Ma194 { get; set; }

        //[ExcelColumn(Name = "请求已清PKM")]
        [ExcelColumnName("请求已清PKM")]
        public string Ma195 { get; set; }

        //[ExcelColumn(Name = "Packaging Code")]
        [ExcelColumnName("Packaging Code")]
        public string Ma196 { get; set; }

        //[ExcelColumn(Name = "危险品的包装状态")]
        [ExcelColumnName("危险品的包装状态")]
        public string Ma197 { get; set; }

        //[ExcelColumn(Name = "物料条件管理")]
        [ExcelColumnName("物料条件管理")]
        public string Ma198 { get; set; }

        //[ExcelColumn(Name = "返回代码")]
        [ExcelColumnName("返回代码")]
        public string Ma199 { get; set; }

        //[ExcelColumn(Name = "后勤等级退货")]
        [ExcelColumnName("后勤等级退货")]
        public string Ma200 { get; set; }

        //[ExcelColumn(Name = "NATO项目")]
        [ExcelColumnName("NATO项目")]
        public string Ma201 { get; set; }

        //[ExcelColumn(Name = "完全互换组")]
        [ExcelColumnName("完全互换组")]
        public string Ma202 { get; set; }

        //[ExcelColumn(Name = "链编号")]
        [ExcelColumnName("链编号")]
        public string Ma203 { get; set; }

        //[ExcelColumn(Name = "创建状态")]
        [ExcelColumnName("创建状态")]
        public string Ma204 { get; set; }

        [Required(ErrorMessage = "内部特性1不能为空")]
        //[ExcelColumn(Name = "内部特性1")]
        [ExcelColumnName("内部特性1")]
        public int Ma205 { get; set; }

        [Required(ErrorMessage = "内部特性2不能为空")]
        //[ExcelColumn(Name = "内部特性2")]
        [ExcelColumnName("内部特性2")]
        public int Ma206 { get; set; }

        [Required(ErrorMessage = "内部特性3不能为空")]
        //[ExcelColumn(Name = "内部特性3")]
        [ExcelColumnName("内部特性3")]
        public int Ma207 { get; set; }

        //[ExcelColumn(Name = "颜色")]
        [ExcelColumnName("颜色")]
        public string Ma208 { get; set; }

        //[ExcelColumn(Name = "主尺寸")]
        [ExcelColumnName("主尺寸")]
        public string Ma209 { get; set; }

        //[ExcelColumn(Name = "次尺寸")]
        [ExcelColumnName("次尺寸")]
        public string Ma210 { get; set; }

        //[ExcelColumn(Name = "特性值")]
        [ExcelColumnName("特性值")]
        public string Ma211 { get; set; }

        //[ExcelColumn(Name = "护理代码")]
        [ExcelColumnName("护理代码")]
        public string Ma212 { get; set; }

        //[ExcelColumn(Name = "商标")]
        [ExcelColumnName("商标")]
        public string Ma213 { get; set; }

        //[ExcelColumn(Name = "组件1")]
        [ExcelColumnName("组件1")]
        public string Ma214 { get; set; }

        [Required(ErrorMessage = "百分比共享1不能为空")]
        //[ExcelColumn(Name = "百分比共享1")]
        [ExcelColumnName("百分比共享1")]
        public int Ma215 { get; set; }

        //[ExcelColumn(Name = "组件2")]
        [ExcelColumnName("组件2")]
        public string Ma216 { get; set; }

        [Required(ErrorMessage = "百分比共2不能为空")]
        //[ExcelColumn(Name = "百分比共2")]
        [ExcelColumnName("百分比共2")]
        public int Ma217 { get; set; }

        //[ExcelColumn(Name = "组件3")]
        [ExcelColumnName("组件3")]
        public string Ma218 { get; set; }

        [Required(ErrorMessage = "百分比共享3不能为空")]
        //[ExcelColumn(Name = "百分比共享3")]
        [ExcelColumnName("百分比共享3")]
        public int Ma219 { get; set; }

        //[ExcelColumn(Name = "组件4")]
        [ExcelColumnName("组件4")]
        public string Ma220 { get; set; }

        [Required(ErrorMessage = "百分比共享4不能为空")]
        //[ExcelColumn(Name = "百分比共享4")]
        [ExcelColumnName("百分比共享4")]
        public int Ma221 { get; set; }

        //[ExcelColumn(Name = "组件5")]
        [ExcelColumnName("组件5")]
        public string Ma222 { get; set; }

        [Required(ErrorMessage = "百分比共享5不能为空")]
        //[ExcelColumn(Name = "百分比共享5")]
        [ExcelColumnName("百分比共享5")]
        public int Ma223 { get; set; }

        //[ExcelColumn(Name = "时装等级")]
        [ExcelColumnName("时装等级")]
        public string Ma224 { get; set; }

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
        [ExcelColumn(Name = "集团删除")]
        public string Ma006Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "物料类型")]
        public string Ma007Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "行业领域")]
        public string Ma008Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "物料组")]
        public string Ma009Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "基本单位")]
        public string Ma011Label { get; set; }
    }

}