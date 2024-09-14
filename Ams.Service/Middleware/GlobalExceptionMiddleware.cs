using System.Text.Encodings.Web;
using Ams.Common;
using Ams.Infrastructure.IPTools;
using Ams.Infrastructure.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using NLog;
using textJson = System.Text.Json;

namespace Ams.Service.Middleware
{
    /// <summary>
    /// 全局异常处理中间件
    /// 调用 app.UseMiddlewareGlobalExceptionMiddleware>();
    /// </summary>
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IOperLogService OperLogService;

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly textJson.JsonSerializerOptions options = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNamingPolicy = textJson.JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        /// <summary>
        ///
        /// </summary>
        /// <param name="next"></param>
        /// <param name="OperLog"></param>
        public GlobalExceptionMiddleware(RequestDelegate next, IOperLogService OperLog)
        {
            this.next = next;
            OperLogService = OperLog;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            LogLevel logLevel = LogLevel.Info;
            int code = (int)ResultCode.GLOBAL_ERROR;
            string msg;
            string error = string.Empty;
            bool notice = true;
            //自定义异常
            if (ex is CustomException customException)
            {
                code = customException.Code;
                msg = customException.Message;
                error = customException.LogMsg;
                notice = customException.Notice;
            }
            else if (ex is ArgumentException)//参数异常
            {
                code = (int)ResultCode.PARAM_ERROR;
                msg = ex.Message;
            }
            else
            {
                msg = "服务器好像出了点问题，请联系系统管理员...";
                error = $"{ex.Message}";
                logLevel = LogLevel.Error;
                context.Response.StatusCode = 500;
            }

            ApiResult apiResult = new(code, msg);
#if DEBUG
            if (logLevel == LogLevel.Error)
            {
                apiResult.Add("error", "请在issue里面寻找答案或者官方文档查看常见问题：https://github.com/Lean365/Lean.Ams/issues");
            }
#endif
            string responseResult = textJson.JsonSerializer.Serialize(apiResult, options);
            string ip = HttpContextExtension.GetClientUserIp(context);
            var ip_info = IpTool.Search(ip);

            OperLog OperLog = new()
            {
                IsStatus = 1,
                OperIp = ip,
                OperUrl = HttpContextExtension.GetRequestUrl(context),
                RequestMethod = context.Request.Method,
                JsonResult = responseResult,
                ErrorMsg = string.IsNullOrEmpty(error) ? msg : error,
                OperName = HttpContextExtension.GetName(context),
                OperLocation = ip_info.Province + " " + ip_info.City,
                OperTime = DateTime.Now,
                OperParam = HttpContextExtension.GetRequestValue(context, context.Request.Method)
            };
            var endpoint = GetEndpoint(context);
            if (endpoint != null)
            {
                var logAttribute = endpoint.Metadata.GetMetadata<LogAttribute>();
                if (logAttribute != null)
                {
                    OperLog.BusinessType = (int)logAttribute.BusinessType;
                    OperLog.Title = logAttribute?.Title;
                    OperLog.OperParam = logAttribute.IsSaveRequestData ? OperLog.OperParam : "";
                    OperLog.JsonResult = logAttribute.IsSaveResponseData ? OperLog.JsonResult : "";
                }
            }
            LogEventInfo ei = new(logLevel, "GlobalExceptionMiddleware", error)
            {
                Exception = ex,
                Message = error
            };
            ei.Properties["status"] = 1;//走正常返回都是通过走GlobalExceptionFilter不通过
            ei.Properties["jsonResult"] = responseResult;
            ei.Properties["requestParam"] = OperLog.OperParam;
            ei.Properties["user"] = OperLog.OperName;

            Logger.Log(ei);
            context.Response.ContentType = "text/json;charset=utf-8";
            await context.Response.WriteAsync(responseResult, System.Text.Encoding.UTF8);

            string errorMsg = $"> 操作人：{OperLog.OperName}" +
                $"\n> 操作地区：{OperLog.OperIp}({OperLog.OperLocation})" +
                $"\n> 操作模块：{OperLog.Title}" +
                $"\n> 操作地址：{OperLog.OperUrl}" +
                $"\n> 错误信息：{msg}\n\n> {error}";

            OperLogService.InsertOperlog(OperLog);
            if (!notice) return;
            WxNoticeHelper.SendMsg("系统异常", errorMsg, msgType: WxNoticeHelper.MsgType.markdown);
        }

        public static Endpoint GetEndpoint(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return context.Features.Get<IEndpointFeature>()?.Endpoint;
        }
    }
}