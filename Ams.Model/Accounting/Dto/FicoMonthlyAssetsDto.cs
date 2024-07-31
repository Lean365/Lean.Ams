
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 固定资产
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:56:51
    /// </summary>
    public class FicoMonthlyAssetsQueryDto : PagerInfo 
    {
        public string FaCorp { get; set; }
        public string FaDept { get; set; }
        public string FaClassCode { get; set; }
        public string FaAssetNo { get; set; }
        public string FaCostCenter { get; set; }
        public string FaAssetShortName { get; set; }
        public string FaAssetFullName { get; set; }
        public DateTime? BeginFaCapitalizedDate { get; set; }
        public DateTime? EndFaCapitalizedDate { get; set; }
        public DateTime? BeginFaScrapDate { get; set; }
        public DateTime? EndFaScrapDate { get; set; }
        public int? FaAssetStop { get; set; }
        public DateTime? BeginFaCheckedDate { get; set; }
        public DateTime? EndFaCheckedDate { get; set; }
    }

    /// <summary>
    /// 固定资产
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:56:51
    /// </summary>
    public class FicoMonthlyAssetsDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FaSfId { get; set; }

        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FaCorp { get; set; }

        [ExcelColumn(Name = "使用部门")]
        [ExcelColumnName("使用部门")]
        public string FaDept { get; set; }

        [ExcelColumn(Name = "资产类别")]
        [ExcelColumnName("资产类别")]
        public string FaClassCode { get; set; }

        [ExcelColumn(Name = "资产编码")]
        [ExcelColumnName("资产编码")]
        public string FaAssetNo { get; set; }

        [ExcelColumn(Name = "成本中心")]
        [ExcelColumnName("成本中心")]
        public string FaCostCenter { get; set; }

        [ExcelColumn(Name = "资产简称")]
        [ExcelColumnName("资产简称")]
        public string FaAssetShortName { get; set; }

        [ExcelColumn(Name = "资产全称")]
        [ExcelColumnName("资产全称")]
        public string FaAssetFullName { get; set; }

        [ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]
        public string FaAssetUnit { get; set; }

        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public int? FaAssetQty { get; set; }

        [ExcelColumn(Name = "管理区分")]
        [ExcelColumnName("管理区分")]
        public int? FaAssetMana { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string FaAssetCcy { get; set; }

        [ExcelColumn(Name = "购买价格")]
        [ExcelColumnName("购买价格")]
        public decimal FaAcquisitionPrice { get; set; }

        [ExcelColumn(Name = "资本化日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("资本化日期")]
        public DateTime? FaCapitalizedDate { get; set; }

        [ExcelColumn(Name = "折旧价值")]
        [ExcelColumnName("折旧价值")]
        public decimal FaDepreciationValue { get; set; }

        [ExcelColumn(Name = "报废日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("报废日期")]
        public DateTime? FaScrapDate { get; set; }

        [ExcelColumn(Name = "报废价值")]
        [ExcelColumnName("报废价值")]
        public decimal FaScrapValue { get; set; }

        [ExcelColumn(Name = "存放位置")]
        [ExcelColumnName("存放位置")]
        public string FaLocale { get; set; }

        [ExcelColumn(Name = "使用年限")]
        [ExcelColumnName("使用年限")]
        public decimal FaAssetUsed { get; set; }

        [ExcelColumn(Name = "是否停用")]
        [ExcelColumnName("是否停用")]
        public int? FaAssetStop { get; set; }

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

        [ExcelColumn(Name = "资产形态")]
        [ExcelColumnName("资产形态")]
        public int? FaEntity { get; set; }

        [ExcelColumn(Name = "资产存在否")]
        [ExcelColumnName("资产存在否")]
        public int? FaHaveorNot { get; set; }

        [ExcelColumn(Name = "盘点人员")]
        [ExcelColumnName("盘点人员")]
        public string FaCheckedby { get; set; }

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

        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



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

    /// <summary>
    /// 固定资产
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:56:51
    /// </summary>
    public class FicoMonthlyAssetsImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FaSfId { get; set; }

        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FaCorp { get; set; }

        [ExcelColumn(Name = "使用部门")]
        [ExcelColumnName("使用部门")]
        public string FaDept { get; set; }

        [ExcelColumn(Name = "资产类别")]
        [ExcelColumnName("资产类别")]
        public string FaClassCode { get; set; }

        [ExcelColumn(Name = "资产编码")]
        [ExcelColumnName("资产编码")]
        public string FaAssetNo { get; set; }

        [ExcelColumn(Name = "成本中心")]
        [ExcelColumnName("成本中心")]
        public string FaCostCenter { get; set; }

        [ExcelColumn(Name = "资产简称")]
        [ExcelColumnName("资产简称")]
        public string FaAssetShortName { get; set; }

        [ExcelColumn(Name = "资产全称")]
        [ExcelColumnName("资产全称")]
        public string FaAssetFullName { get; set; }

        [ExcelColumn(Name = "单位")]
        [ExcelColumnName("单位")]
        public string FaAssetUnit { get; set; }

        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public int? FaAssetQty { get; set; }

        [ExcelColumn(Name = "管理区分")]
        [ExcelColumnName("管理区分")]
        public int? FaAssetMana { get; set; }

        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string FaAssetCcy { get; set; }

        [ExcelColumn(Name = "购买价格")]
        [ExcelColumnName("购买价格")]
        public decimal FaAcquisitionPrice { get; set; }

        [ExcelColumn(Name = "资本化日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("资本化日期")]
        public DateTime? FaCapitalizedDate { get; set; }

        [ExcelColumn(Name = "折旧价值")]
        [ExcelColumnName("折旧价值")]
        public decimal FaDepreciationValue { get; set; }

        [ExcelColumn(Name = "报废日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("报废日期")]
        public DateTime? FaScrapDate { get; set; }

        [ExcelColumn(Name = "报废价值")]
        [ExcelColumnName("报废价值")]
        public decimal FaScrapValue { get; set; }

        [ExcelColumn(Name = "存放位置")]
        [ExcelColumnName("存放位置")]
        public string FaLocale { get; set; }

        [ExcelColumn(Name = "使用年限")]
        [ExcelColumnName("使用年限")]
        public decimal FaAssetUsed { get; set; }

        [ExcelColumn(Name = "是否停用")]
        [ExcelColumnName("是否停用")]
        public int? FaAssetStop { get; set; }

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

        [ExcelColumn(Name = "资产形态")]
        [ExcelColumnName("资产形态")]
        public int? FaEntity { get; set; }

        [ExcelColumn(Name = "资产存在否")]
        [ExcelColumnName("资产存在否")]
        public int? FaHaveorNot { get; set; }

        [ExcelColumn(Name = "盘点人员")]
        [ExcelColumnName("盘点人员")]
        public string FaCheckedby { get; set; }

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

        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "公司")]
        public string FaCorpLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "使用部门")]
        public string FaDeptLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "资产类别")]
        public string FaClassCodeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "成本中心")]
        public string FaCostCenterLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "单位")]
        public string FaAssetUnitLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "管理区分")]
        public string FaAssetManaLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string FaAssetCcyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "是否停用")]
        public string FaAssetStopLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "资产形态")]
        public string FaEntityLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}