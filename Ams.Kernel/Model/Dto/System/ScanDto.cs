namespace Ams.Kernel.Model.Dto.System
{
    /// <summary>
    /// 扫码登录
    /// 输入输出对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    public class ScanDto
    {
        public string Uuid { get; set; }
        public string State { get; set; }
        public string DeviceId { get; set; }
    }
}