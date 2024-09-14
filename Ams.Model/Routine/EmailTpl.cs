namespace Ams.Model.Routine
{
    /// <summary>
    /// 邮件模板
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("routine_email_tpl", TableDescription = "邮件模板")]
    [Tenant("0")]
    public class EmailTpl : SysBase
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        [SugarColumn(ColumnName = "Name", ColumnDescription = "模板名称", Length = 40)]
        public string Name { get; set; }

        /// <summary>
        /// 模板内容
        /// </summary>
        [SugarColumn(ColumnName = "Content", ColumnDescription = "模板内容", ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string Content { get; set; }
    }
}