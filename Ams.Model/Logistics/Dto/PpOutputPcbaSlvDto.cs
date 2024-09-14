
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// PCBA明细
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:35
    /// </summary>
    public class PpOutputPcbaSlvQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// PCBA明细
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:35
    /// </summary>
    public class PpOutputPcbaSlvDto
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long Id { get; set; }

        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        [JsonConverter(typeof(ValueToStringConverter))]

        public long? ParentId { get; set; }

        //[ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]

        public string Mda003 { get; set; }

        //[ExcelColumn(Name = "板别")]
        [ExcelColumnName("板别")]

        public string Mda004 { get; set; }

        //[ExcelColumn(Name = "板面")]
        [ExcelColumnName("板面")]

        public string Mda005 { get; set; }

        [Required(ErrorMessage = "Lot数不能为空")]
        //[ExcelColumn(Name = "Lot数")]
        [ExcelColumnName("Lot数")]

        public int Mda006 { get; set; }

        [Required(ErrorMessage = "生产实绩不能为空")]
        //[ExcelColumn(Name = "生产实绩")]
        [ExcelColumnName("生产实绩")]

        public int Mda007 { get; set; }

        [Required(ErrorMessage = "累计生产数不能为空")]
        //[ExcelColumn(Name = "累计生产数")]
        [ExcelColumnName("累计生产数")]

        public int Mda008 { get; set; }

        //[ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]

        public string Mda009 { get; set; }

        //[ExcelColumn(Name = "完成情况")]
        [ExcelColumnName("完成情况")]

        public string Mda010 { get; set; }

        [Required(ErrorMessage = "总工数不能为空")]
        //[ExcelColumn(Name = "总工数")]
        [ExcelColumnName("总工数")]

        public int Mda011 { get; set; }

        [Required(ErrorMessage = "切换次数不能为空")]
        //[ExcelColumn(Name = "切换次数")]
        [ExcelColumnName("切换次数")]

        public int Mda012 { get; set; }

        [Required(ErrorMessage = "切换时间不能为空")]
        //[ExcelColumn(Name = "切换时间")]
        [ExcelColumnName("切换时间")]

        public int Mda013 { get; set; }

        [Required(ErrorMessage = "切停机时间不能为空")]
        //[ExcelColumn(Name = "切停机时间")]
        [ExcelColumnName("切停机时间")]

        public int Mda014 { get; set; }

        [Required(ErrorMessage = "修工数不能为空")]
        //[ExcelColumn(Name = "修工数")]
        [ExcelColumnName("修工数")]

        public int Mda015 { get; set; }

        [Required(ErrorMessage = "投入工数不能为空")]
        //[ExcelColumn(Name = "投入工数")]
        [ExcelColumnName("投入工数")]

        public int Mda016 { get; set; }

        [Required(ErrorMessage = "不良台数不能为空")]
        //[ExcelColumn(Name = "不良台数")]
        [ExcelColumnName("不良台数")]

        public int Mda017 { get; set; }

        [Required(ErrorMessage = "手插仕损不能为空")]
        //[ExcelColumn(Name = "手插仕损")]
        [ExcelColumnName("手插仕损")]

        public int Mda018 { get; set; }

        [Required(ErrorMessage = "修正仕损不能为空")]
        //[ExcelColumn(Name = "修正仕损")]
        [ExcelColumnName("修正仕损")]

        public int Mda019 { get; set; }

        //[ExcelColumn(Name = "停线原因")]
        [ExcelColumnName("停线原因")]

        public string Mda020 { get; set; }

        //[ExcelColumn(Name = "停线备注说明")]
        [ExcelColumnName("停线备注说明")]

        public string Mda021 { get; set; }

        //[ExcelColumn(Name = "未达成原因")]
        [ExcelColumnName("未达成原因")]

        public string Mda022 { get; set; }

        //[ExcelColumn(Name = "未达成备注说明")]
        [ExcelColumnName("未达成备注说明")]

        public string Mda023 { get; set; }

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
        public string Mda004Label { get; set; }
        [ExcelColumn(Name = "板面")]
        public string Mda005Label { get; set; }
        [ExcelColumn(Name = "完成情况")]
        public string Mda010Label { get; set; }
    }

    /// <summary>
    /// PCBA明细
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:35
    /// </summary>
    public class PpOutputPcbaSlvImportTpl
    {
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        //[ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? ParentId { get; set; }

        //[ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string Mda003 { get; set; }

        //[ExcelColumn(Name = "板别")]
        [ExcelColumnName("板别")]
        public string Mda004 { get; set; }

        //[ExcelColumn(Name = "板面")]
        [ExcelColumnName("板面")]
        public string Mda005 { get; set; }

        [Required(ErrorMessage = "Lot数不能为空")]
        //[ExcelColumn(Name = "Lot数")]
        [ExcelColumnName("Lot数")]
        public int Mda006 { get; set; }

        [Required(ErrorMessage = "生产实绩不能为空")]
        //[ExcelColumn(Name = "生产实绩")]
        [ExcelColumnName("生产实绩")]
        public int Mda007 { get; set; }

        [Required(ErrorMessage = "累计生产数不能为空")]
        //[ExcelColumn(Name = "累计生产数")]
        [ExcelColumnName("累计生产数")]
        public int Mda008 { get; set; }

        //[ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string Mda009 { get; set; }

        //[ExcelColumn(Name = "完成情况")]
        [ExcelColumnName("完成情况")]
        public string Mda010 { get; set; }

        [Required(ErrorMessage = "总工数不能为空")]
        //[ExcelColumn(Name = "总工数")]
        [ExcelColumnName("总工数")]
        public int Mda011 { get; set; }

        [Required(ErrorMessage = "切换次数不能为空")]
        //[ExcelColumn(Name = "切换次数")]
        [ExcelColumnName("切换次数")]
        public int Mda012 { get; set; }

        [Required(ErrorMessage = "切换时间不能为空")]
        //[ExcelColumn(Name = "切换时间")]
        [ExcelColumnName("切换时间")]
        public int Mda013 { get; set; }

        [Required(ErrorMessage = "切停机时间不能为空")]
        //[ExcelColumn(Name = "切停机时间")]
        [ExcelColumnName("切停机时间")]
        public int Mda014 { get; set; }

        [Required(ErrorMessage = "修工数不能为空")]
        //[ExcelColumn(Name = "修工数")]
        [ExcelColumnName("修工数")]
        public int Mda015 { get; set; }

        [Required(ErrorMessage = "投入工数不能为空")]
        //[ExcelColumn(Name = "投入工数")]
        [ExcelColumnName("投入工数")]
        public int Mda016 { get; set; }

        [Required(ErrorMessage = "不良台数不能为空")]
        //[ExcelColumn(Name = "不良台数")]
        [ExcelColumnName("不良台数")]
        public int Mda017 { get; set; }

        [Required(ErrorMessage = "手插仕损不能为空")]
        //[ExcelColumn(Name = "手插仕损")]
        [ExcelColumnName("手插仕损")]
        public int Mda018 { get; set; }

        [Required(ErrorMessage = "修正仕损不能为空")]
        //[ExcelColumn(Name = "修正仕损")]
        [ExcelColumnName("修正仕损")]
        public int Mda019 { get; set; }

        //[ExcelColumn(Name = "停线原因")]
        [ExcelColumnName("停线原因")]
        public string Mda020 { get; set; }

        //[ExcelColumn(Name = "停线备注说明")]
        [ExcelColumnName("停线备注说明")]
        public string Mda021 { get; set; }

        //[ExcelColumn(Name = "未达成原因")]
        [ExcelColumnName("未达成原因")]
        public string Mda022 { get; set; }

        //[ExcelColumn(Name = "未达成备注说明")]
        [ExcelColumnName("未达成备注说明")]
        public string Mda023 { get; set; }

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
        public string Mda004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "板面")]
        public string Mda005Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "完成情况")]
        public string Mda010Label { get; set; }
    }

}