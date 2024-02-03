
namespace Ams.Model.Logistics
{
    /// <summary>
    /// 原因类别
    /// 数据实体
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:54:27)
    /// </summary>
    [SugarTable("pp_cause_type")]
    public class CauseType
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long CtSFID { get; set; }

        /// <summary>
        /// 原因类别 
        /// </summary>
        public string CtCauseType { get; set; }

        /// <summary>
        /// 语言Key 
        /// </summary>
        public string CtCauseLangCode { get; set; }

        /// <summary>
        /// 原因名称 
        /// </summary>
        public string CtCauseText { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        public int? IsDeleted { get; set; }

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