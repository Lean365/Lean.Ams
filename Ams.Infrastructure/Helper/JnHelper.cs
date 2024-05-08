using System;
using System.IO;
using JinianNet.JNTemplate;

namespace Ams.Infrastructure.Helper
{
    /// <summary>
    /// Jn模板帮助类
    /// 极念模板引擎
    /// @author Lean365(Davis Ching)
    /// @date 2024-02-01
    /// </summary>
    public class JnHelper
    {
        /// <summary>
        /// 读取Jn模板
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="tplName"></param>
        /// <returns></returns>
        public static ITemplate ReadTemplate(string dirPath, string tplName)
        {
            string path = Environment.CurrentDirectory;
            string fullName = Path.Combine(path, "wwwroot", dirPath, tplName);
            if (File.Exists(fullName))
            {
                return Engine.LoadTemplate(fullName);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"未找到路径{fullName}");
            return null;
        }
    }
}