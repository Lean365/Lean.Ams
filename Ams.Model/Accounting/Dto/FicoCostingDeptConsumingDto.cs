
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 部门消耗
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:22
    /// </summary>
    public class FicoCostingDeptConsumingQueryDto : PagerInfo 
    {
        public string DcFy { get; set; }
        public string DcYm { get; set; }
        public string DcCorpCode { get; set; }
    }

    /// <summary>
    /// 部门消耗
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:22
    /// </summary>
    public class FicoCostingDeptConsumingDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long DcSfId { get; set; }

        [ExcelColumn(Name = "期间 ")]
        [ExcelColumnName("期间 ")]
        public string DcFy { get; set; }

        [ExcelColumn(Name = "年月 ")]
        [ExcelColumnName("年月 ")]
        public string DcYm { get; set; }

        [ExcelColumn(Name = "公司代码 ")]
        [ExcelColumnName("公司代码 ")]
        public string DcCorpCode { get; set; }

        [ExcelColumn(Name = "公司名称 ")]
        [ExcelColumnName("公司名称 ")]
        public string DcCorpName { get; set; }

        [ExcelColumn(Name = "统计类别 ")]
        [ExcelColumnName("统计类别 ")]
        public string DcExpCategory { get; set; }

        [ExcelColumn(Name = "成本代码 ")]
        [ExcelColumnName("成本代码 ")]
        public string DcCostCode { get; set; }

        [ExcelColumn(Name = "成本名称 ")]
        [ExcelColumnName("成本名称 ")]
        public string DcCostName { get; set; }

        [ExcelColumn(Name = "科目代码 ")]
        [ExcelColumnName("科目代码 ")]
        public string DcTitleCode { get; set; }

        [ExcelColumn(Name = "科目名称 ")]
        [ExcelColumnName("科目名称 ")]
        public string DcTitleName { get; set; }

        [ExcelColumn(Name = "科目分类 ")]
        [ExcelColumnName("科目分类 ")]
        public string DcTitleNote { get; set; }

        [ExcelColumn(Name = "预算 ")]
        [ExcelColumnName("预算 ")]
        public decimal DcBudgetAmt { get; set; }

        [ExcelColumn(Name = "实际 ")]
        [ExcelColumnName("实际 ")]
        public decimal DcActualAmt { get; set; }

        [ExcelColumn(Name = "差异 ")]
        [ExcelColumnName("差异 ")]
        public decimal DcDiffAmt { get; set; }

        [ExcelColumn(Name = "工厂 ")]
        [ExcelColumnName("工厂 ")]
        public string DcPlant { get; set; }

        [ExcelColumn(Name = "物料 ")]
        [ExcelColumnName("物料 ")]
        public string DcMateriel { get; set; }

        [ExcelColumn(Name = "仓库 ")]
        [ExcelColumnName("仓库 ")]
        public string DcStorageLocation { get; set; }

        [ExcelColumn(Name = "移动类型 ")]
        [ExcelColumnName("移动类型 ")]
        public string DcMoveType { get; set; }

        [ExcelColumn(Name = "物料凭证 ")]
        [ExcelColumnName("物料凭证 ")]
        public string DcMaterielDoc { get; set; }

        [ExcelColumn(Name = "凭证明细 ")]
        [ExcelColumnName("凭证明细 ")]
        public string DcMaterielDocDetails { get; set; }

        [ExcelColumn(Name = "数量 ")]
        [ExcelColumnName("数量 ")]
        public decimal DcUseQty { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string DcCcy { get; set; }

        [ExcelColumn(Name = "金额 ")]
        [ExcelColumnName("金额 ")]
        public decimal DcUseAmt { get; set; }

        [ExcelColumn(Name = "预留单 ")]
        [ExcelColumnName("预留单 ")]
        public string DcReserveDoc { get; set; }

        [ExcelColumn(Name = "预留明细 ")]
        [ExcelColumnName("预留明细 ")]
        public string DcAccountant { get; set; }

        [ExcelColumn(Name = "登录日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("登录日期")]
        public DateTime? DcBalanceDate { get; set; }

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



        [ExcelColumn(Name = "期间 ")]
        public string DcFyLabel { get; set; }
        [ExcelColumn(Name = "年月 ")]
        public string DcYmLabel { get; set; }
        [ExcelColumn(Name = "公司代码 ")]
        public string DcCorpCodeLabel { get; set; }
        [ExcelColumn(Name = "成本代码 ")]
        public string DcCostCodeLabel { get; set; }
        [ExcelColumn(Name = "科目代码 ")]
        public string DcTitleCodeLabel { get; set; }
        [ExcelColumn(Name = "科目分类 ")]
        public string DcTitleNoteLabel { get; set; }
        [ExcelColumn(Name = "工厂 ")]
        public string DcPlantLabel { get; set; }
        [ExcelColumn(Name = "币种")]
        public string DcCcyLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 部门消耗
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:22
    /// </summary>
    public class FicoCostingDeptConsumingImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long DcSfId { get; set; }

        [ExcelColumn(Name = "期间 ")]
        [ExcelColumnName("期间 ")]
        public string DcFy { get; set; }

        [ExcelColumn(Name = "年月 ")]
        [ExcelColumnName("年月 ")]
        public string DcYm { get; set; }

        [ExcelColumn(Name = "公司代码 ")]
        [ExcelColumnName("公司代码 ")]
        public string DcCorpCode { get; set; }

        [ExcelColumn(Name = "公司名称 ")]
        [ExcelColumnName("公司名称 ")]
        public string DcCorpName { get; set; }

        [ExcelColumn(Name = "统计类别 ")]
        [ExcelColumnName("统计类别 ")]
        public string DcExpCategory { get; set; }

        [ExcelColumn(Name = "成本代码 ")]
        [ExcelColumnName("成本代码 ")]
        public string DcCostCode { get; set; }

        [ExcelColumn(Name = "成本名称 ")]
        [ExcelColumnName("成本名称 ")]
        public string DcCostName { get; set; }

        [ExcelColumn(Name = "科目代码 ")]
        [ExcelColumnName("科目代码 ")]
        public string DcTitleCode { get; set; }

        [ExcelColumn(Name = "科目名称 ")]
        [ExcelColumnName("科目名称 ")]
        public string DcTitleName { get; set; }

        [ExcelColumn(Name = "科目分类 ")]
        [ExcelColumnName("科目分类 ")]
        public string DcTitleNote { get; set; }

        [ExcelColumn(Name = "预算 ")]
        [ExcelColumnName("预算 ")]
        public decimal DcBudgetAmt { get; set; }

        [ExcelColumn(Name = "实际 ")]
        [ExcelColumnName("实际 ")]
        public decimal DcActualAmt { get; set; }

        [ExcelColumn(Name = "差异 ")]
        [ExcelColumnName("差异 ")]
        public decimal DcDiffAmt { get; set; }

        [ExcelColumn(Name = "工厂 ")]
        [ExcelColumnName("工厂 ")]
        public string DcPlant { get; set; }

        [ExcelColumn(Name = "物料 ")]
        [ExcelColumnName("物料 ")]
        public string DcMateriel { get; set; }

        [ExcelColumn(Name = "仓库 ")]
        [ExcelColumnName("仓库 ")]
        public string DcStorageLocation { get; set; }

        [ExcelColumn(Name = "移动类型 ")]
        [ExcelColumnName("移动类型 ")]
        public string DcMoveType { get; set; }

        [ExcelColumn(Name = "物料凭证 ")]
        [ExcelColumnName("物料凭证 ")]
        public string DcMaterielDoc { get; set; }

        [ExcelColumn(Name = "凭证明细 ")]
        [ExcelColumnName("凭证明细 ")]
        public string DcMaterielDocDetails { get; set; }

        [ExcelColumn(Name = "数量 ")]
        [ExcelColumnName("数量 ")]
        public decimal DcUseQty { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string DcCcy { get; set; }

        [ExcelColumn(Name = "金额 ")]
        [ExcelColumnName("金额 ")]
        public decimal DcUseAmt { get; set; }

        [ExcelColumn(Name = "预留单 ")]
        [ExcelColumnName("预留单 ")]
        public string DcReserveDoc { get; set; }

        [ExcelColumn(Name = "预留明细 ")]
        [ExcelColumnName("预留明细 ")]
        public string DcAccountant { get; set; }

        [ExcelColumn(Name = "登录日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("登录日期")]
        public DateTime? DcBalanceDate { get; set; }

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
        [ExcelColumn(Name = "期间 ")]
        public string DcFyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月 ")]
        public string DcYmLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "公司代码 ")]
        public string DcCorpCodeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "成本代码 ")]
        public string DcCostCodeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "科目代码 ")]
        public string DcTitleCodeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "科目分类 ")]
        public string DcTitleNoteLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "工厂 ")]
        public string DcPlantLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string DcCcyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}