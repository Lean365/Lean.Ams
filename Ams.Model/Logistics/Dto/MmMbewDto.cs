
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 物料评估
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:30:25
    /// </summary>
    public class MmMbewQueryDto : PagerInfo 
    {
        /// <summary>
        /// 物料号 
        /// </summary>        
        public string Md003 { get; set; }
        /// <summary>
        /// 评估范围 
        /// </summary>        
        public string Md004 { get; set; }
        /// <summary>
        /// 评估类型 
        /// </summary>        
        public string Md005 { get; set; }
    }

    /// <summary>
    /// 物料评估
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:30:25
    /// </summary>
    public class MmMbewDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]

        public string Md002 { get; set; }

        [Required(ErrorMessage = "物料号不能为空")]
        //[ExcelColumn(Name = "物料号")]
        [ExcelColumnName("物料号")]

        public string Md003 { get; set; }

        [Required(ErrorMessage = "评估范围不能为空")]
        //[ExcelColumn(Name = "评估范围")]
        [ExcelColumnName("评估范围")]

        public string Md004 { get; set; }

        [Required(ErrorMessage = "评估类型不能为空")]
        //[ExcelColumn(Name = "评估类型")]
        [ExcelColumnName("评估类型")]

        public string Md005 { get; set; }

        //[ExcelColumn(Name = "删除标志")]
        [ExcelColumnName("删除标志")]

        public string Md006 { get; set; }

        [Required(ErrorMessage = "总库存不能为空")]
        //[ExcelColumn(Name = "总库存")]
        [ExcelColumnName("总库存")]

        public decimal Md007 { get; set; }

        [Required(ErrorMessage = "估价值不能为空")]
        //[ExcelColumn(Name = "估价值")]
        [ExcelColumnName("估价值")]

        public decimal Md008 { get; set; }

        //[ExcelColumn(Name = "价格控制")]
        [ExcelColumnName("价格控制")]

        public string Md009 { get; set; }

        [Required(ErrorMessage = "移动价格不能为空")]
        //[ExcelColumn(Name = "移动价格")]
        [ExcelColumnName("移动价格")]

        public decimal Md010 { get; set; }

        [Required(ErrorMessage = "标准价格不能为空")]
        //[ExcelColumn(Name = "标准价格")]
        [ExcelColumnName("标准价格")]

        public decimal Md011 { get; set; }

        [Required(ErrorMessage = "价格单位不能为空")]
        //[ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]

        public decimal Md012 { get; set; }

        //[ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]

        public string Md013 { get; set; }

        [Required(ErrorMessage = "价值/MA价格不能为空")]
        //[ExcelColumn(Name = "价值/MA价格")]
        [ExcelColumnName("价值/MA价格")]

        public decimal Md014 { get; set; }

        [Required(ErrorMessage = "前期总库存不能为空")]
        //[ExcelColumn(Name = "前期总库存")]
        [ExcelColumnName("前期总库存")]

        public decimal Md015 { get; set; }

        [Required(ErrorMessage = "前期总价值不能为空")]
        //[ExcelColumn(Name = "前期总价值")]
        [ExcelColumnName("前期总价值")]

        public decimal Md016 { get; set; }

        //[ExcelColumn(Name = "前期价格控制")]
        [ExcelColumnName("前期价格控制")]

        public string Md017 { get; set; }

        [Required(ErrorMessage = "前期移动平均价不能为空")]
        //[ExcelColumn(Name = "前期移动平均价")]
        [ExcelColumnName("前期移动平均价")]

        public decimal Md018 { get; set; }

        [Required(ErrorMessage = "前期标准价格不能为空")]
        //[ExcelColumn(Name = "前期标准价格")]
        [ExcelColumnName("前期标准价格")]

        public decimal Md019 { get; set; }

        [Required(ErrorMessage = "上期价格单位不能为空")]
        //[ExcelColumn(Name = "上期价格单位")]
        [ExcelColumnName("上期价格单位")]

        public decimal Md020 { get; set; }

        //[ExcelColumn(Name = "上期评价分类")]
        [ExcelColumnName("上期评价分类")]

        public string Md021 { get; set; }

        [Required(ErrorMessage = "上期价值不能为空")]
        //[ExcelColumn(Name = "上期价值")]
        [ExcelColumnName("上期价值")]

        public decimal Md022 { get; set; }

        [Required(ErrorMessage = "前年总库存不能为空")]
        //[ExcelColumn(Name = "前年总库存")]
        [ExcelColumnName("前年总库存")]

        public decimal Md023 { get; set; }

        [Required(ErrorMessage = "上年总价值不能为空")]
        //[ExcelColumn(Name = "上年总价值")]
        [ExcelColumnName("上年总价值")]

        public decimal Md024 { get; set; }

        //[ExcelColumn(Name = "前年价格控制")]
        [ExcelColumnName("前年价格控制")]

        public string Md025 { get; set; }

        [Required(ErrorMessage = "去年移动平均价不能为空")]
        //[ExcelColumn(Name = "去年移动平均价")]
        [ExcelColumnName("去年移动平均价")]

        public decimal Md026 { get; set; }

        [Required(ErrorMessage = "去年标准价格不能为空")]
        //[ExcelColumn(Name = "去年标准价格")]
        [ExcelColumnName("去年标准价格")]

        public decimal Md027 { get; set; }

        [Required(ErrorMessage = "上年价格单位不能为空")]
        //[ExcelColumn(Name = "上年价格单位")]
        [ExcelColumnName("上年价格单位")]

        public decimal Md028 { get; set; }

        //[ExcelColumn(Name = "上年评估类")]
        [ExcelColumnName("上年评估类")]

        public string Md029 { get; set; }

        [Required(ErrorMessage = "上年价值不能为空")]
        //[ExcelColumn(Name = "上年价值")]
        [ExcelColumnName("上年价值")]

        public decimal Md030 { get; set; }

        [Required(ErrorMessage = "当前会计年度不能为空")]
        //[ExcelColumn(Name = "当前会计年度")]
        [ExcelColumnName("当前会计年度")]

        public int Md031 { get; set; }

        [Required(ErrorMessage = "当前期间不能为空")]
        //[ExcelColumn(Name = "当前期间")]
        [ExcelColumnName("当前期间")]

        public int Md032 { get; set; }

        //[ExcelColumn(Name = "评估类别")]
        [ExcelColumnName("评估类别")]

        public string Md033 { get; set; }

        [Required(ErrorMessage = "上期价格不能为空")]
        //[ExcelColumn(Name = "上期价格")]
        [ExcelColumnName("上期价格")]

        public decimal Md034 { get; set; }

        //[ExcelColumn(Name = "最新价格更改", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("最新价格更改")]

        public DateTime? Md035 { get; set; }

        [Required(ErrorMessage = "未来价格不能为空")]
        //[ExcelColumn(Name = "未来价格")]
        [ExcelColumnName("未来价格")]

        public decimal Md036 { get; set; }

        //[ExcelColumn(Name = "有效起始日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效起始日期")]

        public DateTime? Md037 { get; set; }

        [Required(ErrorMessage = "时戳不能为空")]
        //[ExcelColumn(Name = "时戳")]
        [ExcelColumnName("时戳")]

        public decimal Md038 { get; set; }

        [Required(ErrorMessage = "税价1不能为空")]
        //[ExcelColumn(Name = "税价1")]
        [ExcelColumnName("税价1")]

        public decimal Md039 { get; set; }

        [Required(ErrorMessage = "商业价格1不能为空")]
        //[ExcelColumn(Name = "商业价格1")]
        [ExcelColumnName("商业价格1")]

        public decimal Md040 { get; set; }

        [Required(ErrorMessage = "税价3不能为空")]
        //[ExcelColumn(Name = "税价3")]
        [ExcelColumnName("税价3")]

        public decimal Md041 { get; set; }

        [Required(ErrorMessage = "商业价格3不能为空")]
        //[ExcelColumn(Name = "商业价格3")]
        [ExcelColumnName("商业价格3")]

        public decimal Md042 { get; set; }

        [Required(ErrorMessage = "计价不能为空")]
        //[ExcelColumn(Name = "计价")]
        [ExcelColumnName("计价")]

        public decimal Md043 { get; set; }

        [Required(ErrorMessage = "前年总库存不能为空")]
        //[ExcelColumn(Name = "前年总库存")]
        [ExcelColumnName("前年总库存")]

        public decimal Md044 { get; set; }

        [Required(ErrorMessage = "前期总价值不能为空")]
        //[ExcelColumn(Name = "前期总价值")]
        [ExcelColumnName("前期总价值")]

        public decimal Md045 { get; set; }

        [Required(ErrorMessage = "计价在不能为空")]
        //[ExcelColumn(Name = "计价在")]
        [ExcelColumnName("计价在")]

        public decimal Md046 { get; set; }

        [Required(ErrorMessage = "未来计划价格不能为空")]
        //[ExcelColumn(Name = "未来计划价格")]
        [ExcelColumnName("未来计划价格")]

        public decimal Md047 { get; set; }

        [Required(ErrorMessage = "未来计划价格1不能为空")]
        //[ExcelColumn(Name = "未来计划价格1")]
        [ExcelColumnName("未来计划价格1")]

        public decimal Md048 { get; set; }

        [Required(ErrorMessage = "未来计划价格 2不能为空")]
        //[ExcelColumn(Name = "未来计划价格 2")]
        [ExcelColumnName("未来计划价格 2")]

        public decimal Md049 { get; set; }

        [Required(ErrorMessage = "未来计划价格 3不能为空")]
        //[ExcelColumn(Name = "未来计划价格 3")]
        [ExcelColumnName("未来计划价格 3")]

        public decimal Md050 { get; set; }

        //[ExcelColumn(Name = "计划价格日期1", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("计划价格日期1")]

        public DateTime? Md051 { get; set; }

        //[ExcelColumn(Name = "计划价格日期2", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("计划价格日期2")]

        public DateTime? Md052 { get; set; }

        //[ExcelColumn(Name = "计划价格日期3", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("计划价格日期3")]

        public DateTime? Md053 { get; set; }

        //[ExcelColumn(Name = "未来成本估算", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("未来成本估算")]

        public DateTime? Md054 { get; set; }

        //[ExcelColumn(Name = "期间成本估算", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("期间成本估算")]

        public DateTime? Md055 { get; set; }

        //[ExcelColumn(Name = "上期成本估算", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("上期成本估算")]

        public DateTime? Md056 { get; set; }

        //[ExcelColumn(Name = "未来成本估算")]
        [ExcelColumnName("未来成本估算")]

        public string Md057 { get; set; }

        //[ExcelColumn(Name = "当前成本估算")]
        [ExcelColumnName("当前成本估算")]

        public string Md058 { get; set; }

        //[ExcelColumn(Name = "上期成本估算")]
        [ExcelColumnName("上期成本估算")]

        public string Md059 { get; set; }

        //[ExcelColumn(Name = "一般费用代码")]
        [ExcelColumnName("一般费用代码")]

        public string Md060 { get; set; }

        //[ExcelColumn(Name = "LIFO/FIFO 相关")]
        [ExcelColumnName("LIFO/FIFO 相关")]

        public string Md061 { get; set; }

        //[ExcelColumn(Name = "LIFO评估储备号")]
        [ExcelColumnName("LIFO评估储备号")]

        public string Md062 { get; set; }

        [Required(ErrorMessage = "商业价格2不能为空")]
        //[ExcelColumn(Name = "商业价格2")]
        [ExcelColumnName("商业价格2")]

        public decimal Md063 { get; set; }

        [Required(ErrorMessage = "税价2不能为空")]
        //[ExcelColumn(Name = "税价2")]
        [ExcelColumnName("税价2")]

        public decimal Md064 { get; set; }

        [Required(ErrorMessage = "贬值标志不能为空")]
        //[ExcelColumn(Name = "贬值标志")]
        [ExcelColumnName("贬值标志")]

        public int Md065 { get; set; }

        //[ExcelColumn(Name = "维护状态")]
        [ExcelColumnName("维护状态")]

        public string Md066 { get; set; }

        [Required(ErrorMessage = "产品成本核算不能为空")]
        //[ExcelColumn(Name = "产品成本核算")]
        [ExcelColumnName("产品成本核算")]

        public int Md067 { get; set; }

        [Required(ErrorMessage = "成本估算编号不能为空")]
        //[ExcelColumn(Name = "成本估算编号")]
        [ExcelColumnName("成本估算编号")]

        public int Md068 { get; set; }

        //[ExcelColumn(Name = "评估变式1")]
        [ExcelColumnName("评估变式1")]

        public string Md069 { get; set; }

        //[ExcelColumn(Name = "评估变式2")]
        [ExcelColumnName("评估变式2")]

        public string Md070 { get; set; }

        //[ExcelColumn(Name = "评估变式3")]
        [ExcelColumnName("评估变式3")]

        public string Md071 { get; set; }

        [Required(ErrorMessage = "成本核算版本1不能为空")]
        //[ExcelColumn(Name = "成本核算版本1")]
        [ExcelColumnName("成本核算版本1")]

        public int Md072 { get; set; }

        [Required(ErrorMessage = "成本核算版本2不能为空")]
        //[ExcelColumn(Name = "成本核算版本2")]
        [ExcelColumnName("成本核算版本2")]

        public int Md073 { get; set; }

        [Required(ErrorMessage = "成本核算版本3不能为空")]
        //[ExcelColumn(Name = "成本核算版本3")]
        [ExcelColumnName("成本核算版本3")]

        public int Md074 { get; set; }

        //[ExcelColumn(Name = "原始组")]
        [ExcelColumnName("原始组")]

        public string Md075 { get; set; }

        //[ExcelColumn(Name = "间接费分组")]
        [ExcelColumnName("间接费分组")]

        public string Md076 { get; set; }

        [Required(ErrorMessage = "计价期间不能为空")]
        //[ExcelColumn(Name = "计价期间")]
        [ExcelColumnName("计价期间")]

        public int Md077 { get; set; }

        [Required(ErrorMessage = "当前期间不能为空")]
        //[ExcelColumn(Name = "当前期间")]
        [ExcelColumnName("当前期间")]

        public int Md078 { get; set; }

        [Required(ErrorMessage = "前一期间不能为空")]
        //[ExcelColumn(Name = "前一期间")]
        [ExcelColumnName("前一期间")]

        public int Md079 { get; set; }

        [Required(ErrorMessage = "未来会计年度不能为空")]
        //[ExcelColumn(Name = "未来会计年度")]
        [ExcelColumnName("未来会计年度")]

        public int Md080 { get; set; }

        [Required(ErrorMessage = "当前会计年度不能为空")]
        //[ExcelColumn(Name = "当前会计年度")]
        [ExcelColumnName("当前会计年度")]

        public int Md081 { get; set; }

        [Required(ErrorMessage = "上一会计年度不能为空")]
        //[ExcelColumn(Name = "上一会计年度")]
        [ExcelColumnName("上一会计年度")]

        public int Md082 { get; set; }

        //[ExcelColumn(Name = "QS成本核算")]
        [ExcelColumnName("QS成本核算")]

        public string Md083 { get; set; }

        [Required(ErrorMessage = "上期标准价格不能为空")]
        //[ExcelColumn(Name = "上期标准价格")]
        [ExcelColumnName("上期标准价格")]

        public decimal Md084 { get; set; }

        //[ExcelColumn(Name = "ML作业")]
        [ExcelColumnName("ML作业")]

        public string Md085 { get; set; }

        //[ExcelColumn(Name = "价格确定")]
        [ExcelColumnName("价格确定")]

        public string Md086 { get; set; }

        [Required(ErrorMessage = "当前计划价格不能为空")]
        //[ExcelColumn(Name = "当前计划价格")]
        [ExcelColumnName("当前计划价格")]

        public decimal Md087 { get; set; }

        [Required(ErrorMessage = "总SP值不能为空")]
        //[ExcelColumn(Name = "总SP值")]
        [ExcelColumnName("总SP值")]

        public decimal Md088 { get; set; }

        //[ExcelColumn(Name = "物料来源")]
        [ExcelColumnName("物料来源")]

        public string Md089 { get; set; }

        //[ExcelColumn(Name = "库存冻结")]
        [ExcelColumnName("库存冻结")]

        public string Md090 { get; set; }

        //[ExcelColumn(Name = "库存盘点VO物料")]
        [ExcelColumnName("库存盘点VO物料")]

        public string Md091 { get; set; }

        //[ExcelColumn(Name = "最新实际盘点日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("最新实际盘点日期")]

        public DateTime? Md092 { get; set; }

        //[ExcelColumn(Name = "周期盘点的盘点标识")]
        [ExcelColumnName("周期盘点的盘点标识")]

        public string Md093 { get; set; }

        [Required(ErrorMessage = "评价毛利不能为空")]
        //[ExcelColumn(Name = "评价毛利")]
        [ExcelColumnName("评价毛利")]

        public decimal Md094 { get; set; }

        [Required(ErrorMessage = "当前计划价格的固定金额不能为空")]
        //[ExcelColumn(Name = "当前计划价格的固定金额")]
        [ExcelColumnName("当前计划价格的固定金额")]

        public decimal Md095 { get; set; }

        [Required(ErrorMessage = "上年计划价格的固定比例不能为空")]
        //[ExcelColumn(Name = "上年计划价格的固定比例")]
        [ExcelColumnName("上年计划价格的固定比例")]

        public decimal Md096 { get; set; }

        [Required(ErrorMessage = "未来计划价格的固定比例不能为空")]
        //[ExcelColumn(Name = "未来计划价格的固定比例")]
        [ExcelColumnName("未来计划价格的固定比例")]

        public decimal Md097 { get; set; }

        //[ExcelColumn(Name = "当前的值决策")]
        [ExcelColumnName("当前的值决策")]

        public string Md098 { get; set; }

        //[ExcelColumn(Name = "上年评估策略")]
        [ExcelColumnName("上年评估策略")]

        public string Md099 { get; set; }

        //[ExcelColumn(Name = "未来评估决策")]
        [ExcelColumnName("未来评估决策")]

        public string Md100 { get; set; }

        //[ExcelColumn(Name = "销售订单库存")]
        [ExcelColumnName("销售订单库存")]

        public string Md101 { get; set; }

        //[ExcelColumn(Name = "项目库存评估类")]
        [ExcelColumnName("项目库存评估类")]

        public string Md102 { get; set; }

        //[ExcelColumn(Name = "物料用途")]
        [ExcelColumnName("物料用途")]

        public string Md103 { get; set; }

        //[ExcelColumn(Name = "物料来源")]
        [ExcelColumnName("物料来源")]

        public string Md104 { get; set; }

        //[ExcelColumn(Name = "自制产品")]
        [ExcelColumnName("自制产品")]

        public string Md105 { get; set; }

        //[ExcelColumn(Name = "评估单位")]
        [ExcelColumnName("评估单位")]

        public string Md106 { get; set; }

        [Required(ErrorMessage = "价格单位不能为空")]
        //[ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]

        public decimal Md107 { get; set; }

        //[ExcelColumn(Name = "最后期间之前")]
        [ExcelColumnName("最后期间之前")]

        public string Md108 { get; set; }

        //[ExcelColumn(Name = "VC供应商")]
        [ExcelColumnName("VC供应商")]

        public string Md109 { get; set; }

        //[ExcelColumn(Name = "预付库存")]
        [ExcelColumnName("预付库存")]

        public string Md110 { get; set; }

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



        [ExcelColumn(Name = "评估范围")]
        public string Md004Label { get; set; }
        [ExcelColumn(Name = "评估类型")]
        public string Md005Label { get; set; }
    }

    /// <summary>
    /// 物料评估
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:30:25
    /// </summary>
    public class MmMbewImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Md002 { get; set; }

        [Required(ErrorMessage = "物料号不能为空")]
        //[ExcelColumn(Name = "物料号")]
        [ExcelColumnName("物料号")]
        public string Md003 { get; set; }

        [Required(ErrorMessage = "评估范围不能为空")]
        //[ExcelColumn(Name = "评估范围")]
        [ExcelColumnName("评估范围")]
        public string Md004 { get; set; }

        [Required(ErrorMessage = "评估类型不能为空")]
        //[ExcelColumn(Name = "评估类型")]
        [ExcelColumnName("评估类型")]
        public string Md005 { get; set; }

        //[ExcelColumn(Name = "删除标志")]
        [ExcelColumnName("删除标志")]
        public string Md006 { get; set; }

        [Required(ErrorMessage = "总库存不能为空")]
        //[ExcelColumn(Name = "总库存")]
        [ExcelColumnName("总库存")]
        public decimal Md007 { get; set; }

        [Required(ErrorMessage = "估价值不能为空")]
        //[ExcelColumn(Name = "估价值")]
        [ExcelColumnName("估价值")]
        public decimal Md008 { get; set; }

        //[ExcelColumn(Name = "价格控制")]
        [ExcelColumnName("价格控制")]
        public string Md009 { get; set; }

        [Required(ErrorMessage = "移动价格不能为空")]
        //[ExcelColumn(Name = "移动价格")]
        [ExcelColumnName("移动价格")]
        public decimal Md010 { get; set; }

        [Required(ErrorMessage = "标准价格不能为空")]
        //[ExcelColumn(Name = "标准价格")]
        [ExcelColumnName("标准价格")]
        public decimal Md011 { get; set; }

        [Required(ErrorMessage = "价格单位不能为空")]
        //[ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]
        public decimal Md012 { get; set; }

        //[ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]
        public string Md013 { get; set; }

        [Required(ErrorMessage = "价值/MA价格不能为空")]
        //[ExcelColumn(Name = "价值/MA价格")]
        [ExcelColumnName("价值/MA价格")]
        public decimal Md014 { get; set; }

        [Required(ErrorMessage = "前期总库存不能为空")]
        //[ExcelColumn(Name = "前期总库存")]
        [ExcelColumnName("前期总库存")]
        public decimal Md015 { get; set; }

        [Required(ErrorMessage = "前期总价值不能为空")]
        //[ExcelColumn(Name = "前期总价值")]
        [ExcelColumnName("前期总价值")]
        public decimal Md016 { get; set; }

        //[ExcelColumn(Name = "前期价格控制")]
        [ExcelColumnName("前期价格控制")]
        public string Md017 { get; set; }

        [Required(ErrorMessage = "前期移动平均价不能为空")]
        //[ExcelColumn(Name = "前期移动平均价")]
        [ExcelColumnName("前期移动平均价")]
        public decimal Md018 { get; set; }

        [Required(ErrorMessage = "前期标准价格不能为空")]
        //[ExcelColumn(Name = "前期标准价格")]
        [ExcelColumnName("前期标准价格")]
        public decimal Md019 { get; set; }

        [Required(ErrorMessage = "上期价格单位不能为空")]
        //[ExcelColumn(Name = "上期价格单位")]
        [ExcelColumnName("上期价格单位")]
        public decimal Md020 { get; set; }

        //[ExcelColumn(Name = "上期评价分类")]
        [ExcelColumnName("上期评价分类")]
        public string Md021 { get; set; }

        [Required(ErrorMessage = "上期价值不能为空")]
        //[ExcelColumn(Name = "上期价值")]
        [ExcelColumnName("上期价值")]
        public decimal Md022 { get; set; }

        [Required(ErrorMessage = "前年总库存不能为空")]
        //[ExcelColumn(Name = "前年总库存")]
        [ExcelColumnName("前年总库存")]
        public decimal Md023 { get; set; }

        [Required(ErrorMessage = "上年总价值不能为空")]
        //[ExcelColumn(Name = "上年总价值")]
        [ExcelColumnName("上年总价值")]
        public decimal Md024 { get; set; }

        //[ExcelColumn(Name = "前年价格控制")]
        [ExcelColumnName("前年价格控制")]
        public string Md025 { get; set; }

        [Required(ErrorMessage = "去年移动平均价不能为空")]
        //[ExcelColumn(Name = "去年移动平均价")]
        [ExcelColumnName("去年移动平均价")]
        public decimal Md026 { get; set; }

        [Required(ErrorMessage = "去年标准价格不能为空")]
        //[ExcelColumn(Name = "去年标准价格")]
        [ExcelColumnName("去年标准价格")]
        public decimal Md027 { get; set; }

        [Required(ErrorMessage = "上年价格单位不能为空")]
        //[ExcelColumn(Name = "上年价格单位")]
        [ExcelColumnName("上年价格单位")]
        public decimal Md028 { get; set; }

        //[ExcelColumn(Name = "上年评估类")]
        [ExcelColumnName("上年评估类")]
        public string Md029 { get; set; }

        [Required(ErrorMessage = "上年价值不能为空")]
        //[ExcelColumn(Name = "上年价值")]
        [ExcelColumnName("上年价值")]
        public decimal Md030 { get; set; }

        [Required(ErrorMessage = "当前会计年度不能为空")]
        //[ExcelColumn(Name = "当前会计年度")]
        [ExcelColumnName("当前会计年度")]
        public int Md031 { get; set; }

        [Required(ErrorMessage = "当前期间不能为空")]
        //[ExcelColumn(Name = "当前期间")]
        [ExcelColumnName("当前期间")]
        public int Md032 { get; set; }

        //[ExcelColumn(Name = "评估类别")]
        [ExcelColumnName("评估类别")]
        public string Md033 { get; set; }

        [Required(ErrorMessage = "上期价格不能为空")]
        //[ExcelColumn(Name = "上期价格")]
        [ExcelColumnName("上期价格")]
        public decimal Md034 { get; set; }

        //[ExcelColumn(Name = "最新价格更改", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("最新价格更改")]
        public DateTime? Md035 { get; set; }

        [Required(ErrorMessage = "未来价格不能为空")]
        //[ExcelColumn(Name = "未来价格")]
        [ExcelColumnName("未来价格")]
        public decimal Md036 { get; set; }

        //[ExcelColumn(Name = "有效起始日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效起始日期")]
        public DateTime? Md037 { get; set; }

        [Required(ErrorMessage = "时戳不能为空")]
        //[ExcelColumn(Name = "时戳")]
        [ExcelColumnName("时戳")]
        public decimal Md038 { get; set; }

        [Required(ErrorMessage = "税价1不能为空")]
        //[ExcelColumn(Name = "税价1")]
        [ExcelColumnName("税价1")]
        public decimal Md039 { get; set; }

        [Required(ErrorMessage = "商业价格1不能为空")]
        //[ExcelColumn(Name = "商业价格1")]
        [ExcelColumnName("商业价格1")]
        public decimal Md040 { get; set; }

        [Required(ErrorMessage = "税价3不能为空")]
        //[ExcelColumn(Name = "税价3")]
        [ExcelColumnName("税价3")]
        public decimal Md041 { get; set; }

        [Required(ErrorMessage = "商业价格3不能为空")]
        //[ExcelColumn(Name = "商业价格3")]
        [ExcelColumnName("商业价格3")]
        public decimal Md042 { get; set; }

        [Required(ErrorMessage = "计价不能为空")]
        //[ExcelColumn(Name = "计价")]
        [ExcelColumnName("计价")]
        public decimal Md043 { get; set; }

        [Required(ErrorMessage = "前年总库存不能为空")]
        //[ExcelColumn(Name = "前年总库存")]
        [ExcelColumnName("前年总库存")]
        public decimal Md044 { get; set; }

        [Required(ErrorMessage = "前期总价值不能为空")]
        //[ExcelColumn(Name = "前期总价值")]
        [ExcelColumnName("前期总价值")]
        public decimal Md045 { get; set; }

        [Required(ErrorMessage = "计价在不能为空")]
        //[ExcelColumn(Name = "计价在")]
        [ExcelColumnName("计价在")]
        public decimal Md046 { get; set; }

        [Required(ErrorMessage = "未来计划价格不能为空")]
        //[ExcelColumn(Name = "未来计划价格")]
        [ExcelColumnName("未来计划价格")]
        public decimal Md047 { get; set; }

        [Required(ErrorMessage = "未来计划价格1不能为空")]
        //[ExcelColumn(Name = "未来计划价格1")]
        [ExcelColumnName("未来计划价格1")]
        public decimal Md048 { get; set; }

        [Required(ErrorMessage = "未来计划价格 2不能为空")]
        //[ExcelColumn(Name = "未来计划价格 2")]
        [ExcelColumnName("未来计划价格 2")]
        public decimal Md049 { get; set; }

        [Required(ErrorMessage = "未来计划价格 3不能为空")]
        //[ExcelColumn(Name = "未来计划价格 3")]
        [ExcelColumnName("未来计划价格 3")]
        public decimal Md050 { get; set; }

        //[ExcelColumn(Name = "计划价格日期1", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("计划价格日期1")]
        public DateTime? Md051 { get; set; }

        //[ExcelColumn(Name = "计划价格日期2", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("计划价格日期2")]
        public DateTime? Md052 { get; set; }

        //[ExcelColumn(Name = "计划价格日期3", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("计划价格日期3")]
        public DateTime? Md053 { get; set; }

        //[ExcelColumn(Name = "未来成本估算", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("未来成本估算")]
        public DateTime? Md054 { get; set; }

        //[ExcelColumn(Name = "期间成本估算", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("期间成本估算")]
        public DateTime? Md055 { get; set; }

        //[ExcelColumn(Name = "上期成本估算", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("上期成本估算")]
        public DateTime? Md056 { get; set; }

        //[ExcelColumn(Name = "未来成本估算")]
        [ExcelColumnName("未来成本估算")]
        public string Md057 { get; set; }

        //[ExcelColumn(Name = "当前成本估算")]
        [ExcelColumnName("当前成本估算")]
        public string Md058 { get; set; }

        //[ExcelColumn(Name = "上期成本估算")]
        [ExcelColumnName("上期成本估算")]
        public string Md059 { get; set; }

        //[ExcelColumn(Name = "一般费用代码")]
        [ExcelColumnName("一般费用代码")]
        public string Md060 { get; set; }

        //[ExcelColumn(Name = "LIFO/FIFO 相关")]
        [ExcelColumnName("LIFO/FIFO 相关")]
        public string Md061 { get; set; }

        //[ExcelColumn(Name = "LIFO评估储备号")]
        [ExcelColumnName("LIFO评估储备号")]
        public string Md062 { get; set; }

        [Required(ErrorMessage = "商业价格2不能为空")]
        //[ExcelColumn(Name = "商业价格2")]
        [ExcelColumnName("商业价格2")]
        public decimal Md063 { get; set; }

        [Required(ErrorMessage = "税价2不能为空")]
        //[ExcelColumn(Name = "税价2")]
        [ExcelColumnName("税价2")]
        public decimal Md064 { get; set; }

        [Required(ErrorMessage = "贬值标志不能为空")]
        //[ExcelColumn(Name = "贬值标志")]
        [ExcelColumnName("贬值标志")]
        public int Md065 { get; set; }

        //[ExcelColumn(Name = "维护状态")]
        [ExcelColumnName("维护状态")]
        public string Md066 { get; set; }

        [Required(ErrorMessage = "产品成本核算不能为空")]
        //[ExcelColumn(Name = "产品成本核算")]
        [ExcelColumnName("产品成本核算")]
        public int Md067 { get; set; }

        [Required(ErrorMessage = "成本估算编号不能为空")]
        //[ExcelColumn(Name = "成本估算编号")]
        [ExcelColumnName("成本估算编号")]
        public int Md068 { get; set; }

        //[ExcelColumn(Name = "评估变式1")]
        [ExcelColumnName("评估变式1")]
        public string Md069 { get; set; }

        //[ExcelColumn(Name = "评估变式2")]
        [ExcelColumnName("评估变式2")]
        public string Md070 { get; set; }

        //[ExcelColumn(Name = "评估变式3")]
        [ExcelColumnName("评估变式3")]
        public string Md071 { get; set; }

        [Required(ErrorMessage = "成本核算版本1不能为空")]
        //[ExcelColumn(Name = "成本核算版本1")]
        [ExcelColumnName("成本核算版本1")]
        public int Md072 { get; set; }

        [Required(ErrorMessage = "成本核算版本2不能为空")]
        //[ExcelColumn(Name = "成本核算版本2")]
        [ExcelColumnName("成本核算版本2")]
        public int Md073 { get; set; }

        [Required(ErrorMessage = "成本核算版本3不能为空")]
        //[ExcelColumn(Name = "成本核算版本3")]
        [ExcelColumnName("成本核算版本3")]
        public int Md074 { get; set; }

        //[ExcelColumn(Name = "原始组")]
        [ExcelColumnName("原始组")]
        public string Md075 { get; set; }

        //[ExcelColumn(Name = "间接费分组")]
        [ExcelColumnName("间接费分组")]
        public string Md076 { get; set; }

        [Required(ErrorMessage = "计价期间不能为空")]
        //[ExcelColumn(Name = "计价期间")]
        [ExcelColumnName("计价期间")]
        public int Md077 { get; set; }

        [Required(ErrorMessage = "当前期间不能为空")]
        //[ExcelColumn(Name = "当前期间")]
        [ExcelColumnName("当前期间")]
        public int Md078 { get; set; }

        [Required(ErrorMessage = "前一期间不能为空")]
        //[ExcelColumn(Name = "前一期间")]
        [ExcelColumnName("前一期间")]
        public int Md079 { get; set; }

        [Required(ErrorMessage = "未来会计年度不能为空")]
        //[ExcelColumn(Name = "未来会计年度")]
        [ExcelColumnName("未来会计年度")]
        public int Md080 { get; set; }

        [Required(ErrorMessage = "当前会计年度不能为空")]
        //[ExcelColumn(Name = "当前会计年度")]
        [ExcelColumnName("当前会计年度")]
        public int Md081 { get; set; }

        [Required(ErrorMessage = "上一会计年度不能为空")]
        //[ExcelColumn(Name = "上一会计年度")]
        [ExcelColumnName("上一会计年度")]
        public int Md082 { get; set; }

        //[ExcelColumn(Name = "QS成本核算")]
        [ExcelColumnName("QS成本核算")]
        public string Md083 { get; set; }

        [Required(ErrorMessage = "上期标准价格不能为空")]
        //[ExcelColumn(Name = "上期标准价格")]
        [ExcelColumnName("上期标准价格")]
        public decimal Md084 { get; set; }

        //[ExcelColumn(Name = "ML作业")]
        [ExcelColumnName("ML作业")]
        public string Md085 { get; set; }

        //[ExcelColumn(Name = "价格确定")]
        [ExcelColumnName("价格确定")]
        public string Md086 { get; set; }

        [Required(ErrorMessage = "当前计划价格不能为空")]
        //[ExcelColumn(Name = "当前计划价格")]
        [ExcelColumnName("当前计划价格")]
        public decimal Md087 { get; set; }

        [Required(ErrorMessage = "总SP值不能为空")]
        //[ExcelColumn(Name = "总SP值")]
        [ExcelColumnName("总SP值")]
        public decimal Md088 { get; set; }

        //[ExcelColumn(Name = "物料来源")]
        [ExcelColumnName("物料来源")]
        public string Md089 { get; set; }

        //[ExcelColumn(Name = "库存冻结")]
        [ExcelColumnName("库存冻结")]
        public string Md090 { get; set; }

        //[ExcelColumn(Name = "库存盘点VO物料")]
        [ExcelColumnName("库存盘点VO物料")]
        public string Md091 { get; set; }

        //[ExcelColumn(Name = "最新实际盘点日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("最新实际盘点日期")]
        public DateTime? Md092 { get; set; }

        //[ExcelColumn(Name = "周期盘点的盘点标识")]
        [ExcelColumnName("周期盘点的盘点标识")]
        public string Md093 { get; set; }

        [Required(ErrorMessage = "评价毛利不能为空")]
        //[ExcelColumn(Name = "评价毛利")]
        [ExcelColumnName("评价毛利")]
        public decimal Md094 { get; set; }

        [Required(ErrorMessage = "当前计划价格的固定金额不能为空")]
        //[ExcelColumn(Name = "当前计划价格的固定金额")]
        [ExcelColumnName("当前计划价格的固定金额")]
        public decimal Md095 { get; set; }

        [Required(ErrorMessage = "上年计划价格的固定比例不能为空")]
        //[ExcelColumn(Name = "上年计划价格的固定比例")]
        [ExcelColumnName("上年计划价格的固定比例")]
        public decimal Md096 { get; set; }

        [Required(ErrorMessage = "未来计划价格的固定比例不能为空")]
        //[ExcelColumn(Name = "未来计划价格的固定比例")]
        [ExcelColumnName("未来计划价格的固定比例")]
        public decimal Md097 { get; set; }

        //[ExcelColumn(Name = "当前的值决策")]
        [ExcelColumnName("当前的值决策")]
        public string Md098 { get; set; }

        //[ExcelColumn(Name = "上年评估策略")]
        [ExcelColumnName("上年评估策略")]
        public string Md099 { get; set; }

        //[ExcelColumn(Name = "未来评估决策")]
        [ExcelColumnName("未来评估决策")]
        public string Md100 { get; set; }

        //[ExcelColumn(Name = "销售订单库存")]
        [ExcelColumnName("销售订单库存")]
        public string Md101 { get; set; }

        //[ExcelColumn(Name = "项目库存评估类")]
        [ExcelColumnName("项目库存评估类")]
        public string Md102 { get; set; }

        //[ExcelColumn(Name = "物料用途")]
        [ExcelColumnName("物料用途")]
        public string Md103 { get; set; }

        //[ExcelColumn(Name = "物料来源")]
        [ExcelColumnName("物料来源")]
        public string Md104 { get; set; }

        //[ExcelColumn(Name = "自制产品")]
        [ExcelColumnName("自制产品")]
        public string Md105 { get; set; }

        //[ExcelColumn(Name = "评估单位")]
        [ExcelColumnName("评估单位")]
        public string Md106 { get; set; }

        [Required(ErrorMessage = "价格单位不能为空")]
        //[ExcelColumn(Name = "价格单位")]
        [ExcelColumnName("价格单位")]
        public decimal Md107 { get; set; }

        //[ExcelColumn(Name = "最后期间之前")]
        [ExcelColumnName("最后期间之前")]
        public string Md108 { get; set; }

        //[ExcelColumn(Name = "VC供应商")]
        [ExcelColumnName("VC供应商")]
        public string Md109 { get; set; }

        //[ExcelColumn(Name = "预付库存")]
        [ExcelColumnName("预付库存")]
        public string Md110 { get; set; }

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
        [ExcelColumn(Name = "评估范围")]
        public string Md004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "评估类型")]
        public string Md005Label { get; set; }
    }

}