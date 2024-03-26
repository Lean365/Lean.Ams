
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 固定资产
    /// 数据实体对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/3/18 16:31:28)
    /// </summary>
    [SugarTable("fico_asset")]
    public class Asset
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FaSFID { get; set; }

        /// <summary>
        /// 公司 
        /// </summary>
        public string FaCorp { get; set; }

        /// <summary>
        /// 使用部门 
        /// </summary>
        public string FaDept { get; set; }

        /// <summary>
        /// 资产类别 
        /// </summary>
        public string FaClassCode { get; set; }

        /// <summary>
        /// 资产编码 
        /// </summary>
        public string FaAssetNo { get; set; }

        /// <summary>
        /// 成本中心 
        /// </summary>
        public string FaCostCenter { get; set; }

        /// <summary>
        /// 资产简称 
        /// </summary>
        public string FaAssetShortName { get; set; }

        /// <summary>
        /// 资产全称 
        /// </summary>
        public string FaAssetFullName { get; set; }

        /// <summary>
        /// 单位 
        /// </summary>
        public string FaAssetUnit { get; set; }

        /// <summary>
        /// 数量 
        /// </summary>
        public int FaAssetQty { get; set; }

        /// <summary>
        /// 管理区分 
        /// </summary>
        public int FaAssetMana { get; set; }

        /// <summary>
        /// 币种 
        /// </summary>
        public string FaAssetCcy { get; set; }

        /// <summary>
        /// 购买价格 
        /// </summary>
        public decimal FaAcquisitionPrice { get; set; }

        /// <summary>
        /// 资本化日期 
        /// </summary>
        public DateTime? FaCapitalizedDate { get; set; }

        /// <summary>
        /// 折旧价值 
        /// </summary>
        public decimal FaDepreciationValue { get; set; }

        /// <summary>
        /// 报废日期 
        /// </summary>
        public DateTime? FaScrapDate { get; set; }

        /// <summary>
        /// 报废价值 
        /// </summary>
        public decimal FaScrapValue { get; set; }

        /// <summary>
        /// 存放位置 
        /// </summary>
        public string FaLocale { get; set; }

        /// <summary>
        /// 使用年限 
        /// </summary>
        public decimal FaAssetUsed { get; set; }

        /// <summary>
        /// 是否停用 
        /// </summary>
        public int FaAssetStop { get; set; }

        /// <summary>
        /// 供应商 
        /// </summary>
        public string FaAssetVender { get; set; }

        /// <summary>
        /// 制造商 
        /// </summary>
        public string FaAssetManufacturer { get; set; }

        /// <summary>
        /// 供应商物料 
        /// </summary>
        public string FaAssetVenderItem { get; set; }

        /// <summary>
        /// 制造商物料 
        /// </summary>
        public string FaAssetManufacturerItem { get; set; }

        /// <summary>
        /// 资产形态 
        /// </summary>
        public int FaEntity { get; set; }

        /// <summary>
        /// 资产存在否 
        /// </summary>
        public int FaHaveorNot { get; set; }

        /// <summary>
        /// 盘点人员 
        /// </summary>
        public string FaCheckedby { get; set; }

        /// <summary>
        /// 盘点日期 
        /// </summary>
        public DateTime? FaCheckedDate { get; set; }

        /// <summary>
        /// 自定义A 
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B 
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C 
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D 
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E 
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F 
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1 
        /// </summary>
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6 
        /// </summary>
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 创建者 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新者 
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