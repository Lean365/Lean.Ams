using System.Web;

namespace Ams.WebApi.Controllers
{
    /// <summary>
    /// 微信公众号
    /// API控制器
    /// @Author: (Lean365:Davis.Cheng)
    /// @Date: (2023-12-15)
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiExplorerSettings(GroupName = "system")]
    [AllowAnonymous]
    public class WxOpenController : BaseController
    {
        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [Log(Title = "获取微信签名")]
        [HttpGet]
        public IActionResult GetSignature(string url = "")
        {
            url = HttpUtility.UrlDecode(url);
            var appId = AppSettings.App(new string[] { "WxOpen", "AppID" });
            var noncestr = Guid.NewGuid().ToString().Replace("-", "");
            var timestamp = DateTimeHelper.GetUnixTimeSeconds(DateTime.Now);
            var ticketResult = WxHelper.GetTicket();
            if (appId.IsEmpty()) return ToResponse(ResultCode.CUSTOM_ERROR, "appId未配置");
            if (ticketResult?.errcode != 0)
            {
                return ToResponse(ResultCode.CUSTOM_ERROR, "获取配置失败");
            }

            var signature = WxHelper.GetSignature(ticketResult.ticket, timestamp.ToString(), noncestr, url);

            return SUCCESS(new { appId, signature, noncestr, timestamp, url });
        }
    }
}