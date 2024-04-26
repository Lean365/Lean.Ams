using Microsoft.Extensions.Options;

//创建时间：2023-11-20
namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 已发邮件
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [Route("routine/email/sentitems")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class SentItemsController : BaseController
    {
        /// <summary>
        /// 已发邮件接口
        /// </summary>
        private readonly ISentItemsService _SentItemsService;

        private OptionsSetting OptionsSetting;

        public SentItemsController(
            ISentItemsService SentItemsService,
            IOptions<OptionsSetting> options)
        {
            _SentItemsService = SentItemsService;
            OptionsSetting = options.Value;
        }

        /// <summary>
        /// 查询已发邮件列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:sentitems:list")]
        public IActionResult QuerySentItems([FromQuery] SentItemsQueryDto parm)
        {
            var response = _SentItemsService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询已发邮件详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "routine:sentitems:query")]
        public IActionResult GetSentItems(long Id)
        {
            var response = _SentItemsService.GetInfo(Id);

            var info = response.Adapt<SentItemsDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 批量发送邮件(从记录发送)
        /// </summary>
        /// <returns></returns>
        [HttpPost("sendEmail")]
        [ActionPermissionFilter(Permission = "tool:email:send")]
        [Log(Title = "批量邮件发送", BusinessType = BusinessType.INSERT)]
        public IActionResult SendEmail([FromBody] SentItemsDto dto)
        {
            if (dto.IdArr.Length <= 0) { return ToResponse(ApiResult.Error($"发送失败Id 不能为空")); }
            int count = 0;

            foreach (var item in dto.IdArr)
            {
                var response = _SentItemsService.GetInfo(item);
                MailOptions mailOptions = OptionsSetting.MailOptions.Find(x => x.FromName == response.FromName);
                if (mailOptions == null || string.IsNullOrEmpty(mailOptions.Password))
                {
                    continue;
                }
                MailHelper mailHelper = new(mailOptions);
                string[] toUsers = response.ToEmails.Split(",", StringSplitOptions.RemoveEmptyEntries);

                string result = mailHelper.SendMail(toUsers, response.Subject, "", response.FileUrl, response.EmailContent);
                count += _SentItemsService.Update(x => x.Id == item, x => new SentItems()
                {
                    IsSend = 1,
                    SendTime = DateTime.Now,
                    SendResult = result
                });
            }
            return SUCCESS(count);
        }

        /// <summary>
        /// 删除已发邮件
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "routine:sentitems:delete")]
        [Log(Title = "已发邮件", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSentItems(string ids)
        {
            long[] idsArr = Tools.SpitLongArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _SentItemsService.Delete(idsArr);

            return ToResponse(response);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="sendEmailVo">请求参数接收实体</param>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "tool:email:send")]
        [Log(Title = "发送邮件")]
        [HttpPost("/common/SendEmail")]
        public IActionResult SendEmail([FromBody] SendEmailDto sendEmailVo)
        {
            if (sendEmailVo == null)
            {
                return ToResponse(ApiResult.Error($"请求参数不完整"));
            }
            MailOptions mailOptions = OptionsSetting.MailOptions.Find(x => x.FromName == sendEmailVo.FromName);
            if (mailOptions == null || string.IsNullOrEmpty(mailOptions.Password))
            {
                return ToResponse(ApiResult.Error($"请配置邮箱信息"));
            }

            MailHelper mailHelper = new(mailOptions);

            string[] toUsers = sendEmailVo.ToUser.Split(",", StringSplitOptions.RemoveEmptyEntries);
            string result = string.Empty;
            if (sendEmailVo.IsSend)
            {
                result = mailHelper.SendMail(toUsers, sendEmailVo.Subject, sendEmailVo.Content, sendEmailVo.FileUrl, sendEmailVo.HtmlContent);
            }
            sendEmailVo.FromEmail = mailOptions.FromEmail;
            _SentItemsService.AddSentItems(sendEmailVo, result);
            //logger.Info($"发送邮件{JsonConvert.SerializeObject(sendEmailVo)}, 结果{result}");

            return SUCCESS(result);
        }
    }
}