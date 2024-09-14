namespace Ams.Model.Routine
{
    /// <summary>
    /// 培训
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 15:13:49
    /// </summary>
    [SugarTable("routine_ehr_training_ma", "培训")]
    public class RoutineEhrTrainingMa : SysBase
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
        [SugarColumn(ColumnName = "Mq004", ColumnDescription = "年度", Length = 4)]
        public string Mq004 { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(RoutineEhrTrainingSlv.ParentId), nameof(Id))] //自定义关系映射
        public List<RoutineEhrTrainingSlv> RoutineEhrTrainingSlvNav { get; set; }
    }
}