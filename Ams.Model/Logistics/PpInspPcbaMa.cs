namespace Ams.Model.Logistics
{
    /// <summary>
    /// 检查日报ma
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:01:30
    /// </summary>
    [SugarTable("pp_insp_pcba_ma", "检查日报ma")]
    public class PpInspPcbaMa : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long PdiSfId { get; set; }

        /// <summary>
        /// 检查日期
        /// </summary>
        public DateTime? Pdiinspdate { get; set; }

        /// <summary>
        /// 生产机种
        /// </summary>
        [SugarColumn(ColumnName = "Pdimodel", ColumnDescription = "生产机种 ", Length = 50)]
        public string Pdimodel { get; set; }

        /// <summary>
        /// 生产工单
        /// </summary>
        [SugarColumn(ColumnName = "Pdiorder", ColumnDescription = "生产工单 ", Length = 20)]
        public string Pdiorder { get; set; }

        /// <summary>
        /// 生产批次
        /// </summary>
        [SugarColumn(ColumnName = "Pdilot", ColumnDescription = "生产批次 ", Length = 20)]
        public string Pdilot { get; set; }

        /// <summary>
        /// 工单台数
        /// </summary>
        [SugarColumn(ColumnName = "Pdiorderqty", ColumnDescription = "工单台数 ", DefaultValue = "0")]
        public int Pdiorderqty { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(PpInspPcbaSlv.PdiParentSfId), nameof(PdiSfId))] //自定义关系映射
        public List<PpInspPcbaSlv> PpInspPcbaSlvNav { get; set; }
    }
}