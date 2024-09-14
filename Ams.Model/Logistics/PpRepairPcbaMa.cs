namespace Ams.Model.Logistics
{
    /// <summary>
    /// 修理
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:10:27
    /// </summary>
    [SugarTable("pp_repair_pcba_ma", "修理")]
    public class PpRepairPcbaMa : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? Mga002 { get; set; }

        /// <summary>
        /// 生产机种
        /// </summary>
        [SugarColumn(ColumnName = "Mga003", ColumnDescription = "生产机种", Length = 50)]
        public string Mga003 { get; set; }

        /// <summary>
        /// 生产订单
        /// </summary>
        [SugarColumn(ColumnName = "Mga004", ColumnDescription = "生产订单", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mga004 { get; set; }

        /// <summary>
        /// 生产LOT
        /// </summary>
        [SugarColumn(ColumnName = "Mga005", ColumnDescription = "生产LOT", Length = 20)]
        public string Mga005 { get; set; }

        /// <summary>
        /// 订单台数
        /// </summary>
        [SugarColumn(ColumnName = "Mga006", ColumnDescription = "订单台数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mga006 { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(PpRepairPcbaSlv.ParentId), nameof(Id))] //自定义关系映射
        public List<PpRepairPcbaSlv> PpRepairPcbaSlvNav { get; set; }
    }
}