namespace Ams.Model.Dto.Monitor
{
    /// <summary>
    /// 登录日志统计
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public class StatiLoginLogDto
    {
        /// <summary>
        /// 去重数据
        /// </summary>
        public int DeRepeatNum { get; set; }

        public int Num { get; set; }
        public DateTime Date { get; set; }
        public string WeekName { get; set; }
    }
}