
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// QC客诉
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:13:49
    /// </summary>
    public class QmComplaintsQcQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂代码 
        /// </summary>        
        public string Mb002 { get; set; }
        /// <summary>
        /// 客诉No. 
        /// </summary>        
        public string Mb003 { get; set; }
        /// <summary>
        /// 外部客诉No. 
        /// </summary>        
        public string Mb004 { get; set; }
        /// <summary>
        /// 客户 
        /// </summary>        
        public string Mb005 { get; set; }
        /// <summary>
        /// 机种 
        /// </summary>        
        public string Mb006 { get; set; }
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Mb007 { get; set; }
        /// <summary>
        /// 接收日期 
        /// </summary>        
        public DateTime? BeginMb010 { get; set; }
        public DateTime? EndMb010 { get; set; }
    }

    /// <summary>
    /// QC客诉
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:13:49
    /// </summary>
    public class QmComplaintsQcDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "工厂代码不能为空")]
        //[ExcelColumn(Name = "工厂代码")]
        [ExcelColumnName("工厂代码")]

        public string Mb002 { get; set; }

        [Required(ErrorMessage = "客诉No.不能为空")]
        //[ExcelColumn(Name = "客诉No.")]
        [ExcelColumnName("客诉No.")]

        public string Mb003 { get; set; }

        [Required(ErrorMessage = "外部客诉No.不能为空")]
        //[ExcelColumn(Name = "外部客诉No.")]
        [ExcelColumnName("外部客诉No.")]

        public string Mb004 { get; set; }

        [Required(ErrorMessage = "客户不能为空")]
        //[ExcelColumn(Name = "客户")]
        [ExcelColumnName("客户")]

        public string Mb005 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]

        public string Mb006 { get; set; }

        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Mb007 { get; set; }

        //[ExcelColumn(Name = "仕向")]
        [ExcelColumnName("仕向")]

        public string Mb008 { get; set; }

        //[ExcelColumn(Name = "订单")]
        [ExcelColumnName("订单")]

        public string Mb009 { get; set; }

        //[ExcelColumn(Name = "接收日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("接收日期")]

        public DateTime? Mb010 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]

        public int Mb011 { get; set; }

        //[ExcelColumn(Name = "投诉事项")]
        [ExcelColumnName("投诉事项")]

        public string Mb012 { get; set; }

        //[ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]

        public string Mb013 { get; set; }

        //[ExcelColumn(Name = "参考文件")]
        [ExcelColumnName("参考文件")]

        public string Mb014 { get; set; }

        //[ExcelColumn(Name = "症状")]
        [ExcelColumnName("症状")]

        public string Mb015 { get; set; }

        //[ExcelColumn(Name = "分析")]
        [ExcelColumnName("分析")]

        public string Mb016 { get; set; }

        //[ExcelColumn(Name = "承认部门")]
        [ExcelColumnName("承认部门")]

        public string Mb017 { get; set; }

        //[ExcelColumn(Name = "承认日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("承认日期")]

        public DateTime? Mb018 { get; set; }

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



        [ExcelColumn(Name = "工厂代码")]
        public string Mb002Label { get; set; }
        [ExcelColumn(Name = "客户")]
        public string Mb005Label { get; set; }
        [ExcelColumn(Name = "机种")]
        public string Mb006Label { get; set; }
        [ExcelColumn(Name = "物料")]
        public string Mb007Label { get; set; }
        [ExcelColumn(Name = "承认部门")]
        public string Mb017Label { get; set; }
    }

    /// <summary>
    /// QC客诉
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:13:49
    /// </summary>
    public class QmComplaintsQcImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "工厂代码不能为空")]
        //[ExcelColumn(Name = "工厂代码")]
        [ExcelColumnName("工厂代码")]
        public string Mb002 { get; set; }

        [Required(ErrorMessage = "客诉No.不能为空")]
        //[ExcelColumn(Name = "客诉No.")]
        [ExcelColumnName("客诉No.")]
        public string Mb003 { get; set; }

        [Required(ErrorMessage = "外部客诉No.不能为空")]
        //[ExcelColumn(Name = "外部客诉No.")]
        [ExcelColumnName("外部客诉No.")]
        public string Mb004 { get; set; }

        [Required(ErrorMessage = "客户不能为空")]
        //[ExcelColumn(Name = "客户")]
        [ExcelColumnName("客户")]
        public string Mb005 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Mb006 { get; set; }

        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Mb007 { get; set; }

        //[ExcelColumn(Name = "仕向")]
        [ExcelColumnName("仕向")]
        public string Mb008 { get; set; }

        //[ExcelColumn(Name = "订单")]
        [ExcelColumnName("订单")]
        public string Mb009 { get; set; }

        //[ExcelColumn(Name = "接收日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("接收日期")]
        public DateTime? Mb010 { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        //[ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public int Mb011 { get; set; }

        //[ExcelColumn(Name = "投诉事项")]
        [ExcelColumnName("投诉事项")]
        public string Mb012 { get; set; }

        //[ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string Mb013 { get; set; }

        //[ExcelColumn(Name = "参考文件")]
        [ExcelColumnName("参考文件")]
        public string Mb014 { get; set; }

        //[ExcelColumn(Name = "症状")]
        [ExcelColumnName("症状")]
        public string Mb015 { get; set; }

        //[ExcelColumn(Name = "分析")]
        [ExcelColumnName("分析")]
        public string Mb016 { get; set; }

        //[ExcelColumn(Name = "承认部门")]
        [ExcelColumnName("承认部门")]
        public string Mb017 { get; set; }

        //[ExcelColumn(Name = "承认日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("承认日期")]
        public DateTime? Mb018 { get; set; }

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
        [ExcelColumn(Name = "工厂代码")]
        public string Mb002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "客户")]
        public string Mb005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "机种")]
        public string Mb006Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "物料")]
        public string Mb007Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "承认部门")]
        public string Mb017Label { get; set; }
    }

}