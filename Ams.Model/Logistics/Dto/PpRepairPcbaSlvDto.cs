
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 修理明细
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:47
    /// </summary>
    public class PpRepairPcbaSlvQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 修理明细
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:47
    /// </summary>
    public class PpRepairPcbaSlvDto
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

        public string Mha003 { get; set; }

        //[ExcelColumn(Name = "板别")]
        [ExcelColumnName("板别")]

        public string Mha004 { get; set; }

        [Required(ErrorMessage = "Lot数不能为空")]
        //[ExcelColumn(Name = "Lot数")]
        [ExcelColumnName("Lot数")]

        public int Mha005 { get; set; }

        [Required(ErrorMessage = "当日生产数不能为空")]
        //[ExcelColumn(Name = "当日生产数")]
        [ExcelColumnName("当日生产数")]

        public int Mha006 { get; set; }

        [Required(ErrorMessage = "累计完成数不能为空")]
        //[ExcelColumn(Name = "累计完成数")]
        [ExcelColumnName("累计完成数")]

        public int Mha007 { get; set; }

        //[ExcelColumn(Name = "生产组别")]
        [ExcelColumnName("生产组别")]

        public string Mha008 { get; set; }

        //[ExcelColumn(Name = "卡号")]
        [ExcelColumnName("卡号")]

        public string Mha009 { get; set; }

        //[ExcelColumn(Name = "不良症状")]
        [ExcelColumnName("不良症状")]

        public string Mha010 { get; set; }

        //[ExcelColumn(Name = "检出工程")]
        [ExcelColumnName("检出工程")]

        public string Mha011 { get; set; }

        //[ExcelColumn(Name = "不良原因")]
        [ExcelColumnName("不良原因")]

        public string Mha012 { get; set; }

        [Required(ErrorMessage = "不良数量不能为空")]
        //[ExcelColumn(Name = "不良数量")]
        [ExcelColumnName("不良数量")]

        public int Mha013 { get; set; }

        [Required(ErrorMessage = "累计不良台数不能为空")]
        //[ExcelColumn(Name = "累计不良台数")]
        [ExcelColumnName("累计不良台数")]

        public int Mha014 { get; set; }

        //[ExcelColumn(Name = "责任归属")]
        [ExcelColumnName("责任归属")]

        public string Mha015 { get; set; }

        //[ExcelColumn(Name = "不良性质")]
        [ExcelColumnName("不良性质")]

        public string Mha016 { get; set; }

        //[ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]

        public string Mha017 { get; set; }

        //[ExcelColumn(Name = "修理")]
        [ExcelColumnName("修理")]

        public string Mha018 { get; set; }

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
    /// 修理明细
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:47
    /// </summary>
    public class PpRepairPcbaSlvImportTpl
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
        public string Mha003 { get; set; }

        //[ExcelColumn(Name = "板别")]
        [ExcelColumnName("板别")]
        public string Mha004 { get; set; }

        [Required(ErrorMessage = "Lot数不能为空")]
        //[ExcelColumn(Name = "Lot数")]
        [ExcelColumnName("Lot数")]
        public int Mha005 { get; set; }

        [Required(ErrorMessage = "当日生产数不能为空")]
        //[ExcelColumn(Name = "当日生产数")]
        [ExcelColumnName("当日生产数")]
        public int Mha006 { get; set; }

        [Required(ErrorMessage = "累计完成数不能为空")]
        //[ExcelColumn(Name = "累计完成数")]
        [ExcelColumnName("累计完成数")]
        public int Mha007 { get; set; }

        //[ExcelColumn(Name = "生产组别")]
        [ExcelColumnName("生产组别")]
        public string Mha008 { get; set; }

        //[ExcelColumn(Name = "卡号")]
        [ExcelColumnName("卡号")]
        public string Mha009 { get; set; }

        //[ExcelColumn(Name = "不良症状")]
        [ExcelColumnName("不良症状")]
        public string Mha010 { get; set; }

        //[ExcelColumn(Name = "检出工程")]
        [ExcelColumnName("检出工程")]
        public string Mha011 { get; set; }

        //[ExcelColumn(Name = "不良原因")]
        [ExcelColumnName("不良原因")]
        public string Mha012 { get; set; }

        [Required(ErrorMessage = "不良数量不能为空")]
        //[ExcelColumn(Name = "不良数量")]
        [ExcelColumnName("不良数量")]
        public int Mha013 { get; set; }

        [Required(ErrorMessage = "累计不良台数不能为空")]
        //[ExcelColumn(Name = "累计不良台数")]
        [ExcelColumnName("累计不良台数")]
        public int Mha014 { get; set; }

        //[ExcelColumn(Name = "责任归属")]
        [ExcelColumnName("责任归属")]
        public string Mha015 { get; set; }

        //[ExcelColumn(Name = "不良性质")]
        [ExcelColumnName("不良性质")]
        public string Mha016 { get; set; }

        //[ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string Mha017 { get; set; }

        //[ExcelColumn(Name = "修理")]
        [ExcelColumnName("修理")]
        public string Mha018 { get; set; }

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