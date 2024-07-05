namespace Ams.Model.Dto.Monitor
{
    /// <summary>
    /// 任务日志
    /// 查询
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public class TasksQzLogQueryDto
    {
        /// <summary>
        /// 查询字符串
        /// </summary>
        public string Name { get; set; }

        public string JobName { get; set; }
        public string JobId { get; set; }
        public string JobGroup { get; set; }
        public int IsStatus { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
    }

    /// <summary>
    /// 任务日志
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public class TasksQzLogDto
    {
    }
}