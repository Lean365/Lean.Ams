
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 源订单
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:05:57
    /// </summary>
    public class PpSourceOrderQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Zf002 { get; set; }
        /// <summary>
        /// 生产订单 
        /// </summary>        
        public string Zf004 { get; set; }
        /// <summary>
        /// 品号 
        /// </summary>        
        public string Zf005 { get; set; }
    }

    /// <summary>
    /// 源订单
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:05:57
    /// </summary>
    public class PpSourceOrderDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Zf002 { get; set; }

        [Required(ErrorMessage = "订单类型不能为空")]
        //[ExcelColumn(Name = "订单类型")]
        [ExcelColumnName("订单类型")]

        public string Zf003 { get; set; }

        [Required(ErrorMessage = "生产订单不能为空")]
        //[ExcelColumn(Name = "生产订单")]
        [ExcelColumnName("生产订单")]

        public string Zf004 { get; set; }

        [Required(ErrorMessage = "品号不能为空")]
        //[ExcelColumn(Name = "品号")]
        [ExcelColumnName("品号")]

        public string Zf005 { get; set; }

        //[ExcelColumn(Name = "LOT")]
        [ExcelColumnName("LOT")]

        public string Zf006 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]

        public decimal Zf007 { get; set; }

        [Required(ErrorMessage = "已生产不能为空")]
        //[ExcelColumn(Name = "已生产")]
        [ExcelColumnName("已生产")]

        public decimal Zf008 { get; set; }

        //[ExcelColumn(Name = "开始日期")]
        [ExcelColumnName("开始日期")]

        public string Zf009 { get; set; }

        //[ExcelColumn(Name = "作业手顺")]
        [ExcelColumnName("作业手顺")]

        public string Zf010 { get; set; }

        [ExcelIgnore]

        public string Ref01 { get; set; }

        [ExcelIgnore]

        public string Ref02 { get; set; }

        [ExcelIgnore]

        public string Ref03 { get; set; }

        [Required(ErrorMessage = "预留1不能为空")]
        [ExcelIgnore]

        public decimal Ref04 { get; set; }

        [Required(ErrorMessage = "预留2不能为空")]
        [ExcelIgnore]

        public decimal Ref05 { get; set; }

        [Required(ErrorMessage = "预留3不能为空")]
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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]

        public int Udf51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]

        public int Udf52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]

        public int Udf53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]

        public decimal Udf54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]

        public decimal Udf55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
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
        public string Zf002Label { get; set; }
    }

    /// <summary>
    /// 源订单
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:05:57
    /// </summary>
    public class PpSourceOrderImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Zf002 { get; set; }

        [Required(ErrorMessage = "订单类型不能为空")]
        //[ExcelColumn(Name = "订单类型")]
        [ExcelColumnName("订单类型")]
        public string Zf003 { get; set; }

        [Required(ErrorMessage = "生产订单不能为空")]
        //[ExcelColumn(Name = "生产订单")]
        [ExcelColumnName("生产订单")]
        public string Zf004 { get; set; }

        [Required(ErrorMessage = "品号不能为空")]
        //[ExcelColumn(Name = "品号")]
        [ExcelColumnName("品号")]
        public string Zf005 { get; set; }

        //[ExcelColumn(Name = "LOT")]
        [ExcelColumnName("LOT")]
        public string Zf006 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal Zf007 { get; set; }

        [Required(ErrorMessage = "已生产不能为空")]
        //[ExcelColumn(Name = "已生产")]
        [ExcelColumnName("已生产")]
        public decimal Zf008 { get; set; }

        //[ExcelColumn(Name = "开始日期")]
        [ExcelColumnName("开始日期")]
        public string Zf009 { get; set; }

        //[ExcelColumn(Name = "作业手顺")]
        [ExcelColumnName("作业手顺")]
        public string Zf010 { get; set; }

        [ExcelIgnore]
        public string Ref01 { get; set; }

        [ExcelIgnore]
        public string Ref02 { get; set; }

        [ExcelIgnore]
        public string Ref03 { get; set; }

        [Required(ErrorMessage = "预留1不能为空")]
        [ExcelIgnore]
        public decimal Ref04 { get; set; }

        [Required(ErrorMessage = "预留2不能为空")]
        [ExcelIgnore]
        public decimal Ref05 { get; set; }

        [Required(ErrorMessage = "预留3不能为空")]
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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public int Udf51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public int Udf52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public int Udf53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal Udf54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal Udf55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
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
        public string Zf002Label { get; set; }
    }

}