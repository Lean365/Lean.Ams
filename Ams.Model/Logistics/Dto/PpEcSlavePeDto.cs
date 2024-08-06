
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// Pe设变
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:39:48
    /// </summary>
    public class PpEcSlavePeQueryDto : PagerInfo 
    {
        public string PeEcNo { get; set; }
        public string PeModel { get; set; }
        public string PeItem { get; set; }
        public DateTime? BeginPeEnteredDate { get; set; }
        public DateTime? EndPeEnteredDate { get; set; }
    }

    /// <summary>
    /// Pe设变
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:39:48
    /// </summary>
    public class PpEcSlavePeDto
    {
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long? PeSfId { get; set; }

        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long? PeParentSfId { get; set; }

        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string PeEcNo { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string PeModel { get; set; }

        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string PeItem { get; set; }

        [ExcelColumn(Name = "子物料")]
        [ExcelColumnName("子物料")]
        public string PeSubItem { get; set; }

        [Required(ErrorMessage = "SOP不能为空")]
        [ExcelColumn(Name = "SOP")]
        [ExcelColumnName("SOP")]
        public int PeSopStated { get; set; }

        [Required(ErrorMessage = "实施标记不能为空")]
        [ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int PeImplStated { get; set; }

        [ExcelColumn(Name = "SOP确认日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("SOP确认日期")]
        public DateTime? PeEnteredDate { get; set; }

        [Required(ErrorMessage = "SOP部门不能为空")]
        [ExcelColumn(Name = "SOP部门")]
        [ExcelColumnName("SOP部门")]
        public int PeDeptSop { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string PeNote { get; set; }

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



        [ExcelColumn(Name = "SOP")]
        public string PeSopStatedLabel { get; set; }
        [ExcelColumn(Name = "SOP部门")]
        public string PeDeptSopLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// Pe设变
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:39:48
    /// </summary>
    public class PpEcSlavePeImportTpl
    {
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long? PeSfId { get; set; }

        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long? PeParentSfId { get; set; }

        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string PeEcNo { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string PeModel { get; set; }

        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string PeItem { get; set; }

        [ExcelColumn(Name = "子物料")]
        [ExcelColumnName("子物料")]
        public string PeSubItem { get; set; }

        [Required(ErrorMessage = "SOP不能为空")]
        [ExcelColumn(Name = "SOP")]
        [ExcelColumnName("SOP")]
        public int PeSopStated { get; set; }

        [Required(ErrorMessage = "实施标记不能为空")]
        [ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int PeImplStated { get; set; }

        [ExcelColumn(Name = "SOP确认日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("SOP确认日期")]
        public DateTime? PeEnteredDate { get; set; }

        [Required(ErrorMessage = "SOP部门不能为空")]
        [ExcelColumn(Name = "SOP部门")]
        [ExcelColumnName("SOP部门")]
        public int PeDeptSop { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string PeNote { get; set; }

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
        [ExcelColumn(Name = "SOP")]
        public string PeSopStatedLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "SOP部门")]
        public string PeDeptSopLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}