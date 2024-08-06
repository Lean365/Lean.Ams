
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 组立
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:43:00
    /// </summary>
    public class PpEcSlaveAssyQueryDto : PagerInfo 
    {
        public string AssyEcNo { get; set; }
        public string AssyModel { get; set; }
        public string AssyItem { get; set; }
        public DateTime? BeginAssyEnteredDate { get; set; }
        public DateTime? EndAssyEnteredDate { get; set; }
        public string AssyLine { get; set; }
        public string AssyPutLot { get; set; }
    }

    /// <summary>
    /// 组立
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:43:00
    /// </summary>
    public class PpEcSlaveAssyDto
    {
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long? AssySfId { get; set; }

        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long? AssyParentSfId { get; set; }

        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string AssyEcNo { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string AssyModel { get; set; }

        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string AssyItem { get; set; }

        [ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int? AssyImplStated { get; set; }

        [ExcelColumn(Name = "制一登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("制一登入日期")]
        public DateTime? AssyEnteredDate { get; set; }

        [ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string AssyLine { get; set; }

        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string AssyPutLot { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string AssyNote { get; set; }

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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "实施标记")]
        public string AssyImplStatedLabel { get; set; }
        [ExcelColumn(Name = "班组")]
        public string AssyLineLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 组立
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:43:00
    /// </summary>
    public class PpEcSlaveAssyImportTpl
    {
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long? AssySfId { get; set; }

        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long? AssyParentSfId { get; set; }

        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string AssyEcNo { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string AssyModel { get; set; }

        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string AssyItem { get; set; }

        [ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int? AssyImplStated { get; set; }

        [ExcelColumn(Name = "制一登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("制一登入日期")]
        public DateTime? AssyEnteredDate { get; set; }

        [ExcelColumn(Name = "班组")]
        [ExcelColumnName("班组")]
        public string AssyLine { get; set; }

        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string AssyPutLot { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string AssyNote { get; set; }

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

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
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
        [ExcelColumn(Name = "实施标记")]
        public string AssyImplStatedLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "班组")]
        public string AssyLineLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}