namespace Ams.Kernel.Model.Dto.Monitor
{
    /// <summary>
    /// 任务日志
    /// 查询对象
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class TasksQzLogQueryDto
    {
        /// <summary>
        /// 查询字符串
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// 任务ID
        /// </summary>
        public string JobId { get; set; }

        /// <summary>
        /// 任务组
        /// </summary>
        public string JobGroup { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int IsStated { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
    }

    /// <summary>
    /// 任务日志
    /// 输入输出对象
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class TasksQzLogDto
    {
    }
}