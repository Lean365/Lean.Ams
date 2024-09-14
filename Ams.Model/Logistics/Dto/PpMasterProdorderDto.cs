
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 生产工单
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 12:05:47
    /// </summary>
    public class PpMasterProdorderQueryDto : PagerInfo 
    {
        /// <summary>
        /// 生产工厂 
        /// </summary>        
        public string Mc002 { get; set; }
        /// <summary>
        /// 订单类型 
        /// </summary>        
        public string Mc003 { get; set; }
        /// <summary>
        /// 订单号码 
        /// </summary>        
        public string Mc004 { get; set; }
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Mc005 { get; set; }
        /// <summary>
        /// 状态 
        /// </summary>        
        public int? Mc012 { get; set; }
    }

    /// <summary>
    /// 生产工单
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 12:05:47
    /// </summary>
    public class PpMasterProdorderDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "生产工厂不能为空")]
        //[ExcelColumn(Name = "生产工厂")]
        [ExcelColumnName("生产工厂")]

        public string Mc002 { get; set; }

        [Required(ErrorMessage = "订单类型不能为空")]
        //[ExcelColumn(Name = "订单类型")]
        [ExcelColumnName("订单类型")]

        public string Mc003 { get; set; }

        //[ExcelColumn(Name = "订单号码")]
        [ExcelColumnName("订单号码")]

        public string Mc004 { get; set; }

        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Mc005 { get; set; }

        //[ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]

        public string Mc006 { get; set; }

        //[ExcelColumn(Name = "工单数量")]
        [ExcelColumnName("工单数量")]

        public decimal Mc007 { get; set; }

        //[ExcelColumn(Name = "生产数量")]
        [ExcelColumnName("生产数量")]

        public decimal Mc008 { get; set; }

        //[ExcelColumn(Name = "订单日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("订单日期")]

        public DateTime? Mc009 { get; set; }

        //[ExcelColumn(Name = "工艺路线")]
        [ExcelColumnName("工艺路线")]

        public string Mc010 { get; set; }

        //[ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]

        public string Mc011 { get; set; }

        [Required(ErrorMessage = "状态不能为空")]
        //[ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]

        public int Mc012 { get; set; }

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



        [ExcelColumn(Name = "生产工厂")]
        public string Mc002Label { get; set; }
        [ExcelColumn(Name = "订单类型")]
        public string Mc003Label { get; set; }
        [ExcelColumn(Name = "物料")]
        public string Mc005Label { get; set; }
        [ExcelColumn(Name = "状态")]
        public string Mc012Label { get; set; }
    }

    /// <summary>
    /// 生产工单
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 12:05:47
    /// </summary>
    public class PpMasterProdorderImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "生产工厂不能为空")]
        //[ExcelColumn(Name = "生产工厂")]
        [ExcelColumnName("生产工厂")]
        public string Mc002 { get; set; }

        [Required(ErrorMessage = "订单类型不能为空")]
        //[ExcelColumn(Name = "订单类型")]
        [ExcelColumnName("订单类型")]
        public string Mc003 { get; set; }

        //[ExcelColumn(Name = "订单号码")]
        [ExcelColumnName("订单号码")]
        public string Mc004 { get; set; }

        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Mc005 { get; set; }

        //[ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string Mc006 { get; set; }

        //[ExcelColumn(Name = "工单数量")]
        [ExcelColumnName("工单数量")]
        public decimal Mc007 { get; set; }

        //[ExcelColumn(Name = "生产数量")]
        [ExcelColumnName("生产数量")]
        public decimal Mc008 { get; set; }

        //[ExcelColumn(Name = "订单日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("订单日期")]
        public DateTime? Mc009 { get; set; }

        //[ExcelColumn(Name = "工艺路线")]
        [ExcelColumnName("工艺路线")]
        public string Mc010 { get; set; }

        //[ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string Mc011 { get; set; }

        [Required(ErrorMessage = "状态不能为空")]
        //[ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public int Mc012 { get; set; }

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
        [ExcelColumn(Name = "生产工厂")]
        public string Mc002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "订单类型")]
        public string Mc003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "物料")]
        public string Mc005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "状态")]
        public string Mc012Label { get; set; }
    }

}