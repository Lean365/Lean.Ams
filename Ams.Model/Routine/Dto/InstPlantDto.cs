
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 工厂代码
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:16:10
    /// </summary>
    public class InstPlantQueryDto : PagerInfo 
    {
        /// <summary>
        /// 性质 
        /// </summary>        
        public string Mc003 { get; set; }
        /// <summary>
        /// 类别 
        /// </summary>        
        public string Mc004 { get; set; }
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Mc005 { get; set; }
        /// <summary>
        /// 名称 
        /// </summary>        
        public string Mc006 { get; set; }
        /// <summary>
        /// 评估范围 
        /// </summary>        
        public string Mc007 { get; set; }
        /// <summary>
        /// 城市 
        /// </summary>        
        public string Mc015 { get; set; }
        /// <summary>
        /// 采购组织 
        /// </summary>        
        public string Mc016 { get; set; }
        /// <summary>
        /// 销售组织 
        /// </summary>        
        public string Mc017 { get; set; }
        /// <summary>
        /// 国家 
        /// </summary>        
        public string Mc022 { get; set; }
        /// <summary>
        /// 语言 
        /// </summary>        
        public string Mc031 { get; set; }
    }

    /// <summary>
    /// 工厂代码
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:16:10
    /// </summary>
    public class InstPlantDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]

        public string Mc002 { get; set; }

        [Required(ErrorMessage = "性质不能为空")]
        //[ExcelColumn(Name = "性质")]
        [ExcelColumnName("性质")]

        public string Mc003 { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        //[ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]

        public string Mc004 { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Mc005 { get; set; }

        //[ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]

        public string Mc006 { get; set; }

        //[ExcelColumn(Name = "评估范围")]
        [ExcelColumnName("评估范围")]

        public string Mc007 { get; set; }

        //[ExcelColumn(Name = "竞争者")]
        [ExcelColumnName("竞争者")]

        public string Mc008 { get; set; }

        //[ExcelColumn(Name = "工厂供应商号码")]
        [ExcelColumnName("工厂供应商号码")]

        public string Mc009 { get; set; }

        //[ExcelColumn(Name = "日历")]
        [ExcelColumnName("日历")]

        public string Mc010 { get; set; }

        //[ExcelColumn(Name = "名称 2")]
        [ExcelColumnName("名称 2")]

        public string Mc011 { get; set; }

        //[ExcelColumn(Name = "住宅号及街道")]
        [ExcelColumnName("住宅号及街道")]

        public string Mc012 { get; set; }

        //[ExcelColumn(Name = "邮政信箱")]
        [ExcelColumnName("邮政信箱")]

        public string Mc013 { get; set; }

        //[ExcelColumn(Name = "邮政编码")]
        [ExcelColumnName("邮政编码")]

        public string Mc014 { get; set; }

        //[ExcelColumn(Name = "城市")]
        [ExcelColumnName("城市")]

        public string Mc015 { get; set; }

        //[ExcelColumn(Name = "采购组织")]
        [ExcelColumnName("采购组织")]

        public string Mc016 { get; set; }

        //[ExcelColumn(Name = "销售组织")]
        [ExcelColumnName("销售组织")]

        public string Mc017 { get; set; }

        //[ExcelColumn(Name = "批量管理")]
        [ExcelColumnName("批量管理")]

        public string Mc018 { get; set; }

        //[ExcelColumn(Name = "工厂条件")]
        [ExcelColumnName("工厂条件")]

        public string Mc019 { get; set; }

        //[ExcelColumn(Name = "源清单")]
        [ExcelColumnName("源清单")]

        public string Mc020 { get; set; }

        //[ExcelColumn(Name = "MRP")]
        [ExcelColumnName("MRP")]

        public string Mc021 { get; set; }

        //[ExcelColumn(Name = "国家")]
        [ExcelColumnName("国家")]

        public string Mc022 { get; set; }

        //[ExcelColumn(Name = "地区")]
        [ExcelColumnName("地区")]

        public string Mc023 { get; set; }

        //[ExcelColumn(Name = "县")]
        [ExcelColumnName("县")]

        public string Mc024 { get; set; }

        //[ExcelColumn(Name = "市")]
        [ExcelColumnName("市")]

        public string Mc025 { get; set; }

        //[ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]

        public string Mc026 { get; set; }

        //[ExcelColumn(Name = "计划工厂")]
        [ExcelColumnName("计划工厂")]

        public string Mc027 { get; set; }

        //[ExcelColumn(Name = "地区税务代码")]
        [ExcelColumnName("地区税务代码")]

        public string Mc028 { get; set; }

        //[ExcelColumn(Name = "分销渠道")]
        [ExcelColumnName("分销渠道")]

        public string Mc029 { get; set; }

        //[ExcelColumn(Name = "产品组")]
        [ExcelColumnName("产品组")]

        public string Mc030 { get; set; }

        //[ExcelColumn(Name = "语言")]
        [ExcelColumnName("语言")]

        public string Mc031 { get; set; }

        //[ExcelColumn(Name = "SOP工厂")]
        [ExcelColumnName("SOP工厂")]

        public string Mc032 { get; set; }

        //[ExcelColumn(Name = "差异码")]
        [ExcelColumnName("差异码")]

        public string Mc033 { get; set; }

        //[ExcelColumn(Name = "批量管理")]
        [ExcelColumnName("批量管理")]

        public string Mc034 { get; set; }

        //[ExcelColumn(Name = "工厂种类")]
        [ExcelColumnName("工厂种类")]

        public string Mc035 { get; set; }

        //[ExcelColumn(Name = "销售地区")]
        [ExcelColumnName("销售地区")]

        public string Mc036 { get; set; }

        //[ExcelColumn(Name = "供应地区")]
        [ExcelColumnName("供应地区")]

        public string Mc037 { get; set; }

        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Mc038 { get; set; }

        //[ExcelColumn(Name = "常规供应商")]
        [ExcelColumnName("常规供应商")]

        public string Mc039 { get; set; }

        //[ExcelColumn(Name = "第一封催询单")]
        [ExcelColumnName("第一封催询单")]

        public int? Mc040 { get; set; }

        //[ExcelColumn(Name = "第二封催询单")]
        [ExcelColumnName("第二封催询单")]

        public int? Mc041 { get; set; }

        //[ExcelColumn(Name = "第三封催询单")]
        [ExcelColumnName("第三封催询单")]

        public int? Mc042 { get; set; }

        //[ExcelColumn(Name = "第一催讨文本")]
        [ExcelColumnName("第一催讨文本")]

        public string Mc043 { get; set; }

        //[ExcelColumn(Name = "第二催讨文本")]
        [ExcelColumnName("第二催讨文本")]

        public string Mc044 { get; set; }

        //[ExcelColumn(Name = "第三催讨文本")]
        [ExcelColumnName("第三催讨文本")]

        public string Mc045 { get; set; }

        //[ExcelColumn(Name = "采购订单容差")]
        [ExcelColumnName("采购订单容差")]

        public int? Mc046 { get; set; }

        //[ExcelColumn(Name = "业务地点")]
        [ExcelColumnName("业务地点")]

        public string Mc047 { get; set; }

        //[ExcelColumn(Name = "销售范围")]
        [ExcelColumnName("销售范围")]

        public string Mc048 { get; set; }

        //[ExcelColumn(Name = "工厂分配")]
        [ExcelColumnName("工厂分配")]

        public string Mc049 { get; set; }

        //[ExcelColumn(Name = "归档标记")]
        [ExcelColumnName("归档标记")]

        public string Mc050 { get; set; }

        //[ExcelColumn(Name = "批次记录")]
        [ExcelColumnName("批次记录")]

        public string Mc051 { get; set; }

        //[ExcelColumn(Name = "节点类型")]
        [ExcelColumnName("节点类型")]

        public string Mc052 { get; set; }

        //[ExcelColumn(Name = "名称结构")]
        [ExcelColumnName("名称结构")]

        public string Mc053 { get; set; }

        //[ExcelColumn(Name = "成本对象控制")]
        [ExcelColumnName("成本对象控制")]

        public string Mc054 { get; set; }

        //[ExcelColumn(Name = "混合成本核算")]
        [ExcelColumnName("混合成本核算")]

        public string Mc055 { get; set; }

        //[ExcelColumn(Name = "实际成本核算")]
        [ExcelColumnName("实际成本核算")]

        public string Mc056 { get; set; }

        //[ExcelColumn(Name = "装运点/接收点")]
        [ExcelColumnName("装运点/接收点")]

        public string Mc057 { get; set; }

        //[ExcelColumn(Name = "更新作业消耗")]
        [ExcelColumnName("更新作业消耗")]

        public string Mc058 { get; set; }

        //[ExcelColumn(Name = "信用控制")]
        [ExcelColumnName("信用控制")]

        public string Mc059 { get; set; }

        //[ExcelColumn(Name = "附加货源")]
        [ExcelColumnName("附加货源")]

        public string Mc060 { get; set; }

        //[ExcelColumn(Name = "交易评估")]
        [ExcelColumnName("交易评估")]

        public string Mc061 { get; set; }

        //[ExcelColumn(Name = "供应商类型")]
        [ExcelColumnName("供应商类型")]

        public string Mc062 { get; set; }

        //[ExcelColumn(Name = "IPI信贷")]
        [ExcelColumnName("IPI信贷")]

        public string Mc063 { get; set; }

        //[ExcelColumn(Name = "存储类别")]
        [ExcelColumnName("存储类别")]

        public string Mc064 { get; set; }

        //[ExcelColumn(Name = "上级公司")]
        [ExcelColumnName("上级公司")]

        public string Mc065 { get; set; }

        [ExcelIgnore]

        public string REF01 { get; set; }

        [ExcelIgnore]

        public string REF02 { get; set; }

        [ExcelIgnore]

        public string REF03 { get; set; }

        [ExcelIgnore]

        public decimal REF04 { get; set; }

        [ExcelIgnore]

        public decimal REF05 { get; set; }

        [ExcelIgnore]

        public decimal REF06 { get; set; }

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

        public int? UDF51 { get; set; }

        [ExcelIgnore]

        public int? UDF52 { get; set; }

        [ExcelIgnore]

        public int? UDF53 { get; set; }

        [ExcelIgnore]

        public decimal UDF54 { get; set; }

        [ExcelIgnore]

        public decimal UDF55 { get; set; }

        [ExcelIgnore]

        public decimal UDF56 { get; set; }

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



        [ExcelColumn(Name = "性质")]
        public string Mc003Label { get; set; }
        [ExcelColumn(Name = "类别")]
        public string Mc004Label { get; set; }
        [ExcelColumn(Name = "国家")]
        public string Mc022Label { get; set; }
        [ExcelColumn(Name = "语言")]
        public string Mc031Label { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 工厂代码
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:16:10
    /// </summary>
    public class InstPlantImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Mc002 { get; set; }

        [Required(ErrorMessage = "性质不能为空")]
        //[ExcelColumn(Name = "性质")]
        [ExcelColumnName("性质")]
        public string Mc003 { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        //[ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string Mc004 { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Mc005 { get; set; }

        //[ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string Mc006 { get; set; }

        //[ExcelColumn(Name = "评估范围")]
        [ExcelColumnName("评估范围")]
        public string Mc007 { get; set; }

        //[ExcelColumn(Name = "竞争者")]
        [ExcelColumnName("竞争者")]
        public string Mc008 { get; set; }

        //[ExcelColumn(Name = "工厂供应商号码")]
        [ExcelColumnName("工厂供应商号码")]
        public string Mc009 { get; set; }

        //[ExcelColumn(Name = "日历")]
        [ExcelColumnName("日历")]
        public string Mc010 { get; set; }

        //[ExcelColumn(Name = "名称 2")]
        [ExcelColumnName("名称 2")]
        public string Mc011 { get; set; }

        //[ExcelColumn(Name = "住宅号及街道")]
        [ExcelColumnName("住宅号及街道")]
        public string Mc012 { get; set; }

        //[ExcelColumn(Name = "邮政信箱")]
        [ExcelColumnName("邮政信箱")]
        public string Mc013 { get; set; }

        //[ExcelColumn(Name = "邮政编码")]
        [ExcelColumnName("邮政编码")]
        public string Mc014 { get; set; }

        //[ExcelColumn(Name = "城市")]
        [ExcelColumnName("城市")]
        public string Mc015 { get; set; }

        //[ExcelColumn(Name = "采购组织")]
        [ExcelColumnName("采购组织")]
        public string Mc016 { get; set; }

        //[ExcelColumn(Name = "销售组织")]
        [ExcelColumnName("销售组织")]
        public string Mc017 { get; set; }

        //[ExcelColumn(Name = "批量管理")]
        [ExcelColumnName("批量管理")]
        public string Mc018 { get; set; }

        //[ExcelColumn(Name = "工厂条件")]
        [ExcelColumnName("工厂条件")]
        public string Mc019 { get; set; }

        //[ExcelColumn(Name = "源清单")]
        [ExcelColumnName("源清单")]
        public string Mc020 { get; set; }

        //[ExcelColumn(Name = "MRP")]
        [ExcelColumnName("MRP")]
        public string Mc021 { get; set; }

        //[ExcelColumn(Name = "国家")]
        [ExcelColumnName("国家")]
        public string Mc022 { get; set; }

        //[ExcelColumn(Name = "地区")]
        [ExcelColumnName("地区")]
        public string Mc023 { get; set; }

        //[ExcelColumn(Name = "县")]
        [ExcelColumnName("县")]
        public string Mc024 { get; set; }

        //[ExcelColumn(Name = "市")]
        [ExcelColumnName("市")]
        public string Mc025 { get; set; }

        //[ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]
        public string Mc026 { get; set; }

        //[ExcelColumn(Name = "计划工厂")]
        [ExcelColumnName("计划工厂")]
        public string Mc027 { get; set; }

        //[ExcelColumn(Name = "地区税务代码")]
        [ExcelColumnName("地区税务代码")]
        public string Mc028 { get; set; }

        //[ExcelColumn(Name = "分销渠道")]
        [ExcelColumnName("分销渠道")]
        public string Mc029 { get; set; }

        //[ExcelColumn(Name = "产品组")]
        [ExcelColumnName("产品组")]
        public string Mc030 { get; set; }

        //[ExcelColumn(Name = "语言")]
        [ExcelColumnName("语言")]
        public string Mc031 { get; set; }

        //[ExcelColumn(Name = "SOP工厂")]
        [ExcelColumnName("SOP工厂")]
        public string Mc032 { get; set; }

        //[ExcelColumn(Name = "差异码")]
        [ExcelColumnName("差异码")]
        public string Mc033 { get; set; }

        //[ExcelColumn(Name = "批量管理")]
        [ExcelColumnName("批量管理")]
        public string Mc034 { get; set; }

        //[ExcelColumn(Name = "工厂种类")]
        [ExcelColumnName("工厂种类")]
        public string Mc035 { get; set; }

        //[ExcelColumn(Name = "销售地区")]
        [ExcelColumnName("销售地区")]
        public string Mc036 { get; set; }

        //[ExcelColumn(Name = "供应地区")]
        [ExcelColumnName("供应地区")]
        public string Mc037 { get; set; }

        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Mc038 { get; set; }

        //[ExcelColumn(Name = "常规供应商")]
        [ExcelColumnName("常规供应商")]
        public string Mc039 { get; set; }

        //[ExcelColumn(Name = "第一封催询单")]
        [ExcelColumnName("第一封催询单")]
        public int? Mc040 { get; set; }

        //[ExcelColumn(Name = "第二封催询单")]
        [ExcelColumnName("第二封催询单")]
        public int? Mc041 { get; set; }

        //[ExcelColumn(Name = "第三封催询单")]
        [ExcelColumnName("第三封催询单")]
        public int? Mc042 { get; set; }

        //[ExcelColumn(Name = "第一催讨文本")]
        [ExcelColumnName("第一催讨文本")]
        public string Mc043 { get; set; }

        //[ExcelColumn(Name = "第二催讨文本")]
        [ExcelColumnName("第二催讨文本")]
        public string Mc044 { get; set; }

        //[ExcelColumn(Name = "第三催讨文本")]
        [ExcelColumnName("第三催讨文本")]
        public string Mc045 { get; set; }

        //[ExcelColumn(Name = "采购订单容差")]
        [ExcelColumnName("采购订单容差")]
        public int? Mc046 { get; set; }

        //[ExcelColumn(Name = "业务地点")]
        [ExcelColumnName("业务地点")]
        public string Mc047 { get; set; }

        //[ExcelColumn(Name = "销售范围")]
        [ExcelColumnName("销售范围")]
        public string Mc048 { get; set; }

        //[ExcelColumn(Name = "工厂分配")]
        [ExcelColumnName("工厂分配")]
        public string Mc049 { get; set; }

        //[ExcelColumn(Name = "归档标记")]
        [ExcelColumnName("归档标记")]
        public string Mc050 { get; set; }

        //[ExcelColumn(Name = "批次记录")]
        [ExcelColumnName("批次记录")]
        public string Mc051 { get; set; }

        //[ExcelColumn(Name = "节点类型")]
        [ExcelColumnName("节点类型")]
        public string Mc052 { get; set; }

        //[ExcelColumn(Name = "名称结构")]
        [ExcelColumnName("名称结构")]
        public string Mc053 { get; set; }

        //[ExcelColumn(Name = "成本对象控制")]
        [ExcelColumnName("成本对象控制")]
        public string Mc054 { get; set; }

        //[ExcelColumn(Name = "混合成本核算")]
        [ExcelColumnName("混合成本核算")]
        public string Mc055 { get; set; }

        //[ExcelColumn(Name = "实际成本核算")]
        [ExcelColumnName("实际成本核算")]
        public string Mc056 { get; set; }

        //[ExcelColumn(Name = "装运点/接收点")]
        [ExcelColumnName("装运点/接收点")]
        public string Mc057 { get; set; }

        //[ExcelColumn(Name = "更新作业消耗")]
        [ExcelColumnName("更新作业消耗")]
        public string Mc058 { get; set; }

        //[ExcelColumn(Name = "信用控制")]
        [ExcelColumnName("信用控制")]
        public string Mc059 { get; set; }

        //[ExcelColumn(Name = "附加货源")]
        [ExcelColumnName("附加货源")]
        public string Mc060 { get; set; }

        //[ExcelColumn(Name = "交易评估")]
        [ExcelColumnName("交易评估")]
        public string Mc061 { get; set; }

        //[ExcelColumn(Name = "供应商类型")]
        [ExcelColumnName("供应商类型")]
        public string Mc062 { get; set; }

        //[ExcelColumn(Name = "IPI信贷")]
        [ExcelColumnName("IPI信贷")]
        public string Mc063 { get; set; }

        //[ExcelColumn(Name = "存储类别")]
        [ExcelColumnName("存储类别")]
        public string Mc064 { get; set; }

        //[ExcelColumn(Name = "上级公司")]
        [ExcelColumnName("上级公司")]
        public string Mc065 { get; set; }

        [ExcelIgnore]
        public string REF01 { get; set; }

        [ExcelIgnore]
        public string REF02 { get; set; }

        [ExcelIgnore]
        public string REF03 { get; set; }

        [ExcelIgnore]
        public decimal REF04 { get; set; }

        [ExcelIgnore]
        public decimal REF05 { get; set; }

        [ExcelIgnore]
        public decimal REF06 { get; set; }

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
        public int? UDF51 { get; set; }

        [ExcelIgnore]
        public int? UDF52 { get; set; }

        [ExcelIgnore]
        public int? UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

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
        [ExcelColumn(Name = "性质")]
        public string Mc003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "类别")]
        public string Mc004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "国家")]
        public string Mc022Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "语言")]
        public string Mc031Label { get; set; }
    }

}