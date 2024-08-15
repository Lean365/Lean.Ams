namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 主源设变
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:08:51
    /// </summary>
    public class PpSourceEcMaQueryDto : PagerInfo
    {
        public string Zpabdz001 { get; set; }
        public string Zpabdz003 { get; set; }
        public string Zpabdz004 { get; set; }
        public DateTime? BeginZpabdz005 { get; set; }
        public DateTime? EndZpabdz005 { get; set; }
        public string IsSolved { get; set; }
    }

    /// <summary>
    /// 主源设变
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:08:51
    /// </summary>
    public class PpSourceEcMaDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SfId { get; set; }

        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string Zpabdz001 { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Zpabdz002 { get; set; }

        [ExcelColumn(Name = "标题")]
        [ExcelColumnName("标题")]
        public string Zpabdz003 { get; set; }

        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public string Zpabdz004 { get; set; }

        [ExcelColumn(Name = "发行日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("发行日")]
        public DateTime? Zpabdz005 { get; set; }

        [ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]
        public string Zpabdz006 { get; set; }

        [ExcelColumn(Name = "依赖")]
        [ExcelColumnName("依赖")]
        public string Zpabdz007 { get; set; }

        [ExcelColumn(Name = "会议")]
        [ExcelColumnName("会议")]
        public string Zpabdz008 { get; set; }

        [ExcelColumn(Name = "PP番号")]
        [ExcelColumnName("PP番号")]
        public string Zpabdz009 { get; set; }

        [ExcelColumn(Name = "联络书")]
        [ExcelColumnName("联络书")]
        public string Zpabdz010 { get; set; }

        [ExcelColumn(Name = "实施")]
        [ExcelColumnName("实施")]
        public string Zpabdz011 { get; set; }

        [ExcelColumn(Name = "主理由")]
        [ExcelColumnName("主理由")]
        public string Zpabdz012 { get; set; }

        [ExcelColumn(Name = "次理由")]
        [ExcelColumnName("次理由")]
        public string Zpabdz013 { get; set; }

        [ExcelColumn(Name = "安规")]
        [ExcelColumnName("安规")]
        public string Zpabdz014 { get; set; }

        [ExcelColumn(Name = "状况")]
        [ExcelColumnName("状况")]
        public string Zpabdz015 { get; set; }

        [ExcelColumn(Name = "机番")]
        [ExcelColumnName("机番")]
        public string Zpabdz016 { get; set; }

        [ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]
        public string Zpabdz017 { get; set; }

        [ExcelColumn(Name = "服务手册订正")]
        [ExcelColumnName("服务手册订正")]
        public string Zpabdz018 { get; set; }

        [ExcelColumn(Name = "用户手册订正")]
        [ExcelColumnName("用户手册订正")]
        public string Zpabdz019 { get; set; }

        [ExcelColumn(Name = "宣传手册订正")]
        [ExcelColumnName("宣传手册订正")]
        public string Zpabdz020 { get; set; }

        [ExcelColumn(Name = "SOP订正")]
        [ExcelColumnName("SOP订正")]
        public string Zpabdz021 { get; set; }

        [ExcelColumn(Name = "信息发行")]
        [ExcelColumnName("信息发行")]
        public string Zpabdz022 { get; set; }

        [ExcelColumn(Name = "成本变动")]
        [ExcelColumnName("成本变动")]
        public string Zpabdz023 { get; set; }

        [ExcelColumn(Name = "单位成本")]
        [ExcelColumnName("单位成本")]
        public decimal Zpabdz024 { get; set; }

        [ExcelColumn(Name = "模具改造费")]
        [ExcelColumnName("模具改造费")]
        public decimal Zpabdz025 { get; set; }

        [ExcelColumn(Name = "图纸")]
        [ExcelColumnName("图纸")]
        public string Zpabdz026 { get; set; }

        [ExcelColumn(Name = "设变内容")]
        [ExcelColumnName("设变内容")]
        public string Zpabdz027 { get; set; }

        [Required(ErrorMessage = "处理标记不能为空")]
        [ExcelColumn(Name = "处理标记")]
        [ExcelColumnName("处理标记")]
        public string IsSolved { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        public List<PpSourceEcSlvDto> PpSourceEcSlvNav { get; set; }

        [ExcelColumn(Name = "状态")]
        public string Zpabdz004Label { get; set; }

        [ExcelColumn(Name = "处理标记")]
        public string IsSolvedLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 主源设变
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:08:51
    /// </summary>
    public class PpSourceEcMaImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long SfId { get; set; }

        [ExcelColumn(Name = "设变No.")]
        [ExcelColumnName("设变No.")]
        public string Zpabdz001 { get; set; }

        [ExcelColumn(Name = "机种")]
        [ExcelColumnName("机种")]
        public string Zpabdz002 { get; set; }

        [ExcelColumn(Name = "标题")]
        [ExcelColumnName("标题")]
        public string Zpabdz003 { get; set; }

        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public string Zpabdz004 { get; set; }

        [ExcelColumn(Name = "发行日", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("发行日")]
        public DateTime? Zpabdz005 { get; set; }

        [ExcelColumn(Name = "担当")]
        [ExcelColumnName("担当")]
        public string Zpabdz006 { get; set; }

        [ExcelColumn(Name = "依赖")]
        [ExcelColumnName("依赖")]
        public string Zpabdz007 { get; set; }

        [ExcelColumn(Name = "会议")]
        [ExcelColumnName("会议")]
        public string Zpabdz008 { get; set; }

        [ExcelColumn(Name = "PP番号")]
        [ExcelColumnName("PP番号")]
        public string Zpabdz009 { get; set; }

        [ExcelColumn(Name = "联络书")]
        [ExcelColumnName("联络书")]
        public string Zpabdz010 { get; set; }

        [ExcelColumn(Name = "实施")]
        [ExcelColumnName("实施")]
        public string Zpabdz011 { get; set; }

        [ExcelColumn(Name = "主理由")]
        [ExcelColumnName("主理由")]
        public string Zpabdz012 { get; set; }

        [ExcelColumn(Name = "次理由")]
        [ExcelColumnName("次理由")]
        public string Zpabdz013 { get; set; }

        [ExcelColumn(Name = "安规")]
        [ExcelColumnName("安规")]
        public string Zpabdz014 { get; set; }

        [ExcelColumn(Name = "状况")]
        [ExcelColumnName("状况")]
        public string Zpabdz015 { get; set; }

        [ExcelColumn(Name = "机番")]
        [ExcelColumnName("机番")]
        public string Zpabdz016 { get; set; }

        [ExcelColumn(Name = "承认")]
        [ExcelColumnName("承认")]
        public string Zpabdz017 { get; set; }

        [ExcelColumn(Name = "服务手册订正")]
        [ExcelColumnName("服务手册订正")]
        public string Zpabdz018 { get; set; }

        [ExcelColumn(Name = "用户手册订正")]
        [ExcelColumnName("用户手册订正")]
        public string Zpabdz019 { get; set; }

        [ExcelColumn(Name = "宣传手册订正")]
        [ExcelColumnName("宣传手册订正")]
        public string Zpabdz020 { get; set; }

        [ExcelColumn(Name = "SOP订正")]
        [ExcelColumnName("SOP订正")]
        public string Zpabdz021 { get; set; }

        [ExcelColumn(Name = "信息发行")]
        [ExcelColumnName("信息发行")]
        public string Zpabdz022 { get; set; }

        [ExcelColumn(Name = "成本变动")]
        [ExcelColumnName("成本变动")]
        public string Zpabdz023 { get; set; }

        [ExcelColumn(Name = "单位成本")]
        [ExcelColumnName("单位成本")]
        public decimal Zpabdz024 { get; set; }

        [ExcelColumn(Name = "模具改造费")]
        [ExcelColumnName("模具改造费")]
        public decimal Zpabdz025 { get; set; }

        [ExcelColumn(Name = "图纸")]
        [ExcelColumnName("图纸")]
        public string Zpabdz026 { get; set; }

        [ExcelColumn(Name = "设变内容")]
        [ExcelColumnName("设变内容")]
        public string Zpabdz027 { get; set; }

        [Required(ErrorMessage = "处理标记不能为空")]
        [ExcelColumn(Name = "处理标记")]
        [ExcelColumnName("处理标记")]
        public string IsSolved { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        public List<PpSourceEcSlvDto> PpSourceEcSlvNav { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "状态")]
        public string Zpabdz004Label { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "处理标记")]
        public string IsSolvedLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}