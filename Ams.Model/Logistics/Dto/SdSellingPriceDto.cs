
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 销售价格
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:46:00
    /// </summary>
    public class SdSellingPriceQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Md002 { get; set; }
        /// <summary>
        /// 期间 
        /// </summary>        
        public string Md003 { get; set; }
        /// <summary>
        /// 年月 
        /// </summary>        
        public string Md004 { get; set; }
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Md005 { get; set; }
        /// <summary>
        /// 原币利润中心 
        /// </summary>        
        public string Md010 { get; set; }
    }

    /// <summary>
    /// 销售价格
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:46:00
    /// </summary>
    public class SdSellingPriceDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Md002 { get; set; }

        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]

        public string Md003 { get; set; }

        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]

        public string Md004 { get; set; }

        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Md005 { get; set; }

        //[ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]

        public string Md006 { get; set; }

        [Required(ErrorMessage = "原币价格不能为空")]
        //[ExcelColumn(Name = "原币价格")]
        [ExcelColumnName("原币价格")]

        public decimal Md007 { get; set; }

        //[ExcelColumn(Name = "原币种")]
        [ExcelColumnName("原币种")]

        public string Md008 { get; set; }

        [Required(ErrorMessage = "原币Per单位不能为空")]
        //[ExcelColumn(Name = "原币Per单位")]
        [ExcelColumnName("原币Per单位")]

        public int Md009 { get; set; }

        //[ExcelColumn(Name = "原币利润中心")]
        [ExcelColumnName("原币利润中心")]

        public string Md010 { get; set; }

        [Required(ErrorMessage = "本币价格不能为空")]
        //[ExcelColumn(Name = "本币价格")]
        [ExcelColumnName("本币价格")]

        public decimal Md011 { get; set; }

        //[ExcelColumn(Name = "本币种")]
        [ExcelColumnName("本币种")]

        public string Md012 { get; set; }

        [Required(ErrorMessage = "本币Per单位不能为空")]
        //[ExcelColumn(Name = "本币Per单位")]
        [ExcelColumnName("本币Per单位")]

        public int Md013 { get; set; }

        //[ExcelColumn(Name = "本币利润中心")]
        [ExcelColumnName("本币利润中心")]

        public string Md014 { get; set; }

        //[ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日期")]

        public DateTime? Md015 { get; set; }

        //[ExcelColumn(Name = "失效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("失效日期")]

        public DateTime? Md016 { get; set; }

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



        [ExcelColumn(Name = "工厂")]
        public string Md002Label { get; set; }
        [ExcelColumn(Name = "期间")]
        public string Md003Label { get; set; }
        [ExcelColumn(Name = "年月")]
        public string Md004Label { get; set; }
        [ExcelColumn(Name = "物料")]
        public string Md005Label { get; set; }
        [ExcelColumn(Name = "原币种")]
        public string Md008Label { get; set; }
        [ExcelColumn(Name = "原币利润中心")]
        public string Md010Label { get; set; }
    }

    /// <summary>
    /// 销售价格
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 15:46:00
    /// </summary>
    public class SdSellingPriceImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Md002 { get; set; }

        //[ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string Md003 { get; set; }

        //[ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string Md004 { get; set; }

        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Md005 { get; set; }

        //[ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]
        public string Md006 { get; set; }

        [Required(ErrorMessage = "原币价格不能为空")]
        //[ExcelColumn(Name = "原币价格")]
        [ExcelColumnName("原币价格")]
        public decimal Md007 { get; set; }

        //[ExcelColumn(Name = "原币种")]
        [ExcelColumnName("原币种")]
        public string Md008 { get; set; }

        [Required(ErrorMessage = "原币Per单位不能为空")]
        //[ExcelColumn(Name = "原币Per单位")]
        [ExcelColumnName("原币Per单位")]
        public int Md009 { get; set; }

        //[ExcelColumn(Name = "原币利润中心")]
        [ExcelColumnName("原币利润中心")]
        public string Md010 { get; set; }

        [Required(ErrorMessage = "本币价格不能为空")]
        //[ExcelColumn(Name = "本币价格")]
        [ExcelColumnName("本币价格")]
        public decimal Md011 { get; set; }

        //[ExcelColumn(Name = "本币种")]
        [ExcelColumnName("本币种")]
        public string Md012 { get; set; }

        [Required(ErrorMessage = "本币Per单位不能为空")]
        //[ExcelColumn(Name = "本币Per单位")]
        [ExcelColumnName("本币Per单位")]
        public int Md013 { get; set; }

        //[ExcelColumn(Name = "本币利润中心")]
        [ExcelColumnName("本币利润中心")]
        public string Md014 { get; set; }

        //[ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日期")]
        public DateTime? Md015 { get; set; }

        //[ExcelColumn(Name = "失效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("失效日期")]
        public DateTime? Md016 { get; set; }

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
        [ExcelColumn(Name = "工厂")]
        public string Md002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "期间")]
        public string Md003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string Md004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "物料")]
        public string Md005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "原币种")]
        public string Md008Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "原币利润中心")]
        public string Md010Label { get; set; }
    }

}