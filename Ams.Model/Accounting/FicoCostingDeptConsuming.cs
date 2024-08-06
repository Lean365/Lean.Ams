namespace Ams.Model.Accounting
{
    /// <summary>
    /// 部门消耗
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:22
    /// </summary>
    [SugarTable("fico_costing_dept_consuming", "部门消耗")]
    public class FicoCostingDeptConsuming
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long DcSfId { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "DcFy", ColumnDescription = "期间  ", Length = 6)]
        public string DcFy { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "DcYm", ColumnDescription = "年月  ", Length = 6)]
        public string DcYm { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "DcCorpCode", ColumnDescription = "公司代码  ", Length = 4)]
        public string DcCorpCode { get; set; }

        /// <summary>
        /// 统计类别
        /// </summary>
        [SugarColumn(ColumnName = "DcExpCategory", ColumnDescription = "统计类别  ", Length = 10)]
        public string DcExpCategory { get; set; }

        /// <summary>
        /// 成本代码
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "DcCostCode", ColumnDescription = "成本代码  ", Length = 10)]
        public string DcCostCode { get; set; }

        /// <summary>
        /// 科目代码
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "DcTitleCode", ColumnDescription = "科目代码  ", Length = 10)]
        public string DcTitleCode { get; set; }

        /// <summary>
        /// 科目分类
        /// </summary>
        [SugarColumn(ColumnName = "DcTitleNote", ColumnDescription = "科目分类  ", Length = 40)]
        public string DcTitleNote { get; set; }

        /// <summary>
        /// 预算
        /// </summary>
        [SugarColumn(ColumnName = "DcBudgetAmt", ColumnDescription = "预算  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal DcBudgetAmt { get; set; }

        /// <summary>
        /// 实际
        /// </summary>
        [SugarColumn(ColumnName = "DcActualAmt", ColumnDescription = "实际  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal DcActualAmt { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        [SugarColumn(ColumnName = "DcDiffAmt", ColumnDescription = "差异  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal DcDiffAmt { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "DcPlant", ColumnDescription = "工厂  ", Length = 4)]
        public string DcPlant { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "DcMateriel", ColumnDescription = "物料  ", Length = 20)]
        public string DcMateriel { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        [SugarColumn(ColumnName = "DcStorageLocation", ColumnDescription = "仓库  ", Length = 4)]
        public string DcStorageLocation { get; set; }

        /// <summary>
        /// 移动类型
        /// </summary>
        [SugarColumn(ColumnName = "DcMoveType", ColumnDescription = "移动类型  ", Length = 3)]
        public string DcMoveType { get; set; }

        /// <summary>
        /// 物料凭证
        /// </summary>
        [SugarColumn(ColumnName = "DcMaterielDoc", ColumnDescription = "物料凭证  ", Length = 10)]
        public string DcMaterielDoc { get; set; }

        /// <summary>
        /// 凭证明细
        /// </summary>
        [SugarColumn(ColumnName = "DcMaterielDocDetails", ColumnDescription = "凭证明细  ", Length = 5)]
        public string DcMaterielDocDetails { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "DcUseQty", ColumnDescription = "数量  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal DcUseQty { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "DcCcy", ColumnDescription = "币种 ", Length = 3)]
        public string DcCcy { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [SugarColumn(ColumnName = "DcUseAmt", ColumnDescription = "金额  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal DcUseAmt { get; set; }

        /// <summary>
        /// 预留单
        /// </summary>
        [SugarColumn(ColumnName = "DcReserveDoc", ColumnDescription = "预留单  ", Length = 10)]
        public string DcReserveDoc { get; set; }

        /// <summary>
        /// 预留明细
        /// </summary>
        [SugarColumn(ColumnName = "DcAccountant", ColumnDescription = "预留明细  ", Length = 10)]
        public string DcAccountant { get; set; }

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