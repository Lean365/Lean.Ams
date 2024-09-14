namespace Ams.Model.Accounting
{
    /// <summary>
    /// 月度存货
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:55:10
    /// </summary>
    [SugarTable("fico_monthly_inventory", "月度存货")]
    public class FicoMonthlyInventory : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "Mp002", ColumnDescription = "期间", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mp002 { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "Mp003", ColumnDescription = "年月", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mp003 { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Mp004", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mp004 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Mp005", ColumnDescription = "物料", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mp005 { get; set; }

        /// <summary>
        /// 评估类
        /// </summary>
        [SugarColumn(ColumnName = "Mp006", ColumnDescription = "评估类", Length = 4)]
        public string Mp006 { get; set; }

        /// <summary>
        /// 价格控制
        /// </summary>
        [SugarColumn(ColumnName = "Mp007", ColumnDescription = "价格控制", Length = 1)]
        public string Mp007 { get; set; }

        /// <summary>
        /// 移动平均价
        /// </summary>
        [SugarColumn(ColumnName = "Mp008", ColumnDescription = "移动平均价", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mp008 { get; set; }

        /// <summary>
        /// Per单位
        /// </summary>
        [SugarColumn(ColumnName = "Mp009", ColumnDescription = "Per单位", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mp009 { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "Mp010", ColumnDescription = "币种", Length = 3)]
        public string Mp010 { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        [SugarColumn(ColumnName = "Mp011", ColumnDescription = "库存", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mp011 { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [SugarColumn(ColumnName = "Mp012", ColumnDescription = "金额", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mp012 { get; set; }

        /// <summary>
        /// 核算人员
        /// </summary>
        [SugarColumn(ColumnName = "Mp013", ColumnDescription = "核算人员", Length = 10)]
        public string Mp013 { get; set; }

        /// <summary>
        /// 核算日期
        /// </summary>
        public DateTime? Mp014 { get; set; }
    }
}