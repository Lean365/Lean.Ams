namespace Ams.Model.Routine
{
    /// <summary>
    /// 看板
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/20 9:52:38
    /// </summary>
    [SugarTable("routine_board", "看板")]
    public class RoutineBoard : SysBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 起始日
        /// </summary>
        public DateTime Mb002 { get; set; }

        /// <summary>
        /// 结束日
        /// </summary>
        public DateTime Mb003 { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [SugarColumn(ColumnName = "Mb004", ColumnDescription = "公司名称", Length = 400, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb004 { get; set; }

        /// <summary>
        /// 参访人员
        /// </summary>
        [SugarColumn(ColumnName = "Mb005", ColumnDescription = "参访人员", Length = -1, ColumnDataType = "NVARCHAR", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb005 { get; set; }
    }
}