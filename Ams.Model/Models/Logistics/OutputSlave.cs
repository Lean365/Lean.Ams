
namespace Ams.Model.Logistics
{
    /// <summary>
    /// oph从表
    /// 数据实体
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:22:39)
    /// </summary>
    [SugarTable("pp_output_slave")]
    public class OutputSlave
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
        public string PosUnfinishedReasons { get; set; }

        /// <summary>
        /// 未达成说明 
        /// </summary>
        public string PosUnfinishedDescription { get; set; }

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
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2 
        /// </summary>
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3 
        /// </summary>
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4 
        /// </summary>
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5 
        /// </summary>
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6 
        /// </summary>
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 说明 
        /// </summary>
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