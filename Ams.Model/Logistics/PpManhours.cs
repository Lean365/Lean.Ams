namespace Ams.Model.Logistics
{
    /// <summary>
    /// 标准工时
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:04:58
    /// </summary>
    [SugarTable("pp_manhours", "标准工时")]
    public class PpManhours : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long MhSfId { get; set; }

        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime? MhEffDate { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "MhPlant", ColumnDescription = "工厂 ", Length = 4)]
        public string MhPlant { get; set; }

        /// <summary>
        /// 机种名
        /// </summary>
        [SugarColumn(ColumnName = "MhModelType", ColumnDescription = "机种名 ", Length = 40)]
        public string MhModelType { get; set; }

        /// <summary>
        /// 仕向别
        /// </summary>
        [SugarColumn(ColumnName = "MhRegionType", ColumnDescription = "仕向别 ", Length = 20)]
        public string MhRegionType { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "MhItem", ColumnDescription = "物料 ", Length = 20)]
        public string MhItem { get; set; }

        /// <summary>
        /// 物料文本
        /// </summary>
        [SugarColumn(ColumnName = "MhItemText", ColumnDescription = "物料文本 ", Length = 40)]
        public string MhItemText { get; set; }

        /// <summary>
        /// 工作中心
        /// </summary>
        [SugarColumn(ColumnName = "MhWcName", ColumnDescription = "工作中心 ", Length = 40)]
        public string MhWcName { get; set; }

        /// <summary>
        /// 工作中心文本
        /// </summary>
        [SugarColumn(ColumnName = "MhWcText", ColumnDescription = "工作中心文本 ", Length = 40)]
        public string MhWcText { get; set; }

        /// <summary>
        /// 标准点数
        /// </summary>
        [SugarColumn(ColumnName = "MhStdShort", ColumnDescription = "标准点数 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal MhStdShort { get; set; }

        /// <summary>
        /// Short单位
        /// </summary>
        [SugarColumn(ColumnName = "MhShortUnit", ColumnDescription = "Short单位 ", Length = 31)]
        public string MhShortUnit { get; set; }

        /// <summary>
        /// 点数换算汇率
        /// </summary>
        [SugarColumn(ColumnName = "MhToMinRate", ColumnDescription = "点数换算汇率 ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal MhToMinRate { get; set; }

        /// <summary>
        /// 标准工时
        /// </summary>
        [SugarColumn(ColumnName = "MhStdTime", ColumnDescription = "标准工时 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal MhStdTime { get; set; }

        /// <summary>
        /// 工时单位
        /// </summary>
        [SugarColumn(ColumnName = "MhTimeUnit", ColumnDescription = "工时单位 ", Length = 3)]
        public string MhTimeUnit { get; set; }
    }
}