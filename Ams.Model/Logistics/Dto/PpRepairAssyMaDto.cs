using Ams.Model.Logistics;

namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 不良
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:33:52
    /// </summary>
    public class PpRepairAssyMaQueryDto : PagerInfo 
    {
        /// <summary>
        /// 生产订单 
        /// </summary>        
        public string Mea002 { get; set; }
        /// <summary>
        /// 生产批次 
        /// </summary>        
        public string Mea004 { get; set; }
        /// <summary>
        /// 生产机种 
        /// </summary>        
        public string Mea005 { get; set; }
        /// <summary>
        /// 生产日期 
        /// </summary>        
        public DateTime? BeginMea006 { get; set; }
        public DateTime? EndMea006 { get; set; }
        /// <summary>
        /// 生产班组 
        /// </summary>        
        public string Mea007 { get; set; }
    }

    /// <summary>
    /// 不良
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:33:52
    /// </summary>
    public class PpRepairAssyMaDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "生产订单不能为空")]
        //[ExcelColumn(Name = "生产订单")]
        [ExcelColumnName("生产订单")]

        public string Mea002 { get; set; }

        [Required(ErrorMessage = "订单数量不能为空")]
        //[ExcelColumn(Name = "订单数量")]
        [ExcelColumnName("订单数量")]

        public int Mea003 { get; set; }

        //[ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]

        public string Mea004 { get; set; }

        //[ExcelColumn(Name = "生产机种")]
        [ExcelColumnName("生产机种")]

        public string Mea005 { get; set; }

        //[ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]

        public DateTime? Mea006 { get; set; }

        //[ExcelColumn(Name = "生产班组")]
        [ExcelColumnName("生产班组")]

        public string Mea007 { get; set; }

        [Required(ErrorMessage = "生产实绩不能为空")]
        //[ExcelColumn(Name = "生产实绩")]
        [ExcelColumnName("生产实绩")]

        public int Mea008 { get; set; }

        [Required(ErrorMessage = "无不良数不能为空")]
        //[ExcelColumn(Name = "无不良数")]
        [ExcelColumnName("无不良数")]

        public int Mea009 { get; set; }

        [ExcelIgnore]

        public string Remark { get; set; }

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

        public string CreateBy { get; set; }

        [ExcelIgnore]

        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]

        public string UpdateBy { get; set; }

        [ExcelIgnore]

        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        public List<PpRepairAssySlvDto> PpRepairAssySlvNav { get; set; }
        [ExcelColumn(Name = "生产订单")]
        public string Mea002Label { get; set; }
        [ExcelColumn(Name = "生产班组")]
        public string Mea007Label { get; set; }
        [ExcelColumn(Name = "不良区分")]
        public string Mfa003Label { get; set; }
    }

    /// <summary>
    /// 不良
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:33:52
    /// </summary>
    public class PpRepairAssyMaImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "生产订单不能为空")]
        //[ExcelColumn(Name = "生产订单")]
        [ExcelColumnName("生产订单")]
        public string Mea002 { get; set; }

        [Required(ErrorMessage = "订单数量不能为空")]
        //[ExcelColumn(Name = "订单数量")]
        [ExcelColumnName("订单数量")]
        public int Mea003 { get; set; }

        //[ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string Mea004 { get; set; }

        //[ExcelColumn(Name = "生产机种")]
        [ExcelColumnName("生产机种")]
        public string Mea005 { get; set; }

        //[ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? Mea006 { get; set; }

        //[ExcelColumn(Name = "生产班组")]
        [ExcelColumnName("生产班组")]
        public string Mea007 { get; set; }

        [Required(ErrorMessage = "生产实绩不能为空")]
        //[ExcelColumn(Name = "生产实绩")]
        [ExcelColumnName("生产实绩")]
        public int Mea008 { get; set; }

        [Required(ErrorMessage = "无不良数不能为空")]
        //[ExcelColumn(Name = "无不良数")]
        [ExcelColumnName("无不良数")]
        public int Mea009 { get; set; }

        [ExcelIgnore]
        public string Remark { get; set; }

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
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        public List<PpRepairAssySlvDto> PpRepairAssySlvNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "生产订单")]
        public string Mea002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "生产班组")]
        public string Mea007Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "不良区分")]
        public string Mfa003Label { get; set; }
    }

}