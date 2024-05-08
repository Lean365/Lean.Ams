namespace Ams.Kernel.Model.Dto.Monitor
{
    /// <summary>
    /// 任务日志
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
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
        public int IsStated { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
    }

    /// <summary>
    /// 任务日志
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class LogTasksQzDto
    {
    }
}