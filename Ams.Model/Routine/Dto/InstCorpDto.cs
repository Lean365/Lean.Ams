
namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 公司代码
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:19:56
    /// </summary>
    public class InstCorpQueryDto : PagerInfo 
    {
        /// <summary>
        /// 性质 
        /// </summary>        
        public string Ma003 { get; set; }
        /// <summary>
        /// 类别 
        /// </summary>        
        public string Ma004 { get; set; }
        /// <summary>
        /// 代码 
        /// </summary>        
        public string Ma005 { get; set; }
        /// <summary>
        /// 简称 
        /// </summary>        
        public string Ma006 { get; set; }
        /// <summary>
        /// 名称 
        /// </summary>        
        public string Ma007 { get; set; }
        /// <summary>
        /// 国家 
        /// </summary>        
        public string Ma009 { get; set; }
        /// <summary>
        /// 城市 
        /// </summary>        
        public string Ma008 { get; set; }
        /// <summary>
        /// 货币码 
        /// </summary>        
        public string Ma010 { get; set; }
        /// <summary>
        /// 生产公司代码 
        /// </summary>        
        public string Ma036 { get; set; }
    }

    /// <summary>
    /// 公司代码
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:19:56
    /// </summary>
    public class InstCorpDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]

        public string Ma002 { get; set; }

        [Required(ErrorMessage = "性质不能为空")]
        //[ExcelColumn(Name = "性质")]
        [ExcelColumnName("性质")]

        public string Ma003 { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        //[ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]

        public string Ma004 { get; set; }

        [Required(ErrorMessage = "代码不能为空")]
        //[ExcelColumn(Name = "代码")]
        [ExcelColumnName("代码")]

        public string Ma005 { get; set; }

        //[ExcelColumn(Name = "简称")]
        [ExcelColumnName("简称")]

        public string Ma006 { get; set; }

        //[ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]

        public string Ma007 { get; set; }

        //[ExcelColumn(Name = "国家")]
        [ExcelColumnName("国家")]

        public string Ma009 { get; set; }

        //[ExcelColumn(Name = "城市")]
        [ExcelColumnName("城市")]

        public string Ma008 { get; set; }

        //[ExcelColumn(Name = "货币码")]
        [ExcelColumnName("货币码")]

        public string Ma010 { get; set; }

        //[ExcelColumn(Name = "语言")]
        [ExcelColumnName("语言")]

        public string Ma011 { get; set; }

        //[ExcelColumn(Name = "帐目表")]
        [ExcelColumnName("帐目表")]

        public string Ma012 { get; set; }

        //[ExcelColumn(Name = "最大汇率偏差")]
        [ExcelColumnName("最大汇率偏差")]

        public int? Ma013 { get; set; }

        //[ExcelColumn(Name = "会计年度变式")]
        [ExcelColumnName("会计年度变式")]

        public string Ma014 { get; set; }

        //[ExcelColumn(Name = "分配标识符")]
        [ExcelColumnName("分配标识符")]

        public string Ma015 { get; set; }

        //[ExcelColumn(Name = "公司简称")]
        [ExcelColumnName("公司简称")]

        public string Ma016 { get; set; }

        //[ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]

        public string Ma017 { get; set; }

        //[ExcelColumn(Name = "增值税登记号")]
        [ExcelColumnName("增值税登记号")]

        public string Ma018 { get; set; }

        //[ExcelColumn(Name = "财务管理范围")]
        [ExcelColumnName("财务管理范围")]

        public string Ma019 { get; set; }

        //[ExcelColumn(Name = "现金管理项目")]
        [ExcelColumnName("现金管理项目")]

        public string Ma020 { get; set; }

        //[ExcelColumn(Name = "现金预算管理")]
        [ExcelColumnName("现金预算管理")]

        public string Ma021 { get; set; }

        //[ExcelColumn(Name = "资金管理更新")]
        [ExcelColumnName("资金管理更新")]

        public string Ma022 { get; set; }

        //[ExcelColumn(Name = "地区税务代码")]
        [ExcelColumnName("地区税务代码")]

        public string Ma023 { get; set; }

        //[ExcelColumn(Name = "基金分配科目", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("基金分配科目")]

        public DateTime? Ma024 { get; set; }

        //[ExcelColumn(Name = "公司变式")]
        [ExcelColumnName("公司变式")]

        public string Ma025 { get; set; }

        //[ExcelColumn(Name = "预测公司")]
        [ExcelColumnName("预测公司")]

        public string Ma026 { get; set; }

        //[ExcelColumn(Name = "现金管理")]
        [ExcelColumnName("现金管理")]

        public string Ma027 { get; set; }

        //[ExcelColumn(Name = "起息日")]
        [ExcelColumnName("起息日")]

        public string Ma028 { get; set; }

        //[ExcelColumn(Name = "折扣金额净值")]
        [ExcelColumnName("折扣金额净值")]

        public string Ma029 { get; set; }

        //[ExcelColumn(Name = "贷方控制范围")]
        [ExcelColumnName("贷方控制范围")]

        public string Ma030 { get; set; }

        //[ExcelColumn(Name = "净折扣额")]
        [ExcelColumnName("净折扣额")]

        public string Ma031 { get; set; }

        //[ExcelColumn(Name = "从样本科目复制")]
        [ExcelColumnName("从样本科目复制")]

        public string Ma032 { get; set; }

        //[ExcelColumn(Name = "业务部门资产负债表")]
        [ExcelColumnName("业务部门资产负债表")]

        public string Ma033 { get; set; }

        //[ExcelColumn(Name = "建议会计年度")]
        [ExcelColumnName("建议会计年度")]

        public string Ma034 { get; set; }

        //[ExcelColumn(Name = "外向换算记帐")]
        [ExcelColumnName("外向换算记帐")]

        public string Ma035 { get; set; }

        //[ExcelColumn(Name = "生产公司代码")]
        [ExcelColumnName("生产公司代码")]

        public string Ma036 { get; set; }

        //[ExcelColumn(Name = "采购科目")]
        [ExcelColumnName("采购科目")]

        public string Ma037 { get; set; }

        //[ExcelColumn(Name = "联营公司会计")]
        [ExcelColumnName("联营公司会计")]

        public string Ma038 { get; set; }

        //[ExcelColumn(Name = "金融资产管理")]
        [ExcelColumnName("金融资产管理")]

        public string Ma039 { get; set; }

        //[ExcelColumn(Name = "汇率差额")]
        [ExcelColumnName("汇率差额")]

        public string Ma040 { get; set; }

        //[ExcelColumn(Name = "更新MM")]
        [ExcelColumnName("更新MM")]

        public string Ma041 { get; set; }

        //[ExcelColumn(Name = "更新SD")]
        [ExcelColumnName("更新SD")]

        public string Ma042 { get; set; }

        //[ExcelColumn(Name = "外部公司代码")]
        [ExcelColumnName("外部公司代码")]

        public string Ma043 { get; set; }

        //[ExcelColumn(Name = "原始码")]
        [ExcelColumnName("原始码")]

        public string Ma044 { get; set; }

        //[ExcelColumn(Name = "法定科目表")]
        [ExcelColumnName("法定科目表")]

        public string Ma045 { get; set; }

        //[ExcelColumn(Name = "税组")]
        [ExcelColumnName("税组")]

        public string Ma046 { get; set; }

        //[ExcelColumn(Name = "全球公司代码")]
        [ExcelColumnName("全球公司代码")]

        public string Ma047 { get; set; }

        //[ExcelColumn(Name = "字段状态变式")]
        [ExcelColumnName("字段状态变式")]

        public string Ma048 { get; set; }

        //[ExcelColumn(Name = "记帐期间变式")]
        [ExcelColumnName("记帐期间变式")]

        public string Ma049 { get; set; }

        //[ExcelColumn(Name = "套期请求")]
        [ExcelColumnName("套期请求")]

        public string Ma050 { get; set; }

        //[ExcelColumn(Name = "外币换算税金")]
        [ExcelColumnName("外币换算税金")]

        public string Ma051 { get; set; }

        //[ExcelColumn(Name = "工作流变式")]
        [ExcelColumnName("工作流变式")]

        public string Ma052 { get; set; }

        //[ExcelColumn(Name = "库存管理")]
        [ExcelColumnName("库存管理")]

        public string Ma053 { get; set; }

        //[ExcelColumn(Name = "采购订单")]
        [ExcelColumnName("采购订单")]

        public string Ma054 { get; set; }

        //[ExcelColumn(Name = "采购申请")]
        [ExcelColumnName("采购申请")]

        public string Ma055 { get; set; }

        //[ExcelColumn(Name = "合同")]
        [ExcelColumnName("合同")]

        public string Ma056 { get; set; }

        //[ExcelColumn(Name = "税金确定")]
        [ExcelColumnName("税金确定")]

        public string Ma057 { get; set; }

        //[ExcelColumn(Name = "进项税码")]
        [ExcelColumnName("进项税码")]

        public string Ma058 { get; set; }

        //[ExcelColumn(Name = "销项税码")]
        [ExcelColumnName("销项税码")]

        public string Ma059 { get; set; }

        //[ExcelColumn(Name = "进口数据")]
        [ExcelColumnName("进口数据")]

        public string Ma060 { get; set; }

        //[ExcelColumn(Name = "允许负数记帐")]
        [ExcelColumnName("允许负数记帐")]

        public string Ma061 { get; set; }

        //[ExcelColumn(Name = "信用控制范围")]
        [ExcelColumnName("信用控制范围")]

        public string Ma062 { get; set; }

        //[ExcelColumn(Name = "预扣税")]
        [ExcelColumnName("预扣税")]

        public string Ma063 { get; set; }

        //[ExcelColumn(Name = "记帐日期")]
        [ExcelColumnName("记帐日期")]

        public string Ma064 { get; set; }

        //[ExcelColumn(Name = "通货膨胀方法")]
        [ExcelColumnName("通货膨胀方法")]

        public string Ma065 { get; set; }

        //[ExcelColumn(Name = "字段状态变式")]
        [ExcelColumnName("字段状态变式")]

        public string Ma066 { get; set; }

        //[ExcelColumn(Name = "复制控制GR")]
        [ExcelColumnName("复制控制GR")]

        public string Ma067 { get; set; }

        //[ExcelColumn(Name = "收货进口控制")]
        [ExcelColumnName("收货进口控制")]

        public string Ma068 { get; set; }

        //[ExcelColumn(Name = "冲销科目方法")]
        [ExcelColumnName("冲销科目方法")]

        public int? Ma069 { get; set; }

        //[ExcelColumn(Name = "BA变式")]
        [ExcelColumnName("BA变式")]

        public string Ma070 { get; set; }

        //[ExcelColumn(Name = "销售会计核算")]
        [ExcelColumnName("销售会计核算")]

        public string Ma071 { get; set; }

        //[ExcelColumn(Name = "应收科目抵押激活")]
        [ExcelColumnName("应收科目抵押激活")]

        public string Ma072 { get; set; }

        //[ExcelColumn(Name = "可行的金额划分")]
        [ExcelColumnName("可行的金额划分")]

        public string Ma073 { get; set; }

        //[ExcelColumn(Name = "附加费计算方法")]
        [ExcelColumnName("附加费计算方法")]

        public string Ma074 { get; set; }

        //[ExcelColumn(Name = "征税类别")]
        [ExcelColumnName("征税类别")]

        public string Ma075 { get; set; }

        //[ExcelColumn(Name = "金额更正")]
        [ExcelColumnName("金额更正")]

        public string Ma076 { get; set; }

        //[ExcelColumn(Name = "税码更正")]
        [ExcelColumnName("税码更正")]

        public string Ma077 { get; set; }

        //[ExcelColumn(Name = "汇款文件类型")]
        [ExcelColumnName("汇款文件类型")]

        public string Ma078 { get; set; }

        //[ExcelColumn(Name = "递延税规则")]
        [ExcelColumnName("递延税规则")]

        public string Ma079 { get; set; }

        //[ExcelColumn(Name = "报税日期")]
        [ExcelColumnName("报税日期")]

        public string Ma080 { get; set; }

        //[ExcelColumn(Name = "过帐期间变式")]
        [ExcelColumnName("过帐期间变式")]

        public string Ma081 { get; set; }

        //[ExcelColumn(Name = "购物车")]
        [ExcelColumnName("购物车")]

        public string Ma082 { get; set; }

        //[ExcelColumn(Name = "基金管理分配")]
        [ExcelColumnName("基金管理分配")]

        public string Ma083 { get; set; }

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
        public string Ma003Label { get; set; }
        [ExcelColumn(Name = "类别")]
        public string Ma004Label { get; set; }
        [ExcelColumn(Name = "国家")]
        public string Ma009Label { get; set; }
        [ExcelColumn(Name = "货币码")]
        public string Ma010Label { get; set; }
        [ExcelColumn(Name = "语言")]
        public string Ma011Label { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 公司代码
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 10:19:56
    /// </summary>
    public class InstCorpImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "集团不能为空")]
        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Ma002 { get; set; }

        [Required(ErrorMessage = "性质不能为空")]
        //[ExcelColumn(Name = "性质")]
        [ExcelColumnName("性质")]
        public string Ma003 { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        //[ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string Ma004 { get; set; }

        [Required(ErrorMessage = "代码不能为空")]
        //[ExcelColumn(Name = "代码")]
        [ExcelColumnName("代码")]
        public string Ma005 { get; set; }

        //[ExcelColumn(Name = "简称")]
        [ExcelColumnName("简称")]
        public string Ma006 { get; set; }

        //[ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string Ma007 { get; set; }

        //[ExcelColumn(Name = "国家")]
        [ExcelColumnName("国家")]
        public string Ma009 { get; set; }

        //[ExcelColumn(Name = "城市")]
        [ExcelColumnName("城市")]
        public string Ma008 { get; set; }

        //[ExcelColumn(Name = "货币码")]
        [ExcelColumnName("货币码")]
        public string Ma010 { get; set; }

        //[ExcelColumn(Name = "语言")]
        [ExcelColumnName("语言")]
        public string Ma011 { get; set; }

        //[ExcelColumn(Name = "帐目表")]
        [ExcelColumnName("帐目表")]
        public string Ma012 { get; set; }

        //[ExcelColumn(Name = "最大汇率偏差")]
        [ExcelColumnName("最大汇率偏差")]
        public int? Ma013 { get; set; }

        //[ExcelColumn(Name = "会计年度变式")]
        [ExcelColumnName("会计年度变式")]
        public string Ma014 { get; set; }

        //[ExcelColumn(Name = "分配标识符")]
        [ExcelColumnName("分配标识符")]
        public string Ma015 { get; set; }

        //[ExcelColumn(Name = "公司简称")]
        [ExcelColumnName("公司简称")]
        public string Ma016 { get; set; }

        //[ExcelColumn(Name = "地址")]
        [ExcelColumnName("地址")]
        public string Ma017 { get; set; }

        //[ExcelColumn(Name = "增值税登记号")]
        [ExcelColumnName("增值税登记号")]
        public string Ma018 { get; set; }

        //[ExcelColumn(Name = "财务管理范围")]
        [ExcelColumnName("财务管理范围")]
        public string Ma019 { get; set; }

        //[ExcelColumn(Name = "现金管理项目")]
        [ExcelColumnName("现金管理项目")]
        public string Ma020 { get; set; }

        //[ExcelColumn(Name = "现金预算管理")]
        [ExcelColumnName("现金预算管理")]
        public string Ma021 { get; set; }

        //[ExcelColumn(Name = "资金管理更新")]
        [ExcelColumnName("资金管理更新")]
        public string Ma022 { get; set; }

        //[ExcelColumn(Name = "地区税务代码")]
        [ExcelColumnName("地区税务代码")]
        public string Ma023 { get; set; }

        //[ExcelColumn(Name = "基金分配科目", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("基金分配科目")]
        public DateTime? Ma024 { get; set; }

        //[ExcelColumn(Name = "公司变式")]
        [ExcelColumnName("公司变式")]
        public string Ma025 { get; set; }

        //[ExcelColumn(Name = "预测公司")]
        [ExcelColumnName("预测公司")]
        public string Ma026 { get; set; }

        //[ExcelColumn(Name = "现金管理")]
        [ExcelColumnName("现金管理")]
        public string Ma027 { get; set; }

        //[ExcelColumn(Name = "起息日")]
        [ExcelColumnName("起息日")]
        public string Ma028 { get; set; }

        //[ExcelColumn(Name = "折扣金额净值")]
        [ExcelColumnName("折扣金额净值")]
        public string Ma029 { get; set; }

        //[ExcelColumn(Name = "贷方控制范围")]
        [ExcelColumnName("贷方控制范围")]
        public string Ma030 { get; set; }

        //[ExcelColumn(Name = "净折扣额")]
        [ExcelColumnName("净折扣额")]
        public string Ma031 { get; set; }

        //[ExcelColumn(Name = "从样本科目复制")]
        [ExcelColumnName("从样本科目复制")]
        public string Ma032 { get; set; }

        //[ExcelColumn(Name = "业务部门资产负债表")]
        [ExcelColumnName("业务部门资产负债表")]
        public string Ma033 { get; set; }

        //[ExcelColumn(Name = "建议会计年度")]
        [ExcelColumnName("建议会计年度")]
        public string Ma034 { get; set; }

        //[ExcelColumn(Name = "外向换算记帐")]
        [ExcelColumnName("外向换算记帐")]
        public string Ma035 { get; set; }

        //[ExcelColumn(Name = "生产公司代码")]
        [ExcelColumnName("生产公司代码")]
        public string Ma036 { get; set; }

        //[ExcelColumn(Name = "采购科目")]
        [ExcelColumnName("采购科目")]
        public string Ma037 { get; set; }

        //[ExcelColumn(Name = "联营公司会计")]
        [ExcelColumnName("联营公司会计")]
        public string Ma038 { get; set; }

        //[ExcelColumn(Name = "金融资产管理")]
        [ExcelColumnName("金融资产管理")]
        public string Ma039 { get; set; }

        //[ExcelColumn(Name = "汇率差额")]
        [ExcelColumnName("汇率差额")]
        public string Ma040 { get; set; }

        //[ExcelColumn(Name = "更新MM")]
        [ExcelColumnName("更新MM")]
        public string Ma041 { get; set; }

        //[ExcelColumn(Name = "更新SD")]
        [ExcelColumnName("更新SD")]
        public string Ma042 { get; set; }

        //[ExcelColumn(Name = "外部公司代码")]
        [ExcelColumnName("外部公司代码")]
        public string Ma043 { get; set; }

        //[ExcelColumn(Name = "原始码")]
        [ExcelColumnName("原始码")]
        public string Ma044 { get; set; }

        //[ExcelColumn(Name = "法定科目表")]
        [ExcelColumnName("法定科目表")]
        public string Ma045 { get; set; }

        //[ExcelColumn(Name = "税组")]
        [ExcelColumnName("税组")]
        public string Ma046 { get; set; }

        //[ExcelColumn(Name = "全球公司代码")]
        [ExcelColumnName("全球公司代码")]
        public string Ma047 { get; set; }

        //[ExcelColumn(Name = "字段状态变式")]
        [ExcelColumnName("字段状态变式")]
        public string Ma048 { get; set; }

        //[ExcelColumn(Name = "记帐期间变式")]
        [ExcelColumnName("记帐期间变式")]
        public string Ma049 { get; set; }

        //[ExcelColumn(Name = "套期请求")]
        [ExcelColumnName("套期请求")]
        public string Ma050 { get; set; }

        //[ExcelColumn(Name = "外币换算税金")]
        [ExcelColumnName("外币换算税金")]
        public string Ma051 { get; set; }

        //[ExcelColumn(Name = "工作流变式")]
        [ExcelColumnName("工作流变式")]
        public string Ma052 { get; set; }

        //[ExcelColumn(Name = "库存管理")]
        [ExcelColumnName("库存管理")]
        public string Ma053 { get; set; }

        //[ExcelColumn(Name = "采购订单")]
        [ExcelColumnName("采购订单")]
        public string Ma054 { get; set; }

        //[ExcelColumn(Name = "采购申请")]
        [ExcelColumnName("采购申请")]
        public string Ma055 { get; set; }

        //[ExcelColumn(Name = "合同")]
        [ExcelColumnName("合同")]
        public string Ma056 { get; set; }

        //[ExcelColumn(Name = "税金确定")]
        [ExcelColumnName("税金确定")]
        public string Ma057 { get; set; }

        //[ExcelColumn(Name = "进项税码")]
        [ExcelColumnName("进项税码")]
        public string Ma058 { get; set; }

        //[ExcelColumn(Name = "销项税码")]
        [ExcelColumnName("销项税码")]
        public string Ma059 { get; set; }

        //[ExcelColumn(Name = "进口数据")]
        [ExcelColumnName("进口数据")]
        public string Ma060 { get; set; }

        //[ExcelColumn(Name = "允许负数记帐")]
        [ExcelColumnName("允许负数记帐")]
        public string Ma061 { get; set; }

        //[ExcelColumn(Name = "信用控制范围")]
        [ExcelColumnName("信用控制范围")]
        public string Ma062 { get; set; }

        //[ExcelColumn(Name = "预扣税")]
        [ExcelColumnName("预扣税")]
        public string Ma063 { get; set; }

        //[ExcelColumn(Name = "记帐日期")]
        [ExcelColumnName("记帐日期")]
        public string Ma064 { get; set; }

        //[ExcelColumn(Name = "通货膨胀方法")]
        [ExcelColumnName("通货膨胀方法")]
        public string Ma065 { get; set; }

        //[ExcelColumn(Name = "字段状态变式")]
        [ExcelColumnName("字段状态变式")]
        public string Ma066 { get; set; }

        //[ExcelColumn(Name = "复制控制GR")]
        [ExcelColumnName("复制控制GR")]
        public string Ma067 { get; set; }

        //[ExcelColumn(Name = "收货进口控制")]
        [ExcelColumnName("收货进口控制")]
        public string Ma068 { get; set; }

        //[ExcelColumn(Name = "冲销科目方法")]
        [ExcelColumnName("冲销科目方法")]
        public int? Ma069 { get; set; }

        //[ExcelColumn(Name = "BA变式")]
        [ExcelColumnName("BA变式")]
        public string Ma070 { get; set; }

        //[ExcelColumn(Name = "销售会计核算")]
        [ExcelColumnName("销售会计核算")]
        public string Ma071 { get; set; }

        //[ExcelColumn(Name = "应收科目抵押激活")]
        [ExcelColumnName("应收科目抵押激活")]
        public string Ma072 { get; set; }

        //[ExcelColumn(Name = "可行的金额划分")]
        [ExcelColumnName("可行的金额划分")]
        public string Ma073 { get; set; }

        //[ExcelColumn(Name = "附加费计算方法")]
        [ExcelColumnName("附加费计算方法")]
        public string Ma074 { get; set; }

        //[ExcelColumn(Name = "征税类别")]
        [ExcelColumnName("征税类别")]
        public string Ma075 { get; set; }

        //[ExcelColumn(Name = "金额更正")]
        [ExcelColumnName("金额更正")]
        public string Ma076 { get; set; }

        //[ExcelColumn(Name = "税码更正")]
        [ExcelColumnName("税码更正")]
        public string Ma077 { get; set; }

        //[ExcelColumn(Name = "汇款文件类型")]
        [ExcelColumnName("汇款文件类型")]
        public string Ma078 { get; set; }

        //[ExcelColumn(Name = "递延税规则")]
        [ExcelColumnName("递延税规则")]
        public string Ma079 { get; set; }

        //[ExcelColumn(Name = "报税日期")]
        [ExcelColumnName("报税日期")]
        public string Ma080 { get; set; }

        //[ExcelColumn(Name = "过帐期间变式")]
        [ExcelColumnName("过帐期间变式")]
        public string Ma081 { get; set; }

        //[ExcelColumn(Name = "购物车")]
        [ExcelColumnName("购物车")]
        public string Ma082 { get; set; }

        //[ExcelColumn(Name = "基金管理分配")]
        [ExcelColumnName("基金管理分配")]
        public string Ma083 { get; set; }

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
        public string Ma003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "类别")]
        public string Ma004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "国家")]
        public string Ma009Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "货币码")]
        public string Ma010Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "语言")]
        public string Ma011Label { get; set; }
    }

}