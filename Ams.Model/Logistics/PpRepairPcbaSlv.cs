namespace Ams.Model.Logistics
{
    /// <summary>
    /// 修理明细
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:47
    /// </summary>
    [SugarTable("pp_repair_pcba_slv", "修理明细")]
    public class PpRepairPcbaSlv : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? ParentId { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [SugarColumn(ColumnName = "Mha003", ColumnDescription = "批次", Length = 20)]
        public string Mha003 { get; set; }

        /// <summary>
        /// 板别
        /// </summary>
        [SugarColumn(ColumnName = "Mha004", ColumnDescription = "板别", Length = 30)]
        public string Mha004 { get; set; }

        /// <summary>
        /// Lot数
        /// </summary>
        [SugarColumn(ColumnName = "Mha005", ColumnDescription = "Lot数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mha005 { get; set; }

        /// <summary>
        /// 当日生产数
        /// </summary>
        [SugarColumn(ColumnName = "Mha006", ColumnDescription = "当日生产数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mha006 { get; set; }

        /// <summary>
        /// 累计完成数
        /// </summary>
        [SugarColumn(ColumnName = "Mha007", ColumnDescription = "累计完成数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mha007 { get; set; }

        /// <summary>
        /// 生产组别
        /// </summary>
        [SugarColumn(ColumnName = "Mha008", ColumnDescription = "生产组别", Length = 20)]
        public string Mha008 { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        [SugarColumn(ColumnName = "Mha009", ColumnDescription = "卡号", Length = 30)]
        public string Mha009 { get; set; }

        /// <summary>
        /// 不良症状
        /// </summary>
        [SugarColumn(ColumnName = "Mha010", ColumnDescription = "不良症状", Length = 200)]
        public string Mha010 { get; set; }

        /// <summary>
        /// 检出工程
        /// </summary>
        [SugarColumn(ColumnName = "Mha011", ColumnDescription = "检出工程", Length = 30)]
        public string Mha011 { get; set; }

        /// <summary>
        /// 不良原因
        /// </summary>
        [SugarColumn(ColumnName = "Mha012", ColumnDescription = "不良原因", Length = 200)]
        public string Mha012 { get; set; }

        /// <summary>
        /// 不良数量
        /// </summary>
        [SugarColumn(ColumnName = "Mha013", ColumnDescription = "不良数量", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mha013 { get; set; }

        /// <summary>
        /// 累计不良台数
        /// </summary>
        [SugarColumn(ColumnName = "Mha014", ColumnDescription = "累计不良台数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mha014 { get; set; }

        /// <summary>
        /// 责任归属
        /// </summary>
        [SugarColumn(ColumnName = "Mha015", ColumnDescription = "责任归属", Length = 200)]
        public string Mha015 { get; set; }

        /// <summary>
        /// 不良性质
        /// </summary>
        [SugarColumn(ColumnName = "Mha016", ColumnDescription = "不良性质", Length = 200)]
        public string Mha016 { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [SugarColumn(ColumnName = "Mha017", ColumnDescription = "序列号", Length = 200)]
        public string Mha017 { get; set; }

        /// <summary>
        /// 修理
        /// </summary>
        [SugarColumn(ColumnName = "Mha018", ColumnDescription = "修理", Length = 200)]
        public string Mha018 { get; set; }
    }
}