
namespace Ams.Model.Logistics
{
    /// <summary>
    /// 制一OPH从表
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:07:23
    /// </summary>
    [SugarTable("pp_output_assy_slave","制一OPH从表")]
    public class PpOutputAssySlave
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long PosSfid { get; set; }

        /// <summary>
        /// 父SFID 
        /// </summary>
        public long PosParentSfid { get; set; }

        /// <summary>
        /// 生产时段 
        /// </summary>
        [SugarColumn(ColumnName="PosProductionTime", ColumnDescription = "生产时段 ",Length = 11)]
        public string PosProductionTime { get; set; }

        /// <summary>
        /// 实际产能 
        /// </summary>
        [SugarColumn(ColumnName="PosRealOutput", ColumnDescription = "实际产能 ",DefaultValue = "0")]
        public int PosRealOutput { get; set; }

        /// <summary>
        /// 停线时间 
        /// </summary>
        [SugarColumn(ColumnName="PosDownTime", ColumnDescription = "停线时间 ",DefaultValue = "0")]
        public int PosDownTime { get; set; }

        /// <summary>
        /// 停线原因 
        /// </summary>
        [SugarColumn(ColumnName="PosDownTimeReasons", ColumnDescription = "停线原因 ",Length = 200)]
        public string PosDownTimeReasons { get; set; }

        /// <summary>
        /// 停线说明 
        /// </summary>
        [SugarColumn(ColumnName="PosDownTimeDescription", ColumnDescription = "停线说明 ",Length = 200)]
        public string PosDownTimeDescription { get; set; }

        /// <summary>
        /// 未达成原因 
        /// </summary>
        [SugarColumn(ColumnName="PosMissingReasons", ColumnDescription = "未达成原因 ",Length = 200)]
        public string PosMissingReasons { get; set; }

        /// <summary>
        /// 未达成说明 
        /// </summary>
        [SugarColumn(ColumnName="PosMissingDescription", ColumnDescription = "未达成说明 ",Length = 200)]
        public string PosMissingDescription { get; set; }

        /// <summary>
        /// 实际工数 
        /// </summary>
        [SugarColumn(ColumnName="PosRealWorkhours", ColumnDescription = "实际工数 ",DefaultValue = "0")]
        public int PosRealWorkhours { get; set; }

        /// <summary>
        /// 投入工数 
        /// </summary>
        [SugarColumn(ColumnName="PosInputsWorkhours", ColumnDescription = "投入工数 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal PosInputsWorkhours { get; set; }

        /// <summary>
        /// 工时差异 
        /// </summary>
        [SugarColumn(ColumnName="PosRealWorkinghoursDiff", ColumnDescription = "工时差异 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal PosRealWorkinghoursDiff { get; set; }

        /// <summary>
        /// 产能差异 
        /// </summary>
        [SugarColumn(ColumnName="PosRealOutputDiff", ColumnDescription = "产能差异 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal PosRealOutputDiff { get; set; }

        /// <summary>
        /// 达成率 
        /// </summary>
        [SugarColumn(ColumnName="PosAchievedRate", ColumnDescription = "达成率 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal PosAchievedRate { get; set; }

        /// <summary>
        /// 自定义A 
        /// </summary>
        [SugarColumn(ColumnName="UDF01", ColumnDescription = "自定义A ",Length = 200)]
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B 
        /// </summary>
        [SugarColumn(ColumnName="UDF02", ColumnDescription = "自定义B ",Length = 200)]
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C 
        /// </summary>
        [SugarColumn(ColumnName="UDF03", ColumnDescription = "自定义C ",Length = 200)]
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D 
        /// </summary>
        [SugarColumn(ColumnName="UDF04", ColumnDescription = "自定义D ",Length = 200)]
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E 
        /// </summary>
        [SugarColumn(ColumnName="UDF05", ColumnDescription = "自定义E ",Length = 200)]
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F 
        /// </summary>
        [SugarColumn(ColumnName="UDF06", ColumnDescription = "自定义F ",Length = 200)]
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1 
        /// </summary>
        [SugarColumn(ColumnName="UDF51", ColumnDescription = "自定义1 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2 
        /// </summary>
        [SugarColumn(ColumnName="UDF52", ColumnDescription = "自定义2 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3 
        /// </summary>
        [SugarColumn(ColumnName="UDF53", ColumnDescription = "自定义3 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4 
        /// </summary>
        [SugarColumn(ColumnName="UDF54", ColumnDescription = "自定义4 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5 
        /// </summary>
        [SugarColumn(ColumnName="UDF55", ColumnDescription = "自定义5 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6 
        /// </summary>
        [SugarColumn(ColumnName="UDF56", ColumnDescription = "自定义6 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        [SugarColumn(ColumnName="IsDeleted", ColumnDescription = "软删除 ",DefaultValue = "0")]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 说明 
        /// </summary>
        [SugarColumn(ColumnName="Remark", ColumnDescription = "说明 ",Length = 2000)]
        public string Remark { get; set; }

        /// <summary>
        /// 创建者 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新者 
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