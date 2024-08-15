
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 明细科目
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 17:37:35
    /// </summary>
    public class FicoBudgetAccountingSlvQueryDto : PagerInfo 
    {
        public string FbasFdpls { get; set; }
        public string FbasStext { get; set; }
        public string FbasLtext { get; set; }
    }

    /// <summary>
    /// 明细科目
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 17:37:35
    /// </summary>
    public class FicoBudgetAccountingSlvDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbasSfId { get; set; }

        [Required(ErrorMessage = "父ID  不能为空")]
        [ExcelColumn(Name = "父ID  ")]
        [ExcelColumnName("父ID  ")]
        public long FbasParentSfId { get; set; }

        [ExcelColumn(Name = "翻译Key  ")]
        [ExcelColumnName("翻译Key  ")]
        public string FbasSpras { get; set; }

        [ExcelColumn(Name = "明细科目  ")]
        [ExcelColumnName("明细科目  ")]
        public string FbasFdpls { get; set; }

        [ExcelColumn(Name = "名称  ")]
        [ExcelColumnName("名称  ")]
        public string FbasStext { get; set; }

        [ExcelColumn(Name = "长文本  ")]
        [ExcelColumnName("长文本  ")]
        public string FbasLtext { get; set; }

        [ExcelColumn(Name = "附加文本  ")]
        [ExcelColumnName("附加文本  ")]
        public string FbasAtext { get; set; }

        [ExcelColumn(Name = "冻结  ")]
        [ExcelColumnName("冻结  ")]
        public int? FbasXspea { get; set; }

        [ExcelColumn(Name = "预留A  ")]
        [ExcelColumnName("预留A  ")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B  ")]
        [ExcelColumnName("预留B  ")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C  ")]
        [ExcelColumnName("预留C  ")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1  ")]
        [ExcelColumnName("预留1  ")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2  ")]
        [ExcelColumnName("预留2  ")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3 ")]
        [ExcelColumnName("预留3 ")]
        public decimal REF06 { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [ExcelIgnore]
        public int? UDF51 { get; set; }

        [ExcelIgnore]
        public int? UDF52 { get; set; }

        [ExcelIgnore]
        public int? UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除 ")]
        [ExcelColumnName("软删除 ")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明 ")]
        [ExcelColumnName("备注说明 ")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "冻结  ")]
        public string FbasXspeaLabel { get; set; }
        [ExcelColumn(Name = "软删除 ")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 明细科目
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 17:37:35
    /// </summary>
    public class FicoBudgetAccountingSlvImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FbasSfId { get; set; }

        [Required(ErrorMessage = "父ID  不能为空")]
        [ExcelColumn(Name = "父ID  ")]
        [ExcelColumnName("父ID  ")]
        public long FbasParentSfId { get; set; }

        [ExcelColumn(Name = "翻译Key  ")]
        [ExcelColumnName("翻译Key  ")]
        public string FbasSpras { get; set; }

        [ExcelColumn(Name = "明细科目  ")]
        [ExcelColumnName("明细科目  ")]
        public string FbasFdpls { get; set; }

        [ExcelColumn(Name = "名称  ")]
        [ExcelColumnName("名称  ")]
        public string FbasStext { get; set; }

        [ExcelColumn(Name = "长文本  ")]
        [ExcelColumnName("长文本  ")]
        public string FbasLtext { get; set; }

        [ExcelColumn(Name = "附加文本  ")]
        [ExcelColumnName("附加文本  ")]
        public string FbasAtext { get; set; }

        [ExcelColumn(Name = "冻结  ")]
        [ExcelColumnName("冻结  ")]
        public int? FbasXspea { get; set; }

        [ExcelColumn(Name = "预留A  ")]
        [ExcelColumnName("预留A  ")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B  ")]
        [ExcelColumnName("预留B  ")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C  ")]
        [ExcelColumnName("预留C  ")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1  ")]
        [ExcelColumnName("预留1  ")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2  ")]
        [ExcelColumnName("预留2  ")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3 ")]
        [ExcelColumnName("预留3 ")]
        public decimal REF06 { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [ExcelIgnore]
        public int? UDF51 { get; set; }

        [ExcelIgnore]
        public int? UDF52 { get; set; }

        [ExcelIgnore]
        public int? UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除 ")]
        [ExcelColumnName("软删除 ")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明 ")]
        [ExcelColumnName("备注说明 ")]
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
        [ExcelColumn(Name = "冻结  ")]
        public string FbasXspeaLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除 ")]
        public string IsDeletedLabel { get; set; }
    }

}