namespace Ams.Model.Kernel.Dto
{
    public class SysDictDataParamDto
    {
        public string DictType { get; set; }

        //public string ColumnName { get; set; }
        public List<SysDictDataDto> List { get; set; }
    }

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

        public string ExtLabel { get; set; }
        public string ExtValue { get; set; }

        #region uniapp返回字段

        public string Label { get; set; }
        public string Value { get; set; }

        #endregion uniapp返回字段
    }
}