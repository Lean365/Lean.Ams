namespace Ams.Model.Logistics
{
    /// <summary>
    /// 检查
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:26:18
    /// </summary>
    [SugarTable("pp_insp_pcba_ma", "检查")]
    public class PpInspPcbaMa : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 检查日期
        /// </summary>
        public DateTime? Mu002 { get; set; }

        /// <summary>
        /// 生产机种
        /// </summary>
        [SugarColumn(ColumnName = "Mu003", ColumnDescription = "生产机种", Length = 50)]
        public string Mu003 { get; set; }

        /// <summary>
        /// 生产工单
        /// </summary>
        [SugarColumn(ColumnName = "Mu004", ColumnDescription = "生产工单", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mu004 { get; set; }

        /// <summary>
        /// 生产批次
        /// </summary>
        [SugarColumn(ColumnName = "Mu005", ColumnDescription = "生产批次", Length = 20)]
        public string Mu005 { get; set; }

        /// <summary>
        /// 工单台数
        /// </summary>
        [SugarColumn(ColumnName = "Mu006", ColumnDescription = "工单台数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mu006 { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(PpInspPcbaSlv.ParentId), nameof(Id))] //自定义关系映射
        public List<PpInspPcbaSlv> PpInspPcbaSlvNav { get; set; }
    }
}