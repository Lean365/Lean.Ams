
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// Iqc设变
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:41:59
    /// </summary>
    public class PpEcSlaveIqcQueryDto : PagerInfo 
    {
        public string IqcEcNo { get; set; }
        public string IqcModel { get; set; }
        public string IqcPurType { get; set; }
        public string IqcPurGroup { get; set; }
        public string IqcInsmk { get; set; }
        public int? IqcImplStated { get; set; }
        public DateTime? BeginIqcEnteredDate { get; set; }
        public DateTime? EndIqcEnteredDate { get; set; }
    }

    /// <summary>
    /// Iqc设变
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:41:59
    /// </summary>
    public class PpEcSlaveIqcDto
    {
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long? IqcSfId { get; set; }

        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long? IqcParentSfId { get; set; }

        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string IqcEcNo { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string IqcModel { get; set; }

        [ExcelColumn(Name = "新物料")]
        [ExcelColumnName("新物料")]
        public string IqcNewItem { get; set; }

        [ExcelColumn(Name = "新文本")]
        [ExcelColumnName("新文本")]
        public string IqcNewItemText { get; set; }

        [ExcelColumn(Name = "新品库存")]
        [ExcelColumnName("新品库存")]
        public decimal IqcNewCurrStock { get; set; }

        [ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string IqcPurType { get; set; }

        [ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string IqcPurGroup { get; set; }

        [ExcelColumn(Name = "检验否")]
        [ExcelColumnName("检验否")]
        public string IqcInsmk { get; set; }

        [Required(ErrorMessage = "实施标记不能为空")]
        [ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int IqcImplStated { get; set; }

        [ExcelColumn(Name = "IQC登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("IQC登入日期")]
        public DateTime? IqcEnteredDate { get; set; }

        [ExcelColumn(Name = "检验订单")]
        [ExcelColumnName("检验订单")]
        public string IqcPurOrder { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string IqcNote { get; set; }

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
        public string IqcPurTypeLabel { get; set; }
        [ExcelColumn(Name = "采购组")]
        public string IqcPurGroupLabel { get; set; }
        [ExcelColumn(Name = "检验否")]
        public string IqcInsmkLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// Iqc设变
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:41:59
    /// </summary>
    public class PpEcSlaveIqcImportTpl
    {
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long? IqcSfId { get; set; }

        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long? IqcParentSfId { get; set; }

        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string IqcEcNo { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string IqcModel { get; set; }

        [ExcelColumn(Name = "新物料")]
        [ExcelColumnName("新物料")]
        public string IqcNewItem { get; set; }

        [ExcelColumn(Name = "新文本")]
        [ExcelColumnName("新文本")]
        public string IqcNewItemText { get; set; }

        [ExcelColumn(Name = "新品库存")]
        [ExcelColumnName("新品库存")]
        public decimal IqcNewCurrStock { get; set; }

        [ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string IqcPurType { get; set; }

        [ExcelColumn(Name = "采购组")]
        [ExcelColumnName("采购组")]
        public string IqcPurGroup { get; set; }

        [ExcelColumn(Name = "检验否")]
        [ExcelColumnName("检验否")]
        public string IqcInsmk { get; set; }

        [Required(ErrorMessage = "实施标记不能为空")]
        [ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int IqcImplStated { get; set; }

        [ExcelColumn(Name = "IQC登入日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("IQC登入日期")]
        public DateTime? IqcEnteredDate { get; set; }

        [ExcelColumn(Name = "检验订单")]
        [ExcelColumnName("检验订单")]
        public string IqcPurOrder { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string IqcNote { get; set; }

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
        public string IqcPurTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "采购组")]
        public string IqcPurGroupLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "检验否")]
        public string IqcInsmkLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}