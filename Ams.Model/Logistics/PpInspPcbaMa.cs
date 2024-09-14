using Ams.Model.Logistics;

namespace Ams.Model.Logistics
{
    /// <summary>
    /// 检查
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/12 16:26:18
    /// </summary>
    [SugarTable("pp_insp_pcba_ma","检查")]
    public class PpInspPcbaMa : SysBase
    {
        /// <summary>
        /// ID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 检查日期 
        /// </summary>
        public DateTime? Mu002 { get; set; }

        /// <summary>
        /// 生产机种 
        /// </summary>
        [SugarColumn(ColumnName="Mu003", ColumnDescription = "生产机种",Length = 50)]
        public string Mu003 { get; set; }

        /// <summary>
        /// 生产工单 
        /// </summary>
        [SugarColumn(ColumnName="Mu004", ColumnDescription = "生产工单",Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mu004 { get; set; }

        /// <summary>
        /// 生产批次 
        /// </summary>
        [SugarColumn(ColumnName="Mu005", ColumnDescription = "生产批次",Length = 20)]
        public string Mu005 { get; set; }

        /// <summary>
        /// 工单台数 
        /// </summary>
        [SugarColumn(ColumnName="Mu006", ColumnDescription = "工单台数",DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mu006 { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        [SugarColumn(ColumnName="Remark", ColumnDescription = "备注",Length = 500)]
        public string Remark { get; set; }

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
        [SugarColumn(ColumnName = "is_deleted")]
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 创建人 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新人 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 更新时间 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(PpInspPcbaSlv.ParentId), nameof(Id))] //自定义关系映射
        public List<PpInspPcbaSlv> PpInspPcbaSlvNav { get; set; }
    }
}