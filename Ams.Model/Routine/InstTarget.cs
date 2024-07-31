namespace Ams.Model.Routine
{
    /// <summary>
    /// 机构目标
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/30 10:30:14
    /// </summary>
    [SugarTable("inst_target", "机构目标")]
    public class InstTarget : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long IkSfId { get; set; }

        /// <summary>
        /// 公司简称
        /// </summary>
        [SugarColumn(ColumnName = "IkAbbrName", ColumnDescription = "公司简称 ", Length = 255)]
        public string IkAbbrName { get; set; }

        /// <summary>
        /// 财年
        /// </summary>
        [SugarColumn(ColumnName = "IkAnnual", ColumnDescription = "财年 ", Length = 255)]
        public string IkAnnual { get; set; }

        /// <summary>
        /// 语言
        /// </summary>
        [SugarColumn(ColumnName = "IkLangKey", ColumnDescription = "语言 ", Length = 255)]
        public string IkLangKey { get; set; }

        /// <summary>
        /// 目标
        /// </summary>
        [SugarColumn(ColumnName = "IkTarget", ColumnDescription = "目标 ", Length = 255)]
        public string IkTarget { get; set; }
    }
}