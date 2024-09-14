namespace Ams.Model.Admin
{
    //[EpplusTable(PrintHeaders = true, AutofitColumns = true, AutoCalculate = true, ShowTotal = true)]
    public class SysBase
    {
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(ColumnName = "Remark", ColumnDescription = "备注", Length = 500)]
        public string Remark { get; set; }

        /// <summary>
        /// 预留A
        /// </summary>
        [SugarColumn(ColumnName = "Ref01", ColumnDescription = "预留A", Length = 1)]
        public string Ref01 { get; set; }

        /// <summary>
        /// 预留B
        /// </summary>
        [SugarColumn(ColumnName = "Ref02", ColumnDescription = "预留B", Length = 8)]
        public string Ref02 { get; set; }

        /// <summary>
        /// 预留C
        /// </summary>
        [SugarColumn(ColumnName = "Ref03", ColumnDescription = "预留C", Length = 30)]
        public string Ref03 { get; set; }

        /// <summary>
        /// 预留1
        /// </summary>
        [SugarColumn(ColumnName = "Ref04", ColumnDescription = "预留1", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Ref04 { get; set; }

        /// <summary>
        /// 预留2
        /// </summary>
        [SugarColumn(ColumnName = "Ref05", ColumnDescription = "预留2", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Ref05 { get; set; }

        /// <summary>
        /// 预留3
        /// </summary>
        [SugarColumn(ColumnName = "Ref06", ColumnDescription = "预留3", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Ref06 { get; set; }

        /// <summary>
        /// 自定义A
        /// </summary>
        [SugarColumn(ColumnName = "Udf01", ColumnDescription = "自定义A", Length = 200)]
        public string Udf01 { get; set; }

        /// <summary>
        /// 自定义B
        /// </summary>
        [SugarColumn(ColumnName = "Udf02", ColumnDescription = "自定义B", Length = 200)]
        public string Udf02 { get; set; }

        /// <summary>
        /// 自定义C
        /// </summary>
        [SugarColumn(ColumnName = "Udf03", ColumnDescription = "自定义C", Length = 200)]
        public string Udf03 { get; set; }

        /// <summary>
        /// 自定义D
        /// </summary>
        [SugarColumn(ColumnName = "Udf04", ColumnDescription = "自定义D", Length = 500)]
        public string Udf04 { get; set; }

        /// <summary>
        /// 自定义E
        /// </summary>
        [SugarColumn(ColumnName = "Udf05", ColumnDescription = "自定义E", Length = 500)]
        public string Udf05 { get; set; }

        /// <summary>
        /// 自定义F
        /// </summary>
        [SugarColumn(ColumnName = "Udf06", ColumnDescription = "自定义F", Length = 500)]
        public string Udf06 { get; set; }

        /// <summary>
        /// 自定义1
        /// </summary>
        [SugarColumn(ColumnName = "Udf51", ColumnDescription = "自定义1", DefaultValue = "0")]
        public int Udf51 { get; set; }

        /// <summary>
        /// 自定义2
        /// </summary>
        [SugarColumn(ColumnName = "Udf52", ColumnDescription = "自定义2", DefaultValue = "0")]
        public int Udf52 { get; set; }

        /// <summary>
        /// 自定义3
        /// </summary>
        [SugarColumn(ColumnName = "Udf53", ColumnDescription = "自定义3", DefaultValue = "0")]
        public int Udf53 { get; set; }

        /// <summary>
        /// 自定义4
        /// </summary>
        [SugarColumn(ColumnName = "Udf54", ColumnDescription = "自定义4", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Udf54 { get; set; }

        /// <summary>
        /// 自定义5
        /// </summary>
        [SugarColumn(ColumnName = "Udf55", ColumnDescription = "自定义5", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Udf55 { get; set; }

        /// <summary>
        /// 自定义6
        /// </summary>
        [SugarColumn(ColumnName = "Udf56", ColumnDescription = "自定义6", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal Udf56 { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        [JsonProperty(propertyName: "isDeleted")]
        public int Is_deleted { get; set; } = 0;

        /// <summary>
        /// 创建人
        /// </summary>
        [SugarColumn(ColumnName = "Create_by", ColumnDescription = "创建人", IsOnlyIgnoreUpdate = true, Length = 64, IsNullable = true)]
        [JsonProperty(propertyName: "createBy")]
        [ExcelIgnore]
        public string Create_by { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "Create_time", ColumnDescription = "创建时间", IsOnlyIgnoreUpdate = true, IsNullable = true)]
        [JsonProperty(propertyName: "createTime")]
        [ExcelColumn(Format = "yyyy-MM-dd HH:mm:ss")]
        public DateTime Create_time { get; set; } = DateTime.Now;

        /// <summary>
        /// 更新人
        /// </summary>
        [JsonIgnore]
        [JsonProperty(propertyName: "updateBy")]
        [SugarColumn(ColumnName = "Update_by", ColumnDescription = "更新人", IsOnlyIgnoreInsert = true, Length = 64, IsNullable = true)]
        [ExcelIgnore]
        public string Update_by { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        //[JsonIgnore]
        [SugarColumn(ColumnName = "Update_time", ColumnDescription = "更新时间", IsOnlyIgnoreInsert = true, IsNullable = true)]
        [JsonProperty(propertyName: "updateTime")]
        [ExcelIgnore]
        public DateTime? Update_time { get; set; }
    }
}