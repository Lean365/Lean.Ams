
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// Pcba设变
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:40:40
    /// </summary>
    public class PpEcSlavePcbaQueryDto : PagerInfo 
    {
        public string PcbaEcNo { get; set; }
        public string PcbaModel { get; set; }
        public string PcbaItem { get; set; }
        public DateTime? BeginPcbaEnteredDate { get; set; }
        public DateTime? EndPcbaEnteredDate { get; set; }
        public string PcbaLine { get; set; }
        public string PcbaPutLot { get; set; }
    }

    /// <summary>
    /// Pcba设变
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:40:40
    /// </summary>
    public class PpEcSlavePcbaDto
    {
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long? PcbaSfId { get; set; }

        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long? PcbaParentSfId { get; set; }

        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string PcbaEcNo { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string PcbaModel { get; set; }

        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string PcbaItem { get; set; }

        [Required(ErrorMessage = "实施标记不能为空")]
        [ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int PcbaImplStated { get; set; }

        [ExcelColumn(Name = "制二登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("制二登入日期")]
        public DateTime? PcbaEnteredDate { get; set; }

        [ExcelColumn(Name = "Pcba班组")]
        [ExcelColumnName("Pcba班组")]
        public string PcbaLine { get; set; }

        [ExcelColumn(Name = "Pcba批次")]
        [ExcelColumnName("Pcba批次")]
        public string PcbaPutLot { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string PcbaNote { get; set; }

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
        public string PcbaImplStatedLabel { get; set; }
        [ExcelColumn(Name = "Pcba班组")]
        public string PcbaLineLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// Pcba设变
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:40:40
    /// </summary>
    public class PpEcSlavePcbaImportTpl
    {
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long? PcbaSfId { get; set; }

        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long? PcbaParentSfId { get; set; }

        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string PcbaEcNo { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string PcbaModel { get; set; }

        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string PcbaItem { get; set; }

        [Required(ErrorMessage = "实施标记不能为空")]
        [ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int PcbaImplStated { get; set; }

        [ExcelColumn(Name = "制二登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("制二登入日期")]
        public DateTime? PcbaEnteredDate { get; set; }

        [ExcelColumn(Name = "Pcba班组")]
        [ExcelColumnName("Pcba班组")]
        public string PcbaLine { get; set; }

        [ExcelColumn(Name = "Pcba批次")]
        [ExcelColumnName("Pcba批次")]
        public string PcbaPutLot { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string PcbaNote { get; set; }

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
        public string PcbaImplStatedLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "Pcba班组")]
        public string PcbaLineLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}