namespace Ams.Model.Logistics
{
    /// <summary>
    /// 制二OPH主表
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:09:27
    /// </summary>
    [SugarTable("pp_output_pcba_master", "制二OPH主表")]
    public class PpOutputPcbaMaster : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long PomSfId { get; set; }

        /// <summary>
        /// 订单类别
        /// </summary>
        [SugarColumn(ColumnName = "PomOrderType", ColumnDescription = "订单类别 ", Length = 20)]
        public string PomOrderType { get; set; }

        /// <summary>
        /// 订单号码
        /// </summary>
        [SugarColumn(ColumnName = "PomOrderNo", ColumnDescription = "订单号码 ", Length = 20)]
        public string PomOrderNo { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        [SugarColumn(ColumnName = "PomOrderQty", ColumnDescription = "订单数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal PomOrderQty { get; set; }

        /// <summary>
        /// 生产批次
        /// </summary>
        [SugarColumn(ColumnName = "PomLot", ColumnDescription = "生产批次 ", Length = 20)]
        public string PomLot { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "PomModel", ColumnDescription = "机种 ", Length = 50)]
        public string PomModel { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "PomItem", ColumnDescription = "物料 ", Length = 20)]
        public string PomItem { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [SugarColumn(ColumnName = "PomSerial", ColumnDescription = "序列号 ", Length = 200)]
        public string PomSerial { get; set; }

        /// <summary>
        /// 生产班组
        /// </summary>
        [SugarColumn(ColumnName = "PomDeptName", ColumnDescription = "生产班组 ", Length = 20)]
        public string PomDeptName { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? PomDate { get; set; }

        /// <summary>
        /// 直接人数
        /// </summary>
        [SugarColumn(ColumnName = "PomDirect", ColumnDescription = "直接人数 ", DefaultValue = "0")]
        public int PomDirect { get; set; }

        /// <summary>
        /// 间接人数
        /// </summary>
        [SugarColumn(ColumnName = "PomIndirect", ColumnDescription = "间接人数 ", DefaultValue = "0")]
        public int PomIndirect { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(PpOutputPcbaSlave.PosParentSfId), nameof(PomSfId))] //自定义关系映射
        public List<PpOutputPcbaSlave> PpOutputPcbaSlaveNav { get; set; }
    }
}