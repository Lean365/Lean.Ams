
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 月度存货
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:55:10
    /// </summary>
    public class FicoMonthlyInventoryQueryDto : PagerInfo 
    {
        /// <summary>
        /// 期间 
        /// </summary>        
        public string Mp002 { get; set; }
        /// <summary>
        /// 年月 
        /// </summary>        
        public string Mp003 { get; set; }
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Mp004 { get; set; }
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Mp005 { get; set; }
    }

    /// <summary>
    /// 月度存货
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:55:10
    /// </summary>
    public class FicoMonthlyInventoryDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]

        public string Mp002 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]

        public string Mp003 { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Mp004 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Mp005 { get; set; }

        //[ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]

        public string Mp006 { get; set; }

        //[ExcelColumn(Name = "价格控制")]
        [ExcelColumnName("价格控制")]

        public string Mp007 { get; set; }

        //[ExcelColumn(Name = "移动平均价")]
        [ExcelColumnName("移动平均价")]

        public decimal Mp008 { get; set; }

        [Required(ErrorMessage = "Per单位不能为空")]
        //[ExcelColumn(Name = "Per单位")]
        [ExcelColumnName("Per单位")]

        public int Mp009 { get; set; }

        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]

        public string Mp010 { get; set; }

        //[ExcelColumn(Name = "库存")]
        [ExcelColumnName("库存")]

        public decimal Mp011 { get; set; }

        //[ExcelColumn(Name = "金额")]
        [ExcelColumnName("金额")]

        public decimal Mp012 { get; set; }

        //[ExcelColumn(Name = "核算人员")]
        [ExcelColumnName("核算人员")]

        public string Mp013 { get; set; }

        //[ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("核算日期")]

        public DateTime? Mp014 { get; set; }

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

        public string Remark { get; set; }

        [ExcelIgnore]

        public int? IsDeleted { get; set; }

        [ExcelIgnore]

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "期间")]
        public string Mp002Label { get; set; }
        [ExcelColumn(Name = "年月")]
        public string Mp003Label { get; set; }
        [ExcelColumn(Name = "工厂")]
        public string Mp004Label { get; set; }
    }

    /// <summary>
    /// 月度存货
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:55:10
    /// </summary>
    public class FicoMonthlyInventoryImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string Mp002 { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string Mp003 { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Mp004 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Mp005 { get; set; }

        //[ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]
        public string Mp006 { get; set; }

        //[ExcelColumn(Name = "价格控制")]
        [ExcelColumnName("价格控制")]
        public string Mp007 { get; set; }

        //[ExcelColumn(Name = "移动平均价")]
        [ExcelColumnName("移动平均价")]
        public decimal Mp008 { get; set; }

        [Required(ErrorMessage = "Per单位不能为空")]
        //[ExcelColumn(Name = "Per单位")]
        [ExcelColumnName("Per单位")]
        public int Mp009 { get; set; }

        //[ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string Mp010 { get; set; }

        //[ExcelColumn(Name = "库存")]
        [ExcelColumnName("库存")]
        public decimal Mp011 { get; set; }

        //[ExcelColumn(Name = "金额")]
        [ExcelColumnName("金额")]
        public decimal Mp012 { get; set; }

        //[ExcelColumn(Name = "核算人员")]
        [ExcelColumnName("核算人员")]
        public string Mp013 { get; set; }

        //[ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("核算日期")]
        public DateTime? Mp014 { get; set; }

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
        public string Remark { get; set; }

        [ExcelIgnore]
        public int? IsDeleted { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "期间")]
        public string Mp002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string Mp003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string Mp004Label { get; set; }
    }

}