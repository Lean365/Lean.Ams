namespace Ams.Model.Logistics
{
    /// <summary>
    /// 制一OPH从表
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 14:32:42
    /// </summary>
    [SugarTable("pp_output_assy_slave", "制一OPH从表")]
    public class PpOutputAssySlave : SysBase
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
        public string PosProductionTime { get; set; }

        /// <summary>
        /// 实际产能
        /// </summary>
        public int PosRealOutput { get; set; }

        /// <summary>
        /// 停线时间
        /// </summary>
        public int PosDownTime { get; set; }

        /// <summary>
        /// 停线原因
        /// </summary>
        public string PosDownTimeReasons { get; set; }

        /// <summary>
        /// 停线说明
        /// </summary>
        public string PosDownTimeDescription { get; set; }

        /// <summary>
        /// 未达成原因
        /// </summary>
        public string PosMissingReasons { get; set; }

        /// <summary>
        /// 未达成说明
        /// </summary>
        public string PosMissingDescription { get; set; }

        /// <summary>
        /// 实际工数
        /// </summary>
        public int PosRealWorkhours { get; set; }

        /// <summary>
        /// 投入工数
        /// </summary>
        public decimal PosInputsWorkhours { get; set; }

        /// <summary>
        /// 工时差异
        /// </summary>
        public decimal PosRealWorkinghoursDiff { get; set; }

        /// <summary>
        /// 产能差异
        /// </summary>
        public decimal PosRealOutputDiff { get; set; }

        /// <summary>
        /// 达成率
        /// </summary>
        public decimal PosAchievedRate { get; set; }

        /// <summary>
        /// 自定义A
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsDeleted { get; set; }
    }
}