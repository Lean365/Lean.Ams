using Ams.Model.Logistics;

namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// PCBA OPH
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:18:45
    /// </summary>
    public class PpOutputPcbaMaQueryDto : PagerInfo 
    {
        /// <summary>
        /// 订单号码 
        /// </summary>        
        public string Mca003 { get; set; }
        /// <summary>
        /// 生产批次 
        /// </summary>        
        public string Mca005 { get; set; }
        /// <summary>
        /// 机种 
        /// </summary>        
        public string Mca006 { get; set; }
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Mca007 { get; set; }
        /// <summary>
        /// 生产日期 
        /// </summary>        
        public DateTime? BeginMca010 { get; set; }
        public DateTime? EndMca010 { get; set; }
    }

    /// <summary>
    /// PCBA OPH
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:18:45
    /// </summary>
    public class PpOutputPcbaMaDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        //[ExcelColumn(Name = "订单类别")]
        [ExcelColumnName("订单类别")]

        public string Mca002 { get; set; }

        [Required(ErrorMessage = "订单号码不能为空")]
        //[ExcelColumn(Name = "订单号码")]
        [ExcelColumnName("订单号码")]

        public string Mca003 { get; set; }

        [Required(ErrorMessage = "订单数量不能为空")]
        //[ExcelColumn(Name = "订单数量")]
        [ExcelColumnName("订单数量")]

        public decimal Mca004 { get; set; }

        //[ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]

        public string Mca005 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]

        public string Mca006 { get; set; }

        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Mca007 { get; set; }

        //[ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]

        public string Mca008 { get; set; }

        //[ExcelColumn(Name = "生产班组")]
        [ExcelColumnName("生产班组")]

        public string Mca009 { get; set; }

        //[ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]

        public DateTime? Mca010 { get; set; }

        [Required(ErrorMessage = "直接人数不能为空")]
        //[ExcelColumn(Name = "直接人数")]
        [ExcelColumnName("直接人数")]

        public int Mca011 { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        //[ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]

        public int Mca012 { get; set; }

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
        public List<PpOutputPcbaSlvDto> PpOutputPcbaSlvNav { get; set; }
        [ExcelColumn(Name = "订单号码")]
        public string Mca003Label { get; set; }
        [ExcelColumn(Name = "板别")]
        public string Mda004Label { get; set; }
        [ExcelColumn(Name = "板面")]
        public string Mda005Label { get; set; }
        [ExcelColumn(Name = "完成情况")]
        public string Mda010Label { get; set; }
    }

    /// <summary>
    /// PCBA OPH
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:18:45
    /// </summary>
    public class PpOutputPcbaMaImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        //[ExcelColumn(Name = "订单类别")]
        [ExcelColumnName("订单类别")]
        public string Mca002 { get; set; }

        [Required(ErrorMessage = "订单号码不能为空")]
        //[ExcelColumn(Name = "订单号码")]
        [ExcelColumnName("订单号码")]
        public string Mca003 { get; set; }

        [Required(ErrorMessage = "订单数量不能为空")]
        //[ExcelColumn(Name = "订单数量")]
        [ExcelColumnName("订单数量")]
        public decimal Mca004 { get; set; }

        //[ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string Mca005 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Mca006 { get; set; }

        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Mca007 { get; set; }

        //[ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string Mca008 { get; set; }

        //[ExcelColumn(Name = "生产班组")]
        [ExcelColumnName("生产班组")]
        public string Mca009 { get; set; }

        //[ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? Mca010 { get; set; }

        [Required(ErrorMessage = "直接人数不能为空")]
        //[ExcelColumn(Name = "直接人数")]
        [ExcelColumnName("直接人数")]
        public int Mca011 { get; set; }

        [Required(ErrorMessage = "间接人数不能为空")]
        //[ExcelColumn(Name = "间接人数")]
        [ExcelColumnName("间接人数")]
        public int Mca012 { get; set; }

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
        public List<PpOutputPcbaSlvDto> PpOutputPcbaSlvNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "订单号码")]
        public string Mca003Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "板别")]
        public string Mda004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "板面")]
        public string Mda005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "完成情况")]
        public string Mda010Label { get; set; }
    }

}