using System;

namespace Ams.Infrastructure.Extensions
{
    /// <summary>
    /// Extension methods for Exception class.
    /// @author Lean365(Davis Ching)
    /// @date 2024-02-01
    /// </summary>
    public static partial class Extensions
    {
        public static Exception GetOriginalException(this Exception ex)
        {
            if (ex.InnerException == null) return ex;

            return ex.InnerException.GetOriginalException();
        }
    }
}