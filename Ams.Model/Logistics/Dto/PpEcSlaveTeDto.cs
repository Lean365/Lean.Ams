
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// Te设变
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:39:03
    /// </summary>
    public class PpEcSlaveTeQueryDto : PagerInfo 
    {
        public string TeEcNo { get; set; }
        public string TeModel { get; set; }
        public string TeItem { get; set; }
        public string TePurType { get; set; }
        public string TeSloc { get; set; }
        public string TeInsmk { get; set; }
        public string TePlntStated { get; set; }
        public int? TeSopStated { get; set; }
    }

    /// <summary>
    /// Te设变
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:39:03
    /// </summary>
    public class PpEcSlaveTeDto
    {
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long? TeSfId { get; set; }

        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long? TeParentSfId { get; set; }

        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string TeEcNo { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string TeModel { get; set; }

        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string TeItem { get; set; }

        [ExcelColumn(Name = "子物料")]
        [ExcelColumnName("子物料")]
        public string TeSubItem { get; set; }

        [ExcelColumn(Name = "旧物料")]
        [ExcelColumnName("旧物料")]
        public string TeOldItem { get; set; }

        [ExcelColumn(Name = "旧文本")]
        [ExcelColumnName("旧文本")]
        public string TeOldItemText { get; set; }

        [ExcelColumn(Name = "旧品库存")]
        [ExcelColumnName("旧品库存")]
        public decimal TeOldCurrStock { get; set; }

        [ExcelColumn(Name = "用量")]
        [ExcelColumnName("用量")]
        public decimal TeOldUsageQty { get; set; }

        [ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string TeOldSetLoc { get; set; }

        [ExcelColumn(Name = "新物料")]
        [ExcelColumnName("新物料")]
        public string TeNewItem { get; set; }

        [ExcelColumn(Name = "新文本")]
        [ExcelColumnName("新文本")]
        public string TeNewItemText { get; set; }

        [ExcelColumn(Name = "新品库存")]
        [ExcelColumnName("新品库存")]
        public decimal TeNewCurrStock { get; set; }

        [ExcelColumn(Name = "用量")]
        [ExcelColumnName("用量")]
        public decimal TeNewUsageQty { get; set; }

        [ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string TeNewSetLoc { get; set; }

        [ExcelColumn(Name = "bom番号")]
        [ExcelColumnName("bom番号")]
        public string TeBomNo { get; set; }

        [ExcelColumn(Name = "互换")]
        [ExcelColumnName("互换")]
        public string TeChange { get; set; }

        [ExcelColumn(Name = "区分")]
        [ExcelColumnName("区分")]
        public string TeDistLocal { get; set; }

        [ExcelColumn(Name = "指示")]
        [ExcelColumnName("指示")]
        public string TeInstNote { get; set; }

        [ExcelColumn(Name = "旧品处理")]
        [ExcelColumnName("旧品处理")]
        public string TeOldProcess { get; set; }

        [ExcelColumn(Name = "bom日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("bom日期")]
        public DateTime? TeBomDate { get; set; }

        [Required(ErrorMessage = "采购类型不能为空")]
        [ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string TePurType { get; set; }

        [Required(ErrorMessage = "仓库不能为空")]
        [ExcelColumn(Name = "仓库")]
        [ExcelColumnName("仓库")]
        public string TeSloc { get; set; }

        [ExcelColumn(Name = "检验否")]
        [ExcelColumnName("检验否")]
        public string TeInsmk { get; set; }

        [ExcelColumn(Name = "工厂状态")]
        [ExcelColumnName("工厂状态")]
        public string TePlntStated { get; set; }

        [Required(ErrorMessage = "SOP不能为空")]
        [ExcelColumn(Name = "SOP")]
        [ExcelColumnName("SOP")]
        public int TeSopStated { get; set; }

        [Required(ErrorMessage = "实施标记不能为空")]
        [ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int TeImplStated { get; set; }

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
        public string TePurTypeLabel { get; set; }
        [ExcelColumn(Name = "仓库")]
        public string TeSlocLabel { get; set; }
        [ExcelColumn(Name = "检验否")]
        public string TeInsmkLabel { get; set; }
        [ExcelColumn(Name = "工厂状态")]
        public string TePlntStatedLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// Te设变
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 15:39:03
    /// </summary>
    public class PpEcSlaveTeImportTpl
    {
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public long? TeSfId { get; set; }

        [ExcelColumn(Name = "父ID")]
        [ExcelColumnName("父ID")]
        public long? TeParentSfId { get; set; }

        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string TeEcNo { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string TeModel { get; set; }

        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string TeItem { get; set; }

        [ExcelColumn(Name = "子物料")]
        [ExcelColumnName("子物料")]
        public string TeSubItem { get; set; }

        [ExcelColumn(Name = "旧物料")]
        [ExcelColumnName("旧物料")]
        public string TeOldItem { get; set; }

        [ExcelColumn(Name = "旧文本")]
        [ExcelColumnName("旧文本")]
        public string TeOldItemText { get; set; }

        [ExcelColumn(Name = "旧品库存")]
        [ExcelColumnName("旧品库存")]
        public decimal TeOldCurrStock { get; set; }

        [ExcelColumn(Name = "用量")]
        [ExcelColumnName("用量")]
        public decimal TeOldUsageQty { get; set; }

        [ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string TeOldSetLoc { get; set; }

        [ExcelColumn(Name = "新物料")]
        [ExcelColumnName("新物料")]
        public string TeNewItem { get; set; }

        [ExcelColumn(Name = "新文本")]
        [ExcelColumnName("新文本")]
        public string TeNewItemText { get; set; }

        [ExcelColumn(Name = "新品库存")]
        [ExcelColumnName("新品库存")]
        public decimal TeNewCurrStock { get; set; }

        [ExcelColumn(Name = "用量")]
        [ExcelColumnName("用量")]
        public decimal TeNewUsageQty { get; set; }

        [ExcelColumn(Name = "位置")]
        [ExcelColumnName("位置")]
        public string TeNewSetLoc { get; set; }

        [ExcelColumn(Name = "bom番号")]
        [ExcelColumnName("bom番号")]
        public string TeBomNo { get; set; }

        [ExcelColumn(Name = "互换")]
        [ExcelColumnName("互换")]
        public string TeChange { get; set; }

        [ExcelColumn(Name = "区分")]
        [ExcelColumnName("区分")]
        public string TeDistLocal { get; set; }

        [ExcelColumn(Name = "指示")]
        [ExcelColumnName("指示")]
        public string TeInstNote { get; set; }

        [ExcelColumn(Name = "旧品处理")]
        [ExcelColumnName("旧品处理")]
        public string TeOldProcess { get; set; }

        [ExcelColumn(Name = "bom日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("bom日期")]
        public DateTime? TeBomDate { get; set; }

        [Required(ErrorMessage = "采购类型不能为空")]
        [ExcelColumn(Name = "采购类型")]
        [ExcelColumnName("采购类型")]
        public string TePurType { get; set; }

        [Required(ErrorMessage = "仓库不能为空")]
        [ExcelColumn(Name = "仓库")]
        [ExcelColumnName("仓库")]
        public string TeSloc { get; set; }

        [ExcelColumn(Name = "检验否")]
        [ExcelColumnName("检验否")]
        public string TeInsmk { get; set; }

        [ExcelColumn(Name = "工厂状态")]
        [ExcelColumnName("工厂状态")]
        public string TePlntStated { get; set; }

        [Required(ErrorMessage = "SOP不能为空")]
        [ExcelColumn(Name = "SOP")]
        [ExcelColumnName("SOP")]
        public int TeSopStated { get; set; }

        [Required(ErrorMessage = "实施标记不能为空")]
        [ExcelColumn(Name = "实施标记")]
        [ExcelColumnName("实施标记")]
        public int TeImplStated { get; set; }

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
        public string TePurTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "仓库")]
        public string TeSlocLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "检验否")]
        public string TeInsmkLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "工厂状态")]
        public string TePlntStatedLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}