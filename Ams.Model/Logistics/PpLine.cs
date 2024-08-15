namespace Ams.Model.Logistics
{
    /// <summary>
    /// 生产班组
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 14:45:07
    /// </summary>
    [SugarTable("pp_line", "生产班组")]
    public class PpLine : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long PlSfId { get; set; }

        /// <summary>
        /// 班组类别
        /// </summary>
        [SugarColumn(ColumnName = "PlLineType", ColumnDescription = "班组类别 ", Length = 200)]
        public string PlLineType { get; set; }

        /// <summary>
        /// 班组代码
        /// </summary>
        [SugarColumn(ColumnName = "PlLineCode", ColumnDescription = "班组代码 ", Length = 200)]
        public string PlLineCode { get; set; }

        /// <summary>
        /// 翻译Key
        /// </summary>
        [SugarColumn(ColumnName = "PlLineLangCode", ColumnDescription = "翻译Key ", Length = 200)]
        public string PlLineLangCode { get; set; }

        /// <summary>
        /// 班组名称
        /// </summary>
        [SugarColumn(ColumnName = "PlLineName", ColumnDescription = "班组名称 ", Length = 200)]
        public string PlLineName { get; set; }
    }
}