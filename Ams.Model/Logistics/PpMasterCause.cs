namespace Ams.Model.Logistics
{
    /// <summary>
    /// 原因类别
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:44:02
    /// </summary>
    [SugarTable("pp_master_cause", "原因类别")]
    public class PpMasterCause : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 原因类别
        /// </summary>
        [SugarColumn(ColumnName = "Ma002", ColumnDescription = "原因类别", Length = 50, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma002 { get; set; }

        /// <summary>
        /// 语言Key
        /// </summary>
        [SugarColumn(ColumnName = "Ma003", ColumnDescription = "语言Key", Length = 255)]
        public string Ma003 { get; set; }

        /// <summary>
        /// 原因名称
        /// </summary>
        [SugarColumn(ColumnName = "Ma004", ColumnDescription = "原因名称", Length = 255)]
        public string Ma004 { get; set; }
    }
}