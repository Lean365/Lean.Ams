
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 会计科目
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 12:02:48
    /// </summary>
    [SugarTable("fico_accounting_title","会计科目")]
    public class FicoAccountingTitle
    {
        /// <summary>
        /// ID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FatSfId { get; set; }

        /// <summary>
        /// 集团 
        /// </summary>
        [SugarColumn(ColumnName="Mandt", ColumnDescription = "集团 ",Length = 10)]
        public string Mandt { get; set; }

        /// <summary>
        /// 公司代码 
        /// </summary>
        [SugarColumn(ColumnName="Bukrs", ColumnDescription = "公司代码 ",Length = 8)]
        public string Bukrs { get; set; }

        /// <summary>
        /// 币种 
        /// </summary>
        [SugarColumn(ColumnName="Waers", ColumnDescription = "币种 ",Length = 3)]
        public string Waers { get; set; }

        /// <summary>
        /// 语言Key 
        /// </summary>
        [SugarColumn(ColumnName="Spras", ColumnDescription = "语言Key ",Length = 100)]
        public string Spras { get; set; }

        /// <summary>
        /// 科目编号 
        /// </summary>
        [SugarColumn(ColumnName="Saknr", ColumnDescription = "科目编号 ",Length = 20)]
        public string Saknr { get; set; }

        /// <summary>
        /// 科目表 
        /// </summary>
        [SugarColumn(ColumnName="Ktopl", ColumnDescription = "科目表 ",Length = 8)]
        public string Ktopl { get; set; }

        /// <summary>
        /// BS类别 
        /// </summary>
        [SugarColumn(ColumnName="Xbilk", ColumnDescription = "BS类别 ",Length = 1)]
        public string Xbilk { get; set; }

        /// <summary>
        /// PL类别 
        /// </summary>
        [SugarColumn(ColumnName="Gvtyp", ColumnDescription = "PL类别 ",Length = 1)]
        public string Gvtyp { get; set; }

        /// <summary>
        /// 统驭类别 
        /// </summary>
        [SugarColumn(ColumnName="Mitkz", ColumnDescription = "统驭类别 ",Length = 2)]
        public string Mitkz { get; set; }

        /// <summary>
        /// 短文本 
        /// </summary>
        [SugarColumn(ColumnName="Stext", ColumnDescription = "短文本 ",Length = 40)]
        public string Stext { get; set; }

        /// <summary>
        /// 长文本 
        /// </summary>
        [SugarColumn(ColumnName="Ltext", ColumnDescription = "长文本 ",Length = 80)]
        public string Ltext { get; set; }

        /// <summary>
        /// 附加文本 
        /// </summary>
        [SugarColumn(ColumnName="Atext", ColumnDescription = "附加文本 ",Length = 100)]
        public string Atext { get; set; }

        /// <summary>
        /// 科目组 
        /// </summary>
        [SugarColumn(ColumnName="Ktoks", ColumnDescription = "科目组 ",Length = 8)]
        public string Ktoks { get; set; }

        /// <summary>
        /// 冻结 
        /// </summary>
        [SugarColumn(ColumnName="Xspea", ColumnDescription = "冻结 ",DefaultValue = "0")]
        public int Xspea { get; set; }

        /// <summary>
        /// 预留A 
        /// </summary>
        [SugarColumn(ColumnName="REF01", ColumnDescription = "预留A ",Length = 1)]
        public string REF01 { get; set; }

        /// <summary>
        /// 预留B 
        /// </summary>
        [SugarColumn(ColumnName="REF02", ColumnDescription = "预留B ",Length = 8)]
        public string REF02 { get; set; }

        /// <summary>
        /// 预留C 
        /// </summary>
        [SugarColumn(ColumnName="REF03", ColumnDescription = "预留C ",Length = 30)]
        public string REF03 { get; set; }

        /// <summary>
        /// 预留1 
        /// </summary>
        [SugarColumn(ColumnName="REF04", ColumnDescription = "预留1 ",DefaultValue = "0",Length = 18, DecimalDigits = 5)]
        public decimal REF04 { get; set; }

        /// <summary>
        /// 预留2 
        /// </summary>
        [SugarColumn(ColumnName="REF05", ColumnDescription = "预留2 ",DefaultValue = "0",Length = 18, DecimalDigits = 5)]
        public decimal REF05 { get; set; }

        /// <summary>
        /// 预留3  
        /// </summary>
        [SugarColumn(ColumnName="REF06", ColumnDescription = "预留3  ",DefaultValue = "0",Length = 18, DecimalDigits = 5)]
        public decimal REF06 { get; set; }

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
        [SugarColumn(ColumnName="UDF04", ColumnDescription = "自定义D ",Length = 500)]
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E 
        /// </summary>
        [SugarColumn(ColumnName="UDF05", ColumnDescription = "自定义E ",Length = 500)]
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F 
        /// </summary>
        [SugarColumn(ColumnName="UDF06", ColumnDescription = "自定义F ",Length = 500)]
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1 
        /// </summary>
        [SugarColumn(ColumnName="UDF51", ColumnDescription = "自定义1 ",DefaultValue = "0")]
        public int? UDF51 { get; set; }

        /// <summary>
        /// 自定义2 
        /// </summary>
        [SugarColumn(ColumnName="UDF52", ColumnDescription = "自定义2 ",DefaultValue = "0")]
        public int? UDF52 { get; set; }

        /// <summary>
        /// 自定义3 
        /// </summary>
        [SugarColumn(ColumnName="UDF53", ColumnDescription = "自定义3 ",DefaultValue = "0")]
        public int? UDF53 { get; set; }

        /// <summary>
        /// 自定义4 
        /// </summary>
        [SugarColumn(ColumnName="UDF54", ColumnDescription = "自定义4 ",DefaultValue = "0",Length = 18, DecimalDigits = 5)]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5 
        /// </summary>
        [SugarColumn(ColumnName="UDF55", ColumnDescription = "自定义5 ",DefaultValue = "0",Length = 18, DecimalDigits = 5)]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6 
        /// </summary>
        [SugarColumn(ColumnName="UDF56", ColumnDescription = "自定义6 ",DefaultValue = "0",Length = 18, DecimalDigits = 5)]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除  
        /// </summary>
        [SugarColumn(ColumnName="IsDeleted", ColumnDescription = "软删除  ",DefaultValue = "0")]
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 备注说明  
        /// </summary>
        [SugarColumn(ColumnName="Remark", ColumnDescription = "备注说明  ",Length = 500)]
        public string Remark { get; set; }

        /// <summary>
        /// 创建人员 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新人员 
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