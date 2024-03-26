
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 会计科目
    /// 数据实体对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// </summary>
    [SugarTable("fico_accounting_title")]
    public class AccountingTitle
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FatSFID { get; set; }

        /// <summary>
        /// 科目代码 
        /// </summary>
        public string FatCode { get; set; }

        /// <summary>
        /// 科目简称 
        /// </summary>
        public string FatShortName { get; set; }

        /// <summary>
        /// 科目全称 
        /// </summary>
        public string FatFullName { get; set; }

        /// <summary>
        /// 语言 
        /// </summary>
        public string FatLangKey { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 说明 
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