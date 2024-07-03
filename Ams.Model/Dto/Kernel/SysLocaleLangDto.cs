namespace Ams.Model.Dto.Kernel
{
    /// <summary>
    /// 本地语言查询对象
    /// </summary>
    public class CommonLangQueryDto : PagerInfo
    {
        public string LangCode { get; set; }
        public string LangKey { get; set; }
        public DateTime? BeginAddtime { get; set; }
        public DateTime? EndAddtime { get; set; }
        public int ShowMode { get; set; }
    }

    /// <summary>
    /// 本地语言输入对象
    /// </summary>
    public class SysLocaleLangDto
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
}