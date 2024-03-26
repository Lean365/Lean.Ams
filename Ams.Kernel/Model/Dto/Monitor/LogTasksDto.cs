namespace Ams.Kernel.Model.Dto.Monitor
{
    /// <summary>
    /// 日志任务
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// </summary>
    public class LogTasksQzQueryDto
    {
        /// <summary>
        /// 查询字符串
        /// </summary>
        public string Name { get; set; }

        public string JobName { get; set; }
        public string JobId { get; set; }
        public string JobGroup { get; set; }
        public int IsState { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
    }

    /// <summary>
    /// 日志任务
    /// 输入输出对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// </summary>
    public class LogTasksDto
    {
    }
}