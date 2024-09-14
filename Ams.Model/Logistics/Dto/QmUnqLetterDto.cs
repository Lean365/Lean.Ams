
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 不合格联络
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:41:22
    /// </summary>
    public class QmUnqLetterQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Ml002 { get; set; }
        /// <summary>
        /// 检查员 
        /// </summary>        
        public string Ml003 { get; set; }
        /// <summary>
        /// 班组 
        /// </summary>        
        public string Ml004 { get; set; }
        /// <summary>
        /// 订单 
        /// </summary>        
        public string Ml005 { get; set; }
        /// <summary>
        /// 机种 
        /// </summary>        
        public string Ml006 { get; set; }
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Ml007 { get; set; }
        /// <summary>
        /// 仕向 
        /// </summary>        
        public string Ml008 { get; set; }
        /// <summary>
        /// 查验日期 
        /// </summary>        
        public DateTime? BeginMl009 { get; set; }
        public DateTime? EndMl009 { get; set; }
        /// <summary>
        /// 级别 
        /// </summary>        
        public string Ml013 { get; set; }
    }

    /// <summary>
    /// 不合格联络
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:41:22
    /// </summary>
    public class QmUnqLetterDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Ml002 { get; set; }

        //[ExcelColumn(Name = "检查员")]
        [ExcelColumnName("检查员")]

        public string Ml003 { get; set; }

        //[ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]

        public string Ml004 { get; set; }

        //[ExcelColumn(Name = "订单")]
        [ExcelColumnName("订单")]

        public string Ml005 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]

        public string Ml006 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Ml007 { get; set; }

        //[ExcelColumn(Name = "仕向")]
        [ExcelColumnName("仕向")]

        public string Ml008 { get; set; }

        [Required(ErrorMessage = "查验日期不能为空")]
        //[ExcelColumn(Name = "查验日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("查验日期")]

        public DateTime? Ml009 { get; set; }

        //[ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]

        public string Ml010 { get; set; }

        //[ExcelColumn(Name = "序号")]
        [ExcelColumnName("序号")]

        public string Ml011 { get; set; }

        [Required(ErrorMessage = "验退数不能为空")]
        //[ExcelColumn(Name = "验退数")]
        [ExcelColumnName("验退数")]

        public decimal Ml012 { get; set; }

        //[ExcelColumn(Name = "级别")]
        [ExcelColumnName("级别")]

        public string Ml013 { get; set; }

        //[ExcelColumn(Name = "判定说明")]
        [ExcelColumnName("判定说明")]

        public string Ml014 { get; set; }

        //[ExcelColumn(Name = "发行号码")]
        [ExcelColumnName("发行号码")]

        public string Ml015 { get; set; }

        //[ExcelColumn(Name = "附件")]
        [ExcelColumnName("附件")]

        public string Ml016 { get; set; }

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

        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Werks { get; set; }



        [ExcelColumn(Name = "工厂")]
        public string Ml002Label { get; set; }
        [ExcelColumn(Name = "检查员")]
        public string Ml003Label { get; set; }
        [ExcelColumn(Name = "班组")]
        public string Ml004Label { get; set; }
        [ExcelColumn(Name = "级别")]
        public string Ml013Label { get; set; }
    }

    /// <summary>
    /// 不合格联络
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:41:22
    /// </summary>
    public class QmUnqLetterImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Ml002 { get; set; }

        //[ExcelColumn(Name = "检查员")]
        [ExcelColumnName("检查员")]
        public string Ml003 { get; set; }

        //[ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string Ml004 { get; set; }

        //[ExcelColumn(Name = "订单")]
        [ExcelColumnName("订单")]
        public string Ml005 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Ml006 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Ml007 { get; set; }

        //[ExcelColumn(Name = "仕向")]
        [ExcelColumnName("仕向")]
        public string Ml008 { get; set; }

        [Required(ErrorMessage = "查验日期不能为空")]
        //[ExcelColumn(Name = "查验日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("查验日期")]
        public DateTime? Ml009 { get; set; }

        //[ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string Ml010 { get; set; }

        //[ExcelColumn(Name = "序号")]
        [ExcelColumnName("序号")]
        public string Ml011 { get; set; }

        [Required(ErrorMessage = "验退数不能为空")]
        //[ExcelColumn(Name = "验退数")]
        [ExcelColumnName("验退数")]
        public decimal Ml012 { get; set; }

        //[ExcelColumn(Name = "级别")]
        [ExcelColumnName("级别")]
        public string Ml013 { get; set; }

        //[ExcelColumn(Name = "判定说明")]
        [ExcelColumnName("判定说明")]
        public string Ml014 { get; set; }

        //[ExcelColumn(Name = "发行号码")]
        [ExcelColumnName("发行号码")]
        public string Ml015 { get; set; }

        //[ExcelColumn(Name = "附件")]
        [ExcelColumnName("附件")]
        public string Ml016 { get; set; }

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

        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Werks { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string Ml002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "检查员")]
        public string Ml003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "班组")]
        public string Ml004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "级别")]
        public string Ml013Label { get; set; }
    }

}