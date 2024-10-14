namespace Ams.Model.Admin.Dto
{
    public class SysDictDataParamDto
    {
        /// <summary>
        /// 字典类型
        /// </summary>
        public string DictType { get; set; }

        //public string ColumnName { get; set; }
        /// <summary>
        /// 字典清单
        /// </summary>
        public List<SysDictDataDto> List { get; set; }
    }

    public class SysDictDataDto
    {
        /// <summary>
        /// 字典标签
        /// </summary>
        public string DictLabel { get; set; }

        /// <summary>
        /// 字典键值
        /// </summary>
        public string DictValue { get; set; }

        /// <summary>
        /// 字典类型
        /// </summary>
        public string DictType { get; set; }

        /// <summary>
        /// 样式
        /// </summary>
        public string CssClass { get; set; } = string.Empty;

        /// <summary>
        /// 样式属性
        /// </summary>
        public string ListClass { get; set; } = string.Empty;

        /// <summary>
        /// 多语言翻译key值
        /// </summary>
        public string LangKey { get; set; } = string.Empty;

        /// <summary>
        /// 扩展标签
        /// </summary>
        public string ExtLabel { get; set; }

        /// <summary>
        /// 扩展键值
        /// </summary>
        public string ExtValue { get; set; }

        #region uniapp返回字段

        /// <summary>
        /// uniapp返回字段
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// uniapp返回字段
        /// </summary>
        public string Value { get; set; }

        #endregion uniapp返回字段
    }
}