
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// Pur设变
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 14:43:11
    /// </summary>
    public class PpEcSlavePurQueryDto : PagerInfo 
    {
        public string PurEcNo { get; set; }
        public string PurModel { get; set; }
        public string PurType { get; set; }
        public string PurGroup { get; set; }
        public string PurInsmk { get; set; }
        public DateTime? BeginPurEnteredDate { get; set; }
        public DateTime? EndPurEnteredDate { get; set; }
    }

    /// <summary>
    /// Pur设变
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 14:43:11
    /// </summary>
    public class PpEcSlavePurDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long PurSfId { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long PurParentSfId { get; set; }

        [Required(ErrorMessage = "设变No.不能为空")]
        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string PurEcNo { get; set; }

        [Required(ErrorMessage = "机种不能为空")]
        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string PurModel { get; set; }

        [ExcelColumn(Name = "新物料")]
        [ExcelColumnName("新物料")]
        public string PurNewItem { get; set; }

        [ExcelColumn(Name = "新文本")]
        [ExcelColumnName("新文本")]
        public string PurNewItemText { get; set; }

        [Required(ErrorMessage = "新品库存不能为空")]
        [ExcelColumn(Name = "新品库存")]
        [ExcelColumnName("新品库存")]
        public decimal PurNewCurrStock { get; set; }

        [Required(ErrorMessage = "采购类型不能为空")]
        [ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string PurType { get; set; }

        [Required(ErrorMessage = "采购组不能为空")]
        [ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string PurGroup { get; set; }

        [ExcelColumn(Name = "检验到库存")]
        [ExcelColumnName("检验到库存")]
        public string PurInsmk { get; set; }

        [Required(ErrorMessage = "实施标记不能为空")]
        [ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int PurImplStated { get; set; }

        [ExcelColumn(Name = "采购登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("采购登入日期")]
        public DateTime? PurEnteredDate { get; set; }

        [ExcelColumn(Name = "供应商")]
        [ExcelColumnName("供应商")]
        public string PurSupplier { get; set; }

        [ExcelColumn(Name = "采购PO")]
        [ExcelColumnName("采购PO")]
        public string PurPreOrder { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string PurNote { get; set; }

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



        [ExcelColumn(Name = "采购类型")]
        public string PurTypeLabel { get; set; }
        [ExcelColumn(Name = "采购组")]
        public string PurGroupLabel { get; set; }
        [ExcelColumn(Name = "检验到库存")]
        public string PurInsmkLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// Pur设变
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 14:43:11
    /// </summary>
    public class PpEcSlavePurImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long PurSfId { get; set; }

        [Required(ErrorMessage = "父ID不能为空")]
        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long PurParentSfId { get; set; }

        [Required(ErrorMessage = "设变No.不能为空")]
        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string PurEcNo { get; set; }

        [Required(ErrorMessage = "机种不能为空")]
        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string PurModel { get; set; }

        [ExcelColumn(Name = "新物料")]
        [ExcelColumnName("新物料")]
        public string PurNewItem { get; set; }

        [ExcelColumn(Name = "新文本")]
        [ExcelColumnName("新文本")]
        public string PurNewItemText { get; set; }

        [Required(ErrorMessage = "新品库存不能为空")]
        [ExcelColumn(Name = "新品库存")]
        [ExcelColumnName("新品库存")]
        public decimal PurNewCurrStock { get; set; }

        [Required(ErrorMessage = "采购类型不能为空")]
        [ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string PurType { get; set; }

        [Required(ErrorMessage = "采购组不能为空")]
        [ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string PurGroup { get; set; }

        [ExcelColumn(Name = "检验到库存")]
        [ExcelColumnName("检验到库存")]
        public string PurInsmk { get; set; }

        [Required(ErrorMessage = "实施标记不能为空")]
        [ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int PurImplStated { get; set; }

        [ExcelColumn(Name = "采购登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("采购登入日期")]
        public DateTime? PurEnteredDate { get; set; }

        [ExcelColumn(Name = "供应商")]
        [ExcelColumnName("供应商")]
        public string PurSupplier { get; set; }

        [ExcelColumn(Name = "采购PO")]
        [ExcelColumnName("采购PO")]
        public string PurPreOrder { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string PurNote { get; set; }

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
        [ExcelColumn(Name = "采购类型")]
        public string PurTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "采购组")]
        public string PurGroupLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "检验到库存")]
        public string PurInsmkLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}