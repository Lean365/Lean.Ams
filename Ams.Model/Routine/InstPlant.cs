using Ams.Model.Admin;

namespace Ams.Model.Routine
{
    /// <summary>
    /// 工厂代码
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:16:10
    /// </summary>
    [SugarTable("inst_plant", "工厂代码")]
    public class InstPlant : SysBase
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
        /// 性质
        /// </summary>
        [SugarColumn(ColumnName = "Mc003", ColumnDescription = "性质", Length = 1)]
        public string Mc003 { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [SugarColumn(ColumnName = "Mc004", ColumnDescription = "类别", Length = 1)]
        public string Mc004 { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Mc005", ColumnDescription = "工厂", Length = 4)]
        public string Mc005 { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "Mc006", ColumnDescription = "名称", Length = 60)]
        public string Mc006 { get; set; }

        /// <summary>
        /// 评估范围
        /// </summary>
        [SugarColumn(ColumnName = "Mc007", ColumnDescription = "评估范围", Length = 4)]
        public string Mc007 { get; set; }

        /// <summary>
        /// 竞争者
        /// </summary>
        [SugarColumn(ColumnName = "Mc008", ColumnDescription = "竞争者", Length = 10)]
        public string Mc008 { get; set; }

        /// <summary>
        /// 工厂供应商号码
        /// </summary>
        [SugarColumn(ColumnName = "Mc009", ColumnDescription = "工厂供应商号码", Length = 10)]
        public string Mc009 { get; set; }

        /// <summary>
        /// 日历
        /// </summary>
        [SugarColumn(ColumnName = "Mc010", ColumnDescription = "日历", Length = 2)]
        public string Mc010 { get; set; }

        /// <summary>
        /// 名称 2
        /// </summary>
        [SugarColumn(ColumnName = "Mc011", ColumnDescription = "名称 2", Length = 60)]
        public string Mc011 { get; set; }

        /// <summary>
        /// 住宅号及街道
        /// </summary>
        [SugarColumn(ColumnName = "Mc012", ColumnDescription = "住宅号及街道", Length = 30)]
        public string Mc012 { get; set; }

        /// <summary>
        /// 邮政信箱
        /// </summary>
        [SugarColumn(ColumnName = "Mc013", ColumnDescription = "邮政信箱", Length = 10)]
        public string Mc013 { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        [SugarColumn(ColumnName = "Mc014", ColumnDescription = "邮政编码", Length = 10)]
        public string Mc014 { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [SugarColumn(ColumnName = "Mc015", ColumnDescription = "城市", Length = 25)]
        public string Mc015 { get; set; }

        /// <summary>
        /// 采购组织
        /// </summary>
        [SugarColumn(ColumnName = "Mc016", ColumnDescription = "采购组织", Length = 4)]
        public string Mc016 { get; set; }

        /// <summary>
        /// 销售组织
        /// </summary>
        [SugarColumn(ColumnName = "Mc017", ColumnDescription = "销售组织", Length = 4)]
        public string Mc017 { get; set; }

        /// <summary>
        /// 批量管理
        /// </summary>
        [SugarColumn(ColumnName = "Mc018", ColumnDescription = "批量管理", Length = 1)]
        public string Mc018 { get; set; }

        /// <summary>
        /// 工厂条件
        /// </summary>
        [SugarColumn(ColumnName = "Mc019", ColumnDescription = "工厂条件", Length = 1)]
        public string Mc019 { get; set; }

        /// <summary>
        /// 源清单
        /// </summary>
        [SugarColumn(ColumnName = "Mc020", ColumnDescription = "源清单", Length = 1)]
        public string Mc020 { get; set; }

        /// <summary>
        /// MRP
        /// </summary>
        [SugarColumn(ColumnName = "Mc021", ColumnDescription = "MRP", Length = 1)]
        public string Mc021 { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        [SugarColumn(ColumnName = "Mc022", ColumnDescription = "国家", Length = 3)]
        public string Mc022 { get; set; }

        /// <summary>
        /// 地区
        /// </summary>
        [SugarColumn(ColumnName = "Mc023", ColumnDescription = "地区", Length = 3)]
        public string Mc023 { get; set; }

        /// <summary>
        /// 县
        /// </summary>
        [SugarColumn(ColumnName = "Mc024", ColumnDescription = "县", Length = 3)]
        public string Mc024 { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [SugarColumn(ColumnName = "Mc025", ColumnDescription = "市", Length = 4)]
        public string Mc025 { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [SugarColumn(ColumnName = "Mc026", ColumnDescription = "地址", Length = 10)]
        public string Mc026 { get; set; }

        /// <summary>
        /// 计划工厂
        /// </summary>
        [SugarColumn(ColumnName = "Mc027", ColumnDescription = "计划工厂", Length = 4)]
        public string Mc027 { get; set; }

        /// <summary>
        /// 地区税务代码
        /// </summary>
        [SugarColumn(ColumnName = "Mc028", ColumnDescription = "地区税务代码", Length = 15)]
        public string Mc028 { get; set; }

        /// <summary>
        /// 分销渠道
        /// </summary>
        [SugarColumn(ColumnName = "Mc029", ColumnDescription = "分销渠道", Length = 2)]
        public string Mc029 { get; set; }

        /// <summary>
        /// 产品组
        /// </summary>
        [SugarColumn(ColumnName = "Mc030", ColumnDescription = "产品组", Length = 2)]
        public string Mc030 { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        [SugarColumn(ColumnName = "Mc031", ColumnDescription = "语言", Length = 6)]
        public string Mc031 { get; set; }

        /// <summary>
        /// SOP工厂
        /// </summary>
        [SugarColumn(ColumnName = "Mc032", ColumnDescription = "SOP工厂", Length = 1)]
        public string Mc032 { get; set; }

        /// <summary>
        /// 差异码
        /// </summary>
        [SugarColumn(ColumnName = "Mc033", ColumnDescription = "差异码", Length = 6)]
        public string Mc033 { get; set; }

        /// <summary>
        /// 批量管理
        /// </summary>
        [SugarColumn(ColumnName = "Mc034", ColumnDescription = "批量管理", Length = 1)]
        public string Mc034 { get; set; }

        /// <summary>
        /// 工厂种类
        /// </summary>
        [SugarColumn(ColumnName = "Mc035", ColumnDescription = "工厂种类", Length = 1)]
        public string Mc035 { get; set; }

        /// <summary>
        /// 销售地区
        /// </summary>
        [SugarColumn(ColumnName = "Mc036", ColumnDescription = "销售地区", Length = 6)]
        public string Mc036 { get; set; }

        /// <summary>
        /// 供应地区
        /// </summary>
        [SugarColumn(ColumnName = "Mc037", ColumnDescription = "供应地区", Length = 10)]
        public string Mc037 { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Mc038", ColumnDescription = "工厂", Length = 1)]
        public string Mc038 { get; set; }

        /// <summary>
        /// 常规供应商
        /// </summary>
        [SugarColumn(ColumnName = "Mc039", ColumnDescription = "常规供应商", Length = 1)]
        public string Mc039 { get; set; }

        /// <summary>
        /// 第一封催询单
        /// </summary>
        [SugarColumn(ColumnName = "Mc040", ColumnDescription = "第一封催询单", DefaultValue = "0")]
        public int? Mc040 { get; set; }

        /// <summary>
        /// 第二封催询单
        /// </summary>
        [SugarColumn(ColumnName = "Mc041", ColumnDescription = "第二封催询单", DefaultValue = "0")]
        public int? Mc041 { get; set; }

        /// <summary>
        /// 第三封催询单
        /// </summary>
        [SugarColumn(ColumnName = "Mc042", ColumnDescription = "第三封催询单", DefaultValue = "0")]
        public int? Mc042 { get; set; }

        /// <summary>
        /// 第一催讨文本
        /// </summary>
        [SugarColumn(ColumnName = "Mc043", ColumnDescription = "第一催讨文本", Length = 16)]
        public string Mc043 { get; set; }

        /// <summary>
        /// 第二催讨文本
        /// </summary>
        [SugarColumn(ColumnName = "Mc044", ColumnDescription = "第二催讨文本", Length = 16)]
        public string Mc044 { get; set; }

        /// <summary>
        /// 第三催讨文本
        /// </summary>
        [SugarColumn(ColumnName = "Mc045", ColumnDescription = "第三催讨文本", Length = 16)]
        public string Mc045 { get; set; }

        /// <summary>
        /// 采购订单容差
        /// </summary>
        [SugarColumn(ColumnName = "Mc046", ColumnDescription = "采购订单容差", DefaultValue = "0")]
        public int? Mc046 { get; set; }

        /// <summary>
        /// 业务地点
        /// </summary>
        [SugarColumn(ColumnName = "Mc047", ColumnDescription = "业务地点", Length = 4)]
        public string Mc047 { get; set; }

        /// <summary>
        /// 销售范围
        /// </summary>
        [SugarColumn(ColumnName = "Mc048", ColumnDescription = "销售范围", Length = 2)]
        public string Mc048 { get; set; }

        /// <summary>
        /// 工厂分配
        /// </summary>
        [SugarColumn(ColumnName = "Mc049", ColumnDescription = "工厂分配", Length = 3)]
        public string Mc049 { get; set; }

        /// <summary>
        /// 归档标记
        /// </summary>
        [SugarColumn(ColumnName = "Mc050", ColumnDescription = "归档标记", Length = 1)]
        public string Mc050 { get; set; }

        /// <summary>
        /// 批次记录
        /// </summary>
        [SugarColumn(ColumnName = "Mc051", ColumnDescription = "批次记录", Length = 1)]
        public string Mc051 { get; set; }

        /// <summary>
        /// 节点类型
        /// </summary>
        [SugarColumn(ColumnName = "Mc052", ColumnDescription = "节点类型", Length = 3)]
        public string Mc052 { get; set; }

        /// <summary>
        /// 名称结构
        /// </summary>
        [SugarColumn(ColumnName = "Mc053", ColumnDescription = "名称结构", Length = 4)]
        public string Mc053 { get; set; }

        /// <summary>
        /// 成本对象控制
        /// </summary>
        [SugarColumn(ColumnName = "Mc054", ColumnDescription = "成本对象控制", Length = 1)]
        public string Mc054 { get; set; }

        /// <summary>
        /// 混合成本核算
        /// </summary>
        [SugarColumn(ColumnName = "Mc055", ColumnDescription = "混合成本核算", Length = 1)]
        public string Mc055 { get; set; }

        /// <summary>
        /// 实际成本核算
        /// </summary>
        [SugarColumn(ColumnName = "Mc056", ColumnDescription = "实际成本核算", Length = 1)]
        public string Mc056 { get; set; }

        /// <summary>
        /// 装运点/接收点
        /// </summary>
        [SugarColumn(ColumnName = "Mc057", ColumnDescription = "装运点/接收点", Length = 4)]
        public string Mc057 { get; set; }

        /// <summary>
        /// 更新作业消耗
        /// </summary>
        [SugarColumn(ColumnName = "Mc058", ColumnDescription = "更新作业消耗", Length = 1)]
        public string Mc058 { get; set; }

        /// <summary>
        /// 信用控制
        /// </summary>
        [SugarColumn(ColumnName = "Mc059", ColumnDescription = "信用控制", Length = 1)]
        public string Mc059 { get; set; }

        /// <summary>
        /// 附加货源
        /// </summary>
        [SugarColumn(ColumnName = "Mc060", ColumnDescription = "附加货源", Length = 1)]
        public string Mc060 { get; set; }

        /// <summary>
        /// 交易评估
        /// </summary>
        [SugarColumn(ColumnName = "Mc061", ColumnDescription = "交易评估", Length = 1)]
        public string Mc061 { get; set; }

        /// <summary>
        /// 供应商类型
        /// </summary>
        [SugarColumn(ColumnName = "Mc062", ColumnDescription = "供应商类型", Length = 1)]
        public string Mc062 { get; set; }

        /// <summary>
        /// IPI信贷
        /// </summary>
        [SugarColumn(ColumnName = "Mc063", ColumnDescription = "IPI信贷", Length = 1)]
        public string Mc063 { get; set; }

        /// <summary>
        /// 存储类别
        /// </summary>
        [SugarColumn(ColumnName = "Mc064", ColumnDescription = "存储类别", Length = 1)]
        public string Mc064 { get; set; }

        /// <summary>
        /// 上级公司
        /// </summary>
        [SugarColumn(ColumnName = "Mc065", ColumnDescription = "上级公司", Length = 4)]
        public string Mc065 { get; set; }
    }
}