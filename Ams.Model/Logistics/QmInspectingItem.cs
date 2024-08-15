namespace Ams.Model.Logistics
{
    /// <summary>
    /// 检测项目
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/19 9:07:59
    /// </summary>
    [SugarTable("qm_inspecting_item", "检测项目")]
    public class QmInspectingItem : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long QminsItemSfId { get; set; }

        /// <summary>
        /// 项目代码
        /// </summary>
        [SugarColumn(ColumnName = "QminsItemCode", ColumnDescription = "项目代码 ", Length = 20)]
        public string QminsItemCode { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [SugarColumn(ColumnName = "QminsItemName", ColumnDescription = "项目名称 ", Length = 10)]
        public string QminsItemName { get; set; }

        /// <summary>
        /// 项目类别
        /// </summary>
        [SugarColumn(ColumnName = "QminsItemType", ColumnDescription = "项目类别 ", Length = 20)]
        public string QminsItemType { get; set; }

        /// <summary>
        /// 检查工具
        /// </summary>
        [SugarColumn(ColumnName = "QminsItemQcTool", ColumnDescription = "检查工具 ", Length = 20)]
        public string QminsItemQcTool { get; set; }
    }
}