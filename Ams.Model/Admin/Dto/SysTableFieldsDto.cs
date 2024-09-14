namespace Ams.Model.Admin.Dto
{
    /// <summary>
    /// 表字段
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/4 16:50:01
    /// </summary>
    public class SysTableFieldsQueryDto : PagerInfo
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string Tf002 { get; set; }

        /// <summary>
        /// 字段编号
        /// </summary>
        public string Tf005 { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public string Tf015 { get; set; }
    }

    /// <summary>
    /// 表字段
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/4 16:50:01
    /// </summary>
    public class SysTableFieldsDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "表名不能为空")]
        //[ExcelColumn(Name = "表名")]
        [ExcelColumnName("表名")]
        public string Tf002 { get; set; }

        [Required(ErrorMessage = "字段编号不能为空")]
        //[ExcelColumn(Name = "字段编号")]
        [ExcelColumnName("字段编号")]
        public string Tf003 { get; set; }

        //[ExcelColumn(Name = "序号")]
        [ExcelColumnName("序号")]
        public string Tf004 { get; set; }

        //[ExcelColumn(Name = "字段名称")]
        [ExcelColumnName("字段名称")]
        public string Tf005 { get; set; }

        //[ExcelColumn(Name = "类型")]
        [ExcelColumnName("类型")]
        public string Tf006 { get; set; }

        //[ExcelColumn(Name = "长度")]
        [ExcelColumnName("长度")]
        public string Tf007 { get; set; }

        //[ExcelColumn(Name = "字段说明")]
        [ExcelColumnName("字段说明")]
        public string Tf008 { get; set; }

        //[ExcelColumn(Name = "实体类型")]
        [ExcelColumnName("实体类型")]
        public string Tf009 { get; set; }

        [Required(ErrorMessage = "最大长度不能为空")]
        //[ExcelColumn(Name = "最大长度")]
        [ExcelColumnName("最大长度")]
        public int Tf010 { get; set; }

        [Required(ErrorMessage = "精度不能为空")]
        //[ExcelColumn(Name = "精度")]
        [ExcelColumnName("精度")]
        public int Tf011 { get; set; }

        [Required(ErrorMessage = "刻度不能为空")]
        //[ExcelColumn(Name = "刻度")]
        [ExcelColumnName("刻度")]
        public int Tf012 { get; set; }

        //[ExcelColumn(Name = "原字段编号")]
        [ExcelColumnName("原字段编号")]
        public string Tf013 { get; set; }

        [Required(ErrorMessage = "Nullable不能为空")]
        //[ExcelColumn(Name = "Nullable")]
        [ExcelColumnName("Nullable")]
        public int Tf014 { get; set; }

        [Required(ErrorMessage = "翻译不能为空")]
        //[ExcelColumn(Name = "翻译")]
        [ExcelColumnName("翻译")]
        public string Tf015 { get; set; }

        //[ExcelColumn(Name = "建表语句")]
        [ExcelColumnName("建表语句")]
        public string Tf016 { get; set; }

        //[ExcelColumn(Name = "字段语句")]
        [ExcelColumnName("字段语句")]
        public string Tf017 { get; set; }

        //[ExcelColumn(Name = "默认值语句")]
        [ExcelColumnName("默认值语句")]
        public string Tf018 { get; set; }

        //[ExcelColumn(Name = "字段名")]
        [ExcelColumnName("字段名")]
        public string Tf019 { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 表字段
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/4 16:50:01
    /// </summary>
    public class SysTableFieldsImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        //[ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        [Required(ErrorMessage = "表名不能为空")]
        //[ExcelColumn(Name = "表名")]
        [ExcelColumnName("表名")]
        public string Tf002 { get; set; }

        [Required(ErrorMessage = "字段编号不能为空")]
        //[ExcelColumn(Name = "字段编号")]
        [ExcelColumnName("字段编号")]
        public string Tf003 { get; set; }

        //[ExcelColumn(Name = "序号")]
        [ExcelColumnName("序号")]
        public string Tf004 { get; set; }

        //[ExcelColumn(Name = "字段名称")]
        [ExcelColumnName("字段名称")]
        public string Tf005 { get; set; }

        //[ExcelColumn(Name = "类型")]
        [ExcelColumnName("类型")]
        public string Tf006 { get; set; }

        //[ExcelColumn(Name = "长度")]
        [ExcelColumnName("长度")]
        public string Tf007 { get; set; }

        //[ExcelColumn(Name = "字段说明")]
        [ExcelColumnName("字段说明")]
        public string Tf008 { get; set; }

        //[ExcelColumn(Name = "实体类型")]
        [ExcelColumnName("实体类型")]
        public string Tf009 { get; set; }

        [Required(ErrorMessage = "最大长度不能为空")]
        //[ExcelColumn(Name = "最大长度")]
        [ExcelColumnName("最大长度")]
        public int Tf010 { get; set; }

        [Required(ErrorMessage = "精度不能为空")]
        //[ExcelColumn(Name = "精度")]
        [ExcelColumnName("精度")]
        public int Tf011 { get; set; }

        [Required(ErrorMessage = "刻度不能为空")]
        //[ExcelColumn(Name = "刻度")]
        [ExcelColumnName("刻度")]
        public int Tf012 { get; set; }

        //[ExcelColumn(Name = "原字段编号")]
        [ExcelColumnName("原字段编号")]
        public string Tf013 { get; set; }

        [Required(ErrorMessage = "Nullable不能为空")]
        //[ExcelColumn(Name = "Nullable")]
        [ExcelColumnName("Nullable")]
        public int Tf014 { get; set; }

        [Required(ErrorMessage = "翻译不能为空")]
        //[ExcelColumn(Name = "翻译")]
        [ExcelColumnName("翻译")]
        public string Tf015 { get; set; }

        //[ExcelColumn(Name = "建表语句")]
        [ExcelColumnName("建表语句")]
        public string Tf016 { get; set; }

        //[ExcelColumn(Name = "字段语句")]
        [ExcelColumnName("字段语句")]
        public string Tf017 { get; set; }

        //[ExcelColumn(Name = "默认值语句")]
        [ExcelColumnName("默认值语句")]
        public string Tf018 { get; set; }

        //[ExcelColumn(Name = "字段名")]
        [ExcelColumnName("字段名")]
        public string Tf019 { get; set; }
    }
}