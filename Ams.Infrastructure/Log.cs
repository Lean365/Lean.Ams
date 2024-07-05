using System;

namespace Ams.Infrastructure
{
    /// <summary>
    /// 输出日志
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
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