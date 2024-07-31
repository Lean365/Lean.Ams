namespace Ams.Model.Logistics
{
    /// <summary>
    /// 主源设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:08:51
    /// </summary>
    [SugarTable("pp_source_ec_ma", "主源设变")]
    public class PpSourceEcMa : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long SfId { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz001", ColumnDescription = "设变No. ", Length = 6)]
        public string Zpabdz001 { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz002", ColumnDescription = "机种 ", Length = 100)]
        public string Zpabdz002 { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz003", ColumnDescription = "标题 ", Length = 40)]
        public string Zpabdz003 { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz004", ColumnDescription = "状态 ", Length = 40)]
        public string Zpabdz004 { get; set; }

        /// <summary>
        /// 发行日
        /// </summary>
        public DateTime? Zpabdz005 { get; set; }

        /// <summary>
        /// 担当
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz006", ColumnDescription = "担当 ", Length = 100)]
        public string Zpabdz006 { get; set; }

        /// <summary>
        /// 依赖
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz007", ColumnDescription = "依赖 ", Length = 20)]
        public string Zpabdz007 { get; set; }

        /// <summary>
        /// 会议
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz008", ColumnDescription = "会议 ", Length = 20)]
        public string Zpabdz008 { get; set; }

        /// <summary>
        /// PP番号
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz009", ColumnDescription = "PP番号 ", Length = 10)]
        public string Zpabdz009 { get; set; }

        /// <summary>
        /// 联络书
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz010", ColumnDescription = "联络书 ", Length = 10)]
        public string Zpabdz010 { get; set; }

        /// <summary>
        /// 实施
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz011", ColumnDescription = "实施 ", Length = 40)]
        public string Zpabdz011 { get; set; }

        /// <summary>
        /// 主理由
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz012", ColumnDescription = "主理由 ", Length = 40)]
        public string Zpabdz012 { get; set; }

        /// <summary>
        /// 次理由
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz013", ColumnDescription = "次理由 ", Length = 40)]
        public string Zpabdz013 { get; set; }

        /// <summary>
        /// 安规
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz014", ColumnDescription = "安规 ", Length = 40)]
        public string Zpabdz014 { get; set; }

        /// <summary>
        /// 状况
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz015", ColumnDescription = "状况 ", Length = 40)]
        public string Zpabdz015 { get; set; }

        /// <summary>
        /// 机番
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz016", ColumnDescription = "机番 ", Length = 40)]
        public string Zpabdz016 { get; set; }

        /// <summary>
        /// 承认
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz017", ColumnDescription = "承认 ", Length = 40)]
        public string Zpabdz017 { get; set; }

        /// <summary>
        /// 服务手册订正
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz018", ColumnDescription = "服务手册订正 ", Length = 40)]
        public string Zpabdz018 { get; set; }

        /// <summary>
        /// 用户手册订正
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz019", ColumnDescription = "用户手册订正 ", Length = 40)]
        public string Zpabdz019 { get; set; }

        /// <summary>
        /// 宣传手册订正
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz020", ColumnDescription = "宣传手册订正 ", Length = 40)]
        public string Zpabdz020 { get; set; }

        /// <summary>
        /// SOP订正
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz021", ColumnDescription = "SOP订正 ", Length = 40)]
        public string Zpabdz021 { get; set; }

        /// <summary>
        /// 信息发行
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz022", ColumnDescription = "信息发行 ", Length = 40)]
        public string Zpabdz022 { get; set; }

        /// <summary>
        /// 成本变动
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz023", ColumnDescription = "成本变动 ", Length = 40)]
        public string Zpabdz023 { get; set; }

        /// <summary>
        /// 单位成本
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz024", ColumnDescription = "单位成本 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Zpabdz024 { get; set; }

        /// <summary>
        /// 模具改造费
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz025", ColumnDescription = "模具改造费 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Zpabdz025 { get; set; }

        /// <summary>
        /// 图纸
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz026", ColumnDescription = "图纸 ", Length = 210)]
        public string Zpabdz026 { get; set; }

        /// <summary>
        /// 设变内容
        /// </summary>
        [SugarColumn(ColumnName = "Zpabdz027", ColumnDescription = "设变内容 ", Length = 4000)]
        public string Zpabdz027 { get; set; }

        /// <summary>
        /// 处理标记
        /// </summary>
        [SugarColumn(ColumnName = "IsSolved", ColumnDescription = "处理标记 ", Length = 3)]
        public string IsSolved { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(PpSourceEcSlv.ParentSfId), nameof(SfId))] //自定义关系映射
        public List<PpSourceEcSlv> PpSourceEcSlvNav { get; set; }
    }
}