
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 会计科目
    /// 数据实体
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2023/12/26 7:53:53)
    /// </summary>
    [SugarTable("fico_accounting_title")]
    public class FicoAccountingTitle
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long FtSFID { get; set; }

        /// <summary>
        /// 公司名称 
        /// </summary>
        public string FtCorpCode { get; set; }

        /// <summary>
        /// 科目代码 
        /// </summary>
        public string FtTitleCode { get; set; }

        /// <summary>
        /// 科目名称 
        /// </summary>
        public string FtTitleName { get; set; }

        /// <summary>
        /// 语言 
        /// </summary>
        public string FtTitleLang { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 说明 
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建者 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

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