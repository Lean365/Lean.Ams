
namespace Ams.Model.Logistics
{
    /// <summary>
    /// 生产班组
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 14:45:07
    /// </summary>
    [SugarTable("pp_line","生产班组")]
    public class PpLine
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long PlSFID { get; set; }

        /// <summary>
        /// 班组类别 
        /// </summary>
        [SugarColumn(ColumnName="PlLineType", ColumnDescription = "班组类别 ",Length = 200)]
        public string PlLineType { get; set; }

        /// <summary>
        /// 班组代码 
        /// </summary>
        [SugarColumn(ColumnName="PlLineCode", ColumnDescription = "班组代码 ",Length = 200)]
        public string PlLineCode { get; set; }

        /// <summary>
        /// 语言Key 
        /// </summary>
        [SugarColumn(ColumnName="PlLineLangCode", ColumnDescription = "语言Key ",Length = 200)]
        public string PlLineLangCode { get; set; }

        /// <summary>
        /// 班组名称 
        /// </summary>
        [SugarColumn(ColumnName="PlLineName", ColumnDescription = "班组名称 ",Length = 200)]
        public string PlLineName { get; set; }

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