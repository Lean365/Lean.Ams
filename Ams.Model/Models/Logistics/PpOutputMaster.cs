using Ams.Model.Logistics;

namespace Ams.Model.Logistics
{
    /// <summary>
    /// oph主表
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/29 8:56:11
    /// </summary>
    [SugarTable("pp_output_master")]
    public class PpOutputMaster
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long PomSfid { get; set; }

        /// <summary>
        /// 生产工单 
        /// </summary>
        public string PomMfgOrder { get; set; }

        /// <summary>
        /// 工单数量 
        /// </summary>
        public decimal PomMfgOrderQty { get; set; }

        /// <summary>
        /// 管理序列号 
        /// </summary>
        public string PomMfgOrderSerial { get; set; }

        /// <summary>
        /// 生产批次 
        /// </summary>
        public string PomMfgLot { get; set; }

        /// <summary>
        /// 机种名 
        /// </summary>
        public string PomMfgModel { get; set; }

        /// <summary>
        /// 物料 
        /// </summary>
        public string PomMfgItem { get; set; }

        /// <summary>
        /// 生产日期 
        /// </summary>
        public DateTime? PomMfgDate { get; set; }

        /// <summary>
        /// 生产班组 
        /// </summary>
        public string PomMfgLine { get; set; }

        /// <summary>
        /// 直接人数 
        /// </summary>
        public int PomDirect { get; set; }

        /// <summary>
        /// 间接人数 
        /// </summary>
        public int PomIndirect { get; set; }

        /// <summary>
        /// 标准工时 
        /// </summary>
        public decimal PomStdTime { get; set; }

        /// <summary>
        /// 标准产能 
        /// </summary>
        public decimal PomStdOutput { get; set; }

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
        /// 备注 
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

        [Navigate(NavigateType.OneToMany, nameof(PpOutputSlave.PosParentSfid), nameof(PomSfid))] //自定义关系映射
        public List<PpOutputSlave> PpOutputSlaveNav { get; set; }
    }
}