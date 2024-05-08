namespace Ams.Kernel.Model.Dto.Login
{
    /// <summary>
    /// 扫描
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class ScanDto
    {
        public string Uuid { get; set; }
        public string State { get; set; }
        public string DeviceId { get; set; }
    }
}