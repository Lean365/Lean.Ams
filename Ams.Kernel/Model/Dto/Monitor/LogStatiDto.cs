namespace Ams.Kernel.Model.Dto.Monitor
{
    /// <summary>
    /// 去重统计
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class LogStatiDto
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