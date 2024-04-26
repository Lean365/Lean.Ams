using System;

namespace Ams.Infrastructure
{
    /// <summary>
    /// 日志类
    /// @Author Lean365(Davis.Ching)
    /// @Date 2004-02-01
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 输出日志信息
        /// </summary>
        /// <param name="color"></param>
        /// <param name="msg"></param>
        public static void WriteLine(ConsoleColor color = ConsoleColor.Black, string msg = "")
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{DateTime.Now} {msg}");
            Console.ResetColor();
        }
    }
}