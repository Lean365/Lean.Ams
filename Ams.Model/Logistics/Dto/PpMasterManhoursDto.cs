
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 标准工时
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:31:00
    /// </summary>
    public class PpMasterManhoursQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Mb002 { get; set; }
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Mb003 { get; set; }
        /// <summary>
        /// 机种名 
        /// </summary>        
        public string Mb004 { get; set; }
        /// <summary>
        /// 物料描述 
        /// </summary>        
        public string Mb006 { get; set; }
        /// <summary>
        /// 工作中心 
        /// </summary>        
        public string Mb007 { get; set; }
        /// <summary>
        /// 生效日期 
        /// </summary>        
        public DateTime? BeginMb013 { get; set; }
        public DateTime? EndMb013 { get; set; }
    }

    /// <summary>
    /// 标准工时
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:31:00
    /// </summary>
    public class PpMasterManhoursDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Mb002 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Mb003 { get; set; }

        //[ExcelColumn(Name = "机种名")]
        [ExcelColumnName("机种名")]

        public string Mb004 { get; set; }

        //[ExcelColumn(Name = "仕向别")]
        [ExcelColumnName("仕向别")]

        public string Mb005 { get; set; }

        //[ExcelColumn(Name = "物料描述")]
        [ExcelColumnName("物料描述")]

        public string Mb006 { get; set; }

        //[ExcelColumn(Name = "工作中心")]
        [ExcelColumnName("工作中心")]

        public string Mb007 { get; set; }

        [Required(ErrorMessage = "标准点数不能为空")]
        //[ExcelColumn(Name = "标准点数")]
        [ExcelColumnName("标准点数")]

        public decimal Mb008 { get; set; }

        //[ExcelColumn(Name = "Short单位")]
        [ExcelColumnName("Short单位")]

        public string Mb009 { get; set; }

        [Required(ErrorMessage = "点数换算汇率不能为空")]
        //[ExcelColumn(Name = "点数换算汇率")]
        [ExcelColumnName("点数换算汇率")]

        public decimal Mb010 { get; set; }

        [Required(ErrorMessage = "标准工时不能为空")]
        //[ExcelColumn(Name = "标准工时")]
        [ExcelColumnName("标准工时")]

        public decimal Mb011 { get; set; }

        //[ExcelColumn(Name = "工时单位")]
        [ExcelColumnName("工时单位")]

        public string Mb012 { get; set; }

        //[ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日期")]

        public DateTime? Mb013 { get; set; }

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
        public string Mb002Label { get; set; }
        [ExcelColumn(Name = "工作中心")]
        public string Mb007Label { get; set; }
        [ExcelColumn(Name = "点数换算汇率")]
        public string Mb010Label { get; set; }
    }

    /// <summary>
    /// 标准工时
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:31:00
    /// </summary>
    public class PpMasterManhoursImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Mb002 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Mb003 { get; set; }

        //[ExcelColumn(Name = "机种名")]
        [ExcelColumnName("机种名")]
        public string Mb004 { get; set; }

        //[ExcelColumn(Name = "仕向别")]
        [ExcelColumnName("仕向别")]
        public string Mb005 { get; set; }

        //[ExcelColumn(Name = "物料描述")]
        [ExcelColumnName("物料描述")]
        public string Mb006 { get; set; }

        //[ExcelColumn(Name = "工作中心")]
        [ExcelColumnName("工作中心")]
        public string Mb007 { get; set; }

        [Required(ErrorMessage = "标准点数不能为空")]
        //[ExcelColumn(Name = "标准点数")]
        [ExcelColumnName("标准点数")]
        public decimal Mb008 { get; set; }

        //[ExcelColumn(Name = "Short单位")]
        [ExcelColumnName("Short单位")]
        public string Mb009 { get; set; }

        [Required(ErrorMessage = "点数换算汇率不能为空")]
        //[ExcelColumn(Name = "点数换算汇率")]
        [ExcelColumnName("点数换算汇率")]
        public decimal Mb010 { get; set; }

        [Required(ErrorMessage = "标准工时不能为空")]
        //[ExcelColumn(Name = "标准工时")]
        [ExcelColumnName("标准工时")]
        public decimal Mb011 { get; set; }

        //[ExcelColumn(Name = "工时单位")]
        [ExcelColumnName("工时单位")]
        public string Mb012 { get; set; }

        //[ExcelColumn(Name = "生效日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生效日期")]
        public DateTime? Mb013 { get; set; }

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
        public string Mb002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "工作中心")]
        public string Mb007Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "点数换算汇率")]
        public string Mb010Label { get; set; }
    }

}