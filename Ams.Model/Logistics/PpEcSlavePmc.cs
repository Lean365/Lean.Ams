
namespace Ams.Model.Logistics
{
    /// <summary>
    /// Pmc设变
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/24 15:34:41
    /// </summary>
    [SugarTable("pp_ec_slave_pmc","Pmc设变")]
    public class PpEcSlavePmc
    {
        /// <summary>
        /// ID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long PmcSfid { get; set; }

        /// <summary>
        /// 父ID 
        /// </summary>
        public long PmcParentSfid { get; set; }

        /// <summary>
        /// 设变No. 
        /// </summary>
        [SugarColumn(ColumnName="PmcEcNo", ColumnDescription = "设变No. ",Length = 20)]
        public string PmcEcNo { get; set; }

        /// <summary>
        /// 机种 
        /// </summary>
        [SugarColumn(ColumnName="PmcModel", ColumnDescription = "机种 ",Length = 200)]
        public string PmcModel { get; set; }

        /// <summary>
        /// 物料 
        /// </summary>
        [SugarColumn(ColumnName="PmcItem", ColumnDescription = "物料 ",Length = 20)]
        public string PmcItem { get; set; }

        /// <summary>
        /// 实施标记 
        /// </summary>
        [SugarColumn(ColumnName="PmcImplStated", ColumnDescription = "实施标记 ",DefaultValue = "0")]
        public int PmcImplStated { get; set; }

        /// <summary>
        /// 输入日期 
        /// </summary>
        public DateTime? PmcEnteredDate { get; set; }

        /// <summary>
        /// 预投批次 
        /// </summary>
        [SugarColumn(ColumnName="PmcPreLot", ColumnDescription = "预投批次 ",Length = 255)]
        public string PmcPreLot { get; set; }

        /// <summary>
        /// 旧品处理 
        /// </summary>
        [SugarColumn(ColumnName="PmcDisposal", ColumnDescription = "旧品处理 ",DefaultValue = "0")]
        public int PmcDisposal { get; set; }

        /// <summary>
        /// 记事 
        /// </summary>
        [SugarColumn(ColumnName="PmcNote", ColumnDescription = "记事 ",Length = 255)]
        public string PmcNote { get; set; }

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
        /// 备注 
        /// </summary>
        [SugarColumn(ColumnName="Remark", ColumnDescription = "备注 ",Length = 2000)]
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