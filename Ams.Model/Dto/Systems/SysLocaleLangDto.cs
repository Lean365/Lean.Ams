namespace Ams.Model.Dto.Systems
{
    /// <summary>
    /// 本地语言输入对象
    /// </summary>
    public class SysLocaleLangDto : SysBase
    {
        //[Required(ErrorMessage = "id不能为空")]
        public long Id { get; set; }

        //[Required(ErrorMessage = "语言code不能为空")]
        public string LangCode { get; set; }

        public string LangKey { get; set; }

        //[Required(ErrorMessage = "名称不能为空")]
        public string LangName { get; set; }

        public List<SysLocaleLangDto> LangList { get; set; }
    }

    /// 本地语言输入对象
    /// </summary>
    public class SysLocaleLangImportTpl
    {
        //[Required(ErrorMessage = "id不能为空")]
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long Id { get; set; }

        //[Required(ErrorMessage = "语言code不能为空")]
        [Required(ErrorMessage = "语言code不能为空")]
        [ExcelColumn(Name = "语言code")]
        [ExcelColumnName("语言code")]
        public string LangCode { get; set; }

        //[Required(ErrorMessage = "语言key不能为空")]
        [ExcelColumn(Name = "语言key")]
        [ExcelColumnName("语言key")]
        public string LangKey { get; set; }

        //[Required(ErrorMessage = "名称不能为空")]
        public string LangName { get; set; }
    }

    /// <summary>
    /// 本地语言查询对象
    /// </summary>
    public class CommonLangQueryDto : PagerInfo
    {
        public string LangCode { get; set; }
        public string LangKey { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int ShowMode { get; set; }
    }
}