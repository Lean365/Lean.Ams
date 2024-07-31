namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 物料评估
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:50:11
    /// </summary>
    public class MmMbewQueryDto : PagerInfo
    {
        public string Matnr { get; set; }
        public string Bwkey { get; set; }
        public string Bklas { get; set; }
        public int? Lfgja { get; set; }
        public int? Lfmon { get; set; }
    }

    /// <summary>
    /// 物料评估
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:50:11
    /// </summary>
    public class MmMbewDto
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

        [Required(ErrorMessage = "评估范围不能为空")]
        [ExcelColumn(Name = "评估范围")]
        [ExcelColumnName("评估范围")]
        public string Bwkey { get; set; }

        [ExcelColumn(Name = "评估类型")]
        [ExcelColumnName("评估类型")]
        public string Bwtar { get; set; }

        [ExcelColumn(Name = "一种评估类型的所有物料数据的删除标志")]
        [ExcelColumnName("一种评估类型的所有物料数据的删除标志")]
        public string Lvorm { get; set; }

        [ExcelColumn(Name = "总计已估计库存")]
        [ExcelColumnName("总计已估计库存")]
        public decimal Lbkum { get; set; }

        [ExcelColumn(Name = "估价的总库存价值")]
        [ExcelColumnName("估价的总库存价值")]
        public decimal Salk3 { get; set; }

        [ExcelColumn(Name = "价格控制指示符")]
        [ExcelColumnName("价格控制指示符")]
        public string Vprsv { get; set; }

        [ExcelColumn(Name = "移动平均价格/周期单价")]
        [ExcelColumnName("移动平均价格/周期单价")]
        public decimal Verpr { get; set; }

        [ExcelColumn(Name = "标准价格")]
        [ExcelColumnName("标准价格")]
        public decimal Stprs { get; set; }

        [ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]
        public decimal Peinh { get; set; }

        [Required(ErrorMessage = "评估类不能为空")]
        [ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]
        public string Bklas { get; set; }

        [ExcelColumn(Name = "基于平均移动价的值（仅价格控制 S）")]
        [ExcelColumnName("基于平均移动价的值（仅价格控制 S）")]
        public decimal Salkv { get; set; }

        [ExcelColumn(Name = "前期的总评估库存")]
        [ExcelColumnName("前期的总评估库存")]
        public decimal Vmkum { get; set; }

        [ExcelColumn(Name = "上期估过价的总库存价值")]
        [ExcelColumnName("上期估过价的总库存价值")]
        public decimal Vmsal { get; set; }

        [ExcelColumn(Name = "前一期间价格控制标识")]
        [ExcelColumnName("前一期间价格控制标识")]
        public string Vmvpr { get; set; }

        [ExcelColumn(Name = "前一期间的移动平均价格/期间单位价格")]
        [ExcelColumnName("前一期间的移动平均价格/期间单位价格")]
        public decimal Vmver { get; set; }

        [ExcelColumn(Name = "前期的标准价格")]
        [ExcelColumnName("前期的标准价格")]
        public decimal Vmstp { get; set; }

        [ExcelColumn(Name = "前期的价格单位")]
        [ExcelColumnName("前期的价格单位")]
        public decimal Vmpei { get; set; }

        [ExcelColumn(Name = "上期的评价分类")]
        [ExcelColumnName("上期的评价分类")]
        public string Vmbkl { get; set; }

        [ExcelColumn(Name = "基于平均移动价的值(上期)")]
        [ExcelColumnName("基于平均移动价的值(上期)")]
        public decimal Vmsav { get; set; }

        [ExcelColumn(Name = "前年的总评估库存")]
        [ExcelColumnName("前年的总评估库存")]
        public decimal Vjkum { get; set; }

        [ExcelColumn(Name = "上年估价的总库存价值")]
        [ExcelColumnName("上年估价的总库存价值")]
        public decimal Vjsal { get; set; }

        [ExcelColumn(Name = "前一年的价格控制标识")]
        [ExcelColumnName("前一年的价格控制标识")]
        public string Vjvpr { get; set; }

        [ExcelColumn(Name = "前一年移动平均价格/期间单价价格")]
        [ExcelColumnName("前一年移动平均价格/期间单价价格")]
        public decimal Vjver { get; set; }

        [ExcelColumn(Name = "上年的标准价格")]
        [ExcelColumnName("上年的标准价格")]
        public decimal Vjstp { get; set; }

        [ExcelColumn(Name = "去年的价格单位")]
        [ExcelColumnName("去年的价格单位")]
        public decimal Vjpei { get; set; }

        [ExcelColumn(Name = "上年的评价分类")]
        [ExcelColumnName("上年的评价分类")]
        public string Vjbkl { get; set; }

        [ExcelColumn(Name = "基于平均移动价的值(上年)")]
        [ExcelColumnName("基于平均移动价的值(上年)")]
        public decimal Vjsav { get; set; }

        [ExcelColumn(Name = "当前期间的会计年度")]
        [ExcelColumnName("当前期间的会计年度")]
        public int? Lfgja { get; set; }

        [ExcelColumn(Name = "当前期间 (记帐期间)")]
        [ExcelColumnName("当前期间 (记帐期间)")]
        public int? Lfmon { get; set; }

        [ExcelColumn(Name = "评估类别")]
        [ExcelColumnName("评估类别")]
        public string Bwtty { get; set; }

        [ExcelColumn(Name = "上期价格")]
        [ExcelColumnName("上期价格")]
        public decimal Stprv { get; set; }

        [ExcelColumn(Name = "最新价格更改的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("最新价格更改的日期")]
        public DateTime? Laepr { get; set; }

        [ExcelColumn(Name = "未来价格")]
        [ExcelColumnName("未来价格")]
        public decimal Zkprs { get; set; }

        [ExcelColumn(Name = "价格开始有效的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("价格开始有效的日期")]
        public DateTime? Zkdat { get; set; }

        [ExcelColumn(Name = "简短格式的 UTC 时戳 (YYYYMMDDhhmmss)")]
        [ExcelColumnName("简短格式的 UTC 时戳 (YYYYMMDDhhmmss)")]
        public decimal Timestamp { get; set; }

        [ExcelColumn(Name = "基于税法的估价价格 - 级别1")]
        [ExcelColumnName("基于税法的估价价格 - 级别1")]
        public decimal Bwprs { get; set; }

        [ExcelColumn(Name = "基于商法的估价价格 - 级别 1")]
        [ExcelColumnName("基于商法的估价价格 - 级别 1")]
        public decimal Bwprh { get; set; }

        [ExcelColumn(Name = "基于税法的估价价格(BTCI) - 级别3")]
        [ExcelColumnName("基于税法的估价价格(BTCI) - 级别3")]
        public decimal Vjbws { get; set; }

        [ExcelColumn(Name = "基于商业法律的估价价格 - 级别3")]
        [ExcelColumnName("基于商业法律的估价价格 - 级别3")]
        public decimal Vjbwh { get; set; }

        [ExcelColumn(Name = "前年估价的总库存价值")]
        [ExcelColumnName("前年估价的总库存价值")]
        public decimal Vvjsl { get; set; }

        [ExcelColumn(Name = "前年的总评估库存")]
        [ExcelColumnName("前年的总评估库存")]
        public decimal Vvjlb { get; set; }

        [ExcelColumn(Name = "前期的总评估库存")]
        [ExcelColumnName("前期的总评估库存")]
        public decimal Vvmlb { get; set; }

        [ExcelColumn(Name = "前期估价的总库存价值")]
        [ExcelColumnName("前期估价的总库存价值")]
        public decimal Vvsal { get; set; }

        [ExcelColumn(Name = "未来计划价格")]
        [ExcelColumnName("未来计划价格")]
        public decimal Zplpr { get; set; }

        [ExcelColumn(Name = "未来计划价格1")]
        [ExcelColumnName("未来计划价格1")]
        public decimal Zplp1 { get; set; }

        [ExcelColumn(Name = "未来计划价格 2")]
        [ExcelColumnName("未来计划价格 2")]
        public decimal Zplp2 { get; set; }

        [ExcelColumn(Name = "未来计划价格 3")]
        [ExcelColumnName("未来计划价格 3")]
        public decimal Zplp3 { get; set; }

        [ExcelColumn(Name = "计划价格 1 开始有效的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("计划价格 1 开始有效的日期")]
        public DateTime? Zpld1 { get; set; }

        [ExcelColumn(Name = "计划价格 2 开始有效的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("计划价格 2 开始有效的日期")]
        public DateTime? Zpld2 { get; set; }

        [ExcelColumn(Name = "计划价格 3 开始有效的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("计划价格 3 开始有效的日期")]
        public DateTime? Zpld3 { get; set; }

        [ExcelColumn(Name = "未来标准成本估计的期间(未激活)", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("未来标准成本估计的期间(未激活)")]
        public DateTime? Pperz { get; set; }

        [ExcelColumn(Name = "当前标准成本估计的期间(未激活)", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("当前标准成本估计的期间(未激活)")]
        public DateTime? Pperl { get; set; }

        [ExcelColumn(Name = "以前标准成本估计的期间(未激活)", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("以前标准成本估计的期间(未激活)")]
        public DateTime? Pperv { get; set; }

        [ExcelColumn(Name = "标识: 未来期间的标准成本估算")]
        [ExcelColumnName("标识: 未来期间的标准成本估算")]
        public string Kalkz { get; set; }

        [ExcelColumn(Name = "当前期间的标准成本估算")]
        [ExcelColumnName("当前期间的标准成本估算")]
        public string Kalkl { get; set; }

        [ExcelColumn(Name = "标识: 上一期间的标准成本估计")]
        [ExcelColumnName("标识: 上一期间的标准成本估计")]
        public string Kalkv { get; set; }

        [ExcelColumn(Name = "一般费用代码(未激活)")]
        [ExcelColumnName("一般费用代码(未激活)")]
        public string Kalsc { get; set; }

        [ExcelColumn(Name = "LIFO/FIFO 相关")]
        [ExcelColumnName("LIFO/FIFO 相关")]
        public string Xlifo { get; set; }

        [ExcelColumn(Name = "用于LIFO评估的储备号")]
        [ExcelColumnName("用于LIFO评估的储备号")]
        public string Mypol { get; set; }

        [ExcelColumn(Name = "基于商业法律的估价价格：级别 2")]
        [ExcelColumnName("基于商业法律的估价价格：级别 2")]
        public decimal Bwph1 { get; set; }

        [ExcelColumn(Name = "基于税法的估价价格： 级别2")]
        [ExcelColumnName("基于税法的估价价格： 级别2")]
        public decimal Bwps1 { get; set; }

        [ExcelColumn(Name = "最低价值: 贬值标志")]
        [ExcelColumnName("最低价值: 贬值标志")]
        public int? Abwkz { get; set; }

        [ExcelColumn(Name = "维护状态")]
        [ExcelColumnName("维护状态")]
        public string Pstat { get; set; }

        [ExcelColumn(Name = "成本估算号 - 产品成本核算")]
        [ExcelColumnName("成本估算号 - 产品成本核算")]
        public int? Kaln1 { get; set; }

        [ExcelColumn(Name = "没有数量结构的成本估算的成本估算编号")]
        [ExcelColumnName("没有数量结构的成本估算的成本估算编号")]
        public int? Kalnr { get; set; }

        [ExcelColumn(Name = "未来的标准成本估算的估价变式")]
        [ExcelColumnName("未来的标准成本估算的估价变式")]
        public string Bwva1 { get; set; }

        [ExcelColumn(Name = "当前的标准成本估算的估价变式")]
        [ExcelColumnName("当前的标准成本估算的估价变式")]
        public string Bwva2 { get; set; }

        [ExcelColumn(Name = "过去的标准成本估算的估价变式")]
        [ExcelColumnName("过去的标准成本估算的估价变式")]
        public string Bwva3 { get; set; }

        [ExcelColumn(Name = "未来的标准成本估算的成本核算方案")]
        [ExcelColumnName("未来的标准成本估算的成本核算方案")]
        public int? Vers1 { get; set; }

        [ExcelColumn(Name = "当前的标准成本估算的成本核算方案")]
        [ExcelColumnName("当前的标准成本估算的成本核算方案")]
        public int? Vers2 { get; set; }

        [ExcelColumn(Name = "先前的标准成本估算的成本核算方案")]
        [ExcelColumnName("先前的标准成本估算的成本核算方案")]
        public int? Vers3 { get; set; }

        [ExcelColumn(Name = "作为成本要素子组的原始组")]
        [ExcelColumnName("作为成本要素子组的原始组")]
        public string Hrkft { get; set; }

        [ExcelColumn(Name = "成本核算间接费用组")]
        [ExcelColumnName("成本核算间接费用组")]
        public string Kosgr { get; set; }

        [ExcelColumn(Name = "未来成本估算期间")]
        [ExcelColumnName("未来成本估算期间")]
        public int? Pprdz { get; set; }

        [ExcelColumn(Name = "当前的标准成本估算期间")]
        [ExcelColumnName("当前的标准成本估算期间")]
        public int? Pprdl { get; set; }

        [ExcelColumn(Name = "先前的标准成本估算期间")]
        [ExcelColumnName("先前的标准成本估算期间")]
        public int? Pprdv { get; set; }

        [ExcelColumn(Name = "未来标准成本估算的会计年度")]
        [ExcelColumnName("未来标准成本估算的会计年度")]
        public int? Pdatz { get; set; }

        [ExcelColumn(Name = "当前标准成本估算的会计年度")]
        [ExcelColumnName("当前标准成本估算的会计年度")]
        public int? Pdatl { get; set; }

        [ExcelColumn(Name = "上一标准成本估算的会计年度")]
        [ExcelColumnName("上一标准成本估算的会计年度")]
        public int? Pdatv { get; set; }

        [ExcelColumn(Name = "物料根据数量结构进行成本核算")]
        [ExcelColumnName("物料根据数量结构进行成本核算")]
        public string Ekalr { get; set; }

        [ExcelColumn(Name = "上期标准价格")]
        [ExcelColumnName("上期标准价格")]
        public decimal Vplpr { get; set; }

        [ExcelColumn(Name = "物料帐簿在物料层被激活")]
        [ExcelColumnName("物料帐簿在物料层被激活")]
        public string Mlmaa { get; set; }

        [ExcelColumn(Name = "物料价格确定: 控制")]
        [ExcelColumnName("物料价格确定: 控制")]
        public string Mlast { get; set; }

        [ExcelColumn(Name = "当前的计划价格")]
        [ExcelColumnName("当前的计划价格")]
        public decimal Lplpr { get; set; }

        [ExcelColumn(Name = "以销售价格计的总估价库存价值")]
        [ExcelColumnName("以销售价格计的总估价库存价值")]
        public decimal Vksal { get; set; }

        [ExcelColumn(Name = "物料相关的源")]
        [ExcelColumnName("物料相关的源")]
        public string Hkmat { get; set; }

        [ExcelColumn(Name = "实际盘点冻结标识")]
        [ExcelColumnName("实际盘点冻结标识")]
        public string Sperw { get; set; }

        [ExcelColumn(Name = "单一价值物料的盘点库存标识")]
        [ExcelColumnName("单一价值物料的盘点库存标识")]
        public string Kziwl { get; set; }

        [ExcelColumn(Name = "非限制使用的库存中最新实际盘点的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("非限制使用的库存中最新实际盘点的日期")]
        public DateTime? Wlinl { get; set; }

        [ExcelColumn(Name = "周期盘点的盘点标识")]
        [ExcelColumnName("周期盘点的盘点标识")]
        public string Abciw { get; set; }

        [ExcelColumn(Name = "评价毛利")]
        [ExcelColumnName("评价毛利")]
        public decimal Bwspa { get; set; }

        [ExcelColumn(Name = "当前计划价格的固定金额")]
        [ExcelColumnName("当前计划价格的固定金额")]
        public decimal Lplpx { get; set; }

        [ExcelColumn(Name = "上年计划价格的固定比例")]
        [ExcelColumnName("上年计划价格的固定比例")]
        public decimal Vplpx { get; set; }

        [ExcelColumn(Name = "未来计划价格的固定比例")]
        [ExcelColumnName("未来计划价格的固定比例")]
        public decimal Fplpx { get; set; }

        [ExcelColumn(Name = "当前计划价格, 销售订单/项目存货的值决策")]
        [ExcelColumnName("当前计划价格, 销售订单/项目存货的值决策")]
        public string Lbwst { get; set; }

        [ExcelColumn(Name = "上年计划价格，限制使用库存的评估策略")]
        [ExcelColumnName("上年计划价格，限制使用库存的评估策略")]
        public string Vbwst { get; set; }

        [ExcelColumn(Name = "未来计划价格，限制使用库存的评估决策")]
        [ExcelColumnName("未来计划价格，限制使用库存的评估决策")]
        public string Fbwst { get; set; }

        [ExcelColumn(Name = "关于销售订单库存的评估类别")]
        [ExcelColumnName("关于销售订单库存的评估类别")]
        public string Eklas { get; set; }

        [ExcelColumn(Name = "项目库存的评估分类")]
        [ExcelColumnName("项目库存的评估分类")]
        public string Qklas { get; set; }

        [ExcelColumn(Name = "物料用途")]
        [ExcelColumnName("物料用途")]
        public string Mtuse { get; set; }

        [ExcelColumn(Name = "物料来源")]
        [ExcelColumnName("物料来源")]
        public string Mtorg { get; set; }

        [ExcelColumn(Name = "自制产品")]
        [ExcelColumnName("自制产品")]
        public string Ownpr { get; set; }

        [ExcelColumn(Name = "基于批次特定计量单位的评估")]
        [ExcelColumnName("基于批次特定计量单位的评估")]
        public string Xbewm { get; set; }

        [ExcelColumn(Name = "基于税/商法估价价格的价格单位")]
        [ExcelColumnName("基于税/商法估价价格的价格单位")]
        public decimal Bwpei { get; set; }

        [ExcelColumn(Name = "MBEW 最后期间之前，期间的 MBEWH 已经存在。")]
        [ExcelColumnName("MBEW 最后期间之前，期间的 MBEWH 已经存在。")]
        public string Mbrue { get; set; }

        [ExcelColumn(Name = "供应商特殊库存的估价类")]
        [ExcelColumnName("供应商特殊库存的估价类")]
        public string Oklas { get; set; }

        [ExcelColumn(Name = "物料评估类型段的预付库存标记")]
        [ExcelColumnName("物料评估类型段的预付库存标记")]
        public string Oippinv { get; set; }

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

        [ExcelColumn(Name = "评估范围")]
        public string BwkeyLabel { get; set; }

        [ExcelColumn(Name = "评估类")]
        public string BklasLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 物料评估
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 10:50:11
    /// </summary>
    public class MmMbewImportTpl
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

        [Required(ErrorMessage = "评估范围不能为空")]
        [ExcelColumn(Name = "评估范围")]
        [ExcelColumnName("评估范围")]
        public string Bwkey { get; set; }

        [ExcelColumn(Name = "评估类型")]
        [ExcelColumnName("评估类型")]
        public string Bwtar { get; set; }

        [ExcelColumn(Name = "一种评估类型的所有物料数据的删除标志")]
        [ExcelColumnName("一种评估类型的所有物料数据的删除标志")]
        public string Lvorm { get; set; }

        [ExcelColumn(Name = "总计已估计库存")]
        [ExcelColumnName("总计已估计库存")]
        public decimal Lbkum { get; set; }

        [ExcelColumn(Name = "估价的总库存价值")]
        [ExcelColumnName("估价的总库存价值")]
        public decimal Salk3 { get; set; }

        [ExcelColumn(Name = "价格控制指示符")]
        [ExcelColumnName("价格控制指示符")]
        public string Vprsv { get; set; }

        [ExcelColumn(Name = "移动平均价格/周期单价")]
        [ExcelColumnName("移动平均价格/周期单价")]
        public decimal Verpr { get; set; }

        [ExcelColumn(Name = "标准价格")]
        [ExcelColumnName("标准价格")]
        public decimal Stprs { get; set; }

        [ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]
        public decimal Peinh { get; set; }

        [Required(ErrorMessage = "评估类不能为空")]
        [ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]
        public string Bklas { get; set; }

        [ExcelColumn(Name = "基于平均移动价的值（仅价格控制 S）")]
        [ExcelColumnName("基于平均移动价的值（仅价格控制 S）")]
        public decimal Salkv { get; set; }

        [ExcelColumn(Name = "前期的总评估库存")]
        [ExcelColumnName("前期的总评估库存")]
        public decimal Vmkum { get; set; }

        [ExcelColumn(Name = "上期估过价的总库存价值")]
        [ExcelColumnName("上期估过价的总库存价值")]
        public decimal Vmsal { get; set; }

        [ExcelColumn(Name = "前一期间价格控制标识")]
        [ExcelColumnName("前一期间价格控制标识")]
        public string Vmvpr { get; set; }

        [ExcelColumn(Name = "前一期间的移动平均价格/期间单位价格")]
        [ExcelColumnName("前一期间的移动平均价格/期间单位价格")]
        public decimal Vmver { get; set; }

        [ExcelColumn(Name = "前期的标准价格")]
        [ExcelColumnName("前期的标准价格")]
        public decimal Vmstp { get; set; }

        [ExcelColumn(Name = "前期的价格单位")]
        [ExcelColumnName("前期的价格单位")]
        public decimal Vmpei { get; set; }

        [ExcelColumn(Name = "上期的评价分类")]
        [ExcelColumnName("上期的评价分类")]
        public string Vmbkl { get; set; }

        [ExcelColumn(Name = "基于平均移动价的值(上期)")]
        [ExcelColumnName("基于平均移动价的值(上期)")]
        public decimal Vmsav { get; set; }

        [ExcelColumn(Name = "前年的总评估库存")]
        [ExcelColumnName("前年的总评估库存")]
        public decimal Vjkum { get; set; }

        [ExcelColumn(Name = "上年估价的总库存价值")]
        [ExcelColumnName("上年估价的总库存价值")]
        public decimal Vjsal { get; set; }

        [ExcelColumn(Name = "前一年的价格控制标识")]
        [ExcelColumnName("前一年的价格控制标识")]
        public string Vjvpr { get; set; }

        [ExcelColumn(Name = "前一年移动平均价格/期间单价价格")]
        [ExcelColumnName("前一年移动平均价格/期间单价价格")]
        public decimal Vjver { get; set; }

        [ExcelColumn(Name = "上年的标准价格")]
        [ExcelColumnName("上年的标准价格")]
        public decimal Vjstp { get; set; }

        [ExcelColumn(Name = "去年的价格单位")]
        [ExcelColumnName("去年的价格单位")]
        public decimal Vjpei { get; set; }

        [ExcelColumn(Name = "上年的评价分类")]
        [ExcelColumnName("上年的评价分类")]
        public string Vjbkl { get; set; }

        [ExcelColumn(Name = "基于平均移动价的值(上年)")]
        [ExcelColumnName("基于平均移动价的值(上年)")]
        public decimal Vjsav { get; set; }

        [ExcelColumn(Name = "当前期间的会计年度")]
        [ExcelColumnName("当前期间的会计年度")]
        public int? Lfgja { get; set; }

        [ExcelColumn(Name = "当前期间 (记帐期间)")]
        [ExcelColumnName("当前期间 (记帐期间)")]
        public int? Lfmon { get; set; }

        [ExcelColumn(Name = "评估类别")]
        [ExcelColumnName("评估类别")]
        public string Bwtty { get; set; }

        [ExcelColumn(Name = "上期价格")]
        [ExcelColumnName("上期价格")]
        public decimal Stprv { get; set; }

        [ExcelColumn(Name = "最新价格更改的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("最新价格更改的日期")]
        public DateTime? Laepr { get; set; }

        [ExcelColumn(Name = "未来价格")]
        [ExcelColumnName("未来价格")]
        public decimal Zkprs { get; set; }

        [ExcelColumn(Name = "价格开始有效的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("价格开始有效的日期")]
        public DateTime? Zkdat { get; set; }

        [ExcelColumn(Name = "简短格式的 UTC 时戳 (YYYYMMDDhhmmss)")]
        [ExcelColumnName("简短格式的 UTC 时戳 (YYYYMMDDhhmmss)")]
        public decimal Timestamp { get; set; }

        [ExcelColumn(Name = "基于税法的估价价格 - 级别1")]
        [ExcelColumnName("基于税法的估价价格 - 级别1")]
        public decimal Bwprs { get; set; }

        [ExcelColumn(Name = "基于商法的估价价格 - 级别 1")]
        [ExcelColumnName("基于商法的估价价格 - 级别 1")]
        public decimal Bwprh { get; set; }

        [ExcelColumn(Name = "基于税法的估价价格(BTCI) - 级别3")]
        [ExcelColumnName("基于税法的估价价格(BTCI) - 级别3")]
        public decimal Vjbws { get; set; }

        [ExcelColumn(Name = "基于商业法律的估价价格 - 级别3")]
        [ExcelColumnName("基于商业法律的估价价格 - 级别3")]
        public decimal Vjbwh { get; set; }

        [ExcelColumn(Name = "前年估价的总库存价值")]
        [ExcelColumnName("前年估价的总库存价值")]
        public decimal Vvjsl { get; set; }

        [ExcelColumn(Name = "前年的总评估库存")]
        [ExcelColumnName("前年的总评估库存")]
        public decimal Vvjlb { get; set; }

        [ExcelColumn(Name = "前期的总评估库存")]
        [ExcelColumnName("前期的总评估库存")]
        public decimal Vvmlb { get; set; }

        [ExcelColumn(Name = "前期估价的总库存价值")]
        [ExcelColumnName("前期估价的总库存价值")]
        public decimal Vvsal { get; set; }

        [ExcelColumn(Name = "未来计划价格")]
        [ExcelColumnName("未来计划价格")]
        public decimal Zplpr { get; set; }

        [ExcelColumn(Name = "未来计划价格1")]
        [ExcelColumnName("未来计划价格1")]
        public decimal Zplp1 { get; set; }

        [ExcelColumn(Name = "未来计划价格 2")]
        [ExcelColumnName("未来计划价格 2")]
        public decimal Zplp2 { get; set; }

        [ExcelColumn(Name = "未来计划价格 3")]
        [ExcelColumnName("未来计划价格 3")]
        public decimal Zplp3 { get; set; }

        [ExcelColumn(Name = "计划价格 1 开始有效的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("计划价格 1 开始有效的日期")]
        public DateTime? Zpld1 { get; set; }

        [ExcelColumn(Name = "计划价格 2 开始有效的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("计划价格 2 开始有效的日期")]
        public DateTime? Zpld2 { get; set; }

        [ExcelColumn(Name = "计划价格 3 开始有效的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("计划价格 3 开始有效的日期")]
        public DateTime? Zpld3 { get; set; }

        [ExcelColumn(Name = "未来标准成本估计的期间(未激活)", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("未来标准成本估计的期间(未激活)")]
        public DateTime? Pperz { get; set; }

        [ExcelColumn(Name = "当前标准成本估计的期间(未激活)", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("当前标准成本估计的期间(未激活)")]
        public DateTime? Pperl { get; set; }

        [ExcelColumn(Name = "以前标准成本估计的期间(未激活)", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("以前标准成本估计的期间(未激活)")]
        public DateTime? Pperv { get; set; }

        [ExcelColumn(Name = "标识: 未来期间的标准成本估算")]
        [ExcelColumnName("标识: 未来期间的标准成本估算")]
        public string Kalkz { get; set; }

        [ExcelColumn(Name = "当前期间的标准成本估算")]
        [ExcelColumnName("当前期间的标准成本估算")]
        public string Kalkl { get; set; }

        [ExcelColumn(Name = "标识: 上一期间的标准成本估计")]
        [ExcelColumnName("标识: 上一期间的标准成本估计")]
        public string Kalkv { get; set; }

        [ExcelColumn(Name = "一般费用代码(未激活)")]
        [ExcelColumnName("一般费用代码(未激活)")]
        public string Kalsc { get; set; }

        [ExcelColumn(Name = "LIFO/FIFO 相关")]
        [ExcelColumnName("LIFO/FIFO 相关")]
        public string Xlifo { get; set; }

        [ExcelColumn(Name = "用于LIFO评估的储备号")]
        [ExcelColumnName("用于LIFO评估的储备号")]
        public string Mypol { get; set; }

        [ExcelColumn(Name = "基于商业法律的估价价格：级别 2")]
        [ExcelColumnName("基于商业法律的估价价格：级别 2")]
        public decimal Bwph1 { get; set; }

        [ExcelColumn(Name = "基于税法的估价价格： 级别2")]
        [ExcelColumnName("基于税法的估价价格： 级别2")]
        public decimal Bwps1 { get; set; }

        [ExcelColumn(Name = "最低价值: 贬值标志")]
        [ExcelColumnName("最低价值: 贬值标志")]
        public int? Abwkz { get; set; }

        [ExcelColumn(Name = "维护状态")]
        [ExcelColumnName("维护状态")]
        public string Pstat { get; set; }

        [ExcelColumn(Name = "成本估算号 - 产品成本核算")]
        [ExcelColumnName("成本估算号 - 产品成本核算")]
        public int? Kaln1 { get; set; }

        [ExcelColumn(Name = "没有数量结构的成本估算的成本估算编号")]
        [ExcelColumnName("没有数量结构的成本估算的成本估算编号")]
        public int? Kalnr { get; set; }

        [ExcelColumn(Name = "未来的标准成本估算的估价变式")]
        [ExcelColumnName("未来的标准成本估算的估价变式")]
        public string Bwva1 { get; set; }

        [ExcelColumn(Name = "当前的标准成本估算的估价变式")]
        [ExcelColumnName("当前的标准成本估算的估价变式")]
        public string Bwva2 { get; set; }

        [ExcelColumn(Name = "过去的标准成本估算的估价变式")]
        [ExcelColumnName("过去的标准成本估算的估价变式")]
        public string Bwva3 { get; set; }

        [ExcelColumn(Name = "未来的标准成本估算的成本核算方案")]
        [ExcelColumnName("未来的标准成本估算的成本核算方案")]
        public int? Vers1 { get; set; }

        [ExcelColumn(Name = "当前的标准成本估算的成本核算方案")]
        [ExcelColumnName("当前的标准成本估算的成本核算方案")]
        public int? Vers2 { get; set; }

        [ExcelColumn(Name = "先前的标准成本估算的成本核算方案")]
        [ExcelColumnName("先前的标准成本估算的成本核算方案")]
        public int? Vers3 { get; set; }

        [ExcelColumn(Name = "作为成本要素子组的原始组")]
        [ExcelColumnName("作为成本要素子组的原始组")]
        public string Hrkft { get; set; }

        [ExcelColumn(Name = "成本核算间接费用组")]
        [ExcelColumnName("成本核算间接费用组")]
        public string Kosgr { get; set; }

        [ExcelColumn(Name = "未来成本估算期间")]
        [ExcelColumnName("未来成本估算期间")]
        public int? Pprdz { get; set; }

        [ExcelColumn(Name = "当前的标准成本估算期间")]
        [ExcelColumnName("当前的标准成本估算期间")]
        public int? Pprdl { get; set; }

        [ExcelColumn(Name = "先前的标准成本估算期间")]
        [ExcelColumnName("先前的标准成本估算期间")]
        public int? Pprdv { get; set; }

        [ExcelColumn(Name = "未来标准成本估算的会计年度")]
        [ExcelColumnName("未来标准成本估算的会计年度")]
        public int? Pdatz { get; set; }

        [ExcelColumn(Name = "当前标准成本估算的会计年度")]
        [ExcelColumnName("当前标准成本估算的会计年度")]
        public int? Pdatl { get; set; }

        [ExcelColumn(Name = "上一标准成本估算的会计年度")]
        [ExcelColumnName("上一标准成本估算的会计年度")]
        public int? Pdatv { get; set; }

        [ExcelColumn(Name = "物料根据数量结构进行成本核算")]
        [ExcelColumnName("物料根据数量结构进行成本核算")]
        public string Ekalr { get; set; }

        [ExcelColumn(Name = "上期标准价格")]
        [ExcelColumnName("上期标准价格")]
        public decimal Vplpr { get; set; }

        [ExcelColumn(Name = "物料帐簿在物料层被激活")]
        [ExcelColumnName("物料帐簿在物料层被激活")]
        public string Mlmaa { get; set; }

        [ExcelColumn(Name = "物料价格确定: 控制")]
        [ExcelColumnName("物料价格确定: 控制")]
        public string Mlast { get; set; }

        [ExcelColumn(Name = "当前的计划价格")]
        [ExcelColumnName("当前的计划价格")]
        public decimal Lplpr { get; set; }

        [ExcelColumn(Name = "以销售价格计的总估价库存价值")]
        [ExcelColumnName("以销售价格计的总估价库存价值")]
        public decimal Vksal { get; set; }

        [ExcelColumn(Name = "物料相关的源")]
        [ExcelColumnName("物料相关的源")]
        public string Hkmat { get; set; }

        [ExcelColumn(Name = "实际盘点冻结标识")]
        [ExcelColumnName("实际盘点冻结标识")]
        public string Sperw { get; set; }

        [ExcelColumn(Name = "单一价值物料的盘点库存标识")]
        [ExcelColumnName("单一价值物料的盘点库存标识")]
        public string Kziwl { get; set; }

        [ExcelColumn(Name = "非限制使用的库存中最新实际盘点的日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("非限制使用的库存中最新实际盘点的日期")]
        public DateTime? Wlinl { get; set; }

        [ExcelColumn(Name = "周期盘点的盘点标识")]
        [ExcelColumnName("周期盘点的盘点标识")]
        public string Abciw { get; set; }

        [ExcelColumn(Name = "评价毛利")]
        [ExcelColumnName("评价毛利")]
        public decimal Bwspa { get; set; }

        [ExcelColumn(Name = "当前计划价格的固定金额")]
        [ExcelColumnName("当前计划价格的固定金额")]
        public decimal Lplpx { get; set; }

        [ExcelColumn(Name = "上年计划价格的固定比例")]
        [ExcelColumnName("上年计划价格的固定比例")]
        public decimal Vplpx { get; set; }

        [ExcelColumn(Name = "未来计划价格的固定比例")]
        [ExcelColumnName("未来计划价格的固定比例")]
        public decimal Fplpx { get; set; }

        [ExcelColumn(Name = "当前计划价格, 销售订单/项目存货的值决策")]
        [ExcelColumnName("当前计划价格, 销售订单/项目存货的值决策")]
        public string Lbwst { get; set; }

        [ExcelColumn(Name = "上年计划价格，限制使用库存的评估策略")]
        [ExcelColumnName("上年计划价格，限制使用库存的评估策略")]
        public string Vbwst { get; set; }

        [ExcelColumn(Name = "未来计划价格，限制使用库存的评估决策")]
        [ExcelColumnName("未来计划价格，限制使用库存的评估决策")]
        public string Fbwst { get; set; }

        [ExcelColumn(Name = "关于销售订单库存的评估类别")]
        [ExcelColumnName("关于销售订单库存的评估类别")]
        public string Eklas { get; set; }

        [ExcelColumn(Name = "项目库存的评估分类")]
        [ExcelColumnName("项目库存的评估分类")]
        public string Qklas { get; set; }

        [ExcelColumn(Name = "物料用途")]
        [ExcelColumnName("物料用途")]
        public string Mtuse { get; set; }

        [ExcelColumn(Name = "物料来源")]
        [ExcelColumnName("物料来源")]
        public string Mtorg { get; set; }

        [ExcelColumn(Name = "自制产品")]
        [ExcelColumnName("自制产品")]
        public string Ownpr { get; set; }

        [ExcelColumn(Name = "基于批次特定计量单位的评估")]
        [ExcelColumnName("基于批次特定计量单位的评估")]
        public string Xbewm { get; set; }

        [ExcelColumn(Name = "基于税/商法估价价格的价格单位")]
        [ExcelColumnName("基于税/商法估价价格的价格单位")]
        public decimal Bwpei { get; set; }

        [ExcelColumn(Name = "MBEW 最后期间之前，期间的 MBEWH 已经存在。")]
        [ExcelColumnName("MBEW 最后期间之前，期间的 MBEWH 已经存在。")]
        public string Mbrue { get; set; }

        [ExcelColumn(Name = "供应商特殊库存的估价类")]
        [ExcelColumnName("供应商特殊库存的估价类")]
        public string Oklas { get; set; }

        [ExcelColumn(Name = "物料评估类型段的预付库存标记")]
        [ExcelColumnName("物料评估类型段的预付库存标记")]
        public string Oippinv { get; set; }

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
        [ExcelColumn(Name = "评估范围")]
        public string BwkeyLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "评估类")]
        public string BklasLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}