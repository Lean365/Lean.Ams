namespace Ams.Model.Routine
{
    /// <summary>
    /// 邮件发送模板
    /// </summary>
    [SugarTable("routine_email_tpl", "邮件模板")]
    [Tenant("0")]
    public class EmailTpl : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 模板内容
        /// </summary>

        [SugarColumn(ColumnDescription = "模板内容", ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string Content { get; set; }
    }
}