namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 固定资产
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/4 15:23:24
    /// </summary>
    public class FicoAssetQueryDto : PagerInfo
    {
        public string FaCorp { get; set; }
        public string FaDept { get; set; }
        public string FaClassCode { get; set; }
        public string FaAssetNo { get; set; }
        public string FaCostCenter { get; set; }
        public string FaAssetShortName { get; set; }
        public string FaAssetFullName { get; set; }
        public string FaAssetUnit { get; set; }
        public int? FaAssetMana { get; set; }
        public string FaAssetCcy { get; set; }
        public DateTime? BeginFaCapitalizedDate { get; set; }
        public DateTime? EndFaCapitalizedDate { get; set; }
        public DateTime? BeginFaScrapDate { get; set; }
        public DateTime? EndFaScrapDate { get; set; }
        public string FaLocale { get; set; }
        public decimal? FaAssetUsed { get; set; }
        public int? FaAssetStop { get; set; }
        public int? FaEntity { get; set; }
        public int? FaHaveorNot { get; set; }
        public DateTime? BeginFaCheckedDate { get; set; }
        public DateTime? EndFaCheckedDate { get; set; }
    }

    /// <summary>
    /// 固定资产
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/4 15:23:24
    /// </summary>
    public class FicoAssetDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FaSFID { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FaCorp { get; set; }

        [Required(ErrorMessage = "使用部门不能为空")]
        [ExcelColumn(Name = "使用部门")]
        [ExcelColumnName("使用部门")]
        public string FaDept { get; set; }

        [Required(ErrorMessage = "资产类别不能为空")]
        [ExcelColumn(Name = "资产类别")]
        [ExcelColumnName("资产类别")]
        public string FaClassCode { get; set; }

        [Required(ErrorMessage = "资产编码不能为空")]
        [ExcelColumn(Name = "资产编码")]
        [ExcelColumnName("资产编码")]
        public string FaAssetNo { get; set; }

        [Required(ErrorMessage = "成本中心不能为空")]
        [ExcelColumn(Name = "成本中心")]
        [ExcelColumnName("成本中心")]
        public string FaCostCenter { get; set; }

        [Required(ErrorMessage = "资产简称不能为空")]
        [ExcelColumn(Name = "资产简称")]
        [ExcelColumnName("资产简称")]
        public string FaAssetShortName { get; set; }

        [Required(ErrorMessage = "资产全称不能为空")]
        [ExcelColumn(Name = "资产全称")]
        [ExcelColumnName("资产全称")]
        public string FaAssetFullName { get; set; }

        [Required(ErrorMessage = "单位不能为空")]
        [ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]
        public string FaAssetUnit { get; set; }

        [Required(ErrorMessage = "数量不能为空")]
        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public int FaAssetQty { get; set; }

        [Required(ErrorMessage = "管理区分不能为空")]
        [ExcelColumn(Name = "管理区分")]
        [ExcelColumnName("管理区分")]
        public int FaAssetMana { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string FaAssetCcy { get; set; }

        [Required(ErrorMessage = "购买价格不能为空")]
        [ExcelColumn(Name = "购买价格")]
        [ExcelColumnName("购买价格")]
        public decimal FaAcquisitionPrice { get; set; }

        [Required(ErrorMessage = "资本化日期不能为空")]
        [ExcelColumn(Name = "资本化日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("资本化日期")]
        public DateTime? FaCapitalizedDate { get; set; }

        [Required(ErrorMessage = "折旧价值不能为空")]
        [ExcelColumn(Name = "折旧价值")]
        [ExcelColumnName("折旧价值")]
        public decimal FaDepreciationValue { get; set; }

        [ExcelColumn(Name = "报废日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("报废日期")]
        public DateTime? FaScrapDate { get; set; }

        [ExcelColumn(Name = "报废价值")]
        [ExcelColumnName("报废价值")]
        public decimal FaScrapValue { get; set; }

        [Required(ErrorMessage = "存放位置不能为空")]
        [ExcelColumn(Name = "存放位置")]
        [ExcelColumnName("存放位置")]
        public string FaLocale { get; set; }

        [Required(ErrorMessage = "使用年限不能为空")]
        [ExcelColumn(Name = "使用年限")]
        [ExcelColumnName("使用年限")]
        public decimal FaAssetUsed { get; set; }

        [Required(ErrorMessage = "是否停用不能为空")]
        [ExcelColumn(Name = "是否停用")]
        [ExcelColumnName("是否停用")]
        public int FaAssetStop { get; set; }

        [ExcelColumn(Name = "供应商")]
        [ExcelColumnName("供应商")]
        public string FaAssetVender { get; set; }

        [ExcelColumn(Name = "制造商")]
        [ExcelColumnName("制造商")]
        public string FaAssetManufacturer { get; set; }

        [ExcelColumn(Name = "供应商物料")]
        [ExcelColumnName("供应商物料")]
        public string FaAssetVenderItem { get; set; }

        [ExcelColumn(Name = "制造商物料")]
        [ExcelColumnName("制造商物料")]
        public string FaAssetManufacturerItem { get; set; }

        [Required(ErrorMessage = "资产形态不能为空")]
        [ExcelColumn(Name = "资产形态")]
        [ExcelColumnName("资产形态")]
        public int FaEntity { get; set; }

        [Required(ErrorMessage = "资产存在否不能为空")]
        [ExcelColumn(Name = "资产存在否")]
        [ExcelColumnName("资产存在否")]
        public int FaHaveorNot { get; set; }

        [Required(ErrorMessage = "盘点人员不能为空")]
        [ExcelColumn(Name = "盘点人员")]
        [ExcelColumnName("盘点人员")]
        public string FaCheckedby { get; set; }

        [Required(ErrorMessage = "盘点日期不能为空")]
        [ExcelColumn(Name = "盘点日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("盘点日期")]
        public DateTime? FaCheckedDate { get; set; }

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

        [ExcelColumn(Name = "公司")]
        public string FaCorpLabel { get; set; }

        [ExcelColumn(Name = "使用部门")]
        public string FaDeptLabel { get; set; }

        [ExcelColumn(Name = "资产类别")]
        public string FaClassCodeLabel { get; set; }

        [ExcelColumn(Name = "成本中心")]
        public string FaCostCenterLabel { get; set; }

        [ExcelColumn(Name = "单位")]
        public string FaAssetUnitLabel { get; set; }

        [ExcelColumn(Name = "管理区分")]
        public string FaAssetManaLabel { get; set; }

        [ExcelColumn(Name = "币种")]
        public string FaAssetCcyLabel { get; set; }

        [ExcelColumn(Name = "是否停用")]
        public string FaAssetStopLabel { get; set; }

        [ExcelColumn(Name = "资产形态")]
        public string FaEntityLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}