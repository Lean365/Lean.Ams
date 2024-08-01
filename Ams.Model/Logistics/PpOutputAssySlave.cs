namespace Ams.Model.Logistics
{
    /// <summary>
    /// 制一OPH从表
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 16:07:23
    /// </summary>
    [SugarTable("pp_output_assy_slave", "制一OPH从表")]
    public class PpOutputAssySlave : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long PosSfId { get; set; }

        /// <summary>
        /// 父SfId
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PosParentSfId { get; set; }

        /// <summary>
        /// 生产时段
        /// </summary>
        [SugarColumn(ColumnName = "PosProductionTime", ColumnDescription = "生产时段 ", Length = 11)]
        public string PosProductionTime { get; set; }

        /// <summary>
        /// 实际产能
        /// </summary>
        [SugarColumn(ColumnName = "PosRealOutput", ColumnDescription = "实际产能 ", DefaultValue = "0")]
        public int PosRealOutput { get; set; }

        /// <summary>
        /// 停线时间
        /// </summary>
        [SugarColumn(ColumnName = "PosDownTime", ColumnDescription = "停线时间 ", DefaultValue = "0")]
        public int PosDownTime { get; set; }

        /// <summary>
        /// 停线原因
        /// </summary>
        [SugarColumn(ColumnName = "PosDownTimeReasons", ColumnDescription = "停线原因 ", Length = 200)]
        public string PosDownTimeReasons { get; set; }

        /// <summary>
        /// 停线说明
        /// </summary>
        [SugarColumn(ColumnName = "PosDownTimeDescription", ColumnDescription = "停线说明 ", Length = 200)]
        public string PosDownTimeDescription { get; set; }

        /// <summary>
        /// 未达成原因
        /// </summary>
        [SugarColumn(ColumnName = "PosMissingReasons", ColumnDescription = "未达成原因 ", Length = 200)]
        public string PosMissingReasons { get; set; }

        /// <summary>
        /// 未达成说明
        /// </summary>
        [SugarColumn(ColumnName = "PosMissingDescription", ColumnDescription = "未达成说明 ", Length = 200)]
        public string PosMissingDescription { get; set; }

        /// <summary>
        /// 实际工数
        /// </summary>
        [SugarColumn(ColumnName = "PosRealWorkhours", ColumnDescription = "实际工数 ", DefaultValue = "0")]
        public int PosRealWorkhours { get; set; }

        /// <summary>
        /// 投入工数
        /// </summary>
        [SugarColumn(ColumnName = "PosInputsWorkhours", ColumnDescription = "投入工数 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal PosInputsWorkhours { get; set; }

        /// <summary>
        /// 工时差异
        /// </summary>
        [SugarColumn(ColumnName = "PosRealWorkinghoursDiff", ColumnDescription = "工时差异 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal PosRealWorkinghoursDiff { get; set; }

        /// <summary>
        /// 产能差异
        /// </summary>
        [SugarColumn(ColumnName = "PosRealOutputDiff", ColumnDescription = "产能差异 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal PosRealOutputDiff { get; set; }

        /// <summary>
        /// 达成率
        /// </summary>
        [SugarColumn(ColumnName = "PosAchievedRate", ColumnDescription = "达成率 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal PosAchievedRate { get; set; }
    }
}