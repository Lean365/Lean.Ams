namespace Ams.Model.Logistics
{
    /// <summary>
    /// 物料评估
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:30:25
    /// </summary>
    [SugarTable("mm_mbew", "物料评估")]
    public class MmMbew : SysBase
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
        [SugarColumn(ColumnName = "Md002", ColumnDescription = "集团", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md002 { get; set; }

        /// <summary>
        /// 物料号
        /// </summary>
        [SugarColumn(ColumnName = "Md003", ColumnDescription = "物料号", Length = 18, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md003 { get; set; }

        /// <summary>
        /// 评估范围
        /// </summary>
        [SugarColumn(ColumnName = "Md004", ColumnDescription = "评估范围", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md004 { get; set; }

        /// <summary>
        /// 评估类型
        /// </summary>
        [SugarColumn(ColumnName = "Md005", ColumnDescription = "评估类型", Length = 10, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md005 { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        [SugarColumn(ColumnName = "Md006", ColumnDescription = "删除标志", Length = 1)]
        public string Md006 { get; set; }

        /// <summary>
        /// 总库存
        /// </summary>
        [SugarColumn(ColumnName = "Md007", ColumnDescription = "总库存", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md007 { get; set; }

        /// <summary>
        /// 估价值
        /// </summary>
        [SugarColumn(ColumnName = "Md008", ColumnDescription = "估价值", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md008 { get; set; }

        /// <summary>
        /// 价格控制
        /// </summary>
        [SugarColumn(ColumnName = "Md009", ColumnDescription = "价格控制", Length = 1)]
        public string Md009 { get; set; }

        /// <summary>
        /// 移动价格
        /// </summary>
        [SugarColumn(ColumnName = "Md010", ColumnDescription = "移动价格", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md010 { get; set; }

        /// <summary>
        /// 标准价格
        /// </summary>
        [SugarColumn(ColumnName = "Md011", ColumnDescription = "标准价格", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md011 { get; set; }

        /// <summary>
        /// 价格单位
        /// </summary>
        [SugarColumn(ColumnName = "Md012", ColumnDescription = "价格单位", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md012 { get; set; }

        /// <summary>
        /// 评估类
        /// </summary>
        [SugarColumn(ColumnName = "Md013", ColumnDescription = "评估类", Length = 4)]
        public string Md013 { get; set; }

        /// <summary>
        /// 价值/MA价格
        /// </summary>
        [SugarColumn(ColumnName = "Md014", ColumnDescription = "价值/MA价格", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md014 { get; set; }

        /// <summary>
        /// 前期总库存
        /// </summary>
        [SugarColumn(ColumnName = "Md015", ColumnDescription = "前期总库存", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md015 { get; set; }

        /// <summary>
        /// 前期总价值
        /// </summary>
        [SugarColumn(ColumnName = "Md016", ColumnDescription = "前期总价值", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md016 { get; set; }

        /// <summary>
        /// 前期价格控制
        /// </summary>
        [SugarColumn(ColumnName = "Md017", ColumnDescription = "前期价格控制", Length = 1)]
        public string Md017 { get; set; }

        /// <summary>
        /// 前期移动平均价
        /// </summary>
        [SugarColumn(ColumnName = "Md018", ColumnDescription = "前期移动平均价", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md018 { get; set; }

        /// <summary>
        /// 前期标准价格
        /// </summary>
        [SugarColumn(ColumnName = "Md019", ColumnDescription = "前期标准价格", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md019 { get; set; }

        /// <summary>
        /// 上期价格单位
        /// </summary>
        [SugarColumn(ColumnName = "Md020", ColumnDescription = "上期价格单位", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md020 { get; set; }

        /// <summary>
        /// 上期评价分类
        /// </summary>
        [SugarColumn(ColumnName = "Md021", ColumnDescription = "上期评价分类", Length = 4)]
        public string Md021 { get; set; }

        /// <summary>
        /// 上期价值
        /// </summary>
        [SugarColumn(ColumnName = "Md022", ColumnDescription = "上期价值", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md022 { get; set; }

        /// <summary>
        /// 前年总库存
        /// </summary>
        [SugarColumn(ColumnName = "Md023", ColumnDescription = "前年总库存", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md023 { get; set; }

        /// <summary>
        /// 上年总价值
        /// </summary>
        [SugarColumn(ColumnName = "Md024", ColumnDescription = "上年总价值", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md024 { get; set; }

        /// <summary>
        /// 前年价格控制
        /// </summary>
        [SugarColumn(ColumnName = "Md025", ColumnDescription = "前年价格控制", Length = 1)]
        public string Md025 { get; set; }

        /// <summary>
        /// 去年移动平均价
        /// </summary>
        [SugarColumn(ColumnName = "Md026", ColumnDescription = "去年移动平均价", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md026 { get; set; }

        /// <summary>
        /// 去年标准价格
        /// </summary>
        [SugarColumn(ColumnName = "Md027", ColumnDescription = "去年标准价格", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md027 { get; set; }

        /// <summary>
        /// 上年价格单位
        /// </summary>
        [SugarColumn(ColumnName = "Md028", ColumnDescription = "上年价格单位", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md028 { get; set; }

        /// <summary>
        /// 上年评估类
        /// </summary>
        [SugarColumn(ColumnName = "Md029", ColumnDescription = "上年评估类", Length = 4)]
        public string Md029 { get; set; }

        /// <summary>
        /// 上年价值
        /// </summary>
        [SugarColumn(ColumnName = "Md030", ColumnDescription = "上年价值", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md030 { get; set; }

        /// <summary>
        /// 当前会计年度
        /// </summary>
        [SugarColumn(ColumnName = "Md031", ColumnDescription = "当前会计年度", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md031 { get; set; }

        /// <summary>
        /// 当前期间
        /// </summary>
        [SugarColumn(ColumnName = "Md032", ColumnDescription = "当前期间", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md032 { get; set; }

        /// <summary>
        /// 评估类别
        /// </summary>
        [SugarColumn(ColumnName = "Md033", ColumnDescription = "评估类别", Length = 1)]
        public string Md033 { get; set; }

        /// <summary>
        /// 上期价格
        /// </summary>
        [SugarColumn(ColumnName = "Md034", ColumnDescription = "上期价格", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md034 { get; set; }

        /// <summary>
        /// 最新价格更改
        /// </summary>
        public DateTime? Md035 { get; set; }

        /// <summary>
        /// 未来价格
        /// </summary>
        [SugarColumn(ColumnName = "Md036", ColumnDescription = "未来价格", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md036 { get; set; }

        /// <summary>
        /// 有效起始日期
        /// </summary>
        public DateTime? Md037 { get; set; }

        /// <summary>
        /// 时戳
        /// </summary>
        [SugarColumn(ColumnName = "Md038", ColumnDescription = "时戳", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md038 { get; set; }

        /// <summary>
        /// 税价1
        /// </summary>
        [SugarColumn(ColumnName = "Md039", ColumnDescription = "税价1", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md039 { get; set; }

        /// <summary>
        /// 商业价格1
        /// </summary>
        [SugarColumn(ColumnName = "Md040", ColumnDescription = "商业价格1", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md040 { get; set; }

        /// <summary>
        /// 税价3
        /// </summary>
        [SugarColumn(ColumnName = "Md041", ColumnDescription = "税价3", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md041 { get; set; }

        /// <summary>
        /// 商业价格3
        /// </summary>
        [SugarColumn(ColumnName = "Md042", ColumnDescription = "商业价格3", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md042 { get; set; }

        /// <summary>
        /// 计价
        /// </summary>
        [SugarColumn(ColumnName = "Md043", ColumnDescription = "计价", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md043 { get; set; }

        /// <summary>
        /// 前年总库存
        /// </summary>
        [SugarColumn(ColumnName = "Md044", ColumnDescription = "前年总库存", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md044 { get; set; }

        /// <summary>
        /// 前期总价值
        /// </summary>
        [SugarColumn(ColumnName = "Md045", ColumnDescription = "前期总价值", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md045 { get; set; }

        /// <summary>
        /// 计价在
        /// </summary>
        [SugarColumn(ColumnName = "Md046", ColumnDescription = "计价在", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md046 { get; set; }

        /// <summary>
        /// 未来计划价格
        /// </summary>
        [SugarColumn(ColumnName = "Md047", ColumnDescription = "未来计划价格", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md047 { get; set; }

        /// <summary>
        /// 未来计划价格1
        /// </summary>
        [SugarColumn(ColumnName = "Md048", ColumnDescription = "未来计划价格1", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md048 { get; set; }

        /// <summary>
        /// 未来计划价格 2
        /// </summary>
        [SugarColumn(ColumnName = "Md049", ColumnDescription = "未来计划价格 2", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md049 { get; set; }

        /// <summary>
        /// 未来计划价格 3
        /// </summary>
        [SugarColumn(ColumnName = "Md050", ColumnDescription = "未来计划价格 3", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md050 { get; set; }

        /// <summary>
        /// 计划价格日期1
        /// </summary>
        public DateTime? Md051 { get; set; }

        /// <summary>
        /// 计划价格日期2
        /// </summary>
        public DateTime? Md052 { get; set; }

        /// <summary>
        /// 计划价格日期3
        /// </summary>
        public DateTime? Md053 { get; set; }

        /// <summary>
        /// 未来成本估算
        /// </summary>
        public DateTime? Md054 { get; set; }

        /// <summary>
        /// 期间成本估算
        /// </summary>
        public DateTime? Md055 { get; set; }

        /// <summary>
        /// 上期成本估算
        /// </summary>
        public DateTime? Md056 { get; set; }

        /// <summary>
        /// 未来成本估算
        /// </summary>
        [SugarColumn(ColumnName = "Md057", ColumnDescription = "未来成本估算", Length = 1)]
        public string Md057 { get; set; }

        /// <summary>
        /// 当前成本估算
        /// </summary>
        [SugarColumn(ColumnName = "Md058", ColumnDescription = "当前成本估算", Length = 1)]
        public string Md058 { get; set; }

        /// <summary>
        /// 上期成本估算
        /// </summary>
        [SugarColumn(ColumnName = "Md059", ColumnDescription = "上期成本估算", Length = 1)]
        public string Md059 { get; set; }

        /// <summary>
        /// 一般费用代码
        /// </summary>
        [SugarColumn(ColumnName = "Md060", ColumnDescription = "一般费用代码", Length = 6)]
        public string Md060 { get; set; }

        /// <summary>
        /// LIFO/FIFO 相关
        /// </summary>
        [SugarColumn(ColumnName = "Md061", ColumnDescription = "LIFO/FIFO 相关", Length = 1)]
        public string Md061 { get; set; }

        /// <summary>
        /// LIFO评估储备号
        /// </summary>
        [SugarColumn(ColumnName = "Md062", ColumnDescription = "LIFO评估储备号", Length = 4)]
        public string Md062 { get; set; }

        /// <summary>
        /// 商业价格2
        /// </summary>
        [SugarColumn(ColumnName = "Md063", ColumnDescription = "商业价格2", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md063 { get; set; }

        /// <summary>
        /// 税价2
        /// </summary>
        [SugarColumn(ColumnName = "Md064", ColumnDescription = "税价2", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md064 { get; set; }

        /// <summary>
        /// 贬值标志
        /// </summary>
        [SugarColumn(ColumnName = "Md065", ColumnDescription = "贬值标志", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md065 { get; set; }

        /// <summary>
        /// 维护状态
        /// </summary>
        [SugarColumn(ColumnName = "Md066", ColumnDescription = "维护状态", Length = 15)]
        public string Md066 { get; set; }

        /// <summary>
        /// 产品成本核算
        /// </summary>
        [SugarColumn(ColumnName = "Md067", ColumnDescription = "产品成本核算", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md067 { get; set; }

        /// <summary>
        /// 成本估算编号
        /// </summary>
        [SugarColumn(ColumnName = "Md068", ColumnDescription = "成本估算编号", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md068 { get; set; }

        /// <summary>
        /// 评估变式1
        /// </summary>
        [SugarColumn(ColumnName = "Md069", ColumnDescription = "评估变式1", Length = 3)]
        public string Md069 { get; set; }

        /// <summary>
        /// 评估变式2
        /// </summary>
        [SugarColumn(ColumnName = "Md070", ColumnDescription = "评估变式2", Length = 3)]
        public string Md070 { get; set; }

        /// <summary>
        /// 评估变式3
        /// </summary>
        [SugarColumn(ColumnName = "Md071", ColumnDescription = "评估变式3", Length = 3)]
        public string Md071 { get; set; }

        /// <summary>
        /// 成本核算版本1
        /// </summary>
        [SugarColumn(ColumnName = "Md072", ColumnDescription = "成本核算版本1", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md072 { get; set; }

        /// <summary>
        /// 成本核算版本2
        /// </summary>
        [SugarColumn(ColumnName = "Md073", ColumnDescription = "成本核算版本2", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md073 { get; set; }

        /// <summary>
        /// 成本核算版本3
        /// </summary>
        [SugarColumn(ColumnName = "Md074", ColumnDescription = "成本核算版本3", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md074 { get; set; }

        /// <summary>
        /// 原始组
        /// </summary>
        [SugarColumn(ColumnName = "Md075", ColumnDescription = "原始组", Length = 4)]
        public string Md075 { get; set; }

        /// <summary>
        /// 间接费分组
        /// </summary>
        [SugarColumn(ColumnName = "Md076", ColumnDescription = "间接费分组", Length = 10)]
        public string Md076 { get; set; }

        /// <summary>
        /// 计价期间
        /// </summary>
        [SugarColumn(ColumnName = "Md077", ColumnDescription = "计价期间", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md077 { get; set; }

        /// <summary>
        /// 当前期间
        /// </summary>
        [SugarColumn(ColumnName = "Md078", ColumnDescription = "当前期间", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md078 { get; set; }

        /// <summary>
        /// 前一期间
        /// </summary>
        [SugarColumn(ColumnName = "Md079", ColumnDescription = "前一期间", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md079 { get; set; }

        /// <summary>
        /// 未来会计年度
        /// </summary>
        [SugarColumn(ColumnName = "Md080", ColumnDescription = "未来会计年度", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md080 { get; set; }

        /// <summary>
        /// 当前会计年度
        /// </summary>
        [SugarColumn(ColumnName = "Md081", ColumnDescription = "当前会计年度", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md081 { get; set; }

        /// <summary>
        /// 上一会计年度
        /// </summary>
        [SugarColumn(ColumnName = "Md082", ColumnDescription = "上一会计年度", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md082 { get; set; }

        /// <summary>
        /// QS成本核算
        /// </summary>
        [SugarColumn(ColumnName = "Md083", ColumnDescription = "QS成本核算", Length = 1)]
        public string Md083 { get; set; }

        /// <summary>
        /// 上期标准价格
        /// </summary>
        [SugarColumn(ColumnName = "Md084", ColumnDescription = "上期标准价格", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md084 { get; set; }

        /// <summary>
        /// ML作业
        /// </summary>
        [SugarColumn(ColumnName = "Md085", ColumnDescription = "ML作业", Length = 1)]
        public string Md085 { get; set; }

        /// <summary>
        /// 价格确定
        /// </summary>
        [SugarColumn(ColumnName = "Md086", ColumnDescription = "价格确定", Length = 1)]
        public string Md086 { get; set; }

        /// <summary>
        /// 当前计划价格
        /// </summary>
        [SugarColumn(ColumnName = "Md087", ColumnDescription = "当前计划价格", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md087 { get; set; }

        /// <summary>
        /// 总SP值
        /// </summary>
        [SugarColumn(ColumnName = "Md088", ColumnDescription = "总SP值", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md088 { get; set; }

        /// <summary>
        /// 物料来源
        /// </summary>
        [SugarColumn(ColumnName = "Md089", ColumnDescription = "物料来源", Length = 1)]
        public string Md089 { get; set; }

        /// <summary>
        /// 库存冻结
        /// </summary>
        [SugarColumn(ColumnName = "Md090", ColumnDescription = "库存冻结", Length = 1)]
        public string Md090 { get; set; }

        /// <summary>
        /// 库存盘点VO物料
        /// </summary>
        [SugarColumn(ColumnName = "Md091", ColumnDescription = "库存盘点VO物料", Length = 3)]
        public string Md091 { get; set; }

        /// <summary>
        /// 最新实际盘点日期
        /// </summary>
        public DateTime? Md092 { get; set; }

        /// <summary>
        /// 周期盘点的盘点标识
        /// </summary>
        [SugarColumn(ColumnName = "Md093", ColumnDescription = "周期盘点的盘点标识", Length = 1)]
        public string Md093 { get; set; }

        /// <summary>
        /// 评价毛利
        /// </summary>
        [SugarColumn(ColumnName = "Md094", ColumnDescription = "评价毛利", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md094 { get; set; }

        /// <summary>
        /// 当前计划价格的固定金额
        /// </summary>
        [SugarColumn(ColumnName = "Md095", ColumnDescription = "当前计划价格的固定金额", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md095 { get; set; }

        /// <summary>
        /// 上年计划价格的固定比例
        /// </summary>
        [SugarColumn(ColumnName = "Md096", ColumnDescription = "上年计划价格的固定比例", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md096 { get; set; }

        /// <summary>
        /// 未来计划价格的固定比例
        /// </summary>
        [SugarColumn(ColumnName = "Md097", ColumnDescription = "未来计划价格的固定比例", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md097 { get; set; }

        /// <summary>
        /// 当前的值决策
        /// </summary>
        [SugarColumn(ColumnName = "Md098", ColumnDescription = "当前的值决策", Length = 1)]
        public string Md098 { get; set; }

        /// <summary>
        /// 上年评估策略
        /// </summary>
        [SugarColumn(ColumnName = "Md099", ColumnDescription = "上年评估策略", Length = 1)]
        public string Md099 { get; set; }

        /// <summary>
        /// 未来评估决策
        /// </summary>
        [SugarColumn(ColumnName = "Md100", ColumnDescription = "未来评估决策", Length = 1)]
        public string Md100 { get; set; }

        /// <summary>
        /// 销售订单库存
        /// </summary>
        [SugarColumn(ColumnName = "Md101", ColumnDescription = "销售订单库存", Length = 4)]
        public string Md101 { get; set; }

        /// <summary>
        /// 项目库存评估类
        /// </summary>
        [SugarColumn(ColumnName = "Md102", ColumnDescription = "项目库存评估类", Length = 4)]
        public string Md102 { get; set; }

        /// <summary>
        /// 物料用途
        /// </summary>
        [SugarColumn(ColumnName = "Md103", ColumnDescription = "物料用途", Length = 1)]
        public string Md103 { get; set; }

        /// <summary>
        /// 物料来源
        /// </summary>
        [SugarColumn(ColumnName = "Md104", ColumnDescription = "物料来源", Length = 1)]
        public string Md104 { get; set; }

        /// <summary>
        /// 自制产品
        /// </summary>
        [SugarColumn(ColumnName = "Md105", ColumnDescription = "自制产品", Length = 1)]
        public string Md105 { get; set; }

        /// <summary>
        /// 评估单位
        /// </summary>
        [SugarColumn(ColumnName = "Md106", ColumnDescription = "评估单位", Length = 1)]
        public string Md106 { get; set; }

        /// <summary>
        /// 价格单位
        /// </summary>
        [SugarColumn(ColumnName = "Md107", ColumnDescription = "价格单位", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md107 { get; set; }

        /// <summary>
        /// 最后期间之前
        /// </summary>
        [SugarColumn(ColumnName = "Md108", ColumnDescription = "最后期间之前", Length = 1)]
        public string Md108 { get; set; }

        /// <summary>
        /// VC供应商
        /// </summary>
        [SugarColumn(ColumnName = "Md109", ColumnDescription = "VC供应商", Length = 4)]
        public string Md109 { get; set; }

        /// <summary>
        /// 预付库存
        /// </summary>
        [SugarColumn(ColumnName = "Md110", ColumnDescription = "预付库存", Length = 1)]
        public string Md110 { get; set; }
    }
}