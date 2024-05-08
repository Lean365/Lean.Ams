namespace Ams.Kernel.Model.Dto.System
{
    /// <summary>
    /// 字典数据
    /// 参数对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SysDictDataParamDto
    {
        public string DictType { get; set; }

        //public string ColumnName { get; set; }
        public List<SysDictDataDto> List { get; set; }
    }

    /// <summary>
    /// 字典数据
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SysDictDataDto
    {
        public string DictLabel { get; set; }
        public string DictValue { get; set; }
        public string DictType { get; set; }
        public string CssClass { get; set; } = string.Empty;
        public string ListClass { get; set; } = string.Empty;

        /// <summary>
        /// 多语言翻译key值
        /// </summary>
        public string LangKey { get; set; } = string.Empty;

        #region uniapp返回字段

        public string Label { get; set; }
        public string Value { get; set; }

        #endregion uniapp返回字段
    }
}