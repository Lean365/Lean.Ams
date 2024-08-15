namespace Ams.Model.Kernel
{
    /// <summary>
    /// 表名称
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 10:27:13
    /// </summary>
    [SugarTable("sys_table", "表名称")]
    public class SysTable : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long TbId { get; set; }

        /// <summary>
        /// 表名
        /// </summary>

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string Tb001 { get; set; }

        /// <summary>
        /// 表描述
        /// </summary>
        [SugarColumn(ColumnName = "Tb002", ColumnDescription = "表描述 ", Length = 40)]
        public string Tb002 { get; set; }

        /// <summary>
        /// 序号
        /// </summary>

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string Tb003 { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        [SugarColumn(ColumnName = "Tb004", ColumnDescription = "简称 ", Length = 100)]
        public string Tb004 { get; set; }

        /// <summary>
        /// 缩写
        /// </summary>
        [SugarColumn(ColumnName = "Tb005", ColumnDescription = "缩写 ", Length = 20)]
        public string Tb005 { get; set; }

        /// <summary>
        /// 表名称
        /// </summary>

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string Tb006 { get; set; }

        /// <summary>
        /// 字段名称(tw)
        /// </summary>
        [SugarColumn(ColumnName = "Tb007", ColumnDescription = "字段名称(tw)  ", Length = 99)]
        public string Tb007 { get; set; }

        /// <summary>
        /// 字段名称(ja)
        /// </summary>
        [SugarColumn(ColumnName = "Tb008", ColumnDescription = "字段名称(ja)  ", Length = 99)]
        public string Tb008 { get; set; }

        /// <summary>
        /// 字段名称(ko)
        /// </summary>
        [SugarColumn(ColumnName = "Tb009", ColumnDescription = "字段名称(ko)  ", Length = 99)]
        public string Tb009 { get; set; }

        /// <summary>
        /// 字段名称(ar)
        /// </summary>
        [SugarColumn(ColumnName = "Tb010", ColumnDescription = "字段名称(ar)  ", Length = 99)]
        public string Tb010 { get; set; }

        /// <summary>
        /// 字段名称(ru)
        /// </summary>
        [SugarColumn(ColumnName = "Tb011", ColumnDescription = "字段名称(ru)  ", Length = 99)]
        public string Tb011 { get; set; }

        /// <summary>
        /// 字段名称(es)
        /// </summary>
        [SugarColumn(ColumnName = "Tb012", ColumnDescription = "字段名称(es)  ", Length = 99)]
        public string Tb012 { get; set; }

        /// <summary>
        /// 字段名称(fr)
        /// </summary>
        [SugarColumn(ColumnName = "Tb013", ColumnDescription = "字段名称(fr)  ", Length = 99)]
        public string Tb013 { get; set; }

        /// <summary>
        /// 字段名称(de)
        /// </summary>
        [SugarColumn(ColumnName = "Tb014", ColumnDescription = "字段名称(de)  ", Length = 99)]
        public string Tb014 { get; set; }

        /// <summary>
        /// 字段名称(en)
        /// </summary>
        [SugarColumn(ColumnName = "Tb015", ColumnDescription = "字段名称(en)  ", Length = 99)]
        public string Tb015 { get; set; }
    }
}