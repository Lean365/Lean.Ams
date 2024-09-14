using System;
using System.Text;
using Ams.Infrastructure.Helper;
using JinianNet.JNTemplate;
using Microsoft.Extensions.DependencyInjection;

namespace Ams.Infrastructure.WebExtensions
{
    public static class LogoExtension
    {
        public static void AddLogo(this IServiceCollection services)
        {
            int consoleWidth = Console.WindowWidth;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            var contentTpl = JnHelper.ReadTemplate("", "logo.txt");
            var content = contentTpl?.Render();
            var url = AppSettings.GetConfig("urls");
            Console.WriteLine(string.Format("{0," + consoleWidth + "}", content));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            //输出为UTF8编码格式
            Console.OutputEncoding = Encoding.UTF8;
            //string urlSource = "https://leansoft365.github.io/";
            //string textSource = "\ud83c\udfe0\u0020\u70b9\u51fb\u8fd9\u91cc\u8bbf\u95ee\u7f51\u7ad9";
            //string linkSource = $"\u001B]8;;{urlSource}\u001B\\{textSource}\u001B]8;;\u001B\\";
            //Console.WriteLine(linkSource);

            string urlDocument = "https://leansoft365.github.io/";
            string textDocument = "\uD83D\uDE80\u0020\u0044\u006f\u0063\u0075\u006d\u0065\u006e\u0074\u0028\u6587\u6863\u0029";
            string linkDocument = $"\u001B]8;;{urlDocument}\u001B\\{textDocument}\u001B]8;;\u001B\\";

            Console.WriteLine(linkDocument);

            string urlReward = "https://leansoft365.github.io/docs/others/donate.html";
            string textReward = "\ud83d\udcb0\u0020\u0052\u0065\u0077\u0061\u0072\u0064\u0028\u6253\u8d4f\u0029";
            string linkReward = $"\u001B]8;;{urlReward}\u001B\\{textReward}\u001B]8;;\u001B\\";
            Console.WriteLine(linkReward);

            //string urlUniApp = "http://demo.leansoft365.cn/h5";
            //string textUniApp = "\ud83d\udcf1\u0020\u004d\u006f\u0062\u0069\u006c\u0065\u0028\u79fb\u52a8\u7aef\u0029";
            //string linkUniApp = $"\u001B]8;;{urlUniApp}\u001B\\{textUniApp}\u001B]8;;\u001B\\";
            //Console.WriteLine(linkUniApp);

            string urlSwagger = $"{url}/swagger/index.html";
            string textSwagger = "\uD83D\uDEE0\u0020\u0020\u0053\u0077\u0061\u0067\u0067\u0065\u0072\u0028\u540e\u53f0\u0041\u0070\u0069\u63a5\u53e3\u0029";
            string linkSwagger = $"\u001B]8;;{urlSwagger}\u001B\\{textSwagger}\u001B]8;;\u001B\\";
            Console.WriteLine(linkSwagger);

            string urlInit = $"{url}/common/InitSeedData";
            string textInit = "\u2699\ufe0f\u0020\u0049\u006e\u0069\u0074\u0028\u521d\u59cb\u5316\u0029";
            string linkInit = $"\u001B]8;;{urlInit}\u001B\\{textInit}\u001B]8;;\u001B\\";
            Console.WriteLine(linkInit);
        }
    }
}