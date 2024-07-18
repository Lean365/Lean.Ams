using System;
using Ams.Infrastructure.Helper;
using JinianNet.JNTemplate;
using Microsoft.Extensions.DependencyInjection;

namespace Ams.Infrastructure
{
    public static class LogoExtension
    {
        public static void AddLogo(this IServiceCollection services)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            var contentTpl = JnHelper.ReadTemplate("", "logo.txt");
            var content = contentTpl?.Render();
            var url = AppSettings.GetConfig("urls");
            Console.WriteLine(content);
            Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("🎉源码地址: https://github.com/Lean365/Lean.Ams");
            Console.WriteLine("📖官方文档：https://leansoft365.github.io/");
            Console.WriteLine("💰打赏作者：https://leansoft365.github.io/docs/others/donate.html");
            //Console.WriteLine("📱移动端体验：http://demo.leansoft365.cn/h5");
            Console.WriteLine($"Swagger地址：{url}/swagger/index.html");
            Console.WriteLine($"初始化种子数据地址：{url}/common/InitSeedData");
        }
    }
}