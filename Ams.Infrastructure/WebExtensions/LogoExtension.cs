using Ams.Infrastructure.Helper;
using JinianNet.JNTemplate;
using Microsoft.Extensions.DependencyInjection;
using System;
using Ams.Infrastructure.Apps;
using Ams.Infrastructure.Model;
namespace Ams.Infrastructure.WebExtensions
{
    public static class LogoExtension
    {
        public static void AddLogo(this IServiceCollection services)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            var contentTpl = JnHelper.ReadTemplate("", "logo.txt");
            var content = contentTpl?.Render();
            var url = "http://localhost:8888" ;


            //var context = App.HttpContext;
            Console.WriteLine(content);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("网站: https://lean365.github.io/");
            Console.WriteLine("文档：https://leansoft365.github.io/");
            Console.WriteLine("源码：https://gitee.com/leansoft365/Lean365.Ams");

            Console.WriteLine($"Swagger地址：{url}/swagger/index.html");
            Console.WriteLine($"初始化数据：{url}/common/InitSeedData");
        }
    }
}
