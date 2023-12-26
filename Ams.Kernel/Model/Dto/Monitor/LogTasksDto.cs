using System;
using Ams.Model;
namespace Ams.Kernel.Model.Dto.Monitor
{
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

    public class LogTasksDto
    {

    }
}
