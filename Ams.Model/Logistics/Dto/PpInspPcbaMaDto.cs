using Ams.Model.Logistics;

namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 检查
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:26:18
    /// </summary>
    public class PpInspPcbaMaQueryDto : PagerInfo 
    {
        /// <summary>
        /// 检查日期 
        /// </summary>        
        public DateTime? BeginMu002 { get; set; }
        public DateTime? EndMu002 { get; set; }
        /// <summary>
        /// 生产机种 
        /// </summary>        
        public string Mu003 { get; set; }
        /// <summary>
        /// 生产工单 
        /// </summary>        
        public string Mu004 { get; set; }
        /// <summary>
        /// 生产批次 
        /// </summary>        
        public string Mu005 { get; set; }
    }

    /// <summary>
    /// 检查
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:26:18
    /// </summary>
    public class PpInspPcbaMaDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        //[ExcelColumn(Name = "检查日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("检查日期")]

        public DateTime? Mu002 { get; set; }

        //[ExcelColumn(Name = "生产机种")]
        [ExcelColumnName("生产机种")]

        public string Mu003 { get; set; }

        [Required(ErrorMessage = "生产工单不能为空")]
        //[ExcelColumn(Name = "生产工单")]
        [ExcelColumnName("生产工单")]

        public string Mu004 { get; set; }

        //[ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]

        public string Mu005 { get; set; }

        [Required(ErrorMessage = "工单台数不能为空")]
        //[ExcelColumn(Name = "工单台数")]
        [ExcelColumnName("工单台数")]

        public int Mu006 { get; set; }

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
        public List<PpInspPcbaSlvDto> PpInspPcbaSlvNav { get; set; }
        [ExcelColumn(Name = "板别")]
        public string Mv005Label { get; set; }
        [ExcelColumn(Name = "目视线别")]
        public string Mv006Label { get; set; }
        [ExcelColumn(Name = "AOI线别")]
        public string Mv007Label { get; set; }
        [ExcelColumn(Name = "生产班别")]
        public string Mv010Label { get; set; }
        [ExcelColumn(Name = "检查状态")]
        public string Mv015Label { get; set; }
        [ExcelColumn(Name = "生产线别")]
        public string Mv016Label { get; set; }
        [ExcelColumn(Name = "个所区分")]
        public string Mv023Label { get; set; }
    }

    /// <summary>
    /// 检查
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:26:18
    /// </summary>
    public class PpInspPcbaMaImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        //[ExcelColumn(Name = "检查日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("检查日期")]
        public DateTime? Mu002 { get; set; }

        //[ExcelColumn(Name = "生产机种")]
        [ExcelColumnName("生产机种")]
        public string Mu003 { get; set; }

        [Required(ErrorMessage = "生产工单不能为空")]
        //[ExcelColumn(Name = "生产工单")]
        [ExcelColumnName("生产工单")]
        public string Mu004 { get; set; }

        //[ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string Mu005 { get; set; }

        [Required(ErrorMessage = "工单台数不能为空")]
        //[ExcelColumn(Name = "工单台数")]
        [ExcelColumnName("工单台数")]
        public int Mu006 { get; set; }

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
        public List<PpInspPcbaSlvDto> PpInspPcbaSlvNav { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "板别")]
        public string Mv005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "目视线别")]
        public string Mv006Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "AOI线别")]
        public string Mv007Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "生产班别")]
        public string Mv010Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "检查状态")]
        public string Mv015Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "生产线别")]
        public string Mv016Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "个所区分")]
        public string Mv023Label { get; set; }
    }

}