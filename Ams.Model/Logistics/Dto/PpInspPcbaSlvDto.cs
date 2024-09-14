
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 检查明细
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:55
    /// </summary>
    public class PpInspPcbaSlvQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 检查明细
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:55
    /// </summary>
    public class PpInspPcbaSlvDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? ParentId { get; set; }

        //[ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]

        public string Mv003 { get; set; }

        [Required(ErrorMessage = "Lot数不能为空")]
        //[ExcelColumn(Name = "Lot数")]
        [ExcelColumnName("Lot数")]

        public int Mv004 { get; set; }

        //[ExcelColumn(Name = "板别")]
        [ExcelColumnName("板别")]

        public string Mv005 { get; set; }

        //[ExcelColumn(Name = "目视线别")]
        [ExcelColumnName("目视线别")]

        public string Mv006 { get; set; }

        //[ExcelColumn(Name = "AOI线别")]
        [ExcelColumnName("AOI线别")]

        public string Mv007 { get; set; }

        //[ExcelColumn(Name = "B面实装", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("B面实装")]

        public DateTime? Mv008 { get; set; }

        //[ExcelColumn(Name = "T面实装", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("T面实装")]

        public DateTime? Mv009 { get; set; }

        //[ExcelColumn(Name = "生产班别")]
        [ExcelColumnName("生产班别")]

        public string Mv010 { get; set; }

        //[ExcelColumn(Name = "检查员")]
        [ExcelColumnName("检查员")]

        public string Mv011 { get; set; }

        [Required(ErrorMessage = "当日完成数不能为空")]
        //[ExcelColumn(Name = "当日完成数")]
        [ExcelColumnName("当日完成数")]

        public int Mv012 { get; set; }

        [Required(ErrorMessage = "累计完成数不能为空")]
        //[ExcelColumn(Name = "累计完成数")]
        [ExcelColumnName("累计完成数")]

        public int Mv013 { get; set; }

        [Required(ErrorMessage = "检查台数不能为空")]
        //[ExcelColumn(Name = "检查台数")]
        [ExcelColumnName("检查台数")]

        public int Mv014 { get; set; }

        //[ExcelColumn(Name = "检查状态")]
        [ExcelColumnName("检查状态")]

        public string Mv015 { get; set; }

        //[ExcelColumn(Name = "生产线别")]
        [ExcelColumnName("生产线别")]

        public string Mv016 { get; set; }

        [Required(ErrorMessage = "检查工数不能为空")]
        //[ExcelColumn(Name = "检查工数")]
        [ExcelColumnName("检查工数")]

        public int Mv017 { get; set; }

        [Required(ErrorMessage = "AOI工数不能为空")]
        //[ExcelColumn(Name = "AOI工数")]
        [ExcelColumnName("AOI工数")]

        public int Mv018 { get; set; }

        [Required(ErrorMessage = "不良数量不能为空")]
        //[ExcelColumn(Name = "不良数量")]
        [ExcelColumnName("不良数量")]

        public int Mv019 { get; set; }

        //[ExcelColumn(Name = "手贴部品")]
        [ExcelColumnName("手贴部品")]

        public string Mv020 { get; set; }

        //[ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]

        public string Mv021 { get; set; }

        //[ExcelColumn(Name = "内容")]
        [ExcelColumnName("内容")]

        public string Mv022 { get; set; }

        //[ExcelColumn(Name = "个所区分")]
        [ExcelColumnName("个所区分")]

        public string Mv023 { get; set; }

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
    /// 检查明细
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:55
    /// </summary>
    public class PpInspPcbaSlvImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? ParentId { get; set; }

        //[ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string Mv003 { get; set; }

        [Required(ErrorMessage = "Lot数不能为空")]
        //[ExcelColumn(Name = "Lot数")]
        [ExcelColumnName("Lot数")]
        public int Mv004 { get; set; }

        //[ExcelColumn(Name = "板别")]
        [ExcelColumnName("板别")]
        public string Mv005 { get; set; }

        //[ExcelColumn(Name = "目视线别")]
        [ExcelColumnName("目视线别")]
        public string Mv006 { get; set; }

        //[ExcelColumn(Name = "AOI线别")]
        [ExcelColumnName("AOI线别")]
        public string Mv007 { get; set; }

        //[ExcelColumn(Name = "B面实装", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("B面实装")]
        public DateTime? Mv008 { get; set; }

        //[ExcelColumn(Name = "T面实装", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("T面实装")]
        public DateTime? Mv009 { get; set; }

        //[ExcelColumn(Name = "生产班别")]
        [ExcelColumnName("生产班别")]
        public string Mv010 { get; set; }

        //[ExcelColumn(Name = "检查员")]
        [ExcelColumnName("检查员")]
        public string Mv011 { get; set; }

        [Required(ErrorMessage = "当日完成数不能为空")]
        //[ExcelColumn(Name = "当日完成数")]
        [ExcelColumnName("当日完成数")]
        public int Mv012 { get; set; }

        [Required(ErrorMessage = "累计完成数不能为空")]
        //[ExcelColumn(Name = "累计完成数")]
        [ExcelColumnName("累计完成数")]
        public int Mv013 { get; set; }

        [Required(ErrorMessage = "检查台数不能为空")]
        //[ExcelColumn(Name = "检查台数")]
        [ExcelColumnName("检查台数")]
        public int Mv014 { get; set; }

        //[ExcelColumn(Name = "检查状态")]
        [ExcelColumnName("检查状态")]
        public string Mv015 { get; set; }

        //[ExcelColumn(Name = "生产线别")]
        [ExcelColumnName("生产线别")]
        public string Mv016 { get; set; }

        [Required(ErrorMessage = "检查工数不能为空")]
        //[ExcelColumn(Name = "检查工数")]
        [ExcelColumnName("检查工数")]
        public int Mv017 { get; set; }

        [Required(ErrorMessage = "AOI工数不能为空")]
        //[ExcelColumn(Name = "AOI工数")]
        [ExcelColumnName("AOI工数")]
        public int Mv018 { get; set; }

        [Required(ErrorMessage = "不良数量不能为空")]
        //[ExcelColumn(Name = "不良数量")]
        [ExcelColumnName("不良数量")]
        public int Mv019 { get; set; }

        //[ExcelColumn(Name = "手贴部品")]
        [ExcelColumnName("手贴部品")]
        public string Mv020 { get; set; }

        //[ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string Mv021 { get; set; }

        //[ExcelColumn(Name = "内容")]
        [ExcelColumnName("内容")]
        public string Mv022 { get; set; }

        //[ExcelColumn(Name = "个所区分")]
        [ExcelColumnName("个所区分")]
        public string Mv023 { get; set; }

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