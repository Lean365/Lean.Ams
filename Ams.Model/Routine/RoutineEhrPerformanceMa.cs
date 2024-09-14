namespace Ams.Model.Routine
{
    /// <summary>
    /// 绩效
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:19:03
    /// </summary>
    [SugarTable("routine_ehr_performance_ma", "绩效")]
    public class RoutineEhrPerformanceMa : SysBase
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
        [SugarColumn(ColumnName = "Ml002", ColumnDescription = "工号", Length = 8, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ml002 { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [SugarColumn(ColumnName = "Ml003", ColumnDescription = "姓名", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ml003 { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        [SugarColumn(ColumnName = "Ml004", ColumnDescription = "年度", Length = 4)]
        public string Ml004 { get; set; }

        /// <summary>
        /// 总分
        /// </summary>
        [SugarColumn(ColumnName = "Ml005", ColumnDescription = "总分", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ml005 { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [SugarColumn(ColumnName = "Ml006", ColumnDescription = "等级", Length = 1)]
        public string Ml006 { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(RoutineEhrPerformanceSlv.ParentId), nameof(Id))] //自定义关系映射
        public List<RoutineEhrPerformanceSlv> RoutineEhrPerformanceSlvNav { get; set; }
    }
}