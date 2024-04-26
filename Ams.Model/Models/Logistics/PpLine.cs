namespace Ams.Model.Logistics
{
    /// <summary>
    /// 生产班组
    /// 数据实体
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: 2024/4/25 17:15:19
    /// </summary>
    [SugarTable("pp_line", tableDescription: "生产班组")]
    public class PpLine
    {
        /// <summary>
        /// SFID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PlSFID { get; set; }

        /// <summary>
        /// 班组类别
        /// </summary>
        public string PlLineType { get; set; }

        /// <summary>
        /// 班组代码
        /// </summary>
        public string PlLineCode { get; set; }

        /// <summary>
        /// 语言Key
        /// </summary>
        public string PlLineLangCode { get; set; }

        /// <summary>
        /// 班组名称
        /// </summary>
        public string PlLineName { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        public int? IsDeleted { get; set; } = 0;

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
    }
}