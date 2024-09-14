
namespace Ams.Model.Routine
{
    /// <summary>
    /// 培训
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:39
    /// </summary>
    [SugarTable("routine_ehr_training_slv","培训")]
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
        [SugarColumn(ColumnName="Mr003", ColumnDescription = "项目",DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mr003 { get; set; }

        /// <summary>
        /// 内容 
        /// </summary>
        [SugarColumn(ColumnName="Mr004", ColumnDescription = "内容",Length = -1)]
        public string Mr004 { get; set; }

        /// <summary>
        /// 目的 
        /// </summary>
        [SugarColumn(ColumnName="Mr005", ColumnDescription = "目的",Length = -1)]
        public string Mr005 { get; set; }

        /// <summary>
        /// 分数 
        /// </summary>
        [SugarColumn(ColumnName="Mr006", ColumnDescription = "分数",DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mr006 { get; set; }

        /// <summary>
        /// 结果 
        /// </summary>
        [SugarColumn(ColumnName="Mr007", ColumnDescription = "结果",Length = 4)]
        public string Mr007 { get; set; }

        /// <summary>
        /// 日期 
        /// </summary>
        public DateTime? Mr008 { get; set; }

        /// <summary>
        /// 指导老师 
        /// </summary>
        [SugarColumn(ColumnName="Mr009", ColumnDescription = "指导老师",Length = 40)]
        public string Mr009 { get; set; }

        /// <summary>
        /// 确认 
        /// </summary>
        [SugarColumn(ColumnName="Mr010", ColumnDescription = "确认",Length = 40)]
        public string Mr010 { get; set; }

        /// <summary>
        /// 确认 
        /// </summary>
        [SugarColumn(ColumnName="Mr011", ColumnDescription = "确认",Length = 40)]
        public string Mr011 { get; set; }

        /// <summary>
        /// 确认 
        /// </summary>
        [SugarColumn(ColumnName="Mr012", ColumnDescription = "确认",Length = 40)]
        public string Mr012 { get; set; }

        /// <summary>
        /// 承认 
        /// </summary>
        [SugarColumn(ColumnName="Mr013", ColumnDescription = "承认",Length = 40)]
        public string Mr013 { get; set; }

        /// <summary>
        /// 承认 
        /// </summary>
        [SugarColumn(ColumnName="Mr014", ColumnDescription = "承认",Length = 40)]
        public string Mr014 { get; set; }

        /// <summary>
        /// 承认 
        /// </summary>
        [SugarColumn(ColumnName="Mr015", ColumnDescription = "承认",Length = 40)]
        public string Mr015 { get; set; }

        /// <summary>
        /// 预留A 
        /// </summary>
        [SugarColumn(ColumnName="Ref01", ColumnDescription = "预留A",Length = 1)]
        public string Ref01 { get; set; }

        /// <summary>
        /// 预留B 
        /// </summary>
        [SugarColumn(ColumnName="Ref02", ColumnDescription = "预留B",Length = 8)]
        public string Ref02 { get; set; }

        /// <summary>
        /// 预留C 
        /// </summary>
        [SugarColumn(ColumnName="Ref03", ColumnDescription = "预留C",Length = 30)]
        public string Ref03 { get; set; }

        /// <summary>
        /// 预留1 
        /// </summary>
        [SugarColumn(ColumnName="Ref04", ColumnDescription = "预留1",DefaultValue = "0",Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ref04 { get; set; }

        /// <summary>
        /// 预留2 
        /// </summary>
        [SugarColumn(ColumnName="Ref05", ColumnDescription = "预留2",DefaultValue = "0",Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ref05 { get; set; }

        /// <summary>
        /// 预留3 
        /// </summary>
        [SugarColumn(ColumnName="Ref06", ColumnDescription = "预留3",DefaultValue = "0",Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Ref06 { get; set; }

        /// <summary>
        /// 自定义A 
        /// </summary>
        [SugarColumn(ColumnName="Udf01", ColumnDescription = "自定义A",Length = 200)]
        public string Udf01 { get; set; }

        /// <summary>
        /// 自定义B 
        /// </summary>
        [SugarColumn(ColumnName="Udf02", ColumnDescription = "自定义B",Length = 200)]
        public string Udf02 { get; set; }

        /// <summary>
        /// 自定义C 
        /// </summary>
        [SugarColumn(ColumnName="Udf03", ColumnDescription = "自定义C",Length = 200)]
        public string Udf03 { get; set; }

        /// <summary>
        /// 自定义D 
        /// </summary>
        [SugarColumn(ColumnName="Udf04", ColumnDescription = "自定义D",Length = 500)]
        public string Udf04 { get; set; }

        /// <summary>
        /// 自定义E 
        /// </summary>
        [SugarColumn(ColumnName="Udf05", ColumnDescription = "自定义E",Length = 500)]
        public string Udf05 { get; set; }

        /// <summary>
        /// 自定义F 
        /// </summary>
        [SugarColumn(ColumnName="Udf06", ColumnDescription = "自定义F",Length = 500)]
        public string Udf06 { get; set; }

        /// <summary>
        /// 自定义1 
        /// </summary>
        [SugarColumn(ColumnName="Udf51", ColumnDescription = "自定义1",DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int? Udf51 { get; set; }

        /// <summary>
        /// 自定义2 
        /// </summary>
        [SugarColumn(ColumnName="Udf52", ColumnDescription = "自定义2",DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int? Udf52 { get; set; }

        /// <summary>
        /// 自定义3 
        /// </summary>
        [SugarColumn(ColumnName="Udf53", ColumnDescription = "自定义3",DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int? Udf53 { get; set; }

        /// <summary>
        /// 自定义4 
        /// </summary>
        [SugarColumn(ColumnName="Udf54", ColumnDescription = "自定义4",DefaultValue = "0",Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Udf54 { get; set; }

        /// <summary>
        /// 自定义5 
        /// </summary>
        [SugarColumn(ColumnName="Udf55", ColumnDescription = "自定义5",DefaultValue = "0",Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Udf55 { get; set; }

        /// <summary>
        /// 自定义6 
        /// </summary>
        [SugarColumn(ColumnName="Udf56", ColumnDescription = "自定义6",DefaultValue = "0",Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Udf56 { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        [SugarColumn(ColumnName = "is_Deleted")]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 备注说明 
        /// </summary>
        [SugarColumn(ColumnName="Remark", ColumnDescription = "备注说明",Length = 500)]
        public string Remark { get; set; }

        /// <summary>
        /// 创建人员 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新人员 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 更新时间 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }

    }
}