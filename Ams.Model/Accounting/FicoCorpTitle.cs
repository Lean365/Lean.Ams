
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 公司科目
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/3 15:41:55
    /// </summary>
    [SugarTable("fico_corp_title","公司科目")]
    public class FicoCorpTitle
    {
        /// <summary>
        /// FSID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FctSFID { get; set; }

        /// <summary>
        /// 公司代码 
        /// </summary>
        public string FctCorp { get; set; }

        /// <summary>
        /// 科目代码 
        /// </summary>
        public string FctCode { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        public int IsDeleted { get; set; }

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