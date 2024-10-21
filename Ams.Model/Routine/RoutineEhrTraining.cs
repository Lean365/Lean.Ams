namespace Ams.Model.Routine
{
    /// <summary>
    /// 培训
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/21 8:56:48
    /// </summary>
    [SugarTable("routine_ehr_training", "培训")]
    public class RoutineEhrTraining : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [SugarColumn(ColumnName = "Mq002", ColumnDescription = "工号", Length = 8, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mq002 { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [SugarColumn(ColumnName = "Mq003", ColumnDescription = "姓名", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mq003 { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        [SugarColumn(ColumnName = "Mq004", ColumnDescription = "年度", Length = 6)]
        public string Mq004 { get; set; }

        /// <summary>
        /// 项目
        /// </summary>
        [SugarColumn(ColumnName = "Mq005", ColumnDescription = "项目", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mq005 { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [SugarColumn(ColumnName = "Mq006", ColumnDescription = "内容", Length = -1)]
        public string Mq006 { get; set; }

        /// <summary>
        /// 目的
        /// </summary>
        [SugarColumn(ColumnName = "Mq007", ColumnDescription = "目的", Length = -1)]
        public string Mq007 { get; set; }

        /// <summary>
        /// 分数
        /// </summary>
        [SugarColumn(ColumnName = "Mq008", ColumnDescription = "分数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mq008 { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        [SugarColumn(ColumnName = "Mq009", ColumnDescription = "结果", Length = 4)]
        public string Mq009 { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Mq010 { get; set; }

        /// <summary>
        /// 指导老师
        /// </summary>
        [SugarColumn(ColumnName = "Mq011", ColumnDescription = "指导老师", Length = 40)]
        public string Mq011 { get; set; }

        /// <summary>
        /// 确认
        /// </summary>
        [SugarColumn(ColumnName = "Mq012", ColumnDescription = "确认", Length = 40)]
        public string Mq012 { get; set; }

        /// <summary>
        /// 确认
        /// </summary>
        [SugarColumn(ColumnName = "Mq013", ColumnDescription = "确认", Length = 40)]
        public string Mq013 { get; set; }

        /// <summary>
        /// 确认
        /// </summary>
        [SugarColumn(ColumnName = "Mq014", ColumnDescription = "确认", Length = 40)]
        public string Mq014 { get; set; }

        /// <summary>
        /// 承认
        /// </summary>
        [SugarColumn(ColumnName = "Mq015", ColumnDescription = "承认", Length = 40)]
        public string Mq015 { get; set; }

        /// <summary>
        /// 承认
        /// </summary>
        [SugarColumn(ColumnName = "Mq016", ColumnDescription = "承认", Length = 40)]
        public string Mq016 { get; set; }

        /// <summary>
        /// 承认
        /// </summary>
        [SugarColumn(ColumnName = "Mq017", ColumnDescription = "承认", Length = 40)]
        public string Mq017 { get; set; }
    }
}