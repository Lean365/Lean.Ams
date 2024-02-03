using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SqlSugar;
using Ams.Kernel.Filters;
using Ams.Model;
using Ams.Kernel.Signalr;
using Ams.Infrastructure.CustomException;
using Ams.Infrastructure.WebExtensions;
using Ams.Kernel.Model.Routine;
using Ams.Kernel.Model.Dto.Routine;
using Ams.Kernel.Services.IService.Routine;
namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 系统通知
    /// API控制器
    /// @Author: (Lean365:Davis.Cheng)
    /// @Date: (2023-12-15)
    /// </summary>
    [Verify]
    [Route("routine/notices")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class NoticesController : BaseController
    {
        /// <summary>
        /// 通知公告表接口
        /// </summary>
        private readonly INoticesService _NoticesService;
        private readonly IHubContext<MessageHub> _hubContext;

        public NoticesController(INoticesService NoticesService, IHubContext<MessageHub> hubContext)
        {
            _NoticesService = NoticesService;
            _hubContext = hubContext;
        }

        /// <summary>
        /// 查询通知公告表列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("queryNotice")]
        public IActionResult QueryNotice([FromQuery] NoticesQueryDto parm)
        {
            var predicate = Expressionable.Create<Notices>();

            predicate = predicate.And(m => m.IsState == 0);
            var response = _NoticesService.GetPages(predicate.ToExpression(), parm);
            return SUCCESS(response, TIME_FORMAT_YYYMMDD);
        }

        /// <summary>
        /// 查询通知公告表列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:notices:list")]
        public IActionResult QueryNotices([FromQuery] NoticesQueryDto parm)
        {
            PagedInfo<Notices> response = _NoticesService.GetPageList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询通知公告表详情
        /// </summary>
        /// <param name="NoticeId"></param>
        /// <returns></returns>
        [HttpGet("{NoticeId}")]
        public IActionResult GetNotices(int NoticeId)
        {
            var response = _NoticesService.GetFirst(x => x.NoticeId == NoticeId);

            return SUCCESS(response);
        }

        /// <summary>
        /// 添加通知公告表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:notices:add")]
        [Log(Title = "发布通告", BusinessType = BusinessType.INSERT)]
        public IActionResult AddNotices([FromBody] NoticesDto parm)
        {
            var modal = parm.Adapt<Notices>().ToCreate(HttpContext);

            int result = _NoticesService.Insert(modal, it => new
            {
                it.NoticeTitle,
                it.NoticeType,
                it.NoticeContent,
                it.IsState,
                it.NoticeFileurl,
                it.Remark,
                it.Create_by,
                it.Create_time
            });

            return SUCCESS(result);
        }

        /// <summary>
        /// 更新通知公告表
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:notices:update")]
        [Log(Title = "修改公告", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateNotices([FromBody] NoticesDto parm)
        {
            var model = parm.Adapt<Notices>().ToUpdate(HttpContext);
            model.Update_by = HttpContext.GetName();
            var response = _NoticesService.Update(w => w.NoticeId == model.NoticeId, it => new Notices()
            {
                NoticeTitle = model.NoticeTitle,
                NoticeType = model.NoticeType,
                NoticeContent = model.NoticeContent,
                NoticeFileurl = model.NoticeFileurl,
                IsState = model.IsState,
                Remark = model.Remark,
                Update_by = HttpContext.GetName(),
                Update_time = DateTime.Now
            });

            return SUCCESS(response);
        }
        /// <summary>
        /// 发送通知公告表
        /// </summary>
        /// <returns></returns>
        [HttpPut("send/{NoticeId}")]
        [ActionPermissionFilter(Permission = "routine:notices:update")]
        [Log(Title = "发送通知公告", BusinessType = BusinessType.OTHER)]
        public IActionResult SendNotice(int NoticeId = 0)
        {
            if (NoticeId <= 0)
            {
                throw new CustomizeException("请求实体不能为空");
            }
            var response = _NoticesService.GetFirst(x => x.NoticeId == NoticeId);
            if (response != null && response.IsState == 0)
            {
                _hubContext.Clients.All.SendAsync(HubsConstant.ReceiveNotice, response.NoticeTitle, response.NoticeContent);
            }
            return SUCCESS(response);
        }

        /// <summary>
        /// 删除通知公告表
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "routine:notices:delete")]
        [Log(Title = "通知公告", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteNotices(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _NoticesService.Delete(idsArr);

            return SUCCESS(response);
        }
    }
}