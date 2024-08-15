namespace Ams.Model.Logistics
{
    /// <summary>
    /// 物料评估
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:50:11
    /// </summary>
    [SugarTable("mm_mbew", "物料评估")]
    public class MmMbew : SysBase
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
        [SugarColumn(ColumnName = "Matnr", ColumnDescription = "物料号 ", Length = 18)]
        public string Matnr { get; set; }

        /// <summary>
        /// 评估范围
        /// </summary>
        [SugarColumn(ColumnName = "Bwkey", ColumnDescription = "评估范围 ", Length = 4)]
        public string Bwkey { get; set; }

        /// <summary>
        /// 评估类型
        /// </summary>
        [SugarColumn(ColumnName = "Bwtar", ColumnDescription = "评估类型 ", Length = 10)]
        public string Bwtar { get; set; }

        /// <summary>
        /// 一种评估类型的所有物料数据的删除标志
        /// </summary>
        [SugarColumn(ColumnName = "Lvorm", ColumnDescription = "一种评估类型的所有物料数据的删除标志 ", Length = 1)]
        public string Lvorm { get; set; }

        /// <summary>
        /// 总计已估计库存
        /// </summary>
        [SugarColumn(ColumnName = "Lbkum", ColumnDescription = "总计已估计库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Lbkum { get; set; }

        /// <summary>
        /// 估价的总库存价值
        /// </summary>
        [SugarColumn(ColumnName = "Salk3", ColumnDescription = "估价的总库存价值 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Salk3 { get; set; }

        /// <summary>
        /// 价格控制指示符
        /// </summary>
        [SugarColumn(ColumnName = "Vprsv", ColumnDescription = "价格控制指示符 ", Length = 1)]
        public string Vprsv { get; set; }

        /// <summary>
        /// 移动平均价格/周期单价
        /// </summary>
        [SugarColumn(ColumnName = "Verpr", ColumnDescription = "移动平均价格/周期单价 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Verpr { get; set; }

        /// <summary>
        /// 标准价格
        /// </summary>
        [SugarColumn(ColumnName = "Stprs", ColumnDescription = "标准价格 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Stprs { get; set; }

        /// <summary>
        /// 价格单位
        /// </summary>
        [SugarColumn(ColumnName = "Peinh", ColumnDescription = "价格单位 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Peinh { get; set; }

        /// <summary>
        /// 评估类
        /// </summary>
        [SugarColumn(ColumnName = "Bklas", ColumnDescription = "评估类 ", Length = 4)]
        public string Bklas { get; set; }

        /// <summary>
        /// 基于平均移动价的值（仅价格控制 S）
        /// </summary>
        [SugarColumn(ColumnName = "Salkv", ColumnDescription = "基于平均移动价的值（仅价格控制 S） ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Salkv { get; set; }

        /// <summary>
        /// 前期的总评估库存
        /// </summary>
        [SugarColumn(ColumnName = "Vmkum", ColumnDescription = "前期的总评估库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vmkum { get; set; }

        /// <summary>
        /// 上期估过价的总库存价值
        /// </summary>
        [SugarColumn(ColumnName = "Vmsal", ColumnDescription = "上期估过价的总库存价值 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vmsal { get; set; }

        /// <summary>
        /// 前一期间价格控制标识
        /// </summary>
        [SugarColumn(ColumnName = "Vmvpr", ColumnDescription = "前一期间价格控制标识 ", Length = 1)]
        public string Vmvpr { get; set; }

        /// <summary>
        /// 前一期间的移动平均价格/期间单位价格
        /// </summary>
        [SugarColumn(ColumnName = "Vmver", ColumnDescription = "前一期间的移动平均价格/期间单位价格 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vmver { get; set; }

        /// <summary>
        /// 前期的标准价格
        /// </summary>
        [SugarColumn(ColumnName = "Vmstp", ColumnDescription = "前期的标准价格 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vmstp { get; set; }

        /// <summary>
        /// 前期的价格单位
        /// </summary>
        [SugarColumn(ColumnName = "Vmpei", ColumnDescription = "前期的价格单位 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vmpei { get; set; }

        /// <summary>
        /// 上期的评价分类
        /// </summary>
        [SugarColumn(ColumnName = "Vmbkl", ColumnDescription = "上期的评价分类 ", Length = 4)]
        public string Vmbkl { get; set; }

        /// <summary>
        /// 基于平均移动价的值(上期)
        /// </summary>
        [SugarColumn(ColumnName = "Vmsav", ColumnDescription = "基于平均移动价的值(上期) ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vmsav { get; set; }

        /// <summary>
        /// 前年的总评估库存
        /// </summary>
        [SugarColumn(ColumnName = "Vjkum", ColumnDescription = "前年的总评估库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vjkum { get; set; }

        /// <summary>
        /// 上年估价的总库存价值
        /// </summary>
        [SugarColumn(ColumnName = "Vjsal", ColumnDescription = "上年估价的总库存价值 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vjsal { get; set; }

        /// <summary>
        /// 前一年的价格控制标识
        /// </summary>
        [SugarColumn(ColumnName = "Vjvpr", ColumnDescription = "前一年的价格控制标识 ", Length = 1)]
        public string Vjvpr { get; set; }

        /// <summary>
        /// 前一年移动平均价格/期间单价价格
        /// </summary>
        [SugarColumn(ColumnName = "Vjver", ColumnDescription = "前一年移动平均价格/期间单价价格 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vjver { get; set; }

        /// <summary>
        /// 上年的标准价格
        /// </summary>
        [SugarColumn(ColumnName = "Vjstp", ColumnDescription = "上年的标准价格 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vjstp { get; set; }

        /// <summary>
        /// 去年的价格单位
        /// </summary>
        [SugarColumn(ColumnName = "Vjpei", ColumnDescription = "去年的价格单位 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vjpei { get; set; }

        /// <summary>
        /// 上年的评价分类
        /// </summary>
        [SugarColumn(ColumnName = "Vjbkl", ColumnDescription = "上年的评价分类 ", Length = 4)]
        public string Vjbkl { get; set; }

        /// <summary>
        /// 基于平均移动价的值(上年)
        /// </summary>
        [SugarColumn(ColumnName = "Vjsav", ColumnDescription = "基于平均移动价的值(上年) ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vjsav { get; set; }

        /// <summary>
        /// 当前期间的会计年度
        /// </summary>
        [SugarColumn(ColumnName = "Lfgja", ColumnDescription = "当前期间的会计年度 ", DefaultValue = "0")]
        public int? Lfgja { get; set; }

        /// <summary>
        /// 当前期间 (记帐期间)
        /// </summary>
        [SugarColumn(ColumnName = "Lfmon", ColumnDescription = "当前期间 (记帐期间) ", DefaultValue = "0")]
        public int? Lfmon { get; set; }

        /// <summary>
        /// 评估类别
        /// </summary>
        [SugarColumn(ColumnName = "Bwtty", ColumnDescription = "评估类别 ", Length = 1)]
        public string Bwtty { get; set; }

        /// <summary>
        /// 上期价格
        /// </summary>
        [SugarColumn(ColumnName = "Stprv", ColumnDescription = "上期价格 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Stprv { get; set; }

        /// <summary>
        /// 最新价格更改的日期
        /// </summary>
        public DateTime? Laepr { get; set; }

        /// <summary>
        /// 未来价格
        /// </summary>
        [SugarColumn(ColumnName = "Zkprs", ColumnDescription = "未来价格 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Zkprs { get; set; }

        /// <summary>
        /// 价格开始有效的日期
        /// </summary>
        public DateTime? Zkdat { get; set; }

        /// <summary>
        /// 简短格式的 UTC 时戳 (YYYYMMDDhhmmss)
        /// </summary>
        [SugarColumn(ColumnName = "Timestamp", ColumnDescription = "简短格式的 UTC 时戳 (YYYYMMDDhhmmss) ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Timestamp { get; set; }

        /// <summary>
        /// 基于税法的估价价格 - 级别1
        /// </summary>
        [SugarColumn(ColumnName = "Bwprs", ColumnDescription = "基于税法的估价价格 - 级别1 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Bwprs { get; set; }

        /// <summary>
        /// 基于商法的估价价格 - 级别 1
        /// </summary>
        [SugarColumn(ColumnName = "Bwprh", ColumnDescription = "基于商法的估价价格 - 级别 1 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Bwprh { get; set; }

        /// <summary>
        /// 基于税法的估价价格(BTCI) - 级别3
        /// </summary>
        [SugarColumn(ColumnName = "Vjbws", ColumnDescription = "基于税法的估价价格(BTCI) - 级别3 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vjbws { get; set; }

        /// <summary>
        /// 基于商业法律的估价价格 - 级别3
        /// </summary>
        [SugarColumn(ColumnName = "Vjbwh", ColumnDescription = "基于商业法律的估价价格 - 级别3 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vjbwh { get; set; }

        /// <summary>
        /// 前年估价的总库存价值
        /// </summary>
        [SugarColumn(ColumnName = "Vvjsl", ColumnDescription = "前年估价的总库存价值 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vvjsl { get; set; }

        /// <summary>
        /// 前年的总评估库存
        /// </summary>
        [SugarColumn(ColumnName = "Vvjlb", ColumnDescription = "前年的总评估库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vvjlb { get; set; }

        /// <summary>
        /// 前期的总评估库存
        /// </summary>
        [SugarColumn(ColumnName = "Vvmlb", ColumnDescription = "前期的总评估库存 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vvmlb { get; set; }

        /// <summary>
        /// 前期估价的总库存价值
        /// </summary>
        [SugarColumn(ColumnName = "Vvsal", ColumnDescription = "前期估价的总库存价值 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vvsal { get; set; }

        /// <summary>
        /// 未来计划价格
        /// </summary>
        [SugarColumn(ColumnName = "Zplpr", ColumnDescription = "未来计划价格 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Zplpr { get; set; }

        /// <summary>
        /// 未来计划价格1
        /// </summary>
        [SugarColumn(ColumnName = "Zplp1", ColumnDescription = "未来计划价格1 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Zplp1 { get; set; }

        /// <summary>
        /// 未来计划价格 2
        /// </summary>
        [SugarColumn(ColumnName = "Zplp2", ColumnDescription = "未来计划价格 2 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Zplp2 { get; set; }

        /// <summary>
        /// 未来计划价格 3
        /// </summary>
        [SugarColumn(ColumnName = "Zplp3", ColumnDescription = "未来计划价格 3 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Zplp3 { get; set; }

        /// <summary>
        /// 计划价格 1 开始有效的日期
        /// </summary>
        public DateTime? Zpld1 { get; set; }

        /// <summary>
        /// 计划价格 2 开始有效的日期
        /// </summary>
        public DateTime? Zpld2 { get; set; }

        /// <summary>
        /// 计划价格 3 开始有效的日期
        /// </summary>
        public DateTime? Zpld3 { get; set; }

        /// <summary>
        /// 未来标准成本估计的期间(未激活)
        /// </summary>
        public DateTime? Pperz { get; set; }

        /// <summary>
        /// 当前标准成本估计的期间(未激活)
        /// </summary>
        public DateTime? Pperl { get; set; }

        /// <summary>
        /// 以前标准成本估计的期间(未激活)
        /// </summary>
        public DateTime? Pperv { get; set; }

        /// <summary>
        /// 标识: 未来期间的标准成本估算
        /// </summary>
        [SugarColumn(ColumnName = "Kalkz", ColumnDescription = "标识: 未来期间的标准成本估算 ", Length = 1)]
        public string Kalkz { get; set; }

        /// <summary>
        /// 当前期间的标准成本估算
        /// </summary>
        [SugarColumn(ColumnName = "Kalkl", ColumnDescription = "当前期间的标准成本估算 ", Length = 1)]
        public string Kalkl { get; set; }

        /// <summary>
        /// 标识: 上一期间的标准成本估计
        /// </summary>
        [SugarColumn(ColumnName = "Kalkv", ColumnDescription = "标识: 上一期间的标准成本估计 ", Length = 1)]
        public string Kalkv { get; set; }

        /// <summary>
        /// 一般费用代码(未激活)
        /// </summary>
        [SugarColumn(ColumnName = "Kalsc", ColumnDescription = "一般费用代码(未激活) ", Length = 6)]
        public string Kalsc { get; set; }

        /// <summary>
        /// LIFO/FIFO 相关
        /// </summary>
        [SugarColumn(ColumnName = "Xlifo", ColumnDescription = "LIFO/FIFO 相关 ", Length = 1)]
        public string Xlifo { get; set; }

        /// <summary>
        /// 用于LIFO评估的储备号
        /// </summary>
        [SugarColumn(ColumnName = "Mypol", ColumnDescription = "用于LIFO评估的储备号 ", Length = 4)]
        public string Mypol { get; set; }

        /// <summary>
        /// 基于商业法律的估价价格：级别 2
        /// </summary>
        [SugarColumn(ColumnName = "Bwph1", ColumnDescription = "基于商业法律的估价价格：级别 2 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Bwph1 { get; set; }

        /// <summary>
        /// 基于税法的估价价格： 级别2
        /// </summary>
        [SugarColumn(ColumnName = "Bwps1", ColumnDescription = "基于税法的估价价格： 级别2 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Bwps1 { get; set; }

        /// <summary>
        /// 最低价值: 贬值标志
        /// </summary>
        [SugarColumn(ColumnName = "Abwkz", ColumnDescription = "最低价值: 贬值标志 ", DefaultValue = "0")]
        public int? Abwkz { get; set; }

        /// <summary>
        /// 维护状态
        /// </summary>
        [SugarColumn(ColumnName = "Pstat", ColumnDescription = "维护状态 ", Length = 15)]
        public string Pstat { get; set; }

        /// <summary>
        /// 成本估算号 - 产品成本核算
        /// </summary>
        [SugarColumn(ColumnName = "Kaln1", ColumnDescription = "成本估算号 - 产品成本核算 ", DefaultValue = "0")]
        public int? Kaln1 { get; set; }

        /// <summary>
        /// 没有数量结构的成本估算的成本估算编号
        /// </summary>
        [SugarColumn(ColumnName = "Kalnr", ColumnDescription = "没有数量结构的成本估算的成本估算编号 ", DefaultValue = "0")]
        public int? Kalnr { get; set; }

        /// <summary>
        /// 未来的标准成本估算的估价变式
        /// </summary>
        [SugarColumn(ColumnName = "Bwva1", ColumnDescription = "未来的标准成本估算的估价变式 ", Length = 3)]
        public string Bwva1 { get; set; }

        /// <summary>
        /// 当前的标准成本估算的估价变式
        /// </summary>
        [SugarColumn(ColumnName = "Bwva2", ColumnDescription = "当前的标准成本估算的估价变式 ", Length = 3)]
        public string Bwva2 { get; set; }

        /// <summary>
        /// 过去的标准成本估算的估价变式
        /// </summary>
        [SugarColumn(ColumnName = "Bwva3", ColumnDescription = "过去的标准成本估算的估价变式 ", Length = 3)]
        public string Bwva3 { get; set; }

        /// <summary>
        /// 未来的标准成本估算的成本核算方案
        /// </summary>
        [SugarColumn(ColumnName = "Vers1", ColumnDescription = "未来的标准成本估算的成本核算方案 ", DefaultValue = "0")]
        public int? Vers1 { get; set; }

        /// <summary>
        /// 当前的标准成本估算的成本核算方案
        /// </summary>
        [SugarColumn(ColumnName = "Vers2", ColumnDescription = "当前的标准成本估算的成本核算方案 ", DefaultValue = "0")]
        public int? Vers2 { get; set; }

        /// <summary>
        /// 先前的标准成本估算的成本核算方案
        /// </summary>
        [SugarColumn(ColumnName = "Vers3", ColumnDescription = "先前的标准成本估算的成本核算方案 ", DefaultValue = "0")]
        public int? Vers3 { get; set; }

        /// <summary>
        /// 作为成本要素子组的原始组
        /// </summary>
        [SugarColumn(ColumnName = "Hrkft", ColumnDescription = "作为成本要素子组的原始组 ", Length = 4)]
        public string Hrkft { get; set; }

        /// <summary>
        /// 成本核算间接费用组
        /// </summary>
        [SugarColumn(ColumnName = "Kosgr", ColumnDescription = "成本核算间接费用组 ", Length = 10)]
        public string Kosgr { get; set; }

        /// <summary>
        /// 未来成本估算期间
        /// </summary>
        [SugarColumn(ColumnName = "Pprdz", ColumnDescription = "未来成本估算期间 ", DefaultValue = "0")]
        public int? Pprdz { get; set; }

        /// <summary>
        /// 当前的标准成本估算期间
        /// </summary>
        [SugarColumn(ColumnName = "Pprdl", ColumnDescription = "当前的标准成本估算期间 ", DefaultValue = "0")]
        public int? Pprdl { get; set; }

        /// <summary>
        /// 先前的标准成本估算期间
        /// </summary>
        [SugarColumn(ColumnName = "Pprdv", ColumnDescription = "先前的标准成本估算期间 ", DefaultValue = "0")]
        public int? Pprdv { get; set; }

        /// <summary>
        /// 未来标准成本估算的会计年度
        /// </summary>
        [SugarColumn(ColumnName = "Pdatz", ColumnDescription = "未来标准成本估算的会计年度 ", DefaultValue = "0")]
        public int? Pdatz { get; set; }

        /// <summary>
        /// 当前标准成本估算的会计年度
        /// </summary>
        [SugarColumn(ColumnName = "Pdatl", ColumnDescription = "当前标准成本估算的会计年度 ", DefaultValue = "0")]
        public int? Pdatl { get; set; }

        /// <summary>
        /// 上一标准成本估算的会计年度
        /// </summary>
        [SugarColumn(ColumnName = "Pdatv", ColumnDescription = "上一标准成本估算的会计年度 ", DefaultValue = "0")]
        public int? Pdatv { get; set; }

        /// <summary>
        /// 物料根据数量结构进行成本核算
        /// </summary>
        [SugarColumn(ColumnName = "Ekalr", ColumnDescription = "物料根据数量结构进行成本核算 ", Length = 1)]
        public string Ekalr { get; set; }

        /// <summary>
        /// 上期标准价格
        /// </summary>
        [SugarColumn(ColumnName = "Vplpr", ColumnDescription = "上期标准价格 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vplpr { get; set; }

        /// <summary>
        /// 物料帐簿在物料层被激活
        /// </summary>
        [SugarColumn(ColumnName = "Mlmaa", ColumnDescription = "物料帐簿在物料层被激活 ", Length = 1)]
        public string Mlmaa { get; set; }

        /// <summary>
        /// 物料价格确定: 控制
        /// </summary>
        [SugarColumn(ColumnName = "Mlast", ColumnDescription = "物料价格确定: 控制 ", Length = 1)]
        public string Mlast { get; set; }

        /// <summary>
        /// 当前的计划价格
        /// </summary>
        [SugarColumn(ColumnName = "Lplpr", ColumnDescription = "当前的计划价格 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Lplpr { get; set; }

        /// <summary>
        /// 以销售价格计的总估价库存价值
        /// </summary>
        [SugarColumn(ColumnName = "Vksal", ColumnDescription = "以销售价格计的总估价库存价值 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vksal { get; set; }

        /// <summary>
        /// 物料相关的源
        /// </summary>
        [SugarColumn(ColumnName = "Hkmat", ColumnDescription = "物料相关的源 ", Length = 1)]
        public string Hkmat { get; set; }

        /// <summary>
        /// 实际盘点冻结标识
        /// </summary>
        [SugarColumn(ColumnName = "Sperw", ColumnDescription = "实际盘点冻结标识 ", Length = 1)]
        public string Sperw { get; set; }

        /// <summary>
        /// 单一价值物料的盘点库存标识
        /// </summary>
        [SugarColumn(ColumnName = "Kziwl", ColumnDescription = "单一价值物料的盘点库存标识 ", Length = 3)]
        public string Kziwl { get; set; }

        /// <summary>
        /// 非限制使用的库存中最新实际盘点的日期
        /// </summary>
        public DateTime? Wlinl { get; set; }

        /// <summary>
        /// 周期盘点的盘点标识
        /// </summary>
        [SugarColumn(ColumnName = "Abciw", ColumnDescription = "周期盘点的盘点标识 ", Length = 1)]
        public string Abciw { get; set; }

        /// <summary>
        /// 评价毛利
        /// </summary>
        [SugarColumn(ColumnName = "Bwspa", ColumnDescription = "评价毛利 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Bwspa { get; set; }

        /// <summary>
        /// 当前计划价格的固定金额
        /// </summary>
        [SugarColumn(ColumnName = "Lplpx", ColumnDescription = "当前计划价格的固定金额 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Lplpx { get; set; }

        /// <summary>
        /// 上年计划价格的固定比例
        /// </summary>
        [SugarColumn(ColumnName = "Vplpx", ColumnDescription = "上年计划价格的固定比例 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Vplpx { get; set; }

        /// <summary>
        /// 未来计划价格的固定比例
        /// </summary>
        [SugarColumn(ColumnName = "Fplpx", ColumnDescription = "未来计划价格的固定比例 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Fplpx { get; set; }

        /// <summary>
        /// 当前计划价格, 销售订单/项目存货的值决策
        /// </summary>
        [SugarColumn(ColumnName = "Lbwst", ColumnDescription = "当前计划价格, 销售订单/项目存货的值决策 ", Length = 1)]
        public string Lbwst { get; set; }

        /// <summary>
        /// 上年计划价格，限制使用库存的评估策略
        /// </summary>
        [SugarColumn(ColumnName = "Vbwst", ColumnDescription = "上年计划价格，限制使用库存的评估策略 ", Length = 1)]
        public string Vbwst { get; set; }

        /// <summary>
        /// 未来计划价格，限制使用库存的评估决策
        /// </summary>
        [SugarColumn(ColumnName = "Fbwst", ColumnDescription = "未来计划价格，限制使用库存的评估决策 ", Length = 1)]
        public string Fbwst { get; set; }

        /// <summary>
        /// 关于销售订单库存的评估类别
        /// </summary>
        [SugarColumn(ColumnName = "Eklas", ColumnDescription = "关于销售订单库存的评估类别 ", Length = 4)]
        public string Eklas { get; set; }

        /// <summary>
        /// 项目库存的评估分类
        /// </summary>
        [SugarColumn(ColumnName = "Qklas", ColumnDescription = "项目库存的评估分类 ", Length = 4)]
        public string Qklas { get; set; }

        /// <summary>
        /// 物料用途
        /// </summary>
        [SugarColumn(ColumnName = "Mtuse", ColumnDescription = "物料用途 ", Length = 1)]
        public string Mtuse { get; set; }

        /// <summary>
        /// 物料来源
        /// </summary>
        [SugarColumn(ColumnName = "Mtorg", ColumnDescription = "物料来源 ", Length = 1)]
        public string Mtorg { get; set; }

        /// <summary>
        /// 自制产品
        /// </summary>
        [SugarColumn(ColumnName = "Ownpr", ColumnDescription = "自制产品 ", Length = 1)]
        public string Ownpr { get; set; }

        /// <summary>
        /// 基于批次特定计量单位的评估
        /// </summary>
        [SugarColumn(ColumnName = "Xbewm", ColumnDescription = "基于批次特定计量单位的评估 ", Length = 1)]
        public string Xbewm { get; set; }

        /// <summary>
        /// 基于税/商法估价价格的价格单位
        /// </summary>
        [SugarColumn(ColumnName = "Bwpei", ColumnDescription = "基于税/商法估价价格的价格单位 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Bwpei { get; set; }

        /// <summary>
        /// MBEW 最后期间之前，期间的 MBEWH 已经存在。
        /// </summary>
        [SugarColumn(ColumnName = "Mbrue", ColumnDescription = "MBEW 最后期间之前，期间的 MBEWH 已经存在。 ", Length = 1)]
        public string Mbrue { get; set; }

        /// <summary>
        /// 供应商特殊库存的估价类
        /// </summary>
        [SugarColumn(ColumnName = "Oklas", ColumnDescription = "供应商特殊库存的估价类 ", Length = 4)]
        public string Oklas { get; set; }

        /// <summary>
        /// 物料评估类型段的预付库存标记
        /// </summary>
        [SugarColumn(ColumnName = "Oippinv", ColumnDescription = "物料评估类型段的预付库存标记 ", Length = 1)]
        public string Oippinv { get; set; }
    }
}