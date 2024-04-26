using Ams.Model.System.Dto;
using Microsoft.AspNetCore.SignalR;

namespace Ams.WebApi.Controllers.Routine
{
    /// <summary>
    /// 通知公告
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [Route("routine/notice")]
    [ApiExplorerSettings(GroupName = "routine")]
    public class NoticeController : BaseController
    {
        /// <summary>
        /// 通知公告接口
        /// </summary>
        private readonly INoticeService _NoticeService;

        private readonly IHubContext<MessageHub> _hubContext;

        public NoticeController(INoticeService NoticeService, IHubContext<MessageHub> hubContext)
        {
            _NoticeService = NoticeService;
            _hubContext = hubContext;
        }

        /// <summary>
        /// 查询通知公告列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("queryNotice")]
        public IActionResult QuerysNotice([FromQuery] NoticeQueryDto parm)
        {
            var predicate = Expressionable.Create<Notice>();

            predicate = predicate.And(m => m.IsStated == 0);
            var response = _NoticeService.GetPages(predicate.ToExpression(), parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询通知公告列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "routine:notice:list")]
        public IActionResult QueryNotice([FromQuery] NoticeQueryDto parm)
        {
            PagedInfo<Notice> response = _NoticeService.GetPageList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询通知公告详情
        /// </summary>
        /// <param name="NoticeId"></param>
        /// <returns></returns>
        [HttpGet("{NoticeId}")]
        public IActionResult GetNotice(int NoticeId)
        {
            var response = _NoticeService.GetFirst(x => x.NoticeId == NoticeId);

            return SUCCESS(response);
        }

        /// <summary>
        /// 添加通知公告
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "routine:notice:add")]
        [Log(Title = "发布通告", BusinessType = BusinessType.INSERT)]
        public IActionResult AddNotice([FromBody] NoticeDto parm)
        {
            var modal = parm.Adapt<Notice>().ToCreate(HttpContext);

            int result = _NoticeService.Insert(modal, it => new
            {
                it.NoticeTitle,
                it.NoticeType,
                it.NoticeContent,
                it.IsStated,
                it.Remark,
                it.Create_by,
                it.Create_time
            });

            return SUCCESS(result);
        }

        /// <summary>
        /// 更新人员通知公告
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "routine:notice:edit")]
        [Log(Title = "修改公告", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateNotice([FromBody] NoticeDto parm)
        {
            var model = parm.Adapt<Notice>().ToUpdate(HttpContext);
            model.Update_by = HttpContext.GetName();
            var response = _NoticeService.Update(w => w.NoticeId == model.NoticeId, it => new Notice()
            {
                NoticeTitle = model.NoticeTitle,
                NoticeType = model.NoticeType,
                NoticeContent = model.NoticeContent,
                IsStated = model.IsStated,
                Remark = model.Remark,
                Update_by = HttpContext.GetName(),
                Update_time = DateTime.Now
            });

            return SUCCESS(response);
        }

        /// <summary>
        /// 发送通知公告
        /// </summary>
        /// <returns></returns>
        [HttpPut("send/{NoticeId}")]
        [ActionPermissionFilter(Permission = "routine:notice:edit")]
        [Log(Title = "发送通知公告", BusinessType = BusinessType.OTHER)]
        public IActionResult SendNotice(int NoticeId = 0)
        {
            if (NoticeId <= 0)
            {
                throw new CustomException("请求实体不能为空");
            }
            var response = _NoticeService.GetFirst(x => x.NoticeId == NoticeId);
            if (response != null && response.IsStated == 0)
            {
                _hubContext.Clients.All.SendAsync(HubsConstant.ReceiveNotice, response.NoticeTitle, response.NoticeContent);
            }
            return SUCCESS(response);
        }

        /// <summary>
        /// 删除通知公告
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{ids}")]
        [ActionPermissionFilter(Permission = "routine:notice:delete")]
        [Log(Title = "通知公告", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteNotice(string ids)
        {
            int[] idsArr = Tools.SpitIntArrary(ids);
            if (idsArr.Length <= 0) { return ToResponse(ApiResult.Error($"删除失败Id 不能为空")); }

            var response = _NoticeService.Delete(idsArr);

            return SUCCESS(response);
        }

        /// <summary>
        /// 导出通知公告
        /// </summary>
        /// <returns></returns>
        [Log(Title = "通知公告", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "routine:notice:export")]
        public IActionResult Export([FromQuery] NoticeQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _NoticeService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "通知公告", "通知公告");
            return ExportExcel(result.Item2, result.Item1);
        }
    }
}