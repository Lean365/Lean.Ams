namespace Ams.Kernel.Model.Dto.System
{
    /// <summary>
    /// 用户管理
    /// 锁定用户
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>

    public class LockUserDto
    {
        public string Name { get; set; }
        public string ClientId { get; set; }
        public string ConnnectionId { get; set; }
        public string Reason { get; set; }
        public int Time { get; set; }
    }
}