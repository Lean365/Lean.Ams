namespace Ams.Kernel.Model.Routine
{
    /// <summary>
    /// 邮件模板
    /// 数据实体对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 13:57:42)
    /// <summary>
    [SugarTable("routine_email_tpl", "邮件模板")]
    public class EmailTpl : SysBase
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public string Name { get; set; }

        [SugarColumn(ColumnDescription = "模板内容", ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string Content { get; set; }
    }
}