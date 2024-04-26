namespace Ams.Model.System.Dto
{
    /// <summary>
    /// 锁定用户
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class LockUserDto
    {
        public string Name { get; set; }
        public string ClientId { get; set; }
        public string ConnnectionId { get; set; }
        public string Reason { get; set; }
        public int Time { get; set; }
    }
}