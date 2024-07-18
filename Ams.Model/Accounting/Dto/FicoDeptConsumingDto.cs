namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 部门消耗
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:47:09
    /// </summary>
    public class FicoDeptConsumingQueryDto : PagerInfo
    {
        public string DcYm { get; set; }
        public string DcCorpCode { get; set; }
        public string DcPlant { get; set; }
    }

    /// <summary>
    /// 部门消耗
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:47:09
    /// </summary>
    public class FicoDeptConsumingDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long DcSFID { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string DcFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string DcYm { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        [ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string DcCorpCode { get; set; }

        [Required(ErrorMessage = "公司名称不能为空")]
        [ExcelColumn(Name = "公司名称")]
        [ExcelColumnName("公司名称")]
        public string DcCorpName { get; set; }

        [Required(ErrorMessage = "统计类别不能为空")]
        [ExcelColumn(Name = "统计类别")]
        [ExcelColumnName("统计类别")]
        public string DcExpCategory { get; set; }

        [Required(ErrorMessage = "成本代码不能为空")]
        [ExcelColumn(Name = "成本代码")]
        [ExcelColumnName("成本代码")]
        public string DcCostCode { get; set; }

        [Required(ErrorMessage = "成本名称不能为空")]
        [ExcelColumn(Name = "成本名称")]
        [ExcelColumnName("成本名称")]
        public string DcCostName { get; set; }

        [Required(ErrorMessage = "科目代码不能为空")]
        [ExcelColumn(Name = "科目代码")]
        [ExcelColumnName("科目代码")]
        public string DcTitleCode { get; set; }

        [Required(ErrorMessage = "科目名称不能为空")]
        [ExcelColumn(Name = "科目名称")]
        [ExcelColumnName("科目名称")]
        public string DcTitleName { get; set; }

        [Required(ErrorMessage = "科目分类不能为空")]
        [ExcelColumn(Name = "科目分类")]
        [ExcelColumnName("科目分类")]
        public string DcTitleNote { get; set; }

        [Required(ErrorMessage = "预算不能为空")]
        [ExcelColumn(Name = "预算")]
        [ExcelColumnName("预算")]
        public decimal DcBudgetAmt { get; set; }

        [Required(ErrorMessage = "实际不能为空")]
        [ExcelColumn(Name = "实际")]
        [ExcelColumnName("实际")]
        public decimal DcActualAmt { get; set; }

        [Required(ErrorMessage = "差异不能为空")]
        [ExcelColumn(Name = "差异")]
        [ExcelColumnName("差异")]
        public decimal DcDiffAmt { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string DcPlant { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string DcMateriel { get; set; }

        [Required(ErrorMessage = "仓库不能为空")]
        [ExcelColumn(Name = "仓库")]
        [ExcelColumnName("仓库")]
        public string DcStorageLocation { get; set; }

        [Required(ErrorMessage = "移动类型不能为空")]
        [ExcelColumn(Name = "移动类型")]
        [ExcelColumnName("移动类型")]
        public string DcMoveType { get; set; }

        [Required(ErrorMessage = "物料凭证不能为空")]
        [ExcelColumn(Name = "物料凭证")]
        [ExcelColumnName("物料凭证")]
        public string DcMaterielDoc { get; set; }

        [Required(ErrorMessage = "凭证明细不能为空")]
        [ExcelColumn(Name = "凭证明细")]
        [ExcelColumnName("凭证明细")]
        public string DcMaterielDocDetails { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal DcUseQty { get; set; }

        [Required(ErrorMessage = "金额不能为空")]
        [ExcelColumn(Name = "金额")]
        [ExcelColumnName("金额")]
        public decimal DcUseAmt { get; set; }

        [Required(ErrorMessage = "预留单不能为空")]
        [ExcelColumn(Name = "预留单")]
        [ExcelColumnName("预留单")]
        public string DcReserveDoc { get; set; }

        [Required(ErrorMessage = "预留明细不能为空")]
        [ExcelColumn(Name = "预留明细")]
        [ExcelColumnName("预留明细")]
        public string DcAccountant { get; set; }

        [Required(ErrorMessage = "登录日期不能为空")]
        [ExcelColumn(Name = "登录日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("登录日期")]
        public DateTime? DcBalanceDate { get; set; }

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

        [ExcelColumn(Name = "年月")]
        public string DcYmLabel { get; set; }

        [ExcelColumn(Name = "公司代码")]
        public string DcCorpCodeLabel { get; set; }

        [ExcelColumn(Name = "工厂")]
        public string DcPlantLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}