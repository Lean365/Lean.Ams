namespace Ams.Model.Logistics
{
    /// <summary>
    /// 技联
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/13 10:18:56
    /// </summary>
    [SugarTable("pp_ec_liaison", "技联")]
    public class PpEcLiaison : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 发行日
        /// </summary>

        public DateTime? Ma002 { get; set; }

        /// <summary>
        /// 机种明细
        /// </summary>
        [SugarColumn(ColumnName = "Ma003", ColumnDescription = "机种明细", Length = 2000, ColumnDataType = "NVARCHAR")]
        public string Ma003 { get; set; }

        /// <summary>
        /// 担当
        /// </summary>
        [SugarColumn(ColumnName = "Ma004", ColumnDescription = "担当", Length = 50, ColumnDataType = "NVARCHAR")]
        public string Ma004 { get; set; }

        /// <summary>
        /// 输入日
        /// </summary>
        public DateTime? Ma005 { get; set; }

        /// <summary>
        /// 技联NO.
        /// </summary>
        [SugarColumn(ColumnName = "Ma006", ColumnDescription = "技联NO.", Length = 10, ColumnDataType = "NVARCHAR")]
        public string Ma006 { get; set; }

        /// <summary>
        /// 技联文件
        /// </summary>
        [SugarColumn(ColumnName = "Ma007", ColumnDescription = "技联文件", Length = 200, ColumnDataType = "NVARCHAR")]
        public string Ma007 { get; set; }

        /// <summary>
        /// P番NO.
        /// </summary>
        [SugarColumn(ColumnName = "Ma008", ColumnDescription = "P番NO.", Length = 10, ColumnDataType = "NVARCHAR")]
        public string Ma008 { get; set; }

        /// <summary>
        /// P番文件
        /// </summary>
        [SugarColumn(ColumnName = "Ma009", ColumnDescription = "P番文件", Length = 200, ColumnDataType = "NVARCHAR")]
        public string Ma009 { get; set; }

        /// <summary>
        /// TCJ P番NO.
        /// </summary>
        [SugarColumn(ColumnName = "Ma010", ColumnDescription = "TCJ P番NO.", Length = 10, ColumnDataType = "NVARCHAR")]
        public string Ma010 { get; set; }

        /// <summary>
        /// TCJ P番文件
        /// </summary>
        [SugarColumn(ColumnName = "Ma011", ColumnDescription = "TCJ P番文件", Length = 200, ColumnDataType = "NVARCHAR")]
        public string Ma011 { get; set; }

        /// <summary>
        /// 外联NO.
        /// </summary>
        [SugarColumn(ColumnName = "Ma012", ColumnDescription = "外联NO.", Length = 10, ColumnDataType = "NVARCHAR")]
        public string Ma012 { get; set; }

        /// <summary>
        /// 外联文件
        /// </summary>
        [SugarColumn(ColumnName = "Ma013", ColumnDescription = "外联文件", Length = 200, ColumnDataType = "NVARCHAR")]
        public string Ma013 { get; set; }

        /// <summary>
        /// 其它NO.
        /// </summary>
        [SugarColumn(ColumnName = "Ma014", ColumnDescription = "其它NO.", Length = 10)]
        public string Ma014 { get; set; }

        /// <summary>
        /// 附件
        /// </summary>
        [SugarColumn(ColumnName = "Ma015", ColumnDescription = "附件", Length = 200)]
        public string Ma015 { get; set; }
    }
}