namespace Ams.Model.Logistics
{
    /// <summary>
    /// 原因类别
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:12:48
    /// </summary>
    [SugarTable("pp_cause_type", "原因类别")]
    public class PpCauseType : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long CtSfId { get; set; }

        /// <summary>
        /// 原因类别
        /// </summary>
        [SugarColumn(ColumnName = "CtCauseType", ColumnDescription = "原因类别 ", Length = 50)]
        public string CtCauseType { get; set; }

        /// <summary>
        /// 翻译Key
        /// </summary>
        [SugarColumn(ColumnName = "CtCauseLangCode", ColumnDescription = "翻译Key ", Length = 255)]
        public string CtCauseLangCode { get; set; }

        /// <summary>
        /// 原因名称
        /// </summary>
        [SugarColumn(ColumnName = "CtCauseText", ColumnDescription = "原因名称 ", Length = 255)]
        public string CtCauseText { get; set; }
    }
}