
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 技联
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/11 16:21:09
    /// </summary>
    public class PpEcLiaisonQueryDto : PagerInfo 
    {
        /// <summary>
        /// 发行日 
        /// </summary>        
        public DateTime? BeginMa002 { get; set; }
        public DateTime? EndMa002 { get; set; }
        /// <summary>
        /// 设变No. 
        /// </summary>        
        public string Ma003 { get; set; }
        /// <summary>
        /// 机种明细 
        /// </summary>        
        public string Ma004 { get; set; }
        /// <summary>
        /// 担当 
        /// </summary>        
        public string Ma005 { get; set; }
    }

    /// <summary>
    /// 技联
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/11 16:21:09
    /// </summary>
    public class PpEcLiaisonDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? Id { get; set; }

        [Required(ErrorMessage = "发行日不能为空")]
        //[ExcelColumn(Name = "发行日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("发行日")]

        public DateTime? Ma002 { get; set; }

        //[ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]

        public string Ma003 { get; set; }

        //[ExcelColumn(Name = "机种明细")]
        [ExcelColumnName("机种明细")]

        public string Ma004 { get; set; }

        [Required(ErrorMessage = "担当不能为空")]
        //[ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]

        public string Ma005 { get; set; }

        [Required(ErrorMessage = "输入日不能为空")]
        //[ExcelColumn(Name = "输入日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("输入日")]

        public DateTime? Ma006 { get; set; }

        //[ExcelColumn(Name = "技联NO.")]
        [ExcelColumnName("技联NO.")]

        public string Ma007 { get; set; }

        //[ExcelColumn(Name = "技联文件")]
        [ExcelColumnName("技联文件")]

        public string Ma008 { get; set; }

        //[ExcelColumn(Name = "P番NO.")]
        [ExcelColumnName("P番NO.")]

        public string Ma009 { get; set; }

        //[ExcelColumn(Name = "P番文件")]
        [ExcelColumnName("P番文件")]

        public string Ma010 { get; set; }

        //[ExcelColumn(Name = "TCJ P番NO.")]
        [ExcelColumnName("TCJ P番NO.")]

        public string Ma011 { get; set; }

        //[ExcelColumn(Name = "TCJ P番文件")]
        [ExcelColumnName("TCJ P番文件")]

        public string Ma012 { get; set; }

        //[ExcelColumn(Name = "外联NO.")]
        [ExcelColumnName("外联NO.")]

        public string Ma013 { get; set; }

        //[ExcelColumn(Name = "外联文件")]
        [ExcelColumnName("外联文件")]

        public string Ma014 { get; set; }

        //[ExcelColumn(Name = "其它NO.")]
        [ExcelColumnName("其它NO.")]

        public string Ma015 { get; set; }

        //[ExcelColumn(Name = "附件")]
        [ExcelColumnName("附件")]

        public string Ma016 { get; set; }

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



        [ExcelColumn(Name = "设变No.")]
        public string Ma003Label { get; set; }
        [ExcelColumn(Name = "机种明细")]
        public string Ma004Label { get; set; }
        [ExcelColumn(Name = "担当")]
        public string Ma005Label { get; set; }
    }

    /// <summary>
    /// 技联
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/11 16:21:09
    /// </summary>
    public class PpEcLiaisonImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? Id { get; set; }

        [Required(ErrorMessage = "发行日不能为空")]
        //[ExcelColumn(Name = "发行日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("发行日")]
        public DateTime? Ma002 { get; set; }

        //[ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string Ma003 { get; set; }

        //[ExcelColumn(Name = "机种明细")]
        [ExcelColumnName("机种明细")]
        public string Ma004 { get; set; }

        [Required(ErrorMessage = "担当不能为空")]
        //[ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]
        public string Ma005 { get; set; }

        [Required(ErrorMessage = "输入日不能为空")]
        //[ExcelColumn(Name = "输入日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("输入日")]
        public DateTime? Ma006 { get; set; }

        //[ExcelColumn(Name = "技联NO.")]
        [ExcelColumnName("技联NO.")]
        public string Ma007 { get; set; }

        //[ExcelColumn(Name = "技联文件")]
        [ExcelColumnName("技联文件")]
        public string Ma008 { get; set; }

        //[ExcelColumn(Name = "P番NO.")]
        [ExcelColumnName("P番NO.")]
        public string Ma009 { get; set; }

        //[ExcelColumn(Name = "P番文件")]
        [ExcelColumnName("P番文件")]
        public string Ma010 { get; set; }

        //[ExcelColumn(Name = "TCJ P番NO.")]
        [ExcelColumnName("TCJ P番NO.")]
        public string Ma011 { get; set; }

        //[ExcelColumn(Name = "TCJ P番文件")]
        [ExcelColumnName("TCJ P番文件")]
        public string Ma012 { get; set; }

        //[ExcelColumn(Name = "外联NO.")]
        [ExcelColumnName("外联NO.")]
        public string Ma013 { get; set; }

        //[ExcelColumn(Name = "外联文件")]
        [ExcelColumnName("外联文件")]
        public string Ma014 { get; set; }

        //[ExcelColumn(Name = "其它NO.")]
        [ExcelColumnName("其它NO.")]
        public string Ma015 { get; set; }

        //[ExcelColumn(Name = "附件")]
        [ExcelColumnName("附件")]
        public string Ma016 { get; set; }

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
        [ExcelColumn(Name = "设变No.")]
        public string Ma003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "机种明细")]
        public string Ma004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "担当")]
        public string Ma005Label { get; set; }
    }

}