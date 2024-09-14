namespace Ams.Model.Logistics
{
    /// <summary>
    /// PCBA OPH
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:18:45
    /// </summary>
    [SugarTable("pp_output_pcba_ma", "PCBA OPH")]
    public class PpOutputPcbaMa : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 订单类别
        /// </summary>
        [SugarColumn(ColumnName = "Mca002", ColumnDescription = "订单类别", Length = 20)]
        public string Mca002 { get; set; }

        /// <summary>
        /// 订单号码
        /// </summary>
        [SugarColumn(ColumnName = "Mca003", ColumnDescription = "订单号码", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mca003 { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        [SugarColumn(ColumnName = "Mca004", ColumnDescription = "订单数量", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mca004 { get; set; }

        /// <summary>
        /// 生产批次
        /// </summary>
        [SugarColumn(ColumnName = "Mca005", ColumnDescription = "生产批次", Length = 20)]
        public string Mca005 { get; set; }

        /// <summary>
        /// 机种
        /// </summary>
        [SugarColumn(ColumnName = "Mca006", ColumnDescription = "机种", Length = 50)]
        public string Mca006 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Mca007", ColumnDescription = "物料", Length = 20)]
        public string Mca007 { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [SugarColumn(ColumnName = "Mca008", ColumnDescription = "序列号", Length = 200)]
        public string Mca008 { get; set; }

        /// <summary>
        /// 生产班组
        /// </summary>
        [SugarColumn(ColumnName = "Mca009", ColumnDescription = "生产班组", Length = 20)]
        public string Mca009 { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? Mca010 { get; set; }

        /// <summary>
        /// 直接人数
        /// </summary>
        [SugarColumn(ColumnName = "Mca011", ColumnDescription = "直接人数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mca011 { get; set; }

        /// <summary>
        /// 间接人数
        /// </summary>
        [SugarColumn(ColumnName = "Mca012", ColumnDescription = "间接人数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mca012 { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(PpOutputPcbaSlv.ParentId), nameof(Id))] //自定义关系映射
        public List<PpOutputPcbaSlv> PpOutputPcbaSlvNav { get; set; }
    }
}