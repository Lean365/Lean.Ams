
namespace Ams.Model.Logistics
{
    /// <summary>
    /// 物料信息
    /// 数据实体
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/24 11:34:57)
    /// </summary>
    [SugarTable("mm_marb")]
    public class Marb
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long MmSFID { get; set; }

        /// <summary>
        /// 工厂 
        /// </summary>
        public string MmPlnt { get; set; }

        /// <summary>
        /// 物料 
        /// </summary>
        public string MmMatItem { get; set; }

        /// <summary>
        /// 行业类别 
        /// </summary>
        public string MmIndustry { get; set; }

        /// <summary>
        /// 物料类型 
        /// </summary>
        public string MmMatType { get; set; }

        /// <summary>
        /// 物料文本 
        /// </summary>
        public string MmMatDes { get; set; }

        /// <summary>
        /// 标准单位 
        /// </summary>
        public string MmBaseUnit { get; set; }

        /// <summary>
        /// 层次 
        /// </summary>
        public string MmProLevel { get; set; }

        /// <summary>
        /// 物料组 
        /// </summary>
        public string MmMatGroup { get; set; }

        /// <summary>
        /// 采购组 
        /// </summary>
        public string MmPurGroup { get; set; }

        /// <summary>
        /// 采购类型 
        /// </summary>
        public string MmPurType { get; set; }

        /// <summary>
        /// 特殊采购类 
        /// </summary>
        public string MmSpecType { get; set; }

        /// <summary>
        /// 散装物料 
        /// </summary>
        public string MmBulkMat { get; set; }

        /// <summary>
        /// 最小批量 
        /// </summary>
        public int MmMoq { get; set; }

        /// <summary>
        /// 舍入值 
        /// </summary>
        public int MmRoundingVal { get; set; }

        /// <summary>
        /// 交货时间 
        /// </summary>
        public int MmLeadTime { get; set; }

        /// <summary>
        /// 生产天数 
        /// </summary>
        public decimal MmProDays { get; set; }

        /// <summary>
        /// 检验否 
        /// </summary>
        public string MmisChecked { get; set; }

        /// <summary>
        /// 利润中心 
        /// </summary>
        public string MmProfitCenter { get; set; }

        /// <summary>
        /// 差异码 
        /// </summary>
        public string MmDiffCode { get; set; }

        /// <summary>
        /// 批次管理 
        /// </summary>
        public string MmisLot { get; set; }

        /// <summary>
        /// 制造商物料 
        /// </summary>
        public string MmMpn { get; set; }

        /// <summary>
        /// 制造商 
        /// </summary>
        public string MmMfrs { get; set; }

        /// <summary>
        /// 评估类 
        /// </summary>
        public string MmValType { get; set; }

        /// <summary>
        /// 移动平均价 
        /// </summary>
        public decimal MmMovingAvg { get; set; }

        /// <summary>
        /// 币种 
        /// </summary>
        public string MmCcy { get; set; }

        /// <summary>
        /// 价格控制 
        /// </summary>
        public string MmPriceControl { get; set; }

        /// <summary>
        /// 价格单位 
        /// </summary>
        public int MmPriceUnit { get; set; }

        /// <summary>
        /// 采购仓库 
        /// </summary>
        public string MmSLoc { get; set; }

        /// <summary>
        /// 生产仓库 
        /// </summary>
        public string MmESLoc { get; set; }

        /// <summary>
        /// 仓位 
        /// </summary>
        public string MmLocPosn { get; set; }

        /// <summary>
        /// 库存 
        /// </summary>
        public decimal MmInventory { get; set; }

        /// <summary>
        /// EOL 
        /// </summary>
        public string MmLocEol { get; set; }

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
        /// 软删除 
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remark { get; set; }

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