using Ams.Model.Logistics;

namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 组立OPH
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:21:13
    /// </summary>
    public class PpOutputAssyMaQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工单号码 
        /// </summary>        
        public string Mma003 { get; set; }
        /// <summary>
        /// 生产批次 
        /// </summary>        
        public string Mma006 { get; set; }
        /// <summary>
        /// 机种名 
        /// </summary>        
        public string Mma007 { get; set; }
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Mma008 { get; set; }
        /// <summary>
        /// 生产日期 
        /// </summary>        
        public DateTime? BeginMma009 { get; set; }
        public DateTime? EndMma009 { get; set; }
        /// <summary>
        /// 生产班组 
        /// </summary>        
        public string Mma010 { get; set; }
    }

    /// <summary>
    /// 组立OPH
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:21:13
    /// </summary>
    public class PpOutputAssyMaDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        //[ExcelColumn(Name = "工单类别")]
        [ExcelColumnName("工单类别")]

        public string Mma002 { get; set; }

        [Required(ErrorMessage = "工单号码不能为空")]
        //[ExcelColumn(Name = "工单号码")]
        [ExcelColumnName("工单号码")]

        public string Mma003 { get; set; }

        [Required(ErrorMessage = "工单数量不能为空")]
        //[ExcelColumn(Name = "工单数量")]
        [ExcelColumnName("工单数量")]

        public decimal Mma004 { get; set; }

        //[ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]

        public string Mma005 { get; set; }

        //[ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]

        public string Mma006 { get; set; }

        //[ExcelColumn(Name = "机种名")]
        [ExcelColumnName("机种名")]

        public string Mma007 { get; set; }

        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Mma008 { get; set; }

        //[ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]

        public DateTime? Mma009 { get; set; }

        [Required(ErrorMessage = "生产班组不能为空")]
        //[ExcelColumn(Name = "生产班组")]
        [ExcelColumnName("生产班组")]

        public string Mma010 { get; set; }

        [Required(ErrorMessage = "直接人数不能为空")]
        //[ExcelColumn(Name = "直接人数")]
        [ExcelColumnName("直接人数")]

        public int Mma011 { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        //[ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]

        public int Mma012 { get; set; }

        [Required(ErrorMessage = "标准工时不能为空")]
        //[ExcelColumn(Name = "标准工时")]
        [ExcelColumnName("标准工时")]

        public decimal Mma013 { get; set; }

        [Required(ErrorMessage = "标准产能不能为空")]
        //[ExcelColumn(Name = "标准产能")]
        [ExcelColumnName("标准产能")]

        public decimal Mma014 { get; set; }

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
        public List<PpOutputAssySlvDto> PpOutputAssySlvNav { get; set; }
        [ExcelColumn(Name = "工单号码")]
        public string Mma003Label { get; set; }
        [ExcelColumn(Name = "生产班组")]
        public string Mma010Label { get; set; }
        [ExcelColumn(Name = "停线")]
        public string Mmb005Label { get; set; }
        [ExcelColumn(Name = "未达成")]
        public string Mmb007Label { get; set; }
    }

    /// <summary>
    /// 组立OPH
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:21:13
    /// </summary>
    public class PpOutputAssyMaImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        //[ExcelColumn(Name = "工单类别")]
        [ExcelColumnName("工单类别")]
        public string Mma002 { get; set; }

        [Required(ErrorMessage = "工单号码不能为空")]
        //[ExcelColumn(Name = "工单号码")]
        [ExcelColumnName("工单号码")]
        public string Mma003 { get; set; }

        [Required(ErrorMessage = "工单数量不能为空")]
        //[ExcelColumn(Name = "工单数量")]
        [ExcelColumnName("工单数量")]
        public decimal Mma004 { get; set; }

        //[ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string Mma005 { get; set; }

        //[ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string Mma006 { get; set; }

        //[ExcelColumn(Name = "机种名")]
        [ExcelColumnName("机种名")]
        public string Mma007 { get; set; }

        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Mma008 { get; set; }

        //[ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? Mma009 { get; set; }

        [Required(ErrorMessage = "生产班组不能为空")]
        //[ExcelColumn(Name = "生产班组")]
        [ExcelColumnName("生产班组")]
        public string Mma010 { get; set; }

        [Required(ErrorMessage = "直接人数不能为空")]
        //[ExcelColumn(Name = "直接人数")]
        [ExcelColumnName("直接人数")]
        public int Mma011 { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        //[ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]
        public int Mma012 { get; set; }

        [Required(ErrorMessage = "标准工时不能为空")]
        //[ExcelColumn(Name = "标准工时")]
        [ExcelColumnName("标准工时")]
        public decimal Mma013 { get; set; }

        [Required(ErrorMessage = "标准产能不能为空")]
        //[ExcelColumn(Name = "标准产能")]
        [ExcelColumnName("标准产能")]
        public decimal Mma014 { get; set; }

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
        public List<PpOutputAssySlvDto> PpOutputAssySlvNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "工单号码")]
        public string Mma003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "生产班组")]
        public string Mma010Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "停线")]
        public string Mmb005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "未达成")]
        public string Mmb007Label { get; set; }
    }

}