
namespace Ams.Model.Routine
{
    /// <summary>
    /// 绩效
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:38:43
    /// </summary>
    [SugarTable("routine_ehr_performance_slv","绩效")]
    public class RoutineEhrPerformanceSlv : SysBase
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
        /// 考核项目 
        /// </summary>
        [SugarColumn(ColumnName="Mm003", ColumnDescription = "考核项目",DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mm003 { get; set; }

        /// <summary>
        /// 初次评分 
        /// </summary>
        [SugarColumn(ColumnName="Mm004", ColumnDescription = "初次评分",DefaultValue = "0",Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mm004 { get; set; }

        /// <summary>
        /// 初评人 
        /// </summary>
        [SugarColumn(ColumnName="Mm005", ColumnDescription = "初评人",Length = 40)]
        public string Mm005 { get; set; }

        /// <summary>
        /// 初评日期 
        /// </summary>
        public DateTime? Mm006 { get; set; }

        /// <summary>
        /// 二次评分 
        /// </summary>
        [SugarColumn(ColumnName="Mm007", ColumnDescription = "二次评分",DefaultValue = "0",Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mm007 { get; set; }

        /// <summary>
        /// 二次考评人 
        /// </summary>
        [SugarColumn(ColumnName="Mm008", ColumnDescription = "二次考评人",Length = 40)]
        public string Mm008 { get; set; }

        /// <summary>
        /// 二次考评日期 
        /// </summary>
        public DateTime? Mm009 { get; set; }

        /// <summary>
        /// 三次评分 
        /// </summary>
        [SugarColumn(ColumnName="Mm010", ColumnDescription = "三次评分",DefaultValue = "0",Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mm010 { get; set; }

        /// <summary>
        /// 三次考评人 
        /// </summary>
        [SugarColumn(ColumnName="Mm011", ColumnDescription = "三次考评人",Length = 40)]
        public string Mm011 { get; set; }

        /// <summary>
        /// 三次考评日期 
        /// </summary>
        public DateTime? Mm012 { get; set; }

        /// <summary>
        /// 四次评分 
        /// </summary>
        [SugarColumn(ColumnName="Mm013", ColumnDescription = "四次评分",DefaultValue = "0",Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mm013 { get; set; }

        /// <summary>
        /// 四次考评人 
        /// </summary>
        [SugarColumn(ColumnName="Mm014", ColumnDescription = "四次考评人",Length = 40)]
        public string Mm014 { get; set; }

        /// <summary>
        /// 四次考评日期 
        /// </summary>
        public DateTime? Mm015 { get; set; }

        /// <summary>
        /// 五次评分 
        /// </summary>
        [SugarColumn(ColumnName="Mm016", ColumnDescription = "五次评分",DefaultValue = "0",Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mm016 { get; set; }

        /// <summary>
        /// 五次考评人 
        /// </summary>
        [SugarColumn(ColumnName="Mm017", ColumnDescription = "五次考评人",Length = 40)]
        public string Mm017 { get; set; }

        /// <summary>
        /// 五次考评日期 
        /// </summary>
        public DateTime? Mm018 { get; set; }

        /// <summary>
        /// 六次评分 
        /// </summary>
        [SugarColumn(ColumnName="Mm019", ColumnDescription = "六次评分",DefaultValue = "0",Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mm019 { get; set; }

        /// <summary>
        /// 六次考评人 
        /// </summary>
        [SugarColumn(ColumnName="Mm020", ColumnDescription = "六次考评人",Length = 40)]
        public string Mm020 { get; set; }

        /// <summary>
        /// 六次考评日期 
        /// </summary>
        public DateTime? Mm021 { get; set; }

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