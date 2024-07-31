namespace Ams.Model.Logistics
{
    /// <summary>
    /// 修理日报ma
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:04:48
    /// </summary>
    [SugarTable("pp_repair_pcba_ma", "修理日报ma")]
    public class PpRepairPcbaMa : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long PdrSfId { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? Pdrdate { get; set; }

        /// <summary>
        /// 生产机种
        /// </summary>
        [SugarColumn(ColumnName = "Pdrmodel", ColumnDescription = "生产机种 ", Length = 50)]
        public string Pdrmodel { get; set; }

        /// <summary>
        /// 生产订单
        /// </summary>
        [SugarColumn(ColumnName = "Pdrorder", ColumnDescription = "生产订单 ", Length = 20)]
        public string Pdrorder { get; set; }

        /// <summary>
        /// 生产LOT
        /// </summary>
        [SugarColumn(ColumnName = "Pdrlot", ColumnDescription = "生产LOT ", Length = 20)]
        public string Pdrlot { get; set; }

        /// <summary>
        /// 订单台数
        /// </summary>
        [SugarColumn(ColumnName = "Pdrorderqty", ColumnDescription = "订单台数 ", DefaultValue = "0")]
        public int Pdrorderqty { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(PpRepairPcbaSlv.PdrParentSfId), nameof(PdrSfId))] //自定义关系映射
        public List<PpRepairPcbaSlv> PpRepairPcbaSlvNav { get; set; }
    }
}