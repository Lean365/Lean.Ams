namespace Ams.Model.Logistics
{
    /// <summary>
    /// 检测项目
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 11:48:49
    /// </summary>
    [SugarTable("qm_insp_item", "检测项目")]
    public class QmInspItem : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 项目代码
        /// </summary>
        [SugarColumn(ColumnName = "Mh002", ColumnDescription = "项目代码", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mh002 { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [SugarColumn(ColumnName = "Mh003", ColumnDescription = "项目名称", Length = 10)]
        public string Mh003 { get; set; }

        /// <summary>
        /// 项目类别
        /// </summary>
        [SugarColumn(ColumnName = "Mh004", ColumnDescription = "项目类别", Length = 20)]
        public string Mh004 { get; set; }

        /// <summary>
        /// 检查工具
        /// </summary>
        [SugarColumn(ColumnName = "Mh005", ColumnDescription = "检查工具", Length = 20)]
        public string Mh005 { get; set; }
    }
}