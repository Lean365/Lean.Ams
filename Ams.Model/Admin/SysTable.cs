namespace Ams.Model.Admin
{
    /// <summary>
    /// 表名称
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/4 16:50:06
    /// </summary>
    [SugarTable("sys_table", "表名称")]
    public class SysTable : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        [SugarColumn(ColumnName = "Tb002", ColumnDescription = "表名", Length = 255)]
        public string Tb002 { get; set; }

        /// <summary>
        /// 表描述
        /// </summary>
        [SugarColumn(ColumnName = "Tb003", ColumnDescription = "表描述", Length = 40)]
        public string Tb003 { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [SugarColumn(ColumnName = "Tb004", ColumnDescription = "序号", Length = 255)]
        public string Tb004 { get; set; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        [SugarColumn(ColumnName = "Tb005", ColumnDescription = "数据库名称", Length = 100)]
        public string Tb005 { get; set; }

        /// <summary>
        /// 访问方式
        /// </summary>
        [SugarColumn(ColumnName = "Tb006", ColumnDescription = "访问方式", Length = 20)]
        public string Tb006 { get; set; }

        /// <summary>
        /// 前缀
        /// </summary>
        [SugarColumn(ColumnName = "Tb007", ColumnDescription = "前缀", Length = 4000)]
        public string Tb007 { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        [SugarColumn(ColumnName = "Tb008", ColumnDescription = "表名", Length = 255)]
        public string Tb008 { get; set; }

        /// <summary>
        /// 翻译
        /// </summary>
        [SugarColumn(ColumnName = "Tb009", ColumnDescription = "翻译", Length = 4000)]
        public string Tb009 { get; set; }
    }
}