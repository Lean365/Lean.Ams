
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 公司科目
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 17:05:40
    /// </summary>
    [SugarTable("fico_accounting_corp","公司科目")]
    public class FicoAccountingCorp
    {
        /// <summary>
        /// FSID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FctSfid { get; set; }

        /// <summary>
        /// 公司代码 
        /// </summary>
        [SugarColumn(ColumnName="FctCorp", ColumnDescription = "公司代码 ",Length = 4)]
        public string FctCorp { get; set; }

        /// <summary>
        /// 科目代码 
        /// </summary>
        [SugarColumn(ColumnName="FctCode", ColumnDescription = "科目代码 ",Length = 10)]
        public string FctCode { get; set; }

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