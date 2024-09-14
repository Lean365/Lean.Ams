
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 利润中心
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:42:56
    /// </summary>
    public class FicoProfitCenterQueryDto : PagerInfo 
    {
        /// <summary>
        /// 利润中心 
        /// </summary>        
        public string Mq003 { get; set; }
        /// <summary>
        /// 控制范围 
        /// </summary>        
        public string Mq004 { get; set; }
        /// <summary>
        /// 名称 
        /// </summary>        
        public string Mq010 { get; set; }
    }

    /// <summary>
    /// 利润中心
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:42:56
    /// </summary>
    public class FicoProfitCenterDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]

        public string Mq002 { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        //[ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]

        public string Mq003 { get; set; }

        //[ExcelColumn(Name = "控制范围")]
        [ExcelColumnName("控制范围")]

        public string Mq004 { get; set; }

        //[ExcelColumn(Name = "开始生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("开始生效日期")]

        public DateTime? Mq005 { get; set; }

        //[ExcelColumn(Name = "有效截至日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效截至日期")]

        public DateTime? Mq006 { get; set; }

        //[ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]

        public int? Mq007 { get; set; }

        //[ExcelColumn(Name = "负责人")]
        [ExcelColumnName("负责人")]

        public string Mq008 { get; set; }

        //[ExcelColumn(Name = "货币")]
        [ExcelColumnName("货币")]

        public string Mq009 { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        //[ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]

        public string Mq010 { get; set; }

        //[ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]

        public string Mq011 { get; set; }

        //[ExcelColumn(Name = "利润中心说明")]
        [ExcelColumnName("利润中心说明")]

        public string Mq012 { get; set; }

        //[ExcelColumn(Name = "利润中心组")]
        [ExcelColumnName("利润中心组")]

        public string Mq013 { get; set; }

        //[ExcelColumn(Name = "权益类型")]
        [ExcelColumnName("权益类型")]

        public string Mq014 { get; set; }

        //[ExcelColumn(Name = "地区税务代码")]
        [ExcelColumnName("地区税务代码")]

        public string Mq015 { get; set; }

        //[ExcelColumn(Name = "锁定标记")]
        [ExcelColumnName("锁定标记")]

        public int? Mq016 { get; set; }

        //[ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]

        public int? Mq017 { get; set; }

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



        [ExcelColumn(Name = "控制范围")]
        public string Mq004Label { get; set; }
        [ExcelColumn(Name = "货币")]
        public string Mq009Label { get; set; }
        [ExcelColumn(Name = "锁定标记")]
        public string Mq016Label { get; set; }
        [ExcelColumn(Name = "状态")]
        public string Mq017Label { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 利润中心
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:42:56
    /// </summary>
    public class FicoProfitCenterImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        //[ExcelColumn(Name = "集团")]
        [ExcelColumnName("集团")]
        public string Mq002 { get; set; }

        [Required(ErrorMessage = "利润中心不能为空")]
        //[ExcelColumn(Name = "利润中心")]
        [ExcelColumnName("利润中心")]
        public string Mq003 { get; set; }

        //[ExcelColumn(Name = "控制范围")]
        [ExcelColumnName("控制范围")]
        public string Mq004 { get; set; }

        //[ExcelColumn(Name = "开始生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("开始生效日期")]
        public DateTime? Mq005 { get; set; }

        //[ExcelColumn(Name = "有效截至日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("有效截至日期")]
        public DateTime? Mq006 { get; set; }

        //[ExcelColumn(Name = "部门")]
        [ExcelColumnName("部门")]
        public int? Mq007 { get; set; }

        //[ExcelColumn(Name = "负责人")]
        [ExcelColumnName("负责人")]
        public string Mq008 { get; set; }

        //[ExcelColumn(Name = "货币")]
        [ExcelColumnName("货币")]
        public string Mq009 { get; set; }

        [Required(ErrorMessage = "名称不能为空")]
        //[ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string Mq010 { get; set; }

        //[ExcelColumn(Name = "长文本")]
        [ExcelColumnName("长文本")]
        public string Mq011 { get; set; }

        //[ExcelColumn(Name = "利润中心说明")]
        [ExcelColumnName("利润中心说明")]
        public string Mq012 { get; set; }

        //[ExcelColumn(Name = "利润中心组")]
        [ExcelColumnName("利润中心组")]
        public string Mq013 { get; set; }

        //[ExcelColumn(Name = "权益类型")]
        [ExcelColumnName("权益类型")]
        public string Mq014 { get; set; }

        //[ExcelColumn(Name = "地区税务代码")]
        [ExcelColumnName("地区税务代码")]
        public string Mq015 { get; set; }

        //[ExcelColumn(Name = "锁定标记")]
        [ExcelColumnName("锁定标记")]
        public int? Mq016 { get; set; }

        //[ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public int? Mq017 { get; set; }

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
        [ExcelColumn(Name = "控制范围")]
        public string Mq004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "货币")]
        public string Mq009Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "锁定标记")]
        public string Mq016Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "状态")]
        public string Mq017Label { get; set; }
    }

}