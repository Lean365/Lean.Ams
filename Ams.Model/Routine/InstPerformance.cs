namespace Ams.Model.Routine
{
    /// <summary>
    /// 机构目标
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 10:55:04
    /// </summary>
    [SugarTable("inst_performance", "机构目标")]
    public class InstPerformance : SysBase
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
        [SugarColumn(ColumnName = "Md002", ColumnDescription = "期间", Length = 6)]
        public string Md002 { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "Md003", ColumnDescription = "公司", Length = 4)]
        public string Md003 { get; set; }

        /// <summary>
        /// 翻译键值
        /// </summary>
        [SugarColumn(ColumnName = "Md004", ColumnDescription = "翻译键值", Length = 100)]
        public string Md004 { get; set; }

        /// <summary>
        /// 目标标识
        /// </summary>
        [SugarColumn(ColumnName = "Md005", ColumnDescription = "目标标识", Length = -1, ColumnDataType = "NVARCHAR")]
        public string Md005 { get; set; }
    }
}