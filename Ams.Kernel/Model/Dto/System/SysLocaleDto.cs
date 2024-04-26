using System;
using System.Collections.Generic;
using Ams.Model;

namespace Ams.Kernel.Model.Dto.System
{
    /// <summary>
    /// 本地语言输入对象
    /// </summary>
    public class SysLocaleDto
    {
        //[Required(ErrorMessage = "id不能为空")]
        public long Id { get; set; }
        //[Required(ErrorMessage = "语言code不能为空")]
        public string LangCode { get; set; }
        public string LangKey { get; set; }
        //[Required(ErrorMessage = "名称不能为空")]
        public string LangName { get; set; }
        public List<SysLocaleDto> LangList { get; set; }
    }

    /// <summary>
    /// 本地语言查询对象
    /// </summary>
    public class SysLocaleQueryDto : PagerInfo
    {
        public string LangCode { get; set; }
        public string LangKey { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int ShowMode { get; set; }
    }
}
