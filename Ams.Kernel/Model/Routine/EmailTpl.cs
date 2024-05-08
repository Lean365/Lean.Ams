namespace Ams.Kernel.Model.Routine
{
    /// <summary>
    /// 邮件发送模板
    /// 数据实体对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [SugarTable("routine_email_tpl")]
    [Tenant("0")]
    public class EmailTpl : SysBase
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public string Name { get; set; }

        [SugarColumn(ColumnDescription = "模板内容", ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string Content { get; set; }
    }
}