using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ams.Infrastructure
{
    /// <summary>
    /// 跨域扩展
    /// @author Lean365(Davis Ching)
    /// @date 2024-02-01
    /// </summary>
    public static class CorsExtension
    {
        /// <summary>
        /// 跨域配置
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddCors(this IServiceCollection services, IConfiguration configuration)
        {
            var corsUrls = configuration.GetSection("corsUrls").Get<string[]>();

            //配置跨域
            services.AddCors(c =>
            {
                c.AddPolicy("Policy", policy =>
                {
                    policy.WithOrigins(corsUrls ?? Array.Empty<string>())
                    .AllowAnyHeader()//允许任意头
                    .AllowCredentials()//允许cookie
                    .AllowAnyMethod();//允许任意方法
                });
            });
        }
    }
}