namespace Ams.Model.Logistics
{
    /// <summary>
    /// 制一OPH主表
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 14:35:19
    /// </summary>
    [SugarTable("pp_output_assy_master", "制一OPH主表")]
    public class PpOutputAssyMaster : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long PomSfid { get; set; }

        /// <summary>
        /// 工单类别
        /// </summary>
        public string PomOrderType { get; set; }

        /// <summary>
        /// 工单号码
        /// </summary>
        public string PomOrderNo { get; set; }

        /// <summary>
        /// 工单数量
        /// </summary>
        public decimal PomOrderQty { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        public string PomOrderSerial { get; set; }

        /// <summary>
        /// 生产批次
        /// </summary>
        public string PomLot { get; set; }

        /// <summary>
        /// 机种名
        /// </summary>
        public string PomModel { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        public string PomItem { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? PomDate { get; set; }

        /// <summary>
        /// 生产班组
        /// </summary>
        public string PomLine { get; set; }

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

        [Navigate(NavigateType.OneToMany, nameof(PpOutputAssySlave.PosParentSfid), nameof(PomSfid))] //自定义关系映射
        public List<PpOutputAssySlave> PpOutputAssySlaveNav { get; set; }
    }
}