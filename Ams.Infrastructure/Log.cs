using System;

namespace Ams.Infrastructure
{
    /// <summary>
    /// 日志类
    /// @author Lean365(Davis Ching)
    /// @date 2024-02-01
    /// </summary>
    public class Log
    {
        public static void WriteLine(ConsoleColor color = ConsoleColor.Black, string msg = "")
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{DateTime.Now} {msg}");
            Console.ResetColor();
        }
    }
}