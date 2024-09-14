namespace Ams.Model.Logistics
{
    /// <summary>
    /// 主源设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:09:51
    /// </summary>
    [SugarTable("pp_source_ec_ma", "主源设变")]
    public class PpSourceEcMa : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        /// <summary>
        /// 设变No.
        /// </summary>
        [SugarColumn(ColumnName = "Za002", ColumnDescription = "设变No.", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Za002 { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "Za003", ColumnDescription = "机种", Length = 100)]
        public string Za003 { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [SugarColumn(ColumnName = "Za004", ColumnDescription = "标题", Length = 50, ColumnDataType = "NVARCHAR")]
        public string Za004 { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnName = "Za005", ColumnDescription = "状态", Length = 40)]
        public string Za005 { get; set; }

        /// <summary>
        /// 发行日
        /// </summary>
        public DateTime? Za006 { get; set; }

        /// <summary>
        /// 担当
        /// </summary>
        [SugarColumn(ColumnName = "Za007", ColumnDescription = "担当", Length = 100)]
        public string Za007 { get; set; }

        /// <summary>
        /// 依赖
        /// </summary>
        [SugarColumn(ColumnName = "Za008", ColumnDescription = "依赖", Length = 30)]
        public string Za008 { get; set; }

        /// <summary>
        /// 会议
        /// </summary>
        [SugarColumn(ColumnName = "Za009", ColumnDescription = "会议", Length = 20)]
        public string Za009 { get; set; }

        /// <summary>
        /// PP番号
        /// </summary>
        [SugarColumn(ColumnName = "Za010", ColumnDescription = "PP番号", Length = 10)]
        public string Za010 { get; set; }

        /// <summary>
        /// 联络书
        /// </summary>
        [SugarColumn(ColumnName = "Za011", ColumnDescription = "联络书", Length = 10)]
        public string Za011 { get; set; }

        /// <summary>
        /// 实施
        /// </summary>
        [SugarColumn(ColumnName = "Za012", ColumnDescription = "实施", Length = 40)]
        public string Za012 { get; set; }

        /// <summary>
        /// 主理由
        /// </summary>
        [SugarColumn(ColumnName = "Za013", ColumnDescription = "主理由", Length = 40)]
        public string Za013 { get; set; }

        /// <summary>
        /// 次理由
        /// </summary>
        [SugarColumn(ColumnName = "Za014", ColumnDescription = "次理由", Length = 40)]
        public string Za014 { get; set; }

        /// <summary>
        /// 安规
        /// </summary>
        [SugarColumn(ColumnName = "Za015", ColumnDescription = "安规", Length = 40)]
        public string Za015 { get; set; }

        /// <summary>
        /// 状况
        /// </summary>
        [SugarColumn(ColumnName = "Za016", ColumnDescription = "状况", Length = 40)]
        public string Za016 { get; set; }

        /// <summary>
        /// 机番
        /// </summary>
        [SugarColumn(ColumnName = "Za017", ColumnDescription = "机番", Length = 40)]
        public string Za017 { get; set; }

        /// <summary>
        /// 承认
        /// </summary>
        [SugarColumn(ColumnName = "Za018", ColumnDescription = "承认", Length = 40)]
        public string Za018 { get; set; }

        /// <summary>
        /// 服务手册订正
        /// </summary>
        [SugarColumn(ColumnName = "Za019", ColumnDescription = "服务手册订正", Length = 40)]
        public string Za019 { get; set; }

        /// <summary>
        /// 用户手册订正
        /// </summary>
        [SugarColumn(ColumnName = "Za020", ColumnDescription = "用户手册订正", Length = 40)]
        public string Za020 { get; set; }

        /// <summary>
        /// 宣传手册订正
        /// </summary>
        [SugarColumn(ColumnName = "Za021", ColumnDescription = "宣传手册订正", Length = 40)]
        public string Za021 { get; set; }

        /// <summary>
        /// SOP订正
        /// </summary>
        [SugarColumn(ColumnName = "Za022", ColumnDescription = "SOP订正", Length = 40)]
        public string Za022 { get; set; }

        /// <summary>
        /// 信息发行
        /// </summary>
        [SugarColumn(ColumnName = "Za023", ColumnDescription = "信息发行", Length = 40)]
        public string Za023 { get; set; }

        /// <summary>
        /// 成本变动
        /// </summary>
        [SugarColumn(ColumnName = "Za024", ColumnDescription = "成本变动", Length = 40)]
        public string Za024 { get; set; }

        /// <summary>
        /// 单位成本
        /// </summary>
        [SugarColumn(ColumnName = "Za025", ColumnDescription = "单位成本", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Za025 { get; set; }

        /// <summary>
        /// 模具改造费
        /// </summary>
        [SugarColumn(ColumnName = "Za026", ColumnDescription = "模具改造费", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Za026 { get; set; }

        /// <summary>
        /// 图纸
        /// </summary>
        [SugarColumn(ColumnName = "Za027", ColumnDescription = "图纸", Length = 210)]
        public string Za027 { get; set; }

        /// <summary>
        /// 设变内容
        /// </summary>
        [SugarColumn(ColumnName = "Za028", ColumnDescription = "设变内容", Length = -1, ColumnDataType = "NVARCHAR")]
        public string Za028 { get; set; }

        /// <summary>
        /// 处理标记
        /// </summary>
        [SugarColumn(ColumnName = "Za029", ColumnDescription = "处理标记", Length = 3)]
        public string Za029 { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(PpSourceEcSlv.Zb002), nameof(Id))] //自定义关系映射
        public List<PpSourceEcSlv> PpSourceEcSlvNav { get; set; }
    }
}