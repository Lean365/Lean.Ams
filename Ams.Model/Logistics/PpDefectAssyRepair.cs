namespace Ams.Model.Logistics
{
    /// <summary>
    /// 制一不良
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 14:30:29
    /// </summary>
    [SugarTable("pp_defect_assy_repair", "制一不良")]
    public class PpDefectAssyRepair : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long PpdSfid { get; set; }

        /// <summary>
        /// 生产订单
        /// </summary>
        public string PpdOrderNo { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        public int PpdOrderQty { get; set; }

        /// <summary>
        /// 生产批次
        /// </summary>
        public string PpdLot { get; set; }

        /// <summary>
        /// 生产机种
        /// </summary>
        public string PpdModel { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? PpdDate { get; set; }

        /// <summary>
        /// 生产班组
        /// </summary>
        public string PpdLineName { get; set; }

        /// <summary>
        /// 生产实绩
        /// </summary>
        public int PpdRealQty { get; set; }

        /// <summary>
        /// 无不良数
        /// </summary>
        public int PpdNobadQty { get; set; }

        /// <summary>
        /// 不良类别
        /// </summary>
        public string PpdBadType { get; set; }

        /// <summary>
        /// 不良数量
        /// </summary>
        public int PpdBadQty { get; set; }

        /// <summary>
        /// 不良总数
        /// </summary>
        public int PpdBadTotal { get; set; }

        /// <summary>
        /// 不良状况
        /// </summary>
        public string PpdBadSymptom { get; set; }

        /// <summary>
        /// 不良个所
        /// </summary>
        public string PpdBadPosition { get; set; }

        /// <summary>
        /// 不良原因
        /// </summary>
        public string PpdBadReason { get; set; }

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