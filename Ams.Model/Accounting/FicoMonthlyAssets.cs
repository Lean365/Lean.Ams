namespace Ams.Model.Accounting
{
    /// <summary>
    /// 固定资产
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:16
    /// </summary>
    [SugarTable("fico_monthly_assets", "固定资产")]
    public class FicoMonthlyAssets
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FaSfId { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "FaCorp", ColumnDescription = "公司  ", Length = 255)]
        public string FaCorp { get; set; }

        /// <summary>
        /// 使用部门
        /// </summary>
        [SugarColumn(ColumnName = "FaDept", ColumnDescription = "使用部门  ", Length = 255)]
        public string FaDept { get; set; }

        /// <summary>
        /// 资产类别
        /// </summary>
        [SugarColumn(ColumnName = "FaClassCode", ColumnDescription = "资产类别  ", Length = 255)]
        public string FaClassCode { get; set; }

        /// <summary>
        /// 资产编码
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "FaAssetNo", ColumnDescription = "资产编码  ", Length = 255)]
        public string FaAssetNo { get; set; }

        /// <summary>
        /// 成本中心
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "FaCostCenter", ColumnDescription = "成本中心  ", Length = 255)]
        public string FaCostCenter { get; set; }

        /// <summary>
        /// 资产简称
        /// </summary>
        [SugarColumn(ColumnName = "FaAssetShortName", ColumnDescription = "资产简称  ", Length = 255)]
        public string FaAssetShortName { get; set; }

        /// <summary>
        /// 资产全称
        /// </summary>
        [SugarColumn(ColumnName = "FaAssetFullName", ColumnDescription = "资产全称  ", Length = 255)]
        public string FaAssetFullName { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [SugarColumn(ColumnName = "FaAssetUnit", ColumnDescription = "单位  ", Length = 255)]
        public string FaAssetUnit { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "FaAssetQty", ColumnDescription = "数量  ", DefaultValue = "0")]
        public int? FaAssetQty { get; set; }

        /// <summary>
        /// 管理区分
        /// </summary>
        [SugarColumn(ColumnName = "FaAssetMana", ColumnDescription = "管理区分  ", DefaultValue = "0")]
        public int? FaAssetMana { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "FaAssetCcy", ColumnDescription = "币种  ", Length = 3)]
        public string FaAssetCcy { get; set; }

        /// <summary>
        /// 购买价格
        /// </summary>
        [SugarColumn(ColumnName = "FaAcquisitionPrice", ColumnDescription = "购买价格  ", DefaultValue = "0", Length = 18, DecimalDigits = 0)]
        public decimal FaAcquisitionPrice { get; set; }

        /// <summary>
        /// 资本化日期
        /// </summary>
        public DateTime? FaCapitalizedDate { get; set; }

        /// <summary>
        /// 折旧价值
        /// </summary>
        [SugarColumn(ColumnName = "FaDepreciationValue", ColumnDescription = "折旧价值  ", DefaultValue = "0", Length = 18, DecimalDigits = 0)]
        public decimal FaDepreciationValue { get; set; }

        /// <summary>
        /// 报废日期
        /// </summary>
        public DateTime? FaScrapDate { get; set; }

        /// <summary>
        /// 报废价值
        /// </summary>
        [SugarColumn(ColumnName = "FaScrapValue", ColumnDescription = "报废价值  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FaScrapValue { get; set; }

        /// <summary>
        /// 存放位置
        /// </summary>
        [SugarColumn(ColumnName = "FaLocale", ColumnDescription = "存放位置  ", Length = 255)]
        public string FaLocale { get; set; }

        /// <summary>
        /// 使用年限
        /// </summary>
        [SugarColumn(ColumnName = "FaAssetUsed", ColumnDescription = "使用年限  ", DefaultValue = "0", Length = 18, DecimalDigits = 0)]
        public decimal FaAssetUsed { get; set; }

        /// <summary>
        /// 是否停用
        /// </summary>
        [SugarColumn(ColumnName = "FaAssetStop", ColumnDescription = "是否停用  ", DefaultValue = "0")]
        public int? FaAssetStop { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        [SugarColumn(ColumnName = "FaAssetVender", ColumnDescription = "供应商  ", Length = 255)]
        public string FaAssetVender { get; set; }

        /// <summary>
        /// 制造商
        /// </summary>
        [SugarColumn(ColumnName = "FaAssetManufacturer", ColumnDescription = "制造商  ", Length = 255)]
        public string FaAssetManufacturer { get; set; }

        /// <summary>
        /// 供应商物料
        /// </summary>
        [SugarColumn(ColumnName = "FaAssetVenderItem", ColumnDescription = "供应商物料  ", Length = 255)]
        public string FaAssetVenderItem { get; set; }

        /// <summary>
        /// 制造商物料
        /// </summary>
        [SugarColumn(ColumnName = "FaAssetManufacturerItem", ColumnDescription = "制造商物料  ", Length = 255)]
        public string FaAssetManufacturerItem { get; set; }

        /// <summary>
        /// 资产形态
        /// </summary>
        [SugarColumn(ColumnName = "FaEntity", ColumnDescription = "资产形态  ", DefaultValue = "0")]
        public int? FaEntity { get; set; }

        /// <summary>
        /// 资产存在否
        /// </summary>
        [SugarColumn(ColumnName = "FaHaveorNot", ColumnDescription = "资产存在否  ", DefaultValue = "0")]
        public int? FaHaveorNot { get; set; }

        /// <summary>
        /// 盘点人员
        /// </summary>
        [SugarColumn(ColumnName = "FaCheckedby", ColumnDescription = "盘点人员  ", Length = 255)]
        public string FaCheckedby { get; set; }

        /// <summary>
        /// 盘点日期
        /// </summary>
        public DateTime? FaCheckedDate { get; set; }

        /// <summary>
        /// 预留A
        /// </summary>
        [SugarColumn(ColumnName = "REF01", ColumnDescription = "预留A  ", Length = 1)]
        public string REF01 { get; set; }

        /// <summary>
        /// 预留B
        /// </summary>
        [SugarColumn(ColumnName = "REF02", ColumnDescription = "预留B  ", Length = 8)]
        public string REF02 { get; set; }

        /// <summary>
        /// 预留C
        /// </summary>
        [SugarColumn(ColumnName = "REF03", ColumnDescription = "预留C  ", Length = 30)]
        public string REF03 { get; set; }

        /// <summary>
        /// 预留1
        /// </summary>
        [SugarColumn(ColumnName = "REF04", ColumnDescription = "预留1  ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal REF04 { get; set; }

        /// <summary>
        /// 预留2
        /// </summary>
        [SugarColumn(ColumnName = "REF05", ColumnDescription = "预留2  ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal REF05 { get; set; }

        /// <summary>
        /// 预留3
        /// </summary>
        [SugarColumn(ColumnName = "REF06", ColumnDescription = "预留3 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal REF06 { get; set; }

        /// <summary>
        /// 自定义A
        /// </summary>
        [SugarColumn(ColumnName = "UDF01", ColumnDescription = "自定义A  ", Length = 200)]
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B
        /// </summary>
        [SugarColumn(ColumnName = "UDF02", ColumnDescription = "自定义B  ", Length = 200)]
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C
        /// </summary>
        [SugarColumn(ColumnName = "UDF03", ColumnDescription = "自定义C  ", Length = 200)]
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D
        /// </summary>
        [SugarColumn(ColumnName = "UDF04", ColumnDescription = "自定义D  ", Length = 500)]
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E
        /// </summary>
        [SugarColumn(ColumnName = "UDF05", ColumnDescription = "自定义E  ", Length = 500)]
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F
        /// </summary>
        [SugarColumn(ColumnName = "UDF06", ColumnDescription = "自定义F  ", Length = 500)]
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1
        /// </summary>
        [SugarColumn(ColumnName = "UDF51", ColumnDescription = "自定义1  ", DefaultValue = "0")]
        public int? UDF51 { get; set; }

        /// <summary>
        /// 自定义2
        /// </summary>
        [SugarColumn(ColumnName = "UDF52", ColumnDescription = "自定义2  ", DefaultValue = "0")]
        public int? UDF52 { get; set; }

        /// <summary>
        /// 自定义3
        /// </summary>
        [SugarColumn(ColumnName = "UDF53", ColumnDescription = "自定义3  ", DefaultValue = "0")]
        public int? UDF53 { get; set; }

        /// <summary>
        /// 自定义4
        /// </summary>
        [SugarColumn(ColumnName = "UDF54", ColumnDescription = "自定义4  ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5
        /// </summary>
        [SugarColumn(ColumnName = "UDF55", ColumnDescription = "自定义5  ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6
        /// </summary>
        [SugarColumn(ColumnName = "UDF56", ColumnDescription = "自定义6  ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        [SugarColumn(ColumnName = "IsDeleted", ColumnDescription = "软删除 ", DefaultValue = "0")]
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        [SugarColumn(ColumnName = "Remark", ColumnDescription = "备注说明 ", Length = 500)]
        public string Remark { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新人员
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }
    }
}