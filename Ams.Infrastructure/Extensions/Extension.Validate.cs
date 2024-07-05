//using Microsoft.AspNetCore.Http;

namespace Ams.Infrastructure.Extensions
{
    /// <summary>
    /// 验证扩展类.
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public static partial class Extensions
    {
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

        public static bool IsNotEmpty(this object value)
        {
            return !IsEmpty(value);
        }

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