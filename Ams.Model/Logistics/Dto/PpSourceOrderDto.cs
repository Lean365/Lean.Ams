namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 源订单
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:20:14
    /// </summary>
    public class PpSourceOrderQueryDto : PagerInfo
    {
        public string Cooisma001 { get; set; }
        public string Cooisma009 { get; set; }
        public string Cooisma002 { get; set; }
        public string Cooisma003 { get; set; }
    }

    /// <summary>
    /// 源订单
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:20:14
    /// </summary>
    public class PpSourceOrderDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SfId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Cooisma001 { get; set; }

        [ExcelColumn(Name = "订单类型")]
        [ExcelColumnName("订单类型")]
        public string Cooisma009 { get; set; }

        [Required(ErrorMessage = "生产订单不能为空")]
        [ExcelColumn(Name = "生产订单")]
        [ExcelColumnName("生产订单")]
        public string Cooisma002 { get; set; }

        [Required(ErrorMessage = "品号不能为空")]
        [ExcelColumn(Name = "品号")]
        [ExcelColumnName("品号")]
        public string Cooisma003 { get; set; }

        [ExcelColumn(Name = "LOT")]
        [ExcelColumnName("LOT")]
        public string Cooisma004 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal Cooisma005 { get; set; }

        [Required(ErrorMessage = "已生产不能为空")]
        [ExcelColumn(Name = "已生产")]
        [ExcelColumnName("已生产")]
        public decimal Cooisma006 { get; set; }

        [ExcelColumn(Name = "开始日期")]
        [ExcelColumnName("开始日期")]
        public string Cooisma007 { get; set; }

        [ExcelColumn(Name = "作业手顺")]
        [ExcelColumnName("作业手顺")]
        public string Cooisma008 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
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
        public string Cooisma001Label { get; set; }

        [ExcelColumn(Name = "订单类型")]
        public string Cooisma009Label { get; set; }

        [ExcelColumn(Name = "品号")]
        public string Cooisma003Label { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 源订单
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:20:14
    /// </summary>
    public class PpSourceOrderImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SfId { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Cooisma001 { get; set; }

        [ExcelColumn(Name = "订单类型")]
        [ExcelColumnName("订单类型")]
        public string Cooisma009 { get; set; }

        [Required(ErrorMessage = "生产订单不能为空")]
        [ExcelColumn(Name = "生产订单")]
        [ExcelColumnName("生产订单")]
        public string Cooisma002 { get; set; }

        [Required(ErrorMessage = "品号不能为空")]
        [ExcelColumn(Name = "品号")]
        [ExcelColumnName("品号")]
        public string Cooisma003 { get; set; }

        [ExcelColumn(Name = "LOT")]
        [ExcelColumnName("LOT")]
        public string Cooisma004 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal Cooisma005 { get; set; }

        [Required(ErrorMessage = "已生产不能为空")]
        [ExcelColumn(Name = "已生产")]
        [ExcelColumnName("已生产")]
        public decimal Cooisma006 { get; set; }

        [ExcelColumn(Name = "开始日期")]
        [ExcelColumnName("开始日期")]
        public string Cooisma007 { get; set; }

        [ExcelColumn(Name = "作业手顺")]
        [ExcelColumnName("作业手顺")]
        public string Cooisma008 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
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
        public string Cooisma001Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "订单类型")]
        public string Cooisma009Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "品号")]
        public string Cooisma003Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}