namespace Ams.Model.Logistics
{
    /// <summary>
    /// PCBA明细
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:35
    /// </summary>
    [SugarTable("pp_output_pcba_slv", "PCBA明细")]
    public class PpOutputPcbaSlv : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? ParentId { get; set; }

        /// <summary>
        /// 班组
        /// </summary>
        [SugarColumn(ColumnName = "Mda003", ColumnDescription = "班组", Length = 20)]
        public string Mda003 { get; set; }

        /// <summary>
        /// 板别
        /// </summary>
        [SugarColumn(ColumnName = "Mda004", ColumnDescription = "板别", Length = 40)]
        public string Mda004 { get; set; }

        /// <summary>
        /// 板面
        /// </summary>
        [SugarColumn(ColumnName = "Mda005", ColumnDescription = "板面", Length = 40)]
        public string Mda005 { get; set; }

        /// <summary>
        /// Lot数
        /// </summary>
        [SugarColumn(ColumnName = "Mda006", ColumnDescription = "Lot数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mda006 { get; set; }

        /// <summary>
        /// 生产实绩
        /// </summary>
        [SugarColumn(ColumnName = "Mda007", ColumnDescription = "生产实绩", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mda007 { get; set; }

        /// <summary>
        /// 累计生产数
        /// </summary>
        [SugarColumn(ColumnName = "Mda008", ColumnDescription = "累计生产数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mda008 { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [SugarColumn(ColumnName = "Mda009", ColumnDescription = "序列号", Length = 2000)]
        public string Mda009 { get; set; }

        /// <summary>
        /// 完成情况
        /// </summary>
        [SugarColumn(ColumnName = "Mda010", ColumnDescription = "完成情况", Length = 20)]
        public string Mda010 { get; set; }

        /// <summary>
        /// 总工数
        /// </summary>
        [SugarColumn(ColumnName = "Mda011", ColumnDescription = "总工数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mda011 { get; set; }

        /// <summary>
        /// 切换次数
        /// </summary>
        [SugarColumn(ColumnName = "Mda012", ColumnDescription = "切换次数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mda012 { get; set; }

        /// <summary>
        /// 切换时间
        /// </summary>
        [SugarColumn(ColumnName = "Mda013", ColumnDescription = "切换时间", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mda013 { get; set; }

        /// <summary>
        /// 切停机时间
        /// </summary>
        [SugarColumn(ColumnName = "Mda014", ColumnDescription = "切停机时间", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mda014 { get; set; }

        /// <summary>
        /// 修工数
        /// </summary>
        [SugarColumn(ColumnName = "Mda015", ColumnDescription = "修工数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mda015 { get; set; }

        /// <summary>
        /// 投入工数
        /// </summary>
        [SugarColumn(ColumnName = "Mda016", ColumnDescription = "投入工数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mda016 { get; set; }

        /// <summary>
        /// 不良台数
        /// </summary>
        [SugarColumn(ColumnName = "Mda017", ColumnDescription = "不良台数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mda017 { get; set; }

        /// <summary>
        /// 手插仕损
        /// </summary>
        [SugarColumn(ColumnName = "Mda018", ColumnDescription = "手插仕损", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mda018 { get; set; }

        /// <summary>
        /// 修正仕损
        /// </summary>
        [SugarColumn(ColumnName = "Mda019", ColumnDescription = "修正仕损", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mda019 { get; set; }

        /// <summary>
        /// 停线原因
        /// </summary>
        [SugarColumn(ColumnName = "Mda020", ColumnDescription = "停线原因", Length = 200)]
        public string Mda020 { get; set; }

        /// <summary>
        /// 停线备注说明
        /// </summary>
        [SugarColumn(ColumnName = "Mda021", ColumnDescription = "停线备注说明", Length = 200)]
        public string Mda021 { get; set; }

        /// <summary>
        /// 未达成原因
        /// </summary>
        [SugarColumn(ColumnName = "Mda022", ColumnDescription = "未达成原因", Length = 200)]
        public string Mda022 { get; set; }

        /// <summary>
        /// 未达成备注说明
        /// </summary>
        [SugarColumn(ColumnName = "Mda023", ColumnDescription = "未达成备注说明", Length = 200)]
        public string Mda023 { get; set; }
    }
}