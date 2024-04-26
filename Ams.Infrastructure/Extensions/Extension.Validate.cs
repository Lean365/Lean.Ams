//using Microsoft.AspNetCore.Http;

namespace Ams.Infrastructure.Extensions
{
    /// <summary>
    /// 验证对象扩展
    /// @Author Lean365(Davis.Ching)
    /// @Date 2004-02-01
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this object value)
        {
            if (value != null && !string.IsNullOrEmpty(value.ParseToString()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 判断对象是否不为空
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(this object value)
        {
            return !IsEmpty(value);
        }

        /// <summary>
        /// 判断对象是否为空或者0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrZero(this object value)
        {
            if (value == null || value.ParseToString().Trim() == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public static bool IsAjaxRequest(this HttpRequest request)
        //{
        //    if (request == null)
        //        throw new ArgumentNullException("request");

        //    if (request.Headers != null)
        //        return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        //    return false;
        //}
    }
}