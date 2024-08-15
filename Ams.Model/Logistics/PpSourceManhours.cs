namespace Ams.Model.Logistics
{
    /// <summary>
    /// 源工时
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:11:09
    /// </summary>
    [SugarTable("pp_source_manhours", "源工时")]
    public class PpSourceManhours : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long SfId { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Zpbldz001", ColumnDescription = "工厂 ", Length = 4)]
        public string Zpbldz001 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Zpbldz002", ColumnDescription = "物料 ", Length = 20)]
        public string Zpbldz002 { get; set; }

        /// <summary>
        /// 工作中心
        /// </summary>
        [SugarColumn(ColumnName = "Zpbldz003", ColumnDescription = "工作中心 ", Length = 10)]
        public string Zpbldz003 { get; set; }

        /// <summary>
        /// 工作中心描述
        /// </summary>
        [SugarColumn(ColumnName = "Zpbldz004", ColumnDescription = "工作中心描述 ", Length = 40)]
        public string Zpbldz004 { get; set; }

        /// <summary>
        /// 标准值
        /// </summary>
        [SugarColumn(ColumnName = "Zpbldz005", ColumnDescription = "标准值 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Zpbldz005 { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [SugarColumn(ColumnName = "Zpbldz006", ColumnDescription = "单位 ", Length = 1)]
        public string Zpbldz006 { get; set; }

        /// <summary>
        /// 标准值
        /// </summary>
        [SugarColumn(ColumnName = "Zpbldz007", ColumnDescription = "标准值 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Zpbldz007 { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [SugarColumn(ColumnName = "Zpbldz008", ColumnDescription = "单位 ", Length = 3)]
        public string Zpbldz008 { get; set; }
    }
}