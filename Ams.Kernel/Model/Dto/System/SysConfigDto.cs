using Ams.Model;

namespace Ams.Kernel.Model.Dto.System
{
    /// <summary>
    /// 参数配置
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SysConfigQueryDto : PagerInfo
    {
        public string ConfigName { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public string ConfigType { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
    }

    /// <summary>
    /// 参数配置
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SysConfigDto
    {
        public int ConfigId { get; set; }
        public string ConfigName { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public string ConfigType { get; set; }
        public string Remark { get; set; }
    }
}