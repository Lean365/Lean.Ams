namespace Ams.Model.Logistics
{
    /// <summary>
    /// 组立OPH
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:21:13
    /// </summary>
    [SugarTable("pp_output_assy_ma", "组立OPH")]
    public class PpOutputAssyMa : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 工单类别
        /// </summary>
        [SugarColumn(ColumnName = "Mma002", ColumnDescription = "工单类别", Length = 4)]
        public string Mma002 { get; set; }

        /// <summary>
        /// 工单号码
        /// </summary>
        [SugarColumn(ColumnName = "Mma003", ColumnDescription = "工单号码", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mma003 { get; set; }

        /// <summary>
        /// 工单数量
        /// </summary>
        [SugarColumn(ColumnName = "Mma004", ColumnDescription = "工单数量", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mma004 { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [SugarColumn(ColumnName = "Mma005", ColumnDescription = "序列号", Length = 200)]
        public string Mma005 { get; set; }

        /// <summary>
        /// 生产批次
        /// </summary>
        [SugarColumn(ColumnName = "Mma006", ColumnDescription = "生产批次", Length = 20)]
        public string Mma006 { get; set; }

        /// <summary>
        /// 机种名
        /// </summary>
        [SugarColumn(ColumnName = "Mma007", ColumnDescription = "机种名", Length = 100)]
        public string Mma007 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Mma008", ColumnDescription = "物料", Length = 20)]
        public string Mma008 { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? Mma009 { get; set; }

        /// <summary>
        /// 生产班组
        /// </summary>
        [SugarColumn(ColumnName = "Mma010", ColumnDescription = "生产班组", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mma010 { get; set; }

        /// <summary>
        /// 直接人数
        /// </summary>
        [SugarColumn(ColumnName = "Mma011", ColumnDescription = "直接人数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mma011 { get; set; }

        /// <summary>
        /// 间接人数
        /// </summary>
        [SugarColumn(ColumnName = "Mma012", ColumnDescription = "间接人数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mma012 { get; set; }

        /// <summary>
        /// 标准工时
        /// </summary>
        [SugarColumn(ColumnName = "Mma013", ColumnDescription = "标准工时", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mma013 { get; set; }

        /// <summary>
        /// 标准产能
        /// </summary>
        [SugarColumn(ColumnName = "Mma014", ColumnDescription = "标准产能", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mma014 { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(PpOutputAssySlv.ParentId), nameof(Id))] //自定义关系映射
        public List<PpOutputAssySlv> PpOutputAssySlvNav { get; set; }
    }
}