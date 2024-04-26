using System;

namespace Ams.Infrastructure.Extensions
{
    /// <summary>
    /// 异常扩展类
    /// @Author Lean365(Davis.Ching)
    /// @Date 2004-02-01
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 原始异常
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception GetOriginalException(this Exception ex)
        {
            if (ex.InnerException == null) return ex;

            return ex.InnerException.GetOriginalException();
        }
    }
}