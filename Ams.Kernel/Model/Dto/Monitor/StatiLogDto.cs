namespace Ams.Kernel.Model.Dto.Monitor
{
    /// <summary>
    /// 统计日志
    /// 输入输出对象
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class StatiLogDto
    {
        /// <summary>
        /// 去重数据
        /// </summary>
        public int DeRepeatNum { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 星期名称
        /// </summary>
        public string WeekName { get; set; }
    }
}