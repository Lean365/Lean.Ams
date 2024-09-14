namespace Ams.Model.Logistics
{
    /// <summary>
    /// 检查明细
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:55
    /// </summary>
    [SugarTable("pp_insp_pcba_slv", "检查明细")]
    public class PpInspPcbaSlv : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? ParentId { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        [SugarColumn(ColumnName = "Mv003", ColumnDescription = "批次", Length = 20)]
        public string Mv003 { get; set; }

        /// <summary>
        /// Lot数
        /// </summary>
        [SugarColumn(ColumnName = "Mv004", ColumnDescription = "Lot数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mv004 { get; set; }

        /// <summary>
        /// 板别
        /// </summary>
        [SugarColumn(ColumnName = "Mv005", ColumnDescription = "板别", Length = 30)]
        public string Mv005 { get; set; }

        /// <summary>
        /// 目视线别
        /// </summary>
        [SugarColumn(ColumnName = "Mv006", ColumnDescription = "目视线别", Length = 30)]
        public string Mv006 { get; set; }

        /// <summary>
        /// AOI线别
        /// </summary>
        [SugarColumn(ColumnName = "Mv007", ColumnDescription = "AOI线别", Length = 30)]
        public string Mv007 { get; set; }

        /// <summary>
        /// B面实装
        /// </summary>
        public DateTime? Mv008 { get; set; }

        /// <summary>
        /// T面实装
        /// </summary>
        public DateTime? Mv009 { get; set; }

        /// <summary>
        /// 生产班别
        /// </summary>
        [SugarColumn(ColumnName = "Mv010", ColumnDescription = "生产班别", Length = 20)]
        public string Mv010 { get; set; }

        /// <summary>
        /// 检查员
        /// </summary>
        [SugarColumn(ColumnName = "Mv011", ColumnDescription = "检查员", Length = 20)]
        public string Mv011 { get; set; }

        /// <summary>
        /// 当日完成数
        /// </summary>
        [SugarColumn(ColumnName = "Mv012", ColumnDescription = "当日完成数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mv012 { get; set; }

        /// <summary>
        /// 累计完成数
        /// </summary>
        [SugarColumn(ColumnName = "Mv013", ColumnDescription = "累计完成数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mv013 { get; set; }

        /// <summary>
        /// 检查台数
        /// </summary>
        [SugarColumn(ColumnName = "Mv014", ColumnDescription = "检查台数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mv014 { get; set; }

        /// <summary>
        /// 检查状态
        /// </summary>
        [SugarColumn(ColumnName = "Mv015", ColumnDescription = "检查状态", Length = 30)]
        public string Mv015 { get; set; }

        /// <summary>
        /// 生产线别
        /// </summary>
        [SugarColumn(ColumnName = "Mv016", ColumnDescription = "生产线别", Length = 20)]
        public string Mv016 { get; set; }

        /// <summary>
        /// 检查工数
        /// </summary>
        [SugarColumn(ColumnName = "Mv017", ColumnDescription = "检查工数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mv017 { get; set; }

        /// <summary>
        /// AOI工数
        /// </summary>
        [SugarColumn(ColumnName = "Mv018", ColumnDescription = "AOI工数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mv018 { get; set; }

        /// <summary>
        /// 不良数量
        /// </summary>
        [SugarColumn(ColumnName = "Mv019", ColumnDescription = "不良数量", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mv019 { get; set; }

        /// <summary>
        /// 手贴部品
        /// </summary>
        [SugarColumn(ColumnName = "Mv020", ColumnDescription = "手贴部品", Length = 30)]
        public string Mv020 { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [SugarColumn(ColumnName = "Mv021", ColumnDescription = "序列号", Length = 200)]
        public string Mv021 { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [SugarColumn(ColumnName = "Mv022", ColumnDescription = "内容", Length = 30)]
        public string Mv022 { get; set; }

        /// <summary>
        /// 个所区分
        /// </summary>
        [SugarColumn(ColumnName = "Mv023", ColumnDescription = "个所区分", Length = 200)]
        public string Mv023 { get; set; }
    }
}