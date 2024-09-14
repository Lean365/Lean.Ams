
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 废弃部品
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:46:48
    /// </summary>
    public class QmCostWasteQueryDto : PagerInfo 
    {
        /// <summary>
        /// 工厂 
        /// </summary>        
        public string Me002 { get; set; }
        /// <summary>
        /// 日期 
        /// </summary>        
        public DateTime? BeginMe003 { get; set; }
        public DateTime? EndMe003 { get; set; }
        /// <summary>
        /// 机种 
        /// </summary>        
        public string Me004 { get; set; }
        /// <summary>
        /// 物料 
        /// </summary>        
        public string Me006 { get; set; }
    }

    /// <summary>
    /// 废弃部品
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:46:48
    /// </summary>
    public class QmCostWasteDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]

        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]

        public string Me002 { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]

        public DateTime? Me003 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]

        public string Me004 { get; set; }

        [Required(ErrorMessage = "间接人员赁率不能为空")]
        //[ExcelColumn(Name = "间接人员赁率")]
        [ExcelColumnName("间接人员赁率")]

        public decimal Me005 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]

        public string Me006 { get; set; }

        //[ExcelColumn(Name = "描述")]
        [ExcelColumnName("描述")]

        public string Me007 { get; set; }

        //[ExcelColumn(Name = "事故内容")]
        [ExcelColumnName("事故内容")]

        public string Me008 { get; set; }

        [Required(ErrorMessage = "废弃费用不能为空")]
        //[ExcelColumn(Name = "废弃费用")]
        [ExcelColumnName("废弃费用")]

        public decimal Me009 { get; set; }

        [Required(ErrorMessage = "废弃数量不能为空")]
        //[ExcelColumn(Name = "废弃数量")]
        [ExcelColumnName("废弃数量")]

        public decimal Me010 { get; set; }

        [Required(ErrorMessage = "部品单价不能为空")]
        //[ExcelColumn(Name = "部品单价")]
        [ExcelColumnName("部品单价")]

        public decimal Me011 { get; set; }

        [Required(ErrorMessage = "废弃处理费用不能为空")]
        //[ExcelColumn(Name = "废弃处理费用")]
        [ExcelColumnName("废弃处理费用")]

        public decimal Me012 { get; set; }

        [Required(ErrorMessage = "运费不能为空")]
        //[ExcelColumn(Name = "运费")]
        [ExcelColumnName("运费")]

        public decimal Me013 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]

        public decimal Me014 { get; set; }

        [Required(ErrorMessage = "处理作业时间(分)不能为空")]
        //[ExcelColumn(Name = "处理作业时间(分)")]
        [ExcelColumnName("处理作业时间(分)")]

        public int Me015 { get; set; }

        [Required(ErrorMessage = "关税不能为空")]
        //[ExcelColumn(Name = "关税")]
        [ExcelColumnName("关税")]

        public decimal Me016 { get; set; }

        [Required(ErrorMessage = "处理发生其他费用不能为空")]
        //[ExcelColumn(Name = "处理发生其他费用")]
        [ExcelColumnName("处理发生其他费用")]

        public decimal Me017 { get; set; }

        //[ExcelColumn(Name = "设变")]
        [ExcelColumnName("设变")]

        public string Me018 { get; set; }

        //[ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]

        public string Me019 { get; set; }

        //[ExcelColumn(Name = "附件")]
        [ExcelColumnName("附件")]

        public string Me020 { get; set; }

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
        public string Me002Label { get; set; }
        [ExcelColumn(Name = "机种")]
        public string Me004Label { get; set; }
        [ExcelColumn(Name = "物料")]
        public string Me006Label { get; set; }
    }

    /// <summary>
    /// 废弃部品
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 16:46:48
    /// </summary>
    public class QmCostWasteImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long Id { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        //[ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string Me002 { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        //[ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? Me003 { get; set; }

        //[ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Me004 { get; set; }

        [Required(ErrorMessage = "间接人员赁率不能为空")]
        //[ExcelColumn(Name = "间接人员赁率")]
        [ExcelColumnName("间接人员赁率")]
        public decimal Me005 { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        //[ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string Me006 { get; set; }

        //[ExcelColumn(Name = "描述")]
        [ExcelColumnName("描述")]
        public string Me007 { get; set; }

        //[ExcelColumn(Name = "事故内容")]
        [ExcelColumnName("事故内容")]
        public string Me008 { get; set; }

        [Required(ErrorMessage = "废弃费用不能为空")]
        //[ExcelColumn(Name = "废弃费用")]
        [ExcelColumnName("废弃费用")]
        public decimal Me009 { get; set; }

        [Required(ErrorMessage = "废弃数量不能为空")]
        //[ExcelColumn(Name = "废弃数量")]
        [ExcelColumnName("废弃数量")]
        public decimal Me010 { get; set; }

        [Required(ErrorMessage = "部品单价不能为空")]
        //[ExcelColumn(Name = "部品单价")]
        [ExcelColumnName("部品单价")]
        public decimal Me011 { get; set; }

        [Required(ErrorMessage = "废弃处理费用不能为空")]
        //[ExcelColumn(Name = "废弃处理费用")]
        [ExcelColumnName("废弃处理费用")]
        public decimal Me012 { get; set; }

        [Required(ErrorMessage = "运费不能为空")]
        //[ExcelColumn(Name = "运费")]
        [ExcelColumnName("运费")]
        public decimal Me013 { get; set; }

        [Required(ErrorMessage = "其他费用不能为空")]
        //[ExcelColumn(Name = "其他费用")]
        [ExcelColumnName("其他费用")]
        public decimal Me014 { get; set; }

        [Required(ErrorMessage = "处理作业时间(分)不能为空")]
        //[ExcelColumn(Name = "处理作业时间(分)")]
        [ExcelColumnName("处理作业时间(分)")]
        public int Me015 { get; set; }

        [Required(ErrorMessage = "关税不能为空")]
        //[ExcelColumn(Name = "关税")]
        [ExcelColumnName("关税")]
        public decimal Me016 { get; set; }

        [Required(ErrorMessage = "处理发生其他费用不能为空")]
        //[ExcelColumn(Name = "处理发生其他费用")]
        [ExcelColumnName("处理发生其他费用")]
        public decimal Me017 { get; set; }

        //[ExcelColumn(Name = "设变")]
        [ExcelColumnName("设变")]
        public string Me018 { get; set; }

        //[ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]
        public string Me019 { get; set; }

        //[ExcelColumn(Name = "附件")]
        [ExcelColumnName("附件")]
        public string Me020 { get; set; }

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
        public string Me002Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "机种")]
        public string Me004Label { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "物料")]
        public string Me006Label { get; set; }
    }

}