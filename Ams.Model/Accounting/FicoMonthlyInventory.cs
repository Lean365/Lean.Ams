namespace Ams.Model.Accounting
{
    /// <summary>
    /// 月度存货
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 11:52:42
    /// </summary>
    [SugarTable("fico_monthly_inventory", "月度存货")]
    public class FicoMonthlyInventory : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long MiSfId { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "MiLfgja", ColumnDescription = "期间", Length = 6)]
        public string MiLfgja { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "MiLfmon", ColumnDescription = "年月", Length = 6)]
        public string MiLfmon { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "MiWerks", ColumnDescription = "工厂", Length = 4)]
        public string MiWerks { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "MiMatnr", ColumnDescription = "物料", Length = 20)]
        public string MiMatnr { get; set; }

        /// <summary>
        /// 评估类
        /// </summary>
        [SugarColumn(ColumnName = "MiBklas", ColumnDescription = "评估类", Length = 4)]
        public string MiBklas { get; set; }

        /// <summary>
        /// 价格控制
        /// </summary>
        [SugarColumn(ColumnName = "MiVprsv", ColumnDescription = "价格控制", Length = 1)]
        public string MiVprsv { get; set; }

        /// <summary>
        /// 移动平均价
        /// </summary>
        [SugarColumn(ColumnName = "MiVerpr", ColumnDescription = "移动平均价", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal MiVerpr { get; set; }

        /// <summary>
        /// Per单位
        /// </summary>
        [SugarColumn(ColumnName = "MiPeinh", ColumnDescription = "Per单位", DefaultValue = "0")]
        public int? MiPeinh { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "MiWaers", ColumnDescription = "币种", Length = 3)]
        public string MiWaers { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        [SugarColumn(ColumnName = "MiLbkum", ColumnDescription = "库存", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal MiLbkum { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [SugarColumn(ColumnName = "MiSalk", ColumnDescription = "金额", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal MiSalk { get; set; }

        /// <summary>
        /// 核算人员
        /// </summary>
        [SugarColumn(ColumnName = "MiPresp", ColumnDescription = "核算人员", Length = 10)]
        public string MiPresp { get; set; }

        /// <summary>
        /// 核算日期
        /// </summary>
        public DateTime? MiZkdat { get; set; }
    }
}