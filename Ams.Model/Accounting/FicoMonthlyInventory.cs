namespace Ams.Model.Accounting
{
    /// <summary>
    /// 月度存货
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:14
    /// </summary>
    [SugarTable("fico_monthly_inventory", "月度存货")]
    public class FicoMonthlyInventory
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long MiSfId { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "MiPlant", ColumnDescription = "工厂  ", Length = 4)]
        public string MiPlant { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "MiFy", ColumnDescription = "期间  ", Length = 6)]
        public string MiFy { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "MiYm", ColumnDescription = "年月  ", Length = 6)]
        public string MiYm { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "MiItem", ColumnDescription = "物料  ", Length = 20)]
        public string MiItem { get; set; }

        /// <summary>
        /// 评估类
        /// </summary>
        [SugarColumn(ColumnName = "MiValType", ColumnDescription = "评估类  ", Length = 4)]
        public string MiValType { get; set; }

        /// <summary>
        /// 价格控制
        /// </summary>
        [SugarColumn(ColumnName = "MiPriceControl", ColumnDescription = "价格控制  ", Length = 1)]
        public string MiPriceControl { get; set; }

        /// <summary>
        /// 移动平均价
        /// </summary>
        [SugarColumn(ColumnName = "MiMovingAverage", ColumnDescription = "移动平均价  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal MiMovingAverage { get; set; }

        /// <summary>
        /// Per单位
        /// </summary>
        [SugarColumn(ColumnName = "MiPerUnit", ColumnDescription = "Per单位  ", DefaultValue = "0")]
        public int? MiPerUnit { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "MiLocalCcy", ColumnDescription = "币种  ", Length = 3)]
        public string MiLocalCcy { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        [SugarColumn(ColumnName = "MiInventoryQty", ColumnDescription = "库存  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal MiInventoryQty { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [SugarColumn(ColumnName = "MiInventoryAmount", ColumnDescription = "金额  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal MiInventoryAmount { get; set; }

        /// <summary>
        /// 登录日期
        /// </summary>
        public DateTime? MiBalancedate { get; set; }

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