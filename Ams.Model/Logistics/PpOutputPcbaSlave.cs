namespace Ams.Model.Logistics
{
    /// <summary>
    /// 制二OPH从表
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/22 9:31:04
    /// </summary>
    [SugarTable("pp_output_pcba_slave", "制二OPH从表")]
    public class PpOutputPcbaSlave : SysBase
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
        /// 班组
        /// </summary>
        [SugarColumn(ColumnName = "PosLineName", ColumnDescription = "班组 ", Length = 20)]
        public string PosLineName { get; set; }

        /// <summary>
        /// Lot数
        /// </summary>
        [SugarColumn(ColumnName = "PosLotQty", ColumnDescription = "Lot数 ", DefaultValue = "0")]
        public int PosLotQty { get; set; }

        /// <summary>
        /// 生产实绩
        /// </summary>
        [SugarColumn(ColumnName = "PosRealOutput", ColumnDescription = "生产实绩 ", DefaultValue = "0")]
        public int PosRealOutput { get; set; }

        /// <summary>
        /// 累计生产数
        /// </summary>
        [SugarColumn(ColumnName = "PosRealTotal", ColumnDescription = "累计生产数 ", DefaultValue = "0")]
        public int PosRealTotal { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [SugarColumn(ColumnName = "PosPcbSerial", ColumnDescription = "序列号 ", Length = 2000)]
        public string PosPcbSerial { get; set; }

        /// <summary>
        /// 完成情况
        /// </summary>
        [SugarColumn(ColumnName = "PosPcbaStated", ColumnDescription = "完成情况 ", Length = 20)]
        public string PosPcbaStated { get; set; }

        /// <summary>
        /// 生产工数
        /// </summary>
        [SugarColumn(ColumnName = "PosProTime", ColumnDescription = "生产工数 ", DefaultValue = "0")]
        public int PosProTime { get; set; }

        /// <summary>
        /// 切换次数
        /// </summary>
        [SugarColumn(ColumnName = "PosHandoffNum", ColumnDescription = "切换次数 ", DefaultValue = "0")]
        public int PosHandoffNum { get; set; }

        /// <summary>
        /// 切换时间
        /// </summary>
        [SugarColumn(ColumnName = "PosHandoffTime", ColumnDescription = "切换时间 ", DefaultValue = "0")]
        public int PosHandoffTime { get; set; }

        /// <summary>
        /// 切停机时间
        /// </summary>
        [SugarColumn(ColumnName = "PosDownTime", ColumnDescription = "切停机时间 ", DefaultValue = "0")]
        public int PosDownTime { get; set; }

        /// <summary>
        /// 损失工数
        /// </summary>
        [SugarColumn(ColumnName = "PosLossTime", ColumnDescription = "损失工数 ", DefaultValue = "0")]
        public int PosLossTime { get; set; }

        /// <summary>
        /// 投入工数
        /// </summary>
        [SugarColumn(ColumnName = "PosMakeTime", ColumnDescription = "投入工数 ", DefaultValue = "0")]
        public int PosMakeTime { get; set; }

        /// <summary>
        /// 不良台数
        /// </summary>
        [SugarColumn(ColumnName = "PosBadQty", ColumnDescription = "不良台数 ", DefaultValue = "0")]
        public int PosBadQty { get; set; }

        /// <summary>
        /// 手插仕损
        /// </summary>
        [SugarColumn(ColumnName = "PosManualLoss", ColumnDescription = "手插仕损 ", DefaultValue = "0")]
        public int PosManualLoss { get; set; }

        /// <summary>
        /// 修正仕损
        /// </summary>
        [SugarColumn(ColumnName = "PosRepairLoss", ColumnDescription = "修正仕损 ", DefaultValue = "0")]
        public int PosRepairLoss { get; set; }

        /// <summary>
        /// 停线原因
        /// </summary>
        [SugarColumn(ColumnName = "PosDownTimeReasons", ColumnDescription = "停线原因 ", Length = 200)]
        public string PosDownTimeReasons { get; set; }

        /// <summary>
        /// 停线备注说明
        /// </summary>
        [SugarColumn(ColumnName = "PosDownTimeDescription", ColumnDescription = "停线备注说明 ", Length = 200)]
        public string PosDownTimeDescription { get; set; }

        /// <summary>
        /// 未达成原因
        /// </summary>
        [SugarColumn(ColumnName = "PosMissingReasons", ColumnDescription = "未达成原因 ", Length = 200)]
        public string PosMissingReasons { get; set; }

        /// <summary>
        /// 未达成备注说明
        /// </summary>
        [SugarColumn(ColumnName = "PosMissingDescription", ColumnDescription = "未达成备注说明 ", Length = 200)]
        public string PosMissingDescription { get; set; }

        /// <summary>
        /// 自定义A
        /// </summary>
        [SugarColumn(ColumnName = "UDF01", ColumnDescription = "自定义A ", Length = 200)]
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B
        /// </summary>
        [SugarColumn(ColumnName = "UDF02", ColumnDescription = "自定义B ", Length = 200)]
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C
        /// </summary>
        [SugarColumn(ColumnName = "UDF03", ColumnDescription = "自定义C ", Length = 200)]
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D
        /// </summary>
        [SugarColumn(ColumnName = "UDF04", ColumnDescription = "自定义D ", Length = 200)]
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E
        /// </summary>
        [SugarColumn(ColumnName = "UDF05", ColumnDescription = "自定义E ", Length = 200)]
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F
        /// </summary>
        [SugarColumn(ColumnName = "UDF06", ColumnDescription = "自定义F ", Length = 200)]
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1
        /// </summary>
        [SugarColumn(ColumnName = "UDF51", ColumnDescription = "自定义1 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2
        /// </summary>
        [SugarColumn(ColumnName = "UDF52", ColumnDescription = "自定义2 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3
        /// </summary>
        [SugarColumn(ColumnName = "UDF53", ColumnDescription = "自定义3 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4
        /// </summary>
        [SugarColumn(ColumnName = "UDF54", ColumnDescription = "自定义4 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5
        /// </summary>
        [SugarColumn(ColumnName = "UDF55", ColumnDescription = "自定义5 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6
        /// </summary>
        [SugarColumn(ColumnName = "UDF56", ColumnDescription = "自定义6 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        [SugarColumn(ColumnName = "IsDeleted", ColumnDescription = "软删除 ", DefaultValue = "0")]
        public int IsDeleted { get; set; }
    }
}