using System.Reflection;
using Ams.WebApi.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Ams.WebApi.Extensions
{
    public static class SwaggerExtension
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="app"></param>
        public static void UseSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    var url = $"{httpReq.Scheme}://{httpReq.Host.Value}";
                    var referer = httpReq.Headers["Referer"].ToString();
                    if (referer.Contains(GlobalConstant.DevApiProxy))
                        url = referer[..(referer.IndexOf(GlobalConstant.DevApiProxy, StringComparison.InvariantCulture) + GlobalConstant.DevApiProxy.Length - 1)];
                    swaggerDoc.Servers =
                        new List<OpenApiServer>
                        {
                            new OpenApiServer
                            {
                                Url = url
                            }
                        };
                });
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("accounting/swagger.json", "会计核算(accounting)");
                c.SwaggerEndpoint("advertising/swagger.json", "广告(advertising)");
                c.SwaggerEndpoint("logistics/swagger.json", "后勤(logistics)");
                c.SwaggerEndpoint("monitor/swagger.json", "系统监控(monitor)");
                c.SwaggerEndpoint("routine/swagger.json", "日常办公(routine)");
                c.SwaggerEndpoint("statistics/swagger.json", "统计(statistics)");
                c.SwaggerEndpoint("system/swagger.json", "系统管理(system)");
                c.SwaggerEndpoint("tool/swagger.json", "系统工具(tool)");
                c.SwaggerEndpoint("v1/swagger.json", "其它");
                c.DocExpansion(DocExpansion.None); //->修改界面打开时自动折叠
            });
        }

        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            //IWebHostEnvironment hostEnvironment = services.BuildServiceProvider().GetRequiredService<IWebHostEnvironment>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("accounting", new OpenApiInfo
                {
                    Title = "Lean.Ams Api",
                    Version = "v1",
                    Description = "\ud83e\uddee\u0020会计核算(accounting)",
                    Contact = new OpenApiContact { Name = "\uD83c\udfe0\u0020\u0044\u006f\u0063\u0075\u006d\u0065\u006e\u0074\u0028\u6587\u6863\u0029", Url = new Uri("https://leansoft365.github.io/") }
                });
                c.SwaggerDoc("advertising", new OpenApiInfo
                {
                    Title = "Lean.Ams Api",
                    Version = "v1",
                    Description = "\ud83c\udf0f\u0020广告(advertising)",
                    Contact = new OpenApiContact { Name = "\uD83c\udfe0\u0020\u0044\u006f\u0063\u0075\u006d\u0065\u006e\u0074\u0028\u6587\u6863\u0029", Url = new Uri("https://leansoft365.github.io/") }
                });
                c.SwaggerDoc("logistics", new OpenApiInfo
                {
                    Title = "Lean.Ams Api",
                    Version = "v1",
                    Description = "\ud83c\udfed\u0020后勤(logistics)",
                    Contact = new OpenApiContact { Name = "\uD83c\udfe0\u0020\u0044\u006f\u0063\u0075\u006d\u0065\u006e\u0074\u0028\u6587\u6863\u0029", Url = new Uri("https://leansoft365.github.io/") }
                });

                c.SwaggerDoc("monitor", new OpenApiInfo
                {
                    Title = "Lean.Ams Api",
                    Version = "v1",
                    Description = "\ud83e\uddf0\u0020系统监控(monitor)",
                    Contact = new OpenApiContact { Name = "\uD83c\udfe0\u0020\u0044\u006f\u0063\u0075\u006d\u0065\u006e\u0074\u0028\u6587\u6863\u0029", Url = new Uri("https://leansoft365.github.io/") }
                });
                c.SwaggerDoc("routine", new OpenApiInfo
                {
                    Title = "Lean.Ams Api",
                    Version = "v1",
                    Description = "\ud83d\udcbc\u0020日常办公(routine)",
                    Contact = new OpenApiContact { Name = "\uD83c\udfe0\u0020\u0044\u006f\u0063\u0075\u006d\u0065\u006e\u0074\u0028\u6587\u6863\u0029", Url = new Uri("https://leansoft365.github.io/") }
                });
                c.SwaggerDoc("statistics", new OpenApiInfo
                {
                    Title = "Lean.Ams Api",
                    Version = "v1",
                    Description = "\ud83d\udcc8\u0020统计(statistics)",
                    Contact = new OpenApiContact { Name = "\uD83c\udfe0\u0020\u0044\u006f\u0063\u0075\u006d\u0065\u006e\u0074\u0028\u6587\u6863\u0029", Url = new Uri("https://leansoft365.github.io/") }
                });
                c.SwaggerDoc("system", new OpenApiInfo
                {
                    Title = "Lean.Ams Api",
                    Version = "v1",
                    Description = "\ud83d\udee0\ufe0f\u0020系统管理(system)",
                    Contact = new OpenApiContact { Name = "\uD83c\udfe0\u0020\u0044\u006f\u0063\u0075\u006d\u0065\u006e\u0074\u0028\u6587\u6863\u0029", Url = new Uri("https://leansoft365.github.io/") }
                });

                c.SwaggerDoc("tool", new OpenApiInfo
                {
                    Title = "Lean.Ams Api",
                    Version = "v1",
                    Description = "\u2699\ufe0f\u0020系统工具(tool)",
                    Contact = new OpenApiContact { Name = "\uD83c\udfe0\u0020\u0044\u006f\u0063\u0075\u006d\u0065\u006e\u0074\u0028\u6587\u6863\u0029", Url = new Uri("https://leansoft365.github.io/") }
                });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Lean.Ams Api",
                    Version = "v1",
                    Description = "\ud83d\ude80\u0020其他(other)",
                    Contact = new OpenApiContact { Name = "\uD83c\udfe0\u0020\u0044\u006f\u0063\u0075\u006d\u0065\u006e\u0074\u0028\u6587\u6863\u0029", Url = new Uri("https://leansoft365.github.io/") }
                });
                try
                {
                    //var tempPath = hostEnvironment.ContentRootPath;
                    //添加文档注释
                    var baseDir = AppContext.BaseDirectory;
                    c.IncludeXmlComments(Path.Combine(baseDir, "Ams.Model.xml"), true);
                    c.IncludeXmlComments(Path.Combine(baseDir, "Ams.Statistics.xml"), true);
                    c.IncludeXmlComments(Path.Combine(baseDir, "Ams.Service.xml"), true);
                    c.IncludeXmlComments(Path.Combine(baseDir, "Ams.WebApi.xml"), true);

                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(baseDir, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("swagger 文档加载失败" + ex.Message);
                }

                //参考文章：http://www.zyiz.net/tech/detail-134965.html
                //需要安装包Swashbuckle.AspNetCore.Filters
                // 开启权限小锁 需要在对应的Action上添加[Authorize]才能看到
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                //在header 中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme,
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "请输入Login接口返回的Token，前置Bearer。示例：Bearer {Token}",
                        Name = "Authorization",//jwt默认的参数名称,
                        Type = SecuritySchemeType.ApiKey, //指定ApiKey
                        BearerFormat = "JWT",//标识承载令牌的格式 该信息主要是出于文档目的
                        Scheme = JwtBearerDefaults.AuthenticationScheme//授权中要使用的HTTP授权方案的名称
                    });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new List<string>()
                    }
                });

                try
                {
                    //判断接口归于哪个分组
                    c.DocInclusionPredicate((docName, apiDescription) =>
                    {
                        if (docName == "v1")
                        {
                            //当分组为NoGroup时，只要没加特性的都属于这个组
                            return string.IsNullOrEmpty(apiDescription.GroupName);
                        }
                        else
                        {
                            return apiDescription.GroupName == docName;
                        }
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            });
        }
    }
}