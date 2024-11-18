namespace Ams.Model.Logistics
{
    /// <summary>
    /// 不良明细
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/12 17:18:57
    /// </summary>
    [SugarTable("pp_defect_assy_slv", "不良明细")]
    public class PpDefectAssySlv : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? Id { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 不良类别
        /// </summary>
        [SugarColumn(ColumnName = "Mfa003", ColumnDescription = "不良类别", Length = 20)]
        public string Mfa003 { get; set; }

        /// <summary>
        /// 不良数量
        /// </summary>
        [SugarColumn(ColumnName = "Mfa004", ColumnDescription = "不良数量", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mfa004 { get; set; }

        /// <summary>
        /// 不良总数
        /// </summary>
        [SugarColumn(ColumnName = "Mfa005", ColumnDescription = "不良总数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mfa005 { get; set; }

        /// <summary>
        /// 不良状况
        /// </summary>
        [SugarColumn(ColumnName = "Mfa006", ColumnDescription = "不良状况", Length = 200)]
        public string Mfa006 { get; set; }

        /// <summary>
        /// 不良个所
        /// </summary>
        [SugarColumn(ColumnName = "Mfa007", ColumnDescription = "不良个所", Length = 200)]
        public string Mfa007 { get; set; }

        /// <summary>
        /// 不良原因
        /// </summary>
        [SugarColumn(ColumnName = "Mfa008", ColumnDescription = "不良原因", Length = 200)]
        public string Mfa008 { get; set; }
    }
}