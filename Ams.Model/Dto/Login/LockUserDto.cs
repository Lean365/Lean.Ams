namespace Ams.Model.Dto.Login
{
    /// <summary>
    /// LockUserDto
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
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