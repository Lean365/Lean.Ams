namespace Ams.Model.Admin.Dto
{
    /// <summary>
    /// 表名称
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/4 16:50:06
    /// </summary>
    public class SysTableQueryDto : PagerInfo
    {
        public string Tb002 { get; set; }
        public string Tb003 { get; set; }
    }

    /// <summary>
    /// 表名称
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/4 16:50:06
    /// </summary>
    public class SysTableDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "表名不能为空")]
        //[ExcelColumn(Name = "表名")]
        [ExcelColumnName("表名")]
        public string Tb002 { get; set; }

        //[ExcelColumn(Name = "表描述")]
        [ExcelColumnName("表描述")]
        public string Tb003 { get; set; }

        //[ExcelColumn(Name = "序号")]
        [ExcelColumnName("序号")]
        public string Tb004 { get; set; }

        //[ExcelColumn(Name = "简称")]
        [ExcelColumnName("简称")]
        public string Tb005 { get; set; }

        //[ExcelColumn(Name = "缩写")]
        [ExcelColumnName("缩写")]
        public string Tb006 { get; set; }

        //[ExcelColumn(Name = "前缀")]
        [ExcelColumnName("前缀")]
        public string Tb007 { get; set; }

        //[ExcelColumn(Name = "表名")]
        [ExcelColumnName("表名")]
        public string Tb008 { get; set; }

        //[ExcelColumn(Name = "翻译")]
        [ExcelColumnName("翻译")]
        public string Tb009 { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 表名称
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/4 16:50:06
    /// </summary>
    public class SysTableImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "表名不能为空")]
        //[ExcelColumn(Name = "表名")]
        [ExcelColumnName("表名")]
        public string Tb002 { get; set; }

        //[ExcelColumn(Name = "表描述")]
        [ExcelColumnName("表描述")]
        public string Tb003 { get; set; }

        //[ExcelColumn(Name = "序号")]
        [ExcelColumnName("序号")]
        public string Tb004 { get; set; }

        //[ExcelColumn(Name = "简称")]
        [ExcelColumnName("简称")]
        public string Tb005 { get; set; }

        //[ExcelColumn(Name = "缩写")]
        [ExcelColumnName("缩写")]
        public string Tb006 { get; set; }

        //[ExcelColumn(Name = "前缀")]
        [ExcelColumnName("前缀")]
        public string Tb007 { get; set; }

        //[ExcelColumn(Name = "表名")]
        [ExcelColumnName("表名")]
        public string Tb008 { get; set; }

        //[ExcelColumn(Name = "翻译")]
        [ExcelColumnName("翻译")]
        public string Tb009 { get; set; }
    }
}