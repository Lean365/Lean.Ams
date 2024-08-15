using Ams.Model.Routine.Dto;
using Ams.Service.Routine.IRoutineService;
using Microsoft.AspNetCore.Mvc;

namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 邮件模板
    /// API控制器
    /// @author Lean365(Davis.Ching)
    /// @date 2024-05-20
    /// </summary>
    [Verify]
    [Route("routine/email/tpl")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class EmailTplController : BaseController
    {
        /// <summary>
        /// 邮件模板接口
        /// </summary>
        private readonly IEmailTplService _EmailTplService;

        public EmailTplController(IEmailTplService EmailTplService)
        {
            _EmailTplService = EmailTplService;
        }

        /// <summary>
        /// 查询邮件模板列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:emailtpl:list")]
        public IActionResult QueryEmailTpl([FromQuery] EmailTplQueryDto parm)
        {
            var response = _EmailTplService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询邮件模板详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public IActionResult GetEmailTpl(int Id)
        {
            var response = _EmailTplService.GetInfo(Id);

            var info = response.Adapt<EmailTpl>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加邮件模板
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:emailtpl:add")]
        [Log(Title = "邮件模板", BusinessType = BusinessType.ADD)]
        public IActionResult AddEmailTpl([FromBody] EmailTplDto parm)
        {
            var modal = parm.Adapt<EmailTpl>().ToCreate(HttpContext);

            var response = _EmailTplService.AddEmailTpl(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新邮件模板
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:emailtpl:edit")]
        [Log(Title = "邮件模板", BusinessType = BusinessType.EDIT)]
        public IActionResult UpdateEmailTpl([FromBody] EmailTplDto parm)
        {
            var modal = parm.Adapt<EmailTpl>().ToUpdate(HttpContext);
            var response = _EmailTplService.UpdateEmailTpl(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除邮件模板
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "routine:emailtpl:delete")]
        [Log(Title = "邮件模板", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteEmailTpl(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _EmailTplService.Delete(idsArr);

            return ToResponse(response);
        }
    }
}