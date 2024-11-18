namespace Ams.Model.Logistics
{
    /// <summary>
    /// 不良
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/12 17:19:09
    /// </summary>
    [SugarTable("pp_defect_assy_ma", "不良")]
    public class PpDefectAssyMa : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? Id { get; set; }

        /// <summary>
        /// 生产订单
        /// </summary>
        [SugarColumn(ColumnName = "Mea002", ColumnDescription = "生产订单", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mea002 { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        [SugarColumn(ColumnName = "Mea003", ColumnDescription = "订单数量", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mea003 { get; set; }

        /// <summary>
        /// 生产批次
        /// </summary>
        [SugarColumn(ColumnName = "Mea004", ColumnDescription = "生产批次", Length = 20)]
        public string Mea004 { get; set; }

        /// <summary>
        /// 生产机种
        /// </summary>
        [SugarColumn(ColumnName = "Mea005", ColumnDescription = "生产机种", Length = 20)]
        public string Mea005 { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? Mea006 { get; set; }

        /// <summary>
        /// 生产班组
        /// </summary>
        [SugarColumn(ColumnName = "Mea007", ColumnDescription = "生产班组", Length = 20)]
        public string Mea007 { get; set; }

        /// <summary>
        /// 生产实绩
        /// </summary>
        [SugarColumn(ColumnName = "Mea008", ColumnDescription = "生产实绩", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mea008 { get; set; }

        /// <summary>
        /// 无不良数
        /// </summary>
        [SugarColumn(ColumnName = "Mea009", ColumnDescription = "无不良数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mea009 { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(PpDefectAssySlv.ParentId), nameof(Id))] //自定义关系映射
        public List<PpDefectAssySlv> PpDefectAssySlvNav { get; set; }
    }
}