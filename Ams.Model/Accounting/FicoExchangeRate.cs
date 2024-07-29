
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 汇率表
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 17:00:23
    /// </summary>
    [SugarTable("fico_exchange_rate","汇率表")]
    public class FicoExchangeRate
    {
        /// <summary>
        /// ID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FerSfid { get; set; }

        /// <summary>
        /// 公司 
        /// </summary>
        [SugarColumn(ColumnName="FerCorp", ColumnDescription = "公司 ",Length = 4)]
        public string FerCorp { get; set; }

        /// <summary>
        /// 日期 
        /// </summary>
        public DateTime? FerEffDate { get; set; }

        /// <summary>
        /// 基数 
        /// </summary>
        [SugarColumn(ColumnName="FerStd", ColumnDescription = "基数 ",DefaultValue = "0")]
        public int FerStd { get; set; }

        /// <summary>
        /// 从币种 
        /// </summary>
        [SugarColumn(ColumnName="FerfmCcy", ColumnDescription = "从币种 ",Length = 3)]
        public string FerfmCcy { get; set; }

        /// <summary>
        /// 汇率 
        /// </summary>
        [SugarColumn(ColumnName="FerRate", ColumnDescription = "汇率 ",DefaultValue = "0",Length = 18, DecimalDigits = 5)]
        public decimal FerRate { get; set; }

        /// <summary>
        /// 到币种 
        /// </summary>
        [SugarColumn(ColumnName="FertoCcy", ColumnDescription = "到币种 ",Length = 3)]
        public string FertoCcy { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        [SugarColumn(ColumnName="IsDeleted", ColumnDescription = "软删除 ",DefaultValue = "0")]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 说明 
        /// </summary>
        [SugarColumn(ColumnName="Remark", ColumnDescription = "说明 ",Length = 2000)]
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