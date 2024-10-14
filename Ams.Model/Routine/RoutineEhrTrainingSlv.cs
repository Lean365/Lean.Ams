namespace Ams.Model.Routine
{
    /// <summary>
    /// 培训
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:39
    /// </summary>
    [SugarTable("routine_ehr_training_slv", "培训")]
    public class RoutineEhrTrainingSlv : SysBase
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
        /// 项目
        /// </summary>
        [SugarColumn(ColumnName = "Mr003", ColumnDescription = "项目", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mr003 { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [SugarColumn(ColumnName = "Mr004", ColumnDescription = "内容", Length = -1)]
        public string Mr004 { get; set; }

        /// <summary>
        /// 目的
        /// </summary>
        [SugarColumn(ColumnName = "Mr005", ColumnDescription = "目的", Length = -1)]
        public string Mr005 { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        [SugarColumn(ColumnName = "Mr006", ColumnDescription = "分数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mr006 { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        [SugarColumn(ColumnName = "Mr007", ColumnDescription = "结果", Length = 4)]
        public string Mr007 { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Mr008 { get; set; }

        /// <summary>
        /// 指导老师
        /// </summary>
        [SugarColumn(ColumnName = "Mr009", ColumnDescription = "指导老师", Length = 40)]
        public string Mr009 { get; set; }

        /// <summary>
        /// 确认
        /// </summary>
        [SugarColumn(ColumnName = "Mr010", ColumnDescription = "确认", Length = 40)]
        public string Mr010 { get; set; }

        /// <summary>
        /// 确认
        /// </summary>
        [SugarColumn(ColumnName = "Mr011", ColumnDescription = "确认", Length = 40)]
        public string Mr011 { get; set; }

        /// <summary>
        /// 确认
        /// </summary>
        [SugarColumn(ColumnName = "Mr012", ColumnDescription = "确认", Length = 40)]
        public string Mr012 { get; set; }

        /// <summary>
        /// 承认
        /// </summary>
        [SugarColumn(ColumnName = "Mr013", ColumnDescription = "承认", Length = 40)]
        public string Mr013 { get; set; }

        /// <summary>
        /// 承认
        /// </summary>
        [SugarColumn(ColumnName = "Mr014", ColumnDescription = "承认", Length = 40)]
        public string Mr014 { get; set; }

        /// <summary>
        /// 承认
        /// </summary>
        [SugarColumn(ColumnName = "Mr015", ColumnDescription = "承认", Length = 40)]
        public string Mr015 { get; set; }
    }
}