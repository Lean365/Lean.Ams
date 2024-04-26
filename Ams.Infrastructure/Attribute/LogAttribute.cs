using Ams.Infrastructure.Enums;

namespace Ams.Infrastructure.Attribute
{
    /// <summary>
    /// 自定义操作
    /// 日志记录注解
    /// @Author Lean365(Davis.Ching)
    /// @Date 2004-02-01
    /// </summary>
    public class LogAttribute : System.Attribute
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        public BusinessType BusinessType { get; set; }

        /// <summary>
        /// 是否保存请求数据
        /// </summary>
        public bool IsSaveRequestData { get; set; } = true;

        /// <summary>
        /// 是否保存返回数据
        /// </summary>
        public bool IsSaveResponseData { get; set; } = true;

        /// <summary>
        /// 构造函数
        /// </summary>
        public LogAttribute()
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        public LogAttribute(string name)
        {
            Title = name;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="businessType"></param>
        /// <param name="saveRequestData"></param>
        /// <param name="saveResponseData"></param>
        public LogAttribute(string name, BusinessType businessType, bool saveRequestData = true, bool saveResponseData = true)
        {
            Title = name;
            BusinessType = businessType;
            IsSaveRequestData = saveRequestData;
            IsSaveResponseData = saveResponseData;
        }
    }
}