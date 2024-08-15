namespace Ams.Model.Logistics
{
    /// <summary>
    /// 组立不良ma
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 12:00:50
    /// </summary>
    [SugarTable("pp_repair_assy_ma", "组立不良ma")]
    public class PpRepairAssyMa : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long PpdSfId { get; set; }

        /// <summary>
        /// 生产订单
        /// </summary>
        [SugarColumn(ColumnName = "PpdOrderNo", ColumnDescription = "生产订单 ", Length = 20)]
        public string PpdOrderNo { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        [SugarColumn(ColumnName = "PpdOrderQty", ColumnDescription = "订单数量 ", DefaultValue = "0")]
        public int PpdOrderQty { get; set; }

        /// <summary>
        /// 生产批次
        /// </summary>
        [SugarColumn(ColumnName = "PpdLot", ColumnDescription = "生产批次 ", Length = 20)]
        public string PpdLot { get; set; }

        /// <summary>
        /// 生产机种
        /// </summary>
        [SugarColumn(ColumnName = "PpdModel", ColumnDescription = "生产机种 ", Length = 20)]
        public string PpdModel { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? PpdDate { get; set; }

        /// <summary>
        /// 生产班组
        /// </summary>
        [SugarColumn(ColumnName = "PpdLineName", ColumnDescription = "生产班组 ", Length = 20)]
        public string PpdLineName { get; set; }

        /// <summary>
        /// 生产实绩
        /// </summary>
        [SugarColumn(ColumnName = "PpdRealQty", ColumnDescription = "生产实绩 ", DefaultValue = "0")]
        public int PpdRealQty { get; set; }

        /// <summary>
        /// 无不良数
        /// </summary>
        [SugarColumn(ColumnName = "PpdNobadQty", ColumnDescription = "无不良数 ", DefaultValue = "0")]
        public int PpdNobadQty { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(PpRepairAssySlv.PpdParentSfId), nameof(PpdSfId))] //自定义关系映射
        public List<PpRepairAssySlv> PpDefectAssyRepairSlvNav { get; set; }
    }
}