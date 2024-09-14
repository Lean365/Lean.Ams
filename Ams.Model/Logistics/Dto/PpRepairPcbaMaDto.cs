using Ams.Model.Logistics;

namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 修理
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:10:27
    /// </summary>
    public class PpRepairPcbaMaQueryDto : PagerInfo 
    {
        /// <summary>
        /// 生产日期 
        /// </summary>        
        public DateTime? BeginMga002 { get; set; }
        public DateTime? EndMga002 { get; set; }
        /// <summary>
        /// 生产机种 
        /// </summary>        
        public string Mga003 { get; set; }
        /// <summary>
        /// 生产订单 
        /// </summary>        
        public string Mga004 { get; set; }
        /// <summary>
        /// 生产LOT 
        /// </summary>        
        public string Mga005 { get; set; }
    }

    /// <summary>
    /// 修理
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:10:27
    /// </summary>
    public class PpRepairPcbaMaDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        //[ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]

        public DateTime? Mga002 { get; set; }

        //[ExcelColumn(Name = "生产机种")]
        [ExcelColumnName("生产机种")]

        public string Mga003 { get; set; }

        [Required(ErrorMessage = "生产订单不能为空")]
        //[ExcelColumn(Name = "生产订单")]
        [ExcelColumnName("生产订单")]

        public string Mga004 { get; set; }

        //[ExcelColumn(Name = "生产LOT")]
        [ExcelColumnName("生产LOT")]

        public string Mga005 { get; set; }

        [Required(ErrorMessage = "订单台数不能为空")]
        //[ExcelColumn(Name = "订单台数")]
        [ExcelColumnName("订单台数")]

        public int Mga006 { get; set; }

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
        public List<PpRepairPcbaSlvDto> PpRepairPcbaSlvNav { get; set; }
        [ExcelColumn(Name = "板别")]
        public string Mha004Label { get; set; }
        [ExcelColumn(Name = "检出工程")]
        public string Mha011Label { get; set; }
        [ExcelColumn(Name = "责任归属")]
        public string Mha015Label { get; set; }
        [ExcelColumn(Name = "不良性质")]
        public string Mha016Label { get; set; }
        [ExcelColumn(Name = "修理")]
        public string Mha018Label { get; set; }
    }

    /// <summary>
    /// 修理
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:10:27
    /// </summary>
    public class PpRepairPcbaMaImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        //[ExcelColumn(Name = "生产日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生产日期")]
        public DateTime? Mga002 { get; set; }

        //[ExcelColumn(Name = "生产机种")]
        [ExcelColumnName("生产机种")]
        public string Mga003 { get; set; }

        [Required(ErrorMessage = "生产订单不能为空")]
        //[ExcelColumn(Name = "生产订单")]
        [ExcelColumnName("生产订单")]
        public string Mga004 { get; set; }

        //[ExcelColumn(Name = "生产LOT")]
        [ExcelColumnName("生产LOT")]
        public string Mga005 { get; set; }

        [Required(ErrorMessage = "订单台数不能为空")]
        //[ExcelColumn(Name = "订单台数")]
        [ExcelColumnName("订单台数")]
        public int Mga006 { get; set; }

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
        public List<PpRepairPcbaSlvDto> PpRepairPcbaSlvNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "板别")]
        public string Mha004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "检出工程")]
        public string Mha011Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "责任归属")]
        public string Mha015Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "不良性质")]
        public string Mha016Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "修理")]
        public string Mha018Label { get; set; }
    }

}