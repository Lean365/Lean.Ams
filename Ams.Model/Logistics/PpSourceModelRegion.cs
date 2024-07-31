namespace Ams.Model.Logistics
{
    /// <summary>
    /// 源机种仕向
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:18:52
    /// </summary>
    [SugarTable("pp_source_model_region", "源机种仕向")]
    public class PpSourceModelRegion : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long SfId { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Destz001", ColumnDescription = "物料 ", Length = 20)]
        public string Destz001 { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "Destz002", ColumnDescription = "机种 ", Length = 40)]
        public string Destz002 { get; set; }

        /// <summary>
        /// 仕向
        /// </summary>
        [SugarColumn(ColumnName = "Destz003", ColumnDescription = "仕向 ", Length = 40)]
        public string Destz003 { get; set; }
    }
}