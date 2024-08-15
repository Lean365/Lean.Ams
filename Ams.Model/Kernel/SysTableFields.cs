namespace Ams.Model.Kernel
{
    /// <summary>
    /// 表字段
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/31 7:59:06
    /// </summary>
    [SugarTable("sys_table_fields", "表字段")]
    public class SysTableFields : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long TfId { get; set; }

        /// <summary>
        /// 表名
        /// </summary>

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string Tf001 { get; set; }

        /// <summary>
        /// 字段编号
        /// </summary>

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string Tf003 { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        [SugarColumn(ColumnName = "Tf002", ColumnDescription = "序号  ", Length = 4)]
        public string Tf002 { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        [SugarColumn(ColumnName = "Tf004", ColumnDescription = "字段名称  ", Length = 100)]
        public string Tf004 { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [SugarColumn(ColumnName = "Tf005", ColumnDescription = "类型  ", Length = 1)]
        public string Tf005 { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        public float Tf006 { get; set; }

        /// <summary>
        /// 字段说明
        /// </summary>
        [SugarColumn(ColumnName = "Tf007", ColumnDescription = "字段说明  ", Length = 255)]
        public string Tf007 { get; set; }

        /// <summary>
        /// 实体类型
        /// </summary>
        [SugarColumn(ColumnName = "Tf008", ColumnDescription = "实体类型  ", Length = 10)]
        public string Tf008 { get; set; }

        /// <summary>
        /// 最大长度
        /// </summary>
        [SugarColumn(ColumnName = "Tf009", ColumnDescription = "最大长度  ", DefaultValue = "0")]
        public int? Tf009 { get; set; }

        /// <summary>
        /// 精度
        /// </summary>
        [SugarColumn(ColumnName = "Tf010", ColumnDescription = "精度  ", DefaultValue = "0")]
        public int? Tf010 { get; set; }

        /// <summary>
        /// 刻度
        /// </summary>
        [SugarColumn(ColumnName = "Tf011", ColumnDescription = "刻度  ", DefaultValue = "0")]
        public int? Tf011 { get; set; }

        /// <summary>
        /// 原字段编号
        /// </summary>
        [SugarColumn(ColumnName = "Tf012", ColumnDescription = "原字段编号  ", Length = 99)]
        public string Tf012 { get; set; }

        /// <summary>
        /// 字段名称(tw)
        /// </summary>
        [SugarColumn(ColumnName = "Tf013", ColumnDescription = "字段名称(tw)  ", Length = 99)]
        public string Tf013 { get; set; }

        /// <summary>
        /// 字段名称(ja)
        /// </summary>
        [SugarColumn(ColumnName = "Tf014", ColumnDescription = "字段名称(ja)  ", Length = 99)]
        public string Tf014 { get; set; }

        /// <summary>
        /// 字段名称(ko)
        /// </summary>
        [SugarColumn(ColumnName = "Tf015", ColumnDescription = "字段名称(ko)  ", Length = 99)]
        public string Tf015 { get; set; }

        /// <summary>
        /// 字段名称(ar)
        /// </summary>
        [SugarColumn(ColumnName = "Tf016", ColumnDescription = "字段名称(ar)  ", Length = 99)]
        public string Tf016 { get; set; }

        /// <summary>
        /// 字段名称(ru)
        /// </summary>
        [SugarColumn(ColumnName = "Tf017", ColumnDescription = "字段名称(ru)  ", Length = 99)]
        public string Tf017 { get; set; }

        /// <summary>
        /// 字段名称(es)
        /// </summary>
        [SugarColumn(ColumnName = "Tf018", ColumnDescription = "字段名称(es)  ", Length = 99)]
        public string Tf018 { get; set; }

        /// <summary>
        /// 字段名称(fr)
        /// </summary>
        [SugarColumn(ColumnName = "Tf019", ColumnDescription = "字段名称(fr)  ", Length = 99)]
        public string Tf019 { get; set; }

        /// <summary>
        /// 字段名称(de)
        /// </summary>
        [SugarColumn(ColumnName = "Tf020", ColumnDescription = "字段名称(de)  ", Length = 99)]
        public string Tf020 { get; set; }

        /// <summary>
        /// 字段名称(en)
        /// </summary>
        [SugarColumn(ColumnName = "Tf021", ColumnDescription = "字段名称(en)  ", Length = 99)]
        public string Tf021 { get; set; }
    }
}