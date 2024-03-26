using Ams.Model;

namespace Ams.Kernel.Model.Dto.System
{
    /// <summary>
    /// 本地语言
    /// 输入输出对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    public class SysLocaleLangDto
    {
        //[Required(ErrorMessage = "id不能为空")]
        public long Id { get; set; }

        //[Required(ErrorMessage = "语言code不能为空")]
        public string LangCode { get; set; }

        public string LangKey { get; set; }

        //[Required(ErrorMessage = "名称不能为空")]
        public string LangName { get; set; }

        public string Create_by { get; set; }

        public string Update_by { get; set; }

        public List<SysLocaleLangDto> LangList { get; set; }
    }

    /// <summary>
    /// 本地语言
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    public class SysLocaleLangQueryDto : PagerInfo
    {
        public string LangCode { get; set; }
        public string LangKey { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int ShowMode { get; set; }
    }
}