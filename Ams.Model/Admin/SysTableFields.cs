namespace Ams.Model.Admin
{
    /// <summary>
    /// 表字段
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/4 16:50:01
    /// </summary>
    [SugarTable("sys_table_fields", "表字段")]
    public class SysTableFields : SysBase
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
        [SugarColumn(ColumnName = "Tf002", ColumnDescription = "表名", Length = 255)]
        public string Tf002 { get; set; }

        /// <summary>
        /// 字段编号
        /// </summary>
        [SugarColumn(ColumnName = "Tf003", ColumnDescription = "字段编号", Length = 255)]
        public string Tf003 { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [SugarColumn(ColumnName = "Tf004", ColumnDescription = "序号", Length = 4)]
        public string Tf004 { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        [SugarColumn(ColumnName = "Tf005", ColumnDescription = "字段名称", Length = 100)]
        public string Tf005 { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [SugarColumn(ColumnName = "Tf006", ColumnDescription = "类型", Length = 1)]
        public string Tf006 { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        [SugarColumn(ColumnName = "Tf007", ColumnDescription = "长度", Length = 200)]
        public string Tf007 { get; set; }

        /// <summary>
        /// 字段说明
        /// </summary>
        [SugarColumn(ColumnName = "Tf008", ColumnDescription = "字段说明", Length = 255)]
        public string Tf008 { get; set; }

        /// <summary>
        /// 实体类型
        /// </summary>
        [SugarColumn(ColumnName = "Tf009", ColumnDescription = "实体类型", Length = 10)]
        public string Tf009 { get; set; }

        /// <summary>
        /// 最大长度
        /// </summary>
        [SugarColumn(ColumnName = "Tf010", ColumnDescription = "最大长度", DefaultValue = "0")]
        public int Tf010 { get; set; }

        /// <summary>
        /// 精度
        /// </summary>
        [SugarColumn(ColumnName = "Tf011", ColumnDescription = "精度", DefaultValue = "0")]
        public int Tf011 { get; set; }

        /// <summary>
        /// 刻度
        /// </summary>
        [SugarColumn(ColumnName = "Tf012", ColumnDescription = "刻度", DefaultValue = "0")]
        public int Tf012 { get; set; }

        /// <summary>
        /// 原字段编号
        /// </summary>
        [SugarColumn(ColumnName = "Tf013", ColumnDescription = "原字段编号", Length = 99)]
        public string Tf013 { get; set; }

        /// <summary>
        /// Nullable
        /// </summary>
        [SugarColumn(ColumnName = "Tf014", ColumnDescription = "Nullable", DefaultValue = "0")]
        public int Tf014 { get; set; }

        /// <summary>
        /// 翻译
        /// </summary>
        [SugarColumn(ColumnName = "Tf015", ColumnDescription = "翻译", Length = 4000)]
        public string Tf015 { get; set; }

        /// <summary>
        /// 建表语句
        /// </summary>
        [SugarColumn(ColumnName = "Tf016", ColumnDescription = "建表语句", Length = 4000)]
        public string Tf016 { get; set; }

        /// <summary>
        /// 字段语句
        /// </summary>
        [SugarColumn(ColumnName = "Tf017", ColumnDescription = "字段语句", Length = 4000)]
        public string Tf017 { get; set; }

        /// <summary>
        /// 默认值语句
        /// </summary>
        [SugarColumn(ColumnName = "Tf018", ColumnDescription = "默认值语句", Length = 4000)]
        public string Tf018 { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        [SugarColumn(ColumnName = "Tf019", ColumnDescription = "字段名", Length = 255)]
        public string Tf019 { get; set; }
    }
}