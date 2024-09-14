namespace Ams.Model.Logistics
{
    /// <summary>
    /// 抽样标准
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:39:16
    /// </summary>
    [SugarTable("qm_insp_aql", "抽样标准")]
    public class QmInspAql : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 查检水平
        /// </summary>
        [SugarColumn(ColumnName = "Mg002", ColumnDescription = "查检水平", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mg002 { get; set; }

        /// <summary>
        /// 批量范围
        /// </summary>
        [SugarColumn(ColumnName = "Mg003", ColumnDescription = "批量范围", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mg003 { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        [SugarColumn(ColumnName = "Mg004", ColumnDescription = "最小值", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg004 { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        [SugarColumn(ColumnName = "Mg005", ColumnDescription = "最大值", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg005 { get; set; }

        /// <summary>
        /// 样本码
        /// </summary>
        [SugarColumn(ColumnName = "Mg006", ColumnDescription = "样本码", Length = 4)]
        public string Mg006 { get; set; }

        /// <summary>
        /// 抽样数
        /// </summary>
        [SugarColumn(ColumnName = "Mg007", ColumnDescription = "抽样数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg007 { get; set; }

        /// <summary>
        /// 合格项
        /// </summary>
        [SugarColumn(ColumnName = "Mg008", ColumnDescription = "合格项", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg008 { get; set; }

        /// <summary>
        /// 不合格项
        /// </summary>
        [SugarColumn(ColumnName = "Mg009", ColumnDescription = "不合格项", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg009 { get; set; }
    }
}