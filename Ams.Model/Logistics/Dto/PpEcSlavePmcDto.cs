
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// Pmc设变
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:45:42
    /// </summary>
    public class PpEcSlavePmcQueryDto : PagerInfo 
    {
        public string PmcEcNo { get; set; }
        public string PmcModel { get; set; }
        public string PmcItem { get; set; }
        public int? PmcImplStated { get; set; }
        public DateTime? BeginPmcEnteredDate { get; set; }
        public DateTime? EndPmcEnteredDate { get; set; }
        public string PmcPreLot { get; set; }
        public int? PmcDisposal { get; set; }
    }

    /// <summary>
    /// Pmc设变
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:45:42
    /// </summary>
    public class PpEcSlavePmcDto
    {
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? PmcSfId { get; set; }

        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long? PmcParentSfId { get; set; }

        [ExcelColumn(Name = "设变No. ")]
        [ExcelColumnName("设变No. ")]
        public string PmcEcNo { get; set; }

        [ExcelColumn(Name = "机种 ")]
        [ExcelColumnName("机种 ")]
        public string PmcModel { get; set; }

        [ExcelColumn(Name = "物料 ")]
        [ExcelColumnName("物料 ")]
        public string PmcItem { get; set; }

        [Required(ErrorMessage = "实施标记 不能为空")]
        [ExcelColumn(Name = "实施标记 ")]
        [ExcelColumnName("实施标记 ")]
        public int PmcImplStated { get; set; }

        [ExcelColumn(Name = "输入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("输入日期")]
        public DateTime? PmcEnteredDate { get; set; }

        [ExcelColumn(Name = "预投批次 ")]
        [ExcelColumnName("预投批次 ")]
        public string PmcPreLot { get; set; }

        [ExcelColumn(Name = "旧品处理 ")]
        [ExcelColumnName("旧品处理 ")]
        public int? PmcDisposal { get; set; }

        [ExcelColumn(Name = "记事 ")]
        [ExcelColumnName("记事 ")]
        public string PmcNote { get; set; }

        [ExcelColumn(Name = "预留A ")]
        [ExcelColumnName("预留A ")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B ")]
        [ExcelColumnName("预留B ")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C ")]
        [ExcelColumnName("预留C ")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1 ")]
        [ExcelColumnName("预留1 ")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2 ")]
        [ExcelColumnName("预留2 ")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3")]
        [ExcelColumnName("预留3")]
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

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明")]
        [ExcelColumnName("备注说明")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "实施标记 ")]
        public string PmcImplStatedLabel { get; set; }
        [ExcelColumn(Name = "旧品处理 ")]
        public string PmcDisposalLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// Pmc设变
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:45:42
    /// </summary>
    public class PpEcSlavePmcImportTpl
    {
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? PmcSfId { get; set; }

        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long? PmcParentSfId { get; set; }

        [ExcelColumn(Name = "设变No. ")]
        [ExcelColumnName("设变No. ")]
        public string PmcEcNo { get; set; }

        [ExcelColumn(Name = "机种 ")]
        [ExcelColumnName("机种 ")]
        public string PmcModel { get; set; }

        [ExcelColumn(Name = "物料 ")]
        [ExcelColumnName("物料 ")]
        public string PmcItem { get; set; }

        [Required(ErrorMessage = "实施标记 不能为空")]
        [ExcelColumn(Name = "实施标记 ")]
        [ExcelColumnName("实施标记 ")]
        public int PmcImplStated { get; set; }

        [ExcelColumn(Name = "输入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("输入日期")]
        public DateTime? PmcEnteredDate { get; set; }

        [ExcelColumn(Name = "预投批次 ")]
        [ExcelColumnName("预投批次 ")]
        public string PmcPreLot { get; set; }

        [ExcelColumn(Name = "旧品处理 ")]
        [ExcelColumnName("旧品处理 ")]
        public int? PmcDisposal { get; set; }

        [ExcelColumn(Name = "记事 ")]
        [ExcelColumnName("记事 ")]
        public string PmcNote { get; set; }

        [ExcelColumn(Name = "预留A ")]
        [ExcelColumnName("预留A ")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B ")]
        [ExcelColumnName("预留B ")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C ")]
        [ExcelColumnName("预留C ")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1 ")]
        [ExcelColumnName("预留1 ")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2 ")]
        [ExcelColumnName("预留2 ")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3")]
        [ExcelColumnName("预留3")]
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

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明")]
        [ExcelColumnName("备注说明")]
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
        [ExcelColumn(Name = "实施标记 ")]
        public string PmcImplStatedLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "旧品处理 ")]
        public string PmcDisposalLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}