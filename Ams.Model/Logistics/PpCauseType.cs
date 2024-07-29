
namespace Ams.Model.Logistics
{
    /// <summary>
    /// 原因类别
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:12:48
    /// </summary>
    [SugarTable("pp_cause_type","原因类别")]
    public class PpCauseType
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long CtSFID { get; set; }

        /// <summary>
        /// 原因类别 
        /// </summary>
        [SugarColumn(ColumnName="CtCauseType", ColumnDescription = "原因类别 ",Length = 50)]
        public string CtCauseType { get; set; }

        /// <summary>
        /// 语言Key 
        /// </summary>
        [SugarColumn(ColumnName="CtCauseLangCode", ColumnDescription = "语言Key ",Length = 255)]
        public string CtCauseLangCode { get; set; }

        /// <summary>
        /// 原因名称 
        /// </summary>
        [SugarColumn(ColumnName="CtCauseText", ColumnDescription = "原因名称 ",Length = 255)]
        public string CtCauseText { get; set; }

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